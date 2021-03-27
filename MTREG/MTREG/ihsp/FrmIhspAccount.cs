using System;
using System.Data;
using System.Windows.Forms;
using MTREG.common;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.medinsur;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTHIS.main.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hdssy;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsbhnh;
using MTREG.medinsur.hdsbhnh.bll;
using System.Text;
using MTREG.medinsur.hsdryb.ihsp;
using MTREG.medinsur.hsdryb.ihsp.bll;

using MTREG.medinsur.gysyb;
using MTREG.medinsur.gysyb.bo;

using MTREG.medinsur.ahsjk;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.gysyb.bll;
using System.Collections.Generic;
using System.Net;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.ahsjk.bo;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gzsyb.ihsp.bll;
using System.Text.RegularExpressions;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.ihsp;
using MTREG.medinsur.ynsyb.ihsp.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using System.Drawing;
using MTREG.clinic.bll;
using System.Web.UI.WebControls;
using MTREG.netpay;
using MTREG.netpay.bo;

namespace MTREG.ihsp
{
    public partial class FrmIhspAccount : Form
    {
     
       
        double payamt;
        string ihsp_id;//ihspid        
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsur bllInsur = new BllInsur();
        Ihspaccount ihspaccount = new Ihspaccount();
        Ybjk ybjk = new Ybjk();
        Hdsch hdsch = new Hdsch();
        InsurInfo insurInfo = new InsurInfo();
        string str_neonate = "";
        double paytotal = 0;
        double feetotal = 0;

        string invoicecode = "";//发票号
        string nextinvoicesql = "";//发票号sql

        private string member_id = "";
        private string netpaytype = "-1";//网路支付类型

        private string homephone = "";
        private string idcard = "";
        PersonInfo personInfo = new PersonInfo();//贵州省医保
        GetEmpInfo_out getEmpInfo_out = new GetEmpInfo_out();//云南省医保
        /// <summary>
        /// insurInfo类
        /// </summary>
        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }

        private string calcCode;
        /// <summary>
        /// 安徽农合补偿类别编码
        /// </summary>
        public string CalcCode
        {
            get { return calcCode; }
            set { calcCode = value; }
        }

        GzsnhAccInfo gzsnhAccInfo = new GzsnhAccInfo();
        /// <summary>
        /// 贵州省农合传递字段
        /// </summary>
        internal GzsnhAccInfo GzsnhAccInfo
        {
            get { return gzsnhAccInfo; }
            set { gzsnhAccInfo = value; }
        }

        YnydybAccInfo ynydybAccInfo = new YnydybAccInfo();
        /// <summary>
        /// 云南异地预结算信息
        /// </summary>
        internal YnydybAccInfo YnydybAccInfo
        {
            get { return ynydybAccInfo; }
            set { ynydybAccInfo = value; }
        }
        public FrmIhspAccount()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取FrmIhospCost数据
        /// </summary>
        public void getSource(string id)
        {
            this.ihsp_id = id;
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
            this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            if (dt.Rows[0]["outdate"].ToString() != "")
            {
                this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            }
            this.idcard =  dt.Rows[0]["idcard"].ToString();
            this.homephone = dt.Rows[0]["homephone"].ToString();
        }

        /// <summary>
        /// 获取FrmIhospCost数据
        /// </summary>
        public void getSource(string id, string neonate)
        {
            str_neonate = neonate;
            this.ihsp_id = id;
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
            this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            this.idcard = dt.Rows[0]["idcard"].ToString();
            this.homephone = dt.Rows[0]["homephone"].ToString();
        }
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspAccount_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            #region combox设置
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                this.cmbPayType.SelectedValue = "1";
            }
            //DataTable dtp = billCmbList.patientTypeList();
            DataTable dtp = billCmbList.getpatientType();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                this.cmbPatienttype.DataSource = dtp;
            }
            
            #endregion
            cmbPatienttype.Enabled = false;
          
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            dgvBind();
            

            string Patienttype = dt.Rows[0]["bas_patienttype_id"].ToString();
            if (!string.IsNullOrEmpty(Patienttype))
            {
                this.cmbPatienttype.SelectedValue = Patienttype;
            }
            member_id = dt.Rows[0]["member_id"].ToString();
           
            
            //发票号
            
            string invoiceKind = billIhspAct.getInvoiceKind(this.cmbPatienttype.SelectedValue.ToString());
            if (invoiceKind == "")
            {
                MessageBox.Show("获取发票类型时,未找到对应发票类型!");
                this.Close();
                return;
            }
            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                MessageBox.Show("发票已用完，不能进行收费！");
                this.Close();
                return;
            }
            this.lblInvoice.Text = invoicecode;
            
            int invoiceNum = billIhspAct.getInvoiceNum(invoiceKind, ProgramGlobal.User_id.Trim().ToString());
            if (invoiceNum < 10)
            {
                lblInvoiceMsg.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
            }
            else if (invoiceNum >= 10)
            {
                lblInvoiceMsg.Text = "";
            }
            
            DateTime start = Convert.ToDateTime(this.lblIndate.Text);
            DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
            TimeSpan day = end.Subtract(start);
            this.lblIhspDay.Text = day.Days.ToString();
           // payamt = double.Parse(DataTool.FormatData(dt.Rows[0]["balanceamt"].ToString(), "2"));
           
            double payamt = feetotal - paytotal;
            this.lblInBalanceamt.Text = DataTool.FormatData(payamt.ToString(), "2");
            if (payamt < 0) 
            {
                tbxRecivefee.ReadOnly = true;
            }
            else
            {
                tbxRecivefee.ReadOnly = false;
                tbxRecivefee.Focus();
            }
            
        }

        /// <summary>
        /// 绑定datagridview
        /// </summary>
        public void dgvBind()
        {

            //预交款
            DataTable datatable = billIhspAct.payAccount(ihsp_id);
            this.dgvIhspPayinadv.DataSource = datatable;
            #region  dgvIhspPayinadv单元格标题设置
            dgvIhspPayinadv.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspPayinadv.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvIhspPayinadv.Columns["payfee"].HeaderText = "交款金额";
            this.dgvIhspPayinadv.Columns["payfee"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["payfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspPayinadv.Columns["paytypename"].HeaderText = "交款方式";
            this.dgvIhspPayinadv.Columns["paytypename"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["cheque"].HeaderText = "支票号";
            this.dgvIhspPayinadv.Columns["cheque"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["doctorname"].HeaderText = "收款人";
            this.dgvIhspPayinadv.Columns["doctorname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["chargedate"].HeaderText = "收款时间";
            this.dgvIhspPayinadv.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhspPayinadv.Columns["chargedate"].Width = (int)(100 * ProgramGlobal.WidthScale);
            #endregion
             paytotal = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                paytotal += double.Parse(DataTool.FormatData(datatable.Rows[i]["payfee"].ToString(), "2"));
            }
            lblPaytotal.Text = DataTool.FormatData(paytotal.ToString(), "2")+"元";

            datatable = billIhspAct.costSearch(ihsp_id, str_neonate);
            this.dgvIhspCost.DataSource = datatable;

            //费用总和
            #region  dgvIhspCost单元格标题设置
            dgvIhspCost.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspCost.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvIhspCost.Columns["itemtypename"].HeaderText = "项目类别";
            this.dgvIhspCost.Columns["itemtypename"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["name"].HeaderText = "名称";
            this.dgvIhspCost.Columns["name"].Width = (int)(180 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["realfee"].Visible = false;
            this.dgvIhspCost.Columns["spec"].HeaderText = "规格";
            this.dgvIhspCost.Columns["spec"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["num"].HeaderText = "数量";
            this.dgvIhspCost.Columns["num"].Width = (int)(70 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspCost.Columns["prc"].HeaderText = "单价";
            this.dgvIhspCost.Columns["prc"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspCost.Columns["id"].HeaderText = "id";
            this.dgvIhspCost.Columns["id"].Visible = false;
            #endregion
             feetotal = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                string realfee = datatable.Rows[i]["realfee"].ToString();
                if (string.IsNullOrEmpty(datatable.Rows[i]["realfee"].ToString()))
                {
                    realfee = "0";
                }
                //feetotal += double.Parse(DataTool.FormatData(realfee, "2"));
                feetotal += double.Parse(realfee);
            }
            lblFeetotal.Text = DataTool.FormatData(feetotal.ToString(), "2")+"元" ;
            //未结费用

        }
        /// <summary>
        /// 结算时更改数据
        /// </summary>
        public int actMethod()
        {


            //网络支付
            string hisOrderNo = "";
            string currDate = BillSysBase.currDate();
            //if (!doExecNetPay(currDate, ref hisOrderNo))
            //    return -1;
                

            //网络支付_END


            List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();
            
            ihspaccount.Id = BillSysBase.nextId("ihsp_account");
            ihspaccount.Ihsp_id = ihsp_id;
            ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
            ihspaccount.Member_id = member_id;
            ihspaccount.Bas_paytype_id = this.cmbPayType.SelectedValue.ToString();
            ihspaccount.HisOrderNo = hisOrderNo;
        
            ihspaccount.Cheque = tbxCheque.Text.Trim().ToString();
            ihspaccount.Bas_patienttype_id = this.cmbPatienttype.SelectedValue.ToString();
            ihspaccount.Num = "1";

            ihspaccount.Invoice = invoicecode;//发票
            ihspaccount.Nextinvoicesql = nextinvoicesql;//发票sql
            
            //费用
            ihspaccount.Feeamt = DataTool.FormatData(this.feetotal.ToString(), "2");
            //总预交款
            ihspaccount.Prepamt = DataTool.FormatData(this.paytotal.ToString(), "2");
            //payamt=  this.feetotal-this.paytotal;
            payamt = double.Parse(ihspaccount.Feeamt) - double.Parse(ihspaccount.Prepamt);

            ihspaccount.Balanceamt = DataTool.FormatData(payamt.ToString(), "2"); ;
          
           
            ihspaccount.Recivefee = this.tbxRecivefee.Text.Trim().ToString();
            ihspaccount.Retfee = this.tbxRetfee.Text.Trim().ToString();
            ihspaccount.Depart_id = ProgramGlobal.Depart_id;
            ihspaccount.Chargedby_id = ProgramGlobal.User_id;
            ihspaccount.Chargedate = BillSysBase.currDate();
            ihspaccount.Cancleby = "";
            ihspaccount.Ihsp_account_id = "";
            ihspaccount.Status = IhspAccountStatus.SETT.ToString();
         
            ihspaccount.Insurefee = "0";
            ihspaccount.Selffee = "0";
            IhspInvoicedet ihspInvoicedet = new IhspInvoicedet();
            ihspInvoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet.PaytypeId = cmbPayType.SelectedValue.ToString();
            ihspInvoicedet.PaysumbyId = billIhspAct.getPaysumby(cmbPayType.SelectedValue.ToString()); 
            
            ihspInvoicedet.Payfee = ihspaccount.Balanceamt;
            invoicedets.Clear();
            invoicedets.Add(ihspInvoicedet);

            string account_sql = "";
            if (str_neonate.Equals("neonate"))
                account_sql = billIhspAct.doAccount(ihspaccount, invoicedets, "neonate");
            else
                account_sql = billIhspAct.doAccount(ihspaccount, invoicedets, "selfcost");
            if(-1== billIhspMan.doExeSql(account_sql))//结算
            {
                MessageBox.Show("结算失败!请重试或联系工程师");
                return -1;
            }
            return 0;
        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            bool ret = true;
            double payfee = DataTool.stringToDouble(lblInBalanceamt.Text);
            if (!netpaytype.Equals("-1") && payfee>0)
            {
                NetPayIn netPayIn = new NetPayIn();
                NetPayOut netPayOut = new NetPayOut();
                NetpayBll netpayBll = new NetpayBll();
                string chk_authCode = tbx_authCode.Text.Trim();
                if (chk_authCode.Length < 18)
                {
                    tbx_authCode.Text = "";
                    MessageBox.Show("扫码失败，请重新扫码，后重新支付");
                    tbx_authCode.Focus();
                    return false;
                }
                if (chk_authCode.Length > 18)
                {
                    chk_authCode = chk_authCode.Substring(0, 18);
                }

                netPayIn.AuthCode = chk_authCode;
                netPayIn.Czyh = ProgramGlobal.User_id;
                hisOrderNo = netPayIn.OuterOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayIn.Paytype = netpaytype;
                netPayIn.StoreId = "0";
                netPayIn.Subject = "结算收款";
                netPayIn.Ddlx = "2";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "2";//订单来源（默认1）：1门诊;2住院
                netPayIn.Hzxm = lblName.Text;
                netPayIn.Lxdh = homephone;
                //netPayIn.Sfzh = idcard;
                netPayIn.Ysje = lblInBalanceamt.Text;
                netPayIn.Ksmc = lblDepart.Text;
                NetpayRetRes netpayRetRes = Netpay.execNetPay(netPayIn, netPayOut);
             
                NetPayData netPayData = new NetPayData();
                netPayData.AppCode = netPayIn.AppCode;
                netPayData.Czyh = netPayIn.Czyh;
                netPayData.Ddlx = netPayIn.Ddlx;
                netPayData.Ddly = netPayIn.Ddly;
                netPayData.InnerOrderNo = netPayOut.InnerOrderNo;
                netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
                netPayData.Jyrq = currDate;
                netPayData.Ksmc = netPayIn.Ksmc;
                netPayData.MerchantId = netPayIn.MerchantId;
                netPayData.MerId = netPayIn.MerId;
                netPayData.OrgCode = netPayIn.OrgCode;
                netPayData.OuterOrderNo = netPayIn.OuterOrderNo;
                netPayData.Paytype = netPayIn.Paytype;
                netPayData.SourceOuterOrderNo = "";
                netPayData.StoreId = netPayIn.StoreId;
                netPayData.TradeNo = netPayOut.TradeNo;
                netPayData.Ysje = netPayIn.Ysje;
                netPayData.Hzxm = netPayIn.Hzxm;
                netPayData.Sfzh = netPayIn.Sfzh;
                netPayData.Lxdh = netPayIn.Lxdh;
                netPayData.Yymc = ProgramGlobal.HspName;
                netPayData.Zfzt = "1"; //成功
                netPayData.Ihsp_id = this.ihsp_id;
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    netPayData.Zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {
                    netPayData.Zfzt = "-1";//失败[支付不确定]
                    ret = false;
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]支付成功";
                }
                netpayBll.saveToDb(netPayData);
                MessageBox.Show(mesg);
            }
            return ret;
        }
        /// <summary>
        /// 单击结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {            
              string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
           
                //if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
                //{
              btnAccount.Enabled = false;
                    if (actMethod() < 0)
                    {
                        btnAccount.Enabled = true;
                        return;
                    }
                    btnAccount.Enabled = true;
                //}
                FrmClickAccount frmClickAccount = new FrmClickAccount();
                frmClickAccount.getSource(ihspaccount.Invoice, ihsp_id, ihspaccount.Id);
                frmClickAccount.Patienttype = cmbPatienttype.SelectedValue.ToString();
                frmClickAccount.ShowDialog();
                if (frmClickAccount.DialogResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }           
       
     
      
        
        

       

        
      
       
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 实收变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRecivefee_TextChanged(object sender, EventArgs e)
        {
            string recivefee = "0.00";
            if (tbxRecivefee.Text != "")
            {
                if (!Regex.IsMatch(tbxRecivefee.Text, @"(\d+(\.\d+)?)"))
                {
                    MessageBox.Show("提示：实收金额填写格式有误!");
                    this.tbxRecivefee.Focus();
                    this.tbxRecivefee.Text = "";
                    return;
                }
                else
                {
                    recivefee = tbxRecivefee.Text;
                }
            }
            double retfee = double.Parse(DataTool.FormatData(recivefee, "2")) - double.Parse(DataTool.FormatData(lblInBalanceamt.Text, "2"));
            this.tbxRetfee.Text = DataTool.FormatData(retfee.ToString(), "2");
        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;
            tbx_authCode.ReadOnly = true;
            tbx_authCode.Text = "";
            NetpayBll netpayBll = new NetpayBll();
             netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
            if (netpaytype != "-1")
            {
                tbx_authCode.ReadOnly = false;
                tbx_authCode.Clear();
                tbx_authCode.Focus();
                lblInvoiceMsg.Text = "现在选择网络支付";

            }
            else
            {
                lblInvoiceMsg.Text = "                    ";
            }
        }


    }
}
