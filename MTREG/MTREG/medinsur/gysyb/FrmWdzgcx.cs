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
using MTHIS.common;

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmWdzgcx : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        public FrmWdzgcx()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cshrdxx();
        }
        private void cshrdxx()
        {
            string grbh = tbxGrbh.Text.ToString();
            string sql = "select personcode, itemcode, itemname, drid, drname, operatorname from sybwdzgrd";
            if (grbh!="")
            {
                sql += "where personcode='" + tbxGrbh.Text.ToString() + "';";
            }
            dataGridView1.DataSource = BllMain.Db.Select(sql).Tables[0].DefaultView;
        }

        private void btnQxrz_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int rowIdx = dataGridView1.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者!");
                return;
            }
            string personcode = dataGridView1.Rows[rowIdx].Cells["personcode"].Value.ToString().Trim();
            string itemcode = dataGridView1.Rows[rowIdx].Cells["itemcode"].Value.ToString().Trim();
            string operatorname = ProgramGlobal.Username;
            string outXml = gysybservice.Wdzgcx(personcode, itemcode, operatorname);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (flag == "0")
            {
                string sql = "delete from sybwdzgrd where personcode='" + personcode + "' and itemcode='" + itemcode + "';";
                BllMain.Db.Update(sql);
                MessageBox.Show("认定撤消成功");
                cshrdxx();
            }
            else
            {
                MessageBox.Show(info);
            }
        }

    }
}
