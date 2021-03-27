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
using MTHIS.common;
using MTREG.medinsur.hdyb.dor;
using MTREG.dte;
using MTREG.medinsur.sjzsyb;

namespace MTREG.clinic
{
    public partial class FrmClinicCostManage_cw : Form
    {
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllClinicCostManage bllChargeManage = new BllClinicCostManage();
        public FrmClinicCostManage_cw()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmChargeManage_Load(object sender, EventArgs e)
        {
               
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            //BillSysBase.controlAutoSize(this);
            //加载下拉列表
            loadSelectDrop();
            //加载表格
            loadDataGrid();
            gettj();
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

           //收费员
            var dtcharge = bllRecipelCharge.getChargebyInfo();
            this.cmbChargeby.ValueMember = "Id";
            this.cmbChargeby.DisplayMember = "Name";
            var drcharge = dtcharge.NewRow();
            drcharge["Id"] = 0;
            drcharge["Name"] = "--全部--";
            dtcharge.Rows.InsertAt(drcharge, 0);
            this.cmbChargeby.DataSource = dtcharge;
            //是否解锁
            cbxIsLocked.Items.Add("--全部--");
            cbxIsLocked.Items.Add("已解锁");
            cbxIsLocked.Items.Add("未解锁");
            cbxIsLocked.Text = "--全部--";
            //cbxIsLocked.Text = "已解锁";

            //是否退费
            cmbIsret.Items.Add("--全部--");
            cmbIsret.Items.Add("已退费");
            cmbIsret.Items.Add("计费");
            cmbIsret.Text = "--全部--";
           
        }

        private void loadDataGrid()
        {
            try
            {
                getDgvInvoiceData();
                #region updateHeaderText
                dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvInvoice.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                dgvInvoice.Columns["regbill"].HeaderText = "门诊号";
                dgvInvoice.Columns["regbill"].Width = (int)(130 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["regbill"].DisplayIndex = 0;
                dgvInvoice.Columns["invbill"].HeaderText = "发票号";
                dgvInvoice.Columns["invbill"].Width = (int)(80 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["invbill"].DisplayIndex = 1;
                dgvInvoice.Columns["regname"].HeaderText = "姓名";
                dgvInvoice.Columns["regname"].Width = (int)(110 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["regname"].DisplayIndex = 2;
                dgvInvoice.Columns["sex"].HeaderText = "性别";
                dgvInvoice.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["sex"].DisplayIndex = 3;

                dgvInvoice.Columns["dctname"].HeaderText = "收费员";
                dgvInvoice.Columns["dctname"].Width = (int)(70 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["dctname"].DisplayIndex = 4;

                dgvInvoice.Columns["realfee"].HeaderText = "金额";
                dgvInvoice.Columns["realfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInvoice.Columns["realfee"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["realfee"].DisplayIndex = 5;
                dgvInvoice.Columns["chargedate"].HeaderText = "收费时间";
                dgvInvoice.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgvInvoice.Columns["chargedate"].Width = (int)(200 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["chargedate"].DisplayIndex = 6;
                dgvInvoice.Columns["hspcard"].HeaderText = "卡号";
                dgvInvoice.Columns["hspcard"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["hspcard"].DisplayIndex = 7;
                dgvInvoice.Columns["charged"].HeaderText = "计费状态";
                dgvInvoice.Columns["charged"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["charged"].DisplayIndex = 8;
                dgvInvoice.Columns["dptname"].HeaderText = "科室";
                dgvInvoice.Columns["dptname"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["dptname"].DisplayIndex = 10;
                this.dgvInvoice.Columns["patienttype"].HeaderText = "患者类型";
                this.dgvInvoice.Columns["patienttype"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["patienttype"].DisplayIndex = 9;
                dgvInvoice.Columns["ys"].HeaderText = "医生";
                dgvInvoice.Columns["ys"].Width = (int)(70 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["ys"].DisplayIndex = 11;
                dgvInvoice.Columns["bxfs"].HeaderText = "报销方式";
                dgvInvoice.Columns["bxfs"].Width = (int)(70 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["bxfs"].DisplayIndex = 12;
                dgvInvoice.Columns["outby"].HeaderText = "退费员";
                dgvInvoice.Columns["outby"].Width = (int)(70 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["outby"].DisplayIndex = 13;
                dgvInvoice.Columns["outdate"].HeaderText = "退费时间";
                dgvInvoice.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dgvInvoice.Columns["outdate"].Width = (int)(160 * ProgramGlobal.WidthScale);
                dgvInvoice.Columns["outdate"].DisplayIndex = 14;
                dgvInvoice.Columns["age"].Visible = false;
                dgvInvoice.Columns["isregist"].Visible = false;
                dgvInvoice.Columns["id"].Visible = false;
                dgvInvoice.Columns["idcard"].Visible = false;
                dgvInvoice.Columns["regist_id"].Visible = false;
                dgvInvoice.Columns["bas_patienttype_id"].Visible = false;
                dgvInvoice.Columns["displaycolor"].Visible = false;
                dgvInvoice.Columns["ybsfsc"].Visible = false;
                dgvInvoice.ReadOnly = true;
                dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInvoice.MultiSelect = false;
                if (dgvInvoice.Rows.Count > 0)
                {
                   dgvInvoice.Rows[0].Selected = true;
                }
            }
            catch (Exception ex) 
            {
            }
            #endregion
        }

        private void getDgvInvoiceData()
        {
            ChargeManage chargeManage = new ChargeManage();
            chargeManage.PatientName = tbxPatientName.Text.Trim();
            chargeManage.HspCard = tbxHspcard.Text.Trim();
            chargeManage.Depart_id = cmbDepart.SelectedValue.ToString();
            chargeManage.Chargeby = cmbChargeby.SelectedValue.ToString();
            chargeManage.StartDate = this.dtpStime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            chargeManage.EndDate = this.dtpEtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (cbxIsLocked.Text.ToString() == "--全部--")
            {
                chargeManage.Islock = "";
            }
            else if (cbxIsLocked.Text.ToString() == "已解锁")
                chargeManage.Islock = "Y";
            else if (cbxIsLocked.Text.ToString() == "未解锁")
                chargeManage.Islock = "N";

            if (cmbIsret.Text.ToString() == "--全部--")
            {
                chargeManage.Isret = "";
            }
            else if (cmbIsret.Text.ToString() == "已退费")
                chargeManage.Isret = "RET";
            else if (cmbIsret.Text.ToString() == "计费")
                chargeManage.Isret = "CHAR";
            this.dgvInvoice.DataSource=bllChargeManage.getInvoiceList(chargeManage);
            for (int i = 0; i < this.dgvInvoice.Rows.Count; i++)
            {
                string displaycolor = dgvInvoice.Rows[i].Cells["displaycolor"].Value.ToString();
                if (dgvInvoice.Rows[i].Cells["bxfs"].Value.ToString() == "" || dgvInvoice.Rows[i].Cells["displaycolor"].Value.ToString() == null)
                {
                    dgvInvoice.Rows[i].DefaultCellStyle.BackColor = Color.FromName("red");
                }
                else
                {
                    dgvInvoice.Rows[i].DefaultCellStyle.BackColor = Color.FromName(displaycolor);
                }

            }
        }

        /// <summary>
        /// 查询按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDgvInvoiceData();
            gettj();
        }
        /// <summary>
        /// 重打发票按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            FrmReprintInvoice frmReprintInvoice = new FrmReprintInvoice();
            //     int num = dgvInvoice.ColumnCount;
            if (dgvInvoice.SelectedRows.Count != 0 && dgvInvoice.Rows.Count > 0)
            {
                string clinic_invoice_id = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                string invoice = dgvInvoice.SelectedRows[0].Cells["invbill"].Value.ToString();
                frmReprintInvoice.getSource(clinic_invoice_id, invoice);
                frmReprintInvoice.ShowDialog();
            }
            
        }
        /// <summary>
        /// 退费按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count > 0)
            {
                FrmRefund frmRefund = new FrmRefund();
                string invoiceId = dgvInvoice.SelectedRows[0].Cells["invoice_id"].Value.ToString();
                            
                if (dgvInvoice.SelectedRows.Count != 0)
                {
                    frmRefund.ChargeManagePatientInfo.PatientName = dgvInvoice.SelectedRows[0].Cells["regname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Sex = dgvInvoice.SelectedRows[0].Cells["sex"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Hspcard = dgvInvoice.SelectedRows[0].Cells["hspcard"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Depart = dgvInvoice.SelectedRows[0].Cells["dptname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Doctor = dgvInvoice.SelectedRows[0].Cells["dctname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Idcard = dgvInvoice.SelectedRows[0].Cells["idcard"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Regist_id = dgvInvoice.SelectedRows[0].Cells["regist_id"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Amount = dgvInvoice.SelectedRows[0].Cells["realfee"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Bas_patienttype_id = dgvInvoice.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Regbillcode = dgvInvoice.SelectedRows[0].Cells["regbill"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Invoicecode = dgvInvoice.SelectedRows[0].Cells["invbill"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Bas_patienttype_id = dgvInvoice.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.PatienttypeKeyname = bllChargeManage.getPatienttypeKeyname(frmRefund.ChargeManagePatientInfo.Bas_patienttype_id);
                    frmRefund.ChargeManagePatientInfo.Invoice_id = dgvInvoice.SelectedRows[0].Cells["invoice_id"].Value.ToString();
                    if (!bllChargeManage.isRegistRcv(frmRefund.ChargeManagePatientInfo.Invoice_id))
                    {
                        MessageBox.Show("该病人已经接诊,不能退费!");
                        return;
                    }
                }
                frmRefund.ShowDialog();
                getDgvInvoiceData();
            }
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

      

        /// <summary>
        /// 选择不同的发票信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {            
            if (dgvInvoice.SelectedRows.Count != 0 )
            {
                string id = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                DataTable dt = bllChargeManage.getClinicCostdet(id);                
                if (dt == null)
                {
                    return;
                }
                this.dgvCostdet.DataSource = dt;                
                #region  dgvCostdet单元格标题设置
                dgvCostdet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCostdet.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvCostdet.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvCostdet.Columns["name"].HeaderText = "名称";
                this.dgvCostdet.Columns["name"].Width = (int)(250 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["spec"].HeaderText = "规格";
                this.dgvCostdet.Columns["spec"].Width = (int)(180 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["unit"].HeaderText = "单位";
                this.dgvCostdet.Columns["unit"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["num"].HeaderText = "数量";
                this.dgvCostdet.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostdet.Columns["num"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["prc"].HeaderText = "单价";
                this.dgvCostdet.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostdet.Columns["prc"].Width = (int)(115 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["fee"].HeaderText = "金额";
                this.dgvCostdet.Columns["fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostdet.Columns["fee"].Width = (int)(150 * ProgramGlobal.WidthScale);
               
                dgvCostdet.ReadOnly = true;
                dgvCostdet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                #endregion 
                if (dgvInvoice.SelectedRows[0].Cells["charged"].Value.ToString() == "退费" || dgvInvoice.SelectedRows[0].Cells["charged"].Value.ToString() == "红冲")//如果收费状态改为退费不可打印发票
                {
                    btnRePrint.Enabled = false;
                    btnRefund.Enabled = false;
                }
                else
                {
                    btnRePrint.Enabled = true;
                    btnRefund.Enabled = true;
                }
                string invoiceId = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                string unlocked = bllChargeManage.getCostUnlocked(invoiceId);
                if (unlocked.Equals("N"))
                {
                    btnRefund.Enabled = false;
                }
                else 
                {
                    btnRefund.Enabled = true;
                }
             
            }
            else
            {
                dgvCostdet.DataSource = null;
            }

        
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbChargeby.Text = "--全部--";
            cbxIsLocked.Text = "--全部--";
            cmbDepart.SelectedValue = 0;
            tbxHspcard.Text = "";
            tbxPatientName.Text = "";
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            getDgvInvoiceData();
        }
        private void gettj()
        {
            ChargeManage chargeManage = new ChargeManage();
            chargeManage.PatientName = tbxPatientName.Text.Trim();
            chargeManage.HspCard = tbxHspcard.Text.Trim();
            chargeManage.Depart_id = cmbDepart.SelectedValue.ToString();
            chargeManage.Chargeby = cmbChargeby.SelectedValue.ToString();//ProgramGlobal.User_id;
            chargeManage.StartDate = this.dtpStime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            chargeManage.EndDate = this.dtpEtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (cbxIsLocked.Text.ToString() == "--全部--")
            {
                chargeManage.Islock = "";
            }
            else if (cbxIsLocked.Text.ToString() == "已解锁")
                chargeManage.Islock = "Y";
            else if (cbxIsLocked.Text.ToString() == "未解锁")
                chargeManage.Islock = "N";

            if (cmbIsret.Text.ToString() == "--全部--")
            {
                chargeManage.Isret = "";
            }
            else if (cmbIsret.Text.ToString() == "已退费")
                chargeManage.Isret = "RET";
            else if (cmbIsret.Text.ToString() == "计费")
                chargeManage.Isret = "CHAR";
            labsfje.Text = bllChargeManage.getInvoicefee(chargeManage);
            labtfje.Text = bllChargeManage.getInvoiceRRECfee(chargeManage);
            this.labsfzs.Text = bllChargeManage.getInvoicecount(chargeManage);
            labtfzs.Text = bllChargeManage.getInvoiceRRECcount(chargeManage);
            labssje.Text = bllChargeManage.getInvoicess(chargeManage);
        }

        private void cdjsd_Click(object sender, EventArgs e)
        {
            int rowid = dgvInvoice.CurrentRow.Index;
            if (rowid < 0)
            {
                MessageBox.Show("请选择患者!");
                return;
            }
            string patienttypeKeyname = "";
            if (!patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                string sql = "select ";
                if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSYB.ToString()))
                {
                    ClinicInvoice clinicInvoice;
                    MZSyb mzsyb = new MZSyb();
                  //  mzsyb.fpcd(clinicInvoice.Id);
                }
                else
                    if (patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.HDSCH.ToString()))
                    {
                        MZCH mzch = new MZCH();
                       // mzch.fpcd(clinicInvoice.Clinic_cost_ids);
                    }
            }
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getDgvInvoiceData();
            }
        }

        private void dgvCostdet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            //Excel.SaveAs(dgvInvoice);
            FrmExcle frmExcle = new FrmExcle();
            frmExcle.Dg = dgvInvoice;
            frmExcle.Show(this);
        }

      
    }
}
