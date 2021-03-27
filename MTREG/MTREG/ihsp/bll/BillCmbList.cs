using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.ihsp.bll
{
    class BillCmbList
    {
        /// <summary>
        /// 收费科室
        /// </summary>
        /// <returns></returns>
        public DataTable depTypeList()
        {
            string sql = "select * from bas_depart "
                                + " where id in (select depart_id"
                                                + " from bas_depart_departtype "
                                                + " where departtype_id in(select id"
                                                                            + " from bas_departtype"
                                                                            + " where typecode ='CHRG')) and bas_depart.isstop = 'N'";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 患者类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable patientTypeList()
        {
            string sql = "";
            if (ProgramGlobal.Zyyblx == "7")
            {
                sql = "select id,name from bas_patienttype where isstop='N' and payment_id in (7)";
            }
            else
            {
                sql = "select id,name from bas_patienttype where isstop='N' and payment_id in (" + ProgramGlobal.Zyyblx + ",7)";
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getpatientType()
        {
            string sql = "select id,name from bas_patienttype where isstop='N'";// and cost_insurtype_id <>1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 患者类型下拉表——转医保
        /// </summary>
        /// <returns></returns>
        public DataTable patientTypeListInsur()
        {
            string sql = " select id,name  from bas_patienttype where isstop='N' and cost_insurtype_id <>1 and payment_id in (" + ProgramGlobal.Zyyblx + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 入院状态下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspinstatList()
        {
            string sql = "select sn as id,name from sys_dict where dicttype='bas_ihspinstat' and father_id<>0 and isstop='N' order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 出院状态下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspoutstatList()
        {
            string sql = "select sn as id,name from sys_dict where sys_dict.isstop = 'N' and dicttype='bas_ihspoutstat' and father_id<>0 order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 门诊,住院疾病
        /// </summary>
        /// <returns></returns>
        public DataTable regCase(string info)
        {
            string sql = "select id,illcode as icd10 ,name as name from insur_illness "
                        + " where (pincode like  " + DataTool.addFieldBraces("" + info + "%") + " or name like " + DataTool.addFieldBraces("%" + info + "%") + " ) and sign = '1' limit 250";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 行政区域下拉选择
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable regionList(string pincode)
        {
            string sql = "select id,mergername "
                            + " from sys_region"
                            + " where father_id<>0"
                            + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or mergername like " + DataTool.addFieldBraces("%" + pincode + "%") + ")"
                            + " order by ordersn limit 50;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 下拉框 民族
        /// </summary>
        /// <returns></returns>
        public DataTable getRaceInfo(string pincode)
        {
            DataTable dt = new DataTable();
            string sql = "select sys_dict.sn as id "
                       + ",sys_dict.name"
                       + " from sys_dict "
                       + " where father_id <>0 and dicttype = 'member_race' "
                       + " and sys_dict.isstop = 'N' "
                       + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or name like " + DataTool.addFieldBraces("%" + pincode + "%") + ")"
                       + " order by id limit 50";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 民族
        /// </summary>
        /// <returns></returns>
        public DataTable getRaceInfo_code(string standcode)
        {
            DataTable dt = new DataTable();
            string sql = "select sys_dict.sn as id "
                       + ",sys_dict.name"
                       + " from sys_dict "
                       + " where father_id <>0 and dicttype = 'member_race' "
                       + " and sys_dict.isstop = 'N' "
                       + " and standcode = " + DataTool.addFieldBraces(standcode)
                       + " order by id limit 50";
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 性别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable sexList()
        {
            string sql = "select sn as id,name from sys_dict where father_id<>0 and dicttype='bas_sex' and isstop='N' order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 根据关键字获取性别编码
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string sexid(string keyname)
        {
            string sql = "select sn  from sys_dict where father_id<>0 and dicttype='bas_sex' and isstop='N' and keyname=" + DataTool.addFieldBraces(keyname);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string id = datatable.Rows[0]["sn"].ToString();
                return id;
            }
            return "9";
        }

        /// <summary>
        /// 入院途径下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspSourceList()
        {
            string sql = "select sn as id,name from sys_dict where father_id<>0"
                + " and sys_dict.isstop = 'N'"
                + " and dicttype='bas_ihspsource' order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 费用级别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable regCostclassList()
        {
            string sql = "select keyname,name from sys_dict where dicttype='bas_costclass'"
                + " and sys_dict.isstop = 'Y'"
                + " and father_id<>0 order by ordersn;";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 年龄单位下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ageunitList()
        {
            string sql = "select sn as id,name from sys_dict where dicttype='bas_ageunit' "
                + " and sys_dict.isstop = 'N'"
                + " and father_id<>0 order by ordersn;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 科室名称下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable departList()
        {
            string sql = "select id,name  from bas_depart"
                + " where bas_depart.isstop = 'N' and id>1;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 根据简码查询所有科室
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable departList(string pincode)
        {
            string sql = "select id,name  from bas_depart"
                + " where bas_depart.isstop = 'N' and id>1"
                + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or name like " + DataTool.addFieldBraces("%" + pincode + "%") + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 住院科室下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspDepart()
        {
            string sql = "select id,name from bas_depart "
                               + " where id in (select depart_id"
                                               + " from bas_depart_departtype "
                                               + " where departtype_id in(select id"
                                                                           + " from bas_departtype"
                                                                           + " where typecode ='IHSP'))"
                                               + " and bas_depart.isstop = 'N';";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 住院科室下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspDepart(string pincode)
        {
            string sql = "select id,name from bas_depart "
                               + " where bas_depart.isstop = 'N'"
                               + " and id in (select depart_id"
                                               + " from bas_depart_departtype "
                                               + " where departtype_id in(select id"
                                                                           + " from bas_departtype"
                                                                           + " where typecode ='IHSP'))"
                               + " and (pincode like " + DataTool.addFieldBraces("%" + pincode + "%") + " or name like " + DataTool.addFieldBraces("%" + pincode + "%") + ")"
                               + " order by bas_depart.ordersn ";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable payPaytypeList()
        {
            DataTable dt = new DataTable();
            string sql = "select bas_paytype_id as id, name from bas_paysumby where isinsur='0' order by ordersn;";
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
        /// 医生姓名下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable doctorList()
        {
            string sql = "select "
                + " bas_doctor.id"
                + ",bas_doctor.name"
                + " from "
                + " bas_doctor "
                + " where "
                + " bas_doctor.id in (select doctor_id from bas_doctor_doctype where doctype='DOCTOR') and bas_doctor.isstop = 'N'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        ///获取对应科室医生信息
        /// </summary>
        /// <returns></returns>
        ///
        public DataTable doctorNameGet(String depart)
        {
            String sql = "  SELECT"
                                   + " 	bas_doctor.id,"
                                   + " 	bas_doctor. NAME"
                                   + " FROM"
                                   + " 	bas_doctor,"
                                   + " 	bas_doctor_depart,"
                                   + "     bas_doctor_doctype"
                                   + " WHERE"
                                   + " 	bas_doctor.id = bas_doctor_depart.doctor_id"
                                   + " AND  bas_doctor.id = bas_doctor_doctype.doctor_id"
                                   + " AND	 bas_doctor_doctype.doctype= 'DOCTOR'"
                                   + " AND  bas_doctor.isstop = 'N'"
                                   + " AND	 bas_doctor_depart.depart_id= " + DataTool.addFieldBraces(depart);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 费用类别下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable itemtype1List()
        {
            string sql = "select id,name from cost_itemtype1";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取医生姓名
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public string getDoctorName(string doctor)
        {
            string doc = "select name from bas_doctor where id = " + DataTool.addFieldBraces(doctor);
            DataTable datatable = BllMain.Db.Select(doc).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string doct = datatable.Rows[0]["name"].ToString();
                return doct;
            }
            else
            {
                return "0";
            }
        }

    }

}
