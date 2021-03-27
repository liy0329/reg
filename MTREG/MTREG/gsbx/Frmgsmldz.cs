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
    public partial class Frmgsmldz : Form
    {
        public Frmgsmldz()
        {
            InitializeComponent();
        }
        private string iid;
        public string Iid
        {
            get { return iid; }
            set { iid = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private void Frmgsmldz_Load(object sender, EventArgs e)
        {
            this.tbxxm.Text = this.name;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            DataTable ryzddata = new DataTable();
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
            if (e.KeyValue == (char)Keys.Space)
            {
                sql = " select * from gsml ";

                ryzddata = BllMain.Db.Select(sql).Tables[0];
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = ryzddata;
                }
                else
                {
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
            ryzddata = BllMain.Db.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dataGridView1.DataSource = ryzddata;
                dataGridView1.Visible = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbxbm.Text = dataGridView1.Rows[e.RowIndex].Cells["zxbm"].Value.ToString().Trim();
                textBox1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                textBox1.Focus();
                return;
            }
            if (e.KeyValue == 13)
            {
                int rowindex = this.dataGridView1.CurrentRow.Index;
                if (rowindex >= 0)
                {
                    tbxbm.Text = dataGridView1.Rows[rowindex].Cells["zxbm"].Value.ToString().Trim();
                    textBox1.Focus();
                }
            }
            if (e.KeyValue == (char)Keys.Escape)
            {
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (tbxbm.Text.Trim() == "")
            {
                if (MessageBox.Show("确定置为空吗？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            string sql_gx_mtjcxm = "update bas_item set gsbm='" + this.tbxbm.Text.Trim() + "' where id=" + this.iid;
            BllMain.Db.Update(sql_gx_mtjcxm);
            MessageBox.Show("修改成功！");
            this.Close();
        }
    }
}
