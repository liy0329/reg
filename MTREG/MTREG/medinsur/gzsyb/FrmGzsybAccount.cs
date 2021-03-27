using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using guizhousheng.gzswyb.gzsswybInterfaces;
//using guizhousheng.db;
using MTREG.medinsur.gzsyb.gzswyb.common;
//using guizhousheng.gzswyb.baseOperation;
using MTREG.medinsur.gzsyb.Util;
//using guizhousheng.gzsszyb;
using System.IO;
using MTREG.medinsur.gzsyb.listitem;
//using guizhousheng.Common;
using MTREG.medinsur.gzsyb.Report_form;
using MTREG.medinsur.gzsyb.bll;
using MTREG.ihsp.bll;
using MTREG.common;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.ihsp;
using MTREG.ihsp.bo;
using MTREG.netpay;
using MTREG.netpay.bo;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmGzsybAccount : Form
    {
        public FrmGzsybAccount()
        {
            InitializeComponent();
        }
        string ybbx = "";
    
        Gzsybservice Swybservice = new Gzsybservice();
        BillIhspAct billIhspAct = new BillIhspAct();
        BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
        BillCmbList billCmbList = new BillCmbList();

        string invoicecode = "";//发票号
        string nextinvoicesql = "";//发票号sql

        private string ihsp_id; //住院记录iid
        String yjk = "";
        
        private string netpaytype = "-1";//网路支付类型
        private string homephone = "";
        private string idcard = "";
        private string departname = "";
       
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string patienttype_id; //患者类型

        private string zyjlzyh;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyjlzyh
        {
            get { return zyjlzyh; }
            set { zyjlzyh = value; }
        }
        private string sickname;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        private string sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }


        /// <summary>
        /// 获取FrmIhospCost数据
        /// </summary>
        public void getSource(string id)
        {
            this.ihsp_id = id;
           
        }
        private void buttoncybl_Click(object sender, EventArgs e)
        {
            string cyyy = swcyyy.SelectedValue.ToString();
            string currDateTime =BillSysBase.currDate();

            if (bllInsurIhspGZS.Cybl(ihsp_id, cyyy, currDateTime))
            {
                MessageBox.Show("出院办理成功");
            }
        }

        private void buttoncyht_Click(object sender, EventArgs e)
        {
            if (bllInsurIhspGZS.CyblHt(ihsp_id))
            {
                MessageBox.Show("出院回退成功");
            }
        }
        private void buttonyjs_Click(object sender, EventArgs e)
        {
            string returnMsg = "";
            bllInsurIhspGZS.Fymxdr(ihsp_id, ref returnMsg);
            Yjs_retdata retdata = new Yjs_retdata();
            if (bllInsurIhspGZS.Yjsan(ihsp_id, ref retdata))
            {
                buttonjs.Enabled = true;
                MessageBox.Show("预结算成功");
            }
            BillSysBase.doIhspAmt(ihsp_id);
            yjsgrbh.Text = retdata.Aac001;
            yjsjbsj.Text = retdata.Aae036;
            yjsfyze.Text = retdata.Yka055;
            yjsqzfbf.Text = retdata.Yka056;
            yjsxxzf.Text = retdata.Yka057;
            yjsfhfw.Text = retdata.Yka111;
            yjsbzqfx.Text = retdata.Yka058;
            bzjbyl.Text = retdata.Yka248;
            yjsbzdbyl.Text = retdata.Yka062;
            yjsbzgwybx.Text = retdata.Yke030;
            yjsqsfzx.Text = retdata.Ykb037;
            yjsqslb.Text = retdata.Yka316;
            yjsqsfs.Text = retdata.Yka054;
            yjsqsqh.Text = retdata.Yae366;
            tbx_grzhkyye.Text = retdata.Zhyjj;
            //  yjszhkzf.Text = zhkzf;//账户支付
            tbx_grzhye.Text =  bllInsurIhspGZS.getGrzhye(ihsp_id);

            //计算个人账户支付和应收现金
            //write by wzw 2014-5-13_12:29
            //总费用
            double d_yyzfy = DataTool.stringToDouble(yjszje.Text);

            //医保报销  = 基本医疗统筹支付金额 + 大额医疗支付金额 + 公务员补助报销金额
            double d_ybbx = DataTool.stringToDouble(retdata.Yka248) + DataTool.stringToDouble(retdata.Yka062) + DataTool.stringToDouble(retdata.Yke030);
            ybbx = d_ybbx.ToString("0.00");
            //个人应付 = 总费用 - 医保报销
            double d_gryfje = d_yyzfy - d_ybbx;
            //账户余额
            double d_grzhye = DataTool.stringToDouble(this.tbx_grzhye.Text.Trim());
            double d_grzhzf = 0;
            //个人账户最大支付= 个人应付- 全自费
            double d_zhmax_zf = d_gryfje - DataTool.stringToDouble(yjsqzfbf.Text);
            //个人账户最大支付 < 个人账户余额
            if (d_zhmax_zf < d_grzhye)
            {
                d_grzhzf = d_zhmax_zf;
            }
            //个人账户最大支付 >=个人账户余额
            else
            {
                d_grzhzf = d_grzhye;
            }
            tbx_grzhkyye.Text = d_grzhzf.ToString("0.00");
            //赋值个人账户支付
            grzhzf.Text = d_grzhzf.ToString("0.00");

            //预交款金额
            double d_yjkje = DataTool.stringToDouble(yjk);
            //计算个人应收金额 {应收金额= [个人应付-个人账户支付-预交金额]}
            double d_grysje = d_gryfje - d_grzhzf - d_yjkje;
            //赋值收费员应收金额
            tbxPayfee.Text = d_grysje.ToString("0.00");

        }
        //初始化结算交款方式
        private void cshjkfs()
        {
       
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                cmbPayType.ValueMember = "id";
                cmbPayType.DisplayMember = "name";
                cmbPayType.DataSource = dtpt;
                cmbPayType.SelectedValue = "1";
            }
            
        }
        private void Frm_swyjs_Load(object sender, EventArgs e)
        {
          
        DataTable dt= bllInsurIhspGZS.getAccIhspInfo(this.ihsp_id);
        string status = dt.Rows[0]["status"].ToString();
        if (status == "SETT")
        {
            this.btn_canCostDet.Enabled = false;
            this.buttoncybl.Enabled = false;
            this.buttonyjs.Enabled = false;
            this.buttonjs.Enabled = false;
        }
           Cshhs();
           yjk = billIhspAct.getHisPayinadvSum(this.ihsp_id);
           this.tbx_yjk.Text = yjk;
           this.tbx_sickname.Text = dt.Rows[0]["ihspname"].ToString();
           this.tbx_sex.Text =  dt.Rows[0]["sex"].ToString();
           this.tbx_zyjlzyh.Text = dt.Rows[0]["ihspcode"].ToString();
           this.idcard =  dt.Rows[0]["idcard"].ToString();
           this.homephone = dt.Rows[0]["homephone"].ToString();
           departname = dt.Rows[0]["departname"].ToString();
           yjszje.Text = billIhspAct.getHisCostDetSum(this.ihsp_id);
           
           this.patienttype_id = dt.Rows[0]["bas_patienttype_id"].ToString();
           string invoiceKind = billIhspAct.getInvoiceKind(this.patienttype_id);
           
           int invoiceNum = billIhspAct.getInvoiceNum(invoiceKind, ProgramGlobal.User_id.Trim().ToString());
           if (invoiceNum < 10)
           {
               lblInvoiceMsg.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
               lblInvoiceMsg.Visible = true;
           }
           else if (invoiceNum >= 10)
           {
               lblInvoiceMsg.Text = "";
               lblInvoiceMsg.Visible = false;
           }

            //获取发票号
           
           if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
           {
               MessageBox.Show("发票已用完，不能进行收费！");
               this.Close();
               return;
           }
           this.fphtext.Text = invoicecode;

          
           cshjkfs();
           //HISDB hisdb = new HISDB();
           string sql = "select count(id) from inhospital where outcondition='DIE' and id=" + this.ihsp_id.ToString();
            dt = BllMain.Db.Select(sql).Tables[0];
           int cnt = Convert.ToInt32(dt.Rows[0][0].ToString());
           if (cnt > 0)
           {
               this.swcyyy.SelectedValue = "4";
               MessageBox.Show("此患者已死亡，请确认后再办理出院");
           }
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void Cshhs()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("1", "治愈"));
            items.Add(new ListItem("2", "好转"));
            items.Add(new ListItem("3", "死亡"));
            items.Add(new ListItem("4", "转院"));
            items.Add(new ListItem("5", "精神病中途结算"));
            items.Add(new ListItem("9", "其他"));
            swcyyy.DisplayMember = "Text";
            swcyyy.ValueMember = "Value";
            swcyyy.DataSource = items; 
        }
        private bool isHisihspSign()
        {
            if (!billIhspAct.isHisihspSign(ihsp_id))
            {
                MessageBox.Show("当前患者未挂账，不能办理出院，请确认！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonjs_Click(object sender, EventArgs e)
        {
            buttonjs.Enabled = false;
            if (!doAccount())
            {
                buttonjs.Enabled = true;

                return;
            }

           
            this.Close();
            this.Dispose();
        }
        private bool doAccount()
        {
            string currDate = BillSysBase.currDate();
            if (!isHisihspSign())
            {
                return false;
            }
            //新生儿
            double neonSum = DataTool.stringToDouble(billIhspAct.getHisNeonCostDetSum(ihsp_id));
            if (Math.Abs(neonSum) > 0.001)
            {
                MessageBox.Show("请先新生儿结算后再结算！(新生儿住院总费用为：" + neonSum);
              
                return false;
            }
            if (!((DataTool.stringToDouble(yjszje.Text.Trim()) - DataTool.stringToDouble(yjsfyze.Text.Trim())) > -0.001 && (DataTool.stringToDouble(yjszje.Text.Trim()) - DataTool.stringToDouble(yjsfyze.Text.Trim())) < 0.001))
            {
                MessageBox.Show("住院总费用与上传至医保中心的总费用不相等,无法办理结算请确认！(住院总费用为：" + yjszje.Text.Trim() + ",该患者上传至医保中心总费用为:" + yjsfyze.Text.Trim() + ")");
              
                return false;
            }

            //出院
            string cyyy = swcyyy.SelectedValue.ToString();
            if (!bllInsurIhspGZS.Cybl(ihsp_id, cyyy, currDate))
            {
                return false;
            }
            MessageBox.Show("出院办理成功");


            //网络支付
            string hisOrderNo = "";
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return false;


            //网络支付_END

            //结算
            StringBuilder message = new StringBuilder();
            Ihspaccount ihspaccount = new Ihspaccount();
            ihspaccount.Ihsp_id = ihsp_id;
            ihspaccount.Prepamt = yjk;
            ihspaccount.Chargedate = currDate;
            ihspaccount.Bas_paytype_id = cmbPayType.SelectedValue.ToString();
            ihspaccount.HisOrderNo = hisOrderNo;
            ihspaccount.Chargedate = currDate;
            if (!bllInsurIhspGZS.Jsan(ihspaccount, message))
            {
                MessageBox.Show("结算失败：" + message.ToString());
                return false;
            }
            //发票
            FrmClickAccount frmClickAccount = new FrmClickAccount();
            frmClickAccount.getSource(ihspaccount.Invoice, ihsp_id, ihspaccount.Id);
            frmClickAccount.Patienttype = this.patienttype_id;
            frmClickAccount.ShowDialog();
            return true;
        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            double payfee = DataTool.stringToDouble(tbxPayfee.Text);
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
                netPayIn.Hzxm = tbx_sickname.Text;
                netPayIn.Lxdh = homephone;
                //netPayIn.Sfzh = idcard;
                netPayIn.Ysje = tbxPayfee.Text;
                netPayIn.Ksmc = departname;
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
                netPayData.Ihsp_id = ihsp_id;
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
        /// KeyUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swcyzd_KeyUp(object sender, KeyEventArgs e)
        {
            //WdYbSelect wdyb = new WdYbSelect();
            DataTable ryzddata = new DataTable();
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dataGridViewIcd.Rows.Count > 0)
                {
                    dataGridViewIcd.Focus();
                    this.dataGridViewIcd.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dataGridViewIcd.Focus();
                this.dataGridViewIcd.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dataGridViewIcd.Rows.Count > 0)
                {
                    dataGridViewIcd.Focus();
                    this.dataGridViewIcd.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Space)
            {


                ryzddata = bllInsurIhspGZS.GetIcd();
                if (ryzddata.Rows.Count > 0)
                {
                    dataGridViewIcd.DataSource = ryzddata;
                    dataGridViewIcd.Visible = true;
                }
                else
                {
                    dataGridViewIcd.Visible = false;
                }
                return;
            }
            //查询
            if (swcyzd.Text.Trim().Equals(""))
            {
                dataGridViewIcd.Visible = false;
                swzddm.Text = "";
                return;
            }
            ryzddata = bllInsurIhspGZS.GetIcd(swcyzd.Text.Trim());
            if (dataGridViewIcd.Rows.Count > 0)
            {
                dataGridViewIcd.DataSource = ryzddata;
                dataGridViewIcd.Visible = true;
            }
            else
            {
                dataGridViewIcd.Visible = false;
            }
        }
        private void dataGridViewIcd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                swcyzd.Text = dataGridViewIcd.Rows[e.RowIndex].Cells["ryzd_icdname"].Value.ToString();
                dataGridViewIcd.Visible = true;
                swzddm.Text = dataGridViewIcd.Rows[e.RowIndex].Cells["ryzd_icdcode"].Value.ToString();
                dataGridViewIcd.Visible = false;
            }
        }
        private void dataGridViewIcd_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dataGridViewIcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewIcd.CurrentRow == null)
            {
                swcyzd.Focus();
                return;
            }
            if (e.KeyValue == 13)
            {
                int rowindex = this.dataGridViewIcd.CurrentRow.Index;
                if (rowindex >= 0)
                {
                    swcyzd.Text = dataGridViewIcd.Rows[rowindex].Cells["ryzd_icdname"].Value.ToString();
                    dataGridViewIcd.Visible = true;
                    swzddm.Text = dataGridViewIcd.Rows[rowindex].Cells["ryzd_icdcode"].Value.ToString();
                    dataGridViewIcd.Visible = false;
                    swcyzd.Focus();
                }
            }
            if (e.KeyValue == (char)Keys.Escape)
            {
                swcyzd.Focus();
                dataGridViewIcd.Visible = false;
            }
        }

        private void grzhzf_TextChanged(object sender, EventArgs e)
        {
            //write by wzw 2014-4-19_12:29
            //总费用
            double d_yyzfy =  DataTool.stringToDouble(yjszje.Text.Trim());
            //医保报销
            double d_ybbx = DataTool.stringToDouble(ybbx.Trim());
            //个人应付
            double d_gryfje = d_yyzfy - d_ybbx;
            //账户余额
            double d_grzhye = DataTool.stringToDouble(this.tbx_grzhkyye.Text.Trim());
            //个人账户
            double d_grzhzf = DataTool.stringToDouble(grzhzf.Text);
            if (d_grzhzf < 0)
            {
                d_grzhzf = 0;
            }
            int flag_xssf = 0;
            //限制算法 [个人账户支付 < 个人应付]
            if (d_grzhzf > d_gryfje)
            {
                d_grzhzf = d_gryfje;
                grzhzf.Text = d_grzhzf.ToString("0.00");
                flag_xssf = 1;

            }
            //限制算法[个人账户支付<=卡内余额]
            if (d_grzhzf > d_grzhye)
            {
                d_grzhzf = d_grzhye;
                grzhzf.Text = d_grzhzf.ToString("0.00");
                flag_xssf = 1;
            }
            if (flag_xssf == 1)
                MessageBox.Show("个人账户支付最多可支付金额为：" + grzhzf.Text.Trim());

            //预交款金额
            double d_yjkje = DataTool.stringToDouble(yjk);
            //计算个人应收金额 {应收金额= [个人应付金额-个人账户支付-预交金额]}
            double d_grysje = d_gryfje - d_grzhzf - d_yjkje;
            //赋值收费员应收金额
            tbxPayfee.Text = d_grysje.ToString("0.00");
            //write by wzw 2014-4-19_12:29end
        }

        private void tbxysxj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                //write by wzw 2014-4-19_12:29
                //总费用
                double d_yyzfy = DataTool.stringToDouble(yjszje.Text.Trim());
                //医保报销
                double d_ybbx = DataTool.stringToDouble(ybbx.Trim());
                //个人应付
                double d_gryfje = d_yyzfy - d_ybbx;
                //账户余额
                double d_grzhye = DataTool.stringToDouble(this.tbx_grzhkyye.Text.Trim());
                //个人账户
               


                //预交款金额
                double d_yjkje = DataTool.stringToDouble(yjk);
                //计算个人应收金额 {应收金额= [个人应付金额-个人账户支付-预交金额]}
                double d_grysje = DataTool.stringToDouble(tbxPayfee.Text);
                double d_grzhzf = d_gryfje - d_grysje - d_yjkje;

                grzhzf.Text = d_grzhzf.ToString("0.00");
                if (d_grzhzf > d_grzhye)
                {
                    grzhzf.Text = d_grzhye.ToString("0.00");
                }
            }
        }

        private void btn_canCostDet_Click(object sender, EventArgs e)
        {
            bllInsurIhspGZS.fysc(ihsp_id);
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
