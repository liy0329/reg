using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using MTREG.common;

namespace MTREG.clinic
{
    public partial class FrmUnlockRcpManage : Form
    {
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllUnlockRcpManage bllUnlockRcpManage = new BllUnlockRcpManage();
        public FrmUnlockRcpManage()
        {
            InitializeComponent();
        }

        private void FrmClinicRetFeeChk_Load(object sender, EventArgs e)
        {
            //加载下拉列表
            loadSelectDrop();
            //加载表格
            loadDataGrid();
            
        }

        private void loadSelectDrop()
        {
            //科室
            var dt = bllRecipelCharge.getRegDepartInfo();
            this.cmbDepart.ValueMember = "Id";
            this.cmbDepart.DisplayMember = "Name";
            var dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "--全部--";
            dt.Rows.InsertAt(dr, 0);
            this.cmbDepart.DataSource = dt;

            var dtdoc = bllRecipelCharge.getDoctorInfo(cmbDepart.SelectedValue.ToString());
            this.cmbDoctor.ValueMember = "Id";
            this.cmbDoctor.DisplayMember = "Name";
            var drdoc = dtdoc.NewRow();
            drdoc["Id"] = 0;
            drdoc["Name"] = "--全部--";
            dtdoc.Rows.InsertAt(drdoc, 0);
            this.cmbDoctor.DataSource = dtdoc;

            cmbDoctor.SelectedValue = 0;
        }

        private void loadDataGrid()
        {
            getDgvInvoiceData();
            #region updateHeaderText
            dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoice.Font = new Font("宋体", 11);
            dgvInvoice.Columns["regbill"].HeaderText = "门诊号";
            dgvInvoice.Columns["regbill"].Width = 130;
            dgvInvoice.Columns["regbill"].DisplayIndex = 0;
            dgvInvoice.Columns["invbill"].HeaderText = "发票号";
            dgvInvoice.Columns["invbill"].Width = 130;
            dgvInvoice.Columns["invbill"].DisplayIndex = 1;
            dgvInvoice.Columns["name"].HeaderText = "姓名";
            dgvInvoice.Columns["name"].Width = 110;
            dgvInvoice.Columns["name"].DisplayIndex = 2;
            dgvInvoice.Columns["sex"].HeaderText = "性别";
            dgvInvoice.Columns["sex"].Width = 70;
            dgvInvoice.Columns["sex"].DisplayIndex = 3;
            dgvInvoice.Columns["dptname"].HeaderText = "科室";
            dgvInvoice.Columns["dptname"].Width = 90;
            dgvInvoice.Columns["dptname"].DisplayIndex = 4;
            dgvInvoice.Columns["dctname"].HeaderText = "医生";
            dgvInvoice.Columns["dctname"].Width = 70;
            dgvInvoice.Columns["dctname"].DisplayIndex = 5;
            dgvInvoice.Columns["realfee"].HeaderText = "金额";
            dgvInvoice.Columns["realfee"].Width = 90;
            dgvInvoice.Columns["realfee"].DisplayIndex = 6;
            dgvInvoice.Columns["chargedate"].HeaderText = "收费时间";
            dgvInvoice.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvInvoice.Columns["chargedate"].Width = 150;
            dgvInvoice.Columns["chargedate"].DisplayIndex = 7;
            dgvInvoice.Columns["hspcard"].HeaderText = "卡号";
            dgvInvoice.Columns["hspcard"].Width = 150;
            dgvInvoice.Columns["hspcard"].DisplayIndex =8;
            dgvInvoice.Columns["age"].Visible = false;
            dgvInvoice.Columns["id"].Visible = false;
            dgvInvoice.Columns["idcard"].Visible = false;
            dgvInvoice.ReadOnly = true;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvInvoice.Rows.Count > 0)
            {
                dgvInvoice.Rows[0].Selected = true;
            }
            #endregion
        }
 
        private void getDgvInvoiceData()
        {
            ChargeManage chargeManage = new ChargeManage();
            chargeManage.PatientName = tbxPatientName.Text.Trim();
            chargeManage.HspCard = tbxHspcard.Text.Trim();
            chargeManage.Depart_id = cmbDepart.SelectedValue.ToString();
            chargeManage.Doctor_id = cmbDoctor.SelectedValue.ToString();
            chargeManage.StartDate = this.dtpStime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            chargeManage.EndDate = this.dtpEtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            dgvInvoice.DataSource = bllUnlockRcpManage.getChargeData(chargeManage);
        }
        /// <summary>
        /// 当点击回车键时，焦点在控件中一次传递
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
      {
            if ((ActiveControl is TextBox || ActiveControl is ComboBox || ActiveControl is DateTimePicker) &&
                keyData == Keys.Enter)
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择需要解锁的项!");
                return;
            }
            string invoiceId = "";
            if (dgvInvoice.Rows.Count > 0)
            {
                FrmUnlockRcp frmUnlockRcp = new FrmUnlockRcp();
                invoiceId = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                if (dgvInvoice.SelectedRows.Count != 0)
                {
                    frmUnlockRcp.ChargeManagePatientInfo.PatientName = dgvInvoice.SelectedRows[0].Cells["name"].Value.ToString();
                    frmUnlockRcp.ChargeManagePatientInfo.Sex = dgvInvoice.SelectedRows[0].Cells["sex"].Value.ToString();
                    frmUnlockRcp.ChargeManagePatientInfo.Hspcard = dgvInvoice.SelectedRows[0].Cells["hspcard"].Value.ToString();
                    frmUnlockRcp.ChargeManagePatientInfo.Depart = dgvInvoice.SelectedRows[0].Cells["dptname"].Value.ToString();
                    frmUnlockRcp.ChargeManagePatientInfo.Doctor = dgvInvoice.SelectedRows[0].Cells["dctname"].Value.ToString();
                    frmUnlockRcp.ChargeManagePatientInfo.Idcard = dgvInvoice.SelectedRows[0].Cells["idcard"].Value.ToString();
                }
                frmUnlockRcp.prtGetsource();
                frmUnlockRcp.getDgvCliniCost(invoiceId);
                frmUnlockRcp.ShowDialog();
                getDgvInvoiceData();
            }   
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDgvInvoiceData();
        }

        private void cmbDepart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //医生
            var dtd = bllRecipelCharge.getDoctorInfo(cmbDepart.SelectedValue.ToString());
            this.cmbDoctor.ValueMember = "Id";
            this.cmbDoctor.DisplayMember = "Name";
            var drd = dtd.NewRow();
            drd["Id"] = "0";
            drd["Name"] = "--全部--";
            dtd.Rows.InsertAt(drd, 0);
            this.cmbDoctor.DataSource = dtd;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbxHspcard.Text = "";
            tbxPatientName.Text = "";
            cmbDepart.SelectedValue = 0;
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");            
            getDgvInvoiceData();
        }

    }
}
