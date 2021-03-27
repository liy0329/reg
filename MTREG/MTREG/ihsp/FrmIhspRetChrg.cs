using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.common;
using MTREG.ihsp.bo;
using MTHIS.common;
using MTREG.netpay.bo;
using MTREG.netpay;

namespace MTREG.ihsp
{
    public partial class FrmIhspRetChrg : Form
    {
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspcost billIhspcost = new BillIhspcost();
        int flag;
        string thispayid;
        string ihspid;
        string sourceHisOrderNo = "";   //原订单号
        string netpaytype = "-1";
        public FrmIhspRetChrg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从FrmIhspPay获取数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string ihsp_id,string payid)
        {
            this.thispayid = payid;
            this.ihspid = ihsp_id;
            
        }
        private void FrmIhspRetChrg_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dt = new DataTable();
            dt = billCmbList.payPaytypeList();
            this.cmbPayType.ValueMember = "id";
            this.cmbPayType.DisplayMember = "name";
            this.cmbPayType.DataSource = dt;

            DataTable dtIhsp = billIhspcost.ihspIdSearch(ihspid);
            DataTable dtPay = billIhspMan.retSearch(thispayid);
            if (dtIhsp.Rows.Count > 0 && dtPay.Rows.Count > 0)
            {
                this.lblBillcode.Text = dtPay.Rows[0]["billcode"].ToString();
                this.lblRetChrg.Text = dtPay.Rows[0]["payfee"].ToString();
                this.cmbPayType.SelectedValue = dtPay.Rows[0]["bas_paytype_id"].ToString();
                this.lblCheque.Text = dtPay.Rows[0]["cheque"].ToString();
                this.lblIhspcode.Text = dtIhsp.Rows[0]["ihspcode"].ToString();
                this.lblName.Text = dtIhsp.Rows[0]["ihspname"].ToString();
                this.sourceHisOrderNo = dtPay.Rows[0]["hisOrderNo"].ToString();
            }
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
        /// 支付退费
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="hisRefundNo"></param>
        /// <returns></returns>
        bool doexecNetPayTradeRefund(string currDate, ref string hisRefundNo)
        {
            double payfee = DataTool.stringToDouble(lblRetChrg.Text);
            bool ret = true;
            if (!netpaytype.Equals("-1") && payfee > 0)
            {
                NetPayTradeRefundIn netPayTradeRefundIn = new NetPayTradeRefundIn();
                NetPayTradeRefundOut netPayTradeRefundOut = new NetPayTradeRefundOut();
                NetpayBll netpayBll = new NetpayBll();
                netPayTradeRefundIn.Czyh = ProgramGlobal.User_id;
                hisRefundNo = netPayTradeRefundIn.OutRefundNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayTradeRefundIn.Paytype = netpaytype;
                netPayTradeRefundIn.StoreId = "0";
                netPayTradeRefundIn.Subject = "退预交款";
                netPayTradeRefundIn.OuterOrderNo = sourceHisOrderNo;
                netPayTradeRefundIn.Tfje = lblRetChrg.Text.Trim();
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
        /// 撤销预交款按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetChrg_Click(object sender, EventArgs e)
        {
            btnRetChrg.Enabled = false;
            if (!retPayFee())
            {
                btnRetChrg.Enabled = true;
                return;
            }
            this.Close();
        }
        //撤销预付款
        bool retPayFee()
        {
            Ihsppayinadv ihsppayinadv = new Ihsppayinadv();
            DataTable dt = billIhspMan.retSearch(thispayid);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("未找到预交款信息,无法完成撤销");
                return false;
            }
            //网络支付退费
            string currDate = BillSysBase.currDate();
            string hisRefundNo = "";
            //if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
            //{
            //    return false;
            //}

            //网络支付退费_END
            string sql_retfee = "";
            ihsppayinadv.Payman = dt.Rows[0]["payman"].ToString();
            ihsppayinadv.Payfee = "-" + dt.Rows[0]["payfee"].ToString();
            ihsppayinadv.Paytype = cmbPayType.SelectedValue.ToString();
            ihsppayinadv.Bas_paysumby_id = billIhspMan.getPaysumby(ihsppayinadv.Paytype);
            ihsppayinadv.Cheque = dt.Rows[0]["cheque"].ToString();
            ihsppayinadv.Depart = dt.Rows[0]["depart_id"].ToString();
            ihsppayinadv.Billcode = dt.Rows[0]["billcode"].ToString();
            ihsppayinadv.Chargedby = ProgramGlobal.User_id;

            ihsppayinadv.Chargedate = BillSysBase.currDate();
            ihsppayinadv.Ihsp_payinadv_id = thispayid;
            ihsppayinadv.Num = "-1";
            ihsppayinadv.Status = "RREC";
            ihsppayinadv.Ihsp_id = ihspid;
            ihsppayinadv.HisOrderNo = hisRefundNo;
            ihsppayinadv.SourceHisOrderNo = dt.Rows[0]["hisOrderNo"].ToString();
            ihsppayinadv.Id = BillSysBase.nextId("ihsp_payinadv");
            sql_retfee += billIhspMan.upPayStatus(thispayid);//更新原
            sql_retfee += billIhspMan.inhspReturnPay(ihsppayinadv);//插入红冲
            if (billIhspMan.doExeSql(sql_retfee) == -1)
            {
                MessageBox.Show("撤销预付款保存数据失败");
                return false;
            }
            BillSysBase.doIhspAmt(ihspid);
            MessageBox.Show("撤销预付款成功");
            return true;
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
