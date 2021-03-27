using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.bo;
using MTREG.common;

namespace MTREG.medinsur.bll
{
    class BllInsurMethod
    {
        /// <summary>
        /// 获取医保关键字
        /// </summary>
        /// <param name="insurid"></param>
        /// <returns></returns>
        public string getInsurKeyname(string insurid)
        {
            string sql = "select keyname from cost_insurtype where id=" + DataTool.addIntBraces(insurid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["keyname"].ToString();
            }
            return null;
        }

        /// <summary>
        /// 医保接口类型
        /// </summary>
        /// <returns></returns>
        public DataTable insurtype()
        {
            string sql = "select id,name from cost_insurtype";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 地区信息
        /// </summary>
        /// <param name="cost_insurtype_id"></param>
        /// <returns></returns>
        public DataTable areaInfo(string cost_insurtype_id,string info)
        {
            string sql = "select areacode,name from insur_areacode"
                            + " where cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
                            + " and (name like " + DataTool.addFieldBraces("%" + info + "%") + " or pincode like " + DataTool.addFieldBraces("%" + info + "%") +" or areacode like " + DataTool.addFieldBraces("%" + info + "%") + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 地区信息
        /// </summary>
        /// <param name="cost_insurtype_id"></param>
        /// <returns></returns>
        public DataTable allAreaInfo(string cost_insurtype_id, string info)
        {
            string sql = "select insur_areacode.id"
                            + ",cost_insurtype.name as insurname"
                            + ",insur_areacode.name as areaname"
                            + ",areacode"
                            + ",insuritemtype"
                            + ",memo"
                            + ",cost_insurtype_id"
                            + " from insur_areacode"
                            + " left join cost_insurtype on cost_insurtype.id=insur_areacode.cost_insurtype_id"
                            + " where cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
                            + " and (insur_areacode.name like " + DataTool.addFieldBraces("%" + info + "%") + " or pincode like " + DataTool.addFieldBraces("%" + info + "%") + " or areacode like " + DataTool.addFieldBraces("%" + info + "%") + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取指定区域的详细信息
        /// </summary>
        /// <param name="cost_insurtype_id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public DataTable getInsurInfo(string cost_insurtype_id, string info)
        {
            string sql = "select * from insur_areacode"
                            + " where cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
                            + " and (insur_areacode.name like " + DataTool.addFieldBraces("%" + info + "%")  + " or areacode like " + DataTool.addFieldBraces("%" + info + "%") + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 将下载信息插入医保目录表
        /// </summary>
        /// <param name="insurItemInfo"></param>
        /// <returns></returns>
        public string  inInsurItem(InsurItemInfo insurItemInfo)
        {
            string sql = "insert into cost_insuritem(id"
                + ",cost_insurtype_id"
                + ",insuritemtype"
                + ",name2"
                + ",insurcode)values(" + DataTool.addIntBraces(BillSysBase.nextId("cost_insuritem"))
                                    + "," + DataTool.addFieldBraces(insurItemInfo.Cost_insurtype_id)
                                    + "," + DataTool.addFieldBraces(insurItemInfo.Insuritemtype)
                                    + "," + DataTool.addFieldBraces(insurItemInfo.Insurname)
                                    + "," + DataTool.addFieldBraces(insurItemInfo.Insurcode)
                                    + ");";
            return sql;
        }

        /// <summary>
        /// 医保接口信息
        /// </summary>
        /// <returns></returns>
        public DataTable insurtypeInfo()
        {
            string sql = "select id,name from  cost_insurtype ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 查询医保目录信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="insurid"></param>
        /// <param name="insuritemtype"></param>
        /// <returns></returns>
        public DataTable insurItemInfo(string info,string insurid,string areaname)
        {
            string sql = "select * from insur_areacode"
                        + " where cost_insurtype_id=" + DataTool.addFieldBraces(insurid)
                        + " and name=" + DataTool.addFieldBraces(areaname);
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            string insuritemtype ="";
            if (insuritemtype!="")
            {
                insuritemtype = dt.Rows[0]["insuritemtype"].ToString();
            }            
            sql = "select cost_insurtype.name as insurname"
                + ",standcode"
                + ",cost_insuritem.name as itemname"
                + ",insurcode"
                + ",spec"
                + ",unit"
                + ",insurclass"
                + ",ratioihsp"
                + ",islimitprc"
                + ",cost_insuritem.updateat"
                + " from cost_insuritem"
                + " left join cost_insurtype on cost_insurtype.id=cost_insuritem.cost_insurtype_id"
                + " where 1=1 "
                + (!string.IsNullOrEmpty(insurid) ? (" and  cost_insurtype_id = " + DataTool.addFieldBraces(insurid)) : "")
                + (!string.IsNullOrEmpty(insuritemtype) ? (" and  insuritemtype = " + DataTool.addFieldBraces(insuritemtype)) : "")
                + (!string.IsNullOrEmpty(info) ? (" and  (cost_insuritem.name like " + DataTool.addFieldBraces("%" + info + "%") + "or cost_insuritem.pincode like " + DataTool.addFieldBraces("%" + info + "%")) + ")" : "");
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 编辑区域
        /// </summary>
        /// <param name="areaInfo"></param>
        /// <returns></returns>
        public int upAreaInfo(string insuritemtype, string areaname, string areacode,string memo,string id)
        {
            string sql = "update insur_areacode set insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                + " , name=" + DataTool.addFieldBraces(areaname)
                + " , areacode=" + DataTool.addFieldBraces(areacode)
                + " , memo=" + DataTool.addFieldBraces(memo)
                + " , id=" + DataTool.addIntBraces(id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 医药类别查询
        /// </summary>
        /// <returns></returns>
        public DataTable itemfromSelect(string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select insur_itemfrom.itemtype_id as itemid"
                 + " ,insur_itemfrom.id "
                 + " ,insur_itemfrom.itemtype_id as itemtype_id "
                 + " ,cost_itemtype.name as itemname "
                 + " ,insur_itemfrom.name as insurname "
                 + " ,insur_itemfrom.insurcode "
                 + " from insur_itemfrom "
                 + " left join cost_itemtype on cost_itemtype.id=insur_itemfrom.itemtype_id "
                 + " where cost_insurtype_id =" + DataTool.addFieldBraces(cost_insurtype_id)
                 + " order by insur_itemfrom.id";
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
        /// 导入医药照表
        /// </summary>
        /// <returns></returns>
        public int inItemfrom(string Insurtype_id)
        {
            string insql = "";
            string sql = "select id ,name from cost_itemtype ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["name"].ToString();
                string sn = dt.Rows[i]["id"].ToString();
                string id = BillSysBase.nextId("insur_itemtype");
                insql += "insert into insur_itemtype(id,name,itemtype_id,cost_insurtype_id)"
                                + "values(" + DataTool.addIntBraces(id)
                                + "," + DataTool.addFieldBraces(name)
                                + "," + DataTool.addFieldBraces(sn)                 
                                + "," + DataTool.addFieldBraces(Insurtype_id)
                                + ");";
            }
            int flag = BllMain.Db.Update(insql);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 该类型核算类别是否存在
        /// </summary>
        /// <returns></returns>
        public bool isExist(string tableName,string cost_insurtype_id)
        {
            string sql = "select count(id) as num"
                       + " from " + tableName
                       + " where cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id);
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            if (int.Parse(dt.Rows[0]["num"].ToString()) > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 核算类别对照查询
        /// </summary>
        /// <param name="cost_insurtype_id"></param>
        /// <returns></returns>
        public DataTable selectItemfrom1(string cost_insurtype_id)
        {
            string sql = "select insur_itemfrom1.itemtype1_id"
                + ",insur_itemfrom1.id"
                + ",insur_itemfrom1.itemtype1_id as itemtype1"
                + ",insur_itemfrom1.name as insurname"
                + ",insur_itemfrom1.insurcode as insurcode"
                + " from insur_itemfrom1"
                + " left join cost_itemtype1 on cost_itemtype1.id=insur_itemfrom1.itemtype1_id"
                + " where insur_itemfrom1.cost_insurtype_id=" + DataTool.addIntBraces(cost_insurtype_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];

            
            return dt;
        }
        /// <summary>
        /// 导入核算类别
        /// </summary>
        /// <param name="Insurtype_id"></param>
        /// <returns></returns>
        public int inItemtype1(string Insurtype_id)
        {
            string insql = "";
            string sql = "select id,name from cost_itemtype1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 string name = dt.Rows[i]["name"].ToString();
                string itemtype1 = dt.Rows[i]["id"].ToString();
                string id = BillSysBase.nextId("insur_itemtype1");
                insql += "insert into insur_itemfrom1(id"
                + ",cost_insurtype_id"
                + ",name"
                + ",itemtype1_id)values("
                + DataTool.addIntBraces(id)
                + "," + DataTool.addFieldBraces(Insurtype_id)
                + "," + DataTool.addFieldBraces(name)
                + "," + DataTool.addFieldBraces(itemtype1)
                + ");";
            }
            return BllMain.Db.Update(insql);
        }
        /// <summary>
        /// 项目类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable itemtypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from cost_itemtype";
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
        /// 核算类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable itemtype1List()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from cost_itemtype1";
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
        /// 查询医药类别编号是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable itemfromid(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from insur_itemfrom where id=" + id;
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查询核算类别编号是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable itemfrom1id(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from insur_itemfrom1 where id=" + id;
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 医药类别添加
        /// </summary>
        /// <returns></returns>
        public int itemfromIn(DataTable dt, string cost_insurtype_id)
        {
            string sql = "";
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                int i = itemfromid(id).Rows.Count;
                string itemtype_id = row["itemtype_id"].ToString();
                string insurname = row["insurname"].ToString();
                string insurtcode = row["insurcode"].ToString();
                switch (i)
                {
                    case 0:
                        sql += "insert into insur_itemfrom (id"
                                                + " , cost_insurtype_id"
                                                + " , name"
                                                + " , insurcode"
                                                + " , itemtype_id)values(" + DataTool.addFieldBraces(id)
                                                + "," + DataTool.addFieldBraces(cost_insurtype_id)
                                                + "," + DataTool.addFieldBraces(insurname)
                                                + "," + DataTool.addFieldBraces(insurtcode)
                                                + "," + DataTool.addFieldBraces(itemtype_id)
                                                + ");";
                        break;
                    case 1:
                        sql += "update insur_itemfrom set cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
                                                + ",name=" + DataTool.addFieldBraces(insurname)
                                                + ",insurcode=" + DataTool.addFieldBraces(insurtcode)
                                                + ",itemtype_id=" + DataTool.addFieldBraces(itemtype_id)
                                                + " where id=" + DataTool.addFieldBraces(id) + ";";
                        break;
                }
            }
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 核算类别添加
        /// </summary>
        /// <returns></returns>
        public int itemfrom1In(DataTable dt, string cost_insurtype_id)
        {
            string sql = "";
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                int i = itemfrom1id(id).Rows.Count;
                string itemtype1_id = row["itemtype1_id"].ToString();
                string insurname = row["insurname"].ToString();
                string insurtcode = row["insurcode"].ToString();
                switch (i)
                {
                    case 0:
                        sql += "insert into insur_itemfrom1 (id"
                                                + " , cost_insurtype_id"
                                                + " , name"
                                                + " , insurcode"
                                                + " , itemtype1_id)values(" + DataTool.addFieldBraces(id)
                                                + "," + DataTool.addFieldBraces(cost_insurtype_id)
                                                + "," + DataTool.addFieldBraces(insurname)
                                                + "," + DataTool.addFieldBraces(insurtcode)
                                                + "," + DataTool.addFieldBraces(itemtype1_id)
                                                + ");";
                        break;
                    case 1:
                        sql += "update insur_itemfrom1 set cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
                                                + ",name=" + DataTool.addFieldBraces(insurname)
                                                + ",insurcode=" + DataTool.addFieldBraces(insurtcode)
                                                + ",itemtype1_id=" + DataTool.addFieldBraces(itemtype1_id)
                                                + " where id=" + DataTool.addFieldBraces(id) + ";";
                        break;
                }
            }
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 预结算更新医保信息表中的费用
        /// </summary>
        /// <returns></returns>
        public int upInsurinfoFee(string ihsp_id, string Insurefee, string insursettfee)
        {
            string sql = "update ihsp_insurinfo set insurefee=" + DataTool.addFieldBraces(Insurefee)
                + ",insuraccountfee=" + DataTool.addFieldBraces(insursettfee)+ " where ihsp_id="+ihsp_id+";";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 登记更新医保信息表中的卡内余额和密码
        /// </summary>
        /// <returns></returns>
        public int upInsurbalance(string ihsp_id, string insurbalance, string insurpasswd)
        {
            string sql = "update ihsp_insurinfo set insurbalance=" + DataTool.addFieldBraces(insurbalance)
                    + ",insurpasswd=" + DataTool.addFieldBraces(insurpasswd) + " where ihsp_id=" + ihsp_id+";";
            return BllMain.Db.Update(sql);
        }
    }
}
