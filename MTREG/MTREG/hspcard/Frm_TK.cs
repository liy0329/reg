using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using guizhousheng.db;

namespace guizhousheng
{
    public partial class Frm_TK : Form
    {
        public Frm_TK()
        {
            InitializeComponent();
        }
        private String fullname;

        public String Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }


        private String sfzh;

        public String Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        private String zjh;

        public String Zjh
        {
            get { return zjh; }
            set { zjh = value; }
        }
        private String iid;

        public String Iid
        {
            get { return iid; }
            set { iid = value; }
        }
        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        private void btn_tk_Click(object sender, EventArgs e)
        {
            HISDB hisdb = new HISDB();
            String oldId = tbx_jzkh.Text.Trim();
            String newId = "T" + tbx_jzkh.Text.Trim();
            String sql = "update cimsuser set userid='T'||'" + tbx_jzkh.Text.Trim() +"' where iid=" + iid+";";
            sql += "update mtmzblstuff set userid='" + newId + "' where userid='" + oldId + "'";
            if (hisdb.Update(sql) != -1)
                MessageBox.Show("退卡成功");
            else
                MessageBox.Show("退卡失败");
            Frm_JZK frm = (Frm_JZK)this.Owner;
            frm.serch();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_TK_Load(object sender, EventArgs e)
        {
            tbx_xm.Text = fullname;
            tbx_sfzh.Text = sfzh;
            tbx_jzkh.Text = zjh;
            tbx_addr.Text = address;
        }
    }
}
