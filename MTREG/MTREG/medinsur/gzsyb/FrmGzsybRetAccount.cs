using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTHIS.main.bll;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.ynsyb.ihsp.bll;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.netpay.bo;
using MTREG.netpay;

namespace MTREG.ihsp
{
    public partial class FrmGzsybRetAccount : Form
    {
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        Ihspaccount ihspaccount = new Ihspaccount();
        BillIhspcost billIhspcost = new BillIhspcost();
        BillIhspAct bllIhspAct = new BillIhspAct();
        BllInsur bllInsur = new BllInsur();
     
        string ihspId;
        string account_id;
        string patienttype;
        string sourceHisOrderNo = "";   //原订单号
        string netpaytype = "-1";
        public FrmGzsybRetAccount()
        {
            InitializeComponent();
        }
      
        /// <summary>
        /// 从cost中获取数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id,string ihsp_account_id)
        {
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                //this.cmbPayType.SelectedValue = 1;
            }

            this.ihspId = id;
            account_id = ihsp_account_id;
            DataTable dt = billIhspcost.ihspIdSearch(ihspId);
            this.patienttype = dt.Rows[0]["bas_patienttype_id"].ToString();
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
            this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            
            this.lblSex.Text = dt.Rows[0]["sex"].ToString();
            this.lblAge.Text = dt.Rows[0]["age"].ToString();
            this.lblPatienttype.Text = dt.Rows[0]["patienttype"].ToString();
            
            DateTime start = Convert.ToDateTime(this.lblIndate.Text);
            DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
            TimeSpan day = end.Subtract(start);
            this.lblIhspDay.Text = day.Days.ToString();
            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                this.lblInvoice.Text = dataTable.Rows[0]["invoice"].ToString();
                this.cmbPayType.SelectedValue = dataTable.Rows[0]["bas_paytype_id"].ToString();
                this.lblPrepamt.Text = DataTool.FormatData(dataTable.Rows[0]["prepamt"].ToString(), "2");
                this.lblFeeamt.Text = DataTool.FormatData(dataTable.Rows[0]["feeamt"].ToString(), "2");
                this.lblInBalanceamt.Text = DataTool.FormatData(dataTable.Rows[0]["balanceamt"].ToString(), "2");



            }
            else
            {
                this.lblInvoice.Text = "空";
            }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            btn_OK.Enabled = false;
            if (!retFee())
            {
                btn_OK.Enabled = true;
                return;
                
            }
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        bool retFee()
        {
            DataTable dataTable = bllIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count <= 0)
            {
                MessageBox.Show("没有可退结算记录!,结算回退失败");
                return false;
            }
            string ihspaccountId = dataTable.Rows[0]["id"].ToString();
            sourceHisOrderNo = dataTable.Rows[0]["hisOrderNo"].ToString();
            BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();

            if (!bllInsurIhspGZS.cyjsJsht(ihspId, this.cmbPayType.SelectedValue.ToString()))
            {
                return false;
            }
            //网络支付退费
            string currDate = BillSysBase.currDate();
            string hisRefundNo = "";
            if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
            {
                return false;
            }


            //网络支付退费_END
            //更新医保状态
            bllIhspAct.cancelInsureAccount(ihspId);
            if (bllIhspAct.cancleAccount(ihspaccountId, this.cmbPayType.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("医保结算回退成功，his结算回退失败");
                return false;

            }

            MessageBox.Show("结算回退成功!", "提示信息");
            return true;
        }
        /// <summary>
        /// 支付退费
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="hisRefundNo"></param>
        /// <returns></returns>
        bool doexecNetPayTradeRefund(string currDate, ref string hisRefundNo)
        {
            double payfee = DataTool.stringToDouble(lblInBalanceamt.Text);
            bool ret = false;
            if (!netpaytype.Equals("-1") && payfee > 0)
            {
                NetPayTradeRefundIn netPayTradeRefundIn = new NetPayTradeRefundIn();
                NetPayTradeRefundOut netPayTradeRefundOut = new NetPayTradeRefundOut();
                NetpayBll netpayBll = new NetpayBll();
                netPayTradeRefundIn.Czyh = ProgramGlobal.User_id;
                hisRefundNo = netPayTradeRefundIn.OutRefundNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayTradeRefundIn.Paytype = netpaytype;
                netPayTradeRefundIn.StoreId = "0";
                netPayTradeRefundIn.Subject = "退结算款";
                netPayTradeRefundIn.OuterOrderNo = sourceHisOrderNo;
                netPayTradeRefundIn.Tfje = lblInBalanceamt.Text.Trim();
                netPayTradeRefundOut.OutRefundNo = hisRefundNo;
                NetpayRetRes netpayRetRes = Netpay.execNetPayTradeRefund(netPayTradeRefundIn, netPayTradeRefundOut);
                string zfzt = "1"; //成功
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {

                    zfzt = "-1";
                    mesg = "退单号:[" + hisRefundNo + "]原单号:[" + sourceHisOrderNo + "],姓名:[" + this.lblName.Text + "]网络支付超时或不明确，处于支付故障状态，请及时确定未结算信息！";
                    ret = false;
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "退单号:[" + hisRefundNo + "]原单号:[" + sourceHisOrderNo + "],退款成功";
                }
                netpayBll.refundNetPay(sourceHisOrderNo, currDate, zfzt, netPayTradeRefundOut);
                MessageBox.Show(mesg);
              
            }
            return ret;

        }
     

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRetAccount_Load(object sender, EventArgs e)
        {

            if(lblPrepamt.Text=="")
            {
                lblPrepamt.Text = "0.00";
            }
            if (lblFeeamt.Text == "")
            {
                lblFeeamt.Text = "0.00";
            }

            
        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;

            NetpayBll netpayBll = new NetpayBll();
            netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
            if (netpaytype != "-1")
            {

                lblInvoiceMsg.Text = "现在选择网络支付";

            }
            else
            {
                lblInvoiceMsg.Text = "                    ";
            }
        }
    }
}
