using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.clinic;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmXgjyb : Form
    {
        public FrmXgjyb()
        {
            InitializeComponent();
        }
        string xmmc;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }

        private string xzxyysfkb;
        /// <summary>
        /// 是否可报
        /// </summary>
        public string Xzxyysfkb
        {
            get { return xzxyysfkb; }
            set { xzxyysfkb = value; }
        }


        string jyb;
        /// <summary>
        /// 甲乙丙
        /// </summary>
        public string Jyb
        {
            get { return jyb; }
            set { jyb = value; }
        }

        string xzxyysm;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Xzxyysm
        {
            get { return xzxyysm; }
            set { xzxyysm = value; }
        }
        string hzmc;
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Hzmc
        {
            get { return hzmc; }
            set { hzmc = value; }
        }

        string xmbm;
        /// <summary>
        /// 项目编码
        /// </summary>
        public string Xmbm
        {
            get { return xmbm; }
            set { xmbm = value; }
        }

        string xfdhje;
        /// <summary>
        /// 先负担后金额
        /// </summary>
        public string Xfdhje
        {
            get { return xfdhje; }
            set { xfdhje = value; }
        }

        bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private void FrmXgjyb_Load(object sender, EventArgs e)
        {
            this.tbx_hzxm.Text = hzmc;
            this.tbx_xmmc.Text = xmmc;
            this.tbx_fydj.Text = jyb;
            this.tbx_xmbm.Text = xmbm;
            this.tbx_xfdhje.Text = xfdhje;
            this.tbx_ypsm.Text = xzxyysm;
            init_xzxyysfkb();
            flag = false;
        }
        private void init_xzxyysfkb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", ""));
            items.Add(new ListItem("1", "可报"));
            items.Add(new ListItem("2", "不可报"));

            this.cbx_xzxyysfkb.DisplayMember = "Text";
            this.cbx_xzxyysfkb.ValueMember = "Value";
            this.cbx_xzxyysfkb.DataSource = items;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jyb = this.tbx_fydj.Text.Trim();
            xfdhje = this.tbx_xfdhje.Text.Trim();
            xzxyysfkb = this.cbx_xzxyysfkb.SelectedValue.ToString().Trim();
            flag = true;
            this.Close();
        }
    }
}
