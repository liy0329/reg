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

namespace MTREG.clinic
{
    public partial class FrmCliniCostRetFeeManage : Form
    {
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllClinicCostManage bllChargeManage = new BllClinicCostManage();
        public FrmCliniCostRetFeeManage()
        {
            InitializeComponent();
        }

      
         /// <summary>
        /// 加载dataGridview信息
        /// </summary>
        private void initdgvList()
        {

           
          
           
            loadInvoiceList();
            #region updateHeaderText
            dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvInvoice.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));

            dgvInvoice.Columns["isregist"].HeaderText = "挂号";
            dgvInvoice.Columns["isregist"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["isregist"].DisplayIndex = 3;
            dgvInvoice.Columns["regbill"].Visible = true;
            dgvInvoice.Columns["regbill"].HeaderText = "门诊号";
            dgvInvoice.Columns["regbill"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["regbill"].DisplayIndex = 0;
            dgvInvoice.Columns["regbill"].Visible = false;
            dgvInvoice.Columns["invbill"].HeaderText = "发票号";
            dgvInvoice.Columns["invbill"].Width = (int)(130 * ProgramGlobal.WidthScale);
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
            dgvInvoice.Columns["outby"].HeaderText = "退费员";
            dgvInvoice.Columns["outby"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["outby"].DisplayIndex = 5;
            dgvInvoice.Columns["ys"].HeaderText = "医生";
            dgvInvoice.Columns["ys"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["ys"].DisplayIndex = 6;
            dgvInvoice.Columns["realfee"].HeaderText = "金额";
            dgvInvoice.Columns["realfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInvoice.Columns["realfee"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["realfee"].DisplayIndex = 7;
            dgvInvoice.Columns["chargedate"].HeaderText = "收费时间";
            dgvInvoice.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvInvoice.Columns["chargedate"].Width = (int)(160 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["chargedate"].DisplayIndex = 8;
            dgvInvoice.Columns["outdate"].HeaderText = "退费时间";
            dgvInvoice.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvInvoice.Columns["outdate"].Width = (int)(160 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["outdate"].DisplayIndex = 9;
            dgvInvoice.Columns["hspcard"].HeaderText = "卡号";
            dgvInvoice.Columns["hspcard"].Width = (int)(120 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["hspcard"].DisplayIndex = 10;
            dgvInvoice.Columns["charged"].HeaderText = "计费状态";
            dgvInvoice.Columns["charged"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["charged"].DisplayIndex = 11;
            dgvInvoice.Columns["dptname"].HeaderText = "科室";
            dgvInvoice.Columns["dptname"].Width = (int)(160 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["dptname"].DisplayIndex = 12;
            dgvInvoice.Columns["bxfs"].HeaderText = "报销方式";
            dgvInvoice.Columns["bxfs"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["bxfs"].DisplayIndex = 13;
            this.dgvInvoice.Columns["patienttype"].HeaderText = "患者类型";
            this.dgvInvoice.Columns["patienttype"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["patienttype"].DisplayIndex = 14;
            dgvInvoice.Columns["paytype"].HeaderText = "门诊缴费方式";
            dgvInvoice.Columns["paytype"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvInvoice.Columns["paytype"].DisplayIndex = 15;
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
            #endregion
           
        }

    

        private void loadInvoiceList()
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
            this.dgvInvoice.DataSource = bllChargeManage.getInvoiceList(chargeManage);
           
        }

        private void initFormInfo()
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
            //cbxIsLocked.Text = "--全部--";
            cbxIsLocked.Text = "已解锁";
            

            //是否退费
            cmbIsret.Items.Add("--全部--");
            cmbIsret.Items.Add("已退费");
            cmbIsret.Items.Add("计费");
            cmbIsret.Text = "--全部--";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadInvoiceList();
            gettj();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count > 0)
            {
                FrmRefund frmRefund = new FrmRefund();
                string invoiceId = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                string unlocked = bllChargeManage.getCostUnlocked(invoiceId);
                if (unlocked.Equals("N"))
                {
                    MessageBox.Show("药品未解锁不能退费!");
                }
                //if (dgvInvoice.SelectedRows[0].Cells["paytype"].Value.ToString() != "直接缴费")
                //{
                //    MessageBox.Show("该患者的支付方式为：" + dgvInvoice.SelectedRows[0].Cells["paytype"].Value.ToString() + ",无法在收费接口退费！");
                //    return;
                //}
                if (dgvInvoice.SelectedRows.Count != 0)
                {
                    frmRefund.ChargeManagePatientInfo.PatientName = dgvInvoice.SelectedRows[0].Cells["regname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Sex = dgvInvoice.SelectedRows[0].Cells["sex"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Hspcard = dgvInvoice.SelectedRows[0].Cells["hspcard2"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Depart = dgvInvoice.SelectedRows[0].Cells["dptname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Doctor = dgvInvoice.SelectedRows[0].Cells["dctname"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Idcard = dgvInvoice.SelectedRows[0].Cells["idcard"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Regist_id = dgvInvoice.SelectedRows[0].Cells["regist_id"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Amount = dgvInvoice.SelectedRows[0].Cells["realfee"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Regbillcode = dgvInvoice.SelectedRows[0].Cells["regbill"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Invoicecode = dgvInvoice.SelectedRows[0].Cells["invbill"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.Bas_patienttype_id = dgvInvoice.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
                    frmRefund.ChargeManagePatientInfo.PatienttypeKeyname = bllChargeManage.getPatienttypeKeyname(frmRefund.ChargeManagePatientInfo.Bas_patienttype_id);
                    frmRefund.ChargeManagePatientInfo.Invoice_id = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                    //if (bllChargeManage.isRegistRcv(frmRefund.ChargeManagePatientInfo.Invoice_id))
                    //{
                    //    MessageBox.Show("该病人已经接诊,不能退挂号票!");
                    //    return;
                    //}
                }
                frmRefund.ShowDialog();
                loadInvoiceList();
            }
        }
        private void loadClinicCostDet(string invoice_id)
        {
            DataTable dt = bllChargeManage.getClinicCostdet(invoice_id);
            this.dgvCostdet.DataSource = dt;
            
        }
        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count != 0)
            {
                string id = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                loadClinicCostDet(id);
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
                
                string invoiceId = dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString();
                string unlocked = bllChargeManage.getCostUnlocked(invoiceId);
                
                if (dgvInvoice.SelectedRows[0].Cells["charged"].Value.ToString() == "退费"||unlocked.Equals("N"))//如果收费状态改为退费不可打印发票
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
            loadInvoiceList();
        }

        private void FrmCliniCostRetFeeManage_Load(object sender, EventArgs e)
        {
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            //加载下拉列表
            initFormInfo();
            //加载表格
            initdgvList();
            gettj();
        }

        private void gettj()
        {
            ChargeManage chargeManage = new ChargeManage();
            chargeManage.PatientName = tbxPatientName.Text.Trim();
            chargeManage.HspCard = tbxHspcard.Text.Trim();
            chargeManage.Depart_id = cmbDepart.SelectedValue.ToString();
            chargeManage.Chargeby = ProgramGlobal.User_id;//cmbChargeby.SelectedValue.ToString();
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

    }
}
