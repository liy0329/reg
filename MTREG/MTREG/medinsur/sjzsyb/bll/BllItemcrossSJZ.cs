using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.ahsjk.bll;

namespace MTREG.medinsur.sjzsyb.bll
{
    class BllItemcrossSJZ
    {
        /// <summary>
        /// 获取医师中心编码
        /// </summary>
        /// <returns></returns>
        public string getDocCode(string hisCode)
        {
            string depcode = "";

            string sql = " SELECT BKF050 FROM contrast_doc "
                       + " LEFT JOIN register on register.doctor_id =  contrast_doc.bas_doctor_id "
                       + " WHERE register.id = " + DataTool.addFieldBraces(hisCode);
            depcode = BllMain.Db.Select(sql).Tables[0].Rows[0]["BKF050"].ToString();

            return depcode;
        }
        /// <summary>
        /// 获取科室中心编码
        /// </summary>
        /// <returns></returns>
        public string getDepCode(string hisCode)
        {
            string depcode = "";

            string sql = " SELECT AKF001 FROM contrast_dep "
                       + " LEFT JOIN register on register.depart_id =  contrast_dep.bas_depart_id"
                       + " WHERE register.id = " + DataTool.addFieldBraces(hisCode);
            depcode = BllMain.Db.Select(sql).Tables[0].Rows[0]["AKF001"].ToString();

            return depcode;
        }
        /// <summary>
        /// 获取交易流水号
        /// </summary>
        /// <returns></returns>
        public static string getTradingStream()
        {
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(1000, 10000);//用rad生成大于等于1000，小于等于9999的随机数；
            string suijishu = value.ToString(); //转化为字符串；
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string MSGID = "130100" + datetime + ProgramGlobal.AKB020 + suijishu;//交易流水号
            return MSGID;
        }
        /// <summary>
        /// 获取his项目信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="itemfrom"></param>
        /// <param name="isCross"></param>
        /// <returns></returns>
        public DataTable getItemInfo(string name, string itemfrom, string isCross)
        {
            DataTable dt = null;
            string sql = "";
            if (itemfrom.Equals("'DRUG'"))
            {
                sql += "SELECT "
                    + "cost_insurcross.insurcode AS AKA060,"
                    + "cost_insuritem.`name` AS AKA061,"
                    + "cost_insurcross.hiscode AS AKC515,"
                    + "bas_item.`name` AS AKC516,"
                    + "bas_item.pincode AS HISAKA066,"
                    + "sys_dict.`name` AS HISAKA070,"
                    + "bas_item.spec AS HISAKA077,"
                    + "drug_stockdet.realprc AS AKC225,"
                    + "drug_factory.`name` AS HISCKAA00, "
                    + "cost_insurcross.isstop "
                + "FROM "
                    + " cost_insurcross "
                    + " LEFT JOIN bas_item ON bas_item.id = cost_insurcross.item_id "
                    + " LEFT JOIN cost_insuritem ON cost_insuritem.id = cost_insurcross.cost_insuritem_id "
                    + " LEFT JOIN sys_dict ON sys_dict.dicttype = 'drug_dosageform' "
                    + " AND sys_dict.isstop = 'N' "
                    + " AND sys_dict.sn = bas_item.dosageform_id"
                    + " LEFT JOIN drug_stockdet ON drug_stockdet.item_id = bas_item.id"
                    + " LEFT JOIN drug_factory ON drug_factory.id = drug_stockdet.drug_factory_id "
                + " WHERE"
                    + " cost_insurcross.itemfrom = 'DRUG' "
                    + " AND ( cost_insurcross.hiscode LIKE '%" + name + "%' OR bas_item.`name` LIKE '%" + name + "%' OR bas_item.pincode LIKE '%" + name + "%' )";
                if (isCross.Equals("0"))
                {
                    sql += "AND cost_insurcross.isstop  <> '1' ";
                }
                else
                {
                    sql += "AND cost_insurcross.isstop  = '1' ";
                }
            }
            else
            {
                sql += "SELECT "
                    + " cost_insurcross.insurcode AS AKA060,"
                    + " cost_insuritem.`name` AS AKA061,"
                    + " cost_insurcross.hiscode AS AKC515,"
                    + " bas_item.`name` AS AKC516,"
                    + " bas_item.pincode AS HISAKA066,"
                    + " bas_item.county_prc AS AKC225,"
                    + " cost_insurcross.isstop "
                + " FROM"
                    + " cost_insurcross"
                    + " LEFT JOIN bas_item ON bas_item.id = cost_insurcross.item_id"
                    + " LEFT JOIN cost_insuritem ON cost_insuritem.id = cost_insurcross.cost_insuritem_id "
                + " WHERE"
                    + " cost_insurcross.itemfrom IN ( " + itemfrom + ") "
                    + " AND (  cost_insurcross.hiscode LIKE '%" + name + "%' OR bas_item.`name` LIKE '%" + name + "%' OR bas_item.pincode LIKE '%" + name + "%'  ) ";
                if (isCross.Equals("0"))
                {
                    sql += "AND cost_insurcross.isstop  <> '1' ";
                }
                else
                {
                    sql += "AND cost_insurcross.isstop  = '1' ";
                }

            }

            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取医保目录最新更新时间（max + 1）
        /// </summary>
        /// <returns></returns>
        public string getInsuritemUpdateat()
        {

            string sql = "SELECT max(AAE035) AS time from cost_insuritem";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string s = dt.Rows[0]["time"].ToString().Trim();
            if (dt.Rows[0]["time"].ToString().Trim() == null || dt.Rows[0]["time"].ToString().Trim() == "")
            {
                return "";
            }
            else
            {
                DateTime datetime = Convert.ToDateTime(dt.Rows[0]["time"].ToString().Trim());
                datetime = datetime.AddDays(1);
                return datetime.ToString("yyyy-mm-dd");
            }
        }
        /// <summary>
        /// 更新项目对照表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int insetInsurcross(string type, DataTable dt)
        {
            string ybbm = "";
            string hisbm = "";
            string sql = "";
            string hebz = "";
            string beizhu = "";


            foreach (DataRow dr in dt.Rows)
            {
                if (type.Equals("1"))
                {
                    ybbm = dr["AKA060"].ToString();
                    hisbm = dr["AKC515"].ToString();

                }
                else if (type.Equals("2"))
                {
                    ybbm = dr["AKA090"].ToString();
                    hisbm = dr["AKC515"].ToString();
                }
                else if (type.Equals("3"))
                {
                    ybbm = dr["AKA100"].ToString();
                    hisbm = dr["AKC515"].ToString();
                }
                hebz = dr["AAE016"].ToString();
                beizhu = dr["BAE001"].ToString();
                string sql_up = "UPDATE cost_insurcross set isstop = " + DataTool.addFieldBraces(hebz) + " , memo = " + DataTool.addFieldBraces(beizhu) + "  WHERE insurcode = " + DataTool.addFieldBraces(ybbm) + " AND hiscode = " + DataTool.addFieldBraces(hisbm) + ";";

                sql += sql_up;
            }


            return BllMain.Db.Update(sql);
        }
       
        public DataTable getjsxx(string starttime, string endtime, string type)
        {
            DataTable dt = new DataTable();
            string sql1 = "";
            if (type == "2")
                sql1 += " AND AKA130 IN (21,25,27,52)";
            if (type == "1")
                sql1 += " AND AKA130 IN (11,12,14,15,51)";

            string sql = " SELECT "
                       + " ( SELECT COUNT(id) FROM sjz_yb_jsxx WHERE (chongzheng <> 1  OR chongzheng is NULL) AND AKC264 > 0 AND AAE040 >= " + DataTool.addFieldBraces(starttime) + " AND AAE040 <= " + DataTool.addFieldBraces(endtime) + sql1 + "  ) AS BKB001,"
                       + " ( SELECT COUNT(id) FROM sjz_yb_jsxx WHERE (chongzheng <> 1  OR chongzheng is NULL) AND  AKC264 < 0 AND AAE040 >= " + DataTool.addFieldBraces(starttime) + " AND AAE040 <= " + DataTool.addFieldBraces(endtime) + sql1 + "  ) AS BKB002,"
                       + " SUM(AKC264) AS AKC264,"
                       + " SUM(AKC255) AS AKC255,"
                       + " SUM(AKC260) AS AKC260,"
                       + " SUM(AKC261) AS AKC261,"
                       + " SUM(AKC706) AS AKC706,"
                       + " SUM(AKC707) AS AKC707,"
                       + " SUM(AKC708) AS AKC708,"
                       + "(SUM(AKC264) - SUM(clinic_invoice.realfee) )AS clin,"
                       + "(SUM(AKC264)- SUM(ihsp_account.feeamt)) AS ihsp"
                   + " FROM"
                       + " sjz_yb_jsxx"
                   + " LEFT JOIN clinic_invoice on clinic_invoice.invoice = sjz_yb_jsxx.AAE072 "
                   + " LEFT JOIN ihsp_account ON ihsp_account.invoice = sjz_yb_jsxx.AAE072"
                   + " WHERE"
                   + " (chongzheng <> 1  OR chongzheng is NULL) "
                       + " AND "
                       + " AAE040 >= " + DataTool.addFieldBraces(starttime)
                   + " AND AAE040 <= " + DataTool.addFieldBraces(endtime) + sql1;

            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 结算信息
        /// </summary>
        public DataTable GETAccount(string starttime, string endtime, string type, string chargedby_id)
        {
            DataTable dt = new DataTable();

            string sql = " SELECT "
                       + " inhospital.`name` AS `name`, "
                       + " sjz_yb_jsxx.AKC190 AS AKC190, "
                       + " sjz_yb_jsxx.AAE072 AS AAE072,"
                       + " sjz_yb_jsxx.AKC264 AS AKC264,"
                       + " sjz_yb_jsxx.AKC255 AS AKC255,"
                       + " sjz_yb_jsxx.AKC260 AS AKC260,"
                       + " sjz_yb_jsxx.AKC261 AS AKC261,"
                       + " sjz_yb_jsxx.AKC706 AS AKC706,"
                       + " sjz_yb_jsxx.AKC707 AS AKC707,"
                       + " sjz_yb_jsxx.AKC708 AS AKC708,"
                       + " CASE WHEN ihsp_account. STATUS ='SETT' THEN '结算' WHEN ihsp_account. STATUS ='RREC' THEN '红冲'  WHEN ihsp_account. STATUS ='RET' THEN '退结算'  END AS STATUS,"
                       + " sjz_yb_jsxx.MSGID AS MSGID,"
                       + " sjz_yb_jsxx.REFMSGID AS REFMSGID"
                   + " FROM"
                       + " sjz_yb_jsxx"
                   + " LEFT JOIN ihsp_account ON ihsp_account.invoice = sjz_yb_jsxx.AAE072 "
                       + "  AND ihsp_account.status =( CASE WHEN sjz_yb_jsxx.AKC264 > 0 AND iscurr ='Y' THEN 'SETT' WHEN sjz_yb_jsxx.AKC264 > 0 AND iscurr ='N' THEN 'RET' WHEN sjz_yb_jsxx.AKC264 < 0 AND iscurr ='N' THEN 'RREC' END)"
                   + " LEFT JOIN inhospital ON inhospital.id = ihsp_account.ihsp_id"
                   + " WHERE"
                       + " (sjz_yb_jsxx.chongzheng <> 1  OR sjz_yb_jsxx.chongzheng is NULL) "
                       + " AND sjz_yb_jsxx.AAE040 >= " + DataTool.addFieldBraces(starttime)
                       + " AND sjz_yb_jsxx.AAE040 <= " + DataTool.addFieldBraces(endtime);
            if (type == "2")
            {
                sql += " AND sjz_yb_jsxx.registkind = 'IHSP'";
            }
            else if (type == "1")
            {
                sql += " AND sjz_yb_jsxx.registkind = 'CLIN'";
            } if (!String.IsNullOrEmpty(chargedby_id))
            {
                sql += " AND ihsp_account.chargedby_id = " + DataTool.addFieldBraces(chargedby_id) + ";";
            }

            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}