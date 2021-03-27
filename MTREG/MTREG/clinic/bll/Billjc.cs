using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.clinic.bo;
using MTHIS.db;
using System.Data.SqlClient;
using System.Data.Odbc;
using MTHIS.tools;
using MTREG.common.bll;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class Billjc
    {

        /// <summary>
        /// 获取所有部位
        /// </summary>
        /// <returns></returns>
        public DataTable getbw()
        {
            string sql_bw = @"select 0 as id, '' as name union select  id, name  from chk_bodypart ";
            DataTable dt = BllMain.Db.Select(sql_bw).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="mzh"></param>
        /// <returns></returns>
        public string getid(string mzh)
        {
            string sql_clinic_costdet_ids = "SELECT id from clinic_costdet where regist_id = (select id from register where billcode = " + mzh + ") and rcpdate = '" + DateTime.Now+"'";
            DataTable dt = BllMain.Db.Select(sql_clinic_costdet_ids).Tables[0];
            string id = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id += dt.Rows[i]["id"].ToString() + ",";
            }
            return id;
        }
        /// <summary>
        /// 获取所有检查
        /// </summary>
        /// <param name="jcksiid"></param>
        /// <returns></returns>
        public DataTable getjc(string jcksiid, string bw,string pincode)
        {
            string sql_jc = @"SELECT jc.id,jc.NAME,jc.pincode ,(select sum(prc*num) from chk_diagnsetcost where chk_diagnset_id = jc.id and isstop = 'N') as prc,bw.name FROM chk_diagnset AS jc LEFT JOIN chk_diagnbodypart AS jcbw ON jcbw.chk_diagnset_id = jc.id 
                                LEFT JOIN chk_bodypart as bw on jcbw.chk_bodypart_id = bw.id WHERE jc.isstop = 'n'  and jc.chk_opkind_id =" + jcksiid;
            if (pincode != null && pincode != "")
            {
                sql_jc += " AND jc.pincode LIKE '%" + pincode + "%'";
            }
            if (bw != null && bw != "")
            {
                sql_jc += " and bw.id in(select id from chk_bodypart where bw.name like '%" + bw + "%')";
            }
            DataTable dt = BllMain.Db.Select(sql_jc).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取所有检查子项
        /// </summary>
        /// <param name="jcksiid"></param>
        /// <returns></returns>
        public DataTable getjczx(int jcid)
        {
            string sql_jczx = @"select id,name,pincode,prc from chk_diagnsetcost where isstop = 'N' and chk_diagnset_id = " + jcid;
            DataTable dt = BllMain.Db.Select(sql_jczx).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取所有执行科室
        /// </summary>
        /// <param name="jcksiid"></param>
        /// <returns></returns>
        public DataTable getzxks()
        {
            string sql_zxks = @"select * from chk_opkind";
            DataTable dt = BllMain.Db.Select(sql_zxks).Tables[0];
            return dt;
        }
        /// <summary>
        /// 添加检查项目
        /// </summary>
        /// <param name="iid"></param>
        /// <param name="tcname"></param>
        /// <param name="isparentiid"></param>
        /// <param name="mtjciid_1"></param>
        public DataTable getmtjcxm(string name)
        {
            //dataGridViewFy.Rows.Add();
            string sql = @"SELECT chk_diagnset.id AS id,NULL AS itemtype_id,NULL AS itemtype1_id,NULL AS itemtypename,chk_diagnset. NAME AS itemname,
	                        NULL AS spec,
	                        chk_diagnset.unit AS unit,
	                        (select sum(prc*num) from chk_diagnsetcost where chk_diagnset_id = chk_diagnset.id and isstop = 'N') AS prc,
	                        '0' AS qty,
	                        '0' AS useqty,
	                        chk_diagnset.execdept_id AS exedep_id,
	                        bas_depart. NAME AS dptname,
	                        chk_diagnset.chkkind AS type,
	                        'CHECK' AS itemfrom,
	                        '' AS packsole,
	                        '' AS drug_packsole_id,
	                        chk_diagnset.chk_opkind_id,
	                        chk_diagnset.chk_type_id,
	                        chk_diagnset.chk_sampletype_id
                        FROM
	                        chk_diagnset
                        LEFT JOIN bas_depart ON bas_depart.id = chk_diagnset.execdept_id
                        WHERE
	                        chk_diagnset.id = '" + name+"'";
            DataTable dtjc = BllMain.Db.Select(sql).Tables[0];
            return dtjc;
        }
        public DataTable getffp(string id)
        {
            string sql_ffp = @"select exedep_id,count(0)  from clinic_costdet
                               where clinic_cost_id in ("+id+") GROUP BY exedep_id having count(exedep_id) >0 ORDER BY exedep_id";
            DataTable dt = BllMain.Db.Select(sql_ffp).Tables[0];
            return dt;
        }
        public string getpkh(string sfzh,string name)
        {
            string ts = "";
            string sql_cxpkh = @"select * from mtpkh where 1 =1  ";
            if (sfzh != "" && sfzh != null && name != "" && name != null)
            {
                sql_cxpkh += " and sfzh = '" + sfzh + "'";
                sql_cxpkh += " and name = '" + name + "'";
                DataTable dt = BllMain.Db.Select(sql_cxpkh).Tables[0];
                if (dt.Rows.Count == 1)
                    ts = dt.Rows[0]["type"].ToString() ;
                return ts;
            }
            else if (name != "" && name != null)
            {
                sql_cxpkh += " and name = '" + name + "'";
                DataTable dt = BllMain.Db.Select(sql_cxpkh).Tables[0];
                if (dt.Rows.Count > 0)
                    ts = dt.Rows[0]["type"].ToString();
                return ts;
            }
            else if (sfzh != "" && sfzh != null)
            {
                sql_cxpkh += " and sfzh = '" + sfzh + "'";
                DataTable dt = BllMain.Db.Select(sql_cxpkh).Tables[0];
                if (dt.Rows.Count == 1)
                    ts = dt.Rows[0]["type"].ToString();
                return ts;
            }

            return ts;
        }

        
    }
}
