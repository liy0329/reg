using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsyb.gysyb.Entity;
using System.IO;
using MTREG.medinsur.gzsyb.Util;
using MTREG.medinsur.gysyb.bo;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmSybMzJxCx : Form
    {
        public FrmSybMzJxCx()
        {
            InitializeComponent();
        }
        GysybInterface gysybface = new GysybInterface();
        private void btnCx_Click(object sender, EventArgs e)
        {
            String[] param = new String[9];
            param[0] = dateTimePickerKssj.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            param[1] = dateTimePickerJssj.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            param[2] = tbx_grbm.Text.Trim();
            param[3] = "";
            param[4] = "";
            param[5] = "";
            param[6] = "";
            param[7] = "";
            param[8] = "";

            Cxjkptmzjssj xxx = new Cxjkptmzjssj();
            string in_xml = xxx.Cxjkptmzjssj_head() + xxx.Cxjkptmzjssj_in(param) + xxx.Cxjkptmzjssj_tail();
            GysybInterface gysybinterface = new GysybInterface();
            string out_xml = gysybinterface.GetQUERYINFCLINBILL(in_xml);
            StringReader sr = new StringReader(out_xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (flag == "0")
            {
                DataTable dt = ds.Tables["ROW"];
                dataGridView1.DataSource = dt;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cxjkptmzmx xxx = new Cxjkptmzmx();
            String[] param = new String[3];
            int rowIdx = e.RowIndex;
            int colIdx = e.ColumnIndex;
            param[0] = dataGridView1.CurrentRow.Cells["BILLNO"].Value.ToString();
            param[1] = dataGridView1.CurrentRow.Cells["BALANCEID"].Value.ToString();
            param[2] = dataGridView1.CurrentRow.Cells["RETURNID"].Value.ToString();
            string in_Xml = xxx.Cxjkptmzmx_head() + xxx.Cxjkptmzmx_in(param) + xxx.Cxjkptmzmx_tail();
            GysybInterface gysybinterface = new GysybInterface();
            string out_Xml = gysybinterface.GetQUERYINFCLINFEELIST(in_Xml);
            StringReader sr = new StringReader(out_Xml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (flag == "0")
            {
                DataTable dt = ds.Tables["ROW"];
                dataGridView2.DataSource = dt;
            }

        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int rowIdx = dataGridView1.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选定要冲销的结算行");
                return;
            }
            
            String[] param = new String[5];
            param[0] = dataGridView1.CurrentRow.Cells["BILLNO"].Value.ToString();//就诊顺序号
            param[1] = dataGridView1.CurrentRow.Cells["BALANCEID"].Value.ToString(); ;//结算编号
            param[2] = "11";//支付类别
            param[3] = MTHIS.common.ProgramGlobal.User_id;//操作员
            param[4] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//办理时间
            Tp tp = new Tp();
            String InXml = tp.Tp_head() + tp.Tp_in(param) + tp.Tp_tail();
            String outXml = "";
            if (dataGridView1.CurrentRow.Cells["INSURETYPE"].Value.ToString().Equals("2"))
            {
                outXml = gysybface.Lxmztp(InXml); //离休退票
            }
            else
            {
                outXml = gysybface.Ptmztp(InXml);// 普通退票
            }
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
            if (!flag.Equals("0"))
            {
                MessageBox.Show("撤销失败，请稍后重试");
                return;
            }
            MessageBox.Show("费用撤销成功");
        }

    }
}
