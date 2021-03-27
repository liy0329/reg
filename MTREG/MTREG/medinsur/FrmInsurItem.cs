using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.bll;
using MTREG.common;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.bo;
using MTHIS.main.bll;

namespace MTREG.medinsur
{
    public partial class FrmInsurItem : Form
    {
        BllInsurMethod bllInsurMethod = new BllInsurMethod();
        public FrmInsurItem()
        {
            InitializeComponent();
        }

        private void FrmInsurItem_Load(object sender, EventArgs e)
        {            
            init();
            selectMethod();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            dgvArea.Visible = false;
            DataTable dtInsur= bllInsurMethod.insurtypeInfo();            
            cmbInsurtype.DisplayMember = "name";
            cmbInsurtype.ValueMember = "id";
            cmbInsurtype.DataSource = dtInsur;

            tbxAreaCode.Text = "--请先选择接口类型--";
        }

        private void dgvArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvArea.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvArea.CurrentRow != null)
                {
                    tbxAreaCode.Text = dgvArea.SelectedRows[0].Cells["name"].ToString();
                    dgvArea.Visible = false;
                }
            }
        }

        private void tbxAreaCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = bllInsurMethod.areaInfo(cmbInsurtype.SelectedValue.ToString(), tbxAreaCode.Text);
                dgvArea.DataSource = dt;
                this.dgvArea.Columns["areacode"].HeaderText = "地区编码";
                this.dgvArea.Columns["name"].HeaderText = "地区名称";
                dgvArea.ReadOnly = true;
                dgvArea.Visible = true;
                dgvArea.Focus();
                dgvArea.Rows[0].Selected=true;
            }
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectMethod();
        }
        /// <summary>
        /// 查询
        /// </summary>
        public void selectMethod()
        {
            string info = tbxInfo.Text;
            string insurtype_id = cmbInsurtype.SelectedValue.ToString();
            string areacode = "";
            if (tbxAreaCode.Text != "--请先选择接口类型--"&&string.IsNullOrEmpty(tbxAreaCode.Text))
            {
                areacode = tbxAreaCode.Text;
            }
            DataTable dt= bllInsurMethod.insurItemInfo(info, insurtype_id, areacode);
            dgvInsurItem.DataSource = dt;
            this.dgvInsurItem.Columns["insurname"].HeaderText = "接口名称";
            this.dgvInsurItem.Columns["standcode"].HeaderText = "His内码";
            this.dgvInsurItem.Columns["itemname"].HeaderText = "目录名称";
            this.dgvInsurItem.Columns["insurcode"].HeaderText = "医保编码";
            this.dgvInsurItem.Columns["spec"].HeaderText = "规格";
            this.dgvInsurItem.Columns["unit"].HeaderText = "单位";
            this.dgvInsurItem.Columns["insurclass"].HeaderText = "医保等级";
            this.dgvInsurItem.Columns["ratioihsp"].HeaderText = "报销比例";
            this.dgvInsurItem.Columns["islimitprc"].HeaderText = "是否限价";
            this.dgvInsurItem.Columns["updateat"].HeaderText = "更新时间";
            dgvInsurItem.ReadOnly=true;
        }

        private void cmbInsurtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbxAreaCode.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 下载医保目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dt = bllInsurMethod.getInsurInfo(cmbInsurtype.SelectedValue.ToString(),tbxAreaCode.Text);
            InsurItemInfo insurItemInfo = new InsurItemInfo();
            if (bllInsurMethod.getInsurKeyname(cmbInsurtype.SelectedValue.ToString()) == CostInsurtypeKeyname.GZSNH.ToString())
            {
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                string weburl=dt.Rows[0]["weburl"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string password = dt.Rows[0]["password"].ToString();
                string areacode = dt.Rows[0]["areacode"].ToString();
                string insuritemtype = dt.Rows[0]["insuritemtype"].ToString();
                DataTable dtItem= bllGzsnhMethod.feeClassDown(weburl, username, password, areacode);
                string sql = "";
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {

                    insurItemInfo.Cost_insurtype_id = cmbInsurtype.SelectedValue.ToString();
                    insurItemInfo.Insurcode = dtItem.Rows[i][0].ToString(); ;
                    insurItemInfo.Insuritemtype = insuritemtype;
                    insurItemInfo.Insurname = dtItem.Rows[i][1].ToString();
                    sql += bllInsurMethod.inInsurItem(insurItemInfo);

                }
                if (BllMain.Db.Update(sql) < 0)
                {
                    MessageBox.Show("保存下载数据失败!");
                    return;
                }
            }
        }
    }
}
