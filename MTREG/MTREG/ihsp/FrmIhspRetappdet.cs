using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.common;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.ihsp
{
    public partial class FrmIhspRetappdet : Form
    {
        BillIhspcost billIhspcost = new BillIhspcost();
        string retAppId;
        int flag;
        public FrmIhspRetappdet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取退费确认中的信息
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id,string appdep,string billcode)
        {
            this.retAppId = id;
            lblBillcode.Text = billcode;
            lblDepart.Text = appdep;
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspRetappdet_Load(object sender, EventArgs e)
        {
            DataTable datatable = billIhspcost.ihspRetAppdet(retAppId);
            if (datatable.Rows.Count > 0)
            {
                dgvRetappdet.DataSource = datatable;
                #region  dgvIhspRetapp单元格标题设置
                this.dgvRetappdet.Columns["item_id"].HeaderText = "编号";
                this.dgvRetappdet.Columns["item_id"].Width = 100;
                this.dgvRetappdet.Columns["ihspcode"].HeaderText = "住院号";
                this.dgvRetappdet.Columns["ihspcode"].Width = 100;
                this.dgvRetappdet.Columns["sickname"].HeaderText = "姓名";
                this.dgvRetappdet.Columns["sickname"].Width = 100;
                this.dgvRetappdet.Columns["itemtypename"].HeaderText = "项目类别";
                this.dgvRetappdet.Columns["itemtypename"].Width = 100;
                this.dgvRetappdet.Columns["detname"].HeaderText = "项目名称";
                this.dgvRetappdet.Columns["detname"].Width = 100;
                this.dgvRetappdet.Columns["spec"].HeaderText = "规格";
                this.dgvRetappdet.Columns["spec"].Width = 100;
                this.dgvRetappdet.Columns["unit"].HeaderText = "单位";
                this.dgvRetappdet.Columns["unit"].Width = 100;
                this.dgvRetappdet.Columns["prc"].HeaderText = "单价";
                this.dgvRetappdet.Columns["prc"].Width = 100;
                this.dgvRetappdet.Columns["num"].HeaderText = "数量";
                this.dgvRetappdet.Columns["num"].Width = 100;
                this.dgvRetappdet.Columns["chargedate"].HeaderText = "缴费时间";
                this.dgvRetappdet.Columns["chargedate"].Width = 100;
                this.dgvRetappdet.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                this.dgvRetappdet.Columns["ihsp_costdet_id"].HeaderText = "费用表外键";
                this.dgvRetappdet.Columns["ihsp_costdet_id"].Visible = false;
                #endregion
            }
            double total = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                double num = double.Parse(DataTool.FormatData(datatable.Rows[i]["num"].ToString(), "2"));
                double prc = double.Parse(DataTool.FormatData(datatable.Rows[i]["prc"].ToString(), "2"));
                total += num*prc;
            }
            lblTotal.Text = DataTool.FormatData(total.ToString(), "2") + "元";
        }

        /// <summary>
        ///确定按钮 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "";
            string status = IhspRetAppStatus.DO.ToString();
            //MessageBox.Show("修改退费申请单失败!");
            sql += billIhspcost.upRetappdet(retAppId, status);               
            status=CostCharged.RET.ToString();
            // MessageBox.Show("添加红冲记录失败!");
            sql+= billIhspcost.inCostdet(retAppId);
            //MessageBox.Show("修改费用表失败!");  
            sql+=billIhspcost.upCostdet(retAppId,status);
            flag = BllMain.Db.Update(sql);
            if (flag < 0)
            {
                MessageBox.Show("退费失败!");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
