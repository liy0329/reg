using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.common.bll;
using System;
using System.IO;
using System.Xml;
//using MTREG.medinsur.sjzsyb.clinic.bo;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;
using MTHIS.common;
using MTREG.medinsur.hdyb.dor;

namespace MTREG.tools
{
    class Zyybfysc_button
    {
        int sss = 0;
        SjzybInterface SjzybInterface = new SjzybInterface();
        public RetMsg ybscfymx(int ihsp_id, string grbh, string zyh, Label txt)
        {
            sss = 0;
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            string sql = "select * from ihsp_costdet where  insursync = 'N' AND ihsp_costdet.charged IN ('CHAR') and ihsp_id = " + ihsp_id;
            string counts = BllMain.Db.Select(sql).Tables[0].Rows.Count.ToString().Trim();

            int flag = 1;
            while (flag > 0)
            {
                flag = scfymx(ihsp_id, counts, zyh, out mesg, txt);
                sss = sss + 50;
                //if (sss > 5 * int.Parse(counts))
                //{
                //    return ret;
                //}
                if (flag >= 50)
                {
                    Thread.Sleep(1000);
                }
                if (flag == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
                ret.Mesg += mesg;
            }
            int flag1 = 1;
            while (flag1 > 0)
            {
                flag1 = scfymx_at(ihsp_id, counts, zyh, out mesg);
                if (flag1 >= 50)
                {
                    Thread.Sleep(1000);
                }
                if (flag1 == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
                ret.Mesg += mesg;
            }
            return ret;

        }

        /// <summary>
        /// 医保费用上传
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="counts"></param>
        /// <param name="zyh"></param>
        /// <param name="mesg"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        private int scfymx(int ihsp_id, string counts, string zyh, out string mesg, Label txt)
        {
            mesg = "";

            string sql1 = "SELECT "
                            + " inhospital.ihspcode AS AKC190, "//门诊（住院）号，
                            + " ihsp_costdet.id AS AKC220, "//处方号
                            + " ihsp_costdet.costexdate AS AKC221, "//处方日期 YYYYMMDDHH24MISS
                            + " cost_insurcross.hiscode AS AKC515, "//医院收费项目编码
                            + " ihsp_costdet.NAME AS AKC516, "//医院收费项目名称
                            + " cost_insurcross.insurcode AS AKC222, "//中心收费项目编码
                            + " cost_insurcross.insurname AS AKC223, "//中心收费项目名称
                            + " bas_item.itemfrom AS AKC224, "//药品/诊疗/床位费
                            + " ihsp_costdet.prc AS AKC225, "//单价
                            + " ihsp_costdet.num AS AKC226, "//数量
                            + " ROUND(ihsp_costdet.fee,2) AS AKC227, "//金额（单价*数量=金额）
                            + " (SELECT BKF050 FROM contrast_doc WHERE contrast_doc.bas_doctor_id =ihsp_costdet.doctor_id GROUP BY BKF050) AS BKF050, "//中心医师编码
                            + " (SELECT AKF001 FROM contrast_dep WHERE contrast_dep.bas_depart_id = ihsp_costdet.ihspdep_id GROUP BY AKF001) AS BKF040,"//中心科室编码
                            + " bas_item.unit AS BKA076,"//销售单位，例如“盒”
                            + " ihsp_costdet.unit AS BKA067, "//基本单位（小单位），例如“片”
                            + " bas_item.pkgunit AS CKAA08, "//包装单位
                            + " bas_item.pkgcount AS CKAA09 ,"//包装单位基本单位换算比例
                            + " cost_insuritem.AKA068II ,"
                            + " cost_insuritem.AKA068,"
                            + " cost_insuritem.limitprc"
                        + " FROM "
                            + " ihsp_costdet "
                            + " LEFT JOIN inhospital ON inhospital.id = ihsp_costdet.ihsp_id "
                            + " LEFT JOIN cost_itemtype ON cost_itemtype.id = ihsp_costdet.itemtype_id "
                            + " LEFT JOIN bas_item ON bas_item.id = ihsp_costdet.item_id  "
                            + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id "
                            + " LEFT JOIN cost_insuritem ON cost_insurcross.cost_insuritem_id = cost_insuritem.id"
                //+ " LEFT JOIN contrast_dep ON contrast_dep.bas_depart_id = ihsp_costdet.diagndep_id "
                //+ " LEFT JOIN contrast_doc ON contrast_doc.bas_doctor_id = ihsp_costdet.diagndoctor_id "
                            + " where ihsp_costdet.ihsp_id=" + ihsp_id
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('CHAR')"
                //+ " and ihsp_costdet.ypspbz not in(-1)"
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable datatable = BllMain.Db.Select(sql1).Tables[0];


            int retnum = 0;
            retnum = datatable.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }
            SJZYB_IN<DBNull> sjzyb_in = new SJZYB_IN<System.DBNull>();
            sjzyb_in.KC22XML = new List<KC22>();
            int I = 0;
            foreach (DataRow dr in datatable.Rows)
            {
                txt.Text = "正在上传费用：" + (sss + I++ + 1).ToString() + "/" + counts;
                txt.Update();
                KC22 kc22 = new KC22();
                kc22.AKC190 = dr["AKC190"].ToString().Trim();
                kc22.AKC220 = dr["AKC220"].ToString().Trim();
                kc22.AKC221 = DateTime.Parse(dr["AKC221"].ToString().Trim()).ToString("yyyyMMddHHmmss");
                kc22.AKC515 = dr["AKC515"].ToString().Trim();
                kc22.AKC516 = dr["AKC516"].ToString().Trim();
                kc22.AKC222 = dr["AKC222"].ToString().Trim();
                kc22.AKC223 = dr["AKC223"].ToString().Trim();
                if (dr["AKC224"].ToString().Trim().ToUpper().Equals("DRUG"))
                {
                    dr["AKC224"] = "1";
                }
                else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("COST"))
                {
                    dr["AKC224"] = "2";
                }
                else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("STUFF"))
                {
                    dr["AKC224"] = "3";
                }
                kc22.AKC224 = dr["AKC224"].ToString().Trim();
                kc22.AKC225 = dr["AKC225"].ToString().Trim();
                kc22.AKC226 = dr["AKC226"].ToString().Trim();
                kc22.AKC227 = dr["AKC227"].ToString().Trim();
                kc22.AKC378 = DateTime.Now.ToString("yyyyMMddHHmmss") + dr["AKC220"].ToString().Trim();
                kc22.BKF050 = dr["BKF050"].ToString().Trim();
                kc22.BKF040 = dr["BKF040"].ToString().Trim();
                kc22.BKA076 = dr["BKA076"].ToString().Trim();
                kc22.AKA067 = dr["BKA067"].ToString().Trim();
                kc22.CKAA08 = dr["CKAA08"].ToString().Trim();
                kc22.CKAA09 = dr["CKAA09"].ToString().Trim();
                sjzyb_in.KC22XML.Add(kc22);


                //if ((kc22.AKC224 != "1" && dr["limitprc"].ToString() != "0") && (Double.Parse(kc22.AKC225) > Double.Parse(dr["AKA068II"].ToString())))
                //    mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",属于" + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "项目，当前单价：" + kc22.AKC225 + "," + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "：" + dr["AKA068II"].ToString();
                //if ((kc22.AKC224 == "1" && dr["limitprc"].ToString() != "0") && (Double.Parse(kc22.AKC225) > Double.Parse(dr["AKA068"].ToString())))
                //    mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",属于" + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "项目，当前单价：" + kc22.AKC225 + "," + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "：" + dr["AKA068II"].ToString();
                if (String.IsNullOrEmpty(kc22.AKC222))
                {
                    mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",未对照\r\n";
                }

                string sql = "update ihsp_costdet set AKC378 = " + DataTool.addFieldBraces(kc22.AKC378) + " where id = " + DataTool.addFieldBraces(kc22.AKC220);
                BllMain.Db.Update(sql);
            }
            //if (mesg.LastIndexOf("限额") > 0)
            //    return -1;





            string Ylzh = "";

            string sql_gxsfck = "select healthcard,insurcode, AKA130 from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            string yllb = ds_sfck.Tables[0].Rows[0]["AKA130"].ToString().Trim();
            string grbh = ds_sfck.Tables[0].Rows[0]["insurcode"].ToString().Trim();
            string iccode = ds_sfck.Tables[0].Rows[0]["healthcard"].ToString().Trim();

            Ylzh = grbh;

            sjzyb_in.AKA130 = yllb;
            sjzyb_in.AAC001 = Ylzh;
            sjzyb_in.AKC190 = zyh;
            sjzyb_in.AKC020 = iccode;
            sjzyb_in.MSGNO = "1103";

            SJZYB_OUT out1 = new SJZYB_OUT();

            int i = SjzybInterface.zyfysc(sjzyb_in, out1);



            if (out1.RETURNNUM == -1)//错误，业务出参中的errorMSG为错误信息
            {

                mesg += "住院号：" + zyh + "错误信息 " + out1.ERRORMSG;
                return -1;
            }
            foreach (DataRow dr in datatable.Rows)
            {
                string iid = "";
                iid = dr["AKC220"].ToString().Trim();
                string sql_ybsc = "update ihsp_costdet set insursync='Y',MSGID = " + DataTool.addFieldBraces(sjzyb_in.MSGID) + " where id = " + iid.ToString() + ";";
                if (dr["BKA076"].ToString().Trim().Equals("套"))
                {
                    sql_ybsc += "UPDATE ihsp_costdet SET inset = 'N' WHERE id = " + iid.ToString() + ";";
                }
                int z = BllMain.Db.Update(sql_ybsc);
            }



            mesg += "";
            return retnum;
        }
        /// <summary>
        /// 按套限价项目使用情况上传
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="counts"></param>
        /// <param name="zyh"></param>
        /// <param name="mesg"></param>
        /// <returns></returns>
        public int scfymx_at(int ihsp_id, string counts, string zyh, out string mesg)
        {
            mesg = "";

            string sql1 = "SELECT "
                            + " ihsp_costdet.id AS AKC220, "//处方号
                            + " cost_insurcross.insurcode AS AKC222, "//中心收费项目编码
                            + " cost_insurcross.insurname AS AKC223, "//中心收费项目名称
                            + " ihsp_costdet.num AS AKC226 "//数量
                        + " FROM "
                            + " ihsp_costdet "
                            + " LEFT JOIN bas_item ON bas_item.id = ihsp_costdet.item_id  "
                            + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id "
                            + " LEFT JOIN cost_insuritem ON cost_insurcross.cost_insuritem_id = cost_insuritem.id"
                            + " where ihsp_costdet.ihsp_id=" + ihsp_id
                            + " and ihsp_costdet.charged in ('CHAR')"
                            + " AND ihsp_costdet.inset NOT IN ('Y') "
                            + " AND cost_insuritem.unit IN ('套') "
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable datatable = BllMain.Db.Select(sql1).Tables[0];

            int retnum = 0;
            retnum = datatable.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }


            SJZYB_IN<ATSC> sjzyb_in = new SJZYB_IN<ATSC>();
            sjzyb_in.INPUT = new List<ATSC>();
            foreach (DataRow dr in datatable.Rows)
            {
                ATSC atsc = new ATSC();
                atsc.AKC222 = dr["AKC222"].ToString().Trim();
                atsc.AKC223 = dr["AKC223"].ToString().Trim();
                atsc.CKAA11 = dr["AKC226"].ToString().Trim();
                sjzyb_in.INPUT.Add(atsc);
            }



            Sjzsyb_IN syb_in = new Sjzsyb_IN();
            string Ylzh = "";//医疗证号
            string sql_ybjl = "SELECT AKC190,AKA130,AAC001,CKC502 FROM Sybzyjl  WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb = dtybjl.Rows[0]["AKA130"].ToString().Trim();
            string grbh = dtybjl.Rows[0]["AAC001"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["AKC020"].ToString().Trim();
            string sql_gxsfck = "select sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                Ylzh = "0";
            }
            else
            {
                Ylzh = grbh;
            }
            sjzyb_in.AKA130 = yllb;
            sjzyb_in.AAC001 = Ylzh;
            sjzyb_in.AKC190 = zyh;
            sjzyb_in.AKC020 = iccode;
            sjzyb_in.MSGNO = "1130";
            SJZYB_OUT out1 = new SJZYB_OUT();

            int ret = SjzybInterface.zyfysc_at(sjzyb_in, zyh, out1);

            if (out1.RETURNNUM == -1)//错误，业务出参中的errorMSG为错误信息
            {

                mesg += "住院号：" + zyh + "错误信息 " + out1.ERRORMSG;
                return -1;
            }
            foreach (DataRow dr in datatable.Rows)
            {
                string iid = "";
                iid = dr["AKC220"].ToString().Trim();
                string sql_ybsc = "UPDATE ihsp_costdet SET inset = 'N' WHERE id" + iid.ToString() + ";";
                int z = BllMain.Db.Update(sql_ybsc);
            }

            return retnum;
        }
    }
}
