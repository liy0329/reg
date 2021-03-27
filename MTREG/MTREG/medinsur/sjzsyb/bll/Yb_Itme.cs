using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb.bll
{
    public class Yb_Itme
    {
        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e)
            {
                SysWriteLogs.writeLogs1("数据库错误", DateTime.Now, "[" + sql + "]" + e.ToString());
            }

            return result;
        }
        // 清空医保医师
        public int deleteyb_doctoritme()
        {

            string sql = "DELETE FROM yb_doctoritme";

            return doExeSql(sql);
        }


        //---------------

        //病种查询初始化对照
        public DataTable Theplot(string Title)
        {
            string sql = "SELECT"
                    + " id AS  '编号',"
                    + " bas_caseicd_id AS  'his数据ID',"
                    + " bas_caseicd_name AS 'his名称',"
                    + " bas_caseicd_case_icd10 AS 'his疾病编码',"
                    + " insur_illness_id AS '医保编码',"
                    + " Insur_illness_name AS '医保名称',"
                    + " insur_illness_illcode AS '医保疾病编码' "
                    + " FROM "
                    + " insur_directory_contrast contrast"
                    + " WHERE"
                    + " contrast.bas_caseicd_name"
                    + " LIKE '%" + Title + "%'"
                    + " limit 1000";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        //病种双击对照表添加到数据库
        public string plot(string bas_caseicd_id, string bas_caseicd_name, string bas_caseicd_case_icd10, string insur_illness_id, string insur_illness_name, string insur_illness_illcode)
        {
            string sql = "";
            string id = BillSysBase.nextId("insur_directory_contrast");
            string sel_select = "SELECT id FROM insur_directory_contrast WHERE bas_caseicd_case_icd10 = " + DataTool.addFieldBraces(bas_caseicd_case_icd10) + ";";
            DataTable dt_dc = BllMain.Db.Select(sel_select).Tables[0];
            if (dt_dc.Rows.Count == 0)
            {
                sql = " INSERT INTO  insur_directory_contrast(id,bas_caseicd_id,bas_caseicd_name,bas_caseicd_case_icd10,insur_illness_id,insur_illness_name,insur_illness_illcode ) VALUES ("
                           + " NUll"
                           + "," + DataTool.addFieldBraces(bas_caseicd_id)
                           + "," + DataTool.addFieldBraces(bas_caseicd_name)
                           + "," + DataTool.addFieldBraces(bas_caseicd_case_icd10)
                           + "," + DataTool.addFieldBraces(insur_illness_id)
                           + "," + DataTool.addFieldBraces(insur_illness_name)
                           + "," + DataTool.addFieldBraces(insur_illness_illcode)
                           + ");";
            }
            else if (dt_dc.Rows.Count == 1)
            {
                sql = " UPDATE insur_directory_contrast SET "
                           + " bas_caseicd_id = " + DataTool.addFieldBraces(bas_caseicd_id)
                           + ",bas_caseicd_name =" + DataTool.addFieldBraces(bas_caseicd_name)
                           + ",bas_caseicd_case_icd10 = " + DataTool.addFieldBraces(bas_caseicd_case_icd10)
                           + ",insur_illness_id=" + DataTool.addFieldBraces(insur_illness_id)
                           + ",insur_illness_name=" + DataTool.addFieldBraces(insur_illness_name)
                           + ",insur_illness_illcode =" + DataTool.addFieldBraces(insur_illness_illcode)
                           + " WHERE id = " + DataTool.addFieldBraces(dt_dc.Rows[0]["id"].ToString())
                           + ";";
                
            }
            return sql;
        }
        /// <summary>
        /// 修改setbas_caseicd对照状态
        /// </summary>
        /// <param name="bas_caseicd_id"></param>
        /// <param name="iscoll">是否对照 N：未对照   Y：已对照</param>
        /// <returns></returns>
        public string setbas_caseicd(string bas_caseicd_id,string iscoll)
        {
            string sql = "UPDATE bas_caseicd SET iscoll = " + DataTool.addFieldBraces(iscoll) + " WHERE id =" + DataTool.addFieldBraces(bas_caseicd_id) + ";";
            return sql;
        }
        /// <summary>
        /// 删除三目对照记录cost_insurcross
        /// </summary>
        /// <param name="insurcode">医保编码</param>
        /// <param name="hiscode">院内编码</param>
        /// <returns></returns>
        public int Delete_insurcross(string insurcode, string hiscode)
        {
            int flag = -1;
            string sql = "DELETE FROM cost_insurcross where insurcode = " + DataTool.addFieldBraces(insurcode) + "AND hiscode = " + DataTool.addFieldBraces(hiscode);
            flag = BllMain.Db.Update(sql);
            return flag;
        }
        //病种HIS诊断
        public DataTable Diagnostics(string HISM, string HISBM, string diaType)
        {
            string sql = "SELECT"
                      + " single.id AS 'HIS编号',"
                      + " single.case_name AS 'HIS病种名称',"
                      + " single.pincode AS 'HIS拼音简码',"
                      + " single.case_icd10_6 AS 'HIS病种编码',"
                      + " CASE iscoll WHEN 'Y' THEN '已对照' ELSE '未对照' END AS '对照情况'"
                      + " FROM"
                      + " bas_caseicd single"
                      + " WHERE "
                      + " (single.pincode"
                      + " LIKE '%" + HISM + "%'"
                      + " or single.case_name"
                      + " LIKE '%" + HISM + "%')"
                      + " and"
                      + " single.case_icd10_6 "
                      + " LIKE '%" + HISBM + "%'"
                      + " AND iszxzd = " + DataTool.addFieldBraces(diaType);

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        //病种目录对照病种表
        public DataTable entityContrast(string ybpym, string ybbzm, string hisdy)
        {
            string sql = "SELECT"
                      + " illness.Id AS '编号',"
                      + " illness.`name` AS '病种名称',"
                      + " illness.pincode AS '拼音简码',"
                      + " illness.illcode AS '病种编码',"
                      + " illness.cost_insurtype_id AS '外键医保接口类型',"
                      + " illness.keyname AS '关键字',"
                      + " illness.insur_settleway_id AS '结算方式',"
                      + " illness.updatetime AS '更新时间' "
                      + " FROM"
                      + " insur_illness illness"
                      + " WHERE"
                      + " sign = 1 AND "
                      + " (illness.pincode"
                      + " LIKE '%" + ybpym + "%'"
                      + " or"
                      + " illness.`name`"
                      + "LIKE '%" + ybpym + "%')"
                      + " and"
                      + " illness.illcode "
                      + "LIKE '%" + ybbzm + "%'"
                      + "  LIMIT 1000";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        //----------------

        //更改三目对照表对照状态
        public int insurTpyr(string id, string type)
        {
            string sql = "UPDATE cost_insurcross set isstop = " + DataTool.addFieldBraces(type) + " WHERE id IN ( " + id + ")";
            return doExeSql(sql);
        }
        //查询三目对照表
        public DataTable Thequery(ref string id)
        {
            string sql = " SELECT "
                       + " cost.insurname AS '项目名称',"
                       + " cost.insurcode AS '医保编码',"
                       + " bas_item.`name` AS 'his名称',"
                       + " cost.hiscode AS 'his编码',"
                       + " bas_item.pincode AS 'his助记符',"
                       + " (SELECT `name` FROM sys_dict WHERE dicttype = 'drug_dosageform' AND sn = bas_item.dosageform_id) AS '剂型',"
                       + " bas_item.spec AS '规格',"
                       + " bas_item.city_prc AS '价格',"
                       + " cost.itemfrom AS '项目定义类型',"
                       + " cost.item_id AS '项目外键',"
                       + " cost.drug_factyitem_id AS '厂家序列',"
                       + " cost.insurclass AS '医保等级',"
                       + " cost.limituse AS '限制使用信息',"
                       + " ( CASE cost.Isstop WHEN 'N' THEN '已提交审核' WHEN 'Y' THEN '审核未通过' WHEN '' THEN '未审核' END ) AS '审核状态',"
                       + "cost.id AS '编号'"
                   + " FROM"
                       + " cost_insurcross cost"
                   + " LEFT JOIN bas_item ON cost.item_id = bas_item.id"
                   + " LEFT JOIN cost_insuritem ON cost.cost_insuritem_id = cost_insuritem.id"
                   + " WHERE"
                       + " cost.Isstop <> 'T' ";
            DataTable dttb = BllMain.Db.Select(sql).Tables[0];
            return dttb;
        }
        //三目对照成功添加到数据库显示 马庄
        public string Thecomparison(string AKC224, string his515, string YB515, string HIS077, string YB110, string HIS00, string xianzhi, string HIS0771)
        {
            string sql_de = "DELETE FROM cost_insurcross where item_id = " + DataTool.addFieldBraces(his515);
            if (doExeSql(sql_de) == -1)
                return "";
            string id = BillSysBase.nextId("cost_insurcross");
            string sql = "INSERT INTO cost_insurcross ( "
                                                    + "id,"
                                                    + "cost_insurtype_id,"
                                                    + "insuritemtype,"
                                                    + "itemfrom,"
                                                    + "item_id,"
                                                    + "drug_factyitem_id,"
                                                    + "cost_insuritem_id,"
                                                    + "insurcode,"
                                                    + "insurname,"
                                                    + "insurclass,"
                                                    + "limituse,"
                                                    + "hiscode,"
                                                    + "Isstop"
                                                    + ")VALUES("
                                                    + "null"
                                                    + "," + DataTool.addFieldBraces("23")
                                                    + "," + DataTool.addFieldBraces("2")
                                                    + "," + DataTool.addFieldBraces(AKC224)
                                                    + "," + DataTool.addFieldBraces(his515)
                                                    + "," + DataTool.addFieldBraces("0")
                                                    + "," + DataTool.addFieldBraces(YB515)
                                                    + "," + DataTool.addFieldBraces(HIS077)
                                                    + "," + DataTool.addFieldBraces(YB110)
                                                    + "," + DataTool.addFieldBraces(HIS00)
                                                    + "," + DataTool.addFieldBraces(xianzhi)
                                                    + "," + DataTool.addFieldBraces(HIS0771)
                                                    + "," + DataTool.addFieldBraces("Y")
                                                    + ")";
            return sql;

        }
        //医保模糊查询三种
        public DataTable Healthquery(string Healthspell, string HealthBOT, string Healthcoding, string itemfrom)
        {
            string sql = "SELECT"
                   + " insuritem.name AS'项目名称',"
                   + " insuritem.pincode AS'拼音简码',"
                   + " insuritem.insurcode AS'医保项目编码',"
                   + " insuritem.name2 AS'商品名称',"
                //+ " insuritem.Insuritemtype AS'医保目录码',"
                //+ " insuritem.standcode AS'统一编号',"
                //+ " insuritem.category AS'目录类别',"
                   + " insuritem.spec AS'规格',"
                   + " insuritem.unit AS'单位',"
                   + " insuritem.itemfrom AS'项目定义类型',"
                   + " insuritem.insurclass AS'医保等级',"
                   + " insuritem.dosageform AS'剂型',"
                   + " insuritem.drugfactory AS'外键厂家',"
                   + " insuritem.BKA643 AS '物价编码',"
                   //+ " insuritem.ratioclin AS'门诊报销比例',"
                   //+ " insuritem.ratioihsp AS'住院报销比例',"
                   + " insuritem.ratioself AS'自付比例',"
                   + " insuritem.ratioself_jm AS'居民自付比例',"
                   + " insuritem.islimitprc AS'是否限价',"
                   + " insuritem.limitprc AS'限价金额',"
                   + " insuritem.AKA068I AS'县级限价',"
                   + " insuritem.AKA068II AS'市级限价',"
                   + " insuritem.AKA068III AS'省级限价',"
                   + " insuritem.PUB_AKA068I AS'公立医院县级限价',"
                   + " insuritem.PUB_AKA068II AS'公立医院市级限价',"
                   + " insuritem.PUB_AKA068III AS'公立医院省级限价',"
                   + " insuritem.isspecial AS'特殊诊疗标志',"
                   + " insuritem.specprc AS'特殊诊疗限价',"
                   + " insuritem.limituse AS'限制使用信息',"
                   + " insuritem.approve AS'审批标志',"
                   + " insuritem.siglecharge AS'单独收费标志',"
                   + " insuritem.statenum AS'国药准字',"
                   + " insuritem.memo AS'备注',"
                   + " insuritem.updateat AS'更新时间',"
                   + " insuritem.id AS 'id',"
                   + " (CASE isstop WHEN 'N' THEN '有效' WHEN 'Y' THEN '停用' ELSE '其它' END)  AS '有效标志'"
                   + " FROM"
                   + " cost_insuritem insuritem"
                   + " WHERE"
                   + " insuritem.cost_insurtype_id = " + DataTool.addFieldBraces("23")
                   //+ "  AND isstop = 'N'"
                   + " and insuritem.itemfrom = " + DataTool.addFieldBraces(itemfrom);


            ////医保拼音码过滤
            if (!string.IsNullOrEmpty(Healthspell))
            {

                sql += "and insuritem.pincode "
                 + " LIKE'%" + Healthspell + "%'";
            }
            //医保项目名称过滤
            if (!string.IsNullOrEmpty(HealthBOT))
            {
                sql
                    += "and insuritem.name "
                    + " LIKE'%" + HealthBOT + "%'";
            }
            //医保项目编码过滤
            if (!string.IsNullOrEmpty(Healthcoding))
            {
                sql
                    += "and insuritem.insurcode "
                    + " LIKE'%" + Healthcoding + "%'";
            }
            sql += " limit 1000";
            DataTable dttb = BllMain.Db.Select(sql).Tables[0];

            return dttb;
        }
        /// <summary>
        /// 更新项目对照表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string insetInsurcross(string ybcode, string hiscode, string isstop, string iscurr, string memo, string starttime, string endtime, string audittime)
        {
            string sql = "UPDATE cost_insurcross set isstop = " + DataTool.addFieldBraces(isstop)
                        + ",iscurr=" + DataTool.addFieldBraces(iscurr)
                        + ", memo =" + DataTool.addFieldBraces(memo)
                        + ",starttime = " + DataTool.addFieldBraces(starttime)
                        + ",endtime =" + DataTool.addFieldBraces(endtime)
                        + ",audittime=" + DataTool.addFieldBraces(audittime)
                        + "  WHERE insurcode = " + DataTool.addFieldBraces(ybcode) + " AND hiscode = " + DataTool.addFieldBraces(hiscode) + " AND isstop <> 'T' ;";

            return sql;
        }
        public DataTable Healthquery_his(string Healthspell, string HealthBOT, string Healthcoding, string itemfrom)
        {
            string sql = " SELECT"
                       + " cost_insurcross.id,"
                       + " cost_insurcross.insurcode,"
                       + " cost_insurcross.insurname,"
                       + " bas_item.hiscode,"
                       + " bas_item.`name`,"
                       + " cost_insurcross.insurclass,"
                       + " (CASE cost_insurcross.isstop	WHEN 'T' THEN	'审核通过'	WHEN 'Y' THEN	'未审核'	WHEN 'NG' THEN	'审核未通过'		END	) AS AAE016,"
                       + " cost_insurcross.memo,"
                       + " cost_insurcross.audittime,"
                       + " cost_insurcross.starttime,"
                       + " cost_insurcross.endtime,"
                       + " (	CASE cost_insurcross.iscurr	WHEN '1' THEN		'有效'	WHEN '0' THEN		'停用' END	) AS iscurr,"
                       + " bas_item.pincode,"
                       + " cost_insuritem.isstop AS ybty"
                   + " FROM"
                       + " cost_insurcross ,cost_insuritem,bas_item"
                   + " WHERE"
                       + " cost_insurcross.cost_insurtype_id = " + DataTool.addFieldBraces("23")
                       + " AND  bas_item.id = cost_insurcross.item_id AND cost_insuritem.id = cost_insurcross.cost_insuritem_id "
                       +" and cost_insurcross.itemfrom = " + DataTool.addFieldBraces(itemfrom);
                        

            ////医保拼音码过滤
            if (!string.IsNullOrEmpty(Healthspell))
            {

                sql += "and bas_item.pincode  "
                 + " LIKE'%" + Healthspell + "%'";
            }
            //医保项目名称过滤
            if (!string.IsNullOrEmpty(HealthBOT))
            {
                sql
                    += "and bas_item.name "
                    + " LIKE'%" + HealthBOT + "%'";
            }
            //医保项目编码过滤
            if (!string.IsNullOrEmpty(Healthcoding))
            {
                sql
                    += "and bas_item.hiscode "
                    + " LIKE'%" + Healthcoding + "%'";
            }
            DataTable dttb = BllMain.Db.Select(sql).Tables[0];

            return dttb;
        }
        //全部以及HIS模糊查询
        public DataTable QBall(string name, string type)
        {
            string hqsql = "SELECT"
                         + " bsitem.`NAME` AS '项目名称',"
                         + " bsitem.pincode AS '拼音简码',"
                         + " bsitem.itemfrom AS '项目定义类型',"
                         + " bsitem.hiscode AS 'his编码',"
                         + " bsitem.prov_prc AS '省单价',"
                         + " bsitem.spec AS'规格',"
                         + " drug.`name` AS '生产厂家',"
                         + " bsitem.city_prc AS '市单价',"
                         + " bsitem.county_prc AS '县单价',"
                         + " bsitem.itemtype_id AS '项目类别',"
                         + " bsitem.itemtype1_id AS '核算类别',"
                         + " bsitem.bas_mediservicetype_id AS '医疗服务分类',"
                         + " bsitem.Isstop AS '停用',"
                         + " bsitem.dosageform_id AS '剂型' ,"
                         + " bsitem.id AS id ,"
                         + " cost_insurcross.isstop "
                         + " FROM bas_item bsitem "
                         + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bsitem.id"
                         + " LEFT JOIN (SELECT drug_factyitem.drugitem_id as 'id',GROUP_CONCAT( drug_factory.`name`,';') AS 'name' FROM  drug_factyitem "
                         + "            LEFT JOIN drug_factory ON drug_factyitem.drug_factory_id = drug_factory.id "
                         + "            WHERE drug_factyitem.drugitem_id <> '' AND drug_factory.`name`<> '' AND drug_factyitem.isstop = 'N' "
                         + "            GROUP BY drug_factyitem.drugitem_id) drug ON drug.id = bsitem.id "
                         + " WHERE "
                         + ((!String.IsNullOrEmpty(type)) ? "bsitem.itemfrom='" + type + "' AND" : "")
                         + " (bsitem.`name`"
                         + " LIKE'%" + name + "%'"
                        + " OR"
                        + " bsitem.pincode"
                        + " LIKE'%" + name + "%')"
                        + " AND bsitem.isstop = 'N'";
            DataTable dttb = BllMain.Db.Select(hqsql).Tables[0];

            return dttb;
        }
        /// 查询医保医师
        /// </summary>
        /// <returns></returns>
        public DataTable selectyb_doctoritme()
        {
            string sql = "select "
                              + "id,"
                              + "BKF050,"
                              + "BKF051,"
                              + "AKC273,"
                              + "AAC002,"
                              + "AAC004,"
                              + "AAC006,"
                              + "AAC011,"
                              + "BKC113,"
                              + "AAC005,"
                              + "AAB301,"
                              + "BKF063,"
                              + "BKC114,"
                              + "BKF066,"
                              + "AAF009,"
                              + "BKF573,"
                              + "BKF574,"
                              + "BKC115,"
                              + "BKF065,"
                              + "BKF569,"
                              + "AAE005,"
                              + "AKB020,"
                              + "AKF001,"
                              + "AAC020,"
                              + "AAE013 "
                          + " FROM "
                          + " yb_doctoritme";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 添加医保医师
        /// </summary>
        /// <returns></returns>
        public string addyb_doctoritme(Doctor_Out_OUTROW Doctor)
        {
            string id = BillSysBase.nextId("member_rechargedet");
            string sql = "INSERT INTO yb_doctoritme ( "
                              + "id,"
                              + "BKF050,"
                              + "BKF051,"
                              + "AKC273,"
                              + "AAC002,"
                              + "AAC004,"
                              + "AAC006,"
                              + "AAC011,"
                              + "BKC113,"
                              + "AAC005,"
                              + "AAB301,"
                              + "BKF063,"
                              + "BKC114,"
                              + "BKF066,"
                              + "AAF009,"
                              + "BKF573,"
                              + "BKF574,"
                              + "BKC115,"
                              + "BKF065,"
                              + "BKF569,"
                              + "AAE005,"
                              + "AKB020,"
                              + "AKF001,"
                              + "AAC020,"
                              + "AAE013 "
                          + ")VALUES( "
                              + DataTool.addFieldBraces(id)
                              + "," + DataTool.addFieldBraces(Doctor.BKF050)
                              + "," + DataTool.addFieldBraces(Doctor.BKF051)
                              + "," + DataTool.addFieldBraces(Doctor.AKC273)
                              + "," + DataTool.addFieldBraces(Doctor.AAC002)
                              + "," + DataTool.addFieldBraces(Doctor.AAC004)
                              + "," + DataTool.addFieldBraces(Doctor.AAC006)
                              + "," + DataTool.addFieldBraces(Doctor.AAC011)
                              + "," + DataTool.addFieldBraces(Doctor.BKC113)
                              + "," + DataTool.addFieldBraces(Doctor.AAC005)
                              + "," + DataTool.addFieldBraces(Doctor.AAB301)
                              + "," + DataTool.addFieldBraces(Doctor.BKF063)
                              + "," + DataTool.addFieldBraces(Doctor.BKC114)
                              + "," + DataTool.addFieldBraces(Doctor.BKF066)
                              + "," + DataTool.addFieldBraces(Doctor.AAF009)
                              + "," + DataTool.addFieldBraces(Doctor.BKF573)
                              + "," + DataTool.addFieldBraces(Doctor.BKF574)
                              + "," + DataTool.addFieldBraces(Doctor.BKC115)
                              + "," + DataTool.addFieldBraces(Doctor.BKF065)
                              + "," + DataTool.addFieldBraces(Doctor.BKF569)
                              + "," + DataTool.addFieldBraces(Doctor.AAE005)
                              + "," + DataTool.addFieldBraces(Doctor.AKB020)
                              + "," + DataTool.addFieldBraces(Doctor.AKF001)
                              + "," + DataTool.addFieldBraces(Doctor.AAC020)
                              + "," + DataTool.addFieldBraces(Doctor.AAE013)
                              + ");";
            return sql;
        }
        /// <summary>
        /// 查询医保科室
        /// </summary>
        /// <returns></returns>
        public DataTable selectyb_Deparitme()
        {
            string sql = " select AKF001,AKF003,AKF002,AKB020,BKF075,AKF015,AKF008,BKF005,BKF006,BKF061,AAE013 "
                       + " from yb_Departitme ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 清空医保科室目录
        /// </summary>
        /// <returns></returns>
        public int deleteyb_Departitme()
        {
            string sql = "DELETE FROM yb_Departitme";

            return doExeSql(sql);
        }
        /// <summary>
        /// 添加医保科室
        /// </summary>
        /// <returns></returns>
        public string addyb_Departitme(Depart_Out Depart)
        {
            string sql_dep = "INSERT INTO yb_Departitme (AKF001,AKF003,AKF002,AKB020,BKF075,AKF015,AKF008,BKF005,BKF006,BKF061,AAE013) "
                              + " VALUES ("

                              + DataTool.addFieldBraces(Depart.AKF001)
                              + "," + DataTool.addFieldBraces(Depart.AKF003)
                              + "," + DataTool.addFieldBraces(Depart.AKF002)
                              + "," + DataTool.addFieldBraces(Depart.AKB020)
                              + "," + DataTool.addFieldBraces(Depart.BKF075)
                              + "," + DataTool.addFieldBraces(Depart.AKF015)
                              + "," + DataTool.addFieldBraces(Depart.AKF008)
                              + "," + DataTool.addFieldBraces(Depart.BKF005)
                              + "," + DataTool.addFieldBraces(Depart.BKF006)
                              + "," + DataTool.addFieldBraces(Depart.BKF061)
                              + "," + DataTool.addFieldBraces(Depart.AAE013)
                              + ");";
            return sql_dep;
        }
        /// <summary>
        /// 清空病种
        /// </summary>
        /// <returns></returns>
        public int deleteyb_illness(string keyname)
        {
            string sql = "DELETE FROM insur_illness WHERE cost_insurtype_id = " + DataTool.addFieldBraces("23") + " AND type = " + DataTool.addFieldBraces(keyname);

            return doExeSql(sql);
        }
        // <summary>
        /// 添加医保疾病
        /// </summary>
        /// <returns></returns>
        public string addyb_illness(Diseaser_Out_OUTROW Disease)
        {
            string sql = "";
            string sele_sql = "SELECT COUNT(id)  AS COUNT  from insur_illness WHERE illcode = " + DataTool.addFieldBraces(Disease.AKA120);
            DataTable dt = BllMain.Db.Select(sele_sql).Tables[0];
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                string id = BillSysBase.nextId("insur_illness");
                sql = " INSERT INTO insur_illness (id,cost_insurtype_id,name,pincode,illcode,updatetime,type,sign,starttime,Endtime)"
                           + " VALUES( "
                           + DataTool.addFieldBraces(id)
                           + "," + DataTool.addFieldBraces("23");
                if (Disease.AKA121.IndexOf("'") != -1) //判断字符串是否含有单引号
                {
                    sql += ",\"" + Disease.AKA121 + "\"";
                }
                else
                {
                    sql += ",\'" + Disease.AKA121 + "\'";
                }
                if (Disease.AKA066.IndexOf("'") != -1) //判断字符串是否含有单引号
                {
                    sql += ",\"" + Disease.AKA066 + "\"";
                }
                else
                {
                    sql += ",\'" + Disease.AKA066 + "\'";
                }


                sql += "," + DataTool.addFieldBraces(Disease.AKA120)
                    + "," + DataTool.addFieldBraces(Disease.AAE035)
                    + "," + DataTool.addFieldBraces(Disease.AKA123)
                    + "," + DataTool.addFieldBraces(Disease.AAE100)
                    + "," + DataTool.addFieldBraces(Disease.AAE030)
                    + "," + DataTool.addFieldBraces(Disease.AAE031)
                    + " );";
            }
            else
            {

                sql += "UPDATE insur_illness SET ";
                if (Disease.AKA121.IndexOf("'") != -1) //判断字符串是否含有单引号
                {
                    sql += "name =\"" + Disease.AKA121 + "\",";
                }
                else
                {
                    sql += "name =\'" + Disease.AKA121 + "\',";
                }
                if (Disease.AKA066.IndexOf("'") != -1) //判断字符串是否含有单引号
                {
                    sql += "pincode = \"" + Disease.AKA066 + "\"";
                }
                else
                {
                    sql += "pincode =\'" + Disease.AKA066 + "\'";
                }
                sql += ",updatetime = " + DataTool.addFieldBraces(Disease.AAE035)
                 + ",type =" + DataTool.addFieldBraces(Disease.AKA123)
                 + ",sign = " + DataTool.addFieldBraces(Disease.AAE100)
                 + ",starttime = " + DataTool.addFieldBraces(Disease.AAE030)
                 + ",Endtime = " + DataTool.addFieldBraces(Disease.AAE031)
                 + " where illcode = " + DataTool.addFieldBraces(Disease.AKA120) + ";";
            }
            return sql;
        }
        // <summary>
        /// 添加医保药品
        /// </summary>
        /// <returns></returns>
        public string addyb_insuritem_yp(Directory_Out_yp_OUTROW yb_out_dir_yp)
        {
            string sql = "";
            yb_out_dir_yp.AAE035 = yb_out_dir_yp.AAE035.Substring(0, 4) + "-" + yb_out_dir_yp.AAE035.Substring(4, 2) + "-" + yb_out_dir_yp.AAE035.Substring(6, 2);
            if (yb_out_dir_yp.AKA065 == "1")
            {
                yb_out_dir_yp.AKA065 = "甲";
            }
            else if (yb_out_dir_yp.AKA065 == "2")
            {
                yb_out_dir_yp.AKA065 = "乙";
            }
            else if (yb_out_dir_yp.AKA065 == "3")
            {
                yb_out_dir_yp.AKA065 = "丙";
            }
            string sele_sql = "SELECT COUNT(id)  AS COUNT  from cost_insuritem WHERE insurcode = " + DataTool.addFieldBraces(yb_out_dir_yp.AKA060);
            DataTable dt = BllMain.Db.Select(sele_sql).Tables[0];
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                string id = BillSysBase.nextId("insur_illness");
                sql += " INSERT INTO cost_insuritem ("
                     + " id,"
                     + " cost_insurtype_id,"
                     + " NAME,"
                     + " pincode,"
                     + " name2,"
                     + " insurcode,"
                     + " spec,"
                     + " unit,"
                     + " itemfrom,"
                     + " ratioself,"
                     + " ratioself_jm,"
                     + " insurclass,"
                     + " dosageform,"
                     + " islimitprc,"
                     + " AKA068,"
                     + " drugfactory,"
                     + " limituse,"
                     + " memo,"
                     + " isstop,"
                     + " updateat"
                 + " )"
                 + " VALUES ( "
                     + DataTool.addFieldBraces(id)
                     + "," + DataTool.addFieldBraces("23")
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA061)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA066)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA079)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA060)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA077)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA076)
                     + "," + DataTool.addFieldBraces("DRUG")
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA069)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA069_JM)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA065)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA070)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.CKAA10)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AKA068)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.CKAA00)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.CKAA02)
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AAE013)
                     + "," + DataTool.addFieldBraces((yb_out_dir_yp.AAE100 == "0") ? "Y" : "N")
                     + "," + DataTool.addFieldBraces(yb_out_dir_yp.AAE035)
                     + ");";

            }
            else
            {
                sql += " UPDATE cost_insuritem  SET "
                     + " NAME =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA061) + ","
                     + " pincode =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA066) + ","
                     + " name2 =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA079) + ","
                     + " spec =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA077) + ","
                     + " unit =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA076) + ","
                     + " ratioself =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA069) + ","
                     + " ratioself_jm =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA069_JM) + ","
                     + " insurclass =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA065) + ","
                     + " dosageform =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA070) + ","
                     + " islimitprc =" + DataTool.addFieldBraces(yb_out_dir_yp.CKAA10) + ","
                     + " AKA068 =" + DataTool.addFieldBraces(yb_out_dir_yp.AKA068) + ","
                     + " limituse =" + DataTool.addFieldBraces(yb_out_dir_yp.CKAA02) + ","
                     + " drugfactory = " +DataTool.addFieldBraces(yb_out_dir_yp.CKAA00) + ","
                     + " memo =" + DataTool.addFieldBraces(yb_out_dir_yp.AAE013) + ","
                     + " ISSTOP =" + DataTool.addFieldBraces((yb_out_dir_yp.AAE100 == "0") ? "Y" : "N") + ","
                     + " updateat =" + DataTool.addFieldBraces(yb_out_dir_yp.AAE035)
                     + "WHERE insurcode = " + DataTool.addFieldBraces(yb_out_dir_yp.AKA060) + ";";
            }
            return sql;
        }
        // <summary>
        /// 添加医保诊疗
        /// </summary>
        /// <returns></returns>
        public string addyb_insuritem_zl(Directory_Out_zl_OUTROW yb_out_dir_zl)
        {
            string sql = "";
            yb_out_dir_zl.AAE035 = yb_out_dir_zl.AAE035.Substring(0, 4) + "-" + yb_out_dir_zl.AAE035.Substring(4, 2) + "-" + yb_out_dir_zl.AAE035.Substring(6, 2);
            if (yb_out_dir_zl.AKA065 == "1")
            {
                yb_out_dir_zl.AKA065 = "甲";
            }
            else if (yb_out_dir_zl.AKA065 == "2")
            {
                yb_out_dir_zl.AKA065 = "乙";
            }
            else if (yb_out_dir_zl.AKA065 == "3")
            {
                yb_out_dir_zl.AKA065 = "丙";
            }
            string sele_sql = "SELECT COUNT(id)  AS COUNT  from cost_insuritem WHERE insurcode = " + DataTool.addFieldBraces(yb_out_dir_zl.AKA090);
            DataTable dt = BllMain.Db.Select(sele_sql).Tables[0];
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                string id = BillSysBase.nextId("insur_illness");
                sql += " INSERT INTO cost_insuritem ( "
                    + " id,"
                    + " cost_insurtype_id,"
                    + " NAME,"
                    + " pincode,"
                    + " insurcode,"
                    + " unit,"
                    + " CKAA00,"
                    + " AKA068I,"
                    + " AKA068II,"
                    + " AKA068III,"
                    + " PUB_AKA068I,"
                    + " PUB_AKA068II,"
                    + " PUB_AKA068III,"
                    + " BKA643,"
                    + " itemfrom,"
                    + " ratioself,"
                    + " ratioself_jm,"
                    + " insurclass,"
                    + " islimitprc,"
                    + " isstop,"
                    + " updateat"
                + " )"
                + " VALUES"
                    + " ("
                    + DataTool.addFieldBraces(id)
                    + "," + DataTool.addFieldBraces("23")
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA091)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA066)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA090)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA076)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.CKAA00)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA068I)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA068II)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA068III)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068I)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068II)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068III)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.BKA643)
                    + "," + DataTool.addFieldBraces("COST")
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA069)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA069_JM)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AKA065)
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.CKAA10)
                    + "," + DataTool.addFieldBraces((yb_out_dir_zl.AAE100 == "0") ? "Y" : "N")
                    + "," + DataTool.addFieldBraces(yb_out_dir_zl.AAE035)
                    + " );";
            }
            else
            {
                sql += " UPDATE cost_insuritem SET "
                    + " NAME =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA091) + ","
                    + " pincode =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA066) + ","
                    + " unit =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA076) + ","
                    + " ratioself =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA069) + ","
                    + " ratioself_jm =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA069_JM) + ","
                    + " CKAA00 =" + DataTool.addFieldBraces(yb_out_dir_zl.CKAA00) + ","
                    + " AKA068I =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA068I) + ","
                    + " AKA068II =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA068II) + ","
                    + " AKA068III =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA068III) + ","
                    + " PUB_AKA068I =" + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068I) + ","
                    + " PUB_AKA068II =" + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068II) + ","
                    + " PUB_AKA068III =" + DataTool.addFieldBraces(yb_out_dir_zl.PUB_AKA068III) + ","
                    + " BKA643 =" + DataTool.addFieldBraces(yb_out_dir_zl.BKA643) + ","
                    + " insurclass =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA065) + ","
                    + " islimitprc =" + DataTool.addFieldBraces(yb_out_dir_zl.CKAA10) + ","
                    + " isstop = " + DataTool.addFieldBraces((yb_out_dir_zl.AAE100 == "0") ? "Y" : "N") + ","
                    + " updateat =" + DataTool.addFieldBraces(yb_out_dir_zl.AAE035)
                    + "WHERE insurcode =" + DataTool.addFieldBraces(yb_out_dir_zl.AKA090) + ";";
            }
            return sql;
        }
        // <summary>
        /// 添加医保服务
        /// </summary>
        /// <returns></returns>
        public string addyb_insuritem_fw(Directory_Out_fw_OUTROW yb_out_dir_fw)
        {
            string sql = "";
            yb_out_dir_fw.AAE035 = yb_out_dir_fw.AAE035.Substring(0, 4) + "-" + yb_out_dir_fw.AAE035.Substring(4, 2) + "-" + yb_out_dir_fw.AAE035.Substring(6, 2);

            string sele_sql = "SELECT COUNT(id)  AS COUNT  from cost_insuritem WHERE insurcode = " + DataTool.addFieldBraces(yb_out_dir_fw.AKA100);
            DataTable dt = BllMain.Db.Select(sele_sql).Tables[0];
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                string id = BillSysBase.nextId("insur_illness");
                sql += " INSERT INTO cost_insuritem ( "
                    + " id,"
                    + " cost_insurtype_id,"
                    + " NAME,"
                    + " pincode,"
                    + " insurcode,"
                    + " unit,"
                    + " CKAA00,"
                    + " AKA068I,"
                    + " AKA068II,"
                    + " AKA068III,"
                    + " PUB_AKA068I,"
                    + " PUB_AKA068II,"
                    + " PUB_AKA068III,"
                    + " BKA643,"
                    + " itemfrom,"
                    + " ratioself,"
                    + " ratioself_jm,"
                    + " insurclass,"
                    + " islimitprc,"
                    + " isstop,"
                    + " updateat"
                + " )"
                + " VALUES"
                    + " ("
                    + DataTool.addFieldBraces(id)
                    + "," + DataTool.addFieldBraces("23")
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA102)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA066)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA100)
                    + "," + DataTool.addFieldBraces("")
                    + "," + DataTool.addFieldBraces("")
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA068I)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA068II)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA068III)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068I)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068II)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068III)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.BKA643)
                    + "," + DataTool.addFieldBraces("BED")
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA069)
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AKA069_JM)
                    + "," + DataTool.addFieldBraces("")
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.CKAA10)
                    + "," + DataTool.addFieldBraces((yb_out_dir_fw.AAE100 == "0") ? "Y" : "N")
                    + "," + DataTool.addFieldBraces(yb_out_dir_fw.AAE035)
                    + " );";
            }
            else
            {
                sql += " UPDATE cost_insuritem SET "
                    + " NAME =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA102) + ","
                    + " pincode =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA066) + ","
                    + " AKA068I =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA068I) + ","
                    + " AKA068II =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA068II) + ","
                    + " AKA068III =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA068III) + ","
                    + " PUB_AKA068I =" + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068I) + ","
                    + " PUB_AKA068II =" + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068II) + ","
                    + " PUB_AKA068III =" + DataTool.addFieldBraces(yb_out_dir_fw.PUB_AKA068III) + ","
                    + " BKA643 =" + DataTool.addFieldBraces(yb_out_dir_fw.BKA643) + ","
                    + " ratioself =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA069) + ","
                    + " ratioself_jm =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA069_JM) + ","
                    + " islimitprc =" + DataTool.addFieldBraces(yb_out_dir_fw.CKAA10) + ","
                    + " isstop =" + DataTool.addFieldBraces((yb_out_dir_fw.AAE100 == "0") ? "Y" : "N") + ","
                    + " updateat =" + DataTool.addFieldBraces(yb_out_dir_fw.AAE035)
                    + "WHERE insurcode =" + DataTool.addFieldBraces(yb_out_dir_fw.AKA100) + ";";
            }
            return sql;
        }
        /// <summary>
        /// 查询医保疾病
        /// </summary>
        /// <returns></returns>
        public DataTable selectyb_illness(string type)
        {
            string sql = " SELECT id,cost_insurtype_id,name,pincode,illcode,updatetime,keyname FROM insur_illness "
                       + " WHERE cost_insurtype_id = '23' AND type = " + DataTool.addFieldBraces(type);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 删除病种可用三目范围
        /// </summary>
        public void deleteybinsur_scope()
        {
            string sql = "delete from insur_scope;";
            BllMain.Db.Update(sql);

        }
            
        /// <summary>
        /// 添加病种可用三目范围
        /// </summary>
        /// <returns></returns>
        public string Addybinsur_scope(bzkysmfwxz_Out_OUTROW dom)
        {
            string sql = "";
            sql = " INSERT INTO INSUR_scope (`AKA130`, `AKA120`, `AKE001`, `AAE100`, `AAE013`, `AAE030`, `AAE031`) "
                + " VALUES ("
                + DataTool.addFieldBraces(dom.AKA130)
                + "," + DataTool.addFieldBraces(dom.AKA120)
                + "," + DataTool.addFieldBraces(dom.AKE001)
                + "," + DataTool.addFieldBraces(dom.AAE100)
                + "," + DataTool.addFieldBraces(dom.AAE013)
                + "," + DataTool.addFieldBraces(dom.AAE030)
                + "," + DataTool.addFieldBraces(dom.AAE031)
                + ");";
            return sql;
        }

    }
}
