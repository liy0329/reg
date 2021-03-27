using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospCS;
using MTREG.medinsur.gzsyb.Util;
using HISDECDRYTO;
using System.IO;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb.bo;
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_sybwscyinfo : Form
    {
        public Frm_sybwscyinfo()
        {
            InitializeComponent();
        }
        HospCS.bean hospcs = new bean();
        SysWriteLogsxml syswritelogsxml = new SysWriteLogsxml();
        public String ip = "10.169.14.117";
        //public String ip = "10.169.6.50";
        HISDEC hisdec = new HISDEC();
        GzsybInterface gzsybInterface = new GzsybInterface();


        private string mtzyjliid;

        public string Mtzyjliid
        {
            get { return mtzyjliid; }
            set { mtzyjliid = value; }
        }
        private void Frm_wscyinfo_Load(object sender, EventArgs e)
        {
            getinfo();
            inibzxx();
        }
        public void getinfo()
        {
            
            string sql = "select hz.fullname,ys.ssn,mtszks.jblb from mtzyjl,ctct hz,ctct ys,cimsuser,mtszks where mtzyjl.iid=mtszks.mtzyjl and mtszks.isactive=1 and mtszks.iscurrent=1 and mtzyjl.zyjlzyys=cimsuser.iid and cimsuser.ctct=ys.iid and mtzyjl.ctct=hz.iid and mtzyjl.iid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            lblxm.Text = dt.Rows[0]["fullname"].ToString();
            tbxZd.Text = dt.Rows[0]["jblb"].ToString();
            if (tbxZd.Text != "")
            {
                cbx_zdbz.DisplayMember = "jbmc";
                cbx_zdbz.ValueMember = "flbm";
                cbx_zdbz.DataSource = GetIcd(dt.Rows[0]["jblb"].ToString());
            }
            string sql3 = "select akc190,yab003,aka130,aac001,ykb065 from insur_gzsyb_ryinfo where mtzyjliid=" + Mtzyjliid.ToString();
            DataTable dt3 = BllMain.Db.Select(sql3).Tables[0];
            tbx_jzsxh.Text = dt3.Rows[0]["akc190"].ToString();
            tbx_grbh.Text = dt3.Rows[0]["aac001"].ToString();
            tbxYybm.Text = "020023";
            tbxFzxbh.Text = dt3.Rows[0]["yab003"].ToString();
            tbxShbxbf.Text = dt3.Rows[0]["ykb065"].ToString();
            tbxZflb.Text = dt3.Rows[0]["aka130"].ToString();
            


            string sql2 = "select zdname,icdbm from mtzhzd where zyjl="+Mtzyjliid.ToString();
            DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                tbxZd1.Text = dt2.Rows[0]["zdname"].ToString();
                cbx_zdbz1.DisplayMember = "jbmc";
                cbx_zdbz1.ValueMember = "flbm";
                if (dt2.Rows[0]["zdname"].ToString() != "")
                {
                    cbx_zdbz1.DataSource = GetIcd(dt2.Rows[0]["zdname"].ToString());
                }

            }
            if (dt2.Rows.Count > 1)
            {
                tbxZd2.Text = dt2.Rows[1]["zdname"].ToString();
                cbx_zdbz2.DisplayMember = "jbmc";
                cbx_zdbz2.ValueMember = "flbm";
                if (dt2.Rows[1]["zdname"].ToString() != "")
                {
                    cbx_zdbz2.DataSource = GetIcd(dt2.Rows[1]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 2)
            {
                tbxZd3.Text = dt2.Rows[2]["zdname"].ToString();
                cbx_zdbz3.DisplayMember = "jbmc";
                cbx_zdbz3.ValueMember = "flbm";
                if (dt2.Rows[2]["zdname"].ToString() != "")
                {
                    cbx_zdbz3.DataSource = GetIcd(dt2.Rows[2]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 3)
            {
                tbxZd4.Text = dt2.Rows[3]["zdname"].ToString();
                cbx_zdbz4.DisplayMember = "jbmc";
                cbx_zdbz4.ValueMember = "flbm";
                if (dt2.Rows[3]["zdname"].ToString() != "")
                {
                    cbx_zdbz4.DataSource = GetIcd(dt2.Rows[3]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 4)
            {
                tbxZd5.Text = dt2.Rows[4]["zdname"].ToString();
                cbx_zdbz5.DisplayMember = "jbmc";
                cbx_zdbz5.ValueMember = "flbm";
                if (dt2.Rows[4]["zdname"].ToString() != "")
                {
                    cbx_zdbz5.DataSource = GetIcd(dt2.Rows[4]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 5)
            {
                tbxZd6.Text = dt2.Rows[5]["zdname"].ToString();
                cbx_zdbz6.DisplayMember = "jbmc";
                cbx_zdbz6.ValueMember = "flbm";
                if (dt2.Rows[5]["zdname"].ToString() != "")
                {
                    cbx_zdbz6.DataSource = GetIcd(dt2.Rows[5]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 6)
            {
                tbxZd7.Text = dt2.Rows[6]["zdname"].ToString();
                cbx_zdbz7.DisplayMember = "jbmc";
                cbx_zdbz7.ValueMember = "flbm";
                if (dt2.Rows[6]["zdname"].ToString() != "")
                {
                    cbx_zdbz7.DataSource = GetIcd(dt2.Rows[6]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 7)
            {
                tbxZd8.Text = dt2.Rows[7]["zdname"].ToString();
                cbx_zdbz8.DisplayMember = "jbmc";
                cbx_zdbz8.ValueMember = "flbm";
                if (dt2.Rows[7]["zdname"].ToString() != "")
                {
                    cbx_zdbz8.DataSource = GetIcd(dt2.Rows[7]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 8)
            {
                tbxZd9.Text = dt2.Rows[8]["zdname"].ToString();
                cbx_zdbz9.DisplayMember = "jbmc";
                cbx_zdbz9.ValueMember = "flbm";
                if (dt2.Rows[8]["zdname"].ToString() != "")
                {
                    cbx_zdbz9.DataSource = GetIcd(dt2.Rows[8]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 9)
            {
                tbxZd10.Text = dt2.Rows[9]["zdname"].ToString();
                cbx_zdbz10.DisplayMember = "jbmc";
                cbx_zdbz10.ValueMember = "flbm";
                if (dt2.Rows[9]["zdname"].ToString() != "")
                {
                    cbx_zdbz10.DataSource = GetIcd(dt2.Rows[9]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 10)
            {
                tbxZd11.Text = dt2.Rows[10]["zdname"].ToString();
                cbx_zdbz11.DisplayMember = "jbmc";
                cbx_zdbz11.ValueMember = "flbm";
                if (dt2.Rows[10]["zdname"].ToString() != "")
                {
                    cbx_zdbz11.DataSource = GetIcd(dt2.Rows[10]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 11)
            {
                tbxZd12.Text = dt2.Rows[11]["zdname"].ToString();
                cbx_zdbz12.DisplayMember = "jbmc";
                cbx_zdbz12.ValueMember = "flbm";
                if (dt2.Rows[11]["zdname"].ToString() != "")
                {
                    cbx_zdbz12.DataSource = GetIcd(dt2.Rows[11]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 12)
            {
                tbxZd13.Text = dt2.Rows[12]["zdname"].ToString();
                cbx_zdbz13.DisplayMember = "jbmc";
                cbx_zdbz13.ValueMember = "flbm";
                if (dt2.Rows[12]["zdname"].ToString() != "")
                {
                    cbx_zdbz13.DataSource = GetIcd(dt2.Rows[12]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 13)
            {
                tbxZd14.Text = dt2.Rows[13]["zdname"].ToString();
                cbx_zdbz14.DisplayMember = "jbmc";
                cbx_zdbz14.ValueMember = "flbm";
                if (dt2.Rows[13]["zdname"].ToString() != "")
                {
                    cbx_zdbz14.DataSource = GetIcd(dt2.Rows[13]["zdname"].ToString());
                }
            }
            if (dt2.Rows.Count > 14)
            {
                tbxZd15.Text = dt2.Rows[14]["zdname"].ToString();
                cbx_zdbz15.DisplayMember = "jbmc";
                cbx_zdbz15.ValueMember = "flbm";
                if (dt2.Rows[14]["zdname"].ToString() != "")
                {
                    cbx_zdbz15.DataSource = GetIcd(dt2.Rows[14]["zdname"].ToString());
                }
            }



        }
        public void inibzxx()
        {
            object[] objs = { "0", null };
            DataTable dt = new DataTable();
            DataRow dr;

            return;
            
            //DataTable ryzddata = new DataTable();
            //ryzddata = GetIcd();
            //dr = ryzddata.NewRow();
            //dr.ItemArray = objs;
            //ryzddata.Rows.InsertAt(dr, 0);
            cbx_zdbz.DisplayMember = "jbmc";
            cbx_zdbz.ValueMember = "flbm";
            cbx_zdbz.DataSource = GetIcd();
            cbx_zdbz.SelectedValue = "0";
            cbx_zdbz1.DisplayMember = "jbmc";
            cbx_zdbz1.ValueMember = "flbm";
            cbx_zdbz1.DataSource = GetIcd();
            cbx_zdbz1.SelectedValue = "0";
            cbx_zdbz2.DisplayMember = "jbmc";
            cbx_zdbz2.ValueMember = "flbm";
            cbx_zdbz2.DataSource = GetIcd();
            cbx_zdbz2.SelectedValue = "0";
            cbx_zdbz3.DisplayMember = "jbmc";
            cbx_zdbz3.ValueMember = "flbm";
            cbx_zdbz3.DataSource = GetIcd();
            cbx_zdbz3.SelectedValue = "0";
            cbx_zdbz4.DisplayMember = "jbmc";
            cbx_zdbz4.ValueMember = "flbm";
            cbx_zdbz4.DataSource = GetIcd();
            cbx_zdbz4.SelectedValue = "0";
            cbx_zdbz5.DisplayMember = "jbmc";
            cbx_zdbz5.ValueMember = "flbm";
            cbx_zdbz5.DataSource = GetIcd();
            cbx_zdbz5.SelectedValue = "0"; 
            cbx_zdbz6.DisplayMember = "jbmc";
            cbx_zdbz6.ValueMember = "flbm";
            cbx_zdbz6.DataSource = GetIcd();
            cbx_zdbz6.SelectedValue = "0";
            cbx_zdbz7.DisplayMember = "jbmc";
            cbx_zdbz7.ValueMember = "flbm";
            cbx_zdbz7.DataSource = GetIcd();
            cbx_zdbz7.SelectedValue = "0";
            cbx_zdbz8.DisplayMember = "jbmc";
            cbx_zdbz8.ValueMember = "flbm";
            cbx_zdbz8.DataSource = GetIcd();
            cbx_zdbz8.SelectedValue = "0";
            cbx_zdbz9.DisplayMember = "jbmc";
            cbx_zdbz9.ValueMember = "flbm";
            cbx_zdbz9.DataSource = GetIcd();
            cbx_zdbz9.SelectedValue = "0";
            cbx_zdbz10.DisplayMember = "jbmc";
            cbx_zdbz10.ValueMember = "flbm";
            cbx_zdbz10.DataSource = GetIcd();
            cbx_zdbz10.SelectedValue = "0";
            cbx_zdbz11.DisplayMember = "jbmc";
            cbx_zdbz11.ValueMember = "flbm";
            cbx_zdbz11.DataSource = GetIcd();
            cbx_zdbz11.SelectedValue = "0";
            cbx_zdbz12.DisplayMember = "jbmc";
            cbx_zdbz12.ValueMember = "flbm";
            cbx_zdbz12.DataSource = GetIcd();
            cbx_zdbz12.SelectedValue = "0";
            cbx_zdbz13.DisplayMember = "jbmc";
            cbx_zdbz13.ValueMember = "flbm";
            cbx_zdbz13.DataSource = GetIcd();
            cbx_zdbz13.SelectedValue = "0";
            cbx_zdbz14.DisplayMember = "jbmc";
            cbx_zdbz14.ValueMember = "flbm";
            cbx_zdbz14.DataSource = GetIcd();
            cbx_zdbz14.SelectedValue = "0";
            cbx_zdbz15.DisplayMember = "jbmc";
            cbx_zdbz15.ValueMember = "flbm";
            cbx_zdbz15.DataSource = GetIcd();
            cbx_zdbz15.SelectedValue = "0"; 
        }
        public void inissinfo()
        { 
            
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> ss = new Dictionary<string, string>();
            //string sql = "select distinct bcjlssczbm,bcjlssczmc from mtbcjl where bcjljllb=1 and mtzyjl= " + mtzyjliid;
            //DataTable dt = BllMain.db.Select(sql).Tables[0];
            //for (int i = 0; i < 16; i++)
            //{
            //    if (i < dt.Rows.Count)
            //        ss.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            //    else
            //        ss.Add(i.ToString(),null);
            //}
            string zdbz = "";
            string zdbz1 = "";
            string zdbz2 = "";
            string zdbz3 = "";
            string zdbz4 = "";
            string zdbz5 = "";
            string zdbz6 = "";
            string zdbz7 = "";
            string zdbz8 = "";
            string zdbz9 = "";
            string zdbz10 = "";
            string zdbz11 = "";
            string zdbz12 = "";
            string zdbz13 = "";
            string zdbz14 = "";
            string zdbz15 = "";
            string zdbm = "";
            string zdbm1 = "";
            string zdbm2 = "";
            string zdbm3 = "";
            string zdbm4 = "";
            string zdbm5 = ""; 
            string zdbm6 = "";
            string zdbm7 = "";
            string zdbm8 = "";
            string zdbm9 = "";
            string zdbm10 = ""; 
            string zdbm11 = "";
            string zdbm12 = "";
            string zdbm13 = "";
            string zdbm14 = "";
            string zdbm15 = "";



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
            if (!string.IsNullOrEmpty(cbx_zdbz6.Text))
            {
                zdbm6 = cbx_zdbz6.SelectedValue.ToString();
                zdbz6 = cbx_zdbz6.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz7.Text))
            {
                zdbm7 = cbx_zdbz7.SelectedValue.ToString();
                zdbz7 = cbx_zdbz7.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz8.Text))
            {
                zdbm8 = cbx_zdbz8.SelectedValue.ToString();
                zdbz8 = cbx_zdbz8.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz9.Text))
            {
                zdbm9 = cbx_zdbz9.SelectedValue.ToString();
                zdbz9 = cbx_zdbz9.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz10.Text))
            {
                zdbm10 = cbx_zdbz10.SelectedValue.ToString();
                zdbz10 = cbx_zdbz10.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz11.Text))
            {
                zdbm11 = cbx_zdbz11.SelectedValue.ToString();
                zdbz11 = cbx_zdbz11.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz12.Text))
            {
                zdbm12 = cbx_zdbz12.SelectedValue.ToString();
                zdbz12 = cbx_zdbz12.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz13.Text))
            {
                zdbm13 = cbx_zdbz13.SelectedValue.ToString();
                zdbz13 = cbx_zdbz13.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz14.Text))
            {
                zdbm14 = cbx_zdbz14.SelectedValue.ToString();
                zdbz14 = cbx_zdbz14.Text;
            }
            if (!string.IsNullOrEmpty(cbx_zdbz15.Text))
            {
                zdbm15 = cbx_zdbz15.SelectedValue.ToString();
                zdbz15 = cbx_zdbz15.Text;
            }

            

            string xml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            xml += "<input>";
            xml += "<prm_akc190>" + tbx_jzsxh.Text + "</prm_akc190>";
            xml += "<prm_aac001>" + tbx_grbh.Text + "</prm_aac001>";
            xml += "<prm_akb020>" + tbxYybm.Text + "</prm_akb020>";
            xml += "<prm_yab003>" + tbxFzxbh.Text + "</prm_yab003>";
            xml += "<prm_aka130>" + tbxZflb.Text + "</prm_aka130>";
            xml += "<prm_ykb065>" + tbxShbxbf.Text + "</prm_ykb065>";
            xml += "<prm_ykd044>" + zdbm + "</prm_ykd044>";

            xml += "<prm_ykd018>" + zdbm1 + "</prm_ykd018>";

            xml += "<prm_ykd019>" + zdbm2 + "</prm_ykd019>";

            xml += "<prm_ykd020>" + zdbm3 + "</prm_ykd020>";

            xml += "<prm_ykd021>" + zdbm4 + "</prm_ykd021>";

            xml += "<prm_ykd022>" + zdbm5 + "</prm_ykd022>";

            xml += "<prm_ykd023>" + zdbm6 + "</prm_ykd023>";

            xml += "<prm_ykd024>" + zdbm7 + "</prm_ykd024>";

            xml += "<prm_ykd025>" + zdbm8 + "</prm_ykd025>";

            xml += "<prm_ykd026>" + zdbm9 + "</prm_ykd026>";

            xml += "<prm_ykd027>" + zdbm10 + "</prm_ykd027>";

            xml += "<prm_ykd028>" + zdbm11 + "</prm_ykd028>";

            xml += "<prm_ykd029>" + zdbm12 + "</prm_ykd029>";

            xml += "<prm_ykd030>" + zdbm13 + "</prm_ykd030>";

            xml += "<prm_ykd031>" + zdbm14 + "</prm_ykd031>";

            xml += "<prm_ykd032>" + zdbm15 + "</prm_ykd032>";
            xml += "<prm_ykd033></prm_ykd033>";
            xml += "<prm_ykd040></prm_ykd040>";
            xml += "<prm_ykd041></prm_ykd041>";
            xml += "<prm_ykd042></prm_ykd042>";
            xml += "<prm_ykd043></prm_ykd043>";
            xml += "<prm_ykd044></prm_ykd044>";
            xml += "<proxy>1</proxy>";
           
            xml += "</input>";
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "25a";//交易编号
            callIn.Astr_jysr_xml = xml;//交易输入
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
            string sql3 = "update insur_gzsyb_ryinfo set zdysc=1 where mtzyjliid='" + Mtzyjliid.ToString() + "'";
            BllMain.Db.Update(sql3);
            MessageBox.Show("出院诊断上传成功");
            this.Dispose();
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
            //String obj = hospcs.UPDATEHOSPOUT(GenParam1, GenParam2);
            Judge_Visitor.update();

            String jiemi = "";
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

        private void cbx_zdbz6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz6.Text);
                cbx_zdbz6.DataSource = ryzddata;
                cbx_zdbz6.DisplayMember = "jbmc";
                cbx_zdbz6.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz7_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz7.Text);
                cbx_zdbz7.DataSource = ryzddata;
                cbx_zdbz7.DisplayMember = "jbmc";
                cbx_zdbz7.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz8_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz8.Text);
                cbx_zdbz8.DataSource = ryzddata;
                cbx_zdbz8.DisplayMember = "jbmc";
                cbx_zdbz8.ValueMember = "flbm"; 
            }
        }

        private void cbx_zdbz9_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz9.Text);
                cbx_zdbz9.DataSource = ryzddata;
                cbx_zdbz9.DisplayMember = "jbmc";
                cbx_zdbz9.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz10.Text);
                cbx_zdbz10.DataSource = ryzddata;
                cbx_zdbz10.DisplayMember = "jbmc";
                cbx_zdbz10.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz11_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz11.Text);
                cbx_zdbz11.DataSource = ryzddata;
                cbx_zdbz11.DisplayMember = "jbmc";
                cbx_zdbz11.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz12_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz12.Text);
                cbx_zdbz12.DataSource = ryzddata;
                cbx_zdbz12.DisplayMember = "jbmc";
                cbx_zdbz12.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz13_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz13.Text);
                cbx_zdbz13.DataSource = ryzddata;
                cbx_zdbz13.DisplayMember = "jbmc";
                cbx_zdbz13.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz14_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz14.Text);
                cbx_zdbz14.DataSource = ryzddata;
                cbx_zdbz14.DisplayMember = "jbmc";
                cbx_zdbz14.ValueMember = "flbm";
            }
        }

        private void cbx_zdbz15_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                DataTable ryzddata = new DataTable();
                ryzddata = GetIcd(cbx_zdbz15.Text);
                cbx_zdbz15.DataSource = ryzddata;
                cbx_zdbz15.DisplayMember = "jbmc";
                cbx_zdbz15.ValueMember = "flbm";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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
