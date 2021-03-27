using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bo;
using MTREG.clinic.bll;
using MTREG.common;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;

namespace MTREG.clinic
{
    public partial class FrmReprintInvoice : Form
    {
        ChargeManagePatientInfo chargeManagePatientInfo = new ChargeManagePatientInfo();
        BillRegSearch billRegSearch = new BillRegSearch();
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        BllClinicCostManage bllClinicCostManage = new BllClinicCostManage();
        BllClinicReg bllClinicReg = new BllClinicReg();
        string invoicekind ="";
        string clinic_invoice_id = "";
        string invoice = "";
        string invoicecode = "";//发票号
        string nextinvoicesql = "";
        internal ChargeManagePatientInfo ChargeManagePatientInfo
        {
            get { return chargeManagePatientInfo; }
            set { chargeManagePatientInfo = value; }
        }
        public FrmReprintInvoice()
        {
            InitializeComponent();
        }

        public void getSource(string clinic_invoice_id, string invoice)
        {
            this.clinic_invoice_id = clinic_invoice_id;
            this.invoice = invoice;
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            if (rdbNewBillcode.Checked == true)
            {
                if (billRegSearch.upNewInvoice(clinic_invoice_id, invoicecode, nextinvoicesql) < 0)
                {
                    MessageBox.Show("更新发票号失败");
                    return;
                }
            }
            else if (rdbParticularBillcode.Checked == true)
            {
                if (billRegSearch.upSetInvoice(clinic_invoice_id, tbxSetInvoice.Text) < 0)
                {
                    MessageBox.Show("更新发票号失败");
                    return;
                }
            }
            FrxPrintView frxPrintView = new FrxPrintView();
            string sql = "select clinic_cost_id from clinic_costdet where clinic_invoice_id=" + clinic_invoice_id;
            string id = "";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id += dt.Rows[i]["clinic_cost_id"].ToString() + ",";
            }
            string patienttype_id = cmbPatientType.SelectedValue.ToString();
            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == "SELFCOST")
            {
                frxPrintView.ZFprintInvoice(id.Remove(id.Length - 1), clinic_invoice_id);
            }
            else if (keyname == "GSBX")
            {
                frxPrintView.ZFprintInvoice(id.Remove(id.Length - 1), clinic_invoice_id);
            }
            else 
            {
                frxPrintView.printInvoice(id.Remove(id.Length - 1), invoice);
            }     
            //}
            //else
            //{
            //    Billjc bjc = new Billjc();
            //    DataTable dt1 = bjc.getffp(id.Remove(id.Length - 1));
            //    for (int j = 0; j < dt1.Rows.Count; j++)
            //    {
            //        frxPrintView.printInvoice_ffp(id.Remove(id.Length - 1), clinic_invoice_id, dt1.Rows[j]["exedep_id"].ToString());            
            //    }
            //}                       
            Close();
        }

        private void FrmReprintInvoice_Load(object sender, EventArgs e)
        {
        
            invoicekind = bllClinicReg.getInvoiceKind(); //初始化发票类型
            initInfo();
            initInvoice();

        }
        /// <summary>
        /// 初始化发票信息
        /// </summary>
        public void initInvoice()
        {

            ///发票初始化
            int invoiceNum = BillSysBase.currInvoiceA(ProgramGlobal.User_id.Trim(), invoicekind, 1, ref invoicecode, ref nextinvoicesql);
            if (invoiceNum > 0)
            {
                lblNewInvoice.Text = invoicecode;

            }
            else
                lblNewInvoice.Text = "已缺票";
            tbxSetInvoice.ReadOnly = true;
        }
        /// <summary>
        /// 初始化信息
        /// </summary>
        private void initInfo()
        {
            cmbPatientType.Enabled = true;
            var dtp = bllRecipelCharge.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            lblPatienttypeKeyname.Visible = false;
            cmbPatientType.Enabled = false;
            DataTable dt = bllClinicCostManage.getInvoiceInfo(invoice);
            this.lblPatientName.Text = dt.Rows[0]["regname"].ToString();
            this.lblHspcard.Text = dt.Rows[0]["hspcard"].ToString();
            this.lblRegBillcode.Text = dt.Rows[0]["regbill"].ToString();
            this.lblSex.Text = dt.Rows[0]["sex"].ToString();
            this.lblAge.Text = dt.Rows[0]["age"].ToString();
            this.lblDepart.Text = dt.Rows[0]["dptname"].ToString();//科室
            this.lblDoctor.Text = dt.Rows[0]["dctname"].ToString();
            this.lblAmount.Text = dt.Rows[0]["realfee"].ToString();
            this.cmbPatientType.SelectedValue = dt.Rows[0]["bas_patienttype_id"].ToString();
            string isregist = dt.Rows[0]["isregist"].ToString();
            lblRigistStr.Text = "收费";
            if (isregist.Equals("1"))
            {
                lblRigistStr.Text = "挂号";
            }
            lblOldInvoice.Text = dt.Rows[0]["invoice"].ToString();
        }

        private void lblRegBillcode_Click(object sender, EventArgs e)
        {

        }

        private void rdbParticularBillcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbParticularBillcode.Checked)
            {
                tbxSetInvoice.ReadOnly = false;
            }
            else
            {
                tbxSetInvoice.ReadOnly = true;
            }
        }

    }
}
