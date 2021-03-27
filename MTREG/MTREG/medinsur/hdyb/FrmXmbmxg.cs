using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmXmbmxg : Form
    {
        public FrmXmbmxg()
        {
            InitializeComponent();
        }
        private string mtprodiid;//
        /// <summary>
        /// 项目ID
        /// </summary>
        public string Mtprodiid
        {
            get { return mtprodiid; }
            set { mtprodiid = value; }
        }
        private string xmmc;//
        /// <summary>
        /// 项目名称 
        /// </summary>
        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        private string xmjg;//
        /// <summary>
        /// 项目价格
        /// </summary>
        public string Xmjg
        {
            get { return xmjg; }
            set { xmjg = value; }
        }

        private string ghbm;//
        /// <summary>
        /// 改后编码
        /// </summary>
        public string Ghbm
        {
            get { return ghbm; }
            set { ghbm = value; }
        }
        private void FrmXmbmxg_Load(object sender, EventArgs e)
        {
            this.lb_zy1.Text = "注意：若项目自费，请点确定！";
            this.lb_zy2.Text = "若项目报销，请编码作医保对照后再点确定！";
            this.tbx_xmid.Text = mtprodiid;
            this.tbx_xmmc.Text = xmmc;
            this.tbx_xmjg.Text = xmjg;
        }

        private void btn_qd_Click(object sender, EventArgs e)
        {
            if (this.tbx_ghbm.Text.Trim() == "")
            {
                this.tbx_ghbm.Text = "999999999";
            }

            string sql_gx = "update bas_item set standcode='" + this.tbx_ghbm.Text.Trim() + "' where id=" + this.mtprodiid;
            BllMain.Db.Update(sql_gx);
            MessageBox.Show("修改成功！");
            this.Close(); 
        }

        private void but_gb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
