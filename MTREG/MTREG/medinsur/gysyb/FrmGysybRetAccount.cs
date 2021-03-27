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
    public partial class FrmGysybRetAccount : Form
    {
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        Ihspaccount ihspaccount = new Ihspaccount();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsur bllInsur = new BllInsur();
        int flag;
        string ihspId;
        string account_id;
        string patienttype;
        string sourceHisOrderNo = "";   //原订单号
        string netpaytype = "-1";
        public FrmGysybRetAccount()
        {
            InitializeComponent();
        }
      
        /// <summary>
        /// 从cost中获取数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id, string ihsp_account_id)
        {
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                //this.cmbPayType.SelectedValue = 1;
            }

            ihspId = id;
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
            btnOk.Enabled = false;
            if (!retFee())
            {
                btnOk.Enabled = true;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool retFee()
        {
            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                string ihspaccountId = dataTable.Rows[0]["id"].ToString();

                DataTable dt = billIhspcost.ihspIdSearch(ihspId);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                sourceHisOrderNo = dt.Rows[0]["hisOrderNo"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");
                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y")
                {
                    //结算回退
                    if (gysybRet())
                    {
                        //网络支付退费
                        string currDate = BillSysBase.currDate();
                        string hisRefundNo = "";
                        if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
                        {
                            return false;
                        }

                        //网络支付退费_END

                        //更新医保状态
                        BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
                        bllInsurGYSYB.cancelAccountInsurStat(ihspId);
                        //his结算
                        string paytypeId = this.cmbPayType.SelectedValue.ToString();//从界面获取实收金额的paytype
                        if (billIhspAct.cancleAccount(ihspaccountId, paytypeId) < 0)
                        {
                            MessageBox.Show("医保结算回退成功，his结算失败");
                            return false;
                        }

                        MessageBox.Show("结算回退成功!", "提示信息");
                        return true;
                    }
                    return false;
                }
                else
                {
                    MessageBox.Show("不是当天结算,请进行回退申请");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("没有可退结算记录!");
                return false;
            }
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
        /// 贵阳市医保结算回退
        /// </summary>
        private bool gysybRet()
        {
            BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            DataTable dt =  bllInsurGYSYB.getSettledInfo(ihspId);
            //就诊顺序号|结算编号|医保总费用|结算总费用|全自费|挂钩自付|允许报销|本次起付线|进入起付线|基本统筹支付|基本统筹自付|大额统筹支付
            //大额统筹自付|个人账户支付|超限额自付|医疗补助支付|个人账户余额|总费用|医保报销|个人应付|个人账户最大支付|个人账户支付
            //个人医保编码|公司名称
            //string[] infos = dt.Rows[0]["settinfo"].ToString().Split('|');
            //个人编码|分中心编码|姓名|性别|身份证号码|出生日期|人员类别|人员类别名称|保险类别|医疗照顾人员标志|单位编码|单位名称|
            //账户余额|本年住院次数|本次起付线|本年已支付起付线|基本统筹限额|本年已支付基本统筹|大额统筹限额|本年已支付大额统筹|
            //本年普通门诊医疗补助限额|本年普通门诊医疗补助累计|普通门诊医疗补助起付标准|普通门诊医疗补助结转可使用金额|封锁信息|
            //备注|清算方式|卡类别|磁条数据|社会保障号|密码|终端机IP地址|pasm卡号|支付类别|工伤认定编号|工伤康复住院标志|单病种编码
            //string[] mes = dt.Rows[0]["presettleinfo"].ToString().Split('|');
            string insurtype = dt.Rows[0]["insuretype"].ToString();//保险类别
            string bllNo = dt.Rows[0]["billno"].ToString();//就诊顺序号
            string settleNo = dt.Rows[0]["balanceid"].ToString();//结算编号
            string zflx = dt.Rows[0]["paytype"].ToString();//支付类型
            StringBuilder message = new StringBuilder();
            if (!bllInsurGYSYB.Cydjsjht(ihspId,bllNo, message))
            {
                MessageBox.Show("结算回退失败！");
                return false;
            }
            if (insurtype != "2")
            {
                if (!bllInsurGYSYB.zyTp(ihspId,bllNo, settleNo, zflx, message))
                {
                    MessageBox.Show("撤销结算失败" + message.ToString());
                    return false;
                }
            }
            else
            {
                if (!bllInsurGYSYB.lxTp(ihspId,bllNo, settleNo, zflx, message))
                 {
                     MessageBox.Show("撤销结算失败" + message.ToString());
                     return false;
                 }
            }

            return true;
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
    }
}
