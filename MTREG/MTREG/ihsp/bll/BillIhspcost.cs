using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo;

namespace MTREG.ihsp.bll
{
    class BillIhspcost
    {
        /// <summary>
        /// 回退审批查询按钮
        /// </summary>
        /// <returns></returns>
        public DataTable appSearch(Inhospital inhospital)
        {
            string startTime = inhospital.Indate;
            string endTime = inhospital.Outdate;
            string sql = "select inhospital.ihspcode"
                      + ",inhospital.name as ihspname"
                      + ",bas_depart.name as deparname"
                      + ",inhospital.indate"
                      + ",inhospital.outdate"
                      + ",inhospital.prepamt"
                      + ",inhospital.feeamt"
                      + ",bas_patienttype.name as patienttype"
                      + ",inhospital.hspcard"
                      + ",inhospital.balanceamt"
                      + ",inhospital.id"
                      + ",inhospital.sex"
                      + ",inhospital.age"
                      + ",bas_doctor.name as doctorname"
                      + " from inhospital "
                      + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                      + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                      + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                      + " left join member on member.id=inhospital.member_id "
                      + " LEFT JOIN ihsp_account ON ihsp_account.ihsp_id = inhospital.id "
                      + " where 1=1 and inhospital.status='SETT' and (unlocked is NULL or unlocked='N')"
                      + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                      + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                      + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                      + (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and bas_patienttype.name= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "");
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += "and ihsp_account.chargedate >= " + DataTool.addFieldBraces(startTime) + " and ihsp_account.chargedate<=" + DataTool.addFieldBraces(endTime);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 住院记录查询按钮
        /// </summary>
        /// <returns></returns>
        public DataTable ihspSearch(Inhospital inhospital)
        {
            string startTime = inhospital.Indate;
            string endTime = inhospital.Outdate;
            string sql_sign = "";

            if (inhospital.Status.Equals("SIGN"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",inhospital.healthcard"
                         + ",sybzyjl.AKC140 AS AKC140"
                         + ",(CONCAT(bas_patienttype. NAME ,(CASE inhospital.poverty	WHEN '1' THEN	'(低保)'	WHEN '2' THEN	'(农村低保)'	WHEN '3' THEN	'(分散五保)'	WHEN '4' THEN	'(集中五保)'  WHEN '5' THEN		'(建档立卡)'	ELSE	'(非贫困)'	END) )) AS patienttype"
                         + ",(case sybzyjl.AKA130 WHEN '21' THEN '普通住院' WHEN '25' THEN '转入住院' WHEN '27' THEN '意外伤害住院' WHEN '52' THEN '生育住院' ELSE '非医保入院' END) AS AKA130"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",'-1' as ihsp_account_id"
                         + ",'N' as neonate,'' as chargedate,'' as sfyname"
                         + " from inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP' " 
                         + " LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode"
                         + " where 1=1 and inhospital.outdate is not null "
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         + (!string.IsNullOrEmpty(inhospital.Status) ? (" and inhospital.status=  " + DataTool.addFieldBraces(inhospital.Status)) : " and inhospital.status in ('SIGN ','MSIG ')")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql_sign += " and inhospital.outdate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.outdate<=" + DataTool.addFieldBraces(endTime);
                }
            }
            if (inhospital.Status.Equals("SETT"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",inhospital.healthcard"
                         + ",sybzyjl.AKC140 AS AKC140"
                         + ",(CONCAT(bas_patienttype. NAME ,(CASE inhospital.poverty	WHEN '1' THEN	'(低保)'	WHEN '2' THEN	'(农村低保)'	WHEN '3' THEN	'(分散五保)'	WHEN '4' THEN	'(集中五保)'  WHEN '5' THEN		'(建档立卡)'	ELSE	'(非贫困)'	END) )) AS patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",ihsp_account.id as ihsp_account_id"
                         + ",ihsp_account.neonate as neonate,ihsp_account.chargedate,sfy.name as sfyname"
                         + " from ihsp_account,bas_doctor sfy,inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                         + " LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode"
                         + " where 1=1 and  ihsp_account.status='SETT' and ihsp_account.ihsp_id = inhospital.id and ihsp_account.chargedby_id = sfy.id "
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql_sign += " and ihsp_account.chargedate >= " + DataTool.addFieldBraces(startTime) + " and ihsp_account.chargedate<=" + DataTool.addFieldBraces(endTime);
                }
            }
            if (inhospital.Status.Equals("REG"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",inhospital.healthcard"
                         + ",sybzyjl.AKC140 AS AKC140"
                         + ",(CONCAT(bas_patienttype. NAME ,(CASE inhospital.poverty	WHEN '1' THEN	'(低保)'	WHEN '2' THEN	'(农村低保)'	WHEN '3' THEN	'(分散五保)'	WHEN '4' THEN	'(集中五保)'  WHEN '5' THEN		'(建档立卡)'	ELSE	'(非贫困)'	END) )) AS patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",'-1' as ihsp_account_id"
                         + ",'N' as neonate,'' as chargedate,'' as sfyname"
                         + " from inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " LEFT JOIN ihsp_account ON ihsp_account.ihsp_id = inhospital.id AND ihsp_account.status = 'SETT'"
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                         + " LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode"
                         + " where 1=1 and  inhospital.status='REG'"
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "");
                //if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                //{
                //    sql_sign += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
                //}
            }

            if (inhospital.Status.Equals("SYBX"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",inhospital.healthcard"
                         + ",sybzyjl.AKC140 AS AKC140"
                         + ",(CONCAT(bas_patienttype. NAME ,(CASE inhospital.poverty	WHEN '1' THEN	'(低保)'	WHEN '2' THEN	'(农村低保)'	WHEN '3' THEN	'(分散五保)'	WHEN '4' THEN	'(集中五保)'  WHEN '5' THEN		'(建档立卡)'	ELSE	'(非贫困)'	END) )) AS patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",ihsp_account.id as ihsp_account_id"
                         + ",ihsp_account.neonate as neonate,'' as chargedate,'' as sfyname"
                         + " from ihsp_account,bas_doctor sfy,inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                         + " LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode"
                         + " where 1=1 and  ihsp_account.status='SETT' and ihsp_account.ihsp_id = inhospital.id and ihsp_account.chargedby_id = sfy.id "
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql_sign += " and ihsp_account.chargedate >= " + DataTool.addFieldBraces(startTime) + " and ihsp_account.chargedate<=" + DataTool.addFieldBraces(endTime);
                }
            }
           
            DataTable dt = BllMain.Db.Select(sql_sign).Tables[0];
            return dt;
        }
        public DataTable ihspSearch1(Inhospital inhospital)
        {
            string startTime = inhospital.Indate;
            string endTime = inhospital.Outdate;
            string sql_sign = "";

            if (inhospital.Ybzt.Equals("WDJ"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.settInsurdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",bas_patienttype.name as patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",'-1' as ihsp_account_id"

                         + ",'N' as neonate"
                         + " from inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"

                         + " where 1=1 and inhospital.nhflag=0 and inhospital.status<>'XX'"
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                    //+ (!string.IsNullOrEmpty(inhospital.Status) ? (" and inhospital.status=  " + DataTool.addFieldBraces(inhospital.Status)) : " and inhospital.status in ('SIGN ','MSIG ')")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                    //+ (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "")
                         + (!string.IsNullOrEmpty(ProgramGlobal.Zyyblx) ? (" and bas_patienttype.payment_id in (" + ProgramGlobal.Zyyblx + ")") : "");
                //if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                //{
                //    sql_sign += " and inhospital.outdate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.outdate<=" + DataTool.addFieldBraces(endTime);
                //}
            }
            if (inhospital.Ybzt.Equals("YDJ"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.settInsurdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",bas_patienttype.name as patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",'-1' as ihsp_account_id"
                    
                         + ",'N' as neonate"
                         + " from inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                          
                         + " where 1=1 and inhospital.nhflag in(1101,301,1501) and inhospital.status<>'XX'"
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         //+ (!string.IsNullOrEmpty(inhospital.Status) ? (" and inhospital.status=  " + DataTool.addFieldBraces(inhospital.Status)) : " and inhospital.status in ('SIGN ','MSIG ')")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         //+ (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "")
                         + (!string.IsNullOrEmpty(ProgramGlobal.Zyyblx) ? (" and bas_patienttype.payment_id in (" + ProgramGlobal.Zyyblx + ")") : "");
                //if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                //{
                //    sql_sign += " and inhospital.outdate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.outdate<=" + DataTool.addFieldBraces(endTime);
                //}
            }
            if (inhospital.Ybzt.Equals("YCY"))
            {
                sql_sign = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",bas_depart.name as deparname"
                         + ",inhospital.indate"
                         + ",inhospital.outdate"
                         + ",inhospital.settInsurdate"
                         + ",inhospital.prepamt"
                         + ",inhospital.feeamt"
                         + ",bas_patienttype.name as patienttype"
                         + ",bas_patienttype.displaycolor as displaycolor"
                         + ",ihsp_info.companyname"
                         + ",ihsp_info.homeaddress"
                         + ",ihsp_info.homephone"
                         + ",inhospital.status"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         //+ ",'-1' as ihsp_account_id"
                         + " ,ihsp_account.id as ihsp_account_id"
                         + ",'N' as neonate"
                         + " from inhospital "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                         + " left join ihsp_account on ihsp_account.ihsp_id = inhospital.id and ihsp_account.status='SETT'"
                         + " where 1=1 and inhospital.nhflag in(1102,302,1502) and inhospital.status<>'XX'"
                         + (!string.IsNullOrEmpty(inhospital.Name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + inhospital.Name + "%")) : "")
                         //+ (!string.IsNullOrEmpty(inhospital.Status) ? (" and inhospital.status=  " + DataTool.addFieldBraces(inhospital.Status)) : " and inhospital.status in ('SIGN ','MSIG ')")
                         + (!string.IsNullOrEmpty(inhospital.Ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(inhospital.Ihspcode)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(inhospital.Hspcard)) : "")
                         //+ (!string.IsNullOrEmpty(inhospital.Patienttype) ? (" and inhospital.bas_patienttype_id= " + DataTool.addFieldBraces(inhospital.Patienttype)) : "")
                         + (!string.IsNullOrEmpty(inhospital.Depart) ? (" and inhospital.depart_id = " + DataTool.addFieldBraces(inhospital.Depart)) : "")
                         + (!string.IsNullOrEmpty(ProgramGlobal.Zyyblx) ? (" and bas_patienttype.payment_id in (" + ProgramGlobal.Zyyblx + ")") : "");
                //if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                //{
                //    sql_sign += " and inhospital.outdate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.outdate<=" + DataTool.addFieldBraces(endTime);
                //}
            }
            DataTable dt = BllMain.Db.Select(sql_sign).Tables[0];
            return dt;
        }
        /// <summary>
        /// 住院记录主键id查询
        /// </summary>
        /// <returns></returns>
        public DataTable ihspIdSearch(string id)
        {
            string sql = "select inhospital.ihspcode"
                            + ",inhospital.name as ihspname"
                            + ",bas_depart.name as deparname"
                            + ",inhospital.age"
                            + ",ageUnit.name as unitName"
                            + ",inhospital.ageunit"
                            + ",inhospital.moonage"
                            + ",inhospital.moonageunit"
                            + ",inhospital.depart_id"
                            + ",inhospital.doctor_id"
                            + ",inhospital.insurstat"
                            + ",inhospital.indate"
                            + ",inhospital.birthday"
                            + ",inhospital.sickroom_id"
                            + ",inhospital.sickbed_id"
                            + ",inhospital.outdate"
                            + ",inhospital.prepamt"
                            + ",inhospital.feeamt"
                            + ",bas_patienttype.name as patienttype"
                            + ",bas_patienttype.keyname"
                            + ",inhospital.bas_patienttype_id"
                            + ",inhospital.hspcard"
                            + ",inhospital.status"
                            + ",inhospital.balanceamt"
                            + ",inhospital.member_id"
                            + ",inhospital.clinicdiagn"
                            + ",inhospital.clinicicd"
                            + ",inhospital.ihspdiagn"
                            + ",inhospital.ihspicd"
                            + ",ihsp_info.idcard"
                            + ",ihsp_info.homephone"
                            + ",inhospital.limitamt"
                            + ",inhospital.costclass"
                            + ",inhospital.invoicecode"
                            + ",inhospital.introducer"
                            + ",sexList.name as sex"
                            + ",inhospital.sex as sexkeyname"
                            + ",bas_doctor.name as doctorname"
                            + ",inhospital.unlocked"
                            + ",inhospital.enterdep"
                            + ",inhospital.bas_ihspinstat_id"
                            + ",inhospital.bas_ihspoutstat_id"
                            + ",inhospital.bas_ihspsource_id"
                            + ",ihspinstat.name as ihspinstat"
                            + ",ihspoutstat.name as ihspoutstat"
                            + ",ihsp_info.homeaddress"
                            + ",ihsp_info.hmprovince"
                            + ",ihsp_info.hmcity"
                            + ",ihsp_info.hmcounty"
                            + ",ihsp_info.hmhouseNumber"
                            + ",ihsp_info.hmstreetname"
                            + ",ihsp_info.companyname"
                            + ",sys_region.mergername"
                            + " from inhospital "
                            + " left join sys_dict as ihspinstat on inhospital.bas_ihspinstat_id=ihspinstat.sn and ihspinstat.dicttype='bas_ihspinstat' and ihspinstat.father_id<>0"
                            + " left join sys_dict as ihspoutstat on inhospital.bas_ihspoutstat_id=ihspoutstat.sn and ihspoutstat.dicttype='bas_ihspoutstat' and ihspoutstat.father_id<>0"
                            + " left join sys_dict as ageUnit on inhospital.ageunit=ageUnit.sn and ageUnit.dicttype='bas_ageunit' and ageUnit.father_id<>0"
                            + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                            + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                            + " left join ihsp_info on inhospital.id=ihsp_info.ihsp_id and registkind='IHSP'"
                            + " left join sys_region on ihsp_info.hmstreetname=sys_region.id "
                            + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                            + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                            + " where inhospital.id = " + DataTool.addFieldBraces(id) ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            return dt;
        }

        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public string getInvoice(string ihspid)
        {
            DataTable datatable = new DataTable();
            string sql = "select invoice from ihsp_account"
                        + " where ihsp_id=" + DataTool.addFieldBraces(ihspid) 
                        + " and status='SETT'"
                        +" and chargedate="
                        +"(select MAX(chargedate) from ihsp_account where ihsp_id="+ DataTool.addFieldBraces(ihspid) +")";
            if (datatable.Rows.Count > 0)
            {
                string invoice = datatable.Rows[0]["invoice"].ToString();
                return invoice;
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 退费记录查询
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public DataTable ihspRetApp(IhspRetapp ihspRetapp)
        {
            string startTime = ihspRetapp.Approvedate;
            string endTime = ihspRetapp.Chkdate;
            string sql = "select ihsp_retapp.billcode"
                      + ",bas_depart.name as departname"
                      + ",bas_doctor.name as doctorname"
                      + ",ihsp_retapp.appdate"
                      + ",ihsp_retapp.approvedate"
                      + ",case"
                      + " when ihsp_retapp.status='CHK' then '已审核'"
                      + " when ihsp_retapp.status='DO' then '已退费'"
                      + " end as status"
                      + ",appdoctor.name as appdoname"
                      + ",ihsp_retapp.id"
                      + " from ihsp_retapp "
                      + " left join bas_depart on ihsp_retapp.appdep_id=bas_depart.id"
                      + " left join bas_doctor on ihsp_retapp.apper_id=bas_doctor.id "
                      + " left join bas_doctor as appdoctor on ihsp_retapp.approver_id=appdoctor.id "
                      + " where 1=1 "
                      + (!string.IsNullOrEmpty(ihspRetapp.Status) ? (" and ihsp_retapp.status=  " + DataTool.addFieldBraces(ihspRetapp.Status)) : "and ihsp_retapp.status in('CHK','DO')")
                      + (!string.IsNullOrEmpty(ihspRetapp.Appdep_id) ? (" and bas_depart.name =" + DataTool.addFieldBraces(ihspRetapp.Appdep_id)) : "");
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += " and ihsp_retapp.appdate >= " + DataTool.addFieldBraces(startTime) + " and ihsp_retapp.appdate<=" + DataTool.addFieldBraces(endTime);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 退费记录明细查询
        /// </summary>
        /// <returns></returns>
        public DataTable ihspRetAppdet(string id)
        {
            string sql = "select ihsp_retappdet.item_id"
                      + ",ihsp_retappdet.ihspcode"
                      + ",ihsp_retappdet.sickname"
                      + ",cost_itemtype.name as itemtypename"
                      + ",ihsp_retappdet.name as detname"
                      + ",ihsp_retappdet.spec"
                      + ",ihsp_retappdet.unit"
                      + ",ihsp_retappdet.num"
                      + ",ihsp_retappdet.prc"
                      + ",ihsp_retappdet.chargedate"
                      + ",ihsp_retappdet.ihsp_costdet_id"
                      + " from ihsp_retappdet"
                      + " left join bas_item on ihsp_retappdet.item_id=bas_item.id "
                      + " left join cost_itemtype on bas_item.itemtype_id=cost_itemtype.id"
                      + " left join inhospital on inhospital.id=ihsp_retappdet.ihsp_id"
                      + " where ihsp_retappdet.ihsp_retapp_id = " + DataTool.addFieldBraces(id)
                      ; 
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 更新退费记录明细
        /// </summary>
        /// <returns></returns>
        public string upRetappdet(string ihsp_retapp_id, string status)
        {
            string sql = "update ihsp_retapp set status=" + DataTool.addFieldBraces(status) + " where id=" + DataTool.addFieldBraces(ihsp_retapp_id)+";";
            return sql;
        }

        /// <summary>
        /// 更新费用表
        /// </summary>
        /// <returns></returns>
        public string  upCostdet(string appdetid, string status)
        {
            DataTable dt= ihspRetAppdet(appdetid);
            string sql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "update ihsp_costdet set charged=" + DataTool.addFieldBraces(status) + " where id=" + DataTool.addFieldBraces(dt.Rows[i]["ihsp_costdet_id"].ToString()) + ";";
            }
            return sql;
        }

        /// <summary>
        /// 插入红冲记录
        /// </summary>
        /// <param name="costdet_id"></param>
        /// <returns></returns>
        public string  inCostdet(string appdetid)
        {
            DataTable dt = ihspRetAppdet(appdetid);
            string insql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                string sql = "select * from ihsp_costdet where id=" + DataTool.addIntBraces(dt.Rows[i]["ihsp_costdet_id"].ToString());
                DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
                insql += "insert into ihsp_costdet(id"
                                            + ",ihsp_id"
                                            + ",ihsp_advdet_id"
                                            + ",standcode"
                                            + ",item_id"
                                            + ",itemfrom"
                                            + ",ihspdep_id"
                                            + ",diagndep_id"
                                            + ",diagndoctor_id"
                                            + ",exedep_id"
                                            + ",exedoctor_id"
                                            + ",costexdate"
                                            + ",name"
                                            + ",spec"
                                            + ",packsole"
                                            + ",drug_packsole_id"
                                            + ",unit"
                                            + ",num"
                                            + ",prc"
                                            + ",fee"
                                            + ",discnt"
                                            + ",realfee"
                                            + ",itemtype_id"
                                            + ",itemtype1_id"
                                            + ",ihsp_costdet_id"
                                            + ",charged"
                                            + ",chargedate"
                                            + ",auditemark"
                                            + ",charger_id)values("
                                            + DataTool.addIntBraces(BillSysBase.nextId("ihsp_costdet"))
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["ihsp_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["ihsp_advdet_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["standcode"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["item_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["itemfrom"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["ihspdep_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["diagndep_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["diagndoctor_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["exedep_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["exedoctor_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["costexdate"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["name"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["spec"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["packsole"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["drug_packsole_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["unit"].ToString())
                                            + "," + DataTool.addFieldBraces("-"+dt1.Rows[0]["num"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["prc"].ToString())
                                            + "," + DataTool.addFieldBraces("-" + dt1.Rows[0]["fee"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["discnt"].ToString())
                                            + "," + DataTool.addFieldBraces("-" + dt1.Rows[0]["realfee"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["itemtype_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["itemtype1_id"].ToString())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["id"].ToString())
                                            + "," + DataTool.addFieldBraces("RREC")
                                            + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                                            + "," + DataTool.addFieldBraces(dt1.Rows[0]["auditemark"].ToString())
                                            + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                                            + ");";
                string sql1 = "select keyname"
                                +" from cost_insurtype"
                                +" where id=(select cost_insurtype_id "
                                +" from bas_patienttype"
                                +" where id=(select bas_patienttype_id "
                                + " from inhospital where id=" + DataTool.addFieldBraces(dt1.Rows[0]["ihsp_id"].ToString()) + "))";
                DataTable dt2 = BllMain.Db.Select(sql1).Tables[0];
                if (BllMain.Db.Select(sql1).Tables[0].Rows.Count > 0)
                {
                    if(dt2.Rows[0]["keyname"].ToString()==CostInsurtypeKeyname.AHSJNH.ToString())
                    {
                        BllAhsnhMethod bllAhsnhMethod=new BllAhsnhMethod();
                        In_InpatientFeeCancel inp=new In_InpatientFeeCancel();
                        inp.SOperatorDate = dt1.Rows[0]["chargedate"].ToString();
                        inp.SItemKey = dt1.Rows[0]["id"].ToString();
                        BillCmbList billCmbList=new BillCmbList();
                        inp.SInputName = billCmbList.getDoctorName(dt1.Rows[0]["charger_id"].ToString());
                        RegInfo regInfo= bllAhsnhMethod.readRegInfo(dt.Rows[i]["ihsp_id"].ToString());
                        //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
                        inp.SInpatientID = regInfo.SInpatientID;
                        inp.SHospitalCode = regInfo.SHospitalCode;
                        inp.SAreaCode = regInfo.SAreaCode;
                        string sql3 = "select * from insur_costdet where ihsp_costdet_id =" + DataTool.addFieldBraces(dt1.Rows[0]["id"].ToString());
                        DataTable dt3 = BllMain.Db.Select(sql3).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            inp.SCenterKey = dt3.Rows[0]["insur_costed_id"].ToString();
                        }
                        retMesage ret=bllAhsnhMethod.inpatientFeeCancel(inp);
                    }
                }
            }
            return insql;

        }

        /// <summary>
        /// 住院记录查询费用表
        /// </summary>
        /// <returns></returns>
        
        public DataTable costSearch(string ihsp_id)
        {
            string sql = "select ihsp_costdet.item_id"
                      + ",cost_itemtype.name as itemtypename"
                      + ",bas_item.name"
                      + ",ihsp_costdet.spec"
                      + ",ihsp_costdet.prc"
                      + ",ihsp_costdet.num"
                      + ",ihsp_costdet.unit"
                      + ",bas_depart.name as departname"
                      + ",ihsp_costdet.fee"
                      + ",ihsp_costdet.realfee"
                      + ",ihsp_costdet.insurefee"
                      + ",ihsp_costdet.insurclass"
                      + ",ihsp_costdet.selffee"
                      + " from ihsp_costdet "
                      + " left join bas_item on ihsp_costdet.item_id=bas_item.id "
                      + " left join bas_depart on ihsp_costdet.exedep_id=bas_depart.id "
                      + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id"
                      + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                      //+ " and ihsp_costdet.settled= 'N' "
                      + "  and ihsp_costdet.charged in('RREC','RET','CHAR'); ";//charged为RREC：红冲、RET：退费、CHAR: 计费
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 住院记录查询费用表
        /// </summary>
        /// <returns></returns>

        public DataTable costSearchBySettle(string ihsp_acount_id)
        {
            string sql = "select ihsp_costdet.item_id"
                      + ",cost_itemtype.name as itemtypename"
                      + ",bas_item.name"
                      + ",ihsp_costdet.spec"
                      + ",ihsp_costdet.prc"
                      + ",ihsp_costdet.num"
                      + ",ihsp_costdet.unit"
                      + ",bas_depart.name as departname"
                      + ",ihsp_costdet.fee"
                      + ",ihsp_costdet.realfee"
                      + ",ihsp_costdet.insurefee"
                      + ",ihsp_costdet.insurclass"
                      + ",ihsp_costdet.selffee"
                      + " from ihsp_costdet "
                      + " left join bas_item on ihsp_costdet.item_id=bas_item.id "
                      + " left join bas_depart on ihsp_costdet.exedep_id=bas_depart.id "
                      + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id  "
                      + " where ihsp_costdet.ihsp_account_id = " + DataTool.addFieldBraces(ihsp_acount_id)
                      + " and ihsp_costdet.settled= 'Y' "
                      + " and ihsp_costdet.charged in('RREC','RET','CHAR'); ";//charged为RREC：红冲、RET：退费、CHAR: 计费
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public string getihsp_accountfee(Inhospital inhospital, string Chargeby)
        {
            string sql = @"select sum(feeamt) as sfje from ihsp_account where 1= 1 ";
            if (!String.IsNullOrEmpty(Chargeby) && Chargeby != "0")
            {
                sql += "  and ihsp_account.chargedby_id = " + DataTool.addFieldBraces(Chargeby);
            }
            sql += " and  status in('RET','SETT') and 	ihsp_account.chargedate >=" + DataTool.addFieldBraces(inhospital.Indate) + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(inhospital.Outdate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["sfje"].ToString() == null || dt.Rows[0]["sfje"].ToString() == "")
            {
                return "0.00";
            }
            return dt.Rows[0]["sfje"].ToString();
        }
        public string getihsp_accountcount(Inhospital inhospital, string Chargeby)
        {
            string sql = @"select count(*) as countzs from ihsp_account where 1= 1 ";
            if (!String.IsNullOrEmpty(Chargeby) && Chargeby != "0")
            {
                sql += "  and ihsp_account.chargedby_id = " + DataTool.addFieldBraces(Chargeby);
            }
            sql += " and  status in('RET','SETT') and 	ihsp_account.chargedate >=" + DataTool.addFieldBraces(inhospital.Indate) + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(inhospital.Outdate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["countzs"].ToString();
        }
        public string getihsp_accountRRECfee(Inhospital inhospital, string Chargeby)
        {
            string sql = @"select sum(feeamt) as sfje from ihsp_account where 1= 1 ";
            if (!String.IsNullOrEmpty(Chargeby) && Chargeby != "0")
            {
                sql += "  and ihsp_account.chargedby_id = " + DataTool.addFieldBraces(Chargeby);
            }
            sql += " and  status in('RET') and 	ihsp_account.chargedate >=" + DataTool.addFieldBraces(inhospital.Indate) + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(inhospital.Outdate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["sfje"].ToString() == null || dt.Rows[0]["sfje"].ToString() == "")
            {
                return "0.00";
            }
            return dt.Rows[0]["sfje"].ToString();
        }
        public string getihsp_accountRRECcount(Inhospital inhospital, string Chargeby)
        {
            string sql = @"select count(*) as countzs from ihsp_account where 1= 1 ";
            if (!String.IsNullOrEmpty(Chargeby) && Chargeby != "0")
            {
                sql += "  and ihsp_account.chargedby_id = " + DataTool.addFieldBraces(Chargeby);
            }
            sql += " and  status in('RET') and 	ihsp_account.chargedate >=" + DataTool.addFieldBraces(inhospital.Indate) + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(inhospital.Outdate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["countzs"].ToString();
        }
        public string getihsp_accountsum(Inhospital inhospital, string Chargeby)
        {
            string sql = @"select sum(feeamt) as sfje from ihsp_account where 1= 1 ";
            if (!String.IsNullOrEmpty(Chargeby) && Chargeby != "0")
            {
                sql += "  and ihsp_account.chargedby_id = " + DataTool.addFieldBraces(Chargeby);
            }
            sql += " and ihsp_account.chargedate >=" + DataTool.addFieldBraces(inhospital.Indate) + " AND ihsp_account.chargedate <= " + DataTool.addFieldBraces(inhospital.Outdate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["sfje"].ToString() == null || dt.Rows[0]["sfje"].ToString() == "")
            {
                return "0.00";
            }
            return dt.Rows[0]["sfje"].ToString();
        }
        /*
        /// <summary>
        /// 住院记录查询费用表 按项目合并
        /// </summary>
        /// <returns></returns>
        public DataTable costSearch(string ihsp_id)
        {
            string sql = "select ihsp_costdet.item_id"
                      + ",cost_itemtype.name as itemtypename"
                      + ",bas_item.name"
                      + ",ihsp_costdet.spec"
                      + ",ihsp_costdet.prc"
                      + ",sum(ihsp_costdet.num) as num"
                      + ",ihsp_costdet.unit"
                      + ",bas_depart.name as departname"
                      + ",sum(ihsp_costdet.fee) as fee"
                      + ",sum(ihsp_costdet.realfee) as realfee"
                      + ",sum(ihsp_costdet.insurefee) as insurefee"
                      + ",ihsp_costdet.insurclass"
                      + ",sum(ihsp_costdet.selffee) as selffee"
                      + " from ihsp_costdet "
                      + " left join bas_item on ihsp_costdet.item_id=bas_item.id "
                      + " left join bas_depart on ihsp_costdet.exedep_id=bas_depart.id "
                      + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id  "
                      + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                      + "  and ihsp_costdet.charged in('RREC','RET','CHAR')"//charged为RREC：红冲、RET：退费、CHAR: 计费
                      + " group by ihsp_costdet.item_id;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        */
    }
}
