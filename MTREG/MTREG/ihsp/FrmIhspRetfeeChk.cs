using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bo;
using MTREG.ihsp.bll;
using MTREG.common;

namespace MTREG.ihsp
{
    public partial class FrmIhspRetfeeChk : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        IhspRetapp ihspRetapp = new IhspRetapp();
        public FrmIhspRetfeeChk()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspRetapp_Load(object sender, EventArgs e)
        {
            #region combox设置
            this.cmbStatus.Items.Add("--全部--");
            this.cmbStatus.Items.Add("已审核");
            this.cmbStatus.Items.Add("已退费");
            this.cmbStatus.Text = "已审核";

            var dtde = billCmbList.departList();
            this.cmbDepart.ValueMember = "id";
            this.cmbDepart.DisplayMember = "name";
            var drd = dtde.NewRow();
            drd["Id"] = 0;
            drd["Name"] = "--全部--";
            dtde.Rows.InsertAt(drd, 0);
            this.cmbDepart.DataSource = dtde;
            #endregion
            searchMethod();
            #region  dgvIhspRetapp单元格标题设置
            this.dgvIhspRetapp.Columns["billcode"].HeaderText = "退费订单号";
            this.dgvIhspRetapp.Columns["billcode"].Width = 100;
            this.dgvIhspRetapp.Columns["departname"].HeaderText = "申请科室";
            this.dgvIhspRetapp.Columns["departname"].Width = 100;
            this.dgvIhspRetapp.Columns["doctorname"].HeaderText = "申请人";
            this.dgvIhspRetapp.Columns["doctorname"].Width = 150;
            this.dgvIhspRetapp.Columns["appdate"].HeaderText = "申请时间";
            this.dgvIhspRetapp.Columns["appdate"].Width = 150;
            this.dgvIhspRetapp.Columns["appdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhspRetapp.Columns["appdoname"].HeaderText = "确认人";
            this.dgvIhspRetapp.Columns["appdoname"].Width = 100;
            this.dgvIhspRetapp.Columns["approvedate"].HeaderText = "确认时间";
            this.dgvIhspRetapp.Columns["approvedate"].Width = 100;
            this.dgvIhspRetapp.Columns["approvedate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhspRetapp.Columns["status"].HeaderText = "申请状态";
            this.dgvIhspRetapp.Columns["status"].Width = 150;
            this.dgvIhspRetapp.Columns["id"].HeaderText = "id";
            this.dgvIhspRetapp.Columns["id"].Visible = false;
            #endregion
            this.dgvIhspRetapp.ReadOnly = true;
            this.dgvIhspRetapp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void searchMethod()
        {
            string depart = "";
            if (this.cmbDepart.Text == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cmbDepart.Text.Trim().ToString();
            }
            ihspRetapp.Appdep_id = depart;
            //用来记录起始时间
            ihspRetapp.Approvedate = dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            //用来记录截止时间
            ihspRetapp.Chkdate = dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            switch (cmbStatus.Text)
            {
                case "--全部--": ihspRetapp.Status = ""; break;
                case "已审核": ihspRetapp.Status = IhspRetAppStatus.CHK.ToString(); break;
                case "已退费": ihspRetapp.Status = IhspRetAppStatus.DO.ToString(); break;
            }
            DataTable dataTable = billIhspcost.ihspRetApp(ihspRetapp);
            dgvIhspRetapp.DataSource = dataTable;
        }


        /// <summary>
        /// 查询按钮
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
            this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.cmbStatus.Text = "已审核";
            this.cmbDepart.SelectedValue = 0;
            searchMethod();
        }

        /// <summary>
        /// 双击退费订单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIhspRetapp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmIhspRetappdet frmIhspRetappdet = new FrmIhspRetappdet();
            string status = dgvIhspRetapp.SelectedRows[0].Cells["status"].Value.ToString();
            if (status == "已退费")
            {
                MessageBox.Show("该患者已退费");
                return;
            }
            string id = dgvIhspRetapp.SelectedRows[0].Cells["id"].Value.ToString();
            string appdep = dgvIhspRetapp.SelectedRows[0].Cells["departname"].Value.ToString();
            string billcode = dgvIhspRetapp.SelectedRows[0].Cells["billcode"].Value.ToString();
            frmIhspRetappdet.getSource(id,appdep,billcode);
            frmIhspRetappdet.ShowDialog();
            if (frmIhspRetappdet.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("起始日期不能大于当前日期");
                dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:截止日期不能小于开始日期！");
                dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:截止日期不能小于于起始日期！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
        }
    }
}
