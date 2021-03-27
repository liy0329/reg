using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using System.Data;
using MTHIS.common;
using MTREG.common;
using MTREG.clinic.bo;
using MTREG.common.bll;
using MTREG.common;

namespace MTREG.clinic.bll
{
    class BllClinicCost
    {
        /// <summary>
        /// 根据简码查询项目数据
        /// </summary>
        /// <param name="pincode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable getBasItemData(String pincode,string type)
        {
            DataTable dt = new DataTable();
            String sql = "";
            //if (String.IsNullOrEmpty(pincode))
            //{
            //    sql = "select "
            //        + " bas_item.id as id"
            //        + ",bas_item.itemtype_id"
            //        + ",bas_item.itemtype1_id"
            //        + ",cost_itemtype.name as itemtypename"
            //        + ",bas_item.name as itemname"
            //        + ",bas_item.spec as spec"
            //        + ",bas_item.unit as unit"
            //        + ",bas_item.city_prc as prc"     //单价
            //        + ",null as qty"     //库存
            //        + ",null as useqty"
            //        + ",null as exedep_id"
            //        + ",null as dptname"
            //        + ",null as type"  //所属类别
            //        + ",bas_item.itemfrom"
            //        + ",bas_item.standcode as standcode"
            //        + ",'' as packsole"
            //        + ",'' as drug_packsole_id"
            //        + ",'0' as chk_opkind_id "
            //        + ",'0' as chk_type_id"
            //        + ",'0' as chk_sampletype_id"
            //        + " from bas_item "
            //        + " left join cost_itemtype"
            //        + " on cost_itemtype.id = bas_item.itemtype_id"
            //        + " where 1 !=1 ";

            //}
            
                if (type == "qb")
                {
                    string qb_mx = "select "
                               + " bas_costitem.item_id as id"
                               + ",bas_costitem.itemtype_id"
                                + ",bas_costitem.itemtype1_id"
                               + ",cost_itemtype.name as itemtypename"
                               + ",bas_costitem.itemname"
                               + ",bas_costitem.spec"
                               + ",bas_costitem.unit"
                               + ",bas_costitem.prc"
                               + ",bas_costitem.qty"
                               + ",bas_costitem.useqty"
                               + ",bas_costitem.execdept_id as exedep_id"
                               + ",bas_depart.name as dptname"
                               + ",null as type"
                               + ",bas_costitem.itemfrom"
                               + ",bas_costitem.packsole"
                               + ",bas_costitem.drug_packsole_id"
                               + ",'0' as chk_opkind_id "
                               + ",'0' as chk_type_id"
                               + ",'0' as chk_sampletype_id"
                               + " from bas_costitem "
                               + " left join cost_itemtype"
                               + " on bas_costitem.itemtype_id = cost_itemtype.id "
                               + " left join bas_depart"
                               + " on bas_costitem.execdept_id = bas_depart.id"
                               + " where bas_costitem.pincode like '%" + pincode.Trim() + "%' or bas_costitem.itemname like '%" + pincode.Trim() + "%'"
                               + " and bas_costitem.itemfrom in ('COST','STUFF') and bas_costitem.execdept_id is not null"
                    + " UNION ALL "
                    + "select "
                             + " bas_drugstock.item_id as id"
                             + ",bas_drugstock.itemtype_id"
                             + ",bas_drugstock.itemtype1_id"
                             + ",cost_itemtype.name as itemtypename"
                             + ",bas_drugstock.itemname"
                             + ",bas_drugstock.spec"
                             + ",bas_drugstock.unit"
                             + ",bas_drugstock.prc"
                             + ",bas_drugstock.qty"
                             + ",bas_drugstock.useqty"
                             + ",bas_drugstock.execdept_id as exedep_id"
                             + ",bas_depart.name as dptname"
                             + ",null as type"
                             + ",bas_drugstock.itemfrom"
                             + ",bas_drugstock.packsole"
                             + ",bas_drugstock.drug_packsole_id"
                             + ",'0' as chk_opkind_id "
                             + ",'0' as chk_type_id"
                             + ",'0' as chk_sampletype_id"
                             + " from bas_drugstock"
                             + " left join cost_itemtype"
                             + " on bas_drugstock.itemtype_id = cost_itemtype.id"
                             + " left join bas_depart"
                             + " on bas_drugstock.execdept_id = bas_depart.id"
                             + " where bas_drugstock.pincode like '%" + pincode.Trim() + "%' or bas_drugstock.itemname like '%" + pincode.Trim() + "%'"
                             + " and bas_drugstock.itemfrom ='DRUG' " + ";";

                    sql = qb_mx;
                }
                if(type == "cost" ||type == "stuff")
                {
                    string sql_cost_stuff = "select "
                                 + " bas_costitem.item_id as id"
                                 + ",bas_costitem.itemtype_id"
                                  + ",bas_costitem.itemtype1_id"
                                 + ",cost_itemtype.name as itemtypename"
                                 + ",bas_costitem.itemname"
                                 + ",bas_costitem.spec"
                                 + ",bas_costitem.unit"
                                 + ",bas_costitem.prc"
                                 + ",bas_costitem.qty"
                                 + ",bas_costitem.useqty"
                                 + ",bas_costitem.execdept_id as exedep_id"
                                 + ",bas_depart.name as dptname"
                                 + ",null as type"
                                 + ",bas_costitem.itemfrom"
                                 + ",bas_costitem.packsole"
                                 + ",bas_costitem.drug_packsole_id"
                                 + ",'0' as chk_opkind_id "
                                 + ",'0' as chk_type_id"
                                 + ",'0' as chk_sampletype_id"
                                 + " from bas_costitem "
                                 + " left join cost_itemtype"
                                 + " on bas_costitem.itemtype_id = cost_itemtype.id "
                                 + " left join bas_depart"
                                 + " on bas_costitem.execdept_id = bas_depart.id"
                                 + " where bas_costitem.pincode like '%" + pincode.Trim() + "%' or bas_costitem.itemname like '%" + pincode.Trim() + "%'"
                                 + " and bas_costitem.itemfrom in ('COST','STUFF') " + ";";
                    sql = sql_cost_stuff;
                }
                else if (type == "drug")
                {
                
                    string sql_drug = "select "
                             + " bas_drugstock.item_id as id"
                             + ",bas_drugstock.itemtype_id"
                             + ",bas_drugstock.itemtype1_id"
                             + ",cost_itemtype.name as itemtypename"
                             + ",bas_drugstock.itemname"
                             + ",bas_drugstock.spec"
                             + ",bas_drugstock.unit"
                             + ",bas_drugstock.prc"
                             + ",bas_drugstock.qty"
                             + ",bas_drugstock.useqty"
                             + ",bas_drugstock.execdept_id as exedep_id"
                             + ",bas_depart.name as dptname"
                             + ",null as type"
                             + ",bas_drugstock.itemfrom"
                             + ",bas_drugstock.packsole"
                             + ",bas_drugstock.drug_packsole_id"
                             + ",'0' as chk_opkind_id "
                             + ",'0' as chk_type_id"
                             + ",'0' as chk_sampletype_id"
                             + " from bas_drugstock"
                             + " left join cost_itemtype"
                             + " on bas_drugstock.itemtype_id = cost_itemtype.id"
                             + " left join bas_depart"
                             + " on bas_drugstock.execdept_id = bas_depart.id"
                             + " where bas_drugstock.pincode like '%" + pincode.Trim() + "%' or bas_drugstock.itemname like '%" + pincode.Trim() + "%'"
                             + " and bas_drugstock.itemfrom ='DRUG' " + ";";
                    sql = sql_drug;
                }
                else if(type == "check")
                {
                string sql_check = "select "
                               + " chk_diagnset.id as id"//编码
                               + ",null as itemtype_id"
                               + ",null as itemtype1_id"
                               + ",null as itemtypename"//项目类别
                               + ",chk_diagnset.name as itemname"
                               + ",null as spec"//规格
                               + ",chk_diagnset.unit as unit"
                               + ",chk_diagnset.prc as prc"
                               + ",'0' as qty"     //库存
                               + ",'0' as useqty"
                               + ",chk_diagnset.execdept_id as exedep_id"
                               + ",bas_depart.name as dptname"
                               + ",chk_diagnset.chkkind as type"  //所属类别
                               + ",'CHECK' as itemfrom"
                               + ",'' as packsole"
                               + ",'' as drug_packsole_id"
                               + ",chk_diagnset.chk_opkind_id "
                               + ",chk_diagnset.chk_type_id"
                               + ",chk_diagnset.chk_sampletype_id"
                               + " from chk_diagnset "
                               + " left join bas_depart on bas_depart.id = chk_diagnset.execdept_id"
                               + " where chk_diagnset.pincode like '%" + pincode.Trim() + "%' or chk_diagnset.name like '%" + pincode.Trim() + "%';";
                sql = sql_check;
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
        /// 查询项目里的检查条目
        /// </summary>
        /// <param name="che_diagnset_id"></param>
        /// <returns></returns>
        public DataTable getChkCostdet(String che_diagnset_id)
        {
            DataTable dt = new DataTable();
            string sql = "";
            if (String.IsNullOrEmpty(che_diagnset_id))
            {
                sql = "select "
                    + " bas_item.name as name"
                    + ",chk_diagnset.chkkind as chkkind"
                    + ",bas_depart.name as dptname"
                    + ",bas_item.spec"
                    + ",chk_diagnsetcost.num"
                    + ",bas_item.unit"
                    + ",chk_diagnsetcost.prc as prc"
                    + ",1 as discnt"
                    + ",1 as realfee"
                    + ",bas_item.itemfrom"
                    + ",bas_item.id"
                    + ",bas_item.itemtype_id"
                    + ",bas_item.itemtype1_id"
                    + " from chk_diagnsetcost "
                    + " left join chk_diagnset on chk_diagnset.id = chk_diagnsetcost.chk_diagnset_id"
                    + " left join bas_item on chk_diagnsetcost.item_id = bas_item.id"
                    + " left join bas_depart on bas_depart.id = chk_diagnset.execdept_id"
                    + " where 1!= 1";
            }
            else
            {
                string sql_cost = "select "
                    + " bas_item.name as name"
                    + ",chk_diagnset.chkkind as chkkind"
                    + ",bas_depart.name as dptname"
                    + ",bas_item.spec"
                    + ",chk_diagnsetcost.num"
                    + ",bas_item.unit";
                //if (ProgramGlobal.CostClass.Equals(BasCostClass.CITY.ToString()))
                //    sql_cost += ",bas_item.city_prc as prc";
                //else if (ProgramGlobal.CostClass.Equals(BasCostClass.COUNTY.ToString()))
                //    sql_cost += ",bas_item.county_prc as prc";
                //else if (ProgramGlobal.CostClass.Equals(BasCostClass.PROV.ToString()))
                    sql_cost += ",chk_diagnsetcost.prc";
                sql_cost += ",1 as discnt"
                    + ",1 as realfee"
                    + ",bas_item.itemfrom"
                    + ",bas_item.id"
                    + ", bas_item.itemtype_id"
                    + ", bas_item.itemtype1_id"
                    + " from chk_diagnsetcost "
                    + " left join chk_diagnset on chk_diagnset.id = chk_diagnsetcost.chk_diagnset_id"
                    + " left join bas_item on chk_diagnsetcost.item_id = bas_item.id"
                    + " left join bas_depart on bas_depart.id = chk_diagnset.execdept_id"
                    + " where chk_diagnsetcost.isstop = 'N' and chk_diagnsetcost.chk_diagnset_id = " + DataTool.addFieldBraces(che_diagnset_id)
                    + " and bas_item.itemfrom = " + DataTool.addFieldBraces(BasItemFrom.COST.ToString());
                string sql_stuff = "select "
                    + " chk_diagnsetcost.name as name"
                    + ",chk_diagnset.chkkind as chkkind"
                    + ",bas_depart.name as dptname"
                    + ",bas_item.spec"
                    + ",chk_diagnsetcost.num"
                    + ",bas_item.unit"
                    + ",chk_diagnsetcost.prc"
                    + ",1 as discnt"
                    + ",1 as realfee"
                    + ",bas_item.itemfrom"
                    + ",bas_item.id"
                    + ", bas_item.itemtype_id"
                    + ", bas_item.itemtype1_id"
                    + " from chk_diagnsetcost "
                    + " left join chk_diagnset on chk_diagnset.id = chk_diagnsetcost.chk_diagnset_id"
                    + " left join bas_item on chk_diagnsetcost.item_id = bas_item.id"
                    + " left join bas_depart on bas_depart.id = chk_diagnset.execdept_id"
                    + " where chk_diagnsetcost.isstop = 'N' and chk_diagnsetcost.chk_diagnset_id = " + DataTool.addFieldBraces(che_diagnset_id)
                    + " and bas_item.itemfrom = " + DataTool.addFieldBraces(BasItemFrom.STUFF.ToString());
                sql = sql_cost + " union all " + sql_stuff;
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
 

        public int addClinicRecord(ref string id,string reg_id,string dpt_id,ref string merge_sql)
        {
            string sql_search = "select id from clinic_record where regist_id = " + DataTool.addFieldBraces(reg_id);
            DataTable dt  = BllMain.Db.Select(sql_search).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                string sqlDict = "select sn from sys_dict where dicttype='clinic_regtype' and keyname='FVT'";
                DataTable dtRegtype = BllMain.Db.Select(sqlDict).Tables[0];
                id = BillSysBase.nextId("clinic_record");
                string sql = "insert into clinic_record ( "
                           + " id"
                           + ",regist_id"
                           + ",depart_id"
                           + ",clinic_regtype_id ) values ("
                           + DataTool.addFieldBraces(id)
                           + "," + DataTool.addFieldBraces(reg_id)
                           + "," + DataTool.addFieldBraces(dpt_id)
                           + "," + DataTool.addFieldBraces(dtRegtype.Rows[0]["sn"].ToString())
                           + ");";
                merge_sql += sql;
            }
            else if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["id"].ToString();
            }
            return 0;
        }
        /// <summary>
        /// 增加门诊处方记录
        /// </summary>
        /// <param name="clinicRcp"></param>
        /// <param name="clinic_rcp_id"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int addClinicRcp(ClinicRcp clinicRcp,ref string merge_sql)
        {
            
               string sql = "insert into clinic_rcp( "
                          + "id"
                          + ",regist_id"
                          + ",billcode"
                          + ",dep_id"
                          + ",doctor_id"
                          + ",rcpdate"
                          + ",clinic_record_id"
                          + ",recipelfee"
                          + ",opstat"
                          + ",syncost"
                          + " ) values ("
                          + DataTool.addFieldBraces(clinicRcp.Id)
                          + "," + DataTool.addFieldBraces(clinicRcp.Regist_id)
                          + "," + DataTool.addFieldBraces(clinicRcp.Billcode)
                          + "," + DataTool.addFieldBraces(clinicRcp.Dep_id)
                          + "," + DataTool.addFieldBraces(clinicRcp.Doctor_id)
                          + "," + DataTool.addFieldBraces(clinicRcp.Rcpdate)
                          + "," + DataTool.addFieldBraces(clinicRcp.Clinic_record_id)
                          + "," + DataTool.addFieldBraces(clinicRcp.Fee)
                          + "," + DataTool.addFieldBraces(clinicRcp.Opstat)
                          + "," + DataTool.addFieldBraces(clinicRcp.Syncost)
                          + " ) ; ";
               merge_sql += sql;
               return 0;
        }
        /// <summary>
        /// 增加门诊处方明细记录
        /// </summary>
        /// <param name="clinicRcpdetail"></param>
        /// <param name="clinic_rcp_id"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int addClinicRcpdetail(ClinicRcpdetail clinicRcpdetail,ref string merge_sql)
        {
            
            string sql = "insert into clinic_rcpdetail ("
                       + " id"
                       + ",clinic_rcp_id"
                       + ",itemfrom"
                       + ",exedep_id"
                       + ",item_id"
                       + ",name"
                       + ",spec"
                       + ",itemtype_id"
                       + ",packsole"
                       + ",drug_packsole_id"
                       + ",unit"
                       + ",num"
                       + ",prc"
                       + ",groupid"
                       + ",groupnum"
                       + ",executed"
                       + ",syncost"
                       + " ) values ("
                       + DataTool.addFieldBraces(clinicRcpdetail.Id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Clinic_rcp_id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Itemfrom)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Exedep_id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Item_id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Name)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Spec)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Itemtype_id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Packsole)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Drug_packsole_id)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Unit)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Num)
                       + "," + DataTool.addFieldBraces(clinicRcpdetail.Prc)
                       + "," + DataTool.addFieldBraces("0")
                       + "," + DataTool.addFieldBraces("0")
                       + "," + DataTool.addFieldBraces("N")
                       + "," + DataTool.addFieldBraces("N")
                       + " ) ; ";
            merge_sql += sql;
            return 0;
        }
        /// <summary>
        /// 增加一条检查记录表
        /// </summary>
        /// <param name="chkapp"></param>
        /// <param name="chk_app_id"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int addChkApp(ChkApp chkapp,ref string merge_sql)
        {
         
           string sql = "insert into chk_app ("
                      + " id"
                      + ",billcode"
                      + ",regist_id"
                      + ",registkind"
                      + ",chk_diagnset_id"
                      + ",diagnsetname"
                      + ",dep_id"
                      + ",doctor_id"
                      + ",rcpdate"
                      + ",clinic_record_id"
                      + ",instuction"//-检查说明""
                      + ",chk_sampletype_id"//标本类型-
                      + ",chk_type_id"//检验类型-
                      + ",chk_opkind_id"//执行科室类别-
                      + ",num"
                      + ",sendstat"//-送检状态OO-
                      + ",exedep_id"
                      + ",recipelfee"
                      + ",syncost"
                      + ",opstat"
                      + " ) values ("
                      + DataTool.addFieldBraces(chkapp.Id)
                      + "," + DataTool.addFieldBraces(chkapp.Billcode)
                      + "," + DataTool.addFieldBraces(chkapp.Regist_id)
                      + "," + DataTool.addFieldBraces(chkapp.Registkind)
                      + "," + DataTool.addFieldBraces(chkapp.Diagnset_id)
                      + "," + DataTool.addFieldBraces(chkapp.Name)
                      + "," + DataTool.addFieldBraces(chkapp.Dep_id)
                      + "," + DataTool.addFieldBraces(chkapp.Doctor_id)
                      + "," + DataTool.addFieldBraces(chkapp.Rcpdate)
                      + "," + DataTool.addFieldBraces(chkapp.Clinic_record_id)
                      + "," + DataTool.addFieldBraces(chkapp.Instuction)
                      + "," + DataTool.addFieldBraces(chkapp.Chk_sampletype_id)
                      + "," + DataTool.addFieldBraces(chkapp.Chk_type_id)
                      + "," + DataTool.addFieldBraces(chkapp.Chk_opkind_id)
                      + "," + DataTool.addFieldBraces(chkapp.Num)
                      + "," + DataTool.addFieldBraces(chkapp.Sendstat)
                      + "," + DataTool.addFieldBraces(chkapp.Exedep_id)
                       + "," + DataTool.addFieldBraces(chkapp.Fee)
                       + "," + DataTool.addFieldBraces(chkapp.Syncost)
                       + "," + DataTool.addFieldBraces(chkapp.Opstat)
                       + " ) ; ";
            merge_sql += sql;
            return 0;
        }
        /// <summary>
        /// 添加一条检查费用记录
        /// </summary>
        /// <param name="chkappcost"></param>
        /// <param name="chk_app_id"></param>
        /// <param name="merge_sql"></param>
        /// <returns></returns>
        public int addChkAppcost(ChkAppcost chkappcost,ref string merge_sql)
        {
           
            string sql = "insert into chk_appcost ("
                       + " id"
                       + ",chk_app_id"
                       + ",item_id"
                       + ",name"
                       + ",spec"
                       + ",unit"
                       + ",num"
                       + ",prc"
                       + ",ordersn"
                       + ",syncost"
                       + " ) values ("
                       + DataTool.addFieldBraces(chkappcost.Id)
                       + "," + DataTool.addFieldBraces(chkappcost.Chk_app_id)
                       + "," + DataTool.addFieldBraces(chkappcost.Item_id)
                       + "," + DataTool.addFieldBraces(chkappcost.Name)
                       + "," + DataTool.addFieldBraces(chkappcost.Spec)
                       + "," + DataTool.addFieldBraces(chkappcost.Unit)
                       + "," + DataTool.addFieldBraces(chkappcost.Num)
                       + "," + DataTool.addFieldBraces(chkappcost.Prc)
                       + "," + DataTool.addFieldBraces("0")
                       + "," + DataTool.addFieldBraces(chkappcost.Syncost)
                       + " ) ; ";
            merge_sql += sql;
            return 0;

        }




        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e) {
                SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
            }

            return result;
        }
        /// <summary>
        /// 导数据，将门诊处方、门诊处方明细 分别 导入 收费主表、收费主表明细
        /// </summary>
        public int clinicRcp2Cost(string clinic_rcp_idS, ref string clinic_cost_ids, ref string clinic_costdet_ids)
        {
            DataTable dt = new DataTable();
            String sql_slt = "select "
                        + " regist_id"
                        + ",billcode"
                        + ",id"
                        + ",dep_id"
                        + ",doctor_id"
                        + ",rcpdate"
                        + " from clinic_rcp"
                        + " where opstat = 'YES' and syncost = 'N' "
                        + " and id in ( " + DataTool.addFieldBraces(clinic_rcp_idS) 
                        + " )";

            dt = BllMain.Db.Select(sql_slt).Tables[0];

            string sql_inst = "";
            string clinic_rcp_ids = "";
            string clinic_rcpdetail_ids = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string clinic_rcp_id = dt.Rows[i]["id"].ToString();
                    clinic_rcp_ids += clinic_rcp_id + ",";
                    string clinic_cost_id = BillSysBase.nextId("clinic_cost");

                    ClinicCostdet clinicCostdet = new ClinicCostdet();
                    clinicCostdet.Clinic_cost_id = clinic_cost_id;
                    clinicCostdet.Regist_id = dt.Rows[i]["regist_id"].ToString();
                    clinicCostdet.Depart_id = dt.Rows[i]["dep_id"].ToString();
                    clinicCostdet.Doctor_id = dt.Rows[i]["doctor_id"].ToString();
                    double recipelfee = 0;
                    double realfee = 0;
                    clinicRcpdetail2Costdet(clinic_rcp_id, clinicCostdet,ref recipelfee,ref realfee, ref sql_inst, ref clinic_rcpdetail_ids, ref clinic_costdet_ids);

                    sql_inst += "insert into clinic_cost ( "
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
                              + ",recipelfee"
                              + ",realfee"
                              + ",unlocked"           //N
                              + ",retappstat"         //N
                              + " ) values ("
                              + DataTool.addFieldBraces(clinic_cost_id)
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["regist_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["billcode"].ToString())
                              + "," + DataTool.addFieldBraces(CostRcpType.RCP.ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["dep_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["doctor_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdate"].ToString())
                              + "," + DataTool.addFieldBraces(Ischarged.N.ToString())
                              + "," + DataTool.addFieldBraces(recipelfee.ToString())
                              + "," + DataTool.addFieldBraces(realfee.ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces("N")
                              + " ) ; ";

                    clinic_cost_ids += clinic_cost_id + ",";

                }
                clinic_rcp_ids = clinic_rcp_ids.Substring(0, clinic_rcp_ids.Length - 1);
                if (clinic_rcp_ids != "")
                {
                    sql_inst += "update clinic_rcp "
                           + " set syncost = 'Y'"
                           + " where id in ( "
                           + clinic_rcp_ids
                           + " );";
                }
                if (clinic_rcpdetail_ids != "")
                {
                    sql_inst += "update clinic_rcpdetail "
                           + " set syncost = 'Y'"
                           + " where id in ( "
                           + clinic_rcpdetail_ids
                           + " );";
                }
                return doExeSql(sql_inst);


       //         clinic_cost_ids = clinic_cost_ids.Substring(0, clinic_cost_ids.Length - 1);
            }
            return 0;

        }
        public void clinicRcpdetail2Costdet(string clinic_rcp_id, ClinicCostdet clinicRcp,ref double recipelfee,ref double realfee, ref string sql_inst, ref string clinic_rcpdetail_ids, ref string clinic_costdet_ids)
        {
            DataTable dt = new DataTable();

            String sql_slt = "select "
                       + " clinic_rcpdetail.id"           //  id
                //        + "," + cost_id    //收费主表id
                       + ",bas_item.standcode as standcode"
                       + ",clinic_rcpdetail.exedep_id"
                       + ",clinic_rcpdetail.item_id as item_id"            //外键项目      隐式外键
                       + ",bas_item.itemfrom as itemfrom"
                       + ",clinic_rcpdetail.id as rcpdetail_id"                //处方明细
                       + ",bas_item.name as name"
                       + ",bas_item.spec as spec"
                       + ",clinic_rcpdetail.packsole"
                       + ",clinic_rcpdetail.drug_packsole_id"
                       + ",bas_item.unit as unit"
                       + ",clinic_rcpdetail.num as num "
                       + ",bas_item.city_prc as costprc"
                       + ",clinic_rcpdetail.num * bas_item.prov_prc as costfee"   //num * city_prc
                       + ",clinic_rcpdetail.num * bas_item.prov_prc as costrealfee"   //num * city_prc * discnt
                       + ",clinic_rcpdetail.groupid"
                       + ",clinic_rcpdetail.groupnum"
                       + ",bas_item.itemtype_id as itemtype_id"               //费用类别
                       + ",bas_item.itemtype1_id as itemtype1_id"                  //核算类别
                       + ",bas_drugstock.realprc as drugrealprc"
                       + ",bas_drugstock.prc as drugprc"
                       + ",clinic_rcpdetail.num * bas_drugstock.prc as drugfee"   //num * city_prc
                       + ",clinic_rcpdetail.num * bas_drugstock.realprc as drugrealfee"   //num * city_prc * discnt
                       + " from clinic_rcpdetail left join bas_item on clinic_rcpdetail.item_id = bas_item.id"
                       + " left join bas_drugstock on bas_drugstock.item_id=clinic_rcpdetail.item_id and clinic_rcpdetail.exedep_id=bas_drugstock.execdept_id"                       
                       + " where clinic_rcpdetail.syncost = 'N' "
                       + " and clinic_rcpdetail.clinic_rcp_id = " + DataTool.addFieldBraces(clinic_rcp_id) + ";";


            dt = BllMain.Db.Select(sql_slt).Tables[0];

            //        string sql_inst = "";
            //        string clinic_rcpdetail_ids = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string clinic_rcpdetail_id = dt.Rows[i]["id"].ToString();
                    clinic_rcpdetail_ids += clinic_rcpdetail_id + ",";
                    string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                    if (dt.Rows[i]["itemfrom"].ToString() == BasItemFrom.DRUG.ToString())
                    {
                        sql_inst += "insert into clinic_costdet ( "
                              + " id"                      //主键
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
                              + ",charged"          //00
                              + ",groupid"
                              + ",groupnum"
                              + ",unlocked"       //N
                              + ",retappstat"      //检查N处方Y
                              + " ) values ("
                              + DataTool.addFieldBraces(clinic_costdet_id)
                              + "," + DataTool.addFieldBraces(clinicRcp.Clinic_cost_id)
                              + "," + DataTool.addFieldBraces(clinicRcp.Regist_id)
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                              + "," + DataTool.addFieldBraces("RCP")
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdetail_id"].ToString())
                              + "," + DataTool.addFieldBraces(clinicRcp.Depart_id)
                              + "," + DataTool.addFieldBraces(clinicRcp.Doctor_id)
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["packsole"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["drug_packsole_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["drugprc"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["drugfee"].ToString())
                              + "," + DataTool.addFieldBraces("1")
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["drugrealfee"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                              + "," + DataTool.addFieldBraces(CostCharged.OO.ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["groupid"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["groupnum"].ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces("N")
                              + " ) ; ";
                        recipelfee += double.Parse(dt.Rows[i]["drugfee"].ToString());
                        realfee += double.Parse(dt.Rows[i]["drugrealfee"].ToString());
                    }
                    else
                    {
                        sql_inst += "insert into clinic_costdet ( "
                                  + " id"                      //主键
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
                                  + ",charged"          //00
                                  + ",groupid"
                                  + ",groupnum"
                                  + ",unlocked"       //N
                                  + ",retappstat"      //N
                                  + " ) values ("
                                  + DataTool.addFieldBraces(clinic_costdet_id)
                                  + "," + DataTool.addFieldBraces(clinicRcp.Clinic_cost_id)
                                  + "," + DataTool.addFieldBraces(clinicRcp.Regist_id)
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                                  + "," + DataTool.addFieldBraces("RCP")
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdetail_id"].ToString())
                                  + "," + DataTool.addFieldBraces(clinicRcp.Depart_id)
                                  + "," + DataTool.addFieldBraces(clinicRcp.Doctor_id)
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["exedep_id"].ToString())
                                  + "," + DataTool.addFieldBraces("N")
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["packsole"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["drug_packsole_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["costprc"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["costfee"].ToString())
                                  + "," + DataTool.addFieldBraces("1")
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["costrealfee"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype_id"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                                  + "," + DataTool.addFieldBraces(CostCharged.OO.ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["groupid"].ToString())
                                  + "," + DataTool.addFieldBraces(dt.Rows[i]["groupnum"].ToString())
                                  + "," + DataTool.addFieldBraces("N")
                                  + "," + DataTool.addFieldBraces("N")
                                  + " ) ; ";

                        recipelfee += double.Parse(DataTool.checkDouble(dt.Rows[i]["costfee"].ToString()));
                        realfee += double.Parse(DataTool.checkDouble(dt.Rows[i]["costrealfee"].ToString()));
                    }
                    clinic_costdet_ids += clinic_costdet_id + ",";
                    
                }
                clinic_rcpdetail_ids = clinic_rcpdetail_ids.Substring(0, clinic_rcpdetail_ids.Length - 1);
           //     clinic_costdet_ids = clinic_costdet_ids.Substring(0, clinic_costdet_ids.Length - 1);
            }
        }
        /// <summary>
        /// 导表    将检查记录、检查费用 分别导入 收费主表、收费主表明细 
        /// </summary>
        public int chkApp2ClinicCost(string chk_app_idS, ref string clinic_cost_ids, ref string clinic_costdet_ids)
        {
            if (chk_app_idS == "")
                return 0;
            DataTable dt = new DataTable();
            String sql_slt = "select "
                        + " regist_id"
                        + ",billcode"
                        + ",id"
                        + ",dep_id"
                        + ",doctor_id"
                        + ",rcpdate"
                        + ",exedep_id"
                        + ",exedoctor_id"
                        + ",recipelfee"
                        + " from chk_app"
                        + " where registkind = 'CLIN' and opstat = 'YES'"
                        + " and id in (" + chk_app_idS 
                        + " )";

            dt = BllMain.Db.Select(sql_slt).Tables[0];
            string sql_inst = "";
            string chk_app_ids = "";
            string chk_appcost_ids = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string chk_app_id = dt.Rows[i]["id"].ToString();
                    chk_app_ids += chk_app_id + ",";
                    string clinic_cost_id = BillSysBase.nextId("clinic_cost");

                    ClinicCostdet clinicCostdet = new ClinicCostdet();
                    clinicCostdet.Clinic_cost_id = clinic_cost_id;
                    clinicCostdet.Regist_id = dt.Rows[i]["regist_id"].ToString();
                    clinicCostdet.Depart_id = dt.Rows[i]["dep_id"].ToString();
                    clinicCostdet.Doctor_id = dt.Rows[i]["doctor_id"].ToString();
                    clinicCostdet.Exedep_id = dt.Rows[i]["exedep_id"].ToString();
                    clinicCostdet.Exedoctor_id = dt.Rows[i]["exedoctor_id"].ToString();
                    double recipelfee = 0;
                    double realfee = 0;
                    chkAppcost2ClinicCostdet(chk_app_id, clinicCostdet,ref recipelfee,ref realfee, ref sql_inst, ref chk_appcost_ids, ref clinic_costdet_ids);

                    sql_inst += "insert into clinic_cost ( "
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
                              + ",recipelfee"
                              + ",realfee"
                              + ",unlocked"           //N
                              + ",retappstat"         //N
                              + " ) values ("
                              + DataTool.addFieldBraces(clinic_cost_id)
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["regist_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["billcode"].ToString())
                              + "," + DataTool.addFieldBraces(CostRcpType.CHK.ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["dep_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["doctor_id"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["rcpdate"].ToString())
                              + "," + DataTool.addFieldBraces(Ischarged.N.ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["recipelfee"].ToString())
                              + "," + DataTool.addFieldBraces(dt.Rows[i]["recipelfee"].ToString())
                              + "," + DataTool.addFieldBraces("N")
                              + "," + DataTool.addFieldBraces("N")
                              + " ) ; ";

                    clinic_cost_ids += clinic_cost_id + ",";


                }
                if (chk_app_ids != "")
                {
                    chk_app_ids = chk_app_ids.Substring(0, chk_app_ids.Length - 1);
                    sql_inst += "update chk_app "
                      + " set syncost = 'Y'"
                      + " where id in ( "
                      + chk_app_ids
                      + " );";
                }
                if (chk_appcost_ids != "")
                {
                    chk_appcost_ids = chk_appcost_ids.Substring(0, chk_appcost_ids.Length - 1);
                    sql_inst += "update chk_appcost "
                       + " set syncost = 'Y'"
                       + " where id in ( "
                       + chk_appcost_ids
                       + " );";
                }
 
                return doExeSql(sql_inst);
            }
            return 0;
        }
        public void chkAppcost2ClinicCostdet(string chk_app_id, ClinicCostdet clinicCostdet, ref double recipelfee, ref double realfee, ref string sql_inst, ref string chk_appcost_ids, ref string clinic_costdet_ids)
        {
            DataTable dt = new DataTable();

            string sql_slt = "select "
                     + "chk_appcost.id"
                     + ",bas_item.standcode as standcode"
                     + ",chk_appcost.item_id as item_id"            //外键项目      隐式外键
                     + ",bas_item.itemfrom as itemfrom"
                     + ",bas_item.name as name"
                     + ",bas_item.spec as spec"
                     + ",bas_item.unit as unit"
                     + ",chk_appcost.num as num "
                     + ",bas_item.prov_prc as prc"
                     + ",chk_appcost.num * bas_item.prov_prc as fee"   //num * city_prc
                     + ",chk_appcost.num * bas_item.prov_prc as realfee"  //num * city_prc * discnt
                     + ",bas_item.itemtype_id as itemtype_id"               //费用类别
                     + ",bas_item.itemtype1_id as itemtype1_id"                  //核算类别
                     + ",chk_appcost.ordersn"
                     + " from chk_appcost,bas_item "
                     + " where chk_appcost.syncost = 'N' "
                     + " and chk_appcost.item_id = bas_item.id and chk_appcost.chk_app_id = " + chk_app_id + ";";

            dt = BllMain.Db.Select(sql_slt).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string chk_appcost_id = dt.Rows[i]["id"].ToString();
                    chk_appcost_ids += chk_appcost_id + ",";
                    string clinic_costdet_id = BillSysBase.nextId("clinic_costdet");
                    sql_inst += "insert into clinic_costdet ( "
                          + " id"                      //主键
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
                          + ",groupid"
                          + ",groupnum"
                          + ",unlocked"       //N
                          + ",retappstat"      //N
                          + " ) values ("
                          + DataTool.addFieldBraces(clinic_costdet_id)
                          + "," + DataTool.addFieldBraces(clinicCostdet.Clinic_cost_id)
                          + "," + DataTool.addFieldBraces(clinicCostdet.Regist_id)
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["standcode"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                          + "," + DataTool.addFieldBraces("CHK")
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                          + "," + DataTool.addFieldBraces(clinicCostdet.Depart_id)
                          + "," + DataTool.addFieldBraces(clinicCostdet.Doctor_id)
                          + "," + DataTool.addFieldBraces(clinicCostdet.Exedep_id)
                          + "," + DataTool.addFieldBraces(clinicCostdet.Exedoctor_id)
                          + "," + DataTool.addFieldBraces("N")
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["spec"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["unit"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["fee"].ToString())
                          + "," + DataTool.addFieldBraces("1")
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["realfee"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype_id"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["itemtype1_id"].ToString())
                          + "," + DataTool.addFieldBraces(CostCharged.OO.ToString())
                          + "," + DataTool.addFieldBraces("0")
                          + "," + DataTool.addFieldBraces(dt.Rows[i]["ordersn"].ToString())
                          + "," + DataTool.addFieldBraces("N")
                          + "," + DataTool.addFieldBraces("N")
                          + " ) ; ";
                    recipelfee += double.Parse(dt.Rows[i]["fee"].ToString());
                    realfee += double.Parse(dt.Rows[i]["realfee"].ToString());
                    clinic_costdet_ids += clinic_costdet_id + ",";
                }
            }
        }
        public int deleteSql(string clinic_rcp_id, string chk_app_idS, string clinic_cost_ids, string clinic_costdet_ids)
        {
            string sql = "delete from clinic_rcp where id = " + DataTool.addFieldBraces(clinic_rcp_id) + ";";
            sql += "delete from clinic_rcpdetail where clinic_rcp_id = " + DataTool.addFieldBraces(clinic_rcp_id) + ";" ;
            sql += "delete from chk_app where id in ( " + chk_app_idS + ");";
            sql += "delete from chk_appcost where chk_app_id in (" + chk_app_idS + ");";
            sql += "delete from clinic_cost where id in (" + clinic_cost_ids + ");";
            sql += "delete from clinic_costdet where id in (" + clinic_costdet_ids + ");";
            sql += "delete from drug_io where drug_app_id in (" + clinic_cost_ids + ");";
            sql += "delete from drug_iodetail where costdet_id in (" + clinic_costdet_ids + ");";
            return doExeSql(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <param name="patientName"></param>
        /// <returns></returns>
        public DataTable getRegisterInfo(string starTime, string endTime, string hspCard)
        {
            DataTable dt = new DataTable();

            String sql = "SELECT "
                + " register.id"
                + ",register.billcode"
               + ",register.name as regname"
               + ",register.bas_patienttype_id"
               + ",register.depart_id"
               + ",bas_depart.name as dptname"
               + ",register.doctor_id"
               + ",bas_doctor.name as dctname"
               + ",register.hspcard"
               + ",register.sex "
               + ",register.age"
               + ",register.member_id"
               + " from register left join bas_depart on register.depart_id = bas_depart.id "
               + " left join bas_doctor on bas_doctor.id = register.doctor_id "
               + " where  register.regdate>= " + DataTool.addFieldBraces(starTime)
               + " and register.regdate<= " + DataTool.addFieldBraces(endTime)
               + " and register.status = 'REG' ";
            if (!String.IsNullOrEmpty(hspCard))
                sql += " and register.hspcard = " + DataTool.addFieldBraces(hspCard);
            dt = BllMain.Db.Select(sql).Tables[0];

            return dt;
        }
       
    }
}
