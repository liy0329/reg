using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bean;
using System.Web.UI.WebControls;
using MTREG.ihsp.bll;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmSettlementInfo : Form
    {
        public FrmSettlementInfo()
        {
            InitializeComponent();
        }
        SjzybInterface sjzybInterface = new SjzybInterface();
        private void Form2_Load(object sender, EventArgs e)
        {
            inittype();
            initcztype();
            isInformationManager();
        }
        public void inittype()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("门诊", "1"));
            items.Add(new ListItem("住院", "2"));
            this.comboType.DisplayMember = "Text";
            this.comboType.ValueMember = "Value";
            this.comboType.DataSource = items;
            comboType.SelectedValue = "1";
        }
        public void initcztype()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("普通门诊", "11"));
            items.Add(new ListItem("慢性病门诊", "12"));
            items.Add(new ListItem("公务员普通门诊", "14"));
            items.Add(new ListItem("门诊特殊病", "15"));
            items.Add(new ListItem("药店购药", "16"));
            items.Add(new ListItem("普通住院", "21"));
            items.Add(new ListItem("转入住院", "25"));
            items.Add(new ListItem("意外伤害住院", "27"));
            items.Add(new ListItem("生育门诊", "51"));
            items.Add(new ListItem("生育住院", "52"));
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            this.comboBox1.DataSource = items;
            comboBox1.SelectedValue = "11";
        }
        /// <summary>
        /// 判断是不是信息管理员，冲正交易只对信息管理员开放
        /// </summary>
        public void isInformationManager()
        {
            gBchongzheng.Visible = false;
            string sql_sele = "SELECT * from acc_account WHERE id = '1' AND account = " + DataTool.addFieldBraces(ProgramGlobal.User);
            DataTable dt = BllMain.Db.Select(sql_sele).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gBchongzheng.Visible = true;
            }
            else
            {
                gBchongzheng.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getjsxx();
        }
        public void getjsxx()
        {
            DateTime Startime = dateTimePicker1.Value;
            DateTime endtime = dateTimePicker2.Value;
            string from = comboType.SelectedValue.ToString();
            string type = "";
            if (this.radioButton1.Checked == true)
            {
                type = "0";
            }
            else if (this.radioButton2.Checked == true)
            {
                type = "";
            }
            else if (this.radioButton3.Checked == true)
            {
                type = "1";
            }
            else if (this.radioButton4.Checked == true)
            {
                type = "2";
            }
            SJZYB_IN<SettlementInfo_In> yb_in_info = new SJZYB_IN<SettlementInfo_In>();
            yb_in_info.INPUT = new List<SettlementInfo_In>();
            SettlementInfo_In dom = new SettlementInfo_In();
            dom.CKA130 = from;
            dom.AAE030 = Startime.ToString("yyyy-MM-dd");
            dom.AAE031 = endtime.ToString("yyyy-MM-dd");
            dom.CKAA08 = type;
            dom.CURRENTPAGE = "1";
            yb_in_info.INPUT.Add(dom);
            yb_in_info.MSGNO = "1637";

            SettlementInfo_Out yb_out_info = new SettlementInfo_Out();
            int ret = sjzybInterface.DownloadInfo(yb_in_info, ref yb_out_info);

            string ReturnMsg = "";
            if (yb_out_info.OUTROW != null)
            {
                if (int.Parse(yb_out_info.TOTALPAGE) > 2)
                {
                    for (int i = 2; i <= int.Parse(yb_out_info.TOTALPAGE); i++)
                    //for (int i = 100; i <= 120; i++)
                    {
                        yb_in_info.INPUT = new List<SettlementInfo_In>();
                        dom = new SettlementInfo_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.CKA130 = from;
                        dom.AAE030 = Startime.ToString("yyyy-MM-dd");
                        dom.AAE031 = endtime.ToString("yyyy-MM-dd");
                        dom.CKAA08 = type;
                        yb_in_info.INPUT.Add(dom);
                        ret = sjzybInterface.DownloadInfo(yb_in_info, ref yb_out_info);
                        int returnnum = Convert.ToInt32(yb_out_info.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_info.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                    }
                }
            }
            if (yb_out_info.OUTROW == null || yb_out_info.OUTROW.Count < 0)
            {
                return;
            }
            DataTable dt = yb_out_info.OUTROW.ToDataTable<SettlementInfo_Out_OUTROW>();
            dataGridView(dt);
        }
        public void dataGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["AAE040"] = dr["AAE040"].ToString().Substring(0, 4) + dr["AAE040"].ToString().Substring(4, 2) + dr["AAE040"].ToString().Substring(6, 2);
                //if (String.IsNullOrEmpty(dr["CKAA09"].ToString()))
                //dr["CKAA09"] = dr["CKAA09"].ToString().Substring(0, 4) + dr["CKAA09"].ToString().Substring(4, 2) + dr["CKAA09"].ToString().Substring(6, 2);
                if (dr["CKAA08"].ToString() == "0")
                {
                    dr["CKAA08"] = "未对账";
                }
                else if (dr["CKAA08"].ToString() == "1")
                {
                    dr["CKAA08"] = "账平";
                }
                else if (dr["CKAA08"].ToString() == "2")
                {
                    dr["CKAA08"] = "账不平";
                }
                //dr["BAC081"] = dr["BAC081"] == "0" ? "否" : "是";
                if (dr["BAC081"].ToString() == "0")
                {
                    dr["BAC081"] = "否";
                }
                else
                {
                    dr["BAC081"] = "是";
                }
            }
            dataGridView1.DataSource = dt;

            #region
            dataGridView1.Columns["AKB020"].HeaderText = "                            ";
            dataGridView1.Columns["AKB020"].DisplayIndex = 0;
            dataGridView1.Columns["AKB020"].Width = 200;

            dataGridView1.Columns["AKC190"].HeaderText = "门诊住院流水号";
            dataGridView1.Columns["AKC190"].Width = 150;
            dataGridView1.Columns["AKC190"].DisplayIndex = 1;

            dataGridView1.Columns["AAE072"].HeaderText = "单据号";
            dataGridView1.Columns["AAE072"].DisplayIndex = 2;
            dataGridView1.Columns["AAE072"].Width = 200;

            dataGridView1.Columns["AAE040"].HeaderText = "结算日期";
            dataGridView1.Columns["AAE040"].Width = 150;
            dataGridView1.Columns["AAE040"].DisplayIndex = 3;

            dataGridView1.Columns["AAC001"].HeaderText = "个人编号";
            dataGridView1.Columns["AAC001"].Width = 100;
            dataGridView1.Columns["AAC001"].DisplayIndex = 4;

            dataGridView1.Columns["AKC020"].HeaderText = "社保卡号";
            dataGridView1.Columns["AKC020"].Width = 100;
            dataGridView1.Columns["AKC020"].DisplayIndex = 5;

            dataGridView1.Columns["AKC275"].HeaderText = "发送方交易流水号";
            dataGridView1.Columns["AKC275"].Width = 100;
            dataGridView1.Columns["AKC275"].DisplayIndex = 6;

            dataGridView1.Columns["AKC276"].HeaderText = "接收方交易流水号";
            dataGridView1.Columns["AKC276"].Width = 100;
            dataGridView1.Columns["AKC276"].DisplayIndex = 7;

            dataGridView1.Columns["AKC281"].HeaderText = "撤销（或被撤销）的发送方交易流水号";
            dataGridView1.Columns["AKC281"].Width = 100;
            dataGridView1.Columns["AKC281"].DisplayIndex = 8;

            dataGridView1.Columns["AKC282"].HeaderText = "撤销（或被撤销）的接收方交易流水号";
            dataGridView1.Columns["AKC282"].Width = 100;
            dataGridView1.Columns["AKC282"].DisplayIndex = 9;

            dataGridView1.Columns["AKC283"].HeaderText = "冲正（或被冲正）的发送方交易流水号";
            dataGridView1.Columns["AKC283"].Width = 100;
            dataGridView1.Columns["AKC283"].DisplayIndex = 10;

            dataGridView1.Columns["AKC284"].HeaderText = "被冲正（或被冲正）的接收方交易流水号";
            dataGridView1.Columns["AKC284"].Width = 150;
            dataGridView1.Columns["AKC284"].DisplayIndex = 11;

            dataGridView1.Columns["AKC332"].HeaderText = "业务周期号";
            dataGridView1.Columns["AKC332"].DisplayIndex = 12;
            dataGridView1.Columns["AKC332"].Width = 200;

            dataGridView1.Columns["AKC264"].HeaderText = "医疗费总额";
            dataGridView1.Columns["AKC264"].Width = 150;
            dataGridView1.Columns["AKC264"].DisplayIndex = 13;

            dataGridView1.Columns["AKC255"].HeaderText = "帐户支付";
            dataGridView1.Columns["AKC255"].Width = 100;
            dataGridView1.Columns["AKC255"].DisplayIndex = 14;

            dataGridView1.Columns["AKC260"].HeaderText = "统筹基金支付";
            dataGridView1.Columns["AKC260"].Width = 100;
            dataGridView1.Columns["AKC260"].DisplayIndex = 15;

            dataGridView1.Columns["AKC261"].HeaderText = "现金支付";
            dataGridView1.Columns["AKC261"].Width = 100;
            dataGridView1.Columns["AKC261"].DisplayIndex = 16;

            dataGridView1.Columns["AKC706"].HeaderText = "大病救助基金支付";
            dataGridView1.Columns["AKC706"].Width = 100;
            dataGridView1.Columns["AKC706"].DisplayIndex = 17;

            dataGridView1.Columns["AKC707"].HeaderText = "公务员补助支付";
            dataGridView1.Columns["AKC707"].Width = 100;
            dataGridView1.Columns["AKC707"].DisplayIndex = 18;

            dataGridView1.Columns["AKC708"].HeaderText = "其他基金支出";
            dataGridView1.Columns["AKC708"].Width = 100;
            dataGridView1.Columns["AKC708"].DisplayIndex = 19;

            dataGridView1.Columns["MSGNO"].HeaderText = "交易代码";
            dataGridView1.Columns["MSGNO"].Width = 100;
            dataGridView1.Columns["MSGNO"].DisplayIndex = 20;

            dataGridView1.Columns["CKAA08"].HeaderText = "对账状态";
            dataGridView1.Columns["CKAA08"].Width = 150;
            dataGridView1.Columns["CKAA08"].DisplayIndex = 21;

            dataGridView1.Columns["CKAA09"].HeaderText = "对账时间";
            dataGridView1.Columns["CKAA09"].DisplayIndex = 22;
            dataGridView1.Columns["CKAA09"].Width = 200;

            dataGridView1.Columns["CKAA20"].HeaderText = "基本提高支付（发票）";
            dataGridView1.Columns["CKAA20"].Width = 150;
            dataGridView1.Columns["CKAA20"].DisplayIndex = 23;

            dataGridView1.Columns["CKAA27"].HeaderText = "大病提高支付（发票）";
            dataGridView1.Columns["CKAA27"].Width = 100;
            dataGridView1.Columns["CKAA27"].DisplayIndex = 24;

            dataGridView1.Columns["BKE151"].HeaderText = "医疗救助支付（发票）";
            dataGridView1.Columns["BKE151"].Width = 100;
            dataGridView1.Columns["BKE151"].DisplayIndex = 25;

            dataGridView1.Columns["CKAA40"].HeaderText = "医疗救助补充支付（发票）";
            dataGridView1.Columns["CKAA40"].Width = 100;
            dataGridView1.Columns["CKAA40"].DisplayIndex = 26;

            dataGridView1.Columns["BAC081"].HeaderText = "贫困人口标志";
            dataGridView1.Columns["BAC081"].Width = 100;
            dataGridView1.Columns["BAC081"].DisplayIndex = 27;
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            string zyhTmp = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            string cyjsXm = dataGridView1.Rows[Index].Cells["AAE072"].Value.ToString();
            string mes = "确定结算回退[住院号:" + zyhTmp + ",单据号:" + cyjsXm + "]吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            zyjs_ht(Index);
            getjsxx();
        }
        //住院结算回退
        public void zyjs_ht(int Index)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡


            yb_in_ryjbxxhzh.AAC001 = "0";

            yb_in_ryjbxxhzh.MSGNO = "1401";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }

            if (yb_out_ryjbxxhzh.ZKC031.Equals("1"))
            {
                MessageBox.Show("此人目前为在院状态，不能再做住院结算召回操作！", "提示信息");
                return;
            }

            //结算回退
            SJZYB_IN<zyjszh_IN> yb_in_zyjsht = new SJZYB_IN<zyjszh_IN>();
            yb_in_zyjsht.INPUT = new List<zyjszh_IN>();
            zyjszh_IN zyjszh_in = new zyjszh_IN();
            zyjszh_OUT yb_out_zyjsht = new zyjszh_OUT();
            zyjszh_in.AAE072 = dataGridView1.Rows[Index].Cells["AAE072"].Value.ToString();
            zyjszh_in.AKC190 = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            zyjszh_in.AKC281 = dataGridView1.Rows[Index].Cells["AKC275"].Value.ToString();
            yb_in_zyjsht.INPUT.Add(zyjszh_in);

            string sql_sybdz = "SELECT * FROM sjz_yb_jsxx WHERE AKC190 = " + DataTool.addFieldBraces(zyjszh_in.AKC190);
            DataTable dt_sybdz = BllMain.Db.Select(sql_sybdz).Tables[0];
            if (dt_sybdz.Rows.Count <= 0)
            {
                MessageBox.Show("此人目前His没有结算信息，不能再做住院结算召回操作！", "提示信息");
                return;
            }

            string sql_ybjl = "select healthcard,insurcode,AKA130,inhospital.id as 'id' from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where inhospital.ihspcode =" + DataTool.addFieldBraces(zyjszh_in.AKC190.ToString()) + "";
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb = dtybjl.Rows[0]["AKA130"].ToString().Trim();
            string ihsp_id = dtybjl.Rows[0]["id"].ToString().Trim();

            yb_in_zyjsht.AAC001 = "0";
            yb_in_zyjsht.AKC190 = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            yb_in_zyjsht.AKC020 = dataGridView1.Rows[Index].Cells["AKC020"].Value.ToString();
            yb_in_zyjsht.AKA130 = yllb;
            yb_in_zyjsht.MSGNO = "1203";

            int ret_zyjsht = sjzybInterface.zyjszh(yb_in_zyjsht, ref yb_out_zyjsht);
            if (yb_out_zyjsht.RETURNNUM == -1)
            {
                MessageBox.Show(yb_out_zyjsht.ERRORMSG, "提示信息");
                return;
            }

            

            decimal AKC264 = 0;
            decimal AKC255 = 0;
            decimal AKC260 = 0;
            decimal AKC261 = 0;
            decimal AKC706 = 0;
            decimal AKC707 = 0;
            decimal AKC708 = 0;


            AKC264 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC264"].ToString());
            AKC255 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC255"].ToString());
            AKC260 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC260"].ToString());
            AKC261 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC261"].ToString());
            AKC706 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC706"].ToString());
            AKC707 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC707"].ToString());
            AKC708 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC708"].ToString());

            js_sql jsxx = new js_sql();
            jsxx.AAE072 = yb_in_zyjsht.INPUT[0].AAE072;
            jsxx.AKC190 = yb_in_zyjsht.AKC190;
            jsxx.BKC111 = "";
            jsxx.MSGID = yb_in_zyjsht.MSGID;
            jsxx.REFMSGID = yb_out_zyjsht.REFMSGID;
            jsxx.AKA130 = yb_in_zyjsht.AKA130;
            jsxx.id = BillSysBase.nextId("sjz_yb_jsxx");
            string sql_jsxx = " INSERT INTO sjz_yb_jsxx (id,AKA130,AKC190,AAE072,MSGID,REFMSGID,AKC264,AKC255,AKC260,AKC261,AKC706,AKC707,AKC708,AAE040)"
                            + " VALUES( "
                            + DataTool.addFieldBraces(jsxx.id)
                            + "," + DataTool.addFieldBraces(jsxx.AKA130)
                            + "," + DataTool.addFieldBraces(jsxx.AKC190)
                            + "," + DataTool.addFieldBraces(jsxx.AAE072)
                            + "," + DataTool.addFieldBraces(jsxx.MSGID)
                            + "," + DataTool.addFieldBraces(jsxx.REFMSGID)
                            + "," + DataTool.addFieldBraces(AKC264.ToString())
                            + "," + DataTool.addFieldBraces(AKC255.ToString())
                            + "," + DataTool.addFieldBraces(AKC260.ToString())
                            + "," + DataTool.addFieldBraces(AKC261.ToString())
                            + "," + DataTool.addFieldBraces(AKC706.ToString())
                            + "," + DataTool.addFieldBraces(AKC707.ToString())
                            + "," + DataTool.addFieldBraces(AKC708.ToString())
                            + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                            + " )";
            BllMain.Db.Update(sql_jsxx);

            string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0 where ihsp_id=" + ihsp_id;//
            BllMain.Db.Update(his_sql_update_ht);
            string sql = "update inhospital set settInsurdate=null  where id=" + ihsp_id;//_iid.ToString().Trim(); //2019_3_21增加更新医保报销时间为空 czh
            BllMain.Db.Update(sql);
            retAccount(ihsp_id);

            MessageBox.Show("住院结算回退成功", "提示信息");
        }

        private bool retAccount(string ihsp_id)
        {
            //string sql = "select ihsp_account.id,ihsp_invoicedet.bas_paytype_id from ihsp_account,ihsp_invoicedet,inhospital where  ihsp_invoicedet.ihsp_account_id=ihsp_account.id and ihsp_account.ihsp_id = inhospital.id and inhospital.id=" + ihsp_id;
            //DataTable d1t = BllMain.Db.Select(sql).Tables[0];
            string sqll = "select ihsp_account_id from ihsp_costdet where ihsp_id=" + ihsp_id;
            DataTable d2t = BllMain.Db.Select(sqll).Tables[0];
            string account_id = d2t.Rows[0]["ihsp_account_id"].ToString();
            string sql = "select bas_paytype_id from ihsp_invoicedet where  ihsp_account_id=" + account_id;
            DataTable d1t = BllMain.Db.Select(sql).Tables[0];

            BillIhspAct billIhspAct = new BillIhspAct();
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                string ihspaccountId = dataTable.Rows[0]["id"].ToString();
                string sourceHisOrderNo = dataTable.Rows[0]["hisOrderNo"].ToString();
                DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");

                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y" || 1 == 1)
                {

                    //网络支付退费
                    //string currDate = BillSysBase.currDate();
                    //string hisRefundNo = "";
                    //if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
                    //{
                    //    return false;
                    //}

                    //网络支付退费_END
                    string paytypeId = d1t.Rows[0]["bas_paytype_id"].ToString();//从界面获取实收金额的paytype
                    if (billIhspAct.cancleAccount(ihspaccountId, paytypeId) < 0)
                    {

                        return false;
                    }


                    return true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            string zyhTmp = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            string cyjsXm = dataGridView1.Rows[Index].Cells["AAE072"].Value.ToString();
            string mes = "确定结算回退[住院号:" + zyhTmp + ",单据号:" + cyjsXm + "]吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            mzjs_ht(Index);
            getjsxx();
        }
        public void mzjs_ht(int Index)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡


            yb_in_ryjbxxhzh.AAC001 = "0";

            yb_in_ryjbxxhzh.MSGNO = "1401";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            //结算回退
            SJZYB_IN<zyjszh_IN> yb_in_zyjsht = new SJZYB_IN<zyjszh_IN>();
            yb_in_zyjsht.INPUT = new List<zyjszh_IN>();
            zyjszh_IN zyjszh_in = new zyjszh_IN();
            zyjszh_OUT yb_out_zyjsht = new zyjszh_OUT();
            zyjszh_in.AAE072 = dataGridView1.Rows[Index].Cells["AAE072"].Value.ToString();
            zyjszh_in.AKC190 = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            zyjszh_in.AKC281 = dataGridView1.Rows[Index].Cells["AKC275"].Value.ToString();
            yb_in_zyjsht.INPUT.Add(zyjszh_in);


            string sql_ybjl = "SELECT AKA130 FROM sjz_yb_jsxx WHERE AKC190 =" + DataTool.addFieldBraces(zyjszh_in.AKC190.ToString()) + "";
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb = dtybjl.Rows[0]["AKA130"].ToString().Trim();

            yb_in_zyjsht.AAC001 = "0";
            yb_in_zyjsht.AKC190 = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            yb_in_zyjsht.AKC020 = dataGridView1.Rows[Index].Cells["AKC020"].Value.ToString();
            yb_in_zyjsht.AKA130 = yllb;
            yb_in_zyjsht.MSGNO = "1202";

            int ret_zyjsht = sjzybInterface.mzjszh(yb_in_zyjsht, ref yb_out_zyjsht);
            if (yb_out_zyjsht.RETURNNUM == -1)
            {
                MessageBox.Show(yb_out_zyjsht.ERRORMSG, "提示信息");
                return;
            }
            MessageBox.Show("门诊结算回退成功", "提示信息");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            string zyhTmp = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();
            string cyjsXm = dataGridView1.Rows[Index].Cells["AAE072"].Value.ToString();
            string mes = "确定冲正[住院号:" + zyhTmp + ",单据号:" + cyjsXm + "]吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            chongzheng(Index);
            getjsxx();
        }
        public void chongzheng(int Index)
        {
            #region
            //SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            //yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            //DK_IN dk = new DK_IN();
            //DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            //dk.BKA130 = "30";
            //yb_in_ryjbxxhzh.INPUT.Add(dk);
            ////判断有卡无卡


            //yb_in_ryjbxxhzh.AAC001 = "0";

            //yb_in_ryjbxxhzh.MSGNO = "1401";
            //int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            //if (ret == -1)
            //{
            //    MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
            //    return;
            //}
            #endregion
            SJZYB_IN<Correct_In> yb_in_cz = new SJZYB_IN<Correct_In>();
            yb_in_cz.INPUT = new List<Correct_In>();
            Correct_In dom = new Correct_In();
            SJZYB_OUT yb_out_cz = new SJZYB_OUT();
            dom.AKC275 = dataGridView1.Rows[Index].Cells["AKC275"].Value.ToString();
            yb_in_cz.INPUT.Add(dom);
            yb_in_cz.AKC190 = dataGridView1.Rows[Index].Cells["AKC190"].Value.ToString();


            string yllb = this.comboBox1.SelectedValue.ToString();

            yb_in_cz.AAC001 = "0";

            yb_in_cz.AKC020 = dataGridView1.Rows[Index].Cells["AKC020"].Value.ToString();
            yb_in_cz.AKA130 = yllb;
            yb_in_cz.MSGNO = "1301";

            string from = comboType.SelectedValue.ToString();
            double AKC264 = Double.Parse(dataGridView1.Rows[Index].Cells["AKC264"].Value.ToString());
            if (from == "1")
            {
                if (AKC264 > 0)
                {
                    yb_in_cz.ORGMSGNO = "1108";
                }
                else
                {
                    yb_in_cz.ORGMSGNO = "1202";
                }
            }
            else
            {
                if (AKC264 > 0)
                {
                    yb_in_cz.ORGMSGNO = "1105";
                }
                else
                {
                    yb_in_cz.ORGMSGNO = "1203";
                }
            }

            yb_in_cz.ORGMSGID = dataGridView1.Rows[Index].Cells["AKC275"].Value.ToString();

            int ret_zyjsht = sjzybInterface.chongzheng(yb_in_cz, ref yb_out_cz);
            if (yb_out_cz.RETURNNUM == -1)
            {
                MessageBox.Show(yb_out_cz.ERRORMSG, "提示信息");
                return;
            }

            string sql = "select count(id) as count from sjz_yb_jsxx where MSGID = " + DataTool.addFieldBraces(yb_in_cz.ORGMSGID);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (int.Parse( dt.Rows[0]["count"].ToString()) > 0 )
            {
                string upsql = "UPDATE sjz_yb_jsxx SET chongzheng = '1' WHERE MSGID = " + DataTool.addFieldBraces(yb_in_cz.ORGMSGID);
                BllMain.Db.Update(upsql);
            }

            MessageBox.Show("冲正交易成功", "提示信息");
        }
    }
}
