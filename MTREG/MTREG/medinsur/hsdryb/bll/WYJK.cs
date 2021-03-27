using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MTREG.medinsur.hsdryb.bo;
using System.Data;
using MTREG.common.bll;
using MTHIS.main.bll;
using MTHIS.common;
using System.IO;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.bll
{
    class WYJK
    {
        /// <summary>
        /// 获取流水号（暂时的）
        /// </summary>
        /// <returns></returns>
        public static string getLsh()
        {
            Random ran = new Random();
            var value = ran.Next(1000, 10000);
            return "131100" + "WYH001" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss") + value;
        }



        [DllImport("hisinterface.dll")]
        public static extern int hisinterface(string inxml,StringBuilder outxml);
        SysWriteLogs sw = new SysWriteLogs();
        public static string YwZqh
        { get; set; }
        /// <summary>
        /// 5.1【1501】操作员签到
        /// </summary>
        /// <param name="common"></param>
        /// <returns></returns>
        public InOutParameter czyqd(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(250);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                    {
                        parameter.BATNO = item["BATNO"].ToString();
                    }
                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1501】操作员签到 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }
        }
        /// <summary>
        ///   5.2【1503】操作员签退
        /// </summary>
        /// <returns></returns>
        public InOutParameter czyqt()
        {
            InOutParameter parameter = new InOutParameter();
            TopParameter common = new TopParameter();
            StringBuilder outResult = new StringBuilder(300);
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = "WYH001";
            common.AKC190 = "";
            common.AKC020 = "";
            common.AKA130 = "";

            common.MSGNO = "1503";

            common.BATNO = YwZqh;
            common.OPERID = "WYH001";
            common.OPERNAME = "WYH001";
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            sw.writeLogs("上传签退数据", Convert.ToDateTime(BillSysBase.currDate()), " XML ==> " + common.InXml(common));
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
            parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
            parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            return parameter;
        }
        /// <summary>
        /// 5.3【1800】获取中心端时间
        /// </summary>
        /// <returns></returns>
        public InOutParameter hqzxdsj()
        {
            InOutParameter parameter = new InOutParameter();
            TopParameter common = new TopParameter();
            StringBuilder outResult = new StringBuilder(300);
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = "WYH001";
            common.AKC190 = "";
            common.AKC020 = "";
            common.AKA130 = "";

            common.MSGNO = "1800";

            common.BATNO = YwZqh;
            common.OPERID = "WYH001";
            common.OPERNAME = "WYH001";
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            sw.writeLogs("上传获取中心端时间数据", Convert.ToDateTime(BillSysBase.currDate()), " XML ==> " + common.InXml(common));
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AAE036 = item["AAE036"].ToString();
                }
            }
            else
            {


                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;

        }

        /// <summary>
        /// 【1401】获取人员信息 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="common"></param>
        /// <returns></returns> 
        public InOutParameter dryjbxxzhxx(TopParameter tp)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                TopParameter common = new TopParameter();
                StringBuilder outResult = new StringBuilder(1000);
                sw.writeLogs("上传获取人员信息数据", Convert.ToDateTime(BillSysBase.currDate()), " XML ==> " + common.InXml(tp));
                int opstat = hisinterface(common.InXml(tp), outResult);


                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString() != "-1")
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                    {
                        parameter.AAC001 = item["AAC001"].ToString();//个人编号
                        parameter.AAB001 = item["AAB001"].ToString();//单位编号

                        parameter.AKC020 = item["AKC020"].ToString();//ic卡号
                        parameter.AAC002 = item["AAC002"].ToString();//身份证号
                        parameter.AAC003 = item["AAC003"].ToString();//姓名
                        parameter.AAC004 = item["AAC004"].ToString();//性别
                        parameter.ZKC031 = item["ZKC031"].ToString();//住院状态
                        parameter.AKC087 = item["AKC087"].ToString();//账户余额

                        parameter.AAB004 = item["AAB004"].ToString();//单位名称
                        //parameter.AAC005 = item["AAC005"].ToString();//民族
                        //parameter.AAC006 = item["AAC006"].ToString();//出生日期
                        parameter.AKC021 = item["AKC021"].ToString();//人员类别
                        //parameter.AAC030 = item["AAC030"].ToString();//参保日期
                        parameter.AAC008 = item["AAC008"].ToString();//人员状态

                        //parameter.AAC021 = item["AAC021"].ToString();//公务员
                        //parameter.BAC136 = item["BAC136"].ToString();//灵活就业标志
                        //parameter.AAC007 = item["AAC007"].ToString();//参加工作日期
                        //parameter.AKC090 = item["AKC090"].ToString();//住院次数
                        //parameter.AKC086 = item["AKC086"].ToString();//帐户支出累计
                        //parameter.AKC088 = item["AKC088"].ToString();//统筹支出累计
                        //parameter.AKC089 = item["AKC089"].ToString();//符合基本医疗累计
                        //parameter.ZKC026 = item["ZKC026"].ToString();//公务员统筹累计
                        //parameter.AKC099 = item["AKC099"].ToString();//门诊特殊病符合基本医疗

                        //parameter.AKC803 = item["AKC803"].ToString();//参保地行政区划代码
                        //parameter.AKC804 = item["AKC804"].ToString();//参保地社保机构名称
                        //parameter.BAZ061 = item["BAZ061"].ToString();//社保卡SID
                        //parameter.AAE002 = item["AAE002"].ToString();//最大实缴月份
                        parameter.ZKA102 = item["ZKA102"].ToString();//已审批的门诊慢性病病种
                        parameter.ZKA103 = item["ZKA103"].ToString();//已审批的门诊特殊疾病（门诊大病）病种 

                    }

                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1401】获取人员信息失败 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }

        }

        /// <summary>
        /// 【1101】住院登记
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="common"></param>
        /// <returns></returns> 
        public InOutParameter zydj(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                sw.writeLogs("上传入院登记【1101】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1101】住院登记 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }

        }
        /// <summary>
        /// 5.6【1102】住院登记信息修改
        /// </summary>
        /// <param name="common"></param>
        /// <returns></returns>
        public InOutParameter zydjxxxg(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                sw.writeLogs("上传登记信息修改【1102】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1102】住院登记信息修改 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }

        }
        /// <summary>
        /// 【1103】住院费用明细上传
        /// </summary>
        /// <param name="common"></param>
        /// <returns></returns>
        public InOutParameter zyfymxUpload(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                sw.writeLogs("上传住院费用明细【1103】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1103】住院费用明细上传 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }

        }
        /// <summary>
        /// 5.9【1104】住院费用预结算
        /// </summary>
        /// <returns></returns>
        public InOutParameter zyfyyjs(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            sw.writeLogs("上传住院预结算【1104】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 ");
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            if (opstat != -1)
            {
                sw.writeLogs("上传住院预结算【1104】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】  返回参数：【" + outResult + "】");
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                    parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                    parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                    parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                    parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                    parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                    parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                    parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计

                    parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                    parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                    parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                    parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                    parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                    parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                    parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                    parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                    parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                    parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                    parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                    parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                    parameter.AKC253 = item["AKC253"].ToString();//自费费用
                    parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                    parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                    parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                    parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                    parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                    parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                    parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段）
                    //30
                    parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                    parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                    parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                    parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                    parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                    parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                    parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                    parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                    parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                    parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                    parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                    parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                    parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                    parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                    parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                    parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                    parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                    parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                    parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                    parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                    parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                    parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                    parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                    parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                    parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                    parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                    parameter.AAE040 = item["AAE040"].ToString();//结算日期
                    parameter.AKC759 = item["AKC759"].ToString();//基本账户
                    parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                    parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                    parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                    parameter.AKC763 = item["AKC763"].ToString();//补充账户
                    parameter.AKC764 = item["AKC764"].ToString();//补助账户
                    parameter.AKC765 = item["AKC765"].ToString();//其他账户
                    parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                    parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                    parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                    parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                    parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                    parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                    parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                    parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                    parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                    parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                    parameter.AKC776 = item["AKC776"].ToString();//药品费用
                    parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                    parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                    parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                    parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                    parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                    parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                    parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                    parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                    parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                    parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                    parameter.AKC789 = item["AKC789"].ToString();//是否异地 

                }

            }
            else
            {
                sw.writeLogs("上传住院结算【1105】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }

        /// <summary>
        /// 5.10【1105】住院费用结算
        /// </summary>
        /// <returns></returns>
        public InOutParameter zyfyjs(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            sw.writeLogs("上传住院结算【1105】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】");
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                sw.writeLogs("上传住院结算【1105】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                    parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                    parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                    parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                    parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                    parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                    parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                    parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计

                    parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                    parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                    parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                    parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                    parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                    parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                    parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                    parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                    parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                    parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                    parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                    parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                    parameter.AKC253 = item["AKC253"].ToString();//自费费用
                    parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                    parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                    parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                    parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                    parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                    parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                    parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段）
                    //30
                    parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                    parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                    parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                    parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                    parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                    parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                    parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                    parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                    parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                    parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                    parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                    parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                    parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                    parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                    parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                    parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                    parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                    parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                    parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                    parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                    parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                    parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                    parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                    parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                    parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                    parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                    parameter.AAE040 = item["AAE040"].ToString();//结算日期
                    parameter.AKC759 = item["AKC759"].ToString();//基本账户
                    parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                    parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                    parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                    parameter.AKC763 = item["AKC763"].ToString();//补充账户
                    parameter.AKC764 = item["AKC764"].ToString();//补助账户
                    parameter.AKC765 = item["AKC765"].ToString();//其他账户
                    parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                    parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                    parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                    parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                    parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                    parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                    parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                    parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                    parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                    parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                    parameter.AKC776 = item["AKC776"].ToString();//药品费用
                    parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                    parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                    parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                    parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                    parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                    parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                    parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                    parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                    parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                    parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                    parameter.AKC789 = item["AKC789"].ToString();//是否异地 

                }

            }
            else
            {
                sw.writeLogs("上传住院结算【1105】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        /// 5.11【1106】住院费用明细删除
        /// </summary>
        /// <returns></returns>
        public InOutParameter zyfymxDelete(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                sw.writeLogs("上传住院费用删除【1106】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                StringReader sr = new StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1106】住院费用明细删除 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }
        }
        /// <summary>
        /// 5.14【1201】无费退院
        /// </summary>
        /// <returns></returns>
        public InOutParameter wfty(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            sw.writeLogs("上传无费入院回退【1201】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
            StringReader sr = new StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
            parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
            parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            return parameter;
        }

        /// <summary>
        /// 5.16【1203】住院结算召回
        /// </summary>
        /// <returns></returns>
        public InOutParameter zyjszh(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            sw.writeLogs("上传住院结算回退WYH001【1203】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
            StringReader sr = new StringReader(outResult.ToString());

            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                // sw.writeLogs("上传住院结算回退【1203】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额 
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额 
                    parameter.AKC087 = item["AKC087"].ToString();//结算后社保卡余额 
                    parameter.AAE040 = item["AAE040"].ToString();//结算回退时间 
                }
            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        /// 5.18【1702】住院结算单打印
        /// </summary>
        /// <returns></returns>
        public InOutParameter zyjsddy(TopParameter common)
        {
            try
            {
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {
                    sw.writeLogs("上传住院结算打印【1702】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 返回参数：【" + outResult + "】");
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                    {
                        parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                        parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                        parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                        parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                        parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                        parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                        parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                        parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                        parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计

                        parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                        parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                        parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                        parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                        parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                        parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                        parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                        parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                        parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                        parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                        parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                        parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                        parameter.AKC253 = item["AKC253"].ToString();//自费费用
                        parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                        parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                        parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                        parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                        parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                        parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                        parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段）
                        //30
                        parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                        parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                        parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                        parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                        parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                        parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                        parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                        parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                        parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                        parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                        parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                        parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                        parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                        parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                        parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                        parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                        parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                        parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                        parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                        parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                        parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                        parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                        parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                        parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                        parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                        parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                        parameter.AAE040 = item["AAE040"].ToString();//结算日期
                        parameter.AKC759 = item["AKC759"].ToString();//基本账户
                        parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                        parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                        parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                        parameter.AKC763 = item["AKC763"].ToString();//补充账户
                        parameter.AKC764 = item["AKC764"].ToString();//补助账户
                        parameter.AKC765 = item["AKC765"].ToString();//其他账户
                        parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                        parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                        parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                        parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                        parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                        parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                        parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                        parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                        parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                        parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                        parameter.AKC776 = item["AKC776"].ToString();//药品费用
                        parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                        parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                        parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                        parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                        parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                        parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                        parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                        parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                        parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                        parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                        parameter.AKC789 = item["AKC789"].ToString();//是否异地 

                    }

                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1702】住院结算单打印 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                return parameter;
            }

        }

        /// <summary>
        /// 5.19【1910】慢性病审批信息查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter mxbspxxcx(TopParameter common, out DataTable dt)
        {
            InOutParameter parameter = new InOutParameter();
            dt = new DataTable();

            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();

                //返回的慢性病病种信息
                dt = ds.Tables[1];

            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }

        /// <summary>
        /// 5.20【1920】慢性病处方查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter mxbcfcx(TopParameter common, out DataTable dt)
        {
            InOutParameter parameter = new InOutParameter();
            dt = new DataTable();

            StringBuilder outResult = new StringBuilder(1000);

            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();

                //返回的慢性病处方信息
                dt = ds.Tables["OUTROW"];
            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }

        /// <summary>
        /// 5.21【2810】慢性病处方申报(暂时不做)
        /// </summary>
        /// <returns></returns>
        public InOutParameter mxbcfsb(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();

            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTROW"].Rows)
                {
                    parameter.BAE073 = item["BAE073"].ToString();//审批编号
                    parameter.AAE030 = item["AAE030"].ToString();//开始日期
                    parameter.AAE031 = item["AAE031"].ToString();//终止日期
                    parameter.AKA060 = item["AKA060"].ToString();//药品编码
                    parameter.AKA061 = item["AKA061"].ToString();//中文名称
                    parameter.AAE100 = item["AAE100"].ToString();//审批标志
                    parameter.AKA071 = item["AKA071"].ToString();//每次用量
                    parameter.AKA107 = item["AKA107"].ToString();//用法
                    parameter.AAE013 = item["AAE013"].ToString();//备注
                }

            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;

        }
        #region 门诊
        /// <summary>
        ///5.12【1107】门诊费用预结算
        /// </summary>
        /// <returns></returns>
        public InOutParameter mzfyyjs(TopParameter common, KC21 kc21)
        {
            InOutParameter parameter = new InOutParameter();
            // TopParameter common = new TopParameter();
            StringBuilder outResult = new StringBuilder(1000);

            common.KC21XML = kc21.KC21_inXml(kc21);
            KC22 kc22 = new KC22();
            String sql = "";
            if (kc21.AKA130 == "13")//慢性病只上传药品审批编码  暂时不用
            {
                sql = "select " + kc21.AKC190 + " as AKC190, mtprod.iid as iid, case when mtprod.projecttype in (2,3,4) then 1 when mtprod.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtprod.iid as his_dm,mtprod.chargesn as AKC515,mtprod.name as AKC516,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,''as yf, '' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtprod,mtmzblstuff where mtprod.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "'";
            }
            else
            {
                sql = "select " + kc21.AKC190 + " as AKC190, mtprod.iid as iid, case when mtprod.projecttype in (2,3,4) then 1 when mtprod.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtprod.iid as his_dm,mtprod.chargesn as AKC515,mtprod.name as AKC516,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,''as yf, '' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtprod,mtmzblstuff where mtprod.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "' union";
                sql += " select " + kc21.AKC190 + " as AKC190,mtjcxm.iid as iid,case when mtjcxm.projecttype in (2,3,4) then 1 when mtjcxm.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtjcxm.iid as his_dm,mtjcxm.sym as AKC515,mtjcxm.name as AKC516 ,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,'' as yf,'' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtjcxm,mtmzblstuff where mtjcxm.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "' order by AKC220";
            }
        //    HISDB hisdb = new HISDB();
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            var list = Tools<KC22>.ConvertToList(dt);
            common.KC22XML = (kc22.mzKC22_inXml(list));
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);


            if (opstat != -1)
            {
                //string sqlup = "update mtmzblstuff set yb_sfsc=1 where iid ='" + kc21.AKC190+"'";
                //hisdb.Update(sqlup);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                    parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                    parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                    parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                    parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                    parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                    parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                    parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计

                    parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                    parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                    parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                    parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                    parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                    parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                    parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                    parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                    parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                    parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                    parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                    parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                    parameter.AKC253 = item["AKC253"].ToString();//自费费用
                    parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                    parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                    parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                    parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                    parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                    parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                    parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段）
                    //30
                    parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                    parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                    parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                    parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                    parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                    parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                    parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                    parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                    parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                    parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                    parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                    parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                    parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                    parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                    parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                    parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                    parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                    parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                    parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                    parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                    parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                    parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                    parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                    parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                    parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                    parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                    parameter.AAE040 = item["AAE040"].ToString();//结算日期
                    parameter.AKC759 = item["AKC759"].ToString();//基本账户
                    parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                    parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                    parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                    parameter.AKC763 = item["AKC763"].ToString();//补充账户
                    parameter.AKC764 = item["AKC764"].ToString();//补助账户
                    parameter.AKC765 = item["AKC765"].ToString();//其他账户
                    parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                    parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                    parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                    parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                    parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                    parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                    parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                    parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                    parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                    parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                    parameter.AKC776 = item["AKC776"].ToString();//药品费用
                    parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                    parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                    parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                    parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                    parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                    parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                    parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                    parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                    parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                    parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                    parameter.AKC789 = item["AKC789"].ToString();//是否异地 

                }

            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        ///5.13【1108】门诊费用结算
        /// </summary>
        /// <returns></returns>
        public InOutParameter mzfyjs(TopParameter common, KC21 kc21, String grbh, String zfy, String hisfph)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
         //   HISDB hisdb = new HISDB();
            //特定输入参数
            StringBuilder sb = new StringBuilder(200);
            parameter.AKC190 = kc21.AKC190;
            parameter.AAE072 = hisfph;
            parameter.AAC001 = grbh;
            parameter.AKC264 = zfy;
            sb.AppendFormat("<AKC190>{0}</AKC190>", parameter.AKC190);
            sb.AppendFormat("<AAE072>{0}</AAE072>", parameter.AAE072);
            sb.AppendFormat("<AAC001>{0}</AAC001>", parameter.AAC001);
            sb.AppendFormat("<AKC264>{0}</AKC264>", parameter.AKC264);
            common.INPUT = sb.ToString();

            common.KC21XML = kc21.KC21_inXml(kc21);
            KC22 kc22 = new KC22();
            string sql = "";
            if (kc21.AKA130 == "13")//慢性病只上传药品审批编码  暂时不用
            {
                sql = "select " + kc21.AKC190 + " as AKC190, mtprod.iid as iid, case when mtprod.projecttype in (2,3,4) then 1 when mtprod.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtprod.iid as his_dm,mtprod.chargesn as AKC515,mtprod.name as AKC516,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,''as yf, '' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtprod,mtmzblstuff where mtprod.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "'";
            }
            else
            {
                sql = "select " + kc21.AKC190 + " as AKC190, mtprod.iid as iid, case when mtprod.projecttype in (2,3,4) then 1 when mtprod.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtprod.iid as his_dm,mtprod.chargesn as AKC515,mtprod.name as AKC516,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,''as yf, '' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtprod,mtmzblstuff where mtprod.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "' union";
                sql += " select " + kc21.AKC190 + " as AKC190,mtjcxm.iid as iid,case when mtjcxm.projecttype in (2,3,4) then 1 when mtjcxm.projecttype in (-103) then 3 else 2 end as AKC224,mtstuffitem.iid as AKC220,mtmzblstuff.createdat as AKC221,mtjcxm.iid as his_dm,mtjcxm.sym as AKC515,mtjcxm.name as AKC516 ,mtstuffitem.prc as AKC225,mtstuffitem.qty as AKC226,'' as jx,'' as guige," + kc21.BKF050 + " as BKF050,'' as yf,'' as kbmc,mtstuffitem.amt as AKC227 from mtstuffitem,mtjcxm,mtmzblstuff where mtjcxm.iid=mtstuffitem.mtprod and mtmzblstuff.iid=mtstuffitem.mtmzblstuff  and mtstuffitem.yb_sfsc=0 and mtmzblstuff.iid='" + kc21.AKC190 + "' order by AKC220";
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            var list = Tools<KC22>.ConvertToList(dt);
            common.KC22XML = (kc22.mzKC22_inXml(list));
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);


            if (opstat != -1)
            {
                //string sqlup = "update mtmzblstuff set yb_sfsc=1 where iid ='" + kc21.AKC190+"'";
                //hisdb.Update(sqlup);
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                    parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                    parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                    parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                    parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                    parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                    parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                    parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计

                    parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                    parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                    parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                    parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                    parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                    parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                    parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                    parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                    parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                    parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                    parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                    parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                    parameter.AKC253 = item["AKC253"].ToString();//自费费用
                    parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                    parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                    parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                    parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                    parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                    parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                    parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段）
                    //30
                    parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                    parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                    parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                    parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                    parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                    parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                    parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                    parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                    parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                    parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                    parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                    parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                    parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                    parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                    parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                    parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                    parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                    parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                    parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                    parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                    parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                    parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                    parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                    parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                    parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                    parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                    parameter.AAE040 = item["AAE040"].ToString();//结算日期
                    parameter.AKC759 = item["AKC759"].ToString();//基本账户
                    parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                    parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                    parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                    parameter.AKC763 = item["AKC763"].ToString();//补充账户
                    parameter.AKC764 = item["AKC764"].ToString();//补助账户
                    parameter.AKC765 = item["AKC765"].ToString();//其他账户
                    parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                    parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                    parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                    parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                    parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                    parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                    parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                    parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                    parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                    parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                    parameter.AKC776 = item["AKC776"].ToString();//药品费用
                    parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                    parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                    parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                    parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                    parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                    parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                    parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                    parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                    parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                    parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                    parameter.AKC789 = item["AKC789"].ToString();//是否异地 

                }

            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        /// 5.15【1202】门诊结算回退
        /// </summary>
        /// <returns></returns>
        public InOutParameter mzjsht(TopParameter common)
        {
            InOutParameter parameter = new InOutParameter();

            StringBuilder outResult = new StringBuilder(200);

            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额 
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额 
                    parameter.AKC087 = item["AKC087"].ToString();//结算后卡余额 
                    parameter.AAE040 = item["AAE040"].ToString();//结算回退时间 
                }
            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        /// 5.17【1701】门诊结算单打印
        /// </summary>
        /// <returns></returns>
        public InOutParameter mzjsddy()
        {
            InOutParameter parameter = new InOutParameter();
            TopParameter common = new TopParameter();
            StringBuilder outResult = new StringBuilder();
            common.MSGNO = "1701";
            common.AKC190 = "";
            common.AKC020 = "";
            common.AKB020 = "";
            common.AKA130 = "";
            common.AAE140 = "";
            common.AAC001 = "";
            common.BATNO = "";
            common.OPERID = "";
            common.OPERNAME = "";
            common.OPTTIME = "";
            StringBuilder sb = new StringBuilder(200);
            parameter.AKC190 = ""; parameter.AAE072 = "";
            sb.AppendFormat("<AKC190>{0}</AKC190>", parameter.AKC190);
            sb.AppendFormat("<AAE072>{0}</AAE072>", parameter.AAE072);
            common.INPUT = sb.ToString();
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                foreach (DataRow item in ds.Tables["OUTPUT"].Rows)
                {
                    parameter.AKC264 = item["AKC264"].ToString();//医疗费总额
                    parameter.AKC255 = item["AKC255"].ToString();//本次帐户支付金额
                    parameter.AKC260 = item["AKC260"].ToString();//本次统筹支付金额
                    parameter.AKC261 = item["AKC261"].ToString();//本次现金支付金额
                    parameter.AKC706 = item["AKC706"].ToString();//大病救助基金支付
                    parameter.AKC707 = item["AKC707"].ToString();//公务员补助支付
                    parameter.AKC708 = item["AKC708"].ToString();//符合基本医疗保险费用
                    parameter.AKC263 = item["AKC263"].ToString();//本年符合基本医疗累计
                    parameter.AKC089 = item["AKC089"].ToString();//本年统筹支出累计 
                    parameter.AKC121 = item["AKC121"].ToString();//本年大病支出累计
                    parameter.AKC256 = item["AKC256"].ToString();//本次起付标准自付
                    parameter.CKA050 = item["CKA050"].ToString();//本次起付标准
                    parameter.AKC090 = item["AKC090"].ToString();//本年住院次数
                    parameter.AKC268 = item["AKC268"].ToString();//进入统筹费用
                    parameter.AKC278 = item["AKC278"].ToString();//本次进入公务员费用
                    parameter.AKC279 = item["AKC279"].ToString();//本次进入大病部分
                    parameter.AKC718 = item["AKC718"].ToString();//进入其他基金费用
                    parameter.ZKC036 = item["ZKC036"].ToString();//超过大病补充封顶线部分
                    parameter.AKC262 = item["AKC262"].ToString();//本次个人帐户应支付金额
                    parameter.AKC252 = item["AKC252"].ToString();//卡结算前余额
                    parameter.AKC087 = item["AKC087"].ToString();//卡结算后余额
                    parameter.AKC253 = item["AKC253"].ToString();//自费费用
                    parameter.AKC254 = item["AKC254"].ToString();//乙类自付
                    parameter.AKC380 = item["AKC380"].ToString();//乙类药自付
                    parameter.ZKC032 = item["ZKC032"].ToString();//特检自付
                    parameter.ZKC034 = item["ZKC034"].ToString();//特治自付
                    parameter.AKC740 = item["AKC740"].ToString();//统筹分段自付（第1段）
                    parameter.AKC741 = item["AKC741"].ToString();//统筹分段自付（第2段）
                    parameter.AKC742 = item["AKC742"].ToString();//统筹分段自付（第3段） 
                    parameter.AKC743 = item["AKC743"].ToString();//统筹分段自付（第4段）
                    parameter.AKC744 = item["AKC744"].ToString();//统筹分段自付（第5段）
                    parameter.AKC745 = item["AKC745"].ToString();//统筹分段自付（第6段）
                    parameter.AKC746 = item["AKC746"].ToString();//统筹支出（第1段）
                    parameter.AKC747 = item["AKC747"].ToString();//统筹支出（第2段）
                    parameter.AKC748 = item["AKC748"].ToString();//统筹支出（第3段）
                    parameter.AKC750 = item["AKC750"].ToString();//统筹支出（第5段）
                    parameter.AKC749 = item["AKC749"].ToString();//统筹支出（第4段）
                    parameter.AKC751 = item["AKC751"].ToString();//统筹支出（第6段）
                    parameter.AKC752 = item["AKC752"].ToString();//公务员自付
                    parameter.AKC753 = item["AKC753"].ToString();//其他基金自付
                    parameter.AKC258 = item["AKC258"].ToString();//超过封顶线个人自付
                    parameter.BKA067 = item["BKA067"].ToString();//甲类药总费用
                    parameter.BKA068 = item["BKA068"].ToString();//乙类药总费用
                    parameter.BKA069 = item["BKA069"].ToString();//丙类药总费用
                    parameter.AKC368 = item["AKC368"].ToString();//普通检查费用
                    parameter.AKC369 = item["AKC369"].ToString();//特殊检查费用
                    parameter.AKC370 = item["AKC370"].ToString();//自费检查费用
                    parameter.AKC374 = item["AKC374"].ToString();//普通治疗费用
                    parameter.AKC375 = item["AKC375"].ToString();//特殊治疗费用
                    parameter.AKC376 = item["AKC376"].ToString();//自费治疗费用
                    parameter.AKC754 = item["AKC754"].ToString();//总的个人自付金额
                    parameter.AKC755 = item["AKC755"].ToString();//预留字段2
                    parameter.AKC756 = item["AKC756"].ToString();//预留字段3
                    parameter.AKC757 = item["AKC757"].ToString();//预留字段4
                    parameter.AKC758 = item["AKC758"].ToString();//预留字段5
                    parameter.AAE040 = item["AAE040"].ToString();//结算日期
                    parameter.AKC759 = item["AKC759"].ToString();//基本账户
                    parameter.AKC760 = item["AKC760"].ToString();//4%补充账户
                    parameter.AKC761 = item["AKC761"].ToString();//10%补充账户
                    parameter.AKC762 = item["AKC762"].ToString();//10%补助账户
                    parameter.AKC763 = item["AKC763"].ToString();//补充账户
                    parameter.AKC764 = item["AKC764"].ToString();//补助账户
                    parameter.AKC765 = item["AKC765"].ToString();//其他账户
                    parameter.AKC766 = item["AKC766"].ToString();//基本统筹
                    parameter.AKC767 = item["AKC767"].ToString();//4%补充统筹
                    parameter.AKC768 = item["AKC768"].ToString();//10%补充统筹
                    parameter.AKC769 = item["AKC769"].ToString();//10%补助统筹
                    parameter.AKC770 = item["AKC770"].ToString();//补充统筹
                    parameter.AKC771 = item["AKC771"].ToString();//补助统筹
                    parameter.AKC772 = item["AKC772"].ToString();//其他统筹
                    parameter.AKC773 = item["AKC773"].ToString();//定点医疗机构支付
                    parameter.AKC774 = item["AKC774"].ToString();//一次性材料费用
                    parameter.AKC775 = item["AKC775"].ToString();//诊疗项目费用
                    parameter.AKC776 = item["AKC776"].ToString();//药品费用
                    parameter.AKC777 = item["AKC777"].ToString();//服务设施费用
                    parameter.AKC778 = item["AKC778"].ToString();//类型（发票）
                    parameter.AKC779 = item["AKC779"].ToString();//医保类型（发票）
                    parameter.AKC780 = item["AKC780"].ToString();//医保统筹支付（发票）
                    parameter.AKC781 = item["AKC781"].ToString();//起付标准累计（发票）
                    parameter.AKC782 = item["AKC782"].ToString();//统筹累计支付（发票）
                    parameter.AKC785 = item["AKC785"].ToString();//医院垫支（发票）
                    parameter.AKC786 = item["AKC786"].ToString();//大病起付标准自付（发票）
                    parameter.AKC787 = item["AKC787"].ToString();//大病起付标准累计（发票）
                    parameter.AKC788 = item["AKC788"].ToString();//超限价（发票）
                    parameter.AKC789 = item["AKC789"].ToString();//是否异地  
                }
            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }

        #endregion


        /// <summary>
        /// 5.25【1711】病种信息查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter bzxxcx(TopParameter common, out DataTable dt)
        {
            dt = new DataTable();
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(500000);
            sw.writeLogs("上传【1711】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 上传参数：【" + common.InXml(common) + " 】 ");
            int opstat = hisinterface(common.InXml(common), outResult);
            sw.writeLogs("上传【1711】XML参数", Convert.ToDateTime(BillSysBase.currDate()), "患者住院号：【" + common.AKC190 + "】 返回参数：【" + outResult + "】");
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();

                dt = ds.Tables["KA06ROW"];//datatable 就是返回的病种信息

            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }
        /// <summary>
        /// 5.26【1712】住院登记信息查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter zydjcx(TopParameter common, out DataTable dt)
        {
            dt = new DataTable();
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000);
            int opstat = hisinterface(common.InXml(common), outResult);
            System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (opstat != -1)
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                dt = ds.Tables["KC21ROW"];//datatable 就是返回的患者信息              
            }
            else
            {
                parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
            }
            return parameter;
        }

        /// <summary>
        /// 5.23【1709】已上传费用明细查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter yscfymxcx(TopParameter common, out DataTable dt, String zyh, String djh)
        {
            InOutParameter parameter = new InOutParameter();
            StringBuilder outResult = new StringBuilder(1000000);
            int i = 1;
            int page = 1;

            dt = new DataTable();
            while (true)
            {
                DataTable dt_ls = new DataTable();

                common.INPUT = string.Format("<AKC190>{0}</AKC190><AAE072>{1}</AAE072><PAGECNT>{2}</PAGECNT>", zyh, djh, i);
                parameter = new InOutParameter();
                outResult = new StringBuilder(1000000);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {

                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    dt_ls = ds.Tables["KC22ROW"];//datatable 就是返回的费用信息    
                    if ((dt_ls == null || dt_ls.Rows.Count == 0) && (dt == null || dt.Rows.Count == 0))
                    {

                        return parameter;
                    }
                    if (i == 1)
                    {
                        dt = dt_ls.Copy();
                        // dt.Merge(dt_ls);
                        page = Convert.ToInt32(dt_ls.Rows[0]["PAGESIZE"].ToString());
                    }
                    else
                    {
                        if (dt_ls == null || dt_ls.Rows.Count == 0)
                            break;
                        foreach (DataRow dr in dt_ls.Rows)
                        {
                            dt.ImportRow(dr);
                        }
                        //dt.Merge(dt_ls);//合并数据

                    }
                    if (page == i)
                    {
                        break;
                    }
                    i++;
                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    break;
                }
            }

            return parameter;
        }
        /// <summary>
        /// 5.22【1708】中心票据信息查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter zxpjxxcx(TopParameter common, out DataTable dt)
        {
            try
            {
                dt = new DataTable();
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    dt = ds.Tables["OUTPUT"];//datatable 就是返回的费用信息              
                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1702】住院结算单打印 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                dt = null;
                return parameter;
            }

        }
        /// <summary>
        /// 5.24【1710】三目对照基本信息情况查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter smdzjbxxqkcx(TopParameter common, out DataTable dt)
        {
            try
            {
                dt = new DataTable();
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    dt = ds.Tables["OUTPUT"];//datatable 就是返回的费用信息              
                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1710】三目对照基本信息情况查询 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                dt = null;
                return parameter;
            }

        }

        /// <summary>
        /// 5.28【1714】参保人员欠费状态查询
        /// </summary>
        /// <returns></returns>
        public InOutParameter cbryqfztcx(TopParameter common, out DataTable dt)
        {
            try
            {
                dt = new DataTable();
                InOutParameter parameter = new InOutParameter();
                StringBuilder outResult = new StringBuilder(1000);
                int opstat = hisinterface(common.InXml(common), outResult);
                System.IO.StringReader sr = new System.IO.StringReader(outResult.ToString());
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (opstat != -1)
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                    parameter.Output = ds.Tables["RESPONSEDATA"].Rows[0]["OUTPUT"].ToString();//返回的欠费状态  0  未欠费  其他  已欠费          

                }
                else
                {
                    parameter.ErrorMsg = ds.Tables["RESPONSEDATA"].Rows[0]["ERRORMSG"].ToString();
                    parameter.ReturnNum = ds.Tables["RESPONSEDATA"].Rows[0]["RETURNNUM"].ToString();
                    parameter.RefMsgId = ds.Tables["RESPONSEDATA"].Rows[0]["REFMSGID"].ToString();
                }
                return parameter;
            }
            catch (Exception)
            {
                InOutParameter parameter = new InOutParameter();
                parameter.ErrorMsg = "解析过程中发生错误 【1714】参保人员欠费状态查询 ";
                parameter.ReturnNum = "-1";
                parameter.RefMsgId = "";
                dt = null;
                return parameter;
            }

        }
    }
}
