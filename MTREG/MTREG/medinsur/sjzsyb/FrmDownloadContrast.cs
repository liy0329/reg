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
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.common.bll;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmDownloadContrast : Form
    {
        Sjzsyb syb = new Sjzsyb();
        BllItemcrossSJZ bllItemcross = new BllItemcrossSJZ();
        public FrmDownloadContrast()
        {
            InitializeComponent();
        }

        private void FrmDownloadContrast_Load(object sender, EventArgs e)
        {
            this.textBox_page.Text = "1";
            geet();
            try
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnModify";
                btn.HeaderText = "删除";
                btn.DefaultCellStyle.NullValue = "删除";
                dataGridView1.Columns.Add(btn);
                dataGridView1.Columns["btnModify"].HeaderText = "删除";
                dataGridView1.Columns["btnModify"].Width = 50;
                dataGridView1.Columns["btnModify"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            string itemfrom = "";

            if (radioButton_yp.Checked == true)
            {
                itemfrom = "1";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "2";
            }
            else if (radioButton_fw.Checked == true)
            {
                itemfrom = "3";
            }
            DateTime Startime = Starttime.Value; //开始时间
            DateTime endtime = Endtime.Value;//结束时间
            string page = this.textBox_page.Text.ToString().Trim();
            if (String.IsNullOrEmpty(page))
                page = "1";
            SJZYB_IN<DownloadContrast_In> yb_in_DLC = new SJZYB_IN<DownloadContrast_In>();
            yb_in_DLC.INPUT = new List<DownloadContrast_In>();
            DownloadContrast_In dom = new DownloadContrast_In();
            dom.AKC224 = itemfrom;
            dom.AAE030 = Startime.ToString("yyyy-MM-dd");
            dom.AAE031 = endtime.ToString("yyyy-MM-dd");
            dom.CURRENTPAGE = page;
            yb_in_DLC.INPUT.Add(dom);
            yb_in_DLC.MSGNO = "1634";
            SjzybInterface sjzybInterface = new SjzybInterface();
            DownloadContrast_Out_yp yb_out_DLC_yp = new DownloadContrast_Out_yp();
            DownloadContrast_Out_zl yb_out_DLC_zl = new DownloadContrast_Out_zl();
            DownloadContrast_Out_fw yb_out_DLC_fw = new DownloadContrast_Out_fw();
            Yb_Itme docitme = new Yb_Itme();
            DataTable dt = new DataTable();

            int ret = sjzybInterface.Downdeclare_yp(yb_in_DLC, ref yb_out_DLC_yp, ref yb_out_DLC_zl, ref yb_out_DLC_fw);
            if (ret == -1)//错误，业务出参中的errorMSG为错误信息
            {
                MessageBox.Show("下载三目失败", "提示信息");
                return;
            }
            string ReturnMsg = "";
            if (yb_out_DLC_yp.OUTROW != null)
            {
                #region 药品
                if (int.Parse(yb_out_DLC_yp.TOTALPAGE) > 2)
                {
                    for (int i = 2; i <= int.Parse(yb_out_DLC_yp.TOTALPAGE); i++)
                    //for (int i = 100; i <= 120; i++)
                    {
                        yb_in_DLC.INPUT = new List<DownloadContrast_In>();
                        dom = new DownloadContrast_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = itemfrom;
                        dom.AAE030 = Startime.ToString("yyyy-MM-dd");
                        dom.AAE031 = endtime.ToString("yyyy-MM-dd");
                        yb_in_DLC.INPUT.Add(dom);
                        ret = sjzybInterface.Downdeclare_yp(yb_in_DLC, ref yb_out_DLC_yp, ref yb_out_DLC_zl, ref yb_out_DLC_fw);
                        int returnnum = Convert.ToInt32(yb_out_DLC_yp.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_DLC_yp.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                    }
                }
                string sql = "";
                for (int i = 0; i < yb_out_DLC_yp.OUTROW.Count; i++)
                {
                    string ybcode = yb_out_DLC_yp.OUTROW[i].AKA060.ToString();
                    string hiscode = yb_out_DLC_yp.OUTROW[i].AKC515.ToString();
                    string isstop = yb_out_DLC_yp.OUTROW[i].AAE016.ToString();
                    string iscurr = yb_out_DLC_yp.OUTROW[i].AAE100.ToString();
                    string memo = yb_out_DLC_yp.OUTROW[i].BAE001.ToString();
                    string starttime1 = yb_out_DLC_yp.OUTROW[i].AAE030.ToString();
                    string endtime1 = yb_out_DLC_yp.OUTROW[i].AAE031.ToString();
                    string audittime = yb_out_DLC_yp.OUTROW[i].AAE015.ToString();
                    if (isstop == "0")
                        isstop = "Y";
                    if (isstop == "1")
                        isstop = "T";
                    if (isstop == "2")
                        isstop = "NG";
                    sql += docitme.insetInsurcross(ybcode, hiscode, isstop, iscurr, memo, starttime1, endtime1, audittime);

                    if (i % 100 == 0 && i > 0)
                    {
                        if (docitme.doExeSql(sql) == -1)
                        {
                            SysWriteLogs sysWriteLog = new SysWriteLogs();
                            string outLog = (i / 500 - 1).ToString() + "\r\n" + sql;
                            sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);
                            MessageBox.Show("更新药品失败！");
                            return;
                        }
                        sql = "";
                    }
                }
                if (docitme.doExeSql(sql) == -1)
                {
                    MessageBox.Show("更新药品失败！");
                    return;
                }
                MessageBox.Show("更新药品成功！");
                dt = yb_out_DLC_yp.OUTROW.ToDataTable<DownloadContrast_Out_yp_OUTROW>();
                dataGridView("1", dt);
                #endregion
            }
            if (yb_out_DLC_zl.OUTROW != null)
            {
                #region
                if (int.Parse(yb_out_DLC_zl.TOTALPAGE) > 2)
                {
                    for (int i = 2; i <= int.Parse(yb_out_DLC_zl.TOTALPAGE); i++)
                    //for (int i = 2; i <= 20; i++)
                    {
                        yb_in_DLC.INPUT = new List<DownloadContrast_In>();
                        dom = new DownloadContrast_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = itemfrom;
                        dom.AAE030 = Startime.ToString("yyyy-MM-dd");
                        dom.AAE031 = endtime.ToString("yyyy-MM-dd");
                        yb_in_DLC.INPUT.Add(dom);
                        ret = sjzybInterface.Downdeclare_yp(yb_in_DLC, ref yb_out_DLC_yp, ref yb_out_DLC_zl, ref yb_out_DLC_fw);
                        int returnnum = Convert.ToInt32(yb_out_DLC_yp.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_DLC_zl.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                    }
                }
                string sql = "";
                for (int i = 0; i < yb_out_DLC_zl.OUTROW.Count; i++)
                {
                    string ybcode = yb_out_DLC_zl.OUTROW[i].AKA090.ToString();
                    string hiscode = yb_out_DLC_zl.OUTROW[i].AKC515.ToString();
                    string isstop = yb_out_DLC_zl.OUTROW[i].AAE016.ToString();
                    string iscurr = yb_out_DLC_zl.OUTROW[i].AAE100.ToString();
                    string memo = yb_out_DLC_zl.OUTROW[i].BAE001.ToString();
                    string starttime1 = yb_out_DLC_zl.OUTROW[i].AAE030.ToString();
                    string endtime1 = yb_out_DLC_zl.OUTROW[i].AAE031.ToString();
                    string audittime = yb_out_DLC_zl.OUTROW[i].AAE015.ToString();
                    if (isstop == "0")
                        isstop = "Y";
                    if (isstop == "1")
                        isstop = "T";
                    if (isstop == "2")
                        isstop = "NG";
                    sql += docitme.insetInsurcross(ybcode, hiscode, isstop, iscurr, memo, starttime1, endtime1,audittime);

                    if (i % 100 == 0 && i > 0)
                    {
                        if (docitme.doExeSql(sql) == -1)
                        {
                            SysWriteLogs sysWriteLog = new SysWriteLogs();
                            string outLog = (i / 500 - 1).ToString() + "\r\n" + sql;
                            sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);
                            MessageBox.Show("更新诊疗失败！");
                            return;
                        }
                        sql = "";
                    }
                }
                if (docitme.doExeSql(sql) == -1)
                {
                    MessageBox.Show("更新诊疗失败！");
                    return;
                }
                MessageBox.Show("更新诊疗成功！");
                dt = yb_out_DLC_zl.OUTROW.ToDataTable<DownloadContrast_Out_zl_OUTROW>();
                dataGridView("2", dt);
                #endregion
            }
            if (yb_out_DLC_fw.OUTROW != null)
            {
                #region 服务
                if (int.Parse(yb_out_DLC_fw.TOTALPAGE) > 2)
                {
                    for (int i = 2; i <= int.Parse(yb_out_DLC_fw.TOTALPAGE); i++)
                    //for (int i = 2; i <= 3; i++)
                    {
                        yb_in_DLC.INPUT = new List<DownloadContrast_In>();
                        dom = new DownloadContrast_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.AKC224 = itemfrom;
                        dom.AAE030 = Startime.ToString("yyyy-MM-dd");
                        dom.AAE031 = endtime.ToString("yyyy-MM-dd");
                        yb_in_DLC.INPUT.Add(dom);
                        ret = sjzybInterface.Downdeclare_yp(yb_in_DLC, ref yb_out_DLC_yp, ref yb_out_DLC_zl, ref yb_out_DLC_fw);
                        int returnnum = Convert.ToInt32(yb_out_DLC_yp.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_DLC_fw.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                    }
                }
                string sql = "";
                for (int i = 0; i < yb_out_DLC_fw.OUTROW.Count; i++)
                {
                    string ybcode = yb_out_DLC_fw.OUTROW[i].AKA100.ToString();
                    string hiscode = yb_out_DLC_fw.OUTROW[i].AKC515.ToString();
                    string isstop = yb_out_DLC_fw.OUTROW[i].AAE016.ToString();
                    string iscurr = yb_out_DLC_fw.OUTROW[i].AAE100.ToString();
                    string memo = yb_out_DLC_fw.OUTROW[i].BAE001.ToString();
                    string starttime1 = yb_out_DLC_fw.OUTROW[i].AAE030.ToString();
                    string endtime1 = yb_out_DLC_fw.OUTROW[i].AAE031.ToString();
                    string audittime = yb_out_DLC_fw.OUTROW[i].AAE015.ToString();
                    if (isstop == "0")
                        isstop = "Y";
                    if (isstop == "1")
                        isstop = "T";
                    if (isstop == "2")
                        isstop = "NG";
                    sql += docitme.insetInsurcross(ybcode, hiscode, isstop, iscurr, memo, starttime1, endtime1,audittime);
                    if (i % 100 == 0 && i > 0)
                    {
                        if (docitme.doExeSql(sql) == -1)
                        {
                            SysWriteLogs sysWriteLog = new SysWriteLogs();
                            string outLog = (i / 500 - 1).ToString() + "\r\n" + sql;
                            sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);
                            MessageBox.Show("添加服务失败！");
                            return;
                        }
                        sql = "";
                    }
                }
                if (docitme.doExeSql(sql) == -1)
                {
                    MessageBox.Show("添加服务失败！");
                    return;
                }
                MessageBox.Show("添加服务成功！");
                dt = yb_out_DLC_fw.OUTROW.ToDataTable<DownloadContrast_Out_fw_OUTROW>();
                dataGridView("3", dt);
                #endregion
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["AAE016"].Value.ToString() == "未审核")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未审核
                    //else if (dgvItemInfo.Rows[i].Cells["isstop"].Value.ToString() == "1")
                    //    dgvItemInfo.Rows[i].DefaultCellStyle.BackColor = Color.Brown;//
                    else if (dataGridView1.Rows[i].Cells["AAE016"].Value.ToString() == "审核未通过")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;//审核未通过

                }
            }
            
        }
        public void dataGridView(string type, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["AAE016"].ToString() == "0")
                {
                    dr["AAE016"] = "未审核";
                }
                else if (dr["AAE016"].ToString() == "1")
                {
                    dr["AAE016"] = "审核通过";
                }
                else if (dr["AAE016"].ToString() == "2")
                {
                    dr["AAE016"] = "审核未通过";
                }
                if (dr["AAE100"].ToString() == "0")
                {
                    dr["AAE100"] = "无效";
                }
                else if (dr["AAE100"].ToString() == "1")
                {
                    dr["AAE100"] = "有效";
                }

            }
            dataGridView1.DataSource = dt;

            if (type.Equals("1"))
            {
                dataGridView1.Columns["AKA060"].HeaderText = "医保编码";
                dataGridView1.Columns["AKA060"].DisplayIndex = 0;
                dataGridView1.Columns["AKA060"].Width = 200;
                dataGridView1.Columns["AKA061"].HeaderText = "医保名称";
                dataGridView1.Columns["AKA061"].Width = 150;
                dataGridView1.Columns["AKA061"].DisplayIndex = 1;
            }
            else if (type.Equals("2"))
            {
                dataGridView1.Columns["AKA090"].HeaderText = "医保编码";
                dataGridView1.Columns["AKA090"].DisplayIndex = 0;
                dataGridView1.Columns["AKA090"].Width = 200;
                dataGridView1.Columns["AKA091"].HeaderText = "医保名称";
                dataGridView1.Columns["AKA091"].Width = 150;
                dataGridView1.Columns["AKA091"].DisplayIndex = 1;
            }
            else if (type.Equals("3"))
            {
                dataGridView1.Columns["AKA100"].HeaderText = "医保编码";
                dataGridView1.Columns["AKA100"].DisplayIndex = 0;
                dataGridView1.Columns["AKA100"].Width = 200;
                dataGridView1.Columns["AKA102"].HeaderText = "医保名称";
                dataGridView1.Columns["AKA102"].Width = 150;
                dataGridView1.Columns["AKA102"].DisplayIndex = 1;
            }

            dataGridView1.Columns["AKC515"].HeaderText = "His编码";
            dataGridView1.Columns["AKC515"].DisplayIndex = 2;
            dataGridView1.Columns["AKC515"].Width = 200;
            dataGridView1.Columns["AKC516"].HeaderText = "His名称";
            dataGridView1.Columns["AKC516"].Width = 150;
            dataGridView1.Columns["AKC516"].DisplayIndex = 3;
            dataGridView1.Columns["AAE014"].HeaderText = "审核人";
            dataGridView1.Columns["AAE014"].Width = 100;
            dataGridView1.Columns["AAE014"].DisplayIndex = 4;
            dataGridView1.Columns["AAE015"].HeaderText = "审核时间";
            dataGridView1.Columns["AAE015"].Width = 100;
            dataGridView1.Columns["AAE015"].DisplayIndex = 5;
            dataGridView1.Columns["AAE016"].HeaderText = "审核标志";
            dataGridView1.Columns["AAE016"].Width = 100;
            dataGridView1.Columns["AAE016"].DisplayIndex = 6;
            dataGridView1.Columns["BAE001"].HeaderText = "审核说明";
            dataGridView1.Columns["BAE001"].Width = 100;
            dataGridView1.Columns["BAE001"].DisplayIndex = 7;
            dataGridView1.Columns["AAE030"].HeaderText = "开始时间";
            dataGridView1.Columns["AAE030"].Width = 100;
            dataGridView1.Columns["AAE030"].DisplayIndex = 8;
            dataGridView1.Columns["AAE031"].HeaderText = "结束时间";
            dataGridView1.Columns["AAE031"].Width = 100;
            dataGridView1.Columns["AAE031"].DisplayIndex = 9;
            dataGridView1.Columns["AAE100"].HeaderText = "是否有效";
            dataGridView1.Columns["AAE100"].Width = 100;
            dataGridView1.Columns["AAE100"].DisplayIndex = 10;
            try
            {
                dataGridView1.Columns["btnModify"].Visible = false;
            }
            catch { }

        }

        private void tb_ybpymgl_TextChanged(object sender, EventArgs e)
        {
            geet();
            
        }
        public void geet()
        {

            Yb_Itme yb_item = new Yb_Itme();
            string pincode = tb_ybpymgl.Text.ToString().Trim();
            string name = tb_ybxmmcgl.Text.ToString().Trim();
            string hiscode = tb_ybxmbmgl.Text.ToString().Trim();
            string itemfrom = "";
            if (radioButton_yp.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (radioButton_fw.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery_his(pincode, name, hiscode, itemfrom);
            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["AAE016"].Value.ToString() == "未审核")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未审核
                    //else if (dgvItemInfo.Rows[i].Cells["isstop"].Value.ToString() == "1")
                    //    dgvItemInfo.Rows[i].DefaultCellStyle.BackColor = Color.Brown;//
                    else if (dataGridView1.Rows[i].Cells["AAE016"].Value.ToString() == "审核未通过")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;//审核未通过
                    if (dataGridView1.Rows[i].Cells["ybty"].Value.ToString() == "Y")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSlateGray;//未审核

                }
                label7.Visible = true;
                label7.Text = "共有" + dataGridView1.Rows.Count + "条";
            }
            #region  dgv单元格标题设置
            //dataGridView1.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            //this.dataGridView1.RowsDefaultCellStyle.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            //this.dataGridView1.ColumnHeadersHeight = (int)(30 * ProgramGlobal.HeightScale);
            this.dataGridView1.Columns["insurcode"].HeaderText = "医保编号";
            this.dataGridView1.Columns["insurcode"].Width = (int)(140 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["insurcode"].DisplayIndex = 1;

            this.dataGridView1.Columns["insurname"].HeaderText = "医保名称";
            this.dataGridView1.Columns["insurname"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["insurname"].DisplayIndex = 2;

            this.dataGridView1.Columns["hiscode"].HeaderText = "院内编号";
            this.dataGridView1.Columns["hiscode"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["hiscode"].DisplayIndex = 3;

            this.dataGridView1.Columns["name"].HeaderText = "院内名称";
            this.dataGridView1.Columns["name"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["name"].DisplayIndex = 4;

            this.dataGridView1.Columns["insurclass"].HeaderText = "收费项目等级";
            this.dataGridView1.Columns["insurclass"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["insurclass"].DisplayIndex = 5;

            this.dataGridView1.Columns["AAE016"].HeaderText = "审核状态";
            this.dataGridView1.Columns["AAE016"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["AAE016"].DisplayIndex = 6;

            this.dataGridView1.Columns["memo"].HeaderText = "审核说明";
            this.dataGridView1.Columns["memo"].Width = (int)(180 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["memo"].DisplayIndex = 7;

            this.dataGridView1.Columns["audittime"].HeaderText = "审核时间";
            this.dataGridView1.Columns["audittime"].Width = (int)(180 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["audittime"].DisplayIndex = 8;

            this.dataGridView1.Columns["starttime"].HeaderText = "开始时间";
            this.dataGridView1.Columns["starttime"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["starttime"].DisplayIndex = 9;

            this.dataGridView1.Columns["endtime"].HeaderText = "结束时间";
            this.dataGridView1.Columns["endtime"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["endtime"].DisplayIndex = 10;

            this.dataGridView1.Columns["iscurr"].HeaderText = "有效标志";
            this.dataGridView1.Columns["iscurr"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["iscurr"].DisplayIndex = 11;

            this.dataGridView1.Columns["pincode"].HeaderText = "拼音简码";
            this.dataGridView1.Columns["pincode"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["pincode"].DisplayIndex = 12;

            this.dataGridView1.Columns["ybty"].HeaderText = "拼音简码";
            this.dataGridView1.Columns["ybty"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["ybty"].DisplayIndex = 12;

            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["ybty"].Visible = false;
            
            
            #endregion
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            FrmExcle frmExcle = new FrmExcle();
            frmExcle.Dg = dataGridView1;
            frmExcle.Show(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnModify")
                {
                    int Index = dataGridView1.CurrentRow.Index;
                    string itemname = dataGridView1.Rows[Index].Cells["name"].Value.ToString();
                    DialogResult DV_dzsj = MessageBox.Show("删除:" + "【" + itemname + "】", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DV_dzsj == DialogResult.Yes)
                    {
                            Yb_Itme yb = new Yb_Itme();

                            string insurcode = dataGridView1.Rows[Index].Cells["insurcode"].Value.ToString();
                            string hiscode = dataGridView1.Rows[Index].Cells["hiscode"].Value.ToString();
                            int flag = yb.Delete_insurcross(insurcode, hiscode);
                            if (flag == -1)
                            {
                                MessageBox.Show("三目对照关系删除失败！");

                            }
                            geet();
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        


    }
}
