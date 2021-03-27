using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.Util;
using HospCS;
using HISDECDRYTO;
using System.IO;
using MTREG.medinsur.gysyb.bll;
using MTREG.common;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_wsryinfo : Form
    {
        public Frm_wsryinfo()
        {
            InitializeComponent();
        }
        HospCS.bean hospcs = new bean();
        SysWriteLogsxml syswritelogsxml = new SysWriteLogsxml();
        public String ip = "10.169.14.117";
        //public String ip = "10.169.6.50";
        HISDEC hisdec = new HISDEC();

        private string mtzyjliid;

        public string Mtzyjliid
        {
            get { return mtzyjliid; }
            set { mtzyjliid = value; }
        }
        private void Frm_wsryinfo_Load(object sender, EventArgs e)
        {
            getinfo();
            inibzxx();
        }
        public void getinfo()
        {
            string sql = "select insur_gysyb_zy.billno as billno,insur_gysyb_zy.personcode,inhospital.name as fullname,bas_doctor.cardid as ssn,inhospital.Ihspdiagn as zyjlryzd from insur_gysyb_zy,inhospital, bas_doctor where inhospital.doctor_id=bas_doctor.id  and insur_gysyb_zy.mtzyjliid=inhospital.id and insur_gysyb_zy.mtzyjliid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            tbx_jzsxh.Text = dt.Rows[0]["billno"].ToString();
            tbx_grbh.Text = dt.Rows[0]["personcode"].ToString();
            lblxm.Text = dt.Rows[0]["fullname"].ToString();
            tbxRyzd.Text = dt.Rows[0]["zyjlryzd"].ToString();
            tbx_yssfzh.Text = dt.Rows[0]["ssn"].ToString();
            string sql2 = "select ryzd from sybwszd where mtzyjl=" + Mtzyjliid;
            DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                string ryzd = dt2.Rows[0]["ryzd"].ToString();
                if (ryzd == "1")
                {
                    lblZt.Text = "已上传过";
                }
            }
        }
        public void inibzxx()
        {
            object[] objs = { "0", null };
            DataTable dt = new DataTable();
            DataRow dr;
            return;
            
            DataTable dt2 = GetIcd();
            //DataTable ryzddata = new DataTable();
            //ryzddata = GetIcd();
            //dr = ryzddata.NewRow();
            //dr.ItemArray = objs;
            //ryzddata.Rows.InsertAt(dr, 0);
            cbx_zdbz.DisplayMember = "jbmc";
            cbx_zdbz.ValueMember = "flbm";
            cbx_zdbz.DataSource = dt2; 
            cbx_zdbz.SelectedValue = "0";
            cbx_zdbz1.DisplayMember = "jbmc";
            cbx_zdbz1.ValueMember = "flbm";
            cbx_zdbz1.DataSource = dt2; 
            cbx_zdbz1.SelectedValue = "0";
            cbx_zdbz2.DisplayMember = "jbmc";
            cbx_zdbz2.ValueMember = "flbm";
            cbx_zdbz2.DataSource = dt2;
            cbx_zdbz2.SelectedValue = "0";
            cbx_zdbz3.DisplayMember = "jbmc";
            cbx_zdbz3.ValueMember = "flbm";
            cbx_zdbz3.DataSource = dt2;
            cbx_zdbz3.SelectedValue = "0";
            cbx_zdbz4.DisplayMember = "jbmc";
            cbx_zdbz4.ValueMember = "flbm";
            cbx_zdbz4.DataSource = dt2;
            cbx_zdbz4.SelectedValue = "0";
            cbx_zdbz5.DisplayMember = "jbmc";
            cbx_zdbz5.ValueMember = "flbm";
            cbx_zdbz5.DataSource = dt2;
            cbx_zdbz5.SelectedValue = "0";

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string zdbz="";
            string zdbz1="";
            string zdbz2="";
            string zdbz3="";
            string zdbz4="";
            string zdbz5="";
            string zdbm="";
            string zdbm1="";
            string zdbm2="";
            string zdbm3="";
            string zdbm4="";
            string zdbm5="";
            if (!string.IsNullOrEmpty(cbx_zdbz.Text))
            {
                zdbm = cbx_zdbz.SelectedValue.ToString();
                zdbz = cbx_zdbz.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz1.Text))
            {
                zdbm1 = cbx_zdbz1.SelectedValue.ToString();
                zdbz1 = cbx_zdbz1.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz2.Text))
            {
                zdbm2 = cbx_zdbz2.SelectedValue.ToString();
                zdbz2 = cbx_zdbz2.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz3.Text))
            {
                zdbm3 = cbx_zdbz3.SelectedValue.ToString();
                zdbz3 = cbx_zdbz3.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz4.Text))
            {
                zdbm4 = cbx_zdbz4.SelectedValue.ToString();
                zdbz4 = cbx_zdbz4.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz5.Text))
            {
                zdbm5 = cbx_zdbz5.SelectedValue.ToString();
                zdbz5 = cbx_zdbz5.Text;
            }
            string xml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            xml += "<DATA>";
            xml += "<BILLNO>"+tbx_jzsxh.Text+"</BILLNO>";
            xml += "<PERSONCODE>"+tbx_grbh.Text+"</PERSONCODE>";
            xml += "<OPERATOR>" + ProgramGlobal.User_id + "</OPERATOR>";
            xml += "<DODATE>" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss") + "</DODATE>";
                    xml+="<DRID>"+tbx_yssfzh.Text+"</DRID>";
                    xml+="<DIAGID>"+zdbm+"</DIAGID>";
                    xml+="<DIAGNAME>"+zdbz+"</DIAGNAME>";
                    xml += "<DIAGID1>" + zdbm1 + "</DIAGID1>";
                    xml += "<DIAGNAME1>" + zdbz1 + "</DIAGNAME1>";
                    xml += "<DIAGID2>" + zdbm2 + "</DIAGID2>";
                    xml += "<DIAGNAME2>" + zdbz2 + "</DIAGNAME2>";
                    xml += "<DIAGID3>" + zdbm3 + "</DIAGID3>";
                    xml += "<DIAGNAME3>" + zdbz3 + "</DIAGNAME3>";
                    xml += "<DIAGID4>" + zdbm4 + "</DIAGID4>";
                    xml += "<DIAGNAME4>" + zdbz4 + "</DIAGNAME4>";
                    xml += "<DIAGID5>" + zdbm5 + "</DIAGID5>";
                    xml += "<DIAGNAME5>" + zdbz5 + "</DIAGNAME5>";
                    xml += "</DATA>";
                    //if (Syb_Ryzdinfo(xml) == "")
                    //{
                    //    MessageBox.Show("添加失败");
                    //}
                    String outXml = Syb_Ryzdinfo(xml);
                    StringReader sr = new StringReader(outXml);
                    DataSet ds = new DataSet();
                    ds.ReadXml(sr);
                    string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString();//状态码
                    string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString();//错误信息
                    string handledate = ds.Tables["DATA"].Rows[0]["HANDLEDATE"].ToString();//系统处理时间
                    if (!flag.Equals("0"))
                    {
                        MessageBox.Show(info);
                    }
                    else
                    {
                        string sql = "select * from sybwszd where mtzyjl=" + Mtzyjliid.ToString();
                        DataTable dt = BllMain.Db.Select(sql).Tables[0];
                        string sql2 = "";
                        if (dt.Rows.Count == 0)
                        {
                            sql2 = "insert into sybwszd (mtzyjl,ryzd,cyzd) values (" + Mtzyjliid + ",1,0)";
                        }
                        else
                        {
                            sql2 = "update sybwszd set ryzd=1 where mtzyjl=" + Mtzyjliid;
                        }
                        BllMain.Db.Update(sql2);
                        MessageBox.Show("更新入院诊断成功");
                        this.Dispose();
                    }


        }
        /// <summary>
        /// 市医保入院登记  
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public String Syb_Ryzdinfo(string inXml)
        {
            String GenParam1 = "";
            String GenParam2 = "";
            Dictionary<String, String> dic = GetJm(inXml);
            dic.TryGetValue("GenParam1", out GenParam1);
            dic.TryGetValue("GenParam2", out GenParam2);
            if (!Judge_Visitor.judge())
                return "";
            hospcs.setAppServer(ip, "HospCOMSvr.HospCOMServer");
            //String obj = hospcs.UPDATEHOSPREG(GenParam1, GenParam2);
            //Judge_Visitor.update();

            String jiemi ="";
            syswritelogsxml.writeLogs("市医保获得个人信息", DateTime.Now, jiemi);
            return jiemi;
        }
        /// <summary>
        /// 加密函数
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, String> GetJm(String str)
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();
            dic.Add("GenParam1", hisdec.GenParam1(str).ToString());
            dic.Add("GenParam2", hisdec.GenParam2(str).ToString());
            return dic;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <returns></returns>
        public String GetDecrypt(String str)
        {
            String Strret = hisdec.Decrypto(str).ToString();

            return Strret;
        }

       
        //
        private void cbx_zdbz_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz.Text);
                cbx_zdbz.DataSource = ryzddata;
                cbx_zdbz.DisplayMember = "jbmc";
                cbx_zdbz.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz1.Text);
                cbx_zdbz1.DataSource = ryzddata;
                cbx_zdbz1.DisplayMember = "jbmc";
                cbx_zdbz1.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz2.Text);
                cbx_zdbz2.DataSource = ryzddata;
                cbx_zdbz2.DisplayMember = "jbmc";
                cbx_zdbz2.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz3.Text);
                cbx_zdbz3.DataSource = ryzddata;
                cbx_zdbz3.DisplayMember = "jbmc";
                cbx_zdbz3.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz4.Text);
                cbx_zdbz4.DataSource = ryzddata;
                cbx_zdbz4.DisplayMember = "jbmc";
                cbx_zdbz4.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz5.Text);
                cbx_zdbz5.DataSource = ryzddata;
                cbx_zdbz5.DisplayMember = "jbmc";
                cbx_zdbz5.ValueMember = "flbm"; 
            }
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public DataTable GetIcd(String where)
        {
            String sql = "  select flbm,flmc as jbmc  from idc_jb_bz where flbm like '%" + where + "%' or flmc like '%" + where + "%';";
            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable GetIcd()
        {
            String sql = " select flbm,jbmc,pybm from idc_jb where isdelete=0";
            return BllMain.Db.Select(sql).Tables[0];
        }
    }
}
