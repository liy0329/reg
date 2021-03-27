using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.hdyb.dor;
using MTHIS.main.bll;

namespace MTREG.tools
{
    class Zycjfysc_button
    {
        int sss = 0;
        public RetMsg ybscfymx(int mtzyjliid, string grbh, string zyh, Label txt)
        {
            sss = 0;
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            string sql_xgsfdmbz = "update ihsp_costdet set sfdmbz = 1 where sfdmbz is null and ybsc=0 and  ihsp_id = " + mtzyjliid;
            BllMain.Db.Update(sql_xgsfdmbz);
            string sql = "select * from ihsp_costdet where ybsc = 0 and ihsp_id = " + mtzyjliid;
            string counts = BllMain.Db.Select(sql).Tables[0].Rows.Count.ToString().Trim();
            string sql_xgbzwl = "update ihsp_costdet set ypspbz = 0 where ybsc=0 and ypspbz is null and  ihsp_id = " + mtzyjliid;
            BllMain.Db.Update(sql_xgbzwl);
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = scfymx(mtzyjliid, grbh, zyh, out mesg, counts, txt);
                sss = sss + 120;
                if (retnum >= 60)
                {
                    Thread.Sleep(1000);
                }
                if (retnum == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
                ret.Mesg += mesg;
            }

            return ret;
        }

        private int scfymx(int mtzyjliid, string grbh, string zyh, out string mesg, string counts, Label txt)
        {
            mesg = "";
            JKDB jkdb = new JKDB();
            YBCJ yw1 = new YBCJ();

            string sql_xmcx = "select inhospital.ihspcode"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.name"
                            + ", bas_item.hiscode as standcode"
                            + ", insur_itemfrom.insurcode as itemfromcode"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", ihsp_costdet.spec"
                            + ", ihsp_costdet.item_id"
                            + ",ihsp_costdet.ypspbz as xzxypspbz"
                            + " from ihsp_costdet"
                            + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                            + " left join insur_itemfrom on insur_itemfrom.itemtype_id=ihsp_costdet.itemtype_id"
                            + " left join bas_item on bas_item.id=ihsp_costdet.item_id and bas_item.hiscode not in('','0')"
                            + " where ihsp_costdet.ihsp_id=" + mtzyjliid
                            + " and insur_itemfrom.cost_insurtype_id='6'"
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('RREC','RET','CHAR')"
                            + " and ihsp_costdet.ypspbz not in(-1)"
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable dt_xmcx = BllMain.Db.Select(sql_xmcx).Tables[0];
            //传送最多120行未传送数据
            int retnum = 0;
            //传送数据
            YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
            yw_in_ybsjcs.Yw = "BB310001";
            yw_in_ybsjcs.Ybcjbz = "1";
            string sql_gxsfck = "select sfck,outdiagn from inhospital where id='" + mtzyjliid + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ybsjcs.Ylzh = "0";
            }
            else
            {
                yw_in_ybsjcs.Ylzh = grbh;
            }
            yw_in_ybsjcs.Rc = grbh + "|" + zyh;
            int opt_ybsjcs = yw1.ybcjhs(yw_in_ybsjcs);
            if (opt_ybsjcs == 0)
            {
                string _sql4 = "update KC22 set CKC126=1 where AKC190='" + zyh + "'";
                jkdb.Update(_sql4);
            }
            else
            {
                mesg += "[数据传输：zyh-" + zyh + "-" + yw_in_ybsjcs.Mesg + "-" + "]\r\n";
                retnum = -1;
                return retnum;
            }

            retnum = dt_xmcx.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }

            string outdiagn_fysc = "";
            try
            {
                outdiagn_fysc = Convert.ToDateTime(ds_sfck.Tables[0].Rows[0]["outdiagn"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            { }
            for (int j = 0; j < dt_xmcx.Rows.Count; j++)
            {
                txt.Text = "正在上传费用：" + (sss + j + 1).ToString() + "/" + counts;
                txt.Update();
                string id = dt_xmcx.Rows[j]["id"].ToString();//费用id
                string ihspcode = dt_xmcx.Rows[j]["ihspcode"].ToString();//住院号
                string chargedate = Convert.ToDateTime(dt_xmcx.Rows[j]["chargedate"]).ToString("yyyy-MM-dd");//处方日期,结算日期
                string itemname = dt_xmcx.Rows[j]["name"].ToString();//收费项目名称
                string standcode = dt_xmcx.Rows[j]["standcode"].ToString();//医保编码
                string insurcode = dt_xmcx.Rows[j]["itemfromcode"].ToString();//药品/诊疗/床位费
                string prc = dt_xmcx.Rows[j]["prc"].ToString();//单价
                string fee = dt_xmcx.Rows[j]["fee"].ToString();//金额
                string num = dt_xmcx.Rows[j]["num"].ToString();//数量
                string itemid = dt_xmcx.Rows[j]["item_id"].ToString();
                //string insuritemid = BillSysBase.nextId("cost_insuritem");
                //string insurcrossid = BillSysBase.nextId("cost_insurcross");
                string guige = dt_xmcx.Rows[j]["spec"].ToString();
                string cfrq = Convert.ToDateTime(dt_xmcx.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                string jsrq = Convert.ToDateTime(dt_xmcx.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                if (!string.IsNullOrEmpty(outdiagn_fysc))
                {
                    if (DateTime.Parse(cfrq) > DateTime.Parse(outdiagn_fysc))
                    {
                        cfrq = outdiagn_fysc;
                    }
                }
                string dqrq_xz = Convert.ToDateTime(getServiceCurrtime()).ToString("yyyy-MM-dd") + " 00:00:00";
                try
                {
                    if (DateTime.Parse(Convert.ToDateTime(cfrq).ToString("yyyy-MM-dd")) > DateTime.Parse(dqrq_xz))
                    {
                        BllMain.Db.Update("update ihsp_costdet set sfdmbz=0 where id=" + id + ";");
                        continue;
                    }
                }
                catch
                { }
                string xmmc = System.Text.RegularExpressions.Regex.Replace(itemname, "[|<>&]", "");
                string lb = "2";
                string spbz = "";
                string ypdj = "";
                string dqdzxxfh = "";
                string yptsxx = "";

                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "1";
                if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
                {
                    yw_in_smldz.Ylzh = "0";
                }
                else
                {
                    yw_in_smldz.Ylzh = grbh;
                }
                yw_in_smldz.Rc = standcode;
                if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
                {
                    lb = "1";
                    yw_in_smldz.Yw = "BB31KA02";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照药品：" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[药品没有对码：" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        try
                        {
                            yptsxx = System.Text.RegularExpressions.Regex.Replace(smldz_cc[6], "['|<>&]", "");
                        }
                        catch { }
                        try
                        {
                            dqdzxxfh = System.Text.RegularExpressions.Regex.Replace(yw_in_smldz.Cc, "['<>&]", "");
                        }
                        catch
                        { }
                        if ((smldz_cc[5] == "1") && ((dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim() == "0") || (string.IsNullOrEmpty(dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim()))))
                        {
                            mesg += "[药品是限制用药：" + id + "-" + xmmc + "-" + yptsxx + "]\r\n";
                            string update_sql_xzxyp = "update ihsp_costdet set ypspbz=-1,dqdzxx='" + dqdzxxfh + "',yptsxx='" + yptsxx + "' where id=" + id + ";";
                            BllMain.Db.Update(update_sql_xzxyp);
                            continue;
                        }
                        else
                        {
                            if ((smldz_cc[5] == "1") && (dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim() != "0") && (!string.IsNullOrEmpty(dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim())) && (dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim() != "-1"))
                            {
                                spbz = dt_xmcx.Rows[j]["xzxypspbz"].ToString().Trim();
                            }
                        }
                    }
                }
                else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
                {
                    lb = "3";
                    yw_in_smldz.Yw = "BB31KA04";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照床位：" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[床位没有对码：" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        try
                        {
                            dqdzxxfh = System.Text.RegularExpressions.Regex.Replace(yw_in_smldz.Cc, "['<>&]", "");
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    yw_in_smldz.Yw = "BB31KA03";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照诊疗：-" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[诊疗没有对码：-" + id + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        if (smldz_cc[9] == "1")
                        {
                            spbz = "3";
                        }
                        try
                        {
                            dqdzxxfh = System.Text.RegularExpressions.Regex.Replace(yw_in_smldz.Cc, "['<>&]", "");
                        }
                        catch
                        { }
                    }
                }
                if (string.IsNullOrEmpty(ypdj.Trim()))
                {
                    string update_sql_sfdm = "update ihsp_costdet set sfdmbz=0 where id=" + id + ";";
                    BllMain.Db.Update(update_sql_sfdm);
                    mesg += "[没有对码：" + id + "-" + xmmc + "]\r\n";
                    continue;
                }
                string _insert_sql = "insert into KC22 (AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,AKC227,AAE040,ZKA100,CKC126,CKC125,AKA065,CKC048) values ";
                _insert_sql += "('" + ihspcode + "','" + id + "','" + ihspcode + "','" + cfrq + "','" + standcode + "','" + xmmc + "','" + lb + "'," + prc + "," + num + "," + fee + ",'" + jsrq + "','" + guige + "',0,0,'" + ypdj + "','" + spbz + "')";
                //更新ihsp_costdet.insursync=1
                string update_sql = "update ihsp_costdet set ybsc=1,yblx='" + ypdj + "',dqdzxx='" + dqdzxxfh + "',yptsxx='" + yptsxx + "' where id=" + id + ";";

                if (BllMain.Db.Update(update_sql) == 0)
                {
                    if (jkdb.Update2(_insert_sql) == -1)
                    {
                        mesg += "插入kc22失败：[" + _insert_sql + "]\r\n";
                        SysWriteLogs.writeLogs1("【" + ihspcode + "】-插入kc22失败", DateTime.Now, "sql=" + _insert_sql);
                    }
                }
            }

            //传送费用
            int opt_ybsjcs1 = yw1.ybcjhs(yw_in_ybsjcs);
            if (opt_ybsjcs1 == 0)
            {
                string _sql4 = "update KC22 set CKC126=1 where AKC190='" + zyh + "'";
                jkdb.Update(_sql4);
            }
            else
            {
                mesg += "[数据传输：zyh-" + zyh + "-" + yw_in_ybsjcs.Mesg + "-" + "]\r\n";
                retnum = -1;
                return retnum;
            }
            mesg += "";
            return retnum;
        }
        //先负担后金额甲乙丙(批量)
        public bool xfdhjejyb_pl(string grbh, string mtzyjliid, string zyh, out string mesg)
        {
            mesg = "";
            JKDB jkdb = new JKDB();
            YBCJ yw1 = new YBCJ();
            string his_cx = "select id from ihsp_costdet  where ihsp_id='" + mtzyjliid + "' and ybsc=1 and ybxfdhjebz=0;";
            DataTable dt_his_cx = BllMain.Db.Select(his_cx).Tables[0];
            if (dt_his_cx.Rows.Count == 0)
            {
                return true;
            }

            string kc22_cx = "select AKC220 from kc22 where akc190='" + zyh + "' and CKC126=1 ";
            string iid_sqls = " and AKC220 in('";
            for (int i = 0; i < dt_his_cx.Rows.Count; i++)
            {
                iid_sqls += dt_his_cx.Rows[i]["id"].ToString().Trim() + "','";
            }
            iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
            iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
            kc22_cx += iid_sqls + ")";
            DataTable dt_kc22_cx = jkdb.Select(kc22_cx).Tables[0];
            if (dt_kc22_cx.Rows.Count == 0)
            {
                return true;
            }
            string sql_gxsfck = "select sfck,zyjlsfcy,nhflag,insurcode from inhospital  where id='" + mtzyjliid + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);

            YBCJ_IN yw_in_dqkcxfdhje_pl = new YBCJ_IN();
            yw_in_dqkcxfdhje_pl.Yw = "BB310005";
            yw_in_dqkcxfdhje_pl.Ybcjbz = "1";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_dqkcxfdhje_pl.Ylzh = "0";
            }
            else
            {
                yw_in_dqkcxfdhje_pl.Ylzh = ds_sfck.Tables[0].Rows[0]["insurcode"].ToString().Trim();
            }
            yw_in_dqkcxfdhje_pl.Rc = dt_kc22_cx.Rows.Count.ToString() + "|" + zyh + "|";
            for (int i = 0; i < dt_kc22_cx.Rows.Count; i++)
            {
                yw_in_dqkcxfdhje_pl.Rc += dt_kc22_cx.Rows[i]["AKC220"].ToString().Trim() + "|";
            }
            yw_in_dqkcxfdhje_pl.Rc = yw_in_dqkcxfdhje_pl.Rc.Remove(yw_in_dqkcxfdhje_pl.Rc.Length - 1);
            int opt_dqkcxfdhje_pl = yw1.ybcjhs(yw_in_dqkcxfdhje_pl);
            if (opt_dqkcxfdhje_pl != 0)
            {
                mesg += "[负担后余额：zyh-" + zyh + "-" + yw_in_dqkcxfdhje_pl.Mesg + "]\r\n";
                return true;
            }

            string[] dqkcxfdhje_pl_ccs = yw_in_dqkcxfdhje_pl.Cc.Split(new string[] { "^^" }, StringSplitOptions.None);
            string sql_update_kc22 = "";
            string sql_update_mtzyjlstuff = "";
            for (int i = 0; i < dqkcxfdhje_pl_ccs.Length - 1; i++)
            {
                string[] dqkcxfdhje_pl_cc = dqkcxfdhje_pl_ccs[i].Split('|');
                sql_update_mtzyjlstuff = "update ihsp_costdet  set ybxfdhjebz=1,ybxfdhje=" + dqkcxfdhje_pl_cc[3].Trim() + ", yblx = '" + dqkcxfdhje_pl_cc[4].Trim() + "' where ihsp_id=" + mtzyjliid + " and id=" + dqkcxfdhje_pl_cc[0].Trim() + ";";
                BllMain.Db.Update(sql_update_mtzyjlstuff);
                sql_update_kc22 = "update KC22 set AKA065='" + dqkcxfdhje_pl_cc[4].Trim() + "',AKC515='" + dqkcxfdhje_pl_cc[1].Trim() + "' where AKC190='" + zyh + "' and AKC220='" + dqkcxfdhje_pl_cc[0].Trim() + "'";
                jkdb.Update(sql_update_kc22);
            }

            return true;
        }
        public static string getServiceCurrtime()
        {
            string currdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "select to_char(localtimestamp, 'YYYY-MM-DD HH24:MI:SS') as currtime";
            try
            {
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                currdatetime = dt.Rows[0]["currtime"].ToString().Trim();

            }
            catch (Exception)
            {
                //currdatetime = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
            }
            return currdatetime;
        }
    }
}
