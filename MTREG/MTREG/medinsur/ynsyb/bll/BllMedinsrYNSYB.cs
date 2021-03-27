using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;

namespace MTREG.medinsur.ynsyb.bll
{
    class BllMedinsrYNSYB
    {
        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <returns></returns>
        public DataTable getPatientType()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name from bas_patienttype";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        public DataTable getDiagnInfo(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select aka120 as code,aka121 as name,aka066 as bre_code from ka06 where 1=1 and aka066 like '%" + pincode + "%' or aka121 like '%" + pincode + "%' or aka120 like '%" + pincode + "%'";
                dt = BllMain.Ynsybdb.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
            
            }
            return dt;
        }
    }
}
