using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.common;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.ihsptab.bo;

namespace MTREG.ihsp
{
    public partial class FrmIhspRpt : Form
    {
        BillIhspcost billIhspcost = new BillIhspcost();
        int flag;
        string ihsp_id;
        string account_id;
        string invoicecode;
        string nextinvoicesql;

        public FrmIhspRpt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从FrmIhspcost中获取信息
        /// </summary>
        /// <param name="source"></param>
        public void getSouse(string id,string ihsp_account_id)
        {
            this.ihsp_id = id;
            this.account_id = ihsp_account_id;
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            if(dt.Rows.Count>0)
            {
                lblName.Text = dt.Rows[0]["ihspname"].ToString();
                lblSex.Text = dt.Rows[0]["sex"].ToString();
                lblAge.Text = dt.Rows[0]["age"].ToString();
                lblHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                lblDepart.Text = dt.Rows[0]["deparname"].ToString();
                lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
                lblDoctor.Text = dt.Rows[0]["doctorname"].ToString();
            }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRePrint_Load(object sender, EventArgs e)
        {
            BillIhspAct billIhspAct=new BillIhspAct();
            rbtnOldBill.Checked = true;
            DataTable dt= billIhspAct.rePrintSearch(this.account_id);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("未找到发票信息");
                this.Close();
                return;
            }
           // account_id = dt.Rows[0]["id"].ToString();
                
            lblBas_paytype.Text = dt.Rows[0]["paytype"].ToString();
            lblPatienttype.Text = dt.Rows[0]["patienttype"].ToString();
            lblFeeamt.Text = dt.Rows[0]["feeamt"].ToString();
            lblPrepamt.Text = dt.Rows[0]["prepamt"].ToString();
            lblInsurefee.Text = dt.Rows[0]["insurefee"].ToString();
            lblSelffee.Text = dt.Rows[0]["insuraccountfee"].ToString();
            lblCheque.Text = dt.Rows[0]["cheque"].ToString();
            lblOldBill.Text = dt.Rows[0]["invoice"].ToString();//BillSysBase.currBillcode("ihsp_account_billcode");
            //显示新发票号
            string patienttype_id = dt.Rows[0]["bas_patienttype_id"].ToString();
            string invoiceKind = billIhspAct.getInvoiceKind(patienttype_id);

            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                lblNewBill.Text = "发票已用完";
                rbtnNewBill.Enabled = false;
            }
            else
            {
                lblNewBill.Text = invoicecode;
            }

            tbxBillcode.Enabled = false;
        }

        /// <summary>
        /// radiobtn选择更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnInvoicecode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBillcode.Checked == true)
            {
                tbxBillcode.Enabled = true;
            }
            else
            {
                tbxBillcode.Enabled = false;
            }
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            BillIhspAct billIhspAct = new BillIhspAct();
            if (rbtnNewBill.Checked)
            {
                //更新发票号
                flag = billIhspAct.upAccInvoice(account_id, lblNewBill.Text, nextinvoicesql);
                if (flag < 0)
                {
                    MessageBox.Show("更新单据号失败!");
                    return;
                }
            }
            else if (rbtnBillcode.Checked)
            {
                flag = billIhspAct.upAccInvoice(account_id, tbxBillcode.Text, "");
                if (flag < 0)
                {
                    MessageBox.Show("更新单据号失败!");
                    return;
                }
            }

            FrxPrintView frxPrintView = new FrxPrintView();
            //frxPrintView.IhspAccZfPrt(cmbBillNum.SelectedValue.ToString());
            frxPrintView.IhspAccPrt(account_id);
            this.Close();
        }
    }
}
