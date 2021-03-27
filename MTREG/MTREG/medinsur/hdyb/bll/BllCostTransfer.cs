using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdyb.bll
{
    class BllCostTransfer
    {
        /// <summary>
        /// 传输查询
        /// </summary>
        /// <param name="costInsurTypeId"></param>
        /// <returns></returns>
        public DataTable ihspSearch(string costInsurTypeId)
        {
            DataTable dt = new DataTable();
            string sql = "select inhospital.ihspcode"
                      + ",inhospital.name as ihspname"
                      + ",sexList.name as sex"
                      + ",bas_depart.name as departname"
                      + ",bas_doctor.name as doctorname"
                      + ",bas_sickroom.name as sickroomname"
                      + ",bas_sickbed.name as sickbedname"
                      + ",inhospital.indate"
                      + ",inhospital.hspcard"
                      + ",bas_patienttype.name as patienttypename "
                      + ",inhospital.bas_patienttype_id as patienttype"
                      + ",inhospital.id"
                      + " from inhospital "
                      + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                      + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                      + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                      + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                      + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                      + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                      + " where inhospital.insurstat = 'REG'";
            if (!string.IsNullOrEmpty(costInsurTypeId))
            {
                sql += " and inhospital.bas_patienttype_id"
                    + " in(select id from bas_patienttype where cost_insurtype_id =" + DataTool.addFieldBraces(costInsurTypeId)
                    + ") ";
            }
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 患者类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable costInsurTypeList()
        {
            string sql = "select id,name from cost_insurtype where keyname <>'SELFCOST'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 对照查询
        /// </summary>
        /// <param name="patienttypeId"></param>
        /// <returns></returns>
        public DataTable crossSearch(string itemfrom,string nameOrPincode)
        {
            DataTable dt = new DataTable();
            string sql = "select id "
                + ", standcode "
                + ", name "
                + ", spec "
                + ", unit "
                + ", city_prc"
                + " from bas_item "
                + " where itemfrom in (" + DataTool.addFieldBraces(itemfrom)+")"
                + " and (name like "+DataTool.addFieldBraces("%"+nameOrPincode+"%")
                + " or pincode like "+DataTool.addFieldBraces("%"+nameOrPincode+"%")
                + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

    }
}
