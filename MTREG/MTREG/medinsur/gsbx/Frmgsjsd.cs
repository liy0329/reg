using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using zhongluyiyuan.global;
using System.Collections;
using zhongluyiyuan.Entity;
using zhongluyiyuan.Util;
using zhongluyiyuan.db;
namespace zhongluyiyuan.gsbx
{
    public partial class Frmgsjsd : Form
    {
        public Frmgsjsd()
        {
            InitializeComponent();
        }

        //预览方法
        public void PreView(DataTable dt1,DataTable dt2,string grbh)
        {
            CrystalReport1 ReportCydyfp = new CrystalReport1();
            ReportCydyfp.SetDataSource(GetData(dt1, dt2,grbh));
            this.crystalReportViewer1.ReportSource = ReportCydyfp;
            ///指定自定义纸张
            //System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            //doc.PrinterSettings.PrinterName = Tool.Dyjmc;
            //int rawKind = 1;
            //for (int i = 0; i < doc.PrinterSettings.PaperSizes.Count; i++)
            //{
            //    if (doc.PrinterSettings.PaperSizes[i].PaperName == "mtcyfp")
            //    {
            //        rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
            //        break;
            //    }

            //}

            //ReportCydyfp.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;   //指定纸张尺寸
            ////指定自定义纸张end

            //ReportCydyfp.PrintToPrinter(1, false, 1, 1);
            ////cRvzydy.ReportSource = Tool.CRpeportgh;

        }
        private List<Reportgsjsd> GetData(DataTable dt1, DataTable dt2,string grbh)
        {
            HISDB hisdb=new HISDB();
            List<Reportgsjsd> rcList = new List<Reportgsjsd>();
            int xh = 0;
            try
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    Reportgsjsd rcfpdy = new Reportgsjsd();
                    rcfpdy.Zyh = dt1.Rows[0]["akc190"].ToString().Trim();
                    rcfpdy.Yymc = dt1.Rows[0]["akb020name"].ToString().Trim();
                    rcfpdy.Hzxm = dt1.Rows[0]["aac003"].ToString().Trim();
                    rcfpdy.Sfzh = dt1.Rows[0]["aac002"].ToString().Trim();

                    string xb = dt1.Rows[0]["aac004"].ToString().Trim();
                    if (xb == "1") { xb = "男"; } else { xb = "女"; }
                    rcfpdy.Hzxb = xb;

                    rcfpdy.Gsbw = dt1.Rows[0]["alc022"].ToString().Trim();
                    rcfpdy.Cbd = dt1.Rows[0]["aab301name"].ToString().Trim();
                    rcfpdy.Shbzh = grbh;
                    rcfpdy.Gssj = dt1.Rows[0]["alc020"].ToString().Trim().Substring(0, 10);

                    string jylx = dt1.Rows[0]["aka130"].ToString().Trim();
                    if (jylx == "11") { jylx = "门诊"; } else { jylx = "住院"; }
                    rcfpdy.Jylx = jylx;

                    string zllb = dt1.Rows[0]["akc191"].ToString().Trim();
                    if (zllb == "7") { zllb = "治疗"; } else { zllb = "康复"; }
                    rcfpdy.Zllb = zllb;
                    rcfpdy.Jssj = dt1.Rows[0]["jsdate"].ToString().Trim().Substring(0, 10);
                    rcfpdy.Rysj = dt1.Rows[0]["akc192"].ToString().Trim();
                    string ryzd = dt1.Rows[0]["alc028"].ToString().Trim();

                    string sql_ryzd = "select jbmc as name from gsjblx where jbbm='" + ryzd + "'";
                    DataTable dt_ryzd = hisdb.Select(sql_ryzd).Tables[0];
                    rcfpdy.Ryzd = dt_ryzd.Rows[0]["name"].ToString().Trim(); 
                    rcfpdy.Cysj = dt1.Rows[0]["akc194"].ToString().Trim();

                    string cyzd = dt1.Rows[0]["alc028"].ToString().Trim();
                    string sql_cyzd = "select jbmc as name from gsjblx where jbbm='" + cyzd + "'";
                    DataTable dt_cyzd = hisdb.Select(sql_cyzd).Tables[0];
                    rcfpdy.Cyzd = dt_cyzd.Rows[0]["name"].ToString().Trim(); 
                    rcfpdy.Ylzf = dt1.Rows[0]["alc407sum"].ToString().Trim();
                    rcfpdy.Gszf = dt1.Rows[0]["jjin"].ToString().Trim();
                    rcfpdy.Zfje = dt1.Rows[0]["alc408sum"].ToString().Trim();
                    rcfpdy.Jbr = Tool.Yymc;
                    rcfpdy.Dysj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xh = xh + 1;
                    rcfpdy.Xh = xh.ToString();
                    rcfpdy.Xmmc = dt2.Rows[i]["alc403"].ToString().Trim();
                    rcfpdy.Sl = dt2.Rows[i]["alc406"].ToString().Trim();
                    rcfpdy.Dj = dt2.Rows[i]["alc405"].ToString().Trim();
                    rcfpdy.Je = dt2.Rows[i]["alc407"].ToString().Trim();
                    rcfpdy.Jzfje = dt2.Rows[i]["alc408"].ToString().Trim();
                    string zfyy = dt2.Rows[i]["marktype"].ToString().Trim();
                    if (zfyy == "1") { zfyy = "目录外"; } else if (zfyy == "2") { zfyy = "非工伤"; } else if (zfyy == "3") { zfyy = "其他"; } else if (zfyy == "4") { zfyy = "超剂量"; } else if (zfyy == "5") { zfyy = "超价格服务标准"; }
                    else if (zfyy == "6") { zfyy = "非适应部位"; } else if (zfyy == "7") { zfyy = "非适应症"; } else if (zfyy == "8") { zfyy = "材料不全"; } else if (zfyy == "9") { zfyy = "不可报销"; }
                    else if (zfyy == "10") { zfyy = "性别不匹配"; }
                    rcfpdy.Zfyy = zfyy;
                    rcList.Add(rcfpdy);
                }
            }
            catch {
                Reportgsjsd rcfpdy = new Reportgsjsd();
                rcfpdy.Zyh = dt1.Rows[0]["akc190"].ToString().Trim();
                rcfpdy.Yymc = dt1.Rows[0]["akb020name"].ToString().Trim();
                rcfpdy.Hzxm = dt1.Rows[0]["aac003"].ToString().Trim();
                rcfpdy.Sfzh = dt1.Rows[0]["aac002"].ToString().Trim();
                string xb = dt1.Rows[0]["aac004"].ToString().Trim();
                if (xb == "1") { xb = "男"; } else { xb = "女"; }
                rcfpdy.Hzxb = xb;

                rcfpdy.Gsbw = dt1.Rows[0]["alc022"].ToString().Trim();
                rcfpdy.Cbd = dt1.Rows[0]["aab301name"].ToString().Trim();
                rcfpdy.Shbzh = grbh;
                rcfpdy.Gssj = dt1.Rows[0]["alc020"].ToString().Trim().Substring(0, 10);

                string jylx = dt1.Rows[0]["aka130"].ToString().Trim();
                if (jylx == "11") { jylx = "门诊"; } else { jylx = "住院"; }
                rcfpdy.Jylx = jylx;

                string zllb = dt1.Rows[0]["akc191"].ToString().Trim();
                if (zllb == "7") { zllb = "治疗"; } else { zllb = "康复"; }
                rcfpdy.Zllb = zllb;
                rcfpdy.Jssj = dt1.Rows[0]["jsdate"].ToString().Trim().Substring(0, 10);
                rcfpdy.Rysj = dt1.Rows[0]["akc192"].ToString().Trim();
                string ryzd = dt1.Rows[0]["alc028"].ToString().Trim();

                string sql_ryzd = "select jbmc as name from gsjblx where jbbm='" + ryzd + "'";
                DataTable dt_ryzd = hisdb.Select(sql_ryzd).Tables[0];
                rcfpdy.Ryzd = dt_ryzd.Rows[0]["name"].ToString().Trim();
                rcfpdy.Cysj = dt1.Rows[0]["akc194"].ToString().Trim();

                string cyzd = dt1.Rows[0]["alc028"].ToString().Trim();
                string sql_cyzd = "select jbmc as name from gsjblx where jbbm='" + cyzd + "'";
                DataTable dt_cyzd = hisdb.Select(sql_cyzd).Tables[0];
                rcfpdy.Cyzd = dt_cyzd.Rows[0]["name"].ToString().Trim();
                rcfpdy.Ylzf = dt1.Rows[0]["alc407sum"].ToString().Trim();
                rcfpdy.Gszf = dt1.Rows[0]["jjin"].ToString().Trim();
                rcfpdy.Zfje = dt1.Rows[0]["alc408sum"].ToString().Trim();
                rcfpdy.Jbr = Tool.Yymc;
                rcfpdy.Dysj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                rcList.Add(rcfpdy);
            }
            return rcList;
        }
    }
}
