using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using System.Net;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh.bo;
//using System.Web.UI.WebControls;
using MTREG.ihsp;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.medinsur.gzsyb.listitem;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhdj : Form
    {
        public FrmGzsnhdj()
        {
            InitializeComponent();
        }

        private void frmnhdj_Load(object sender, EventArgs e)
        {
            inirydj();
        }
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        GzsnhRegInfo nhdj = new GzsnhRegInfo();
        WebClient webClient = new WebClient();
        private string sickname;

        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        private string zyh;

        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
       
        private string patienttypeId;

        public string PatienttypeId
        {
            get { return patienttypeId; }
            set { patienttypeId = value; }
        }
        
        private string state;//页面状态

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string ihsp_id; //住院记录IID
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        public void getSource(string id, string state, string patienttypeId)
        {
            this.ihsp_id = id;
            this.state = state;
            this.patienttypeId = patienttypeId;
            DataTable dt = bllGzsnhMethod.getHisInhspInfo(ihsp_id);
            this.zyh = dt.Rows[0]["ihspcode"].ToString();
            this.sickname = dt.Rows[0]["name"].ToString();

        }
        private void button8_Click(object sender, EventArgs e)
        {
            dtv_nhxx1.Rows.Clear();
            if (string.IsNullOrEmpty(tbx_zjhm1.Text))
                return;
            dtv_nhxx1.Visible = true;
            Dictionary<int, string> result = new Dictionary<int, string>();
            string identify = "";
            switch (cbx_zjlx1.SelectedValue.ToString())
            {
                case "0":
                    identify = "&bookno=" + Base64.encodebase64(tbx_zjhm1.Text.Trim()) + "&idcardno=&guardianCardno=";
                    break;
                case "1":
                    identify = "&bookno=&idcardno=" + Base64.encodebase64(tbx_zjhm1.Text.Trim()) + "&guardianCardno=";
                    break;
                case "2":
                    identify = "&bookno=&idcardno=&guardianCardno=" + Base64.encodebase64(tbx_zjhm1.Text.Trim()) + "";
                    break;
            }
            string year = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy");
            string url = GzsnhGlobal.Url + "getPersonInfo?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + identify + "&year=" + Base64.encodebase64(year) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //getdata.nhypflxzdelete();
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                        for (int j = 0; j < detial.Length; j++)
                        {
                            string[] data = detial[j].Split(':');
                            result.Add(j, Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                        }
                        //getdata.nhypflxz(result);
                        dtv_nhxx1.Rows.Add();
                        for (int j = 0; j < result.Count; j++)
                        {
                            if (j >= 14)
                                continue;
                            dtv_nhxx1.Rows[i].Cells[j].Value = result[j];
                        }
                        result.Clear();
                    }
                    //ypflxz();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); dtv_nhxx1.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "\r\n"+ex.ToString()); dtv_nhxx1.Visible = false;
                return;
            }
        }
        public void inirydj()
        {
            if (state == "rd")
            {
                btn_rydj1.Visible = false;
                //btn_rydj11.Visible = false;
                btn_enter.Visible = false;
            }
            else
            {
                btn_enter.Visible = false;
            }
            tbx_hiszyh1.Text = zyh;
            tbx_hzxm1.Text = sickname;
            object[] objs = { "0", null };
            DataTable dt = new DataTable();
            DataRow dr;            

            List<ListItem> zjlx = new List<ListItem>();//证件类型
            ListItem zjlx1 = new ListItem("0", "医疗证（卡）号");
            ListItem zjlx2 = new ListItem("1", "身份证号");
            ListItem zjlx3 = new ListItem("2", "监护人身份证号");
            zjlx.Add(zjlx1);
            zjlx.Add(zjlx2);
            zjlx.Add(zjlx3);
            cbx_zjlx1.DisplayMember = "Text";
            cbx_zjlx1.ValueMember = "Value";
            cbx_zjlx1.DataSource = zjlx;
            cbx_zjlx1.SelectedValue = "0";

            cbx_ss1.DisplayMember = "name";
            cbx_ss1.ValueMember = "insureid";
            dt = bllGzsnhMethod.getOpsInfo();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_ss1.DataSource = dt;//手术

            cbx_zlfs1.DisplayMember = "name";
            cbx_zlfs1.ValueMember = "code";
            dt = bllGzsnhMethod.getNhzlfsbm();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_zlfs1.DataSource = dt;//治疗方式

            cbx_hisryks1.DisplayMember = "name";
            cbx_hisryks1.ValueMember = "code";
            cbx_hisryks1.DataSource = bllGzsnhMethod.getNhksxxbm();//农合科室

            List<ListItem> jzlx = new List<ListItem>();//就诊类型
            ListItem jzlx1 = new ListItem("1", "门诊");
            ListItem jzlx2 = new ListItem("2", "住院");
            ListItem jzlx3 = new ListItem("3", "体格检查");
            ListItem jzlx4 = new ListItem("4", "正常分娩住院");
            ListItem jzlx5 = new ListItem("9", "其他");
            jzlx.Add(jzlx1);
            jzlx.Add(jzlx2);
            jzlx.Add(jzlx3);
            jzlx.Add(jzlx4);
            jzlx.Add(jzlx5);
            cbx_jzlx1.DisplayMember = "Text";
            cbx_jzlx1.ValueMember = "Value";
            cbx_jzlx1.DataSource = jzlx;
            cbx_jzlx1.SelectedValue = "2";

            List<ListItem> ryzt = new List<ListItem>();//入院状态
            ListItem ryzt1 = new ListItem("1", "危");
            ListItem ryzt2 = new ListItem("2", "急");
            ListItem ryzt3 = new ListItem("3", "一般");
            ListItem ryzt4 = new ListItem("9", "其他");
            ryzt.Add(ryzt1);
            ryzt.Add(ryzt2);
            ryzt.Add(ryzt3);
            ryzt.Add(ryzt4);
            cbx_ryzt1.DisplayMember = "Text";
            cbx_ryzt1.ValueMember = "Value";
            cbx_ryzt1.DataSource = ryzt;
            cbx_ryzt1.SelectedValue = "3";

            List<ListItem> zzlx = new List<ListItem>();//转诊类型
            ListItem zzlx1 = new ListItem("0", "正常转院");
            ListItem zzlx2 = new ListItem("1", "县外就医转诊");
            ListItem zzlx3 = new ListItem("2", "转院");
            ListItem zzlx4 = new ListItem("3", "其他");
            zzlx.Add(zzlx1);
            zzlx.Add(zzlx2);
            zzlx.Add(zzlx3);
            zzlx.Add(zzlx4);
            cbx_zzlx1.DisplayMember = "Text";
            cbx_zzlx1.ValueMember = "Value";
            cbx_zzlx1.DataSource = zzlx;
            cbx_zzlx1.SelectedValue = "1";

            List<ListItem> xsexb = new List<ListItem>();//新生儿性别
            ListItem xsexb1 = new ListItem("1", "男");
            ListItem xsexb2 = new ListItem("2", "女");
            xsexb.Add(xsexb1);
            xsexb.Add(xsexb2);
            cbx_xsexb1.DisplayMember = "Text";
            cbx_xsexb1.ValueMember = "Value";
            cbx_xsexb1.DataSource = xsexb;

            cbx_zdbm11.DisplayMember = "icdname";
            cbx_zdbm11.ValueMember = "icdallno";
            dt = bllGzsnhMethod.getnhjbxxbm();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_zdbm11.DataSource = dt;//疾病编码
            cbx_zdbm11.SelectedValue = "0";
            cbx_zdbm21.DisplayMember = "icdname";
            cbx_zdbm21.ValueMember = "icdallno";
            dt = bllGzsnhMethod.getnhjbxxbm();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_zdbm21.DataSource = dt;//疾病编码
            cbx_zdbm21.SelectedValue = "0";

            cbx_zdbm31.DisplayMember = "icdname";
            cbx_zdbm31.ValueMember = "icdallno";
            dt = bllGzsnhMethod.getnhjbxxbm(); 
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_zdbm31.DataSource = dt;//疾病编码
            cbx_zdbm31.SelectedValue = "0";

            dtv_nhxx1.Visible = false;
            
            dtv_nhzxbm.Visible = false;
            dtp_zyrq1.Value = DateTime.Now;
            tbx_zzzybm1.Text = "";
            cbx_zzlx1.SelectedIndex = 1;
             
            if (ihsp_id != null)
            {
              //  string sql = "select org.nhkscode,zyjlmzzd,zyjlrysj,familyno,memberno,inpatientsn,turnmode,turncode,turndate,centerno,ctct1.fullname as ys,ctct2.m_tel AS tel from mtzyjl,org,ctct ctct1,ctct ctct2,cimsuser where mtzyjl.ctct=ctct2.iid and ctct1.iid=cimsuser.ctct and cimsuser.iid=mtzyjl.zyjlzyys and mtzyjl.iid=" + mtzyjliid + " and mtzyjl.org=org.iid";
                string sql =" SELECT"
	                +" inhospital.id,"
	                +" cost_insurdepart.insurcode AS nhkscode,"
                    + " ihsp_diagnmes.diagnname as clinicdiagn,"
                    +" bas_doctor.name as doctorname,"
                    +" inhospital.indate,"
                    +" ihsp_info.homephone"
                    +" FROM"
	                +" inhospital"
                    +"  LEFT JOIN cost_insurdepart ON cost_insurdepart.depart_id = inhospital.depart_id AND cost_insurdepart.insuritemtype = '1'"
                    +" LEFT JOIN bas_doctor on inhospital.doctor_id = bas_doctor.id"
                    + " left join ihsp_info on ihsp_info.ihsp_id = inhospital.id and ihsp_info.registkind='IHSP'"
                    + " left join ihsp_diagnmes on ihsp_diagnmes.ihsp_id=inhospital.id and ihsp_diagnmes.opkind='MAIN' and ihsp_diagnmes.diagnKind='CLIN'"
                    + " where inhospital.id=" + ihsp_id;


                DataTable dt2 =  BllMain.Db.Select(sql).Tables[0];
                cbx_hisryks1.SelectedValue = dt2.Rows[0]["nhkscode"].ToString();
                tbx_ryzd.Text = dt2.Rows[0]["clinicdiagn"].ToString();
                tbx_dhhm1.Text = dt2.Rows[0]["homephone"].ToString();
                tbx_jzys1.Text = dt2.Rows[0]["doctorname"].ToString();
                dtp_ryrq1.Value = DateTime.Parse(dt2.Rows[0]["indate"].ToString().Split(' ')[0]);
                string sql2 = "select * from insur_gzsnhryinfo where mtzyjliid=" + ihsp_id;//centerno is null and
                DataTable dt3 = BllMain.Db.Select(sql2).Tables[0];
                if (dt3.Rows.Count > 0)
                {
                    tbx_zjhm1.Text = dt3.Rows[0]["bookno"].ToString();
                    tbx_jtbh1.Text = dt3.Rows[0]["familysysno"].ToString();
                    tbx_grbh1.Text = dt3.Rows[0]["membersysno"].ToString();
                    string turnmode = dt3.Rows[0]["turnmode"].ToString();
                    if (turnmode != "")
                    {
                        cbx_zzlx1.SelectedIndex = Convert.ToInt32(turnmode);
                    }
                    tbx_zzzybm1.Text = dt3.Rows[0]["turncode"].ToString();
                    string turndate = dt3.Rows[0]["turndate"].ToString();
                    if (turndate != "")
                    {
                        dtp_zyrq1.Value = DateTime.Parse(turndate);
                    }
                    tbx_centerno.Text = dt3.Rows[0]["centerno"].ToString();
                    tbx_sg1.Text = dt3.Rows[0]["stature"].ToString();
                    tbx_tz1.Text = dt3.Rows[0]["weight"].ToString();
                    cbx_zdbm11.SelectedValue = dt3.Rows[0]["icdallno"].ToString();
                    cbx_zdbm21.SelectedValue = dt3.Rows[0]["secondicdno"].ToString();
                    cbx_zdbm31.SelectedValue = dt3.Rows[0]["threeicdno"].ToString();
                    cbx_ss1.SelectedValue = dt3.Rows[0]["opsid"].ToString();
                    cbx_zlfs1.SelectedValue = dt3.Rows[0]["treatcode"].ToString();
                    cbx_jzlx1.SelectedValue = dt3.Rows[0]["cureid"].ToString();
                    tbx_bfz1.Text = dt3.Rows[0]["complication"].ToString();
                    cbx_ryzt1.SelectedValue = dt3.Rows[0]["inhosid"].ToString();
                    tbx_jzys1.Text = dt3.Rows[0]["curedocotor"].ToString();
                    tbx_cwh1.Text = dt3.Rows[0]["bedno"].ToString();
                    tbx_rybq1.Text = dt3.Rows[0]["sectionno"].ToString();
                    tbx_zysfsj1.Text = dt3.Rows[0]["ticketno"].ToString();
                    tbx_mztzsh1.Text = dt3.Rows[0]["ministernotice"].ToString();
                    tbx_syzh1.Text = dt3.Rows[0]["procreatenotice"].ToString();
                    tbx_dhhm1.Text = dt3.Rows[0]["tel"].ToString();
                    string isnewborn = dt3.Rows[0]["isnewborn"].ToString();
                    if (isnewborn == "1")
                    {
                        cbx_sfxse1.Checked = true;
                        tbx_xsexm1.Text = dt3.Rows[0]["newbornname"].ToString();
                        dtp_cssj1.Value = DateTime.Parse(dt3.Rows[0]["newbornbirthday"].ToString());
                        cbx_xsexb1.SelectedValue = dt3.Rows[0]["newbornsex"].ToString();
                    }

                }
            }
            //else
            //{
            //    tbx_zzzybm1.Text = "";
            //    dtp_zyrq1.Value = DateTime.Now;
            //    cbx_zzlx1.SelectedIndex = 1;

            //}
            //if (org != null)
            //{
            //    string sql = "select nhkscode from org where iid=" + org;
            //    cbx_hisryks1.SelectedValue = hisdb.Select(sql).Tables[0].Rows[0]["nhkscode"].ToString();
            //}
            //if (Doctor != null)
            //{
           //     tbx_jzys1.Text = Doctor.ToString();
            //}
            
           
        }

        private void cbx_zdbm21_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zdbm21.DisplayMember = "icdname";
                cbx_zdbm21.ValueMember = "icdallno";
                cbx_zdbm21.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_zdbm21.Text.ToUpper()); //疾病编码
            }
        }

        private void cbx_zdbm31_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zdbm31.DisplayMember = "icdname";
                cbx_zdbm31.ValueMember = "icdallno";
                cbx_zdbm31.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_zdbm31.Text.ToUpper());//疾病编码
            }
        }
        private void cbx_zdbm11_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zdbm11.DisplayMember = "icdname";
                cbx_zdbm11.ValueMember = "icdallno";
                cbx_zdbm11.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_zdbm11.Text.ToUpper());//疾病编码
            }
        }
        private void cbx_ss1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_ss1.DisplayMember = "name";
                cbx_ss1.ValueMember = "insureid";
                cbx_ss1.DataSource = bllGzsnhMethod.getOpsInfo(cbx_ss1.Text.ToUpper());//手术
            }
        }

        private void cbx_zlfs1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zlfs1.DisplayMember = "name";
                cbx_zlfs1.ValueMember = "code";
                cbx_zlfs1.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_zlfs1.Text);//治疗方式
            }
        }

        private void cbx_hisryks1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_hisryks1.DisplayMember = "name";
                cbx_hisryks1.ValueMember = "code";
                cbx_hisryks1.DataSource = bllGzsnhMethod.getNhksxxbm(cbx_hisryks1.Text);//农合科室
            }
        }

        private void cbx_sfxse1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_sfxse1.Checked)
            {
                lbl_xsecssj1.ForeColor = Color.Red;
                lbl_xsexb1.ForeColor = Color.Red;
                lbl_xsexm1.ForeColor = Color.Red;
            }
            else
            {
                lbl_xsecssj1.ForeColor = Color.Black;
                lbl_xsexb1.ForeColor = Color.Black;
                lbl_xsexm1.ForeColor = Color.Black;
            }
        }

        private void btn_rydj1_Click(object sender, EventArgs e)
        {
            rydjxg("1");
        }
        public void rydjxg(string oper)
        {
            if (string.IsNullOrEmpty(tbx_hiszyh1.Text))
            {
                MessageBox.Show("住院号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_jtbh1.Text))
            {
                MessageBox.Show("家庭编号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_grbh1.Text))
            {
                MessageBox.Show("个人编号不能为空"); return;
            }
            if (cbx_zdbm11.SelectedValue==null || cbx_zdbm11.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("入院主诊断不能为空"); return;
            }
            string icd2 = "";
            if (cbx_zdbm21.SelectedValue != null && cbx_zdbm21.SelectedValue.ToString() != "0")
                icd2 = cbx_zdbm21.SelectedValue.ToString();
            string icd3 = "";
            if (cbx_zdbm31.SelectedValue != null && cbx_zdbm31.SelectedValue.ToString() != "0")
                icd2 = cbx_zdbm31.SelectedValue.ToString();
            string zddb1 = "";
            if (cbxZdjb1.SelectedValue != null && cbxZdjb1.SelectedValue.ToString() != "0")
                zddb1 = cbxZdjb1.SelectedValue.ToString();
            string zddb2 = "";
            if (cbxZdjb2.SelectedValue != null && cbxZdjb2.SelectedValue.ToString() != "0")
                zddb2 = cbxZdjb2.SelectedValue.ToString();
            string zddb3 = "";
            if (cbxZdjb3.SelectedValue != null && cbxZdjb3.SelectedValue.ToString() != "0")
                zddb3 = cbxZdjb3.SelectedValue.ToString();
            string ops = "";
            if (cbx_ss1.SelectedValue != null && cbx_ss1.SelectedValue.ToString() != "0")
                ops = cbx_ss1.SelectedValue.ToString();
            string treat = "";
            if (cbx_zlfs1.SelectedValue != null && cbx_zlfs1.SelectedValue.ToString() != "0")
                treat = cbx_zlfs1.SelectedValue.ToString();
            string treat2 = "";
            if (cbx_zlfs2.SelectedValue != null && cbx_zlfs2.SelectedValue.ToString() != "0")
                treat2 = cbx_zlfs2.SelectedValue.ToString();
            string treat3 = "";
            if (cbx_zlfs3.SelectedValue != null && cbx_zlfs3.SelectedValue.ToString() != "0")
                treat3 = cbx_zlfs3.SelectedValue.ToString();
            
            if (cbx_hisryks1.SelectedValue.ToString() == "0" && cbx_hisryks1.SelectedValue.ToString() != null)
            {
                MessageBox.Show("入院科室不能为空"); return;
            }
            if (string.IsNullOrEmpty(dtp_ryrq1.Text))
            {
                MessageBox.Show("入院时间不能为空"); return;
            }
            if (cbx_jzlx1.Text.ToString() == "0")
            {
                MessageBox.Show("就诊类型不能为空"); return;
            }
            if (cbx_ryzt1.Text.ToString() == "0")
            {
                MessageBox.Show("入院状态不能为空"); return;
            }
            string turn = "";
            if (cbx_zzlx1.SelectedValue.ToString() != "")
                turn = cbx_zzlx1.SelectedValue.ToString();
            string turndate = "";
            if (tbx_zzzybm1.Text.ToString()!="")
                turndate = DateTime.Parse(dtp_zyrq1.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string born = "0";
            string bornb = "";
            string bornn = "";
            string borns = "";
            nhdj.Stature = tbx_sg1.Text.Trim();
            nhdj.Weight = tbx_tz1.Text.Trim();
            nhdj.Icdallno = cbx_zdbm11.SelectedValue.ToString();
            nhdj.Secondicdno = icd2;
            nhdj.Threeicdno = icd3;
            nhdj.Opsid = ops;
            nhdj.Treatcode = treat;
            nhdj.Inofficeid = cbx_hisryks1.SelectedValue.ToString();
            nhdj.Officedate = DateTime.Parse(dtp_ryrq1.Text).ToString("yyyy-MM-dd HH:mm:ss");
            nhdj.Cureid = cbx_jzlx1.SelectedValue.ToString();
            nhdj.Complication = tbx_bfz1.Text;
            nhdj.Inhosid = cbx_ryzt1.SelectedValue.ToString();
            nhdj.Curedoctor = tbx_jzys1.Text;
            nhdj.Bedno = tbx_cwh1.Text;
            nhdj.Sectionno = tbx_rybq1.Text;;
            nhdj.Ministernotice = tbx_mztzsh1.Text.Trim();
            nhdj.Procreatenotice = tbx_syzh1.Text.Trim();
            nhdj.Tel = tbx_dhhm1.Text.Trim();
        
            nhdj.Centerno = tbx_centerno.Text.Trim();            
            nhdj.Familysysno = tbx_jtbh1.Text.Trim();
            nhdj.Membersysno = tbx_grbh1.Text.Trim();
            nhdj.BookNo = tbx_zjhm1.Text.ToString();

            if (tbx_zzzybm1.Text == "")
            {
                turn = "";
                turndate = "";
            }
            nhdj.Turncode = tbx_zzzybm1.Text;//转诊编码
            nhdj.Turnmode = turn;//转诊类型
            nhdj.Turndate = turndate;//转诊日期

            if (cbx_sfxse1.Checked)
            {
                born = "1";
                if (DateTime.Parse(dtp_cssj1.Text).ToString("yyyy-MM-dd HH:mm:ss") == "1990-01-01 00:00:00")
                {
                    MessageBox.Show("新生儿出生日期不能为空"); return;
                }
                if (string.IsNullOrEmpty(tbx_xsexm1.Text))
                {
                    MessageBox.Show("新生儿姓名不能为空"); return;
                }
                bornb = DateTime.Parse(dtp_cssj1.Text).ToString("yyyy-MM-dd HH:mm:ss");
                bornn = tbx_xsexm1.Text;
                borns = cbx_xsexb1.SelectedValue.ToString();
            }
            nhdj.Isnewborn = born;
            nhdj.Newbornbirthday = bornb;
            nhdj.Newbornname = bornn;
            nhdj.Newbornsex = borns;

            string url = GzsnhGlobal.Url + "inpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.Trim()) + "&type=" + Base64.encodebase64(oper) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientNo=" + Base64.encodebase64(tbx_hiszyh1.Text.Trim()) + "&familySysno=" + Base64.encodebase64(tbx_jtbh1.Text.Trim()) + "&memberSysno=" + Base64.encodebase64(tbx_grbh1.Text.Trim()) + "&Stature=" + Base64.encodebase64(tbx_sg1.Text.Trim()) + "&Weight=" + Base64.encodebase64(tbx_tz1.Text.Trim()) + "&icdAllNo=" + Base64.encodebase64(cbx_zdbm11.SelectedValue.ToString()) + "&secondIcdNo=" + Base64.encodebase64(icd2) + "";
            url += "&threeIcdNo=" + Base64.encodebase64(icd3) + "&majorDiseaseICD=" + Base64.encodebase64(zddb1) + "&secondMajorDiseaseICD=" + Base64.encodebase64(zddb2) + "&threeMajorDiseaseICD=" + Base64.encodebase64(zddb3) + "&secondTreatCode=" + Base64.encodebase64(treat2) + "&threeTreatCode=" + Base64.encodebase64(treat3) + "&opsId=" + Base64.encodebase64(ops) + "&treatCode=" + Base64.encodebase64(treat) + "&inOfficeId=" + Base64.encodebase64(cbx_hisryks1.SelectedValue.ToString()) + "&officeDate=" + Base64.encodebase64(DateTime.Parse(dtp_ryrq1.Text).ToString("yyyy-MM-dd HH:mm:ss")) + "&cureId=" + Base64.encodebase64(cbx_jzlx1.SelectedValue.ToString()) + "&complication=" + Base64.encodebase64(tbx_bfz1.Text) + "&inHosId=" + Base64.encodebase64(cbx_ryzt1.SelectedValue.ToString()) + "&cureDoctor=" + Base64.encodebase64(tbx_jzys1.Text) + "&bedNo=" + Base64.encodebase64(tbx_cwh1.Text) + "&sectionNo=" + Base64.encodebase64(tbx_rybq1.Text) + "";
            url += "&turnMode=" + Base64.encodebase64(turn) + "&turnCode=" + Base64.encodebase64(tbx_zzzybm1.Text) + "&turnDate=" + Base64.encodebase64(turndate) + "&ticketNo=" + Base64.encodebase64(tbx_zysfsj1.Text) + "&ministerNotice=" + Base64.encodebase64(tbx_mztzsh1.Text.Trim()) + "&procreateNotice=" + Base64.encodebase64(tbx_syzh1.Text.Trim()) + "&tel=" + Base64.encodebase64(tbx_dhhm1.Text.Trim()) + "&isNewborn=" + Base64.encodebase64(born) + "&newbornBirthday=" + Base64.encodebase64(bornb) + "&newbornName=" + Base64.encodebase64(bornn) + "&newbornSex=" + Base64.encodebase64(borns) + "";
            string sj = DateTime.Now.ToString("HHmm_");
            if (oper == "2")
            {
                string sn = bllGzsnhMethod.getHisInpatientsn(ihsp_id);
                
                url += "&registerID=" + Base64.encodebase64(sj+ihsp_id) + "&inpatientSn=" + Base64.encodebase64(sn);
            }
            else
            {
                url += "&registerID=" + Base64.encodebase64(sj+ihsp_id) + "&inpatientSn=" + Base64.encodebase64("");
            }
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //for (int i = 0; i < info.Length; i++)
                    //{
                    string[] detial = info[0].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                    //for (int j = 0; j < detial.Length; j++)
                    //{
                    string[] data = detial[0].Replace("{", "").Replace("}", "").Split(':');
                    //    }
                    //}
                    string insuritemtype = "";
                    if (bllGzsnhMethod.isInGysnh(nhdj.Centerno))
                    {
                        insuritemtype = "2";//是贵阳市地区
                    }
                    else
                    {
                        insuritemtype = "1";//不是是贵阳市地区
                    }
                    nhdj.Inpatientsn = Base64.decodebase64(data[1]);
                    int i = bllGzsnhMethod.updateHisNhryinfo(ihsp_id, nhdj, patienttypeId,insuritemtype);//更新HIS数据
                    if (i == -1)
                    {
                        MessageBox.Show("农合登记成功，数据更新失败！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            if (oper == "1")
            {
                MessageBox.Show("登记成功");
            }
            else
                MessageBox.Show("修改成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void btn_rydj11_Click(object sender, EventArgs e)
        {
            rydjxg("2");
        }

        private void btn_qxrydj1_Click(object sender, EventArgs e)
        {
            string sn = bllGzsnhMethod.getHisInpatientsn(ihsp_id);
            string url = GzsnhGlobal.Url + "cancelInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(sn) + "&cancelCause=" + Base64.encodebase64(tbx_rydjqx.Text);
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
                if (Base64.decodebase64(param.Split(',')[0]) == "1")
                {
                    bllGzsnhMethod.cancleHisNhryinfo(ihsp_id);
                    MessageBox.Show("登记已取消");
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                return ;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
        

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_hiszyh1.Text))
            {
                MessageBox.Show("住院号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_jtbh1.Text))
            {
                MessageBox.Show("家庭编号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_grbh1.Text))
            {
                MessageBox.Show("个人编号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_centerno.Text))
            {
                MessageBox.Show("农合中心编码不能为空"); return;
            }
            if (cbx_zdbm11.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("入院主诊断不能为空"); return;
            }
            string icd2 = "";
            if (cbx_zdbm21.SelectedValue.ToString() != "0")
                icd2 = cbx_zdbm21.SelectedValue.ToString();
            string icd3 = "";
            if (cbx_zdbm31.SelectedValue.ToString() != "0")
                icd2 = cbx_zdbm31.SelectedValue.ToString();
            string ops = "";
            if (cbx_ss1.SelectedValue.ToString() != "0")
                ops = cbx_ss1.SelectedValue.ToString();
            string treat = "";
            if (cbx_zlfs1.SelectedValue.ToString() != "0")
                treat = cbx_zlfs1.SelectedValue.ToString();
            if (cbx_hisryks1.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("入院科室不能为空"); return;
            }
            if (string.IsNullOrEmpty(dtp_ryrq1.Text))
            {
                MessageBox.Show("入院时间不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_centerno.Text))
            {
                MessageBox.Show("农合中心编码不能为空"); return;
            }
            if (cbx_jzlx1.Text.ToString() == "0")
            {
                MessageBox.Show("就诊类型不能为空"); return;
            }
            if (cbx_ryzt1.Text.ToString() == "0")
            {
                MessageBox.Show("入院状态不能为空"); return;
            }
            string turn = "";
            if (cbx_zzlx1.SelectedValue.ToString() != "3")
                turn = cbx_zzlx1.SelectedValue.ToString();
            string turndate = "";
            if (DateTime.Parse(dtp_zyrq1.Text).ToString("yyyy-MM-dd HH:mm:ss") != "1990-01-01 00:00:00")
                turndate = DateTime.Parse(dtp_zyrq1.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string born = "0";
            string bornb = "";
            string bornn = "";
            string borns = "";
            if (cbx_sfxse1.Checked)
            {
                born = "1";
                if (DateTime.Parse(dtp_cssj1.Text).ToString("yyyy-MM-dd HH:mm:ss") == "1990-01-01 00:00:00")
                {
                    MessageBox.Show("新生儿出生日期不能为空"); return;
                }
                if (string.IsNullOrEmpty(tbx_xsexm1.Text))
                {
                    MessageBox.Show("新生儿姓名不能为空"); return;
                }
                bornb = DateTime.Parse(dtp_cssj1.Text).ToString("yyyy-MM-dd HH:mm:ss");
                bornn = tbx_xsexm1.Text;
                borns = cbx_xsexb1.SelectedValue.ToString();
            }
            nhdj.Type = "1";
            nhdj.Inpatientsn= tbx_hiszyh1.Text.Trim();
            nhdj.Familysysno = tbx_jtbh1.Text.Trim();
            nhdj.Membersysno = tbx_grbh1.Text.Trim();
            nhdj.Centerno = tbx_centerno.Text.Trim();
            nhdj.Stature = tbx_sg1.Text.Trim();
            nhdj.Weight = tbx_tz1.Text.Trim();
            nhdj.Icdallno = cbx_zdbm11.SelectedValue.ToString();
            nhdj.Secondicdno = icd2;
            nhdj.Threeicdno = icd3;
            nhdj.Opsid = ops;
            nhdj.Treatcode = treat;
            nhdj.Inofficeid = cbx_hisryks1.SelectedValue.ToString();
            nhdj.Officedate = DateTime.Parse(dtp_ryrq1.Text).ToString("yyyy-MM-dd HH:mm:ss");
            nhdj.Cureid = cbx_jzlx1.SelectedValue.ToString();
            nhdj.Complication = tbx_bfz1.Text;
            nhdj.Inhosid = cbx_ryzt1.SelectedValue.ToString();
            nhdj.Curedoctor = tbx_jzys1.Text;
            nhdj.Bedno = tbx_cwh1.Text;
            nhdj.Sectionno = tbx_rybq1.Text;
            nhdj.Turnmode = turn;
            nhdj.Turncode = tbx_zzzybm1.Text;
            nhdj.Turndate = turndate;
            nhdj.Ticketno = tbx_zysfsj1.Text;
            nhdj.Ministernotice = tbx_mztzsh1.Text.Trim();
            nhdj.Procreatenotice = tbx_syzh1.Text.Trim();
            nhdj.Tel = tbx_dhhm1.Text.Trim();
            nhdj.Isnewborn = born;
            nhdj.Newbornbirthday = bornb;
            nhdj.Newbornname = bornn;
            nhdj.Newbornsex = borns;
            nhdj.BookNo = tbx_zjhm1.Text;
            this.Close();
            this.Dispose();
        }

        private void dtv_nhxx1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtv_nhxx1.CurrentRow.Cells["name_ryxx1"].Value.ToString() != tbx_hzxm1.Text.Trim())
            {
                if (MessageBox.Show("农合姓名与登记姓名不一致是否继续？", "提示信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    dtv_nhxx.Visible = false;
                    return;
                }
            }
            tbx_zjhm1.Text = dtv_nhxx1.CurrentRow.Cells["bookNo1"].Value.ToString();
            cbx_zjlx1.SelectedValue = "0";
            tbx_jtbh1.Text = dtv_nhxx1.CurrentRow.Cells["familySysno1"].Value.ToString();
            tbx_grbh1.Text = dtv_nhxx1.CurrentRow.Cells["memberNO1"].Value.ToString();
            dtv_nhxx1.Visible = false;
        }

      

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_centerno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtv_nhzxbm.Visible = true;
                dtv_nhzxbm.DataSource = bllGzsnhMethod.getHisCenternoList(this.tbx_centerno.Text.Trim());
            }
        }

        private void dtv_nhzxbm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_centerno.Text = dtv_nhzxbm.CurrentRow.Cells["nhzxbm1"].Value.ToString();
            dtv_nhzxbm.Visible = false;
        }

        private void dtv_nhxx1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_hqzzdxx_Click(object sender, EventArgs e)
        {
            if (tbx_centerno.Text.ToString() == "")
            {
                MessageBox.Show("农合中心编码不能为空");
                return;
            }
            if (tbx_grbh1.Text.ToString() == "")
            {
                MessageBox.Show("个人编号不能为空");
                return;
            }
            Dictionary<int, string> result = new Dictionary<int, string>();
            string url = GzsnhGlobal.Url + "downloadReferralsheet?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&trunCode=" + Base64.encodebase64("") + "&memberNo=" + Base64.encodebase64(tbx_grbh1.Text.ToString());
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //getdata.nhypflxzdelete();
                    if (info.Length > 0)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                            //for (int j = 0; j < detial.Length; j++)
                            //{
                            //    string[] data = detial[j].Split(':');
                            //    result.Add(j, Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                            //}
                            result.Add(0, Base64.decodebase64(detial[0].Split(':')[1]).Replace("\'", "\\\'"));
                            result.Add(1, Base64.decodebase64(detial[4].Split(':')[1]).Replace("\'", "\\\'"));
                            string zzlx = Base64.decodebase64(detial[10].Split(':')[1]).Replace("\'", "\\\'");
                            if (zzlx == "1")
                            {
                                result.Add(2, "门诊");
                            }
                            else
                            {
                                result.Add(2, "住院");
                            }
                            result.Add(3, Base64.decodebase64(detial[13].Split(':')[1]).Replace("\'", "\\\'"));

                            dtv_zzdxx.Rows.Add();
                            for (int j = 0; j < result.Count; j++)
                            {
                                dtv_zzdxx.Rows[i].Cells[j].Value = result[j];
                            }
                            result.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("该病人未有转入我院的转诊单");
                        return;
                    }
                    dtv_zzdxx.Visible = true;
                    //ypflxz();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); 
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取转诊信息失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
        }

        private void dtv_zzdxx_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cbx_zzlx1.SelectedValue = "1";
            tbx_zzzybm1.Text = dtv_zzdxx.CurrentRow.Cells[0].Value.ToString();
            dtp_zyrq1.Value = DateTime.Parse(dtv_zzdxx.CurrentRow.Cells[3].Value.ToString());
            dtv_zzdxx.Visible = false;
        }

        private void cbxZdjb1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb1.DisplayMember = "icdname";
                cbxZdjb1.ValueMember = "icdallno";
                cbxZdjb1.DataSource =bllGzsnhMethod.getnhjbxxbm(cbxZdjb1.Text.ToUpper()); //疾病编码
            }
        }

        private void cbxZdjb2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb2.DisplayMember = "icdname";
                cbxZdjb2.ValueMember = "icdallno";
                cbxZdjb2.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxZdjb2.Text.ToUpper()); //疾病编码
            }
        }

        private void cbxZdjb3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb3.DisplayMember = "icdname";
                cbxZdjb3.ValueMember = "icdallno";
                cbxZdjb3.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxZdjb3.Text.ToUpper()); //疾病编码
            }
        }

       

        private void cbx_zlfs2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zlfs2.DisplayMember = "name";
                cbx_zlfs2.ValueMember = "code";
                cbx_zlfs2.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_zlfs2.Text);//治疗方式
            }
        }

        private void cbx_zlfs3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_zlfs3.DisplayMember = "name";
                cbx_zlfs3.ValueMember = "code";
                cbx_zlfs3.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_zlfs3.Text);//治疗方式
            }
        }
    }
}
