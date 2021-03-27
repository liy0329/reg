using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.clinic.bo;

namespace MTREG.clinic.bll
{
    class BllMemberSett
    {
        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <param name="hspcode"></param>
        /// <returns></returns>
        public DataTable getMemberInfo(string hspcode)
        {
            string sql = "select member.name"
                + " ,member.sex"
                + " ,member.id"
                + ",register.id as register_id"
                + ",register.age"
                + ",register.ageunit"
                + ",register.billcode"
                + ",register.healthcard"
                + ",register.insurcode"
                + ",register.depart_id"
                + ",register.doctor_id"
                + ",member_balance.balance"
                + " from register "
                + " left join member on register.member_id=member.id"
                + " left join member_balance on member_balance.bas_member_id=member.id"
                + " where member.hspcard=" + DataTool.addFieldBraces(hspcode)
                + " ORDER BY register.id DESC";
                //+ " and register.prepaid='Y'";
            DataTable dt= BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取未结算记录
        /// </summary>
        /// <returns></returns>
        public DataTable getNoSett(string member_id, string starttime, string endtime)
        {
            string sql = " SELECT"
	                   + " clinic_cost.id,"
	                   + " clinic_cost.billcode,"
	                   + " clinic_cost.rcptype"
                   + " FROM"
	                   + " clinic_cost"
                   + " LEFT JOIN clinic_costdet ON clinic_cost.id = clinic_costdet.clinic_cost_id"
                   + " RIGHT JOIN register ON register.ID = clinic_cost.regist_id " // AND register.clininicpay = 'B'"
                   + " WHERE"
	                   + " ("
		                   + " clinic_cost.ischarged = 'Y'"
		                   + " OR clinic_costdet.charged = 'CHAR'"
	                   + " )"
                   + " AND clinic_cost.regist_id IN ( SELECT  register.id FROM register LEFT JOIN member ON register.member_id=member.id WHERE member.id = "+DataTool.addFieldBraces(member_id)+" )"
                   + " AND clinic_costdet.rcpdate >= " + DataTool.addFieldBraces(starttime)
                   + " AND clinic_costdet.rcpdate <= " + DataTool.addFieldBraces(endtime)
                   + " AND (clinic_costdet.clinic_Invoice_id = '' OR clinic_costdet.clinic_Invoice_id IS NULL)"
                   + " GROUP BY"
	                   + " clinic_cost.id"
                   + " ORDER BY"
	                   + " clinic_cost.rcpdate DESC";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据收费主表id获取明细
        /// </summary>
        /// <param name="rechargedet_id"></param>
        /// <returns></returns>
        public DataTable getNoSettCostdet(string rechargedet_ids)
        {
            string sql = "select name"
                + ",spec"
                + ",unit"
                + ",num"
                + ",prc"
                + ",fee"
                + ",insurefee"
                + ",selffee"
                + ",id"
                + " from clinic_costdet"
                + " where clinic_cost_id in(" + DataTool.addIntBraces(rechargedet_ids) + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据发票记录获取明细
        /// </summary>
        /// <param name="rechargedet_id"></param>
        /// <returns></returns>
        public DataTable getSettCostdet(string Invoice_id)
        {
            string sql = "select name"
                + ",spec"
                + ",unit"
                + ",num"
                + ",prc"
                + ",fee"
                + ",insurefee"
                + ",selffee"
                + ",id"
                + " from clinic_costdet"
                + " where clinic_Invoice_id in(" + DataTool.addIntBraces(Invoice_id) + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据挂号记录编号获取
        /// </summary>
        /// <param name="regist_id"></param>
        /// <returns></returns>
        public DataTable getInvoiceInfo(string member_id)
        {
            string sql = "select invoice,id from clinic_invoice  where regist_id IN (SELECT  register.id FROM register LEFT JOIN member ON register.member_id=member.id WHERE member.id =" + DataTool.addIntBraces(member_id) + " )";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 更新费用明细
        /// </summary>
        /// <param name="rechargedet_id"></param>
        /// <returns></returns>
        public string upClinic_costdet(string rechargedet_ids)
        {
            string sql = "update clinic_costdet "
                        +" set settled='Y' "
                        + " where clinic_cost_id in (" + DataTool.addIntBraces(rechargedet_ids)
                        +");";
            return sql;
        }
        /// <summary>
        /// 更新修改充值记录
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public string upRechargedet(string rechargedet_ids)
        {
            string sql = "update member_rechargedet "
                + " set settled='Y'"
                + " where id in (" + DataTool.addIntBraces(rechargedet_ids)
                +");";
            return sql;
        }

        /// <summary>
        /// 插入发票表
        /// </summary>
        /// <param name="clinicInvoice"></param>
        /// <returns></returns>
        public string inClinic_invoice(ClinicInvoice clinicInvoice)
        {
            string sql = "insert into clinic_invoice(id"
                        + ",healthcard"
                        + ",insurcode"
                        + ",regist_id"
                        + ",sickname"
                        + ",fee"
                        + ",bas_patienttype_id"
                        + ",billcode"
                        + ",depart_id"
                        + ",chargedate"
                        + ",chargeby"
                        + ",charged"
                        + ",insurstat"
                        + ",Insurefee"
                        + ",insuraccountfee)values(" + DataTool.addIntBraces(clinicInvoice.Id)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Healthcard)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Insurcode)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Regist_id)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Sickname)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Fee)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Bas_patienttype_id)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Billcode)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Depart_id)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Chargedate)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Chargeby)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Charged)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Insurstat)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Insurefee)
                        + "," + DataTool.addFieldBraces(clinicInvoice.Insuraccountfee)
                        +");";
            return sql;     
        }
        /// <summary>
        /// 插入会员充值记录表
        /// </summary>
        /// <returns></returns>
        public string inMember_rechargedet(MemRechargedet memRechargedet)
        {
            string sql = "insert into member_rechargedet(id"
                       + ",bas_member_id"
                       + ",billcode"
                       + ",opertype"
                       + ",amount"
                       + ",bas_paytype_id"
                       + ",cheque"
                       + ",settled"
                       + ",balance"
                       + ",operator"
                       + ",operatdate"
                       + ",memo)values(" + DataTool.addFieldBraces(memRechargedet.Id)
                       + "," + DataTool.addFieldBraces(memRechargedet.Bas_member_id)
                       + "," + DataTool.addFieldBraces(memRechargedet.Billcode)
                       + "," + DataTool.addFieldBraces(memRechargedet.Opertype)
                       + "," + DataTool.addFieldBraces(memRechargedet.Amount)
                       + "," + DataTool.addFieldBraces("")//收款类型
                       + "," + DataTool.addFieldBraces("")//支票号
                       + "," + DataTool.addFieldBraces("Y")//是否已结算
                       + "," + DataTool.addFieldBraces(memRechargedet.Balance)
                       + "," + DataTool.addFieldBraces(memRechargedet.Operatorid)
                       + "," + DataTool.addFieldBraces(memRechargedet.Operatdate)
                       + "," + DataTool.addFieldBraces("")//备注
                       + ");";
            return sql;
        }

        /// <summary>
        /// 修改会员卡内余额表
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public string modifyMember_balance(string balance,string member_id)
        {
            string sql = "update member_balance set balance = " + DataTool.addFieldBraces(balance)
                + "where bas_member_id = " + DataTool.addFieldBraces(member_id) + ";";
            return sql;
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDepartInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlDepart = "select id,name from bas_depart where id in (select depart_id from bas_depart_departtype where departtype_id in(select id from bas_departtype where typecode in('CLIN','IHSP')))";
                dt = BllMain.Db.Select(sqlDepart).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        ///根据id或者外键， 获取医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDoctorInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sqlDoctor = "select id,name from bas_doctor "
                                 + " where id in (select doctor_id from bas_doctor_doctype where doctype = 'DOCTOR')";
                dt = BllMain.Db.Select(sqlDoctor).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
