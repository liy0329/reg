using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.clintab.bll
{
    class BllFrxOper
    {
        /// <summary>
        /// 加载就诊类别下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getRegtypeInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlRegtype = "select id,name,keyname from bas_patienttype";
                dt = BllMain.Db.Select(sqlRegtype).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 加载部门下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDepartInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlDepart = "select id,name from bas_depart";
                dt = BllMain.Db.Select(sqlDepart).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        public DataTable getDepartInfo(string starTime,string endTime,string deparType,string depart,string patienType)
        {
            DataTable dt_orign = new DataTable();
            DataTable dt_now = new DataTable();
            string sql_orign = "";
            if (deparType == "RCPDPT")
            {
                sql_orign = " select "
                            + "bas_depart.name as diagndep_id,cost_itemtype1.name as name,sum(clinictab_costgather.realfee) as realfee"
                            + " from clinictab_costgather "
                            + " right join cost_itemtype1 "
                            + " on clinictab_costgather.itemtype1_id = cost_itemtype1.id "
                            + " left join bas_depart"
                            + " on bas_depart.id = clinictab_costgather.diagndep_id"
                            + " and clinictab_costgather.clinictab_id in ( select id from clinictab where enddate >="
                            + DataTool.addFieldBraces(starTime)
                            + " and enddate <= "
                            + DataTool.addFieldBraces(endTime) + ")";
                           if (!string.IsNullOrEmpty(depart)&& depart != "0")
                    sql_orign += " and clinictab_costgather.diagndep_id = "
                           + DataTool.addFieldBraces(depart);
                           if (!string.IsNullOrEmpty(patienType))
                    sql_orign += " and clinictab_costgather.bas_patienttype_id = "
                           + DataTool.addFieldBraces(patienType);
                           sql_orign += " group by diagndep_id,name ";
            }
            else if (deparType == "EXEDPT")
            {
                sql_orign = " select "
                               + "bas_depart.name as diagndep_id,cost_itemtype1.name as name,sum(clinictab_costgather.realfee) as realfee"
                               + " from clinictab_costgather "
                               + " right join cost_itemtype1 "
                               + " on clinictab_costgather.itemtype1_id = cost_itemtype1.id "
                               + " left join bas_depart"
                               + " on bas_depart.id = clinictab_costgather.diagndep_id"
                               + " and  clinictab_costgather.clinictab_id in ( select id from clinictab where enddate >="
                               + DataTool.addFieldBraces(starTime)
                               + " and enddate <= "
                               + DataTool.addFieldBraces(endTime) + ") ";
                               if(!string.IsNullOrEmpty(depart) && depart != "0")
                        sql_orign += " and clinictab_costgather.exedep_id = "
                               + DataTool.addFieldBraces(depart);
                               if(!string.IsNullOrEmpty(patienType))
                        sql_orign+= " and clinictab_costgather.bas_patienttype_id = "
                               + DataTool.addFieldBraces(patienType);
                               sql_orign += " group by diagndep_id,name ";
            }
            dt_orign = BllMain.Db.Select(sql_orign).Tables[0];
            string sql_num = " select count(id) from cost_itemtype1 where isstop ='N'";
            string num = BllMain.Db.Select(sql_num).Tables[0].Rows[0][0].ToString();
            //string sql_now = "select bas_depart.name "
            //               + " clinictab_costgather.costfee"

            return dt_orign;
        }
        public DataTable getDoctorInfo(string starTime, string endTime, string deparType, string depart, string patienType)
        {
            DataTable dt = new DataTable();
            string sql = "";
            if (deparType == "RCPDPT")
            {
                sql = " select "
                            + "bas_depart.name as diagndep_id,bas_doctor.name as dctname,cost_itemtype1.name as name,sum(clinictab_costgather.realfee) as realfee"
                            + " from clinictab_costgather "
                            + " right join cost_itemtype1 "
                            + " on clinictab_costgather.itemtype1_id = cost_itemtype1.id "
                            + " left join bas_depart"
                            + " on bas_depart.id = clinictab_costgather.diagndep_id"
                            + " left join bas_doctor"
                            + " on bas_doctor.id = clinictab_costgather.diagndoctor_id"
                            + " and clinictab_costgather.clinictab_id in ( select id from clinictab where enddate >="
                            + DataTool.addFieldBraces(starTime)
                            + " and enddate <= "
                            + DataTool.addFieldBraces(endTime) + ")";
                if (!string.IsNullOrEmpty(depart) && depart != "0")
                    sql += " and clinictab_costgather.diagndep_id = "
                           + DataTool.addFieldBraces(depart);
                if (!string.IsNullOrEmpty(patienType))
                    sql += " and clinictab_costgather.bas_patienttype_id = "
                           + DataTool.addFieldBraces(patienType);
                sql += " group by diagndep_id,dctname,name ";
            }
            else if (deparType == "EXEDPT")
            {
                sql = " select "
                               + "bas_depart.name as diagndep_id,bas_doctor.name as dctname,cost_itemtype1.name as name,sum(clinictab_costgather.realfee) as realfee"
                               + " from clinictab_costgather "
                               + " right join cost_itemtype1 "
                               + " on clinictab_costgather.itemtype1_id = cost_itemtype1.id "
                               + " left join bas_depart"
                               + " on bas_depart.id = clinictab_costgather.diagndep_id"
                               + " left join bas_doctor"
                               + " on bas_doctor.id = clinictab_costgather.exedoctor_id"
                               + " and  clinictab_costgather.clinictab_id in ( select id from clinictab where enddate >="
                               + DataTool.addFieldBraces(starTime)
                               + " and enddate <= "
                               + DataTool.addFieldBraces(endTime) + ") ";
                if (!string.IsNullOrEmpty(depart) && depart != "0")
                    sql += " and clinictab_costgather.exedep_id = "
                           + DataTool.addFieldBraces(depart);
                if (!string.IsNullOrEmpty(patienType))
                    sql += " and clinictab_costgather.bas_patienttype_id = "
                           + DataTool.addFieldBraces(patienType);
                sql += " group by diagndep_id,dctname,name ";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}
