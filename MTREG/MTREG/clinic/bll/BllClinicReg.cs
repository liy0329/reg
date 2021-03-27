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
using MTREG.common;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Windows.Forms;
using System.Threading;

namespace MTREG.clinic.bll
{
    class BllClinicReg
    {
        
        /// <summary>
        /// 获取挂号医生信息
        /// </summary>
        /// <returns></returns>
        ///

        public DataTable getDoctor(string doctor_id) 
        {
            DataTable dt = new DataTable();
            try
            {
            //String sql = "select"
            //            + " doctor.id as doctor_id"
            //            + ",doctor.depart_id as depart_id"
            //            + ",doctor.name as dctname"
            //            + ",depart.name as dptname"
            //            + ",dict.name dictname"
            //            + ",count(register.doctor_id) as num"
            //            + ",register.amount as amount"
            //            + ",doctor.keyword as time"
            //            + " from bas_doctor as doctor,bas_depart as depart,sys_dict as dict,register"
            //            + " where doctor.isstop='N' and register.depart_id=depart.id and dict.dicttype='reg_level' and dict.sn=doctor.reg_level_id and register.doctor_id=doctor.id group by register.doctor_id";
                String sql = "select "
                            + " doctor_id"
                            + ",depart_id"
                            + ",reg_level_id "
                            + ",reglevel "
                            + ",doctor"
                            + ",depart"
                            + ",clinicroom"
                            + ",regprc"
                            + ",diagnlen"
                            + ",waitnum"
                            + ",waitlen"
                            + " from bas_visit "
                            + " where doctor_id = " + DataTool.addFieldBraces(doctor_id);
                dt = BllMain.Db.Select(sql).Tables[0];
                String sql0 = "select consulroom from sys_config limit 1";
                string clinicRoom = BllMain.Db.Select(sql0).Tables[0].Rows[0][0].ToString();
                if (clinicRoom == "Y")
                { 
       
                }
                else if (clinicRoom == "N")
                { 
                    for(int i = 0;i<dt.Rows.Count;i++)
                    {
                        dt.Rows[i]["clinicroom"] = ""; 
                    }
                }
            }
            catch(Exception  e)
            { 

            }
            return dt;
        }
        public DataTable getRegisterInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                //String sql = "select"
                //            + " doctor.id as doctor_id"
                //            + ",doctor.depart_id as depart_id"
                //            + ",doctor.name as dctname"
                //            + ",depart.name as dptname"
                //            + ",dict.name dictname"
                //            + ",count(register.doctor_id) as num"
                //            + ",register.amount as amount"
                //            + ",doctor.keyword as time"
                //            + " from bas_doctor as doctor,bas_depart as depart,sys_dict as dict,register"
                //            + " where doctor.isstop='N' and register.depart_id=depart.id and dict.dicttype='reg_level' and dict.sn=doctor.reg_level_id and register.doctor_id=doctor.id group by register.doctor_id";
                String sql = "select "
                            + " doctor_id"
                            + ",depart_id"
                            + ",reg_level_id "
                            + ",reglevel "
                            + ",doctor"
                            + ",depart"
                            + ",clinicroom"
                            + ",regprc"
                            + ",diagnlen"
                            + ",waitnum"
                            + ",waitlen"
                            + " from bas_visit ";                           
                dt = BllMain.Db.Select(sql).Tables[0];
                String sql0 = "select consulroom from sys_config limit 1";
                string clinicRoom = BllMain.Db.Select(sql0).Tables[0].Rows[0][0].ToString();
                if (clinicRoom == "Y")
                {

                }
                else if (clinicRoom == "N")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["clinicroom"] = "";
                    }
                }
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDepartInfo(string name) 
        {
            DataTable dt=new DataTable();
            try
            {
                String sqlDepart = "select id,name from bas_depart where id in "
                    +"(select depart_id from bas_depart_departtype where departtype_id in(select id from bas_departtype where typecode in('CLIN','IHSP')))"
                    +" and isstop = 'N'"
                    + " and (pincode like " + DataTool.addFieldBraces("%" + name + "%") + " or name like " + DataTool.addFieldBraces("%" + name + "%") + ")"
                    + " order by bas_depart.ordersn ";

                dt = BllMain.Db.Select(sqlDepart).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 获取患者类型信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getPatientTypeInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select bas_patienttype.id"
                    + ",bas_patienttype.name "
                    + " from bas_patienttype "
                    + " where  isclinic='Y'";
                    
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 是否急诊
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getUrgent()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select sn as id ,name from sys_dict where father_id <> 0 and dicttype = 'sys_yesno' order by id desc ";
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
        public DataTable getDoctorByDepartId(String depart_id) 
        {
            DataTable dt = new DataTable();
            try
            {
              String sql ="  SELECT"
                                    + " 	bas_doctor.id,"
                                    + " 	bas_doctor. NAME"
                                    + " FROM"
                                    + " 	bas_doctor,"
                                    + " 	bas_doctor_depart,"
                                    + "     bas_doctor_doctype"
                                    + " WHERE"
                                    + " 	bas_doctor.id = bas_doctor_depart.doctor_id"
                                    + " AND  bas_doctor.id = bas_doctor_doctype.doctor_id"
                                    + " AND	 bas_doctor_doctype.doctype= 'DOCTOR'"
                                    + " AND  bas_doctor.isstop = 'N'"
                                    + " AND	 bas_doctor_depart.depart_id= " + DataTool.addFieldBraces(depart_id);
                    dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        ///根据姓名或者简拼， 获取医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getDoctorByDocname(String docname)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "  SELECT"
                                      + " 	bas_doctor.id,"
                                      + " 	bas_doctor. NAME"
                                      + " FROM"
                                      + " 	bas_doctor"
                                      + " WHERE"
                                      + " bas_doctor.isstop = 'N'"
                                      + " AND bas_doctor.id <> 1"
                                      + " AND ( bas_doctor.name LIKE '%" + docname + "%' OR bas_doctor.pincode LIKE '%" + docname + "%')";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
       
        /// <summary>
        /// 下拉框 民族
        /// </summary>
        /// <returns></returns>
        public DataTable getRaceInfo(string pincode)
        {
            DataTable dt = new DataTable();
            string sql = "select sys_dict.sn as id "
                       + ",sys_dict.name"
                       + ",sys_dict.pincode"
                       + " from sys_dict "
                       + " where father_id <>0 and dicttype = 'member_race'"
                       + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or name like " + DataTool.addFieldBraces("%" + pincode + "%") + ")"
                       + " order by id limit 50";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 行政区域下拉选择
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable regionList(string pincode)
        {
            string sql = "select id,mergername "
                            + " from sys_region"
                            + " where father_id<>0"
                            + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or mergername like " + DataTool.addFieldBraces("%" + pincode + "%") + ")"
                            + " order by ordersn limit 50;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 省
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable provinceList(string pincode)
        {
            if (string.IsNullOrEmpty(pincode) || pincode == "")
            {
                string sql = "select id,name "
                          + " from sys_region"
                          + " where father_id<>0"
                          + " and level in(1)"                     
                          + " order by ordersn limit 40";
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                return dt;
            }
            else
            {
                string sql = "select id,name "
                          + " from sys_region"
                          + " where father_id<>0"
                          + " and level in(1)"
                          + " and mergername like " + DataTool.addFieldBraces("%" + pincode + "%")
                          + " order by ordersn limit 40";
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                return dt;
            }
          
        }
        /// <summary>
        /// 市
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable cityList(string pincode)
        {
            string sql = "select id,name "
                            + " from sys_region"
                            + " where father_id<>0"
                            + " and level in(2)"
                            + " and mergername like " + DataTool.addFieldBraces("%" + pincode + "%")
                            + " order by ordersn limit 40";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
      
        /// <summary>
        /// 市_2
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable cityListB(string supercode)
        {
            string sql = "select id,name "
                            + " from sys_region"
                          //  + " where father_id<>0"
                          //  + " and level in(2)"
                            + " where id like " + DataTool.addFieldBraces(supercode.Substring(0,2) + "__00")
                            + " and id <>"+DataTool.addFieldBraces(supercode)
                            + " order by ordersn ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 县
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable countyList(string pincode)
        {
            string sql = "select id,name "
                            + " from sys_region"
                            + " where father_id<>0"
                            + " and level in(3)"
                            + " and mergername like " + DataTool.addFieldBraces("%" + pincode + "%")
                            + " order by ordersn limit 40";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 县_2
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable countyListB(string supercode)
        {
            string sql = "select id,name "
                            + " from sys_region"
                //+ " where father_id<>0"
                // + " and level in(3)"
                            + " where id like " + DataTool.addFieldBraces(supercode.Substring(0, 4) + "__")
                            + " and id <>"+DataTool.addFieldBraces(supercode)
                            + " order by ordersn ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 职业类别
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable professionList(string pincode)
        {
            string sql = "select sn as id,name"
                            + " from sys_dict"
                            + " where dicttype='member_profession'"
                            + " and father_id<>0"
                            + " and isstop = 'N'"
                            + " order by ordersn limit 50;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 年龄单位下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ageunitList()
        {
            string sql = "select sn as id,name from sys_dict where dicttype='bas_ageunit' and father_id<>0 order by ordersn";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 性别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable sexList()
        {
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='bas_sex' order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        ///获取挂号费和诊查费
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getPrcByDoctor(String param) 
        {
            DataTable dt = new DataTable();
            String sql = "";
            if (param == "")
            {
                sql = "select "
                          + " bas_item.name "
                          + ",cost_reglevel.item_id"
                          + ",bas_item.itemfrom"
                          + ",bas_item.standcode"
                          + ",bas_item.spec"
                          + ",bas_item.unit"
                          + ",bas_item.itemtype_id"
                          +",cost_itemtype.keyname"
                          + ",bas_item.itemtype1_id";
                if (ProgramGlobal.CostClass.Equals(BasCostClass.CITY.ToString()))
                    sql += ",bas_item.city_prc as prc";
                else if (ProgramGlobal.CostClass.Equals(BasCostClass.COUNTY.ToString()))
                    sql += ",bas_item.county_prc as prc";
                else if (ProgramGlobal.CostClass.Equals(BasCostClass.PROV.ToString()))
                    sql += ",bas_item.prov_prc as prc";
                sql += " from cost_reglevel left join bas_doctor on cost_reglevel.reg_level_id=bas_doctor.reg_level_id "
                           + " left join bas_item on cost_reglevel.item_id=bas_item.id "
                            + " left join cost_itemtype on cost_itemtype.id=bas_item.itemtype_id "
                           + " where 1!=1;";
            }
            else
            {
                sql = "select "
                          + " bas_item.name "
                          + ",cost_reglevel.item_id"
                          + ",bas_item.itemfrom"
                          + ",bas_item.standcode"
                          + ",bas_item.spec"
                          + ",bas_item.unit"
                          + ",bas_item.itemtype_id"
                          + ",cost_itemtype.keyname"
                          + ",bas_item.itemtype1_id";
                if (ProgramGlobal.CostClass.Equals(BasCostClass.CITY.ToString()))
                    sql += ",bas_item.city_prc as prc";
                else if (ProgramGlobal.CostClass.Equals(BasCostClass.COUNTY.ToString()))
                    sql += ",bas_item.county_prc as prc";
                else if (ProgramGlobal.CostClass.Equals(BasCostClass.PROV.ToString()))
                    sql += ",bas_item.prov_prc as prc";
                sql += " from cost_reglevel left join bas_doctor on cost_reglevel.reg_level_id=bas_doctor.reg_level_id "
                           + " left join bas_item on cost_reglevel.item_id=bas_item.id "
                           + " left join cost_itemtype on cost_itemtype.id=bas_item.itemtype_id "
                           + " where bas_doctor.id='" + DataTool.stringToInt(param) + "'";
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

        public DataTable getCurrClinicRoom(string doctor_id)
        {
            string sql = "SELECT acc_account.clinic_room_id as clinicroom_id,clinic_room.name  as clinicroom from acc_account LEFT JOIN clinic_room on clinic_room.id = acc_account.clinic_room_id where acc_account.doctor_id = " + DataTool.addFieldBraces(doctor_id) + ";";
            DataTable dt = null;
            try

            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception)
            {
                
            }
            return dt;
        }
        /// <summary>
        ///获取当前医生的挂号等级
        /// </summary>
        /// <returns></returns>
        ///

        public DataTable getRegLevelByDoctor( String param) 
        {
            DataTable dt = new DataTable();
            String sql = "select  reg_level_id from bas_doctor where id=" + param;
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
        ///获取用户挂号信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable getRegisterById(String  today) 
        {
            
            DataTable dt = new DataTable();
            String sql = "select register.id "
                       + ",case when register.status = 'BACK' then '已退号' when register.status = 'REG' then '挂号' end as status"
                       + ",register.regdate "
                       + ",register.name "
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_patienttype.name as patienttype"
                       + ",register.amount "
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",''as username"
                       + ",register.hspcard"
                       + "  from register  "
                       + " Left join bas_patienttype "
                       + " on register.bas_patienttype_id = bas_patienttype.id"
                       + " left join bas_depart on bas_depart.id = register.depart_id"
                       + " left join bas_doctor on register.doctor_id = bas_doctor.id"
                       + " where register.regdate>= " + DataTool.addFieldBraces(today)
                       //+ " and register.prepaid<>'N'"
                       + " and register.status in ('REG','BACK')"
                       + " order by register.regdate desc";
           
                try
                {
                    dt = BllMain.Db.Select(sql).Tables[0];
                }
                catch (Exception e)
                {

                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["username"] = ProgramGlobal.Username;
                }
            return dt;
        }
        public int ExeSql(string merge_sql)
        {
            return BllMain.Db.Update(merge_sql);
        }
        /// <summary>
        ///插入一条挂号记录
        /// </summary>
        /// <returns></returns>
        ///
        public string addRegisterItem(Register register,string member_id) 
        {                  
               
            String billcode=register.Billcode;
            String clininicpay = register.clininicpay;
            String regdate=register.Regdate;
            String reg_level_id=register.Reg_level_id;
            String bas_patienttype_id=register.Bas_patienttype_id;
            String healthcard=register.Healthcard;
            String sys_region_id=register.Sys_region_id;
            String reg_regclass_id=register.Reg_regclass_id;
            String urgent=register.Urgent;
            String doctor_id=register.Doctor_id;
            String depart_id=register.Depart_id;
            String users_id=register.Users_id;
            String amount=register.Amount;
            String status=register.Status;
            String isarchive=register.Isarchive;
            String hspcard=register.Hspcard;
            String name=register.Name;
            String pincode=register.Pincode;
            String sex=register.Sex;
            String birthday = register.Birthday;//出生日期
            String age=register.Age;
            String ageunit=register.Ageunit;
            String createtime=register.Createtime;
            String updatetime=register.Updatetime;
            String Insuritemtype = register.Insuritemtype;//如果为医保就搞成3
            String sql = "insert into register ( "
                        + "id"
                        + ", billcode"
                        + ", regdate"
                        + ", clininicpay"
                        + ", reg_level_id"
                        + ", bas_patienttype_id"
                        + ", healthcard"
                        + ", sys_region_id"
                        + ", reg_regclass_id"
                        + ", urgent"
                        + ", doctor_id"
                        + ", depart_id"
                        + ", users_id"
                        + ", amount"
                        + ", status"
                        + ", isarchive"
                        + ", member_id"
                        + ", hspcard"
                        + ", name"
                        + ", pincode"
                        + ", sex"
                        + ", birthday"
                        + ", age"
                        + ", ageunit"
                        + ", moonage"
                        + ", moonageunit"
                        + ", createtime"
                        + ", reservedate"
                        + ", insuritemtype"
                        + ", clinicroom"
                        + ", regnum"
                        + ", insurcode"
                        + ", updatetime) values("
                        + DataTool.addFieldBraces(register.Id)
                        + "," + DataTool.addFieldBraces(billcode)
                        + "," + DataTool.addFieldBraces(regdate)
                        + "," + DataTool.addFieldBraces(clininicpay)
                        + "," + DataTool.addFieldBraces(reg_level_id)
                        + "," + DataTool.addFieldBraces(bas_patienttype_id)
                        + "," + DataTool.addFieldBraces(healthcard)
                        + "," + DataTool.addFieldBraces(sys_region_id)
                        + "," + DataTool.addFieldBraces(reg_regclass_id)
                        + "," + DataTool.addFieldBraces(urgent)
                        + "," + DataTool.addFieldBraces(doctor_id)
                        + "," + DataTool.addFieldBraces(depart_id)
                        + "," + DataTool.addFieldBraces(users_id)
                        + "," + DataTool.addFieldBraces(amount)
                        + "," + DataTool.addFieldBraces(status)
                        + "," + DataTool.addFieldBraces(isarchive)
                        + "," + DataTool.addFieldBraces(member_id)
                        + "," + DataTool.addFieldBraces(hspcard)
                        + "," + DataTool.addFieldBraces(name)
                        + "," + DataTool.addFieldBraces(pincode)
                        + "," + DataTool.addFieldBraces(sex)
                        + "," + DataTool.addFieldBraces(birthday)
                        + "," + DataTool.addFieldBraces(age)
                        + "," + DataTool.addFieldBraces(ageunit)
                        + "," + DataTool.addFieldBraces(register.Moonage)
                        + "," + DataTool.addFieldBraces(register.Moonageunit)
                        + "," + DataTool.addFieldBraces(createtime)
                        + "," + DataTool.addFieldBraces(regdate)
                        + "," + DataTool.addFieldBraces(Insuritemtype)
                        + "," + DataTool.addFieldBraces(register.Clinicroom)
                        + "," + DataTool.addFieldBraces(register.Regnum)
                        + "," + DataTool.addFieldBraces(register.Insurcode)
                        + "," + DataTool.addFieldBraces(updatetime)
                        + " );";
            return sql; 
        }
        public string addIhspInfoItem(IhspInfo ihspInfo)
        {
            string sql = "insert into ihsp_info("
                                    + "id"
                                    + ",ihsp_id"
                                    + ",registkind"
                                    + ",idcard"
                                    + ",profession"
                                    + ",profession_id"
                                    + ",hmstreetname"
                                    + ",hmhouseNumber"//门牌号
                                    + ",resihouseNumber"//户籍门牌号
                                    + ",houseNumber"//出生地门牌号
                                    + ",homephone"
                                    + ",race_id"
                                    + ",race"
                                    + ",companyname"
                                    + ",mobile"
                                    + ",homeaddress"//现地址
                                    + ",hmprovince"
                                    + ",hmcity"
                                    + ",hmcounty"
                                    + ",residenceaddress"//户籍地址
                                    + ",resiprovice"
                                    + ",resicity"
                                    + ",resicounty"
                                    + ",birthplace"//出生地
                                    + ",provice_id"
                                    + ",city_id"
                                    + ",county_id"                                  
                                    + " ) values ("
                                    + DataTool.addFieldBraces(ihspInfo.Id)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Ihsp_id)
                                    + "," + DataTool.addFieldBraces("CLIN")
                                    + "," + DataTool.addFieldBraces(ihspInfo.Idcard)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Profession)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Profession_id)                                    
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmstreetname)
                                    + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                                    + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                                    + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homephone)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Race_id)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Race)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Companyname)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Mobile)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmprovince)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcity)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcounty)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmprovince)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcity)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcounty)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmprovince)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcity)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmcounty)
                                    +" );";
           return sql;
            
        }
        //获取人员信息：
        public DataTable getMemberInfo(string hspcard)
        {
            DataTable dt = new DataTable();
            String sql = "select member.id "
                       + ",member.race_id"
                       + ",member.race"
                       + ",member.name"
                       + ",member.sex"
                       + ",member.birthday"
                       + ",member.homeaddress"
                       + ",sys_region.mergername"
                       + ",member.hmstreetname"
                       + ",member.hmhousenumber"
                       + ",member.mobile"
                       + ",member.profession"
                       + ",member.profession_id"
                       + ",member.companyname"
                       + ",member.idcard"
                       + ",member_balance.balance"
                       + ",member.provice_id"
                       + ",member.city_id"
                       + ",member.county_id"
                       + " from member "
                       + " left join sys_region on sys_region.id=member.hmstreetname"
                       + " left join member_balance on member_balance.bas_member_id=member.id"
                       + " where member.usehspcard = 'Y' and member.hspcard = " + DataTool.addFieldBraces(hspcard);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public string doMemberItem(Member member, ref string member_id)
        {
            string sql = "";
            DataTable dt = getMemberInfo(member.Hspcard);
           if(dt.Rows.Count==1)
           {
               member_id = dt.Rows[0]["id"].ToString();

               sql = "update member"
                      + " set "
                       + " name=" + DataTool.addFieldBraces(member.Name)
                       + ", pincode=" + DataTool.addFieldBraces(member.Pincode)
                       + ", sex=" + DataTool.addFieldBraces(member.Sex)
                       + ", birthday=" + DataTool.addFieldBraces(member.Birthday)
                       + ", hspcard=" + DataTool.addFieldBraces(member.Hspcard)
                       + ", usehspcard=" + DataTool.addFieldBraces("Y")
                       + ", race=" + DataTool.addFieldBraces(member.Race)
                       + ", race_id=" + DataTool.addFieldBraces(member.Race_id)
                       + ", homeaddress=" + DataTool.addFieldBraces(member.Homeaddress)
                       + ", hmstreetname=" + DataTool.addFieldBraces(member.Hmstreetname)
                       + ", idcard=" + DataTool.addFieldBraces(member.Idcard)
                       + ", profession=" + DataTool.addFieldBraces(member.Profession)
                       + ", profession_id=" + DataTool.addFieldBraces(member.Profession_id)
                       + ", mobile=" + DataTool.addFieldBraces(member.Mobile)
                       + ", homephone=" + DataTool.addFieldBraces(member.Mobile)
                       + ", companyname=" + DataTool.addFieldBraces(member.Companyname)
                       + ", cardstat=" + DataTool.addFieldBraces("YES")
                       + ", createdate=" + DataTool.addFieldBraces(member.Createdate)
                       + ", hmhousenumber=" + DataTool.addFieldBraces(member.HmhouseNumber)
                       + ", provice_id=" + DataTool.addFieldBraces(member.Provice_id)
                       + ", city_id=" + DataTool.addFieldBraces(member.City_id)
                       + ", county_id=" + DataTool.addFieldBraces(member.County_id)
                       + ", createdby=" + DataTool.addFieldBraces(member.Createdby)
                       + " where id = " + DataTool.addFieldBraces(member_id)
                       + ";";
                   return sql;
            }
            member_id = BillSysBase.nextId("member");
            sql = "insert into member ( "
                               + "id"
                               + ", name"
                               + ", pincode"
                               + ", sex"
                               + ", birthday"
                               + ", hspcard"
                               + ", usehspcard"
                               + ", race"
                               + ", race_id"
                               + ", homeaddress"                     //地址
                               + ", hmstreetname"
                               + ", idcard"
                               + ", profession"
                               + ", profession_id"
                               + ", mobile"
                               + ", homephone"
                               + ", companyname"
                               + ", cardstat"
                               + ", createdate"
                               + ", hmhousenumber"
                               + ", provice_id"
                               + ", city_id"
                               + ", county_id"
                               + ", createdby) values("
                               + DataTool.addFieldBraces(member_id)
                               + "," + DataTool.addFieldBraces(member.Name)
                               + "," + DataTool.addFieldBraces(member.Pincode)
                               + "," + DataTool.addFieldBraces(member.Sex)
                               + "," + DataTool.addFieldBraces(member.Birthday)
                               + "," + DataTool.addFieldBraces(member.Hspcard)
                               + "," + DataTool.addFieldBraces("Y")
                               + "," + DataTool.addFieldBraces(member.Race)
                               + "," + DataTool.addFieldBraces(member.Race_id)
                               + "," + DataTool.addFieldBraces(member.Homeaddress)            //地址
                               + "," + DataTool.addFieldBraces(member.Hmstreetname)
                               + "," + DataTool.addFieldBraces(member.Idcard)
                               + "," + DataTool.addFieldBraces(member.Profession)
                               + "," + DataTool.addFieldBraces(member.Profession_id)
                               + "," + DataTool.addFieldBraces(member.Mobile)
                               + "," + DataTool.addFieldBraces(member.Mobile)
                               + "," + DataTool.addFieldBraces(member.Companyname)
                               + "," + DataTool.addFieldBraces("YES")
                               + "," + DataTool.addFieldBraces(member.Createdate)
                               + "," + DataTool.addFieldBraces(member.HmhouseNumber)
                               + "," + DataTool.addFieldBraces(member.Provice_id)
                               + "," + DataTool.addFieldBraces(member.City_id)
                               + "," + DataTool.addFieldBraces(member.County_id)
                               + "," + DataTool.addFieldBraces(member.Createdby)
                               + " );";
           return sql;           
        }

        public int addClinicCost(ClinicCost clinicCost, ref string merge_sql)
        {            
            string sql = "insert into clinic_cost ( "
                       + "id"
                       + ",regist_id"
                       + ",clinicInvoice"
                       + ",billcode"
                       + ",rcptype"
                       + ",clinic_rcp_id"
                       + ",executed"
                       + ",depart_id"
                       + ",doctor_id"
                       + ",rcpdate"
                       + ",recipelfee"
                       + ",realfee"
                       + ",unlocked"
                       + ",retappstat ) values ("
                       + DataTool.addFieldBraces(clinicCost.Id)
                       + "," + DataTool.addFieldBraces(clinicCost.Regist_id)
                       + "," + DataTool.addFieldBraces(clinicCost.ClinicInvoice)
                       + "," + DataTool.addFieldBraces(clinicCost.Billcode)
                       + "," + DataTool.addFieldBraces(clinicCost.Rcptype )
                       + "," + DataTool.addFieldBraces(clinicCost.Clinic_rcp_id)
                       + "," + DataTool.addFieldBraces(clinicCost.Executed)
                       + "," + DataTool.addFieldBraces(clinicCost.Depart_id)
                       + "," + DataTool.addFieldBraces(clinicCost.Doctor_id)
                       + "," + DataTool.addFieldBraces(clinicCost.Rcpdate)
                       + "," + DataTool.addFieldBraces(clinicCost.Recipelfee)
                       + "," + DataTool.addFieldBraces(clinicCost.Realfee)
                       + "," + DataTool.addFieldBraces(clinicCost.Unlocked)
                       + "," + DataTool.addFieldBraces(clinicCost.Retappstat)
                       + ");";
             merge_sql += sql;
                  
            return 0;
        }
        public int addClinicCostDet(CliniCostdet cliniCostdet,ref string clinic_costdet_ids,ref string merge_sql)
        {
            string sql = "insert into clinic_costdet ( "
                           + " id"                      //主键
                           +",bas_patienttype_id"
                           + ",clinic_cost_id"          //收费主表外键
                           + ",regist_id"               //挂号编号外键
                           + ",standcode"               //统一编码
                           + ",item_id"                 //外键项目  隐式外键
                           + ",itemfrom"                //项目定义类型
                           + ",clinic_rcpdetail_id"     //处方明细
                           + ",depart_id"               // 处方科室
                           + ",doctor_id"               // 处方医生
                           + ",exedep_id"               //执行科室
                           + ",executed"
                           + ",name"                    //项目名称
                           + ",spec"                    //规格  单位 数量 单价
                           + ",packsole"                //大包装销售
                           + ",drug_packsole_id"        //大包装定义
                           + ",unit"
                           + ",num"
                           + ",prc"
                           + ",fee"                //金额 打折 实收金额
                           + ",discnt"
                           + ",realfee"
                           + ",itemtype_id"     //费用类别
                           + ",itemtype1_id"     //核算类别
                           + ",unlocked"       //N
                           + ",retappstat"      //N
                           + ",rcptype"      //N
                           + ",charged"
                           + ",chargedate"
                           + " ) values ("
                           + DataTool.addFieldBraces(cliniCostdet.Id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Bas_patienttype_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Clinic_cost_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Regist_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Standcode)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Item_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Itemfrom)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Clinic_rcpdetail_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Depart_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Doctor_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Exedep_id)
                           + "," + DataTool.addFieldBraces("N")
                           + "," + DataTool.addFieldBraces(cliniCostdet.Name)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Spec)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Packsole)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Drug_packsole_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Unit)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Num)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Prc)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Fee)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Discnt)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Realfee)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Itemtype_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Itemtype1_id)
                           + "," + DataTool.addFieldBraces("N")
                           + "," + DataTool.addFieldBraces("N")
                           + "," + DataTool.addFieldBraces(cliniCostdet.Rcptype)
                           + "," + DataTool.addFieldBraces("OO")
                           + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                           + " ) ; ";
            clinic_costdet_ids += cliniCostdet.Id + ",";
            merge_sql += sql;
            return 0;
        }
 
        /// <summary>
        /// 挂号类型
        /// </summary>
        /// <returns></returns>
        public string getRegclass()
        {
            DataTable dt = new DataTable();
            String sql = "select sn from sys_dict where father_id <> 0 and dicttype = 'reg_regclass' and keyname = " + DataTool.addFieldBraces(RegClass.WIN.ToString());
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0][0].ToString();
        }

        public string getUrgent(string sn)
        {
            DataTable dt = new DataTable();
            String sql = "select keyname from sys_dict where father_id <> 0 and dicttype = 'sys_yesno' and sn = " + DataTool.addFieldBraces(sn);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0][0].ToString();
        }
        
        public bool hasMember(string hspcard)
        {
            DataTable dt = new DataTable();
            string sql = "select count(id) from member where hspcard = " + DataTool.addFieldBraces(hspcard);
            dt = BllMain.Db.Select(sql).Tables[0];
            if( dt.Rows[0][0].ToString().Equals("0"))
               return false;
            return true;
        }

        public string getInvoiceKind(string patienttype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select sys_clinicinvoicekind_id from bas_patienttype where id = " + DataTool.addFieldBraces(patienttype_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0][0].ToString();

        }
        /// <summary>
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select bas_paytype_id as id, name from bas_paysumby where isinsur='0' order by ordersn desc;";
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
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypexj()
        {
            DataTable dt = new DataTable();
            string sql = "select bas_paytype_id as id from bas_paysumby where isinsur='0' and name like '%现金%' order by ordersn desc;";
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
        /// 获取支付类型ID
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaytypeId(string keyname)
        {
            string sql = "select sn from sys_dict where dicttype='bas_paytype' and father_id<>0 and keyname="+DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["sn"].ToString();
        }
        /// <summary>
        /// 获取支付汇总Id
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaysumby(string keyname)
        {
            string sql = "select id from bas_paysumby where keyname="+DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["id"].ToString();
        }
        /// <summary>
        /// 获取PaysumbyId
        /// </summary>
        /// <param name="paytypeId"></param>
        /// <returns></returns>
        public string getPaysumbyFor(string paytypeId)
        {
            string sql = " SELECT id from bas_paysumby WHERE bas_paysumby.bas_paytype_id =" + DataTool.addFieldBraces(paytypeId);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["id"].ToString();
            return ret;
        }
        public void transportInfo(string json)
        {
            IConnectionFactory factory;
            factory = new ConnectionFactory("tcp://192.168.0.36:61616");
            try
            {
                //通过工厂建立连接
                using (IConnection connection = factory.CreateConnection())
                {
                    //通过连接创建Session会话
                    using (ISession session = connection.CreateSession())
                    {
                        //通过会话创建生产者，方法里面new出来的是MQ中的Queue
                        IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"));
                        //创建一个发送的消息对象
                        ITextMessage message = prod.CreateTextMessage();
                        //给这个对象赋实际的消息
                        string mes = json;
                        message.Properties.SetString("message", mes);
                        //设置消息对象的属性，这个很重要哦，是Queue的过滤条件，也是P2P消息的唯一指定属性

                        //message.Properties.SetString("filter", "demo");
                        //message.Properties.SetString("cmd","INCALL");
                        //message.Properties.SetString("calladdr", "192.168.1.140");
                        //message.Properties.SetString("keyid", inCall.Register_id);
                        //message.Properties.SetString("depart_id", inCall.Depart_id);
                        //message.Properties.SetString("clinicroom_id", inCall.Clinicroom_id);
                        //message.Properties.SetString("doctor", inCall.Doctor);
                        //message.Properties.SetString("sickname", inCall.Sickname);
                        //message.Properties.SetString("depart", inCall.Depart);
                        //message.Properties.SetString("clinicroom", inCall.Clinicroom);
                        //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否长链，MsgPriority消息优先级别，发送最小单位，当然还有其他重载
                        prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    }
                }
            }
            catch
            {
                //MessageBox.Show("门诊叫号传输数据失败!");
                return;
            }
            //MessageBox.Show("门诊叫号传输成功!");
        }

       
        /// <summary>
        /// 获取挂号费类别
        /// </summary>
        /// <returns></returns>
        public DataTable getReg()
        {
            string sql = "select bas_item.id"
               + ",bas_item.name"
               + " from bas_item"
               + " left join cost_itemtype on cost_itemtype.id=bas_item.itemtype_id"
               + " where cost_itemtype.keyname='REG'"
               +" and bas_item.isstop='N'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获取诊察费类别
        /// </summary>
        /// <returns></returns>
        public DataTable getDagn()
        {
            string sql = "select bas_item.id"
                + ",bas_item.name"
                + " from bas_item"
                + " left join cost_itemtype on cost_itemtype.id=bas_item.itemtype_id"
                + " where cost_itemtype.keyname='DIGN'"
                + " and bas_item.isstop='N'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据费用类别获取信息
        /// </summary>
        /// <returns></returns>
        public DataTable getItemInfo(string item_id)
        {
            string sql = "select "
                    + " bas_item.name "
                    + ",bas_item.id as item_id"
                    + ",bas_item.itemfrom"
                    + ",bas_item.standcode"
                    + ",bas_item.spec"
                    + ",bas_item.unit"
                    + ",bas_item.itemtype_id"
                    + ",cost_itemtype.keyname"
                    + ",bas_item.itemtype1_id";
            if (ProgramGlobal.CostClass.Equals(BasCostClass.CITY.ToString()))
                sql += ",bas_item.city_prc as prc";
            else if (ProgramGlobal.CostClass.Equals(BasCostClass.COUNTY.ToString()))
                sql += ",bas_item.county_prc as prc";
            else if (ProgramGlobal.CostClass.Equals(BasCostClass.PROV.ToString()))
                sql += ",bas_item.prov_prc as prc";
            sql += " from bas_item "
                        + " left join cost_itemtype on cost_itemtype.id=bas_item.itemtype_id "
                       + " where bas_item.id=" + item_id;
            return BllMain.Db.Select(sql).Tables[0];
        }
        public void sendInCallUpdateSys_calling(InCall inCall)
        {
          
            string calladdr = inCall.Calladdr;
            string keyid = inCall.Register_id;
            string clinicroom_id = inCall.Clinicroom_id;
            string depart = inCall.Depart;
            string doctor = inCall.Doctor;
            string clinicroom = inCall.Clinicroom;
            string depart_id = inCall.Depart_id;
            string sickname = inCall.Sickname;
            string apptime = BillSysBase.currDate();
            int max = getMaxSeqNum(inCall.Depart_id);
            string seqnum= inCall.Seqnum = (max + 1).ToString();
            
            string sql = "insert into sys_calling ( "
                           + " calladdr"
                           + ",keyid"
                           + ",clinicroom_id"
                           + ",depart"
                           + ",doctor"
                           + ",clinicroom"
                           + ",regist_id"
                           + ",sickname"
                           + ",seqnum"
                           + ",apptime"
                           + ",called ) values ( "
                           + DataTool.addFieldBraces(calladdr)
                           + "," + DataTool.addFieldBraces(keyid)
                           + "," + DataTool.addFieldBraces(clinicroom_id)
                           + "," + DataTool.addFieldBraces(depart)
                           + "," + DataTool.addFieldBraces(doctor)
                           + "," + DataTool.addFieldBraces(clinicroom)
                           + "," + DataTool.addFieldBraces(depart_id)
                           + "," + DataTool.addFieldBraces(sickname)
                           + "," + DataTool.addFieldBraces(seqnum)
                           + "," + DataTool.addFieldBraces(apptime)
                           + "," + DataTool.addFieldBraces("N")
                           + ");";
            BllMain.Db.Update(sql);

            //异步调用发送消息
            Thread ResultT = new Thread(new ParameterizedThreadStart(SendMessage));
            ResultT.IsBackground = true;

            if (ResultT.ThreadState != ThreadState.Running)
            {
                ResultT.Start(inCall);
            }
           

        }

        private void SendMessage(object source )
        {
            InCall inCall = (InCall)source;
            IConnectionFactory factory;
            factory = new ConnectionFactory(inCall.Callserverurl);
            try
            {
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"));
                        ITextMessage message = prod.CreateTextMessage();
                        string mes = jsonStr(inCall);
                        message.Properties.SetString("message", mes);
                        prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);

                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 叫号Json字符串
        /// </summary>
        /// <param name="inCall"></param>
        /// <returns></returns>
        private string jsonStr(InCall inCall)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("'cmd':" + "'INCALL',");
            json.Append("'calladdr':" + inCall.Calladdr + ",");
            json.Append("'keyid':" + "'" + inCall.Register_id + "',");
            json.Append("'depart_id':" + "'" + inCall.Depart_id + "',");
            json.Append("'clinicroom_id':" + "'" + inCall.Clinicroom_id + "',");
            json.Append("'doctor':" + "'" + inCall.Doctor + "',");
            json.Append("'sickname':" + "'" + inCall.Sickname + "',");
            json.Append("'depart':" + "'" + inCall.Depart + "',");
            json.Append("'clinicroom':" + "'" + inCall.Clinicroom + "'");
            json.Append("}");
            string jsonstr = json.ToString();
            return jsonstr;
        }
        public int getMaxSeqNum(string depart_id)
        {
            int seqnum = 0;
            string sql = "select seqnum from sys_calling "
                + " where timestampdiff(DAY,date_format(apptime,'%Y-%m-%d')"
                + ",date_format(now(), '%Y-%m-%d')) = 0"
                + " order by seqnum desc  limit 1";


            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                seqnum = 0;
                return seqnum;
            }
            seqnum = int.Parse(dt.Rows[0]["seqnum"].ToString());
            return seqnum;
        }
        /// <summary>
        /// 获取发票号类型
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <returns></returns>
        public string getInvoiceKind()
        {
            string sql = "select id from  sys_invoicekind where keyname= 'GZSMZ'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];


            try
            {
                string pat = dt.Rows[0]["id"].ToString();
                return pat;
            }
            catch (Exception e)
            {

            }
            return "";
        }
    }
}

