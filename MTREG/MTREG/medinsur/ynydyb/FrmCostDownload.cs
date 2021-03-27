using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.tools;
using MTHIS.main.bll;

namespace MTREG.medinsur.ynydyb
{
    public partial class FrmCostDownload : Form
    {
        public FrmCostDownload()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            YdZzplsjxz_in ydZzplsjxz_in = new YdZzplsjxz_in();
            YdZzplsjxz_out ydZzplsjxz_out1 = new YdZzplsjxz_out();
            ydZzplsjxz_in.Czybh = ProgramGlobal.User_id;
            ydZzplsjxz_in.Ywzqh = ynydybGlobal.Ywzqh;

            YNYDYB ynydyb = new YNYDYB();
            int opt_ydmxzplsjxz = ynydyb.ydzzplsjxz(ydZzplsjxz_in, ydZzplsjxz_out1);
            if (opt_ydmxzplsjxz != 0)
            {
                MessageBox.Show(ydZzplsjxz_out1.ErrorMessage + ", 总账批量数据下载失败！", "提示信息");
                return;
            }

            lblFilePath.Text = ydZzplsjxz_out1.Xzdz;
            MessageBox.Show("下载成功！");
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            YdZzplsjxz_in ydZzplsjxz_in = new YdZzplsjxz_in();
            YdZzplsjxz_out ydZzplsjxz_out1 = new YdZzplsjxz_out();
            ydZzplsjxz_in.Czybh = ProgramGlobal.User_id;
            ydZzplsjxz_in.Ywzqh = ynydybGlobal.Ywzqh;

            YNYDYB ynydyb = new YNYDYB();
            int opt_ydmxzplsjxz = ynydyb.ydzzplsjxz(ydZzplsjxz_in, ydZzplsjxz_out1);
            if (opt_ydmxzplsjxz != 0)
            {
                MessageBox.Show(ydZzplsjxz_out1.ErrorMessage + ", 总账批量数据下载失败！", "提示信息");
                return;
            }

            lblFilePath.Text = ydZzplsjxz_out1.Xzdz;
            Get_file(lblFilePath.Text.Trim());
        }
        public void Get_file(String file_path)
        {
            dgvCost.Rows.Clear();
            String[] ret_val = null;
            FileStream fs = null;
            try
            {
                ret_val = new String[File.ReadAllLines(file_path).Length];
                fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                StreamReader m_streamReader = new StreamReader(fs, Encoding.Default);
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                string strLine = m_streamReader.ReadLine();//每一行接收的字符串
                int a = 0;
                while (strLine != null)
                {
                    a++;
                    if (strLine.Trim().Equals(""))
                    {
                        strLine = m_streamReader.ReadLine();
                        continue;
                    }
                    strLine = "\t\t\t" + strLine;
                    string[] str_line = strLine.Split('\t');
                    dgvCost.Rows.Add(str_line);

                    strLine = m_streamReader.ReadLine();
                    if (a == 4000)
                    {
                        a = 0;
                    }
                }
                int rowCount = dgvCost.Rows.Count;

                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        string zyh=dgvCost.Rows[i].Cells["yyzyh"].ToString();
                        string sql1 = "select ihsp_account.feeamt"
                                     + ",ihsp_account.insurefee"
                                     + ",ihsp_account.insuraccountfee"
                                     + " from ihsp_account "
                                     + " left join inhospital on ihsp_account.ihsp_id=inhospital.id"
                                     + " where inhospital.hspcode=" + DataTool.addFieldBraces(zyh);
                        DataTable ihspDt = BllMain.Db.Select(sql1).Tables[0];
                        if (ihspDt.Rows.Count == 0)
                        {
                            string sql2 = "select fee"
                                        + ",insurefee"
                                        + ",insuraccountfee"
                                        + " from clinic_invoice "
                                        + " left join register on ihsp_account.regist_id=register.id"
                                        + " where register.billcode=" + DataTool.addFieldBraces(zyh);
                            DataTable clinicDt = BllMain.Db.Select(sql2).Tables[0];
                            if (clinicDt.Rows.Count == 0)
                            {
                                dgvCost.Rows[i].Cells["sfdz"].Value = "本地无";
                                dgvCost.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else
                            {
                                double cz1 = double.Parse(clinicDt.Rows[0]["fee"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["ylfyze"].Value.ToString());
                                double cz2 = double.Parse(clinicDt.Rows[0]["insurefee"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["ybzfje"].Value.ToString());
                                double cz3 = double.Parse(clinicDt.Rows[0]["insuraccountfee"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["zhzfje"].Value.ToString());
                                if ((cz1 > 0.01 || cz1 < -0.01) || (cz2 > 0.01 || cz2 < -0.01) || (cz3 > 0.01 || cz3 < -0.01))
                                {
                                    dgvCost.Rows[i].Cells["sfdz"].Value = "错";
                                    dgvCost.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                                }
                                else
                                {
                                    dgvCost.Rows[i].Cells["sfdz"].Value = "对";
                                }
                            }
                        }
                        else
                        {
                            double cz1 = double.Parse(ihspDt.Rows[0]["feeamt"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["ylfyze"].Value.ToString());
                            double cz2 = double.Parse(ihspDt.Rows[0]["insurefee"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["ybzfje"].Value.ToString());
                            double cz3 = double.Parse(ihspDt.Rows[0]["insuraccountfee"].ToString()) - double.Parse(dgvCost.Rows[i].Cells["zhzfje"].Value.ToString());
                            if ((cz1 > 0.01 || cz1 < -0.01) || (cz2 > 0.01 || cz2 < -0.01) || (cz3 > 0.01 || cz3 < -0.01))
                            {
                                dgvCost.Rows[i].Cells["sfdz"].Value = "错";
                                dgvCost.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                            }
                            else
                            {
                                dgvCost.Rows[i].Cells["sfdz"].Value = "对";
                            }
                        }
                    }
                }

                m_streamReader.Close();
            }
            catch (FileNotFoundException e)
            {
                string info="下载基础数据读取文本错误"+e.Message.ToString();
                LogUtils.writeErrLog( info);
            }
            return;
        }

        /// <summary>
        /// 冲正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRet_Click(object sender, EventArgs e)
        {
            if (dgvCost.Rows.Count == 0)
                return;

            int rowIdx = dgvCost.CurrentRow.Index;

            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者!");
                return;
            }
            if (dgvCost.Rows[rowIdx].Cells["sfdz"].Value.ToString() != "本地无")
            {
                MessageBox.Show("请选择【本地无】患者，即单元格为【红色】的患者！");
                return;
            }

            YNYDYB ynydyb_ydczjy = new YNYDYB();
            Hqfsflsh_out hqfsflsh_out_ydczjy = new Hqfsflsh_out();
            int opt_hqjslsh_wfty = ynydyb_ydczjy.hqfsflsh(hqfsflsh_out_ydczjy);
            if (opt_hqjslsh_wfty != 0)
            {
                MessageBox.Show(hqfsflsh_out_ydczjy.ErrorMessage + ", 异地医保--获取【结算冲正】发送方交易流水号失败！", "错误信息");
                return;
            }
            BllYnydybMethod bllYnydybMethod=new BllYnydybMethod();
            YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
            YdCzjy_out ydCzjy_out1 = new YdCzjy_out();
            string id="";
            DataTable infoDt = new DataTable();
            string ihspSql = "select id from inhospital where ihspcode=" + DataTool.addFieldBraces(dgvCost.Rows[rowIdx].Cells["yyzyh"].Value.ToString());
            DataTable ihspDt = BllMain.Db.Select(ihspSql).Tables[0];
            if (ihspDt.Rows.Count == 0)
            {
                string clinicSql = "select id from clinic_invoice where billcode=" + DataTool.addFieldBraces(dgvCost.Rows[rowIdx].Cells["yyzyh"].Value.ToString());
                DataTable clinicDt = BllMain.Db.Select(clinicSql).Tables[0];
                id = clinicDt.Rows[0]["id"].ToString();
            }
            else
            {
                id=ihspDt.Rows[0]["id"].ToString();
                infoDt = bllYnydybMethod.readIhspRegInfo(id);
            }
            ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydczjy.Swqjwyzym;
            ydCzjy_in1.Hzcbdtcqbh = infoDt.Rows[0]["InsuredAreaNo"].ToString();
            ydCzjy_in1.Hzgrbh = infoDt.Rows[0]["PersonNo"].ToString();
            ydCzjy_in1.Hzybkh = infoDt.Rows[0]["SICardNo"].ToString();
            ydCzjy_in1.Czybh = ProgramGlobal.User_id;
            ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
            ydCzjy_in1.Yfsfjylsh = dgvCost.Rows[rowIdx].Cells["fsflsh"].Value.ToString();
            ydCzjy_in1.Yjym = "14";
            StringBuilder jsfjylsh_ydczjy = new StringBuilder(2048);
            int opstat = ynydyb_ydczjy.ydczjy(jsfjylsh_ydczjy, ydCzjy_in1, ydCzjy_out1);
            if (opstat != 0)
            {
                MessageBox.Show("异地医保--【结算冲正】失败:" + ydCzjy_out1.ErrorMessage, "错误信息");
                return;
            }
            MessageBox.Show("异地医保--【结算冲正】成功！");
        }

        /// <summary>
        /// 重发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRe_Click(object sender, EventArgs e)
        {

        }
    }
}
