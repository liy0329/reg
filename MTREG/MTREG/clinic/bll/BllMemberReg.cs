using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTREG.clinic.bo;
using MTHIS.common;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class BllMemberReg
    {
        /// <summary>
        /// 包含空选项的支付类型下拉列表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypeListWithNull()
        {
            DataTable dt = new DataTable();
            string sql = " "
                        + "select sn as id,name from sys_dict"
                        + " where father_id<>0 "
                        + " and dicttype='bas_paytype'"
                        + " and keyname in ("
                        + DataTool.addFieldBraces(BasPaytypeKeyname.ALIPAY.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.WECHAT.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.CASHFEE.ToString())
                //+ "," + DataTool.addFieldBraces(BasPaytypeKeyname.CYBERPAY.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.UNIONPAY.ToString())
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

        /// <summary>
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select sn as id,name from sys_dict"
                        +" where father_id<>0 "
                        +" and dicttype='bas_paytype'"
                        + " and keyname in ("
                        + DataTool.addFieldBraces(BasPaytypeKeyname.ALIPAY.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.WECHAT.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.CASHFEE.ToString())
                        //+ "," + DataTool.addFieldBraces(BasPaytypeKeyname.CYBERPAY.ToString())
                        + "," + DataTool.addFieldBraces(BasPaytypeKeyname.UNIONPAY.ToString())
                        +")";
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
        public DataTable getRegisterById(String today)
        {

            DataTable dt = new DataTable();
            String sql = "select register.id "
                       + ", register.billcode"
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
                       + " and register.prepaid='Y'"
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
        /// <summary>
        /// 插入挂号记录表
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public string inRegister(Register register, string member_id)
        {
            string sql = "insert into register ( "
                       + "id"
                       + ", billcode"
                       + ", regdate"
                       + ", bas_patienttype_id"
                       + ", prepaid"
                       + ", reg_level_id"
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
                       + ", updatetime ) values("
                       + DataTool.addFieldBraces(register.Id)
                       + "," + DataTool.addFieldBraces(register.Billcode)
                       + "," + DataTool.addFieldBraces(register.Regdate)
                       + "," + DataTool.addFieldBraces(register.Bas_patienttype_id)
                       + "," + DataTool.addFieldBraces("Y")
                       + "," + DataTool.addFieldBraces(register.Reg_level_id)
                       + "," + DataTool.addFieldBraces(register.Healthcard)
                       + "," + DataTool.addFieldBraces(register.Sys_region_id)
                       + "," + DataTool.addFieldBraces(register.Reg_regclass_id)
                       + "," + DataTool.addFieldBraces(register.Urgent)
                       + "," + DataTool.addFieldBraces(register.Doctor_id)
                       + "," + DataTool.addFieldBraces(register.Depart_id)
                       + "," + DataTool.addFieldBraces(register.Users_id)
                       + "," + DataTool.addFieldBraces(register.Amount)
                       + "," + DataTool.addFieldBraces(register.Status)
                       + "," + DataTool.addFieldBraces(register.Isarchive)
                       + "," + DataTool.addFieldBraces(member_id)
                       + "," + DataTool.addFieldBraces(register.Hspcard)
                       + "," + DataTool.addFieldBraces(register.Name)
                       + "," + DataTool.addFieldBraces(register.Pincode)
                       + "," + DataTool.addFieldBraces(register.Sex)
                       + "," + DataTool.addFieldBraces(register.Birthday)
                       + "," + DataTool.addFieldBraces(register.Age)
                       + "," + DataTool.addFieldBraces(register.Ageunit)
                       + "," + DataTool.addFieldBraces(register.Moonage)
                       + "," + DataTool.addFieldBraces(register.Moonageunit)
                       + "," + DataTool.addFieldBraces(register.Createtime)
                       + "," + DataTool.addFieldBraces(register.Regdate)
                       + "," + DataTool.addFieldBraces(register.Updatetime)
                       + " );";
            return sql;
        }
        public string inIhspInfo(IhspInfo ihspInfo)
        {
            string sql = "insert into ihsp_info("
                                    + "id"
                                    + ",ihsp_id"
                                    + ",registkind"
                                    + ",idcard"
                                    + ",profession"
                                    + ",profession_id"
                                    + ",homeaddress"
                                    + ",hmstreetname"
                                    + ",hmhouseNumber"
                                    + ",homephone"
                                    + " ) values ("
                                    + DataTool.addFieldBraces(ihspInfo.Id)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Ihsp_id)
                                    + "," + DataTool.addFieldBraces("CLIN")
                                    + "," + DataTool.addFieldBraces(ihspInfo.Idcard)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Profession)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Profession_id)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homeaddress)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Hmstreetname)
                                    + "," + DataTool.addFieldBraces(ihspInfo.HmhouseNumber)
                                    + "," + DataTool.addFieldBraces(ihspInfo.Homephone)
                                    + " );";
            return sql;
        }
        /// <summary>
        /// 添加会员表
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public string addMemberItem( Member member)
        {
            string sql = "insert into member ( "
                            + "id"
                            + ", name"
                            + ", pincode"
                            + ", sex"
                            + ", birthday"
                            + ", hspcard"
                            + ", usehspcard"
                            + ", race"
                            + ", race_id"
                            + ", homeaddress"
                            + ", hmstreetname"
                            + ", hmhouseNumber"
                            + ", idcard"
                            + ", profession"
                            + ", profession_id"
                            + ", mobile"
                            + ", companyname"
                            + ", cardstat"
                            + ", createdate"
                            + ", createdby) values("
                            + DataTool.addFieldBraces(member.Id)
                            + "," + DataTool.addFieldBraces(member.Name)
                            + "," + DataTool.addFieldBraces(member.Pincode)
                            + "," + DataTool.addFieldBraces(member.Sex)
                            + "," + DataTool.addFieldBraces(member.Birthday)
                            + "," + DataTool.addFieldBraces(member.Hspcard)
                            + "," + DataTool.addFieldBraces("Y")
                            + "," + DataTool.addFieldBraces(member.Race)
                            + "," + DataTool.addFieldBraces(member.Race_id)
                            + "," + DataTool.addFieldBraces(member.Homeaddress)
                            + "," + DataTool.addFieldBraces(member.Hmstreetname)
                            + "," + DataTool.addFieldBraces(member.HmhouseNumber)
                            + "," + DataTool.addFieldBraces(member.Idcard)
                            + "," + DataTool.addFieldBraces(member.Profession)
                            + "," + DataTool.addFieldBraces(member.Profession_id)
                            + "," + DataTool.addFieldBraces(member.Mobile)
                            + "," + DataTool.addFieldBraces(member.Companyname)
                            + "," + DataTool.addFieldBraces("YES")
                            + "," + DataTool.addFieldBraces(member.Createdate)
                            + "," + DataTool.addFieldBraces(member.Createdby)
                            + " );";
            return sql;
        }

        /// <summary>
        /// 插入收费主表
        /// </summary>
        /// <param name="clinicCost"></param>
        /// <returns></returns>
        public string  addClinic_costItem(ClinicCost clinicCost)
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
                       + "," + DataTool.addFieldBraces(CostRcpType.REG.ToString())
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
            return sql;
        }

        /// <summary>
        /// 插入明细
        /// </summary>
        /// <param name="cliniCostdet"></param>
        /// <param name="clinic_costdet_ids"></param>
        /// <returns></returns>
        public string addClinic_costDetItem(CliniCostdet cliniCostdet)
        {
            string sql = "insert into clinic_costdet ( "
                           + " id"                      //主键
                           + ",clinic_cost_id"          //收费主表外键
                           + ",regist_id"               //挂号编号外键
                           + ",standcode"               //统一编码
                           + ",item_id"                 //外键项目  隐式外键
                           + ",itemfrom"                //项目定义类型
                           + ",rcptype"                 //费用种类
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
                           + ",settled"
                           + ",unlocked"       //N
                           + ",retappstat"      //N
                           + ",member_rechargedet_id"  
                           + " ) values ("
                           + DataTool.addFieldBraces(cliniCostdet.Id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Clinic_cost_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Regist_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Standcode)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Item_id)
                           + "," + DataTool.addFieldBraces(cliniCostdet.Itemfrom)
                           + "," + DataTool.addFieldBraces(CostRcpType.REG.ToString())
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
                           + "," + DataTool.addFieldBraces("N")
                           + "," + DataTool.addFieldBraces(cliniCostdet.Member_rechargedet_id)
                           + " ) ; ";
            return sql;
        }

        /// <summary>
        /// 插入会员卡内余额表
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public string inMember_balance(string member_id,string balance)
        {
            string id=BillSysBase.nextId("member_balance");
            string sql = "insert into member_balance(id"
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
            return sql;
        }

        /// <summary>
        /// 更新卡内余额
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public string upMember_balance(string member_id, string balance)
        {
            string sql = "update member_balance set balance=" + DataTool.addFieldBraces(balance)
                        + ", available=" + DataTool.addFieldBraces(balance)
                        + " where bas_member_id=" + DataTool.addIntBraces(member_id)+";";
            return sql;
        }

        /// <summary>
        /// 插入会员充值记录表
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="opertype"></param>
        /// <param name="amount"></param>
        /// <param name="bas_paytype_id"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public string inMember_rechargedet(string member_id,string opertype,string amount, string bas_paytype_id, string balance,ref string id)
        {
            id=BillSysBase.nextId("member_rechargedet");
            string billcode=BillSysBase.newBillcode("member_rechargedet_billcode");
            string sql = "insert into member_rechargedet(id"
                + ",bas_member_id"
                + ",billcode"
                + ",opertype"
                + ",amount"
                + ",bas_paytype_id"
                + ",settled"
                + ",balance"
                + ",depart_id"
                + ",operator"
                + ",operatdate)values(" + DataTool.addIntBraces(id)
                + "," + DataTool.addIntBraces(member_id)
                + "," + DataTool.addFieldBraces(billcode)
                + "," + DataTool.addFieldBraces(opertype)
                + "," + DataTool.addFieldBraces(amount)
                + "," + DataTool.addIntBraces(bas_paytype_id)
                + "," + DataTool.addFieldBraces("N")
                + "," + DataTool.addFieldBraces(balance)
                + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
                + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                + ");";

            return sql;
        }

        /// <summary>
        /// 获取支付方式sn
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaytypeId(string keyname)
        {
            string sql = "select sn from sys_dict where dicttype='bas_paytype' and father_id<>0 and keyname="+DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["sn"].ToString();
        }
    }
}
