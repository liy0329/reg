using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
///using WebAPI;
//using guizhousheng.Util;
//using guizhousheng.Common;
using MTREG.medinsur.gzsyb.listitem;
using MTREG.medinsur.gzsnh.bll;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.common;
using MTREG.medinsur.gzsnh.bo;
using MTREG.ihsp.bo;
using MTREG.ihsp;
using MTREG.netpay;
using MTREG.netpay.bo;
//using guizhousheng.global;
//using guizhousheng.db;
//using guizhousheng.Entity;
//using guizhousheng.nh;
//using guizhousheng.Report_form;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmdoAccount : Form
    {
        public FrmdoAccount()
        {
            InitializeComponent();
        }
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        BillIhspAct bllIhspAct = new BillIhspAct();
        BillIhspcost billIhspcost = new BillIhspcost();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillCmbList billCmbList = new BillCmbList();
        WebClient webClient = new WebClient();
       
        private string netpaytype = "-1";//网路支付类型
        private string homephone = "";
        private string idcard = "";
        private string ihspname = "";
        private string deparname = "";

        private string inpatientsn;

        public string Inpatientsn
        {
            get { return inpatientsn; }
            set { inpatientsn = value; }
        }
        private string outdate;

        public string Outdate
        {
            get { return outdate; }
            set { outdate = value; }
        }
        private string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string ylfkfs;

        public string Ylfkfs
        {
            get { return ylfkfs; }
            set { ylfkfs = value; }
        }
        private string member_id;

        private string centerno;
        public string Centerno
        {
            get { return centerno; }
            set { centerno = value; }
        }

        private void frmCharge_Load(object sender, EventArgs e)
        {
            inipage();
        }
        public void inipage()
        {
            cbx_bclx.DisplayMember = "name";
            cbx_bclx.ValueMember = "code";
            cbx_bclx.DataSource = bllGzsnhMethod.getHisnhbcflcx();

            dtp_cysj.Text = outdate;

            List<ListItem> hslb = new List<ListItem>();
            ListItem item1 = new ListItem("1", "预结算");
            ListItem item2 = new ListItem("2", "正式结算");
            hslb.Add(item1);
            hslb.Add(item2);
            cbx_hslx.DisplayMember = "Text";
            cbx_hslx.ValueMember = "Value";
            cbx_hslx.DataSource = hslb;
            cbx_bclx.SelectedIndex = 0;
            //cbx_hslx.ValueMember = "id";


            List<ListItem> sfcl = new List<ListItem>();
            ListItem sfcl1 = new ListItem("0", "未提供");
            ListItem sfcl2 = new ListItem("1", "已提供");
            //ListItem sfcl3 = new ListItem("-1", "");
            sfcl.Add(sfcl1);
            sfcl.Add(sfcl2);
            //sfcl.Add(sfcl3);
            cbx_sftgcl.DisplayMember = "Text";
            cbx_sftgcl.ValueMember = "Value";
            cbx_sftgcl.DataSource = sfcl;
            cbx_sftgcl.SelectedIndex = 1;

            DataTable dt = new DataTable();
            dt = billCmbList.payPaytypeList();
            this.cmbPayType.ValueMember = "id";
            this.cmbPayType.DisplayMember = "name";
            this.cmbPayType.DataSource = dt;
            this.cmbPayType.SelectedValue = 1;

            this.btn_enter.Enabled = false;
          
            this.tbx_yjk.Text =  bllIhspAct.getHisPayinadvSum(ihsp_id);
            this.tbx_yyfy.Text = bllIhspAct.getHisCostDetSum(ihsp_id);
            DataTable cyxx = bllGzsnhMethod.getHisIhspInsurInfo(ihsp_id); 
            this.inpatientsn = cyxx.Rows[0]["inpatientsn"].ToString();
            this.outdate = Convert.ToDateTime(cyxx.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"); 
            this.ylfkfs = cyxx.Rows[0]["bas_patienttype_id"].ToString();
            member_id = cyxx.Rows[0]["member_id"].ToString();
            this.centerno = cyxx.Rows[0]["centerno"].ToString();
            dt = billIhspcost.ihspIdSearch(ihsp_id);


            ihspname = dt.Rows[0]["ihspname"].ToString();
            deparname = dt.Rows[0]["deparname"].ToString();
            idcard = dt.Rows[0]["idcard"].ToString();
            homephone = dt.Rows[0]["homephone"].ToString();

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            btn_enter.Enabled = false;
            if (!doAccount())
            {
                btn_enter.Enabled = true;
                return;
            }
        
            this.Close();
        }

        private void nhYjs()
        {
            string returnMsg = "";
            if (!bllGzsnhMethod.uploadDetials(ihsp_id, ref returnMsg))
            {
                MessageBox.Show(returnMsg + "费用上传失败，请重新预结算");
                return;
            }

            Yjs_data jsdata = new Yjs_data();
            string sftgcl = "";
            if (cbx_sftgcl.SelectedValue.ToString() != "-1")
                sftgcl = cbx_sftgcl.SelectedValue.ToString();//身份证累呗
            string bclx = cbx_bclx.SelectedValue.ToString();
             List<Dictionary<int, string>> bcxxList = new List<Dictionary<int,string>>();
             bool ret =bllGzsnhMethod.nhYjs(ihsp_id, sftgcl, bclx, ref  jsdata, bcxxList);
             if (!ret)
             {
                 MessageBox.Show("预结算后失败");
                 return;
             }
             BillSysBase.doIhspAmt(ihsp_id);
             tbx_jsxx.Text = jsdata.Jsxx;
             tbx_nhbx.Text = jsdata.Nhbx;
             tbx_nhfy.Text = jsdata.Nhfy;
             tbxInBalanceamt.Text = DataTool.FormatData((Convert.ToDouble(tbx_yyfy.Text) - Convert.ToDouble(tbx_yjk.Text) - Convert.ToDouble(tbx_nhbx.Text)).ToString(),"2");
             dtv_fdxx.Rows.Clear();
             for (int j = 0; j < bcxxList.Count; j++)
             {
                 Dictionary<int, string> gradeList = bcxxList[j];
                 dtv_fdxx.Rows.Add();
                 for (int l = 0; l < gradeList.Count; l++)
                 {
                     dtv_fdxx.Rows[j].Cells[l].Value = gradeList[l];
                 }
             }
             this.btn_enter.Enabled = true;
        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            double payfee = DataTool.stringToDouble(tbxInBalanceamt.Text);
            bool ret = true;
            if (!netpaytype.Equals("-1") && payfee > 0)
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
                netPayIn.Hzxm = ihspname;
                netPayIn.Lxdh = homephone;
                //netPayIn.Sfzh = idcard;
                netPayIn.Ysje = tbxInBalanceamt.Text;
                netPayIn.Ksmc = deparname;
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
        private bool doAccount()
        {




            //发票号
            string invoiceKind = bllIhspAct.getInvoiceKind(this.ylfkfs);
            string invoicecode="";
            string nextinvoicesql="";
            if (tbx_nhbx.Text.ToString().Equals(""))
            {
                MessageBox.Show("请先预结算后，再点击结算");
               return false;
            }
            //新生儿
            double neonSum = DataTool.stringToDouble(bllIhspAct.getHisNeonCostDetSum(ihsp_id));
            if (Math.Abs(neonSum) > 0.001)
            {
                MessageBox.Show("请先新生儿结算后再结算！(新生儿住院总费用为：" + neonSum);
            
                return false;
            }

            double yyfy = DataTool.stringToDouble(tbx_yyfy.Text.ToString());
            double nhfy = DataTool.stringToDouble(tbx_nhfy.Text.ToString());
            double yjk = DataTool.stringToDouble(tbx_yjk.Text);
            if (Math.Abs(nhfy-yyfy)>0.001)
            {
                MessageBox.Show("医院费用与农合费用不一致，不能结算");
              
                return false;
            }
            if (invoiceKind == "")
            {
                MessageBox.Show("获取发票类型时,未找到对应发票类型!");

                return false;
            }
          

            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(),invoiceKind,ref invoicecode, ref nextinvoicesql))
            {
                MessageBox.Show("发票已用完，不能进行收费！");

                return false;
            }

            //网络支付
            string hisOrderNo = "";
            string currDate = BillSysBase.currDate();
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return false;
                
            //网络支付_END

            string sftgcl = "";
            if (cbx_sftgcl.SelectedValue.ToString() != "-1")
                sftgcl = cbx_sftgcl.SelectedValue.ToString();
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<int, string> gradeList = new Dictionary<int, string>();
            string url = GzsnhGlobal.Url + "inpatientCalculate?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(centerno) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(inpatientsn) + "&redeemNo=" + Base64.encodebase64(cbx_bclx.SelectedValue.ToString()) + "&outDate=" + Base64.encodebase64(outdate) + "&type=" + Base64.encodebase64("2") + "&isMaterials=" + Base64.encodebase64(sftgcl) + "&operationName=" + Base64.encodebase64(ProgramGlobal.Username) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("\"", "").Replace(",gradeList:", "@").Split('@');
                    string[] firstp = info[0].Replace("{", "").Replace("}", "").Split(',');
                    for (int i = 0; i < firstp.Length; i++)
                    {
                        string[] item = firstp[i].Split(':');
                        result.Add(item[0], Base64.decodebase64(item[1]));
                    }
                    //基金支付金额
                    double nhbx = Convert.ToDouble(result["calculateMoney"]);
                    //民政优抚医疗补助
                    double mzbz = 0;
                    if (result["YFmedicalAid"] != "")
                        mzbz = Convert.ToDouble(result["YFmedicalAid"]);
                    //民政城乡医疗救助
                    double cxbz = 0;
                    if (result["CXmedicalAid"] != "")
                        cxbz = Convert.ToDouble(result["CXmedicalAid"]);
                    //本次大病保险补偿金额
                    double dbbx = 0;
                    if (result["CIICalculateMoney"] != "")
                        dbbx = Convert.ToDouble(result["CIICalculateMoney"]);
                    //慈善总会支付金额
                    double csbz = 0;
                    if (result["ChinaCharityPay"] != "")
                        csbz = Convert.ToDouble(result["ChinaCharityPay"]);
                    //计生两户减免费用金额
                    double jsbz = 0;
                    if (result["FamilyPlanningWaiver"] != "")
                        jsbz = Convert.ToDouble(result["FamilyPlanningWaiver"]);
                    double zbx = nhbx + mzbz + cxbz + dbbx + csbz + jsbz;
                    double jssk = nhfy - zbx - yjk;

                    int p = bllGzsnhMethod.accountNhStat(ihsp_id);
                    if (p == -1)
                        MessageBox.Show("农合结算成功，数据更新失败");
                    p = bllGzsnhMethod.doAccNhJsxx(result, ihsp_id);
                    if (p == -1)
                        MessageBox.Show("农合结算成功，数据更新失败");
                    /*
                    string[] secondp = info[1].Replace("[", "").Replace("]", "").Replace("},{", "@").Replace("{", "").Replace("}", "").Split('@');
                    for (int j = 0; j < secondp.Length; j++)
                    {
                        if (secondp[j] == "")
                        {
                            continue;
                        }
                        string[] item1 = secondp[j].Split(',');
                        for (int k = 0; k < item1.Length; k++)
                        {
                            string[] item2 = item1[k].Split(':');
                            gradeList.Add(k, Base64.decodebase64(item2[1]));
                        }
                        if (cbx_hslx.SelectedValue.ToString() == "2")
                        {
                            int ret = bllGzsnhMethod.doAccNhbcfdxx(gradeList, ihsp_id);
                            if (ret == -1)
                                MessageBox.Show("农合结算成功，数据更新失败");
                        }
                        gradeList.Clear();
                    }*/
                    
                    Ihspaccount ihspaccount = new Ihspaccount();
                    List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();
                        
                    ihspaccount.Id = BillSysBase.nextId("ihsp_account");
                    ihspaccount.Ihsp_id = ihsp_id;
                    ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
                    ihspaccount.Member_id = member_id;
                    ihspaccount.Bas_paytype_id = this.cmbPayType.SelectedValue.ToString();
                    ihspaccount.HisOrderNo = hisOrderNo;
                 
                    ihspaccount.Cheque = tbxCheque.Text.Trim().ToString();
                    ihspaccount.Bas_patienttype_id = this.ylfkfs;
                    ihspaccount.Num = "1";
                    //发票号
                      
                    ihspaccount.Invoice = invoicecode;//发票
                    ihspaccount.Nextinvoicesql = nextinvoicesql;//发票sql
                    //费用
                    ihspaccount.Feeamt = DataTool.FormatData(nhfy.ToString(), "2");
                    //总预交款
                    ihspaccount.Prepamt = DataTool.FormatData(yjk.ToString(), "2");
                    ihspaccount.Insurefee = DataTool.FormatData(zbx.ToString(), "2");
                    ihspaccount.Selffee = "0";
                    ihspaccount.Balanceamt = DataTool.FormatData(jssk.ToString(), "2");
                    ihspaccount.Depart_id = ProgramGlobal.Depart_id;
                    ihspaccount.Chargedby_id = ProgramGlobal.User_id;
                    ihspaccount.Chargedate = currDate;
                    ihspaccount.Cancleby = "0";
                    ihspaccount.Ihsp_account_id = "0";
                    ihspaccount.Status = IhspAccountStatus.SETT.ToString();

                    IhspInvoicedet invoicedet = new IhspInvoicedet();
                    invoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
                    invoicedet.IhspAccountId = ihspaccount.Id;
                    invoicedet.PaytypeId = this.cmbPayType.SelectedValue.ToString();
                    invoicedet.PaysumbyId = bllIhspAct.getPaysumby(invoicedet.PaytypeId);
                    invoicedet.Payfee = DataTool.FormatData(jssk.ToString(), "2");
                    invoicedet.Billcode = ihspaccount.Cheque;
                    invoicedets.Add(invoicedet);
                    IhspInvoicedet invoicedet1 = new IhspInvoicedet();
                    invoicedet1.Id = BillSysBase.nextId("ihsp_invoicedet");
                    invoicedet1.IhspAccountId = ihspaccount.Id;
                    invoicedet1.PaytypeId = bllIhspAct.getInsurFeePaytypeId();
                    invoicedet1.PaysumbyId = bllIhspAct.getPaysumbyKeyname("GZSNH"); //医保报销
                    invoicedet1.Payfee = DataTool.FormatData(zbx.ToString(), "2");
                    invoicedet1.Billcode = "";
                    invoicedets.Add(invoicedet1);
                    string account_sql = bllIhspAct.accountInsurStat(ihsp_id);//医保状态信息
                    account_sql += bllIhspAct.doAccount(ihspaccount, invoicedets, "insur");
                    if (-1 == billIhspMan.doExeSql(account_sql))//结算
                    {
                        MessageBox.Show("HIS结算失败, 请及时处理农合已结算信息, 结算时用网络支付请及时退网络支付费用");
                        return false;
                    }
                   //发票
                   FrmClickAccount frmClickAccount = new FrmClickAccount();
                  frmClickAccount.getSource(ihspaccount.Invoice, ihsp_id, ihspaccount.Id);
                  frmClickAccount.Patienttype = this.ylfkfs;
                  frmClickAccount.ShowDialog();
                  return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return false;
            }
          
        }
        public void zyjsfpdy()//发票打印
        {
            string path_rpt = @"..\..\Report_form\CrystalReportZydyfp.rpt";
            path_rpt = System.IO.Path.GetFullPath(path_rpt);
            CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            doc.Load(path_rpt);
            //doc.PrintOptions.PrinterName = "\\\\2014-0803-1830\\报补单";//192.168.2.3报补单打印机名称            
            System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
            int rawKind = 1;
            for (int i = 0; i < print.PrinterSettings.PaperSizes.Count; i++)
            {
                if (print.PrinterSettings.PaperSizes[i].PaperName == "mtzyfp")
                {
                    rawKind = print.PrinterSettings.PaperSizes[i].RawKind;
                    break;
                }
            }
            doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
          //  doc.SetDataSource(Cdfp());
            doc.PrintToPrinter(1, false, 0, 0);
        }
        //public List<Zydyfp> Cdfp()
        //{
        //    //String cyjsmtzyjl_iid = this.mtzyjl_iid;
        //    List<Zydyfp> Zydyfps = new List<Zydyfp>();
        //    Zydyfp zydyfp = new Zydyfp();
        //    String cwf = "";//床位费 
        //    double zcf = 0;//诊查费
        //    double jcf = 0;//检查费
        //    double zlf = 0;//治疗费
        //    String hlf = "";//护理费
        //    String ssf = "";//手术费
        //    double hyf = 0;//化验费
        //    String xyf = "";//西药费
        //    String zcy = "";//中成药
        //    String cy = "";//中草药
        //    double qt = 0;//其他
        //    String sxf = "";//输血费
        //    DataTable datafpdy = getdata.zydyfp(hiszyh).Tables[0];
        //    for (int i = 0; i < datafpdy.Rows.Count; i++)
        //    {
        //        if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
        //        {
        //            cwf = datafpdy.Rows[i]["Amt"].ToString();//床位费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
        //        {
        //            zcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊查费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复"))
        //        {
        //            zlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费"))
        //        {
        //            hlf = datafpdy.Rows[i]["Amt"].ToString();//护理费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费"))
        //        {
        //            ssf = datafpdy.Rows[i]["Amt"].ToString();//手术费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
        //        {
        //            hyf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
        //            continue;
        //        }
        //        if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药"))
        //        {
        //            xyf = datafpdy.Rows[i]["Amt"].ToString();//西药费
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药"))
        //        {
        //            zcy = datafpdy.Rows[i]["Amt"].ToString();//中成药
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
        //        {
        //            cy = datafpdy.Rows[i]["Amt"].ToString();//中草药
        //            continue;
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费"))
        //        {
        //            if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
        //            {
        //                jcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
        //                continue;
        //            }
        //        }
        //        else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
        //        {
        //            sxf = datafpdy.Rows[i]["Amt"].ToString();//输血费
        //            continue;
        //        }
        //        else
        //        {
        //            qt += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他
        //            continue;
        //        }
        //    }
        //    DataTable grxx = getdata.GetDyfpbyszyb(hiszyh).Tables[0];
        //    zydyfp.Cwf = Global.Getdouble(cwf).ToString("0.00");
        //    zydyfp.Zcf = Global.Getdouble(zcf.ToString()).ToString("0.00");
        //    zydyfp.Jcf = Global.Getdouble(jcf.ToString()).ToString("0.00");
        //    zydyfp.Zlf = Global.Getdouble(zlf.ToString()).ToString("0.00");
        //    zydyfp.Hlf = Global.Getdouble(hlf).ToString("0.00");
        //    zydyfp.Ssf = Global.Getdouble(ssf).ToString("0.00");
        //    zydyfp.Hyf = Global.Getdouble(hyf.ToString()).ToString("0.00");
        //    zydyfp.Xy = Global.Getdouble(xyf).ToString("0.00");
        //    zydyfp.Zcy = Global.Getdouble(zcy).ToString("0.00");
        //    zydyfp.Cy = Global.Getdouble(cy).ToString("0.00");
        //    zydyfp.Qt = Global.Getdouble(qt.ToString()).ToString("0.00");
        //    zydyfp.Sxf = Global.Getdouble(sxf).ToString("0.00");
        //    double yjk_xj = 0;
        //    double yjk_zp = 0;
        //    double yjk_hj = 0;
        //    for (int i = 0; i < grxx.Rows.Count; i++)
        //    {
        //        if (grxx.Rows[i]["mtylfkfs_iid"].ToString().Equals("144") || grxx.Rows[i]["mtylfkfs_iid"].ToString().Equals("136"))
        //        {
        //            yjk_xj += double.Parse(grxx.Rows[i]["amt"].ToString());
        //        }
        //        else
        //        {
        //            yjk_zp += double.Parse(zydyfp.Yskzp = grxx.Rows[i]["amt"].ToString());
        //        }
        //        yjk_hj += double.Parse(grxx.Rows[i]["amt"].ToString());
        //    }
        //    zydyfp.Zyh = hiszyh;
        //    zydyfp.Yskhj = yjk_hj.ToString("0.00");// 预交款合计
        //    zydyfp.Yskxj = yjk_xj.ToString("0.00");//预交款现金
        //    zydyfp.Yskzp = yjk_zp.ToString("0.00");//预交款支票
        //    DataTable Dygrxx = getdata.GetDygrxx(hiszyh).Tables[0];
        //    zydyfp.Xm = Dygrxx.Rows[0]["hzxm"].ToString();
        //    zydyfp.Xb = Dygrxx.Rows[0]["xb"].ToString();
        //    zydyfp.Zyks = Dygrxx.Rows[0]["org_name"].ToString();
        //    zydyfp.Cwh = Dygrxx.Rows[0]["cwh"].ToString();
        //    zydyfp.Zysj = Dygrxx.Rows[0]["zysj"].ToString();
        //    zydyfp.Cysj = Dygrxx.Rows[0]["cysj"].ToString();
        //    zydyfp.Zyts = Dygrxx.Rows[0]["zyts"].ToString();
        //    zydyfp.Fph = Dygrxx.Rows[0]["fph"].ToString();
        //    zydyfp.Zyjzsj = Dygrxx.Rows[0]["zyjzsj"].ToString();
        //    money m = new money(Global.Getdouble(zydyfp.Yskxj) - yjk_xj - yjk_zp); //预交款
        //    zydyfp.Ssxjdx = m.Convert();
        //    zydyfp.Ssxj = (Global.Getdouble(zydyfp.Yskxj) - yjk_xj - yjk_zp).ToString("0.00");
        //    zydyfp.Fyze = Global.Getdouble(Dygrxx.Rows[0]["amt"].ToString()).ToString("0.00");//费用合计
        //    zydyfp.Hj = Global.Getdouble(zydyfp.Fyze).ToString("0.00");
        //    money n = new money(Global.Getdouble(zydyfp.Fyze));
        //    zydyfp.Fyzedx = n.Convert();
        //    zydyfp.Sfy = Global.Myuser;
        //    zydyfp.Djh = getdata.Getcybr().Tables[0].Rows[0]["lsh"].ToString();
        //    DataTable szybfy = getdata.GetJsxx(hiszyh).Tables[0];
        //    //zydyfp.Dw = szybfy.Rows[0]["aab004"].ToString();//单位名称
        //    zydyfp.Dyxslb = szybfy.Rows[0]["redeemtypename"].ToString();//医疗人员类别名称
        //    zydyfp.Grbh = szybfy.Rows[0]["memberno"].ToString();//个人编号
        //    //zydyfp.Bnzycs = szybfy.Rows[0]["bnzycs"].ToString();//本年次住院次数
        //    zydyfp.Fylb = "贵阳农合";// szybfy.Rows[0]["aka130"].ToString();//费用类别
        //    //zydyfp.Dyxslb = szybfy.Rows[0]["akc021"].ToString();//待遇享受类别
        //    // zydyfp.Ddyljgjb = szybfy.Rows[0]["aka101"].ToString();//定点医疗结构级别
        //    String strjbtczf = szybfy.Rows[0]["calculateMoney"].ToString();//基本统筹支付
        //    String strdbtczf = szybfy.Rows[0]["personalpaymoney"].ToString() == "0" ? "0" : (double.Parse(szybfy.Rows[0]["totalcosts"].ToString()) - double.Parse(szybfy.Rows[0]["personalpaymoney"].ToString())).ToString();//大病统筹支付
        //    String strgwytczf = "0.00";//公务员统筹支付
        //    String strgrzf = "0.00";//个人帐户支付
        //    String strxjzf = (double.Parse(szybfy.Rows[0]["totalcosts"].ToString()) - double.Parse(szybfy.Rows[0]["startmoney"].ToString())).ToString();//现金支付
        //    String strzje = szybfy.Rows[0]["totalcosts"].ToString();//总费用
        //    double double_jbtczf = Global.Getdouble(strjbtczf);//基本统筹支付
        //    double double_dbtczf = Global.Getdouble(strdbtczf);//大病统筹支付
        //    double double_gwytczf = Global.Getdouble(strgwytczf);//公务员统筹支付
        //    double double_grzf = Global.Getdouble(strgrzf);//个人帐户支付
        //    // double double_xjzf = util.Getdouble(strxjzf);//现金支付
        //    double double_zje = Global.Getdouble(strzje);//总金额
        //    double jjzfhj = double_jbtczf + double_dbtczf + double_gwytczf;//统筹报销金额
        //    //计算实收现金_
        //    double double_xjzf = double_zje - double_grzf - jjzfhj;//
        //    money m_sz = new money(double_xjzf);
        //    zydyfp.Ssxjdx = m_sz.Convert();
        //    zydyfp.Ssxj = double_xjzf.ToString("0.00");//实收现金
        //    //计算实收现金_end
        //    zydyfp.Jjhj = jjzfhj.ToString("0.00");//基金合计
        //    zydyfp.Grzh = double_grzf.ToString("0.00");//个人账户
        //    zydyfp.Tcjj = double_jbtczf.ToString("0.00");//统筹基金;
        //    zydyfp.Debz = double_dbtczf.ToString("0.00");//大额补助
        //    zydyfp.Xjzf = double_xjzf.ToString("0.00");//现金支付
        //    zydyfp.Gwybz = double_gwytczf.ToString("0.00");//公务员补助
        //    zydyfp.Dedbbzm = "医院承担";
        //    zydyfp.Gwylbzm = "民政补助";

        //    double double_zlje = yjk_hj - double_xjzf;//找零金额
        //    if (double_zlje > 0)
        //    {
        //        zydyfp.Ysktk = double_zlje.ToString("0.00");
        //        zydyfp.Yskbk = "0.00";
        //    }
        //    else
        //    {
        //        zydyfp.Ysktk = "0.00";
        //        zydyfp.Yskbk = (-double_zlje).ToString("0.00");
        //    }
        //    Zydyfps.Add(zydyfp);
        //    return Zydyfps;
        //}
        //public void zyjsdy()//结算单打印
        //{
        //    string path_rpt = @"..\..\Report_form\CrystalReport_Fpdy.rpt";
        //    path_rpt = System.IO.Path.GetFullPath(path_rpt);
        //    CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //    doc.Load(path_rpt);
        //    //doc.PrintOptions.PrinterName = "\\\\2014-0803-1830\\报补单";//192.168.2.3报补单打印机名称            
        //    //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //    doc.SetDataSource(sdCdfp());
        //    doc.PrintToPrinter(1, false, 0, 0);
        //}
        public List<frmnhzy> sdCdfp()
        {
            //List<frmnhzy> sourse = new List<frmnhzy>();
            //frmnhzy data = new frmnhzy();
            //DataTable zydynh = getdata.zyjsdy(hiszyh).Tables[0];
            //DataTable zydyhis = getdata.zyjsdyhis(hiszyh).Tables[0];
            //data.Address = zydynh.Rows[0]["address"].ToString();
            //data.Age = (int.Parse(DateTime.Now.ToString().Substring(0, 4)) - int.Parse(zydynh.Rows[0]["birthday"].ToString().Substring(0, 4))).ToString();
            //data.Bcje = zydynh.Rows[0]["startMoney"].ToString();
            //money mm = new money(double.Parse(zydynh.Rows[0]["startMoney"].ToString()));
            //data.Bcjedx = mm.Convert();
            //data.Bcjg = "贵州省骨科医院";
            //data.Bclx = zydynh.Rows[0]["redeemtypename"].ToString();
            //data.Bkbfy = (double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["enablemoney"].ToString())).ToString();
            //data.Bzfyde = zydynh.Rows[0]["fundpaymoney"].ToString() == "0" ? "" : zydynh.Rows[0]["fundpaymoney"].ToString();
            //data.Clcxzf = zydynh.Rows[0]["materialmoney"].ToString() == "0" ? "" : zydynh.Rows[0]["materialmoney"].ToString();
            //data.Cyrq = zydyhis.Rows[0]["zyjlcysj"].ToString();
            //data.Cyzd = zydyhis.Rows[0]["zyjlmzzd"].ToString();
            //data.Dbybpf = zydynh.Rows[0]["personalpaymoney"].ToString() == "0" ? "" : (double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["personalpaymoney"].ToString())).ToString();
            //data.Fph = zydyhis.Rows[0]["fph"].ToString();
            //data.Grsx = zydynh.Rows[0]["identityname"].ToString();
            //data.Grzfje = (double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["startmoney"].ToString())).ToString();
            //data.Hzname = zydynh.Rows[0]["name"].ToString();
            //data.Hzxm = zydynh.Rows[0]["mastername"].ToString();
            //data.Jjsjbcje = zydynh.Rows[0]["calculateMoney"].ToString();
            //data.Jyjg = "贵州省骨科医院";
            //data.Kbfy = zydynh.Rows[0]["enablemoney"].ToString();
            //data.Mzjxje = (double.Parse(zydynh.Rows[0]["yfmedicalaid"].ToString()) + double.Parse(zydynh.Rows[0]["cxmedicalaid"].ToString())).ToString();
            //data.Qfx = "";
            //data.Ryrq = zydyhis.Rows[0]["zyjlrysj"].ToString();
            //data.Sex = zydynh.Rows[0]["sexname"].ToString();
            //data.Sfzz = "否";
            //data.Tbtgbce = zydynh.Rows[0]["anlagernmoney"].ToString();
            //data.Tel = zydyhis.Rows[0]["h_tel"].ToString();
            //data.Ylzh = zydynh.Rows[0]["bookno"].ToString();
            //data.Yycdje = zydynh.Rows[0]["hospassumemoney"].ToString();
            //data.Yyfy = zydynh.Rows[0]["curryeartotal"].ToString();
            //data.Zdjb = zydynh.Rows[0]["personalpaymoney"].ToString() == "0" ? "否" : "是";
            //data.Zfy = zydynh.Rows[0]["totalcosts"].ToString();
            //data.Zlfs = "";
            //data.Zycs = zydynh.Rows[0]["curryearredeemcount"].ToString();
            //data.Zyh = zydynh.Rows[0]["hiszyh"].ToString();
            //sourse.Add(data);
            //return sourse;
            return null;
        }

        private void btn_yjs_Click(object sender, EventArgs e)
        {
            
            nhYjs();
        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;
            tbx_authCode.ReadOnly = true;
            tbx_authCode.Text = "";
            NetpayBll netpayBll = new NetpayBll();
            string netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
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
