/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       ComBoxUtils
     * 机器名称：       TIANCI
     * 命名空间：       MTLIS.common
     * 文 件 名：       ComBoxUtils
     * 创建时间：       2013/5/13 14:43:37
     * 作    者：       杨天赐
     * 说   明：        系统Combox下拉的取数据工具类
     * 修改时间：       2013/5/22 9:40:37
     * 修 改 人：       田非
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.db;
using MTHIS.main.bll;
using System.Windows.Forms;

namespace MTHIS.common
{
    /**定义一些常用的下拉选择**/
    public class ComBoxUtils
    {
      
        /// <summary>
        ///返回仪器设备数据 
        /// </summary>
        public static DataTable getDevList()
        {
            string sql = "select ld.id as id , ld.devname as name,ld.printtemp1 as mod_id from lis_dev ld where ld.isUsed=1 and isselected=1";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        ///返回相应检验类型下的检验项目
        /// </summary>
        public static DataTable getItemList(int id)
        {
            string sql = "";
            if (id == 0)
            {
                sql = "select i.id,i.name from lis_item i where (i.isstrval = 1 or i.isstrval=6) and i.id in (select di.item_id from lis_devitem di)";
            }
            else
            {
                sql = "select i.id,i.name from lis_item i where i.chktype_id='" + id + "' and (isstrval = 1 or isstrval= 6) and i.id in (select di.item_id from lis_devitem di)";
            }
            
            return BllMain.Db.Select(sql).Tables[0];
        }


        public static DataTable getItemList(string pincode,int id)
        {
            string sql = "";
            if (id == 0)
            {
                sql = "select i.id,i.name from lis_item i where (i.isstrval = 1 or i.isstrval=6) and i.id in (select di.item_id from lis_devitem di)  and i.pincode like '%" + pincode + "%' ";
            }
            else
            {
                sql = "select i.id,i.name from lis_item i where i.chktype_id='" + id + "' and (isstrval = 1 or isstrval= 6) and i.id in (select di.item_id from lis_devitem di)  and i.pincode like '%" + pincode + "%'";
            }

            return BllMain.Db.Select(sql).Tables[0];
        }



        /// <summary>
        /// 返回模板数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getlis_print()
        {
            string sql = " select printcode,printname from lis_print";
            return BllMain.Db.Select(sql).Tables[0];
        }
        
        /// <summary>
        ///根据检验类型返回仪器设备数据 
        /// </summary>
        public static DataTable getDevListByChkType(string type)
        {
            string sql = "select ld.id as id , ld.devname as name from lis_dev ld where ld.isUsed=1 and ld.isselected=1" +
                ((type != "0" && type != "") ? " and chktype_id='" + type + "'" : "");
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        ///返回相同检验类型的仪器设备数据 
        /// </summary>
        public static DataTable getDevListByDev(string devid)
        {
            string sql = "select ld.id as id, ld.devname as name from lis_dev ld where ld.isUsed=1 and ld.isselected=1"
                + (devid != "" ? (" and chktype_id in (select chktype_id from lis_dev where id='" + devid + "')") : "");
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        ///返回默认质控规则 
        /// </summary>
        public static DataTable getDefQltyRuleList() 
        {
            string sql = "select ld.id as id , ld.name as 'name' from lis_dict ld where ld.isShow=1 and ld.dicttype='"
                +DictTypeConstant.QLTY_RULE+"' and ld.father_id != 0";
            return BllMain.Db.Select(sql).Tables[0]; 
        }
        /// <summary>
        ///  返回批号数据 (通过仪器id)
        /// </summary>
        public static DataTable getBatchList(int dev_id)
        {
            string sql = string.Format("select id as qlty_id ,batch as batch from lis_quality qlty  where dev_id={0} order by id asc ", dev_id);
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 返回质控品名称
        /// </summary>
        /// <returns></returns>
        public static DataTable getQlty(int dev_id)
        {
            string sql = "select distinct"
                       + " name as name"
                       + " from lis_quality qlty"
                       + " where" 
                       + " dev_id=" + dev_id
                       + " and isUsed=1 order by name asc ";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        ///  返回质控项目数据
        /// </summary>
        public static DataTable getQltyPrjList(int qlty_id)
        {
            string sql = string.Format("select id as qltyItem_id ,'name' as prjname from lis_qualityitem where quality_id={0} order by id asc",qlty_id);
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        ///  返回质控明细中实验方法
        /// </summary>
        public static DataTable getTestMethod() 
        {
            string sql = "select ld.id as id , ld.name as name from lis_dict ld where ld.isShow=1 and ld.dicttype='" + DictTypeConstant.CHK_METHOD + "' and ld.father_id != 0";
             return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        ///  返回质控项目明细中 使用波长
        /// </summary>
        public static DataTable getWavelength()
        {
            string sql = "select ld.id as id , ld.name as name from lis_dict ld where ld.isShow=1 and ld.dicttype='" + DictTypeConstant.QLTY_WAVE_LENGTH + "' and ld.father_id != 0";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 返回失控处理中的失控原因维护
        /// </summary>
        /// <returns></returns>
        public static DataTable getLoseCasue()
        {
            string sql = "select ld.id as id , ld.name as name from lis_dict ld where ld.isShow=1 and ld.dicttype='" + DictTypeConstant.LOSE_CAUSE + "' and ld.father_id != 0";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 返回失控处理中的措施维护
        /// </summary>
        /// <returns></returns>
        public static DataTable getCorrectMeasures()
        {
            string sql = "select ld.id as id , ld.name as name from lis_dict ld where ld.isShow=1 and ld.dicttype='" + DictTypeConstant.CORRECT_MEASURE + "' and ld.father_id != 0";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 返回失控处理中的结果维护
        /// </summary>
        /// <returns></returns>
        public static DataTable getCorrectResult()
        {
            string sql = "select ld.id as id , ld.name as name from lis_dict ld where ld.isShow=1 and ld.dicttype='" + DictTypeConstant.CORRECT_RESULT + "' and ld.father_id != 0";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDepart()
        {
            string sql = "select * from lis_depart where isshow=1";
            return BllMain.Db.Select(sql).Tables[0];
        }


        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDepartAll()
        {
            string sql = "select * from lis_depart ";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDepart(string pincode)
        {
            string sql = "select * from lis_depart where isshow='1' and pincode like '%" + pincode + "%'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获取医生列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDoctor()
        {
            string sql = "select * from lis_doctor where isshow='1'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据科室获取医生列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDoctor(string departid)
        {
            string sql = "select * from lis_doctor where isshow='1' and depart_id = '" + departid  + "'";
            return BllMain.Db.Select(sql).Tables[0];
        }


        /// <summary>
        /// 根据科室，简码获取医生列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getDoctor(string departid, string pincode)
        {
            string sql = "select * from lis_doctor where isshow='1' and depart_id = '" + departid + "' and pincode like '%" + pincode + "%'";
            return BllMain.Db.Select(sql).Tables[0];
        }

        
        /// <summary>
        /// 根据数据类型获得字典列表
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <returns></returns>
        public static DataTable getListByType(String type)
        {
            string sql = "select name, id, sn,memo from lis_dict where dicttype='" + type + "' and father_id != 0 and isshow='1' order by sn";
            return BllMain.Db.Select(sql).Tables[0];
        }

        public static DataTable getListByType(string pincode,String type)
        {
            string sql = "select id, name, sn from lis_dict where dicttype='" + type + "' and father_id != 0 and isshow='1' and pincode like '%" + pincode + "%'";
            return BllMain.Db.Select(sql).Tables[0];
        }

  
        /// <summary>
        /// 获取表中某个字段的最大值
        /// </summary>
        /// <param name="dt">表</param>
        /// <param name="OrderField">对应字段</param>
        /// <returns>最大值</returns>
        public static string GetMaxOrderCode(DataTable dt, string OrderField)
        {
            string orderCode = "1";
            if (dt.Rows.Count > 0)
                orderCode = (Convert.ToInt16(dt.Compute("max([" + OrderField + "])", "")) + 1).ToString();
            return orderCode;
        }


        public static DataTable getPlatList()
        {
            string sql = "select * from lis_platform";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 根据设备id获取套餐 添加人：杨慧慧，添加原因：窗体的需要， 添加时间：2013-12-02
        /// </summary>
        /// <param name="devid"></param>
        /// <returns></returns>
        public static DataTable getDiagnest(int devid)
        {
            string sql = "select id, name from lis_diagnset " +
                " where defdev_id = " + devid;
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 获得对应设备，对应检验套餐的检验项目
        /// </summary>
        /// <param name="diagnestid"></param>
        /// <param name="devid"></param>
        /// <returns></returns>
        public static DataTable getItem(string id_s,string opdate,string dev_id)
        {
            #region 注释
            
            ////string sql = "select di.item_id as id, di.name from lis_diagnitem di" +
            ////        " left join lis_diagnset d on d.id = di.diagnset_id " +
            ////        " where d.defdev_id = " + devid +
            ////    // " and d.id = " + diagnestid +
            ////        " ";
            //string sql = "select distinct ai.name, ai.item_id as id from  lis_appitem as ai" +
            //    " left join lis_app as a on a.id = ai.app_id " +
            //    //" left join lis_item it on it.id = ai.item_id " +
            //    " where a.dev_id = " + devid +
            //    " and a.opdate = '" + opdate +
            //    "' and ai.opdate = '" + opdate +
            //    "' and ai.dev_id = " + devid;
            //    //" order by it.id";
             
            #endregion
            string sql = "select distinct ai.item_id as id, ai.name as name from lis_appitem as ai"
                + " left join lis_app as a on a.app_sn = ai.app_sn "
                + " where a.opdate = '" + opdate + "' and a.dev_id = '" + dev_id + "' and a.id in (" + id_s + ")";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 得到病人检验单中项目的结果值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opdate"></param>
        /// <param name="dev_id"></param>
        /// <param name="item_id"></param>
        /// <returns></returns>
        public static string item_val(string id, string opdate, string dev_id, string item_id)
        {
            string sql = "select ai.resstr from lis_appitem as ai"
                + " left join lis_app as a on a.app_sn = ai.app_sn "
                + " where a.id = '" + id + "' and a.opdate = '" + opdate + "' and a.dev_id = '" + dev_id + "' and ai.item_id = '" + item_id + "' and isrecive = 1";
            DataTable dt =  BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["resstr"] != null)
                {
                    return dt.Rows[0]["resstr"].ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            else
            {
                return "NULL";
            }
        }
        /// <summary>
        /// 查询是否已经存在了相同的样本号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opdate"></param>
        /// <param name="dev_id"></param>
        /// <returns></returns>
        public static string isHaveSampleID(string id, string opdate, string dev_id)
        {

            string newid = "";
            string sql = "select * from lis_app where opdate = '" + opdate + "' and dev_id = '" + dev_id + "' and ID = '" + id + "' and isrecive = 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                newid = id;
            }
            return newid;
        }
        /// <summary>
        /// 修改样本号
        /// </summary>
        /// <param name="oldid"></param>
        /// <param name="opdate"></param>
        /// <param name="dev_id"></param>
        /// <param name="newid"></param>
        /// <returns></returns>
        public static bool changeSampleID(string oldid, string opdate, string dev_id, string newid)
        {
            string app_sn = "0";
            string sql_app_sn = "select * from lis_app where opdate = '" + opdate + "' and dev_id = '" + dev_id + "' and ID = '" + oldid + "' and isrecive = 1 ;";
            DataTable dt = BllMain.Db.Select(sql_app_sn).Tables[0];
            if (dt.Rows.Count > 0)
            {
                app_sn = dt.Rows[0]["app_sn"].ToString();
            }

            string sql = "update lis_app set id = '" + newid + "' where app_sn = '" + app_sn + "' ;"
                + " update lis_appitem set app_id = '" + newid + "' where app_sn = '" + app_sn + "' ; ";
            int i = BllMain.Db.Update(sql);
            if (i >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
            
        }

        /// <summary>
        /// 更新结果
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opdate"></param>
        /// <param name="dev_id"></param>
        /// <param name="item_id"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void  updateCalibrateResult(string id, string opdate, string dev_id, string item_id, string result)
        {

            string sql_app = " select * from lis_app where lis_app.id = '" + id + "' and lis_app.opdate = '" + opdate + "' and lis_app.dev_id = '" + dev_id + "'";
            DataTable dt_app  =  BllMain.Db.Select(sql_app).Tables[0];
            string app_sn = "";
            if (dt_app.Rows.Count > 0)
            {
                app_sn = dt_app.Rows[0]["app_sn"].ToString();
            }
            if (result == null)
            {
                string sql = "update lis_appitem set lis_appitem.resstr = NULL "
                + " "
                + " where  lis_appitem.item_id = '" + item_id + "' and lis_appitem.app_sn = '" + app_sn + "'";
                int i = BllMain.Db.Update(sql);
            }
            else
            {
                if (IsNumber(result))
                {
                    string sql = "update lis_appitem set lis_appitem.resstr = '" + result + "', lis_appitem.resval = " + result + " "
                + " "
                + " where  lis_appitem.item_id = '" + item_id + "' and lis_appitem.app_sn = '" + app_sn + "'";
                    int i = BllMain.Db.Update(sql);
                }
                else
                {
                    string sql = "update lis_appitem set lis_appitem.resstr = '" + result + "'"
                + " "
                + " where  lis_appitem.item_id = '" + item_id + "' and lis_appitem.app_sn = '" + app_sn + "'";
                    int i = BllMain.Db.Update(sql);
                }
            }
            
        }

        public static bool IsNumber(string resstr)
        {
            try
            {
                if (resstr.Length > 0)
                {
                    if (resstr.Substring(0, 1) == "0")
                    {
                        return false;
                    }
                    else if (resstr.Substring(0, 1) == "-" && resstr.Length > 1)
                    {
                        resstr = resstr.Substring(1, resstr.Length - 1);
                    }
                    char[] num_s = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
                    char[] resstr_chars = resstr.ToCharArray();
                    bool isnum = false;
                    for (int i = 0; i < resstr_chars.Length; i++)
                    {
                        for (int j = 0; j < num_s.Length; j++)
                        {
                            if (resstr_chars[i] == num_s[j])
                            {
                                isnum = true;
                                break;
                            }
                        }
                        if (isnum == false)
                        {
                            return false;
                        }
                        isnum = false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 获取检验单
        /// </summary>
        /// <param name="whereSql">在其他页面的业务层拼sql</param>
        /// <returns>检验单表</returns>
        public static DataTable getCheckApp(string devid, string opdate)
        {
            // add ytc
            StringBuilder sql = new StringBuilder();
            sql.Append("select");
            sql.Append("     la.id as id, la.opdate as opdate,la.dev_id as dev_id,la.appdate as appdate,");
            sql.Append("     la.diagnset_id as diagnset_id,la.app_sn as app_id,la.ihsp_id as ihsp_id,li.ihsp_id as ihspNum, ");
            sql.Append("     la.depart_id as depart_id, la.doctor_id as doctor_id ,la.sampletype_id as sampletype_id, ");
            sql.Append("     la.apptype_id as apptype_id, la.operator_id as operator_id ,la.checkleader_id as checkleader_id,");
            sql.Append("     la.sendor_id as sendor_id , la.status_id as status_id, li.phonenum as phonenum,");
            sql.Append("     la.diagnsetname as diagnsetname,la.isrecive as isrecive,la.ischarged as ischarged, ");
            sql.Append("     la.invalid as invalid,la.checking as checking,la.chkdate as chkdate, la.appbillno as appbillno,");
            sql.Append("     la.barcode as barcode,la.isfirstprint as isfirstprint,la.ischk as ischk, ");
            sql.Append("     la.platform_id as platform_id ,la.diagndesc as diagndesc, la.issend as issend, ");
            sql.Append("     la.memo as memo,la.urgentstate as urgentstate,la.sumtotal as sumtotal, ");
            sql.Append("     la.chargedate as chargedate,la.invoice as invoice, la.senddate as senddate,");
            sql.Append("     li.name as name,li.sex as sex,li.age as age, li.ageunit as ageunit,  ");
            sql.Append("     statusDict.name as status,");
            sql.Append("     (select name from lis_dict dict where dict.dicttype='apptype' and dict.sn=la.apptype_id) as apptype, ");
            sql.Append("     sampDict.name as sampletype,ld.name as depart, li.bednum as bednum, ");
            sql.Append("     operAcc.name as operator,chkAcc.name as checkleader,");
            sql.Append("     diagn.name as diagnset,diagn.defdev_id as defdev_id,");
            sql.Append("     sendorAcc.name as sendor  ");
            sql.Append("from lis_app la ");
            sql.Append("left join lis_ihsp li on la.ihsp_id =li.id  ");
            sql.Append("left join lis_diagnset diagn on la.diagnset_id=diagn.id  ");
            sql.Append("left join lis_dict sampDict  on  sampDict.id=la.sampletype_id  ");
            sql.Append("left join lis_dict statusDict on statusDict.id=la.status_id ");
            sql.Append("left join lis_depart ld on ld.id=la.depart_id  ");
            sql.Append("left join lis_account operAcc  on  operAcc.id =la.operator_id  ");
            sql.Append("left join lis_account chkAcc  on chkAcc.id=la.checkleader_id  ");
            sql.Append("left join lis_account sendorAcc on sendorAcc.id=la.sendor_id  ");
            sql.Append("where la.opdate = '" + opdate + "' ");
            sql.Append(" and la.dev_id = " + devid + " and la.ischk = 0 and la.checking != 0 and isrecive = 1");
           // sql.Append(" and la.diagnset_id = " + diagnsetid);
            sql.Append("  order by la.opdate desc, la.id  ");

            return BllMain.Db.Select(sql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取检验单
        /// </summary>
        /// <param name="whereSql">在其他页面的业务层拼sql</param>
        /// <returns>检验单表</returns>
        public static DataTable getCheckApp_Error(string devid, string opdate,string state,string haveid,string oldid)
        {
            if (state == "load")
            {
                // add ytc
                StringBuilder sql = new StringBuilder();
                sql.Append("select");
                sql.Append("     la.id as id, la.opdate as opdate,la.dev_id as dev_id,la.appdate as appdate,");
                sql.Append("     la.diagnset_id as diagnset_id,la.app_sn as app_id,la.ihsp_id as ihsp_id,li.ihsp_id as ihspNum, ");
                sql.Append("     la.depart_id as depart_id, la.doctor_id as doctor_id ,la.sampletype_id as sampletype_id, ");
                sql.Append("     la.apptype_id as apptype_id, la.operator_id as operator_id ,la.checkleader_id as checkleader_id,");
                sql.Append("     la.sendor_id as sendor_id , la.status_id as status_id, li.phonenum as phonenum,");
                sql.Append("     la.diagnsetname as diagnsetname,la.isrecive as isrecive,la.ischarged as ischarged, ");
                sql.Append("     la.invalid as invalid,la.checking as checking,la.chkdate as chkdate, la.appbillno as appbillno,");
                sql.Append("     la.barcode as barcode,la.isfirstprint as isfirstprint,la.ischk as ischk, ");
                sql.Append("     la.platform_id as platform_id ,la.diagndesc as diagndesc, la.issend as issend, ");
                sql.Append("     la.memo as memo,la.urgentstate as urgentstate,la.sumtotal as sumtotal, ");
                sql.Append("     la.chargedate as chargedate,la.invoice as invoice, la.senddate as senddate,");
                sql.Append("     li.name as name,li.sex as sex,li.age as age, li.ageunit as ageunit,  ");
                sql.Append("     statusDict.name as status,");
                sql.Append("     (select name from lis_dict dict where dict.dicttype='apptype' and dict.sn=la.apptype_id) as apptype, ");
                sql.Append("     sampDict.name as sampletype,ld.name as depart, li.bednum as bednum, ");
                sql.Append("     operAcc.name as operator,chkAcc.name as checkleader,");
                sql.Append("     diagn.name as diagnset,diagn.defdev_id as defdev_id,");
                sql.Append("     sendorAcc.name as sendor  ");
                sql.Append("from lis_app la ");
                sql.Append("left join lis_ihsp li on la.ihsp_id =li.id  ");
                sql.Append("left join lis_diagnset diagn on la.diagnset_id=diagn.id  ");
                sql.Append("left join lis_dict sampDict  on  sampDict.id=la.sampletype_id  ");
                sql.Append("left join lis_dict statusDict on statusDict.id=la.status_id ");
                sql.Append("left join lis_depart ld on ld.id=la.depart_id  ");
                sql.Append("left join lis_account operAcc  on  operAcc.id =la.operator_id  ");
                sql.Append("left join lis_account chkAcc  on chkAcc.id=la.checkleader_id  ");
                sql.Append("left join lis_account sendorAcc on sendorAcc.id=la.sendor_id  ");
                sql.Append("where la.opdate = '" + opdate + "' ");
                sql.Append(" and la.dev_id = " + devid + " and la.ischk = -1 and la.checking != 0 and isrecive = -1");
                // sql.Append(" and la.diagnset_id = " + diagnsetid);
                sql.Append("  order by la.opdate desc, la.id ");

                return BllMain.Db.Select(sql.ToString()).Tables[0];
            }
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select");
                sql.Append("     la.id as id, la.opdate as opdate,la.dev_id as dev_id,la.appdate as appdate,");
                sql.Append("     la.diagnset_id as diagnset_id,la.app_sn as app_id,la.ihsp_id as ihsp_id,li.ihsp_id as ihspNum, ");
                sql.Append("     la.depart_id as depart_id, la.doctor_id as doctor_id ,la.sampletype_id as sampletype_id, ");
                sql.Append("     la.apptype_id as apptype_id, la.operator_id as operator_id ,la.checkleader_id as checkleader_id,");
                sql.Append("     la.sendor_id as sendor_id , la.status_id as status_id, li.phonenum as phonenum,");
                sql.Append("     la.diagnsetname as diagnsetname,la.isrecive as isrecive,la.ischarged as ischarged, ");
                sql.Append("     la.invalid as invalid,la.checking as checking,la.chkdate as chkdate, la.appbillno as appbillno,");
                sql.Append("     la.barcode as barcode,la.isfirstprint as isfirstprint,la.ischk as ischk, ");
                sql.Append("     la.platform_id as platform_id ,la.diagndesc as diagndesc, la.issend as issend, ");
                sql.Append("     la.memo as memo,la.urgentstate as urgentstate,la.sumtotal as sumtotal, ");
                sql.Append("     la.chargedate as chargedate,la.invoice as invoice, la.senddate as senddate,");
                sql.Append("     li.name as name,li.sex as sex,li.age as age, li.ageunit as ageunit, ");
                sql.Append("     statusDict.name as status,");
                sql.Append("     (select name from lis_dict dict where dict.dicttype='apptype' and dict.sn=la.apptype_id) as apptype, ");
                sql.Append("     sampDict.name as sampletype,ld.name as depart, li.bednum as bednum, ");
                sql.Append("     operAcc.name as operator,chkAcc.name as checkleader,");
                sql.Append("     diagn.name as diagnset,diagn.defdev_id as defdev_id,");
                sql.Append("     sendorAcc.name as sendor  ");
                sql.Append("from lis_app la ");
                sql.Append("left join lis_ihsp li on la.ihsp_id =li.id  ");
                sql.Append("left join lis_diagnset diagn on la.diagnset_id=diagn.id  ");
                sql.Append("left join lis_dict sampDict  on  sampDict.id=la.sampletype_id  ");
                sql.Append("left join lis_dict statusDict on statusDict.id=la.status_id ");
                sql.Append("left join lis_depart ld on ld.id=la.depart_id  ");
                sql.Append("left join lis_account operAcc  on  operAcc.id =la.operator_id  ");
                sql.Append("left join lis_account chkAcc  on chkAcc.id=la.checkleader_id  ");
                sql.Append("left join lis_account sendorAcc on sendorAcc.id=la.sendor_id  ");
                sql.Append("where la.opdate = '" + opdate + "' ");
                sql.Append(" and la.dev_id = " + devid + " and la.ischk = 0 and la.checking != 0 and isrecive = 1 and la.id in ( " + oldid + ")");
                // sql.Append(" and la.diagnset_id = " + diagnsetid);
                sql.Append("  order by la.opdate desc, la.id ");

                return BllMain.Db.Select(sql.ToString()).Tables[0];
            }
        }

        /// <summary>
        /// 根据Item_id查询对应项目的数值类型
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public static string getIsStrVal(string itemid)
        {
            string sql = "select isstrval from lis_item where id = " + itemid;
            return BllMain.Db.Select(sql.ToString()).Tables[0].Rows[0]["isstrval"].ToString();
        }
        /// <summary>
        /// 查询结果
        /// </summary>
        /// <returns></returns>
        public static DataTable getResult(string devid, string itemid, string opdate)
        {
            string sql = "select * from lis_appitem ai " +
                " left join lis_app a on a.id = ai.app_id " +
                " where ai.item_id = " + itemid +
                " and a.dev_id = " + devid +
                " and a.opdate = '" + opdate + "'";
            return BllMain.Db.Select(sql.ToString()).Tables[0];
        }
        /// <summary>
        /// 更新修改的阴阳值
        /// </summary>
        /// <param name="val">阴阳值</param>
        /// <param name="devid">设备ID</param>
        /// <param name="diagnset">套餐ID</param>
        /// <param name="itemid">项目ID</param>
        /// <param name="opdate">检验日期</param>
        public static int updateYinYang(string val, string devid, string itemid, string opdate)
        {
            string sql = "update lis_appitem set resstr = '" + val + "'" +
                        " where app_id in(select id from lis_app where dev_id = "+devid+")" +
                        " and item_id = "+itemid+" and opdate = '"+opdate+"'";
            return BllMain.Db.Update(sql.ToString());
        }

        public static int updateResVal(string val, string devid, string itemid, string opdate,DataTable dt)
        {
            string sql = "";
            string sign = val.Substring(0, 1);
            float res;
            
            foreach (DataRow row in dt.Rows)
            {
                if (sign == "-" && row["resstr"].ToString() != "")
                {
                    res = float.Parse(row["resstr"].ToString()) - float.Parse(val.Substring(1, val.Length - 1).Trim());
                }
                else
                {
                    if (row["resstr"].ToString() == "")
                        res = float.Parse(val.Substring(1, val.Length - 1).Trim());
                    else
                       res = float.Parse(row["resstr"].ToString()) + float.Parse(val.Substring(1, val.Length - 1).Trim());
                }
                sql += "update lis_appitem set resstr = '" + res + "'" +
                       " where app_id in(select id from lis_app where dev_id = " + devid + ")" +
                       " and item_id = " + itemid + 
                       " and opdate = '" + opdate + "'" +
                       " and app_id = " + row["app_id"].ToString();
            }
            return BllMain.Db.Update(sql.ToString());
        }

        /////////////////
        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showCmbxList(ComboBox cmbx, DataTable dt
            , string displayMember, string valueMember, int selectedIndex)
        {
            cmbx.DataSource = dt;
            cmbx.DisplayMember = displayMember;
            cmbx.ValueMember = valueMember;
            if (selectedIndex >= 0)
                cmbx.SelectedIndex = selectedIndex;
        }

        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showCmbxList(ComboBox cmbx, DataTable dt)
        {
            showCmbxList(cmbx, dt, "name", "id", -1);
        }

        /// <summary>
        ///  显示CMBX下拉选择,带: --选择所有--
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showFristStrCmbxList(ComboBox cmbx, DataTable dt
            , string displayMember, string valueMember, string fristStr, int selectedIndex)
        {
            DataRow dr = dt.NewRow();
            dr[displayMember] = fristStr;
            dr[valueMember] = 0;
            dt.Rows.InsertAt(dr, 0);
            showCmbxList(cmbx, dt, displayMember, valueMember, selectedIndex);
        }
        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showFristStrCmbxList(ComboBox cmbx, DataTable dt
            , string displayMember, string valueMember, string fristStr)
        {
            showFristStrCmbxList(cmbx, dt, displayMember, valueMember, fristStr, -1);
        }
        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showFristStrCmbxList(ComboBox cmbx, DataTable dt
            , string fristStr, int selectedIndex)
        {
            showFristStrCmbxList(cmbx, dt, "name", "id", fristStr, selectedIndex);
        }
        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showFristStrCmbxList(ComboBox cmbx, DataTable dt
            , string fristStr)
        {
            showFristStrCmbxList(cmbx, dt, "name", "id", fristStr, -1);
        }

        /// <summary>
        ///  显示CMBX下拉选择,带: --选择所有--
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showAllCmbxList(ComboBox cmbx, DataTable dt
            , string displayMember, string valueMember, int selectedIndex)
        {
            showFristStrCmbxList(cmbx, dt, displayMember, valueMember, "--选择所有--", selectedIndex);
        }

        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showAllCmbxList(ComboBox cmbx, DataTable dt, int selectedIndex)
        {
            showAllCmbxList(cmbx, dt, "name", "id", selectedIndex);
        }

        /// <summary>
        ///  显示CMBX下拉选择
        /// </summary>
        /// <param name="?">Cmbx下拉框,数据集合</param>
        public static void showAllCmbxList(ComboBox cmbx, DataTable dt)
        {
            showAllCmbxList(cmbx, dt, -1);
        }

        /// <summary>
        /// 显示多选框
        /// </summary>
        /// <param name="clbx"></param>
        /// <param name="dt"></param>
        public static void showClbxList(CheckedListBox clbx, DataTable dt)
        {
            clbx.DataSource = dt;
            clbx.ValueMember = "id";
            clbx.DisplayMember = "name";
        }


    }
}
