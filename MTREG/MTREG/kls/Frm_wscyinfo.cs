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
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_wscyinfo : Form
    {
        public Frm_wscyinfo()
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
        private void Frm_wscyinfo_Load(object sender, EventArgs e)
        {
            getinfo();
            inibzxx();
        }
        public void getinfo()
        {

            string sql = "select insur_gysyb_zy.billno,insur_gysyb_zy.personcode,inhospital.name as fullname,bas_doctor.cardid as ssn,inhospital.Outdiagn as jblb from insur_gysyb_zy,inhospital, bas_doctor where inhospital.doctor_id=bas_doctor.id  and insur_gysyb_zy.mtzyjliid=inhospital.id  and mtzyjliid=" + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            tbx_jzsxh.Text = dt.Rows[0]["billno"].ToString();
            tbx_grbh.Text = dt.Rows[0]["personcode"].ToString();
            lblxm.Text = dt.Rows[0]["fullname"].ToString();
            tbx_yssfzh.Text = dt.Rows[0]["ssn"].ToString();
            tbxZd.Text = dt.Rows[0]["jblb"].ToString();
            if (tbxZd.Text != "")
            {
                cbx_zdbz.DisplayMember = "jbmc";
                cbx_zdbz.ValueMember = "flbm";
                cbx_zdbz.DataSource = GetIcd(dt.Rows[0]["jblb"].ToString());
            }

            string sql2 = "select diagnname as zdname,diagnICD as icdbm from ihsp_diagnmes where   diagnKind = 'OUT' and ihsp_id=" + Mtzyjliid.ToString();
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

            string sql3 = "select oper_recorddet.name as bcjlssczmc2,oper_recorddet.opicd as  bcjlssczbm2 "
            + "from oper_recorddet where oper_recorddet.ihsp_id  andoper_recorddet.ihsp_id=" + Mtzyjliid.ToString() + " order by oper_recorddet.id desc";
            DataTable dt3 = BllMain.Db.Select(sql3).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                tbxSs.Text = dt3.Rows[0]["bcjlssczmc2"].ToString();
                cbx_scss.DisplayMember = "ssmc";
                cbx_scss.ValueMember = "flbm";
                if (dt3.Rows[0]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_scss.DataSource = getSsIcd(dt3.Rows[0]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 1)
            {
                tbxSs2.Text = dt3.Rows[1]["bcjlssczmc2"].ToString();
                cbx_2css.DisplayMember = "ssmc";
                cbx_2css.ValueMember = "flbm";
                if (dt3.Rows[1]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_2css.DataSource = getSsIcd(dt3.Rows[1]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 2)
            {
                tbxSs3.Text = dt3.Rows[2]["bcjlssczmc2"].ToString();
                cbx_3css.DisplayMember = "ssmc";
                cbx_3css.ValueMember = "flbm";
                if (dt3.Rows[2]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_3css.DataSource = getSsIcd(dt3.Rows[2]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 3)
            {
                tbxSs4.Text = dt3.Rows[3]["bcjlssczmc2"].ToString();
                cbx_4css.DisplayMember = "ssmc";
                cbx_4css.ValueMember = "flbm";
                if (dt3.Rows[3]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_4css.DataSource = getSsIcd(dt3.Rows[3]["bcjlssczbm2"].ToString());
                }
            }

            if (dt3.Rows.Count > 4)
            {
                tbxSs5.Text = dt3.Rows[4]["bcjlssczmc2"].ToString();
                cbx_5css.DisplayMember = "ssmc";
                cbx_5css.ValueMember = "flbm";
                if (dt3.Rows[4]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_5css.DataSource = getSsIcd(dt3.Rows[4]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 5)
            {

                tbxSs6.Text = dt3.Rows[5]["bcjlssczmc2"].ToString();
                cbx_6css.DisplayMember = "ssmc";
                cbx_6css.ValueMember = "flbm";
                if (dt3.Rows[5]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_6css.DataSource = getSsIcd(dt3.Rows[5]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 6)
            {
                tbxSs7.Text = dt3.Rows[6]["bcjlssczmc2"].ToString();
                cbx_7css.DisplayMember = "ssmc";
                cbx_7css.ValueMember = "flbm";
                if (dt3.Rows[6]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_7css.DataSource = getSsIcd(dt3.Rows[6]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 7)
            {
                tbxSs8.Text = dt3.Rows[7]["bcjlssczmc2"].ToString();
                cbx_8css.DisplayMember = "ssmc";
                cbx_8css.ValueMember = "flbm";
                if (dt3.Rows[7]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_8css.DataSource = getSsIcd(dt3.Rows[7]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 8)
            {
                tbxSs9.Text = dt3.Rows[8]["bcjlssczmc2"].ToString();
                cbx_9css.DisplayMember = "ssmc";
                cbx_9css.ValueMember = "flbm";
                if (dt3.Rows[8]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_9css.DataSource = getSsIcd(dt3.Rows[8]["bcjlssczbm2"].ToString());
                }
            }
            if (dt3.Rows.Count > 9)
            {
                tbxSs10.Text = dt3.Rows[9]["bcjlssczmc2"].ToString();
                cbx_10css.DisplayMember = "ssmc";
                cbx_10css.ValueMember = "flbm";
                if (dt3.Rows[9]["bcjlssczbm2"].ToString() != "")
                {
                    cbx_10css.DataSource = getSsIcd(dt3.Rows[9]["bcjlssczbm2"].ToString());
                }
            }
            string sql4 = "select cyzd from sybwszd where mtzyjl=" + Mtzyjliid;
            DataTable dt4 = BllMain.Db.Select(sql4).Tables[0];
            if (dt4.Rows.Count > 0)
            {
                string ryzd = dt4.Rows[0]["cyzd"].ToString();
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
            string sql = "select distinct bcjlssczbm,bcjlssczmc from mtbcjl where bcjljllb=1 and mtzyjl= " + mtzyjliid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < 16; i++)
            {
                if (i < dt.Rows.Count)
                    ss.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                else
                    ss.Add(i.ToString(),null);
            }
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

            string ssmc1 = "";
            string ssmc2 = "";
            string ssmc3 = "";
            string ssmc4 = "";
            string ssmc5 = "";
            string ssmc6 = "";
            string ssmc7 = "";
            string ssmc8 = "";
            string ssmc9 = "";
            string ssmc10 = "";

            string ssbm1 = "";
            string ssbm2 = "";
            string ssbm3 = "";
            string ssbm4 = "";
            string ssbm5 = "";
            string ssbm6 = "";
            string ssbm7 = "";
            string ssbm8 = "";
            string ssbm9 = "";
            string ssbm10 = "";

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

            if (!string.IsNullOrEmpty(cbx_scss.Text))
            {
                ssbm1 = cbx_scss.SelectedValue.ToString();
                ssmc1 = cbx_scss.Text;
            }
            if (!string.IsNullOrEmpty(cbx_2css.Text))
            {
                ssbm2 = cbx_2css.SelectedValue.ToString();
                ssmc2 = cbx_2css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_3css.Text))
            {
                ssbm3 = cbx_3css.SelectedValue.ToString();
                ssmc3 = cbx_3css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_4css.Text))
            {
                ssbm4 = cbx_4css.SelectedValue.ToString();
                ssmc4 = cbx_4css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_5css.Text))
            {
                ssbm5 = cbx_5css.SelectedValue.ToString();
                ssmc5 = cbx_5css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_6css.Text))
            {
                ssbm6 = cbx_6css.SelectedValue.ToString();
                ssmc6 = cbx_6css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_7css.Text))
            {
                ssbm7 = cbx_7css.SelectedValue.ToString();
                ssmc7 = cbx_7css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_8css.Text))
            {
                ssbm8 = cbx_8css.SelectedValue.ToString();
                ssmc8 = cbx_8css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_8css.Text))
            {
                ssbm8 = cbx_8css.SelectedValue.ToString();
                ssmc8 = cbx_8css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_9css.Text))
            {
                ssbm9 = cbx_9css.SelectedValue.ToString();
                ssmc9 = cbx_9css.Text;
            }
            if (!string.IsNullOrEmpty(cbx_10css.Text))
            {
                ssbm10 = cbx_10css.SelectedValue.ToString();
                ssmc10 = cbx_10css.Text;
            }

            string xml = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            xml += "<DATA>";
            xml += "<BILLNO>" + tbx_jzsxh.Text + "</BILLNO>";
            xml += "<PERSONCODE>" + tbx_grbh.Text + "</PERSONCODE>";
            xml += "<OPERATOR>" + ProgramGlobal.User_id + "</OPERATOR>";
            xml += "<DODATE>" + Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd HH:mm:ss") + "</DODATE>";
            xml += "<DRID>" + tbx_yssfzh.Text + "</DRID>";
            xml += "<DIAGID>" + zdbm + "</DIAGID>";
            xml += "<DIAGNAME>" + zdbz + "</DIAGNAME>";
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
            xml += "<DIAGID6>" + zdbm6 + "</DIAGID6>";
            xml += "<DIAGNAME6>" + zdbz6 + "</DIAGNAME6>";
            xml += "<DIAGID7>" + zdbm7 + "</DIAGID7>";
            xml += "<DIAGNAME7>" + zdbz7 + "</DIAGNAME7>";
            xml += "<DIAGID8>" + zdbm8 + "</DIAGID8>";
            xml += "<DIAGNAME8>" + zdbz8 + "</DIAGNAME8>";
            xml += "<DIAGID9>" + zdbm9 + "</DIAGID9>";
            xml += "<DIAGNAME9>" + zdbz9 + "</DIAGNAME9>";
            xml += "<DIAGID10>" + zdbm10 + "</DIAGID10>";
            xml += "<DIAGNAME10>" + zdbz10 + "</DIAGNAME10>"; 
            xml += "<DIAGID11>" + zdbm11 + "</DIAGID11>";
            xml += "<DIAGNAME11>" + zdbz11 + "</DIAGNAME11>";
            xml += "<DIAGID12>" + zdbm12 + "</DIAGID12>";
            xml += "<DIAGNAME12>" + zdbz12 + "</DIAGNAME12>";
            xml += "<DIAGID13>" + zdbm13 + "</DIAGID13>";
            xml += "<DIAGNAME13>" + zdbz13 + "</DIAGNAME13>";
            xml += "<DIAGID14>" + zdbm14 + "</DIAGID14>";
            xml += "<DIAGNAME14>" + zdbz14 + "</DIAGNAME14>";
            xml += "<DIAGID15>" + zdbm15 + "</DIAGID15>";
            xml += "<DIAGNAME15>" + zdbz15 + "</DIAGNAME15>";
            List<string> list=new List<string>(ss.Keys);
            xml += "<OPITEMCODE1>" + ssbm1 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc1 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm2 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc2 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm3 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc3 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm4 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc4 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm5 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc5 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm6 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc6 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm7 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc7 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm8 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc8 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm9 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc9 + "</OPITEMNAME1>";
            xml += "<OPITEMCODE1>" + ssbm10 + "</OPITEMCODE1><OPITEMNAME1>" + ssmc10 + "</OPITEMNAME1>";

            //if (!string.IsNullOrEmpty(ss[list[0]]))
            //    xml += "<OPITEMCODE1>" + list[0] + "</OPITEMCODE1><OPITEMNAME1>" + ss[list[0]] + "</OPITEMNAME1>";
            //else
            //    xml += "<OPITEMCODE1></OPITEMCODE1><OPITEMNAME1></OPITEMNAME1>";
            //if (!string.IsNullOrEmpty(ss[list[1]]))
            //    xml += "<OPITEMCODE2>" + list[1] + "</OPITEMCODE2><OPITEMNAME2>" + ss[list[1]] + "</OPITEMNAME2>";
            //else
            //    xml += "<OPITEMCODE2></OPITEMCODE2><OPITEMNAME2></OPITEMNAME2>";
            //if (!string.IsNullOrEmpty(ss[list[2]]))
            //    xml += "<OPITEMCODE3>" + list[2] + "</OPITEMCODE3><OPITEMNAME3>" + ss[list[2]] + "</OPITEMNAME3>";
            //else
            //    xml += "<OPITEMCODE3></OPITEMCODE3><OPITEMNAME3></OPITEMNAME3>";
            //if (!string.IsNullOrEmpty(ss[list[3]]))
            //    xml += "<OPITEMCODE4>" + list[3] + "</OPITEMCODE4><OPITEMNAME4>" + ss[list[3]] + "</OPITEMNAME4>";
            //else
            //    xml += "<OPITEMCODE4></OPITEMCODE4><OPITEMNAME4></OPITEMNAME4>";
            //if (!string.IsNullOrEmpty(ss[list[4]]))
            //    xml += "<OPITEMCODE5>" + list[4] + "</OPITEMCODE5><OPITEMNAME5>" + ss[list[4]] + "</OPITEMNAME5>";
            //else
            //    xml += "<OPITEMCODE5></OPITEMCODE5><OPITEMNAME5></OPITEMNAME5>";
            //if (!string.IsNullOrEmpty(ss[list[5]]))
            //    xml += "<OPITEMCODE6>" + list[5] + "</OPITEMCODE6><OPITEMNAME6>" + ss[list[5]] + "</OPITEMNAME6>";
            //else
            //    xml += "<OPITEMCODE6></OPITEMCODE6><OPITEMNAME6></OPITEMNAME6>";
            //if (!string.IsNullOrEmpty(ss[list[6]]))
            //    xml += "<OPITEMCODE7>" + list[6] + "</OPITEMCODE7><OPITEMNAME7>" + ss[list[6]] + "</OPITEMNAME7>";
            //else
            //    xml += "<OPITEMCODE7></OPITEMCODE7><OPITEMNAME7></OPITEMNAME7>";
            //if (!string.IsNullOrEmpty(ss[list[7]]))
            //    xml += "<OPITEMCODE8>" + list[7] + "</OPITEMCODE8><OPITEMNAME8>" + ss[list[7]] + "</OPITEMNAME8>";
            //else
            //    xml += "<OPITEMCODE8></OPITEMCODE8><OPITEMNAME8></OPITEMNAME8>";
            //if (!string.IsNullOrEmpty(ss[list[8]]))
            //    xml += "<OPITEMCODE9>" + list[8] + "</OPITEMCODE9><OPITEMNAME9>" + ss[list[8]] + "</OPITEMNAME9>";
            //else
            //    xml += "<OPITEMCODE9></OPITEMCODE9><OPITEMNAME9></OPITEMNAME9>"; 
            //if (!string.IsNullOrEmpty(ss[list[9]]))
            //    xml += "<OPITEMCODE10>" + list[9] + "</OPITEMCODE10><OPITEMNAME10>" + ss[list[9]] + "</OPITEMNAME10>";
            //else
            //    xml += "<OPITEMCODE10></OPITEMCODE10><OPITEMNAME10></OPITEMNAME10>";
            xml += "</DATA>";
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
                string sql3 = "select * from sybwszd where mtzyjl=" + Mtzyjliid.ToString();
                DataTable dt3 = BllMain.Db.Select(sql3).Tables[0];
                string sql2 = "";
                if (dt3.Rows.Count == 0)
                {
                    sql2 = "insert into sybwszd (mtzyjl,ryzd,cyzd) values (" + Mtzyjliid + ",0,1)";
                }
                else
                {
                    sql2 = "update sybwszd set cyzd=1 where mtzyjl=" + Mtzyjliid;
                }
                BllMain.Db.Update(sql2);
                MessageBox.Show("出院诊断上传成功");
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
            //String obj = hospcs.UPDATEHOSPOUT(GenParam1, GenParam2);
            Judge_Visitor.update();

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

        private void cbx_scss_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_scss.DisplayMember = "ssmc";
            cbx_scss.ValueMember = "flbm";
            cbx_scss.DataSource = getSsIcd(cbx_scss.Text);
        }

        private void cbx_2css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_2css.DisplayMember = "ssmc";
            cbx_2css.ValueMember = "flbm";
            cbx_2css.DataSource = getSsIcd(cbx_2css.Text);
        }

        private void cbx_3css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_3css.DisplayMember = "ssmc";
            cbx_3css.ValueMember = "flbm";
            cbx_3css.DataSource = getSsIcd(cbx_3css.Text);
        }

        private void cbx_4css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_4css.DisplayMember = "ssmc";
            cbx_4css.ValueMember = "flbm";
            cbx_4css.DataSource = getSsIcd(cbx_4css.Text);
        }

        private void cbx_5css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_5css.DisplayMember = "ssmc";
            cbx_5css.ValueMember = "flbm";
            cbx_5css.DataSource = getSsIcd(cbx_5css.Text);
        }

        private void cbx_6css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_6css.DisplayMember = "ssmc";
            cbx_6css.ValueMember = "flbm";
            cbx_6css.DataSource = getSsIcd(cbx_6css.Text);
        }

        private void cbx_7css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_7css.DisplayMember = "ssmc";
            cbx_7css.ValueMember = "flbm";
            cbx_7css.DataSource = getSsIcd(cbx_7css.Text);
        }

        private void cbx_8css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_8css.DisplayMember = "ssmc";
            cbx_8css.ValueMember = "flbm";
            cbx_8css.DataSource = getSsIcd(cbx_8css.Text);
        }

        private void cbx_9css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_9css.DisplayMember = "ssmc";
            cbx_9css.ValueMember = "flbm";
            cbx_9css.DataSource = getSsIcd(cbx_9css.Text);
        }

        private void cbx_10css_KeyUp(object sender, KeyEventArgs e)
        {
            
            cbx_10css.DisplayMember = "ssmc";
            cbx_10css.ValueMember = "flbm";
            cbx_10css.DataSource = getSsIcd(cbx_10css.Text);
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
        public DataTable getSsIcd(String bm)
        {
            string sql = " select flbm,flmc as ssmc from idc_ss_bz where flmc like '%" + bm + "%'";
            return BllMain.Db.Select(sql).Tables[0];
        }
    }
}
