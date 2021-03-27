using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.ynsyb.bo;
using MTHIS.common;
using MTREG.common;

namespace MTREG.medinsur.ynsyb.bll
{
    class YNSYB
    {
        /*/
        [DllImport("HisInterface.dll")]
        public static extern int CONNECT2TARGET(string InputData, StringBuilder OutputDate);

        [DllImport("HisInterface.dll")]
        public static extern int DISCONNECT4TARGET(string InputData, StringBuilder OutputDate);
        [DllImport("HisInterface.dll", EntryPoint = "GetEmpInfo")]
        public static extern int GetEmpInfo(string InputData, StringBuilder OutputDate);
        [DllImport("HisInterface.dll")]
        public static extern int BUSINESS_HANDLE(string InputData, StringBuilder OutputDate);
        [DllImport("HisInterface.dll")]
        public static extern int CARD_OPERATE(string InputData, StringBuilder OutputDate);


        /*/

        //*
        public int CONNECT2TARGET(string InputData, StringBuilder OutputDate)
        {
            return 0;
        }
        public int DISCONNECT4TARGET(string InputData, StringBuilder OutputDate)
        {
            return 0;
        }
        public int GetEmpInfo(string InputData, StringBuilder OutputDate)
        {
            //inputData = "卡证标志|个人编号|证号";
            //string scsj = "姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型";
            string scsj = "杨运|女|532524196603091863|1966-03-09|01|退休工人|云南秀山一中|001|02|03|0|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值|19660201||1987.29|0|封锁";
            OutputDate.Append(scsj);
            return 0;
        }
        public int BUSINESS_HANDLE(string InputData, StringBuilder OutputDate)
        {
            string[] s = InputData.Split('|');
            string jylbdm = s[0];
            if ("01".Equals(jylbdm))
            {
                string scsj = "DJ" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|1|500";
                OutputDate.Append(scsj);
            }

            if ("02".Equals(jylbdm))
            {
                string scsj = "审批结果类别|审批编号";
                OutputDate.Append(scsj);
            }

            if ("03".Equals(jylbdm))
            {
                string scsj = "1|S2016|X1101|M中国|S2017|X1102|M美国|S2018|X1103|M英国|S2019|X1104|M德国";
                OutputDate.Append(scsj);
            }

            if ("06".Equals(jylbdm))
            {
                string scsj = "CF" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|" + s[10] + "|2||4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2|4.4|2审批号";
                OutputDate.Append(scsj);
            }

            if ("07".Equals(jylbdm))
            {
                string scsj = s[5]+"|D甲";
                OutputDate.Append(scsj);
            }

            if ("08".Equals(jylbdm))
            {
                string scsj = "TF" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|4.4|20|4.4|2|4.4|2|4.4|2|0";
                OutputDate.Append(scsj);
            }
            //if ("09".Equals(jylbdm))
            //{
            //    string scsj = "YJS" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余|结算时间|包干标准|包干结余";
            //    OutputDate.Append(scsj);
            //}

            //if ("10".Equals(jylbdm))
            //{
            //    string scsj = "JS" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起付线|住院次数|起付线剩余|结算时间|包干标准|包干结余";
            //    OutputDate.Append(scsj);
            //}

            //if ("11".Equals(jylbdm))
            //{
            //    string scsj = "ZH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|-4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余";
            //    OutputDate.Append(scsj);
            //}
            if ("09".Equals(jylbdm))
            {
                string scsj = "YJS" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|1700.91|300|700.91|700|0|0|0|0|300|1|0|2017-01-12|0|0|13.9|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余|结算时间|包干标准|包干结余";
                //string scsj = "YJS" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|3.47|0|4.4|0|0|0|0|0|300|1|0|2017-01-12|0|0|13.9|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余|结算时间|包干标准|包干结余";
                OutputDate.Append(scsj);
            }

            if ("10".Equals(jylbdm))
            {
                string scsj = "JS" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|1700.91|300|700.91|700|0|0|0|0|300|1|0|2017-01-12|0|0|13.9|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起付线|住院次数|起付线剩余|结算时间|包干标准|包干结余";
                OutputDate.Append(scsj);
            }

            if ("11".Equals(jylbdm))
            {
                string scsj = "ZH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|-4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|4.4|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余";
                OutputDate.Append(scsj);
            }

            if ("15".Equals(jylbdm))
            {
                string scsj = "行政职务代码";
                OutputDate.Append(scsj);
            }

            return 0;
        }
        public int CARD_OPERATE(string InputData, StringBuilder OutputDate)
        {
            return 0;
        }
       //*/


        /// <summary>
        /// 2.1.1 CONNECT2TARGET
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int connect2target(Connect2target_out out1)
        {


            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = CONNECT2TARGET("", OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]";
                return ret;
            }

            return ret;
        }








        /// <summary>
        /// 2.1.2 DISCONNECT4TARGET
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int disconnect4target(Disconnect4target_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = DISCONNECT4TARGET("", OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]";
                return ret;
            }

            return ret;
        }





        /// <summary>
        /// 2.1.3 GetEmpInfo
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int getEmpInfo(GetEmpInfo_in in1, GetEmpInfo_out out1)
        {
            //交易特定输入数据(卡证标志|个人编号|证号)
            string InputData = in1.Kzbz + "|" + in1.Grbh + "|" + in1.Zh;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = GetEmpInfo(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }


            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Xm = scdata[0].ToString();//姓名
            out1.Xb = scdata[1].ToString();//性别
            out1.Sfzh = scdata[2].ToString();//身份证号
            out1.Csrq = scdata[3].ToString();//出身日期
            out1.Rylbbm = scdata[4].ToString();//人员类别编码
            out1.Rylbmc = scdata[5].ToString();//人员类别名称
            out1.Dwmc = scdata[6].ToString();//单位名称
            out1.Dwbh = scdata[7].ToString();//单位编号
            out1.Tcqh = scdata[8].ToString();//统筹区号
            out1.Qybh = scdata[9].ToString();//区域编号
            out1.Zgjmbz = scdata[10].ToString();//职工居民标志
            out1.Ybcsmc1 = scdata[11].ToString();//医保参数1名称
            out1.Ybcsz1 = scdata[12].ToString();//医保参数1值
            out1.Ybcsmc2 = scdata[13].ToString();//医保参数2名称
            out1.Ybcsz2 = scdata[14].ToString();//医保参数2值
            out1.Ybcsmc3 = scdata[15].ToString();//医保参数3名称
            out1.Ybcsz3 = scdata[16].ToString();//医保参数3值
            out1.Ybcsmc4 = scdata[17].ToString();//医保参数4名称
            out1.Ybcsz4 = scdata[18].ToString();//医保参数4值
            out1.Ybcsmc5 = scdata[19].ToString();//医保参数5名称
            out1.Ybcsz5 = scdata[20].ToString();//医保参数5值
            out1.Ybcsmc6 = scdata[21].ToString();//医保参数6名称
            out1.Ybcsz6 = scdata[22].ToString();//医保参数6值
            out1.Grbh = scdata[23].ToString();//个人编号
            out1.Kh = scdata[24].ToString();//卡号（无卡人员为空）
            out1.Zhye = scdata[25].ToString();//账户余额
            out1.Fsbz = scdata[26].ToString();//封锁标志
            out1.Fslx = scdata[27].ToString();//封锁类型

            return ret;
        }




        /// <summary>
        /// 2.1.5 CARD_OPERATE
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int card_operate(Card_operate_in in1)
        {
            //交易特定输入数据(操作类别)
            string InputData = in1.Czlb;
            //string InputData = "1";

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = CARD_OPERATE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }





        /// <summary>
        /// 2.2.2.1 登记
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int dj(Dj_in in1, Dj_out out1)
        {

            //交易类别代码|交易特定输入数据(个人编号|定点编号|住院号|医疗类别|入院日期|经办人|相关审批编号)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Zyh + "|" + in1.Yllb + "|" + in1.Ryrq + "|" + in1.Jbr + "|" + in1.Xgspbh;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（登记ID）
            out1.Zycs = scdata[1].ToString();//住院次数
            out1.Qfx = scdata[2].ToString();//起付线

            return ret;
        }





        /// <summary>
        /// 2.2.2.2 项目审批结果查询
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int xmspjgcx(Xmspjgcx_in in1, Xmspjgcx_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|项目编号|开方时间)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Xmbh + "|" + in1.Kfsj;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Spjglb = scdata[0].ToString();//审批结果类别
            out1.Spbh = scdata[1].ToString();//审批编号

            return ret;
        }





        /// <summary>
        /// 2.2.2.3 获得通过审批信息
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int hdtgspxx(Hdtgspxx_in in1, Hdtgspxx_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|审批类别的编码)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Splbdbm;
            //string InputData = "03|" + in1.Grbh + "|" + in1.Ddbh + "|03";

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            out1.Spxx = data + "|X";//审批信息
            return ret;
        }





        ///// <summary>
        ///// 2.2.2.4 更新医保参数信息
        ///// </summary>
        ///// <param name="in1"></param>
        ///// <param name="out1"></param>
        ///// <returns></returns>
        //public int gxybcsxx(Gxybcsxx_in in1)
        //{
        //    //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）)
        //    string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh;

        //    StringBuilder OutputDate = new StringBuilder(2048);
        //    //调用动态库
        //    int ret = BUSINESS_HANDLE(InputData, OutputDate);
        //    //分解协议
        //    string data = OutputDate.ToString();

        //    if (ret != 0)
        //    {
        //        in1.ErrorMessage = "[" + data + "]"; ;
        //        return ret;
        //    }

        //    return ret;
        //}

        /// <summary>
        /// 2.2.2.4 多诊断上传
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int dzdsc(Dzdsc_in in1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）|操作员|多诊断信息)
            string InputData = "04|" + in1.Grbh + "|" + ProgramGlobal.InsurHspCode + "|" + in1.Jylsh + "|" + ProgramGlobal.Username + "|" + in1.Dzdxx;
            InputData = InputData.Remove(InputData.Length - 1);
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }


        /// <summary>
        /// 2.2.2.5 更新就诊信息
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int gxjzxx(Gxjzxx_in in1)
        {

            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）|更新标志|医疗类别|科室|医保卡号|入院日期|出院日期|确诊疾病编码|入院疾病名称|出院疾病名称|经办人|出院原因)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Gxbz + "|" + in1.Yllb + in1.Ks + in1.Ybkh + in1.Ryrq + in1.Cyrq + in1.Qzjbbm + in1.Ryjbmc + in1.Cyjbmc + in1.Jbr + in1.Cyyy;
            InputData = InputData.Remove(InputData.Length - 1);
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }




        /// <summary>
        /// 2.2.2.6 处方明细录入
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int cfmxlr(Cfmxlr_in in1, Cfmxlr_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）|处方号|处方内序号|医院内码|医保编码|项目名称|费用类别|单价|数量|金额|单位|规格|剂型|开方日期|开方科室|开方医生|相关审批编号)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Cfh + "|" + in1.Cfnxh + "|" + in1.Yynm + "|" + in1.Ybbm + "|" + in1.Xmmc + "|" + in1.Fylb + "|" + in1.Dj + "|" + in1.Sl + "|" + in1.Je + "|" + in1.Dw + "|" + in1.Gg + "|" + in1.Jx + "|" + in1.Kfrq + "|" + in1.Kfks + "|" + in1.Kfys + "|" + in1.Xgspbh + "|" + in1.Ysbm;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString() + "|";

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]";
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（处方ID）
            out1.Sjdj = scdata[1].ToString();//实际单价
            string _xmdj = scdata[2].ToString();//项目等级 
            if (_xmdj.Equals("1"))
            {
                out1.Xmdj = "甲类";
            }
            else if (_xmdj.Equals("2"))
            {
                out1.Xmdj = "乙类";
            }
            else if (_xmdj.Equals("3"))
            {
                out1.Xmdj = "自费";
            }
            else if (_xmdj.Equals("4"))
            {
                out1.Xmdj = "特检特治";
            }

            //out1.Xmdj = scdata[2].ToString();//项目等级
            out1.Sph = scdata[3].ToString();//审批号
            out1.Zlfy = scdata[4].ToString();//自理费用
            out1.Zffy = scdata[5].ToString();//自费费用
            out1.Cfje = scdata[6].ToString();//处方金额
            out1.Znshydxx = scdata[7].ToString();//智能审核疑点信息

            return ret;
        }




        /// <summary>
        /// 2.2.2.7 确定明细项目单价
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int qdmxxmdj(Qdmxxmdj_in in1, Qdmxxmdj_out out1)
        {

            //交易类别代码|交易特定输入数据(个人编号|定点编号|医保编号|费用类别|医院单价)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Ybbh + "|" + in1.Fylb + "|" + in1.Yydj;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Kydj = scdata[0].ToString();//可用单价
            out1.Xmdj = scdata[1].ToString();//项目等级

            return ret;
        }




        /// <summary>
        /// 2.2.2.8 处方明细退方
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int cfmxtf(Cfmxtf_in in1, Cfmxtf_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（处方ID）|退除数量|退除金额)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Tcsl + "|" + in1.Tcje;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（处方ID）
            out1.Xmbm = scdata[1].ToString();//项目编码
            out1.Sysl = scdata[2].ToString();//剩余数量
            out1.Syje = scdata[3].ToString();//剩余金额
            out1.Syzl = scdata[4].ToString();//剩余自理
            out1.Syzf = scdata[5].ToString();//剩余自费

            return ret;
        }




        /// <summary>
        /// 2.2.2.9 预结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int yjs(Yjs_in in1, Yjs_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）|处方截止时间|卡支付金额｜起付线支付金额)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Cfjzsj + "|" + in1.Kzfje + "|" + in1.Qfxzfje;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString() + "|";

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            //0| 总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余|结算时间|包干标准|包干结余
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（结算ID）
            out1.Zfy = scdata[1].ToString();//总费用
            out1.Tc = scdata[2].ToString();//统筹
            out1.Zh = scdata[3].ToString();//账户
            out1.Xj = scdata[4].ToString();//现金
            out1.Dblp = scdata[5].ToString();//大病理赔
            out1.Zgrybz = scdata[6].ToString();//照顾人员补助
            out1.Gwybz = scdata[7].ToString();//公务员补助
            out1.Jfqgzrybz = scdata[8].ToString();//解放前工作人员补助
            out1.Qfx = scdata[9].ToString();//起付线
            out1.Zycs = scdata[10].ToString();//住院次数
            out1.Qfxsy = scdata[11].ToString();//起付线剩余
            out1.Jssj = scdata[12].ToString();//结算时间
            out1.Bgbz = scdata[13].ToString();//包干标准
            out1.Bgjy = scdata[14].ToString();//包干结余
            out1.Qzfje = scdata[15].ToString();//全自费金额
            out1.Znshydxx = scdata[16].ToString();//智能审核疑点信息

            return ret;
        }




        /// <summary>
        /// 2.2.2.10 结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int js(Js_in in1, Js_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）|处方截止时间(中途结算适用)|发票号|结算类型|经办人｜卡支付金额｜起付线支付金额)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Cfjzsj + "|" + in1.Fph + "|" + in1.Jslx + "|" + in1.Jbr + "|" + in1.Kzfje + "|" + in1.Qfxzfje;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString() + "|";

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（结算ID）
            out1.Zfy = scdata[1].ToString();//总费用
            out1.Tc = scdata[2].ToString();//统筹
            out1.Zh = scdata[3].ToString();//账户
            out1.Xj = scdata[4].ToString();//现金
            out1.Dblp = scdata[5].ToString();//大病理赔
            out1.Zgrybz = scdata[6].ToString();//照顾人员补助
            out1.Gwybz = scdata[7].ToString();//公务员补助
            out1.Jfqgzrybz = scdata[8].ToString();//解放前工作人员补助
            out1.Qfx = scdata[9].ToString();//起付线
            out1.Zycs = scdata[10].ToString();//住院次数
            out1.Qfxsy = scdata[11].ToString();//起付线剩余
            out1.Jssj = scdata[12].ToString();//结算时间
            out1.Bgbz = scdata[13].ToString();//包干标准
            out1.Bgjy = scdata[14].ToString();//包干结余
            out1.Qzfje = scdata[15].ToString();//全自费金额
            out1.Znshydxx = scdata[16].ToString();//智能审核疑点信息

            return ret;
        }




        /// <summary>
        /// 2.2.2.11 结算召回
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int jszh(Jszh_in in1, Jszh_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（结算ID）|发票号|经办人)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh + "|" + in1.Fph + "|" + in1.Jbr;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            //交易流水号（结算召回ID）|总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起伏线|住院次数|起付线剩余
            string[] scdata = data.Split('|');
            out1.Jylsh = scdata[0].ToString();//交易流水号（结算召回ID）
            out1.Zfy = scdata[1].ToString();//总费用
            out1.Tc = scdata[2].ToString();//统筹
            out1.Zh = scdata[3].ToString();//账户
            out1.Xj = scdata[4].ToString();//现金
            out1.Dblp = scdata[5].ToString();//大病理赔
            out1.Zgrybz = scdata[6].ToString();//照顾人员补助
            out1.Gwybz = scdata[7].ToString();//公务员补助
            out1.Jfqgzrybz = scdata[8].ToString();//解放前工作人员补助
            out1.Qfx = scdata[9].ToString();//起付线
            out1.Zycs = scdata[10].ToString();//住院次数
            out1.Qfxsy = scdata[11].ToString();//起付线剩余

            return ret;
        }




        /// <summary>
        /// 2.2.2.12 无费退院
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int wfty(Wfty_in in1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|交易流水号（登记ID）)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Jylsh;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }




        /// <summary>
        /// 2.2.2.13 获取行政职务
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int hqxzzw(Hqxzzw_in in1, Hqxzzw_out out1)
        {
            //交易类别代码|交易特定输入数据(个人编号|定点编号|要查询的信息编码|附加信息|)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Ddbh + "|" + in1.Ycxdxxbm + "|" + in1.Fjxx;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            //封住返回数据
            string[] scdata = data.Split('|');
            out1.Xzzwdm = scdata[0].ToString();//行政职务代码

            return ret;
        }




        /// <summary>
        /// 2.2.2.14 未结算处方清除交易
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int wjscfqcjy(Wjscfqcjy_in in1)
        {
            //交易类别代码|交易特定输入数据(个人编号|医院编码|交易流水号（登记ID）)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Yybm + "|" + in1.Jylsh;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }




        /// <summary>
        /// 2.2.2.15 冲正交易
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int czjy(Czjy_in in1)
        {
            //交易类别代码|交易特定输入数据(个人编号|被冲正交易流水号|被冲正交易类型代码|操作员)
            string InputData = in1.Jylbdm + "|" + in1.Grbh + "|" + in1.Bczjylsh + "|" + in1.Bczjylxdm + "|" + in1.Czy;

            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BUSINESS_HANDLE(InputData, OutputDate);
            //分解协议
            string data = OutputDate.ToString();

            if (ret != 0)
            {
                in1.ErrorMessage = "[" + data + "]"; ;
                return ret;
            }

            return ret;
        }
    }
}
