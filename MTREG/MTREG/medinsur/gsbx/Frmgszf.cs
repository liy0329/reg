using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;

namespace MTREG.gsbx
{
    public partial class Frmgszf : Form
    {
        public Frmgszf()
        {
            InitializeComponent();
        }
        private string mtprodiid;//项目ID

        public string Mtprodiid
        {
            get { return mtprodiid; }
            set { mtprodiid = value; }
        }
        private string xmmc;//项目名称 Mtprodiid

        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        private void Frmgszf_Load(object sender, EventArgs e)
        {
            this.tbx_xmid.Text = mtprodiid;
            this.tbx_xmmc.Text = xmmc;
        }

        private void btn_qd_Click(object sender, EventArgs e)
        {
            string gszf = "";
            string sql_cx = "select * from mtprod where iid=" + this.mtprodiid;
            DataTable dt_cx = BllMain.Db.Select(sql_cx).Tables[0];
            if (dt_cx.Rows.Count == 0)
            {
                sql_cx = "select * from mtjcxm where iid=" + this.mtprodiid;
                DataTable dt_cx1 = BllMain.Db.Select(sql_cx).Tables[0];
                if (dt_cx1.Rows.Count == 0)
                    return;
                if (checkBox1.Checked == true)
                {
                    gszf = "1";
                }
                else { gszf = "0"; }
                string sql_gx_mtjcxm = "update mtjcxm set gszf='"+gszf + "' where iid=" + this.mtprodiid;
                BllMain.Db.Update(sql_gx_mtjcxm);
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    gszf = "1";
                }
                else { gszf = "0"; }
                string sql_gx = "update mtprod set gszf='" + gszf + "' where iid=" + this.mtprodiid;
                BllMain.Db.Update(sql_gx);
                MessageBox.Show("修改成功！");
                this.Close();
            }
        }
    }
}
