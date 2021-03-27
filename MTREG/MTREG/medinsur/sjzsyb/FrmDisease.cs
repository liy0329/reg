using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bean;
using MTHIS.tools;
using MTREG.common.bll;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmDisease : Form
    {
        Sjzsyb syb = new Sjzsyb();
        public FrmDisease()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDisease_Load(object sender, EventArgs e)
        {
            getcBox_category();

        }
        public void getcBox_category()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", "普通病种"));
            items.Add(new ListItem("1", "特殊病种"));
            items.Add(new ListItem("2", "慢性病种"));
            items.Add(new ListItem("5", "生育病种（住院）"));
            this.cBox_category.DisplayMember = "Value";
            this.cBox_category.ValueMember = "Test";
            this.cBox_category.SelectedValue = "0";
            this.cBox_category.DataSource = items;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = this.cBox_category.SelectedValue.ToString().Trim();
            //下载当前定点中心的病种目录
            SJZYB_IN<Disease_In> yb_in_dis = new SJZYB_IN<Disease_In>();
            yb_in_dis.INPUT = new List<Disease_In>();
            Disease_Out yb_out_dis = new Disease_Out();
            Disease_In doc = new Disease_In();
            SjzybInterface yb_xz = new SjzybInterface();
            yb_in_dis.MSGNO = "1635";
            doc.AKA123 = type;
            doc.CURRENTPAGE = "1";
            yb_in_dis.INPUT.Add(doc);


            int opstat = yb_xz.DownloadDisease(yb_in_dis, ref yb_out_dis);

            string ReturnMsg = "";
            if ((yb_out_dis.TOTALPAGE != null && int.Parse(yb_out_dis.TOTALPAGE) > 2))
            {
                for (int i = 2; i <= int.Parse(yb_out_dis.TOTALPAGE); i++)
                //for (int i = 20; i <= 30; i++)
                {
                    yb_in_dis.INPUT = new List<Disease_In>();
                    doc = new Disease_In();
                    doc.CURRENTPAGE = i.ToString();
                    doc.AKA123 = type;
                    yb_in_dis.INPUT.Add(doc);
                    opstat = yb_xz.DownloadDisease(yb_in_dis, ref yb_out_dis);
                }
            }

            int returnnum = Convert.ToInt32(yb_out_dis.RETURNNUM);
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_dis.ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            //更新sjz_yb_doc

            string sql = "";
            string zfc = "";
            if (type == "0")
            {
                zfc = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Disease_pt");//
            }
            else if (type == "1")
            {
                zfc = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Disease_ts");//
            }
            else if (type == "2")
            {
                zfc = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Disease_mx");//
            }
            else if (type == "5")
            {
                zfc = IniUtils.IniReadValue(IniUtils.syspath, "Updatetime", "Disease_sy");//
            }
            DateTime updateTime = Convert.ToDateTime(zfc.Substring(0,4)+"-"+zfc.Substring(4,2) +"-"+ zfc.Substring(6,2));

            Yb_Itme docitme = new Yb_Itme();
            //docitme.deleteyb_illness( type);
            for (int i = 0; i < yb_out_dis.OUTROW.Count; i++)
            {
                if (yb_out_dis.OUTROW[i].AKA120 == "0839")
                {
                }
                DateTime changeTime = Convert.ToDateTime(yb_out_dis.OUTROW[i].AAE035.ToString().Substring(0, 4) + "-" + yb_out_dis.OUTROW[i].AAE035.ToString().Substring(4, 2) + "-"+ yb_out_dis.OUTROW[i].AAE035.ToString().Substring(6,2));
                if (updateTime < changeTime)
                {
                    sql += docitme.addyb_illness(yb_out_dis.OUTROW[i]);
                }
                if (i % 1000 == 0 && i > 0)
                {
                    if (docitme.doExeSql(sql) == -1)
                    {
                        SysWriteLogs sysWriteLog = new SysWriteLogs();
                        string outLog = (i / 500 - 1).ToString() + "\r\n" + sql;
                        sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);
                        MessageBox.Show("添加病种失败！");
                        //return;
                    }
                    sql = "";
                }
            }
            if (docitme.doExeSql(sql) == -1)
            {
                MessageBox.Show("添加病种失败！");
                return;
            }
            string newTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (type == "0")
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Disease_pt", newTime);
            }
            else if (type == "1")
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Disease_ts", newTime);
            }
            else if (type == "2")
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Disease_mx", newTime);
            }
            else if (type == "5")
            {
                IniUtils.IniWriteValue(IniUtils.syspath, "Updatetime", "Disease_sy", newTime);
            }

            DataTable dt = docitme.selectyb_illness(type);
            dataGridView1.DataSource = dt;
            this.label1.Visible = true;

            this.label1.Text = "共获取病种：" + dt.Rows.Count.ToString() + "种";
        }

    }
}
