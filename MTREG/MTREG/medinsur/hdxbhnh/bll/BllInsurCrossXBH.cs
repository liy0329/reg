using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.medinsur.hdxbhnh.bll
{
    class BllInsurCrossXBH
    {
        #region 药品项目对照
        /// <summary>
        /// 药品类别查询
        /// </summary>
        /// <returns></returns>
        public DataTable drugSelect(string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select id"
                 + " ,itemtype_id as itemname"
                 + " ,name as insurname"
                 + " ,insurcode"
                 + " from insur_drugtype "
                 + " where cost_insurtype_id =" + DataTool.addFieldBraces(cost_insurtype_id)
                 + " order by id";
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
        /// 查询药品编号是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable idselect(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from insur_drugtype where id=" + id;
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 药品类别添加
        /// </summary>
        /// <returns></returns>
        public int drugIn(DataTable dt, string cost_insurtype_id)
        {
            string sql = "";
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                int i = idselect(id).Rows.Count;
                string itemname = row["itemname"].ToString();
                string insurname = row["insurname"].ToString();
                string insurtcode = row["insurcode"].ToString();
                string sql1 = "select id from cost_itemtype where  name =" + DataTool.addFieldBraces(itemname);
                string itemtype_id = BllMain.Db.Select(sql1).Tables[0].Rows[0]["id"].ToString();
                switch (i)
                {
                    case 0:
                        sql += "insert into insur_drugtype (id"
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
                        sql += "update insur_drugtype set cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
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
        /// 删除药品表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int drugDel(string id)
        {
            string sql = "delete from insur_drugtype where id=" + id;
            return BllMain.Db.Update(sql);
        }
        #endregion

        #region 医药项目对照
        /// <summary>
        /// 医药类别查询
        /// </summary>
        /// <returns></returns>
        public DataTable itemfromSelect(string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select id"
                 + " ,itemtype_id as itemname "
                 + " ,name as insurname "
                 + " ,insurcode "
                 + " from insur_itemfrom "
                 + " where cost_insurtype_id =" + DataTool.addFieldBraces(cost_insurtype_id)
                 + " order by id";
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
                string itemname = row["itemname"].ToString();
                string insurname = row["insurname"].ToString();
                string insurtcode = row["insurcode"].ToString();
                string sql1 = "select id from cost_itemtype where  name =" + DataTool.addFieldBraces(itemname);
                string itemtype_id = BllMain.Db.Select(sql1).Tables[0].Rows[0]["id"].ToString();
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
        /// 删除医药类别
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int itemfromDel(string id)
        {
            string sql = "delete from insur_itemfrom where id=" + id;
            return BllMain.Db.Update(sql);
        }

        #endregion

        #region 医保财务对照
        /// <summary>
        /// 医保财务查询
        /// </summary>
        /// <returns></returns>
        public DataTable itemtypeSelect(string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select id "
                 + " ,CAST(itemtype_id as char(30)) as itemname "
                 + " ,name as insurname "
                 + " ,insurcode "
                 + " from insur_itemtype "
                 + " where cost_insurtype_id =" + DataTool.addFieldBraces(cost_insurtype_id)
                 + " order by id";
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
        /// 查询医保财务编号是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable itemtypeid(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from insur_itemtype where id=" + id;
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 医保财务添加
        /// </summary>
        /// <returns></returns>
        public int itemtypeIn(DataTable dt, string cost_insurtype_id)
        {
            string sql = "";
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                int i = itemtypeid(id).Rows.Count;
                string itemname = row["itemname"].ToString();
                string insurname = row["insurname"].ToString();
                string insurtcode = row["insurcode"].ToString();
                string sql1 = "select id from cost_itemtype where name =" + DataTool.addFieldBraces(itemname);
                string itemtype_id = BllMain.Db.Select(sql1).Tables[0].Rows[0]["id"].ToString();
                switch (i)
                {
                    case 0:
                        sql += "insert into insur_itemtype (id"
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
                        sql += "update insur_itemtype set cost_insurtype_id=" + DataTool.addFieldBraces(cost_insurtype_id)
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
        /// 删除医保财务
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int itemtypeDel(string id)
        {
            string sql = "delete from insur_itemtype where id=" + id;
            return BllMain.Db.Update(sql);
        }

        #endregion

        /// <summary>
        /// 项目类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable itemtypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from cost_itemtype;";
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
        /// 医疗类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable insurtypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from cost_insurtype ;";
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
