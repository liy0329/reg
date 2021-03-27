using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb.bean;
using MTHIS.tools;
using MTREG.common.bll;


namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmDownloadDirectory : Form
    {
        Sjzsyb syb = new Sjzsyb();
        BllItemcrossSJZ bllItemcrossSJZ = new bll.BllItemcrossSJZ();
        public FrmDownloadDirectory()
        {
            InitializeComponent();
        }

        private void FrmDownloadDirectory_Load(object sender, EventArgs e)
        {
            getcategory();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProgramGlobal.ybDownload)
            {
                MessageBox.Show("正在自动更新医保三目，无法手动更新");
                return;
            }
            string type = this.cBox_category.SelectedValue.ToString().Trim();
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
            SjzybInterface yb_xz = new SjzybInterface();
            Yb_Itme docitme = new Yb_Itme();
            yb_in_dis.MSGNO = "1632";
            dom.AKC224 = type;
            dom.AAE030 = time;
            string updatetime = "";// DateTime.Now.ToString("yyyy-MM-dd");
            dom.AAE031 = updatetime;
            dom.CURRENTPAGE = page == "" ? "1" : page;
            yb_in_dis.INPUT.Add(dom);


            int opstat = yb_xz.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);

            if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
            {
                MessageBox.Show(yb_out_dir_yp.ERRORMSG, "提示信息");
                return;
            }
            this.label9.Visible = true;
            this.label9.Text = "合计：" + yb_out_dir_yp.TOTALPAGE + "页,正在下载 ：1页";
            this.label9.Update();
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
                        this.label9.Visible = true;
                        this.label9.Text = "合计：" + yb_out_dir_yp.TOTALPAGE + "页,正在下载 ：" + i + "页";
                        this.label9.Update();
                        yb_in_dis.INPUT = new List<Directory_In>();
                        dom = new Directory_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = type;
                        dom.AAE030 = time;
                        dom.AAE031 = updatetime;
                        yb_in_dis.INPUT.Add(dom);
                        opstat = yb_xz.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);
                        int returnnum = Convert.ToInt32(yb_out_dir_yp.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_dir_yp.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }

                        string sql = "";
                        for (int j = 0; j < yb_out_dir_yp.OUTROW.Count; j++)
                        {

                            sql += docitme.addyb_insuritem_yp(yb_out_dir_yp.OUTROW[j]);

                            if (j % 50 == 0 && j > 0)
                            {
                                if (docitme.doExeSql(sql) == -1)
                                {
                                    MessageBox.Show("添加药品失败！");
                                    return;
                                }
                                sql = "";
                            }
                        }
                        if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                        {
                            MessageBox.Show("添加药品失败！");
                            return;
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
                                MessageBox.Show("添加药品失败！");
                                return;
                            }
                            sql = "";
                        }
                    }
                    if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                    {
                        MessageBox.Show("添加药品失败！");
                        return;
                    }
                    yb_out_dir_yp.OUTROW.Clear();
                    #endregion
                }

                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_yp", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                MessageBox.Show("添加药品成功！");
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
                        this.label9.Visible = true;
                        this.label9.Text = "合计：" + yb_out_dir_zl.TOTALPAGE + "页,正在下载 ：" + i + "页";
                        this.label9.Update();
                        yb_in_dis.INPUT = new List<Directory_In>();
                        dom = new Directory_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = type;
                        dom.AAE030 = time;
                        dom.AAE031 = updatetime;
                        yb_in_dis.INPUT.Add(dom);
                        opstat = yb_xz.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);
                        int returnnum = Convert.ToInt32(yb_out_dir_zl.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_dir_zl.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                        string sql = "";
                        for (int j = 0; j < yb_out_dir_zl.OUTROW.Count; j++)
                        {

                            sql += docitme.addyb_insuritem_zl(yb_out_dir_zl.OUTROW[j]);

                            if (j % 50 == 0 && j + 1 > 0)
                            {
                                if (docitme.doExeSql(sql) == -1)
                                {
                                    MessageBox.Show("添加诊疗失败！");
                                    return;
                                }
                                sql = "";
                            }
                        }
                        if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                        {
                            MessageBox.Show("添加治疗失败！");
                            return;
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
                                MessageBox.Show("添加诊疗失败！");
                                return;
                            }
                            sql = "";
                        }
                    }
                    if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                    {
                        MessageBox.Show("添加治疗失败！");
                        return;
                    }
                    yb_out_dir_zl.OUTROW.Clear();
                    #endregion
                }

                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_zl", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                MessageBox.Show("添加诊疗成功！");
                #endregion
            }
            if (yb_out_dir_fw.OUTROW != null)
            {
                #region 服务
                if (int.Parse(yb_out_dir_fw.TOTALPAGE) > 2)
                {
                    #region 多页
                    for (int i = int.Parse(page) + 1; i <= int.Parse(yb_out_dir_fw.TOTALPAGE); i++)
                    //for (int i = 2; i <= 3; i++)
                    {
                        this.label9.Visible = true;
                        this.label9.Text = "合计：" + yb_out_dir_fw.TOTALPAGE + "页,正在下载 ：" + i + "页";
                        this.label9.Update();
                        yb_in_dis.INPUT = new List<Directory_In>();
                        dom = new Directory_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = type;
                        dom.AAE030 = time;
                        dom.AAE031 = updatetime;
                        yb_in_dis.INPUT.Add(dom);
                        opstat = yb_xz.DownloadDirectory(yb_in_dis, ref yb_out_dir_yp, ref yb_out_dir_zl, ref yb_out_dir_fw);
                        int returnnum = Convert.ToInt32(yb_out_dir_fw.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_dir_fw.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }

                        string sql = "";
                        for (int j = 0; j < yb_out_dir_fw.OUTROW.Count; j++)
                        {

                            sql += docitme.addyb_insuritem_fw(yb_out_dir_fw.OUTROW[j]);

                            if (j % 50 == 0 && j + 1 > 0)
                            {
                                if (docitme.doExeSql(sql) == -1)
                                {
                                    MessageBox.Show("添加服务失败！");
                                    return;
                                }
                                sql = "";
                            }
                        }
                        if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                        {
                            MessageBox.Show("添加服务失败！");
                            return;
                        }
                        yb_out_dir_fw.OUTROW.Clear();
                    }
                    #endregion
                }
                else
                {
                    #region 单页
                    string sql = "";
                    for (int j = 0; j < yb_out_dir_fw.OUTROW.Count; j++)
                    {
                        sql += docitme.addyb_insuritem_fw(yb_out_dir_fw.OUTROW[j]);

                        if (j % 50 == 0 && j + 1 > 0)
                        {
                            if (docitme.doExeSql(sql) == -1)
                            {
                                MessageBox.Show("添加服务失败！");
                                return;
                            }
                            sql = "";
                        }
                    }
                    if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
                    {
                        MessageBox.Show("添加服务失败！");
                        return;
                    }
                    yb_out_dir_fw.OUTROW.Clear();
                    #endregion
                }

                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Directory_fw", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                MessageBox.Show("添加服务成功！");
                #endregion
            }
            if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
            {
                if (yb_out_dir_fw.ERRORMSG != "")
                    ReturnMsg = yb_out_dir_fw.ERRORMSG;
                if (yb_out_dir_yp.ERRORMSG != "")
                    ReturnMsg = yb_out_dir_yp.ERRORMSG;
                if (yb_out_dir_zl.ERRORMSG != "")
                    ReturnMsg = yb_out_dir_zl.ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }


        }
        public void getcategory()
        {
            List<ListItem> item = new List<ListItem>();
            item.Add(new ListItem("1", "药品"));
            item.Add(new ListItem("2", "诊疗项目"));
            item.Add(new ListItem("3", "服务设施"));
            this.cBox_category.DisplayMember = "Value";
            this.cBox_category.ValueMember = "Test";
            this.cBox_category.SelectedValue = "1";
            this.cBox_category.DataSource = item;

        }


    }
}
