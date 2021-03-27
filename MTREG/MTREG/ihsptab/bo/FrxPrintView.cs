using System;
using System.Windows.Forms;
using System.Data;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;
using MTHIS.db;
using System.Drawing.Printing;
using MTHIS.chklist;
using MTHIS.tools;
using MTREG.ihsptab.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdsch.bll;
using System.Text;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.gzsnh.bll;
using System.IO;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.ynydyb.bll;
using System.Collections.Generic;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;

namespace MTREG.ihsptab.bo
{
    class FrxPrintView
    {
        BllFrxOper billFrxOper = new BllFrxOper();
        BllIhsptab billIhsptab = new BllIhsptab();
        public FrxPrintView() { }
        FastReport.Preview.PreviewControl previewCtrl;
        public FrxPrintView(FastReport.Preview.PreviewControl previewCtrl)
        {
            this.previewCtrl = previewCtrl;
        }
        /// <summary>
        /// 石家庄医保结算单（公务员）
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int sjzybybSettRpt_gwy(string invoice, string ihspcode, ybSettRpt_Out sjzyb_out)
        {
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.sjzybybSettRpt_gwy.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtAccInfo = billFrxOper.getAccInfo(invoice);

            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("yljg");
            dtInfo.Columns.Add("jsdh");
            dtInfo.Columns.Add("jsrq");
            dtInfo.Columns.Add("zyh");
            dtInfo.Columns.Add("xm");
            dtInfo.Columns.Add("xb");
            dtInfo.Columns.Add("nl");
            dtInfo.Columns.Add("sfzh");
            dtInfo.Columns.Add("sbkh");
            dtInfo.Columns.Add("rysj");
            dtInfo.Columns.Add("cysj");
            dtInfo.Columns.Add("zyts");
            dtInfo.Columns.Add("cyzd");
            dtInfo.Columns.Add("cyks");//
            dtInfo.Columns.Add("CKAA14");
            dtInfo.Columns.Add("CKAA15");
            dtInfo.Columns.Add("AKC090");
            dtInfo.Columns.Add("AKC088");
            dtInfo.Columns.Add("CKAA19");
            dtInfo.Columns.Add("ZKC026");
            dtInfo.Columns.Add("AKC252");
            dtInfo.Columns.Add("AKC264");
            dtInfo.Columns.Add("AKC263");
            dtInfo.Columns.Add("AKC254");
            dtInfo.Columns.Add("CKA050");
            dtInfo.Columns.Add("CKAA33");
            dtInfo.Columns.Add("BKE033");
            dtInfo.Columns.Add("AKC260");
            dtInfo.Columns.Add("AKC740");
            dtInfo.Columns.Add("AKC256");
            dtInfo.Columns.Add("AKC707");
            dtInfo.Columns.Add("CKAA29");
            dtInfo.Columns.Add("AKC786");
            dtInfo.Columns.Add("CKAA30");
            dtInfo.Columns.Add("CKAA31");
            dtInfo.Columns.Add("CKAA32");
            dtInfo.Columns.Add("CKAA22");
            dtInfo.Columns.Add("CKAA23");
            dtInfo.Columns.Add("CKAA24");
            dtInfo.Columns.Add("CKAA25");
            dtInfo.Columns.Add("CKAA26");
            dtInfo.Columns.Add("AKC790");
            dtInfo.Columns.Add("ZKC036");
            dtInfo.Columns.Add("AKC255");
            dtInfo.Columns.Add("AKC754");
            dtInfo.Columns.Add("AKC253");
            dtInfo.Columns.Add("bxje");
            
            dtInfo.Columns.Add("printdate");//打印时间

            DataRow dr = dtInfo.NewRow();
            dr["yljg"] = "井陉县中医院(WH02)";
            dr["jsdh"] = dtAccInfo.Rows[0]["invoice"].ToString();
            dr["jsrq"] = dtAccInfo.Rows[0]["chargedate"].ToString();
            dr["zyh"] = dtAccInfo.Rows[0]["ihspcode"].ToString();
            dr["xm"] = dtAccInfo.Rows[0]["ihspname"].ToString();
            dr["xb"] = dtAccInfo.Rows[0]["sex"].ToString();
            dr["nl"] = dtAccInfo.Rows[0]["age"].ToString();
            dr["sfzh"] = dtAccInfo.Rows[0]["idcard"].ToString();
            dr["sbkh"] = dtAccInfo.Rows[0]["healthcard"].ToString();
            dr["rysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            dr["cysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            dr["zyts"] = (Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()) - Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString())).ToString("dd");
            dr["cyzd"] = dtAccInfo.Rows[0]["cyzd"].ToString();
            dr["cyks"] = dtAccInfo.Rows[0]["ks"].ToString();
            if (sjzyb_out.CKAA14 == "0")
            {
                sjzyb_out.CKAA14 = "居民";
            }
            else if (sjzyb_out.CKAA14 == "1")
            {
                sjzyb_out.CKAA14 = "职工";
            }
            else if (sjzyb_out.CKAA14 == "2")
            {
                sjzyb_out.CKAA14 = "公务员";
            }
            dr["CKAA14"] = sjzyb_out.CKAA14;
            dr["CKAA15"] = sjzyb_out.CKAA15;
            dr["AKC090"] = sjzyb_out.AKC090;
            dr["AKC088"] = sjzyb_out.AKC088;
            dr["CKAA19"] = sjzyb_out.CKAA19;
            dr["ZKC026"] = sjzyb_out.ZKC026;
            dr["AKC252"] = sjzyb_out.AKC252;
            dr["AKC264"] = sjzyb_out.AKC264;
            dr["AKC263"] = sjzyb_out.AKC263;
            dr["AKC254"] = sjzyb_out.AKC254;
            dr["CKA050"] = sjzyb_out.CKA050;
            dr["CKAA33"] = sjzyb_out.CKAA33;
            dr["BKE033"] = sjzyb_out.BKE033;
            dr["AKC260"] = sjzyb_out.AKC260;
            dr["AKC740"] = sjzyb_out.AKC740;
            dr["AKC256"] = sjzyb_out.AKC256;
            dr["AKC707"] = sjzyb_out.AKC707;
            dr["CKAA29"] = sjzyb_out.CKAA29;
            dr["AKC786"] = sjzyb_out.AKC786;
            dr["CKAA30"] = sjzyb_out.CKAA30;
            dr["CKAA31"] = sjzyb_out.CKAA31;
            dr["CKAA32"] = sjzyb_out.CKAA32;
            dr["CKAA22"] = sjzyb_out.CKAA22;
            dr["CKAA23"] = sjzyb_out.CKAA23;
            dr["CKAA24"] = sjzyb_out.CKAA24;
            dr["CKAA25"] = sjzyb_out.CKAA25;
            dr["CKAA26"] = sjzyb_out.CKAA26;
            dr["AKC790"] = sjzyb_out.AKC790;
            dr["ZKC036"] = sjzyb_out.ZKC036;
            dr["AKC255"] = sjzyb_out.AKC255;
            dr["AKC754"] = sjzyb_out.AKC754;
            dr["AKC253"] = sjzyb_out.AKC253;
            dr["bxje"] = (Double.Parse(sjzyb_out.AKC260.ToString()) + Double.Parse(sjzyb_out.AKC707) + Double.Parse(sjzyb_out.AKC255)).ToString("0.00");
            dr["printdate"] = DateTime.Now.ToString("");
            dtInfo.Rows.Add(dr);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chargeRptPath);
                payTypeRpt.RegisterData(dtInfo, "His_Table");
                payTypeRpt.Preview = this.previewCtrl;
                if (payTypeRpt.Prepare())
                {
                    payTypeRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 石家庄医保结算单（居民）
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int sjzybybSettRpt_jm(string invoice, string ihspcode, ybSettRpt_Out sjzyb_out)
        {
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.sjzybybSettRpt_jm.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtAccInfo = billFrxOper.getAccInfo(invoice);

            List<ybSettRpt_Out> list = new List<ybSettRpt_Out>();
            if (sjzyb_out.CKAA14 == "0")
            {
                sjzyb_out.CKAA14 = "居民";
            }
            else if (sjzyb_out.CKAA14 == "1")
            {
                sjzyb_out.CKAA14 = "职工";
            }
            else if (sjzyb_out.CKAA14 == "2")
            {
                sjzyb_out.CKAA14 = "公务员";
            }
            list.Add( sjzyb_out);
            DataTable ybInfo = list.ToDataTable<ybSettRpt_Out>();
            ybInfo.Columns.Add("bxje");
            ybInfo.Rows[0]["bxje"] = Double.Parse(sjzyb_out.AKC260) + Double.Parse(sjzyb_out.AKC706) + Double.Parse(sjzyb_out.CKAA20) + Double.Parse(sjzyb_out.CKAA27) + Double.Parse(sjzyb_out.BKE151) + Double.Parse(sjzyb_out.CKAA40);
            
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("printdate");//打印时间
            dtInfo.Columns.Add("yljg");
            dtInfo.Columns.Add("jsdh");
            dtInfo.Columns.Add("jsrq");
            dtInfo.Columns.Add("zyh");
            dtInfo.Columns.Add("xm");
            dtInfo.Columns.Add("xb");
            dtInfo.Columns.Add("nl");
            dtInfo.Columns.Add("sfzh");
            dtInfo.Columns.Add("sbkh");
            dtInfo.Columns.Add("rysj");
            dtInfo.Columns.Add("cysj");
            dtInfo.Columns.Add("zyts");
            dtInfo.Columns.Add("cyzd");
            dtInfo.Columns.Add("cyks");//
            DataRow dr = dtInfo.NewRow();
            dr["yljg"] = "井陉县中医院(WH02)";
            dr["jsdh"] = dtAccInfo.Rows[0]["invoice"].ToString();
            dr["jsrq"] = dtAccInfo.Rows[0]["chargedate"].ToString();
            dr["zyh"] = dtAccInfo.Rows[0]["ihspcode"].ToString();
            dr["xm"] = dtAccInfo.Rows[0]["ihspname"].ToString();
            dr["xb"] = dtAccInfo.Rows[0]["sex"].ToString();
            dr["nl"] = dtAccInfo.Rows[0]["age"].ToString();
            dr["sfzh"] = dtAccInfo.Rows[0]["idcard"].ToString();
            dr["sbkh"] = dtAccInfo.Rows[0]["healthcard"].ToString();
            dr["rysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            dr["cysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            dr["zyts"] = (Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()) - Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString())).ToString("dd");
            dr["cyzd"] = dtAccInfo.Rows[0]["cyzd"].ToString();
            dr["cyks"] = dtAccInfo.Rows[0]["ks"].ToString();
            dr["printdate"] = DateTime.Now.ToString("");
            dtInfo.Rows.Add(dr);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chargeRptPath);
                payTypeRpt.RegisterData(dtInfo, "His_Table");
                payTypeRpt.RegisterData(ybInfo, "yb_Table");
                payTypeRpt.Preview = this.previewCtrl;
                if (payTypeRpt.Prepare())
                {
                    payTypeRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 石家庄医保结算单（职工）
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int sjzybybSettRpt_zg(string invoice, string ihspcode, ybSettRpt_Out sjzyb_out)
        {
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.sjzybybSettRpt_zg.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtAccInfo = billFrxOper.getAccInfo(invoice);

            List<ybSettRpt_Out> list = new List<ybSettRpt_Out>();
            if (sjzyb_out.CKAA14 == "0")
            {
                sjzyb_out.CKAA14 = "居民";
            }
            else if (sjzyb_out.CKAA14 == "1")
            {
                sjzyb_out.CKAA14 = "职工";
            }
            else if (sjzyb_out.CKAA14 == "2")
            {
                sjzyb_out.CKAA14 = "公务员";
            }
            list.Add(sjzyb_out);
            DataTable ybInfo = list.ToDataTable<ybSettRpt_Out>();
            ybInfo.Columns.Add("bxje");
            ybInfo.Rows[0]["bxje"] = Double.Parse(sjzyb_out.AKC260) + Double.Parse(sjzyb_out.AKC706) + Double.Parse(sjzyb_out.AKC255);

            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("printdate");//打印时间
            dtInfo.Columns.Add("yljg");
            dtInfo.Columns.Add("jsdh");
            dtInfo.Columns.Add("jsrq");
            dtInfo.Columns.Add("zyh");
            dtInfo.Columns.Add("xm");
            dtInfo.Columns.Add("xb");
            dtInfo.Columns.Add("nl");
            dtInfo.Columns.Add("sfzh");
            dtInfo.Columns.Add("sbkh");
            dtInfo.Columns.Add("rysj");
            dtInfo.Columns.Add("cysj");
            dtInfo.Columns.Add("zyts");
            dtInfo.Columns.Add("cyzd");
            dtInfo.Columns.Add("cyks");//
            DataRow dr = dtInfo.NewRow();
            dr["yljg"] = "井陉县中医院(WH02)";
            dr["jsdh"] = dtAccInfo.Rows[0]["invoice"].ToString();
            dr["jsrq"] = dtAccInfo.Rows[0]["chargedate"].ToString();
            dr["zyh"] = dtAccInfo.Rows[0]["ihspcode"].ToString();
            dr["xm"] = dtAccInfo.Rows[0]["ihspname"].ToString();
            dr["xb"] = dtAccInfo.Rows[0]["sex"].ToString();
            dr["nl"] = dtAccInfo.Rows[0]["age"].ToString();
            dr["sfzh"] = dtAccInfo.Rows[0]["idcard"].ToString();
            dr["sbkh"] = dtAccInfo.Rows[0]["healthcard"].ToString();
            dr["rysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            dr["cysj"] = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            dr["zyts"] = (Convert.ToDateTime(dtAccInfo.Rows[0]["indate"].ToString()) - Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"].ToString())).ToString("dd");
            dr["cyzd"] = dtAccInfo.Rows[0]["cyzd"].ToString();
            dr["cyks"] = dtAccInfo.Rows[0]["ks"].ToString();
            dr["printdate"] = DateTime.Now.ToString("");
            dtInfo.Rows.Add(dr);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chargeRptPath);
                payTypeRpt.RegisterData(dtInfo, "His_Table");
                payTypeRpt.RegisterData(ybInfo, "yb_Table");
                payTypeRpt.Preview = this.previewCtrl;
                if (payTypeRpt.Prepare())
                {
                    payTypeRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 石家庄费用清单
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="codeid"></param>
        /// <returns></returns>
        public int costdetPrt_sjz(DataTable dt_dost ,string ihsp_id ,string dwdm)
        {
            string frmurl = billFrxOper.getPrintFrmurl("ihspCostSum_sjz").Rows[0]["frmurl"].ToString();
            string invoiceRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtInfo0 = billFrxOper.getIhspInfo(ihsp_id);
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("patientname", typeof(string));
            dtInfo.Columns.Add("sex", typeof(string));
            dtInfo.Columns.Add("age", typeof(string));
            dtInfo.Columns.Add("ihspcode", typeof(string));
            dtInfo.Columns.Add("healthcard", typeof(string));

            dtInfo.Columns.Add("dptname", typeof(string));//
            dtInfo.Columns.Add("cybq", typeof(string));//
            dtInfo.Columns.Add("cybz", typeof(string));//
            dtInfo.Columns.Add("dwdm", typeof(string));
            dtInfo.Columns.Add("zydj", typeof(string));//

            dtInfo.Columns.Add("indate", typeof(string));//
            dtInfo.Columns.Add("outdate", typeof(string));//
            dtInfo.Columns.Add("days", typeof(string));
            dtInfo.Columns.Add("jsd", typeof(string));
            dtInfo.Columns.Add("cylx", typeof(string));//

            dtInfo.Columns.Add("today", typeof(string));//
            dtInfo.Columns.Add("jbr", typeof(string));//
            dtInfo.Columns.Add("jsqz", typeof(string));
            dtInfo.Columns.Add("fsqj", typeof(string));
            dtInfo.Columns.Add("jsrq", typeof(string));//
            //dtInfo.Columns.Add("feesum", typeof(string));//
            DataRow dr = dtInfo.NewRow();
            dr["patientname"] = dtInfo0.Rows[0]["patientname"].ToString();
            dr["sex"] = dtInfo0.Rows[0]["sex"].ToString();
            dr["age"] = dtInfo0.Rows[0]["age"].ToString();
            dr["ihspcode"] = dtInfo0.Rows[0]["ihspcode"].ToString();
            dr["healthcard"] = dtInfo0.Rows[0]["healthcard"].ToString();
            dr["dptname"] = dtInfo0.Rows[0]["dptname"].ToString();
            dr["cybq"] = dtInfo0.Rows[0]["cybq"].ToString();
            dr["cybz"] = dtInfo0.Rows[0]["cyzd"].ToString();
            dr["dwdm"] = dwdm;
            dr["zydj"] = dtInfo0.Rows[0]["patienttypename"].ToString() == "市医保" ? "职工等级":"居民登记"; ;
            dr["indate"] = Convert.ToDateTime(dtInfo0.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            dr["outdate"] = Convert.ToDateTime(dtInfo0.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            dr["days"] = (Convert.ToDateTime(dtInfo0.Rows[0]["indate"].ToString()) - Convert.ToDateTime(dtInfo0.Rows[0]["outdate"].ToString())).ToString("dd");
            dr["jsd"] = dtInfo0.Rows[0]["AAE072"].ToString();
            dr["cylx"] = dtInfo0.Rows[0]["cybq"].ToString();
            dr["today"] = DateTime.Now.ToString("yyyy-MM-dd");
            dr["jbr"] = ProgramGlobal.Nickname;
            dr["jsqz"] = "";
            dr["fsqj"] = Convert.ToDateTime(dtInfo0.Rows[0]["indate"].ToString()).ToString("yyyy/MM/dd") + " - " + Convert.ToDateTime(dtInfo0.Rows[0]["outdate"].ToString()).ToString("yyyy/MM/dd");
            dr["jsrq"] = dtInfo0.Rows[0]["AAE040"].ToString();
            dtInfo.Rows.Add(dr);
            dt_dost.Columns.Add("AAE013", typeof(string));
            Double feesum = 0.00;
            foreach (DataRow drdost in dt_dost.Rows)
            {
                string sql = "SELECT memo FROM cost_insuritem  WHERE insurcode = " + DataTool.addFieldBraces(drdost["AKC222"].ToString());
                DataTable dtm = BllMain.Db.Select(sql).Tables[0];
                drdost["AAE013"] =  dtm.Rows[0]["memo"].ToString();
                feesum += Double.Parse(drdost["AKC227"].ToString());
            }
            DataRow dr_cost = dt_dost.NewRow();
            dr_cost["AKC604"] = "合计";
            dr_cost["AKC227"] = feesum;
            dt_dost.Rows.Add(dr_cost);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(invoiceRptPath);
                payTypeRpt.RegisterData(dtInfo, "Info");
                payTypeRpt.RegisterData(dt_dost, "CostDet");
                payTypeRpt.Preview = this.previewCtrl;
                if (payTypeRpt.Prepare())
                {
                    payTypeRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 云南异地医保结算单打印/预览
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int ynydybSettRpt(string ihsp_id, string printOrView)
        {
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ynydybSettPrt.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            BllYnydybMethod bllYnydybMethod = new BllYnydybMethod();
            DataTable dtInsur = bllYnydybMethod.ynydybIhspInfo(ihsp_id);
            ///登记信息
            string reginfo = dtInsur.Rows[0]["registinfo"].ToString();
            StringReader ihsp = new System.IO.StringReader(reginfo);
            DataSet dsIhsp = new DataSet();
            dsIhsp.ReadXml(ihsp);
            DataTable dtIhsp = dsIhsp.Tables["output"];
            //结算信息
            string settinfo = dtInsur.Rows[0]["settinfo"].ToString();
            StringReader sett = new System.IO.StringReader(settinfo);
            DataSet dsSett = new DataSet();
            dsSett.ReadXml(sett);
            DataTable dtSett = dsSett.Tables["output"];
            //住院信息
            DataTable dtReg = billFrxOper.ynydybInfo(ihsp_id);

            string sex = "";
            if (dtIhsp.Rows[0]["AAC004"].ToString() == "1")
            {
                sex = "男";
            }
            else if (dtIhsp.Rows[0]["AAC004"].ToString() == "2")
            {
                sex = "女";
            }
            else { sex = "未说明性别"; }
            string persontype = "";
            if (dtIhsp.Rows[0]["AKC300"].ToString() == "1")
            {
                persontype = "城镇职工";
            }
            else if (dtIhsp.Rows[0]["AKC300"].ToString() == "2")
            {
                persontype = "城镇居民";
            }
            else { persontype = "离休"; }

            string outcondition = "";
            switch (dtIhsp.Rows[0]["AKC300"].ToString())
            {
                case "OO": outcondition = "未出院"; break;
                case "CURE": outcondition = "治愈"; break;
                case "BETTER": outcondition = "好转"; break;
                case "NOT": outcondition = "未愈"; break;
                case "DIE": outcondition = "死亡"; break;
                case "OTHER ": outcondition = "其它"; break;
            }
            DateTime start = Convert.ToDateTime(dtReg.Rows[0]["indate"].ToString());
            DateTime end = Convert.ToDateTime(dtReg.Rows[0]["outdate"].ToString());
            TimeSpan day = end.Subtract(start);
            string days = day.Days.ToString();

            string gwybz = (DataTool.stringToDouble(dtSett.Rows[0]["AKC804"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC103"].ToString())
                    + DataTool.stringToDouble(dtSett.Rows[0]["AKC805"].ToString())).ToString();//公务员补助

            //个人支付总额
            string grzfze = (DataTool.stringToDouble(dtSett.Rows[0]["CKC120"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC121"].ToString())
                         + DataTool.stringToDouble(dtSett.Rows[0]["AKC290"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC156"].ToString())
                         + DataTool.stringToDouble(dtSett.Rows[0]["CKC162"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC170"].ToString())
                         - DataTool.stringToDouble(gwybz)).ToString();
            //基本医疗统筹共付
            string jbyltcgf = (DataTool.stringToDouble(dtSett.Rows[0]["CKC155"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC156"].ToString())).ToString();
            //大病医疗统筹共付
            string dbyltcgf = (DataTool.stringToDouble(dtSett.Rows[0]["CKC161"].ToString()) + DataTool.stringToDouble(dtSett.Rows[0]["CKC162"].ToString())).ToString();
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("name");
            dtInfo.Columns.Add("sex");
            dtInfo.Columns.Add("age");
            dtInfo.Columns.Add("settcode");
            dtInfo.Columns.Add("sicardno");
            dtInfo.Columns.Add("personno");
            dtInfo.Columns.Add("company");
            dtInfo.Columns.Add("depart");
            dtInfo.Columns.Add("casecode");
            dtInfo.Columns.Add("ihspcode");
            dtInfo.Columns.Add("bedcode");
            dtInfo.Columns.Add("persontype");
            dtInfo.Columns.Add("outcondition");
            dtInfo.Columns.Add("indate");
            dtInfo.Columns.Add("outdate");
            dtInfo.Columns.Add("days");
            dtInfo.Columns.Add("ihspdiagn");
            dtInfo.Columns.Add("outdiagn");
            dtInfo.Columns.Add("AKC264");//费用总额
            dtInfo.Columns.Add("AKC255");//卡支付金额
            dtInfo.Columns.Add("AKC261");//现金支付金额
            dtInfo.Columns.Add("CKC120");//全自费部分
            dtInfo.Columns.Add("CKC121");//先自付部分
            dtInfo.Columns.Add("AKC290");//实付起付线
            dtInfo.Columns.Add("CKC155");//基本医疗统筹自付部分
            dtInfo.Columns.Add("CKC156");//基本医疗统筹支付部分
            dtInfo.Columns.Add("CKC161");//大病医疗统筹自付部分
            dtInfo.Columns.Add("CKC162");//大病医疗统筹支付部分
            dtInfo.Columns.Add("CKC170");//超大病限额自付
            dtInfo.Columns.Add("grzfze");//个人自付总额
            dtInfo.Columns.Add("jbyltcgf");//基本医疗统筹共付
            dtInfo.Columns.Add("dbyltcgf");//大病医疗统筹共付
            dtInfo.Columns.Add("gwybz");//公务员补助
            dtInfo.Columns.Add("ihspdoctor");//入院经办人
            dtInfo.Columns.Add("settdoctor");//结算经办人
            dtInfo.Columns.Add("settdate");//结算日期
            dtInfo.Columns.Add("printdate");//打印时间
            DataRow dr = dtInfo.NewRow();
            dr["name"] = dtIhsp.Rows[0]["AAC003"].ToString();
            dr["sex"] = sex;
            dr["age"] = dtIhsp.Rows[0]["AKC023"].ToString();
            dr["settcode"] = dtReg.Rows[0]["billcode"].ToString();
            dr["sicardno"] = dtIhsp.Rows[0]["AKC020"].ToString();
            dr["personno"] = dtIhsp.Rows[0]["AAC001"].ToString();
            dr["company"] = dtIhsp.Rows[0]["AAB004"].ToString();
            dr["depart"] = dtReg.Rows[0]["depart"].ToString();
            dr["casecode"] = dtReg.Rows[0]["casecode"].ToString();
            dr["ihspcode"] = dtReg.Rows[0]["ihspcode"].ToString();
            dr["bedcode"] = dtReg.Rows[0]["bedcode"].ToString();
            dr["persontype"] = persontype;
            dr["outcondition"] = outcondition;
            dr["indate"] = dtReg.Rows[0]["indate"].ToString();
            dr["outdate"] = dtReg.Rows[0]["outdate"].ToString();
            dr["days"] = days;
            dr["ihspdiagn"] = dtReg.Rows[0]["ihspdiagn"].ToString();
            dr["outdiagn"] = dtReg.Rows[0]["outdiagn"].ToString();
            dr["AKC264"] = dtSett.Rows[0]["AKC264"].ToString();
            dr["AKC255"] = dtSett.Rows[0]["AKC255"].ToString();
            dr["AKC261"] = dtSett.Rows[0]["AKC261"].ToString();
            dr["CKC120"] = dtSett.Rows[0]["CKC120"].ToString();
            dr["CKC121"] = dtSett.Rows[0]["CKC121"].ToString();
            dr["AKC290"] = dtSett.Rows[0]["AKC290"].ToString();
            dr["CKC155"] = dtSett.Rows[0]["CKC155"].ToString();
            dr["CKC156"] = dtSett.Rows[0]["CKC156"].ToString();
            dr["CKC161"] = dtSett.Rows[0]["CKC161"].ToString();
            dr["CKC162"] = dtSett.Rows[0]["CKC162"].ToString();
            dr["CKC170"] = dtSett.Rows[0]["CKC170"].ToString();
            dr["grzfze"] = grzfze;
            dr["jbyltcgf"] = jbyltcgf;
            dr["dbyltcgf"] = dbyltcgf;
            dr["gwybz"] = gwybz;
            dr["ihspdoctor"] = dtReg.Rows[0]["ihspdoc"].ToString();
            dr["settdoctor"] = dtReg.Rows[0]["settdoc"].ToString();
            dr["settdate"] = Convert.ToDateTime(dtReg.Rows[0]["chargedate"].ToString()).ToString("yyyy-MM-dd");
            dr["printdate"] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss");
            dtInfo.Rows.Add(dr);
            FastReport.Report ynydybSettPrt = new FastReport.Report();
            try
            {
                ynydybSettPrt.Load(chargeRptPath);
                ynydybSettPrt.RegisterData(dtInfo, "Tb_Info");
                if (ynydybSettPrt.Prepare() && printOrView == "view")
                {
                    ynydybSettPrt.Preview = previewCtrl;
                    ynydybSettPrt.ShowPrepared();
                }
                else
                {
                    print("IhspTabForCharger.frx", ynydybSettPrt);
                }
            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 邯郸市医院病人费用清单
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="codeid"></param>
        /// <returns></returns>
        public int costdetPrt(string ihsp_id, string ihsp_account_id)
        {
            string frmurl = billFrxOper.getPrintFrmurl("IHSP_COSTSUM").Rows[0]["frmurl"].ToString();
            string invoiceRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtCostDet = null;
            if (DataTool.stringToInt(ihsp_account_id) <= 0)
            {
               dtCostDet = billFrxOper.getIhspCostdetInfo(ihsp_id);
            }
            else
            {
                dtCostDet = billFrxOper.getIhspCostdetInfoBySettle(ihsp_account_id);
            
            }
            DataTable dtInfo0 = billFrxOper.getIhspInfo(ihsp_id);
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("casecode", typeof(string));//病人ID
            dtInfo.Columns.Add("ihspcode", typeof(string));//住院号
            dtInfo.Columns.Add("patientname", typeof(string));//姓名
            dtInfo.Columns.Add("sex", typeof(string));//性别
            dtInfo.Columns.Add("days", typeof(string));//住院天数
            dtInfo.Columns.Add("indate", typeof(string));//入院日期
            dtInfo.Columns.Add("outdate", typeof(string));//出院日期
            dtInfo.Columns.Add("dptname", typeof(string));//入院科室
            dtInfo.Columns.Add("patienttypename", typeof(string));//费别
            dtInfo.Columns.Add("balanceamt", typeof(string));//预交金余额
            dtInfo.Columns.Add("feeamt", typeof(string));//住院费用
            dtInfo.Columns.Add("companyname", typeof(string));//工作单位
            dtInfo.Columns.Add("today",typeof(string));
            string inDate = dtInfo0.Rows[0]["indate"].ToString();
            string outDate = dtInfo0.Rows[0]["outdate"].ToString();
            DateTime start = Convert.ToDateTime(inDate);
            if (String.IsNullOrEmpty(outDate))
            {
                outDate = BillSysBase.currDate();
            }
            DateTime end = Convert.ToDateTime(outDate);
            TimeSpan day = end.Subtract(start);
            DataRow row = dtInfo.NewRow();
            row["casecode"] = dtInfo0.Rows[0]["casecode"].ToString();
            row["ihspcode"] = dtInfo0.Rows[0]["ihspcode"].ToString();
            row["patientname"] = dtInfo0.Rows[0]["patientname"].ToString();
            row["sex"] = dtInfo0.Rows[0]["sex"].ToString();
            row["days"] = day.Days.ToString();//住院天数
            row["indate"] = Convert.ToDateTime(inDate).ToString("yyyy-MM-dd");
            row["outdate"] = Convert.ToDateTime(outDate).ToString("yyyy-MM-dd");
            row["dptname"] = dtInfo0.Rows[0]["dptname"].ToString();
            row["patienttypename"] = dtInfo0.Rows[0]["patienttypename"].ToString();
            row["balanceamt"] = dtInfo0.Rows[0]["prepamt"].ToString();
            row["feeamt"] = dtInfo0.Rows[0]["feeamt"].ToString();
            row["companyname"] = dtInfo0.Rows[0]["companyname"].ToString();
            row["today"] = BillSysBase.currDate();
            dtInfo.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            { 
                payTypeRpt.Load(invoiceRptPath);
                payTypeRpt.RegisterData(dtCostDet, "CostDet");
                payTypeRpt.RegisterData(dtInfo, "Info");
                payTypeRpt.Preview = this.previewCtrl;
                if (payTypeRpt.Prepare())
                {
                    payTypeRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
            //try
            //{
            //    payTypeRpt.Load(invoiceRptPath);
            //    payTypeRpt.RegisterData(dtCostDet, "CostDet");
            //    payTypeRpt.RegisterData(dtInfo, "Info");
            //    print("ClinicInvoice", payTypeRpt);
            //}
            //catch
            //{
            //    MessageBox.Show("打印失败！");
            //    return -1;
            //}

            return 0;
        }
        /// <summary>
        /// 住院收费员明细日结表
        /// </summary>
        /// <param name="timeBegin"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public int ihspTabForCharger(string id, string star, string end, string paytype, string printOrView)
        {
            double total = 0.00;
            string startime = star;
            string endtime = end;
            string maker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string chker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string now = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd");
            string pay = paytype;
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITFC.ToString()).Rows[0]["frmurl"].ToString();
            string ihspTabForChargerPath = GlobalParams.reportDir + "\\"+frmurl;
            DataTable dt = billFrxOper.unPayCost(id,pay);
            DataTable dtCharge = new DataTable();
            DataColumn newdc = new DataColumn();
            newdc.ColumnName = "number";
            newdc.AutoIncrement = true;
            newdc.AutoIncrementSeed = 1;
            newdc.AutoIncrementStep = 1;
            dtCharge.Columns.Add(newdc);
            dtCharge.Merge(dt);
            DataTable dtpay = billFrxOper.tabPay(id,pay);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += double.Parse(dt.Rows[i]["fee"].ToString());
            }
            DataTable dgvPay = new DataTable();
            DataColumn dc = new DataColumn("bas_paytype_id", typeof(System.String));
            dgvPay.Columns.Add(dc);
            dc = new DataColumn("fee", typeof(System.String));
            dgvPay.Columns.Add(dc);
            dc = new DataColumn("bas_paytype_id1", typeof(System.String));
            dgvPay.Columns.Add(dc);
            dc = new DataColumn("fee1", typeof(System.String));
            dgvPay.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtpay.Rows.Count) / 2)); i++)
            {
                dgvPay.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            int j = 0;
            for (int a = 0; a < 4; a++)
            {
                for (int i = 0; i <= 2 && j < dtpay.Rows.Count; i = i + 2, j++)
                {
                    dgvPay.Rows[a][i] = dtpay.Rows[j]["bas_paytype_id"].ToString();
                    dgvPay.Rows[a][i + 1] = dtpay.Rows[j]["fee"].ToString();
                }
            }
            for (int a = 0; a < dgvPay.Rows.Count; a++)
            {
                for (int i = 0; i <= 2; i = i + 2)
                {
                    if (dgvPay.Rows[a][i].ToString() == "")
                    {
                        dgvPay.Rows[a][i] = "----";
                    }
                }
            }
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("timeBegin", typeof(string));
            dtLbl.Columns.Add("timeEnd", typeof(string));
            dtLbl.Columns.Add("now", typeof(string));
            dtLbl.Columns.Add("chker", typeof(string));
            dtLbl.Columns.Add("maker", typeof(string));
            dtLbl.Columns.Add("total", typeof(string));
            dtLbl.Columns.Add("paytype", typeof(string));
            dtLbl.Columns.Add("mark", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["timeBegin"] = startime;
            row["timeEnd"] = endtime;
            row["now"] = now;
            row["chker"] = chker;
            row["maker"] = maker;
            row["total"] = total.ToString();
            if (pay == "tab")
            {
                row["paytype"] = "科室";
            }
            else if (pay == "duty")
            {
                row["paytype"] = "个人";
            }
            row["mark"] = "";
            dtLbl.Rows.Add(row);
            FastReport.Report ihspTabForCharger = new FastReport.Report();
            try
            {
                ihspTabForCharger.Load(ihspTabForChargerPath);
                ihspTabForCharger.RegisterData(dtCharge, "Tb_ChargeRpt");
                ihspTabForCharger.RegisterData(dgvPay, "Tb_PayType");
                ihspTabForCharger.RegisterData(dtLbl, "Tb_LblText");
                if (ihspTabForCharger.Prepare() && printOrView == "view")
                {
                    ihspTabForCharger.Preview = previewCtrl;
                    ihspTabForCharger.ShowPrepared();
                }
                else
                {
                    print("IhspTabForCharger.frx", ihspTabForCharger);
                }
            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 出院收入汇总日结表
        /// </summary>
        /// <param name="timeBegin"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public int ihspTabCostAmt(string id, string star, string end, string paytype, string depart_id,string printOrView)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITCA.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\"+frmurl;
            string startime = star;
            string endtime = end;
            string maker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string chker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string now = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd");
            string pay = paytype;
            DataTable dt1 = billFrxOper.outIhsp(id);
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name3", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee3", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dt1.Rows.Count) / 3)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            string sql2 = "select sum(fee) as fee from ihsptab_payinadv where ihsptab_duty_id in (select id from ihsptab_duty where ihsptab_day_id=" + DataTool.addFieldBraces(id) + ")";
            DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
            string sql = "select sum(feeamt) as feeamt ,sum(balanceamt) as balanceamt from ihsptab_account where ihsptab_duty_id in (select id from ihsptab_duty where ihsptab_day_id=" + DataTool.addFieldBraces(id) + ")";
            DataTable dt3 = BllMain.Db.Select(sql).Tables[0];
            int j = 0;
            for (int a = 0; a < 5; a++)
            {
                for (int i = 0; i <= 4 && j < dt1.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dt1.Rows[j]["name"].ToString();
                    dgv.Rows[a][i + 1] = dt1.Rows[j]["realfee"].ToString();
                }
            }
            for (int a = 0; a < dgv.Rows.Count; a++)
            {
                for (int i = 0; i <= 4; i = i + 2)
                {
                    if (dgv.Rows[a][i].ToString() == "")
                    {
                        dgv.Rows[a][i] = "----";
                    }
                }
            }
            dgv.Rows.Add(new object[] { ("退款合计:").ToString(), (dt3.Rows[0]["balanceamt"]).ToString(), ("费用合计:").ToString(), (dt3.Rows[0]["feeamt"]).ToString(), ("预交金合计:").ToString(), (dt2.Rows[0]["fee"]).ToString() });
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("timeBegin", typeof(string));
            dtLbl.Columns.Add("timeEnd", typeof(string));
            dtLbl.Columns.Add("now", typeof(string));
            dtLbl.Columns.Add("chker", typeof(string));
            dtLbl.Columns.Add("maker", typeof(string));
            dtLbl.Columns.Add("paytype", typeof(string));
            dtLbl.Columns.Add("mark", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["timeBegin"] = startime;
            row["timeEnd"] = endtime;
            row["now"] = now;
            row["chker"] = chker;
            row["maker"] = maker;
            if (pay == "tab")
            {
                row["paytype"] = "科室";
            }
            else if (pay == "duty")
            {
                row["paytype"] = "个人";
            }
            row["mark"] = "";
            dtLbl.Rows.Add(row);
            FastReport.Report ihspTabCostAmt = new FastReport.Report();
            try
            {
                ihspTabCostAmt.Load(chargeRptPath);
                ihspTabCostAmt.RegisterData(dgv, "Tb_ChargeRpt");
                ihspTabCostAmt.RegisterData(dtLbl, "Tb_LblText");
                if (ihspTabCostAmt.Prepare() && printOrView == "view")
                {
                    ihspTabCostAmt.Preview = previewCtrl;
                    ihspTabCostAmt.ShowPrepared();
                }
                else
                {
                    print("IhspTabCostAmt.frx", ihspTabCostAmt);
                }

            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 住院收费员汇总日结表
        /// </summary>
        /// <param name="timeBegin"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public int ihspTabForChargerAmt(string id, string star, string end, string paytype, string printOrView)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITFCA.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\"+frmurl;
            string startime = star;
            string endtime = end;
            string maker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string chker = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            string now = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd");
            string pay = paytype;
            DataTable dtcharger = billFrxOper.getCharger(id,pay);
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("charger_id", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("payfee", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("retpayfee", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("balanceamt", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("amt", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("fee", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("bank", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("iscash", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("nocash", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < dtcharger.Rows.Count;i++)
            {
                string retfee = billFrxOper.getChargerPay(id, dtcharger.Rows[i]["settleby"].ToString(), "-1", pay);
                string fee = billFrxOper.getChargerPay(id, dtcharger.Rows[i]["settleby"].ToString(), "1", pay);
                string balanceamt = billFrxOper.getChargerAcc(id, dtcharger.Rows[i]["settleby"].ToString(), pay);
                if(retfee=="")
                {
                    retfee = "0.00";
                }
                if (fee == "")
                {
                    fee = "0.00";
                }
                if (balanceamt == "")
                {
                    balanceamt = "0.00";
                }
                double bank = double.Parse(retfee) + double.Parse(fee) + double.Parse(balanceamt);
                dgv.Rows.Add(new object[] { (dtcharger.Rows[i]["name"]).ToString(), (fee).ToString(), (retfee).ToString(), (balanceamt).ToString(), ("").ToString(), ("").ToString(), (bank).ToString(), ("").ToString(), ("").ToString() });
            }
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("timeBegin", typeof(string));
            dtLbl.Columns.Add("timeEnd", typeof(string));
            dtLbl.Columns.Add("now", typeof(string));
            dtLbl.Columns.Add("chker", typeof(string));
            dtLbl.Columns.Add("maker", typeof(string));
            dtLbl.Columns.Add("paytype", typeof(string));
            dtLbl.Columns.Add("mark", typeof(string));
            dtLbl.Columns.Add("total", typeof(string));
            dtLbl.Columns.Add("yesterday", typeof(string));
            dtLbl.Columns.Add("increase", typeof(string));
            dtLbl.Columns.Add("reduce", typeof(string));
            dtLbl.Columns.Add("today", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["timeBegin"] = startime;
            row["timeEnd"] = endtime;
            row["now"] = now;
            row["chker"] = chker;
            row["maker"] = maker;
            if (pay == "tab")
            {
                row["paytype"] = "科室";
            }
            else if (pay == "duty")
            {
                row["paytype"] = "个人";
            }
            row["mark"] = "";
            row["total"] = "";
            row["yesterday"] = "";
            row["reduce"] = ""; 
            row["today"] = "";
            dtLbl.Rows.Add(row);

            DataTable dtpay = billFrxOper.tabPay(id,pay);
            DataTable dgvPay = new DataTable();
            DataColumn dcpay = new DataColumn("bas_paytype_id", typeof(System.String));
            dgvPay.Columns.Add(dcpay);
            dc = new DataColumn("fee", typeof(System.String));
            dgvPay.Columns.Add(dc);
            dc = new DataColumn("bas_paytype_id1", typeof(System.String));
            dgvPay.Columns.Add(dc);
            dc = new DataColumn("fee1", typeof(System.String));
            dgvPay.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtpay.Rows.Count) / 2)); i++)
            {
                dgvPay.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            int j = 0;
            for (int a = 0; a < 4; a++)
            {
                for (int i = 0; i <= 2 && j < dtpay.Rows.Count; i = i + 2, j++)
                {
                    dgvPay.Rows[a][i] = dtpay.Rows[j]["bas_paytype_id"].ToString();
                    dgvPay.Rows[a][i + 1] = dtpay.Rows[j]["fee"].ToString();
                }
            }
            for (int a = 0; a < dgvPay.Rows.Count; a++)
            {
                for (int i = 0; i <= 2; i = i + 2)
                {
                    if (dgvPay.Rows[a][i].ToString() == "")
                    {
                        dgvPay.Rows[a][i] = "----";
                    }
                }
            }
            FastReport.Report ihspTabForChargerAmt = new FastReport.Report();
            try
            {
                ihspTabForChargerAmt.Load(chargeRptPath);
                ihspTabForChargerAmt.RegisterData(dgv, "Tb_ChargeRpt");
                ihspTabForChargerAmt.RegisterData(dtLbl, "Tb_LblText");
                ihspTabForChargerAmt.RegisterData(dgvPay, "Tb_PayType");
                if (ihspTabForChargerAmt.Prepare() && printOrView=="view")
                {
                    ihspTabForChargerAmt.Preview = previewCtrl;
                    ihspTabForChargerAmt.ShowPrepared();
                }
                else
                {
                    print("IhspTabForChargerAmt.frx", ihspTabForChargerAmt);
                }
            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 结算后打印
        /// </summary>
        /// <returns></returns>
        public int afterAcc(Ihsptab ihsptab,string name,string charger,string printOrView)
        {            
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITACI.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\"+frmurl;
            double payiscash = 0.00;
            double paynocash = 0.00;
            DataTable dtpay = billIhsptab.paySearch(name, ihsptab);
            DataColumn paycol = new DataColumn();
            paycol.ColumnName = "序列";
            dtpay.Columns.Add(paycol);
            dtpay.Columns["序列"].SetOrdinal(0);
            if (dtpay != null && dtpay.Rows.Count > 0)
            {
                if (dtpay.Rows.Count > 0)
                {
                    DataRow dr = dtpay.NewRow();
                    double payfee = 0.00;
                    for (int i = 0; i < dtpay.Rows.Count; i++)
                    {
                        payfee = payfee + double.Parse(dtpay.Rows[i]["payfee"].ToString());
                        if (dtpay.Rows[i]["paytypename"].ToString() == "现金")
                        {
                            payiscash += double.Parse(dtpay.Rows[i]["payfee"].ToString());
                        }
                    }
                    dr["序列"] = "合计：";
                    dr["payfee"] = payfee;
                    dtpay.Rows.Add(dr);
                    paynocash = payfee - payiscash;
                }
            }

            double acciscash = 0.00;
            double accnocash = 0.00;
            DataTable dtacc = new DataTable();// billIhsptab.accountSearch(name, ihsptab);
            DataColumn acccol = new DataColumn();
            acccol.ColumnName = "序列";
            dtacc.Columns.Add(acccol);
            dtacc.Columns["序列"].SetOrdinal(0);
            if (dtacc != null && dtacc.Rows.Count > 0)
            {
                if (dtacc.Rows.Count > 0)
                {
                    DataRow dr = dtacc.NewRow();
                    double prepamt = 0.00;
                    double feeamt = 0.00;
                    double retfee = 0.00;
                    for (int i = 0; i < dtacc.Rows.Count; i++)
                    {
                        if (dtacc.Rows[i]["prepamt"].ToString() != "")
                        {
                            prepamt = prepamt + double.Parse(DataTool.FormatData(dtacc.Rows[i]["prepamt"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["feeamt"].ToString() != "")
                        {
                            feeamt = feeamt + double.Parse(DataTool.FormatData(dtacc.Rows[i]["feeamt"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["retfee"].ToString() != "")
                        {
                            retfee = retfee + double.Parse(DataTool.FormatData(dtacc.Rows[i]["retfee"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["paytypename"].ToString() == "现金")
                        {
                            if (dtacc.Rows[i]["feeamt"].ToString() != "")
                            {
                                acciscash += double.Parse(DataTool.FormatData(dtacc.Rows[i]["feeamt"].ToString(), "2"));
                            }
                        }
                    }
                    dr["序列"] = "合计：";
                    dr["prepamt"] = prepamt;
                    dr["feeamt"] = feeamt;
                    dr["retfee"] = retfee;
                    dtacc.Rows.Add(dr);
                    accnocash = feeamt - acciscash;
                }
            }

            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("iscash1", typeof(string));
            dtLbl.Columns.Add("nocash1", typeof(string));
            dtLbl.Columns.Add("iscash2", typeof(string));
            dtLbl.Columns.Add("nocash2", typeof(string));
            dtLbl.Columns.Add("starttime", typeof(string));
            dtLbl.Columns.Add("endtime", typeof(string));
            dtLbl.Columns.Add("name", typeof(string));
            dtLbl.Columns.Add("charger", typeof(string));
            dtLbl.Columns.Add("paytype", typeof(string));
            DataRow rowLbl = dtLbl.NewRow();
            rowLbl["iscash1"] = DataTool.FormatData(payiscash.ToString(), "2");
            rowLbl["nocash1"] = DataTool.FormatData(paynocash.ToString(), "2");
            rowLbl["iscash2"] = DataTool.FormatData(acciscash.ToString(), "2");
            rowLbl["nocash2"] = DataTool.FormatData(accnocash.ToString(), "2");
            rowLbl["starttime"] = Convert.ToDateTime(ihsptab.Startdate).ToString("yyyy-MM-dd");
            rowLbl["endtime"] = Convert.ToDateTime(ihsptab.Enddate).ToString("yyyy-MM-dd");
            rowLbl["name"] = name;
            rowLbl["charger"] = charger;
         
            dtLbl.Rows.Add(rowLbl);
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("iscash", typeof(string));
            dtAll.Columns.Add("nocash", typeof(string));
            dtAll.Columns.Add("total", typeof(string));
            DataRow rowAll = dtAll.NewRow();
            rowAll["iscash"] = DataTool.FormatData((payiscash + acciscash).ToString(), "2");
            rowAll["nocash"] = DataTool.FormatData((paynocash + accnocash).ToString(), "2");
            rowAll["total"] = DataTool.FormatData((payiscash + acciscash + paynocash + accnocash).ToString(), "2");
            dtAll.Rows.Add(rowAll);
            FastReport.Report afterAccRpt = new FastReport.Report();
            try
            {
                afterAccRpt.Load(chargeRptPath);
                afterAccRpt.RegisterData(dtpay, "Tb_Pay");
                afterAccRpt.RegisterData(dtacc, "Tb_Account");
                afterAccRpt.RegisterData(dtAll, "Tb_All");
                afterAccRpt.RegisterData(dtLbl, "Tb_LblText");
                if (afterAccRpt.Prepare() && printOrView == "view")
                {
                    afterAccRpt.Preview = previewCtrl;
                    afterAccRpt.ShowPrepared();
                }
                else
                {
                    print("IhspTabAfterCostInfo.frx", afterAccRpt);
                }
                return 0;

            }
            catch
            {
                MessageBox.Show("预览失败！");
                return -1;
            }
        }

        /// <summary>
        /// 打印预付款发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int getIhspPayInadv(string id)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl("IHSP_PAYINADV").Rows[0]["frmurl"].ToString();
            string ihspPayInadvPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dt = billFrxOper.ihspPayInadv(id);
            dt.Columns.Add("dxpayfee", typeof(string));
            dt.Columns.Add("balanceamt", typeof(string));
            dt.Columns.Add("yymc", typeof(string));
            dt.Rows[0]["yymc"] = ProgramGlobal.HspName;
            dt.Rows[0]["dxpayfee"] = RMB_DX.Convert(Convert.ToDecimal(dt.Rows[0]["payfee"]));
            //总费用
            double d_feeamt = DataTool.Getdouble(dt.Rows[0]["feeamt"].ToString());
            //本次预交款
            double d_payfee = DataTool.Getdouble(dt.Rows[0]["payfee"].ToString());
            //总预交款
            double d_prepamt = DataTool.Getdouble(dt.Rows[0]["prepamt"].ToString());
            dt.Rows[0]["balanceamt"] = (d_prepamt + d_payfee - d_feeamt).ToString("0.00");

            FastReport.Report ihspPayInadv = new FastReport.Report();
            try
            {
                ihspPayInadv.Load(ihspPayInadvPath);
                ihspPayInadv.RegisterData(dt, "Tb_LblText");
                print(frmurl, ihspPayInadv);                
                return 0;
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
        }
        /// <summary>
        /// 担保凭证打印
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int getIhspGua(string id)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IG.ToString()).Rows[0]["frmurl"].ToString();
            string ihspGuaPath = GlobalParams.reportDir + "\\" + frmurl;
            string sql = "select inhospital.name as sickname "
                + ",sexList.name as sex"
                + ",inhospital.age"
                + ",inhospital.ihspcode"
                + ",ihspdepart.name as ihspdep"
                + ",guadepart.name as guadep"
                + ",doctor.name as doctorname"
                + ",createdby.name as createdname"
                + ",ihsp_guaranfee.enddate"
                + ",ihsp_guaranfee.amt"
                + ",ihsp_guaranfee.memo,ihsp_guaranfee.createdate"
                + " from ihsp_guaranfee"
                + " left join inhospital on ihsp_guaranfee.ihsp_id=inhospital.id"
                + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                + " left join bas_depart as ihspdepart on inhospital.depart_id=ihspdepart.id"
                + " left join bas_depart as guadepart on ihsp_guaranfee.depart_id=guadepart.id"
                + " left join bas_doctor as doctor on ihsp_guaranfee.doctor_id=doctor.id"
                + " left join bas_doctor as createdby on ihsp_guaranfee.createdby=createdby.id"
                + " where ihsp_guaranfee.id=" + DataTool.addIntBraces(id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            FastReport.Report ihspGua = new FastReport.Report();
            try
            {                
                ihspGua.Load(ihspGuaPath);
                ihspGua.RegisterData(dt, "Tb_Gua");
                //print(frmurl, ihspGua);
                ihspGua.Preview = previewCtrl;
                if (ihspGua.Prepare())
                {
                    ihspGua.ShowPrepared();
                }
                return 0;
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
        }

        /// <summary>
        /// 科室核算
        /// </summary>
        /// <returns></returns>
        public int ihspInDepAcc(DepDocAcc departAcc,string printOrView,string path) 
        {
            string depAccPath = GlobalParams.reportDir + "\\" + path;
            BllFrxOper billFrxOper = new BllFrxOper();
            DataTable dtdep = billFrxOper.departAccounting(departAcc);
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("patienttype", typeof(string));
            dtLbl.Columns.Add("itemtype", typeof(string));
            dtLbl.Columns.Add("depart", typeof(string));
            dtLbl.Columns.Add("endtime", typeof(string));
            dtLbl.Columns.Add("starttime", typeof(string));
            DataRow rowLbl = dtLbl.NewRow();
            rowLbl["patienttype"] = departAcc.Patienttype;
            rowLbl["itemtype"] = departAcc.Itemtype1;
            rowLbl["depart"] = departAcc.Depart;
            rowLbl["endtime"] = departAcc.EndTime;
            rowLbl["starttime"] = departAcc.StartTime;
            dtLbl.Rows.Add(rowLbl);
            FastReport.Report IhspInDepAcc = new FastReport.Report();
            try
            {
                IhspInDepAcc.Load(depAccPath);
                IhspInDepAcc.RegisterData(dtdep, "Tb_DepAcc");
                IhspInDepAcc.RegisterData(dtLbl, "Tb_LblText");
                if (IhspInDepAcc.Prepare() && printOrView == "view")
                {
                    IhspInDepAcc.Preview = previewCtrl;
                    IhspInDepAcc.ShowPrepared();
                }
                else
                {
                    print(path, IhspInDepAcc);
                }

            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 医生核算
        /// </summary>
        /// <returns></returns>
        public int ihspInDocAcc(DepDocAcc departAcc, string printOrView, string path)
        {
            string docAccPath = GlobalParams.reportDir + "\\" + path;
            BllFrxOper billFrxOper = new BllFrxOper();
            DataTable dtdoc = billFrxOper.doctorAccounting(departAcc);
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("itemtype", typeof(string));
            dtLbl.Columns.Add("depart", typeof(string));
            dtLbl.Columns.Add("endtime", typeof(string));
            dtLbl.Columns.Add("starttime", typeof(string));
            DataRow rowLbl = dtLbl.NewRow();
            rowLbl["itemtype"] = departAcc.Itemtype1;
            rowLbl["depart"] = departAcc.Depart;
            rowLbl["endtime"] = departAcc.EndTime;
            rowLbl["starttime"] = departAcc.StartTime;
            dtLbl.Rows.Add(rowLbl);
            FastReport.Report IhspInDocAcc = new FastReport.Report();
            try
            {
                IhspInDocAcc.Load(docAccPath);
                IhspInDocAcc.RegisterData(dtdoc, "Tb_DocAcc");
                IhspInDocAcc.RegisterData(dtLbl, "Tb_LblText");
                if (IhspInDocAcc.Prepare() && printOrView == "view")
                {
                    IhspInDocAcc.Preview = previewCtrl;
                    IhspInDocAcc.ShowPrepared();
                }
                else
                {
                    print(path, IhspInDocAcc);
                }

            }
            catch
            {
                MessageBox.Show("预览/预览失败！");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 邯郸市城合打印
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int IhspAccHdschPrt(string ihspid)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_HDSCHFP.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\"+frmurl;
            BillIhspcost billIhspcost = new BillIhspcost();
            BllInsur bllInsur = new BllInsur();
            Hdsch hdsch = new Hdsch();
            Zyjsdy_in zyjsdy_in = new Zyjsdy_in();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            zyjsdy_in.Mzzyh = dt.Rows[0]["ihspcode"].ToString();
            DataTable dataTable = bllInsur.hdybinfo(ihspid);
            string info = dataTable.Rows[0]["registinfo"].ToString();
            string[] message = info.Split('|');//个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
            string info1 = dataTable.Rows[0]["settinfo"].ToString();
            string[] message1 = info.Split('|');////经办人|账户支付金额|单据号
            zyjsdy_in.Djh = message1[2];
            zyjsdy_in.Jbr = message1[0];
            zyjsdy_in.Grbh = message[0];
            Zyjsddy_out zyjsddy_out = new Zyjsddy_out();
            int flag = hdsch.zyjsddy(zyjsdy_in, zyjsddy_out, message[0]);
            if (flag < 0)
            {
                return -1;
            }
            DataTable dtLbl = new DataTable();
            DataTable dtAccInfo = billFrxOper.getIhspAccInfo(ihspid);
            dtLbl.Columns.Add("ihspcode", typeof(string));
            dtLbl.Columns.Add("name", typeof(string));
            dtLbl.Columns.Add("depart", typeof(string));
            dtLbl.Columns.Add("indate", typeof(string));
            dtLbl.Columns.Add("sex", typeof(string));
            dtLbl.Columns.Add("patienttype", typeof(string));
            dtLbl.Columns.Add("outdate", typeof(string));
            dtLbl.Columns.Add("days", typeof(string));
            dtLbl.Columns.Add("djh", typeof(string));
            dtLbl.Columns.Add("invoice", typeof(string));
            dtLbl.Columns.Add("healthcard", typeof(string));
            dtLbl.Columns.Add("prepamt", typeof(string));
            dtLbl.Columns.Add("feeamt", typeof(string));
            dtLbl.Columns.Add("selffee", typeof(string));
            dtLbl.Columns.Add("insurefee", typeof(string));
            dtLbl.Columns.Add("insuraccountfee", typeof(string));
            dtLbl.Columns.Add("insurselffee", typeof(string));
            dtLbl.Columns.Add("balanceamt0", typeof(string));
            dtLbl.Columns.Add("balanceamt1", typeof(string));
            dtLbl.Columns.Add("hspname", typeof(string));
            dtLbl.Columns.Add("hspkind", typeof(string));
            dtLbl.Columns.Add("chargedby", typeof(string));
            dtLbl.Columns.Add("dxhj", typeof(string));
            dtLbl.Columns.Add("hj", typeof(string));
            dtLbl.Columns.Add("zycs", typeof(string));//住院次数
            dtLbl.Columns.Add("qfx", typeof(string));//起付线
            dtLbl.Columns.Add("ycxclfhjbyl", typeof(string));//一次性材料符合基本医疗
            dtLbl.Columns.Add("ptxmfhjbyl", typeof(string));//普通项目符合基本医疗
            dtLbl.Columns.Add("jrdbjjje", typeof(string));//进入大病基金金额
            dtLbl.Columns.Add("grzfxj", typeof(string));//个人支付现金|
            dtLbl.Columns.Add("zfzfjehj", typeof(string));//自付自费金额合计|
            dtLbl.Columns.Add("bzcf", typeof(string));//标准床费
            dtLbl.Columns.Add("ycxclbxje", typeof(string));//一次性材料报销金额
            dtLbl.Columns.Add("pttczf", typeof(string));//普通统筹支付 = 本次统筹支付 – 一次性材料报销金额
            dtLbl.Columns.Add("bndtcjjzf", typeof(string));//本年度统筹基金支付  
            dtLbl.Columns.Add("bczfhgrzhye", typeof(string));//本次支付后个人账户余额          
            dtLbl.Columns.Add("jsrq", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["jsrq"] = zyjsddy_out.Jsrq;//结算日期
            row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();//住院号
            row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();//姓名
            row["depart"] = zyjsddy_out.Ks;//科室
            row["indate"] = zyjsddy_out.Ryrq;// retdata[8];//入院日期
            row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();//性别
            row["outdate"] = zyjsddy_out.Cyrq;// retdata[9];//出院日期
            row["days"] = zyjsddy_out.Zyts;//住院天数|
            row["djh"] = zyjsddy_out.Djh;//单据号|
            row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();//流水号
            row["healthcard"] = dtAccInfo.Rows[0]["healthcard"].ToString();//社保账号
            row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();//医保类型
            row["prepamt"] = dtAccInfo.Rows[0]["prepamt"].ToString();//总预交款
            row["feeamt"] = dtAccInfo.Rows[0]["feeamt"].ToString();
            row["insuraccountfee"] = zyjsddy_out.Qzgrzhzf;//其中个人账户支付
            row["selffee"] = zyjsddy_out.Grzfxj;//个人支付现金
            row["insurselffee"] = zyjsddy_out.Jbylzfje;//基本医疗自付金额
            row["insurefee"] = zyjsddy_out.Tcjjzf;//统筹基金支付
            row["chargedby"] = zyjsddy_out.Jbr;//经办人
            row["dxhj"] = RMB_DX.Convert(zyjsddy_out.Hj);//大写合计
            row["hj"] = zyjsddy_out.Hj;//合计
            row["hspname"] = ProgramGlobal.HspName;
            row["hspkind"] = ProgramGlobal.HspKind;
            row["ycxclfhjbyl"] = zyjsddy_out.Ycxclfhjbyl;//一次性材料符合基本医疗
            row["ptxmfhjbyl"] = zyjsddy_out.Ptxmfhjbyl;//普通项目符合基本医疗
            row["jrdbjjje"] = zyjsddy_out.Jrdbjjje;//进入大病基金金额
            row["zfzfjehj"] = zyjsddy_out.Zfzfjehj;//自付自费金额合计|
            row["bzcf"] = zyjsddy_out.Bzcf;//标准床费
            row["qfx"] = zyjsddy_out.Qfbz;//起付标准
            row["zycs"] = zyjsddy_out.Cycs;//出院次数
            row["pttczf"] = double.Parse(zyjsddy_out.Tcjjzf)-double.Parse(zyjsddy_out.Ycxclbxje);//普通统筹支付 = 本次统筹支付 – 一次性材料报销金额/
            row["ycxclbxje"] = zyjsddy_out.Ycxclbxje;//一次性材料报销金额
            row["bndtcjjzf"] = zyjsddy_out.Bndtcjjzf;//本年度统筹基金支付|
            row["bczfhgrzhye"] = zyjsddy_out.Bczfhgrzhye;//本次支付后个人账户余额|
            if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) < 0)
            {
                row["balanceamt0"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应收
                row["balanceamt1"] = 0;
            }   
            else if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) > 0)
            {
                row["balanceamt1"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应退
                row["balanceamt0"] = 0;
            }
            else
            {
                row["balanceamt0"] = 0;
                row["balanceamt1"] = 0;
            }
            dtLbl.Rows.Add(row);
            DataTable dtCost = billFrxOper.insurInfo(ihspid, CostInsurtypeKeyname.HDSCH.ToString());
            DataTable dtItemtype = billFrxOper.getItemTypeName();
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString()});
            }
            int j = 0;

            for (int a = 0; a < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); a++)
            {
                for (int i = 0; i <= 2 && j < dtItemtype.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dtItemtype.Rows[j]["name"].ToString();
                    for (int m = 0; m < dtCost.Rows.Count; m++)
                    {
                        if (dtCost.Rows[m]["name"] == dgv.Rows[a][i])
                        {
                            dgv.Rows[a][i + 1] = DataTool.FormatData(dtCost.Rows[j]["realfee"].ToString(), "2");
                        }
                        else
                        {
                            dgv.Rows[a][i + 1] = "0.00";
                        }
                    }
                }
            }            
            FastReport.Report hdschRpt = new FastReport.Report();
            try
            {
                hdschRpt.Load(chargeRptPath);
                hdschRpt.RegisterData(dtLbl, "Tb_LblText");
                hdschRpt.RegisterData(dgv, "Tb_Itemtype");
                //frxPrintView.print("IhspAccount.frx", ihspAccRpt);
                if (hdschRpt.Prepare())
                {
                    hdschRpt.Preview = previewCtrl;
                    hdschRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 邯郸市医保打印
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int IhspAccHdsybPrt(string ihspid)
        {   
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_HDSYBFP.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            BillIhspcost billIhspcost = new BillIhspcost();
            BllInsur bllInsur = new BllInsur();
            Ybjk ybjk = new Ybjk();
            Zyjsdy_in zyjsdy_in=new Zyjsdy_in();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            zyjsdy_in.Mzzyh = dt.Rows[0]["ihspcode"].ToString();
            DataTable dataTable=bllInsur.hdybinfo(ihspid);
            string info = dataTable.Rows[0]["registinfo"].ToString();
            string[] message = info.Split('|');//个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
            string info1 = dataTable.Rows[0]["settinfo"].ToString();
            string[] message1 = info.Split('|');////经办人|账户支付金额|单据号
            zyjsdy_in.Djh = message1[2];
            zyjsdy_in.Jbr = message1[0];
            zyjsdy_in.Grbh = message[0];
            Zyjsddy_out zyjsddy_out = new Zyjsddy_out();
            int flag=ybjk.zyjsddy(zyjsdy_in, zyjsddy_out);
            if (flag < 0)
            {
                return -1;
            }
            DataTable dtLbl = new DataTable();
            DataTable dtAccInfo = billFrxOper.getIhspAccInfo(ihspid);
            dtLbl.Columns.Add("ihspcode", typeof(string));
            dtLbl.Columns.Add("name", typeof(string));
            dtLbl.Columns.Add("depart", typeof(string));
            dtLbl.Columns.Add("indate", typeof(string));
            dtLbl.Columns.Add("sex", typeof(string));
            dtLbl.Columns.Add("patienttype", typeof(string));
            dtLbl.Columns.Add("outdate", typeof(string));
            dtLbl.Columns.Add("days", typeof(string));
            dtLbl.Columns.Add("djh", typeof(string));
            dtLbl.Columns.Add("invoice", typeof(string));
            dtLbl.Columns.Add("healthcard", typeof(string));
            dtLbl.Columns.Add("prepamt", typeof(string));
            dtLbl.Columns.Add("feeamt", typeof(string));            
            dtLbl.Columns.Add("selffee", typeof(string));
            dtLbl.Columns.Add("insurefee", typeof(string));
            dtLbl.Columns.Add("insuraccountfee", typeof(string));
            dtLbl.Columns.Add("insurselffee", typeof(string));            
            dtLbl.Columns.Add("balanceamt0", typeof(string));
            dtLbl.Columns.Add("balanceamt1", typeof(string));
            dtLbl.Columns.Add("hspname", typeof(string));
            dtLbl.Columns.Add("hspkind", typeof(string));
            dtLbl.Columns.Add("chargedby", typeof(string));
            dtLbl.Columns.Add("dxhj", typeof(string));
            dtLbl.Columns.Add("hj", typeof(string));
            dtLbl.Columns.Add("dbzf", typeof(string));
            dtLbl.Columns.Add("dbljzf", typeof(string));
            dtLbl.Columns.Add("cdbzf", typeof(string));
            dtLbl.Columns.Add("gwybzzf", typeof(string));
            dtLbl.Columns.Add("bcbxze", typeof(string));
            dtLbl.Columns.Add("qfx", typeof(string));
            dtLbl.Columns.Add("zycs", typeof(string));
            dtLbl.Columns.Add("bndtcjjzf", typeof(string));
            dtLbl.Columns.Add("bczfhgrzhye", typeof(string));
            dtLbl.Columns.Add("jsrq", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["jsrq"] = zyjsddy_out.Jsrq;//结算日期
            row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();//住院号
            row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();//姓名
            row["depart"] = zyjsddy_out.Ks;//科室
            row["indate"] = zyjsddy_out.Ryrq;// retdata[8];//入院日期|
            row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();//性别
            row["outdate"] = zyjsddy_out.Cyrq;// retdata[9];//出院日期|
            row["days"] = zyjsddy_out.Zyts;//住院天数|
            row["djh"] = zyjsddy_out.Djh;//单据号|
            row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();//流水号
            row["healthcard"] = dtAccInfo.Rows[0]["healthcard"].ToString();//社保账号
            row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();//医保类型
            row["prepamt"] = dtAccInfo.Rows[0]["prepamt"].ToString();//总预交款
            row["feeamt"] = dtAccInfo.Rows[0]["feeamt"].ToString();
            row["insuraccountfee"] = zyjsddy_out.Qzgrzhzf;//其中个人账户支付|
            row["selffee"]=zyjsddy_out.Grzfxj;//个人支付现金|
            row["insurselffee"]=zyjsddy_out.Jbylzfje;//基本医疗自付金额|
            row["insurefee"] = zyjsddy_out.Tcjjzf;//统筹基金支付|
            row["chargedby"] = zyjsddy_out.Jbr;//经办人|
            row["dxhj"] = RMB_DX.Convert(zyjsddy_out.Hj);//大写合计|
            row["hj"]=zyjsddy_out.Hj;//合计|
            row["hspname"] = ProgramGlobal.HspName;
            row["hspkind"] = ProgramGlobal.HspKind;
            row["bndtcjjzf"] = zyjsddy_out.Bndtcjjzf;//本年度统筹基金支付
            row["bczfhgrzhye"] = zyjsddy_out.Bczfhgrzhye;//本次支付后个人账户余额
            row["dbzf"] = zyjsddy_out.Dbjjzf;//大病基金支付
            row["dbljzf"] = zyjsddy_out.Bnddbjjzf;//本年度大病基金支付
            row["cdbzf"] = zyjsddy_out.Cdbjjzf;//超大病基金支付
            row["gwybzzf"] = zyjsddy_out.Jrgwyjjje;//进入公务员基金金额
            row["bcbxze"] = zyjsddy_out.Bcbxze;//本次报销总额
            row["qfx"] = zyjsddy_out.Qfbz;//起付标准
            row["zycs"] = zyjsddy_out.Cycs;//出院次数

            if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) < 0)
            {
                row["balanceamt0"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应收
                row["balanceamt1"] = 0;
            }
            else if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) > 0)
            {
                row["balanceamt1"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应退
                row["balanceamt0"] = 0;
            }
            else
            {
                row["balanceamt0"] = 0;
                row["balanceamt1"] = 0;
            }
            dtLbl.Rows.Add(row);
            DataTable dtCost = billFrxOper.insurInfo(ihspid, CostInsurtypeKeyname.HDSYB.ToString());
            DataTable dtItemtype = billFrxOper.getItemTypeName();
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString()});
            }
            int j = 0;

            for (int a = 0; a < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); a++)
            {
                for (int i = 0; i <= 2 && j < dtItemtype.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dtItemtype.Rows[j]["name"].ToString();
                    for (int m = 0; m < dtCost.Rows.Count; m++)
                    {
                        if (dtCost.Rows[m]["name"] == dgv.Rows[a][i])
                        {
                            dgv.Rows[a][i + 1] = DataTool.FormatData(dtCost.Rows[j]["realfee"].ToString(), "2");
                        }
                        else
                        {
                            dgv.Rows[a][i + 1] = "0.00";
                        }
                    }
                }
            }            
            FastReport.Report hdybRpt = new FastReport.Report();
            try
            {
                hdybRpt.Load(chargeRptPath);
                hdybRpt.RegisterData(dtLbl, "Tb_LblText");
                hdybRpt.RegisterData(dgv, "Tb_Itemtype");
                //frxPrintView.print("IhspAccount.frx", ihspAccRpt);
                if (hdybRpt.Prepare())
                {
                    hdybRpt.Preview = previewCtrl;
                    hdybRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 邯郸市生育医保打印
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int IhspAccHdssyPrt(string ihspid)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_HDSSYFP.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            BillIhspcost billIhspcost = new BillIhspcost();
            BllInHspMedinsrHDSSY bllInHspMedinsrHDSSY = new BllInHspMedinsrHDSSY();
            DataTable dataTable = bllInHspMedinsrHDSSY.hdsyybinfo(ihspid);
            string info = dataTable.Rows[0]["registinfo"].ToString();
            string[] message = info.Split('|');//个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
            string info1 = dataTable.Rows[0]["settinfo"].ToString();
            string[] message1 = info.Split('|');////经办人|账户支付金额|单据号
            Ybjk ybjk = new Ybjk();
            Dysyjsd_in dysyjsd_in = new Dysyjsd_in();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            dysyjsd_in.Grbh = message[0];
            dysyjsd_in.Mzzyh = dt.Rows[0]["ihspcode"].ToString();
            dysyjsd_in.Jbr = message1[0];
            Dysyjsd_out dysyjsd_out = new Dysyjsd_out();
            int flag = ybjk.dysyjsd(dysyjsd_in, dysyjsd_out);
            if (flag < 0)
            {
                return -1;
            }
            DataTable dtLbl = new DataTable();
            DataTable dtAccInfo = billFrxOper.getIhspAccInfo(ihspid);
            dtLbl.Columns.Add("ihspcode", typeof(string));
            dtLbl.Columns.Add("name", typeof(string));
            dtLbl.Columns.Add("depart", typeof(string));
            dtLbl.Columns.Add("indate", typeof(string));
            dtLbl.Columns.Add("sex", typeof(string));
            dtLbl.Columns.Add("patienttype", typeof(string));
            dtLbl.Columns.Add("outdate", typeof(string));
            dtLbl.Columns.Add("days", typeof(string));
            dtLbl.Columns.Add("djh", typeof(string));
            dtLbl.Columns.Add("invoice", typeof(string));
            dtLbl.Columns.Add("healthcard", typeof(string));
            dtLbl.Columns.Add("prepamt", typeof(string));
            dtLbl.Columns.Add("feeamt", typeof(string));
            dtLbl.Columns.Add("selffee", typeof(string));
            dtLbl.Columns.Add("balanceamt0", typeof(string));
            dtLbl.Columns.Add("balanceamt1", typeof(string));
            dtLbl.Columns.Add("hspname", typeof(string));
            dtLbl.Columns.Add("hspkind", typeof(string));
            dtLbl.Columns.Add("chargedby", typeof(string));
            dtLbl.Columns.Add("dxhj", typeof(string));
            dtLbl.Columns.Add("hj", typeof(string));
            dtLbl.Columns.Add("zycs", typeof(string));
            dtLbl.Columns.Add("jsrq", typeof(string));
            dtLbl.Columns.Add("syylfdebtje",typeof(string));//生育医疗费定额补贴金额
            DataRow row = dtLbl.NewRow();
            row["jsrq"] = dysyjsd_out.Jsrq;//结算日期
            row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();//住院号
            row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();//姓名
            row["depart"] = dysyjsd_out.Ks;//科室
            row["indate"] = dysyjsd_out.Ryrq;// retdata[8];//入院日期|
            row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();//性别
            row["outdate"] = dysyjsd_out.Cyrq;// retdata[9];//出院日期|
            row["days"] = dysyjsd_out.Zyts;//住院天数|
            row["djh"] = message1[2];//单据号|
            row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();//流水号
            row["healthcard"] = dtAccInfo.Rows[0]["healthcard"].ToString();//社保账号
            row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();//医保类型
            row["prepamt"] = dtAccInfo.Rows[0]["prepamt"].ToString();//总预交款
            row["feeamt"] = dtAccInfo.Rows[0]["feeamt"].ToString();
            row["selffee"] = dysyjsd_out.Grzfxj;//个人支付现金|
            row["chargedby"] = dysyjsd_out.Jbr;//经办人|
            row["dxhj"] = RMB_DX.Convert(dysyjsd_out.Ssje);//大写合计|
            row["hj"] = dysyjsd_out.Ssje;//合计|
            row["hspname"] = ProgramGlobal.HspName;
            row["hspkind"] = ProgramGlobal.HspKind;
            row["zycs"] = dysyjsd_out.Zycs;//住院次数
            row["syylfdebtje"] = dysyjsd_out.Syylfdebtje;//生育医疗费定额补贴金额

            if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) < 0)
            {
                row["balanceamt0"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应收
                row["balanceamt1"] = 0;
            }
            else if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) > 0)
            {
                row["balanceamt1"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应退
                row["balanceamt0"] = 0;
            }
            else
            {
                row["balanceamt0"] = 0;
                row["balanceamt1"] = 0;
            }
            dtLbl.Rows.Add(row);
            DataTable dtCost = billFrxOper.insurInfo(ihspid, CostInsurtypeKeyname.HDSSY.ToString());
            DataTable dtItemtype = billFrxOper.getItemTypeName();
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            int j = 0;

            for (int a = 0; a < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); a++)
            {
                for (int i = 0; i <= 2 && j < dtItemtype.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dtItemtype.Rows[j]["name"].ToString();
                    for (int m = 0; m < dtCost.Rows.Count; m++)
                    {
                        if (dtCost.Rows[m]["name"] == dgv.Rows[a][i])
                        {
                            dgv.Rows[a][i + 1] = DataTool.FormatData(dtCost.Rows[j]["realfee"].ToString(), "2");
                        }
                        else
                        {
                            dgv.Rows[a][i + 1] = "0.00";
                        }
                    }
                }
            }
            FastReport.Report hdybRpt = new FastReport.Report();
            try
            {
                hdybRpt.Load(chargeRptPath);
                hdybRpt.RegisterData(dtLbl, "Tb_LblText");
                hdybRpt.RegisterData(dgv, "Tb_Itemtype");
                //frxPrintView.print("IhspAccount.frx", ihspAccRpt);
                if (hdybRpt.Prepare())
                {
                    hdybRpt.Preview = previewCtrl;
                    hdybRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 衡水武邑县医保打印
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int IhspAccHsdrybPrt(string ihspid)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_HSWYXYB.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            BllIhspMedinsrHSDR bllIhspMedinsrHSDR = new BllIhspMedinsrHSDR();
            DataTable dtReg = bllIhspMedinsrHSDR.readRegInfo(ihspid);
            //string info = dataTable.Rows[0]["registinfo"].ToString();
            //string[] message = info.Split('|');//个人编号|ic卡号|医疗类别|账户余额|单位编号|单位名称|封锁状态|经办人|入院诊断疾病编码|疾病名称|人员类别
            DataTable dtSett = bllIhspMedinsrHSDR.readSettleInfo(ihspid);
            //string info1 = dataTable.Rows[0]["settinfo"].ToString();
            //string[] message1 = info.Split('|');////单据号|经办人|账户支付金额|
            TopParameter common = new TopParameter();
            common.AKC190 = dt.Rows[0]["ihspcode"].ToString();
            common.AKC020 = dtReg.Rows[0]["ICCardID"].ToString();//message[1];
            common.AKA130 = dtReg.Rows[0]["MediType"].ToString();//message[2];
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.MSGNO = "1702";
            common.MSGID = "";
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            StringBuilder sb = new StringBuilder(50);
            sb.AppendFormat("<AKC190>{0}</AKC190>", common.AKC190);
            sb.AppendFormat("<AAE072>{1}</AAE072>", /*message1[0]*/dtSett.Rows[0]["Invoice"].ToString());
            common.INPUT = sb.ToString();
            WYJK wyjk = new WYJK();
            var opt = wyjk.zyjsddy(common);

            if (opt.ReturnNum == "-1")
            {
                MessageBox.Show("调用医保结算单打印失败！");
                return -1;
            }
            DataTable dtLbl = new DataTable();
            DataTable dtAccInfo = billFrxOper.getIhspAccInfo(ihspid);
            dtLbl.Columns.Add("ihspcode", typeof(string));//
            dtLbl.Columns.Add("name", typeof(string));//
            dtLbl.Columns.Add("depart", typeof(string));//
            dtLbl.Columns.Add("indate", typeof(string));//
            dtLbl.Columns.Add("sex", typeof(string));//
            dtLbl.Columns.Add("patienttype", typeof(string));//
            dtLbl.Columns.Add("outdate", typeof(string));//
            dtLbl.Columns.Add("djh", typeof(string));//
            dtLbl.Columns.Add("invoice", typeof(string));//
            dtLbl.Columns.Add("healthcard", typeof(string));//
            dtLbl.Columns.Add("prepamt", typeof(string));//
            dtLbl.Columns.Add("feeamt", typeof(string));//
            dtLbl.Columns.Add("balanceamt0", typeof(string));//补交金额
            dtLbl.Columns.Add("balanceamt1", typeof(string));//退费金额
            dtLbl.Columns.Add("hspname", typeof(string));//
            dtLbl.Columns.Add("hspkind", typeof(string));//
            dtLbl.Columns.Add("dxhj", typeof(string));//
            dtLbl.Columns.Add("jsrq", typeof(string));//

            dtLbl.Columns.Add("yydz",typeof(string));//医院垫支

            dtLbl.Columns.Add("Insurefee", typeof(string));//医保统筹支付
            dtLbl.Columns.Add("insuraccountfee", typeof(string));//个人账户支付
            dtLbl.Columns.Add("selffee", typeof(string));//个人自付
            dtLbl.Columns.Add("Self", typeof(string));//个人自费
            dtLbl.Columns.Add("accountbalance", typeof(string));//个人账户余额
            dtLbl.Columns.Add("sumInsurefee", typeof(string));//统筹累计支付

            DataRow row = dtLbl.NewRow();
            row["jsrq"] = dtAccInfo.Rows[0]["chargedate"].ToString();//结算日期
            row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();//住院号
            row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();//姓名
            row["depart"] = dt.Rows[0]["deparname"].ToString();//科室
            row["indate"] = dt.Rows[0]["indate"].ToString();// retdata[8];//入院日期|
            row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();//性别
            row["outdate"] = dt.Rows[0]["outdate"].ToString();// retdata[9];//出院日期|
            row["djh"] = dtSett.Rows[0]["Invoice"].ToString();//单据号|
            row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();//流水号
            row["healthcard"] = dtAccInfo.Rows[0]["healthcard"].ToString();//社保账号
            row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();//医保类型
            row["prepamt"] = dtAccInfo.Rows[0]["prepamt"].ToString();//总预交款
            row["feeamt"] = dtAccInfo.Rows[0]["feeamt"].ToString();//总费用
            row["dxhj"] = RMB_DX.Convert(dtAccInfo.Rows[0]["feeamt"].ToString());//大写合计|
            row["hspname"] = ProgramGlobal.HspName;
            row["hspkind"] = ProgramGlobal.HspKind;
            row["Insurefee"] =opt.AKC780;//医保统筹支付
            row["insuraccountfee"] = opt.AKC262;//本次个人账户应支付金额
            row["selffee"] = opt.AKC754;//总的个人自付金额
            row["Self"] =  opt.AKC253;//自费费用
            row["accountbalance"] =  opt.AKC087;//个人账户余额
            row["sumInsurefee"] = opt.AKC782;//统筹累计支付
           // row["yydz"] = ;


            if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) < 0)
            {
                row["balanceamt0"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应收
                row["balanceamt1"] = 0;
            }
            else if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) > 0)
            {
                row["balanceamt1"] = dtAccInfo.Rows[0]["balanceamt"].ToString();//应退
                row["balanceamt0"] = 0;
            }
            else
            {
                row["balanceamt0"] = 0;
                row["balanceamt1"] = 0;
            }
            dtLbl.Rows.Add(row);
            DataTable dtCost = billFrxOper.insurInfo(ihspid, CostInsurtypeKeyname.HSDRYB.ToString());
            DataTable dtItemtype = billFrxOper.getItemTypeName();
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            int j = 0;

            for (int a = 0; a < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 2)); a++)
            {
                for (int i = 0; i <= 2 && j < dtItemtype.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dtItemtype.Rows[j]["name"].ToString();
                    for (int m = 0; m < dtCost.Rows.Count; m++)
                    {
                        if (dtCost.Rows[m]["name"] == dgv.Rows[a][i])
                        {
                            dgv.Rows[a][i + 1] = DataTool.FormatData(dtCost.Rows[j]["realfee"].ToString(), "2");
                        }
                        else
                        {
                            dgv.Rows[a][i + 1] = "0.00";
                        }
                    }
                }
            }
            FastReport.Report hdybRpt = new FastReport.Report();
            try
            {
                hdybRpt.Load(chargeRptPath);
                hdybRpt.RegisterData(dtLbl, "Tb_LblText");
                hdybRpt.RegisterData(dgv, "Tb_Itemtype");
                //frxPrintView.print("IhspAccount.frx", ihspAccRpt);
                if (hdybRpt.Prepare())
                {
                    hdybRpt.Preview = previewCtrl;
                    hdybRpt.ShowPrepared();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 住院结算自费打印
        /// </summary>
        /// <returns></returns>
        public int IhspAccZfPrt(string acc_id)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_ZYZFFP.ToString()).Rows[0]["frmurl"].ToString();
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            DataTable dtAccInfo = billFrxOper.getAccInfo(acc_id);
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("ihspcode", typeof(string));
            dtLbl.Columns.Add("name", typeof(string));
            dtLbl.Columns.Add("indate", typeof(string));
            dtLbl.Columns.Add("sex", typeof(string));
            dtLbl.Columns.Add("outdate", typeof(string));
            dtLbl.Columns.Add("days", typeof(string));
            dtLbl.Columns.Add("billcode", typeof(string));
            dtLbl.Columns.Add("invoice", typeof(string));
            dtLbl.Columns.Add("patienttype", typeof(string));
            dtLbl.Columns.Add("healthcard", typeof(string));
            dtLbl.Columns.Add("casecode", typeof(string));
            dtLbl.Columns.Add("prepamt", typeof(string));
            dtLbl.Columns.Add("feeamt", typeof(string));
            dtLbl.Columns.Add("dxfeeamt", typeof(string));
            dtLbl.Columns.Add("selffee", typeof(string));
            dtLbl.Columns.Add("insurefee", typeof(string));
            dtLbl.Columns.Add("balanceamt0", typeof(string));
            dtLbl.Columns.Add("balanceamt1", typeof(string));
            dtLbl.Columns.Add("hspname", typeof(string));
            dtLbl.Columns.Add("hspkind", typeof(string));
            dtLbl.Columns.Add("now", typeof(string));
            dtLbl.Columns.Add("chargedby", typeof(string));
            dtLbl.Columns.Add("slfecash", typeof(string));
            DataRow row = dtLbl.NewRow();
            row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();
            row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();
            row["indate"] = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"]).ToString("yyyy-MM-dd");
            row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();
            row["outdate"] = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"]).ToString("yyyy-MM-dd");
            DateTime start = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"]);
            DateTime end = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"]);
            TimeSpan day = end.Subtract(start);
            row["days"] = day.Days.ToString();
            row["billcode"] = dtAccInfo.Rows[0]["billcode"].ToString();
            row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();
            row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();
            row["healthcard"] = dtAccInfo.Rows[0]["healthcard"].ToString();
            row["casecode"] = dtAccInfo.Rows[0]["casecode"].ToString();
            row["prepamt"] = dtAccInfo.Rows[0]["prepamt"].ToString();
            row["feeamt"] = dtAccInfo.Rows[0]["feeamt"].ToString();
            row["selffee"] = dtAccInfo.Rows[0]["insurefee"].ToString();
            row["insurefee"] = dtAccInfo.Rows[0]["insurefee"].ToString();
            row["chargedby"] = dtAccInfo.Rows[0]["chargedby"].ToString();
            row["dxfeeamt"] = RMB_DX.Convert(Convert.ToDecimal(dtAccInfo.Rows[0]["feeamt"]));
            row["hspname"] = ProgramGlobal.HspName;
            row["hspkind"] = ProgramGlobal.HspKind;
            row["now"] = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd");
            if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) < 0)
            {
                row["balanceamt0"] = dtAccInfo.Rows[0]["balanceamt"].ToString();
                row["balanceamt1"] = 0;
            }
            else if (Convert.ToDecimal(dtAccInfo.Rows[0]["balanceamt"]) > 0)
            {
                row["balanceamt1"] = dtAccInfo.Rows[0]["balanceamt"].ToString();
                row["balanceamt0"] = 0;
            }
            else
            {
                row["balanceamt0"] = 0;
                row["balanceamt1"] = 0;
            }


            string feeamt = dtAccInfo.Rows[0]["feeamt"].ToString();
            if (feeamt == "")
            {
                feeamt = "0";
            }
            string insurefee = dtAccInfo.Rows[0]["insurefee"].ToString();
            if (insurefee == "")
            {
                insurefee = "0";
            }
            string selffee = dtAccInfo.Rows[0]["insuraccountfee"].ToString();
            if (selffee == "")
            {
                selffee = "0";
            }
            double slfecash = double.Parse(DataTool.FormatData(feeamt, "2")) - double.Parse(DataTool.FormatData(insurefee, "2")) - double.Parse(DataTool.FormatData(selffee, "2"));
            row["slfecash"] = DataTool.FormatData(slfecash.ToString(), "2");
            dtLbl.Rows.Add(row);

            DataTable dtCost = billFrxOper.getIhspCostInfo(acc_id);
            DataTable dtItemtype = billFrxOper.getItemTypeName();
            DataTable dgv = new DataTable();
            DataColumn dc = new DataColumn("name1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee1", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee2", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("name3", typeof(System.String));
            dgv.Columns.Add(dc);
            dc = new DataColumn("realfee3", typeof(System.String));
            dgv.Columns.Add(dc);
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 3)); i++)
            {
                dgv.Rows.Add(new object[] { ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString(), ("").ToString() });
            }
            int j = 0;
            for (int a = 0; a < Math.Ceiling(Convert.ToDecimal(Convert.ToDouble(dtItemtype.Rows.Count) / 3)); a++)
            {
                for (int i = 0; i <= 4 && j < dtItemtype.Rows.Count; i = i + 2, j++)
                {
                    dgv.Rows[a][i] = dtItemtype.Rows[j]["name"].ToString();
                    for (int m = 0; m < dtCost.Rows.Count; m++)
                    {
                        if (dtCost.Rows[m]["name"] == dgv.Rows[a][i])
                        {
                            dgv.Rows[a][i + 1] = DataTool.FormatData(dtCost.Rows[j]["realfee"].ToString(), "2");
                        }
                        else
                        {
                            dgv.Rows[a][i + 1] = "0.00";
                        }
                    }
                }
            }            
            FastReport.Report ihspAccRpt = new FastReport.Report();
            try
            {
                ihspAccRpt.Load(chargeRptPath);
                ihspAccRpt.RegisterData(dgv, "Tb_Itemtype");
                ihspAccRpt.RegisterData(dtLbl, "Tb_LblText");
                //frxPrintView.print("IhspAccount.frx", ihspAccRpt);
                if (ihspAccRpt.Prepare())
                {
                    ihspAccRpt.ShowPrepared();
                }

            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        public DataTable zydyfp(String mtzyjl_iid)
        {
            String sql = "select cost_itemtype.name as xmlb,sum(fee) as amt from cost_itemtype,ihsp_costdet where ihsp_costdet.ihsp_id=" + mtzyjl_iid + " and ihsp_costdet.itemtype_id=cost_itemtype.id and ihsp_costdet.charged <> 'XX' GROUP BY xmlb ";
            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable GetDygrxx(String mtzyjl_iid)
        {
            string sql_up = "update inhospital set chargedate = '" + DateTime.Now.ToString() + "' where id =" + mtzyjl_iid;
            BllMain.Db.Update(sql_up);
            String sql = @"select (case sex when 'M' then '男' when 'W' then '女' when 'U' then '未知' end) as xb,chargedate as zyjzsj,(select sum(realfee) from ihsp_costdet where ihsp_id = " + mtzyjl_iid + " and ihsp_costdet.charged <> 'XX') as amt,inhospital.name from inhospital where id=" + mtzyjl_iid;
            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable getZyjlZyh(String mtzyjliid)
        {
            String sql = @"select ihsp_account.billcode as fph, ihspcode as zyh,inhospital.indate,inhospital.outdate,bas_depart.name as org_name from inhospital 
                            LEFT JOIN bas_depart on bas_depart.id = inhospital.depart_id
                            LEFT JOIN ihsp_account on ihsp_account.ihsp_id = inhospital.id
                            where inhospital.id = " + mtzyjliid;
             return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 住院发票打印
        /// </summary>
        /// <param name="acc_id"></param>
        /// <returns></returns>
        public int IhspAccPrt(string acc_id)
        {
            #region
            double cwf = 0;//床位费 
            double zcf = 0;//诊察费
            double jcf = 0;//检查费
            double hyf = 0;//化验费
            double zlf = 0;//治疗费
            double ssf = 0;//手术费
            double hlf = 0;//护理费
            double wsclf = 0;//卫生材料费
            double ypf = 0; //药品费
            double ysfwf = 0;//药事服务费
            double ybzlf = 0;//一般诊疗费
            double sxf = 0;//输血费
            double qtzyfy = 0;//其他住院收费
            string sql_up = " UPDATE ihsp_account SET print = print+1 WHERE ihsp_id = '" + acc_id + "';";
            BllMain.Db.Update(sql_up);
            string sqla = "select ihsp_id from ihsp_costdet where ihsp_id='" + acc_id + "' limit 1";
            string strZyjlid = BllMain.Db.Select(sqla).Tables[0].Rows[0]["ihsp_id"].ToString().Trim();
            DataTable datafpdy = zydyfp(strZyjlid);
            double hj = 0;
            for (int i = 0; i < datafpdy.Rows.Count; i++)
            {
                hj += DataTool.Getdouble(datafpdy.Rows[i]["Amt"].ToString().Trim());
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
                {
                    cwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//床位费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊察费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
                {
                    zcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊察费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复"))
                {
                    zlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("监护费"))
                {
                    hlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//护理费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费"))
                {
                    ssf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//手术费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
                {
                    hyf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("卫生材料费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("材料费"))
                {
                    wsclf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//卫生材料费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药品费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
                {
                    ypf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药品费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药事服务费"))
                {
                    ysfwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药事服务费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("一般诊疗费"))
                {
                    ybzlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//一般诊疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑血流图费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("数字胃肠") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("钼靶费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("碳14") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("视功能费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("骨密度") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费"))
                {
                    if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
                    {
                        jcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
                        continue;
                    }
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
                {
                    sxf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//输血费
                    continue;
                }
                else
                {
                    qtzyfy += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他住院收费
                    continue;
                }
            }
            DataTable Dygrxx = GetDygrxx(strZyjlid);
            hj = Math.Round(hj, 2);
            if (hj.ToString("0.00") != DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()).ToString("0.00"))
            {
                MessageBox.Show("项目类型之和【" + hj.ToString() + "】与病人费用总和【" + Dygrxx.Rows[0]["amt"].ToString() + "】不等！");
                //return;
            }
            DataTable dt_xx = getZyjlZyh(strZyjlid);
            string in_zfc1 = "|";
            in_zfc1 += ProgramGlobal.HspName + "|";//定点医院名称
            in_zfc1 += "|";
            in_zfc1 += dt_xx.Rows[0]["org_name"].ToString().Trim() + "|";//科室
            in_zfc1 += dt_xx.Rows[0]["fph"].ToString().Trim() + "|";//单据号
            in_zfc1 += dt_xx.Rows[0]["zyh"].ToString().Trim() + "|";//医院住院号
            in_zfc1 += DateTime.Parse(dt_xx.Rows[0]["indate"].ToString().Trim()).Year.ToString().Trim() + "|" + DateTime.Parse(dt_xx.Rows[0]["indate"].ToString().Trim()).Month.ToString().Trim() + "|" + DateTime.Parse(dt_xx.Rows[0]["indate"].ToString().Trim()).Day.ToString().Trim() + "|";//入院日期
            in_zfc1 += DateTime.Parse(dt_xx.Rows[0]["outdate"].ToString().Trim()).Year.ToString().Trim() + "|" + DateTime.Parse(dt_xx.Rows[0]["outdate"].ToString().Trim()).Month.ToString().Trim() + "|" + DateTime.Parse(dt_xx.Rows[0]["outdate"].ToString().Trim()).Day.ToString().Trim() + "|";//出院日期
            TimeSpan ts = DateTime.Parse(DateTime.Parse(dt_xx.Rows[0]["outdate"].ToString().Trim()).ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Parse(dt_xx.Rows[0]["indate"].ToString().Trim()).ToString("yyyy-MM-dd"));
            in_zfc1 += ts.Days.ToString().Trim() + "|";//住院天数
            in_zfc1 += Dygrxx.Rows[0]["name"].ToString().Trim() + "|";//患者姓名
            in_zfc1 += Dygrxx.Rows[0]["xb"].ToString().Trim() + "|";//患者性别
            in_zfc1 += "|";
            in_zfc1 += "|";//个人编号
            string sql_s = "SELECT bas_patienttype.name FROM inhospital LEFT JOIN bas_patienttype ON bas_patienttype.id = inhospital.bas_patienttype_id WHERE inhospital.id ='" + strZyjlid+"'";
            string dt_type = BllMain.Db.Select(sql_s).Tables[0].Rows[0][0].ToString();
            in_zfc1 += "床位费|" + cwf.ToString("0.00") + "|" + dt_type + "|护理费|" + hlf.ToString("0.00") + "|" + dt_type + "|诊查费|" + zcf.ToString("0.00") + "|" + dt_type + "|";
            in_zfc1 += "卫生材料费|" + wsclf.ToString("0.00") + "|" + dt_type + "|检查费|" + jcf.ToString("0.00") + "|" + dt_type + "|药品费|" + ypf.ToString("0.00") + "|" + dt_type + "|";
            in_zfc1 += "化验费|" + hyf.ToString("0.00") + "|" + dt_type + "|药事服务费|" + ysfwf.ToString("0.00") + "|" + dt_type + "|治疗费|" + zlf.ToString("0.00") + "|" + dt_type + "|";
            in_zfc1 += "一般诊疗费|" + ybzlf.ToString("0.00") + "|" + dt_type + "|手术费|" + ssf.ToString("0.00") + "|" + dt_type + "|其他住院费用|" + qtzyfy.ToString("0.00") + "|" + dt_type + "|输血费|" + sxf.ToString("0.00") + "|" + dt_type + "|";
            money n = new money(DataTool.Getdouble(DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()).ToString("0.00")));//费用合计-大写
            in_zfc1 += n.Convert() + "|";//合计大写
            in_zfc1 += DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()).ToString("0.00") + "|";//合计
            string sql_amt = "select COALESCE( sum(payfee),0) as sum from ihsp_payinadv where ihsp_id='" + strZyjlid + "'";
            DataTable dt_amt = BllMain.Db.Select(sql_amt).Tables[0];
            double amt_yj = 0;
            double amt_bj = 0;
            double amt_tf = 0;
            if (dt_amt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt_amt.Rows[0]["sum"].ToString().Trim()))
                {
                    amt_yj = DataTool.Getdouble(dt_amt.Rows[0]["sum"].ToString());
                    in_zfc1 += amt_yj.ToString("0.00") + "|";//预缴金额
                }
                else
                {
                    in_zfc1 += "0|";//预缴金额
                }
            }
            else
            {
                in_zfc1 += "0|";//预缴金额
            }
            amt_tf = amt_yj - DataTool.Getdouble(DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()).ToString("0.00"));
            if (amt_tf < 0)
            {
                amt_bj = -amt_tf;
                amt_tf = 0;
            }
            in_zfc1 += amt_bj.ToString("0.00") + "|";//补缴金额
            in_zfc1 += amt_tf.ToString("0.00") + "|";//退费金额
            string sql = "SELECT bas_doctor.`name` FROM ihsp_account LEFT JOIN bas_doctor ON bas_doctor.id = ihsp_account.chargedby_id WHERE STATUS = 'SETT' AND ihsp_id =  '" + acc_id + "'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            in_zfc1 += dt.Rows[0]["name"] + "|";//经办人cyjsYs
            //in_zfc1 += ProgramGlobal.Username + "|";//经办人
            //in_zfc1 += DateTime.Parse(Dygrxx.Rows[0]["zyjzsj"].ToString().Trim()).Year.ToString().Trim() + "|" + DateTime.Parse(Dygrxx.Rows[0]["zyjzsj"].ToString().Trim()).Month.ToString().Trim() + "|" + DateTime.Parse(Dygrxx.Rows[0]["zyjzsj"].ToString().Trim()).Day.ToString().Trim() + "|"; ;//结算日期
            in_zfc1 += DateTime.Now.ToString("yyyy") + "|" + DateTime.Now.ToString("MM") + "|" + DateTime.Now.ToString("dd") + "|"; //fpxx.AAE040.Substring(0, 4) + "|" + fpxx.AAE040.Substring(4, 2) + "|" + fpxx.AAE040.Substring(6, 2) + "|"; ;//结算日期
            
            FrmDy zyzfdy = new FrmDy();
            zyzfdy.in_zfc = in_zfc1;
            zyzfdy.dy("zyzf");
            #endregion
            #region
            //BllFrxOper billFrxOper = new BllFrxOper();
            //string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_ZYFP.ToString()).Rows[0]["frmurl"].ToString();
            //string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;
            ////结算信息
            //DataTable dtAccInfo = billFrxOper.getAccInfo(acc_id);
            //DataTable dtLbl = new DataTable();
            //dtLbl.Columns.Add("ihspcode", typeof(string));
            //dtLbl.Columns.Add("name", typeof(string));
            //dtLbl.Columns.Add("indate", typeof(string));
            //dtLbl.Columns.Add("sex", typeof(string));
            //dtLbl.Columns.Add("outdate", typeof(string));
            //dtLbl.Columns.Add("days", typeof(string));
            //dtLbl.Columns.Add("billcode", typeof(string));
            //dtLbl.Columns.Add("invoice", typeof(string));
            //dtLbl.Columns.Add("patienttype", typeof(string));
            //dtLbl.Columns.Add("insurcode", typeof(string));
            //dtLbl.Columns.Add("casecode", typeof(string));
            //dtLbl.Columns.Add("prepamt", typeof(string));
            //dtLbl.Columns.Add("feeamt", typeof(string));
            //dtLbl.Columns.Add("dxfeeamt", typeof(string));
            //dtLbl.Columns.Add("selffee", typeof(string));
            //dtLbl.Columns.Add("insurefee", typeof(string));
            //dtLbl.Columns.Add("balanceamt0", typeof(string));
            //dtLbl.Columns.Add("balanceamt1", typeof(string));
            //dtLbl.Columns.Add("hspname", typeof(string));
            //dtLbl.Columns.Add("hspkind", typeof(string));
            //dtLbl.Columns.Add("chargedate", typeof(string));
            //dtLbl.Columns.Add("chargedby", typeof(string));
            //dtLbl.Columns.Add("slfecash", typeof(string));
            //dtLbl.Columns.Add("qtybzf", typeof(string));
            //dtLbl.Columns.Add("dbbxlbl", typeof(string));
            //dtLbl.Columns.Add("dbbx", typeof(string));
            //dtLbl.Columns.Add("paytypename", typeof(string));
            //DataRow row = dtLbl.NewRow();
            //row["paytypename"] = dtAccInfo.Rows[0]["paytypename"].ToString();
            //row["ihspcode"] = dtAccInfo.Rows[0]["ihspcode"].ToString();
            //row["name"] = dtAccInfo.Rows[0]["ihspname"].ToString();
            //row["indate"] = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"]).ToString("yyyy-MM-dd");
            //row["sex"] = dtAccInfo.Rows[0]["sex"].ToString();
            //row["outdate"] = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"]).ToString("yyyy-MM-dd");
            //DateTime start = Convert.ToDateTime(dtAccInfo.Rows[0]["indate"]);
            //DateTime end = Convert.ToDateTime(dtAccInfo.Rows[0]["outdate"]);
            //TimeSpan day = end.Subtract(start);
            //row["days"] = day.Days.ToString();
            //row["billcode"] = dtAccInfo.Rows[0]["billcode"].ToString();
            //row["invoice"] = dtAccInfo.Rows[0]["invoice"].ToString();
            //row["patienttype"] = dtAccInfo.Rows[0]["patienttype"].ToString();
            ////row["insurcode"] = dtAccInfo.Rows[0]["insurcode"].ToString();
            //row["casecode"] = dtAccInfo.Rows[0]["casecode"].ToString();
            ////预交款
            //double d_prepamt = DataTool.Getdouble(dtAccInfo.Rows[0]["prepamt"].ToString());
            //row["prepamt"] = d_prepamt.ToString("0.00");
            ////总费用
            //double d_feeamt = DataTool.Getdouble(dtAccInfo.Rows[0]["feeamt"].ToString());
            //row["feeamt"] = d_feeamt.ToString("0.00");
            //row["dxfeeamt"] = RMB_DX.Convert(Convert.ToDecimal(dtAccInfo.Rows[0]["feeamt"]));
            ////row["selffee"] = dtAccInfo.Rows[0]["insuraccountfee"].ToString();
            ////row["insurefee"] = dtAccInfo.Rows[0]["insurefee"].ToString();
            ////row["qtybzf"] = dtAccInfo.Rows[0]["qtybzf"].ToString();
            //row["chargedby"] = dtAccInfo.Rows[0]["chargedby"].ToString();
            //row["hspname"] = ProgramGlobal.HspName;
            //row["hspkind"] = ProgramGlobal.HspKind;
            //row["chargedate"] = Convert.ToDateTime(dtAccInfo.Rows[0]["chargedate"]).ToString("yyyy-MM-dd HH:mm:ss");
            ////计算补缴金额和退费金额
            //double d_balanceamt = DataTool.Getdouble(dtAccInfo.Rows[0]["balanceamt"].ToString());
            //if (d_balanceamt < 0)
            //{
            //    row["balanceamt1"] = (-d_balanceamt).ToString("0.00");
            //    row["balanceamt0"] = "0.00";
            //}
            //else
            //{
            //    row["balanceamt0"] = d_balanceamt.ToString("0.00");
            //    row["balanceamt1"] = "0.00";
            //}
            //string ihsp_id = dtAccInfo.Rows[0]["ihsp_id"].ToString();
            //string patienttype_id = dtAccInfo.Rows[0]["patienttype_id"].ToString();
            //BillIhspMan bllIhspMan = new BillIhspMan();
            //string keyname = bllIhspMan.getInsurtype(patienttype_id);
            //if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            //{
            //    //自费
            //    //个人支付金额=总费用
            //    row["slfecash"] = d_feeamt.ToString("0.00");
            //}
            //else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    //市医保
            //    //BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            //    DataTable gysybDt = billFrxOper.getGYSYBZyjsInfo(ihsp_id);
            //    //个人编号
            //    row["insurcode"] = gysybDt.Rows[0]["personcode"].ToString();
            //    //基本统筹支付
            //    double d_jbtczf = DataTool.Getdouble(gysybDt.Rows[0]["fund1pay"].ToString());
            //    //大额统筹支付
            //    double d_detczf = DataTool.Getdouble(gysybDt.Rows[0]["fund2pay"].ToString());
            //    //医疗补助支付
            //    double d_ylbzzf = DataTool.Getdouble(gysybDt.Rows[0]["fund3pay"].ToString());
            //    //商保支付
            //    double d_sbzf = DataTool.Getdouble(gysybDt.Rows[0]["sbpay"].ToString());
            //    //个人帐户支付
            //    double d_grzhzf = DataTool.Getdouble(gysybDt.Rows[0]["acctpay"].ToString());
            //    //医保统筹支付 = 基本统筹支付'fund1pay'+大额统筹支付'fund2pay'
            //    row["insurefee"] = (d_jbtczf + d_detczf).ToString("0.00");
            //    row["selffee"] = d_grzhzf.ToString("0.00");
            //    //其他医保支付 = 医疗补助支付
            //    row["qtybzf"] = d_ylbzzf.ToString("0.00");
            //    //医保报销 = 基本统筹支付+大额统筹支付+医疗补助支付+商保支付
            //    double d_ybbx = d_jbtczf + d_detczf + d_ylbzzf + d_sbzf;
            //    //个人支付金额 = 总金额-医保报销-个人帐户支付
            //    double d_grzfje = d_feeamt - d_ybbx - d_grzhzf;
            //    row["slfecash"] = d_grzfje.ToString("0.00");
            //    if (d_sbzf > 0)
            //    {
            //        row["dbbxlbl"] = "商保支付";
            //        row["dbbx"] = d_sbzf.ToString("0.00");
            //    }
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            //{
            //    //异地医保
            //    DataTable gzsybDt = billFrxOper.getGZSYBZyjsInfo(ihsp_id);
            //    string fzx = gzsybDt.Rows[0]["yab003"].ToString();
            //    if (fzx == "9908")
            //    {
            //        row["patienttype"] = "省老干";
            //        row["insurefee"] = d_feeamt;//医保统筹支付
            //        row["selffee"] = "0.00";//个人账户支付
            //        row["qtybzf"] = "0.00";//其他医保支付
            //        row["slfecash"] = "0.00";//个人支付金额
            //    }
            //    else
            //    {
            //        if (fzx == "9900")
            //            row["patienttype"] = "省直医保";
            //        else
            //            row["patienttype"] = "异地医保";
            //        //个人编号
            //        row["insurcode"] = gzsybDt.Rows[0]["aac001"].ToString();
            //        //基本统筹支付
            //        double d_jbtczf = DataTool.Getdouble(gzsybDt.Rows[0]["yka248"].ToString());
            //        //大病统筹支付
            //        double d_dbtczf = DataTool.Getdouble(gzsybDt.Rows[0]["yka062"].ToString());
            //        //公务员统筹支付
            //        double d_gwytczf = DataTool.Getdouble(gzsybDt.Rows[0]["yke030"].ToString());
            //        //个人帐户支付
            //        double d_grzhzf = DataTool.Getdouble(gzsybDt.Rows[0]["yka065"].ToString());

            //        //医保统筹支付 = 基本统筹支付'yka248' +大病统筹支付'yka062'
            //        row["insurefee"] = (d_jbtczf + d_dbtczf).ToString("0.00");
            //        row["selffee"] = d_grzhzf.ToString("0.00");
            //        //其他医保支付 = 公务员统筹支付
            //        row["qtybzf"] = d_gwytczf.ToString("0.00");
            //        //医保报销 = 基本统筹支付+大病统筹支付+公务员统筹支付
            //        double d_ybbx = d_jbtczf + d_dbtczf + d_gwytczf;
            //        //个人支付金额=总金额-个人帐户支付-医保报销
            //        double d_grzfje = d_feeamt - d_grzhzf - d_ybbx;
            //        row["slfecash"] = d_grzfje.ToString("0.00");
            //    }
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            //{
            //    //农合
            //    DataTable gzsnhDt = billFrxOper.getGZSNHZyjsInfo(ihsp_id);
            //    //个人编号
            //    row["insurcode"] = gzsnhDt.Rows[0]["memberno"].ToString();
            //    //基金支付金额
            //    double d_calculateMoney = DataTool.Getdouble(gzsnhDt.Rows[0]["calculateMoney"].ToString());
            //    //民政优抚医疗补助
            //    double d_yfmedicalaid = DataTool.Getdouble(gzsnhDt.Rows[0]["yfmedicalaid"].ToString());
            //    //民政城乡医疗救助
            //    double d_cxmedicalaid = DataTool.Getdouble(gzsnhDt.Rows[0]["cxmedicalaid"].ToString());
            //    //本次大病保险补偿金额
            //    double d_CIICalculateMoney = DataTool.Getdouble(gzsnhDt.Rows[0]["CIICalculateMoney"].ToString());
            //    //慈善总会支付金额
            //    double d_ChinaCharityPay = DataTool.Getdouble(gzsnhDt.Rows[0]["ChinaCharityPay"].ToString());
            //    //计生两户减免费用金额
            //    double d_FamilyPlanningWaiver = DataTool.Getdouble(gzsnhDt.Rows[0]["FamilyPlanningWaiver"].ToString());

            //    //医保统筹支付 = 基金支付金额
            //    row["insurefee"] = d_calculateMoney.ToString("0.00");
            //    //个人账户支付 0
            //    row["selffee"] = "0.00";
            //    //其他医保支付 = 民政补助 = 民政优抚医疗补助+民政城乡医疗救助
            //    row["qtybzf"] = (d_yfmedicalaid + d_cxmedicalaid).ToString("0.00");
            //    //大病报销
            //    double d_dbbx = d_yfmedicalaid + d_cxmedicalaid + d_CIICalculateMoney + d_ChinaCharityPay + d_FamilyPlanningWaiver;
            //    if (d_dbbx > 0)
            //    {
            //        row["dbbxlbl"] = "大病报销";
            //        row["dbbx"] = d_dbbx.ToString("0.00");
            //    }
            //    //个人支付金额 = 总金额-基金支付金额-大病报销
            //    double d_grzfje = d_feeamt - d_calculateMoney - d_dbbx;
            //    row["slfecash"] = d_grzfje.ToString("0.00");
            //}

            //dtLbl.Rows.Add(row);

            //#region 费用汇总
           // DataTable dtCost = billFrxOper.getIhspCostInfo(acc_id);
            //DataTable dgv = new DataTable();
            //dgv.Columns.Add("cwf", typeof(string));
            //dgv.Columns.Add("zcf", typeof(string));
            //dgv.Columns.Add("jcf", typeof(string));
            //dgv.Columns.Add("zlf", typeof(string));
            //dgv.Columns.Add("hlf", typeof(string));
            //dgv.Columns.Add("ssf", typeof(string));
            //dgv.Columns.Add("hyf", typeof(string));
            //dgv.Columns.Add("xyf", typeof(string));
            //dgv.Columns.Add("zcyf", typeof(string));
            //dgv.Columns.Add("cyf", typeof(string));
            //dgv.Columns.Add("sxf", typeof(string));
            //dgv.Columns.Add("qtf", typeof(string));
            //DataRow dgvRow = dgv.NewRow();
            //dgvRow["cwf"] = "0.00";
            //dgvRow["zcf"] = "0.00";
            //dgvRow["jcf"] = "0.00";
            //dgvRow["zlf"] = "0.00";
            //dgvRow["hlf"] = "0.00";
            //dgvRow["ssf"] = "0.00";
            //dgvRow["hyf"] = "0.00";
            //dgvRow["xyf"] = "0.00";
            //dgvRow["zcyf"] = "0.00";
            //dgvRow["cyf"] = "0.00";
            //dgvRow["sxf"] = "0.00";
            //dgvRow["qtf"] = "0.00";
            //double qtf = 0;
            //for (int i = 0; i < dtCost.Rows.Count; i++)
            //{
            //    if (dtCost.Rows[i]["name"].ToString() == "床位费")
            //    {
            //        dgvRow["cwf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "诊查费")
            //    {
            //        dgvRow["zcf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "检查费")
            //    {
            //        dgvRow["jcf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "治疗费")
            //    {
            //        dgvRow["zlf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "护理费")
            //    {
            //        dgvRow["hlf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "手术费")
            //    {
            //        dgvRow["ssf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "化验费")
            //    {
            //        dgvRow["hyf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "西药")
            //    {
            //        dgvRow["xyf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "中成药")
            //    {
            //        dgvRow["zcyf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "中草药")
            //    {
            //        dgvRow["cyf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "输血费")
            //    {
            //        dgvRow["sxf"] = DataTool.FormatData(dtCost.Rows[i]["realfee"].ToString(), "2");
            //    }
            //    else if (dtCost.Rows[i]["name"].ToString() == "其他费用" || dtCost.Rows[i]["name"].ToString() == "卫生材料" || dtCost.Rows[i]["name"].ToString() == "药物服务费" || dtCost.Rows[i]["name"].ToString() == "一般诊疗费")
            //    {
            //        qtf += double.Parse(dtCost.Rows[i]["realfee"].ToString());
            //    }
            //}
            //dgvRow["qtf"] = qtf.ToString("0.00");
            //dgv.Rows.Add(dgvRow);
            //#endregion 

            //FastReport.Report ihspAccRpt = new FastReport.Report();
            //try
            //{
            //    ihspAccRpt.Load(chargeRptPath);
            //    ihspAccRpt.RegisterData(dgv, "Tb_fyhz");
            //    ihspAccRpt.RegisterData(dtLbl, "Tb_LblText");
            //    print(frmurl, ihspAccRpt);
            //    //if (ihspAccRpt.Prepare())
            //    //{
            //    //    ihspAccRpt.ShowPrepared();
            //    //}

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("打印失败！异常信息：" + ex.Message);
            //    return -1;
            //}
            #endregion
            return 0;
        }

         /// <summary>
        /// 贵州省新型农村合作医疗住院补偿结算单
        /// </summary>
        /// <returns></returns>
        public int IhspAccGzsnhPrt(string thisid, string patienttype_id)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getFrmurl(patienttype_id);
            string chargeRptPath = GlobalParams.reportDir + "\\" + frmurl;            
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            DataTable dt = bllGzsnhMethod.readSettInfo(thisid);
            FastReport.Report ihspAccRpt = new FastReport.Report();
            try
            {
                ihspAccRpt.Load(chargeRptPath);
                ihspAccRpt.RegisterData(dt,"Tb_dt");
                if (ihspAccRpt.Prepare())
                {
                    ihspAccRpt.ShowPrepared();
                }

            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <param name="rptName"></param>
        /// <param name="rpt"></param>
        /// <returns></returns>
        public int print(String rptName, FastReport.Report rpt)
        {
            Ini.INIClass(Ini.syspath);
            String printName = Ini.IniReadValue("reportprint", rptName);
            if (String.IsNullOrEmpty(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();

                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint", rptName);
            }
            if (String.IsNullOrEmpty(printName))
            {
                MessageBox.Show("没有指定打印机,无法打印");
                return -1;
            }
            if (!exists(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();

                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint", rptName);
            }

            rpt.PrintSettings.ShowDialog = false;
            rpt.PrintSettings.Printer = printName;
            rpt.Print();
            return 0;
        }

        private Boolean exists(string printerName)
        {
            foreach (string installedPrntName in PrinterSettings.InstalledPrinters)
            {
                if (installedPrntName == printerName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 腕带打印
        /// </summary>
        /// <param name="Mtzyil_iid"></param>
        /// <returns></returns>
        public int WristbandPrt(string Mtzyil_iid)
        {
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.IHSP_WRISTBAND.ToString()).Rows[0]["frmurl"].ToString();
            string prtPath = GlobalParams.reportDir + "\\" + frmurl;

            BillIhspMan billIhspMan = new BillIhspMan();
            DataTable dwddt = billIhspMan.GetWdxx(Mtzyil_iid);
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("zyh", typeof(string));
            dt1.Columns.Add("hzxm", typeof(string));
            dt1.Columns.Add("xb", typeof(string));
            dt1.Columns.Add("dob", typeof(string));
            dt1.Columns.Add("zyjlrysj", typeof(string));
            DataRow row = dt1.NewRow();
            row["zyh"] = "梦里面什么都有";//dwddt.Rows[0]["zyh"].ToString();
            row["hzxm"] = dwddt.Rows[0]["hzxm"].ToString();
            row["xb"] = dwddt.Rows[0]["xb"].ToString();

            row["zyjlrysj"] = DateTime.Parse(dwddt.Rows[0]["zyjlrysj"].ToString()).ToString("yyyy-MM-dd");
            string csrq = DateTime.Parse(dwddt.Rows[0]["dob"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            String hznl = xsage(csrq);
            row["dob"] = hznl;
            dt1.Rows.Add(row);
            FastReport.Report ihspAccRpt = new FastReport.Report();
            try
            {
                ihspAccRpt.Load(prtPath);

                ihspAccRpt.RegisterData(dt1, "wtr");
                //print(prtPath, ihspAccRpt); 直接打印函数
                ihspAccRpt.Show(); //预览函数
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败！异常信息：" + ex.Message);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 新生儿腕带打印
        /// </summary>
        /// <param name="Mtzyil_iid"></param>
        /// <returns></returns>
        public void xse(DataTable dwddt)
        {
            for (int i = 0; i < dwddt.Rows.Count; i++)
            {
                BllFrxOper billFrxOper = new BllFrxOper();
                string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.xse_WRISTBAND.ToString()).Rows[0]["frmurl"].ToString();
                string prtPath = GlobalParams.reportDir + "\\" + frmurl;
                BillIhspMan billIhspMan = new BillIhspMan();
                DataTable dt1 = new DataTable();//hzxm    xb   sg   tz   zyh    csrq
                dt1.Columns.Add("zyh", typeof(string));
                dt1.Columns.Add("hzxm", typeof(string));
                dt1.Columns.Add("xb", typeof(string));
                dt1.Columns.Add("sg", typeof(string));
                dt1.Columns.Add("tz", typeof(string));
                dt1.Columns.Add("csrq", typeof(string));
                dt1.Columns.Add("mqname", typeof(string));
                DataRow row = dt1.NewRow();
                row["zyh"] = dwddt.Rows[i]["zyh"].ToString();
                row["hzxm"] = dwddt.Rows[i]["name"].ToString();
                row["xb"] = dwddt.Rows[i]["sex"].ToString();

                row["csrq"] = Convert.ToDateTime(dwddt.Rows[i]["birthday"].ToString()).ToString("yyyy-MM-dd")+ " " + dwddt.Rows[i]["birthtime"].ToString();
                row["sg"] = dwddt.Rows[i]["height"].ToString()+" cm";
                row["tz"] = dwddt.Rows[i]["weight"].ToString()+" 克";
                row["mqname"] = dwddt.Rows[i]["mqname"].ToString() + " 克";
                dt1.Rows.Add(row);
                FastReport.Report ihspAccRpt = new FastReport.Report();
                try
                {
                    ihspAccRpt.Load(prtPath);
                    ihspAccRpt.RegisterData(dt1, "wtr");
                    //print(prtPath, ihspAccRpt); 直接打印函数
                    ihspAccRpt.Show(); //预览函数
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打印失败！异常信息：" + ex.Message);
                }
                
            }
        }
        /// <summary>
        /// 根据出生日期算出年龄
        /// </summary>
        /// <param name="strCsrq"></param>
        /// <returns></returns>
        public String xsage(String strCsrq)
        {
            String nl = "";
            if (strCsrq != null || !strCsrq.Equals(""))
            {
                string nowtime = DateTime.Now.ToString("yyyy-MM");
                string nown = nowtime.Split('-')[0];
                string nowy = nowtime.Split('-')[1];
                string csrqn = strCsrq.Split('-')[0];
                string csrqy = strCsrq.Split('-')[1];
                int c = int.Parse(csrqy) - int.Parse(nowy);
                int age = int.Parse(nown) - int.Parse(csrqn);
                if (c > 0)
                {
                    return nl = (age - 1).ToString();
                }
                else
                {
                    return nl = age.ToString();
                }
            }
            return nl;
        }
    }
}
