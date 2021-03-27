using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.common;
using MTREG.clinic.bll;
using MTREG.ihsp.bo;
using MTREG.clinic.bo;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.clinic
{
    public partial class FrmRegPrt : Form
    {
        BillRegSearch billRegSearch = new BillRegSearch();
        string registerid;
        string invoiceid;
        string patienttype;
        public FrmRegPrt()
        {
            InitializeComponent();
        }

        public void getSource(string id)
        {
            this.registerid = id;
            BillRegSearch billRegSearch = new BillRegSearch();
            DataTable dt = billRegSearch.regIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                this.lblName.Text = dt.Rows[0]["regname"].ToString();
                this.lblBillcode.Text = dt.Rows[0]["billcode"].ToString();
                this.lblHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                this.lblAge.Text = dt.Rows[0]["age"].ToString();
                this.lblDepart.Text = dt.Rows[0]["departname"].ToString();
                this.lblDoctor.Text = dt.Rows[0]["doctorname"].ToString();
                this.lblAmount.Text = dt.Rows[0]["amount"].ToString();
                this.lblSex.Text = dt.Rows[0]["sex"].ToString();
                this.lblPatienttype.Text = dt.Rows[0]["patienttype"].ToString();
                this.patienttype = dt.Rows[0]["patienttypeid"].ToString(); 
            }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegPrint_Load(object sender, EventArgs e)
        {
            BllClinicReg bllRegister = new BllClinicReg();
            DataTable dt = billRegSearch.invoice(registerid);
            lblOldBill.Text = dt.Rows[0]["billcode"].ToString();
            string invoiceKind = bllRegister.getInvoiceKind(patienttype);
            string ip = ProgramGlobal.Ip;
            string billcode = BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1")[0];
            invoiceid = dt.Rows[0]["id"].ToString();
            if (BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), ip, invoiceKind, "1").Count == 0)
            {
                MessageBox.Show("发票已用完，不能进行重打！");
                return ;
            }
            lblNewBill.Text = billcode;
            tbxInvoicecode.Enabled = false;
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {            
            if (rbtnNewBill.Checked)
            {
                if (billRegSearch.upSetInvoice(invoiceid, lblNewBill.Text) < 0)
                {
                    MessageBox.Show("更新发票号失败");
                    return;
                }
                FrxPrintView frxPrintView = new FrxPrintView();
                string sql = "select id from clinic_cost where clinic_invoice_id=" + invoiceid;
                string id = BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString();
                frxPrintView.printInvoice(id, invoiceid);
            }
            else if (rbtnOldBill.Checked)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                string sql = "select id from clinic_cost where clinic_invoice_id=" + invoiceid;
                string id = BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString();
                frxPrintView.printInvoice(id, invoiceid);
            }
            else
            {
                if (billRegSearch.upSetInvoice(invoiceid, tbxInvoicecode.Text) < 0)
                {
                    MessageBox.Show("更新发票号失败");
                    return;
                }
                FrxPrintView frxPrintView = new FrxPrintView();
                string sql = "select id from clinic_cost where clinic_invoice_id=" + invoiceid;
                string id = BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString();
                frxPrintView.printInvoice(id, invoiceid);
            }
        }

        /// <summary>
        /// radiobtn修改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnInvoicecode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInvoicecode.Checked == true)
            {
                tbxInvoicecode.Enabled = true;
            }
            else
            {
                tbxInvoicecode.Enabled = false;
            }
        }
    }
}
