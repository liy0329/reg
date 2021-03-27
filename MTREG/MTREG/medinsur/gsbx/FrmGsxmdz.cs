using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhongluyiyuan.db;
namespace zhongluyiyuan.gsbx
{
    public partial class FrmGsxmdz : Form
    {
        public FrmGsxmdz()
        {
            InitializeComponent();
        }
        HISDB hisdb = new HISDB();
        DataTable ryzddata = new DataTable();
        private void tbxxm_KeyUp(object sender, KeyEventArgs e)
        {
            
            string sql = "";
           
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Focus();
                    this.dataGridView1.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dataGridView1.Focus();
                this.dataGridView1.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Focus();
                    this.dataGridView1.Rows[0].Selected = true;
                }
                return;
            }
            //查询
            if (tbxxm.Text.Trim().Equals(""))
            {
                return;
            }
            string tiaojian = " where mtprod.prodjixing=prodjixing.iid and (mtprod.name like '%" + tbxxm.Text.Trim() + "%' or jm like '%" + tbxxm.Text.ToLower().Trim() + "%') ";

            if (checkBox1.Checked == true)
            {
                tiaojian += " and projecttype in(2,3,4) and isdelete=0 ";
                sql = " select mtprod.iid,gsbm as bm,mtprod.name,jm,prodjixing.name as jixingname from mtprod,prodjixing  " + tiaojian;
            }
            if (checkBox2.Checked == true)
            {
                sql = " select iid,gsbm as bm,name,jm,'' as jixingname from mtprod  " + tiaojian + " and isdelete=0 and projecttype not in(2,3,4) union select iid,gsbm as bm,name,jm,'' as jixingname from mtjcxm  " + tiaojian + "  and isactive=0 ";
            }
            ryzddata = hisdb.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dataGridView1.DataSource = ryzddata;
                dataGridView1.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cx();
        }
        private void cx()
        {
            string sql = "";
            //查询
            if (tbxxm.Text.Trim().Equals(""))
            {
                return;
            }
            string tiaojian = " where mtprod.prodjixing=prodjixing.iid and (mtprod.name like '%" + tbxxm.Text.Trim() + "%' or jm like '%" + tbxxm.Text.ToLower().Trim() + "%') ";

            if (checkBox1.Checked == true)
            {
                tiaojian += " and projecttype in(2,3,4) and isdelete=0 ";
                sql = " select mtprod.iid,gsbm as bm,mtprod.name,jm,prodjixing.name as jixingname from mtprod,prodjixing  " + tiaojian;
            }
            if (checkBox2.Checked == true)
            {
                sql = " select iid,gsbm as bm,name,jm,'' as jixingname from mtprod  " + tiaojian + " and isdelete=0 and projecttype not in(2,3,4) union select iid,gsbm as bm,name,jm,'' as jixingname from mtjcxm  " + tiaojian + "  and isactive=0 ";
            }
            ryzddata = hisdb.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dataGridView1.DataSource = ryzddata;
                dataGridView1.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxiid.Text.Trim() == "")
            {
                    return;
            }
            if (tbxbm.Text.Trim() == "")
            {
                if (MessageBox.Show("确定置为空吗？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            string sql_cx = "select * from mtprod where iid=" + tbxiid.Text.Trim();
            DataTable dt_cx = hisdb.Select(sql_cx).Tables[0];
            if (dt_cx.Rows.Count == 0)
            {
                sql_cx = "select * from mtjcxm where iid=" + tbxiid.Text.Trim();
                DataTable dt_cx1 = hisdb.Select(sql_cx).Tables[0];
                if (dt_cx1.Rows.Count == 0)
                { return; }
                string sql_gx_mtjcxm = "update mtjcxm set gsbm='" + this.tbxbm.Text.Trim() + "' where iid=" + tbxiid.Text.Trim();
                hisdb.Update(sql_gx_mtjcxm);
                MessageBox.Show("修改成功！");
                cx();
            }
            else
            {
                string sql_gx = "update mtprod set gsbm='" + this.tbxbm.Text.Trim() + "' where iid=" + tbxiid.Text.Trim();
                hisdb.Update(sql_gx);
                MessageBox.Show("修改成功！");
                cx();
            }
        }

        private void FrmGsxmdz_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "";
            //查询
            if (textBox1.Text.Trim().Equals(""))
            {
                return;
            }
            string tiaojian = " where 1=1 and name like '%" + textBox1.Text.Trim() + "%' or jm like '%" + textBox1.Text.Trim().ToUpper() + "%' ";
            sql = " select * from gsml  " + tiaojian;
            ryzddata = hisdb.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dataGridView2.DataSource = ryzddata;
                dataGridView2.Visible = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            DataTable ryzddata = new DataTable();
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dataGridView1.Rows.Count > 0)
                {
                    dataGridView2.Focus();
                    this.dataGridView2.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dataGridView2.Focus();
                this.dataGridView2.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Focus();
                    this.dataGridView2.Rows[0].Selected = true;
                }
                return;
            }
            //查询
            if (textBox1.Text.Trim().Equals(""))
            {
                return;
            }
            string tiaojian = " where 1=1 and name like '%" + textBox1.Text.Trim() + "%' or jm like '%" + textBox1.Text.Trim().ToUpper() + "%' ";
            sql = " select * from gsml  " + tiaojian;
            ryzddata = hisdb.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dataGridView2.DataSource = ryzddata;
                dataGridView2.Visible = true;
            }
            else
            {
                dataGridView2.DataSource = null;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbxbm.Text = dataGridView1.Rows[e.RowIndex].Cells["zxbm"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["xmname"].Value.ToString().Trim();
                tbxiid.Text = dataGridView1.Rows[e.RowIndex].Cells["iid"].Value.ToString().Trim();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbxbm.Text = dataGridView2.Rows[e.RowIndex].Cells["zxdbm"].Value.ToString().Trim();
            }
        }
    }
}
