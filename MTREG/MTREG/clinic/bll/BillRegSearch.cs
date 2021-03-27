using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTREG.clinic.bo;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.clinic.bll
{
    class BillRegSearch
    {

       
        /// <summary>
        /// 挂号记录查询按钮
        /// </summary>
        /// <returns></returns>
        public DataTable regSearch(Register register)
        {
            string startTime = register.Createtime;
            string endTime = register.Updatetime;
            DataTable dt = new DataTable();
            
          string  sql = @"select register.billcode,
	                    register.hspcard,
	                    (select sexList.name from sys_dict AS sexList WHERE register.sex = sexList.keyname AND sexList.dicttype = 'bas_sex' AND sexList.father_id <> 0) AS sex,
	                    register.NAME AS regname,
	                    register.age,
	                    (select name from sys_dict AS ageUnit where register.ageunit = ageUnit.sn AND ageUnit.dicttype = 'bas_ageunit' AND ageUnit.father_id <> 0) AS ageunit,
	                    register.amount,
                      (select name from bas_depart WHERE register.depart_id = bas_depart.id) AS deparname,	
	                    (select name from bas_doctor where register.doctor_id = bas_doctor.id) AS doctorname,
                      (SELECT name from bas_doctor AS chargeby where register.users_id = chargeby.id) AS chargeby,
	                    register.regdate,
	                    CASE
                    WHEN register. STATUS = 'REG' THEN
	                    '挂号'
                    WHEN register. STATUS = 'BACK' THEN
	                    '退号'
                    WHEN register. STATUS = 'XX' THEN
	                    '作废'
                    END AS STATUS,
                     CASE
                    WHEN register.prepaid = 'N' THEN
	                    '非储值卡'
                    WHEN register.prepaid = 'Y' THEN
	                    '储值卡'
                    END AS prepaid,
                    (SELECT	id FROM clinic_invoice WHERE register.id = clinic_invoice.regist_id	AND clinic_invoice.isregist = '1') AS clinic_invoice_id,
                    (SELECT	invoice FROM clinic_invoice WHERE register.id = clinic_invoice.regist_id	AND clinic_invoice.isregist = '1') as invoice,
                     register.id AS registerid from register where 1 =1  "
                      + (!string.IsNullOrEmpty(register.Name) ? (" and  register.name like '%" +register.Name+"%'") : "")
                      + (!string.IsNullOrEmpty(register.Hspcard) ? (" and register.hspcard = " + DataTool.addFieldBraces(register.Hspcard)) : "")
                      + (!string.IsNullOrEmpty(register.Status) ? (" and register.status= " + DataTool.addFieldBraces(register.Status)) : "and register.status in('RECV','REG','RUSH')");
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += " and register.regdate >= " + DataTool.addFieldBraces(startTime) + " and register.regdate<=" + DataTool.addFieldBraces(endTime);
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
        /// 主键查询
        /// </summary>
        /// <returns></returns>
        public DataTable regIdSearch(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select register.billcode"
                      + ",register.name as regname"
                      + ",sexList.name as sex"
                      + ",register.age"
                      + ",register.ageunit"
                      + ",register.depart_id"
                      + ",register.doctor_id"
                      + ",bas_depart.name as departname"
                      + ",bas_doctor.name as doctorname"
                      + ",chargeby.name as chargeby"
                      + ",register.amount"
                      + ",register.regdate"
                      + ",register.hspcard"
                      + ",register.status"
                      + ",register.birthday"
                      + ",member.profession "
                      + ",member.profession_id "
                      + ",member.race_id "
                      + ",member.race"
                      + ",member.mobile"
                      + ",member.homephone"
                      + ",member.homeaddress"
                      + ",member.hmstreetname"
                      + ",member.hmhouseNumber"
                      + ",member.idcard"
                      + ",member.profession_id"
                      + ",member.id as memberid"
                      + ",register.id as registerid"
                      + ",bas_patienttype.name as patienttype"
                      + ",register.bas_patienttype_id as patienttypeid"
                      + ",register.id as registerid"
                      + ",sys_region.mergername"                      
                      + " from register "                      
                      + " left join bas_depart on register.depart_id=bas_depart.id "
                      + " left join bas_doctor on register.doctor_id=bas_doctor.id "
                      + " left join bas_doctor as chargeby on register.users_id=chargeby.id "
                      + " left join member on register.member_id=member.id "
                      + " left join sys_region on sys_region.id=member.hmstreetname"
                      + " left join sys_dict as sexList on register.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                      + " left join bas_patienttype on register.bas_patienttype_id=bas_patienttype.id "
                      + " where 1=1 "
                      + (!string.IsNullOrEmpty(id) ? (" and register.id = " + DataTool.addFieldBraces(id)) : "")
                      ;
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
        /// 查询ihsp_info的省id 市id 与县id 还有地址
        /// </summary>
        /// <returns></returns>
        public DataTable ihspIdSearch(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select hmprovince"
                      + ",hmcity"
                      + ",hmcounty"
                      + ",homeaddress"
                      + " from ihsp_info"
                      + " where 1=1 "
                      + (!string.IsNullOrEmpty(id) ? (" and ihsp_info.ihsp_id = " + DataTool.addFieldBraces(id)) : "")
                      ;
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
        /// 查找发票号
        /// </summary>
        /// <param name="regist_id"></param>
        /// <returns></returns>
        public DataTable invoice(string regist_id)
        {
            DataTable dt=new DataTable();
            string sql = "select id"
                        +",billcode"
                        +" from clinic_invoice"
                        +" where id="
                        + "(select distinct clinic_costdet.clinic_invoice_id"
                        + " from clinic_costdet"
                        + " where clinic_cost_id in("
                        + " select id "
                        + " from clinic_cost"
                        + " where regist_id=" + DataTool.addIntBraces(regist_id)
                        + " and rcptype='REG'))";               
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
        /// 更新发票号
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public int upSetInvoice(string invoice_id, string invoice)
        {
            string sql = "update clinic_invoice"
                            + " set invoice =" + DataTool.addFieldBraces(invoice)
                            + " where id=" + DataTool.addIntBraces(invoice_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 更新发票号
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public int upNewInvoice(string invoice_id,string invoicecode,string  nextinvoicesql)
        {
            string sql = "update clinic_invoice"
                            + " set invoice =" + DataTool.addFieldBraces(invoicecode)
                            + " where id=" + DataTool.addIntBraces(invoice_id)
                            +";";
            sql += nextinvoicesql;

            return BllMain.Db.Update(sql);
          
        }
        /// <summary>
        /// 获取医保类型关键字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getInsurtype(string id)
        {
            string sql = "select cost_insurtype.keyname as keyname "
                              + " from bas_patienttype "
                              + " left join cost_insurtype on cost_insurtype.id=bas_patienttype.cost_insurtype_id"
                              + " where bas_patienttype.id= " + DataTool.addFieldBraces(id);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string keyname = datatable.Rows[0]["keyname"].ToString();
                return keyname;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 费用明细表查询
        /// </summary>
        /// <param name="clinicCostdet"></param>
        /// <returns></returns>
        public DataTable costSearch(string regist_id)
        {
            DataTable dt = new DataTable();
            string sql = "select *"
                      + " from clinic_costdet "
                      + " where regist_id=" + DataTool.addFieldBraces(regist_id);
                      ;
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
        /// 插入收费明细表 
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string inCostdet(ClinicCostdet clinicCostdet)
        {
            string sql = "insert into clinic_costdet(id"
                                               + ",clinic_cost_id"
                                               + ",clinic_Invoice_id"
                                               + ",regist_id"
                                               + ",standcode"
                                               + ",item_id"
                                               + ",itemfrom"
                                               + ",clinic_rcpdetail_id"
                                               + ",depart_id"
                                               + ",doctor_id"
                                               + ",exedep_id"
                                               + ",exedoctor_id"
                                               + ",drug_packsole_id"
                                               + ",name"
                                               + ",spec"
                                               + ",unit"
                                               + ",num"
                                               + ",prc"
                                               + ",fee"
                                               + ",realfee"
                                               + ",itemtype_id"
                                               + ",itemtype1_id"
                                               + ",charged"
                                               + ",chargedate"
                                               + ",chargeby"
                                               + ",clinic_costdet_id)values(" + DataTool.addFieldBraces(clinicCostdet.Id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Clinic_cost_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Clinic_Invoice_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Regist_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Standcode)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Item_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Itemfrom)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Clinic_rcpdetail_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Depart_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Doctor_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Exedep_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Exedoctor_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Drug_packsole_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Name)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Spec)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Unit)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Num)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Prc)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Fee)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Realfee)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Itemtype_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Itemtype1_id)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Charged)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Chargedate)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Chargeby)
                                                                    + "," + DataTool.addFieldBraces(clinicCostdet.Retcost_id)
                                                                    +");";
            sql += "update clinic_costdet set charged='RET'"
                    + " where id=" + DataTool.addFieldBraces(clinicCostdet.Id)
                    + " and charged='CHAR'"+";";

            return sql;
        }

        /// <summary>
        /// 更新挂号记录表状态
        /// </summary>
        /// <returns></returns>
        public string upRegSta(string regid)
        {
            string sql = "update register set status='BACK'"
                              + " where id=" + DataTool.addIntBraces(regid) + ";";
            return sql;
        }

        /// <summary>
        /// 更新收费主表
        /// </summary>
        /// <returns></returns>
        public string upClinicCost(string id)
        {
            string sql = "update clinic_cost set ischarged='R'"
                                                 + " where rcptype='REG'" + " and regist_id=" + DataTool.addFieldBraces(id) + ";";
            return sql;
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="uosql"></param>
        /// <param name="insql"></param>
        /// <returns></returns>
        public int sql(string sql)
        {
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 获取主表id
        /// </summary>
        /// <returns></returns>
        public DataTable getClinicCostId(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select id from clinic_costdet where regist_id=" + DataTool.addFieldBraces(id);
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
        /// 修改会员表
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int upMember(Member member)
        {
            string sql = "update member set birthday=" + DataTool.addFieldBraces(member.Birthday)
                                      + ",profession =" + DataTool.addFieldBraces(member.Profession)
                                      + ",profession_id =" + DataTool.addFieldBraces(member.Profession_id)
                                      + ",mobile=" + DataTool.addFieldBraces(member.Mobile)
                                      + ",homephone=" + DataTool.addFieldBraces(member.Mobile)
                                      + ",homeaddress=" + DataTool.addFieldBraces(member.Homeaddress)
                                      + ",hmstreetname=" + DataTool.addFieldBraces(member.Hmstreetname)
                                      + ",hmhouseNumber=" + DataTool.addFieldBraces(member.HmhouseNumber)
                                      + ",idcard=" + DataTool.addFieldBraces(member.Idcard)
                                      + ",race_id=" + DataTool.addFieldBraces(member.Race_id)
                                      + ",race=" + DataTool.addFieldBraces(member.Race)
                                      + " where id=" + DataTool.addFieldBraces(member.Id);
            return BllMain.Db.Update(sql);

        }
        /// <summary>
        /// 修改ihsp_info表
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int upIhsp(IhspInfo ihsp_info)
        {
            string sql = "update ihsp_info set idcard=" + DataTool.addFieldBraces(ihsp_info.Idcard)
                                     // + ",mobile =" + DataTool.addFieldBraces(ihsp_info.Mobile)
                                      + ",homephone =" + DataTool.addFieldBraces(ihsp_info.Homephone)
                                      + ",profession =" + DataTool.addFieldBraces(ihsp_info.Profession)
                                      + ",profession_id =" + DataTool.addFieldBraces(ihsp_info.Profession_id)
                                      + ",homeaddress=" + DataTool.addFieldBraces(ihsp_info.Homeaddress)
                                      + ",hmprovince=" + DataTool.addFieldBraces(ihsp_info.Hmprovince)
                                      + ",hmcity=" + DataTool.addFieldBraces(ihsp_info.Hmcity)
                                      + ",hmcounty=" + DataTool.addFieldBraces(ihsp_info.Hmcounty)
                                      + ",hmhouseNumber=" + DataTool.addFieldBraces(ihsp_info.HmhouseNumber)
                                      + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_info.Ihsp_id);
            return BllMain.Db.Update(sql);

        }
        /// <summary>
        /// 修改挂号记录表
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int upRegister(Register register)
        {
            string sql = "update register set name=" + DataTool.addFieldBraces(register.Name)
                                      + ",sex =" + DataTool.addFieldBraces(register.Sex)
                                      + ",age=" + DataTool.addFieldBraces(register.Age)
                                      + ",ageunit=" + DataTool.addFieldBraces(register.Ageunit)
                                      + ",birthday=" + DataTool.addFieldBraces(register.Birthday)
                                      + " where billcode=" + DataTool.addFieldBraces(register.Billcode);
            return BllMain.Db.Update(sql);

        }

        /// <summary>
        /// 医生姓名下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable DoctorList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from bas_doctor where id in (select doctor_id from bas_doctor_doctype where doctype = 'DOCTOR')";            
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
        /// 科室名称下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable DepartList()
        {
            DataTable dt = new DataTable();
            string sql = " select id"
                       + ",name"
                       + " from bas_depart where id in (select depart_id from bas_depart_departtype where departtype_id in(select id from bas_departtype where typecode ='CLIC'))";
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
        /// 获取性别id
        /// </summary>
        /// <returns></returns>
        public string sexId(string name)
        {
            string sql = "select sn as id from sys_dict where name=" + DataTool.addFieldBraces(name);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string sex = datatable.Rows[0]["id"].ToString();
                return sex;
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 性别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable sexList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='bas_sex' order by ordersn";
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
        /// 职业下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable professionList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='member_profession' order by ordersn";
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
        ///根据id或者外键， 获取医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable doctorNameGet(String depart)
        {
            DataTable dt = new DataTable();
            string sql = "select "
               + " bas_doctor.id"
               + ",bas_doctor.name"
               + " from "
               + " bas_doctor "
               + " left join bas_doctor_depart on bas_doctor_depart.doctor_id=bas_doctor.id "
               + " where "
               + " bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='DOCTOR') "
               + " and bas_doctor_depart.depart_id=" + DataTool.addFieldBraces(depart);

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
        /// 获取科室id
        /// </summary>
        /// <returns></returns>
        public string departId(string name)
        {
            string sql = "select id from bas_depart where name=" + DataTool.addFieldBraces(name);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string dep = datatable.Rows[0]["id"].ToString();
                return dep;
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 获取医生id
        /// </summary>
        /// <returns></returns>
        public string doctorId(string name)
        {
            string sql = "select id from bas_doctor where name=" + DataTool.addFieldBraces(name);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string doc = datatable.Rows[0]["id"].ToString();
                return doc;
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 撤销时修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int updateDepart(Register register)
        {
            string sql = "update register set doctor_id=" + DataTool.addIntBraces(register.Doctor_id)
                                                            + ", depart_id=" + DataTool.addFieldBraces(register.Depart_id)
                                                            + " where billcode =" + DataTool.addFieldBraces(register.Billcode);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 根据门诊发票号查询费用明细
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getCostdet(string regist_id)
        {
            DataTable dt = new DataTable();
            string sql = "select clinic_costdet.name"
                        + ",clinic_costdet.spec"
                        + ",clinic_costdet.unit"
                        + ",clinic_costdet.num"
                        + ",clinic_costdet.prc"
                        + ",clinic_costdet.fee"
                        + " from clinic_costdet"
                        + " where clinic_cost_id in("
                        + " select id "
                        + " from clinic_cost"
                        + " where regist_id=" + DataTool.addIntBraces(regist_id)
                        + " and rcptype='REG')";                                                              
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
