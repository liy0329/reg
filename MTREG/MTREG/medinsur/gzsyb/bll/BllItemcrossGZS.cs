using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.gzsyb.bo;

namespace MTREG.medinsur.gzsyb.bll
{
    class BllItemcrossGZS
    {
        public DataTable getItemInfo(string name, string itemfrom, string isCross)
        {
            DataTable dt = null;
            string sql = "";
            if (isCross == "0")
            {
                sql = "select "
                    + " id"
                    + ",standcode"
                    + ",name"
                    + ",unit"
                    + ",spec"
                    + ",itemfrom"
                    + " from bas_item where name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%' "
                    + " and itemfrom in ("
                    + itemfrom + ")"
                    + " and id in (select item_id from cost_insurcross);";
            }
            else if (isCross == "-1")
            {
                sql = "select "
                    + " id"
                    + ",standcode"
                    + ",name"
                    + ",unit"
                    + ",spec"
                    + ",itemfrom"
                    + " from bas_item where name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%' "
                    + " and itemfrom in ('"
                    + itemfrom + "')"
                    + " and id not in (select item_id from cost_insurcross);";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getInsurInfo(string name)
        {
            DataTable dt = null;
            string sql = "select "
                       + " id"
                       + ",name"
                       + ",ifnull(insurcode,' ') as insurcode"
                       + ",ifnull(name2,' ') as name2"
                       + ",ifnull(itemfrom,' ') as itemfrom"
                       + ",ifnull(unit,' ') as unit"
                       + ",ifnull(spec,' ') as spec"
                       + " from cost_insuritem where name like '%" + name.Trim() + "%' "
                       + " or pincode like '%" + name.Trim() + "%' "
                       + " or name2 like '%" + name.Trim() + "%' ";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public bool ischeck(string item_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " count(*)"
                       + " from cost_insurcross where item_id = " + DataTool.addFieldBraces(item_id);
            dt = BllMain.Db.Select(sql).Tables[0];
            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable getInsurItemFromCross(string item_id)
        {
            DataTable dt = null;
            string sql = "select "
                       + " cost_insurcross.id"
                       + ",cost_insuritem.name"
                       + ",cost_insuritem.name2"
                       + ",cost_insuritem.insurcode"
                       + ",cost_insuritem.itemfrom"
                       + ",cost_insuritem.unit"
                       + ",cost_insuritem.spec"
                       + " from cost_insuritem left join cost_insurcross on cost_insuritem.id = cost_insurcross.cost_insuritem_id"
                       + " where cost_insurcross.item_id = "
                       + DataTool.addFieldBraces(item_id) + " and cost_insurcross.cost_insurtype_id = (select id from cost_insurtype where keyname = "
                       + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSYB.ToString()) + ")";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public int itemCross(CostInsurcrossGZS costInsurcross)
        {
            string sql = "insert into cost_insurcross ("
                       + " id"
                       + ",cost_insurtype_id"//医保类型
                       + ",itemfrom"
                       + ",item_id"
                       + ",drug_factyitem_id"//厂家序列
                       + ",cost_insuritem_id )values ("//医保目录
                       + DataTool.addFieldBraces(costInsurcross.Id)
                       + "," + DataTool.addFieldBraces(costInsurcross.Cost_insurtype_id)
                       + "," + DataTool.addFieldBraces(costInsurcross.Itemfrom)
                       + "," + DataTool.addFieldBraces(costInsurcross.Item_id)
                       + "," + DataTool.addFieldBraces(costInsurcross.Drug_factyitem_id)
                       + "," + DataTool.addFieldBraces(costInsurcross.Cost_insuritem_id)
                       + ");";
            int result = BllMain.Db.Update(sql);
            return result;
        }
        public int itemCrossCancel(string id)
        {
            string sql = "delete from cost_insurcross where id = " + DataTool.addFieldBraces(id);
            int result = BllMain.Db.Update(sql);
            return result;
        }
        public string getInsurTypeId()
        {
            string sql = "select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSYB.ToString());
            return BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString();
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
        public int insertInsurItem(string cost_insurtype_id, DataTable dt)
        {
            clearInsurItem(cost_insurtype_id);
            string sql = "";
            string curTime = BillSysBase.currDate();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string cost_insuritem_id = BillSysBase.nextId("cost_insuritem");
                string standcode = "";

                string YKA096_name = "";
                string YKA096_id = "";
                string islimitprc = "";
                string limituse = "";
                string YKA096 = dt.Rows[i]["AKA065"].ToString();
                if (YKA096 == "0")
                {
                    YKA096_name = "甲";
                    YKA096_id = "1";
                }
                else if (YKA096 == "1")
                {
                    YKA096_name = "丙";
                    YKA096_id = "2";
                }
                else 
                {
                    YKA096_name = "乙";
                    YKA096_id = "3";
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
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["yka003"].ToString())
                    + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(dt.Rows[i]["yka003"].ToString()))
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["yka002"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["YKA001"].ToString())
                    + "," + DataTool.addFieldBraces(YKA096_id)
                    + "," + DataTool.addFieldBraces(YKA096_name)
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA069"].ToString())
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["AKA069"].ToString())
                    + "," + DataTool.addFieldBraces("")//是否限价
                    + "," + DataTool.addFieldBraces("")//限价金额
                    + "," + DataTool.addFieldBraces("")//限制使用信息
                    + "," + DataTool.addFieldBraces("")//审批标志
                    + "," + DataTool.addFieldBraces(curTime)
                    + ");";
                //与91函数返回字段对应有问题，需检查
            }
            return 0;
        }
    }
}
