using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.Util;
using MTHIS.tools;
using System.Text.RegularExpressions;
using MTREG.gsbx.bll;
using MTREG.medinsur.sjzsyb.clinic;
using MTHIS.main.bll;

namespace MTREG.gsbx
{
    public partial class FrmJxzl : Form
    {
        DlDC dldc = new DlDC();
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        GSBXinterface GSBXinterface = new GSBXinterface();
        string sessionid = "";
        public FrmJxzl()
        {
            InitializeComponent();
        }
        private string mtzyjliid;
        public string Mtzyjliid
        {
            get { return mtzyjliid; }
            set { mtzyjliid = value; }
        }
        private string xm;
        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        private string rdsh;
        public string Rdsh
        {
            get { return rdsh; }
            set { rdsh = value; }
        }
        private string sfzh;
        public string Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        private string grbh;
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private string zzys;
        public string Zzys
        {
            get { return zzys; }
            set { zzys = value; }
        }
        private string ylzd;
        public string Ylzd
        {
            get { return ylzd; }
            set { ylzd = value; }
        }
        private string mzzy;
        public string Mzzy
        {
            get { return mzzy; }
            set { mzzy = value; }
        }

        private void FrmJxzl_Load(object sender, EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("3", "康复治疗"));
            items.Add(new ListItem("2", "继续治疗"));
            items.Add(new ListItem("1", "        "));
            this.combo_zllb.DisplayMember = "Text";
            this.combo_zllb.ValueMember = "Value";
            this.combo_zllb.DataSource = items;
            this.combo_zllb.SelectedValue = "1";
            tbx_Grbh.Text = grbh;
            tbx_kszr.Text = zzys;
            tbx_rdsh.Text = rdsh;
            tbx_Sfzh.Text = sfzh;
            tbx_Xm.Text = xm;
            tbx_zzys.Text = zzys;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_zllb.SelectedValue == "1")
            {
                MessageBox.Show("请选择治疗类别！");
                return;
            }
            if (tbx_yszd.Text.Trim() == "")
            {
                MessageBox.Show("请填写医生诊断！");
                return;
            }
            if (tbx_dwyj.Text.Trim() == "")
            {
                MessageBox.Show("请填写单位意见！");
                return;
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "sendCure";
            in1.YwName = "sendCure";
            string data = "<cureReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += "<lkb7>";
            data += "<aac002>"+tbx_Sfzh.Text.Trim()+"</aac002>";
            data += "<aac003>"+tbx_Xm.Text.Trim()+"</aac003>";
            data += "<alca02>"+tbx_rdsh.Text.Trim()+"</alca02>";
            data += "<aac001>"+tbx_Grbh.Text.Trim()+"</aac001>";
            data += "<jxzl>2</jxzl>";
            data += "<ale021>"+combo_zllb.SelectedValue.ToString().Trim()+"</ale021>";
            data += "<cka039>"+tbx_zzys.Text.Trim()+"</cka039>";
            data += "<aae014>" + tbx_zzys.Text.Trim() +  "</aae014>";
            data += "<akc173>" +Starttime.Value.ToString("yyyy-MM-dd") + "</akc173>";
            data += "<aae031>" + Endtime.Value.ToString("yyyy-MM-dd") + "</aae031>";
            data += "<akc174>"+tbx_yszd.Text.Trim()+"</akc174>";
            data += "<akc177>"+tbx_dwyj.Text.Trim()+"</akc177>";
            data += "</lkb7>";
            data += " </cureReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu("20180925153226256");
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["cureRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["cureRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show(in1.Log_name + "出错！【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            MessageBox.Show("申请成功！");
            string sql_up="";
            if (mzzy == "1")
            {
                sql_up = "update mtzyjl set spbh=" + out1.Ds.Tables["cureRespData"].Rows[0]["aae073"].ToString().Trim() + " where iid=" + mtzyjliid;
            }
            else
            {
               sql_up = "update mtmzblstuff set spbh=" + out1.Ds.Tables["cureRespData"].Rows[0]["aae073"].ToString().Trim() + " where iid=" + mtzyjliid;
            }
            BllMain.Db.Update(sql_up);
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            button1.Enabled = false;
        }
    }
}
