using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Text.RegularExpressions;
//using zhongluyiyuan.Common;
//using zhongluyiyuan.Report_form;
//using zhongluyiyuan.Mzgh;

namespace zhongluyiyuan.Util
{
    public class Common_Util
    {
        //Gyd gyd = Gyd.getGyd();
        //Mzfpdy mzfpbd = new Mzfpdy();
        /// <summary>
        /// 重置入院登记所需表的iid 序列号
        /// </summary>
        //public bool ResettingSequence()
        //{
        //    OdbcConnection connection = hisdb.getConntion();
        //    connection.Open();
        //    String sql = " select max(iid) as iid from ctct";
        //    String ctct_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) +1).ToString().Trim();
        //    sql = " select max(iid) as iid from cimsuser";
        //    String cimsuser_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from address";
        //    String address_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from ctctaddr";
        //    String ctctaddr_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from ctctorg";
        //    String ctctorg_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from mtchargeinfo";
        //    String mtchargeinfo_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from mtzyjl";
        //    String mtzyjl_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select zyjlbah,zyjlzyh from mtzyjl where iid=" + mtzyjl_iid;
        //    String mtzyjl_bah = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["zyjlbah"].ToString()) + 1).ToString().Trim();
        //    String mtzyjl_zyh = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["zyjlzyh"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from mtszks ";
        //    String mtszks_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select Max(iid) as iid from mtprecharge ";
        //    String mtprecharge_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select Max(iid) as iid from cimsuserrole";
        //    String cimsuserrole_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from mtcxcy";
        //    String mtcxcy_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid)as iid from mtmzblstuff ";
        //    String mtmzblstuff_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select Max(iid) as iid from mtqyd_yb";
        //    String mtqyd_yb_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid  from mtmzgh";
        //    String mtmzgh_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(iid) as iid from mtmzbl";
        //    String mtmzbl_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select Max(iid) as iid from mtstuffitem";
        //    String mtstuffitem_iid = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["iid"].ToString()) + 1).ToString().Trim();
        //    sql = " select max(mzblmzh) as mtblmzh from mtmzbl";
        //    String mtblmzh_mzh = (Convert.ToInt32(hisdb.Select(sql, connection).Tables[0].Rows[0]["mtblmzh"].ToString()) + 1).ToString().Trim();
        //    String updateSeq = " select setval('ctct_iid_seq'," + ctct_iid + "); select setval('cimsuser_iid_seq'," + cimsuser_iid + "); select setval('address_iid_seq'," + address_iid + ");";
        //            updateSeq += " select setval('ctctaddr_iid_seq'," + ctctaddr_iid + "); select setval('ctctorg_iid_seq'," + ctctorg_iid + "); select setval('mtchargeinfo_iid_seq'," + mtchargeinfo_iid + ");";
        //            updateSeq += " select setval('mtzyjl_iid_seq'," + mtzyjl_iid + "); select setval('mtzyjl_bah_seq'," + mtzyjl_bah + ");select setval('mtzyjl_zyh_seq'," + mtzyjl_zyh + ");select setval('mtszks_iid_seq'," + mtszks_iid + ");";
        //            updateSeq += " select setval('mtprecharge_iid_seq'," + mtprecharge_iid + ");";
        //            updateSeq += " select setval('cimsuserrole_iid_seq'," + cimsuserrole_iid + ");";
        //            updateSeq += " select setval('mtcxcy_iid_seq'," + mtcxcy_iid + ");";
        //            updateSeq +=" select setval('mtmzblstuff_iid_seq'," + mtmzblstuff_iid + ");";
        //            updateSeq += " select setval('mtqyd_yb_iid_seq'," + mtqyd_yb_iid + ");";
        //            updateSeq += " select setval('mtmzgh_iid_seq'," + mtmzgh_iid + ");";
        //            updateSeq += " select setval('mtmzbl_iid_seq'," + mtmzbl_iid + ");";
        //            updateSeq += " select setval('mtstuffitem_iid_seq'," + mtstuffitem_iid + ");";
        //            updateSeq += " select setval('mtmzbl_mzh_seq'," + mtblmzh_mzh + ");";
        //    if (hisdb.Select(updateSeq).Tables[0].Rows.Count > 0)
        //    {
        //        hisdb.ColseConnection(connection);
        //        return true;
        //    }
        //    else
        //    {

        //        return false;
        //    }

        //}
        /// <summary>
        /// 验证是否是数字
        /// </summary>
        /// <param name="str"></param>
        public bool yzsz(string str)
        {
            //String pattern = " /^-?[1-9]+(\\.\\d+)?$|^-?0(\\.\\d+)?$|^-?[1-9]+[0-9]*(\\.\\d+)?$/";
            //Match m = Regex.Match(str, pattern);
            //if (m.Success)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            try
            {
                float d = float.Parse(str.Trim());
            }
            catch
            {
                return false;
            }
            return true;

        }
        ///// <summary>
        ///// 医保结算后插入数据
        ///// </summary>
        ///// <returns></returns>
        //public bool ybjs(Dictionary<String, String> dic2, StringBuilder message, Dictionary<String, float> dic, string currDateTime)
        //{
        //    if (!gyd.ybJs_Add_paragraph(dic2, message, dic, currDateTime))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>    
        /// 实现数据的四舍五入法　　 
        /// </summary>    
        /// <param name="v">要进行处理的数据</param>    
        /// <param name="x">保留的小数位数</param>   
        /// <returns>四舍五入后的结果</returns>   
        public double Round(double v, int x)
        {
            bool isNegative = false;
            //如果是负数        
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }
            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue, 0);
            v = Int / IValue;
            if (isNegative)
            {
                v = -v;
            }
            return v;
        }
        /// <summary>
        /// 打印腕带
        /// </summary>
        /// <param name="Mtzyjl_iid"></param>
        /// <param name="nl"></param>
        public void Dywd(String Mtzyjl_iid,String nl)
        {
            //Report_Select report_select = new Report_Select();
            //DataTable dywd= report_select.Dywd(Mtzyjl_iid);
            //dywd.Rows[0][""].ToString().Trim();

        }
        /// <summary>
        /// 根据传过来的字符串返回double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public float Getfloat(String str)
        {
            if (str.Equals(""))
            {
                return 0;
            }
            else
            {
                if (yzsz(str))
                {
                    return float.Parse(str);
                }
                return 0;
            }
        
        }
        /// <summary>
        /// 根据传过来的字符串返回double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public double Getdouble(String str)
        {
            double ret = 0;
            try
            {
                ret = Convert.ToDouble(str.Trim());
               
            }
            catch
            {
                ret = 0;
            }
            return  Math.Round(ret, 2);

            //if ("".Equals(str))
            //{
            //    return 0;
            //}
            //else
            //{
            //    if (yzsz(str))
            //    {
            //        return double.Parse(str);
            //    }
            //    return 0;
            //}

        }
        /// <summary>
        /// 根据Mtmzblstuff_iid循环打印发票
        /// </summary>
        /// <param name="Mtmzblstuff_iid"></param>
        public void Mzfpdy(String Mtmzblstuff_iid,String yl_fkfs)
        {
            //frmMzdy frm_mzfp = new frmMzdy();
            //DataTable grxxdt = mzfpbd.mzsffp3(Mtmzblstuff_iid);
            //for (int i = 0; i < grxxdt.Rows.Count; i++)
            //{
            //    frm_mzfp.Fphzd = grxxdt.Rows[i]["fph"].ToString().Trim();
            //    frm_mzfp.Mtmzblstuff_iid = Mtmzblstuff_iid;
            //    frm_mzfp.Ylkfkfs = yl_fkfs;
            //    frm_mzfp.Preview();
            //    //frm_mzfp.Show();
            //}
        }

        /// <summary>
        /// 根据Mtmzblstuff_iid循环打印发票（修改）
        /// </summary>
        /// <param name="Mtmzblstuff_iid"></param>
        public void Mzfpdy1(String Mtmzblstuff_iid, String yl_fkfs,String fph)
        {
            //FrmMzfp frm_mzfp = new FrmMzfp();
            ////DataTable grxxdt = mzfpbd.mzsffp3(Mtmzblstuff_iid);
            //DataTable grxxdt = mzfpbd.mzsffp4(fph);
            ////for (int i = 0; i < grxxdt.Rows.Count; i++)
            ////{
            //frm_mzfp.Fphzd = grxxdt.Rows[0]["fph"].ToString().Trim();
            //frm_mzfp.Mtmzblstuff_iid = Mtmzblstuff_iid;
            //frm_mzfp.Ylkfkfs = yl_fkfs;
            //frm_mzfp.Preview();
            //frm_mzfp.Show();
            //}
        }


        /// <summary>
        /// 组品字符串时判断字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public String Getstr(String str)
        {
            String[] strs = str.Split('\'');
            StringBuilder newstr = new StringBuilder(1024);
            for (int i = 0; i < strs.Length; i++)
            {

                if (i == strs.Length - 1)
                {
                    newstr.Append(strs[i]);
                }
                else
                {
                    newstr.Append(strs[i] + "\\'");
                }
            }
            return newstr.ToString().Trim();
        }
        /// <summary>
        /// 根据年龄算出出生日期
        /// </summary>
        /// <param name="nl"></param>
        /// <returns></returns>
        public  string Getcsrq(String nl)
        {
            String nown = DateTime.Now.ToString("yyyy");
            double csnl_double = Getdouble(nown) - Getdouble(nl);
            string csnlstr = csnl_double.ToString()+"-01-01 00:00:00";
            return csnlstr.ToString().Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String Getuptime(String time)
        {
            string[] times = time.Split(':');
            if (Getdouble(times[2]) > 1)
            { 
                    
            
            }
            return "";
        }

        public String getRylb(string rylb)
        {
            String ret = "";
            if (rylb.Equals("11"))
            {
                ret = "在职";
            }
            else if (rylb.Equals("21"))
            {
                ret = "退休";
            }
            else if (rylb.Equals("32"))
            {
                ret = "省属离休";
            }
            else if (rylb.Equals("34"))
            {
                ret = "市属离休";
            }
            else if (rylb.Equals("41"))
            {
                ret = "普通居民";
            }
            else if (rylb.Equals("42"))
            {
                ret = "低保对象";
            }
            else if (rylb.Equals("43"))
            {
                ret = "三无人员";
            }
            else if (rylb.Equals("44"))
            {
                ret = "低收入家庭";
            }
            else if (rylb.Equals("45"))
            {
                ret = "重度残疾";
            }
            return ret;
        }


    }
}
