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

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmCxwdzg : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        public FrmCxwdzg()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxGrbh.Text.ToString().Trim()) && string.IsNullOrEmpty(tbxXmbm.Text.ToString().Trim()) && string.IsNullOrEmpty(tbxSfzh.Text.ToString().Trim()))
            {
                MessageBox.Show("三个参数不能都为空!");
                return;
            }
            string personcode = tbxGrbh.Text.ToString().Trim();
            string itemcode = tbxXmbm.Text.ToString().Trim();
            string drid = tbxSfzh.Text.ToString().Trim();
            string outXml = gysybservice.CxWdzg(personcode, itemcode, drid);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString().Trim();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString().Trim();//错误信息
            if (flag == "0")
            {
                dataGridView1.DataSource = ds.Tables["ROW"].DefaultView;
            }
            else
            {
                MessageBox.Show(info);
            }
        }
    }
}
