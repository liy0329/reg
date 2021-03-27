using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTREG.clinic.bo;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;

namespace MTREG.clinic.bll
{
    class BllUnlockRcpManage
    {
        public DataTable getChargeData(ChargeManage chargeManage)
        {
            DataTable dt = new DataTable();

            string sql = "select "
                       + "clinic_invoice.id"
                       + ",register.billcode as regbill"
                       + ",clinic_invoice.billcode as invbill"
                       + ",register.name"
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",clinic_invoice.chargedate"
                       + ",register.hspcard"
                       + ",register.age"
                       + ",clinic_invoice.realfee"
                       + ",ihsp_info.idcard"
                       + " from clinic_invoice "
                       + " left join register"
                       + " on clinic_invoice.regist_id = register.id"
                       + " left join bas_depart"
                       + " on clinic_invoice.rcpdep_id = bas_depart.id"
                       + " left join bas_doctor"
                       + " on clinic_invoice.rcpdoctor_id = bas_doctor.id"
                       + " left join ihsp_info on ihsp_info.ihsp_id=register.id and ihsp_info.registkind=" + DataTool.addFieldBraces(RegistKind.CLIN.ToString())
                       + " where clinic_invoice.chargedate>= " + DataTool.addFieldBraces(chargeManage.StartDate)
                       + " and clinic_invoice.chargedate<= " + DataTool.addFieldBraces(chargeManage.EndDate)
                       + " and clinic_invoice.charged = " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                       + " and clinic_invoice.id in (select clinic_Invoice_id from clinic_costdet "
                       + " where retappstat = 'Y' and unlocked = 'N' )";
            if (!String.IsNullOrEmpty(chargeManage.PatientName))
                sql += "  and register.name like " + DataTool.addFieldBraces("%" + chargeManage.PatientName + "%");
            if (!String.IsNullOrEmpty(chargeManage.HspCard))
                sql += "  and register.hspcard = " + DataTool.addFieldBraces(chargeManage.HspCard);
            if (chargeManage.Depart_id != "0")
                sql += "  and clinic_invoice.rcpdep_id = " + DataTool.addFieldBraces(chargeManage.Depart_id);
            if (chargeManage.Doctor_id != "0")
                sql += "  and clinic_invoice.rcpdoctor_id = " + DataTool.addFieldBraces(chargeManage.Doctor_id);

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
