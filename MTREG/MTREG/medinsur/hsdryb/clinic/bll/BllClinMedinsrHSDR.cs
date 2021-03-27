using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.hdyb.clinic.bo;
using System.Windows.Forms;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.bll
{
    class BllClinMedinsrHSDR
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
        /// <summary>
        /// 获取门诊疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getClinicDisease(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name,illcode  from cost_insurillness where pincode like '%" + pincode.Trim() + "%' ";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// 获得就诊病人信息
        /// </summary>
        /// <returns></returns>
        public DataTable getRegInfo(string reg_billcode)
        {
            string sql = "select AKC192"
                       + ",AAE036"
                       + ",AKC008"
                       + ",AKC025"
                       + ",AKC031"
                       + ",BKF050"
                       + " from KC21 where AKC190 = " + DataTool.addFieldBraces(reg_billcode);
            return BllMain.Hsdrdb.Select(sql).Tables[0];
        }
        /// <summary>
        /// 传输病人就诊信息
        /// </summary>
        /// <returns></returns>
        public bool insurReg(InsurInfo insurinfo, string reg_id)
        {
            string currData = BillSysBase.currDate();
            string sql = "select register.billcode,register.regdate,bas_depart.name as depart,bas_doctor.name as doctor"
                       + " from register left join bas_doctor on register.doctor_id = bas_doctor.id"
                       + " left join bas_depart on register.depart_id = bas_depart.id "
                       + " where register.id =" + DataTool.addFieldBraces(reg_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string AKC190 = dt.Rows[0]["billcode"].ToString();
            string AKC192 = dt.Rows[0]["regdate"].ToString();
            string AKC008 = dt.Rows[0]["doctor"].ToString();
            string AKC025 = dt.Rows[0]["depart"].ToString();
            string sql_insert = "insert into KC21 ( "
                       + " AKC190"
                       + ",AKA130"
                       + ",AKC192"
                       + ",AKC193"//门诊特殊病、住院时必录
                       + ",AAE011"
                       + ",AAE036"
                       + ",AKC008"
                       + ",AKC025"
                       + ",AKC031"//病历号
                       + ",AMC026"//生育类别   选择生育门诊、生育住院结算时必须录入
                       + ") values ("
                       + DataTool.addFieldBraces(AKC190)
                       + "," + DataTool.addFieldBraces(insurinfo.Ihsptype)
                       + "," + DataTool.addFieldBraces(AKC192)
                       + "," + DataTool.addFieldBraces("")
                        + "," + DataTool.addFieldBraces(ProgramGlobal.Username)
                       + "," + DataTool.addFieldBraces(currData)
                       + "," + DataTool.addFieldBraces(AKC008)
                       + "," + DataTool.addFieldBraces(AKC025)
                       + "," + DataTool.addFieldBraces(AKC190)
                       + "," + DataTool.addFieldBraces("")
                       + ");";
            string sql_search = "select count(*) from KC21 where AKC190 = " + DataTool.addFieldBraces(AKC190);
            DataTable dt_kc21 = BllMain.Hsdrdb.Select(sql_search).Tables[0];
            if (int.Parse(dt_kc21.Rows[0][0].ToString()) == 0)
            {
                int res = BllMain.Hsdrdb.Update(sql_insert);
                if (res == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("中间库录入登记信息错误 zydj---kc21----" + AKC190);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("中间库患者信息已存在 zydj---kc21----" + AKC190);
                return true;
            }
        }
        /// <summary>
        /// 费用信息传送到KC22
        /// </summary>
        /// <returns></returns>
        public int costdetTransfer(string cliniCode, string costdetIds, string insurtypeKeyname)
        {
            string sql = "";
            string sql_search = "select clinic_costdet.id,clinic_costdet.item_id,bas_item.name"
                              + ",case clinic_costdet.itemfrom when 'DRUG' then '1' when 'COST' then '2' when 'STUFF' then '3' end"
                              + ",clinic_costdet.prc,clinic_costdet.Num,clinic_costdet.realfee"
                              + " from clinic_costdet left join bas_item where clinic_costdet.item_id = bas_item.id"
                              + " where id in " + costdetIds;
            DataTable dt = BllMain.Db.Select(sql_search).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[0]["id"].ToString();
                string sql_sear = " select clinic_rcp.billcode,clinic_rcp.rcpdate from clinic_rcp"
                                + " where clinic_rcp id = (select clinic_rcp_id from clinic_rcpdetail where id in ("
                                + " select clinic_rcpdetail_id from clinic_costdet where id = " + DataTool.addFieldBraces(id)
                                + " ))";
                DataTable dt_sear = BllMain.Db.Select(sql_sear).Tables[0];

                   sql += "insert into KC22 ( "
                            + " AKC190"
                            + ",AKC220"
                            + ",AKC221"
                            + ",AKC515"
                            + ",AKC516"
                            + ",AKC224"
                            + ",AKC225"
                            + ",AKC226"
                            + ",AKC227 ) values ( "
                            + DataTool.addFieldBraces(cliniCode)
                            + "," + DataTool.addFieldBraces(id)
                            + "," + DataTool.addFieldBraces(dt_sear.Rows[0]["rcpdate"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["item_id"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["name"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["itemfrom"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["prc"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["num"].ToString())
                            + "," + DataTool.addFieldBraces(dt.Rows[0]["realfee"].ToString())
                            + ");";
            }
            int res = BllMain.Hsdrdb.Update(sql);
            if (res == 0)
            {
                string his_sql = "update clinic_costdet set insursync = 1 where id in ( " + costdetIds + ")";
                BllMain.Db.Update(his_sql);
                return 0;
            }
            else 
            {
                MessageBox.Show("上传至中间库信息失败 ---kc22---" + cliniCode);
                return -1;
            }
        }
    }
}
