using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace MTREG.medinsur.hdyb
{
    public partial class FormXzxypsp : Form
    {
        public FormXzxypsp()
        {
            InitializeComponent();
        }
        string xmmc;

        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }

        private string xzxyysfkb;

        public string Xzxyysfkb
        {
            get { return xzxyysfkb; }
            set { xzxyysfkb = value; }
        }


        string jyb;

        public string Jyb
        {
            get { return jyb; }
            set { jyb = value; }
        }

        string xzxyysm;

        public string Xzxyysm
        {
            get { return xzxyysm; }
            set { xzxyysm = value; }
        }
        string hzmc;

        public string Hzmc
        {
            get { return hzmc; }
            set { hzmc = value; }
        }

        string xmbm;

        public string Xmbm
        {
            get { return xmbm; }
            set { xmbm = value; }
        }
        private void FormXzxypsp_Load(object sender, EventArgs e)
        {
            this.tbx_hzxm.Text = hzmc;
            this.tbx_xmmc.Text = xmmc;
            this.tbx_fydj.Text = jyb;
            this.tbx_xmbm.Text = xmbm;
            this.tbx_ypsm.Text = xzxyysm;
            init_xzxyysfkb();
        }
        private void init_xzxyysfkb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("可报", "1"));
            items.Add(new ListItem("不可报", "2"));

            this.cbx_xzxyysfkb.DisplayMember = "Text";
            this.cbx_xzxyysfkb.ValueMember = "Value";
            this.cbx_xzxyysfkb.DataSource = items;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xzxyysfkb = this.cbx_xzxyysfkb.SelectedValue.ToString().Trim();
            this.Close();
        }
    }
}
