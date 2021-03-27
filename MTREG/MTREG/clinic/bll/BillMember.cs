using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTREG.clinic.bo;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class BillMember
    {
        /// <summary>
        /// 会员表查询
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public DataTable memberSearch(Member member,string starttime,string endtime)
        {
            DataTable dt = new DataTable();
            string sql = "select member.hspcard"
                        + ",member.name"
                        + ",sexList.name as sex"
                        + ",member.birthday"
                        + ",member.idcard"
                        + ",member.cardstat"
                        + ",member.mobile"
                        + ",member_balance.balance"
                        + ",member.id"
                        + ",member.createdate"
                        + " from member"
                        + " RIGHT JOIN member_balance on member.id=member_balance.bas_member_id"
                        + " left join sys_dict as sexList on member.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                        + " where 1=1 "
                        + (!string.IsNullOrEmpty(member.Hspcard) ? (" and member.hspcard=" + DataTool.addFieldBraces(member.Hspcard) + "") : "")
                        + (!string.IsNullOrEmpty(member.Mzfare) ? (" and member.mzfare=" + DataTool.addFieldBraces(member.Mzfare) + "") : "")
                        + (!string.IsNullOrEmpty(member.Name) ? (" and member.name like '%" +member.Name +"%'") : "")
                        + (!string.IsNullOrEmpty(member.Mobile) ? (" and member.mobile=" + DataTool.addFieldBraces(member.Mobile)) : "")
                        + (!string.IsNullOrEmpty(member.Idcard) ? (" and member.idcard =" + DataTool.addFieldBraces(member.Idcard)) : "")
                        + (!string.IsNullOrEmpty(member.Cardstat) ? (" and member.cardstat =" + DataTool.addFieldBraces(member.Cardstat)) : "")
                        + (!string.IsNullOrEmpty(starttime) ? (" and member.createdate >" + DataTool.addFieldBraces(starttime)) : "")
                        + (!string.IsNullOrEmpty(endtime) ? (" and member.createdate <" + DataTool.addFieldBraces(endtime)) : "")
                        + " order by member.id desc";
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
        /// 主键id查询
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public DataTable memIdSearch(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select member.id"
                    + ",member.name"
                    + ",member.sex"
                    + ",member.birthday"
                    + ",member.idcard"
                    + ",member.cardstat"
                    + ",member_balance.balance"
                    + ",member.homeaddress"
                    + ",member.mobile"
                    + ",member.profession"
                    + ",member.hspcard"
                    + ",member.race"
                    + ",member.race_id"
                    + ",member.profession "
                    + ",member.profession_id"
                    + ",sys_region.mergername"
                    + ",member.hmstreetname"
                    + ",member.hmhouseNumber"
                    + ",member.email"
                    + ",member.companyname"
                    + ",member.companyphone"
                    + ",member.companyaddr"
                    + ",member.qqcode"
                    + " from member"
                    + " left join member_balance on member.id=member_balance.bas_member_id"
                    + " left join sys_region on sys_region.id=member.hmstreetname "
                    + " where 1=1 "
                    + (!string.IsNullOrEmpty(id) ? (" and member.id=" + DataTool.addFieldBraces(id)) : "")
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
        /// 插入会员表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string inMember(Member member)
        {            
            string sql = "insert into member(id"
                                            + ",idcard"
                                            + ",hspcard"
                                            + ",usehspcard"
                                            + ",mzfare"
                                            + ",usemzfare"
                                            + ",homeaddress"
                                            + ",hmstreetname"
                                            + ",hmhouseNumber"
                                            + ",email"
                                            + ",companyname"
                                            + ",companyphone"
                                            + ",name"
                                            + ",pincode"
                                            + ",sex"
                                            + ",race_id"
                                            + ",race"
                                            + ",profession"
                                            + ",profession_id"
                                            + ",bloodtype"
                                            + ",qqcode"
                                            + ",companyaddr"
                                            + ",companyzip"
                                            + ",birthday"
                                            + ",mobile"
                                            + ",marriage_id"
                                            + ",member_rank_id"
                                            + ",createdate"
                                            + ",cardstat"
                                            + ",createdby)values(" + DataTool.addFieldBraces(member.Id)
                                                                + "," + DataTool.addFieldBraces(member.Idcard)
                                                                + "," + DataTool.addFieldBraces(member.Hspcard)
                                                                + "," + DataTool.addFieldBraces("Y")
                                                                + "," + DataTool.addFieldBraces(member.Mzfare)
                                                                + "," + DataTool.addFieldBraces("Y")
                                                                + "," + DataTool.addFieldBraces(member.Homeaddress)
                                                                + "," + DataTool.addFieldBraces(member.Hmstreetname)
                                                                + "," + DataTool.addFieldBraces(member.HmhouseNumber)
                                                                + "," + DataTool.addFieldBraces(member.Email)
                                                                + "," + DataTool.addFieldBraces(member.Companyname)
                                                                + "," + DataTool.addFieldBraces(member.Companyphone)
                                                                + "," + DataTool.addFieldBraces(member.Name)
                                                                + "," + DataTool.addFieldBraces(member.Pincode)
                                                                + "," + DataTool.addFieldBraces(member.Sex)
                                                                + "," + DataTool.addFieldBraces(member.Race_id)
                                                                + "," + DataTool.addFieldBraces(member.Race)
                                                                + "," + DataTool.addFieldBraces(member.Profession)
                                                                + "," + DataTool.addFieldBraces(member.Profession_id)
                                                                + "," + DataTool.addFieldBraces(member.Bloodtype)
                                                                + "," + DataTool.addFieldBraces(member.Qqcode)
                                                                + "," + DataTool.addFieldBraces(member.Companyaddr)
                                                                + "," + DataTool.addFieldBraces(member.Companyzip)
                                                                + "," + DataTool.addFieldBraces(member.Birthday)
                                                                + "," + DataTool.addFieldBraces(member.Mobile)
                                                                + "," + DataTool.addFieldBraces(member.Marriage_id)
                                                                + "," + DataTool.addFieldBraces(member.Member_rank_id)
                                                                + "," + DataTool.addFieldBraces(member.Createdate)
                                                                + "," + DataTool.addFieldBraces(member.Cardstat)
                                                                + "," + DataTool.addFieldBraces(member.Createdby)
                                                                + ");";
            return sql;
            //return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 查询挂号记录表
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public DataTable getRegister(string member_id)
        {
            string sql = "SELECT id FROM register  WHERE member_id = " + DataTool.addFieldBraces(member_id) + " ORDER BY createtime,id;";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 更改会员表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string setMember(Member member)
        {
            string sql = " UPDATE member SET "
                                            + "idcard = " + DataTool.addFieldBraces(member.Idcard)
                                            + ",homeaddress = " + DataTool.addFieldBraces(member.Homeaddress)
                                            + ",hmstreetname = " + DataTool.addFieldBraces(member.Hmstreetname)
                                            + ",hmhouseNumber = " + DataTool.addFieldBraces(member.HmhouseNumber)
                                            + ",email = " + DataTool.addFieldBraces(member.Email)
                                            + ",companyname = " + DataTool.addFieldBraces(member.Companyname)
                                            + ",companyphone = " + DataTool.addFieldBraces(member.Companyphone)
                                            + ",name = " + DataTool.addFieldBraces(member.Name)
                                            + ",pincode = " + DataTool.addFieldBraces(member.Pincode)
                                            + ",sex = " + DataTool.addFieldBraces(member.Sex)
                                            + ",race_id = " + DataTool.addFieldBraces(member.Race_id)
                                            + ",race = " + DataTool.addFieldBraces(member.Race)
                                            + ",profession = " + DataTool.addFieldBraces(member.Profession)
                                            + ",profession_id = " + DataTool.addFieldBraces(member.Profession_id)
                                            + ",bloodtype = " + DataTool.addFieldBraces(member.Bloodtype)
                                            + ",qqcode = " + DataTool.addFieldBraces(member.Qqcode)
                                            + ",companyaddr = " + DataTool.addFieldBraces(member.Companyaddr)
                                            + ",companyzip = " + DataTool.addFieldBraces(member.Companyzip)
                                            + ",birthday = " + DataTool.addFieldBraces(member.Birthday)
                                            + ",mobile = " + DataTool.addFieldBraces(member.Mobile)
                                            + ",marriage_id = " + DataTool.addFieldBraces(member.Marriage_id)
                                            + ",member_rank_id = " + DataTool.addFieldBraces(member.Member_rank_id)
                                        + " WHERE "
                                            + " id = " + DataTool.addFieldBraces(member.Id) + ";";
            return sql;
        }
        /// <summary>
        /// 修改挂号记录表
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public string setRegister(string Register_id, string name, string hspcard,string sex, string age)
        {
            string sql = "UPDATE register SET `name` = " + DataTool.addFieldBraces(name) + ", hspcard = " + DataTool.addFieldBraces(hspcard) + ",sex = "+DataTool.addFieldBraces(sex)+", age = "+DataTool.addFieldBraces(age)+"  WHERE id = " + DataTool.addFieldBraces(Register_id) + ";";
            return sql;
        }
        /// <summary>
        /// 插入会员卡内余额表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string inMemberBalance(string id, string memid, string balance,string cardstat)
        {
            string sql = "insert into member_balance(id"
                                            + ",bas_member_id"
                                            + ",balance"
                                            + ",available"
                                            + ",cardstat)values(" + DataTool.addFieldBraces(id)
                                                                + "," + DataTool.addFieldBraces(memid)
                                                                + "," + DataTool.addFieldBraces(balance)
                                                                + "," + DataTool.addFieldBraces(balance)
                                                                + "," + DataTool.addFieldBraces(cardstat)
                                                                + ");";
            return sql;
            //return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 插入会员充值记录表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string inMemBalancedet(MemRechargedet memRechargedet)
        {
            string sql = "insert into member_rechargedet(id"
                                            + ",bas_member_id"
                                            + ",billcode"
                                            + ",opertype"
                                            + ",amount"
                                            + ",bas_paytype_id"
                                            + ",balance"
                                            + ",depart_id"
                                            + ",operator"
                                            + ",settled"
                                            + ",operatdate)values(" + DataTool.addFieldBraces(memRechargedet.Id)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Bas_member_id)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Billcode)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Opertype)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Amount)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Paytype_id)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Balance)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.depart_id)
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Operatorid)
                                                                + "," + DataTool.addFieldBraces("N")
                                                                + "," + DataTool.addFieldBraces(memRechargedet.Operatdate)
                                                                + ");";
            return sql;
            //return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 办卡模拟挂号，存入register
        /// </summary>
        /// <returns></returns>
        public string xregister( string member_id, string member_hspcard,string[] mem)
        {
            //获取门诊号
            string sql_register_billcode = "SELECT newBillNo('register_billcode')";
            string register_billcode = BllMain.Db.Select(sql_register_billcode).Tables[0].Rows[0][0].ToString();
            string sql_register_id = "SELECT NEXTID('register')";
            string register_id = BllMain.Db.Select(sql_register_id).Tables[0].Rows[0][0].ToString();
            string year = (DateTime.Now.Year - (DateTime.Parse(mem[3].ToString()).Year)).ToString();
            string sql = "insert into register ( "
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
                        + DataTool.addFieldBraces(register_id)
                        + "," + DataTool.addFieldBraces(register_billcode)
                        + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                        + "," + DataTool.addFieldBraces("B")
                        + "," + DataTool.addFieldBraces("1")
                        + "," + DataTool.addFieldBraces("1")
                        + "," + DataTool.addFieldBraces("")
                        + "," + DataTool.addFieldBraces("3")
                        + "," + DataTool.addFieldBraces("3")
                        + "," + DataTool.addFieldBraces("N")
                        + "," + DataTool.addFieldBraces("172")
                        + "," + DataTool.addFieldBraces("41")
                        + "," + DataTool.addFieldBraces("76")
                        + "," + DataTool.addFieldBraces("0")
                        + "," + DataTool.addFieldBraces("REG")
                        + "," + DataTool.addFieldBraces("OO")
                        + "," + DataTool.addFieldBraces(member_id)
                        + "," + DataTool.addFieldBraces(member_hspcard)
                        + "," + DataTool.addFieldBraces(mem[0].ToString())
                        + "," + DataTool.addFieldBraces(mem[1].ToString())
                        + "," + DataTool.addFieldBraces(mem[2].ToString())
                        + "," + DataTool.addFieldBraces(mem[3].ToString())
                        + "," + DataTool.addFieldBraces(year)
                        + "," + DataTool.addFieldBraces("4")
                        + "," + DataTool.addFieldBraces("")
                        + "," + DataTool.addFieldBraces("3")
                        + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                        + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                        + "," + DataTool.addFieldBraces("0")
                        + "," + DataTool.addFieldBraces("治未病门诊")
                        + "," + DataTool.addFieldBraces("22")
                        + "," + DataTool.addFieldBraces("")
                        + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                        + " );";
            return sql;
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
        /// 获取性别id
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public string getSexId(string sex)
        {
            switch(sex)
            {
                case "M": sex = "男";break;
                case "W": sex = "女"; break;
                case "U": sex = "未知"; break;
            }
            string depar = "select sn as id from sys_dict where name = " + DataTool.addFieldBraces(sex);
            DataTable datatable = BllMain.Db.Select(depar).Tables[0];
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
        /// 会员等级下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable rankList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='member_rank' order by ordersn";
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
        /// 婚姻状况下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable marriageList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='member_marriage' order by ordersn";
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
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='member_profession'";
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
        /// 血型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable bloodtypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='blood_bloodtype' order by ordersn";
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
        /// 下拉框 民族
        /// </summary>
        /// <returns></returns>
        public DataTable getRaceInfo()
        {
            DataTable dt = new DataTable();
            string sql = "select sys_dict.sn as id "
                       + ",sys_dict.name"
                       + ",sys_dict.pincode"
                       + " from sys_dict "
                       + " where father_id <>0 and dicttype = 'member_race' order by id";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 更新会员卡表
        /// </summary>
        /// <returns></returns>
        public string upMember(Member member)
        {
            //string sql = "update member set idcard=" + DataTool.addFieldBraces(member.Idcard)
            //                                        + ",race_id=" + DataTool.addFieldBraces(member.Race_id)
            //                                        + ",race=" + DataTool.addFieldBraces(member.Race)
            //                                        + ",hspcard=" + DataTool.addFieldBraces(member.Hspcard)
            //                                        + ",homeaddress=" + DataTool.addFieldBraces(member.Homeaddress)
            //                                        + ",hmstreetname=" + DataTool.addFieldBraces(member.Hmstreetname)//
            //                                        + ",hmhouseNumber=" + DataTool.addFieldBraces(member.HmhouseNumber)//
            //                                        + ",email=" + DataTool.addFieldBraces(member.Email)
            //                                        + ",companyname=" + DataTool.addFieldBraces(member.Companyname)
            //                                        + ",companyphone=" + DataTool.addFieldBraces(member.Companyphone)
            //                                        + ",name=" + DataTool.addFieldBraces(member.Name)
            //                                        + ",sex=" + DataTool.addFieldBraces(member.Sex)
            //                                        + ",profession=" + DataTool.addFieldBraces(member.Profession)
            //                                        + ",profession_id=" + DataTool.addFieldBraces(member.Profession_id)//
            //                                        + ",bloodtype=" + DataTool.addFieldBraces(member.Bloodtype)
            //                                        + ",qqcode=" + DataTool.addFieldBraces(member.Qqcode)
            //                                        + ",companyaddr=" + DataTool.addFieldBraces(member.Companyaddr)
            //                                        + ",companyzip=" + DataTool.addFieldBraces(member.Companyzip)
            //                                        + ",birthday=" + DataTool.addFieldBraces(member.Birthday)
            //                                        + ",mobile=" + DataTool.addFieldBraces(member.Mobile)
            //                                        + ",marriage_id=" + DataTool.addFieldBraces(member.Marriage_id)
            //                                        + ",member_rank_id=" + DataTool.addFieldBraces(member.Member_rank_id)
            //                                        + ",createdate=" + DataTool.addFieldBraces(member.Createdate)
            //                                        + " where id=" + DataTool.addFieldBraces(member.Id);
            string sql = "update member set hspcard=" + DataTool.addFieldBraces(member.Hspcard)
                                        + ",mzfare = " + DataTool.addFieldBraces(member.Mzfare)
                                        + ",createdate=" + DataTool.addFieldBraces(member.Createdate)
                                        + " where id=" + DataTool.addFieldBraces(member.Id)
                                        + ";";
            return sql;
            //return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 更新会员卡余额表余额
        /// </summary>
        /// <returns></returns>
        public string upMemBalance(string member_id, string balance)
        {
            string upsql = "";
            string sql = "select id from member_balance where bas_member_id=" + DataTool.addFieldBraces(member_id);
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                string id = BillSysBase.nextId("member_balance");
                upsql = "insert into member_balance(id"
                    + ",bas_member_id"
                    + ",balance"
                    + ",available"
                    + ",cardstat"
                    + ")values(" + DataTool.addIntBraces(id)
                    + "," + DataTool.addIntBraces(member_id)
                    + "," + DataTool.addFieldBraces(balance)
                    + "," + DataTool.addFieldBraces(balance)
                    + "," + DataTool.addFieldBraces(MemberCardStat.YES.ToString())
                    + ");";
            }
            else
            {
                upsql = "update member_balance set balance=" + DataTool.addFieldBraces(balance)
                    + ",available=" + DataTool.addFieldBraces(balance)
                    + " where bas_member_id=" + DataTool.addFieldBraces(member_id)
                    + ";";
            }
            //return BllMain.Db.Update(upsql);
            return upsql;
        }

        /// <summary>
        /// 更新会员卡余额表状态
        /// </summary>
        /// <returns></returns>
        public string upMemBalanceSta(string id, string cardstat)
        {
            string sql = "update member_balance set cardstat=" + DataTool.addFieldBraces(cardstat)
                + " where bas_member_id=" + DataTool.addFieldBraces(id) + ";";
            return sql;
        }

        /// <summary>
        /// 更新会员卡余额表状态
        /// </summary>
        /// <returns></returns>
        public string upMemSta(string id, string cardstat)
        {
            string sql = "update member set cardstat=" + DataTool.addFieldBraces(cardstat)
                + " where id=" + DataTool.addFieldBraces(id) + ";";
            return sql;
        }

        /// <summary>
        /// 更新退卡
        /// </summary>
        /// <returns></returns>
        public string upMemHspcard(string id, string usehspcard)
        {
            string hspcard = BillSysBase.newBillcode("member_hspcard");
            //string sql = "delete from member where id=" + DataTool.addIntBraces(id)+";";
            //sql += "insert into member(id,hspcard,usehspcard,cardstat)values(" + DataTool.addFieldBraces(id)
            //                                                          + "," + DataTool.addFieldBraces(hspcard)
            //                                                          + "," + DataTool.addFieldBraces(usehspcard)
            //                                                          + "," + DataTool.addFieldBraces("XX")
            //                                                          + ");";
            string sql = "update member set hspcard=" + DataTool.addFieldBraces(hspcard)
                + ",usehspcard=" + DataTool.addFieldBraces(usehspcard)
                + ",cardstat=" + DataTool.addFieldBraces("NO")
                + ",usemzfare =" + DataTool.addFieldBraces(usehspcard)
                + ",mzfare = "+ DataTool.addFieldBraces("")
                +" where id="+DataTool.addIntBraces(id)
                + ";";
            return sql;
        }
        /// <summary>
        /// 查询充值记录性别
        /// </summary>
        /// <param name="id"></param>
        public DataTable memRechargedets(string id)
        {
            string sql = "SELECT"
                    + " member_rechargedet.operatdate,"
                    + " member_rechargedet.opertype,"
                    + " member_rechargedet.amount,"
                    + " member_rechargedet.balance,"
                    + " member.NAME,"
                    + " member.sex,"
                    + " CASE"
                    + " WHEN member.sex = 'W' THEN"
                    + " '女' "
                    + " WHEN member.sex = 'M' THEN"
                    + " '男'"
                    + " ELSE '"
                    + " 未知' "
                    + " END AS sex,"
                    + " member.sex "
                    + " FROM"
                    + " member_rechargedet"
                    + " LEFT JOIN member ON member.id = member_rechargedet.bas_member_id "
                    + " where member_rechargedet.bas_member_id=" + DataTool.addFieldBraces(id);
                	
            DataTable dt = new DataTable();
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
        /// 查询充值记录
        /// </summary>
        /// <param name="id"></param>
        public DataTable memRechargedet(string id, string begin,string end)
        {
            string sql = "select member_rechargedet.operatdate "
                        + ",member_rechargedet.opertype"
                        + ",member_rechargedet.amount"
                        + ",member_rechargedet.balance"
                        + ",a.`name` as paytype"
                        + " from member_rechargedet"   
                        + " LEFT JOIN (SELECT * FROM sys_dict WHERE  father_id<>0 AND dicttype='bas_paytype') a ON a.sn = member_rechargedet.bas_paytype_id"
                        + " where member_rechargedet.bas_member_id=" + DataTool.addFieldBraces(id)
                        + " AND member_rechargedet.operatdate >= " + DataTool.addFieldBraces(begin) + " AND  member_rechargedet.operatdate <=" + DataTool.addFieldBraces(end) + " ;"
                        ;
            DataTable dt=new DataTable();
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
