using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using MTREG.medinsur.hdyb;
using System.Runtime.InteropServices;
using MTREG.medinsur.hdyb.dor;
using MTREG.common.bll;
using MTHIS.main.bll;
using System.Data;
using System.Data.Odbc;
using MTHIS.tools;

namespace MTREG.medinsur.hdyb.bll
{
    class YBCJ
    {
        private string zyh;
        private string ybcjbz;
       [DllImport("dblib.dll")]
        public static extern int comminterface(string ywlx, string rc, StringBuilder cc, string ylzh);

        public int ybcjhs(YBCJ_IN in1)
        {
            this.zyh = in1.Hisjl;
            this.ybcjbz = in1.Ybcjbz;
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
                opstat = comminterface_mn(in1.Yw, in1.Rc, returnMsg, in1.Ylzh);
                in1.Cc = returnMsg.ToString();
                try
                {
                    if (string.IsNullOrEmpty(in1.Ywmc))
                    {
                        in1.Mesg = "【医保提示：" + in1.Yw + "--" + in1.Cc + "！】";
                    }
                    else
                    {
                        in1.Mesg = "【医保提示：" + in1.Yw + "--" + in1.Ywmc + "--" + in1.Cc + "！】";
                    }
                }
                catch
                { }
                return opstat; 
            }
            else
            {
                opstat = comminterface(in1.Yw, in1.Rc, returnMsg, in1.Ylzh);
            }

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
            in1.Cc = ret;
            JKDB jkdb = new JKDB();
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
                    sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
                    sql += ((in1.Ylzh == "0") ? ("持卡") : ("无卡")).ToString().Trim() + "')";
                    BllMain.Db.Update(sql);
                }
                else if (in1.Yw == "CC511003")
                {
                    string[] retdata_rc = in1.Rc.Split('|');
                    string sql_cxsy = "select TOP 1 AAE072 from KC22 where AKC190='" + retdata_rc[1] + "'";
                    DataTable dt_cxsy = jkdb.Select(sql_cxsy).Tables[0];
                    string djh_ = "";
                    if (dt_cxsy.Rows.Count != 0)
                    {
                        djh_ = dt_cxsy.Rows[0]["AAE072"].ToString().Trim();
                    }
                    string sql = "insert into ybjsjl(mzzyh,yllb,djh,ylfyze,jsr,jssj,jsrc,jscc,tp,sfck) values('";
                    sql += retdata_rc[1] + "','";
                    sql += retdata_rc[2] + "','";
                    sql += djh_ + "','";
                    sql += retdata[0] + "','";
                    sql += retdata_rc[4] + "','";
                    sql += DateTime.Now.ToString() + "','";
                    sql += in1.Rc + "','";
                    sql += in1.Cc + "','";
                    sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
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
                        DataTable dt_cxyllb = jkdb.Select(sql_cxyllb).Tables[0];
                        string yllb_ = "";
                        if (dt_cxyllb.Rows.Count != 0)
                        {
                            yllb_ = dt_cxyllb.Rows[0]["AKA130"].ToString().Trim();
                        }
                        string sql = "insert into ybjsjl(mzzyh,yllb,djh,ylfyze,cxr,cxsj,cxrc,cxcc,tp,sfck) values('";
                        sql += retdata_rc[1] + "','";
                        sql += yllb_ + "','";
                        sql += retdata_rc[2] + "','";
                        sql += retdata[0] + "','";
                        sql += retdata_rc[3] + "','";
                        sql += DateTime.Now.ToString() + "','";
                        sql += in1.Rc + "','";
                        sql += in1.Cc + "','";
                        sql += ((in1.Ybcjbz == "0") ? ("医保职工") : ("城乡居民")).ToString().Trim() + "','";
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

        public int comminterface_mn(string ywlx, string rc, StringBuilder cc, string ylzh)
        {
 
            JKDB jkdb = new JKDB();
            int ret = 0;
            if (this.ybcjbz == "1")
            {
                //读基本信息
                if (ywlx == "AA311010")
                {
                    cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|刘明波|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");
                }
                //读帐户
                else if (ywlx == "AA311011")
                {
                    cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|刘明波|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");
                }
                //基本信息和帐户
                else if (ywlx == "AA311012")
                {
                    try
                    {
                        if (zyh == "")
                        {
                            cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|八戒|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");

                        }
                        else
                        {
                            string sql = "select name from inhospital where ihspcode='" + zyh + "' ";
                            DataTable dt = BllMain.Db.Select(sql).Tables[0];
                            cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|" + dt.Rows[0]["name"].ToString() + "|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");

                        }
                    }
                    catch
                    {
                        cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|八戒|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");
                    }

                }
                //封锁信息
                else if (ywlx == "AB31KC08")
                {
                    cc.Append("0|1|2|3|0|XX");
                }
                //药品
                else if (ywlx == "BB31KA02")
                {
                    cc.Append("乙|.05|.05||西药|1|限有药敏试验证据|XX");
                }
                //诊疗
                else if (ywlx == "BB31KA03")
                {
                    //cc.Append("甲|0|0|23||||化验费|化验费|0|癌胚抗原测定(CEA)化学发光法|XX");
                    cc.Append("|XX");
                }
                //读取服务设施信息
                else if (ywlx == "BB31KA04")
                {
                    cc.Append("甲|床位费|30|30|XX");
                }
                //审批
                else if (ywlx == "BB31KC20")
                {
                    cc.Append("1|XX");
                }
                //住院预结算
                else if (ywlx == "BC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(fee) as zfy from ihsp_costdet where ihsp_id in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|1368.6|13.49|0.00|0.00|0.00|0.00|500.0|20.77|0.0|0.0|590.31|0.00|90.31|0.0|");
                    cc.Append((double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.8).ToString("0.00") + "|");
                    cc.Append((double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.2).ToString("0.00") + "|");
                    cc.Append("0.00|0.0|500.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0||XX");
                }
                //住院结算
                else if (ywlx == "CC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(fee) as zfy from ihsp_costdet where ihsp_id in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|1368.6|13.49|0.00|0.00|0.00|0.00|500.0|20.77|0.0|0.0|590.31|0.00|90.31|0.0|");
                    cc.Append((double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.8).ToString("0.00") + "|");
                    cc.Append((double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.2).ToString("0.00") + "|");
                    cc.Append("0.00|0.0|500.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0|0.0||XX");
                }
                //住院结算单打印
                else if (ywlx == "BB310003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_jsdy = "select * from zlsyb_zyinfo where zyh='" + retdata1[1] + "'";
                    DataSet ds_jsdy = BllMain.Db.Select(sql_jsdy);
                    string sql_jsdy2 = "select * from inhospital where ihspcode='" + retdata1[1] + "'";
                    DataSet ds_jsdy2 = BllMain.Db.Select(sql_jsdy2);
                    cc.Append("邯郸市大名县医疗保险管理中心|" + ds_jsdy.Tables[0].Rows[0]["zyh"].ToString() + "|" + ds_jsdy.Tables[0].Rows[0]["fph"].ToString() + "|");
                    cc.Append(ProgramGlobal.HspName + "||1|" + ds_jsdy.Tables[0].Rows[0]["hzname"].ToString() + "|" + ds_jsdy.Tables[0].Rows[0]["zyh"].ToString() + "|");
                    cc.Append(Convert.ToDateTime(ds_jsdy2.Tables[0].Rows[0]["indate"].ToString().Trim()).ToString("yyyyMMddHHmmss") + "|");
                    cc.Append(Convert.ToDateTime(ds_jsdy2.Tables[0].Rows[0]["outdate"].ToString().Trim()).ToString("yyyyMMddHHmmss") + "|6|");
                    cc.Append("1304251383552||普通城乡居民||90|496.92|374.85|1413.5|283|60|133|0|0|0|0|0|305.68|3156.95|986.66|1819.99|574|90|");
                    cc.Append("437.14|26.18|46.14|163.5|0|500|0|2398.74|2170.29|0|728.45|0|0|228.45|||986.66|||986.66|0|0|" + ProgramGlobal.Username + "|");
                    cc.Append("20171127105152|2898.74|0|0|0|0|0|0|0|0|0|0|0|0||0|0|0|0|0|0|0|1405.5|0|0|0|0||XX");
                }
                //住院结算(回退)
                else if (ywlx == "DC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select jswzsczfc from zlsyb_zyinfo where mzzyjliid in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    string[] retdata2 = ds_yjs.Tables[0].Rows[0]["jswzsczfc"].ToString().Trim().Split('|');
                    cc.Append(retdata2[0] + "|" + retdata2[16] + "|" + retdata2[18] + "|XX");
                }
                //门诊预结算
                else if (ywlx == "BC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0.0|0.00|0.00|0.00|0.00|0.0|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|0.00|0.0|0.0|0.0|0.0|0.00|0.00|0.0|0.0||0.0|0.0|0||0|0|0.0|0.0|0.0|0|0|XX");
                }
                //门诊结算
                else if (ywlx == "CC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0.0|0.00|0.00|0.00|0.00|0.0|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|0.00|0.0|0.0|0.0|0.0|0.00|0.00|0.0|0.0||0.0|0.0|0||0|0|0.0|0.0|0.0|0|0|XX");
                }
                //门诊结算单打印
                else if (ywlx == "BB310002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    string sql_yjs1 = "select * from kc21 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs1 = jkdb.Select(sql_yjs1);
                    cc.Append("邯郸市医疗保险基金管理中心|" + retdata1[1] + "|" + ProgramGlobal.HspName + "|" + ds_yjs1.Tables[0].Rows[0]["zkc272"].ToString().Trim() + "|");
                    cc.Append(ds_yjs1.Tables[0].Rows[0]["AAC003"].ToString().Trim() + "|在职|" + ds_yjs1.Tables[0].Rows[0]["AAC001"].ToString().Trim() + "|");
                    cc.Append("1525063|864913061612C4A5|0|0|0|0|0|0|0|0|0|5.75|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|");
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|2295.38|0|0|" + ProgramGlobal.Username + "|20180112051041|");
                    cc.Append(ds_yjs1.Tables[0].Rows[0]["AKA130"].ToString().Trim() + "|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|5.75|0||XX");
                }
                //门诊结算回退
                else if (ywlx == "DC311002")
                {
                    cc.Append("0|1|2|XX");
                }
                //门诊已审批过的特殊病
                else if (ywlx == "BB31TSXX")
                {
                    cc.Append("bzbm11|冠心病1|bzbm22|糖尿病1|XX");
                }
                //生育出院结算
                else if (ywlx == "CC511003")
                {
                    cc.Append("5000|1|3000|2000|XX");
                }

                //打印生育结算单
                else if (ywlx == "BB510002")
                {
                    cc.Append("邯郸市医保中心|000888|123456789|邯郸市第二医院|妇科|2|张美丽|000888|2007-11-16 10:23:15|2007-11-28 10:23:15|13|00015852512|123456|人员类别|否|4321.01|1000|2560.44|张海青|2007-11-28 10:23:15|XX");
                }

                //生育出院预结算
                else if (ywlx == "BC510001")
                {
                    cc.Append("5000|1|3000|2000|XX");
                }
                //封锁信息 （生育）
                else if (ywlx == "AB51KC08")
                {
                    cc.Append("0|0|0|0|0|XX");
                }

                //门诊结算
                else if (ywlx == "CC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0.0|0.00|0.00|0.00|0.00|0.0|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim()) * 0.5).ToString() + "|0.00|0.0|0.0|0.0|0.0|0.00|0.00|0.0|0.0||0.0|0.0|0||0|0|0.0|0.0|0.0|0|0|XX");
                }
                //BB31SPXX 门诊已审批过的慢性病 5
                else if (ywlx == "BB31SPXX")
                {
                    cc.Append("bzbm1|冠心病|bzbm2|糖尿病|XX");
                }
                //读疾病药品对照信息
                else if (ywlx == "BB31ZK06")
                {
                    cc.Append("1|XX");
                }
                //读取生育药品信息
                else if (ywlx == "BB51MA02")
                {
                    cc.Append("甲类|1|住院自付比例|药品最高限价|费用类别（西药、中草药等）|XX");
                }
                //读取生育诊疗信息
                else if (ywlx == "BB51MA03")
                {
                    cc.Append("甲类|1|住院自付比例| 特殊诊疗标志|特殊诊疗限价|门诊费用类别（检查费、床位费等）| 住院费用类别（检查费、床位费等）|XX");
                }
                //读取生育申报信息
                else if (ywlx == "BB51MC01")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //读取生育申报信息
                else if (ywlx == "BB51MC01")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //传输数据
                else if (ywlx == "BB310001")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //读取扣除先负担后金额
                else if (ywlx == "BB310004")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_cxprc = "select fee,yblx from ihsp_costdet where id=" + retdata1[1];
                    DataTable dt_cxprc = BllMain.Db.Select(sql_cxprc).Tables[0];
                    if (dt_cxprc.Rows[0]["yblx"].ToString().Trim() == "甲")
                    {
                        cc.Append(double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()).ToString() + "|甲||0|XX");
                    }
                    else if (dt_cxprc.Rows[0]["yblx"].ToString().Trim() == "乙")
                    {
                        cc.Append((double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()) * 0.95).ToString() + "|乙||0.95|XX");
                    }
                    else
                    {
                        cc.Append(double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()).ToString() + "|丙||1|XX");
                    }
                }
                else
                {
                    cc.Append("|XX");
                }
            }
            else
            {
                //读基本信息
                if (ywlx == "AA311010")
                {
                    cc.Append("1304258012586|132121195502256921|13042560128|DD0297498|刘明波|女|19550225120000|退休|20040509120000|参保缴费|20090728053009||||||20171129124128|出院已结算||||130425|机关||不是公务员|101||||||||||||||||||130425000275322||不是基残人员|||20171129124128|2017|0|1403.4|20171129124128|1153.35|0|1165.4|0|0|0|0|0|0|0|0|0|0|0||0|0|0||0|0|0|0|0|0|0|0|XX");
                }
                //读人员账户信息
                else if (ywlx == "AA311011")
                {
                    cc.Append("1304258012586|132121195502256921|13042560128|DD0297498|刘明波|女|19550225120000|退休|20040509120000|参保缴费|20090728053009||||||20171129124128|出院已结算||||130425|机关||不是公务员|101||||||||||||||||||130425000275322||不是基残人员|||20171129124128|2017|0|1403.4|20171129124128|1153.35|0|1165.4|0|0|0|0|0|0|0|0|0|0|0||0|0|0||0|0|0|0|0|0|0|0|XX");
                }
                //读人员基本信息和账户
                else if (ywlx == "AA311012")
                {
                    try
                    {
                        if (zyh == "")
                        {
                            cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|八戒|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");

                        }
                        else
                        {
                            string sql = "select name from inhospital where ihspcode='" + zyh + "' ";
                            DataTable dt = BllMain.Db.Select(sql).Tables[0];
                            cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|" + dt.Rows[0]["name"].ToString() + "|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");

                        }
                    }
                    catch
                    {
                        cc.Append("1304026177318|130421197408115114|130402000000|1304026177318|小鸟|男|19740811|普通居民|20170101|1|20170714|||||||不在院||||130402|||||||||||||123456|||||||||||2||||||0|||0.0|0.0|785.4|0.00|1520.0|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0|||XX");
                    }
                }
                //读取人员封锁信息(中心)
                else if (ywlx == "AB31KC08")
                {
                    cc.Append("||||0|XX");
                }

                 //读取药品信息
                else if (ywlx == "BB31KA02")
                {
                    cc.Append("乙|.05|.05||西药|1|限有药敏试验证据|XX");
                }
                //读取诊疗信息
                else if (ywlx == "BB31KA03")
                {
                    //cc.Append("甲|0|0|23||||化验费|化验费|0|癌胚抗原测定(CEA)化学发光法|XX");
                    cc.Append("|XX");
                }
                //读取服务设施信息
                else if (ywlx == "BB31KA04")
                {
                    cc.Append("甲|床位费|30|30|XX");
                }
                //读人员审批信息
                else if (ywlx == "BB31KC20")
                {
                    cc.Append("1|XX");
                }
                //住院结算(回退)
                else if (ywlx == "DC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select jswzsczfc from zlsyb_zyinfo where mzzyjliid in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    string[] retdata2 = ds_yjs.Tables[0].Rows[0]["jswzsczfc"].ToString().Trim().Split('|');
                    cc.Append(retdata2[0] + "|" + retdata2[16] + "|" + retdata2[18] + "|XX");
                }
                //住院结算(预结算)
                else if (ywlx == "BC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(fee) as zfy from ihsp_costdet where ihsp_id in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|324.87|30.31|0|0|0|0|150|278.44|0|6860.33|" + ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "||" + ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|0|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.8).ToString("0.00") + "|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.2).ToString("0.00") + "|0|2477.67|150|0|1|0|0|0|0|XX");
                }
                //住院结算
                else if (ywlx == "CC311003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(fee) as zfy from ihsp_costdet where ihsp_id in(select id from inhospital where ihspcode='" + retdata1[1] + "')";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|324.87|30.31|0|0|0|0|150|278.44|0|6860.33|" + ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "||" + ds_yjs.Tables[0].Rows[0]["zfy"].ToString() + "|0|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.8).ToString("0.00") + "|" + (double.Parse(ds_yjs.Tables[0].Rows[0]["zfy"].ToString()) * 0.2).ToString("0.00") + "|0|2477.67|150|0|1|0|0|0|0|XX");
                }
                //住院结算单打印
                else if (ywlx == "BB310003")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_jsdy = "select * from zlsyb_zyinfo where zyh='" + retdata1[1] + "'";
                    DataSet ds_jsdy = BllMain.Db.Select(sql_jsdy);
                    string sql_jsdy2 = "select * from inhospital where ihspcode='" + retdata1[1] + "'";
                    DataSet ds_jsdy2 = BllMain.Db.Select(sql_jsdy2);
                    //邯郸市医疗保险基金管理中心|100000|3000002|高臾精神病医院|精神科三区|2|吴丽英|100000|20171128035209|20171231103354|33|1304012234919|8649091225090B4E|在职|否|684|510.47|0|0|80|607|2036.8|0|0|0|0|0|167.35|4085.62|883.62|292.06|2179|684|60.89|544.8|157.52|167.35|0|150|0|3480.44|3202|2695.5|0|0|0|278.44|0|0|883.62|0|2477.67|883.62|0|0|吴芳|20171231112521|0|100|0|0|0|0|0|0|0|3202|883.62|30.31|324.87|0|XX
                    cc.Append("邯郸市大名县医疗保险管理中心|" + ds_jsdy.Tables[0].Rows[0]["zyh"].ToString() + "|" + ds_jsdy.Tables[0].Rows[0]["fph"].ToString() + "|");
                    cc.Append(ProgramGlobal.HspName + "||1|" + ds_jsdy.Tables[0].Rows[0]["hzname"].ToString() + "|" + ds_jsdy.Tables[0].Rows[0]["zyh"].ToString() + "|");
                    cc.Append(Convert.ToDateTime(ds_jsdy2.Tables[0].Rows[0]["indate"].ToString().Trim()).ToString("yyyyMMddHHmmss") + "|");
                    cc.Append(Convert.ToDateTime(ds_jsdy2.Tables[0].Rows[0]["outdate"].ToString().Trim()).ToString("yyyyMMddHHmmss") + "|6|");
                    cc.Append("1304251383552|8649091225090B4E|在职|否|684|510.47|0|0|80|607|2036.8|0|0|0|0|0|167.35|4085.62|883.62|292.06|2179|");
                    cc.Append("684|60.89|544.8|157.52|167.35|0|150|0|3480.44|3202|2695.5|0|0|0|278.44|0|0|883.62|0|2477.67|883.62|0|0|" + ProgramGlobal.Username + "|");
                    cc.Append("20171231112521|0|100|0|0|0|0|0|0|0|3202|883.62|30.31|324.87|0|XX");
                }
                //门诊结算(预结算)
                else if (ywlx == "BC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|5.75|0|0|0|0|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|0|2295.38|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|0|0|0||XX");

                }
                //门诊结算
                else if (ywlx == "CC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|5.75|0|0|0|0|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|0|2295.38|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|0|0|0||XX");
                }
                //门诊结算单打印
                else if (ywlx == "BB310002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select sum(AKC227) as ybzfy from kc22 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs = jkdb.Select(sql_yjs);
                    string sql_yjs1 = "select * from kc21 where akc190='" + retdata1[1] + "'";
                    DataSet ds_yjs1 = jkdb.Select(sql_yjs1);
                    cc.Append("邯郸市医疗保险基金管理中心|" + retdata1[1] + "|" + ProgramGlobal.HspName + "|" + ds_yjs1.Tables[0].Rows[0]["zkc272"].ToString().Trim() + "|");
                    cc.Append(ds_yjs1.Tables[0].Rows[0]["AAC003"].ToString().Trim() + "|在职|" + ds_yjs1.Tables[0].Rows[0]["AAC001"].ToString().Trim() + "|");
                    cc.Append("1525063|864913061612C4A5|0|0|0|0|0|0|0|0|0|5.75|" + ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|0|0|");
                    cc.Append(ds_yjs.Tables[0].Rows[0]["ybzfy"].ToString().Trim() + "|2295.38|0|0|" + ProgramGlobal.Username + "|20180112051041|");
                    cc.Append(ds_yjs1.Tables[0].Rows[0]["AKA130"].ToString().Trim() + "|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|5.75|0||XX");
                }
                //门诊结算回退
                else if (ywlx == "DC311002")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_yjs = "select jswzsczfc from zlsyb_mzinfo where ybmzh='" + retdata1[1] + "'";
                    DataSet ds_yjs = BllMain.Db.Select(sql_yjs);
                    string[] retdata2 = ds_yjs.Tables[0].Rows[0]["jswzsczfc"].ToString().Trim().Split('|');
                    cc.Append(retdata2[0] + "|" + retdata2[9] + "|" + retdata2[12] + "|XX");
                }
                //BB31BB31TSXXSPXX 门诊已审批过的特殊病 5
                else if (ywlx == "BB31TSXX")
                {
                    cc.Append("bzbm11|冠心病1|bzbm22|糖尿病1|XX");
                }

                //生育出院结算
                else if (ywlx == "CC511003")
                {
                    cc.Append("5000|1|3000|2000|XX");
                }

                //打印生育结算单
                else if (ywlx == "BB510002")
                {
                    cc.Append("邯郸市医保中心|000888|123456789|邯郸市第二医院|妇科|2|张美丽|000888|2007-11-16 10:23:15|2007-11-28 10:23:15|13|00015852512|123456|人员类别|否|4321.01|1000|2560.44|张海青|2007-11-28 10:23:15|XX");
                }

                //生育出院预结算
                else if (ywlx == "BC510001")
                {
                    cc.Append("5000|1|3000|2000|XX");
                }
                //封锁信息 （生育）
                else if (ywlx == "AB51KC08")
                {
                    cc.Append("0|0|0|0|0|XX");
                }
                //BB31SPXX 门诊已审批过的慢性病 5
                else if (ywlx == "BB31SPXX")
                {
                    cc.Append("bzbm1|冠心病|bzbm2|糖尿病|XX");
                }
                //读疾病药品对照信息
                else if (ywlx == "BB31ZK06")
                {
                    cc.Append("1|XX");
                }
                //读取生育药品信息
                else if (ywlx == "BB51MA02")
                {
                    cc.Append("甲类|1|住院自付比例|药品最高限价|费用类别（西药、中草药等）|XX");
                }
                //读取生育诊疗信息
                else if (ywlx == "BB51MA03")
                {
                    cc.Append("甲类|1|住院自付比例| 特殊诊疗标志|特殊诊疗限价|门诊费用类别（检查费、床位费等）| 住院费用类别（检查费、床位费等）|XX");
                }
                //读取生育申报信息
                else if (ywlx == "BB51MC01")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //读取生育申报信息
                else if (ywlx == "BB51MC01")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //传输数据
                else if (ywlx == "BB310001")
                {
                    cc.Append("生育流水号|经办时间|审批状态|XX");
                }
                //读取扣除先负担后金额
                else if (ywlx == "BB310004")
                {
                    string[] retdata1 = rc.Split('|');
                    string sql_cxprc = "select fee,yblx from ihsp_costdet where id=" + retdata1[1];
                    DataTable dt_cxprc = BllMain.Db.Select(sql_cxprc).Tables[0];
                    if (dt_cxprc.Rows[0]["yblx"].ToString().Trim() == "甲")
                    {
                        cc.Append(double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()).ToString() + "|甲||0|XX");
                    }
                    else if (dt_cxprc.Rows[0]["yblx"].ToString().Trim() == "乙")
                    {
                        cc.Append((double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()) * 0.95).ToString() + "|乙||0.95|XX");
                    }
                    else
                    {
                        cc.Append(double.Parse(dt_cxprc.Rows[0]["fee"].ToString().Trim()).ToString() + "|丙||1|XX");
                    }
                }
                else
                {
                    cc.Append("|XX");
                }
            }
            return ret;
        }
    }
}
