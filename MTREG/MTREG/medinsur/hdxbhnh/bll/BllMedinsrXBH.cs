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
    class BllMedinsrXBH
    {
        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <returns></returns>
        public DataTable getPatientType()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name from bas_patienttype";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        public DataTable getZoneCode()
        {
            DataTable dt = new DataTable();
            string sql = "select uniquekey as id,name from insur_hdsbhnh_trustpointcode ";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public int addIhsp_insurinfo(string registinfo, string ihsp_id)
        {
            string[] message = registinfo.Split('|');
            string strXml = "<info>";
            strXml += "<personJoinNum>" + message[0] + "</personJoinNum>";
            strXml += "<zoneCode>" + message[1] + "</zoneCode>";
            strXml += "<info>";
            string sql = "insert into ihsp_insurinfo ("
                       + " id"
                       + ",ihsp_id"
                       + ",registinfo" 
                       + ",opstat)values ("
                       + DataTool.addFieldBraces(BillSysBase.nextId("ihsp_insurinfo"))
                       + "," + DataTool.addFieldBraces(ihsp_id)
                       + "," + DataTool.addFieldBraces(strXml)
                       + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                       + ")";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 传输病人就诊信息
        /// </summary>
        /// <returns></returns>
        public bool insurReg(string registinfo, string ihsp_id)
        {
            string[] retdata = registinfo.Split('|');
            string personJoinNum = retdata[0];
            string zoneCode = retdata[1];
            string sql_select = "select id"
                              + ",ihspcode"
                              + ",name"
                              + ",case sex when 'M' then '1' when 'W' then '2' end as sex"
                              + ",indate"
                              + ",registdate"
                              + ",prepamt"
                              + " from inhospital where id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql_select).Tables[0];

             string sql_ist = "insert into T_CON1 ("
                           + " Zyh"
                           + ",Zyh1"
                           + ",Ylzbh"
                           + ",Hzxm"
                           + ",Xb"
                           + ",Djrq"
                           + ",Yj"
                           + ",Z_date1"
                           + ",Nhzt"
                           + ",qhdm ) values ( "
                           + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString())
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString())
                           + "," + DataTool.addFieldBraces(personJoinNum)
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["name"].ToString())
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["sex"].ToString())
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["registdate"].ToString())
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["prepamt"].ToString())
                           + "," + DataTool.addFieldBraces(dt.Rows[0]["indate"].ToString())
                           + "," + "0"
                           + "," + DataTool.addFieldBraces(zoneCode)
                           + ")";
            int result = BllMain.Hdxbhnhdb.Update(sql_ist);
            if (result == 0)
            {
                string sql_upd = "update inhospital set insurstat = " + DataTool.addFieldBraces(Insurstat.REG.ToString())
                               + " where id = " + DataTool.addFieldBraces(ihsp_id);
                BllMain.Db.Update(sql_upd);
                return true;
            }
            else
            {
                string sql_upd = "update inhospital set insurstat = " + DataTool.addFieldBraces(Insurstat.OO.ToString())
                               + " where id = " + DataTool.addFieldBraces(ihsp_id);
                BllMain.Db.Update(sql_upd);
                return false;
            } 
        }
        public void costdetTransfer(string ihsp_id,StringBuilder message)
        {
            int flag = 0;
            for (; ; )
            {
                flag = costdetTransferSub(ihsp_id);
                if (flag < 50)
                    break;
                if (flag == 50)
                { 
                
                }
            }
            switch (flag)
            {
                case -1: message.Append("数据传输失败！");
                    return;
                case -2: message.Append("未找到相关表信息！");
                    return;
                case -3: message.Append("无可传输项！");
                    return;
            }
        }
        /// <summary>
        /// 费用信息传送到
        /// </summary>
        /// <returns></returns>
        public int costdetTransferSub(string ihsp_id)
        {
            string sql = "";
            string costdetIds = "";
            string sql_search = "select "
                              + " ihsp_costdet.id"
                              + ",inhospital.ihspcode"
                              + ",ihsp_costdet.chargedate"
                              + ",case ihsp_costdet.itemfrom when 'DRUG' then '1' when 'COST' then '2' when 'STUFF' then '3' end as itemfrom"
                              + ", 1 as isInsur"
                              + ",ihsp_costdet.item_id"
                              + ",ihsp_costdet.standcode as insuritem_code"
                              + ",bas_item.name"
                              + ",bas_item.name as insurname"
                              + ",ihsp_costdet.prc"
                              + ",ihsp_costdet.num"
                              + ",ihsp_costdet.fee"
                              + " from ihsp_costdet left join bas_item on ihsp_costdet.item_id = bas_item.id "
                              + " left join inhospital on ihsp_costdet.ihsp_id = inhospital.id"
                              + " where ihsp_costdet.charged in ( " + DataTool.addFieldBraces(CostCharged.CHAR.ToString())
                              + ","+ DataTool.addFieldBraces(CostCharged.RET.ToString())
                              + ","+ DataTool.addFieldBraces(CostCharged.RREC.ToString())
                              + ")"+" and ihsp_costdet.insursync = 'N' and ihsp_costdet.ihsp_id in (" + ihsp_id + ")"
                              + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataSet ds = BllMain.Db.Select(sql_search);
            if (ds.Tables.Count <= 0)
            {//未找到相关表信息！
                return -2; 
            }
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count <= 0)
            {//无可传输项
                return -3;
            }
            string sql_slt = "select cost_insurcross.item_id"
                           + ",cost_insuritem.insurcode"
                           + ",cost_insuritem.name"
                           + " from cost_insurcross left join cost_insuritem on cost_insurcross.cost_insuritem_id = cost_insuritem.id"
                           + " where cost_insurcross.item_id in ( select item_id from ihsp_costdet where ihsp_id in ( " + ihsp_id + "));";
            DataTable dt_upd = BllMain.Db.Select(sql_slt).Tables[0];
            for(int i=0;i<dt_upd.Rows.Count;i++)
            {
                for(int j=0;j<dt.Rows.Count;j++)
                {
                    if(dt_upd.Rows[i]["item_id"].ToString() == dt.Rows[j]["item_id"].ToString())
                    {
                        dt.Rows[j]["isInsur"] = "0";
                        dt.Rows[j]["insuritem_code"] = dt_upd.Rows[i]["insurcode"];
                        dt.Rows[j]["insurname"] = dt_upd.Rows[i]["name"];
                    }
                }
            }
            for(int i=0 ;i<dt.Rows.Count;i++)
            {
                   sql += "insert into T_CON2 ("
                               + " Id"//费用Id
                               + ",Zyh"//住院号
                               + ",Fysj"//划价时间
                               + ",Zf"//是否补偿项目
                               + ",Yyfl"//医药分类
                               + ",Xmdm"//项目编码1
                               + ",Xmdm1"//项目编码2
                               + ",Xmmc"//项目名称1
                               + ",Xmmc2"//项目名称2
                               + ",Dj"//项目单价
                               + ",Sl"//项目数量
                               + ",Je ) values ("
                               + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["ihspcode"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["chargedate"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["isInsur"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["itemfrom"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["insuritem_code"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["item_id"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["insurname"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["name"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["prc"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["num"].ToString())
                               + "," + DataTool.addFieldBraces(dt.Rows[i]["fee"].ToString())
                               + ");";
                costdetIds += dt.Rows[i]["id"].ToString() + ",";
            }
            costdetIds = costdetIds.Substring(0,costdetIds.Length-1);
            int result = BllMain.Hdxbhnhdb.Update(sql);
            if(result ==0)
            {
                 string sql_upd = " update ihsp_costdet set insursync = 'Y' where id in ("+costdetIds+");";
                 BllMain.Db.Update(sql_upd);
            }
            return result;
        }
        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="invoiceCode"></param>
        /// <param name="invoiceTime"></param>
        /// <returns></returns>
        public int outhspMag(string ihsp_id,string invoiceCode,string invoiceTime)
        {
            string sql_slt = "select ihspcode,prepamt,outdate from inhospital where id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql_slt).Tables[0];
            string update = "update T_CON1 set Fph = " + DataTool.addFieldBraces(invoiceCode)
                          + ",Fpsj = " + DataTool.addFieldBraces(invoiceTime)
                          + ",Yj = " + DataTool.addFieldBraces(dt.Rows[0]["prepamt"].ToString())
                          + ",Z_date2 = " + DataTool.addFieldBraces(dt.Rows[0]["outdate"].ToString())
                          + " where Zyh1 = " + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString());
            return BllMain.Hdxbhnhdb.Update(update);       
        }
        public int turnSelfFee(string ihspid,string ihspcode )
        {
            string sql_search = "select id from ihsp_costdet where ihsp_id = " + DataTool.addFieldBraces(ihspid);
            DataTable dt = BllMain.Db.Select(sql_search).Tables[0];
            string costdetIds = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                costdetIds += dt.Rows[i]["id"].ToString() + ",";
            }
            costdetIds = costdetIds.Substring(0,costdetIds.Length-1);
            string sql = "delete from T_CON2 where id in ( " + costdetIds + " );";
            sql += "delete from T_CON1 where Zyh = " + DataTool.addFieldBraces(ihspcode) + "and Zyh1 = " + DataTool.addFieldBraces(ihspcode);
            int value =  BllMain.Hdxbhnhdb.Update(sql);
            if (value == 0)
            {
                string sql_update = "update ihsp_costdet set insursync = 'N';";
                sql_update += "update inhospital set bas_patienttype_id = (select id from bas_patienttype where cost_insurtype_id = (select id "
                           + " from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.SELFCOST.ToString()) + "))"
                           + " where id = " + DataTool.addFieldBraces(ihspid);
                BllMain.Db.Update(sql_update);
            }
            return value;
        }

        public int retIhspReg(string thisid)
        {
            string sql = "";
            string sql_search = "select ihspcode from inhospital  where id = " + DataTool.addFieldBraces(thisid);
            string sql_costdetIds = "select id from ihsp_costdet where ihsp_id = " + DataTool.addFieldBraces(thisid);
            DataTable dt = BllMain.Db.Select(sql_search).Tables[0];
            DataTable dt_costdetIds = BllMain.Db.Select(sql_costdetIds).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "delete from T_ CON1 where Zyh = " + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString()) + " and Zyh1 = " + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString()) + ";";
            }
            string costdetIds = "";
            for (int i = 0; i < dt_costdetIds.Rows.Count; i++)
            {
                costdetIds += dt_costdetIds.Rows[i]["id"].ToString() + ",";
            }
            costdetIds = costdetIds.Substring(0,costdetIds.Length-1);
            sql += "delete from T_CON2 where id in (" + costdetIds + ");";
            int value = BllMain.Hdxbhnhdb.Update(sql);
            return value;
        }
        /// <summary>
        /// 更新住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upinsurstat(string ihspcode, string insurstat)
        {
            string sql = "update inhospital set insurstat=" + DataTool.addFieldBraces(insurstat) + " where ihspcode=" + DataTool.addFieldBraces(ihspcode);
            return BllMain.Db.Update(sql);
        }
       
     }                
 }                    