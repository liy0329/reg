using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using MTREG.common.bll;
using System.Data;
using MTREG.medinsur.hdyb.bll;
using System.Windows.Forms;
using System.Threading;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;

namespace MTREG.medinsur.hdyb.dor
{
    class Zysyybfysc
    {
        int sss = 0;
        YBCJ yw1 = new YBCJ();
        JKDB jkdb = new JKDB();
        /// <summary>
        /// 医保上传费用明细
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="patienttypeid"></param>
        /// <param name="grbh"></param>
        /// <param name="zyh"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public RetMsg ybscfymx(int ihsp_id, string patienttypeid, string grbh, string zyh, Label txt)
        {
            sss = 0;
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            string sql_xgscbzwl = "update ihsp_costdet set insursync = 'N' where insursync is null and  ihsp_id = " + ihsp_id;
            BllMain.Db.Update(sql_xgscbzwl);
            string sql = "select * from ihsp_costdet where insursync = 'N' and ihsp_id = " + ihsp_id;
            string counts = BllMain.Db.Select(sql).Tables[0].Rows.Count.ToString().Trim();
            string sql_xgbzwl = "update ihsp_costdet set ypspbz = 0 where insursync='N' and ypspbz is null and  ihsp_id = " + ihsp_id;
            BllMain.Db.Update(sql_xgbzwl);
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = scfymx(ihsp_id, patienttypeid, grbh, zyh, out mesg, counts, txt);
                sss = sss + 50;
                if (sss > 5 * int.Parse(counts))
                {
                    return ret;
                }
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
        private int scfymx(int ihsp_id, string patienttypeid, string grbh, string zyh, out string mesg, string counts, Label txt)
        {
            mesg = "";
            string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "select inhospital.ihspcode"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.name"
                            + ", bas_item.standcode as standcode"
                            + ", cost_itemtype.netcode as itemfromcode"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", ihsp_costdet.spec"
                            + ", ihsp_costdet.item_id"
                            + ",ihsp_costdet.ypspbz as xzxypspbz"
                            + " from ihsp_costdet"
                            + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                            + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id"
                            + " left join bas_item on bas_item.id=ihsp_costdet.item_id and bas_item.standcode not in('','0')"
                            + " where ihsp_costdet.ihsp_id=" + ihsp_id
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('RREC','RET','CHAR')"
                            + " and ihsp_costdet.ypspbz not in(-1)"
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable datatable = BllMain.Db.Select(sql1).Tables[0];
            int retnum = 0;
            retnum = datatable.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }
            string sql_gxsfck = "select sfck,outdate from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
            yw_in_ybsjcs.Yw = "BB510001";
            yw_in_ybsjcs.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ybsjcs.Ylzh = "0";
            }
            else
            {
                yw_in_ybsjcs.Ylzh = grbh;
            }
            yw_in_ybsjcs.Rc = grbh + "|" + zyh;
            string zyjlcysj_fysc = "";
            try
            {
                zyjlcysj_fysc = Convert.ToDateTime(ds_sfck.Tables[0].Rows[0]["outdate"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            { }
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                txt.Text = "正在上传费用：" + (sss + i + 1).ToString() + "/" + counts;
                txt.Update();
                string id = datatable.Rows[i]["id"].ToString();//费用id
                string ihspcode = datatable.Rows[i]["ihspcode"].ToString();//住院号
                string chargedate = Convert.ToDateTime(datatable.Rows[i]["chargedate"]).ToString("yyyy-MM-dd");//处方日期,结算日期
                string itemname = datatable.Rows[i]["name"].ToString();//收费项目名称
                string standcode = datatable.Rows[i]["standcode"].ToString();//医保编码
                string insurcode = datatable.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
                string prc = datatable.Rows[i]["prc"].ToString();//单价
                string fee = datatable.Rows[i]["fee"].ToString();//金额
                string num = datatable.Rows[i]["num"].ToString();//数量
                string itemid = datatable.Rows[i]["item_id"].ToString();
                //string insuritemid = BillSysBase.nextId("cost_insuritem");
                //string insurcrossid = BillSysBase.nextId("cost_insurcross");
                string guige = datatable.Rows[i]["spec"].ToString();
                string cfrq = Convert.ToDateTime(datatable.Rows[i]["chargedate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                string jsrq = Convert.ToDateTime(datatable.Rows[i]["chargedate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                if (!string.IsNullOrEmpty(zyjlcysj_fysc))
                {
                    if (DateTime.Parse(cfrq) > DateTime.Parse(zyjlcysj_fysc))
                    {
                        cfrq = zyjlcysj_fysc;
                    }
                }
                string dqrq_xz = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
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
                        ypdj = "丙";
                        standcode = "999999999";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        //try
                        //{
                        //    yptsxx = System.Text.RegularExpressions.Regex.Replace(smldz_cc[6], "['|<>&]", "");
                        //}
                        //catch { }
                        try
                        {
                            dqdzxxfh = System.Text.RegularExpressions.Regex.Replace(yw_in_smldz.Cc, "['<>&]", "");
                        }
                        catch
                        { }
                        //if ((smldz_cc[5] == "1") && ((datatable.Rows[i]["xzxypspbz"].ToString().Trim() == "0") || (string.IsNullOrEmpty(datatable.Rows[i]["xzxypspbz"].ToString().Trim()))))
                        //{
                        //    mesg += "[药品是限制用药：" + id + "-" + xmmc + "-" + yptsxx + "]\r\n";
                        //    string update_sql_xzxyp = "update ihsp_costdet set ypspbz=-1,dqdzxx='" + dqdzxxfh + "',yptsxx='" + yptsxx + "' where id=" + id + ";";
                        //    BllMain.Db.Update(update_sql_xzxyp);
                        //    continue;
                        //}
                        //else
                        //{
                        //    if ((smldz_cc[5] == "1") && (datatable.Rows[i]["xzxypspbz"].ToString().Trim() != "0") && (!string.IsNullOrEmpty(datatable.Rows[i]["xzxypspbz"].ToString().Trim())) && (datatable.Rows[i]["xzxypspbz"].ToString().Trim() != "-1"))
                        //    {
                        //        spbz = datatable.Rows[i]["xzxypspbz"].ToString().Trim();
                        //    }
                        //}
                    }
                }
                //读取床位信息
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
                        ypdj = "丙";
                        standcode = "999999999";
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
                //读取诊疗信息
                else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
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
                        ypdj = "丙";
                        standcode = "999999999";
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
                    ypdj = "丙";
                }
                string _insert_sql = "insert into KC22 (AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,AKC227,AAE040,ZKA100,CKC126,CKC125,AKA065,CKC048) values ";
                _insert_sql += "('" + ihspcode + "','" + id + "','" + ihspcode + "','" + cfrq + "','" + standcode + "','" + xmmc + "','" + lb + "'," + prc + "," + num + "," + fee + ",'" + jsrq + "','" + guige + "',0,0,'" + ypdj + "','" + spbz + "')";
                //更新ihsp_costdet.insursync=1
                string update_sql = "update ihsp_costdet set insursync='Y',yblx='" + ypdj + "',insurclass='" + ypdj + "',dqdzxx='" + dqdzxxfh + "',yptsxx='" + yptsxx + "' where id=" + id + ";";

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
        /// <summary>
        /// 先负担后金额
        /// </summary>
        /// <param name="mtzyjliid"></param>
        /// <param name="zyh"></param>
        /// <param name="mesg"></param>
        /// <returns></returns>
        public bool xfdhje(int ihsp_id, string zyh, out string mesg)
        {
            mesg = "";
            string ylzh = "";
            mesg = "";
            string his_cx = "select id from ihsp_costdet where ihsp_id='" + ihsp_id + "' and insursync='Y' and ybxfdhjebz=0;";
            DataTable dt_his_cx = BllMain.Db.Select(his_cx).Tables[0];
            if (dt_his_cx.Rows.Count == 0)
            {
                return true;
            }
            string sql_gxsfck = "select sfck,insurcode,ihspcode from inhospital where id='" + ihsp_id + "'";
            DataTable ds_sfck = BllMain.Db.Select(sql_gxsfck).Tables[0];
            if (ds_sfck.Rows[0]["sfck"].ToString().Trim() == "1")
            {
                ylzh = "0";
            }
            else
            {
                ylzh = ds_sfck.Rows[0]["insurcode"].ToString().Trim();
            }
            string sql_xgbzwl = "update ihsp_costdet set ybxfdhjebz = 0 where insursync='N' and ihsp_id = " + ihsp_id;
            BllMain.Db.Update(sql_xgbzwl);

            string kc22_cx = "select AKC220,AKC515 from kc22 where akc190='" + zyh + "' and CKC126=1 ";
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
            //先负担后金额
            YBCJ_IN yw_in_fdhje = new YBCJ_IN();
            yw_in_fdhje.Yw = "BB310004";
            yw_in_fdhje.Ybcjbz = "0";
            yw_in_fdhje.Ylzh = ylzh;
            for (int i = 0; i < dt_kc22_cx.Rows.Count; i++)
            {
                yw_in_fdhje.Rc = ds_sfck.Rows[0]["ihspcode"].ToString().Trim() + "|" + dt_kc22_cx.Rows[i]["AKC220"].ToString().Trim() + "|" + dt_kc22_cx.Rows[i]["AKC515"].ToString().Trim();
                int opt_ybfdhje = yw1.ybcjhs(yw_in_fdhje);
                if (opt_ybfdhje == 0)
                {
                    string[] fdhje_cc = yw_in_fdhje.Cc.Split('|');
                    //2019-3-21 程子浩 加insurclass
                    string update_sql = "update ihsp_costdet set ybxfdhjebz=1,ybxfdhje='" + fdhje_cc[0] + "', yblx = '" + fdhje_cc[1] + "', insurclass = '" + fdhje_cc[1] + "' where id=" + dt_kc22_cx.Rows[i]["AKC220"].ToString().Trim() + ";";
                    BllMain.Db.Update(update_sql);
                    string update_jkdb_sql = "update KC22 set AKA065='" + fdhje_cc[1] + "' where AKC190='" + ds_sfck.Rows[0]["ihspcode"].ToString().Trim() + "' and AKC220='" + dt_kc22_cx.Rows[i]["AKC220"].ToString().Trim() + "'";
                    jkdb.Update(update_jkdb_sql);
                }
                else
                {
                    mesg += "[负担后余额：zyh-" + zyh + "-" + yw_in_fdhje.Mesg + "]\r\n";
                }
            }
            return true;
        }
    }
}
