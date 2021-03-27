using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.clintab.bo;

namespace MTREG.clintab.bll
{
    class BllClicTabManage
    {
        /// <summary>
        /// 日结管理
        /// </summary>
        /// <param name="dtpStime"></param>
        /// <param name="dtpEtime"></param>
        /// <returns></returns>
        public DataTable getClinicTabDay(string dtpStime, string dtpEtime,string depart)
        {
            string sql = "select "
                       + " clinictab_day.id"
                       + ",clinictab_day.depart_id"
                       + ",bas_depart.name as dptname"
                       + ",clinictab_day.enddate"
                       + ",clinictab_day.startdate"
                       + ",clinictab_day.billcode"
                       + ",clinictab_day.settledate"
                       + " from clinictab_day "
                       + " left join bas_depart"
                       + " on clinictab_day.depart_id = bas_depart.id"
                       + " where  clinictab_day.depart_id = " + DataTool.addFieldBraces(depart)
                       +" and clinictab_day.settledate  > " + DataTool.addFieldBraces(dtpStime)
                       + " and  clinictab_day.settledate <= " + DataTool.addFieldBraces(dtpEtime);
                     
                       
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 班结管理
        /// </summary>
        /// <param name="dtpStime"></param>
        /// <param name="dtpEtime"></param>
        /// <returns></returns>
        public DataTable getClinicTabDuty(string dtpStime, string dtpEtime, string createdby)
        {
            string sql = "select "
                       + " clinictab_duty.id"
                       + ",clinictab_duty.depart_id"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.name as dctname"
                       + ",clinictab_duty.enddate"
                       + ",clinictab_duty.startdate"
                       + ",clinictab_duty.billcode"
                       + ",clinictab_duty.settleby"
                       + " from clinictab_duty "
                       + " left join bas_depart on clinictab_duty.depart_id = bas_depart.id"
                       + " left join bas_doctor on clinictab_duty.charger_id = bas_doctor.id"
                       + " where  bas_doctor.name = " + DataTool.addFieldBraces(createdby)
                       + " and clinictab_duty.settledate  > " + DataTool.addFieldBraces(dtpStime)
                       + " and  clinictab_duty.settledate <= " + DataTool.addFieldBraces(dtpEtime);
                       
                      
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取日结可退结算id
        /// </summary>
        /// <param name="createdby"></param>
        /// <returns></returns>
        public DataTable getTabMaxId(string depart)
        {
            string sql = "select max(id) as id from clinictab_day where depart_id= " + DataTool.addFieldBraces(depart)
                        + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public bool getLastClinicTab(Clinictab clinictab)
        {
            bool ret = false;
            string sql = "select * from clinictab_day where depart_id= " + DataTool.addFieldBraces(clinictab.Depart_id)
                                  + " and islock='N'   order by id desc limit 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                clinictab.Startdate = dt.Rows[0]["startdate"].ToString();
                clinictab.Enddate = dt.Rows[0]["enddate"].ToString();
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// 日退结算
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public string  retClinicTab(string depart)
        {
            DataTable dt = getTabMaxId(depart);
            string clinictab_id = dt.Rows[0]["id"].ToString();
            
            //删除强制班结信息    
            string upsql = " delete from clinictab_detail where clinictab_duty_id in (select id from clinictab_duty"
                          +" where clinictab_day_id = " + DataTool.addFieldBraces(clinictab_id)
                          +" and daytab='Y');" 
                          +" delete from clinictab_invoiceamt where clinictab_duty_id in (select id from clinictab_duty"
                          +" where clinictab_day_id = " + DataTool.addFieldBraces(clinictab_id)
                          +" and daytab='Y');"
                          +" delete from clinictab_prepaid where clinictab_duty_id in (select id from clinictab_duty"
                          +" where clinictab_day_id = " + DataTool.addFieldBraces(clinictab_id)
                          +" and daytab='Y');"
                          +" delete from clinictab_duty"
                          +" where clinictab_day_id = " + DataTool.addFieldBraces(clinictab_id)
                          +" and daytab='Y';";
            //还原班结信息
            upsql += "update clinictab_duty set clinictab_day_id='0'"
                    + " where clinictab_day_id=" + DataTool.addFieldBraces(clinictab_id)
                    + ";";
            //删除日结信息
            upsql +="delete from clinictab_costgather"
                    + " where clinictab_day_id = " + DataTool.addFieldBraces(clinictab_id)
                    + ";"
                    +" delete from clinictab_day"
                    + " where id = " + DataTool.addFieldBraces(clinictab_id)
                    + ";";
            return upsql;
        }

        /// <summary>
        /// 获取班结可退结算id
        /// </summary>
        /// <param name="createdby"></param>
        /// <returns></returns>
        public DataTable getDutyMaxId(string createdby)
        {
            string sql = "select max(id) as id from clinictab_duty where charger_id= " + DataTool.addFieldBraces(createdby)
                                   + " and clinictab_day_id='0'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public bool getLastClinicTabDuty(Clinictab clinictab)
        {
            bool ret = false;
            string sql = "select * from clinictab_duty where charger_id= " + DataTool.addFieldBraces(clinictab.Charger_id)
                                  + " and clinictab_day_id='0' order by id desc limit 1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                clinictab.Startdate = dt.Rows[0]["startdate"].ToString();
                clinictab.Enddate = dt.Rows[0]["enddate"].ToString();
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 班退结算
        /// </summary>
        /// <returns></returns>
        public int deleteClinicTabDuty(string createdby)
        {
            DataTable dt = getDutyMaxId(createdby);
            string clinictab_duty_id = dt.Rows[0]["id"].ToString();
            string upsql = "delete from clinictab_duty"
                         + " where id = " + DataTool.addFieldBraces(clinictab_duty_id)
                         + ";";
            upsql += "delete from clinictab_detail"
                         + " where clinictab_duty_id = " + DataTool.addFieldBraces(clinictab_duty_id)
                         + ";";
            upsql += "delete from clinictab_invoiceamt"
                         + " where clinictab_duty_id = " + DataTool.addFieldBraces(clinictab_duty_id)
                         + ";";
            return doExeSql(upsql);
        }

        //执行sql语句
        public int doExeSql(string sql)
        {
            int result = -1;
            try
            {
                result = BllMain.Db.Update(sql);
            }
            catch (Exception e) { }

            return result;
        }       
    }
}
