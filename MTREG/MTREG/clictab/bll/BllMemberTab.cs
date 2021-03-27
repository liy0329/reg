using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.clintab.bo;

namespace MTREG.clintab.bll
{
    class BllMemberTab
    {
        /// <summary>
        /// 查询会员充值记录信息
        /// </summary>
        /// <param name="startime"></param>
        /// <param name="endtime"></param>
        /// <param name="info"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable getRechargedetInfo(string startime,string endtime,string info,string flag)
        {
            string sql = "select amount"
                + " ,CASE"
                + " WHEN opertype='RE' THEN '充值'"
                + " WHEN opertype='EN' THEN '取现'"
                + " END as opertype"
                + ",sys_dict.name as paytype"
                + ",bas_depart.name as depart"
                + ",bas_doctor.name as doctor"
                + ",operatdate"
                + " from member_rechargedet"
                + " left join bas_depart  on bas_depart.id = member_rechargedet.depart_id "
                + " left join bas_doctor  on bas_doctor.id = member_rechargedet.operator "
                + " left join sys_dict on member_rechargedet.bas_paytype_id=sys_dict.sn and sys_dict.dicttype='bas_paytype'"
                + " where opertype<>'CO'";
            if (startime != endtime && !string.IsNullOrEmpty(startime) && !string.IsNullOrEmpty(endtime))
            {
                sql += " and operatdate>" + DataTool.addFieldBraces(startime)
                    + " and operatdate<=" + DataTool.addFieldBraces(endtime);
            }                
            if (flag == "duty")
            {
                sql += " and operator=" + DataTool.addFieldBraces(info);
            }
            else if (flag == "tab")
            {
                sql += " and member_rechargedet.depart_id=" + DataTool.addFieldBraces(info);
            }
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 插入门诊班结储值卡汇总
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="id"></param>
        public string inClinictab_detail(Clinictab clinictab,string id)
        {
            string sqlRE = "select count(id) as num"
                        + ",opertype"
                        + ",SUM(amount) as amount"
                        + ",bas_paytype_id"
                        + " from member_rechargedet "
                        + " where operator = " + DataTool.addFieldBraces(clinictab.Charger_id)
                        + " and operatdate>" + DataTool.addFieldBraces(clinictab.Startdate)
                        + " and operatdate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                        + " and opertype='RE'"
                        + " group by bas_paytype_id,opertype";
            DataTable dtRE = BllMain.Db.Select(sqlRE).Tables[0];
            string sqlEN = "select count(id) as num"
                        + ",opertype"
                        + ",SUM(amount) as amount"
                        + ",bas_paytype_id"
                        + " from member_rechargedet "
                        + " where operator = " + DataTool.addFieldBraces(clinictab.Charger_id)
                        + " and operatdate>" + DataTool.addFieldBraces(clinictab.Startdate)
                        + " and operatdate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                        + " and opertype='EN'"
                        + " group by bas_paytype_id,opertype";
            DataTable dtEN = BllMain.Db.Select(sqlEN).Tables[0];
            string insql = "";
            bool ishave=false;
            for (int i = 0; i < dtRE.Rows.Count; i++)
            {
                for (int j = 0; j < dtEN.Rows.Count; j++)
                {
                    if (dtRE.Rows[i]["bas_paytype_id"].ToString() == dtEN.Rows[j]["bas_paytype_id"].ToString())
                    {
                        string clinictab_prepaid_id = BillSysBase.nextId("clinictab_prepaid");
                        double realfee = double.Parse(dtRE.Rows[i]["amount"].ToString()) - double.Parse(dtEN.Rows[i]["amount"].ToString());
                        insql += "insert into clinictab_prepaid (id"
                              + ",clinictab_duty_id"
                              + ",bas_paytype_id"
                              + ",num"
                              + ",fee"
                              + ",retnum"
                              + ",retfee"
                              + ",realfee)values("
                              + DataTool.addFieldBraces(clinictab_prepaid_id)
                              + "," + DataTool.addFieldBraces(id)
                              + "," + DataTool.addFieldBraces(dtRE.Rows[i]["bas_paytype_id"].ToString())
                              + "," + DataTool.addFieldBraces(dtRE.Rows[i]["num"].ToString())
                              + "," + DataTool.addFieldBraces(dtRE.Rows[i]["amount"].ToString())
                              + "," + DataTool.addFieldBraces(dtEN.Rows[i]["num"].ToString())
                              + "," + DataTool.addFieldBraces(dtEN.Rows[i]["amount"].ToString())
                              + "," + DataTool.addFieldBraces(realfee.ToString())
                              + ");";
                        ishave = true;
                    }
                    else
                    {
                        for (int m = 0; m < dtRE.Rows.Count; m++)
                        {
                            if (dtRE.Rows[m]["bas_paytype_id"].ToString() == dtEN.Rows[j]["bas_paytype_id"].ToString())
                            {
                                ishave = true;
                            }
                        }
                        if (!ishave)
                        {
                            string clinictab_prepaid_id = BillSysBase.nextId("clinictab_prepaid");
                            insql += "insert into clinictab_prepaid (id"
                                                         + ",clinictab_duty_id"
                                                         + ",bas_paytype_id"
                                                         + ",num"
                                                         + ",fee"
                                                         + ",retnum"
                                                         + ",retfee"
                                                         + ",realfee)values("
                                                         + DataTool.addFieldBraces(clinictab_prepaid_id)
                                                         + "," + DataTool.addFieldBraces(id)
                                                         + "," + DataTool.addFieldBraces(dtEN.Rows[j]["bas_paytype_id"].ToString())
                                                         + "," + DataTool.addFieldBraces("0")
                                                         + "," + DataTool.addFieldBraces("0")
                                                         + "," + DataTool.addFieldBraces(dtEN.Rows[j]["num"].ToString())
                                                         + "," + DataTool.addFieldBraces(dtEN.Rows[j]["amount"].ToString())
                                                         + "," + DataTool.addFieldBraces(dtEN.Rows[j]["amount"].ToString())
                                                         + ");";
                        }
                    }
                }
                if (!ishave)
                {
                    string clinictab_prepaid_id = BillSysBase.nextId("clinictab_prepaid");
                    insql += "insert into clinictab_prepaid (id"
                                                 + ",clinictab_duty_id"
                                                 + ",bas_paytype_id"
                                                 + ",num"
                                                 + ",fee"
                                                 + ",retnum"
                                                 + ",retfee"
                                                 + ",realfee)values("
                                                 + DataTool.addFieldBraces(clinictab_prepaid_id)
                                                 + "," + DataTool.addFieldBraces(id)
                                                 + "," + DataTool.addFieldBraces(dtRE.Rows[i]["bas_paytype_id"].ToString())
                                                 + "," + DataTool.addFieldBraces(dtRE.Rows[i]["num"].ToString())
                                                 + "," + DataTool.addFieldBraces(dtRE.Rows[i]["amount"].ToString())
                                                 + "," + DataTool.addFieldBraces("0")
                                                 + "," + DataTool.addFieldBraces("0")
                                                 + "," + DataTool.addFieldBraces(dtRE.Rows[i]["amount"].ToString())
                                                 + ");";
                }
            }
            return insql;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinictab"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable memberTabReport(Clinictab clinictab,string flag)
        {
            string sql = "select count(member_rechargedet.id) as num"
                        + ",bas_doctor.name"
                        + ",bas_depart.name"
                        + ",opertype"
                        + ",SUM(amount) as amount"
                        + ",bas_paytype_id"
                        + " from member_rechargedet "
                        + " left join bas_doctor on bas_doctor.id=member_rechargedet.operator"
                        + " left join bas_depart on bas_depart.id=member_rechargedet.depart_id";
                        if(flag=="duty")
                        {
                            sql += " where member_rechargedet.operator = " + DataTool.addFieldBraces(clinictab.Charger_id);
                        }
                        else if (flag == "tab")
                        {
                            sql += " where member_rechargedet.depart_id = " + DataTool.addFieldBraces(clinictab.Depart_id);
                        }                        
                        sql+= " and operatdate>" + DataTool.addFieldBraces(clinictab.Startdate)
                        + " and operatdate<=" + DataTool.addFieldBraces(clinictab.Enddate)
                        + " and opertype in ('RE','EN')"
                        + " group by bas_paytype_id,opertype";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
    }
}
