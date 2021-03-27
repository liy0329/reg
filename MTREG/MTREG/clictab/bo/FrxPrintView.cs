using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MTHIS.common;
using MTHIS.db;
using MTHIS.chklist;
using System.Drawing.Printing;
using MTHIS.tools;
using MTREG.clintab.bll;

namespace MTREG.clintab.bo
{
    class FrxPrintView
    {
        BllFrxOper bllFrxOper = new BllFrxOper();
        BllClicAfterinfo bllAccountGathered = new BllClicAfterinfo();
        BllClicTabReport bllClinicTabReport = new BllClicTabReport();

        public FrxPrintView() { }
        FastReport.Preview.PreviewControl previewCtrl;
        public FrxPrintView(FastReport.Preview.PreviewControl previewCtrl)
        {
            this.previewCtrl = previewCtrl;
        }
        /// <summary>
        /// 科室收入报表预览
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="depart"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewDepartInWindow(string beginTime,string endTime,string deparType,string depart,string patienType)
        {
        //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicDepartAccounting.frx";
            DataTable dtPageHeader = bllFrxOper.getDepartInfo(beginTime, endTime,deparType,depart,patienType);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime",typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart",typeof(string));
            dtTime.Columns.Add("type",typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = depart;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report departRpt = new FastReport.Report();
            try
            {
                departRpt.Load(chkRptPath);
                departRpt.RegisterData(dtPageHeader, "DepartReport");
                departRpt.RegisterData(dtTime,"Time");
                departRpt.Preview = previewCtrl;
                if (departRpt.Prepare())
                {
                    departRpt.ShowPrepared();
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
        /// 医生收入报表预览
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewDoctorInWindow(string beginTime, string endTime, string deparType,string depart, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicDoctorAccounting.frx";
            DataTable dtPageHeader = bllFrxOper.getDoctorInfo(beginTime, endTime,deparType,depart,patienType);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = depart;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report doctorRpt = new FastReport.Report();
            try
            {
                doctorRpt.Load(chkRptPath);
                doctorRpt.RegisterData(dtPageHeader, "DepartReport");
                doctorRpt.RegisterData(dtTime, "Time");
                doctorRpt.Preview = previewCtrl;
                if (doctorRpt.Prepare())
                {
                    doctorRpt.ShowPrepared();
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
        /// 打印医生收入报表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printDoctorAccount(string beginTime, string endTime, string deparType, string depart, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicDoctorAccounting.frx";
            DataTable dtPageHeader = bllFrxOper.getDoctorInfo(beginTime, endTime, deparType, depart, patienType);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = depart;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report doctorRpt = new FastReport.Report();
            try
            {
                doctorRpt.Load(chkRptPath);
                doctorRpt.RegisterData(dtPageHeader, "DepartReport");
                doctorRpt.RegisterData(dtTime, "Time");
                print("ClinicDoctorAccounting", doctorRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 打印科室收入报表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="depart"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printDepartAccount(string beginTime, string endTime,string deparType, string depart, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicDepartAccounting.frx";
            DataTable dtPageHeader = bllFrxOper.getDepartInfo(beginTime, endTime, deparType, depart, patienType);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = depart;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report departRpt = new FastReport.Report();
            try
            {
                departRpt.Load(chkRptPath);
                departRpt.RegisterData(dtPageHeader, "DepartReport");
                departRpt.RegisterData(dtTime, "Time");
                print("ClinicDepartAccounting", departRpt);
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
        public int print(string rptName, FastReport.Report rpt)
        {
            string printName = Ini.IniReadValue("reportprint",rptName);
            if (string.IsNullOrEmpty(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();
                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint",rptName);
            }
            if (string.IsNullOrEmpty(printName))
            {
                MessageBox.Show("没有指定打印机，无法打印");
                return -1;
            }
            if (!exists(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();
                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint",rptName);
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
        /// 门诊结算后项目汇总报表预览
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewItemInWindow(string beginTime, string endTime, string doctor, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabAfterCostItemInfo.frx";
            DataTable dtItem = bllAccountGathered.getItemGather(beginTime, endTime);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = doctor;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report itemRpt = new FastReport.Report();
            try
            {
                itemRpt.Load(chkRptPath);
                itemRpt.RegisterData(dtItem, "Table_Item");
                itemRpt.RegisterData(dtTime, "Table_Time");
                itemRpt.Preview = previewCtrl;
                if (itemRpt.Prepare())
                {
                    itemRpt.ShowPrepared();
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
        /// 门诊结算后支付类型报表预览
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewPayTypeInWindow(string beginTime, string endTime, string doctor, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabAfterPayTypeInfo.frx";
            DataTable dtPayType = bllAccountGathered.getPaytypeGather(beginTime, endTime);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = doctor;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chkRptPath);
                payTypeRpt.RegisterData(dtPayType, "Table_PayType");
                payTypeRpt.RegisterData(dtTime, "Table_Time");
                payTypeRpt.Preview = previewCtrl;
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
        /// 打印门诊结算后项目汇总报表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printItem(string beginTime, string endTime, string doctor, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabAfterCostItemInfo.frx";
            DataTable dtItem = bllAccountGathered.getItemGather(beginTime, endTime);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = doctor;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report itemRpt = new FastReport.Report();
            try
            {
                itemRpt.Load(chkRptPath);
                itemRpt.RegisterData(dtItem, "Table_Item");
                itemRpt.RegisterData(dtTime, "Table_Time");
                print("ClinicTabAfterCostItemInfo", itemRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 打印门诊结算后支付类型汇总报表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printPayType(string beginTime, string endTime, string doctor, string patienType)
        {
            //    string chkRptPath = Application.StartupPath + "\\ChkRpt.frx";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabAfterPayTypeInfo.frx";
            DataTable dtPayType = bllAccountGathered.getPaytypeGather(beginTime, endTime);
            DataTable dtTime = new DataTable();
            dtTime.Columns.Add("starTime", typeof(string));
            dtTime.Columns.Add("endTime", typeof(string));
            dtTime.Columns.Add("depart", typeof(string));
            dtTime.Columns.Add("type", typeof(string));
            
            DataRow row = dtTime.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["depart"] = doctor;
            row["type"] = patienType;
            dtTime.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chkRptPath);
                payTypeRpt.RegisterData(dtPayType, "Table_PayType");
                payTypeRpt.RegisterData(dtTime, "Table_Time");
                print("ClinicTabAfterPayTypeInfo", payTypeRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 打印门诊收费员日结表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printClinicTabCharger(string id,string flag,string printOrview)
        {
            string beginTime="";
            string endTime = "";
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabForCharger.frx";
            DataTable dtTabinfo = bllClinicTabReport.getCharger(id,flag);
            DataTable dtCharge=new DataTable();
            if (flag == "duty")
            {
                beginTime = dtTabinfo.Rows[0]["startdate"].ToString();
                endTime = dtTabinfo.Rows[0]["enddate"].ToString();
                string chargeby = dtTabinfo.Rows[0]["charger_id"].ToString();
                dtCharge = bllClinicTabReport.getChargeFee(beginTime, endTime, chargeby, "");
            }
            else if (flag == "tab")
            {
                beginTime = dtTabinfo.Rows[0]["startdate"].ToString();
                endTime = dtTabinfo.Rows[0]["enddate"].ToString();
                string depart_id = dtTabinfo.Rows[0]["depart_id"].ToString();
                dtCharge = bllClinicTabReport.getChargeFee(beginTime, endTime, "", depart_id);
            }
            DataTable dtPaysum=bllClinicTabReport.getPaysumby();
            DataTable dtFee = new DataTable();
            dtFee.Columns.Add("docname", typeof(string));
            dtFee.Columns.Add("recivefee", typeof(string));
            dtFee.Columns.Add("retfee", typeof(string));
            dtFee.Columns.Add("realfee", typeof(string));         
            dtFee.Columns.Add("charinvoice", typeof(string));
            dtFee.Columns.Add("retinvoice", typeof(string));
            dtFee.Columns.Add("realinvoice", typeof(string));
            for(int i=0;i<dtPaysum.Rows.Count;i++)
            {
               dtFee.Columns.Add( "pTypeFee" + i, typeof(string));
            }
            for (int j = 0; j < dtCharge.Rows.Count; j++)
            {
                DataRow rowFee = dtFee.Rows.Add();
                rowFee["docname"] = dtCharge.Rows[0]["name"].ToString();
                rowFee["recivefee"] = dtCharge.Rows[0]["charfee"].ToString();
                if (rowFee["recivefee"].ToString() == "")
                {
                    rowFee["recivefee"] = "0";
                }
                rowFee["retfee"] = dtCharge.Rows[0]["retfee"].ToString();
                if (rowFee["retfee"].ToString() == "")
                {
                    rowFee["retfee"] = "0";
                }
                rowFee["realfee"] = dtCharge.Rows[0]["allfee"].ToString();
                if (rowFee["realfee"].ToString() == "")
                {
                    rowFee["realfee"] = "0";
                }
                rowFee["charinvoice"] = dtCharge.Rows[0]["charinvoice"].ToString();
                if (rowFee["charinvoice"].ToString() == "")
                {
                    rowFee["charinvoice"] = "0";
                }
                rowFee["retinvoice"] = dtCharge.Rows[0]["retinvoice"].ToString();
                if (rowFee["retinvoice"].ToString() == "")
                {
                    rowFee["retinvoice"] = "0";
                }
                rowFee["realinvoice"] = dtCharge.Rows[0]["allinvoice"].ToString();
                if (rowFee["realinvoice"].ToString() == "")
                {
                    rowFee["realinvoice"] = "0";
                }
                for (int i = 0; i < dtPaysum.Rows.Count; i++)
                {
                    rowFee["pTypeFee" + i] = dtCharge.Rows[j]["pTypeFee" + i].ToString();
                    if (rowFee["pTypeFee" + i].ToString() == "")
                    {
                        rowFee["pTypeFee" + i] = "0";
                    }
                }
            }
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("starTime", typeof(string));
            dtInfo.Columns.Add("endTime", typeof(string));
            dtInfo.Columns.Add("title", typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["title"] = ProgramGlobal.HspName + "门诊收费员日结表";
            dtInfo.Rows.Add(row);
            FastReport.Report chargerRpt = new FastReport.Report();
            if (printOrview == "print")
            {
                try
                {
                    chargerRpt.Load(chkRptPath);
                    chargerRpt.RegisterData(dtFee, "Charger");
                    chargerRpt.RegisterData(dtInfo, "Info");
                    print("ClinicTabForCharger", chargerRpt);
                }
                catch
                {
                    MessageBox.Show("打印失败！");
                    return -1;
                }
            }
            else
            {
                try
                {
                    chargerRpt.Load(chkRptPath);
                    chargerRpt.RegisterData(dtFee, "Charger");
                    chargerRpt.RegisterData(dtInfo, "Info");
                    chargerRpt.Preview = previewCtrl;
                    if (chargerRpt.Prepare())
                    {
                        chargerRpt.ShowPrepared();
                    }
                }
                catch
                {
                    MessageBox.Show("预览失败！");
                    return -1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 预览门诊收入汇总表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewClinicTabCostAmtInWindow(string ids,string beginTime, string endTime)
        {
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabForCostAmt.frx";
            DataTable dtCostAmt = bllClinicTabReport.getCostAmt(ids,beginTime, endTime);
            double allfee = 0;
            for (int i = 0; i < dtCostAmt.Rows.Count; i++)
            {
                allfee += DataTool.stringToDouble(dtCostAmt.Rows[i]["realfee"].ToString());
            }
            DataRow dr = dtCostAmt.Rows.Add();
            dr["name"] = "合计金额";
            dr["realfee"] = allfee.ToString();

            DataTable dtInfo = new DataTable();
            DataTable dt = bllClinicTabReport.getInfo(ids,"tab");
            dtInfo.Columns.Add("starTime", typeof(string));
            dtInfo.Columns.Add("endTime", typeof(string));
            dtInfo.Columns.Add("billcode", typeof(string));
            dtInfo.Columns.Add("charger", typeof(string));
            dtInfo.Columns.Add("title",typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["title"] = ProgramGlobal.HspName + "门诊收入汇总日结表";
            row["charger"] = "科室：" + dt.Rows[0]["depname"].ToString();
            row["billcode"] = "";            
            dtInfo.Rows.Add(row);
            FastReport.Report costAmtRpt = new FastReport.Report();
            try
            {
                costAmtRpt.Load(chkRptPath);
                costAmtRpt.RegisterData(dtCostAmt, "CostAmt");
                costAmtRpt.RegisterData(dtInfo, "Info");
                costAmtRpt.Preview = previewCtrl;
                if (costAmtRpt.Prepare())
                {
                    costAmtRpt.ShowPrepared();
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
        /// 打印门诊收入汇总报表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printClinicTabCostAmt(string ids,string beginTime, string endTime)
        {
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabForCostAmt.frx";
            DataTable dtCostAmt = bllClinicTabReport.getCostAmt(ids,beginTime, endTime);
            DataTable dtInfo = new DataTable();
            DataTable dt = bllClinicTabReport.getInfo(ids,"tab");
            dtInfo.Columns.Add("starTime", typeof(string));
            dtInfo.Columns.Add("endTime", typeof(string));
            dtInfo.Columns.Add("billcode", typeof(string));
            dtInfo.Columns.Add("charger", typeof(string));
            dtInfo.Columns.Add("title", typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["title"] = ProgramGlobal.HspName + "门诊收入汇总日结表";
            row["charger"] = "科室：" + dt.Rows[0]["depname"].ToString();
            row["billcode"] = "";
            dtInfo.Rows.Add(row);
            FastReport.Report costAmtRpt = new FastReport.Report();
            try
            {
                costAmtRpt.Load(chkRptPath);
                costAmtRpt.RegisterData(dtCostAmt, "CostAmt");
                costAmtRpt.RegisterData(dtInfo, "Info");
                print("ClinicTabForCostAmt", costAmtRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 预览支付类型日结表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int viewClinicTabPayTypeInWindow(string ids,string beginTime, string endTime,string flag)
        {
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabForPaytype.frx";
            DataTable dtPayType = bllClinicTabReport.getPayType(ids,beginTime, endTime,flag);
            DataTable dtInfo = new DataTable();
            DataTable dt = bllClinicTabReport.getInfo(ids,flag);
            dtInfo.Columns.Add("starTime", typeof(string));
            dtInfo.Columns.Add("endTime", typeof(string));
            dtInfo.Columns.Add("billcode", typeof(string));
            dtInfo.Columns.Add("charger", typeof(string));
            dtInfo.Columns.Add("title",typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["title"] = ProgramGlobal.HspName + "支付类型日结表";
            if (flag == "duty")
            {
                row["charger"] = "收费员：" + dt.Rows[0]["settleby"].ToString();
                row["billcode"] = "结算单号：" + dt.Rows[0]["billcode"].ToString();
            }
            else if (flag == "tab")
            {
                row["charger"] = "科室：" + dt.Rows[0]["depname"].ToString();
                row["billcode"] = "";
            }

            dtInfo.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chkRptPath);
               payTypeRpt.RegisterData(dtPayType, "PayType");
                payTypeRpt.RegisterData(dtInfo, "Info");
                payTypeRpt.Preview = previewCtrl;
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
        /// 打印支付类型日结表
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="doctor"></param>
        /// <param name="patienType"></param>
        /// <returns></returns>
        public int printClinicTabPayType(string ids,string beginTime, string endTime,string flag)
        {
            string chkRptPath = GlobalParams.reportDir + "\\ClinicTabForPaytype.frx";
            DataTable dtPayType = bllClinicTabReport.getPayType(ids,beginTime, endTime,flag);
            DataTable dtInfo = new DataTable();
            DataTable dt = bllClinicTabReport.getInfo(ids,flag);
            dtInfo.Columns.Add("starTime", typeof(string));
            dtInfo.Columns.Add("endTime", typeof(string));
            dtInfo.Columns.Add("billcode", typeof(string));
            dtInfo.Columns.Add("charger", typeof(string));
            dtInfo.Columns.Add("title", typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starTime"] = beginTime;
            row["endTime"] = endTime;
            row["title"] = ProgramGlobal.HspName + "支付类型日结表";
            if (flag == "duty")
            {
                row["charger"] = "收费员：" + dt.Rows[0]["settleby"].ToString();
                row["billcode"] = "结算单号：" + dt.Rows[0]["billcode"].ToString();
            }
            else if (flag == "tab")
            {
                row["charger"] = "科室：" + dt.Rows[0]["depname"].ToString();
                row["billcode"] = "";
            }

            dtInfo.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();

            try
            {
                payTypeRpt.Load(chkRptPath);
                payTypeRpt.RegisterData(dtPayType, "PayType");
                payTypeRpt.RegisterData(dtInfo, "Info");
                print("ClinicTabForPaytype", payTypeRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 门诊储值卡发票打印
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="flag"></param>
        /// <param name="viewOrPrint"></param>
        /// <returns></returns>
        public int printMembere(string info, string beginTime, string endTime, string flag,string viewOrPrint)
        {
            //BillFrxOper billFrxOper = new BillFrxOper();
            //string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITFC.ToString()).Rows[0]["frmurl"].ToString();
            string chkRptPath = GlobalParams.reportDir + "\\" + "MemberDuty.frx";
            DataTable dt = bllClinicTabReport.memberInfo(info,beginTime, endTime, flag);
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("starttime", typeof(string));
            dtInfo.Columns.Add("endtime", typeof(string));
            dtInfo.Columns.Add("fee", typeof(string));
            DataRow row = dtInfo.NewRow();
            row["starttime"] = beginTime;
            row["endtime"] = endTime;
            double reAmount = 0;
            double enAmount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["opertype"].ToString() == "充值")
                {
                    reAmount += double.Parse(dt.Rows[i]["amount"].ToString());
                }
                else if (dt.Rows[i]["opertype"].ToString() == "取现")
                {
                    enAmount += double.Parse(dt.Rows[i]["amount"].ToString());
                }
            }
            row["fee"] = (reAmount - enAmount).ToString();
            dtInfo.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(chkRptPath);
                payTypeRpt.RegisterData(dt, "Tb_Amount");
                payTypeRpt.RegisterData(dtInfo, "Tb_Lable");
                payTypeRpt.Preview = previewCtrl;
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

    }
}
