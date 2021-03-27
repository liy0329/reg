using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.clinic.bll
{
    class BllSearchRegister
    {
        public DataTable getRegisterInfo(string starTime,string endTime,string patientName , string hspcard)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT "
                + " register.id"
                + ",register.billcode"
               + ",register.name as regname"
               + ",register.bas_patienttype_id"
               + ",register.depart_id"
               + ",bas_depart.name as dptname"
               + ",register.doctor_id"
               + ",bas_doctor.name as dctname"
               + ",register.hspcard"
               + ",register.sex "
               + ",register.age"
               + ",register.member_id"
               + " from register left join bas_depart on register.depart_id = bas_depart.id "
               + " left join bas_doctor on bas_doctor.id = register.doctor_id "
               + " where 1=1 "
               + " and register.status = 'REG' ";
               if (!String.IsNullOrEmpty(patientName))
                    sql += " and register.name like '%" + patientName.Trim() + "%' ";
               if (!String.IsNullOrEmpty(hspcard))
                   sql += " and register.hspcard = '" + hspcard.Trim() + "' ";
             
               sql += " and register.regdate>= " + DataTool.addFieldBraces(starTime)
                         + " and register.regdate<= " + DataTool.addFieldBraces(endTime);
              sql += ";";
            dt = BllMain.Db.Select(sql).Tables[0];

            return dt;
        }

    }
}
