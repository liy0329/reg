using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using System.Windows.Forms;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.bll
{
    class BllItemCrossHSDR
    {
        /// <summary>
        /// 院内目录信息
        /// </summary>
        /// <returns></returns>
        public DataTable getHisItem(string itemfrom,string name)
        {
            DataTable dt = new DataTable();
            String sql = "select id ,standcode,name,spec,unit,city_prc from bas_item where itemfrom = " + DataTool.addFieldBraces(itemfrom);
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and (name like '%" + name.Trim() + "%' " + "or pincode like'%" + name.Trim() + "%' )";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 医保目录信息
        /// </summary>
        /// <returns></returns>
        public DataTable getInsurItem(string itemfrom, string name, string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            String sql = "select "
                       + " standcode"
                       + ",insurcode"
                       + ",name"
                       + ",insurclass"
                       + ",limitprc"
                       + ",ratioihsp"
                       + ",itemfrom"
                       + ",limituse"   //限制信息
                       + ",approve"                 //审批状态
                       + " from cost_insuritem "
                       + " where cost_insurtype_id = " + DataTool.addFieldBraces(cost_insurtype_id)
                       + " and itemfrom in ("+ itemfrom
                       + ")";
            if (!string.IsNullOrEmpty(name))
            {
                sql += "and (name like '%" + name.Trim() + "%' " + "or pincode like'%" + name.Trim() + "%' )";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 清空医保目录信息
        /// </summary>
        /// <returns></returns>
        public int clearInsurItem(string cost_insurtype_id)
        {
            string sql = "delete from cost_insuritem where cost_insurtype_id = " + DataTool.addFieldBraces(cost_insurtype_id) + ";";
            int result = BllMain.Db.Update(sql);
            return result;
        }
        /// <summary>
        /// 更新医保目录表
        /// </summary>
        /// <returns></returns>
        public int insertInsurItem(string cost_insurtype_id, string standcode, DataTable dt)
        {
            clearInsurItem(cost_insurtype_id);
            string sql = "";
            string curTime = BillSysBase.currDate();
            for (int i=0;i<dt.Rows.Count;i++)
            {
                string cost_insuritem_id = BillSysBase.nextId("cost_insuritem");
                string AKA065_name = "";
                string islimitprc = "";
                string limituse = "";
                string AKA065 = dt.Rows[i]["AKA065"].ToString();
                if (AKA065 == "1")
                {
                    AKA065_name = "甲";
                }
                else if (AKA065 == "2")
                {
                    AKA065_name = "乙";
                }
                else if (AKA065 == "3")
                {
                    AKA065_name = "丙";
                }
                string AKA068 = dt.Rows[i]["AKA068"].ToString();
                if (AKA068 == "0")
                {
                    islimitprc = "N";
                }
                else
                {
                    islimitprc = "Y";
                }
                if (dt.Rows[i]["AAE013"] is DBNull)
                {
                    limituse = "";
                }
                else
                {
                    limituse = dt.Rows[i]["AAE013"].ToString();
                }
                sql += "insert into cost_insuritem ("
                    + " id"
                    + ",cost_insurtype_id"
                    + ",standcode"
                    + ",name"
                    + ",pincode"
                    + ",insurcode"
                    + ",itemfrom"
                    + ",insurclass_id"
                    + ",insurclass"
                    + ",ratioclin"
                    + ",ratioihsp"
                    + ",islimitprc"
                    + ",limitprc"
                    + ",limituse"
                    + ",approve"
                    + ",updateat ) values ("
                    + DataTool.addFieldBraces(cost_insuritem_id)
                    + "," + DataTool.addFieldBraces(cost_insurtype_id)
                    + "," + DataTool.addFieldBraces(standcode)
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKE002"].ToString())
                    + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(dt.Rows[i]["AKE002"].ToString()))
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKE001"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA063"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA065"].ToString())
                    + "," + DataTool.addFieldBraces(AKA065_name)
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA069"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA069"].ToString())
                    + "," + DataTool.addFieldBraces(islimitprc)
                    + "," + DataTool.addFieldBraces(AKA068)
                    + "," + DataTool.addFieldBraces(limituse)
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["BKC002"].ToString())
                    + "," + DataTool.addFieldBraces(curTime)
                    + ");";
            }
            return 0;
        }
        /// <summary>
        /// 查询医保病种信息
        /// </summary>
        /// <returns></returns>
        public DataTable getDiseaseInfo(string cost_insurtype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select "
                       + " id"
       
                       + ",illcode"
                       + ",name"
                       + ",pincode"
                       + " from cost_insurillness where cost_insurtype_id = "
                       + DataTool.addFieldBraces(cost_insurtype_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 项目类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable itemtypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select id,name from cost_itemtype ";
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
        /// 查询医药代码对照
        /// </summary>
        /// <returns></returns>
        public DataTable getDrugcodeCross(string cost_insurtype_id)
        { 
            DataTable dt = new DataTable();
            string sql = "select insur_itemfrom.itemtype_id as itemid"
                 + " ,insur_itemfrom.id"
                 + " ,insur_itemfrom.itemtype_id as itemtype_id"
                 + " ,cost_itemtype.name as itemname"
                 + " ,insur_itemfrom.name as insurname"
                 + " ,insur_itemfrom.insurcode"
                 + " from insur_itemfrom "
                 + " left join cost_itemtype on cost_itemtype.id=insur_itemfrom.itemtype_id "
                 + " where cost_insurtype_id =" + DataTool.addFieldBraces(cost_insurtype_id)
                 + " order by insur_itemfrom.id";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 医保类别修改
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cost_insurtype_id"></param>
        /// <returns></returns>
        public int updateItemfrom(DataTable dt,string cost_insurtype_id)
        {
            string sql = "";
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                string itemtype_id = row["itemtype_id"].ToString();
                string insurname = row["insurname"].ToString();
                string insurcode = row["insurcode"].ToString();
                sql += "update insur_itemfrom set cost_insurtype_id = " + DataTool.addFieldBraces(cost_insurtype_id)
                    + ",name =" + DataTool.addFieldBraces(insurname)
                    + ",insurcode=" + DataTool.addFieldBraces(insurcode)
                    + ",itemtype_id = " + DataTool.addFieldBraces(itemtype_id)
                    + " where id =" + DataTool.addFieldBraces(id) + ";";
            }
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 导入医保药品信息
        /// </summary>
        /// <param name="Insurtype_id"></param>
        /// <returns></returns>
        public int inDrugtype(string Insurtype_id)
        {
            string insql = "";
            string sql = "select id,name from cost_itemtype  ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["name"].ToString();
                string sn = dt.Rows[i]["id"].ToString();
                insql += "insert into insur_itemtype(name,itemtype_id,cost_insurtype_id)"
                      + "values(" + DataTool.addFieldBraces(name)
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
        public int clearInsurillness(string cost_insurtype_id)
        {
            string sql = "delete from cost_insurillness where cost_insurtype_id = " + DataTool.addFieldBraces(cost_insurtype_id);
            int flag = BllMain.Db.Update(sql);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }
        public void updateInsurillness(int n,DataTable dt,string cost_insurtype_id)
        {
            string insertSql = "";
            foreach (DataRow item in dt.Rows)
            { 
                string cost_insurillness_id = "";
                string currTime = "";
                insertSql += "insert into cost_insurillness ("
                           + " id"
                           + ",cost_insurtype_id"
                           + ",name"
                           + ",pincode"
                           + ",illcode"
                           + ",keyname"
                           + ",createdat"
                           + ",createdby ) values ( "
                           + DataTool.addFieldBraces(cost_insurillness_id)
                           + "," + DataTool.addFieldBraces(cost_insurtype_id)
                           + "," + DataTool.addFieldBraces(item["AKA121"].ToString().Replace("'",""))
                           + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(item["AKA121"].ToString().Replace("'","")))
                           + "," + DataTool.addFieldBraces(item["AKA120"].ToString())
                           + "," + DataTool.addFieldBraces(item["AKA123"].ToString())
                           + "," + DataTool.addFieldBraces(currTime)
                           + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                           + ");";
            }
            if(!string.IsNullOrEmpty(insertSql.ToString()))
            {
                int res = 0;
                try
                {
                    res = BllMain.Db.Update(insertSql);
                }
                catch(Exception ex)
                {
                   MessageBox.Show("更新第" + n + "出现异常  " + ex.ToString());
                }
                if(res == -1)
                {
                    MessageBox.Show("更新第" + n +"出现异常");
                }
            }
            else
            {
                MessageBox.Show("获取数据异常！");
            }
        }

    }
}
