using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.gzsyb.bo;
using System.Threading;
using MTREG.common;
using MTREG.common.bll;

namespace MTREG.medinsur.gzsyb.bll
{
    /// <summary>
    /// 基础业务类
    /// </summary>
    class GzsybInterface
    {
        private static yh_interface.CoClass_n_yh_interfacebaseClass yhInterface = null;  
        private static Init_out iniOut = null;
        private Thread thread;
        public GzsybInterface()
        {
            thread = new Thread(GzsybInterface.cshclass);
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
        }
        public static void cshclass()
        {
           
                if (yhInterface == null)
                {
                    try
                    {
                        yhInterface = new yh_interface.CoClass_n_yh_interfacebaseClass();
                    }
                    catch (Exception ex)
                    {
                        yhInterface = null;
                    }
                }
                else
                {
                    try
                    {
                        string rlt = yhInterface.ToString();
                        if (!rlt.Equals("yh_interface.CoClass_n_yh_interfacebaseClass"))
                        {
                            yhInterface = new yh_interface.CoClass_n_yh_interfacebaseClass();
                        }
                    }
                    catch (Exception ex)
                    {
                        yhInterface = new yh_interface.CoClass_n_yh_interfacebaseClass();
                    }
                }
               
         
        }
        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns></returns>
        public Init_out Init()
        {
            thread = new Thread(GzsybInterface.Init2);
            thread.IsBackground = true;
            thread.Start();
            thread.Join();

            return iniOut;
        }
        /// <summary>
        /// 初始化函数
        /// </summary>
        public static void Init2()
        {
            try
            {
                if (iniOut == null)
                {
                    iniOut = new Init_out();
                    Object AintAppcode = new object();
                    Object AstrAppmsg = new object();
                    //交易的处理流程
                    yhInterface.yh_interface_init(ref AintAppcode, ref AstrAppmsg);
                    int AintAppcode2 = (int)AintAppcode;
                    string AstrAppmsg2 = (string)AstrAppmsg;
                    iniOut.AintAppcode = AintAppcode2;
                    iniOut.AstrAppmsg = AstrAppmsg2;
                    if (iniOut.AintAppcode < 0)
                    {
                        //Tool.SysWriteLogs.writeLogs("省医保动态库连接失败日志", Convert.ToDateTime(BillSysBase.currDate()), iniOut.AstrAppmsg);
                    }
                }
            }
            catch (Exception ex)
            {
                //Tool.SysWriteLogs.writeLogs("省医保动态库连接失败日志", Convert.ToDateTime(BillSysBase.currDate()), "try-catch捕获到异常,ex:" + ex.ToString());
            }
        }
        public void Destroy()
        {
            yhInterface.yh_interface_destroy();
        }
        /// <summary>
        /// 编写日志
        /// </summary>
        /// <param name="astrJybh">方法编号</param>
        public void writeLogs(string astrJybh, string info)
        {
            string fileType = "";
            switch (astrJybh)
            {
                case "03":
                    fileType = "贵州省医保获取身份信息";
                    break;
                case "31":
                    fileType = "贵州省医保费用明细写入";
                    break;
                case "48":
                    fileType = "贵州省医保门诊结算";
                    break;
                case "42":
                    fileType = "贵州省医保结算回退";
                    break;
                case "21":
                    fileType = "贵州省医保入院登记";
                    break;
                case "22":
                    fileType = "贵州省医保入院登记回退";
                    break;
                case "33":
                    fileType = "贵州省医保批量删除明细";
                    break;
                case "25":
                    fileType = "贵州省医保出院办理";
                    break;
                case "26":
                    fileType = "贵州省医保出院办理回退";
                    break;
                case "43":
                    fileType = "贵州省医保住院预结算";
                    break;
                case "41":
                    fileType = "贵州省医保住院结算";
                    break;
            }

            SysWriteLogs.writeLogs1(fileType, Convert.ToDateTime(BillSysBase.currDate()), info);

        }
        /// <summary>
        /// 交易主函数，完成所有医疗业务的实际处理
        /// </summary>
        /// <param name="inl"></param>
        /// <returns></returns>
        public Call_out Call(Call_in inl)
        {
            Object astr_jylsh = new object();
            Object astr_jyyzm = new object();
            Object astr_jysc_xml = new object();
            Object aint_appcode = new object();
            Object astr_appmsg = new object();
            yhInterface.yh_interface_call(inl.AstrJybh,inl.Astr_jysr_xml,ref astr_jylsh,ref astr_jyyzm,ref astr_jysc_xml,ref aint_appcode,ref astr_appmsg);
            Call_out out1 = new Call_out();
            string astr_jylsh2 = astr_jylsh.ToString();
            string astr_jyyzm2 = astr_jyyzm.ToString();
            string astr_jysc_xml2 = astr_jysc_xml.ToString();
            long aint_appcode2 = (int)aint_appcode;
            string astr_appmsg2 = astr_appmsg.ToString();
            out1.Astrjylsh = astr_jylsh2;
            out1.Astrjyyzm = astr_jyyzm2;
            out1.Astrjyscxml = astr_jysc_xml2;
            out1.Aintappcode = aint_appcode2;
            out1.Astrappms = astr_appmsg2;
            writeLogs(inl.AstrJybh, inl.Astr_jysr_xml + astr_jysc_xml + astr_appmsg);
            return out1;
        }
        /// <summary>
        /// 交易辅助函数，完成交易的确认处理
        /// </summary>
        /// <returns></returns>
        public Confirm_out Confirm(Confirm_in inl)
        {
            Object aint_appcode = new object();
            Object astr_appmsg = new object();
            yhInterface.yh_interface_confirm(inl.Astrjylsh,inl.Astrjyyzm,ref aint_appcode,ref astr_appmsg);
            Confirm_out out1 = new Confirm_out();
            long aint_appcode2 = (int)aint_appcode;
            string astr_appmsg2 = (string)astr_appmsg;
            out1.AintAppcode = aint_appcode2;
            out1.AstrAppmsg = astr_appmsg2;
            return out1;
        }
        /// <summary>
        /// 交易辅助函数，完成交易的确认处理
        /// </summary>
        /// <param name="inl"></param>
        /// <returns></returns>
        public Cancel_out Cancel(Cancel_in inl)
        {
            Object aint_appcode = new object();
            Object astr_appmsg = new object();
            yhInterface.yh_interface_cancel(inl.Astrjylsh, ref aint_appcode, ref astr_appmsg);
            Cancel_out out1 = new Cancel_out();
            long aint_appcode2 = (int)aint_appcode;
            string astr_appmsg2 = (string)astr_appmsg;
            out1.AintAppcode = aint_appcode2;
            out1.AstrAppmsg = astr_appmsg2;
            return out1;
        }
        /// <summary>
        /// 交易辅助函数，完成不确定交易的查询处理。
        /// </summary>
        /// <returns></returns>
        public Getuncertaintytrade_out GetUnCertaintyTrade(Getuncertaintytrade_in inl)
        {
            Object astr_jgxml = new object();
            Object aint_appcode = new object();
            Object astr_appmsg = new object();
            yhInterface.yh_interface_getuncertaintytrade(inl.AstrJybh, ref astr_jgxml, ref aint_appcode, ref astr_appmsg);
            Getuncertaintytrade_out out1 = new Getuncertaintytrade_out();
            string astr_jgxml2 = (string)astr_jgxml;
            long aint_appcode2 = (int)aint_appcode;
            string astr_appmsg2 = (string)astr_appmsg;
            out1.Astr_jgxml = astr_jgxml2;
            out1.AintAppcode = aint_appcode2;
            out1.AstrAppmsg = astr_appmsg2;
            return out1;
        }
    }
}
