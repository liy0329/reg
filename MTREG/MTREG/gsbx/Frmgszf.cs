using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;
namespace zhongluyiyuan.gsbx
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
            if (checkBox1.Checked == true)
            {
                gszf = "1";
            }
            else { gszf = "0"; }
            string sql_gx = "update bas_item set gszf='" + gszf + "' where id=" + this.mtprodiid;
            BllMain.Db.Update(sql_gx);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
