using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.clinic.bll
{
    class BllFrxPrintInvoice
    {

        public bool isRegisterInvoice(string clinic_invoice_id)
        {
            bool ret = false;
             
            DataTable dt = null;
            string sql = "select isregist from clinic_invoice where id = "+DataTool.addFieldBraces(clinic_invoice_id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                string isregist = dt.Rows[0]["isregist"].ToString();
                if (isregist.Trim() == "1")
                    ret = true;
            }
            catch (Exception ex)
            { 
                
            }
            return ret;
        }

        public DataTable getInvoice(string clinic_invoice_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " clinic_invoice.billcode as billcode"//时间
                       + ", register.name as patientname"//姓名
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"//性别
                       + ",cost_insurtype.keyname as patienttypekeyname"
                       + ",rcp_depart.`name` as rcpdepart" //科室
                       + ",exe_depart.`name` as exedepart" //科室
                       + ",bas_doctor.`name` as chargeby" //收费员姓名
                       + ",clinic_invoice.chargedate as chargedate"//时间
                       + ",clinic_invoice.realfee as amt"//总费用
                       + ",clinic_invoice.invoice as invoice "//发票号
                       + ",bas_paytype.name as paytypename"//收费时间
                       + ",(select clinicdiagn from  clinic_record where regist_id = clinic_invoice.regist_id limit 1) as clinicdiagn " //门诊诊断
                       + ",register.billcode as regbillcode" //门诊号
                       + " from clinic_invoice left join bas_patienttype on clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left  join cost_insurtype on bas_patienttype.cost_insurtype_id=cost_insurtype.id "
                       + " left join bas_depart rcp_depart on clinic_invoice.rcpdep_id = rcp_depart.id"
                       + " left join bas_depart exe_depart on clinic_invoice.exedep_id = exe_depart.id"
                       + " left join bas_doctor on bas_doctor.id =clinic_invoice.chargeby"
                       + " left join sys_dict bas_paytype on bas_paytype.sn = clinic_invoice.bas_paytype_id"
                       + " left join register on clinic_invoice.regist_id = register.id"
                       + " left join clinic_record on clinic_record.regist_id = register.id"
                       + " where clinic_invoice.id = " + DataTool.addFieldBraces(clinic_invoice_id)
                       + " and bas_paytype.dicttype='bas_paytype'";
             
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 挂号获取发票信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <returns></returns>
        public DataTable getRegInvoiceInfo(string clinic_invoice_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " register.name as patientname"//患者姓名
                       + ",register.id as registerid"//流水号
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_patienttype.`name` as patienttype"//医保类别
                       + ",clinic_invoice.bas_patienttype_id AS patienttype_id"//医保类型id
                       + ",bas_depart.`name` as departname"//科室名称
                       + ",bas_doctor.`name` as chargeby"//收费员
                       + ",doctor.name as doctorname"//医生名
                       + ",clinic_invoice.chargedate as chargedate"//收费时间
                       + ",bas_paytype.name as paytypename"//收费时间
                       + ",clinic_invoice.realfee as amt"//金额
                       + ",clinic_invoice.invoice as invbillcode "//发票号
                       + ",clinic_invoice.chargeby  as chargeby_id"//收费员id
                       + ",register.billcode as regbillcode"//门诊号
                       + ",register.clinicroom"//诊室名称
                       + ",register.regnum"//流水号
                       + ",member.hspcard"
                       + " from clinic_invoice left join bas_patienttype on clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left join bas_depart on clinic_invoice.rcpdep_id = bas_depart.id"
                       + " left join bas_doctor on bas_doctor.id = clinic_invoice.chargeby"
                       + " left join bas_doctor as doctor on doctor.id=clinic_invoice.rcpdoctor_id"
                       + " left join sys_dict bas_paytype on bas_paytype.sn = clinic_invoice.bas_paytype_id"
                       + " left join register on clinic_invoice.regist_id = register.id"
                       + " left join member on register.member_id = member.id"
                       + " where clinic_invoice.id = " + DataTool.addFieldBraces(clinic_invoice_id)
                       + " and bas_paytype.dicttype='bas_paytype'";
           
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询市医保挂号发票信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <returns></returns>
        public DataTable getGysybRegInvoiceInfo(string clinic_invoice_id)
        {
            DataTable dt = null;
            string sql = "select "
                    + " grzhzf" //个人账户支付
                    + ",grzhye"//本次个人账户支付后帐户余额
                    + ",jjtczf"//基本统筹支付
                    + ",ylbzzf"//医疗补助支付
                    + ",detczf"//大额补助支付
                    + ",grbh"//个人编号
                    + ",zflb"//支付类别
                    + ",bxlb"//保险类别
                    + ",bndptmzylbzqfx"//门诊补助起付线
                    + ",ptmzylbzlj"//门诊补助累计
                    + " from gysyb_mz"
                    + " where gysyb_mtmzblstuff_iid=" + DataTool.addFieldBraces(clinic_invoice_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询异地医保挂号发票信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <returns></returns>
        public DataTable getGzsybRegInvoiceInfo(string clinic_invoice_id)
        {
            DataTable dt = null;
            string sql = "select "
                    + " yka065"//个人账户支付
                    + ",akc087"//本次个人账户支付后帐户余额
                    + ",yka058"//本次起付线
                    + ",yka248"//本次基本医疗报销金额
                    + ",yke030"//公务员报销金额
                    + ",yka062"//本次大病医疗报销金额
                    + ",yab139"//所属社保机构编码
                    + ",aac001"//个人编号
                    + ",yka368"//门诊补助起付线
                    + ",yke025"//门诊补助累计
                    + " from gzsyb_mzfyb"
                    + " where mtmzblstuffiid=" + DataTool.addFieldBraces(clinic_invoice_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public string getDoctorName(string clinic_invoice_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " bas_doctor.name as name"//医生姓名   
                       + " from clinic_invoice"
                       + " left join bas_doctor on bas_doctor.id = clinic_invoice.rcpdoctor_id"
                       + " where clinic_invoice.id = " + DataTool.addFieldBraces(clinic_invoice_id);

            dt = BllMain.Db.Select(sql).Tables[0];

            return dt.Rows[0]["name"].ToString();
        }
        public DataTable getCostDet(string invoice_id)
        {
            DataTable dt2 = null;
            dt2 = getInvoiceCostDets(invoice_id);
            DataTable dt = null;
            string sql = "select "
                       + " clinic_costdet.name"
                       + ",clinic_costdet.num"
                       + ",clinic_costdet.fee"
                       + ",bas_depart.name as zxks"
                       + " from clinic_costdet "
                       + " left join bas_depart on bas_depart.id = clinic_costdet.exedep_id"
                       + " where clinic_costdet.clinic_invoice_id = " + DataTool.addFieldBraces(invoice_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;


        }

        /// <summary>
        /// 贵州省门诊发票信息
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable get_GZSMZ_InvoiceInfo(string invoice_id)
        {

            String sql = "select yka065,akc087,yka058,yka248,yka062,yke030,aac001,yab139,akc090, yka120, yka122, yka368, yke025, aae001, yka900,aka130 from gzsyb_mzfyb where mtmzblstuffiid ='" + invoice_id + "'";
            return BllMain.Db.Select(sql).Tables[0];
        }


        /// <summary>
        /// 门诊挂号业务查询
        /// </summary>
        /// <param name="Mtmzblstuff_iid"></param>
        /// <returns></returns>
        public DataTable get_GYSMZ_InvoiceInfo(string invoice_id)
        {
            string sql = " select grzhzf,ylbzzf,jjtczf,detczf,sbpay,grzhye,fph,bxlb,bndptmzylbzqfx,ptmzylbzqfx,ptmzylbzlj,zflb,grbh from gysyb_mz where gysyb_mtmzblstuff_iid='" + invoice_id+ "';";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 发票费用明细
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getInvoiceCostDets(string invoice_id)
        {
         
            string sql = "";
            string serch = "select rcptype from clinic_cost where clinic_cost.clinic_invoice_id=" + DataTool.addFieldBraces(invoice_id);
            string selrcp = BllMain.Db.Select(serch).Tables[0].Rows[0]["rcptype"].ToString();
            switch (selrcp)
            {
                case "CHK":
                    sql += "select chk_app.diagnsetname as name"
                        + " ,'1' as num"
                        + " ,'' as insurclass"
                        + " ,clinic_cost.recipelfee as fee "
                        + " ,bas_depart.name as zxks"
                        + " from clinic_cost"
                        + " left join chk_app on chk_app.id=clinic_cost.clinic_rcp_id"
                        + " left join bas_depart on chk_app.exedep_id = bas_depart.id"
                        + " where clinic_cost.rcptype='CHK'"
                        + " and clinic_cost.clinic_invoice_id=" + DataTool.addFieldBraces(invoice_id);
                    break;
                case "RCP":
                    sql += "select "
                        + " cost_insurcross.insurclass"
                        + ",clinic_costdet.name"
                        + ",clinic_costdet.num"
                        + ",clinic_costdet.fee"
                        + ",bas_depart.name as zxks"
                        + " from clinic_costdet,cost_insurcross,bas_depart"                    
                        + " where clinic_costdet.item_id = cost_insurcross.item_id"
                        + " and bas_depart.id = clinic_costdet.exedep_id"
                        + " and cost_insurcross.Insuritemtype='3'"                    
                        + " and clinic_costdet.clinic_invoice_id = " + DataTool.addFieldBraces(invoice_id);
                    break;
                case "REG":
                    sql += "select "                    
                     + " bas_item.name"
                     + " ,'' as insurclass"
                     + ",clinic_costdet.num"
                     + ",clinic_costdet.fee"
                     + ",bas_depart.name as zxks"
                     + " from clinic_costdet left join bas_item on bas_item.id = clinic_costdet.item_id"
                     + " left join bas_depart on bas_depart.id = clinic_costdet.exedep_id"
                     + " where clinic_costdet.clinic_invoice_id = " + DataTool.addFieldBraces(invoice_id);
                    break;
            }

            return BllMain.Db.Select(sql).Tables[0];
        }

        public DataTable getSysPrintFrmurl(int id)
        {
            string iid = id.ToString();
            DataTable dt = null;
            string sql = "select frmurl"
                       + " from sys_print"
                       + " where id = " + DataTool.addFieldBraces(iid);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getSysPrintFrmurl(string codeid)
        {
            DataTable dt = null;
            string sql = "select frmurl"
                       + " from sys_print"
                       + " where codeid = " + DataTool.addFieldBraces(codeid);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getSysPrintId(string keyname)
        {
            string sql = "select sys_clinicprint_id from cost_insurtype where keyname = "
                + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 门诊收费明细单信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <returns></returns>
        public DataTable getoutpatientFeeDetailsinfo(string clinic_invoice_id)
        {
            string sql = " SELECT "
	                   + " clinic_invoice.sickname,"
	                   + " clinic_invoice.invoice,"
	                   + " clinic_invoice.chargeby,"
	                   + " clinic_invoice.chargedate,"
	                   + " clinic_invoice.realfee,"
	                   + " bas_depart.`name` AS depart,"
	                   + " bas_doctor.`name` AS doctor"
                   + " FROM"
	                   + " clinic_invoice"
                   + " LEFT JOIN clinic_costdet ON clinic_costdet.clinic_Invoice_id = clinic_invoice.id"
                   + " LEFT JOIN bas_depart ON bas_depart.id = clinic_costdet.depart_id"
                   + " LEFT JOIN bas_doctor ON bas_doctor.id = clinic_costdet.doctor_id"
                   + " WHERE"
                       + " clinic_invoice.id = " + DataTool.addFieldBraces(clinic_invoice_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 门诊收费明细单信息明细
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getoutpatientFeeDetailsinfoDets(string invoice_id)
        {

            string sql = "";
            
            sql += "select "
                     + " bas_item.name"
                     + ",clinic_costdet.num"
                     + ",clinic_costdet.Unit"
                     + ",clinic_costdet.Prc"
                     + " from clinic_costdet left join bas_item on bas_item.id = clinic_costdet.item_id"
                     + " left join bas_depart on bas_depart.id = clinic_costdet.exedep_id"
                     + " where clinic_costdet.clinic_invoice_id = " + DataTool.addFieldBraces(invoice_id);

            return BllMain.Db.Select(sql).Tables[0];
        }

    }
}
