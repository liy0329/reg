using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmCxtsxmyl : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        public FrmCxtsxmyl()
        {
            InitializeComponent();
            tbxNd.Text = DateTime.Now.ToString("yyyy");
        }
        private void btnCxrdyp_Click(object sender, EventArgs e)
        {
            string grbh = tbxGrbh.Text.ToString();
            string sql = "select personcode, itemcode, itemname, drid, drname, operatorname from sybwdzgrd";
            if (grbh != "")
            {
                sql += "where personcode='" + tbxGrbh.Text.ToString() + "';";
            }
            dataGridView1.DataSource = BllMain.Db.Select(sql).Tables[0].DefaultView;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int rowIdx = dataGridView1.CurrentRow.Index;
            if (rowIdx < 0)
            {
                return;
            }
            string personcode = dataGridView1.Rows[rowIdx].Cells["personcode"].Value.ToString().Trim();
            string itemcode = dataGridView1.Rows[rowIdx].Cells["itemcode"].Value.ToString().Trim();
            string nd = tbxNd.Text.ToString().Trim();
            string outXml = gysybservice.CxTsxmyl(personcode, itemcode, nd);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString().Trim();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString().Trim();//错误信息
            if (flag == "0")
            {
                tbxLjyl.Text = ds.Tables["DATA"].Rows[0]["LASTTOTALQTY"].ToString().Trim();
                tbxZhjsyy.Text = ds.Tables["DATA"].Rows[0]["LASTHOSPNAME "].ToString().Trim();
                tbxDnsyl.Text = ds.Tables["DATA"].Rows[0]["LASTQTY"].ToString().Trim();
                tbxZhsysj.Text = ds.Tables["DATA"].Rows[0]["LASTDATE"].ToString().Trim();
                tbxZflb.Text = ds.Tables["DATA"].Rows[0]["PAYTYPE"].ToString().Trim();
            }
            else
            {
                MessageBox.Show(info);
            }
        }
    }
}
