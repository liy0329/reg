using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zhongluyiyuan.gsbx.bll;
using zhongluyiyuan.listitem;
using zhongluyiyuan.Util;
using MTHIS.tools;
namespace zhongluyiyuan.gsbx
{
    public partial class Frmgsplhq : Form
    {
        public Frmgsplhq()
        {
            InitializeComponent();
        }
        DlDC dldc = new DlDC();
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        GSBXinterface GSBXinterface = new GSBXinterface();
        string sessionid;
        private void Frmgsplhq_Load(object sender, EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "获取工伤备案"));
            items.Add(new ListItem("21", "获取继续治疗"));
            this.cbx_cx.DisplayMember = "Text";
            this.cbx_cx.ValueMember = "Value";
            this.cbx_cx.DataSource = items;
            cbx_cx.SelectedValue = "11";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbx_cx.SelectedValue.ToString() == "11")
            {
                string flag = dldc.dengru();
                if (flag == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = dldc.Sessionid;

                in1.Log_name = "getReportBatch";
                in1.YwName = "getReportBatch";
                string data = "<getReportBatchReqData>";
                data += " <sessionid>" + sessionid + "</sessionid>";
                if (tbx_xm.Text.Trim() != "")
                {
                    data += " <aac002>" + tbx_xm.Text.Trim() + "</aac002>";
                }
                if (tbx_sfzh.Text.Trim() != "")
                {
                    data += " <aac003>" + tbx_sfzh.Text.Trim() + "</aac003>";
                }
                if (checkBox1.Checked == true)
                {
                    data += " <aae035>"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"</aae035>";
                    data += "<aae037>" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "</aae037>";
                }
                data += " </getReportBatchReqData>";
                in1.YwData = Base64.encodebase64(in1.head() + data);

                out1 = GSBXinterface.request(in1);
                if (out1.State == "2")
                {
                    MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                    string flag11 = dldc.dengchu(sessionid);
                    if (flag11 == "1")
                    {
                        MessageBox.Show(dldc.Message);
                        return;
                    }
                    sessionid = ""; return;
                }

                out1.State = out1.Ds.Tables["getReportBatchRespData"].Rows[0]["code"].ToString().Trim();
                out1.Message = out1.Ds.Tables["getReportBatchRespData"].Rows[0]["msg"].ToString().Trim();
                if (out1.State != "0")
                {
                    MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                    string flag11 = dldc.dengchu(sessionid);
                    if (flag11 == "1")
                    {
                        MessageBox.Show(dldc.Message);
                        return;
                    }
                    sessionid = "";
                    return;
                }
                DataTable dt = out1.Ds.Tables["ldch"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bz = dt.Rows[i]["alc029"].ToString().Trim();
                    if (bz == "0") { bz = "未认定"; } else if (bz == "1") { bz = "认定为工伤"; } else if (bz == "2") { bz = "不认定为工伤"; } else if (bz == "3") { bz = "认定为视同工伤"; } else if (bz == "4") { bz = "不认定为视同工伤"; }
                    dt.Rows[i]["alc029"] = bz;
                    string bz1 = dt.Rows[i]["CLC004"].ToString().Trim();
                    if (bz1 == "00") { bz1 = "事故报告"; } else if (bz1 == "10") { bz1 = "认定申请"; } else if (bz1 == "20") { bz1 = "认定受理"; } else if (bz1 == "30") { bz1 = "认定决议"; } else if (bz1 == "40") { bz1 = "认定回证"; } else if (bz1 == "50") { bz1 = "认定补证"; } else if (bz1 == "60") { bz1 = "认定举证"; } else if (bz1 == "70") { bz1 = "认定调查"; } else if (bz1 == "80") { bz1 = "认定中止"; }
                    dt.Rows[i]["CLC004"] = bz1;
                }
                dataGridView2.DataSource = dt;
                tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                string flag = dldc.dengru();
                if (flag == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = dldc.Sessionid;

                in1.Log_name = "getCureBatch";
                in1.YwName = "getCureBatch";
                string data = "<getCureBatchReqData>";
                data += " <sessionid>" + sessionid + "</sessionid>";
                if (tbx_xm.Text.Trim() != "")
                {
                    data += " <aac002>" + tbx_xm.Text.Trim() + "</aac002>";
                }
                if (tbx_sfzh.Text.Trim() != "")
                {
                    data += " <aac003>" + tbx_sfzh.Text.Trim() + "</aac003>";
                }
                if (checkBox1.Checked == true)
                {
                    data += " <aae035>" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "</aae035>";
                    data += "<aae037>" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "</aae037>";
                }
                data += " </getCureBatchReqData>";
                in1.YwData = Base64.encodebase64(in1.head() + data);

                out1 = GSBXinterface.request(in1);
                if (out1.State == "2")
                {
                    MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                    string flag11 = dldc.dengchu(sessionid);
                    if (flag11 == "1")
                    {
                        MessageBox.Show(dldc.Message);
                        return;
                    }
                    sessionid = ""; return;
                }

                out1.State = out1.Ds.Tables["getCureBatchRespData"].Rows[0]["code"].ToString().Trim();
                out1.Message = out1.Ds.Tables["getCureBatchRespData"].Rows[0]["msg"].ToString().Trim();
                if (out1.State != "0")
                {
                    MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                    string flag11 = dldc.dengchu(sessionid);
                    if (flag11 == "1")
                    {
                        MessageBox.Show(dldc.Message);
                        return;
                    }
                    sessionid = "";
                    return;
                }
                dataGridView1.DataSource = out1.Ds.Tables["lkb7"];
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;

            in1.Log_name = "getPerDetail";
            in1.YwName = "getPerDetail";
            string data = "<perDetailReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            if (textBox1.Text.Trim() != "")
            {
                data += " <aac002>" + textBox1.Text.Trim() + "</aac002>";
            }
            if (textBox2.Text.Trim() != "")
            {
                data += " <aac003>" + textBox2.Text.Trim() + "</aac003>";
            }
            if (checkBox2.Checked == true)
            {
                data += " <akc192s>" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "</akc192s>";
                data += "<akc192e>" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "</akc192e>";
            }
            if (checkBox3.Checked == true)
            {
                data += " <akc194s>" + dateTimePicker6.Value.ToString("yyyy-MM-dd") + "</akc194s>";
                data += "<akc194e>" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "</akc194e>";
            }
            if (checkBox4.Checked == true)
            {
                data += " <aae036s>" + dateTimePicker8.Value.ToString("yyyy-MM-dd") + "</aae036s>";
                data += "<aae036e>" + dateTimePicker7.Value.ToString("yyyy-MM-dd") + "</aae036e>";
            }
            data += " </perDetailReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["perDetailRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["perDetailRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            dataGridView3.DataSource = out1.Ds.Tables["detailData"];
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                switch (dataGridView3.Rows[i].Cells["Column7"].Value.ToString())
                {
                    case "21": dataGridView3.Rows[i].Cells["Column7"].Value = "住院";
                        break;
                    case "11": dataGridView3.Rows[i].Cells["Column7"].Value = "门诊";
                        break;
                    default:
                        break;
                }
                switch (dataGridView3.Rows[i].Cells["Column10"].Value.ToString())
                {
                    case "4": dataGridView3.Rows[i].Cells["Column10"].Value = "康复";
                        break;
                    case "7": dataGridView3.Rows[i].Cells["Column10"].Value = "治疗";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
