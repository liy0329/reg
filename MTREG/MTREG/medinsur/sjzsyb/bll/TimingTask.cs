using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;
using System.Data;
using MTREG.common.bll;
using MTHIS.tools;
using MTHIS.common;

namespace MTREG.medinsur.sjzsyb.bll
{
    /// <summary>
    /// 定时任务
    /// </summary>
    public class TimingTask
    {
        SysWriteLogs writeLogs = new SysWriteLogs();
        SjzybInterface sjzybInterface = new SjzybInterface();
        /// <summary>
        /// 【1121】医疗费信息对账（明细）
        /// </summary>
        public void Reconciliation()
        {

            DateTime starttime = DateTime.Now.AddDays(-1);

            writeLogs.writeLogs("定时任务：医保对账（明细）", DateTime.Now, "定时任务：医保对账（明细）        开始");
            BllItemcrossSJZ BllItemcrossSJZ = new BllItemcrossSJZ();


            DataTable dt = BllItemcrossSJZ.GETAccount(starttime.ToString("yyyy-MM-dd 00:00:00"), starttime.ToString("yyyy-MM-dd 23:59:59"), "", "");

            if (dt.Rows.Count < 0)
            {
                writeLogs.writeLogs("定时任务：医保对账（明细）", DateTime.Now, "定时任务：医保对账（明细）        未查询到有效数据，推出、退出");
                return;
            }

            SJZYB_IN<Reconciliation_In_xm> yb_in_dz = new SJZYB_IN<Reconciliation_In_xm>();
            yb_in_dz.INPUT = new List<Reconciliation_In_xm>();
            List<Reconciliation_Out_xm> yb_out_dz = new List<Reconciliation_Out_xm>(); ;
            yb_in_dz.MSGNO = "1121";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Reconciliation_In_xm dom = new Reconciliation_In_xm();
                dom.MSGID = dt.Rows[i]["MSGID"].ToString();
                dom.REFMSGID = dt.Rows[i]["REFMSGID"].ToString();
                dom.AKC264 = dt.Rows[i]["AKC264"].ToString();
                dom.AKC255 = dt.Rows[i]["AKC255"].ToString();
                dom.AKC260 = dt.Rows[i]["AKC260"].ToString();
                dom.AKC261 = dt.Rows[i]["AKC261"].ToString();
                dom.AKC706 = dt.Rows[i]["AKC706"].ToString();
                dom.AKC707 = dt.Rows[i]["AKC707"].ToString();
                dom.AKC708 = dt.Rows[i]["AKC708"].ToString();
                yb_in_dz.INPUT.Add(dom);

                if (yb_in_dz.INPUT.Count == 100)
                {
                    int ret = sjzybInterface.ylxxdz_mx(yb_in_dz, ref yb_out_dz);
                    if (ret == -1)
                        writeLogs.writeLogs("定时任务：医保对账（明细）", DateTime.Now, "定时任务：医保对账（明细）        " + yb_out_dz[0].ERRORMSG);

                    yb_in_dz.INPUT.Clear();
                }
            }
            int rets = sjzybInterface.ylxxdz_mx(yb_in_dz, ref yb_out_dz);
            if (rets == -1)
                writeLogs.writeLogs("定时任务：医保对账（明细）", DateTime.Now, "定时任务：医保对账（明细）        " + yb_out_dz[0].ERRORMSG);
            writeLogs.writeLogs("定时任务：医保对账（明细）", DateTime.Now, "定时任务：医保对账（明细）        已完成，共计：" + dt.Rows.Count);

        }
        /// <summary>
        /// 【1632】三目下载
        /// </summary>
        /// <param name="typearr">收费项目类别</param>
        public void DownloadDirectory(object[] typearr)
        {
            ProgramGlobal.ybDownload = true;
            foreach (string type in typearr)
            {
                string time = "";//开始时间
                string page = "";//开始页数
                if (type == "1")
                {
                    time = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_yp");
                    page = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_yp_page");
                }
                else if (type == "2")
                {
                    time = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_zl");
                    page = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_zl_page");
                }
                else if (type == "3")
                {
                    time = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_fw");
                    page = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Directory_fw_page");
                }
                //下载当前定点中心的所有三目下载
                SJZYB_IN<Directory_In> yb_in_dis = new SJZYB_IN<Directory_In>();
                yb_in_dis.INPUT = new List<Directory_In>();
                Directory_Out_fw yb_out_dir_fw = new Directory_Out_fw();
                Directory_Out_zl yb_out_dir_zl = new Directory_Out_zl();
                Directory_Out_yp yb_out_dir_yp = new Directory_Out_yp();
                Directory_In dom = new Directory_In();
                Yb_Itme docitme = new Yb_Itme();
                yb_in_dis.MSGNO = "1632";
                dom.AKC224 = type;
                dom.AAE030 = time;
                string updatetime = "";// DateTime.Now.ToString("yyyy-MM-dd");
                dom.AAE031 = updatetime;
                dom.CURRENTPAGE = page == "" ? "1" : page;
                yb_in_dis.INPUT.Add(dom);

                writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        开始");
                int opstat = sjzybInterface.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);

                if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
                {
                    writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        失败，ERRORMSG{" + yb_out_dir_yp.ERRORMSG + "}");
                    continue;
                }
                string ReturnMsg = "";

                if (yb_out_dir_yp.OUTROW != null)
                {
                    #region 药品
                    if (int.Parse(yb_out_dir_yp.TOTALPAGE) > 2)
                    {
                        #region 多页
                        for (int i = int.Parse(page) + 1; i <= int.Parse(yb_out_dir_yp.TOTALPAGE); i++)
                        //for (int i = 100; i <= 120; i++)
                        {
                            yb_in_dis.INPUT = new List<Directory_In>();
                            dom = new Directory_In();
                            dom.CURRENTPAGE = i.ToString();
                            dom.AKC224 = type;
                            dom.AAE030 = time;
                            dom.AAE031 = updatetime;
                            yb_in_dis.INPUT.Add(dom);
                            opstat = sjzybInterface.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);
                            int returnnum = Convert.ToInt32(yb_out_dir_yp.RETURNNUM);
                            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                            {
                                ReturnMsg = yb_out_dir_yp.ERRORMSG;
                                writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        失败，ERRORMSG{" + ReturnMsg + "}");
                                continue;
                            }

                            string sql = "";
                            for (int j = 0; j < yb_out_dir_yp.OUTROW.Count; j++)
                            {

                                sql += docitme.addyb_insuritem_yp(yb_out_dir_yp.OUTROW[j]);

                                if (j % 50 == 0 && j > 0)
                                {
                                    if (docitme.doExeSql(sql) == -1)
                                    {
                                        writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加药品失败,sql出错");
                                        continue;
                                    }
                                    sql = "";
                                }
                            }
                            if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                            {
                                writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加药品失败,sql出错");
                                continue;
                            }
                            yb_out_dir_yp.OUTROW.Clear();
                            //IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_yp_page", (i + 1).ToString());
                        }
                        #endregion
                    }
                    else
                    {
                        #region 单页
                        string sql = "";
                        for (int j = 0; j < yb_out_dir_yp.OUTROW.Count; j++)
                        {

                            sql += docitme.addyb_insuritem_yp(yb_out_dir_yp.OUTROW[j]);

                            if (j % 50 == 0 && j > 0)
                            {
                                if (docitme.doExeSql(sql) == -1)
                                {
                                    writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加药品失败,sql出错");
                                    continue;
                                }
                                sql = "";
                            }
                        }
                        if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                        {
                            writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加药品失败,sql出错");
                            continue;
                        }
                        yb_out_dir_yp.OUTROW.Clear();
                        #endregion
                    }
                    IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_yp", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                    writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加药品成功");
                    #endregion
                }
                if (yb_out_dir_zl.OUTROW != null)
                {
                    #region 治疗
                    if (int.Parse(yb_out_dir_zl.TOTALPAGE) > 2)
                    {
                        #region 页数在2页上的
                        for (int i = int.Parse(page) + 1; i <= int.Parse(yb_out_dir_zl.TOTALPAGE); i++)
                        //for (int i = 2; i <= 20; i++)
                        {
                            yb_in_dis.INPUT = new List<Directory_In>();
                            dom = new Directory_In();
                            dom.CURRENTPAGE = i.ToString();
                            dom.AKC224 = type;
                            dom.AAE030 = time;
                            dom.AAE031 = updatetime;
                            yb_in_dis.INPUT.Add(dom);
                            opstat = sjzybInterface.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);
                            int returnnum = Convert.ToInt32(yb_out_dir_zl.RETURNNUM);
                            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                            {
                                ReturnMsg = yb_out_dir_zl.ERRORMSG;
                                writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        失败，ERRORMSG{" + ReturnMsg + "}");
                                continue;
                            }
                            string sql = "";
                            for (int j = 0; j < yb_out_dir_zl.OUTROW.Count; j++)
                            {

                                sql += docitme.addyb_insuritem_zl(yb_out_dir_zl.OUTROW[j]);

                                if (j % 50 == 0 && j + 1 > 0)
                                {
                                    if (docitme.doExeSql(sql) == -1)
                                    {
                                        writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加治疗失败");
                                        continue;
                                    }
                                    sql = "";
                                }
                            }
                            if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                            {
                                writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加治疗失败");
                                continue;
                            }
                            yb_out_dir_zl.OUTROW.Clear();
                            //IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_zl_page", (i + 1).ToString());
                        }
                        #endregion
                    }
                    else
                    {
                        #region 单页
                        string sql = "";
                        for (int j = 0; j < yb_out_dir_zl.OUTROW.Count; j++)
                        {

                            sql += docitme.addyb_insuritem_zl(yb_out_dir_zl.OUTROW[j]);

                            if (j % 50 == 0 && j + 1 > 0)
                            {
                                if (docitme.doExeSql(sql) == -1)
                                {
                                    writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加治疗失败,sql出错");
                                    continue;
                                }
                                sql = "";
                            }
                        }
                        if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                        {
                            writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加治疗失败,sql出错");
                            continue;
                        }
                        yb_out_dir_zl.OUTROW.Clear();
                        #endregion
                    }

                    IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_zl", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                    writeLogs.writeLogs("定时任务：三目下载", DateTime.Now, "定时任务：三目下载        添加治疗成功");
                    #endregion
                }
            }
            ProgramGlobal.ybDownload = false;
        }
    }
}
