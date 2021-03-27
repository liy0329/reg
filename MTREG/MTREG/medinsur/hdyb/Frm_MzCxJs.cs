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
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.hdyb
{
    public partial class Frm_MzCxJs : Form
    {
        public Frm_MzCxJs()
        {
            InitializeComponent();
        }

        public string zffs { get; set; }

        bool flag = false;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public zyjs_OUT Js_out { get; set; }
        public string regist_id { get; set; }
        //健康卡余额
        public string balance { get; set; }

        private void Frm_MzCxJs_Load(object sender, EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", "账户支付"));
            items.Add(new ListItem("1", "现金支付"));
            this.cbx_zffs.DisplayMember = "Text";
            this.cbx_zffs.ValueMember = "Value";
            this.cbx_zffs.DataSource = items;
            this.cbx_zffs.SelectedValue = "0";
            flag = false;


            this.lb_dbju.Text = Js_out.AKC706;
            this.lb_gwyzf.Text = Js_out.AKC707;
            this.lb_qtzf.Text = Js_out.AKC708;
            this.lb_shye.Text = Js_out.AKC252;
            this.lb_sqye.Text = Js_out.AKC087;
            this.lb_tczf.Text = Js_out.AKC260;
            this.lb_xjzf.Text = Js_out.AKC261;
            this.lb_zfy.Text = Js_out.AKC264;
            this.lb_zfzf.Text = Js_out.AKC754;
            this.lb_zhzf.Text = Js_out.AKC255;
            this.lb_jkkye.Text = balance;
            this.lb_jkkyeh.Text = (double.Parse(balance) - double.Parse(Js_out.AKC261)).ToString();
            

            


        }

        private void but_js_Click(object sender, EventArgs e)
        {
            if ((double.Parse(balance) - double.Parse(Js_out.AKC261)) < 0)
            {
                MessageBox.Show("健康卡余额不足，请充值！","提示");
                flag = false;
                return;
            }
            int zffs2 = this.cbx_zffs.SelectedIndex;
            if (zffs2 < 0)
            {
                MessageBox.Show("请选择支付方式！", "提示信息");
                return;
            }
            zffs = this.cbx_zffs.SelectedValue.ToString().Trim();
            flag = true;
            this.Close();
        }

        private void but_tc_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }
    }
}