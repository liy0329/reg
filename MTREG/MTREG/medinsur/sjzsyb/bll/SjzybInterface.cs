using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;
using System.Data;
using System.IO;
using MTREG.common.bll;
using System.Xml;


namespace MTREG.medinsur.sjzsyb.bll
{
    class SjzybInterface
    {

        #region //交易函数
        [DllImport(@".\SJZ_dll\SHJZhisinterface.dll")]
        public static extern int hisinterface(string inputDate, StringBuilder outputData);


        #endregion
        /// <summary>
        /// 【1633】三目对照关系申报
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public void ceshi(string in1, ref SJZYB_OUT out1)
        {
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(in1, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
        }

        /// 医保签到
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int Signin(SJZYB_IN<DBNull> in1, ref Signin_Out out1)
        {
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());



            string[] log = new string[6];
            log[0] = (in1.AKC190 != null) ? in1.AKC190 : in1.OPERNAME;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret == 1)
            {
                List<Signin_Out> list = objk<Signin_Out>.FillModel(dt1);
                out1 = list[0];
            }

            return ret;
        }
        /// 医保签退
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int Signback(SJZYB_IN<DBNull> in1, ref SJZYB_OUT out1)
        {
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);



            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());



            string[] log = new string[6];
            log[0] = (in1.AKC190 != null) ? in1.AKC190 : in1.OPERNAME;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }

        /// <summary>
        /// 住院费用上传
        /// </summary>
        /// <param name="sjzyb_in"></param>
        /// <returns></returns>
        public int zyfysc(SJZYB_IN<DBNull> in1, SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(5120);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();



            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            string[] log = new string[6];
            log[0] = (in1.AKC190 != null) ? in1.AKC190 : in1.OPERNAME;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);


            return ret;
        }
        /// <summary>
        /// 【1130】按套限价项目使用情况上传
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyfysc_at(SJZYB_IN<ATSC> in1, string zyh, SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<ATSC>.getXML(in1, "INROW");
            StringBuilder outputData = new StringBuilder(5120);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            SJZYB_OUT sjzyb_out = new SJZYB_OUT();
            DataTable dt = ds.Tables["RESPONSEDATA"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            if (ret != 0)
            {
                //写日志文件 
                SysWriteLogs sysWriteLog = new SysWriteLogs();
                string outLog = "上传费用，住院号：" + zyh + "入参：" + inputData + ",出参：" + Date;
                sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);

                return ret;
            }
            SysWriteLogs sysWriteLog2 = new SysWriteLogs();
            string outLog2 = "上传费用，住院号：" + zyh + "入参：" + inputData + ",出参：" + Date;
            sysWriteLog2.writeLogs(zyh, DateTime.Now, outLog2);


            return ret;
        }
        /// <summary>
        /// 【1401】获取人员信息 
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int DK(SJZYB_IN<DK_IN> in1, ref DK_OUT out1)
        {
            //序列化
            string inputData = objk<DK_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();


            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            if (ret != -1)
            {
                List<DK_OUT> list = objk<DK_OUT>.FillModel(dt1);
                out1 = list[0];
            }
            //string[] log = new string[6];
            //log[0] = out1.AKC020;
            //log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            //log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            //log[3] = "		      【入参】" + inputData;
            //log[4] = "		      【出参】" + Date;
            //log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            //SysWriteLogs.writeLogs_yb(log);


            return ret;
        }
        /// <summary>
        /// 【2110】修改卡密码
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int modify(SJZYB_IN<DBNull> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【2131】激活 UKey
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int activation(SJZYB_IN<DBNull> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【2130】设置门诊定点
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int clinicPoint(SJZYB_IN<clinicPoint_In> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<clinicPoint_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【2132】社保卡启用
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int Enable(SJZYB_IN<DBNull> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【1101】住院登记
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zydj(SJZYB_IN<DBNull> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【 1102住院登记信息修改
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zymodify(SJZYB_IN<modify_In> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<modify_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【1201】无费退院
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyht(SJZYB_IN<ReHospital_In> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<ReHospital_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【 1104】住院费用预结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyyjs(SJZYB_IN<zyyjs_IN> in1, ref zyjs_OUT out1)
        {

            //序列化
            string inputData = objk<zyyjs_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();


            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjs_OUT> list = objk<zyjs_OUT>.FillModel(dt1);
                out1 = list[0];
            }

            return ret;

        }
        /// <summary>
        /// 【1105】住院费用结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyjs(SJZYB_IN<zyjs_IN> in1, ref zyjs_OUT out1)
        {
            //序列化
            string inputData = objk<zyjs_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];



            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjs_OUT> list = objk<zyjs_OUT>.FillModel(dt1);
                out1 = list[0];
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 住院结算召回
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyjszh(SJZYB_IN<zyjszh_IN> in1, ref zyjszh_OUT out1)
        {
            //序列化
            string inputData = objk<zyjszh_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];


            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjszh_OUT> list = objk<zyjszh_OUT>.FillModel(dt1);
                out1 = list[0];
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            return ret;
        }
        /// <summary>
        /// 【1202】门诊结算回退
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int mzjszh(SJZYB_IN<zyjszh_IN> in1, ref zyjszh_OUT out1)
        {
            //序列化
            string inputData = objk<zyjszh_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];



            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjszh_OUT> list = objk<zyjszh_OUT>.FillModel(dt1);
                out1 = list[0];
            }

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【1106】住院费用明细删除
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int zyfy_delete(SJZYB_IN<zyfysc_IN> in1, SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<zyfysc_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            SJZYB_OUT sjzyb_out = new SJZYB_OUT();
            DataTable dt = ds.Tables["RESPONSEDATA"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 对账
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int dz(SJZYB_IN<DZ_IN> in1, DZ_OUT out1)
        {
            //序列化
            string inputData = objk<DZ_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder();
            int ret = 0;//hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            SJZYB_OUT sjzyb_out = new SJZYB_OUT();

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            if (ret != 0)
            {
                //写日志文件 
                SysWriteLogs sysWriteLog = new SysWriteLogs();
                string outLog = "上传费用，住院号：" + "入参：" + inputData + ",出参：" + Date;
                sysWriteLog.writeLogs("", DateTime.Now, outLog);

                return ret;
            }
            SysWriteLogs sysWriteLog2 = new SysWriteLogs();
            string outLog2 = "上传费用，住院号：" + "入参：" + inputData + ",出参：" + Date;
            sysWriteLog2.writeLogs("", DateTime.Now, outLog2);

            List<DZ_OUT> list = objk<DZ_OUT>.FillModel(dt1);
            out1 = list[0];

            return ret;
        }
        /// <summary>
        /// 对账明细
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int dz_mx(SJZYB_IN<DZmx_IN> in1, DZmx_OUT out1)
        {
            //序列化
            string inputData = objk<DZmx_IN>.getXML(in1, "INROW");
            StringBuilder outputData = new StringBuilder();
            int ret = 0;//hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            SJZYB_OUT sjzyb_out = new SJZYB_OUT();

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            if (ret != 0)
            {
                //写日志文件 
                SysWriteLogs sysWriteLog = new SysWriteLogs();
                string outLog = "上传费用，住院号：" + "入参：" + inputData + ",出参：" + Date;
                sysWriteLog.writeLogs("", DateTime.Now, outLog);

                return ret;
            }
            SysWriteLogs sysWriteLog2 = new SysWriteLogs();
            string outLog2 = "上传费用，住院号：" + "入参：" + inputData + ",出参：" + Date;
            sysWriteLog2.writeLogs("", DateTime.Now, outLog2);

            List<Dzlist> list = objk<Dzlist>.FillModel(dt1);
            out1.list = list;

            return ret;
        }
        /// <summary>
        /// 门诊预结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int mzyjs(SJZYB_IN<Mzyjs_IN> in1, ref  zyjs_OUT out1)
        {
            //序列化
            string inputData = objk<Mzyjs_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(300000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjs_OUT> list = objk<zyjs_OUT>.FillModel(dt1);
                out1 = list[0];
            }

            return ret;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int mzjs(SJZYB_IN<mzjs_IN> in1, ref  zyjs_OUT out1)
        {
            //序列化
            string inputData = objk<mzjs_IN>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(300000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            if (ret != -1)
            {
                List<zyjs_OUT> list = objk<zyjs_OUT>.FillModel(dt1);
                out1 = list[0];
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【1631】医师下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadDoctor(SJZYB_IN<Doctor_In> in1, ref Doctor_Out out1)
        {
            string inputData = objk<Doctor_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {
                out1.OUTROW = new List<Doctor_Out_OUTROW>();
                List<Doctor_Out_OUTROW> list = objk<Doctor_Out_OUTROW>.FillModel(dt3);
                out1.OUTROW.AddRange(list);
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();

            string[] log = new string[6];
            log[0] = "医师下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1635】病种目录下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadDisease(SJZYB_IN<Disease_In> in1, ref Disease_Out out1)
        {
            string inputData = objk<Disease_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {
                if (out1.OUTROW == null)
                {
                    out1.OUTROW = new List<Diseaser_Out_OUTROW>();
                }
                List<Diseaser_Out_OUTROW> list = objk<Diseaser_Out_OUTROW>.FillModel(dt3);
                out1.OUTROW.AddRange(list);
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            if (dt1 != null)
                out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();

            string[] log = new string[6];
            log[0] = "病种目录下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1636】 费用明细下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadCostdet(SJZYB_IN<DownloadCostdet_In> in1, ref DownloadCostdet_Out out1)
        {
            string inputData = objk<DownloadCostdet_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {
                if (out1.OUTROW == null)
                {
                    out1.OUTROW = new List<DownloadCostdet_Out_OUTROW>();
                }
                List<DownloadCostdet_Out_OUTROW> list = objk<DownloadCostdet_Out_OUTROW>.FillModel(dt3);
                out1.OUTROW.AddRange(list);
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            if (dt1 != null)
                out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();

            return ret;
        }
        /// <summary>
        /// 【 1731】 查询住院费用结算清单
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadSett(SJZYB_IN<ybSettRpt_In> in1, ref ybSettRpt_Out out1)
        {
            string inputData = objk<ybSettRpt_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTPUT"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {

                List<ybSettRpt_Out> list = objk<ybSettRpt_Out>.FillModel(dt3);
                out1 = list[0];
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【 1732】 城乡费用结算清单
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadstatementsJM(SJZYB_IN<statementsJM_In> in1, ref statementsJM_Out out1)
        {
            string inputData = objk<statementsJM_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTPUT"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {

                List<statementsJM_Out> list = objk<statementsJM_Out>.FillModel(dt3);
                out1 = list[0];
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【1632】三目下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadDirectory(SJZYB_IN<Directory_In> in1, ref Directory_Out_yp out1, ref Directory_Out_zl out2, ref Directory_Out_fw out3)
        {
            string inputData = objk<Directory_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];

            if (ret == 1)
            {
                if (in1.INPUT[0].AKC224 == "1")
                {
                    if (out1.OUTROW == null)
                    {
                        out1.OUTROW = new List<Directory_Out_yp_OUTROW>();
                    }
                    List<Directory_Out_yp_OUTROW> list = objk<Directory_Out_yp_OUTROW>.FillModel(dt3);
                    out1.OUTROW.AddRange(list);
                    out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
                else if (in1.INPUT[0].AKC224 == "2")
                {
                    if (out2.OUTROW == null)
                    {
                        out2.OUTROW = new List<Directory_Out_zl_OUTROW>();
                    }
                    List<Directory_Out_zl_OUTROW> list = objk<Directory_Out_zl_OUTROW>.FillModel(dt3);
                    out2.OUTROW.AddRange(list);
                    out2.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
                else if (in1.INPUT[0].AKC224 == "3")
                {
                    if (out3.OUTROW == null)
                    {
                        out3.OUTROW = new List<Directory_Out_fw_OUTROW>();
                    }
                    List<Directory_Out_fw_OUTROW> list = objk<Directory_Out_fw_OUTROW>.FillModel(dt3);
                    out3.OUTROW.AddRange(list);
                    out3.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            string[] log = new string[6];
            log[0] = "三目目录下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1630】科室下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadDepart(SJZYB_IN<DBNull> in1, ref List<Depart_Out> out1)
        {
            string inputData = objk<DBNull>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {

                List<Depart_Out> list = objk<Depart_Out>.FillModel(dt3);
                out1.AddRange(list);
            }
            out1[0].ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1[0].REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1[0].RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            string[] log = new string[6];
            log[0] = "科室下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1730】个人门诊费用明细查询
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int Detailedquery(SJZYB_IN<Detailedquery_In> in1, ref List<Detailedquery_Out> out1)
        {
            string inputData = objk<Detailedquery_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1)
            {
                List<Detailedquery_Out> list = objk<Detailedquery_Out>.FillModel(dt3);
                out1.AddRange(list);
            }
            out1[0].ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1[0].REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1[0].RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            return ret;
        }
        /// <summary>
        /// 【1633】三目对照关系申报
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int declare_yp(SJZYB_IN<declare_yp_In> in1, ref SJZYB_OUT out1)
        {
            string inputData = objk<declare_yp_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);



            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());



            string[] log = new string[6];
            log[0] = "药品对照";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1633】三目对照关系申报
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int declare_zl(SJZYB_IN<declare_zl_In> in1, ref SJZYB_OUT out1)
        {
            string inputData = objk<declare_zl_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);



            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = "治疗对照";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);


            return ret;
        }
        /// <summary>
        /// 【1633】三目对照关系申报
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int declare_fw(SJZYB_IN<declare_fw_In> in1, ref SJZYB_OUT out1)
        {
            string inputData = objk<declare_fw_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = "服务对照";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【1634】三目对照关系下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int Downdeclare_yp(SJZYB_IN<DownloadContrast_In> in1, ref DownloadContrast_Out_yp out1, ref DownloadContrast_Out_zl out2, ref DownloadContrast_Out_fw out3)
        {
            string inputData = objk<DownloadContrast_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(300000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];


            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());


            if (ret == 1)
            {
                if (in1.INPUT[0].AKC224 == "1")
                {
                    if (out1.OUTROW == null)
                    {
                        out1.OUTROW = new List<DownloadContrast_Out_yp_OUTROW>();
                    }
                    List<DownloadContrast_Out_yp_OUTROW> list = objk<DownloadContrast_Out_yp_OUTROW>.FillModel(dt3);
                    out1.OUTROW.AddRange(list);
                    out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
                else if (in1.INPUT[0].AKC224 == "2")
                {
                    if (out2.OUTROW == null)
                    {
                        out2.OUTROW = new List<DownloadContrast_Out_zl_OUTROW>();
                    }
                    List<DownloadContrast_Out_zl_OUTROW> list = objk<DownloadContrast_Out_zl_OUTROW>.FillModel(dt3);
                    out2.OUTROW.AddRange(list);
                    out2.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
                else if (in1.INPUT[0].AKC224 == "3")
                {
                    if (out3.OUTROW == null)
                    {
                        out3.OUTROW = new List<DownloadContrast_Out_fw_OUTROW>();
                    }
                    List<DownloadContrast_Out_fw_OUTROW> list = objk<DownloadContrast_Out_fw_OUTROW>.FillModel(dt3);
                    out3.OUTROW.AddRange(list);
                    out3.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
                }
            }
            string[] log = new string[6];
            log[0] = "三目对照关系下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1120】医疗费信息对账
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int ylxxdz(SJZYB_IN<Reconciliation_In> in1, ref Reconciliation_Out out1)
        {
            //序列化
            string inputData = objk<Reconciliation_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(30000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            if (ret == 1)
            {

                List<Reconciliation_Out> list = objk<Reconciliation_Out>.FillModel(dt1);
                out1 = list[0];
            }
            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【1121】医疗费信息对账（明细）
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int ylxxdz_mx(SJZYB_IN<Reconciliation_In_xm> in1, ref List<Reconciliation_Out_xm> out1)
        {
            //序列化
            string inputData = objk<Reconciliation_In_xm>.getXML(in1, "INROW");
            StringBuilder outputData = new StringBuilder(300000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];



            if (ret == 1)
            {

                List<Reconciliation_Out_xm> list = objk<Reconciliation_Out_xm>.FillModel(dt1);
                out1.AddRange(list);
            }
            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            out1[0].ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1[0].REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1[0].RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            return ret;
        }
        /// <summary>
        /// 【1637】结算信息下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int DownloadInfo(SJZYB_IN<SettlementInfo_In> in1, ref SettlementInfo_Out out1)
        {
            string inputData = objk<SettlementInfo_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];
            //DataTable dt1 = ds.Tables["OUTPUT"];

            if (ret == 1 && dt1 != null)
            {
                if (out1.OUTROW == null)
                {
                    out1.OUTROW = new List<SettlementInfo_Out_OUTROW>();
                }
                List<SettlementInfo_Out_OUTROW> list = objk<SettlementInfo_Out_OUTROW>.FillModel(dt3);
                out1.OUTROW.AddRange(list);
            }
            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            if (dt1 != null)
                out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();

            string[] log = new string[6];
            log[0] = "结算信息下载";
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
        /// <summary>
        /// 【1301】冲正交易
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int chongzheng(SJZYB_IN<Correct_In> in1, ref SJZYB_OUT out1)
        {
            //序列化
            string inputData = objk<Correct_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTPUT"];

            out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
            out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
            out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());

            string[] log = new string[6];
            log[0] = in1.AKC190;
            log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            log[3] = "		      【入参】" + inputData;
            log[4] = "		      【出参】" + Date;
            log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            SysWriteLogs.writeLogs_yb(log);



            return ret;
        }
        /// <summary>
        /// 【1910】个人慢性(或特殊)病审批信息查询
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="zyh"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int grmxbspxxcx(SJZYB_IN<grmxbspxxcx_In> in1, ref List<grmxbspxxcx_Out> out1)
        {
            //序列化
            string inputData = objk<grmxbspxxcx_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000);
            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            out1.Add(new grmxbspxxcx_Out());
            DataTable dt = ds.Tables["RESPONSEDATA"];
            DataTable dt1 = ds.Tables["OUTROW"];

            if (ret == 1 && dt1 != null)
            {
                List<grmxbspxxcx_Out> list = objk<grmxbspxxcx_Out>.FillModel(dt1);
                out1 = list;
            }
            try
            {
                out1[0].ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
                out1[0].REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
                out1[0].RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            }
            catch { }

            return ret;
        }
        /// <summary>
        /// 【1638】病种可用三目范围下载
        /// </summary>
        /// <param name="in1"></param>
        /// <returns></returns>
        public int Downloadbzkysmfwxz(SJZYB_IN<bzkysmfwxz_In> in1, ref bzkysmfwxz_Out out1)
        {
            string inputData = objk<bzkysmfwxz_In>.getXML(in1, "");
            StringBuilder outputData = new StringBuilder(3000000);

            int ret = hisinterface(inputData, outputData);
            string Date = outputData.ToString().Trim();

            StringReader sr = new StringReader(Date);
            DataSet ds = new DataSet();

            XmlTextReader reader = new XmlTextReader(sr);
            ds.ReadXml(reader);

            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];

            DataTable dt = ds.Tables["RESPONSEDATA"];

            if (ret == 1)
            {
                if (out1.OUTROW == null)
                {
                    out1.OUTROW = new List<bzkysmfwxz_Out_OUTROW>();
                }
                List<bzkysmfwxz_Out_OUTROW> list = objk<bzkysmfwxz_Out_OUTROW>.FillModel(dt3);
                out1.OUTROW.AddRange(list);
                out1.TOTALPAGE = dt1.Rows[0]["TOTALPAGE"].ToString();
            }
            try
            {
                out1.ERRORMSG = dt.Rows[0]["ERRORMSG"].ToString();
                out1.REFMSGID = dt.Rows[0]["REFMSGID"].ToString();
                out1.RETURNNUM = int.Parse(dt.Rows[0]["RETURNNUM"].ToString());
            }
            catch { }


            //string[] log = new string[6];
            //log[0] = "三目fa下载";
            //log[1] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】开始----------------------------------------------------------------------------";
            //log[2] = "		      【是否成功】" + ((ret != -1) ? "成功" : "失败") + ")";
            //log[3] = "		      【入参】" + inputData;
            //log[4] = "		      【出参】";
            //log[5] = DateTime.Now.ToString() + "==>【" + in1.MSGNO + "】结束----------------------------------------------------------------------------";
            //SysWriteLogs.writeLogs_yb(log);

            return ret;
        }
    }
}