using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.main.bll;
using System.Data;
using System.Threading;

namespace MTREG.medinsur.gysyb.bll
{
    //在数据库中建立gysyb_visitor表，有三列syb,szyb,swyb.
    //默认值为0，表示可以访问，为1，表示正被占用，提示稍后再试
    //如果有访问医保中心，则选取的相应字段的结果值，根据值来判断是否继续操作
    class Judge_Visitor
    {
        //flag代表是何种医保的标志0代表市医保，1代表省医保，2代表省外医保
        /// <summary>
        /// 判断医保中心是否被占用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        //public bool judge(String flag,HISDB hisdb,OdbcTransaction trans)
        //{
        //    if (update1(flag, hisdb, trans) != -1)
        //        return true;
        //    return false;
        //}
        
        
        
        public static bool judge()
        {
            String sql = "select syb,EXTRACT(MINUTE FROM  (localtimestamp-updatetime)) as date from gysyb_visitor";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            //if(flag =="171")
            if (Getdouble(dt.Rows[0]["date"].ToString()) < 2)
            {
                int count = 0;
                while (true)
                {
                    count++;
                    if (count > 100)
                    {
                        return false;
                    }
                   
                   
                    if ("0".Equals(dt.Rows[0]["syb"].ToString()))
                        break;
                    else
                        Thread.Sleep(500);
                    dt = BllMain.Db.Select(sql).Tables[0];
                 
                }
            }
            if (update1() == -1)
                return false;
      
           
            return true;
        }
        //设置标记为为1，表示不可访问
        //public int update1(String flag, HISDB hisdb, OdbcTransaction trans)
        //{
        //    if ("171".Equals(flag))
        //    {
        //        String sql = "update visitor set syb=1";
        //        int ver =hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    if ("168".Equals(flag))
        //    {
        //        String sql = "update visitor set szyb=1";
        //        int ver = hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    if ("173".Equals(flag))
        //    {
        //        String sql = "update visitor set szyb=1";
        //        int ver = hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    return 0;
        //}
        //设置标记为为1，表示不可访问
        public static int update1()
        {
            //if ("171".Equals(flag))
            //{
            String sql = "update gysyb_visitor set syb=1,updatetime=localtimestamp where 1=1";
                int ver = BllMain.Db.Update(sql);
                return ver;
            //}
            //if ("168".Equals(flag))
            //{
            //    String sql = "update visitor set szyb=1 where 1=1";
            //    int ver = hisdb.Update(sql);
            //    return ver;
            //}
            //if ("173".Equals(flag))
            //{
            //    String sql = "update visitor set szyb=1 where 1=1";
            //    int ver = hisdb.Update(sql);
            //    return ver;
            //}
            //return 0;
        }


        /// <summary>
        /// 根据传过来的字符串返回double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Getdouble(String str)
        {
            if ("".Equals(str))
            {
                return 0;
            }
            else
            {
                if (yzsz(str))
                {
                    return double.Parse(str);
                }
                return 0;
            }

        }



        /// <summary>
        /// 验证是否是数字
        /// </summary>
        /// <param name="str"></param>
        public static  bool yzsz(string str)
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




        //设置标记为为0，表示可访问
        /// <summary>
        /// 访问结束，更新标记位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public int update(String flag, HISDB hisdb, OdbcTransaction trans)
        //{
        //    if ("171".Equals(flag))
        //    {
        //        String sql = "update visitor set syb=0";
        //        int ver =hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    if ("168".Equals(flag))
        //    {
        //        String sql = "update visitor set szyb=0";
        //        int ver =hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    if ("173".Equals(flag))
        //    {
        //        String sql = "update visitor set szyb=0";
        //        int ver =hisdb.insert(sql,trans);
        //        return ver;
        //    }
        //    return 0;
        //}
        //设置标记为为0，表示可访问
        /// <summary>
        /// 访问结束，更新标记位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static int update()
        {
            //if ("171".Equals(flag))
            //{
            String sql = "update gysyb_visitor set syb=0,updatetime=localtimestamp where 1=1";
                int ver = BllMain.Db.Update(sql);
                return ver;
            //}
            //if ("168".Equals(flag))
            //{
            //    String sql = "update visitor set szyb=0 where 1=1";
            //    int ver = hisdb.Update(sql);
            //    return ver;
            //}
            //if ("173".Equals(flag))
            //{
            //    String sql = "update visitor set szyb=0 where 1=1";
            //    int ver = hisdb.Update(sql);
            //    return ver;
            //}
            //return 0;
        }


        /// <summary>
        /// 获得排队号-----------------------------------
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static bool acquire_pdh(ref int pdh, String org)
        {
            String sql = "select pds,flag from mtmzghpdb where org='" + org + "' and rq='" + DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {

                String sql_insert = "CREATE SEQUENCE mtmzpdb_seq_" + DateTime.Today.ToString("yyyyMMdd") + "_" + org + " INCREMENT 1   MINVALUE 1   MAXVALUE 999   START 2 CACHE 1;"
                                    + "insert into mtmzghpdb(pds,rq,org,flag) values(1,'" + DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00','" + org + "',1" + ");";
                String sql_delete = "drop sequence mtmzpdb_seq_" + DateTime.Today.AddDays(-2).ToString("yyyyMMdd") + "_" + org + ";"
                                    + "delete from mtmzghpdb where org='" + org + "' and rq='" + DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd") + " 00:00:00'";
                String sql_delete_7 = "drop sequence mtmzpdb_seq_" + DateTime.Today.AddDays(-7).ToString("yyyyMMdd") + "_" + org + ";"
                                    + "delete from mtmzghpdb where org='" + org + "' and rq='" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + " 00:00:00'";
                if (BllMain.Db.Update(sql_insert) == -1)
                    return false;
                BllMain.Db.Update(sql_delete);
                BllMain.Db.Update(sql_delete_7);
                pdh = 1;
                return true;

            }
            String sql_pds = "select nextval('mtmzpdb_seq_" + DateTime.Today.ToString("yyyyMMdd") + "_" + org + "') as pds";
            DataTable pds = BllMain.Db.Select(sql_pds).Tables[0];
            pdh = Convert.ToInt32(pds.Rows[0]["pds"].ToString());
            return true;
        }
    }
}
