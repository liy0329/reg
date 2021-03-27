using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmCxtsxmml : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        public FrmCxtsxmml()
        {
            InitializeComponent();
        }
        private void btnCx_Click(object sender, EventArgs e)
        {
            string itemcode = textBox1.Text.ToString().Trim();
            string isvalid = "0";
            if (checkBox1.Checked)
            {
                isvalid = "1";
            }
            string outxml = gysybservice.Cxwdtsxmml("", isvalid);
            StringReader sr = new StringReader(outxml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString().Trim();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString().Trim();//错误信息
            if (flag == "0")
            {
                string sql = "delete from sybwdtsxmml;";
                DataTable dt = ds.Tables["ROW"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string _itemcode = dt.Rows[i]["ITEMCODE"].ToString().Trim();
                    string selfrate = dt.Rows[i]["SELFRATE"].ToString().Trim();
                    string type = dt.Rows[i]["SPECITEMTYPE"].ToString().Trim();
                    string startdate = dt.Rows[i]["STARTDATE"].ToString().Trim();
                    string enddate = dt.Rows[i]["ENDDATE"].ToString().Trim();
                    sql += "INSERT INTO sybwdtsxmml(itemcode, selfrate, specitemtype, startdate, enddate) VALUES ('" + _itemcode + "', " + selfrate + ", '" + type + "', '" + startdate + "', '" + enddate + "');";
                }
                BllMain.Db.Update(sql);
                sql = "select * from sybwdtsxmml";
                DataTable dt2 = BllMain.Db.Select(sql).Tables[0];
                dataGridView1.DataSource = dt2.DefaultView;
            }
            else
            {
                MessageBox.Show(info);
            }
        }
    }
}
