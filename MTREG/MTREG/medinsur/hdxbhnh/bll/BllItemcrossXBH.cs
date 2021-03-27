using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.hdxbhnh.bo;

namespace MTREG.medinsur.hdxbhnh.bll
{
    class BllItemcrossXBH
    {
        public DataTable getItemInfo(string name,string itemfrom,string isCross)
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
                    + " from bas_item where (name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%') "
                    + " and itemfrom in ("
                    + DataTool.addFieldBraces(itemfrom) + ")"
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
                    + " from bas_item where (name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%') "
                    + " and itemfrom in ("
                    + DataTool.addFieldBraces(itemfrom) + ")"
                    + " and id not in (select item_id from cost_insurcross);";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getInsurInfo(string name,string itemfrom)
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
                       + " from cost_insuritem where (name like '%" + name.Trim() + "%' "
                       + " or pincode like '%" + name.Trim() + "%' "
                       + " or name2 like '%" + name.Trim() + "%' )"
                        + " and itemfrom in (" + DataTool.addFieldBraces(itemfrom) + ") and cost_insurtype_id = (select id from cost_insurtype where keyname = "
                       + DataTool.addFieldBraces(CostInsurtypeKeyname.HDXBHNH.ToString()) + ")";
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
                       + DataTool.addFieldBraces(CostInsurtypeKeyname.HDXBHNH.ToString()) + ")";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public int itemCross(CostInsurcross costInsurcross)
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
            string sql = "select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.HDXBHNH.ToString());
            return BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString();
        }
    }
}
