using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
//using MTREG.medinsur.hdyb;
using System.Runtime.InteropServices;
using MTREG.medinsur.hdyb.dor;
using MTREG.common.bll;
using MTHIS.main.bll;
using System.Data;
using System.Data.Odbc;
using MTHIS.tools;
using System.IO;

namespace MTREG.medinsur.sjzsyb.bll
{
    class Sjzsyb
    {
        private string zyh;

        [DllImport("hisinterface.dll")]
        public static extern int hisinterface(string rc, ref string cc);

        public int ybcjhs(Sjzsyb_IN in1)
        {
            this.zyh = in1.Hisjl;
            string Cc = "";

            StringBuilder returnMsg = new StringBuilder();
            returnMsg.Capacity = 3000;
            if (in1.Yw == "BB310005")
            {
                returnMsg.Capacity = 90000;
            }
            string[] log = new string[6];
            log[0] = in1.Hisjl;
            if (string.IsNullOrEmpty(in1.Ywmc))
            {
                log[1] = DateTime.Now.ToString() + "==>【" + in1.Yw + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】开始----------------------------------------------------------------------------";
            }
            else
            {
                log[1] = DateTime.Now.ToString() + "==>【" + in1.Yw + "-" + in1.Ywmc + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】开始----------------------------------------------------------------------------";
            }
            string ismn = IniUtils.IniReadValue(IniUtils.syspath, "MN", "mn");
            int opstat = -1;
            if (ismn.Equals("1"))
            {
                opstat = hisinterface_mn(in1.Yw, in1.Rc, ref Cc);
            }
            else
            {
                opstat = hisinterface(in1.Rc, ref Cc);
            }

            in1.Cc = Cc;


            string ret = returnMsg.ToString().Trim();
            if (opstat != 0)
            {
                if (string.IsNullOrEmpty(in1.Ywmc))
                {
                    in1.Mesg = "【医保提示：" + in1.Yw + "--" + ret + "！】";
                }
                else
                {
                    in1.Mesg = "【医保提示：" + in1.Yw + "--" + in1.Ywmc + "--" + ret + "！】";
                }
                log[2] = "		      【完整】" + opstat.ToString() + " = comminterface(" + in1.Yw + "," + in1.Rc + "," + returnMsg + "," + in1.Ylzh + ")";
                log[3] = "		      【入参】" + in1.Rc;
                log[4] = "		      【出参】" + returnMsg;
                if (string.IsNullOrEmpty(in1.Ywmc))
                {
                    log[5] = DateTime.Now.ToString() + "==>【" + in1.Yw + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】失败----------------------------------------------------------------------------";
                }
                else
                {
                    log[5] = DateTime.Now.ToString() + "==>【" + in1.Yw + "-" + in1.Ywmc + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】失败----------------------------------------------------------------------------";
                }
                SysWriteLogs.writeLogs_yb(log);
                return opstat;
            }

            log[2] = "		      【完整】" + opstat.ToString() + " = comminterface(" + in1.Yw + "," + in1.Rc + "," + returnMsg + "," + in1.Ylzh + ")";
            log[3] = "		      【入参】" + in1.Rc;
            log[4] = "		      【出参】" + returnMsg;
            if (string.IsNullOrEmpty(in1.Ywmc))
            {
                log[5] = DateTime.Now.ToString() + "==>【" + in1.Yw + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】成功----------------------------------------------------------------------------";
            }
            else
            {
                log[5] = DateTime.Now.ToString() + "==>【" + in1.Yw + "-" + in1.Ywmc + "】-【" + ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "】成功----------------------------------------------------------------------------";
            }
            SysWriteLogs.writeLogs_yb(log);

            string[] retdata = ret.Split('|');
            //in1.Cc = ret;
            //JKDB jkdb = new JKDB();
            try
            {
                if (string.IsNullOrEmpty(in1.Ywmc))
                {
                    in1.Mesg = "【医保提示：" + in1.Yw + "--" + ret + "！】";
                }
                else
                {
                    in1.Mesg = "【医保提示：" + in1.Yw + "--" + in1.Ywmc + "--" + ret + "！】";
                }
                if ((in1.Yw == "CC311003") || (in1.Yw == "CC311002"))
                {
                    string[] retdata_rc = in1.Rc.Split('|');
                    string sql = "insert into ybjsjl(mzzyh,yllb,djh,ylfyze,jsr,jssj,jsrc,jscc,tp,sfck) values('";
                    sql += retdata_rc[1] + "','";
                    sql += retdata_rc[2] + "','";
                    sql += retdata_rc[3] + "','";
                    sql += retdata[0] + "','";
                    sql += retdata_rc[4] + "','";
                    sql += DateTime.Now.ToString() + "','";
                    sql += in1.Rc + "','";
                    sql += in1.Cc + "','";
                    // sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
                    sql += ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "')";
                    BllMain.Db.Update(sql);
                }
                else if (in1.Yw == "CC511003")
                {
                    string[] retdata_rc = in1.Rc.Split('|');
                    string sql_cxsy = "select TOP 1 AAE072 from KC22 where AKC190='" + retdata_rc[1] + "'";
                    //DataTable dt_cxsy = jkdb.Select(sql_cxsy).Tables[0];
                    string djh_ = "";
                    //if (dt_cxsy.Rows.Count != 0)
                    //{
                    //    djh_ = dt_cxsy.Rows[0]["AAE072"].ToString().Trim();
                    //}
                    string sql = "insert into ybjsjl(mzzyh,yllb,djh,ylfyze,jsr,jssj,jsrc,jscc,tp,sfck) values('";
                    sql += retdata_rc[1] + "','";
                    sql += retdata_rc[2] + "','";
                    sql += djh_ + "','";
                    sql += retdata[0] + "','";
                    sql += retdata_rc[4] + "','";
                    sql += DateTime.Now.ToString() + "','";
                    sql += in1.Rc + "','";
                    sql += in1.Cc + "','";
                    //sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
                    sql += ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "')";
                    BllMain.Db.Update(sql);
                }
                else if ((in1.Yw == "DC311003") || (in1.Yw == "DC311002"))//
                {
                    string[] retdata_rc = in1.Rc.Split('|');
                    string sql_cx = "select * from ybjsjl where mzzyh='" + retdata_rc[1] + "' and djh='" + retdata_rc[2] + "' and ylfyze='" + retdata[0] + "' and jssj is not null order by jssj desc;";
                    DataTable dt_cx = BllMain.Db.Select(sql_cx).Tables[0];
                    if (dt_cx.Rows.Count == 0)
                    {
                        string sql_cxyllb = "select AKA130 from KC21 where AKC190='" + retdata_rc[1] + "'";
                        //DataTable dt_cxyllb = jkdb.Select(sql_cxyllb).Tables[0];
                        string yllb_ = "";
                        //if (dt_cxyllb.Rows.Count != 0)
                        //{
                        //    yllb_ = dt_cxyllb.Rows[0]["AKA130"].ToString().Trim();
                        //}
                        string sql = "insert into ybjsjl(mzzyh,yllb,djh,ylfyze,cxr,cxsj,cxrc,cxcc,tp,sfck) values('";
                        sql += retdata_rc[1] + "','";
                        sql += yllb_ + "','";
                        sql += retdata_rc[2] + "','";
                        sql += retdata[0] + "','";
                        sql += retdata_rc[3] + "','";
                        sql += DateTime.Now.ToString() + "','";
                        sql += in1.Rc + "','";
                        sql += in1.Cc + "','";
                        //sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
                        sql += ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "')";
                        BllMain.Db.Update(sql);
                    }
                    else
                    {
                        string sql = "update ybjsjl set ";
                        sql += " cxr='" + retdata_rc[3] + "',";
                        sql += " cxsj='" + DateTime.Now.ToString() + "',";
                        sql += " cxrc='" + in1.Rc + "',";
                        sql += " cxcc='" + in1.Cc + "' ";
                        sql += " where mzzyh='" + retdata_rc[1] + "' and djh='" + retdata_rc[2] + "' and ylfyze='" + retdata[0] + "' and jssj='" + Convert.ToDateTime(dt_cx.Rows[0]["jssj"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss") + "';";
                        BllMain.Db.Update(sql);
                    }
                }
            }
            catch
            { }
            return opstat;
        }

        public int hisinterface_mn(string ywlx, string rc, ref string cc)
        {
            string cc_head = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                           + "<HOSDATA>"
                           + "<RESPONSEDATA>"
                           + "<RETURNNUM>1</RETURNNUM>"//返回值
                           + "<ERRORMSG></ERRORMSG>"//错误信息
                           + "<REFMSGID>3435454645654</REFMSGID>"//接收方交易流水号
                           + "<OUTPUT>";//特定输出
            string cc_foot = "</OUTPUT>"
                           + "</RESPONSEDATA>"
                           + "</HOSDATA>";

            int ret = 0;
            //登入
            if (ywlx == "1501")
            {
                cc = cc_head + "<BATNO>000001</BATNO>" + cc_foot;//业务周期号
            }
            //登出
            if (ywlx == "1503") { cc = cc_head + cc_foot; }
            //获取中心端时间
            else if (ywlx == "1800")
            {
                cc = cc_head + "<AAE036>20151013120000</AAE036>" + cc_foot;
            }
            #region //获取人员信息
            else if (ywlx == "1401")
            {
                cc = cc_head + "<AAC001>130429199011112222</AAC001>"//个人编号
                             + "<AAB001>123456</AAB001>"//单位编号
                             + "<AAB004>邯郸市某某公司</AAB004>"//单位名称
                             + "<AKC020>13042919901111</AKC020>"//卡号
                             + "<AAC002>130429199011112222</AAC002>"//身份证号
                             + "<AAC003>t</AAC003>"//姓名
                             + "<AAC004>1</AAC004>"//性别
                             + "<AAC005>1</AAC005>"//民族  
                             + "<AAC006>1995-01-01</AAC006>"//出生日期
                             + "<AKC021></AKC021>"//人员类别
                             + "<AAC030>19950101</AAC030>"//
                             + "<AAC008>正常</AAC008>"//人员状态
                             + "<ZKC031>不在院</ZKC031>"//住院状态
                             + "<AAC021>0</AAC021>"//公务员标志
                             + "<BAC136>1</BAC136>"//灵活就业标志
                             + "<AAC007>2015-01-01</AAC007>"//参加工作日期
                             + "<AKC090>0</AKC090>"//住院次数
                             + "<AKC086>0.0000</AKC086>"//帐户支出累计
                             + "<AKC088>0.0000</AKC088>"//统筹支出累计
                             + "<AKC089>100.0000</AKC089>"//符合基本医疗累计
                             + "<ZKC026>0.0000</ZKC026>"//公务员统筹累计
                             + "<AKC099>23.0000</AKC099>"//门诊特殊病符合基本医疗
                             + "<AKC087>569.0000</AKC087>"//账户余额
                             + "<AKC803>130100</AKC803>"//参保地行政区划代码
                             + "<AKC804>石家庄鹿泉区</AKC804>"//参保地行政区划名称
                             + "<BAZ061>123456</BAZ061>"//社保卡 SID
                             + "<AAE002>10</AAE002>"//最大实缴月份
                             + "<ZKA102>糖尿病</ZKA102>"//已审批的门诊慢性病病种
                             + "<ZKA103>糖尿病</ZKA103>"//已审批的门诊特殊疾病（门诊大病）病种
                             + "<CKAA12>0</CKAA12>"//是否副市级以上人员
                             + "<CKAA34>1</CKAA34>"//是否个人定点
                             + "<CKAA35>0</CKAA35>"//贫困人口标识
                             //是否个人慢性病定点
                             + "<CKAA36>0</CKAA36>" + cc_foot;
            }
            #endregion

            //住院登记
            else if (ywlx == "1101")
            {
                cc = cc_head + cc_foot;
            }
            //住院登记信息修改
            else if (ywlx == "1102")
            {
                cc = cc_head + cc_foot;
            }
            //住院费用明细上传
            else if (ywlx == "1103")
            {
                cc = cc_head + cc_foot;
            }
            //住院费用预结算
            else if (ywlx == "1104" || ywlx == "1105" || ywlx == "1107" || ywlx == "1108")
            {
                cc = cc_head + "<AKC264>AKC264</AKC264>"
                             + "<AKC255>AKC255</AKC255>"
                             + "<AKC260>AKC260</AKC260>"
                             + "<AKC261>AKC261</AKC261>"
                             + "<AKC706>AKC706</AKC706>"
                             + "<AKC707>AKC707</AKC707>"
                             + "<AKC708>AKC708</AKC708>"
                             + "<AKC263>AKC263</AKC263>"
                             + "<AKC089>AKC089</AKC089>"
                             + "<AKC088>AKC088</AKC088>"
                             + "<AKC121>AKC121</AKC121>"
                             + "<AKC256>AKC256</AKC256>"
                             + "<CKA050>CKA050</CKA050>"
                             + "<AKC090>AKC090</AKC090>"
                             + "<AKC268>AKC268</AKC268>"
                             + "<AKC278>AKC278</AKC278>"
                             + "<AKC279>AKC279</AKC279>"
                             + "<AKC718>AKC718</AKC718>"
                             + "<ZKC036>ZKC036</ZKC036>"
                             + "<AKC262>AKC262</AKC262>"
                             + "<AKC252>AKC252</AKC252>"
                             + "<AKC087>AKC087</AKC087>"
                             + "<AKC253>AKC253</AKC253>"
                             + "<AKC254>AKC254</AKC254>"
                             + "<AKC380>AKC380</AKC380>"
                             + "<ZKC032>ZKC032</ZKC032>"
                             + "<ZKC034>ZKC034</ZKC034>"
                             + "<AKC740>AKC740（第 1 段）</AKC740>"
                             + "<AKC741>AKC741（第 2 段）</AKC741>"
                             + "<AKC742>AKC742（第 3 段）</AKC742>"
                             + "<AKC743>AKC743（第 4 段）</AKC743>"
                             + "<AKC744>AKC744（第 5 段）</AKC744>"
                             + "<AKC745>AKC745（第 6 段）</AKC745>"
                             + "<AKC746>AKC746（第 1 段）</AKC746>"
                             + "<AKC747>AKC747（第 2 段）</AKC747>"
                             + "<AKC748>AKC748（第 3 段）</AKC748>"
                             + "<AKC749>AKC749（第 4 段）</AKC749>"
                             + "<AKC750>AKC750（第 5 段）</AKC750>"
                             + "<AKC751>AKC751（第 6 段）</AKC751>"
                             + "<AKC752>AKC752</AKC752>"
                             + "<AKC753>AKC753</AKC753>"
                             + "<AKC258>AKC258</AKC258>"
                             + "<BKA067>BKA067</BKA067>"
                             + "<BKA068>BKA068</BKA068>"
                             + "<BKA069>BKA069</BKA069>"
                             + "<AKC368>AKC368</AKC368>"
                             + "<AKC369>AKC369</AKC369>"
                             + "<AKC370>AKC370</AKC370>"
                             + "<AKC374>AKC374</AKC374>"
                             + "<AKC375>AKC375</AKC375>"
                             + "<AKC376>AKC376</AKC376>"
                             + "<AKC754>AKC754</AKC754>"
                             + "<AKC755>AKC755 2</AKC755>"
                             + "<AKC756>AKC756</AKC756>"
                             + "<AKC757>AKC757 4</AKC757>"
                             + "<AKC758>AKC758 5</AKC758>"
                             + "<AAE040>AAE040</AAE040>"
                             + "<AKC759>AKC759</AKC759>"
                             + "<AKC760>4%AKC760</AKC760>"
                             + "<AKC761>10%AKC761</AKC761>"
                             + "<AKC762>10%AKC762</AKC762>"
                             + "<AKC763>AKC763</AKC763>"
                             + "<AKC764>AKC764</AKC764>"
                             + "<AKC765>AKC765</AKC765>"
                             + "<AKC766>AKC766</AKC766>"
                             + "<AKC767>4%AKC767</AKC767>"
                             + "<AKC768>10%AKC768</AKC768>"
                             + "<AKC769>10%AKC769</AKC769>"
                             + "<AKC770>AKC770</AKC770>"
                             + "<AKC771>AKC771</AKC771>"
                             + "<AKC772>AKC772</AKC772>"
                             + "<AKC773>AKC773</AKC773>"
                             + "<AKC774>AKC774</AKC774>"
                             + "<AKC775>AKC775</AKC775>"
                             + "<AKC776>AKC776</AKC776>"
                             + "<AKC777>AKC777</AKC777>"
                             + "<AKC778>AKC778（发票）</AKC778>"
                             + "<AKC779>AKC779（发票）</AKC779>"
                             + "<AKC780>AKC780（发票）</AKC780>"
                             + "<AKC781>AKC781（发票）</AKC781>"
                             + "<AKC782>AKC782（发票）</AKC782>"
                             + "<AKC783>AKC783（发票）</AKC783>"
                             + "<AKC784>AKC784（发票）</AKC784>"
                             + "<AKC785>AKC785（发票）</AKC785>"
                             + "<AKC786>AKC786（发票）</AKC786>"
                             + "<AKC787>AKC787（发票）</AKC787>"
                             + "<AKC788>AKC788（发票）</AKC788>"
                             + "<AKC789>AKC789（发票）</AKC789>"
                             + "<AKC790>AKC790（发票）</AKC790>"
                             + "<AKC791>AKC791（发票）</AKC791>"
                             + "<AKC792>AKC792（发票）</AKC792>"
                             + "<AKC793>AKC793（发票）</AKC793>"
                             + "<AKE182>AKE182</AKE182>"
                             + "<AKB021>AKB021（发票）</AKB021>"
                             + "<CKAA20>CKAA20（发票）</CKAA20>"
                             + "<CKAA27>CKAA27（发票）</CKAA27>"
                             + "<BKE151>BKE151（发票）</BKE151>"
                             + "<CKAA40>CKAA40（发票）</CKAA40>"
                             + "<BAC081>BAC081</BAC081>" + cc_foot;
            }
            //住院费用明细删除
            else if (ywlx == "1106")
            {
                cc = cc_head + cc_foot;
            }
            //按套限价项目使用情况上传
            else if (ywlx == "1130")
            {
                cc = cc_head + cc_foot;
            }
            //按套限价项目查询
            else if (ywlx == "1131")
            {
                cc = cc_head + "<AKB020>定点医疗机构编码</AKB020>"
                             + "<AKC190>门诊住院流水号</AKC190>"
                             + "<AKC225>单价</AKC225>"
                             + "<AKC226>数量</AKC226>"
                             + "<AKC227>金额</AKC227>"
                             + "<AKC222>中心收费项目编码</AKC222>"
                             + "<AKC223>中心收费项目名称</AKC223>"
                             + "<AKA069>自付比例</AKA069>"
                             + "<CKAA06>限额内金额</CKAA06>"
                             + "<AKC253>超限自费金额</AKC253>"
                             + "<AKC783>免收金额</AKC783>"
                             + "<AKA070>剂型</AKA070>"
                             + "<AKC604>规格</AKC604>"
                             + "<AKC221>处方日期</AKC221>" + cc_foot;
            }
            else if (ywlx == "1120")//医疗费信息对账
            {
                cc = cc_head + "<AKE150>对帐结果</AKE150>"
                             + "<AAE030>开始时间</AAE030>"
                             + "<AAE031>终止时间</AAE031>"
                             + "<CKA130>业务类型</CKA130>"
                             + "<BKB001>正交易笔数</BKB001>"
                             + "<BKB002>反交易笔数</BKB002>"
                             + "<AKC264>接收方医疗费总额</AKC264>"
                             + "<AKC255>接收方帐户支付合计</AKC255>"
                             + "<AKC260>接收方统筹基金支付合计</AKC260>"
                             + "<AKC261>接收方现金支付合计</AKC261>"
                             + "<AKC706>接收方大病救助基金支付</AKC706>"
                             + "<AKC707>接收方公务员补助合计</AKC707>"
                             + "<AKC708>接收方其他基金支付</AKC708>" + cc_foot;
            }
            //医疗费信息对账（明细）
            else if (ywlx == "1121")
            {
                cc = cc_head + "<CKAA08>对账状态</CKAA08>"
                             + "<AAA204>提示信息</AAA204>"
                             + "<MSGID>发送方交易流水号</MSGID>"
                             + "<REFMSGID>接收方交易流水号</REFMSGID>"
                             + "<AKC264>接收方医疗费总额</AKC264>"
                             + "<AKC255>接收方帐户支付合计</AKC255>"
                             + "<AKC260>接收方统筹基金支付合计</AKC260>"
                             + "<AKC261>接收方现金支付合计</AKC261>"
                             + "<AKC706>接收方大病救助基金支付</AKC706>"
                             + "<AKC707>接收方公务员补助合计</AKC707>"
                             + "<AKC708>接收方其他基金支付</AKC708>" + cc_foot;
            }
            //无费退院
            else if (ywlx == "1201")
            {
                cc = cc_head + cc_foot;
            }
            //门诊结算回退
            else if (ywlx == "1202")
            {
                cc = cc_head + "<AKC264>医疗费总额</AKC264>"
                             + "<AKC261>本次现金支付金额</AKC261>"
                             + "<AKC087>结算后卡余额</AKC087>"
                             + "<AAE040>结算回退时间</AAE040>" + cc_foot;
            }
            //住院结算召回
            else if (ywlx == "1203")
            {
                cc = cc_head + "<AKC264>医疗费总额</AKC264>"
                             + "<AKC261>本次现金支付金额</AKC261>"
                             + "<AKC087>结算后卡余额</AKC087>"
                             + "<AAE040>结算回退时间</AAE040>" + cc_foot;
            }
            //冲正交易
            else if (ywlx == "1301")
            {
                cc = cc_head + cc_foot;
            }

            //异地就医急诊住院申报
            else if (ywlx == "1604")
            {
                cc = cc_head + cc_foot;
            }

            //科室下载
            else if (ywlx == "1630")
            {
                cc = cc_head + "<OUTROW>"
                             + "<AKF001>0001</AKF001>"//科室编码
                             + "<AKF003>001</AKF003>"//科室代码
                             + "<AKF002>外科</AKF002>"//科室名称
                             + "<AKB020>4545</AKB020>"//医疗机构编号
                             + "<BKF075>02</BKF075>"//科室分类
                             + "<AKF015>10</AKF015>"//床位数
                             + "<AKF008>22</AKF008>"//职工数量
                             + "<BKF005>张三</BKF005>"//负责人
                             + "<BKF006>110112119</BKF006>"//联系电话
                             + "<BKF061>治病</BKF061>"//业务范围
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKF001>0002</AKF001>"//科室编码
                             + "<AKF003>002</AKF003>"//科室代码
                             + "<AKF002>外科2</AKF002>"//科室名称
                             + "<AKB020>4545</AKB020>"//医疗机构编号
                             + "<BKF075>02</BKF075>"//科室分类
                             + "<AKF015>10</AKF015>"//床位数
                             + "<AKF008>22</AKF008>"//职工数量
                             + "<BKF005>张三2</BKF005>"//负责人
                             + "<BKF006>110112119</BKF006>"//联系电话
                             + "<BKF061>治病</BKF061>"//业务范围
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKF001>0003</AKF001>"//科室编码
                             + "<AKF003>003</AKF003>"//科室代码
                             + "<AKF002>外科3</AKF002>"//科室名称
                             + "<AKB020>4545</AKB020>"//医疗机构编号
                             + "<BKF075>02</BKF075>"//科室分类
                             + "<AKF015>10</AKF015>"//床位数
                             + "<AKF008>22</AKF008>"//职工数量
                             + "<BKF005>张三3</BKF005>"//负责人
                             + "<BKF006>110112119</BKF006>"//联系电话
                             + "<BKF061>治病</BKF061>"//业务范围
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + cc_foot;
            }
            //医师下载
            else if (ywlx == "1631")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>1</CURRENTPAGE>"//当前页
                             + "<TOTALPAGE>12</TOTALPAGE>"//总页数
                             + "<TOTALRECORD>10</TOTALRECORD>"//总记录数
                             + "<PAGESIZE>100</PAGESIZE>"//每页条数
                             + "<OUTROW>"
                             + "<BKF050>0001</BKF050>"//
                             + "<BKF051>0001</BKF051>"//定点医师编码
                             + "<AKC273>张三1</AKC273>"//医师姓名
                             + "<AAC002>15478954987547895</AAC002>"//证件号码
                             + "<AAC004>1</AAC004>"//性别
                             + "<AAC006>20190804</AAC006>"//出生日期
                             + "<AAC011>11</AAC011>"//学历
                             + "<BKC113>1</BKC113>"//学位
                             + "<AAC005>01</AAC005>"//民族
                             + "<AAB301>130100</AAB301>"//行政区划
                             + "<BKF063>110</BKF063>"//医师类别
                             + "<BKC114>1001</BKC114>"//所学专业
                             + "<BKF066>101</BKF066>"//执  范围
                             + "<AAF009>231</AAF009>"//卫生技术人员专业技术职务
                             + "<BKF573>11111</BKF573>"//资格证书编码
                             + "<BKF574>11111</BKF574>"//注册证书编号
                             + "<BKC115>20190505</BKC115>"//发证日期
                             + "<BKF065>10</BKF065>"//执业类别
                             + "<BKF569>mt</BKF569>"//执业地点
                             + "<AAE005>110112119</AAE005>"//手机
                             + "<AKB020>22222</AKB020>"//医疗机构编码
                             + "<AKF001>4545</AKF001>"//科室编码
                             + "<AAC020>30</AAC020>"//行政职务
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<BKF050>0002</BKF050>"//
                             + "<BKF051>0002</BKF051>"//定点医师编码
                             + "<AKC273>张三2</AKC273>"//医师姓名
                             + "<AAC002>15478954987547896</AAC002>"//证件号码
                             + "<AAC004>1</AAC004>"//性别
                             + "<AAC006>20190804</AAC006>"//出生日期
                             + "<AAC011>11</AAC011>"//学历
                             + "<BKC113>1</BKC113>"//学位
                             + "<AAC005>01</AAC005>"//民族
                             + "<AAB301>130100</AAB301>"//行政区划
                             + "<BKF063>110</BKF063>"//医师类别
                             + "<BKC114>1001</BKC114>"//所学专业
                             + "<BKF066>101</BKF066>"//执  范围
                             + "<AAF009>231</AAF009>"//卫生技术人员专业技术职务
                             + "<BKF573>11111</BKF573>"//资格证书编码
                             + "<BKF574>11111</BKF574>"//注册证书编号
                             + "<BKC115>20190505</BKC115>"//发证日期
                             + "<BKF065>10</BKF065>"//执业类别
                             + "<BKF569>mt</BKF569>"//执业地点
                             + "<AAE005>110112119</AAE005>"//手机
                             + "<AKB020>22222</AKB020>"//医疗机构编码
                             + "<AKF001>4545</AKF001>"//科室编码
                             + "<AAC020>30</AAC020>"//行政职务
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<BKF050>0003</BKF050>"//
                             + "<BKF051>0003</BKF051>"//定点医师编码
                             + "<AKC273>张三3</AKC273>"//医师姓名
                             + "<AAC002>15478954987547898</AAC002>"//证件号码
                             + "<AAC004>1</AAC004>"//性别
                             + "<AAC006>20190804</AAC006>"//出生日期
                             + "<AAC011>11</AAC011>"//学历
                             + "<BKC113>1</BKC113>"//学位
                             + "<AAC005>01</AAC005>"//民族
                             + "<AAB301>130100</AAB301>"//行政区划
                             + "<BKF063>110</BKF063>"//医师类别
                             + "<BKC114>1001</BKC114>"//所学专业
                             + "<BKF066>101</BKF066>"//执  范围
                             + "<AAF009>231</AAF009>"//卫生技术人员专业技术职务
                             + "<BKF573>11111</BKF573>"//资格证书编码
                             + "<BKF574>11111</BKF574>"//注册证书编号
                             + "<BKC115>20190505</BKC115>"//发证日期
                             + "<BKF065>10</BKF065>"//执业类别
                             + "<BKF569>mt</BKF569>"//执业地点
                             + "<AAE005>110112119</AAE005>"//手机
                             + "<AKB020>22222</AKB020>"//医疗机构编码
                             + "<AKF001>4545</AKF001>"//科室编码
                             + "<AAC020>30</AAC020>"//行政职务
                             + "<AAE013>备注</AAE013>"//备注
                             + "</OUTROW>"
                             + "</PAGE>" + cc_foot;
            }

            //三目下载
            else if (ywlx == "1632")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>1</CURRENTPAGE>"//当前页
                             + "<TOTALPAGE>10</TOTALPAGE>"//总页数
                             + "<TOTALRECORD>100</TOTALRECORD>"//总记录数
                             + "<PAGESIZE>10</PAGESIZE>";//每页条数
                             
                    //药品目录
                StringReader sr = new StringReader(rc);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                DataTable dt3 = ds.Tables["INPUT"];
                
                    if( dt3.Rows[0]["AKC224"].ToString().Trim() == "1" )
                    {
                        cc += "<OUTROW>"
                            + "<AKA060>15545</AKA060>"//药品编码
                            + "<AKA061>感冒灵01</AKA061>"//通用名称
                            + "<AKA062>gml</AKA062>"//英文名称
                            + "<AKA063>01</AKA063>"//收费类别
                            + "<AKA065>1</AKA065>"//甲乙类标志
                            + "<AKA066>gml</AKA066>"//拼音助记码
                            + "<AKA070>冲剂</AKA070>"//剂型
                            + "<AKA077>15袋/盒</AKA077>"//规格
                            + "<AKA079>感冒灵</AKA079>"//药品商品名
                            + "<AKA081>g</AKA081>"//商品名拼音码
                            + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                            + "<AKA069>0.8</AKA069>"//自付比例
                            + "<AKA069_JM>0.44</AKA069_JM>"//居民自付比例
                            + "<CKAA01>1</CKAA01>"//是否离休可用
                            + "<CKAA02>1</CKAA02>"//限用标志
                            + "<AKA068>85</AKA068>"//限价
                            + "<AAE013>备注</AAE013>"//备注
                            + "<AAE035>2019-08-08</AAE035>"//变更日期
                            + "<AAE030>2019-08-08</AAE030>"//开始时间
                            + "<AAE031>2019-08-08</AAE031>"//结束时间
                            + "<AAE100>1</AAE100>"//是否有效
                            + "<CKAA10>0</CKAA10>"//限价标志
                            + "</OUTROW>";
                        cc += "<OUTROW>"
                            + "<AKA060>15548</AKA060>"//药品编码
                            + "<AKA061>感冒灵02</AKA061>"//通用名称
                            + "<AKA062>gml</AKA062>"//英文名称
                            + "<AKA063>01</AKA063>"//收费类别
                            + "<AKA065>1</AKA065>"//甲乙类标志
                            + "<AKA066>gml</AKA066>"//拼音助记码
                            + "<AKA070>冲剂</AKA070>"//剂型
                            + "<AKA077>15袋/盒</AKA077>"//规格
                            + "<AKA079>感冒灵</AKA079>"//药品商品名
                            + "<AKA081>g</AKA081>"//商品名拼音码
                            + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                            + "<AKA069>0.8</AKA069>"//自付比例
                            + "<AKA069_JM>0.44</AKA069_JM>"//居民自付比例
                            + "<CKAA01>1</CKAA01>"//是否离休可用
                            + "<CKAA02>1</CKAA02>"//限用标志
                            + "<AKA068>85</AKA068>"//限价
                            + "<AAE013>备注</AAE013>"//备注
                            + "<AAE035>2019-08-08</AAE035>"//变更日期
                            + "<AAE030>2019-08-08</AAE030>"//开始时间
                            + "<AAE031>2019-08-08</AAE031>"//结束时间
                            + "<AAE100>1</AAE100>"//是否有效
                            + "<CKAA10>0</CKAA10>"//限价标志
                            + "</OUTROW>";
                        cc += "<OUTROW>"
                            + "<AKA060>15555</AKA060>"//药品编码
                            + "<AKA061>感冒灵03</AKA061>"//通用名称
                            + "<AKA062>gml</AKA062>"//英文名称
                            + "<AKA063>01</AKA063>"//收费类别
                            + "<AKA065>1</AKA065>"//甲乙类标志
                            + "<AKA066>gml</AKA066>"//拼音助记码
                            + "<AKA070>冲剂</AKA070>"//剂型
                            + "<AKA077>15袋/盒</AKA077>"//规格
                            + "<AKA079>感冒灵</AKA079>"//药品商品名
                            + "<AKA081>g</AKA081>"//商品名拼音码
                            + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                            + "<AKA069>0.8</AKA069>"//自付比例
                            + "<AKA069_JM>0.44</AKA069_JM>"//居民自付比例
                            + "<CKAA01>1</CKAA01>"//是否离休可用
                            + "<CKAA02>1</CKAA02>"//限用标志
                            + "<AKA068>85</AKA068>"//限价
                            + "<AAE013>备注</AAE013>"//备注
                            + "<AAE035>2019-08-08</AAE035>"//变更日期
                            + "<AAE030>2019-08-08</AAE030>"//开始时间
                            + "<AAE031>2019-08-08</AAE031>"//结束时间
                            + "<AAE100>1</AAE100>"//是否有效
                            + "<CKAA10>0</CKAA10>"//限价标志
                            + "</OUTROW>";
                    }
                    
                    //诊疗目录
                    if (dt3.Rows[0]["AKC224"].ToString().Trim() == "2")
                    {

                        cc += "<OUTROW>"
                         + "<AKA090>258749</AKA090>"//项目编码
                         + "<AKA091>足疗01</AKA091>"//项目名称
                         + "<AKA063>5</AKA063>"//收费类别
                         + "<AKA065>1</AKA065>"//甲乙类标志
                         + "<AKA066>zl</AKA066>"//拼音助记码
                         + "<AKA076>次</AKA076>"//单位
                         + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                         + "<AKA068I>10</AKA068I>"//县级限价
                         + "<AKA068II>9</AKA068II>"//市级限价
                         + "<AKA068III>8</AKA068III>"//省级限价
                         + "<PUB_AKA068I>10</PUB_AKA068I>"//公立医院县级限价
                         + "<PUB_AKA068II>9</PUB_AKA068II>"//公立医院市级限价
                         + "<PUB_AKA068III>8</PUB_AKA068III>"//公立医院省级限价
                         + "<CKAA07>1</CKAA07>"//目录适用类型标志
                         + "<AKA069>0.58</AKA069>"//自付比例
                         + "<AKA069_JM>0.8</AKA069_JM>"//居民自付比例
                         + "<CKAA01>1</CKAA01>"//是否离休可用
                         + "<AAE013>备注</AAE013>"//备注
                         + "<AAE035>2019-08-08</AAE035>"//变更日期
                         + "<AAE030>2019-08-08</AAE030>"//开始时间
                         + "<AAE031>2019-08-08</AAE031>"//结束时间
                         + "<AAE100>1</AAE100>"//是否有效
                         + "<BKA643>54848</BKA643>"//物价编码
                         + "<CKAA10>0</CKAA10>"//限价标志
                         + "</OUTROW>";
                        cc += "<OUTROW>"
                         + "<AKA090>258750</AKA090>"//项目编码
                         + "<AKA091>足疗02</AKA091>"//项目名称
                         + "<AKA063>5</AKA063>"//收费类别
                         + "<AKA065>1</AKA065>"//甲乙类标志
                         + "<AKA066>zl</AKA066>"//拼音助记码
                         + "<AKA076>次</AKA076>"//单位
                         + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                         + "<AKA068I>10</AKA068I>"//县级限价
                         + "<AKA068II>9</AKA068II>"//市级限价
                         + "<AKA068III>8</AKA068III>"//省级限价
                         + "<PUB_AKA068I>10</PUB_AKA068I>"//公立医院县级限价
                         + "<PUB_AKA068II>9</PUB_AKA068II>"//公立医院市级限价
                         + "<PUB_AKA068III>8</PUB_AKA068III>"//公立医院省级限价
                         + "<CKAA07>1</CKAA07>"//目录适用类型标志
                         + "<AKA069>0.58</AKA069>"//自付比例
                         + "<AKA069_JM>0.8</AKA069_JM>"//居民自付比例
                         + "<CKAA01>1</CKAA01>"//是否离休可用
                         + "<AAE013>备注</AAE013>"//备注
                         + "<AAE035>2019-08-08</AAE035>"//变更日期
                         + "<AAE030>2019-08-08</AAE030>"//开始时间
                         + "<AAE031>2019-08-08</AAE031>"//结束时间
                         + "<AAE100>1</AAE100>"//是否有效
                         + "<BKA643>54848</BKA643>"//物价编码
                         + "<CKAA10>0</CKAA10>"//限价标志
                         + "</OUTROW>";
                        cc += "<OUTROW>"
                         + "<AKA090>258799</AKA090>"//项目编码
                         + "<AKA091>足疗03</AKA091>"//项目名称
                         + "<AKA063>5</AKA063>"//收费类别
                         + "<AKA065>1</AKA065>"//甲乙类标志
                         + "<AKA066>zl</AKA066>"//拼音助记码
                         + "<AKA076>次</AKA076>"//单位
                         + "<CKAA00>生产厂家</CKAA00>"//生产厂家
                         + "<AKA068I>10</AKA068I>"//县级限价
                         + "<AKA068II>9</AKA068II>"//市级限价
                         + "<AKA068III>8</AKA068III>"//省级限价
                         + "<PUB_AKA068I>10</PUB_AKA068I>"//公立医院县级限价
                         + "<PUB_AKA068II>9</PUB_AKA068II>"//公立医院市级限价
                         + "<PUB_AKA068III>8</PUB_AKA068III>"//公立医院省级限价
                         + "<CKAA07>1</CKAA07>"//目录适用类型标志
                         + "<AKA069>0.58</AKA069>"//自付比例
                         + "<AKA069_JM>0.8</AKA069_JM>"//居民自付比例
                         + "<CKAA01>1</CKAA01>"//是否离休可用
                         + "<AAE013>备注</AAE013>"//备注
                         + "<AAE035>2019-08-08</AAE035>"//变更日期
                         + "<AAE030>2019-08-08</AAE030>"//开始时间
                         + "<AAE031>2019-08-08</AAE031>"//结束时间
                         + "<AAE100>1</AAE100>"//是否有效
                         + "<BKA643>54848</BKA643>"//物价编码
                         + "<CKAA10>0</CKAA10>"//限价标志
                         + "</OUTROW>";
                    }
                    //服务设施目录
                    if (dt3.Rows[0]["AKC224"].ToString().Trim() == "3")
                    {
                        cc += "<OUTROW>"
                        + "<AKA100>157748</AKA100>"//医疗服务设施编码
                        + "<AKA102>绷带01</AKA102>"//服务设施名称
                        + "<AKA063>10</AKA063>"//收费类别
                        + "<AKA066>bd</AKA066>"//拼音助记码
                        + "<AKA104>5.89</AKA104>"//支付标准
                        + "<AKA068I>19</AKA068I>"//县级限价
                        + "<AKA068II>18</AKA068II>"//市级限价
                        + "<AKA068III>17</AKA068III>"//省级限价
                        + "<PUB_AKA068I>16</PUB_AKA068I>"//公立医院县级限价
                        + "<PUB_AKA068II>15</PUB_AKA068II>"//公立医院市级限价
                        + "<PUB_AKA068III>14</PUB_AKA068III>"//公立医院省级限价
                        + "<CKAA07>1</CKAA07>"//目录适用类型标志
                        + "<AKA069>0.14</AKA069>"//自付比例
                        + "<AKA069_JM>44.22</AKA069_JM>"//居民自付比例
                        + "<CKAA01>1</CKAA01>"//是否离休可用
                        + "<AAE035>2019-08-05</AAE035>"//变更日期
                        + "<AAE030>2019-08-05</AAE030>"//开始时间
                        + "<AAE031>2019-08-05</AAE031>"//结束时间
                        + "<AAE100>1</AAE100>"//是否有效
                        + "<BKA643>65644</BKA643>"//物价编码
                        + "<CKAA10>1</CKAA10>"//限价标志
                        +"</OUTROW>";
                        cc += "<OUTROW>"
                        + "<AKA100>157780</AKA100>"//医疗服务设施编码
                        + "<AKA102>绷带02</AKA102>"//服务设施名称
                        + "<AKA063>10</AKA063>"//收费类别
                        + "<AKA066>bd</AKA066>"//拼音助记码
                        + "<AKA104>5.89</AKA104>"//支付标准
                        + "<AKA068I>19</AKA068I>"//县级限价
                        + "<AKA068II>18</AKA068II>"//市级限价
                        + "<AKA068III>17</AKA068III>"//省级限价
                        + "<PUB_AKA068I>16</PUB_AKA068I>"//公立医院县级限价
                        + "<PUB_AKA068II>15</PUB_AKA068II>"//公立医院市级限价
                        + "<PUB_AKA068III>14</PUB_AKA068III>"//公立医院省级限价
                        + "<CKAA07>1</CKAA07>"//目录适用类型标志
                        + "<AKA069>0.14</AKA069>"//自付比例
                        + "<AKA069_JM>44.22</AKA069_JM>"//居民自付比例
                        + "<CKAA01>1</CKAA01>"//是否离休可用
                        + "<AAE035>2019-08-05</AAE035>"//变更日期
                        + "<AAE030>2019-08-05</AAE030>"//开始时间
                        + "<AAE031>2019-08-05</AAE031>"//结束时间
                        + "<AAE100>1</AAE100>"//是否有效
                        + "<BKA643>65644</BKA643>"//物价编码
                        + "<CKAA10>1</CKAA10>"//限价标志
                        + "</OUTROW>";
                        cc += "<OUTROW>"
                        + "<AKA100>157954</AKA100>"//医疗服务设施编码
                        + "<AKA102>绷带03</AKA102>"//服务设施名称
                        + "<AKA063>10</AKA063>"//收费类别
                        + "<AKA066>bd</AKA066>"//拼音助记码
                        + "<AKA104>5.89</AKA104>"//支付标准
                        + "<AKA068I>19</AKA068I>"//县级限价
                        + "<AKA068II>18</AKA068II>"//市级限价
                        + "<AKA068III>17</AKA068III>"//省级限价
                        + "<PUB_AKA068I>16</PUB_AKA068I>"//公立医院县级限价
                        + "<PUB_AKA068II>15</PUB_AKA068II>"//公立医院市级限价
                        + "<PUB_AKA068III>14</PUB_AKA068III>"//公立医院省级限价
                        + "<CKAA07>1</CKAA07>"//目录适用类型标志
                        + "<AKA069>0.14</AKA069>"//自付比例
                        + "<AKA069_JM>44.22</AKA069_JM>"//居民自付比例
                        + "<CKAA01>1</CKAA01>"//是否离休可用
                        + "<AAE035>2019-08-05</AAE035>"//变更日期
                        + "<AAE030>2019-08-05</AAE030>"//开始时间
                        + "<AAE031>2019-08-05</AAE031>"//结束时间
                        + "<AAE100>1</AAE100>"//是否有效
                        + "<BKA643>65644</BKA643>"//物价编码
                        + "<CKAA10>1</CKAA10>"//限价标志
                        + "</OUTROW>";
                    }
                               
                                  cc+= "</PAGE>" + cc_foot;
            }
            //三目对照关系申报
            else if (ywlx == "1633")
            {
                cc = cc_head + cc_foot;
            }
            //三目对照关系下载
            else if (ywlx == "1634")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>当前页</CURRENTPAGE>"
                             + "<TOTALPAGE>总页数</TOTALPAGE>"
                             + "<TOTALRECORD>总记录数</TOTALRECORD>"
                             + "<PAGESIZE>每页条数</PAGESIZE>";
                StringReader sr = new StringReader(rc);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                DataTable dt3 = ds.Tables["INPUT"];

                //药品目录
                if (dt3.Rows[0]["AKC224"].ToString().Trim() == "1")
                {
                    cc += "<OUTROW>"
                             + "<AKA060>N86980571000015</AKA060>"//药品编码
                             + "<AKA061>丁二磺酸腺苷蛋氨酸肠溶片</AKA061>"//通用名称
                             + "<AKC515>10003301</AKC515>"//医院收费项目编码
                             + "<AKC516>丁二磺酸腺苷蛋氨酸肠溶片</AKC516>"//医院收费项目名称
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>2019-08-08</AAE015>"//审核时间
                             + "<AAE016>1</AAE016>"//审核标志
                             + "<BAE001></BAE001>"//审核说明
                             + "<AAE030>2019-08-08</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//结束时间
                             + "<AAE100>1</AAE100>"//是否有效
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA060>N86902699002566</AKA060>"//药品编码
                             + "<AKA061>卡托普利片</AKA061>"//通用名称
                             + "<AKC515>9925</AKC515>"//医院收费项目编码
                             + "<AKC516>卡托普利片</AKC516>"//医院收费项目名称
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>2019-08-08</AAE015>"//审核时间
                             + "<AAE016>0</AAE016>"//审核标志
                             + "<BAE001></BAE001>"//审核说明
                             + "<AAE030>2019-08-08</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//结束时间
                             + "<AAE100>0</AAE100>"//是否有效
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA060>N86903546000964</AKA060>"//药品编码
                             + "<AKA061>50/50混合重组人胰岛素注射液</AKA061>"//通用名称
                             + "<AKC515>23550</AKC515>"//医院收费项目编码
                             + "<AKC516>50/50混合重组人胰岛素注射液</AKC516>"//医院收费项目名称
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>2019-08-08</AAE015>"//审核时间
                             + "<AAE016>2</AAE016>"//审核标志
                             + "<BAE001>不让你通过</BAE001>"//审核说明
                             + "<AAE030>2019-08-08</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//结束时间
                             + "<AAE100>1</AAE100>"//是否有效
                             + "</OUTROW>";
                             
                }


                          
                    //诊疗目录
                    if (dt3.Rows[0]["AKC224"].ToString().Trim() == "2")
                {
                    cc += "<OUTROW>"
                       + "<AKA090>项目编码</AKA090>"
                       + "<AKA091>项目名称</AKA091>"
                       + "<AKC515>医院收费项目编码</AKC515>"
                       + "<AKC516>医院收费项目名称</AKC516>"
                       + "<AAE014>审核人</AAE014>"
                       + "<AAE015>审核时间</AAE015>"
                       + "<AAE016>审核标志</AAE016>"
                       + "<BAE001>审核说明</BAE001>"
                       + "<AAE030>开始时间</AAE030>"
                       + "<AAE031>结束时间</AAE031>"
                       + "<AAE100>是否有效</AAE100>"
                       + "</OUTROW>"
                       + "<OUTROW>"
                       + "<AKA090>项目编码</AKA090>"
                       + "<AKA091>项目名称</AKA091>"
                       + "<AKC515>医院收费项目编码</AKC515>"
                       + "<AKC516>医院收费项目名称</AKC516>"
                       + "<AAE014>审核人</AAE014>"
                       + "<AAE015>审核时间</AAE015>"
                       + "<AAE016>审核标志</AAE016>"
                       + "<BAE001>审核说明</BAE001>"
                       + "<AAE030>开始时间</AAE030>"
                       + "<AAE031>结束时间</AAE031>"
                       + "<AAE100>是否有效</AAE100>"
                       + "</OUTROW>"
                       + "<OUTROW>"
                       + "<AKA090>项目编码</AKA090>"
                       + "<AKA091>项目名称</AKA091>"
                       + "<AKC515>医院收费项目编码</AKC515>"
                       + "<AKC516>医院收费项目名称</AKC516>"
                       + "<AAE014>审核人</AAE014>"
                       + "<AAE015>审核时间</AAE015>"
                       + "<AAE016>审核标志</AAE016>"
                       + "<BAE001>审核说明</BAE001>"
                       + "<AAE030>开始时间</AAE030>"
                       + "<AAE031>结束时间</AAE031>"
                       + "<AAE100>是否有效</AAE100>"
                       + "</OUTROW>";
                }
                             
                    //服务设施目录
                    if (dt3.Rows[0]["AKC224"].ToString().Trim() == "3")
                {
                    cc += "<OUTROW>"
                             + "<AKA100>医疗服务设施编码</AKA100>"
                             + "<AKA102>服务设施名称</AKA102>"
                             + "<AKC515>医院收费项目编码</AKC515>"
                             + "<AKC516>医院收费项目名称</AKC516>"
                             + "<AAE014>审核人</AAE014>"
                             + "<AAE015>审核时间</AAE015>"
                             + "<AAE016>审核标志</AAE016>"
                             + "<BAE001>审核说明</BAE001>"
                             + "<AAE030>开始时间</AAE030>"
                             + "<AAE031>结束时间</AAE031>"
                             + "<AAE100>是否有效</AAE100>"
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA100>医疗服务设施编码</AKA100>"
                             + "<AKA102>服务设施名称</AKA102>"
                             + "<AKC515>医院收费项目编码</AKC515>"
                             + "<AKC516>医院收费项目名称</AKC516>"
                             + "<AAE014>审核人</AAE014>"
                             + "<AAE015>审核时间</AAE015>"
                             + "<AAE016>审核标志</AAE016>"
                             + "<BAE001>审核说明</BAE001>"
                             + "<AAE030>开始时间</AAE030>"
                             + "<AAE031>结束时间</AAE031>"
                             + "<AAE100>是否有效</AAE100>"
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA100>医疗服务设施编码</AKA100>"
                             + "<AKA102>服务设施名称</AKA102>"
                             + "<AKC515>医院收费项目编码</AKC515>"
                             + "<AKC516>医院收费项目名称</AKC516>"
                             + "<AAE014>审核人</AAE014>"
                             + "<AAE015>审核时间</AAE015>"
                             + "<AAE016>审核标志</AAE016>"
                             + "<BAE001>审核说明</BAE001>"
                             + "<AAE030>开始时间</AAE030>"
                             + "<AAE031>结束时间</AAE031>"
                             + "<AAE100>是否有效</AAE100>"
                             + "</OUTROW>";

                }
                             
                           cc+= "</PAGE>" + cc_foot;
            }
            //病种目录下载
            else if (ywlx == "1635")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>1</CURRENTPAGE>"//当前页
                             + "<TOTALPAGE>10</TOTALPAGE>"//总页数
                             + "<TOTALRECORD>100</TOTALRECORD>"//总记录数
                             + "<PAGESIZE>10</PAGESIZE>"//每页条数
                             + "<OUTROW>"
                             + "<AKA120>001</AKA120>"//病种编码
                             + "<AKA121>发烧1</AKA121>"//病种名称
                             + "<AKA123>0</AKA123>"//病种类别
                             + "<AKA066>asd</AKA066>"//拼音助记码
                             + "<AAE100>0</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE035>20190808000000</AAE035>"//变更日期
                             + "<AAE030>20190808</AAE030>"//开始时间
                             + "<AAE031>20190808</AAE031>"//结束时间
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA120>002</AKA120>"//病种编码
                             + "<AKA121>发烧2</AKA121>"//病种名称
                             + "<AKA123>1</AKA123>"//病种类别
                             + "<AKA066>asd</AKA066>"//拼音助记码
                             + "<AAE100>0</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE035>20190808000000</AAE035>"//变更日期
                             + "<AAE030>20190808</AAE030>"//开始时间
                             + "<AAE031>20190808</AAE031>"//结束时间
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA120>003</AKA120>"//病种编码
                             + "<AKA121>发烧3</AKA121>"//病种名称
                             + "<AKA123>3</AKA123>"//病种类别
                             + "<AKA066>asd</AKA066>"//拼音助记码
                             + "<AAE100>0</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE035>20190808000000</AAE035>"//变更日期
                             + "<AAE030>20190808</AAE030>"//开始时间
                             + "<AAE031>20190808</AAE031>"//结束时间
                             + "</OUTROW>"
                             + "</PAGE>" + cc_foot;
            }
            //费用明细下载
            else if (ywlx == "1636")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>当前页</CURRENTPAGE>"
                             + "<TOTALPAGE>总页数</TOTALPAGE>"
                             + "<TOTALRECORD>总记录数</TOTALRECORD>"
                             + "<PAGESIZE>每页条数</PAGESIZE>"
                             + "<OUTROW>"
                             + "<AKC275>发送方交易流水号</AKC275>"
                             + "<AKC276>接收方交易流水号</AKC276>"
                             + "<AKB020>定点医疗机构编码</AKB020>"
                             + "<AKC190>门诊住院流水号</AKC190>"
                             + "<AKC515>医院收费项目编码</AKC515>"
                             + "<AKC516>医院收费项目名称</AKC516>"
                             + "<AKA065>项目等级</AKA065>"
                             + "<AKA063>收费类别</AKA063>"
                             + "<AKC225>单价</AKC225>"
                             + "<AKC226>数量</AKC226>"
                             + "<AKC227>金额</AKC227>"
                             + "<AKC222>中心收费项目编码</AKC222>"
                             + "<AKC223>中心收费项目名称</AKC223>"
                             + "<AKA069>自付比例</AKA069>"
                             + "<CKAA06>限额内金额</CKAA06>"
                             + "<AKC253>超限自费金额</AKC253>"
                             + "<AKC783>免收金额</AKC783>"
                             + "<AKA070>剂型</AKA070>"
                             + "<AKC604>规格</AKC604>"
                             + "<AKC221>处方日期</AKC221>"
                             + "<AKC378>医院处方流水号</AKC378>"
                             + "</OUTROW>"
                             + "</PAGE>" + cc_foot;
            }
            //结算信息下载
            else if (ywlx == "1637")
            {
                cc = cc_head + "<PAGE>"
                             + "<CURRENTPAGE>当前页</CURRENTPAGE>"
                             + "<TOTALPAGE>总页数</TOTALPAGE>"
                             + "<TOTALRECORD>总记录数</TOTALRECORD>"
                             + "<PAGESIZE>每页条数</PAGESIZE>"
                             + "<OUTROW>"
                             + "<AKB020>定点医疗机构编号</AKB020>"
                             + "<AKC190>门诊住院流水号</AKC190>"
                             + "<AAE072>单据号</AAE072>"
                             + "<AAE040>结算日期</AAE040>"
                             + "<AAC001>个人编号</AAC001>"
                             + "<AKC020>社保卡号</AKC020>"
                             + "<AKC275>发送方交易流水号</AKC275>"
                             + "<AKC276>接收方交易流水号</AKC276>"
                             + "<AKC281>撤销（或被撤销）的发送方交易流水号</AKC281>"
                             + "<AKC282>撤销（或被撤销）的接收方交易流水号</AKC282>"
                             + "<AKC283>冲正（或被冲正）的发送方交易流水号</AKC283>"
                             + "<AKC284>被冲正（或被冲正）的接收方交易流水号</AKC284>"
                             + "<AKC332>业务周期号</AKC332>"
                             + "<AKC264>医疗费总额</AKC264>"
                             + "<AKC255>帐户支付</AKC255>"
                             + "<AKC260>统筹基金支付</AKC260>"
                             + "<AKC261>现金支付</AKC261>"
                             + "<AKC706>大病救助基金支付</AKC706>"
                             + "<AKC707>公务员补助支付</AKC707>"
                             + "<AKC708>其他基金支出</AKC708>"
                             + "<MSGNO>交易代码</MSGNO>"
                             + "<CKAA08>对账状态</CKAA08>"
                             + "<CKAA09>对账时间</CKAA09>"
                             + "<CKAA20>基本提高支付（发票）</CKAA20>"
                             + "<CKAA27>大病提高支付（发票）</CKAA27>"
                             + "<BKE151>医疗救助支付（发票）</BKE151>"
                             + "<CKAA40>医疗救助补充支付（发票）</CKAA40>"
                             + "<BAC081>贫困人口标志</BAC081>"
                             + "</OUTROW>"
                             + "</PAGE>" + cc_foot;
            }
            //病种可用三目范围下载
            else if (ywlx == "1638")
            {
                cc = cc_head + " <PAGE>"
                             + "<CURRENTPAGE>1</CURRENTPAGE>"//当前页
                             + "<TOTALPAGE>10</TOTALPAGE>"//总页数
                             + "<TOTALRECORD>100</TOTALRECORD>"//总记录数
                             + "<PAGESIZE>10</PAGESIZE>"//每页条数
                             + "<OUTROW>"
                             + "<AKA130>11</AKA130>"//医疗类别
                             + "<AKA120>454</AKA120>"//病种编码
                             + "<AKE001>565</AKE001>"//药品/项目编码
                             + "<AAE100>1</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE030>0912-08-05</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//终止时间
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA130>12</AKA130>"//医疗类别
                             + "<AKA120>454</AKA120>"//病种编码
                             + "<AKE001>565</AKE001>"//药品/项目编码
                             + "<AAE100>1</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE030>0912-08-05</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//终止时间
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<AKA130>13</AKA130>"//医疗类别
                             + "<AKA120>454</AKA120>"//病种编码
                             + "<AKE001>565</AKE001>"//药品/项目编码
                             + "<AAE100>1</AAE100>"//有效标志
                             + "<AAE013>备注</AAE013>"//备注
                             + "<AAE030>0912-08-05</AAE030>"//开始时间
                             + "<AAE031>2019-08-08</AAE031>"//终止时间
                             + "</OUTROW>"
                             + "</PAGE>"
                             + cc_foot;
            }
            //异地就医急诊住院申报信息查询
            else if (ywlx == "1639")
            {
                cc = cc_head + "<OUTROW>"
                             + "<BAZ061>社保卡 SID</BAZ061>"//社保卡
                             + "<AKC020>社保卡号</AKC020>"//社保卡号
                             + "<AAC002>公民身份号码</AAC002>"//公民身份号码
                             + "<AAC003>姓名</AAC003>"//姓名
                             + "<BKF040>中心科室编码</BKF040>"//中心科室编码
                             + "<AKC025>科室名称</AKC025>"//科室名称
                             + "<AKE020>床号</AKE020>"//床号
                             + "<AKC600>病情摘要</AKC600>"//病情摘要
                             + "<AKC141>诊断</AKC141>"//诊断
                             + "<AAE004>联系人姓名</AAE004>"//联系人姓名
                             + "<AAE005>联系电话</AAE005>"//联系电话
                             + "<AAE004_H>医院联系人姓名</AAE004_H>"//医院联系人姓名
                             + "<AAE005_H>医院联系电话</AAE005_H>"//医院联系电话
                             + "<AAE011>登记人</AAE011>"//登记人
                             + "<AAE036>登记日期</AAE036>"//登记日期
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>审核时间</AAE015>"//审核时间
                             + "<AAE022>0</AAE022>"//审批结果
                             + "<AAE023>审批结果内容</AAE023>"//审批结果内容
                             + "<AAE073>审批编号</AAE073>"//审批编号
                             + "<AAE100>1</AAE100>"//有效标志
                             + "<AKB093>申报流水号</AKB093>"//申报流水号
                             + "<OUTROW>"
                             + "<BAZ061>社保卡 SID</BAZ061>"//社保卡
                             + "<AKC020>社保卡号</AKC020>"//社保卡号
                             + "<AAC002>公民身份号码</AAC002>"//公民身份号码
                             + "<AAC003>姓名</AAC003>"//姓名
                             + "<BKF040>中心科室编码</BKF040>"//中心科室编码
                             + "<AKC025>科室名称</AKC025>"//科室名称
                             + "<AKE020>床号</AKE020>"//床号
                             + "<AKC600>病情摘要</AKC600>"//病情摘要
                             + "<AKC141>诊断</AKC141>"//诊断
                             + "<AAE004>联系人姓名</AAE004>"//联系人姓名
                             + "<AAE005>联系电话</AAE005>"//联系电话
                             + "<AAE004_H>医院联系人姓名</AAE004_H>"//医院联系人姓名
                             + "<AAE005_H>医院联系电话</AAE005_H>"//医院联系电话
                             + "<AAE011>登记人</AAE011>"//登记人
                             + "<AAE036>登记日期</AAE036>"//登记日期
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>审核时间</AAE015>"//审核时间
                             + "<AAE022>2</AAE022>"//审批结果
                             + "<AAE023>审批结果内容</AAE023>"//审批结果内容
                             + "<AAE073>审批编号</AAE073>"//审批编号
                             + "<AAE100>1</AAE100>"//有效标志
                             + "<AKB093>申报流水号</AKB093>"//申报流水号
                             + "</OUTROW>"
                             + "<OUTROW>"
                             + "<BAZ061>社保卡 SID</BAZ061>"//社保卡
                             + "<AKC020>社保卡号</AKC020>"//社保卡号
                             + "<AAC002>公民身份号码</AAC002>"//公民身份号码
                             + "<AAC003>姓名</AAC003>"//姓名
                             + "<BKF040>中心科室编码</BKF040>"//中心科室编码
                             + "<AKC025>科室名称</AKC025>"//科室名称
                             + "<AKE020>床号</AKE020>"//床号
                             + "<AKC600>病情摘要</AKC600>"//病情摘要
                             + "<AKC141>诊断</AKC141>"//诊断
                             + "<AAE004>联系人姓名</AAE004>"//联系人姓名
                             + "<AAE005>联系电话</AAE005>"//联系电话
                             + "<AAE004_H>医院联系人姓名</AAE004_H>"//医院联系人姓名
                             + "<AAE005_H>医院联系电话</AAE005_H>"//医院联系电话
                             + "<AAE011>登记人</AAE011>"//登记人
                             + "<AAE036>登记日期</AAE036>"//登记日期
                             + "<AAE014>审核人</AAE014>"//审核人
                             + "<AAE015>审核时间</AAE015>"//审核时间
                             + "<AAE022>1</AAE022>"//审批结果
                             + "<AAE023>审批结果内容</AAE023>"//审批结果内容
                             + "<AAE073>审批编号</AAE073>"//审批编号
                             + "<AAE100>0</AAE100>"//有效标志
                             + "<AKB093>申报流水号</AKB093>"//申报流水号
                             + "</OUTROW>"
                             + "</OUTROW>"
                             + cc_foot;
            }
            //中心票据信息查询
            else if (ywlx == "1708")
            {
                cc = cc_head + "<AKC264>医疗费总额</AKC264>"
                              + "<AKC255>本次帐户支付金额</AKC255>"
                              + "<AKC260>本次统筹支付金额</AKC260>"
                              + "<AKC261>本次现金支付金额</AKC261>"
                              + "<AKC706>大病救助基金支付</AKC706>"
                              + "<AKC707>公务员补助支付</AKC707>"
                              + "<AKC708>其他基金支出</AKC708>"
                              + "<AKC263>符合基本医疗保险费用</AKC263>"
                              + "<AKC089>本年符合基本医疗累计</AKC089>"
                              + "<AKC088>本年统筹支出累计</AKC088>"
                              + "<AKC121>本年大病支出累计</AKC121>"
                              + "<AKC256>本次起付标准自付</AKC256>"
                              + "<CKA050>本次起付标准</CKA050>"
                              + "<AKC090>本年住院次数</AKC090>"
                              + "<AKC268>进入统筹费用</AKC268>"
                              + "<AKC278>本次进入公务员费用</AKC278>"
                              + "<AKC279>本次进入大病部分</AKC279>"
                              + "<AKC718>进入其他基金费用</AKC718>"
                              + "<ZKC036>超过大病补充封顶线部分</ZKC036>"
                              + "<AKC262>本次个人帐户应支付金额</AKC262>"
                              + "<AKC252>卡结算前余额</AKC252>"
                              + "<AKC087>卡结算后余额</AKC087>"
                              + "<AKC253>自费费用</AKC253>"
                              + "<AKC254>乙类自付</AKC254>"
                              + "<AKC380>乙类药自付</AKC380>"
                              + "<ZKC032>特检自付</ZKC032>"
                              + "<ZKC034>特治自付</ZKC034>"
                              + "<AKC740>统筹分段自付（第 1 段）</AKC740>"
                              + "<AKC741>统筹分段自付（第 2 段）</AKC741>"
                              + "<AKC742>统筹分段自付（第 3 段）</AKC742>"
                              + "<AKC743>统筹分段自付（第 4 段）</AKC743>"
                              + "<AKC744>统筹分段自付（第 5 段）</AKC744>"
                              + "<AKC745>统筹分段自付（第 6 段）</AKC745>"
                              + "<AKC746>统筹支出（第 1 段）</AKC746>"
                              + "<AKC747>统筹支出（第 2 段）</AKC747>"
                              + "<AKC748>统筹支出（第 3 段）</AKC748>"
                              + "<AKC749>统筹支出（第 4 段）</AKC749>"
                              + "<AKC750>统筹支出（第 5 段）</AKC750>"
                              + "<AKC751>统筹支出（第 6 段）</AKC751>"
                              + "<AKC752>公务员自付</AKC752>"
                              + "<AKC753>其他基金自付</AKC753>"
                              + "<AKC258>超过封顶线个人自付</AKC258>"
                              + "<BKA067>甲类药总费用</BKA067>"
                              + "<BKA068>乙类药总费用</BKA068>"
                              + "<BKA069>丙类药总费用</BKA069>"
                              + "<AKC368>普通检查费用</AKC368>"
                              + "<AKC369>特殊检查费用</AKC369>"
                              + "<AKC370>自费检查费用</AKC370>"
                              + "<AKC374>普通治疗费用</AKC374>"
                              + "<AKC375>特殊治疗费用</AKC375>"
                              + "<AKC376>自费治疗费用</AKC376>"
                              + "<AKC754>总的个人自付金额</AKC754>"
                              + "<AKC755>预留字段 2</AKC755>"
                              + "<AKC756>预留字段</AKC756>"
                              + "<AKC757>预留字段 4</AKC757>"
                              + "<AKC758>预留字段 5</AKC758>"
                              + "<AAE040>结算日期</AAE040>"
                              + "<AKC759>基本账户</AKC759>"
                              + "<AKC760>4%补充账户</AKC760>"
                              + "<AKC761>10%补充账户</AKC761>"
                              + "<AKC762>10%补助账户</AKC762>"
                              + "<AKC763>补充账户</AKC763>"
                              + "<AKC764>补助账户</AKC764>"
                              + "<AKC765>其他账户</AKC765>"
                              + "<AKC766>基本统筹</AKC766>"
                              + "<AKC767>4%补充统筹</AKC767>"
                              + "<AKC768>10%补充统筹</AKC768>"
                              + "<AKC769>10%补助统筹</AKC769>"
                              + "<AKC770>补充统筹</AKC770>"
                              + "<AKC771>补助统筹</AKC771>"
                              + "<AKC772>其他统筹</AKC772>"
                              + "<AKC773>定点医疗机构支付</AKC773>"
                              + "<AKC774>一次性材料费用</AKC774>"
                              + "<AKC775>诊疗项目费用</AKC775>"
                              + "<AKC776>药品费用</AKC776>"
                              + "<AKC777>服务设施费用</AKC777>"
                              + "<BAC081>贫困人口标志</BAC081>" + cc_foot;
            }
            //个人门诊费用明细查询
            else if (ywlx == "1730")
            {
                cc = cc_head + "<OUTROW>" 
                                + "<AKC192>20190831</AKC192>"
                                + "<AKC222>AKC22222</AKC222>"
                                + "<AKC223>布洛芬</AKC223>"
                                + "<AKA070>剂型</AKA070>"
                                + "<AKA077>10片</AKA077>"
                                + "<BKA076>片</BKA076>"
                                + "<AKC226>10</AKC226>"
                                + "<AKB020>AKB020</AKB020>"
                             + "</OUTROW>"
                             + "<OUTROW>"
                                + "<AKC192>20190831</AKC192>"
                                + "<AKC222>AKC33333</AKC222>"
                                + "<AKC223>感冒灵颗粒</AKC223>"
                                + "<AKA070>剂型</AKA070>"
                                + "<AKA077>10包</AKA077>"
                                + "<BKA076>包</BKA076>"
                                + "<AKC226>10</AKC226>"
                                + "<AKB020>AKB020</AKB020>"
                             + "</OUTROW>"
                             + cc_foot;
            }
            //查询住院费用结算清单
            else if (ywlx == "1731")
            {
                cc = cc_head + "<CKAA14>医保类型</CKAA14>"
                           + "<CKAA15>基本医保支付限额 </CKAA15>"
                           + "<CKAA16>大病保险支付限额</CKAA16>"
                           + "<CKAA17>贫困人口大病保险</CKAA17>"
                           + "<CKAA18>医疗补助支付限额</CKAA18>"
                           + "<AKC090>有效住院累计次数</AKC090>"
                           + "<AKC088>基本统筹累计支付</AKC088>"
                           + "<CKAA19>补助起付线累计支付</CKAA19>"
                           + "<ZKC026>补助累计支付</ZKC026>"
                           + "<AKC252>个人账户余额</AKC252>"
                           + "<BKE106>累计进入大病费用</BKE106>"
                           + "<AKC787>大病起付线累计支付</AKC787>"
                           + "<AKC121>大病保险累计支付</AKC121>"
                           + "<BKE152>医疗救助累计支付</BKE152>"
                           + "<AKC264>费用总额</AKC264>"
                           + "<AKC263>医保医疗费</AKC263>"
                           + "<AKC254>乙类首先自付</AKC254>"
                           + "<CKA050>起付线标准</CKA050>"
                           + "<BKE033>超限额自费</BKE033>"
                           + "<AKC260>基本统筹支付</AKC260>"
                           + "<AKC740>基本统筹自付</AKC740>"
                           + "<AKC256>起付标准自付</AKC256>"
                           + "<CKAA20>提高待遇合计 2A</CKAA20>"
                           + "<BKE155>起付线降低提高待遇</BKE155>"
                           + "<BKE148>提高报销比例提高待遇 </BKE148>"
                           + "<AKC706>大病支付合计</AKC706>"
                           + "<AKC279>本次进入大病费用</AKC279>"
                           + "<CKAA21>大病起付标准(医疗补助起付标准)</CKAA21>"
                           + "<AKC786>起付标准自付(补助起付线自付)</AKC786>"
                           + "<CKAA22>大病一段支付(补助一段支付)</CKAA22>"
                           + "<CKAA23>大病二段支付(补助二段支付)</CKAA23>"
                           + "<CKAA24>大病三段支付(补助三段支付)</CKAA24>"
                           + "<CKAA25>大病四段支付(补助四段支付)</CKAA25>"
                           + "<CKAA26>大病五段支付(补助五段支付)</CKAA26>"
                           + "<AKC790>大病段内自付(补助段内自付)</AKC790>"
                           + "<ZKC036>大病超限额自付(补助超限额自付)</ZKC036>"
                           + "<CKAA27>提高待遇合计 3A</CKAA27>"
                           + "<BKE149>取消起付线提高待遇</BKE149>"
                           + "<BKE150>提高封顶线</BKE150>"
                           + "<BKE151>医疗救助合计</BKE151>"
                           + "<CKAA28>本次进入医疗救助费用</CKAA28>"
                           + "<CKAA49>医疗救助自付</CKAA49>"
                           + "<AKC707>补助支付合计</AKC707>"
                           + "<CKAA29>医疗补助起付标准</CKAA29>"
                           + "<AKC752>补助自付</AKC752>"
                           + "<CKAA30>医疗补助支付基本起付线</CKAA30>"
                           + "<CKAA31>千元以上一次性材料补助</CKAA31>"
                           + "<CKAA32>医疗补助支付基本段内自付</CKAA32>"
                           + "<AKC780>医保统筹支付</AKC780>"
                           + "<AKC255>个人账户支付</AKC255>"
                           + "<AKC754>个人自付</AKC754>"
                           + "<AKC253>个人自费</AKC253>"
                           + "<CKAA33>其他自费</CKAA33>"
                           + "<AKC063LIST>大类列表</AKC063LIST>"
                           + "<CKAA37>累计进入补充保险费用</CKAA37>"
                           + "<CKAA38>补充保险起付线累计支付</CKAA38>"
                           + "<CKAA39>补充保险累计支付</CKAA39>"
                           + "<CKAA40>支付合计</CKAA40>"
                           + "<CKAA41>本次进入补充保险费用</CKAA41>"
                           + "<CKAA42>补充保险起付标准</CKAA42>"
                           + "<CKAA43>补充保险起付标准自付</CKAA43>"
                           + "<CKAA44>补充一段支付</CKAA44>"
                           + "<CKAA45>补充二段支付</CKAA45>"
                           + "<CKAA46>补充三段支付</CKAA46>"
                           + "<CKAA47>补充四段支付</CKAA47>"
                           + "<CKAA48>补充超限额</CKAA48>"
                           + "<CKAA50>补充保险段内自付</CKAA50>"
                           + "<CKAA51>备注</CKAA51>"
                           + "<BAC081>贫困人口标志</BAC081>" + cc_foot;
            }
            //城乡居民医疗保障费用结算单
            else if (ywlx == "1732")
            {
                cc = cc_head + "<CKAA52>报销类别</CKAA52>"
                           + "<AKB021>医疗机构名称</AKB021>"
                           + "<CKAA53>医疗机构等级</CKAA53>"
                           + "<AKC190>住院号</AKC190>"
                           + "<AAC003>姓名</AAC003>"
                           + "<AAC004>性别</AAC004>"
                           + "<AAC002>身份证号</AAC002>"
                           + "<CKAA54>参保地</CKAA54>"
                           + "<CKAA55>人员类别</CKAA55>"
                           + "<AKC141>诊断名称</AKC141>"
                           + "<AKC192>入院日期</AKC192>"
                           + "<AKC194>出院日期</AKC194>"
                           + "<AKC264>费用总额</AKC264>"
                           + "<CKAA56>政策内费用</CKAA56>"
                           + "<AKC260>基本医保统筹支付</AKC260>"
                           + "<CKAA20>基本医保提高待遇</CKAA20>"
                           + "<AKC706>大病保险统筹支付</AKC706>"
                           + "<CKAA27>大病保险提高待遇</CKAA27>"
                           + "<BKE151>医疗救助</BKE151>"
                           + "<AKC708>其他保障或补助</AKC708>"
                           + "<AAE072>票据号</AAE072>"
                           + "<CKAA57>报销流水号</CKAA57>"
                           + "<AKC780>本次报销合计</AKC780>"
                           + "<CKAA58>本次个人负担小计</CKAA58>"
                           + "<AKC754>政策内自付</AKC754>"
                           + "<AKC253>政策外自费</AKC253>"
                           + "<CKAA59>是否享受三重保障</CKAA59>"
                           + "<AAE040>结算日期</AAE040>" + cc_foot;
            }
            //个人慢性(或特殊)病审批信息查询
            else if (ywlx == "1910")
            {
                cc = cc_head + "<BAE073>审批编号</BAE073>"
                           + "<AKA130>AKA130</AKA130>"
                           + "<BKC462>病种代码</BKC462>"
                           + "<AKA121>病种名称</AKA121>"
                           + "<AAE030>开始日期</AAE030>"
                           + "<AAE031>终止日期</AAE031>"
                           + "<AKB020>定点医疗机构编码</AKB020>" + cc_foot;
            }
            //修改卡密码
            else if (ywlx == "2110") { cc = cc_head + cc_foot; }
            //设置门诊定点
            else if (ywlx == "2130") { cc = cc_head + cc_foot; }
            //激活 UKey
            else if (ywlx == "2131") { cc = cc_head + cc_foot; }
            //社保卡启用
            else if (ywlx == "2132") { cc = cc_head + cc_foot; }
            else { }
            return ret;
        }
    }
}
