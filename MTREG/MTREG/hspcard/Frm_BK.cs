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
    public partial class Frm_BK : Form
    {
        public Frm_BK()
        {
            InitializeComponent();
        }
        private String iid;

        public String Iid
        {
            get { return iid; }
            set { iid = value; }
        }
        private String fullname;

        public String Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            HISDB hisdb =new HISDB();
            String sql2 = "select userid from cimsuser where iid=" + iid;
            DataTable dt = hisdb.Select(sql2).Tables[0];
            String oldId = dt.Rows[0]["userid"].ToString();
            String sql = "update cimsuser set userid='" + tbx_jzkh.Text + "' where iid=" + iid +";";
            sql += "update mtmzblstuff set userid='" + tbx_jzkh.Text + "' where userid='" + oldId + "'";
            if (hisdb.Update(sql) != -1)
                MessageBox.Show("补卡成功");
                
            else
                MessageBox.Show("补卡失败");
            Frm_JZK frm = (Frm_JZK)this.Owner;
            frm.serch();
            this.Close();
        }

        private void Frm_BK_Load(object sender, EventArgs e)
        {
            label_xm.Text = fullname;
            tbx_addr.Text = address;
        }

        private void tbx_jzkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String userID = tbx_jzkh.Text.Trim();
                if (userID.Length > 2)
                    if (userID.Substring(0, 1).Equals(";") || userID.Substring(0, 1).Equals("；"))
                    {
                        userID = userID.Substring(1, userID.Length - 2);
                        tbx_jzkh.Text = userID;
                    }
               
                
            }
        }

        private void Frm_BK_Activated(object sender, EventArgs e)
        {
            tbx_jzkh.Focus();
        }

        
    }
}
