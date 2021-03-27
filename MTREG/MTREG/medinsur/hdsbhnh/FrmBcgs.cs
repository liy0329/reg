using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.medinsur.hdsbhnh.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmBcgs : Form
    {
        Header header = new Header();
        DataTable dt_area = new DataTable();
        DataTable dt_bclb = new DataTable();
        BllSnhMethod bllSnhMethod = new BllSnhMethod();
        public FrmBcgs()
        {
            InitializeComponent();
        }

        private void FrmBcgs_Load(object sender, EventArgs e)
        {
            dt_area = bllSnhMethod.area();
            cmbArea.DataSource = dt_area;
            cmbArea.ValueMember = "id";
            cmbArea.DisplayMember = "name";

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", ""));
            items.Add(new ListItem("1", "补偿日期"));
            items.Add(new ListItem("2", "发票日期"));
            cmbRqfl.DisplayMember = "Text";
            cmbRqfl.ValueMember = "Value";
            cmbRqfl.DataSource = items;
            cmbRqfl.SelectedValue = "0";
        }

        /// <summary>
        /// 区域变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectedValueChanged(object sender, EventArgs e)
        {
            header.Password = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["password"].ToString().Trim();
            header.Weburl = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["weburl"].ToString().Trim();
            header.TargetOrg = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["uniquekey"].ToString().Trim(); ;
            header.Trustpointcode = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["trustpointcode"].ToString().Trim();
            header.Name = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["name"].ToString().Trim();
            header.Identity = Convert.ToInt32(dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["id"].ToString().Trim());
            initBclb(header.Identity.ToString());
            this.cmbBcfl.Text = "";
        }
        /// <summary>
        /// 初始化补偿类别
        /// </summary>
        /// <param name="qyid"></param>
        public void initBclb(string qyid)
        {
            string sql = "select * from insur_hdsbh_sysdict where qyid ='" + qyid + "' and insurcode='25' ";//创建查询语句
            dt_bclb = BllMain.Db.Select(sql).Tables[0];
            this.cmbBcfl.DataSource = dt_bclb;
            this.cmbBcfl.DisplayMember = "name";
            this.cmbBcfl.ValueMember = "sn";
        }
        //补偿类别快捷查询
        private void bclbcx(string qyid)
        {
            string sql = "select * from insur_hdsbh_sysdict where trustpointcode_id = " + qyid + " and insurcode='25' "+" and (name like '" + this.cmbBcfl.Text + "%' or pincode like '" + this.cmbBcfl.Text + "%')";//创建查询语句
            dt_bclb = BllMain.Db.Select(sql).Tables[0];
            cmbBcfl.DataSource = dt_bclb;
            cmbBcfl.DisplayMember = "name";
            cmbBcfl.ValueMember = "sn";
        }

        /// <summary>
        /// 补偿分类模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBcfl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                bclbcx(header.Identity.ToString());
                cmbBcfl.SelectAll();
            }
        }

        /// <summary>
        /// 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTj_Click(object sender, EventArgs e)
        {
            dgvBcgs.Rows.Clear();
            if (cmbArea.Text == "")
            {
                MessageBox.Show("请选择区域", "提示信息");
                cmbArea.Focus();
                return;
            }
            if (cmbRqfl.Text == "")
            {
                MessageBox.Show("请选择日期分类！", "提示信息");
                cmbRqfl.Focus();
                return;
            }
            string[] param = new string[5];
            param[0] = this.cmbRqfl.SelectedValue.ToString();
            string qsrq = this.dtpKssj.Text;

            param[1] = DateTime.Parse(qsrq).ToString("yyyy-MM-ddTHH-mm-ss");
            string jsrq = (this.dtpJssj.Text) + " 23:59:59";
            param[2] = DateTime.Parse(jsrq).ToString("yyyy-MM-ddTHH-mm-ss");
            if (cmbBcfl.Text != "")
            {
                param[3] = dt_bclb.Rows[cmbBcfl.SelectedIndex]["dm"].ToString();
            }

            BcgsXml bcgsXml = new BcgsXml();
            BhnhReturn retdata = bcgsXml.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show("失败信息：" + retdata.Ret_mesg, "提示信息");
                return;
            }
            //string data = System.IO.File.ReadAllText(@"d:test.xml");
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            if (ds.Tables["item"] == null)
            {
                MessageBox.Show("当前补偿分类病人数为 0 ", "提示信息");
                return;
            }
            //dataGridView1.DataSource = ds.Tables["body"];
            for (int j = 0; j < ds.Tables["item"].Rows.Count; ++j)
            {
                dgvBcgs.Rows.Add();
                DataGridViewRow row = dgvBcgs.Rows[dgvBcgs.Rows.Count - 1];
                for (int k = 0; k < ds.Tables["item"].Columns.Count - 1; ++k)
                {
                    row.Cells[ds.Tables["item"].Columns[k].ColumnName].Value
                        = ds.Tables["item"].Rows[j][ds.Tables["item"].Columns[k].ColumnName];
                }                
            }
            double hjZFSFY = 0;
            double hjBCFSFY = 0;
            double hjBCJE = 0;
            double hjDEEC = 0;
            double hjJtzhcdje = 0;
            double hjDsfbcbxje = 0;
            double hjDsfdejzje = 0;
            double hjTszdjbbcje = 0;
            for (int i = 0; i < dgvBcgs.Rows.Count; i++)
            {
                string sex = dgvBcgs.Rows[i].Cells["D504_04"].Value.ToString();
                if (sex == "1")
                {
                    dgvBcgs.Rows[i].Cells["D504_04"].Value = "男";
                }
                else if (sex == "2")
                {
                    dgvBcgs.Rows[i].Cells["D504_04"].Value = "女";
                }
                hjZFSFY += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_03"].Value);
                hjBCFSFY += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_19"].Value);
                hjBCJE += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_24"].Value);
                if (dgvBcgs.Rows[i].Cells["D506_95"].Value.ToString() != "" && dgvBcgs.Rows[i].Cells["D506_95"].Value.ToString() != null)
                {
                    hjDEEC += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_95"].Value);
                }
                hjJtzhcdje += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_57"].Value);
                hjDsfbcbxje += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_59"].Value);
                hjDsfdejzje += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_60"].Value);
                hjTszdjbbcje += Convert.ToDouble(dgvBcgs.Rows[i].Cells["D506_58"].Value);
            }
            testBoxHj.Text = "            总发生费用" + hjZFSFY.ToString() + ",  住院可报总费用" + hjBCFSFY.ToString() + ", 补偿金额" + hjBCJE.ToString() + ",   大额二次" + hjDEEC.ToString();
            this.tbx_hj.Text = "           家庭账户冲抵金额" + hjJtzhcdje.ToString() + ", 第三方补充保险补偿" + hjDsfbcbxje.ToString() + ", 第三方救助" + hjDsfdejzje.ToString() + ",特殊重大疾病" + hjTszdjbbcje.ToString();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
