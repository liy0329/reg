using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTHIS.tools;
using MTREG.clinic.bo;

namespace MTREG.clinic.bll
{
    class BllClinicCostManage
    {

        public DataTable getInvoiceList(ChargeManage chargeManage)
        {
            DataTable dt = new DataTable();
            string type = IniUtils.IniReadValue(IniUtils.syspath, "FEETYPE", "TYPE");
            string sql = "select "
                       + "register.billcode as regbill"
                       + ",clinic_invoice.invoice as invbill"
                       + ",register.name as regname"
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",(select name from bas_doctor where x2.chargeby = bas_doctor.id) as outby"
                       + ",(select name from bas_doctor where clinic_invoice.rcpdoctor_id = bas_doctor.id) as ys"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.chargedate,x2.chargedate as outdate"
                       + ",register.hspcard as hspcard2,member.mzfare as hspcard"
                       + ",register.age"
                       + ",bas_patienttype. NAME AS patienttype"
                       + ",case when clinic_invoice.charged='RET' then '退费' when clinic_invoice.charged='RREC' then '红冲' when clinic_invoice.charged='CHAR' then '计费' end as charged"
                       + ",CASE WHEN clinic_invoice.ybsfsc = 0 THEN '无' WHEN clinic_invoice.ybsfsc = 201 THEN '城乡报销' WHEN clinic_invoice.ybsfsc = 301 THEN '职工报销' end as bxfs"
                       + ",clinic_invoice.isregist,clinic_invoice.ybsfsc"
                       + ",clinic_invoice.id"
                       + ",clinic_invoice.regist_id"
                       + ",clinic_invoice.bas_patienttype_id"
                       + ",ihsp_info.idcard,bas_patienttype.displaycolor,clinic_invoice.print"
                       + ",case when register.clininicpay = 'A' then '直接缴费' when register.clininicpay = 'B' then '储值卡缴费' when register.clininicpay = '' then '未知' end as paytype"
                       + " from clinic_invoice "
                       + " left join register"
                       + " on clinic_invoice.regist_id = register.id left join member on register.member_id=member.id "
                       + " left join bas_depart"
                       + " on clinic_invoice.rcpdep_id = bas_depart.id"
                       + " LEFT JOIN bas_patienttype ON clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left join bas_doctor"
                       + " on clinic_invoice.chargeby = bas_doctor.id"
                       + " left join ihsp_info on ihsp_info.ihsp_id=register.id and ihsp_info.registkind=" + DataTool.addFieldBraces(RegistKind.CLIN.ToString())
                       + "LEFT JOIN clinic_Invoice as x2 on x2.clinic_Invoice_id = clinic_invoice.id"
                       + " where clinic_invoice.chargedate>= " + DataTool.addFieldBraces(chargeManage.StartDate)
                       + " and clinic_invoice.chargedate<= " + DataTool.addFieldBraces(chargeManage.EndDate)
                       + " and clinic_invoice.charged <> " + DataTool.addFieldBraces(CostCharged.OO.ToString())
                //+ " and register.prepaid <>'Y'"
                       + " and clinic_invoice.id in (select clinic_invoice_id from clinic_costdet) ";
            if (!String.IsNullOrEmpty(chargeManage.PatientName))
                sql += "  and register.name like  '%" + chargeManage.PatientName + "%' ";
            if (!String.IsNullOrEmpty(chargeManage.HspCard))
                sql += "  and register.hspcard = " + DataTool.addFieldBraces(chargeManage.HspCard);
            if (!String.IsNullOrEmpty(chargeManage.mobile))
                sql += "  and register.member_id IN (select id from member where cardstat = 'YES' AND mobile = " + DataTool.addFieldBraces(chargeManage.mobile) + ")";
            if (chargeManage.Depart_id != "0" && chargeManage.Depart_id != "" && chargeManage.Depart_id != null)
                sql += "  and clinic_invoice.rcpdep_id = " + DataTool.addFieldBraces(chargeManage.Depart_id);
            if (chargeManage.Chargeby != "0" && chargeManage.Chargeby != "" && chargeManage.Chargeby != null)
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            if (chargeManage.Fph != "0" && chargeManage.Fph != "" && chargeManage.Fph != null)
                sql += "  and clinic_invoice.invoice = " + DataTool.addFieldBraces(chargeManage.Fph);
            if (type == "YAOFANG")
                sql += " and clinic_invoice.id IN(SELECT clinic_Invoice_id FROM clinic_costdet WHERE clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id = '90'))";
            if (type == "YISHENG")
                sql += " and clinic_invoice.id IN(SELECT clinic_Invoice_id FROM clinic_costdet WHERE clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id = '91'))";
            if (type == "KESHI")
                sql += " and clinic_invoice.id IN(SELECT clinic_Invoice_id FROM clinic_costdet WHERE clinic_costdet.exedep_id  IN (SELECT depart_id FROM bas_depart_departtype WHERE departtype_id IN ('93','94')))";

            if (!String.IsNullOrEmpty(chargeManage.Isret))
            {
                sql += "  and clinic_invoice.charged = " + DataTool.addFieldBraces(chargeManage.Isret);
            }
            if (!String.IsNullOrEmpty(chargeManage.Islock))
            {
                sql += "  and clinic_invoice.id in ";
                sql += " (select distinct clinic_Invoice_id from  clinic_costdet where  unlocked = " + DataTool.addFieldBraces(chargeManage.Islock);
                sql += " ) order by clinic_invoice.chargedate DESC";
            }
            else
            {
                sql += " order by clinic_invoice.chargedate DESC";
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

        public DataTable getInvoiceInfo(string clinic_invoice_id)
        {
            DataTable dt = new DataTable();
            string sql = "select "
                       + "register.billcode as regbill"
                       + ",clinic_invoice.invoice as invoice"
                       + ",register.name as regname"
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.chargedate"
                       + ",register.hspcard"
                       + ",register.age"
                       + ",case when clinic_invoice.charged='RET' then '退费' when clinic_invoice.charged='RREC' then '红冲' when clinic_invoice.charged='CHAR' then '计费' end as charged"
                       + ",clinic_invoice.isregist"
                       + ",clinic_invoice.id"
                       + ",clinic_invoice.regist_id"
                       + ",clinic_invoice.bas_patienttype_id"
                       + ",ihsp_info.idcard"
                       + " from clinic_invoice "
                       + " left join register"
                       + " on clinic_invoice.regist_id = register.id"
                       + " left join bas_depart"
                       + " on clinic_invoice.rcpdep_id = bas_depart.id"
                       + " left join bas_doctor"
                       + " on clinic_invoice.rcpdoctor_id = bas_doctor.id"
                       + " left join ihsp_info on ihsp_info.ihsp_id=register.id and ihsp_info.registkind=" + DataTool.addFieldBraces(RegistKind.CLIN.ToString())
                       + " where 1=1"
                       //+ " and register.prepaid <>'Y'"
                       + " and clinic_invoice.invoice = " + DataTool.addFieldBraces(clinic_invoice_id);
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
        /// 根据门诊发票号查询费用明细
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getClinicCostdet(string invoice_id)
        {
            string sql = "";

            if (string.IsNullOrEmpty(invoice_id))
            {
                sql = "select name"
                    + ",spec"
                    + ",unit,num"
                    + ",prc,fee"
                    + " from clinic_costdet"
                    + " where 1!=1";
            }
            else
            {
                sql = "select name"
                  + ",spec"
                  + ",unit,num"
                  + ",prc,fee"
                  + " from clinic_costdet"
                  + " where clinic_Invoice_id=" + DataTool.addIntBraces(invoice_id);
            }

            DataTable dt;
           
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                dt = null;

            }
            if (dt == null) return dt;
            decimal fee = 0.00M;
            int i=0;
            for (; i < dt.Rows.Count; i++)
            {

                fee += decimal.Parse(DataTool.checkDouble(dt.Rows[i]["fee"].ToString()));
            }
            string sumfee = Math.Round(fee,2).ToString();
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows[i]["name"] = "票面合计：";
            dt.Rows[i]["fee"] = sumfee;
            return dt;
        }

        public DataTable ClinicCostdets(string invoice_id)
        {
            string sql = "";

            if (string.IsNullOrEmpty(invoice_id))
            {
                sql = @"SELECT
                        clinic_costdet.id,
	                    clinic_Invoice.invoice,
	                    -- 发票号
	                    clinic_costdet. NAME,
                        clinic_costdet.yptsxx,
                        clinic_costdet.spbz,
	                    -- 名称
	                    clinic_costdet.spec,
	                    -- 规格
	                    clinic_costdet.unit,
	                    -- 单位
	                    clinic_costdet.num,
	                    -- 数量
	                    clinic_costdet.prc,
	                    -- 单价
	                    clinic_costdet.fee,
	                    -- 总费用
	                    clinic_Invoice.chargedate,
	                    -- 时间
	                    bas_depart.hiscode as kdksbm,
	                    -- 开单科室编码
	                    -- cost_insurcross.insurclass as insurclass1,
                        clinic_costdet.yblx as insurclass,
	                    -- 等级
	                    bas_item.standcode,
	                    -- 统一编码
	                    CASE
                    WHEN clinic_costdet.itemfrom = 'COST' THEN
	                    '费用'
                    WHEN clinic_costdet.itemfrom = 'DRUG' THEN
	                    '药品'
                    WHEN clinic_costdet.itemfrom = 'MSG' THEN
	                    '信息'
                    WHEN clinic_costdet.itemfrom = 'STUFF' THEN
	                    '材料'
                    END AS charged -- 种类

                    FROM
	                    clinic_costdet
                    LEFT JOIN clinic_Invoice ON clinic_Invoice.id = clinic_costdet.clinic_Invoice_id
                    LEFT JOIN bas_depart ON bas_depart.id = clinic_costdet.depart_id
                    LEFT JOIN cost_insurcross ON cost_insurcross.item_id = clinic_costdet.item_id
                    AND cost_insurcross.drug_factyitem_id = clinic_costdet.drug_factyitem_id and cost_insurcross.itemfrom = clinic_costdet.itemfrom
                    LEFT JOIN cost_insuritem ON cost_insurcross.insuritemtype = cost_insuritem.id
                    LEFT JOIN bas_item on clinic_costdet.item_id = bas_item.id
                    WHERE 1 = 1";
            }
            else
            {
                sql = @"SELECT
                        clinic_costdet.id,
	                    clinic_Invoice.invoice,
	                    -- 发票号
	                    clinic_costdet. NAME,
                        clinic_costdet.yptsxx,
                        clinic_costdet.spbz,
	                    -- 名称
	                    clinic_costdet.spec,
	                    -- 规格
	                    clinic_costdet.unit,
	                    -- 单位
	                    clinic_costdet.num,
	                    -- 数量
	                    clinic_costdet.prc,
	                    -- 单价
	                    clinic_costdet.fee,
	                    -- 总费用
	                    clinic_Invoice.chargedate,
	                    -- 时间
	                    bas_depart.hiscode as kdksbm,
	                    -- 开单科室编码
	                    -- cost_insurcross.insurclass as insurclass1,
                        clinic_costdet.yblx as insurclass,
	                    -- 等级
	                    bas_item.standcode,
	                    -- 统一编码
	                    CASE
                    WHEN clinic_costdet.itemfrom = 'COST' THEN
	                    '费用'
                    WHEN clinic_costdet.itemfrom = 'DRUG' THEN
	                    '药品'
                    WHEN clinic_costdet.itemfrom = 'MSG' THEN
	                    '信息'
                    WHEN clinic_costdet.itemfrom = 'STUFF' THEN
	                    '材料'
                    END AS charged -- 种类

                    FROM
	                    clinic_costdet
                    LEFT JOIN clinic_Invoice ON clinic_Invoice.id = clinic_costdet.clinic_Invoice_id
                    LEFT JOIN bas_depart ON bas_depart.id = clinic_costdet.depart_id
                    LEFT JOIN cost_insurcross ON cost_insurcross.item_id = clinic_costdet.item_id
                    AND cost_insurcross.drug_factyitem_id = clinic_costdet.drug_factyitem_id and cost_insurcross.itemfrom = clinic_costdet.itemfrom
                    LEFT JOIN cost_insuritem ON cost_insurcross.insuritemtype = cost_insuritem.id
                    LEFT JOIN bas_item on clinic_costdet.item_id = bas_item.id
                    WHERE
	                    clinic_costdet.clinic_Invoice_id = " + DataTool.addIntBraces(invoice_id);
            }

            DataTable dt;

            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                dt = null;

            }
            if (dt == null) return dt;
            int allcheck = 1;
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Boolean"); //该列的数据类型  
            dc.ColumnName = "checkrcp";//该列得名称  
            dc.DefaultValue = allcheck;//该列得默认值 
            dt.Columns.Add(dc);
            return dt;
        }
        public string getCostUnlocked(string invoice_id)
        {
            DataTable dt = new DataTable();
            string sql = "select name"
                + ", unlocked"
                + " from clinic_costdet"
                + " where clinic_Invoice_id=" + DataTool.addIntBraces(invoice_id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                dt = null;
            }
            string unlock = "Y";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                if (unlocked.ToUpper().Equals("N"))
                {
                    unlock = "N";
                    break;
                }
            }
            return unlock;
        }
        public string getPatienttypeKeyname(string bas_patienttype_id)
        {
            string keyname = "";
            string sql = " select keyname from cost_insurtype where id in(select cost_insurtype_id from bas_patienttype where id = " + DataTool.addFieldBraces(bas_patienttype_id)+")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                keyname = dt.Rows[0][0].ToString();
            }
            return keyname;
        }
        /// <summary>
        /// 是否存在接诊记录
        /// </summary>
        /// <param name="register_id"></param>
        /// <returns></returns>
        public bool isRegistRcv(string invoice_id)
        {
            bool ret = false;

            string sql = "select id from clinic_record where "
                         + "regist_id in (select regist_id from clinic_invoice where id =" + DataTool.addFieldBraces(invoice_id) + " and isregist='1') ";

            DataTable dtId = BllMain.Db.Select(sql).Tables[0];
            if (dtId.Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
                     
        }

        public DataTable getInvoice(ChargeManage chargeManage,int sfsc)
        {
            DataTable dt = new DataTable();

            string sql = "select "
                       + "register.billcode as regbill"
                       + ",clinic_invoice.invoice as invbill"
                       + ",register.name as regname"
                       + ",case when register.sex = 'W' then '女' when register.sex = 'M' then '男' when register.sex = 'U' then '未知' end as sex"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",(select name from bas_doctor where clinic_invoice.rcpdoctor_id = bas_doctor.id) as ys"
                       + ",clinic_invoice.realfee"
                       + ",clinic_invoice.chargedate"
                       + ",register.hspcard"
                       + ",register.age"
                       + ",bas_patienttype. NAME AS patienttype"
                       + ",case when clinic_invoice.charged='RET' then '退费' when clinic_invoice.charged='RREC' then '红冲' when clinic_invoice.charged='CHAR' then '计费' end as charged"
                       + ",clinic_invoice.isregist"
                       + ",clinic_invoice.id"
                       + ",clinic_invoice.regist_id"
                       + ",clinic_invoice.bas_patienttype_id"
                       + ",ihsp_info.idcard"
                       + " from clinic_invoice "
                       + " left join register"
                       + " on clinic_invoice.regist_id = register.id"
                       + " left join bas_depart"
                       + " on clinic_invoice.rcpdep_id = bas_depart.id"
                       + " LEFT JOIN bas_patienttype ON clinic_invoice.bas_patienttype_id = bas_patienttype.id"
                       + " left join bas_doctor"
                       + " on clinic_invoice.chargeby = bas_doctor.id"
                       + " left join ihsp_info on ihsp_info.ihsp_id=register.id and ihsp_info.registkind=" + DataTool.addFieldBraces(RegistKind.CLIN.ToString())
                       + " where clinic_invoice.chargedate>= " + DataTool.addFieldBraces(chargeManage.StartDate)
                       + " and clinic_invoice.chargedate<= " + DataTool.addFieldBraces(chargeManage.EndDate)
                       + " and clinic_invoice.charged <> " + DataTool.addFieldBraces(CostCharged.OO.ToString())
                       + " and register.prepaid <>'Y'"
                       + " and clinic_invoice.id in (select clinic_invoice_id from clinic_costdet) ";
            if (!String.IsNullOrEmpty(chargeManage.PatientName))
                sql += "  and register.name = " + DataTool.addFieldBraces(chargeManage.PatientName);
            if (!String.IsNullOrEmpty(chargeManage.HspCard))
                sql += "  and register.hspcard = " + DataTool.addFieldBraces(chargeManage.HspCard);
            if (chargeManage.Depart_id != "0" && chargeManage.Depart_id != "" && chargeManage.Depart_id != null)
                sql += "  and clinic_invoice.rcpdep_id = " + DataTool.addFieldBraces(chargeManage.Depart_id);
            if (chargeManage.Chargeby != "0" && chargeManage.Chargeby != "" && chargeManage.Chargeby != null)
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            if (chargeManage.Fph != "0" && chargeManage.Fph != "" && chargeManage.Fph != null)
                sql += "  and clinic_invoice.invoice = " + DataTool.addFieldBraces(chargeManage.Fph);
            if (!String.IsNullOrEmpty(chargeManage.Isret))
            {
                sql += "  and clinic_invoice.charged = " + DataTool.addFieldBraces(chargeManage.Isret);
            }
            sql += "  AND clinic_invoice.isregist != 1  and clinic_invoice.ybsfsc = " + sfsc;
            if (!String.IsNullOrEmpty(chargeManage.Islock))
            {
                sql += "  and clinic_invoice.id in ";
                sql += " (select distinct clinic_Invoice_id from  clinic_costdet where  unlocked = " + DataTool.addFieldBraces(chargeManage.Islock);
                sql += " ) order by clinic_invoice.chargedate DESC";
            }
            else
            {
                sql += " order by clinic_invoice.chargedate DESC";
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

        public string getInvoicefee(ChargeManage chargeManage)
        {
            string sql = @"SELECT sum(fee) as sfje from clinic_Invoice where 1= 1 ";
            if (!String.IsNullOrEmpty(chargeManage.Chargeby) && chargeManage.Chargeby != "0")
            {
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            }
            sql +=" and  charged in('RET','CHAR') and 	clinic_invoice.chargedate >="+ DataTool.addFieldBraces(chargeManage.StartDate)+" AND clinic_invoice.chargedate <= "+ DataTool.addFieldBraces(chargeManage.EndDate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["sfje"].ToString() == null || dt.Rows[0]["sfje"].ToString() == "")
            {
                return "0.00";
            }
                return dt.Rows[0]["sfje"].ToString();
        }
        public string getInvoiceRRECfee(ChargeManage chargeManage)
        {
            string sql = @"SELECT sum(fee) as RRECfee from clinic_Invoice where 1= 1 ";
            if (!String.IsNullOrEmpty(chargeManage.Chargeby) && chargeManage.Chargeby != "0")
            {
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            }
            sql += " and  charged in('RREC') and 	clinic_invoice.chargedate >=" + DataTool.addFieldBraces(chargeManage.StartDate) + " AND clinic_invoice.chargedate <= " + DataTool.addFieldBraces(chargeManage.EndDate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["RRECfee"].ToString() == null || dt.Rows[0]["RRECfee"].ToString() == "")
            {
                return "0.00";
            }
                return dt.Rows[0]["RRECfee"].ToString();
        }
        public string getInvoiceRRECcount(ChargeManage chargeManage)
        {
            string sql = @"SELECT count(*) as countzs from clinic_Invoice where 1= 1 ";
            if (!String.IsNullOrEmpty(chargeManage.Chargeby) && chargeManage.Chargeby != "0")
            {
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            }
            sql += " and  charged in('RREC') and 	clinic_invoice.chargedate >=" + DataTool.addFieldBraces(chargeManage.StartDate) + " AND clinic_invoice.chargedate <= " + DataTool.addFieldBraces(chargeManage.EndDate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
                return dt.Rows[0]["countzs"].ToString();
        }
        public string getInvoicecount(ChargeManage chargeManage)
        {
            string sql = @"SELECT count(*) as countzs from clinic_Invoice where 1= 1 ";
            if (!String.IsNullOrEmpty(chargeManage.Chargeby) && chargeManage.Chargeby != "0")
            {
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            }
            sql += " and  charged in('RET','CHAR') and 	clinic_invoice.chargedate >=" + DataTool.addFieldBraces(chargeManage.StartDate) + " AND clinic_invoice.chargedate <= " + DataTool.addFieldBraces(chargeManage.EndDate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
                return dt.Rows[0]["countzs"].ToString();
        }

        public string getInvoicess(ChargeManage chargeManage)
        {
            string sql = @"SELECT sum(fee) as sumfee from clinic_Invoice where 1= 1 ";
            if (!String.IsNullOrEmpty(chargeManage.Chargeby) && chargeManage.Chargeby != "0")
            {
                sql += "  and clinic_invoice.chargeby = " + DataTool.addFieldBraces(chargeManage.Chargeby);
            }
            sql += " and 	clinic_invoice.chargedate >=" + DataTool.addFieldBraces(chargeManage.StartDate) + " AND clinic_invoice.chargedate <= " + DataTool.addFieldBraces(chargeManage.EndDate);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["sumfee"].ToString() == null || dt.Rows[0]["sumfee"].ToString() == "")
            {
                return "0.00";
            }
            return dt.Rows[0]["sumfee"].ToString();
        }

    }
}
