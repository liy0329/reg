using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.clinic.bll
{
    class BllCmbList
    {
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
        /// <summary>
        /// 加载医生下拉框信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDoctorInfo(string depart_id)
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlDoctor = "select id,name from bas_doctor ";

                if (!(String.IsNullOrEmpty(depart_id) || depart_id == ""))
                    sqlDoctor += " where depart_id = "
                             + DataTool.addFieldBraces(depart_id);
                dt = BllMain.Db.Select(sqlDoctor).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
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
                String sqlRegtype = "select id,name from bas_patienttype";
                dt = BllMain.Db.Select(sqlRegtype).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
