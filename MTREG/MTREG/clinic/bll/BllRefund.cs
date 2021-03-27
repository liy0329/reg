using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.tools;
using MTREG.clinic.bo;
using MTHIS.tools;

namespace MTREG.clinic.bll
{
    class BllRefund
    {
        /// <summary>
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select bas_paytype_id as id, name from bas_paysumby where isinsur='0' order by ordersn;";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        public string getPaytypeByInvoiceId(string invoice_id)
        {
            string ret = "1";
            DataTable dt = new DataTable();
            string sql = "select bas_paytype_id  from clinic_invoice where id="+DataTool.addFieldBraces(invoice_id)+";";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                ret = dt.Rows[0]["bas_paytype_id"].ToString();
                if (string.IsNullOrEmpty(ret))
                    ret = "1";
            }
            catch (Exception e)
            {
                ret = "1";
            }
            return ret;
        }

        /// <summary>
        /// 根据门诊发票号查询其他明细
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>

        public DataTable getInvoiceFee(string invoiceId)
        {


            DataSet dataset = null;
            string sql = "SELECT realfee,insurefee,insuraccountfee,payfee,bas_paytype_id, hisOrderNo, sjz_yb_jsxx.AKC255,sjz_yb_jsxx.AKC780,sjz_yb_jsxx.AKC261 from clinic_invoice LEFT JOIN sjz_yb_jsxx ON clinic_invoice.invoice = sjz_yb_jsxx.aae072 where clinic_invoice.id=" + DataTool.addFieldBraces(invoiceId);
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        public DataTable getChargeData(string invoiceId)
        {
            DataSet dataset = null;
            string type = IniUtils.IniReadValue(IniUtils.syspath, "FEETYPE", "TYPE");
            string sql = "";
            if (string.IsNullOrEmpty(invoiceId))
            {
                sql = "select "
                           + " clinic_cost.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.clinicinvoice"
                           + ",clinic_cost.chargedate"
                           + ",bas_depart.name as dptname"
                           + ",bas_doctor.name as dctname"
                           + ",clinic_cost.Realfee"
                           + ",clinic_cost.rcptype"
                           + ",clinic_cost.clinic_rcp_id"
                           + " from clinic_cost"
                           + " left join bas_depart on clinic_cost.depart_id = bas_depart.id"
                           + " left join bas_doctor on clinic_cost.doctor_id = bas_doctor.id"
                           + " where 1!=1";
            }
            else
            {
                sql = "select "
                           + " clinic_cost.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.clinicinvoice"
                           + ",clinic_cost.chargedate"
                           + ",bas_depart.name as dptname"
                           + ",bas_doctor.name as dctname"
                           + ",clinic_cost.Realfee"
                           + ",clinic_cost.rcptype"
                           + ",clinic_cost.clinic_rcp_id"
                           + " from clinic_cost"
                           + " left join bas_depart on clinic_cost.depart_id = bas_depart.id"
                           + " left join bas_doctor on clinic_cost.doctor_id = bas_doctor.id"
                           + " where clinic_cost.id in (select clinic_cost_id from clinic_costdet where clinic_invoice_id = " + DataTool.addFieldBraces(invoiceId)
                           + " and charged = " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                           + " and unlocked = " + DataTool.addFieldBraces("Y")
                           + ") ";
            }
            dataset = BllMain.Db.Select(sql);
            DataTable dt = dataset.Tables[0];
            int allcheck = 1;
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Boolean"); //该列的数据类型  
            dc.ColumnName = "checkrcp";//该列得名称  
            dc.DefaultValue = allcheck;//该列得默认值 
            dt.Columns.Add(dc);
        
            return dt;
        }
        public DataTable getPatienttypeKeyname(string patientTypeId)
        {
            DataSet dataset = null;
            string sql = "SELECT keyname from cost_insurtype where id = "
                       + " (SELECT cost_insurtype_id from bas_patienttype where id ="
                       + DataTool.addFieldBraces(patientTypeId)
                       + ");";
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
        public DataTable getClinicRcp(string cliniCostId,string invoiceld)
        {
            DataSet dataset = null;
            string sql = "select "
                       + " clinic_costdet.id"
                       + ",clinic_costdet.bas_patienttype_id"
                       + ",clinic_invoice.billcode"
                       + ",clinic_costdet.name"
                       + ",clinic_costdet.spec"
                       + ",clinic_costdet.unit"
                       + ",clinic_costdet.num"
                       + ",clinic_costdet.prc"
                       + ",clinic_costdet.charged"
                       + ",clinic_costdet.unlocked"
                       + " from clinic_costdet "
                       + " left join clinic_invoice on clinic_costdet.clinic_Invoice_id=clinic_invoice.id"
                       + " where clinic_costdet.clinic_cost_id = "
                       + DataTool.addFieldBraces(cliniCostId)
                       +"and clinic_costdet.clinic_invoice_id="
                       + DataTool.addFieldBraces(invoiceld);
            dataset = BllMain.Db.Select(sql);
            return dataset.Tables[0];
        }
       

        /// <summary>
        /// 退费红冲
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currDate"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int upCliniCostdet(string ids,string currDate,string ret_invoice_id,ref string merge_sql)
        { 
            string sql_slt = "select "
                      + " id"                      //主键
                          + ",clinic_invoice_id"
                          + ",bas_patienttype_id"
                          + ",clinic_cost_id"          //收费主表外键
                          + ",regist_id"               //挂号编号外键
                          + ",standcode"               //统一编码
                          + ",item_id"                 //外键项目  隐式外键
                          + ",drug_factyitem_id"
                          + ",itemfrom"                //项目定义类型
                          + ",rcptype"                 //种类
                          + ",clinic_rcpdetail_id"     //处方明细
                          + ",depart_id"               // 处方科室
                          + ",doctor_id"               // 处方医生
                          + ",exedep_id"               //执行科室
                          + ",exedoctor_id"            //执行医生
                          + ",executed"
                          + ",packsole"
                          + ",drug_packsole_id"
                          + ",name"                    //项目名称
                          + ",spec"                    //规格  单位 数量 单价
                          + ",unit"
                          + ",num"
                          + ",prc"
                          + ",fee"                //金额 打折 实收金额
                          + ",discnt"
                          + ",realfee"
                          + ",itemtype_id"     //费用类别
                          + ",itemtype1_id"     //核算类别
                          + ",charged"          //00
                          + ",chargedate"
                          + ",chargeby"
                          + ",unlocked"       //N
                          + ",retappstat"      //N
                          + ",clinic_costdet_id"
                          + " from clinic_costdet where id in ( " + ids    + ");";
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                string num = "-" + dt.Rows[i]["num"].ToString();
                string fee = "-" + dt.Rows[i]["fee"].ToString();
                string realfee = "-" + dt.Rows[i]["realfee"].ToString();
                string sql_int = "insert into clinic_costdet ( "
                          + " id"                      //主键
                          + ",clinic_invoice_id"
                          + ",bas_patienttype_id"      //患者类型
                          + ",clinic_cost_id"          //收费主表外键
                          + ",regist_id"               //挂号编号外键
                          + ",standcode"               //统一编码
                          + ",item_id"                 //外键项目  隐式外键
                          + ",drug_factyitem_id"                 //外键厂家序列 
                          + ",itemfrom"                //项目定义类型
                          + ",rcptype"                 //种类
                          + ",clinic_rcpdetail_id"     //处方明细
                          + ",depart_id"               // 处方科室
                          + ",doctor_id"               // 处方医生
                          + ",exedep_id"               //执行科室
                          + ",exedoctor_id"            //执行医生
                          + ",executed"
                          + ",packsole"
                          + ",drug_packsole_id"
                          + ",name"                    //项目名称
                          + ",spec"                    //规格  单位 数量 单价
                          + ",unit"
                          + ",num"
                          + ",prc"
                          + ",fee"                //金额 打折 实收金额
                          + ",discnt"
                          + ",realfee"
                          + ",itemtype_id"     //费用类别
                          + ",itemtype1_id"     //核算类别
                          + ",charged"          //00
                          + ",chargedate"
                          + ",chargeby"
                          + ",unlocked"       //N
                          + ",retappstat"      //N
                          + ",clinic_costdet_id"
                          + " ) values ("
                          + DataTool.addFieldBraces(clinic_costdet_id)
                             + "," + DataTool.addFieldBraces(ret_invoice_id)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_patienttype_id"].ToString()) 
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["clinic_cost_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["regist_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["drug_factyitem_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["rcptype"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["clinic_rcpdetail_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["depart_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["doctor_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["exedoctor_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["executed"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["packsole"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["drug_packsole_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                             + "," + DataTool.addFieldBraces(num)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
                             + "," + DataTool.addFieldBraces(fee)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["discnt"].ToString())
                             + "," + DataTool.addFieldBraces(realfee)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                             + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                             + "," + DataTool.addFieldBraces(currDate)
                             + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                             + "," + DataTool.addFieldBraces("N")
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["retappstat"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                           + " ) ; ";
                merge_sql += sql_int;              
                string sql_upd = "update clinic_costdet "
                            + " set charged = "
                            + DataTool.addFieldBraces(CostCharged.RET.ToString())
                            + " where id = "
                            + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                            + " ;";
                if (dt.Rows[0]["itemfrom"].ToString() == "DRUG")
                {
                    
                    sql_upd += "update drug_iodetail "
                            + " set opstat ='XX'"
                            + " where drug_iodetail.costdet_id = "
                            + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                            + " and iokind = 'OUT04' and opstat='USE';";
                }
                merge_sql += sql_upd;
            }
                return 0;
        }
        /// <summary>
        /// 将收费主表收费状态改为退费
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int upClinicCost(string id, ref string merge_sql)
        {
            string sql_upd = "update clinic_cost "
                        + " set ischarged = "
                        + DataTool.addFieldBraces(Ischarged.R.ToString())
                        + " where id =" + DataTool.addFieldBraces(id)
                        + ";";
                       merge_sql += sql_upd;
            return 0;
        }
        /// <summary>
        /// 添加门诊发票记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currDate"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int upClinicInvoice(string id, string currDate, ref string ret_invoice_id,ref string merge_sql)
        {
            string sql_slt = "select "
                +"id"                           
                +", account_id"
                +", regist_id"
                +", sickname"
                +", rcpdep_id"
                +", rcpdoctor_id"
                +", fee"
                +", discnt"
                +", realfee"
                +", bas_patienttype_id"
                +", healthcard"
                +", billcode"
                + ", invoice"
                +", depart_id"
                +",bas_patienttype1_id"
                +",exedep_id"
                +", chargedate"
                +", chargeby"
                +", charged"
                +", insurstat"
                +", Insurefee"
                + ", insuraccountfee"
                +", clinic_Invoice_id"
                + ", hisorderno"
                +" from clinic_invoice where id = "
                + DataTool.addFieldBraces(id);
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            string hisorderno = dt.Rows[0]["hisorderno"].ToString();
            ret_invoice_id = BillSysBase.nextId("clinic_invoice");
            string fee = "-" + dt.Rows[0]["fee"].ToString();
            string realfee = "-" + dt.Rows[0]["realfee"].ToString();
            string sql_int = "insert into clinic_invoice ( "
                +"id"                           
                +", account_id"
                +", regist_id"
                +", sickname"
                +", rcpdep_id"
                +", rcpdoctor_id"
                +", fee"
                +", discnt"
                +", realfee"
                +", bas_patienttype_id"
                +", healthcard"
                +", billcode"
                + ", invoice"
                + ",bas_patienttype1_id"
                + ",exedep_id"
                +", depart_id"
                +", chargedate"
                +", chargeby"
                +", charged"
                +", insurstat"
                +", Insurefee"
                + ", insuraccountfee"
                +", clinic_Invoice_id"
                +", clinic_tab_id ) values("
                    + DataTool.addFieldBraces(ret_invoice_id)
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["account_id"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["regist_id"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["sickname"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["rcpdep_id"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["rcpdoctor_id"].ToString())
                    + "," + DataTool.addFieldBraces(fee)
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["discnt"].ToString())
                    + "," + DataTool.addFieldBraces(realfee)
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["bas_patienttype_id"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["healthcard"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["billcode"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["invoice"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["bas_patienttype1_id"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["exedep_id"].ToString())
                    + "," + DataTool.addFieldBraces(ProgramGlobal.Depart_id)
                    + "," + DataTool.addFieldBraces(currDate)
                    + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                    + "," + DataTool.addFieldBraces(CostCharged.RREC.ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["insurstat"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["Insurefee"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["insuraccountfee"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[0]["id"].ToString())
                    + "," + DataTool.addFieldBraces("")
                    + " ) ; ";
            BillClinicRcpCost billClinicRcpCost = new BillClinicRcpCost();
            ClinicInvoiceDet clinicInvoiceDet = new ClinicInvoiceDet();
            //退费在发票支付表中插入负记录
            string sql = "select bas_paytype_id,payfee,bas_paysumby_id,cheque from clinic_invoicedet where clinic_invoice_id=" + DataTool.addIntBraces(dt.Rows[0]["id"].ToString());
            DataTable dtdet = BllMain.Db.Select(sql).Tables[0];
            if (dtdet.Rows.Count > 0)
            {
                for (int i = 0; i < dtdet.Rows.Count; i++)
                {
                    clinicInvoiceDet.Bas_paytype_id = dtdet.Rows[i]["bas_paytype_id"].ToString();
                    clinicInvoiceDet.Payfee = "-" + dtdet.Rows[i]["payfee"].ToString();
                    clinicInvoiceDet.Bas_paysumby_id = dtdet.Rows[i]["bas_paysumby_id"].ToString();
                    clinicInvoiceDet.Cheque = dtdet.Rows[i]["cheque"].ToString();
                    clinicInvoiceDet.Clinic_invoice_id = ret_invoice_id;
                    billClinicRcpCost.addClinicInvoicedet(clinicInvoiceDet, ref sql_int);
                }
            }
            merge_sql += sql_int;
            string sql_upd = "update clinic_invoice "
                    + " set charged = "
                    + DataTool.addFieldBraces(CostCharged.RET.ToString())
                    + " where id = "
                    + DataTool.addFieldBraces(id)
                    + " ; ";
            if (!string.IsNullOrEmpty(hisorderno))
            {
                sql_upd += "UPDATE netpaydata set hisstat =1 where sourceOuterOrderNo=" + DataTool.addFieldBraces(hisorderno) + ";"
                          + "UPDATE netpaydata set isCancel =1 where outerOrderNo=" + DataTool.addFieldBraces(hisorderno) + ";";
            }
            merge_sql += sql_upd;
            return 0;
        }
        public int upClinicRcpOrChk(string clinic_rcp_id,string rcptype, ref string sql_merge)
        {
            if (rcptype=="RCP")
            sql_merge += "update clinic_rcp set syncost = " + DataTool.addFieldBraces("R")
               + " where id =" + DataTool.addFieldBraces(clinic_rcp_id) + ";";
            if (rcptype == "CHK")
            {
                sql_merge += "update chk_app set syncost = " + DataTool.addFieldBraces("R")
                   + " where id =" + DataTool.addFieldBraces(clinic_rcp_id) + ";";
                sql_merge += "update chk_appcost set syncost = " + DataTool.addFieldBraces("R")
                    + " where chk_app_id=" + DataTool.addFieldBraces(clinic_rcp_id) + ";";
            }
            return 0;
        }
      
        /// <summary>
        ///生成部分退再次收费主表
        /// </summary>
        public string mkCliniCost(string costdetIds,string invoiceBillcode,ref string clinic_cost_ids,ref string clinic_costdet_ids, string currDate)
        {
            string merge_sql = "";
            string sql_slt = "select "
                             + "id"                //主键
                             + ",regist_id"         //挂号外键
                             + ",billcode"          //处方编号/检验单号
                             + ",rcptype"           //费用种类 REG RCP CHK
                             + ",clinic_rcp_id"     //处方.id   检验.id
                             + ",executed"          //N
                             + ",depart_id"         //处方科室外键
                             + ",doctor_id"         //处方医生外键
                             + ",rcpdate"           //处方时间
                             + ",ischarged"         //  N
                             + ",chargedate"
                             + ",unlocked"           //N
                             + ",retappstat"         //N
                             + " from clinic_cost where id in (select clinic_cost_id from clinic_costdet where id in ( " + costdetIds + "))";
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            string sql_upt = "update clinic_cost set ischarged = " + DataTool.addFieldBraces("T") + " where id in (select clinic_cost_id from clinic_costdet where id in ( " + costdetIds + "));";
            merge_sql += sql_upt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string clinic_cost_id = BillSysBase.nextId("clinic_cost");
                string sql_int = "insert into clinic_cost ( "
                                  + "id"                //主键
                                  + ",regist_id"         //挂号外键
                                  + ",clinicInvoice"
                                  + ",billcode"          //处方编号/检验单号
                                  + ",rcptype"           //费用种类 REG RCP CHK
                                  + ",clinic_rcp_id"     //处方.id   检验.id
                                  + ",executed"          //N
                                  + ",depart_id"         //处方科室外键
                                  + ",doctor_id"         //处方医生外键
                                  + ",rcpdate"           //处方时间
                                  + ",ischarged"         //  N
                                  + ",unlocked"           //N
                                  + ",retappstat"         //N
                                  + " ) values ("
                                  + DataTool.addFieldBraces(clinic_cost_id)
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["regist_id"].ToString())
                                  + "," + DataTool.addFieldBraces(invoiceBillcode)
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["billcode"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["rcptype"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["clinic_rcp_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["executed"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["depart_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["doctor_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdate"].ToString())
                                  + "," + DataTool.addFieldBraces(Ischarged.N.ToString())
                                  + "," + DataTool.addFieldBraces("N")
                                  + "," + DataTool.addFieldBraces("N")
                                  + " ) ; ";
                clinic_cost_ids += clinic_cost_id + ",";
                string cliniCostId = dt.Rows[i]["id"].ToString();
                merge_sql += sql_int;
                mkCliniCostdet(costdetIds,cliniCostId, clinic_cost_id, currDate,ref clinic_costdet_ids, ref merge_sql);

            }
            clinic_cost_ids = clinic_cost_ids.Substring(0, clinic_cost_ids.Length-1);
            clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length-1);
            return merge_sql;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliniCostId"></param>老主表记录ID
        /// <param name="clinic_cost_id"></param>新主表记录ID
        /// <param name="currDate"></param>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int mkCliniCostdet(string CostdetIds,string cliniCostId, string clinic_cost_id, string currDate, ref string clinic_costdet_ids, ref string merge_sql)
        {
            double  realfee = 0;
            double recipelfee = 0;
            string sql_slt = "select "
                  + " id"                      //主键
                      + ",clinic_invoice_id"
                      + ",bas_patienttype_id"
                      + ",clinic_cost_id"          //收费主表外键
                      + ",regist_id"               //挂号编号外键
                      + ",standcode"               //统一编码
                      + ",item_id"                 //外键项目  隐式外键
                      + ",itemfrom"                //项目定义类型
                      + ",rcptype"                 //种类
                      + ",clinic_rcpdetail_id"     //处方明细
                      + ",depart_id"               // 处方科室
                      + ",doctor_id"               // 处方医生
                      + ",exedep_id"               //执行科室
                      + ",exedoctor_id"            //执行医生
                      + ",executed"
                      + ",packsole"
                      + ",drug_packsole_id"
                      + ",name"                    //项目名称
                      + ",spec"                    //规格  单位 数量 单价
                      + ",unit"
                      + ",num"
                      + ",prc"
                      + ",fee"                //金额 打折 实收金额
                      + ",discnt"
                      + ",realfee"
                      + ",itemtype_id"     //费用类别
                      + ",itemtype1_id"     //核算类别
                      + ",groupid"
                      + ",groupnum"
                      + ",charged"          //00
                      + ",chargedate"
                      + ",chargeby"
                      + ",unlocked"       //N
                      + ",retappstat"      //N
                      + ",clinic_costdet_id"
                      + " from clinic_costdet where clinic_cost_id in  (" + cliniCostId + ")"
                      + " and id in (" + CostdetIds + ");";

            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                string sql_int = "insert into clinic_costdet ( "
                          + " id"                      //主键
                          + ",bas_patienttype_id"
                          + ",clinic_cost_id"          //收费主表外键
                          + ",regist_id"               //挂号编号外键
                          + ",standcode"               //统一编码
                          + ",item_id"                 //外键项目  隐式外键
                          + ",itemfrom"                //项目定义类型
                          + ",rcptype"
                          + ",clinic_rcpdetail_id"     //处方明细
                          + ",depart_id"               // 处方科室
                          + ",doctor_id"               // 处方医生
                          + ",exedep_id"               //执行科室
                          + ",exedoctor_id"            //执行医生
                          + ",executed"
                          + ",packsole"
                          + ",drug_packsole_id"
                          + ",name"                    //项目名称
                          + ",spec"                    //规格  单位 数量 单价
                          + ",unit"
                          + ",num"
                          + ",prc"
                          + ",fee"                //金额 打折 实收金额
                          + ",discnt"
                          + ",realfee"
                          + ",itemtype_id"     //费用类别
                          + ",itemtype1_id"     //核算类别
                          + ",groupid"
                          + ",groupnum"
                          + ",charged"          //00
                          + ",unlocked"       //N
                          + ",retappstat"      //N
                          + " ) values ("
                          + DataTool.addFieldBraces(clinic_costdet_id)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["bas_patienttype_id"].ToString())
                             + "," + DataTool.addFieldBraces(clinic_cost_id)
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["regist_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["rcptype"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["clinic_rcpdetail_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["depart_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["doctor_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["exedoctor_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["executed"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["packsole"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["drug_packsole_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["fee"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["discnt"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["groupid"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["groupnum"].ToString())
                             + "," + DataTool.addFieldBraces(CostCharged.OO.ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[i]["unlocked"].ToString())
                             + "," + DataTool.addFieldBraces(dt.Rows[0]["retappstat"].ToString())
                           + " ) ; ";
                merge_sql += sql_int;
                realfee = realfee + double.Parse(dt.Rows[i]["realfee"].ToString());
                recipelfee = recipelfee + double.Parse(dt.Rows[i]["fee"].ToString());
                clinic_costdet_ids += clinic_costdet_id + ",";

            }
            string sql_update = "update clinic_cost set recipelfee = "
                              + DataTool.addFieldBraces(realfee.ToString())
                              + ",realfee = "
                              + DataTool.addFieldBraces(recipelfee.ToString())
                              + "where id = "
                              + DataTool.addFieldBraces(clinic_cost_id);
            merge_sql += sql_update;
            return 0;
        }
 

        public DataTable getClinicInvoiceInfo(string id)
        {
            string sql_slt = "select "
                + "id"
                + ", regist_id"
                + ", sickname"
                + ", rcpdep_id"
                + ", rcpdoctor_id"
                + ", fee"
                + ", discnt"
                + ", realfee"
                + ", bas_patienttype_id"
                + ", healthcard"
                + ", billcode"
                + ", depart_id"
                + ", chargedate"
                + ", chargeby"
                + ", charged"
                + ", Insurefee"
                + ", insuraccountfee"
                + ", clinic_Invoice_id"
                + " from clinic_invoice where id = "
                + DataTool.addFieldBraces(id);
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获得SELFFEE支付类型ID
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaytypeId(string keyname)
        {
            DataTable dt = new DataTable();
            String sql = "select sn from sys_dict where father_id <> 0 and dicttype = 'bas_paytype' and keyname = " + DataTool.addFieldBraces(keyname);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 从发票表里得到医保报销数据
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataTable getInsurFromInvoice(string invoiceId)
        {
              string sql = "select "
                         + " insurefee"
                         + ",insuraccountfee"
                         + ",realfee"
                         + " from clinic_invoice"
                         + " where id = " + DataTool.addFieldBraces(invoiceId);
              DataTable dt = BllMain.Db.Select(sql).Tables[0];
              return dt;
        }

        public int backRegister(string invoice_id, ref string merge_sql)
        {

            if (string.IsNullOrEmpty(invoice_id))
                return 0;
             string selectsql = " SELECT"
                + " register.id,"
                + " register.netcode,"
                + " register.billcode,"
                + " register.regdate,"
                + " register.reservedate,"
                + " register.reg_level_id,"
                + " register.bas_patienttype_id,"
                + " register.prepaid,"
                + " register.insurcode,"
                + " register.healthCard,"
                + " register.insuregcode,"
                + " register.insuritemtype,"
                + " register.sys_region_id,"
                + " register.reg_regclass_id,"
                + " register.urgent,"
                + " register.doctor_id,"
                + " register.depart_id,"
                + " register.users_id,"
                + " register.amount,"
                + " register.`status`,"
                + " register.callserial,"
                + " register.isarchive,"
                + " register.archivedate,"
                + " register.register_id,"
                + " register.member_id,"
                + " register.hspcard,"
                + " register.`name`,"
                + " register.pincode,"
                + " register.sex,"
                + " register.birthday,"
                + " register.age,"
                + " register.ageunit,"
                + " register.moonage,"
                + " register.moonageunit,"
                + " register.introducer,"
                + " register.retappstat,"
                + " register.clinictab_id,"
                + " register.createtime,"
                + " register.updatetime,"
                + " register.sync,"
                + " register.memo,"
                + " register.clinicroom,"
                + " register.regnum"
                + " FROM"
                + " register"
                + " where id  in ( select regist_id from clinic_invoice where isregist=1 and id=" + DataTool.addFieldBraces(invoice_id) + ");";
                ;
                DataTable dt = BllMain.Db.Select(selectsql).Tables[0];
                if (dt.Rows.Count == 1)
                {
                    string id = dt.Rows[0]["id"].ToString();
                    string register_id = BillSysBase.nextId("register");
                    string sql = "update register set status='BACK' where id = " + DataTool.addFieldBraces(id)+";";

                    sql += " INSERT into  register("
                        + " id,"
                        + " netcode,"
                        + " billcode,"
                        + " regdate,"
                        + " reservedate,"
                        + " reg_level_id,"
                        + " bas_patienttype_id,"
                        + " prepaid,"
                        + " insurcode,"
                        + " healthCard,"
                        + " insuregcode,"
                        + " insuritemtype,"
                        + " sys_region_id,"
                        + " reg_regclass_id,"
                        + " urgent,"
                        + " doctor_id,"
                        + " depart_id,"
                        + " users_id,"
                        + " amount,"
                        + " status,"
                        + " callserial,"
                        + " isarchive,"
                        + " archivedate,"
                        + " register_id,"
                        + " member_id,"
                        + " hspcard,"
                        + " name,"
                        + " pincode,"
                        + " sex,"
                        + " birthday,"
                        + " age,"
                        + " ageunit,"
                        + " moonage,"
                        + " moonageunit,"
                        + " introducer,"
                        + " retappstat,"
                        + " clinictab_id,"
                        + " createtime,"
                        + " updatetime,"
                        + " sync,"
                        + " memo,"
                        + " clinicroom,"
                        + " regnum)"
                        + "  VALUES "
                        + " ("
                         + " " + DataTool.addFieldBraces(register_id)
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["netcode"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["billcode"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["regdate"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["reservedate"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["reg_level_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["bas_patienttype_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["prepaid"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["insurcode"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["healthCard"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["insuregcode"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["insuritemtype"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["sys_region_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["reg_regclass_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["urgent"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["doctor_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["depart_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["users_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["amount"].ToString())
                         + "," + DataTool.addFieldBraces("RREG")
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["callserial"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["isarchive"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["archivedate"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["register_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["member_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["hspcard"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["name"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["pincode"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["sex"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["birthday"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["age"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["ageunit"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["moonage"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["moonageunit"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["introducer"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["retappstat"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["clinictab_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["createtime"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["updatetime"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["sync"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["memo"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["clinicroom"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["regnum"].ToString())
                         +");";
                    merge_sql += sql;                      
                }
            return 0;
           
        }

        /// <summary>
        /// 判断门诊是否发药
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public bool isDrugDispensing(string invoice_id)
        {
            bool ret = false;
            string sql = "select * from clinic_cost where "
                         + " clinic_invoice_id=" + DataTool.addFieldBraces(invoice_id)
                         + " and executed='Y' and ischarged='Y';";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret = true;
            }
            return ret;
        }
    }
}

