using System;
using System.Data;
using System.Linq;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.ihsp.bo;
using MTREG.common;
using MTHIS.tools;
using MTREG.netpay.bo;
using MTREG.netpay;


namespace MTREG.ihsp.bll
{
    class BillIhspMan
    {
        /// <summary>
        /// 入院通知单中的查询
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="hspcard">卡号</param>
        /// <returns></returns>
        public DataTable IhspNoticeSearch(string name, string hspcard, string depart, string startime, string endtime)
        {
            string sql = "select register.hspcard"
                    + ",clinic_ihspnotice.name"
                    + " ,CASE"
                    + " WHEN clinic_ihspnotice.sex='M' THEN '男'"
                    + " WHEN clinic_ihspnotice.sex='W' THEN '女'"
                    + " ELSE '未知' END as sex"
                    + ",clinic_ihspnotice.age"
                    + ",clinic_ihspnotice.birthday"
                    + ",bas_depart.name as departname"
                    + ",clinic_ihspnotice.payfee"
                    + ",clinic_ihspnotice.id "
                    + ",register.bas_patienttype_id,clinic_ihspnotice.indate"
                    + " from clinic_ihspnotice"
                    + " left join register on register.id=clinic_ihspnotice.regist_id"
                    + " left join member on member.id=clinic_ihspnotice.member_id"
                    + " left join bas_depart on bas_depart.id=clinic_ihspnotice.depart_id"
                    + " where 1=1 "
                    + " and clinic_ihspnotice.opstat='APP'"
                    + (!string.IsNullOrEmpty(name) ? (" and  clinic_ihspnotice.name like '%" + name + "%' ") : "")
                    + (!string.IsNullOrEmpty(hspcard) ? (" and  register.hspcard=" + DataTool.addFieldBraces(hspcard)) : "")
                    + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                    + (!string.IsNullOrEmpty(startime) ? (" and clinic_ihspnotice.indate >" + DataTool.addFieldBraces(startime)) : "")
                    + (!string.IsNullOrEmpty(endtime) ? (" and clinic_ihspnotice.indate <" + DataTool.addFieldBraces(endtime)) : "")
                    ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 入院通知书Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable IhspNoticeId(string id)
        {
            string sql = "select register.hspcard"
                        + ",clinic_ihspnotice.regist_id"
                        + ",clinic_ihspnotice.name"
                        + ",clinic_ihspnotice.sex"
                        + ",clinic_ihspnotice.age"
                        + ",clinic_ihspnotice.ageunit"
                        + ",clinic_ihspnotice.birthday"
                        + ",clinic_ihspnotice.depart_id"
                        + ",bas_depart.name as departname"
                        + ",clinic_ihspnotice.payfee"
                        + ",clinic_ihspnotice.id as clinicid"
                        + ",clinic_ihspnotice.introducer"
                        + ",clinic_ihspnotice.limitamt"
                        + ",clinic_ihspnotice.bas_ihspsource_id"
                        + ",clinic_ihspnotice.bas_ihspinstat_id"
                        + ",ihsp_info.idcard"
                        + ",ihsp_info.hmprovince"
                        + ",ihsp_info.hmcity"
                        + ",ihsp_info.hmcounty"
                        + ",ihsp_info.homephone"//电话
                        + ",ihsp_info.profession_id"//职业id
                        + ",ihsp_info.profession"//职业
                        + ",ihsp_info.marriage_id"//婚姻状况
                        + ",member.id as memid"
                        + ",member.homeaddress"
                        + ",member.hmstreetname"
                        + ",sys_region.mergername"
                        + ",member.hmhouseNumber"
                        + ",member.companyname"
                        + " from clinic_ihspnotice"
                        + " left join register on register.id=clinic_ihspnotice.regist_id"
                        + " left join member on member.id=clinic_ihspnotice.member_id"
                        + " left join sys_region on sys_region.id=member.hmstreetname"
                        + " left join bas_depart on bas_depart.id=clinic_ihspnotice.depart_id"
                        + " left join ihsp_info on ihsp_info.ihsp_id=register.id and ihsp_info.registkind=" + DataTool.addFieldBraces(RegistKind.CLIN.ToString())
                        + " where 1=1 "
                        + " and clinic_ihspnotice.Opstat='APP'"
                        + (!string.IsNullOrEmpty(id) ? (" and  clinic_ihspnotice.id=" + DataTool.addFieldBraces(id)) : "")
                        ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 入院通知书疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getNoticediagn(string id)
        {
            string sql = "select diagnICD"
                           + ",diagnname"
                           + " from clinic_noticediagn"
                           + " where clinic_ihspnotice_id=" + DataTool.addIntBraces(id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 住院诊断信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable getIhspDiagn(string ihspid)
        {
            string sql = "select diagnICD"
                + ",diagnname"
                + " from ihsp_diagnmes"
                + " where diagnKind=" + DataTool.addFieldBraces(DiagnKind.CLIN.ToString())
                + " and ihsp_id=" + DataTool.addIntBraces(ihspid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 更新住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upinsurstat(string ihspcode, string insurstat)
        {
            string sql = "update inhospital set insurstat=" + DataTool.addFieldBraces(insurstat) + " where ihspcode=" + DataTool.addFieldBraces(ihspcode);
            return BllMain.Db.Update(sql);
        }


        /// <summary>
        /// 更新患者类型
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="insurstat"></param>
        /// <returns></returns>
        public int uppatienttype(string ihsp_id, string insurstat)
        {
            string sql = "update inhospital set bas_patienttype_id=" + DataTool.addFieldBraces(insurstat)
                + " where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        public string Updatemember(string member_id, Member member, Inhospital inhospital)
        {
            string sql = "update member"
                   + " set "
                    + " name=" + DataTool.addFieldBraces(inhospital.Name)
                    + ", pincode=" + DataTool.addFieldBraces(inhospital.Pincode)
                    + ", sex=" + DataTool.addFieldBraces(inhospital.Sex)
                    + ", birthday=" + DataTool.addFieldBraces(inhospital.Birthday)
                    + ", hspcard=" + DataTool.addFieldBraces(inhospital.Hspcard)
                    + ", usehspcard=" + DataTool.addFieldBraces("Y")
                    + ", race=" + DataTool.addFieldBraces(member.Race)
                    + ", homeaddress=" + DataTool.addFieldBraces(member.Homeaddress)
                    + ", hmstreetname=" + DataTool.addFieldBraces(member.Hmstreetname)
                    + ", idcard=" + DataTool.addFieldBraces(member.Idcard)
                    + ", profession=" + DataTool.addFieldBraces(member.Profession)
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
        /// <summary>
        /// 入院登记添加会员
        /// </summary>
        /// <returns></returns>
        public string Regmember(string member_id, Member member, Inhospital inhospital)
        {
            string sql = "insert into member(id"
                                            + ",name"
                                            + ",pincode"
                                            + ",sex"
                                            + ",birthday"
                                            + ",hspcard"
                                            + ",idcard"
                                            + ",mobile"
                                            + ",companyname"
                                            + ",createdate"
                                            + ",usehspcard"
                                            + ",cardstat"
                                            + ",race_id"
                                            + ",race"
                                            + ",homeaddress"
                                            + ",hmhouseNumber"
                                            + ",hmprovince"
                                            + ",hmcity"
                                            + ",hmcounty"
                                            + ", provice_id"
                                            + ", city_id"
                                            + ", county_id"
                                            + ",createdby)values(" + DataTool.addFieldBraces(member_id)
                                                                  + "," + DataTool.addFieldBraces(inhospital.Name)
                                                                  + "," + DataTool.addFieldBraces(inhospital.Pincode)
                                                                  + "," + DataTool.addFieldBraces(inhospital.Sex)
                                                                  + "," + DataTool.addFieldBraces(inhospital.Birthday)
                                                                  + "," + DataTool.addFieldBraces(inhospital.Hspcard)
                                                                  + "," + DataTool.addFieldBraces(member.Idcard)
                                                                  + "," + DataTool.addFieldBraces(member.Mobile)
                                                                  + "," + DataTool.addFieldBraces(member.Companyname)
                                                                  + "," + DataTool.addFieldBraces(member.Createdate)
                                                                  + "," + DataTool.addFieldBraces("Y")
                                                                  + "," + DataTool.addFieldBraces("YES")
                                                                  + "," + DataTool.addFieldBraces(member.Raceid)
                                                                  + "," + DataTool.addFieldBraces(member.Race)
                                                                  + "," + DataTool.addFieldBraces(member.Homeaddress)
                                                                  + "," + DataTool.addFieldBraces(member.HmhouseNumber)
                                                                  + "," + DataTool.addFieldBraces(member.Hmprovince)
                                                                  + "," + DataTool.addFieldBraces(member.Hmcity)
                                                                  + "," + DataTool.addFieldBraces(member.Hmcounty)
                                                                   + "," + DataTool.addFieldBraces(member.Provice_id)
                                                                   + "," + DataTool.addFieldBraces(member.City_id)
                                                                   + "," + DataTool.addFieldBraces(member.County_id)
                                                                  + "," + DataTool.addFieldBraces(member.Createdby)
                                                                  + ");";
            return sql;
        }

        /// <summary>
        /// 入院登记窗口添加数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <param name="hspcard">医院卡</param>
        /// <param name="name">姓名</param>
        /// <param name="sex">性别</param>
        /// <returns></returns>
        public string inhspReg(Inhospital inhospital, IhspInfo ihspInfo)
        {
            string sql = "insert into inhospital(id"
                                                + ", register_id"
                                                 + ", hspcard"
                                                 + ", ihspsn"
                                                 + ", name"
                                                 + ", pincode"
                                                 + ", sex"
                                                 + ", age"
                                                 + ", ageunit"
                                                 + ", moonage"
                                                 + ", moonageunit"
                                                 + ", depart_id"
                                                 + ", ihspcode"
                                                 + ", casecode"
                                                 + ", clinicdiagn"
                                                 + ", clinicicd"
                                                 + ", birthday"
                                                 + ", indate"
                                                 + ", bas_ihspsource_id"
                                                 + ", introducer"
                                                 + ", doctor_id"
                                                 + ", bas_patienttype_id"

                                                 + ", bas_patienttype1_id"
                                                 + ", insurstat"
                                                 + ", insuritemtype"
                                                 + ", insurcode"
                                                 + ", limitamt"
                                                 + ", prepamt"
                                                 + ", member_id"
                                                 + ", nustmpamt"
                                                 + ", feeamt"
                                                 + ", balanceamt"
                                                 + ", bas_ihspinstat_id"
                                                 + ",costclass"
                                                 + ",registdate"
                                                 + ",registby"
                                                 + ",enterdep"
                                                 + ",inbed"
                                                 + ",ihspstate"
                                                 + ",isarchive"
                                                 + ",status"
                                                 + ",poverty"
                                                 + ",clinic_depart_id"
                                                 + ",clinic_doctor_id)values(" + DataTool.addFieldBraces(inhospital.Id)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Register_id)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Hspcard)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Ihspsn)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Name)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Pincode)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Sex)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Age)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Ageunit)
                                                                    + "," + DataTool.addFieldBraces(inhospital.MonAge)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Monageunit)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Depart)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Ihspcode)
                                                                      + "," + DataTool.addFieldBraces(inhospital.Casecode)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Clinicdiagn)

                                                                    + "," + DataTool.addFieldBraces(inhospital.Clinicicd)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Birthday)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Indate)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Inspsource)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Introducer)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Doctor)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Patienttype)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Bas_patienttype1_id)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Insurstat)
                                                                    + " , '1'"
                                                                    + "," + DataTool.addFieldBraces(inhospital.Insurcode)

                                                                    + "," + DataTool.addFieldBraces(inhospital.Limitamt)
                                                                    + "," + DataTool.addFieldBraces(inhospital.Prepamt)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Member_id)
                                                                    + " , '0'"
                                                                    + " , '0'"
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Prepamt)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Bas_ihspinstat_id)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Costclass)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Registdate)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.Registby)
                                                                    + " , " + DataTool.addFieldBraces(IhspEnterDep.OO.ToString())
                                                                    + " , " + DataTool.addFieldBraces(IhspInbed.N.ToString())
                                                                    + " , " + DataTool.addFieldBraces(IhspIshpstate.COMM.ToString())
                                                                    + " , " + DataTool.addFieldBraces(IhspIsarchive.OO.ToString())
                                                                    + " , " + DataTool.addFieldBraces(IhspStatus.BREG.ToString())
                                                                    + " , " + DataTool.addFieldBraces(inhospital.poverty)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.ClinicDepart)
                                                                    + " , " + DataTool.addFieldBraces(inhospital.ClinicDoctor)
                                                                    + ");";

            if (!string.IsNullOrEmpty(inhospital.Clinicicd))
            {
                string icdInfo = inhospital.Clinicicd;
                string[] icdList = icdInfo.Split(',');
                string nameInfo = inhospital.Clinicdiagn;
                string[] nameList = nameInfo.Split(',');
                string opkind = "";
                for (int i = 0; i < icdList.Length; i++)
                {
                    string ihspDiagnmesId = BillSysBase.nextId("ihsp_diagnmes");
                    //是否为主要诊断
                    if (i == 0)
                    {
                        opkind = "MAIN";
                    }
                    else
                    {
                        opkind = "OTHEN";
                    }
                    sql += "insert into ihsp_diagnmes(id"
                        + ",ihsp_id"
                        + ",diagnKind"
                        + ",sn"
                        + ",diagndate"
                        + ",doctor_id"
                        + ",opkind"
                        + ",diagnICD"
                        + ",diagnname)values(" + DataTool.addIntBraces(ihspDiagnmesId)
                        + "," + DataTool.addIntBraces(ihspInfo.Ihsp_id)
                        + "," + DataTool.addFieldBraces(DiagnKind.CLIN.ToString())
                        + "," + DataTool.addIntBraces(i.ToString())
                        + "," + DataTool.addFieldBraces(inhospital.Indate)
                        + "," + DataTool.addFieldBraces(inhospital.Doctor)
                        + "," + DataTool.addFieldBraces(opkind)
                        + "," + DataTool.addFieldBraces(icdList[i])
                        + "," + DataTool.addFieldBraces(nameList[i])
                        + ");";
                }
            }
            ihspInfo.Id = BillSysBase.nextId("ihsp_info");
            sql += "insert into ihsp_info(id"
                + ",ihsp_id"
                + ",registkind"
                + ",idcard"
                + ",race"
                + ",race_id"
                + ",homeaddress"//现地址
                + ",hmhouseNumber"
                + ",hmprovince"
                + ",hmcity"
                + ",hmcounty"
                + ",residenceaddress"//户籍地址
                + ",resihouseNumber"
                + ",resiprovice"
                + ",resicity"
                + ",resicounty"
                + ",birthplace"//出生地
                + ",houseNumber"
                + ",provice_id"
                + ",city_id"
                + ",county_id"
                //+ ",mobile"
                + ",homephone"
                + ",profession_id"
                + ",profession"
                + ",marriage_id"
                + ",companyname)values(" + DataTool.addIntBraces(ihspInfo.Id)
                + "," + DataTool.addIntBraces(ihspInfo.Ihsp_id)
                + "," + DataTool.addFieldBraces(RegistKind.IHSP.ToString())
                + "," + DataTool.addFieldBraces(ihspInfo.Idcard)
                + "," + DataTool.addFieldBraces(ihspInfo.Race)
                + "," + DataTool.addFieldBraces(ihspInfo.Raceid)
                + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                + "," + DataTool.addFieldBraces(ihspInfo.Province_id)
                + "," + DataTool.addFieldBraces(ihspInfo.City_id)
                + "," + DataTool.addFieldBraces(ihspInfo.County_id)
                + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                + "," + DataTool.addFieldBraces(ihspInfo.Province_id)
                + "," + DataTool.addFieldBraces(ihspInfo.City_id)
                + "," + DataTool.addFieldBraces(ihspInfo.County_id)
                + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                + "," + DataTool.addFieldBraces(ihspInfo.Province_id)
                + "," + DataTool.addFieldBraces(ihspInfo.City_id)
                + "," + DataTool.addFieldBraces(ihspInfo.County_id)
                //+ "," + DataTool.addFieldBraces(ihspInfo.Homephone)
                + "," + DataTool.addFieldBraces(ihspInfo.Homephone)
                + "," + DataTool.addFieldBraces(ihspInfo.Profession_id)
                + "," + DataTool.addFieldBraces(ihspInfo.Profession)
                + "," + DataTool.addFieldBraces(ihspInfo.Marriage_id)
                + "," + DataTool.addFieldBraces(ihspInfo.Companyname)
                + ");";
            string sql_sel = "select count(id) numb from clinic_ihspnotice where id = " + DataTool.addFieldBraces(inhospital.Clinic_ihspnotice_id) + ";";
            string numb = "0";
            try
            {
                numb = BllMain.Db.Select(sql_sel).Tables[0].Rows[0]["numb"].ToString();
            }
            catch (Exception)
            { }
            if (numb == "1")

                sql += "update clinic_ihspnotice set opstat='CHK',ihsp_id =" + DataTool.addFieldBraces(ihspInfo.Ihsp_id) + " where id=" + DataTool.addFieldBraces(inhospital.Clinic_ihspnotice_id) + ";";
            else
            {
                string clinic_ihspnotice_id = BillSysBase.nextId("clinic_ihspnotice");
                sql += "insert into clinic_ihspnotice ("
                    + " id"
                    + ", opstat"
                    + ", ihsp_id"
                    + ")values("
                    + DataTool.addFieldBraces(clinic_ihspnotice_id)
                    + "," + DataTool.addFieldBraces("CHK")
                    + "," + DataTool.addFieldBraces(ihspInfo.Ihsp_id)
                    + ");";

            }

            return sql;
        }

        /// <summary>
        /// 入院登记窗口改变数据
        /// </summary>
        /// <param name="inhospital"></param>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public int uphspReg(Inhospital inhospital, Member member)
        {
            string sql = "update inhospital set name=" + DataTool.addFieldBraces(inhospital.Name)
                                      + ", pincode=" + DataTool.addFieldBraces(inhospital.Pincode)
                                      + ", sex=" + DataTool.addFieldBraces(inhospital.Sex)
                                      + ", depart_id=" + DataTool.addFieldBraces(inhospital.Depart)
                                      + ", doctor_id=" + DataTool.addFieldBraces(inhospital.Doctor)
                                      + ", age=" + DataTool.addFieldBraces(inhospital.Age)
                                      + ",ageunit=" + DataTool.addFieldBraces(inhospital.Ageunit)
                                      + ", introducer = " + DataTool.addFieldBraces(inhospital.Introducer)
                                      + " where id=" + DataTool.addFieldBraces(inhospital.Id)
                                      + ";";
            sql += "update member set "
                 + " name=" + DataTool.addFieldBraces(inhospital.Name)
                 + ", idcard=" + DataTool.addFieldBraces(member.Idcard)
                 + ", pincode=" + DataTool.addFieldBraces(inhospital.Pincode)
                 + ", sex=" + DataTool.addFieldBraces(inhospital.Sex)
                 + ", birthday=" + DataTool.addFieldBraces(inhospital.Birthday)
                 + " where id=" + DataTool.addFieldBraces(inhospital.Member_id)
                 + ";";
            return BllMain.Db.Update(sql);
        }
        public int upemr_neonate(string name, string sex, string id)
        {
            string sql = @"update emr_neonate set name = '{0}',sex = '{1}' where id = {2}";
            sql = string.Format(sql, name, sex, id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 住院登记查询
        /// </summary>
        /// <param name="hspcard">卡号</param>
        /// <returns></returns>
        public DataTable ihspEnterSearchByhspcard(string hspcard)
        {
            string sql = "select member.name"//姓名
                      + ",member.sex"//性别
                      + ",member.birthday"//生日
                      + ",member.homeaddress"//现住址
                      + ",sys_region.mergername"//
                      + ",member.hmstreetname"//现住址村
                      + ",member.hmhouseNumber"//门牌号
                      + ",member.companyname"//单位名称
                      + ",member.idcard"//身份证
                      + ",member.id"
                      + ",member.race"
                      + ",member.race_id"
                      + " from member "
                      + " left join sys_region on sys_region.id=member.hmstreetname "
                      + " where  hspcard = " + DataTool.addFieldBraces(hspcard)
                      + " and cardstat='YES'";
            /*string sql = "select "
                + " register.member_id, "
                + " register.name, "
                + " ihsp_info.idcard, "
                + " register.sex, "
                + " ihsp_info.race_id, "
                + " ihsp_info.race, "
                + " register.birthday, "
                + " ihsp_info.companyname, "
                + " ihsp_info.hmprovince, "
                + " ihsp_info.hmcity, "
                + " ihsp_info.hmcounty, "
                + " ihsp_info.hmhouseNumber "
                + " from ihsp_info,register "
                + " where register.id=ihsp_info.ihsp_id "
                + " and ihsp_info.registkind='CLIN' "
                + " and register.hspcard=" + DataTool.addFieldBraces(hspcard)
                + " order by ihsp_info.id desc limit 1 ";*/
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 住院记录查询按钮
        /// </summary>
        /// <returns></returns>
        public DataTable manSearch(string name, string ihspcode, string hspcard
                                   , string depart, string startTime, string endTime, string status)
        {
            string sql = "select inhospital.ihspcode"
                      + ",inhospital.name as ihspname"
                      + ",sexList.name as sex"
                      + ",bas_depart.id as bas_depart_id"
                      + ",bas_depart.name as departname"
                      + ",bas_doctor.id as bas_doctor_id"
                      + ",bas_doctor.name as doctorname"
                      + ",member.mobile AS mobile"
                      + ",inhospital.indate"
                      + ",inhospital.healthcard"
                       + ",sybzyjl.AKC140 AS AKC140"
                      + ",bas_patienttype.keyname"
                      + ",(CONCAT(bas_patienttype. NAME ,(CASE inhospital.poverty	WHEN '1' THEN	'(低保)'	WHEN '2' THEN	'(农村低保)'	WHEN '3' THEN	'(分散五保)'	WHEN '4' THEN	'(集中五保)'  WHEN '5' THEN		'(建档立卡)'	ELSE	'(非贫困)'	END) )) AS patienttype"
                      + ",(case sybzyjl.AKA130 WHEN '21' THEN '普通住院' WHEN '25' THEN '转入住院' WHEN '27' THEN '意外伤害住院' WHEN '52' THEN '生育住院' ELSE '非医保入院' END) AS AKA130"
                      + ",inhospital.id"
                      + ",inhospital.bas_patienttype_id"
                      + ",bas_patienttype.displaycolor"
                      + ",bas_sickroom.name as sickroomname"
                      + ",bas_sickbed.name as sickbedname"
                      + " from inhospital "
                      + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                      + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                      + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                      + " LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode "
                      + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                      + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                      + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                      + " LEFT JOIN member ON member.id = inhospital.member_id "
                      + " where 1=1 "
                      + (!string.IsNullOrEmpty(status) ? (" and inhospital.status = " + DataTool.addFieldBraces(status)) : " and inhospital.status in ('REG','BREG','SETT')")
                      + (!string.IsNullOrEmpty(name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + name + "%")) : "")
                      + (!string.IsNullOrEmpty(ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(ihspcode)) : "")
                      + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                      + (!string.IsNullOrEmpty(hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(hspcard)) : "");
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
            }
            sql += " order by id desc";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable manSearch1(string name, string ihspcode, string hspcard
                                   , string depart, string startTime, string endTime, string status, Inhospital inhospital)
        {
            string sql = "";
            if (inhospital.Ybzt.Equals("WDJ"))
            {
                sql = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",sexList.name as sex"
                         + ",bas_depart.name as departname"
                         + ",bas_doctor.name as doctorname"
                         + ",bas_sickroom.name as sickroomname"
                         + ",bas_sickbed.name as sickbedname"
                         + ",inhospital.indate"
                         + ",inhospital.hspcard"
                         + ",bas_patienttype.name as patienttype"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",bas_patienttype.displaycolor"
                         + " from inhospital "
                         + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                         + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                         + " where 1=1 and inhospital.nhflag=0 and inhospital.status<>'XX'"
                    //+ (!string.IsNullOrEmpty(status) ? (" and inhospital.status = " + DataTool.addFieldBraces(status)) : " and inhospital.status in ('REG','BREG')")
                         + (!string.IsNullOrEmpty(name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + name + "%")) : "")
                         + (!string.IsNullOrEmpty(ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(ihspcode)) : "")
                         + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                         + (!string.IsNullOrEmpty(hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(hspcard)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
                }
                sql += " order by id desc";
            }
            if (inhospital.Ybzt.Equals("YDJ"))
            {
                sql = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",sexList.name as sex"
                         + ",bas_depart.name as departname"
                         + ",bas_doctor.name as doctorname"
                         + ",bas_sickroom.name as sickroomname"
                         + ",bas_sickbed.name as sickbedname"
                         + ",inhospital.indate"
                         + ",inhospital.hspcard"
                         + ",bas_patienttype.name as patienttype"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",bas_patienttype.displaycolor"
                         + " from inhospital "
                         + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                         + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                         + " where 1=1 and inhospital.nhflag in(1101,301,1501) and inhospital.status<>'XX'"
                    //+ (!string.IsNullOrEmpty(status) ? (" and inhospital.status = " + DataTool.addFieldBraces(status)) : " and inhospital.status in ('REG','BREG')")
                         + (!string.IsNullOrEmpty(name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + name + "%")) : "")
                         + (!string.IsNullOrEmpty(ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(ihspcode)) : "")
                         + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                         + (!string.IsNullOrEmpty(hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(hspcard)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
                }
                sql += " order by id desc";
            }
            if (inhospital.Ybzt.Equals("YCY"))
            {
                sql = "select inhospital.ihspcode"
                         + ",inhospital.name as ihspname"
                         + ",sexList.name as sex"
                         + ",bas_depart.name as departname"
                         + ",bas_doctor.name as doctorname"
                         + ",bas_sickroom.name as sickroomname"
                         + ",bas_sickbed.name as sickbedname"
                         + ",inhospital.indate"
                         + ",inhospital.hspcard"
                         + ",bas_patienttype.name as patienttype"
                         + ",inhospital.id"
                         + ",inhospital.bas_patienttype_id"
                         + ",bas_patienttype.displaycolor"
                         + " from inhospital "
                         + " left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0"
                         + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                         + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                         + " left join bas_patienttype on inhospital.bas_patienttype_id=bas_patienttype.id "
                         + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                         + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                         + " where 1=1 and inhospital.nhflag in(1102,302,1502) and inhospital.status<>'XX'"
                    //+ (!string.IsNullOrEmpty(status) ? (" and inhospital.status = " + DataTool.addFieldBraces(status)) : " and inhospital.status in ('REG','BREG')")
                         + (!string.IsNullOrEmpty(name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + name + "%")) : "")
                         + (!string.IsNullOrEmpty(ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(ihspcode)) : "")
                         + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                         + (!string.IsNullOrEmpty(hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(hspcard)) : "");
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    sql += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
                }
                sql += " order by id desc";
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 为住院记录表和科室表的外键服务
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public string getDepartId(string depart)
        {
            string depar = "select id from bas_depart where name = " + DataTool.addFieldBraces(depart);
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
        public DataTable getdr(string name, string ihspcode, string hspcard
                                   , string depart, string startTime, string endTime)
        {
            string sql = @"SELECT
	                            inhospital.ihspcode
                                ,inhospital.name as ihspname
                                ,sexList.name as sex
                                ,bas_depart.name as departname
                                ,bas_doctor.name as doctorname
                                ,bas_sickroom.name as sickroomname
                                ,bas_sickbed.name as sickbedname
                                ,inhospital.indate
                                ,inhospital.hspcard
                                ,bas_patienttype.name as patienttype
                                ,inhospital.id
                                ,inhospital.bas_patienttype_id
                                ,bas_patienttype.displaycolor
                            FROM
	                            inhospital
                            LEFT JOIN sys_dict AS sexList ON inhospital.sex = sexList.keyname 
                            AND sexList.dicttype = 'bas_sex'
                            AND sexList.father_id <> 0
                            LEFT JOIN bas_doctor ON inhospital.doctor_id = bas_doctor.id
                            LEFT JOIN bas_depart ON inhospital.depart_id = bas_depart.id
                            LEFT JOIN bas_patienttype ON inhospital.bas_patienttype_id = bas_patienttype.id
                            LEFT JOIN bas_sickroom ON inhospital.sickroom_id = bas_sickroom.id
                            LEFT JOIN bas_sickbed ON inhospital.sickbed_id = bas_sickbed.id
                            WHERE
	                            1 = 1 and inhospital.status in ('REG','BREG') AND sexList.NAME = '女' "
                      + (!string.IsNullOrEmpty(name) ? (" and  inhospital.name like " + DataTool.addFieldBraces("%" + name + "%")) : "")
                      + (!string.IsNullOrEmpty(ihspcode) ? (" and inhospital.ihspcode = " + DataTool.addFieldBraces(ihspcode)) : "")
                      + (!string.IsNullOrEmpty(depart) ? (" and bas_depart.name =" + DataTool.addFieldBraces(depart)) : "")
                      + (!string.IsNullOrEmpty(hspcard) ? (" and inhospital.hspcard= " + DataTool.addFieldBraces(hspcard)) : "");
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                sql += " and inhospital.indate >= " + DataTool.addFieldBraces(startTime) + " and inhospital.indate<=" + DataTool.addFieldBraces(endTime);
            }
            sql += " order by id desc";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getxse(int id)
        {
            string sql_xse = @" SELECT id,name,case when sex = 'W' then '女' when sex = 'M' then '男' end as sex ,birthday,birthtime,weight,height,recorddate,isihsp FROM emr_neonate WHERE ihsp_id = " + id;
            DataTable dt = BllMain.Db.Select(sql_xse).Tables[0];
            return dt;
        }
        public DataTable getxsexx(string id, string brid)
        {
            string sql_xse = @" SELECT id,(select inhospital.ihspcode from inhospital where inhospital.id = emr_neonate.ihsp_id) as zyh,(select inhospital.name from inhospital where inhospital.id = emr_neonate.ihsp_id) as mqname,name,case when sex = 'W' then '女' when sex = 'M' then '男' end as sex ,birthday,birthtime,weight,height,recorddate,isihsp FROM emr_neonate WHERE 1 = 1"
                               + (!string.IsNullOrEmpty(id) ? (" and id = " + DataTool.addFieldBraces(id)) : "")
                               + (!string.IsNullOrEmpty(brid) ? (" and ihsp_id = " + DataTool.addFieldBraces(brid)) : "");
            DataTable dt = BllMain.Db.Select(sql_xse).Tables[0];
            return dt;
        }
        public DataTable getHisNetPayInfo(string ihsp_id)
        {
            string sql = "select inhospital.ihspcode"
                    + ",inhospital.name as ihspname"
                    + ",bas_depart.name as departname"
                    + ",inhospital.hspcard"
                    + ",inhospital.id"
                    + ",ihsp_info.homephone"
                    + ",inhospital.prepamt"
                    + ",inhospital.feeamt"
                    + " from inhospital "
                    + " left join ihsp_info  on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'"
                    + " left join bas_depart on inhospital.depart_id=bas_depart.id "
                    + " where inhospital.id= " + DataTool.addFieldBraces(ihsp_id);

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 护士网络支付
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="chk_authCode"></param>
        /// <param name="netpaytype"></param>
        /// <param name="payfee"></param>
        /// <param name="operid"></param>
        /// <param name="mesg"></param>
        /// <returns></returns>
        public bool doNursPayinadvNetPay(string ihsp_id, string chk_authCode, string bas_paytype_id, string payfee, string operid, ref string mesg)
        {
            bool ret = true;
            string currDate = BillSysBase.currDate();

            DataTable dt = getHisNetPayInfo(ihsp_id);
            NetPayIn netPayIn = new NetPayIn();
            NetPayOut netPayOut = new NetPayOut();
            NetpayBll netpayBll = new NetpayBll();
            string netpaytype = netpayBll.getNetPaytype(bas_paytype_id);
            if (netpaytype == "-1")
            {
                mesg = "请选择网络支付";
                return false;
            }
            string hisOrderNo = "";
            //string chk_authCode = tbx_authCode.Text.Trim();
            if (chk_authCode.Length < 18)
            {
                mesg = "扫码失败，请重新扫码，后重新支付";
                return false;
            }
            if (chk_authCode.Length > 18)
            {
                chk_authCode = chk_authCode.Substring(0, 18);
            }

            netPayIn.AuthCode = chk_authCode;
            netPayIn.Czyh = operid;
            netPayIn.StoreId = "2";
            hisOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
            netPayIn.OuterOrderNo = hisOrderNo;
            netPayIn.Paytype = netpaytype;
            netPayIn.Subject = "预付款";
            netPayIn.Ddlx = "3";//订单类型（默认1）：1挂号；2缴费；3预交金 
            netPayIn.Ddly = "2";//订单来源（默认1）：1门诊;2住院
            netPayIn.Hzxm = dt.Rows[0]["ihspname"].ToString();
            netPayIn.Lxdh = dt.Rows[0]["homephone"].ToString();
            //  netPayIn.Sfzh = idcard;
            netPayIn.Ysje = payfee;
            netPayIn.Ksmc = dt.Rows[0]["departname"].ToString();
            NetpayRetRes netpayRetRes = Netpay.execNetPay(netPayIn, netPayOut);

            NetPayData netPayData = new NetPayData();
            netPayData.AppCode = netPayIn.AppCode;
            netPayData.Czyh = netPayIn.Czyh;
            netPayData.Ddlx = netPayIn.Ddlx;
            netPayData.Ddly = netPayIn.Ddly;
            netPayData.InnerOrderNo = netPayOut.InnerOrderNo;
            netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
            netPayData.Jyrq = currDate;
            netPayData.Ksmc = netPayIn.Ksmc;
            netPayData.MerchantId = netPayIn.MerchantId;
            netPayData.MerId = netPayIn.MerId;
            netPayData.OrgCode = netPayIn.OrgCode;
            netPayData.OuterOrderNo = netPayIn.OuterOrderNo;
            netPayData.Paytype = netPayIn.Paytype;
            netPayData.SourceOuterOrderNo = "";
            netPayData.StoreId = netPayIn.StoreId;
            netPayData.TradeNo = netPayOut.TradeNo;
            netPayData.Ysje = netPayIn.Ysje;
            netPayData.Hzxm = netPayIn.Hzxm;
            netPayData.Sfzh = netPayIn.Sfzh;
            netPayData.Lxdh = netPayIn.Lxdh;
            netPayData.Yymc = ProgramGlobal.HspName;
            netPayData.Zfzt = "1"; //成功
            netPayData.Ihsp_id = ihsp_id;
            netpayBll.saveToDb(netPayData);
            if (netpayRetRes.Errcode > 0)
            {
                mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                netPayData.Zfzt = "0";//失败

                return false;
            }
            if (netpayRetRes.Errcode < 0)
            {
                netPayData.Zfzt = "-1";//失败[支付不确定]

                mesg = "订单号:[" + netPayIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                return false;
            }
            if (netpayRetRes.Errcode == 0)
            {
                mesg = "订单号:[" + netPayIn.OuterOrderNo + "]支付成功";
            }
            Ihsppayinadv ihsppayinadv = new Ihsppayinadv();
            ihsppayinadv.Id = BillSysBase.nextId("ihsp_payinadv");
            ihsppayinadv.Billcode = BillSysBase.newBillcode("ihsp_payinadv_billcode");
            ihsppayinadv.Ihsp_id = ihsp_id;
            ihsppayinadv.Paytype = bas_paytype_id;
            ihsppayinadv.Cheque = "";
            ihsppayinadv.Num = "1";
            ihsppayinadv.Payman = "";
            ihsppayinadv.Prepamt = dt.Rows[0]["prepamt"].ToString();
            ihsppayinadv.Feeamt = dt.Rows[0]["feeamt"].ToString();
            ihsppayinadv.Payfee = payfee;
            ihsppayinadv.Status = IhspPayinadvStatus.CHRG.ToString();
            ihsppayinadv.Depart = ProgramGlobal.Depart_id;
            ihsppayinadv.Chargedby = ProgramGlobal.User_id;
            ihsppayinadv.HisOrderNo = hisOrderNo;
            ihsppayinadv.Chargedate = currDate;
            ihsppayinadv.Ihsp_payinadv_id = null;
            ihsppayinadv.Netpay_store_id = "2";
            string sql = inhspPay(ihsppayinadv);
            if (doExeSql(sql) == -1)
            {
                mesg = " 网络支付成功,系统交预付款失败,请及时撤销网络支付单";
                return false;
            }
            BillSysBase.doIhspAmt(ihsp_id);
            mesg = "交预付款成功,请保留电子凭证";
            return ret;
        }
        /// <summary>
        /// 交预交款
        /// </summary>
        /// <returns></returns>
        public string inhspPay(Ihsppayinadv ihsppayinadv)
        {
            string sql = "insert into ihsp_payinadv(id"
                            + ",billcode"
                            + ",ihsp_id"
                            + ",bas_paytype_id"
                            + ",bas_paysumby_id"
                            + ",cheque"
                            + ",num"
                            + ",payman"
                            + ",payfee"
                            + ",feeamt"
                            + ",prepamt"
                            + ",status"
                            + ",ihsp_payinadv_id"
                            + ",depart_id"
                            + ",hisOrderNo"
                            + ",netpay_store_id"
                            + ",chargedby"
                            + ",chargedate)values(" + DataTool.addFieldBraces(ihsppayinadv.Id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Billcode)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Ihsp_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Paytype)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Bas_paysumby_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Cheque)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Num)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Payman)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Payfee)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Feeamt)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Prepamt)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Status)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Ihsp_payinadv_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Depart)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.HisOrderNo)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Netpay_store_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Chargedby)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Chargedate)
                                                 + ");";

            if (!string.IsNullOrEmpty(ihsppayinadv.HisOrderNo))
            {
                sql += "update netpaydata set hisstat = 1 where outerOrderNo=" + DataTool.addFieldBraces(ihsppayinadv.HisOrderNo) + ";";
            }
            return sql;
        }
        public string getbaspaysumbyid(string bas_paytype_id)
        {
            string sql = "select id from bas_paysumby where bas_paytype_id = " + bas_paytype_id + ";";
            return BllMain.Db.Select(sql).Tables[0].Rows[0]["id"].ToString();
        }
        /// <summary>
        /// 退预交款
        /// </summary>
        /// <returns></returns>
        public string inhspReturnPay(Ihsppayinadv ihsppayinadv)
        {
            string sql = "insert into ihsp_payinadv(id"
                            + ",billcode"
                            + ",ihsp_id"
                            + ",bas_paytype_id"
                             + ",bas_paysumby_id"
                            + ",cheque"
                            + ",num"
                            + ",payman"
                            + ",payfee"
                            + ",feeamt"
                            + ",prepamt"
                            + ",status"
                            + ",ihsp_payinadv_id"
                            + ",depart_id"
                            + ",hisOrderNo"
                            + ",chargedby"
                            + ",chargedate)values(" + DataTool.addFieldBraces(ihsppayinadv.Id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Billcode)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Ihsp_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Paytype)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Bas_paysumby_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Cheque)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Num)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Payman)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Payfee)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Feeamt)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Prepamt)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Status)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Ihsp_payinadv_id)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Depart)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.HisOrderNo)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Chargedby)
                                                 + "," + DataTool.addFieldBraces(ihsppayinadv.Chargedate)
                                                 + ");";

            if (!string.IsNullOrEmpty(ihsppayinadv.HisOrderNo))
            {
                sql += "update netpaydata set hisstat = 1 where outerOrderNo=" + DataTool.addFieldBraces(ihsppayinadv.HisOrderNo) + ";"
                    + "update netpaydata set isCancel = 1 where outerOrderNo=" + DataTool.addFieldBraces(ihsppayinadv.SourceHisOrderNo) + ";";
            }
            //Inhsopital 表汇总
            sql += " update inhospital set  prepamt= (select SUM(payfee)from ihsp_payinadv where ihsp_id=" + DataTool.addFieldBraces(ihsppayinadv.Ihsp_id) + " and settled='N'),balanceamt = (prepamt - feeamt), nustmpamt = (balanceamt + insurefee + insuraccountfee) where id=" + DataTool.addFieldBraces(ihsppayinadv.Ihsp_id) + ";";
            return sql;
        }

        /// <summary>
        /// 缴费添加后的查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable paySearch(string ihsp_id, string ihspStatus)
        {
            string sql = "select ihsp_payinadv.billcode"
                      + ",ihsp_payinadv.payfee"
                      + ",sys_dict.name as paytypename"
                      + ",ihsp_payinadv.cheque"
                      + " ,CASE"
                      + " WHEN ihsp_payinadv.status='RET' THEN '退费'"
                      + " WHEN ihsp_payinadv.status='RREC' THEN '红冲'"
                      + " WHEN ihsp_payinadv.status='CHRG' THEN '计费'"
                      + " END as status"
                      + ",bas_doctor.name as doctorname"
                      + ",ihsp_payinadv.chargedate"
                      + ",ihsp_payinadv.id"
                      + ",ihsp_payinadv.ihsp_id"
                      + " from ihsp_payinadv "
                      + " left join inhospital on ihsp_payinadv.ihsp_id=inhospital.id "
                      + " left join sys_dict on ihsp_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype' and sys_dict.father_id<>0"
                      + " left join bas_doctor on ihsp_payinadv.chargedby=bas_doctor.id "
                      + " where ihsp_payinadv.ihsp_id=" + DataTool.addFieldBraces(ihsp_id)
                      + (ihspStatus.Equals("SETT") ? "" : " and settled='N'");
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 预交款撤销/重打获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable retSearch(string id)
        {
            string sql = "select ihsp_payinadv.payman"
                      + ",bas_doctor.name as chargedby"
                      + ",ihsp_payinadv.payfee"
                      + ",sys_dict.name as paytype"
                      + ",ihsp_payinadv.bas_paytype_id"
                      + ",ihsp_payinadv.cheque"
                      + ",ihsp_payinadv.depart_id"
                      + ",ihsp_payinadv.billcode"
                      + ",ihsp_payinadv.hisOrderNo"
                      + " from ihsp_payinadv "
                      + " LEFT JOIN sys_dict on sys_dict.sn=ihsp_payinadv.bas_paytype_id and dicttype='bas_paytype' and sys_dict.father_id<>0"
                      + " left join bas_doctor on bas_doctor.id=ihsp_payinadv.chargedby"
                      + " where ihsp_payinadv.id = " + DataTool.addFieldBraces(id)
                      + " order by ihsp_payinadv.chargedate DESC"
                      ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 撤销时修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string upPayStatus(string id)
        {
            string sql = "update ihsp_payinadv set status='RET' where id=" + DataTool.addIntBraces(id) + ";";
            return sql;

        }
        /// <summary>
        /// 更新预交款单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int upPayBill(string id, string billcode)
        {
            string sql = "update ihsp_payinadv set billcode=" + DataTool.addFieldBraces(billcode) + " where id=" + DataTool.addIntBraces(id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 入院回退时修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int upOutStatus(string id)
        {
            string sql = "update inhospital set ihspcode=CONCAT('X',ihspcode), status='XX', enterdep='OO' where id=" + DataTool.addIntBraces(id) + "; delete from ihsp_info where ihsp_id = " + DataTool.addFieldBraces(id) + " and registkind='IHSP';";
            return BllMain.Db.Update(sql);
        }


        /// <summary>
        /// 根据科室查询科室内所有医生信息
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public DataTable getAllDoctorByDepart(string depart)
        {
            string sql = "select "
               + " bas_doctor.id"
               + ",bas_doctor.name"
               + " from "
               + " bas_doctor "
               + " left join bas_doctor_depart on bas_doctor_depart.doctor_id=bas_doctor.id "
               + " where "
               + " bas_doctor.isstop='N' ";
            if (depart != "0")
            {
                sql += " and bas_doctor_depart.depart_id=" + DataTool.addFieldBraces(depart);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        ///根据id或者外键， 获取医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable doctorNameGet(string depart)
        {
            string sql = "select "
               + " bas_doctor.id"
               + ",bas_doctor.name"
               + " from "
               + " bas_doctor "
               + " left join bas_doctor_depart on bas_doctor_depart.doctor_id=bas_doctor.id "
               + " where "
               + " bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='DOCTOR') ";
            if (depart != "0")
            {
                sql += " and bas_doctor_depart.depart_id=" + DataTool.addFieldBraces(depart);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 担保窗口担保
        /// </summary>
        /// <param name="ihspid"></param>
        /// <param name="depart"></param>
        /// <returns></returns>
        public int inGua(Ihspguaranfee ihspguaranfee)
        {
            string sql = "insert into ihsp_guaranfee(id"
                                                  + ",ihsp_id"
                                                  + ",depart_id"
                                                  + ",doctor_id"
                                                  + ",enddate"
                                                  + ",amt"
                                                  + ",memo"
                                                  + ",kind"
                                                  + ",createdby,createdate)values(" + DataTool.addFieldBraces(ihspguaranfee.Id)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Ihspid)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Depart)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Doctor)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Enddate)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Amt)
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Memo)
                                                                        + "," + DataTool.addFieldBraces("Y")
                                                                        + "," + DataTool.addFieldBraces(ihspguaranfee.Createdby)
                                                                        + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                                                                        + ");";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 查询担保金额表
        /// </summary>
        /// <returns></returns>
        public DataTable guaSearch(string ihsp_id)
        {
            string sql = "select inhospital.ihspcode"
                      + ",inhospital.name as ihsp_name"
                      + ",bas_doctor.name as doctor_name"
                      + ",bas_depart.name as depart_name"
                      + ",ihsp_guaranfee.amt"
                      + ",ihsp_guaranfee.enddate"
                      + ",ihsp_guaranfee.id,ihsp_guaranfee.delstat "
                      + " from ihsp_guaranfee "
                      + " left join inhospital on ihsp_guaranfee.ihsp_id=inhospital.id "
                      + " left join bas_depart on ihsp_guaranfee.depart_id=bas_depart.id "
                      + " left join bas_doctor on ihsp_guaranfee.doctor_id=bas_doctor.id "
                      + " where ihsp_guaranfee.ihsp_id= " + DataTool.addFieldBraces(ihsp_id)
                      + " order by ihsp_guaranfee.createdate DESC"
                      ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 撤销担保
        /// </summary>
        /// <param name="selectOne"></param>
        /// <returns></returns>
        public int guaBtnRet(string id)
        {
            string sql = "UPDATE ihsp_guaranfee set canceltime = '" + DateTime.Now.ToString() + "',cance_cxr = '" + ProgramGlobal.Account_id + "',delstat = 'Y' where id = " + DataTool.addFieldBraces(id);
            return BllMain.Db.Update(sql);
        }



        /// <summary>
        /// 获取汇总费用
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string getIhspFeeamt(string ihsp_id)
        {
            string sql = "select SUM(fee) as sumfee from ihsp_costdet where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["sumfee"].ToString();
            }
            return "0";
        }

        /// <summary>
        /// 汇总药品费用
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string getIhspDrugamt(string ihsp_id)
        {
            string sql = "select SUM(fee) as sumfee from ihsp_costdet where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and itemfrom = 'DRUG'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["sumfee"].ToString();
            }
            return "0";
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
        /// 打印腕带所需信息
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <returns></returns>
        public DataTable GetWdxx(String Mtzyjl_iid)
        {
            String sql = " select inhospital.ihspcode as zyh"//住院号
                    + ",inhospital.name as hzxm"//姓名
                    + ",sexList.name as xb"//性别
                    + ",inhospital.birthday as dob"//生日
                    + ",inhospital.indate as zyjlrysj "//入院时间
                    + " from inhospital "
                    + " left join sys_dict as sexList on inhospital.sex = sexList.keyname and sexList.dicttype = 'bas_sex' and sexList.father_id <> 0 "
                    + " where inhospital.id=" + Mtzyjl_iid + ";";
            return BllMain.Db.Select(sql).Tables[0];
        }

        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e) { }
            if (result < 0)
            {
                LogUtils.writeFileLog("住院HIS", "结算sql:" + sql);
            }
            return result;
        }
        public int getIhspsnByIdcard(string idcard)
        {
            string sql = "select count(ihsp_id) as idsum from ihsp_info where idcard =" + DataTool.addFieldBraces(idcard) + " and registkind='IHSP';";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string idsum = dt.Rows[0]["idsum"].ToString();
            int ret = DataTool.stringToInt(idsum);
            return ret;
        }

        /// <summary>
        /// 获取PaysumbyId
        /// </summary>
        /// <param name="PaytypeId"></param>
        /// <returns></returns>
        public string getPaysumby(string PaytypeId)
        {
            string sql = " SELECT id from bas_paysumby WHERE bas_paysumby.bas_paytype_id =" + DataTool.addFieldBraces(PaytypeId);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["id"].ToString();
            return ret;
        }

        /// <summary>
        /// 查询住院状态
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string getIhspStatus(string ihsp_id)
        {
            string sql = "select status from inhospital where id=" + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["status"].ToString();
        }
    }
}