using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MTREG.medinsur.hdyb.bll;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.dor;
using MTHIS.common;
using MTREG.medinsur;
using MTHIS.dte;
using MTREG.Util;


namespace MTREG
{
    public partial class Frm_Ybzxfy : Form
    {
        public Frm_Ybzxfy()
        {
            InitializeComponent();
        }
 
        JKDB jkdb = new JKDB();
        YBCJ yw1 = new YBCJ();
  
        private string mtzyjl_iid;
        public string Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }

        private string sfck;
        public string Sfck
        {
            get { return sfck; }
            set { sfck = value; }
        }

        private string ybgrbh;
        public string Ybgrbh
        {
            get { return ybgrbh; }
            set { ybgrbh = value; }
        }

        private string qfybch;
        public string Qfybch
        {
            get { return qfybch; }
            set { qfybch = value; }
        }
        private string excel_Path;
        public string Excel_Path
        {
            get { return excel_Path; }
            set { excel_Path = value; }
        }
        private void Frm_Ybzxfy_Load(object sender, EventArgs e)
        {

        }
        private void init_dgv(DataGridView dgv)
        {
            try
            {
                dgv.DataSource = null;
                dgv.Columns.Clear();
                dgv.Rows.Clear();
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 获取Excel的DataTable
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件内容</returns>
        private DataTable importExecl(string filePath)
        {
            ExcelIO excelIO = new ExcelIO();
            return excelIO.ImportExcel(filePath);
        }
        private void btn_Dr_Click(object sender, EventArgs e)
        {
            init_dgv(dgv_ybzxfy);
            this.excel_Path = "";
            //this.ofdImportExcel.Filter = "Excel文件|*.xlsx";
            this.ofdImportExcel.Filter = "Excel文件|*.xls";
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.ofdImportExcel.InitialDirectory = deskPath;
            if (this.ofdImportExcel.ShowDialog() == DialogResult.OK)
            {
                string excelPath = this.ofdImportExcel.FileName;
                string[] filename = excelPath.Split('.');
                int len = filename.Length;
                //if (filename[len - 1].ToUpper() != "XLSX")
                if (filename[len - 1].ToUpper() != "XLS")
                {
                    MessageBox.Show("请选择Excel文件");
                    return;
                }
                this.excel_Path = excelPath;
                DataTable memInfo = importExecl(excelPath);
                this.dgv_ybzxfy.DataSource = memInfo;
            }
        }

        private void btn_Fysc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_Zyh.Text.Trim()))
            {
                MessageBox.Show("住院号不可以为空！");
                return;
            }
            string ybjk_sql_delete = " delete from KC22 where AKC190 = '" + this.tbx_Zyh.Text.Trim() + "' and CKC126=0";
            jkdb.Update(ybjk_sql_delete);
            string ybjk_sql = "select AKC220 from KC22 where AKC190 = '" + this.tbx_Zyh.Text.Trim() + "'";
            DataTable dt = jkdb.Select(ybjk_sql).Tables[0];
            string selectihsp_id = "select id from inhospital where ihspcode  = " + this.tbx_Zyh.Text.Trim();
            DataTable ihsp_ids=  BllMain.Db.Select(selectihsp_id).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + ihsp_ids.Rows[0]["id"].ToString() + " and id not in (";
                string iid_sqls = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iid_sqls += dt.Rows[i]["AKC220"].ToString() + ",";
                }
                iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
                his_sql_update += iid_sqls + ")";
                BllMain.Db.Update(his_sql_update);
            }
            else
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + ihsp_ids.Rows[0]["id"].ToString() + "";
                int ac = BllMain.Db.Update(his_sql_update);
            }
            string mesg = "";
            YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
            yw_in_ybsjcs.Yw = "BB310001";
            if (this.sfck == "1")
            {
                yw_in_ybsjcs.Ylzh = "0";
            }
            else
            {
                yw_in_ybsjcs.Ylzh = this.ybgrbh;
            }
            yw_in_ybsjcs.Rc = this.ybgrbh + "|" + this.tbx_Zyh.Text.Trim();
            for (int i = 0; i < dgv_ybzxfy.Rows.Count; i++)
            {
                if (DataTool.Getdouble(dgv_ybzxfy.Rows[i].Cells["数量"].Value.ToString().Trim()) == 0)
                    continue;
                string sql_fycx = "select top 1 * from kc22 where AKC225='" + dgv_ybzxfy.Rows[i].Cells["单价"].Value.ToString().Trim() + "'";
                sql_fycx += " and AKC223='" + dgv_ybzxfy.Rows[i].Cells["项目名称"].Value.ToString().Trim() + "'";
                sql_fycx += " and AKC190='" + this.tbx_Zyh.Text.Trim() + "' order by AKC220 asc";
                DataTable dt_fycx = jkdb.Select(sql_fycx).Tables[0];
                if (dt_fycx.Rows.Count > 0)
                {
                    string AKC220_kc22 = DateTime.Now.ToString("yyMMddHHmmss") + i.ToString();
                    string sql_fy_insert = "insert into kc22(AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,";
                    sql_fy_insert += "AKC227,AKA070,AAE040,ZKA100,ZKA101,CKC048,CKC126,CKC125,AKA065) values ('";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC190"].ToString().Trim() + "','";
                    sql_fy_insert += AKC220_kc22 + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC221"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC515"].ToString().Trim() + "','";
                    sql_fy_insert += dgv_ybzxfy.Rows[i].Cells["项目名称"].Value.ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC224"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC225"].ToString().Trim() + "','";
                    sql_fy_insert += (-double.Parse(dgv_ybzxfy.Rows[i].Cells["数量"].Value.ToString().Trim())).ToString() + "','";
                    sql_fy_insert += (-double.Parse(dgv_ybzxfy.Rows[i].Cells["金额"].Value.ToString().Trim())).ToString() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKA070"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AAE040"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["ZKA100"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["ZKA101"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["CKC048"].ToString().Trim() + "','";
                    sql_fy_insert += "0','";
                    sql_fy_insert += dt_fycx.Rows[0]["CKC125"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKA065"].ToString().Trim() + "')";
                    if (jkdb.Update(sql_fy_insert) == -1)
                    {
                        mesg += "[插入KC22错误：zyh-" + this.tbx_Zyh.Text.Trim() + "-项目名称-" + dgv_ybzxfy.Rows[i].Cells["项目名称"].Value.ToString().Trim() + "-数量-" + dgv_ybzxfy.Rows[i].Cells["数量"].Value.ToString().Trim() + "]\r\n";
                        continue;
                    }
                    int opt_ybsjcs = yw1.ybcjhs(yw_in_ybsjcs);
                    if (opt_ybsjcs == 0)
                    {
                        string ckc126_1 = "update KC22 set CKC126=1,AKC190='-" + this.tbx_Zyh.Text.Trim() + "',AAE072='-" + dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "' where AKC190='" + this.tbx_Zyh.Text.Trim() + "' and AKC220='" + AKC220_kc22 + "';";
                        jkdb.Update(ckc126_1);
                    }
                    else
                    {
                        mesg += "[数据传输：zyh-" + this.tbx_Zyh.Text.Trim() + "-项目名称-" + dgv_ybzxfy.Rows[i].Cells["项目名称"].Value.ToString().Trim() + "-" + yw_in_ybsjcs.Mesg + "-" + "]\r\n";
                        string sql_del = "delete from KC22 where AKC190='-" + this.tbx_Zyh.Text.Trim() + " and AKC220='" + AKC220_kc22 + "';";
                        jkdb.Update(sql_del);
                        continue;
                    }
                }
                else
                {
                    mesg += "[项目不存在：zyh-" + this.tbx_Zyh.Text.Trim() + "-项目名称-" + dgv_ybzxfy.Rows[i].Cells["项目名称"].Value.ToString().Trim() + "-数量-" + dgv_ybzxfy.Rows[i].Cells["数量"].Value.ToString().Trim() + "]\r\n";
                    continue;
                }
            }
            if (!string.IsNullOrEmpty(mesg))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg;
                frmmesg.ShowDialog(this);
            }
            this.btn_Qd.Enabled = true;
            MessageBox.Show("费用删除完成！请去东软软件里查看该患者费用是否已经为0，若为0，请点击确定按钮！");
        }

        private void btn_Cx_Click(object sender, EventArgs e)
        {
            init_dgv(dgv_kc22);
            if (string.IsNullOrEmpty(this.tbx_Zyh.Text.Trim()))
            {
                MessageBox.Show("住院号不可以为空！");
                return;
            }
            try
            {
                string sql_mtzyjl_cx = "select sfck,insurcode,qfybch from inhospital where ihspcode='" + this.tbx_Zyh.Text.Trim() + "' limit 1";
                DataTable dt_mtzyjl_cx = BllMain.Db.Select(sql_mtzyjl_cx).Tables[0];
                this.sfck = dt_mtzyjl_cx.Rows[0]["sfck"].ToString().Trim();
                this.ybgrbh = dt_mtzyjl_cx.Rows[0]["insurcode"].ToString().Trim();
                this.qfybch = dt_mtzyjl_cx.Rows[0]["qfybch"].ToString().Trim();
            }
            catch
            { }
            string sql_kc22_cx = " SELECT AKC515 as 编码,AKC223 as 项目名称,AKC225 as 单价,sum(AKC226) as 数量,sum(AKC227) as 金额,AKA065 as 性质 FROM KC22 WHERE AKC190='" + this.tbx_Zyh.Text.Trim() + "' ";
            sql_kc22_cx += " and CKC126=1 group by AKC515,AKC223,AKC225,AKA065 order by AKC223 asc;";
            DataTable dt_kc22_cx = jkdb.Select(sql_kc22_cx).Tables[0];
            this.dgv_kc22.DataSource = dt_kc22_cx;
        }

        private void btn_Qd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_Zyh.Text.Trim()))
            {
                MessageBox.Show("住院号不可以为空！");
                return;
            }
            this.btn_Qd.Enabled = false;
            string ybjk_sql_delete = "delete from KC22 where AKC190 = '" + this.tbx_Zyh.Text.Trim() + "'";
            jkdb.Update(ybjk_sql_delete);
            string selectihsp_id = "select id from inhospital where ihspcode = " + this.tbx_Zyh.Text.Trim();
           DataTable dt = BllMain.Db.Select(selectihsp_id).Tables[0];
           string his_sql_update = "update ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + dt.Rows[0]["id"].ToString() + "";
            BllMain.Db.Update(his_sql_update);
            MessageBox.Show("请去出院结算界面做预结算处理！");
        }
    }
}
