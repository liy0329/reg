using System;
using System.Collections.Generic;
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
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.hdyb.dor;
using MTHIS.main.bll;

namespace MTREG.tools
{
    class ZySyybfysc_zd
    {
        public RetMsg ybscfymx(int mtzyjliid, string grbh, string zyh)
        {
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = scfymx(mtzyjliid, grbh, zyh, out mesg);
                if (retnum >= 30)
                {
                    Thread.Sleep(1000);
                }
                if (retnum == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
            }
            return ret;
        }

        private int scfymx(int mtzyjliid, string grbh, string zyh, out string mesg)
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
            //传送最多30行未传送数据 
            int retnum = 0;
            //传送数据
            YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
            yw_in_ybsjcs.Yw = "BB510001";
            yw_in_ybsjcs.Ybcjbz = "0";
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

            retnum = dt_xmcx.Rows.Count;

            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }

            for (int j = 0; j < dt_xmcx.Rows.Count; j++)
            {
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
                yw_in_smldz.Ybcjbz = "0";
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
                    yw_in_smldz.Yw = "BB51MA02";
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
                            dqdzxxfh = System.Text.RegularExpressions.Regex.Replace(yw_in_smldz.Cc, "['<>&]", "");
                        }
                        catch
                        { }
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
                    yw_in_smldz.Yw = "BB51MA03";
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
