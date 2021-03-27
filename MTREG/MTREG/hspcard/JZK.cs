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
    public partial class Frm_JZK : Form
    {
        public Frm_JZK()
        {
            InitializeComponent();
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            serch();
        }

        private void btn_tk_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                return;
            }
            int rowIdx = dgv.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }

            Frm_TK form = new Frm_TK();
            form.Fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            form.Sfzh = dgv.CurrentRow.Cells["ssn"].Value.ToString();
            form.Zjh = dgv.CurrentRow.Cells["userid"].Value.ToString();
            form.Iid = dgv.CurrentRow.Cells["iid"].Value.ToString();
            form.Address = dgv.CurrentRow.Cells["address"].Value.ToString();
            form.ShowDialog(this);

        }

        private void btn_bk_Click(object sender, EventArgs e)
        {
            
            if (dgv.CurrentRow == null)
            {
                return;
            }
            int rowIdx = dgv.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }

            Frm_BK form = new Frm_BK();
            form.Fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            form.Iid = dgv.CurrentRow.Cells["iid"].Value.ToString();
            form.Address = dgv.CurrentRow.Cells["address"].Value.ToString();
            form.ShowDialog(this);
        }

        private void tbx_xm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_cx.Focus();

            }
        }

        private void tbxjzk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String userID = tbxjzk.Text.Trim();
                if (userID.Length > 2)
                {

                    if (userID.Substring(0, 1).Equals(";") || userID.Substring(0, 1).Equals("；"))
                    {
                        userID = userID.Substring(1, userID.Length - 2);
                        tbxjzk.Text = userID;
                    }
                }
                serch();

            }
        }

        public void serch()
        {
            if (tbx_xm.Text.Trim().Equals("") && tbxjzk.Text.Trim().Equals(""))
            {
                dgv.DataSource = null;
                return;

            }
            
            String sql = "select ctct.fullname,(CASE WHEN ctct.gender in(1) THEN '男' WHEN ctct.gender in(2) THEN '女' ELSE '' END) as xb,cimsuser.userid,ctct.ssn,( select address.addr_dt1 from address,ctctaddr  where ctctaddr.addr = address.iid and  ctctaddr.ctct = ctct.iid ) as address  ,cimsuser.createdat,cimsuser.iid"
                        +" from ctct,cimsuser where cimsuser.ctct=ctct.iid";
            
            if (!tbx_xm.Text.Equals(""))
            {
                sql +=" and ctct.fullname like '%" + tbx_xm.Text + "%'";
            }
            if (!tbxjzk.Text.Equals(""))
            {
                sql += " and cimsuser.userid='" + tbxjzk.Text.Trim() + "'";
            }


            HISDB hisdb = new HISDB();
            DataTableCollection dtc = hisdb.Select(sql).Tables;
            if(dtc.Count>0)
            {
                dgv.DataSource = dtc[0];
            }
        }

        private void Frm_JZK_Activated(object sender, EventArgs e)
        {
            tbxjzk.Focus();
        }

        private void Frm_JZK_Load(object sender, EventArgs e)
        {
            dgv.DataSource = null;
        }
    }
}
