using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.gzswyb.common;
using MTREG.medinsur.gzsyb.Util;
using System.IO;
using Microsoft.Office.Interop.Excel;
using MTREG.medinsur.gzsyb.bll;
using MTHIS.main.bll;
using MTREG.medinsur.gzsyb.bo;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_ydjscxall : Form
    {
        GzsybInterface gzsybInterface = new GzsybInterface();
        public Frm_ydjscxall()
        {
            InitializeComponent();
        }
        private void btn_cx_Click(object sender, EventArgs e)
        {
            string[] param = new string[4];
            param[0] = "020023";
            param[1] = dateTimePicker1.Value.ToString().Split(' ')[0];
            param[2] = dateTimePicker2.Value.ToString().Split(' ')[0];
            param[3] = "c:\\jscx.txt";
            GetJsAll ihh = new GetJsAll();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "46";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param) ;
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "清算申请查询错误信息");
                return;
            }
            StreamReader objReader = new StreamReader("c:\\jscx.txt",System.Text.Encoding.Default);
            String sLine = "";
            List<String> lineList = new List<String>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != null)
                    lineList.Add(sLine);
            }
            objReader.Close();
            string sql = "delete from gzsyb_jscxall;";
            BllMain.Db.Update(sql);
            
            string s = "";
            for (int i = 0; i < lineList.Count; i++)
            {
                string _data = lineList[i];
                string[] _d2 = _data.Split('\t');
                for (int j = 0; j < _d2.Length; j++)
                {
                    if (_d2[j].StartsWith(".") == true)
                    {
                        _d2[j] = "0" + _d2[j];
                    }
                    if (_d2[6] == "")
                    {
                        _d2[6] = "0";
                    }
                }
                

                s += "INSERT INTO gzsyb_jscxall (";
                s += "aac001, yka065, yka055, yka056, yka057, yka111, yka058, yka248, ";
                s += "yka062, yke030, ykc177, yab037, yka316, yka054, yae366, akc021, ";
                s += "ykc121, ykc280, ykc281, aae036, akc190, aac003, yka103, ykb65, aka130, yab003)";
                s += " VALUES (";
                s += "'" + _d2[0] + "',";
                s += _d2[1] + ",";
                s += _d2[2] + ",";
                s += _d2[3] + ",";
                s += _d2[4] + ",";
                s += _d2[5] + ",";
                s += _d2[6] + ",";
                s += _d2[7] + ",";
                s += _d2[8] + ",";
                s += _d2[9] + ",";
                s += "'" + _d2[10] + "',";
                s += "'" + _d2[11] + "',";
                s += "'" + _d2[12] + "',";
                s += "'" + _d2[13] + "',";
                s += "'" + _d2[14] + "',";
                s += "'" + _d2[15] + "',";
                s += "'" + _d2[16] + "',";
                s += "'" + _d2[17] + "',";
                s += "'" + _d2[18] + "',";
                s += "'" + _d2[19] + "',";
                s += "'" + _d2[20] + "',";
                s += "'" + _d2[21] + "',";
                s += "'" + _d2[22] + "',";
                s += "'" + _d2[23] + "',";
                s += "'" + _d2[24] + "',";
                s += "'" + _d2[25] + "');";
                if (i % 500 == 0)
                {
                    BllMain.Db.Update(s);
                    s = "";
                }
            }
            if (s != "")
            {
                BllMain.Db.Update(s);
            }
            //MessageBox.Show("从医保中心下载数据成功");
            
            string sql3 = "select * from gzsyb_jscxall";
            dataGridView1.DataSource = BllMain.Db.Select(sql3).Tables[0];
        }

        private void btn_daochu_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); 
            excel.Application.Workbooks.Add(true);  //生成字段名称  
            for (int i = 0; i < dataGridView1.ColumnCount; i++)  
            {
                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }  
            //填充数据  
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)  
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)  
                {
                    if (dataGridView1[j, i].Value == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "" + dataGridView1[i, j].Value.ToString();  
                    }  
                    else  
                    {
                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();  
                    }  
                }  
            }
            excel.Visible = true;
        }

        private void btnCx_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.CurrentRow.Index;
            string Jbr = ProgramGlobal.User_id;
            string xgxxJbr = ProgramGlobal.Username;
            string jbsj = DateTime.Now.ToString();
            String[] param = new String[10];
            param[0] = dataGridView1.Rows[idx].Cells["akc190"].Value.ToString(); //dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dataGridView1.Rows[idx].Cells["yab003"].Value.ToString();//dt.Rows[0]["yab003"].ToString();//分中心编号
            param[2] = dataGridView1.Rows[idx].Cells["aka130"].Value.ToString(); //dt.Rows[0]["aka130"].ToString();//支付类别
            param[3] = dataGridView1.Rows[idx].Cells["yka103"].Value.ToString(); //dt.Rows[0]["yka103"].ToString();//结算编号
            param[4] = Jbr;//经办人员编码（可空）
            param[5] = xgxxJbr;//经办人姓名
            param[6] = DateTime.Now.ToString();//经办时间(可空)
            param[7] = "不祥";//退费原因
            param[8] = dataGridView1.Rows[idx].Cells["ykb65"].Value.ToString(); //dt.Rows[0]["ykb065"].ToString();//社会保险办法
            param[9] = dataGridView1.Rows[idx].Cells["aac001"].Value.ToString();//dt.Rows[0]["aac001"].ToString();//个人编号
            SettleBack ihh = new SettleBack();
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "42";
            callIn.Astr_jysr_xml = ihh.xmlCode_head() + ihh.xmlCode_in(param);
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return;
            }
            Confirm_in confirmIn = new Confirm_in();
            confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
            confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
            Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
            if (confirmOut.AintAppcode < 0)
            {
                MessageBox.Show(confirmOut.AstrAppmsg, "错误信息");
                return;
            }
            MessageBox.Show("结算回退成功！", "提示消息");
        }
    }
}
