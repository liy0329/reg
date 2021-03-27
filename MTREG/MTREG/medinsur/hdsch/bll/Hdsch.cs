using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdyb.bo;

namespace MTREG.medinsur.hdsch.bll
{
    class Hdsch
    {

        //[DllImport("dblib.dll")]
        //public static extern int comminterface(string ywlx, string rc, StringBuilder cc, string ylzh);

        ///*
        /// <summary>
        /// 模拟函数
        /// </summary>
        /// <param name="ywlx">业务类型</param>
        /// <param name="rc">业务入参</param>
        /// <param name="cc">执行结果(出参)</param>
        /// <param name="ylzh">居民医疗证号</param>
        /// <returns></returns>
        public static int comminterface(string ywlx, string rc, StringBuilder cc, string ylzh)
        {
            //读人员基本信息
            int ret = 0;
            if (ywlx == "AA311010")
            {
                cc.Append("1301047897409|1|86597412500|123456789|4|5||7||9||||||15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|15|47|48|XX");

            }
            //读人员帐户信息
            if (ywlx == "AA311011")
            {
                cc.Append("1301047897|1|2|3|4|5|199208021123|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|XX");
            }
            //读人员基本信息和账户
            if (ywlx == "AA311012")
            {
                cc.Append("1301047897|1|2|3|乐乐|5|20080908122325|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|46|47|48|49|15|3000|1500|53|54|3000|56|57|58|59|60|61|62|63|64|65|66|67|68|69|70|71|72|73|74|75|76|77|78|79|XX");

            }
            //读取人员封锁信息(中心)
            if (ywlx == "AB31KC08")
            {
                cc.Append("0|1|2|3|0|XX");
            }

            //读取诊疗信息
            if (ywlx == "BB31KA03")
            {
                cc.Append("乙类|1|2|3|4|5|6|7|8|9|XX");
                ret = 0;
            }
            //读人员审批信息
            if (ywlx == "BB31KC20")
            {
                cc.Append("1|XX");
            }
            //住院回退
            if (ywlx == "DC311003")
            {
                cc.Append("0|1|2|XX");
            }
            //住院结算
            if (ywlx == "CC311003")
            {
                cc.Append("0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|XX");
            }
            //结算打印
            if (ywlx == "BB310003")
            {

                cc.Append("0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|46|47|48|49|50|51|52|53|54|55|56|XX");
            }
            //门诊结算(预结算)
            if (ywlx == "BC311002")
            {
                cc.Append("465656.00|255655456.00|3.00|4.00|5.00|6.00|7.00|8.00|9.00|10.00|11.00|12.00|13.00|14.00|15.00|16.00|17.00|18.00|19.00|XX");

            }
            //DC311002 门诊结算回退   4
            if (ywlx == "DC311002")
            {
                cc.Append("0|1|2|XX");
            }
            //BB31BB31TSXXSPXX 门诊已审批过的特殊病 5
            if (ywlx == "BB31SPXX")
            {
                cc.Append("bzbm11|冠心病1|bzbm22|糖尿病1|XX");
            }

            //住院结算(预结算)
            if (ywlx == "BC311003")
            {
                cc.Append("0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|XX");
            }

            //生育出院结算
            if (ywlx == "CC511003")
            {
                cc.Append("5000|1|3000|2000|XX");
            }

            //打印生育结算单
            if (ywlx == "BB510002")
            {
                cc.Append("邯郸市医保中心|000888|123456789|邯郸市第二医院|妇科|2|张美丽|000888|2007-11-16 10:23:15|2007-11-28 10:23:15|13|00015852512|123456|人员类别|否|4321.01|1000|2560.44|张海青|2007-11-28 10:23:15|XX");
            }

            //生育出院预结算
            if (ywlx == "BC510001")
            {
                cc.Append("5000|1|3000|2000|XX");
            }
            //封锁信息 （生育）
            if (ywlx == "AB51KC08")
            {
                cc.Append("0|0|0|0|0|XX");
            }
            //门诊结算单打印
            if (ywlx == "BB310002")
            {
                if (ylzh == "0")
                    cc.Append("邯郸市医保中心|123456789|邯郸市第二医院|妇科|张美丽|人员类别|000888|1111|2222|1|2|3|4|5|6|7|8|9|10|100|215.23|80|00015852512|110|4000|1000|张海青|2007-11-28 10:23:15|1|2|3|4|5|6|7|8|XX");
                else
                    cc.Append("邯郸市医保中心|123456789|邯郸市第二医院|妇科|张美丽|人员类别|000888|1111|2222|1|2|3|4|5|6|7|8|9|10|100|215.23|80|00015852512|110|4000|1000|张海青|2007-11-28 10:23:15|1|2|3|4|XX");
            }
            // 住院结算单打印
            if (ywlx == "BB310003")
            {
                if (ylzh == "0")
                    cc.Append("邯郸市医保中心|000888|123456789|邯郸市第二医院|妇科|2|张美丽|000888|2007-11-16 10:23:15|2007-11-28 10:23:15|13|00123456|123567|人员类别|否|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|100|200|4000|1000|200|2560.44|张海青|2007-11-28 10:23:15|XX");
                else

                    cc.Append("邯郸市医保中心|000888|123456789|邯郸市第二医院|妇科|2|张美丽|000888|2007-11-16 10:23:15|2007-11-28 10:23:15|13|00123456|123567|人员类别|否|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|100|200|4000|1000|200|2560.44|张海青|2007-11-28 10:23:15|57|58|59|60|61|62|63|64|65|66|67|68|69|XX");
            }
            //门诊结算单打印
            if (ywlx == "BB31KA04")
            {
                cc.Append("乙类|112|335|665|XX");
            }
            //门诊结算单
            if (ywlx == "CC311002")
            {
                cc.Append("'100'|20|30|40|50|60|70|80|10|20|30|40|10|2|3|5|6|1|XX");
            }
            //BB31SPXX 门诊已审批过的慢性病 5
            if (ywlx == "BB31SPXX")
            {
                cc.Append("bzbm1|冠心病|bzbm2|糖尿病|XX");
            }

            //读取药品信息
            if (ywlx == "BB31KA02")
            {
                cc.Append("甲类|1|住院自付比例|药品最高限价（如果为0或空，则表示没有限价） |费用类别（西药、中草药等）|0|限制性用药说明|XX");
            }
            //读疾病药品对照信息
            if (ywlx == "BB31ZK06")
            {
                cc.Append("1|XX");
            }
            //读取生育药品信息
            if (ywlx == "BB51MA02")
            {
                cc.Append("甲类|1|住院自付比例|药品最高限价|费用类别（西药、中草药等）|XX");
            }
            //读取生育诊疗信息
            if (ywlx == "BB51MA03")
            {
                cc.Append("甲类|1|住院自付比例| 特殊诊疗标志|特殊诊疗限价|门诊费用类别（检查费、床位费等）| 住院费用类别（检查费、床位费等）|XX");
            }
            //读取生育申报信息
            if (ywlx == "BB51MC01")
            {
                cc.Append("生育流水号|经办时间|审批状态|XX");
            }
            //读取生育申报信息
            if (ywlx == "BB51MC01")
            {
                cc.Append("生育流水号|经办时间|审批状态|XX");
            }
            //传输数据
            if (ywlx == "BB310001")
            {
                cc.Append("生育流水号|经办时间|审批状态|XX");
            }
            //读取扣除先负担后金额
            if (ywlx == "BB310004")
            {
                cc.Append("100|药品等级|费用类别|自付比例|XX");
            }
            return ret;
        }
        // */
        /// <summary>
        /// 1,读人员基本信息
        /// </summary>
        /// <param name="dryjbxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dryjbxx(Dryjbxx_out dryjbxx_out, string jmylzh)
        {
            string opt_type = "AA311010";
            //StringBuilder returnMsg = new StringBuilder();
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            string in_info = "";
            int opstat = comminterface(opt_type, in_info, returnMsg, jmylzh);
            string ret = returnMsg.ToString();//returnMsg.toString();

            if (opstat != 0)
            {
                dryjbxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];

            if (endflag == "XX")
            {
                dryjbxx_out.Grbh = retdata[0];      //个人编号
                dryjbxx_out.Sfzh = retdata[1];      //身份证号
                dryjbxx_out.Dwbh = retdata[2];      //单位编号
                dryjbxx_out.Ickh = retdata[3];      //IC卡号
                dryjbxx_out.Xm = retdata[4];        //姓名
                dryjbxx_out.Xb = retdata[5];     //性别
                dryjbxx_out.Csrq = retdata[6];   //出生日期
                dryjbxx_out.Rylb = retdata[7];   //人员类别
                dryjbxx_out.Cbrq = retdata[8];   //参保日期
                dryjbxx_out.Ryzt = retdata[9];    //人员状态
                dryjbxx_out.Bgrq = retdata[10];     //变更日期
                dryjbxx_out.Ddyy1 = retdata[11]; //定点医院1
                dryjbxx_out.Ddyy2 = retdata[12];  //定点医院2
                dryjbxx_out.Ddyy3 = retdata[13];  //定点医院3
                dryjbxx_out.Ddyy4 = retdata[14];  //定点医院4
                dryjbxx_out.Ddyy5 = retdata[15];    //定点医院5
                dryjbxx_out.Cyrq = retdata[16];   //出院日期
                dryjbxx_out.Zyzt = retdata[17]; //住院状态
                dryjbxx_out.Ylzd1 = retdata[18];  //预留字段
                dryjbxx_out.Ylzd2 = retdata[19];  //预留字段
                dryjbxx_out.Ylzd3 = retdata[20];     //预留字段
                dryjbxx_out.Qh = retdata[21];//区号
                dryjbxx_out.Dwlx = retdata[22];  //单位类型
                dryjbxx_out.Ylzd4 = retdata[23];  //预留字段
                dryjbxx_out.Gwy = retdata[24];   //公务员
                dryjbxx_out.Jfys = retdata[25];   //缴费月数
                dryjbxx_out.Zwjb = retdata[26]; //职务级别|
                dryjbxx_out.Ddyym1 = retdata[27]; //定点医院名1|
                dryjbxx_out.Ddyym2 = retdata[28]; //定点医院名2|
                dryjbxx_out.Ddyym3 = retdata[29]; //定点医院名3|
                dryjbxx_out.Mxbyy1 = retdata[30]; //慢性病医院1|
                dryjbxx_out.Mxbyy2 = retdata[31]; //慢性病医院2|
                dryjbxx_out.Mxbyy3 = retdata[32]; //慢性病医院3|
                dryjbxx_out.Mxbyy4 = retdata[33]; //慢性病医院4|
                dryjbxx_out.Mxbyy5 = retdata[34]; //慢性病医院5|
                dryjbxx_out.Ddyym4 = retdata[35]; //定点医院名4|
                dryjbxx_out.Ddyym5 = retdata[36];   //定点医院名5|
                dryjbxx_out.Lybbh = retdata[37]; //老医保编号|
                dryjbxx_out.Ylzd5 = retdata[38];   //预留字段|
                dryjbxx_out.Xzjb = retdata[39];  //行政级别|
                dryjbxx_out.Ylzd6 = retdata[40];  //预留字段|
                dryjbxx_out.Ylzd7 = retdata[41]; //预留字段|
                dryjbxx_out.Lhjybz = retdata[42]; //灵活就业标志
                dryjbxx_out.Ljkh = retdata[43];  //逻辑卡号
                dryjbxx_out.Ylzd8 = retdata[44]; //预留字段
                dryjbxx_out.Sfjcry = retdata[45];  //是否基残人员
                dryjbxx_out.Grid = retdata[46];   //个人ID
                dryjbxx_out.Dwid = retdata[47]; //单位ID
                dryjbxx_out.Cjgzrq = retdata[48];//参加工作日期
            }
            else
            {
                opstat = -1;
                dryjbxx_out.Message = ret + "[读人员基本信息(dryjbxx)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 2,读人员账户信息
        /// </summary>
        /// <param name="dryzhxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dryzhxx(Dryzhxx_out dryzhxx_out, string jmylzh)
        {
            string opt_type = "AA311011";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, "", returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dryzhxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];

            if (endflag == "XX")
            {
                dryzhxx_out.Nd = retdata[0];           //年度
                dryzhxx_out.Lnjz = retdata[1];         //历年结转
                dryzhxx_out.Bnzr = retdata[2];         //本年注入
                dryzhxx_out.Sxsj = retdata[3];         //刷新时间
                dryzhxx_out.Fyhj = retdata[4];         //费用合计
                dryzhxx_out.Zycs = retdata[5];          //住院次数
                dryzhxx_out.Zhzc = retdata[6];          //帐户支出
                dryzhxx_out.Tczc = retdata[7];          //统筹支出
                dryzhxx_out.Grzf = retdata[8];          //个人支付
                dryzhxx_out.Zf = retdata[9];            //自费（用做符合基本医疗累计）
                dryzhxx_out.Jzjlj = retdata[10];        //结转金累计
                dryzhxx_out.Zytc = retdata[11];         //住院统筹
                dryzhxx_out.Mzdbtc = retdata[12];     //大病统筹支付累计
                dryzhxx_out.Mztstclj = retdata[13];     //门诊特殊统筹累计
                dryzhxx_out.Mztsjbqfbzlj = retdata[14]; //门诊特殊疾病起付标准累计
                dryzhxx_out.Jtbclj = retdata[15];       //家庭病床累计
                dryzhxx_out.Fhjbyllj = retdata[16];     //符合基本医疗累计
                dryzhxx_out.Jrtclj = retdata[17];       //进入统筹累计
                dryzhxx_out.Ylzd = retdata[18];        //预留字段
                dryzhxx_out.Gwytclj = retdata[19];      //公务员统筹累计
                dryzhxx_out.Ylzd2 = retdata[20];        //预留字段
                dryzhxx_out.Mzmxbtczflj = retdata[21];  //门诊慢性病统筹支付累计
                dryzhxx_out.Ylzd3 = retdata[22];        //预留字段
                dryzhxx_out.Zyfhjbyl = retdata[23];     //住院符合基本医疗
                dryzhxx_out.Mxbqfbz = retdata[24];      //慢性病起付标准
                dryzhxx_out.Mxbfhjbyl = retdata[25];    //慢性病符合基本医疗
                dryzhxx_out.Dxjctclj = retdata[26];     //大型检查统筹累计
                dryzhxx_out.Dxjcfhjbyl = retdata[27];   //大型检查符合基本医疗
                dryzhxx_out.Mztsbfhjbyl = retdata[28];    //门诊特殊病符合基本医疗
                dryzhxx_out.Zwmztclj = retdata[29];     //转外门诊统筹累计
                dryzhxx_out.Zwmzfhjbyl = retdata[30];   //转外门诊符合基本医疗|XX
            }
            else
            {
                opstat = -1;
                dryzhxx_out.Message = ret + "[读人员账户信息(dryzhxx)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 3,读人员基本信息和账户
        /// </summary>
        /// <param name="dryjbxxzhxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dryjbxxzhxx(Dryjbxxhzh_out dryjbxxzhxx_out, string jmylzh)
        {
            string opt_type = "AA311012";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, "", returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dryjbxxzhxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dryjbxxzhxx_out.Grbh = retdata[0];      //个人编号
                dryjbxxzhxx_out.Sfzh = retdata[1];      //身份证号
                dryjbxxzhxx_out.Dwbh = retdata[2];      //单位编号
                dryjbxxzhxx_out.Ickh = retdata[3];      //IC卡号
                dryjbxxzhxx_out.Xm = retdata[4];        //姓名
                dryjbxxzhxx_out.Xb = retdata[5];     //性别
                dryjbxxzhxx_out.Csrq = retdata[6];   //出生日期
                dryjbxxzhxx_out.Rylb = retdata[7];   //人员类别
                dryjbxxzhxx_out.Cbrq = retdata[8];   //参保日期
                dryjbxxzhxx_out.Ryzt = retdata[9];    //人员状态
                dryjbxxzhxx_out.Bgrq = retdata[10];     //变更日期
                dryjbxxzhxx_out.Ddyy1 = retdata[11]; //定点医院1
                dryjbxxzhxx_out.Ddyy2 = retdata[12];  //定点医院2
                dryjbxxzhxx_out.Ddyy3 = retdata[13];  //定点医院3
                dryjbxxzhxx_out.Ddyy4 = retdata[14];  //定点医院4
                dryjbxxzhxx_out.Ddyy5 = retdata[15];    //定点医院5
                dryjbxxzhxx_out.Cyrq = retdata[16];   //出院日期
                dryjbxxzhxx_out.Zyzt = retdata[17]; //住院状态
                dryjbxxzhxx_out.Ylzd1 = retdata[18];  //预留字段
                dryjbxxzhxx_out.Ylzd2 = retdata[19];  //预留字段
                dryjbxxzhxx_out.Ylzd3 = retdata[20];     //预留字段
                dryjbxxzhxx_out.Qh = retdata[21];//区号
                dryjbxxzhxx_out.Dwlx = retdata[22];  //单位类型
                dryjbxxzhxx_out.Ylzd4 = retdata[23];  //预留字段
                dryjbxxzhxx_out.Gwy = retdata[24];   //公务员
                dryjbxxzhxx_out.Jfys = retdata[25];   //缴费月数
                dryjbxxzhxx_out.Zwjb = retdata[26]; //职务级别|
                dryjbxxzhxx_out.Ddyym1 = retdata[27]; //定点医院名1|
                dryjbxxzhxx_out.Ddyym2 = retdata[28]; //定点医院名2|
                dryjbxxzhxx_out.Ddyym3 = retdata[29]; //定点医院名3|
                dryjbxxzhxx_out.Mxbyy1 = retdata[30]; //慢性病医院1|
                dryjbxxzhxx_out.Mxbyy2 = retdata[31]; //慢性病医院2|
                dryjbxxzhxx_out.Mxbyy3 = retdata[32]; //慢性病医院3|
                dryjbxxzhxx_out.Mxbyy4 = retdata[33]; //慢性病医院4|
                dryjbxxzhxx_out.Mxbyy5 = retdata[34]; //慢性病医院5|
                dryjbxxzhxx_out.Ddyym4 = retdata[35]; //定点医院名4|
                dryjbxxzhxx_out.Ddyym5 = retdata[36];   //定点医院名5|
                dryjbxxzhxx_out.Lybbh = retdata[37]; //老医保编号|
                dryjbxxzhxx_out.Dwmc = retdata[38];   //预留字段|//改成单位名称
                dryjbxxzhxx_out.Xzjb = retdata[39];  //行政级别|
                dryjbxxzhxx_out.Ylzd6 = retdata[40];  //预留字段|
                dryjbxxzhxx_out.Ylzd7 = retdata[41]; //预留字段|
                dryjbxxzhxx_out.Lhjybz = retdata[42]; //灵活就业标志
                dryjbxxzhxx_out.Ljkh = retdata[43];  //逻辑卡号
                dryjbxxzhxx_out.Ylzd8 = retdata[44]; //预留字段
                dryjbxxzhxx_out.Sfjcry = retdata[45];  //是否基残人员
                dryjbxxzhxx_out.Grid = retdata[46];   //个人ID
                dryjbxxzhxx_out.Dwid = retdata[47]; //单位ID
                dryjbxxzhxx_out.Cjgzrq = retdata[48];//参加工作日期

                dryjbxxzhxx_out.ZhNd = retdata[49];           //年度
                dryjbxxzhxx_out.ZhLnjz = retdata[50];         //历年结转
                dryjbxxzhxx_out.ZhBnzr = retdata[51];         //本年注入
                dryjbxxzhxx_out.ZhSxsj = retdata[52];         //刷新时间
                dryjbxxzhxx_out.ZhFyhj = retdata[53];         //费用合计
                dryjbxxzhxx_out.ZhZycs = retdata[54];          //住院次数
                dryjbxxzhxx_out.ZhZhzc = retdata[55];          //帐户支出
                dryjbxxzhxx_out.ZhTczc = retdata[56];          //统筹支出
                dryjbxxzhxx_out.ZhGrzf = retdata[57];          //个人支付
                dryjbxxzhxx_out.ZhZf = retdata[58];            //自费（用做符合基本医疗累计）
                dryjbxxzhxx_out.ZhJzjlj = retdata[59];        //结转金累计
                dryjbxxzhxx_out.ZhZytc = retdata[60];         //住院统筹
                dryjbxxzhxx_out.ZhMzdbtc = retdata[61];     //大病统筹支付累计
                dryjbxxzhxx_out.ZhMztstclj = retdata[62];     //门诊特殊统筹累计
                dryjbxxzhxx_out.ZhMztsjbqfbzlj = retdata[63]; //门诊特殊疾病起付标准累计
                dryjbxxzhxx_out.ZhJtbclj = retdata[64];       //家庭病床累计
                dryjbxxzhxx_out.ZhFhjbyllj = retdata[65];     //符合基本医疗累计
                dryjbxxzhxx_out.ZhJrtclj = retdata[66];       //进入统筹累计
                dryjbxxzhxx_out.ZhYlzd = retdata[67];        //预留字段
                dryjbxxzhxx_out.ZhGwytclj = retdata[68];      //公务员统筹累计
                dryjbxxzhxx_out.ZhYlzd2 = retdata[69];        //预留字段
                dryjbxxzhxx_out.ZhMzmxbtczflj = retdata[70];  //门诊慢性病统筹支付累计
                dryjbxxzhxx_out.ZhYlzd3 = retdata[71];        //预留字段
                dryjbxxzhxx_out.ZhZyfhjbyl = retdata[72];     //住院符合基本医疗
                dryjbxxzhxx_out.ZhMxbqfbz = retdata[73];      //慢性病起付标准
                dryjbxxzhxx_out.ZhMxbfhjbyl = retdata[74];    //慢性病符合基本医疗
                dryjbxxzhxx_out.ZhDxjctclj = retdata[75];     //大型检查统筹累计
                dryjbxxzhxx_out.ZhDxjcfhjbyl = retdata[76];   //大型检查符合基本医疗
                dryjbxxzhxx_out.ZhMztsbfhjbyl = retdata[77];    //门诊特殊病符合基本医疗
                dryjbxxzhxx_out.ZhZwmztclj = retdata[78];     //转外门诊统筹累计
                dryjbxxzhxx_out.ZhZwmzfhjbyl = retdata[79];   //转外门诊符合基本医疗|XX
            }
            else
            {
                opstat = -1;
                dryjbxxzhxx_out.Message = ret + "[读人员基本信息和账户(dryjbxxzhxx)]协议校验错误!";
            }
            //SplitRecover(retdata);
            return opstat;
        }

         /// <summary>
        /// 4,读人员封锁信息  【入参】人员基本信息  【出参】读人员封锁信息_out
         /// </summary>
         /// <param name="ryxx"></param>
         /// <param name="dqryfsxx_out"></param>
         /// <param name="jmylzh"></param>
         /// <returns></returns>       
        public int dqryfsxx(string ryxx, Dqryfsxx_out dqryfsxx_out, string jmylzh)
        {
            string opt_type = "AB31KC08";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, ryxx, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqryfsxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqryfsxx_out.Fsbz = retdata[0];
                dqryfsxx_out.Fskssj = retdata[1];
                dqryfsxx_out.Fsjssj = retdata[2];
                dqryfsxx_out.Fsyy = retdata[3];
                dqryfsxx_out.Fsjb = retdata[4];
            }
            else
            {
                opstat = -1;
                dqryfsxx_out.Message = ret + "[读人员封锁信息(dqryfsxx)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 5,删除错误数据
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sccysj(Sccwsj_in ryxx, string jmylzh)
        {
            string opt_type = "BB310000";
            string opt_parameter = ryxx.Mzzyh + "|" + ryxx.Djh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx.Message = ret;
            }
            return opstat;
        }

        /// <summary>
        /// 6,医保数据传输
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int ybsjcs(Ybsjcs_in ryxx, string jmylzh)
        {
            string opt_type = "BB310001";
            string opt_parameter = ryxx.Grbh + "|" + ryxx.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx.Message = ret;
            }
            return opstat;
        }
        /// <summary>
        /// 7,读取药品信息    【入参】药品编码（his 内码） 【出参】 药品信息
        /// </summary>
        /// <param name="dqypxx"></param>
        /// <param name="ypbm"></param>
        /// <param name="another"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqypxx(Dqypxx_out dqypxx, string ypbm, int another, string jmylzh)
        {
            string opt_type = "BB31KA02";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, ypbm, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqypxx.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');

            //未发现HIS内码对应编码

            string str_nofind = retdata[1];
            if (str_nofind == "XX")
            {
                dqypxx.Message = ret;
                return opstat;
            }
            //正常协议
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqypxx.Fydj = retdata[0];     //费用等级（甲类或乙类或丙类）|
                dqypxx.Mzzfbl = retdata[1];   //门诊自付比例|
                dqypxx.Zyzfbl = retdata[2];   //住院自付比例|
                dqypxx.Ypzgxj = retdata[3];   //药品最高限价（如果为0或空，则表示没有限价） |
                dqypxx.Fylb = retdata[4];     //费用类别（西药、中草药等）|
                dqypxx.Xzxyybz = retdata[5];  //限制性用药标志|
                dqypxx.Xzxyysm = retdata[6];  //限制性用药说明|XX
            }
            else
            {
                opstat = -1;
                dqypxx.Message = ret + "[读取药品信息(dqypxx)]协议校验错误!";
            }
            return opstat;
        }
                 
        /// <summary>
        /// 8,读取诊疗信息  【入参】诊疗编码（his 内码） 【出参】 诊疗信息
        /// </summary>
        /// <param name="zlbm"></param>
        /// <param name="dqzlxx_out"></param>
        /// <param name="another"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqzlxx(string zlbm, Dqzlxx_out dqzlxx_out, int another, string jmylzh)
        {
            string opt_type = "BB31KA03";
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, zlbm, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqzlxx_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');

            //未发现HIS内码对应编码

            string str_nofind = retdata[1];
            if (str_nofind == "XX")
            {
                dqzlxx_out.Message = ret;
                return opstat;
            }
            //正常协议
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqzlxx_out.Fydj = retdata[0];
                dqzlxx_out.Mzzfbl = retdata[1];
                dqzlxx_out.Zyzfbl = retdata[2];
                dqzlxx_out.Zgxj = retdata[3];
                dqzlxx_out.Xjbz = retdata[4];
                dqzlxx_out.Tszlbz = retdata[5];
                dqzlxx_out.Tszlxj = retdata[6];
                dqzlxx_out.Mzfylb = retdata[7];
                dqzlxx_out.Zyfylb = retdata[8];
                dqzlxx_out.Tnzhclbz = retdata[9];
            }
            else
            {
                opstat = -1;
                dqzlxx_out.Message = ret + "[读取诊疗信息(dqzlxx)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 读取服务设施信息   【入参】人员基本信息（生育）his内码  【出参】  读取服务设施信息
        /// </summary>
        /// <param name="fwssbm"></param>
        /// <param name="dqfwssxx_out"></param>
        /// <param name="another"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqfwssxx(string fwssbm, Dqfwssxx_out dqfwssxx_out, int another, string jmylzh)
        {
            string opt_type = "BB31KA04";
            //服务设施编码（His内码）
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, fwssbm, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqfwssxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');

            //未发现HIS内码对应编码

            string str_nofind = retdata[1];
            if (str_nofind == "XX")
            {
                dqfwssxx_out.Message = retdata[0];
                return opstat;
            }

            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqfwssxx_out.Fydj = retdata[0]; //费用等级（甲类或乙类或丙类）|
                dqfwssxx_out.Fylb = retdata[1]; //费用类别|
                dqfwssxx_out.Bdjg = retdata[2]; //本地价格|
                dqfwssxx_out.Zxje = retdata[3]; //中心价格
            }
            else
            {
                opstat = -1;
                dqfwssxx_out.Message = ret + "[读取服务设施信息(dqfwssxx)]协议校验错误!";
            }
            return opstat;

        }          
        /// <summary>
        /// 9,读人员审批信息   【入参】人员基本信息 【出参】审批标志
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="dryspxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqryspxx(Dryspxx_in ryxx, Dryspxx_out dryspxx_out, string jmylzh)
        {
            string opt_type = "BB31KC20";
            string opt_parameter = ryxx.Grbh + "|" + ryxx.Splb + "|" + ryxx.Jbbm;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dryspxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');

            //或者用字符串常量
            string endflag = retdata[1];
            if (endflag == "XX")
            {
                dryspxx_out.Spbz = retdata[0];
            }
            else
            {
                opstat = -1;
                dryspxx_out.Message = ret + "[读人员审批信息(dqryspxx)]协议校验错误!";
            }
            return opstat;
        }
         
        /// <summary>
        ///  10,入院登记   【入参】人员基本信息 【出参】无
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int rydj(Rydj_in ryxx, string jmylzh)
        {
            string opt_type = "CC311001";
            string opt_parameter = ryxx.Grbh + "|" + ryxx.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx.Message = ret;
            }
            return opstat;
        }
          
        /// <summary>
        /// 11,入院登记_回退   【入参】人员基本信息 【出参】无
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int rydj_ht(Rydj_in ryxx, string jmylzh)
        {
            string opt_type = "DC311001";
            string opt_parameter = ryxx.Grbh + "|" + ryxx.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx.Message = ret;
            }
            return opstat;
        }
         /// <summary>
        ///  12,住院结算_回退   【入参】人员基本信息 【出参】住院结算 金额
         /// </summary>
         /// <param name="ryxx_2_in"></param>
         /// <param name="zyjs_ht_out"></param>
         /// <param name="jmylzh"></param>
         /// <returns></returns>
        public int zyjs_ht(Zyjsht_in ryxx_2_in, Zyjsht_out zyjs_ht_out, string jmylzh)
        {
            string opt_type = "DC311003";
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                zyjs_ht_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                zyjs_ht_out.Ylfyze = retdata[0];
                zyjs_ht_out.Bcxjzfje = retdata[1];
                zyjs_ht_out.Jshickye = retdata[2];
            }
            else
            {
                opstat = -1;
                zyjs_ht_out.Message = ret + "[住院结算_回退(zyjs_ht)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 13,住院结算   【入参】人员基本信息 【出参】住院结算
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="zyjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns> 
        public int zyjs(Zyjs_in ryxx_2_in, Zyjs_out zyjs_out, string jmylzh)
        {
            string opt_type = "CC311003";
            //个人编号 门诊住院号，医疗类别，单据号，经办人，帐户支付金额
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Yllb + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr + "|" + ryxx_2_in.Zffs + "|" + ryxx_2_in.Zhzfje;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                zyjs_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                zyjs_out.Ylfze = retdata[0];			//医疗费总额
                zyjs_out.Ybwzfje = retdata[1];		//本次医保外自费金额（自费类费用）
                zyjs_out.Ylzfje = retdata[2];		//本次乙类自费金额
                zyjs_out.Tjzfje = retdata[3];		//本次特检自付金额
                zyjs_out.Tjtczfje = retdata[4];		//本次特检统筹支付金额
                zyjs_out.Tzzfje = retdata[5];		//本次特治自付金额
                zyjs_out.Tztczfje = retdata[6];		//本次特治统筹支付金额
                zyjs_out.Qfbzzfje = retdata[7];		//本次起付标准自付金额
                zyjs_out.Fdzfje = retdata[8];		//本次分段自付金额
                zyjs_out.Cgtcfdxzfje = retdata[9];         //本次超过统筹封顶线个人自付金额
                zyjs_out.Lcljje = retdata[10];	        //历次符合基本医疗保险累计金额
                zyjs_out.Bcfyje = retdata[11];	        //本次符合基本医疗保险费用金额
                zyjs_out.Ylzd = retdata[12];		//预留字段
                zyjs_out.Bctcfyje = retdata[13];		//本次进入统筹费用金额
                zyjs_out.Bczhzfje = retdata[14];		//本次帐户支付金额
                zyjs_out.Bctczfje = retdata[15];		//本次统筹支付金额
                zyjs_out.Bcxjzfje = retdata[16];		//本次现金支付金额
                zyjs_out.Bcgwybzzcje = retdata[17];		//本次公务员补助支出金额
                zyjs_out.Jshickye = retdata[18];		//结算后IC卡余额
                zyjs_out.Bcqfxbz = retdata[19];			//本次起付线标准
                zyjs_out.Bczhyzf = retdata[20];			//本次帐户应支付
                zyjs_out.Bnzycs = retdata[21];			//本年住院次数
                zyjs_out.Bcjrdbbf = retdata[22];		//本次进入大病部分
                zyjs_out.Bcdbzfje = retdata[23];		//本次大病支付金额
                zyjs_out.Bccgdbfdx = retdata[24];		//本次超过大病封顶线
                zyjs_out.Bnlcdbzflj = retdata[25];            //本年历次大病支付累计
            }
            else
            {
                opstat = -1;
                zyjs_out.Message = ret + "[住院结算(zyjs)]协议校验错误!";
            }
            return opstat;
        }


        //---------------------------------------------------------------------------
        /// <summary>
        /// 14,住院结算单打印  【入参】人员基本信息 【出参】住院结算单打印
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="zyjsddy_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int zyjsddy(Zyjsdy_in ryxx_2_in, Zyjsddy_out zyjsddy_out, string jmylzh)
        {
            string opt_type = "BB310003";
            //个人编号|门诊住院号|单据号|经办人
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                zyjsddy_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                zyjsddy_out.Ybzxmc = retdata[0];//医保中心名称|
                zyjsddy_out.Yyzyh = retdata[1];//医院住院号|
                zyjsddy_out.Djh = retdata[2];//单据号|
                zyjsddy_out.Ddyymc = retdata[3];//定点医院名称|
                zyjsddy_out.Ks = retdata[4];//科室|
                zyjsddy_out.Cycs = retdata[5];//出院次数|
                zyjsddy_out.Hzxm = retdata[6];//患者姓名|
                zyjsddy_out.Zyh = retdata[7];//住院号|
                zyjsddy_out.Ryrq = retdata[8];// retdata[8];//入院日期|
                zyjsddy_out.Cyrq = retdata[9];// retdata[9];//出院日期|
                zyjsddy_out.Zyts = retdata[10];//住院天数|
                zyjsddy_out.Grbh = retdata[11];//个人编号|
                zyjsddy_out.Ickh = retdata[12];//IC卡号|
                zyjsddy_out.Rylb = retdata[13];//人员类别|
                zyjsddy_out.Sfgwy = retdata[14];//是否公务员|
                zyjsddy_out.Cwf = retdata[15];//床位费|
                zyjsddy_out.Xy = retdata[16];//西药|
                zyjsddy_out.Zchengy = retdata[17];//中成药|
                zyjsddy_out.Zcaoy = retdata[18];//中草药|
                zyjsddy_out.Hy = retdata[19];//化验|
                zyjsddy_out.Jc = retdata[20];//检查|
                zyjsddy_out.Zl = retdata[21];//治疗|
                zyjsddy_out.Fs = retdata[22];//放射|
                zyjsddy_out.Ss = retdata[23];//手术|
                zyjsddy_out.Xf = retdata[24];//血费|
                zyjsddy_out.Sy = retdata[25];//输氧|
                zyjsddy_out.Ln = retdata[26];//冷暖|
                zyjsddy_out.Qt = retdata[27];//其他|
                zyjsddy_out.Hj = retdata[28];//合计|
                zyjsddy_out.Ssje = retdata[29];//实收金额|
                zyjsddy_out.Jlyf = retdata[30];//甲类药费|
                zyjsddy_out.Jlzl = retdata[31];//甲类诊疗|
                zyjsddy_out.Bzcf = retdata[32];//标准床费|
                zyjsddy_out.Ylyf = retdata[33];//乙类药费|
                zyjsddy_out.Ylzl = retdata[34];//乙类诊疗|
                zyjsddy_out.Zfyf = retdata[35];//自费药费|
                zyjsddy_out.Zfzl = retdata[36];//自费诊疗|
                zyjsddy_out.Cbcf = retdata[37];//超标床费|
                zyjsddy_out.Qfbz = retdata[38];//起付标准|
                zyjsddy_out.Qtzf = retdata[39];//其他自费|
                zyjsddy_out.Jrtcjjje = retdata[40];//进入统筹基金金额|
                zyjsddy_out.Tcjjzf = retdata[41];//统筹基金支付|
                zyjsddy_out.Bndtcjjzf = retdata[42];//本年度统筹基金支付|
                zyjsddy_out.Jrdbjjje = retdata[43];//进入大病基金金额|
                zyjsddy_out.Dbjjzf = retdata[44];//大病基金支付|
                zyjsddy_out.Bnddbjjzf = retdata[45];//本年度大病基金支付|
                zyjsddy_out.Jbylzfje = retdata[46];//基本医疗自付金额|
                zyjsddy_out.Gwyjjzf = retdata[47];//公务员基金支付|
                zyjsddy_out.Bcjshfdye = retdata[48];//本次结算后负担余额|
                zyjsddy_out.Zfzfjehj = retdata[49];//自付自费金额合计|
                zyjsddy_out.Qzgrzhzf = retdata[50];//其中个人账户支付|
                zyjsddy_out.Bczfhgrzhye = retdata[51];//本次支付后个人账户余额|
                zyjsddy_out.Grzfxj = retdata[52];//个人支付现金|
                zyjsddy_out.Yj = retdata[53];//押金|
                zyjsddy_out.Thbxj = retdata[54];//退或补现金|
                zyjsddy_out.Jbr = retdata[55];//经办人|
                zyjsddy_out.Jsrq = retdata[56];//结算日期
                zyjsddy_out.Ptxmfhjbyl = retdata[57];//普通项目符合基本医疗
                zyjsddy_out.Ycxclbxje = retdata[58];//一次性材料报销金额
                zyjsddy_out.Ycxclfhjbyl = retdata[59];//一次性材料符合基本医疗
                zyjsddy_out.Tcdyd = retdata[60];//统筹第一段
                zyjsddy_out.Tcded = retdata[61];//统筹第2段
                zyjsddy_out.Tcdsd = retdata[62];//统筹第3段
                zyjsddy_out.Tcdsid = retdata[63];//统筹第4段
                zyjsddy_out.Tcdwd = retdata[64];//统筹第5段
                zyjsddy_out.Tcdydzfje = retdata[65];//统筹1段自付金额
                zyjsddy_out.Tcdedzfje = retdata[66];//统筹2段自付金额
                zyjsddy_out.Tcdsdzfje = retdata[67];//统筹3段自付金额
                zyjsddy_out.Tcdsidzfje = retdata[68];//统筹4段自付金额
                zyjsddy_out.Tcdwdzfje = retdata[69];//统筹5段自付金额
            }
            else
            {
                opstat = -1;
                zyjsddy_out.Message = ret + "[住院结算单打印(zyjsddy)]协议校验错误!";
            }
            return opstat;

        }
        
        /// <summary>
        /// 15,读人员已审批过的慢性病信息
        /// </summary>
        /// <param name="grbh"></param>
        /// <param name="dryyspgdmxbxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dryyspgdmxbxx(string grbh, Drymxbxx_out dryyspgdmxbxx_out, string jmylzh)
        {
            string opt_type = "BB31SPXX";
            //个人编号
            string opt_parameter = grbh; ;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dryyspgdmxbxx_out.Message = ret;
                return opstat;
            }

            if (opstat == 0)
            {
                dryyspgdmxbxx_out.Spxx = ret;
                //string[] retdata = ret.Split('|');

                ////或者用字符串常量
                //string endflag = retdata[4];


                //dryyspgdmxbxx_out.Bznm1 = retdata[0];
                //dryyspgdmxbxx_out.Bzmc1 = retdata[1];

                //if (endflag == "XX")
                //{
                //    if (retdata[2] != null && retdata[2] != "")
                //    {
                //        dryyspgdmxbxx_out.Bznm2 = retdata[2];
                //    }
                //    if (retdata[3] != null && retdata[3] != "")
                //    {
                //        dryyspgdmxbxx_out.Bzmc2 = retdata[3];
                //    }
                //}
            }
            else
            {
                opstat = -1;
                dryyspgdmxbxx_out.Message = ret + "[读人员已审批过的慢性病信息(dryyspgdmxbxx)]协议校验错误!";
            }
            return opstat;
        }
        
        /// <summary>
        /// 16,读疾病药品对照信息
        /// </summary>
        /// <param name="djbypdzxx_in"></param>
        /// <param name="djbypdzxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int djbypdzxx(Djbypdzxx_in djbypdzxx_in, Djbypdzxx_out djbypdzxx_out, string jmylzh)
        {
            string opt_type = "BB31ZK06";
            //个人编号
            string opt_parameter = djbypdzxx_in.Jbbm + "|" + djbypdzxx_in.Ypbm;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                djbypdzxx_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                djbypdzxx_out.Dzbz = retdata[0]; //对照标志：0没有对照信息，1有对照信息
            }
            else
            {
                opstat = -1;
                djbypdzxx_out.Message = ret + "[读疾病药品对照信息(djbypdzxx)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        ///  17,门诊结算（预结算）
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="mzjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int mzjs_yjs(Mzjs_in ryxx_2_in, Mzjs_out mzjs_out, string jmylzh)
        {
            string opt_type = "BC311002";
            //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Yllb + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr + "|" + ryxx_2_in.Zffs;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);

            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                mzjs_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');

            //或者用字符串常量
            string endflag = retdata[retdata.Length - 1];


            if (endflag == "XX")
            {
                mzjs_out.Ylfyze = retdata[0];			//医疗费用总额
                mzjs_out.Bcfhje = retdata[1];	                //本次符合基本医疗保险费用金额
                mzjs_out.Bczfje = retdata[2];	        //本次符合基本医疗保险外自费金额
                mzjs_out.Bctjzfje = retdata[3];			//本次特检自付金额
                mzjs_out.Bctjtcje = retdata[4];			//本次特检统筹支付金额
                mzjs_out.Bctzzfje = retdata[5];			//本次特治自付金额
                mzjs_out.Bctztcje = retdata[6];			//本次特治统筹支付金额
                mzjs_out.Bcgrzhzfje = retdata[7];			//本次个人帐户支付金额
                mzjs_out.Bctczfje = retdata[8];			//本次统筹支付金额
                mzjs_out.Bcxjzfje = retdata[9];			//本次现金支付金额
                mzjs_out.Bcgwybzzcje = retdata[10];		        //本次公务员补助支出金额
                mzjs_out.Jshickye = retdata[11]; 			//结算后IC卡余额
                mzjs_out.Bczhyzf = retdata[12];			//本次帐户应支付
                mzjs_out.Bcjrdbbf = retdata[13];			//本次进入大病部分
                mzjs_out.Bcdbzfje = retdata[14];			//本次大病支付金额
                mzjs_out.Bccgdbfdx = retdata[15];			//本次超过大病封顶线
                mzjs_out.Bnlcdbzflj = retdata[16];			//本年历次大病支付累计
                mzjs_out.Bcqfxzfje = retdata[17];           //本次起付线支付金额
                //mzjs_out.Ndzjzlx = retdata[18];             //尿毒症就诊类型
            }
            else
            {
                opstat = -1;
                mzjs_out.Message = ret + "[门诊结算（预结算）(mzjs_yjs)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 18,门诊结算
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="mzjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int mzjs(Mzjs_in ryxx_2_in, Mzjs_out mzjs_out, string jmylzh)
        {
            string opt_type = "CC311002";
            //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Yllb + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr + "|" + ryxx_2_in.Zffs;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);

            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                mzjs_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                mzjs_out.Ylfyze = retdata[0];			//医疗费用总额
                mzjs_out.Bcfhje = retdata[1];	                //本次符合基本医疗保险费用金额
                mzjs_out.Bczfje = retdata[2];	        //本次符合基本医疗保险外自费金额
                mzjs_out.Bctjzfje = retdata[3];			//本次特检自付金额
                mzjs_out.Bctjtcje = retdata[4];			//本次特检统筹支付金额
                mzjs_out.Bctzzfje = retdata[5];			//本次特治自付金额
                mzjs_out.Bctztcje = retdata[6];			//本次特治统筹支付金额
                mzjs_out.Bcgrzhzfje = retdata[7];			//本次个人帐户支付金额
                mzjs_out.Bctczfje = retdata[8];			//本次统筹支付金额
                mzjs_out.Bcxjzfje = retdata[9];			//本次现金支付金额
                mzjs_out.Bcgwybzzcje = retdata[10];		        //本次公务员补助支出金额
                mzjs_out.Jshickye = retdata[11]; 			//结算后IC卡余额
                mzjs_out.Bczhyzf = retdata[12];			//本次帐户应支付
                mzjs_out.Bcjrdbbf = retdata[13];			//本次进入大病部分
                mzjs_out.Bcdbzfje = retdata[14];			//本次大病支付金额
                mzjs_out.Bccgdbfdx = retdata[15];			//本次超过大病封顶线
                mzjs_out.Bnlcdbzflj = retdata[16];			//本年历次大病支付累计
                mzjs_out.Bcqfxzfje = retdata[17];           //本次起付线支付金额
                //mzjs_out.Ndzjzlx = retdata[18];             //尿毒症就诊类型
            }
            else
            {
                opstat = -1;
                mzjs_out.Message = ret + "[门诊结算(mzjs)]协议校验错误!";
            }
            return opstat;
        }
        
        /// <summary>
        /// 19,门诊结算(打印)
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="mzjsdy_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int mzjs_dy(Mzjsdy_in ryxx_2_in, Mzjsddy_out mzjsdy_out, string jmylzh)
        {
            string opt_type = "BB310002";
            //个人编号|门诊住院号|单据号|经办人
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                mzjsdy_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                mzjsdy_out.Ybzxmc = retdata[0];			//医保中心名称
                mzjsdy_out.Sjh = retdata[1];				//收据号
                mzjsdy_out.Ddyljgmc = retdata[2];		        //定点医疗机构名称
                mzjsdy_out.Ks = retdata[3]; 				//科室
                mzjsdy_out.Xm = retdata[4];				//姓名
                mzjsdy_out.Grlb = retdata[5];			        //人员类别
                mzjsdy_out.Grbh = retdata[6];			        //个人编号
                mzjsdy_out.Cfh = retdata[7];				//处方号
                mzjsdy_out.Ickh = retdata[8];			        //IC卡号
                mzjsdy_out.Xy = retdata[9];				//西药
                mzjsdy_out.Zcy = retdata[10];				//中成药
                mzjsdy_out.Cy = retdata[11];				//草药
                mzjsdy_out.Hy = retdata[12];				//化验
                mzjsdy_out.Jc = retdata[13];				//检查
                mzjsdy_out.Fs = retdata[14];				//放射
                mzjsdy_out.Zl = retdata[15];				//治疗
                mzjsdy_out.Ss = retdata[16];				//手术
                mzjsdy_out.Cf = retdata[17];				//床费
                mzjsdy_out.Qt = retdata[18];				//其他
                mzjsdy_out.Ysje = retdata[19];			//应收金额
                mzjsdy_out.Ssje = retdata[20];			//实收金额
                mzjsdy_out.Zfje = retdata[21];			//自付金额
                mzjsdy_out.Grzhzf = retdata[22];			//个人账户支付
                mzjsdy_out.Zhye = retdata[23];		        //本次支付后账户余额
                mzjsdy_out.Gwyzc = retdata[24];			//公务员支出
                mzjsdy_out.Bnzflj = retdata[25];			//本年支付累计
                mzjsdy_out.Sfy = retdata[26];				//收费员
                mzjsdy_out.Dyrq = retdata[27];			//打印日期
                mzjsdy_out.Yllb = retdata[28];//   医疗类别
                mzjsdy_out.Bctczf = retdata[29];//本次统筹支付
                mzjsdy_out.Bnmxbtczflj = retdata[30]; //本年慢性病统筹支付累计
                mzjsdy_out.Bnmztczflj = retdata[31];//本年门诊统筹支付累计
                mzjsdy_out.Bcfhjbyl = retdata[32];//本次符合基本医疗
                //mzjsdy_out.Qfx = retdata[33];//起付线
                //mzjsdy_out.Bcdbzf = retdata[34];//本次大病支付
                //mzjsdy_out.Bcjsqbntclj = retdata[35];//本次结算前本年统筹累计
                //mzjsdy_out.Bcjsqdbzflj = retdata[36];//本次结算前大病支付累计
                //mzjsdy_out.Bccdbzf = retdata[37];// 本次超大病支付
                //mzjsdy_out.Zifujine = retdata[38];//自付金额
                //mzjsdy_out.Zifeijine = retdata[39];//自费金额
                //mzjsdy_out.Bcbxze = retdata[40];//本次报销总额
                //mzjsdy_out.Ndzjzlx = retdata[41];//尿毒症就诊类型|
            }
            else
            {
                opstat = -1;
                mzjsdy_out.Message = ret + "[门诊结算(打印)(mzjs_dy)]协议校验错误!";
            }
            return opstat;
        }          
        /// <summary>
        /// 20,门诊结算_回退   【入参】人员基本信息 【出参】门诊结算 金额 使用的是住院结算回退结构体      
        /// </summary>
        /// <param name="ryxx_in"></param>
        /// <param name="zyjs_ht_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int mzjs_ht(Mzjsht_in ryxx_in, Mzjsht_out zyjs_ht_out, string jmylzh)
        {
            string opt_type = "DC311002";
            string opt_parameter = ryxx_in.Grbh + "|" + ryxx_in.Mzzyh + "|" + ryxx_in.Djh + "|" + ryxx_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                zyjs_ht_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                zyjs_ht_out.Ylfyze = retdata[0];
                zyjs_ht_out.Bcxjzfje = retdata[1];
                zyjs_ht_out.Jshickye = retdata[2];
            }
            else
            {
                opstat = -1;
                zyjs_ht_out.Message = ret + "[门诊结算_回退(mzjs_ht)]协议校验错误!";
            }
            return opstat;
        }

        //21,四舍五入函数
        double round(double value, int dot)
        {
            /*for(int k = 0; k < precision;)
            {
                    origin = origin * 10;
            }
            float result = (float)(int)(origin + 0.5);
            for(int k = 0; k < precision;)
            {
                    result = result / 10;
            }
            return result;
                    char ss[40],ss1[40];

                    double aa;

                    sprintf(ss1,"%s%dlf","%.",dot);

                    if(value>=0)aa=value+0.00000001;//解决C语言的四舍五入问题

                    else aa=value-0.00000001;

                    sprintf(ss,ss1,aa);

                    aa=atof(ss);

                    return aa;  */

            return 0;

        }
        /// <summary>
        ///  22,住院预结算   【入参】人员基本信息 【出参】住院结算
        /// </summary>
        /// <param name="ryxx_2_in"></param>
        /// <param name="zyjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int zy_yjs(Zyjs_in ryxx_2_in, Zyjs_out zyjs_out, string jmylzh)
        {
            string opt_type = "BC311003";
            //个人编号 门诊住院号，医疗类别，单据号，经办人，帐户支付金额
            string opt_parameter = ryxx_2_in.Grbh + "|" + ryxx_2_in.Mzzyh + "|" + ryxx_2_in.Yllb + "|" + ryxx_2_in.Djh + "|" + ryxx_2_in.Jbr + "|" + ryxx_2_in.Zffs + "|" + ryxx_2_in.Zhzfje;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                zyjs_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                zyjs_out.Ylfze = retdata[0];			//医疗费总额
                zyjs_out.Ybwzfje = retdata[1];		//本次医保外自费金额（自费类费用）
                zyjs_out.Ylzfje = retdata[2];		//本次乙类自费金额
                zyjs_out.Tjzfje = retdata[3];		//本次特检自付金额
                zyjs_out.Tjtczfje = retdata[4];		//本次特检统筹支付金额
                zyjs_out.Tzzfje = retdata[5];		//本次特治自付金额
                zyjs_out.Tztczfje = retdata[6];		//本次特治统筹支付金额
                zyjs_out.Qfbzzfje = retdata[7];		//本次起付标准自付金额
                zyjs_out.Fdzfje = retdata[8];		//本次分段自付金额
                zyjs_out.Cgtcfdxzfje = retdata[9];         //本次超过统筹封顶线个人自付金额
                zyjs_out.Lcljje = retdata[10];	        //历次符合基本医疗保险累计金额
                zyjs_out.Bcfyje = retdata[11];	        //本次符合基本医疗保险费用金额
                zyjs_out.Ylzd = retdata[12];		//预留字段
                zyjs_out.Bctcfyje = retdata[13];		//本次进入统筹费用金额
                zyjs_out.Bczhzfje = retdata[14];		//本次帐户支付金额
                zyjs_out.Bctczfje = retdata[15];		//本次统筹支付金额
                zyjs_out.Bcxjzfje = retdata[16];		//本次现金支付金额
                zyjs_out.Bcgwybzzcje = retdata[17];		//本次公务员补助支出金额
                zyjs_out.Jshickye = retdata[18];		//结算后IC卡余额
                zyjs_out.Bcqfxbz = retdata[19];			//本次起付线标准
                zyjs_out.Bczhyzf = retdata[20];			//本次帐户应支付
                zyjs_out.Bnzycs = retdata[21];			//本年住院次数
                zyjs_out.Bcjrdbbf = retdata[22];		//本次进入大病部分
                zyjs_out.Bcdbzfje = retdata[23];		//本次大病支付金额
                zyjs_out.Bccgdbfdx = retdata[24];		//本次超过大病封顶线
                zyjs_out.Bnlcdbzflj = retdata[25];            //本年历次大病支付累计
            }
            else
            {
                opstat = -1;
                zyjs_out.Message = ret + "[住院预结算(zy_yjs)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 读取生育药品信息  【入参】药品编码（his 内码）   【出参】   读取生育药品信息
        /// </summary>
        /// <param name="ypbm"></param>
        /// <param name="dqsyypxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>          
        public int dqsyypxx(string ypbm, Dqsyypxx_out dqsyypxx_out, string jmylzh)
        {
            string opt_type = "BB51MA02";
            string opt_parameter = ypbm;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqsyypxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            String str_nofind = retdata[1];
            if (str_nofind == "XX")
            {
                dqsyypxx_out.Message = retdata[0];
                return opstat;
            }
            //正常协议

            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqsyypxx_out.Fydjdj = retdata[0]; // 费用等级登记（甲类或乙类或丙类）|
                dqsyypxx_out.Mzzfbl = retdata[1]; // 门诊自付比例|
                dqsyypxx_out.Zyzfbl = retdata[2]; // 住院自付比例|
                dqsyypxx_out.Ypzgxj = retdata[3]; // 药品最高限价|
                dqsyypxx_out.Fylb = retdata[4]; // 费用类别（西药、中草药等）|
            }
            else
            {
                opstat = -1;
                dqsyypxx_out.Message = ret + "[读取生育药品信息(dqsyypxx)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 读取生育诊疗信息   【入参】诊疗编码（his 内码）  【出参】  读取生育诊疗信息
        /// </summary>
        /// <param name="zlbm"></param>
        /// <param name="dqsyzlxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqsyzlxx(string zlbm, Dqsyzlxx_out dqsyzlxx_out, string jmylzh)
        {
            string opt_type = "BB51MA03";

            string opt_parameter = zlbm;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, "0");
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dqsyzlxx_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string str_nofind = retdata[1];
            if (str_nofind == "XX")
            {
                dqsyzlxx_out.Message = retdata[0];
                return opstat;
            }
            //正常协议
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqsyzlxx_out.Fydj = retdata[0]; // 费用等级（甲类或乙类或丙类）|
                dqsyzlxx_out.Mzzfbl = retdata[1]; // 门诊自付比例|
                dqsyzlxx_out.Zyzfbl = retdata[2]; // 住院自付比例|
                dqsyzlxx_out.Tszlbz = retdata[3]; // 特殊诊疗标志|
                dqsyzlxx_out.Tszlxj = retdata[4]; // 特殊诊疗限价|
                dqsyzlxx_out.Mzfylb = retdata[5]; // 门诊费用类别（检查费、床位费等）|
                dqsyzlxx_out.Zyfylb = retdata[6]; // 住院费用类别（检查费、床位费等）|
            }
            else
            {
                opstat = -1;
                dqsyzlxx_out.Message = ret + "[读取生育诊疗信息(dqsyzlxx)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 读取生育申报信息   【入参】人员基本信息（生育）  【出参】 读取生育申报信息
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="dqsysbxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqsysbxx(Dqsysbxx_in ryxx_sy_in, Dqsysbxx_out dqsysbxx_out, string jmylzh)
        {
            string opt_type = "BB51MC01";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人|his内码
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                dqsysbxx_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqsysbxx_out.Sylsh = retdata[0]; // 生育流水号|
                dqsysbxx_out.Jbsj = retdata[1]; // 经办时间|
                dqsysbxx_out.Spzt = retdata[2]; //  审批状态|
            }
            else
            {
                opstat = -1;
                dqsysbxx_out.Message = ret + "[读取生育申报信息(dqsysbxx)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 读取单位封锁信息（生育）    【入参】人员基本信息（生育）  【出参】  读取单位封锁信息（生育）
        /// </summary>
        /// <param name="grbh"></param>
        /// <param name="dqdwfsxx_sy_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dqdwfsxx_sy(string grbh, Dqdwfsxxsy_out dqdwfsxx_sy_out, string jmylzh)
        {
            string opt_type = "AB51KC08";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人|his内码
            string opt_parameter = grbh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                dqdwfsxx_sy_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dqdwfsxx_sy_out.Fsbz = retdata[0]; // 封锁标志|
                dqdwfsxx_sy_out.Fskssj = retdata[1]; // 封锁开始时间 |
                dqdwfsxx_sy_out.Fsjssj = retdata[2]; // 封锁结束时间 |
                dqdwfsxx_sy_out.Fsyy = retdata[3]; // 封锁原因 |
                dqdwfsxx_sy_out.Fsjb = retdata[4]; // 封锁级别|
            }
            else
            {
                opstat = -1;
                dqdwfsxx_sy_out.Message = ret + "[读取单位封锁信息（生育）(dqdwfsxx_sy)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 生育数据传输    【入参】人员基本信息（生育）
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sysjcs(Ryxx_in ryxx_sy_in, string jmylzh)
        {
            string opt_type = "BB510001";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人|his内码
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx_sy_in.Message = ret;
            }
            return opstat;
        }
        /// <summary>
        /// 生育入院登记   【入参】人员基本信息（生育）
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int syrydj(Ryxx_in ryxx_sy_in, string jmylzh)
        {
            string opt_type = "CC511001";
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx_sy_in.Message = ret;
            }
            return opstat;
        }
        /// <summary>
        /// 生育入院登记（回退）  【入参】人员基本信息（生育）
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int syrydj_ht(Ryxx_in ryxx_sy_in, string jmylzh)
        {
            string opt_type = "DC511001";
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx_sy_in.Message = ret;
            }
            return opstat;
        }
        /// <summary>
        /// 生育出院结算   【入参】人员基本信息（生育） 【出参】生育出院结算
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="sycyjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sycyjs(Sycyjs_in ryxx_sy_in, Sycyjs_out sycyjs_out, string jmylzh)
        {
            string opt_type = "CC511003";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh + "|" + ryxx_sy_in.Sslb + "|" + ryxx_sy_in.Ylfze + "|" + ryxx_sy_in.Tes + "|" + ryxx_sy_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                sycyjs_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                sycyjs_out.Ylfze = retdata[0]; //医疗费总额|
                sycyjs_out.Syylfdebtxe = retdata[1]; //生育医疗费定额补贴限额 |
                sycyjs_out.Grzf = retdata[2]; //个人自费|
                sycyjs_out.Syylfdebtje = retdata[3]; //生育医疗费定额补贴金额|
            }
            else
            {
                opstat = -1;
                sycyjs_out.Message = ret + "[生育出院结算(sycyjs)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 生育出院预结算   【入参】人员基本信息（生育）  【出参】生育出院预结算
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="sycyjs_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sycyyjs(Sycyjs_in ryxx_sy_in, Sycyjs_out sycyjs_out, string jmylzh)
        {
            string opt_type = "BC510001";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh + "|" + ryxx_sy_in.Sslb + "|" + ryxx_sy_in.Ylfze + "|" + ryxx_sy_in.Tes + "|" + ryxx_sy_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();

            if (opstat != 0)
            {
                sycyjs_out.Message = ret;
                return opstat;
            }
            string[] retdata = ret.Split('|');
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                sycyjs_out.Ylfze = retdata[0]; //医疗费总额|
                sycyjs_out.Syylfdebtxe = retdata[1]; //生育医疗费定额补贴限额 |
                sycyjs_out.Grzf = retdata[2]; //个人自费|
                sycyjs_out.Syylfdebtje = retdata[3]; //生育医疗费定额补贴金额|
            }
            else
            {
                opstat = -1;
                sycyjs_out.Message = ret + "[生育出院预结算(sycyyjs)]协议校验错误!";
            }
            return opstat;
        }
        /// <summary>
        /// 生育退费     【入参】人员基本信息（生育）
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sytf(Sytf_in ryxx_sy_in, string jmylzh)
        {
            string opt_type = "DC511002";
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人|his内码
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh + "|" + ryxx_sy_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx_sy_in.Message = ret;
            }
            return opstat;
        }

        /// <summary>
        /// 打印生育结算单   【入参】人员基本信息（生育）  【出参】  打印生育结算单
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="dysyjsd_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dysyjsd(Dysyjsd_in ryxx_sy_in, Dysyjsd_out dysyjsd_out, string jmylzh)
        {

            string opt_type = "BB510002";
            //个人编号|住院号|经办人
            string opt_parameter = ryxx_sy_in.Grbh + "|" + ryxx_sy_in.Mzzyh + "|" + ryxx_sy_in.Jbr;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dysyjsd_out.Message = ret;
                return opstat;
            }

            string[] retdata = ret.Split('|');

            //或者用字符串常量
            string endflag = retdata[retdata.Length - 1];
            if (endflag == "XX")
            {
                dysyjsd_out.Ybzxmc = retdata[0]; //医保中心名称|
                dysyjsd_out.Yyzyh = retdata[1]; //医院住院号|
                dysyjsd_out.Djh = retdata[2]; //单据号|
                dysyjsd_out.Ddyymc = retdata[3]; //定点医院名称|
                dysyjsd_out.Ks = retdata[4]; //科室|
                dysyjsd_out.Zycs = retdata[5];
                dysyjsd_out.Hzxm = retdata[6]; //患者姓名|
                dysyjsd_out.Zyh = retdata[7]; //住院号|
                dysyjsd_out.Ryrq = retdata[8]; //入院日期|
                dysyjsd_out.Cyrq = retdata[9]; //出院日期|
                dysyjsd_out.Zyts = retdata[10]; //住院天数|
                dysyjsd_out.Grbh = retdata[11]; //个人编号|
                dysyjsd_out.Ickh = retdata[12]; //IC卡号|
                dysyjsd_out.Rylb = retdata[13]; //人员类别|
                dysyjsd_out.Sfgwy = retdata[14]; //是否公务员|
                dysyjsd_out.Ssje = retdata[15]; //实收金额|
                dysyjsd_out.Syylfdebtje = retdata[16]; //生育医疗费定额补贴金额|
                dysyjsd_out.Grzfxj = retdata[17]; //个人支付现金|
                dysyjsd_out.Jbr = retdata[18]; //经办人|
                dysyjsd_out.Jsrq = retdata[19]; //结算日期
                //dysyjsd_out->hj = retdata[19];//合计|
            }
            else
            {
                opstat = -1;
                dysyjsd_out.Message = ret + "[打印生育结算单(dysyjsd)]协议校验错误!";
            }
            return opstat;
        }

        /// <summary>
        /// 23,删除错误数据  (有关生育)  （新添）
        /// </summary>
        /// <param name="ryxx_sy_in"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int sccwsj_sy(Sccwsj_in ryxx_sy_in, string jmylzh)
        {
            string opt_type = "BB310000";
            string opt_parameter = ryxx_sy_in.Mzzyh + "|" + ryxx_sy_in.Djh;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                ryxx_sy_in.Message = ret;
            }
            return opstat;
        }
        /// <summary>
        /// 24 读人员已审批过的特殊病信息
        /// </summary>
        /// <param name="grbh"></param>
        /// <param name="dryyspgdtsbxx_out"></param>
        /// <param name="jmylzh"></param>
        /// <returns></returns>
        public int dryyspgdtsbxx(string grbh, Drymxbxx_out dryyspgdtsbxx_out, string jmylzh)
        {
            string opt_type = "BB31TSXX";
            //个人编号
            string opt_parameter = grbh; ;
            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 1000;
            int opstat = comminterface(opt_type, opt_parameter, returnMsg, jmylzh);
            string ret = returnMsg.ToString();
            if (opstat != 0)
            {
                dryyspgdtsbxx_out.Message = ret;
                return opstat;
            }

            if (opstat == 0)
            {
                string[] retdata = ret.Split('|');

                //或者用字符串常量
                string endflag = retdata[retdata.Length - 1];


                dryyspgdtsbxx_out.Bznm1 = retdata[0];
                dryyspgdtsbxx_out.Bzmc1 = retdata[1];

                if (endflag == "XX")
                {
                    if (retdata[2] != null && retdata[2] != "")
                    {
                        dryyspgdtsbxx_out.Bznm2 = retdata[2];
                    }
                    if (retdata[3] != null && retdata[3] != "")
                    {
                        dryyspgdtsbxx_out.Bzmc2 = retdata[3];
                    }
                }
            }
            else
            {
                opstat = -1;
                dryyspgdtsbxx_out.Message = ret + "[读人员已审批过的特殊病信息(dryyspgdmxbxx)]协议校验错误!";
            }
            return opstat;
        }
    }
}
