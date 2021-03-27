using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HISDECDRYTO;
using HospCS;
using MTREG.common;
namespace MTREG.medinsur.gysyb.bll
{
    class GysybInterface
    {
        HISDEC hisdec = new HISDEC();
        HospCS.bean hospcs = new bean();
        SysWriteLogsxml syswritelogsxml = new SysWriteLogsxml();
        public string ip = "10.169.14.117";

        /// <summary>
        /// 清除在院数据
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string DELHOSPDATA(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.DELHOSPDATA(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 五定资格认定
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string REGSPECQFY(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.REGSPECQFY(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 五定资格撤销
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string DELSPECQFY(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.DELSPECQFY(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 查询五定资格
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string QUERYSPECQFY(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.QUERYSPECQFY(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 查询五定特殊项目目录
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string QUERYSPECITEM(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.QUERYSPECITEM(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 查询特殊项目用量
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string QUERYSPECITEMQTY(string inXml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");

            String obj = hospcs.QUERYSPECITEMQTY(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }


        /// <summary>
        /// 3.1获得个人信息
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GETCLINNO(string inXml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);//返回true成功，false失败
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.GETPSNINFO(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保获得个人信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);

            return jiemi;
        }

        /// <summary>
        /// 3.11查询接口特殊门诊结算数据
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFSPECCLINBILL(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFSPECCLINBILL(GenParam1, GenParam2);
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("查询接口特殊门诊结算数据", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }


        /// <summary>
        /// 3.14查询接口特殊门诊结算明细
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFSPECCLINFEELIST(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFSPECCLINFEELIST(GenParam1, GenParam2);
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("查询接口特殊门诊结算明细", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }


        /// <summary>
        /// 3.13查询接口普通门诊结算明细
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFCLINFEELIST(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFCLINFEELIST(GenParam1, GenParam2);
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("查询接口普通门诊结算明细", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }


        /// <summary>
        /// 3.10查询接口普通门诊结算数据
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFCLINBILL(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFCLINBILL(GenParam1, GenParam2);
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("查询接口普通门诊结算数据", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }


        /// <summary>
        /// 3.22市医保入院登记  
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public String Syb_Rydj(string inXml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.HOSPREG(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保入院登记后的返回消息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.16查询入院登记
        /// </summary>
        /// <returns></returns>
        public String Cxrydj(string inXml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.QUERYINFHOSPREG(GenParam1, GenParam2);
            String jiemi = GetDecrypt(obj);
            //object obj = hospcomserer.GETPSNINFO(GenParam1, GenParam2);
            return jiemi;
        }
        /// <summary>
        /// 3.24设置结算方式
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public String Szjsfs(String inXml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.SETCALTYPE(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("市医保设置结算方式", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.25设置清算方式
        /// </summary>
        /// <param name="Inxml"></param>
        /// <returns></returns>
        public String Szqsfs(String Inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            Dictionary<String, String> dic = GetJm(Inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            string obj = hospcs.SETRECKONINGTYPE(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("市医保设置清算方式", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;

        }
        /// <summary>
        /// 3.26住院结算
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String mnZyjs(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.CALHOSP(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("住院结算信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.29住院特殊结算
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Zytsjs(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.CALHOSPSP(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("住院特殊结算信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.2获取工伤认定信息
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Hqgsrdxx(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.GETGSINFO(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("获取工伤认定信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.27出院登记
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String cydj(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.HOSPOUT(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("出院办理信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.30住院退票
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String ZyTp(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.RETBALANCE(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("住院退票信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 3.31离休退票
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String ZyLxTp(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.RETLX(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("离休退票信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.32出院登记数据回退
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Cydjht(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.RETHOSPOUT(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("出院登记数据回退信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.37上传普通门诊数据
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String SctpMzsj(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            //object obj = hospcomserer.GETPSNINFO(GenParam1, GenParam2);
            Judge_Visitor.update();
            return "";
        }
        /// <summary>
        /// 3.39上传住院数据
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Sczysj(String inxml)
        {
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.UPLOADHOSP(hisdec.GenParam1("").ToString());
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj);
            syswritelogsxml.writeLogs("住院上传信息", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        ///3.19普通门诊挂号
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Ptmzgh(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.GETCLINNO(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("普通门诊挂号", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        ///3.20普通门诊结算
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Ptmzjs(String inxml)
        {

            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);

            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.CALCLIN(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("普通门诊结算", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        ///3.21特殊门诊结算
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Tsmzjs(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);

            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);

            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            String obj = hospcs.CALSPECCLIN(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("特殊门诊结算", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        ///3.30普通门诊退票
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Ptmztp(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.RETBALANCE(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("普通门诊退票", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        ///3.31离休门诊退票
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String Lxmztp(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.RETLX(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("普通门诊退票", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.33中心下载医保药品诊疗服务目录
        /// </summary>
        /// <returns></returns>
        public String GETSERVICE()
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            string obj = hospcs.GETSERVICE(hisdec.GenParam1("").ToString());
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("中心下载医保药品诊疗服务目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.34中心下载特殊病种目录
        /// </summary>
        /// <returns></returns>
        public String GETSPECILLNESS()
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            string obj = hospcs.GETSPECILLNESS(hisdec.GenParam1("").ToString());
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("中心下载特殊病种目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.36中心下载医院单病种清算数据
        /// </summary>
        /// <returns></returns>
        public String GETHOSPSINGLEILLNESS_BG()
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            string obj = hospcs.GETHOSPSINGLEILLNESS_BG(hisdec.GenParam1("").ToString());
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("中心下载医院单病种清算数据", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return "";
        }
        /// <summary>
        /// 3.4查询医保药品诊疗服务目录
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String QUERYSERVICE(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYSERVICE(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询医保药品诊疗服务目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.5查询特殊病种目录
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String QUERYSPECILLNESS(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYSPECILLNESS(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询特殊病种目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.6查询医院住院单病种包干结算目录
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String QUERYHOSPSINGLEILLNESS(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYHOSPSINGLEILLNESS(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询医院住院单病种包干结算目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.7查询医院单病种包干结算目录
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String QUERYHOSPSINGLEILLNESS_BG(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYHOSPSINGLEILLNESS_BG(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询特殊病种目录", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }
        /// <summary>
        /// 3.12查询接口住院结算数据
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFHOSPBILL(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFHOSPBILL(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询接口住院结算数据", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }

        /// <summary>
        /// 3.15查询医院住院结算费用明细
        /// </summary>
        /// <param name="inxml"></param>
        /// <returns></returns>
        public String GetQUERYINFHOSPFEELIST(String inxml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inxml);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            String obj = hospcs.QUERYINFHOSPFEELIST(GenParam1, GenParam2);
            Judge_Visitor.update();
            String jiemi = GetDecrypt(obj.ToString());
            syswritelogsxml.writeLogs("查询医院住院结算费用明细", Convert.ToDateTime(BillSysBase.currDate()), jiemi);
            return jiemi;
        }




        /// <summary>
        /// 加密函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Dictionary<String, String> GetJm(String str)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("GenParam1", hisdec.GenParam1(str).ToString());
            dic.Add("GenParam2", hisdec.GenParam2(str).ToString());
            return dic;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public String GetDecrypt(String str)
        {
            String Strret = hisdec.Decrypto(str).ToString();
            return Strret;
        }

    }
}
