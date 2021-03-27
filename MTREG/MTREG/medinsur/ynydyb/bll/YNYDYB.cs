using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using MTREG.common;
using MTREG.medinsur.ynydyb.bo;
using MTHIS.common;

namespace MTREG.medinsur.ynydyb.bll
{
    class YNYDYB
    {
        /*
        [DllImport("YDJYInterface.dll")]
        public static extern int YDJYDLLINIT(StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern int SIGNIN(string OperatorNo, string SenderSerialNo, StringBuilder ReceiverSerialNo, StringBuilder OutputDate);
        [DllImport("YDJYInterface.dll")]
        public static extern int SIGNOUT(string OperatorNo, string BusiCycleNo, string CheckAccInfo, string SenderSerialNo, StringBuilder ReceiverSerialNo, StringBuilder OutputDate);


        [DllImport("YDJYInterface.dll")]
        public static extern int CenterQuery(string TransCode, string InputData, StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern int RouteRepeater(string TransCode, string InsuredAreaNo, string PersonNo, string InputData, StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern int SIReadCard(StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern int ModifyPassword(StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern int YDJYBusiness_Handle(string TransCode, string SenderSerialNo, string PersonNo, string SICardNo, string InsuredAreaNo, string OldTransCode, string OldSenderSerialNo, string OperatorNo, string BusiCycleNo, string InputData, StringBuilder ReceiverSerialNo, StringBuilder OutputData);

        [DllImport("YDJYInterface.dll")]
        public static extern int BatchDownload(string TransCode, string OperatorNo, string BusiCycleNo, string InputData, StringBuilder OutputDate);

        [DllImport("YDJYInterface.dll")]
        public static extern string Conversion(string TtemType, string OldItem);

        */

       //*
        public int YDJYDLLINIT(StringBuilder OutputDate)
       {
           return 0;
       }
        public int SIGNIN(string OperatorNo, string SenderSerialNo, StringBuilder ReceiverSerialNo, StringBuilder OutputDate)
       {
           ReceiverSerialNo.Append( "QDJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
           OutputDate.Append("<output><BATCHNO>530004230001" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "</BATCHNO></output>");
           return 0;
       }
        public int SIGNOUT(string OperatorNo, string BusiCycleNo, string CheckAccInfo, string SenderSerialNo, StringBuilder ReceiverSerialNo, StringBuilder OutputDate)
       {
           ReceiverSerialNo.Append("QTJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
           return 0;
       }
        public int CenterQuery(string TransCode, string InputData, StringBuilder OutputDate)
       {
           if ("81".Equals(TransCode))
           {
               OutputDate.Append("<output><TRANSID>FSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + "</TRANSID></output>");
           }
           if ("82".Equals(TransCode))
           {
               OutputDate.Append("<output><TRANSSTAT>交易状态</TRANSSTAT><CANCELSTAT>正交易被撤销状态</CANCELSTAT></output>");
           }
           if ("84".Equals(TransCode))
           {
               //OutputDate.Append("<input><POSNUM>正交易笔数</POSNUM><NEGNUM>反交易笔数</NEGNUM><AKC264>医疗费用总额</AKC264><AKC261>现金支付总额</AKC261><AKC255>账户支付总额</AKC255><AKC260>统筹支付总额</AKC260></input>");
               OutputDate.Append("<input><POSNUM>1</POSNUM><NEGNUM>0</NEGNUM><AKC264>4936.93</AKC264><AKC261>959.44</AKC261><AKC255>368.10</AKC255><AKC260>3609.39</AKC260></input>");
           }
           return 0;
       }
        public int RouteRepeater(string TransCode, string InsuredAreaNo, string PersonNo, string InputData, StringBuilder OutputDate)
        {
            if ("72".Equals(TransCode))
            {
//                OutputDate.Append(@"<output><AKC264>医疗费用总额</AKC264><AKC260>医保支付金额</AKC260><AKC255>账户支付总额</AKC255><AKC261>现金支付总额</AKC261><AKC262>大病理赔</AKC262><AKC290>起付线</AKC290><AKC090>住院次数</AKC090><AKC272>起付线剩余
//                </AKC272><AKC801>进入基数部分</AKC801><CKC120>全自费部分</CKC120><CKC121>挂钩自费部分</CKC121><CKC155>基本医疗统筹自付部分</CKC155><CKC156>基本医疗统筹支付部分</CKC156><CKC161>大病医疗统筹自付部分</CKC161>
//                <CKC162>大病医疗统筹支付部分</CKC162><CKC170>超限自付部分</CKC170><AKC802>特殊人群专项补助自付部分</AKC802><AKC803>特殊人群专项补助支付部分</AKC803><AKC804>公务员基本医疗补助部分</AKC804>
//                <CKC103>公务员大病医疗补助部分</CKC103><AKC805>公务员超限补助部分</AKC805><AKC806>其他补助部分</AKC806><AKC807>其他补助部分</AKC807><AKC808>特殊挂钩先自付部分</AKC808><PRINT>发票医保支付打印串</PRINT></output>");
                OutputDate.Append(@"<output><AKC264>506.47</AKC264><AKC260>0</AKC260><AKC255>306.47</AKC255><AKC261>200</AKC261><AKC290>0</AKC290><AKC090></AKC090><AKC272>0</AKC272><AKC801>0</AKC801><CKC120>0</CKC120><CKC121>50</CKC121><CKC155>450</CKC155><CKC156>0</CKC156><CKC161>0</CKC161><CKC162>0</CKC162><CKC170>0</CKC170><AKC802></AKC802><AKC803>0</AKC803><AKC804>0</AKC804><CKC103>0</CKC103><AKC805>0</AKC805><AKC806>0</AKC806><AKC808>0</AKC808><AKC808></AKC808></output>");
                //OutputDate.Append(@"<output><AKC264>4936.93</AKC264><AKC260>3609.39</AKC260><AKC255>368.1</AKC255><AKC261>959.44</AKC261><AKC290>400</AKC290><AKC090>0</AKC090><AKC272>0</AKC272><AKC801>400</AKC801><CKC120>270</CKC120><CKC121>343.68</CKC121><CKC155>313.86</CKC155><CKC156>3609.39</CKC156><CKC161>0</CKC161><CKC162>0</CKC162><CKC170>0</CKC170><AKC802>0</AKC802><AKC803>0</AKC803><AKC804>0</AKC804><CKC103>0</CKC103><AKC805>0</AKC805><AKC806>0</AKC806><AKC808>0</AKC808></output>");
            }
            if ("73".Equals(TransCode))
            {
                //OutputDate.Append("<output><AKC225>可用单价</AKC225><AKA065>项目等级</AKA065></output>");
                var el = XElement.Load(new StringReader(InputData));
                OutputDate.Append("<output><AKC225>" + el.Element("AKC225").Value.ToString() + "</AKC225><AKA065>1</AKA065></output>");
            }
            if ("74".Equals(TransCode))
            {
                OutputDate.Append("<input><AKC180>审批结果类别</AKC180><AAE073>审批编号</AAE073></input>");
            }
            if ("75".Equals(TransCode))
            {
                OutputDate.Append("<input><AKC180>审批结果类别</AKC180><APPROVECNT>审批结果条数</APPROVECNT></input>");
            }
            return 0;
        }

        public int SIReadCard(StringBuilder OutputDate)
        {
            //OutputDate.Append(@"<output><AKC020>26240008488</AKC020><YAB300>5304</YAB300><YAB600>0423</YAB600><AAC001>2624008488</AAC001><AAC003>岳修毕</AAC003><AAC004>1</AAC004><AAC006>1949-04-30</AAC006><AAC002>532625194904300019</AAC002><AKC021>22</AKC021><AKC023>67</AKC023><AAB001>26230213</AAB001><AAB004>西畴公路分局</AAB004><AKC300>1</AKC300><AKC087>368.1</AKC087><YKC999>2</YKC999><YAB003>5326</YAB003><YAB060>2623</YAB060><YBCS1N></YBCS1N><YBCS1V></YBCS1V><YBCS2N></YBCS2N><YBCS2V></YBCS2V><YBCS3N></YBCS3N><YBCS3V></YBCS3V><YBCS4N></YBCS4N><YBCS4V></YBCS4V><YBCS5N></YBCS5N><YBCS5V></YBCS5V><YBCS6N></YBCS6N><YBCS6V></YBCS6V></output>");
            OutputDate.Append(@"<output><AKC020>01026442960</AKC020><YAB300>5304</YAB300><YAB600>0423</YAB600><AAC001>0102582771</AAC001><AAC003>李粉英</AAC003><AAC004>2</AAC004><AAC006>1991-09-30</AAC006><AAC002>530423199109300324</AAC002><AKC021>11</AKC021><AKC023>25</AKC023><AAB001>01027581</AAB001><AAB004>云南觉晟企业管理有限公司</AAB004><AKC300>1</AKC300><AKC087>376.32</AKC087><YKC999>2</YKC999><YAB003>5301</YAB003><YAB060>0102</YAB060><YBCS1N></YBCS1N><YBCS1V></YBCS1V><YBCS2N></YBCS2N><YBCS2V></YBCS2V><YBCS3N></YBCS3N><YBCS3V></YBCS3V><YBCS4N></YBCS4N><YBCS4V></YBCS4V><YBCS5N></YBCS5N><YBCS5V></YBCS5V><YBCS6N></YBCS6N><YBCS6V></YBCS6V></output>");

//            OutputDate.Append(@"<output><AKC020>医保卡号</AKC020><YAB300>就医地统筹区编码</YAB300><YAB600>就医地分中心编号</YAB600><AAC001>个人编码</AAC001><AAC003>师进萍</AAC003><AAC004>性别</AAC004><AAC006>出生日期</AAC006>
//                <AAC002>身份证号</AAC002><AKC021>医疗人员类别</AKC021><AKC023>实足年龄</AKC023><AAB001>单位编码</AAB001><AAB004>单位名称</AAB004><AKC300>人群类别</AKC300><AKC087>100</AKC087>
//                <YKC999>就医地类别</YKC999><YAB003>参保地统筹区编码</YAB003><YAB060>参保地分中心编号</YAB060><YBCS1N>医保参数1名称</YBCS1N><YBCS1V>医保参数1值</YBCS1V><YBCS2N>医保参数2名称</YBCS2N>
//                <YBCS2V>医保参数2值</YBCS2V><YBCS3N>医保参数3名称</YBCS3N><YBCS3V>医保参数3值</YBCS3V><YBCS4N>医保参数4名称</YBCS4N><YBCS4V>医保参数4值</YBCS4V><YBCS5N>医保参数5名称</YBCS5N>
//                <YBCS5V>医保参数5值</YBCS5V><YBCS6N>医保参数6名称</YBCS6N><YBCS6V>医保参数6值</YBCS6V></output>");
            return 0;
        }
        public int ModifyPassword(StringBuilder OutputDate) 
        {
            return 0;
        }

        public int YDJYBusiness_Handle(string TransCode, string SenderSerialNo, string PersonNo, string SICardNo, string InsuredAreaNo, string OldTransCode, string OldSenderSerialNo, string OperatorNo, string BusiCycleNo, string InputData, StringBuilder ReceiverSerialNo, StringBuilder OutputDate)
        { 
            if ("11".Equals(TransCode))
            {
                ReceiverSerialNo.Append("DJJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
                //OutputDate.Append(@"<output><AAC001>2624008488</AAC001><AKC020>26240008488</AKC020><AAC003>岳修毕</AAC003><AAC004>1</AAC004><AAC006>1949-04-30</AAC006><AAC002>532625194904300019</AAC002><AKC021>22</AKC021><AKC023>67</AKC023><AAB001>26230213</AAB001><AAB004>西畴公路分局</AAB004><AAB020>890</AAB020><AAB019>2</AAB019><AAB021>4</AAB021><YAB063>0</YAB063><YAB060>2623</YAB060><AKC300>1</AKC300><AKC087>368.1</AKC087><YKC002>0</YKC002><YKC606></YKC606><AKC025>0</AKC025><YKC609>0</YKC609><SAC004>0</SAC004><SAC006>0</SAC006><SAC008>0</SAC008><SAC010>0</SAC010><AKC190>2623WS1701170428801</AKC190><YKA116>0</YKA116><AKC270>400</AKC270><YKA119>70652.17</YKA119><YKA121>210526.32</YKA121><YKA123>0</YKA123><AKC251>0</AKC251><YKA437>0</YKA437><YKA438>0</YKA438><AKC090>0</AKC090></output>");

                OutputDate.Append(@"<output><AAC001>0102582771</AAC001><AKC020>01026442960</AKC020><AAC003>李粉英</AAC003><AAC004>2</AAC004><AAC006>1991-09-30</AAC006><AAC002>530423199109300324</AAC002><AKC021>11</AKC021><AKC023>25</AKC023><AAB001>01027581</AAB001><AAB004>云南觉晟企业管理有限公司</AAB004><AAB020>100</AAB020><AAB019>10</AAB019><AAB021>52</AAB021><YAB063></YAB063><YAB060>0102</YAB060><AKC300>1</AKC300><AKC087>376.32</AKC087><YKC002></YKC002><YKC606></YKC606><AKC025></AKC025><YKC609></YKC609><SAC004>0</SAC004><SAC006>0</SAC006><SAC008>0</SAC008><SAC010>0</SAC010><AKC190>0102KM1701172548380</AKC190><YKA116>0</YKA116><AKC270>0</AKC270><YKA119>0</YKA119><YKA121>0</YKA121><YKA123>0</YKA123><AKC251>0</AKC251><YKA437>0</YKA437><YKA438>0</YKA438><AKC090></AKC090></output>");
//                OutputDate.Append(@"<output><AAC001>个人编号</AAC001><AKC020>医保卡号</AKC020><AAC003>师进萍</AAC003><AAC004>性别</AAC004><AAC006>出生日期</AAC006><AAC002>身份证</AAC002><AKC021>医疗人员类别
//                    </AKC021><AKC023>实足年龄</AKC023><AAB001>单位编码</AAB001><AAB004>单位名称</AAB004><AAB020>经济类型</AAB020><AAB019>单位类型</AAB019><AAB021>隶属关系</AAB021><YAB063>公医单位标志
//                    </YAB063><YAB060>参保地分中心编号</YAB060><AKC300>人群类别</AKC300><AKC087>100</AKC087><YKC002>特殊人群标志</YKC002><YKC606>离休人员职务标志</YKC606><YKC609>公务员待遇享受标志
//                    </YKC609><AKC025>公务员标志</AKC025><SAC004>是否低保</SAC004><SAC006>是否重度残疾</SAC006><SAC008>是否低收入</SAC008><SAC010>老年人标志</SAC010><AKC190>住院号(门诊号)
//                    </AKC190><YKA116>起付线累计</YKA116><AKC270>本次应付起付线</AKC270><YKA119>基本医疗本次支付限额</YKA119><YKA121>大病医疗本次支付限额</YKA121><YKA123>公务员本次支付限额
//                    </YKA123><AKC251>基本医疗统筹累计</AKC251><YKA437>大病医疗统筹累计</YKA437><YKA438>公务员统筹累计</YKA438><AKC090>本年住院次数</AKC090><AKC009></AKC009><AAE140></AAE140></output>");
            }
            if ("12".Equals(TransCode))
            {
                ReceiverSerialNo.Append("CFLRJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
                var el = XElement.Load(new StringReader(InputData));
                OutputDate.Append("<output><AKC225>" + el.Element("AKC225").Value.ToString() + "</AKC225><AKA065>1</AKA065><AAE073>审批编号</AAE073><AKC229>0</AKC229><AKC227>" + el.Element("AKC225").Value.ToString() + "</AKC227><AKC253>0</AKC253><AKC228>0</AKC228><AKC800>" + el.Element("AKC225").Value.ToString() + "</AKC800></output>");
            }
            if ("14".Equals(TransCode))
            {
                ReceiverSerialNo.Append("JSJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
//                OutputDate.Append(@"<output><AKC264>医疗费用总额</AKC264><AKC260>医保支付金额</AKC260><AKC255>账户支付总额</AKC255><AKC261>现金支付总额</AKC261><AKC262>大病理赔</AKC262><AKC290>起付线</AKC290><AKC090>住院次数</AKC090><AKC272>起付线剩余
//                </AKC272><AKC801>进入基数部分</AKC801><CKC120>全自费部分</CKC120><CKC121>挂钩自费部分</CKC121><CKC155>基本医疗统筹自付部分</CKC155><CKC156>基本医疗统筹支付部分</CKC156><CKC161>大病医疗统筹自付部分</CKC161>
//                <CKC162>大病医疗统筹支付部分</CKC162><CKC170>超限自付部分</CKC170><AKC802>特殊人群专项补助自付部分</AKC802><AKC803>特殊人群专项补助支付部分</AKC803><AKC804>公务员基本医疗补助部分</AKC804>
//                <CKC103>公务员大病医疗补助部分</CKC103><AKC805>公务员超限补助部分</AKC805><AKC806>其他补助部分</AKC806><AKC807>其他补助部分</AKC807><AKC808>特殊挂钩先自付部分</AKC808><PRINT>发票医保支付打印串</PRINT></output>");
                //OutputDate.Append(@"<output><AKC264>4936.93</AKC264><AKC260>3609.39</AKC260><AKC255>368.1</AKC255><AKC261>959.44</AKC261><AKC290>400</AKC290><AKC090>0</AKC090><AKC272>0</AKC272><AKC801>400</AKC801><CKC120>270</CKC120><CKC121>343.68</CKC121><CKC155>313.86</CKC155><CKC156>3609.39</CKC156><CKC161>0</CKC161><CKC162>0</CKC162><CKC170>0</CKC170><AKC802>0</AKC802><AKC803>0</AKC803><AKC804>0</AKC804><CKC103>0</CKC103><AKC805>0</AKC805><AKC806>0</AKC806><AKC808>0</AKC808></output>");
                OutputDate.Append(@"<output><AKC264>506.47</AKC264><AKC260>0</AKC260><AKC255>306.47</AKC255><AKC261>200</AKC261><AKC290>0</AKC290><AKC090></AKC090><AKC272>0</AKC272><AKC801>0</AKC801><CKC120>0</CKC120><CKC121>50</CKC121><CKC155>450</CKC155><CKC156>0</CKC156><CKC161>0</CKC161><CKC162>0</CKC162><CKC170>0</CKC170><AKC802></AKC802><AKC803>0</AKC803><AKC804>0</AKC804><CKC103>0</CKC103><AKC805>0</AKC805><AKC806>0</AKC806><AKC808>0</AKC808></output>");
            }
            if ("15".Equals(TransCode))
            {
                ReceiverSerialNo.Append("GXJZDJJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            }
            if ("21".Equals(TransCode))
            {
                ReceiverSerialNo.Append("FJSJJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            }
            if ("22".Equals(TransCode))
            {
                ReceiverSerialNo.Append("WFTYJJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            }
            if ("23".Equals(TransCode))
            {
                ReceiverSerialNo.Append("CFTFJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
                OutputDate.Append("<output><REMAINCNT>剩余数量</REMAINCNT><REMAINFEE>剩余金额</REMAINFEE></output>");
            }
            if ("24".Equals(TransCode))
            {
                ReceiverSerialNo.Append("PLSCJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            }
            if ("98".Equals(TransCode))
            {
                ReceiverSerialNo.Append("JYCFJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
            }
            if ("99".Equals(TransCode))
            {
                ReceiverSerialNo.Append("CZJYJSFLSH" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"));
                OutputDate.Append("<output><CANCELSTAT>1</CANCELSTAT></output>");
            }
            return 0;
        }

        public int BatchDownload(string TransCode, string OperatorNo, string BusiCycleNo, string InputData, StringBuilder OutputDate)
        {
            if ("83".Equals(TransCode))
            {
                OutputDate.Append("F:\\云南\\新建文件夹\\总账批量数据下载" + ProgramGlobal.User_id + ynydybGlobal.Ywzqh + ".txt");
            }
            if ("85".Equals(TransCode))
            {
                OutputDate.Append("E:\\云南\\新民腾医保20161227\\新建文件夹\\zhongluyiyuan\\bin\\Debug\\明细账批量数据下载" + ProgramGlobal.User_id + ynydybGlobal.Ywzqh + ".txt");
            }
            return 0;
        }

        public string Conversion(string TtemType, string OldItem)
        {
            return OldItem;
        }
       //*/



        /// <summary>
        /// 1.1 ydjydllinit  异地交易接口初始化
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int ydjydllinit(YDJYDLLINIT_out out1)
        {


            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = YDJYDLLINIT(OutputDate);
            //分解协议
            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }



        /// <summary>
        /// 1.2 signin  操作员签到
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int signin(string czybh, string fsfjylsh, StringBuilder jsfjylsh, SIGNIN_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = SIGNIN(czybh, fsfjylsh, jsfjylsh, OutputDate);
            //分解协议
            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Czyywzqh = el.Element("BATCHNO").Value.ToString();
            return ret;
        }



        /// <summary>
        /// 1.3 signout  操作员签退
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int signout(string czybh, string ywzqh, Dzcx_out dzjytdsrsj_in, string fsfjylsh, StringBuilder jsfjylsh, SIGNOUT_out out1)
        {

            StringBuilder OutputDate = new StringBuilder(2048);
            string dzjytdsrsj = "<input><POSNUM>" + dzjytdsrsj_in.Zjybs + "</POSNUM><NEGNUM>" + dzjytdsrsj_in.Fjybs + "</NEGNUM><AKC264>" + dzjytdsrsj_in.Ylfyze + "</AKC264><AKC261>" + dzjytdsrsj_in.Xjzfze + "</AKC261><AKC255>" + dzjytdsrsj_in.Zhzfze + "</AKC255><AKC260>" + dzjytdsrsj_in.Tczfze + "</AKC260></input>";
            //调用动态库
            int ret = SIGNOUT(czybh, ywzqh, dzjytdsrsj, fsfjylsh, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            return ret;
        }



        /// <summary>
        /// 81 hqfsflsh  获取发送方流水号
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int hqfsflsh(Hqfsflsh_out out1)
        {


            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = CenterQuery("81", " ", OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Swqjwyzym = el.Element("TRANSID").Value.ToString();
            return ret;
        }



        /// <summary>
        /// 82 jcjyzt  检测交易状态
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int jcjyzt(Jcjyzt_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = CenterQuery("82", " ", OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Jyzt = el.Element("TRANSSTAT").Value.ToString();
            out1.Zjybcxzt = el.Element("CANCELSTAT").Value.ToString();
            return ret;
        }



        /// <summary>
        /// 84 dzcx  对账查询
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int dzcx(Dzcx_in in1, Dzcx_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><OPERID>" + in1.Czybh + "</OPERID><BATNO>" + in1.Ywzqh + "</BATNO></input>";
            //调用动态库
            int ret = CenterQuery("84", InputData, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Zjybs = el.Element("POSNUM").Value.ToString();
            out1.Fjybs = el.Element("NEGNUM").Value.ToString();
            out1.Ylfyze = el.Element("AKC264").Value.ToString();
            out1.Xjzfze = el.Element("AKC261").Value.ToString();
            out1.Zhzfze = el.Element("AKC255").Value.ToString();
            out1.Tczfze = el.Element("AKC260").Value.ToString();
            return ret;
        }


        //public static bool Check(string card)
        //{
        //    bool ck = true;
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(HttpContext.Current.Server.MapPath("XML.xml"));
        //    XmlNodeList xnl = xmlDoc.SelectNodes("/FMT/ML");
        //    foreach (XmlNode linkNode in xnl)
        //    {
        //        XmlElement xe = (XmlElement)linkNode;//将子节点类型转换为XmlElement类型
        //        string aa = xe.SelectSingleNode("Card").InnerText.Trim();
        //        if (aa == card)
        //        {
        //            ck = false;
        //        }
        //    }
        //    return ck;
        //}
        /// <summary>
        /// 72  ydylfyyjs  医疗费用预结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydylfyyjs(YdYlfyyjs_in in1, YdYlfyyjs_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><AKC221>" + in1.Cfjzsj + "</AKC221><AKC064>" + in1.Fyze + "</AKC064><AKC255>" + in1.Zhzfje + "</AKC255></input>";
            //调用动态库
            int ret = RouteRepeater("72", in1.Cbdtcqbh, in1.Hzgrbh, InputData, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            StringReader sr = new StringReader(OutputDate.ToString());
            //DataSet ds = new DataSet();
            //ds.ReadXml(sr);
            //int i = ds.Tables["output"].Columns.Count; 
            //string sql=ds.Tables["output"].Columns[0].ColumnName;
            //string AKC264 = ds.Tables["output"].Rows[0]["AKC264"].ToString();//
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            if (OutputDate.ToString().Contains("AKC262"))
            {
                out1.Dblp = el.Element("AKC262").Value.ToString();//大病理赔
            }
            if (OutputDate.ToString().Contains("AKC806"))
            {
                out1.Qtbzbf1 = el.Element("AKC806").Value.ToString();//其他补助部分
            }
            if (OutputDate.ToString().Contains("AKC807"))
            {
                out1.Qtbzbf2 = el.Element("AKC807").Value.ToString();//其他补助部分2
            }
            if (OutputDate.ToString().Contains("PRINT"))
            {
                out1.Fpybzfdyc = el.Element("PRINT").Value.ToString();//发票医保支付打印串
            }
            out1.Ylfze = el.Element("AKC264").Value.ToString();//医疗费总额
            out1.Ybzfje = el.Element("AKC260").Value.ToString();//医保支付金额
            out1.Zhzfje = el.Element("AKC255").Value.ToString();//账户支付金额
            out1.Xjzfje = el.Element("AKC261").Value.ToString();//现金支付金额
            //out1.Dblp = el.Element("AKC262").Value.ToString();//大病理赔
            out1.Qfx = el.Element("AKC290").Value.ToString();//起付线
            out1.Zycs = el.Element("AKC090").Value.ToString();//住院次数
            out1.Qfxsy = el.Element("AKC272").Value.ToString();//起付线剩余
            out1.Jrjsbf = el.Element("AKC801").Value.ToString();//进入基数部分
            out1.Qzfbf = el.Element("CKC120").Value.ToString();//全自费部分
            out1.Ggzfbf = el.Element("CKC121").Value.ToString();//挂钩自费部分
            out1.Jbyltczifbf = el.Element("CKC155").Value.ToString();//基本医疗统筹自付部分
            out1.Jbyltczhifbf = el.Element("CKC156").Value.ToString();//基本医疗统筹支付部分
            out1.Dbyltczifbf = el.Element("CKC161").Value.ToString();//大病医疗统筹自付部分
            out1.Dbyltczhifbf = el.Element("CKC162").Value.ToString();//大病医疗统筹支付部分
            out1.Cxzfbf = el.Element("CKC170").Value.ToString();//超限自付部分
            out1.Tsrqzxbzzifbf = el.Element("AKC802").Value.ToString();//特殊人群专项补助自付部分
            out1.Tsrqzxbzzhifbf = el.Element("AKC803").Value.ToString();//特殊人群专项补助支付部分
            out1.Gwyjbylbzbf = el.Element("AKC804").Value.ToString();//公务员基本医疗补助部分
            out1.Gwydbylbzbf = el.Element("CKC103").Value.ToString();//公务员大病医疗补助部分
            out1.Gwycxbzbf = el.Element("AKC805").Value.ToString();//公务员超限补助部分
            //out1.Qtbzbf = el.Element("AKC806").Value.ToString();//其他补助部分
            out1.Tsggxzfbf = el.Element("AKC808").Value.ToString();//特殊挂钩先自付部分
            //out1.Fpybzfdyc = el.Element("PRINT").Value.ToString();//发票医保支付打印串

            return ret;
        }



        /// <summary>
        /// 73  ydhqxmdj  获取项目单价
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydhqxmdj(YdHqxmdj_in in1, YdHqxmdj_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC222>" + in1.Sfxmbm + "</AKC222><AKA111>" + in1.Fylb + "</AKA111><AKC225>" + in1.Yydj + "</AKC225></input>";
            //调用动态库
            int ret = RouteRepeater("73", in1.Cbdtcqbh, in1.Hzgrbh, InputData, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Kydj = el.Element("AKC225").Value.ToString();
            out1.Xmdj = el.Element("AKA065").Value.ToString();

            return ret;
        }



        /// <summary>
        /// 74  ydxmspjgcx  项目审批结果查询
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydxmspjgcx(YdXmspjgcx_in in1, YdXmspjgcx_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC222>" + in1.Xmbh + "</AKC222><AKC221>" + in1.Kfsj + "</AKC221></input>";
            //调用动态库
            int ret = RouteRepeater("74", in1.Cbdtcqbh, in1.Hzgrbh, InputData, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Spjglb = el.Element("AKC180").Value.ToString();
            out1.Spbh = el.Element("AAE073").Value.ToString();

            return ret;
        }



        /// <summary>
        /// 75  ydhdtgspxx  获得通过审批信息
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydhdtgspxx(YdHdtgspxx_in in1, YdHdtgspxx_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC170>" + in1.Splbdbm + "</AKC170></input>";
            //调用动态库
            int ret = RouteRepeater("75", in1.Cbdtcqbh, in1.Hzgrbh, InputData, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Spjglb = el.Element("AKC180").Value.ToString();
            if (out1.Spjglb == "1")
            {
                out1.Spjgts = el.Element("APPROVECNT").Value.ToString();
                if (out1.Spjgts == "1")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                }
                else if (out1.Spjgts == "2")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                }
                else if (out1.Spjgts == "3")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                }
                else if (out1.Spjgts == "4")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                }
                else if (out1.Spjgts == "5")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                }
                else if (out1.Spjgts == "6")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                    out1.Spbh6 = el.Element("AAE073_6").Value.ToString();
                    out1.Xmbh6 = el.Element("AKC222_6").Value.ToString();
                    out1.Xmmc6 = el.Element("AKC223_6").Value.ToString();
                }
                else if (out1.Spjgts == "7")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                    out1.Spbh6 = el.Element("AAE073_6").Value.ToString();
                    out1.Xmbh6 = el.Element("AKC222_6").Value.ToString();
                    out1.Xmmc6 = el.Element("AKC223_6").Value.ToString();
                    out1.Spbh7 = el.Element("AAE073_7").Value.ToString();
                    out1.Xmbh7 = el.Element("AKC222_7").Value.ToString();
                    out1.Xmmc7 = el.Element("AKC223_7").Value.ToString();
                }
                else if (out1.Spjgts == "8")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                    out1.Spbh6 = el.Element("AAE073_6").Value.ToString();
                    out1.Xmbh6 = el.Element("AKC222_6").Value.ToString();
                    out1.Xmmc6 = el.Element("AKC223_6").Value.ToString();
                    out1.Spbh8 = el.Element("AAE073_8").Value.ToString();
                    out1.Xmbh8 = el.Element("AKC222_8").Value.ToString();
                    out1.Xmmc8 = el.Element("AKC223_8").Value.ToString();
                }
                else if (out1.Spjgts == "9")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                    out1.Spbh6 = el.Element("AAE073_6").Value.ToString();
                    out1.Xmbh6 = el.Element("AKC222_6").Value.ToString();
                    out1.Xmmc6 = el.Element("AKC223_6").Value.ToString();
                    out1.Spbh8 = el.Element("AAE073_8").Value.ToString();
                    out1.Xmbh8 = el.Element("AKC222_8").Value.ToString();
                    out1.Xmmc8 = el.Element("AKC223_8").Value.ToString();
                    out1.Spbh9 = el.Element("AAE073_9").Value.ToString();
                    out1.Xmbh9 = el.Element("AKC222_9").Value.ToString();
                    out1.Xmmc9 = el.Element("AKC223_9").Value.ToString();
                }
                else if (out1.Spjgts == "10")
                {
                    out1.Spbh1 = el.Element("AAE073_1").Value.ToString();
                    out1.Xmbh1 = el.Element("AKC222_1").Value.ToString();
                    out1.Xmmc1 = el.Element("AKC223_1").Value.ToString();
                    out1.Spbh2 = el.Element("AAE073_2").Value.ToString();
                    out1.Xmbh2 = el.Element("AKC222_2").Value.ToString();
                    out1.Xmmc2 = el.Element("AKC223_2").Value.ToString();
                    out1.Spbh3 = el.Element("AAE073_3").Value.ToString();
                    out1.Xmbh3 = el.Element("AKC222_3").Value.ToString();
                    out1.Xmmc3 = el.Element("AKC223_3").Value.ToString();
                    out1.Spbh4 = el.Element("AAE073_4").Value.ToString();
                    out1.Xmbh4 = el.Element("AKC222_4").Value.ToString();
                    out1.Xmmc4 = el.Element("AKC223_4").Value.ToString();
                    out1.Spbh5 = el.Element("AAE073_5").Value.ToString();
                    out1.Xmbh5 = el.Element("AKC222_5").Value.ToString();
                    out1.Xmmc5 = el.Element("AKC223_5").Value.ToString();
                    out1.Spbh6 = el.Element("AAE073_6").Value.ToString();
                    out1.Xmbh6 = el.Element("AKC222_6").Value.ToString();
                    out1.Xmmc6 = el.Element("AKC223_6").Value.ToString();
                    out1.Spbh8 = el.Element("AAE073_8").Value.ToString();
                    out1.Xmbh8 = el.Element("AKC222_8").Value.ToString();
                    out1.Xmmc8 = el.Element("AKC223_8").Value.ToString();
                    out1.Spbh9 = el.Element("AAE073_9").Value.ToString();
                    out1.Xmbh9 = el.Element("AKC222_9").Value.ToString();
                    out1.Xmmc9 = el.Element("AKC223_9").Value.ToString();
                    out1.Spbh10 = el.Element("AAE073_10").Value.ToString();
                    out1.Xmbh10 = el.Element("AKC222_10").Value.ToString();
                    out1.Xmmc10 = el.Element("AKC223_10").Value.ToString();
                }
            }
            else if (out1.Spjglb == "100")
            {
                out1.Spjgts = "0";
            }
            return ret;
        }



        /// <summary>
        /// 1.6  dkcx  读卡查询
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int dkcx(Dkcx_out out1)
        {


            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = SIReadCard(OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Ybkh = el.Element("AKC020").Value.ToString();//医保卡号
            out1.Grbm = el.Element("AAC001").Value.ToString();//个人编码
            out1.Xm = el.Element("AAC003").Value.ToString();//姓名
            out1.Xb = el.Element("AAC004").Value.ToString();//性别
            out1.Csrq = el.Element("AAC006").Value.ToString();//出生日期
            out1.Sfzh = el.Element("AAC002").Value.ToString();//身份证号
            out1.Ylrylb = el.Element("AKC021").Value.ToString();//医疗人员类别
            out1.Sznl = el.Element("AKC023").Value.ToString();//实足年龄
            out1.Dwbm = el.Element("AAB001").Value.ToString();//单位编码
            out1.Dwmc = el.Element("AAB004").Value.ToString();//单位名称
            out1.Rqlb = el.Element("AKC300").Value.ToString();//人群类别
            out1.Zhye = el.Element("AKC087").Value.ToString();//帐户余额
            out1.Jydlb = el.Element("YKC999").Value.ToString();//就医地类别
            out1.Cbdtcqbm = el.Element("YAB003").Value.ToString();//参保地统筹区编码
            out1.Jydtcqbm = el.Element("YAB300").Value.ToString();//就医地统筹区编码
            out1.Cbdfzxbh = el.Element("YAB060").Value.ToString();//参保地分中心编号
            out1.Jydfzxbh = el.Element("YAB600").Value.ToString();//就医地分中心编号
            out1.Ybcsmc1 = el.Element("YBCS1N").Value.ToString();//医保参数1名称
            out1.Ybcsz1 = el.Element("YBCS1V").Value.ToString();//医保参数1值
            out1.Ybcsmc2 = el.Element("YBCS2N").Value.ToString();//医保参数2名称
            out1.Ybcsz2 = el.Element("YBCS2V").Value.ToString();//医保参数2值
            out1.Ybcsmc3 = el.Element("YBCS3N").Value.ToString();//医保参数3名称
            out1.Ybcsz3 = el.Element("YBCS3V").Value.ToString();//医保参数3值
            out1.Ybcsmc4 = el.Element("YBCS4N").Value.ToString();//医保参数4名称
            out1.Ybcsz4 = el.Element("YBCS4V").Value.ToString();//医保参数4值
            out1.Ybcsmc5 = el.Element("YBCS5N").Value.ToString();//医保参数5名称
            out1.Ybcsz5 = el.Element("YBCS5V").Value.ToString();//医保参数5值
            out1.Ybcsmc6 = el.Element("YBCS6N").Value.ToString();//医保参数6名称
            out1.Ybcsz6 = el.Element("YBCS6V").Value.ToString();//医保参数6值
            return ret;
        }



        /// <summary>
        /// 1.7 xgkmm  修改卡密码
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns>
        public int xgkmm(Xgkmm_out out1)
        {


            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = ModifyPassword(OutputDate);
            //分解协议
            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }



        /// <summary>
        /// 11  jzxxdj  就诊信息登记
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int jzxxdj(StringBuilder jsfjylsh,StringBuilder OutputDate, Jzxxdj_in in1, Jzxxdj_out out1, StringBuilder djfhxx)
        {
            string InputData = "<input><YKC006>" + in1.Kms + "</YKC006><YKC010>" + in1.Zyh + "</YKC010><AKA130>" + in1.Yllb + "</AKA130><AKC192>" + in1.Ryrq + "</AKC192><AKC193>";
            InputData += in1.Ryzdbm + "</AKC193><AAE011>" + in1.Jbr + "</AAE011><AAE073>" + in1.Spbh + "</AAE073><AKA123>" + in1.Sftzb + "</AKA123><AKA120>";
            InputData += in1.Jbbm + "</AKA120><YKC009>" + in1.Blh + "</YKC009><YKC011>" + in1.Ryks + "</YKC011><YKC012>" + in1.Rycw + "</YKC012><YKC600>";
            InputData += in1.Ryzdmc + "</YKC600><YKC601>" + in1.Ryzdbm2 + "</YKC601><YKC602>" + in1.Ryzdbm3 + "</YKC602><YKC008>" + in1.Ryzdys + "</YKC008><AAE004>" + in1.Hzlxr + "</AAE004><AAE005>" + in1.Hzlxdh + "</AAE005></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("11", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            djfhxx.Append(OutputDate);
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Ybkh = el.Element("AKC020").Value.ToString();//医保卡号
            out1.Grbh = el.Element("AAC001").Value.ToString();//个人编号
            out1.Xm = el.Element("AAC003").Value.ToString();//姓名
            out1.Xb = el.Element("AAC004").Value.ToString();//性别
            out1.Csrq = el.Element("AAC006").Value.ToString();//出生日期
            out1.Sfzh = el.Element("AAC002").Value.ToString();//身份证号
            out1.Ylrylb = el.Element("AKC021").Value.ToString();//医疗人员类别
            out1.Sznl = el.Element("AKC023").Value.ToString();//实足年龄
            out1.Dwbm = el.Element("AAB001").Value.ToString();//单位编码
            out1.Dwmc = el.Element("AAB004").Value.ToString();//单位名称
            out1.Rqlb = el.Element("AKC300").Value.ToString();//人群类别
            out1.Zhye = el.Element("AKC087").Value.ToString();//帐户余额
            out1.Jjlx = el.Element("AAB020").Value.ToString();//经济类型
            out1.Dwlx = el.Element("AAB019").Value.ToString();//单位类型
            out1.Lsgx = el.Element("AAB021").Value.ToString();//隶属关系
            out1.Cbdfzxbh = el.Element("YAB060").Value.ToString();//参保地分中心编号
            out1.Gydwbz = el.Element("YAB063").Value.ToString();//公医单位标志
            out1.Tsrqbz = el.Element("YKC002").Value.ToString();//特殊人群标志
            out1.Lxryzwbz = el.Element("YKC606").Value.ToString();//离休人员职务标志
            out1.Gwydyxsbz = el.Element("YKC609").Value.ToString();//公务员待遇享受标志
            out1.Gwybz = el.Element("AKC025").Value.ToString();//公务员标志
            out1.Sfdb = el.Element("SAC004").Value.ToString();//是否低保
            out1.Sfzdcj = el.Element("SAC006").Value.ToString();//是否重度残疾
            out1.Sfdsr = el.Element("SAC008").Value.ToString();//是否低收入
            out1.Lnrbz = el.Element("SAC010").Value.ToString();//老年人标志
            out1.Zyh = el.Element("AKC190").Value.ToString();//住院号(门诊号)
            out1.Qfxlj = el.Element("YKA116").Value.ToString();//起付线累计
            out1.Bcyfqfx = el.Element("AKC270").Value.ToString();//本次应付起付线
            out1.Jbylbczfxe = el.Element("YKA119").Value.ToString();//基本医疗本次支付限额
            out1.Dbylbczfxe = el.Element("YKA121").Value.ToString();//大病医疗本次支付限额
            out1.Gwybczfxe = el.Element("YKA123").Value.ToString();//公务员本次支付限额
            out1.Jbyltclj = el.Element("AKC251").Value.ToString();//基本医疗统筹累计
            out1.Dbyltclj = el.Element("YKA437").Value.ToString();//大病医疗统筹累计
            out1.Gwytclj = el.Element("YKA438").Value.ToString();//公务员统筹累计
            out1.Bnzycs = el.Element("AKC090").Value.ToString();//本年住院次数


            return ret;
        }



        /// <summary>
        /// 12  ydcfmxlr  处方明细录入
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydcfmxlr(StringBuilder jsfjylsh, YdCfmxlr_in in1, YdCfmxlr_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><AKC220>" + in1.Cfh + "</AKC220><AKC231>" + in1.Cfnxh + "</AKC231><AKC515>" + in1.Yysfxmnm + "</AKC515><AKC516>";
            InputData += in1.Yysfxmmc + "</AKC516><AKC222>" + in1.Sfxmbm + "</AKC222><AKC223>" + in1.Sfxmmc + "</AKC223><AKA063>" + in1.Sflb + "</AKA063><AKA111>";
            InputData += in1.Sfdl + "</AKA111><AKC225>" + in1.Dj + "</AKC225><AKC226>" + in1.Sl + "</AKC226><AKC227>" + in1.Je + "</AKC227><AKA067>";
            InputData += in1.Dw + "</AKA067><AKA074>" + in1.Gg + "</AKA074><AKA070>" + in1.Jx + "</AKA070><AKA071>" + in1.Mcyl + "</AKA071><AKA073>" + in1.Yf + "</AKA073><AKC221>";
            InputData += in1.Kfrq + "</AKC221><AKC201>" + in1.Kfks + "</AKC201><AAE014>" + in1.Kfys + "</AAE014><AAE073>" + in1.Xgspbh + "</AAE073><YKC611>" + in1.Cd + "</YKC611><AAE011>" + in1.Jbr + "</AAE011></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("12", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            string _xmdj = el.Element("AKA065").Value.ToString();//项目收费等级
            if (_xmdj.Equals("1"))
            {
                out1.Xmsfdj = "甲类";
            }
            else if (_xmdj.Equals("2"))
            {
                out1.Xmsfdj = "乙类";
            }
            else if (_xmdj.Equals("3"))
            {
                out1.Xmsfdj = "自费";
            }
            else if (_xmdj.Equals("4"))
            {
                out1.Xmsfdj = "特检特治";
            }
            out1.Sjdj = el.Element("AKC225").Value.ToString();//实际单价
            //out1.Xmsfdj = el.Element("AKA065").Value.ToString();//项目收费等级
            out1.Spbh = el.Element("AAE073").Value.ToString();//审批编号
            out1.Zfbl = el.Element("AKC229").Value.ToString();//自付比例
            out1.Fyze = el.Element("AKC227").Value.ToString();//费用总额
            out1.Qzfbf = el.Element("AKC253").Value.ToString();//全自费部分
            out1.Xzfbf = el.Element("AKC228").Value.ToString();//先自付部分
            out1.Yxbxbf = el.Element("AKC800").Value.ToString();//允许报销部分

            return ret;
        }



        /// <summary>
        /// 14   ydylfyjs  医疗费用结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydylfyjs(StringBuilder jsfjylsh, YdYlfyjs_in in1, StringBuilder OutputDate)
        {
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><AKC221>" + in1.Cfjzsj + "</AKC221><AAE072>" + in1.Fph + "</AAE072><AKA050>" + in1.Jslx + "</AKA050><AAE011>" + in1.Jbr + "</AAE011><AKC255>" + in1.Grzhzfje + "</AKC255></input>";

            //调用动态库
            int ret = YDJYBusiness_Handle("14", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            return ret;
        }



        /// <summary>
        /// 15   ydgxjzdjxx    更新就诊登记信息
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydgxjzdjxx(StringBuilder jsfjylsh, YdGxjzdjxx_in in1, YdGxjzdjxx_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><AKA130>" + in1.Yllb + "</AKA130><AKC020>" + in1.Ybkh + "</AKC020><AKC192>" + in1.Ryrq + "</AKC192><AKC194>";
            InputData += in1.Cyrq + "</AKC194><AKA123>" + in1.Sftzb + "</AKA123><AKA120>" + in1.Qzjbbm + "</AKA120><AKC193>" + in1.Ryjbbm + "</AKC193><AKC196>";
            InputData += in1.Cyjbbm + "</AKC196><AAE011>" + in1.Ryjbr + "</AAE011><YKC011>" + in1.Ryks + "</YKC011><YKC012>" + in1.Rycw + "</YKC012><YKC600>";
            InputData += in1.Ryzdmc + "</YKC600><YKC601>" + in1.Ryzdbm2 + "</YKC601><YKC602>" + in1.Ryzdbm3 + "</YKC602><YKC008>" + in1.Ryzdys + "</YKC008><YKC015>" + in1.Cyks + "</YKC015><YKC016>";
            InputData += in1.Cycw + "</YKC016><YKC603>" + in1.Cyzdmc + "</YKC603><YKC604>" + in1.Cyzdbm2 + "</YKC604><YKC605>" + in1.Cyzdbm3 + "</YKC605><YKC020>" + in1.Cyzdys + "</YKC020><AKC195>" + in1.Cyyy + "</AKC195><YKC017>" + in1.Cyjbr + "</YKC017></input>";

            //string InputData = "<input><AKC190>0401YX1703020130643</AKC190><AKA130></AKA130><AKC020></AKC020><AKC192></AKC192><AKC194></AKC194><AKA123></AKA123><AKA120>A18.406</AKA120><AKC193>A18.406</AKC193><AKC196></AKC196><AAE011>吕鸿燕</AAE011><YKC011>妇产科</YKC011><YKC012>18</YKC012><YKC600>狼疮</YKC600><YKC601></YKC601><YKC602></YKC602><YKC008>樊丽萍</YKC008><YKC015></YKC015><YKC016></YKC016><YKC603></YKC603><YKC604></YKC604><YKC605></YKC605><YKC020></YKC020><AKC195></AKC195><YKC017></YKC017></input>";

            //调用动态库
            int ret = YDJYBusiness_Handle("15", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }



        /// <summary>
        /// 21   ydylfyfjs    医疗费用反结算
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydylfyfjs(StringBuilder jsfjylsh, YdYlfyfjs_in in1, YdYlfyfjs_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><HANDLEID>" + in1.Jsjyfhdjylsh + "</HANDLEID><AAE072>" + in1.Fph + "</AAE072><AAE011>" + in1.Jbr + "</AAE011></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("21", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }



        /// <summary>
        /// 22   ydwfty   无费退院
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydwfty(StringBuilder jsfjylsh, YdWfty_in in1, YdWfty_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190><HANDLEID>" + in1.Djjyfhdjylsh + "</HANDLEID><AAE011>" + in1.Jbr + "</AAE011></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("22", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }



        /// <summary>
        /// 23   ydcfmxtf  处方明细退方
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydcfmxtf(StringBuilder jsfjylsh, YdCfmxtf_in in1, YdCfmxtf_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Jzdjh + "</AKC190><HANDLEID>" + in1.Mxlrjyfhdjylsh + "</HANDLEID><CANCELCNT>" + in1.Tcsl + "</CANCELCNT><CANCELFEE>" + in1.Tcje + "</CANCELFEE><AAE011>" + in1.Jbr + "</AAE011></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("23", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            out1.Sysl = el.Element("REMAINCNT").Value.ToString();//剩余数量
            out1.Syje = el.Element("REMAINFEE").Value.ToString();//剩余金额

            return ret;
        }



        /// <summary>
        /// 24   ydwjscfplsc  未结算处方批量删除
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydwjscfplsc(StringBuilder jsfjylsh, YdWjscfplsc_in in1, YdWjscfplsc_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("24", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, " ", " ", in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }


        /// <summary>
        /// 98   ydjycf  交易重发
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydjycf(StringBuilder jsfjylsh, YdJycf_in in1, YdJycf_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            string InputData = "<input><AKC190>" + in1.Zyh + "</AKC190></input>";
            //调用动态库
            int ret = YDJYBusiness_Handle("98", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, in1.Yjym, in1.Yfsfjylsh, in1.Czybh, in1.Ywzqh, InputData, jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }

            return ret;
        }


        /// <summary>
        /// 99  ydczjy  冲正交易
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydczjy(StringBuilder jsfjylsh, YdCzjy_in in1, YdCzjy_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);

            //调用动态库
            int ret = YDJYBusiness_Handle("99", in1.Fsfjylsh, in1.Hzgrbh, in1.Hzybkh, in1.Hzcbdtcqbh, in1.Yjym, in1.Yfsfjylsh, in1.Czybh, in1.Ywzqh, " ", jsfjylsh, OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            var el = XElement.Load(new StringReader(OutputDate.ToString()));
            try
            {
                out1.Czzt = el.Element("CANCELSTAT").Value.ToString();//冲正状态
            }
            catch (Exception e)
            { }
            //out1.Czzt = el.Element("CANCELSTAT").Value.ToString();//冲正状态

            return ret;
        }



        /// <summary>
        /// 83   ydzzplsjxz  总账批量数据下载
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydzzplsjxz(YdZzplsjxz_in in1, YdZzplsjxz_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BatchDownload("83", in1.Czybh, in1.Ywzqh, " ", OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            out1.Xzdz = OutputDate.ToString();

            return ret;
        }



        /// <summary>
        /// 85   ydmxzplsjxz   明细账批量数据下载
        /// </summary>
        /// <param name="in1"></param>
        /// <param name="out1"></param>
        /// <returns></returns> 
        public int ydmxzplsjxz(YdMxzzplsjxz_in in1, YdMxzzplsjxz_out out1)
        {
            StringBuilder OutputDate = new StringBuilder(2048);
            //调用动态库
            int ret = BatchDownload("85", in1.Czybh, in1.Ywzqh, " ", OutputDate);
            //分解协议

            if (ret != 0)
            {
                out1.ErrorMessage = "[" + OutputDate.ToString() + "]";
                return ret;
            }
            out1.Xzdz = OutputDate.ToString();

            return ret;
        }
    }
}
