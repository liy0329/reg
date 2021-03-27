using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTHIS.common;
using MTREG.common;

namespace MTREG.ihsp
{
    public partial class FrmIhspChkRetSetle : Form
    {
        public FrmIhspChkRetSetle()
        {
            InitializeComponent();
        }

        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        Inhospital inhospital = new Inhospital();

        /// <summary>
        /// 查找方法
        /// </summary>
        private void searchMethod()
        {
            string patienttype = "";
            inhospital.Name = this.tbxName.Text.Trim().ToString();
            inhospital.Ihspcode = this.tbxIhspcode.Text.Trim().ToString();
            inhospital.Indate = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            inhospital.Outdate = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            inhospital.Hspcard = this.tbxHspcard.Text.Trim().ToString();
            if (this.cmbPatienttype.Text == "--全部--")
            {
                patienttype = "";
            }
            else
            {
                patienttype = this.cmbPatienttype.Text.Trim().ToString();
            }
            inhospital.Patienttype = patienttype;
            DataTable dt = billIhspcost.appSearch(inhospital);
            dgvInhospital.DataSource = dt;
        }

        /// <summary>
        /// 审批按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApprover_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmUnlocked frmUnlocked = new FrmUnlocked();
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            frmUnlocked.getAppSource(id);
            frmUnlocked.ShowDialog();
            if (frmUnlocked.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmApprover_Load(object sender, EventArgs e)
        {
            #region 下拉菜单绑定数据
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                var drd = dtp.NewRow();
                drd["Id"] = 0;
                drd["Name"] = "--全部--";
                dtp.Rows.InsertAt(drd, 0);
                this.cmbPatienttype.DataSource = dtp;
            }
            #endregion
            searchMethod();
            #region  dgvInhospital单元格标题设置
            this.dgvInhospital.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvInhospital.Columns["ihspcode"].Width = 100;
            this.dgvInhospital.Columns["ihspname"].HeaderText = "姓名";
            this.dgvInhospital.Columns["ihspname"].Width = 80;
            this.dgvInhospital.Columns["deparname"].HeaderText = "科室";
            this.dgvInhospital.Columns["deparname"].Width = 100;
            this.dgvInhospital.Columns["indate"].HeaderText = "入院时间";
            this.dgvInhospital.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvInhospital.Columns["indate"].Width = 120;
            this.dgvInhospital.Columns["outdate"].HeaderText = "出院时间";
            this.dgvInhospital.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvInhospital.Columns["outdate"].Width = 120;
            this.dgvInhospital.Columns["patienttype"].HeaderText = "患者类型";
            this.dgvInhospital.Columns["patienttype"].Width = 80;
            this.dgvInhospital.Columns["prepamt"].HeaderText = "预交合计";
            this.dgvInhospital.Columns["prepamt"].Width = 100;
            this.dgvInhospital.Columns["feeamt"].HeaderText = "费用合计";
            this.dgvInhospital.Columns["feeamt"].Width = 100;
            this.dgvInhospital.Columns["hspcard"].HeaderText = "卡号";
            this.dgvInhospital.Columns["hspcard"].Width = 100;
            this.dgvInhospital.Columns["balanceamt"].HeaderText = "剩余金额";
            this.dgvInhospital.Columns["balanceamt"].Visible = false;
            this.dgvInhospital.Columns["id"].HeaderText = "id";
            this.dgvInhospital.Columns["id"].Visible = false;
            this.dgvInhospital.Columns["sex"].HeaderText = "sex";
            this.dgvInhospital.Columns["sex"].Visible = false;
            this.dgvInhospital.Columns["age"].HeaderText = "age";
            this.dgvInhospital.Columns["age"].Visible = false;
            this.dgvInhospital.Columns["doctorname"].HeaderText = "doctor";
            this.dgvInhospital.Columns["doctorname"].Visible = false;
            #endregion
            this.dgvInhospital.ReadOnly = true;
            this.dgvInhospital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod();
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbxHspcard.Text = "";
            this.tbxIhspcode.Text = "";
            this.tbxName.Text = "";
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");            
            cmbPatienttype.SelectedValue = 0;
            searchMethod();
        }

        /// <summary>
        ///dgv选择内容变化时 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInhospital_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count != 0)
            {
                //string ihspcode = dgvInhospital.SelectedRows[0].Cells["ihspcode"].Value.ToString();
                string ihsp_id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
                DataTable datatable = billIhspcost.costSearch(ihsp_id);
                this.dgvIhspCost.DataSource = datatable;
                #region  dgvIhspCost单元格标题设置
                this.dgvIhspCost.Columns["item_id"].HeaderText = "编号";
                this.dgvIhspCost.Columns["item_id"].Width = 120;
                this.dgvIhspCost.Columns["itemtypename"].HeaderText = "项目类别";
                this.dgvIhspCost.Columns["itemtypename"].Width = 150;
                this.dgvIhspCost.Columns["name"].HeaderText = "名称";
                this.dgvIhspCost.Columns["name"].Width = 130;
                this.dgvIhspCost.Columns["spec"].HeaderText = "规格";
                this.dgvIhspCost.Columns["spec"].Width = 130;
                this.dgvIhspCost.Columns["prc"].HeaderText = "单价";
                this.dgvIhspCost.Columns["prc"].Width = 110;
                this.dgvIhspCost.Columns["num"].HeaderText = "数量";
                this.dgvIhspCost.Columns["num"].Width = 110;
                this.dgvIhspCost.Columns["departname"].HeaderText = "执行科室";
                this.dgvIhspCost.Columns["departname"].Width = 140;
                this.dgvIhspCost.Columns["unit"].HeaderText = "单位";
                this.dgvIhspCost.Columns["unit"].Visible = false;
                this.dgvIhspCost.Columns["fee"].HeaderText = "费用";
                this.dgvIhspCost.Columns["fee"].Visible = false;
                this.dgvIhspCost.Columns["insurefee"].HeaderText = "报销金额";
                this.dgvIhspCost.Columns["insurefee"].Visible = false;
                this.dgvIhspCost.Columns["insurclass"].HeaderText = "医保等级";
                this.dgvIhspCost.Columns["insurclass"].Visible = false;
                this.dgvIhspCost.Columns["selffee"].HeaderText = "账户支付";
                this.dgvIhspCost.Columns["selffee"].Visible = false;
                this.dgvIhspCost.Columns["realfee"].HeaderText = "实际金额";
                this.dgvIhspCost.Columns["realfee"].Visible = false;

                #endregion
                double total = 0;
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    //total += double.Parse(DataTool.FormatData(datatable.Rows[i]["realfee"].ToString(), "2"));
                    total += DataTool.Getdouble(datatable.Rows[i]["realfee"].ToString());
                }
                lblTotal.Text = DataTool.FormatData(total.ToString(), "2") + "元";
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("起始日期不能大于当前日期");
                this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
                return;
            }
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:起始日期不能大于截止日期！");
                this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
                this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
                return;
            }
        }
        /// <summary>
        /// 焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspChkRetSetle_Activated(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:起始日期不能大于截止日期！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
        }
    }
}
