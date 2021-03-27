using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.common;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.ihsptab.bo;
using MTREG.medinsur.hdyb.bll;

namespace MTREG.ihsp
{
    public partial class FrmIhspPayRpt : Form
    {
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspcost billIhspcost = new BillIhspcost();
        int flag;
        string thispayid;
        string patienttype;
        public FrmIhspPayRpt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从FrmIhspPay
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string ihspid,string payid)
        {
            this.thispayid = payid;
            DataTable dtIhsp = billIhspcost.ihspIdSearch(ihspid);
            DataTable dtPay = billIhspMan.retSearch(thispayid);
            if (dtIhsp.Rows.Count > 0 && dtPay.Rows.Count > 0)
            {
                lblPrepamt.Text = dtIhsp.Rows[0]["prepamt"].ToString();
                lblPaytype.Text = dtPay.Rows[0]["paytype"].ToString();
                lblCheque.Text = dtPay.Rows[0]["cheque"].ToString();
                lblDoctor.Text = dtPay.Rows[0]["chargedby"].ToString();
                lblName.Text = dtIhsp.Rows[0]["ihspname"].ToString();
                lblPatientType.Text = dtIhsp.Rows[0]["patienttype"].ToString();
                lblAge.Text = dtIhsp.Rows[0]["age"].ToString();
                lblHspcard.Text = dtIhsp.Rows[0]["hspcard"].ToString();
                lblDepart.Text = ProgramGlobal.DepartName;
                lblIhspcode.Text = dtIhsp.Rows[0]["ihspcode"].ToString();
                lblSex.Text = dtIhsp.Rows[0]["sex"].ToString();
                lblOldBill.Text = dtPay.Rows[0]["billcode"].ToString();
                patienttype = dtIhsp.Rows[0]["bas_patienttype_id"].ToString();
            }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspRePrint_Load(object sender, EventArgs e)
        {
            rbtnOldBill.Checked = true;

            //lblNewBill.Text = BillSysBase.newBillcode("ihsp_payinadv_billcode");
            lblNewBill.Text = BillSysBase.currBillcode("ihsp_payinadv_billcode");
            tbxBillcode.Enabled = false;
            if (lblPrepamt.Text == "")
            {
                lblPrepamt.Text = "0.00";
            }
        }

        /// <summary>
        /// radiobtn选择改变时
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
            FrxPrintView frxPrintView = new FrxPrintView();
            if (rbtnNewBill.Checked)
            {
                flag = billIhspMan.upPayBill(thispayid, BillSysBase.newBillcode("ihsp_payinadv_billcode"));
                if (flag < 0)
                {
                    MessageBox.Show("单据号更改错误!");
                    return;
                }
            }
            else if(rbtnBillcode.Checked)
            {
                flag = billIhspMan.upPayBill(thispayid, tbxBillcode.Text);
                if (flag < 0)
                {
                    MessageBox.Show("单据号更改错误!");
                    return;
                }
            }
            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(patienttype);
            
            
                frxPrintView.getIhspPayInadv(thispayid);
            
        }
    }
}
