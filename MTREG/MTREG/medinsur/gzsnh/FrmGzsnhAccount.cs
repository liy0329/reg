using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.listitem;
using System.Net;
//using guizhousheng.global;
//using WebAPI;
//using guizhousheng.db;
using System.IO;
//using MTREG.medinsur.gzsnh.nh;
using MTREG.ihsp.bll;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh.bo;
using MTREG.common;
using MTREG.medinsur.gzsyb;
using MTHIS.common;
 
namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhAccount : Form
    {
        
        BillIhspcost billIhspcost = new BillIhspcost();
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        BillIhspAct billIhspAct = new BillIhspAct();

        private string insuritemtype;

        public string Insuritemtype
        {
            get { return insuritemtype; }
            set { insuritemtype = value; }
        }

       // private string ihsp_id;
        ///// <summary>
        ///// 住院记录ID
        ///// </summary>
        //public string Ihsp_id
        //{
        //    get { return ihsp_id; }
        //    set { ihsp_id = value; }
        //}
        public FrmGzsnhAccount()
        {
            InitializeComponent();
        }
         private string zyh;

        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
        private string sickname;

        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        private string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string ylfkfs;

        public string Ylfkfs
        {
            get { return ylfkfs; }
            set { ylfkfs = value; }
        }
        private string ihsp_account_id = "";
        public void getSource(string id)
        {
            this.ihsp_id = id;
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
            this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");

            DateTime start = Convert.ToDateTime(this.lblIndate.Text);
            DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
            TimeSpan day = end.Subtract(start);
            this.lblIhspDay.Text = day.Days.ToString();
            
        }
        private void frmnhcyjs_Load(object sender, EventArgs e)
        {
            cyini();
        }
        WebClient webClient = new WebClient();
       // HISDB hisdb = new HISDB();
        //nhService Nhservice = new nhService();
        private void cyini()
        {
            object[] objs = { "0", null };
            DataTable dt = new DataTable();
            DataTable jb_dt = new DataTable();
            DataTable zlfs_dt = new DataTable();
            DataRow dr;

            cbx_cyks.DisplayMember = "name";
            cbx_cyks.ValueMember = "code";
            cbx_cyks.DataSource = bllGzsnhMethod.getNhksxxbm();//农合科室

            List<ListItem> cyzt = new List<ListItem>();//出院状态
            ListItem cyzt1 = new ListItem("1", "治愈");
            ListItem cyzt2 = new ListItem("2", "好转");
            ListItem cyzt3 = new ListItem("3", "未愈");
            ListItem cyzt4 = new ListItem("4", "死亡");
            ListItem cyzt5 = new ListItem("9", "其他");
            cyzt.Add(cyzt1);
            cyzt.Add(cyzt2);
            cyzt.Add(cyzt3);
            cyzt.Add(cyzt4);
            cyzt.Add(cyzt5);
            cbx_cyzt.DataSource = cyzt;
            cbx_cyzt.SelectedIndex = 1;


            cbx_cyzd.DisplayMember = "icdname";
            cbx_cyzd.ValueMember = "icdallno";
            jb_dt = bllGzsnhMethod.getnhjbxxbm();
            dr = jb_dt.NewRow();
            dr.ItemArray = objs;
            jb_dt.Rows.InsertAt(dr, 0);
            cbx_cyzd.DataSource = jb_dt;//疾病编码

            cbx_dezd.DisplayMember = "icdname";
            cbx_dezd.ValueMember = "icdallno";
            //dt = getdata.nhjbxxbm().Tables[0];
            //dr = dt.NewRow();
            //dr.ItemArray = objs;
            //dt.Rows.InsertAt(dr, 0);
            cbx_dezd.DataSource = jb_dt;//疾病编码

            cbx_dszd.DisplayMember = "icdname";
            cbx_dszd.ValueMember = "icdallno";
            //dt = getdata.nhjbxxbm().Tables[0];
            //dr = dt.NewRow();
            //dr.ItemArray = objs;
            //dt.Rows.InsertAt(dr, 0);
            cbx_dszd.DataSource = jb_dt;//疾病编码

            cbx_cyzlfs.DisplayMember = "name";
            cbx_cyzlfs.ValueMember = "code";
            zlfs_dt = bllGzsnhMethod.getNhzlfsbm();
            dr = zlfs_dt.NewRow();
            dr.ItemArray = objs;
            zlfs_dt.Rows.InsertAt(dr, 0);
            cbx_cyzlfs.DataSource = zlfs_dt;//治疗方式

            cbx_defs.DisplayMember = "name";
            cbx_defs.ValueMember = "code";
            //dt = getdata.nhzlfsbm().Tables[0];
            //dr = dt.NewRow();
            //dr.ItemArray = objs;
            //dt.Rows.InsertAt(dr, 0);
            cbx_defs.DataSource = zlfs_dt;//治疗方式

            cbx_dsfs.DisplayMember = "name";
            cbx_dsfs.ValueMember = "code";
            //dt = getdata.nhzlfsbm().Tables[0];
  //        //dr = dt.NewRow();
            //dr.ItemArray = objs;
            //dt.Rows.InsertAt(dr, 0);
            cbx_dsfs.DataSource = zlfs_dt;//治疗方式

            List<ListItem> cyzzlx = new List<ListItem>();//转诊类型
            ListItem cyzzlx1 = new ListItem("0", "正常转院");
            ListItem cyzzlx2 = new ListItem("1", "县外就医转诊");
            ListItem cyzzlx3 = new ListItem("2", "转院");
            ListItem cyzzlx4 = new ListItem("3", "其他");
            cyzzlx.Add(cyzzlx1);
            cyzzlx.Add(cyzzlx2);
            cyzzlx.Add(cyzzlx3);
            cyzzlx.Add(cyzzlx4);
            //cbx_cyzzlx.DisplayMember = "name";
            //cbx_cyzzlx.ValueMember = "id";
            cbx_cyzzlx.DataSource = cyzzlx;
            //cbx_cyzzlx.SelectedValue = "3";
            cbx_cyzzlx.SelectedIndex = 3;

          

            DataTable cyxx = bllGzsnhMethod.getHisIhspInsurInfo(ihsp_id);
            string status = cyxx.Rows[0]["status"].ToString();
            if (status == "SETT")
            {
                btn_cydj.Enabled = false;
                btn_js.Enabled = false;
            }

            tbx_djlsh.Text = cyxx.Rows[0]["inpatientsn"].ToString();
            tbx_ylzh.Text = cyxx.Rows[0]["membersysno"].ToString();
            tbx_centerno.Text = cyxx.Rows[0]["centerno"].ToString();
            dtp_cyrq.Text = cyxx.Rows[0]["outdate"].ToString() != null ? cyxx.Rows[0]["outdate"].ToString() : DateTime.Today.ToString();
            tbx_hiscyzd.Text = cyxx.Rows[0]["diagnname"].ToString();
            ihsp_account_id = cyxx.Rows[0]["ihsp_account_id"].ToString();
            this.insuritemtype = cyxx.Rows[0]["insuritemtype"].ToString();
            this.sickname = cyxx.Rows[0]["name"].ToString();
            if (string.IsNullOrEmpty(ihsp_account_id))
            {
                this.btn_jscx.Enabled = false;
            }
            else
                this.btn_jscx.Enabled = true;
            string turnmode = cyxx.Rows[0]["turnmode"].ToString();
            if (turnmode != "")
            {
                cbx_cyzzlx.SelectedIndex = Convert.ToInt32(turnmode);// +1;
            }

            tbx_zybm.Text = cyxx.Rows[0]["turncode"].ToString();
            string turndate = cyxx.Rows[0]["turndate"].ToString();
            if (turndate != "")
            {
                dtp_cyzyrq.Value = DateTime.Parse(cyxx.Rows[0]["turndate"].ToString());
            }

            cbx_cyks.SelectedValue = cyxx.Rows[0]["nhkscode"].ToString();


            dtv_hisfy.DataSource = bllGzsnhMethod.getHisCostDet(ihsp_id, insuritemtype);
            lbl_zyf.Text = "共:" + billIhspAct.getHisCostDetSum(ihsp_id);
            lbl_xm.Text = sickname;
        }

        private void btn_fylr_Click(object sender, EventArgs e)
        {
            //uploaddetials();
        }
        public void uploaddetials()//费用录入
        {
            //DataTable basedata = getdata.fyly(zyh).Tables[0];
            //DataTable det = getdata.fymx(zyh).Tables[0];
            //string paramc = "";
            //for (int j = 0; j < det.Rows.Count; j++)
            //{
            //    if (j != 0)
            //        paramc += ",";
            //    paramc += "{\"hisDetailCode\":\"" + Base64.encodebase64(det.Rows[j]["iid"].ToString()) + "\",\"hisMedicineCode\":\"" + Base64.encodebase64(det.Rows[j]["mtprod"].ToString()) + "\",\"medicineCode\":\"" + Base64.encodebase64(det.Rows[j]["nhbm"].ToString()) + "\",\"medicineName\":\"" + Base64.encodebase64(det.Rows[j]["xmmc"].ToString()) + "\",\"spec\":\"" + Base64.encodebase64(det.Rows[j]["guige"].ToString()) + "\",\"conf\":\"" + Base64.encodebase64(det.Rows[j]["prodjixing"].ToString()) + "\",\"unit\":\"" + Base64.encodebase64(det.Rows[j]["uom"].ToString()) + "\",\"price\":\"" + Base64.encodebase64(det.Rows[j]["prc"].ToString()) + "\",\"quantity\":\"" + Base64.encodebase64(det.Rows[j]["qty"].ToString()) + "\",\"useDate\":\"" + Base64.encodebase64(det.Rows[j]["createdat"].ToString()) + "\"}";
            //    if (j % 100 == 0 && j != 0)
            //    {
            //        string param = "{\"userName\":\"" + Base64.encodebase64(Global.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(Global.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(Global.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(tbx_ylzh.Text.Trim()) + "\",\"name\":\"" + Base64.encodebase64(basedata.Rows[0]["fullname"].ToString()) + "\",\"familyNo\":\"" + Base64.encodebase64(basedata.Rows[0]["familyno"].ToString()) + "\",\"memberNo\":\"" + Base64.encodebase64(basedata.Rows[0]["memberno"].ToString()) + "\",\"inpatientSn\":\"" + Base64.encodebase64(tbx_djlsh.Text) + "\",\"rows\":\"" + Base64.encodebase64("100") + "\",\"InpatientDetailList\":[";
            //        int a = fytran(param + paramc + "]}");
            //        if (a == -1)
            //        {
            //            if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
            //                break;
            //        }
            //    }
            //    else if (j == det.Rows.Count - 1)
            //    {
            //        string param = "{\"userName\":\"" + Base64.encodebase64(Global.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(Global.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(Global.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(tbx_ylzh.Text.Trim()) + "\",\"name\":\"" + Base64.encodebase64(basedata.Rows[0]["fullname"].ToString()) + "\",\"familyNo\":\"" + Base64.encodebase64(basedata.Rows[0]["familyno"].ToString()) + "\",\"memberNo\":\"" + Base64.encodebase64(basedata.Rows[0]["memberno"].ToString()) + "\",\"inpatientSn\":\"" + Base64.encodebase64(tbx_djlsh.Text) + "\",\"rows\":\"" + Base64.encodebase64((det.Rows.Count % 100).ToString()) + "\",\"InpatientDetailList\":[";
            //        int a = fytran(param + paramc + "]}");
            //        if (a == -1)
            //        {
            //            if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
            //                break;
            //        }
            //    }
            //}
            MessageBox.Show("操作成功");
        }
        public int fytran(string param)//费用录入
        {
            //Dictionary<string, string> result = new Dictionary<string, string>();
            //Dictionary<string, string> ResultList = new Dictionary<string, string>();
            //string message = posturl(Global.Url + "uploadInpatientDetails", param);
            //try
            //{
            //    string[] info = message.Replace("\"", "").Replace(",InpatientDetailResultList:", "@").Split('@');
            //    string[] detial = info[0].Replace("{", "").Replace("}", "").Split(',');
            //    for (int h = 0; h < detial.Length; h++)
            //    {
            //        string[] data = detial[h].Replace("{", "").Replace("}", "").Split(':');
            //        result.Add(data[0], Base64.decodebase64(data[1]));
            //    }
            //    if (result["success"] != "1")
            //    {
            //        Log4Net.error(param + ":" + result["message"]); return -1;
            //    }
            //    else
            //    {
            //        string[] fymx = info[1].Replace("[", "").Replace("]", "").Replace("},{", "@").Split('@');
            //        for (int k = 0; k < fymx.Length; k++)
            //        {
            //            string[] xm = fymx[k].Replace("{", "").Replace("}", "").Split(',');
            //            for (int l = 0; l < xm.Length; l++)
            //            {
            //                string[] dd = xm[l].Split(':');
            //                ResultList.Add(dd[0], Base64.decodebase64(dd[1]));
            //            }
            //            int i = getdata.updatefyly(ResultList["hisDetailCode"], ResultList["detailNo"]);
            //            if (i == -1)
            //            {
            //                Log4Net.error("数据更新失败！" + ResultList["hisDetailCode"]);
            //            }
            //            ResultList.Clear();
            //        }
            //    }
            //    result.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    return -1;
            //}
            return 0;
        }
        public string posturl(string website, string param)//费用录入
        {
           string result = "";
            //try
            //{
            //    string postData = param;//POST参数和值写入POSTDATE里
            //    byte[] byteArray = Encoding.Default.GetBytes(postData);
            //    string url = website;
            //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            //    webRequest.Method = "POST";
            //    webRequest.ContentType = "application/json";
            //    webRequest.ContentLength = byteArray.Length;
            //    Stream newStream = webRequest.GetRequestStream();
            //    newStream.Write(byteArray, 0, byteArray.Length);
            //    newStream.Close();
            //    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //    StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
            //    string Message = php.ReadToEnd();
            //    result = Message;
            //}
            //catch (WebException ex)
            //{
            //    string strHtml = "";
            //    HttpWebResponse res = ex.Response as HttpWebResponse;
            //    if (res.StatusCode == HttpStatusCode.InternalServerError)
            //    {
            //        Stream s = res.GetResponseStream();
            //        StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding("utf-8"));
            //        string strLine = "";
            //        //读取                      
            //        while (strLine != null)
            //        {
            //            strLine = objReader.ReadLine();
            //            if (strLine != null)
            //            {
            //                strHtml += strLine.Trim();
            //            }
            //        }
            //    }
            //    else { strHtml = ex.Message; }

            //    result = strHtml;
            //}
            return result;
        }

        private void btn_fycx_Click(object sender, EventArgs e)
        {
            string url = GzsnhGlobal.Url + "inpCancelFee?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(tbx_djlsh.Text.Trim()) + "";
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
                if (Base64.decodebase64(param.Split(',')[0]) != "1")
                {
                    MessageBox.Show("撤销失败"); return;
                }
                int i = bllGzsnhMethod.undoUploadCostdet(ihsp_id);
                if (i == -1)
                {
                    MessageBox.Show("数据库更新失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                //Log4Net.error(Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "项目名称：" + dtyp.Rows[i]["name"].ToString() + "项目编码：" + dtyp.Rows[i]["iid"].ToString());
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            MessageBox.Show("成功！");
        }

        private void btn_cydj_Click(object sender, EventArgs e)
        {
            string returnMsg = "";
            bllGzsnhMethod.uploadDetials(ihsp_id,ref returnMsg);//费用上传
            if (string.IsNullOrEmpty(tbx_djlsh.Text))
            {
                MessageBox.Show("住院登记流水号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbx_ylzh.Text))
            {
                MessageBox.Show("医疗证号不能为空"); return;
            }
            if (string.IsNullOrEmpty(cbx_cyks.Text))
            {
                MessageBox.Show("出院科室不能为空"); return;
            }
            if (string.IsNullOrEmpty(cbx_cyzd.Text))
            {
                MessageBox.Show("出院诊断不能为空"); return;
            }
            string icd2 = "";
            if (!string.IsNullOrEmpty(cbx_dezd.Text))
                icd2 = cbx_dezd.SelectedValue.ToString();
            string icd3 = "";
            if (!string.IsNullOrEmpty(cbx_dszd.Text))
                icd3 = cbx_dszd.SelectedValue.ToString();
            string icd4 = "";
            if (!string.IsNullOrEmpty(cbxjbzd4.Text))
                icd4 = cbxjbzd4.SelectedValue.ToString();
            string icd5 = "";
            if (!string.IsNullOrEmpty(cbxjbzd5.Text))
                icd5 = cbxjbzd5.SelectedValue.ToString();
            string treated = "";
            if (!string.IsNullOrEmpty(cbx_cyzlfs.Text))
                treated = cbx_cyzlfs.SelectedValue.ToString();
            string treated2 = "";
            if (!string.IsNullOrEmpty(cbx_defs.Text))
                treated2 = cbx_defs.SelectedValue.ToString();
            string treated3 = "";
            if (!string.IsNullOrEmpty(cbx_dsfs.Text))
                treated3 = cbx_dsfs.SelectedValue.ToString();
            string treated4 = "";
            if (!string.IsNullOrEmpty(cbxZlfs4.Text))
                treated4 = cbxZlfs4.SelectedValue.ToString();
            string treated5 = "";
            if (!string.IsNullOrEmpty(cbxZlfs5.Text))
                treated5 = cbxZlfs5.SelectedValue.ToString();

            string zdjb1 = "";
            if (!string.IsNullOrEmpty(cbxZdjb1.Text))
                zdjb1 = cbxZdjb1.SelectedValue.ToString();
            string zdjb2 = "";
            if (!string.IsNullOrEmpty(cbxZdjb2.Text))
                zdjb2 = cbxZdjb2.SelectedValue.ToString();
            string zdjb3 = "";
            if (!string.IsNullOrEmpty(cbxZdjb3.Text))
                zdjb3 = cbxZdjb3.SelectedValue.ToString();
            string zdjb4 = "";
            if (!string.IsNullOrEmpty(cbxZdjb4.Text))
                zdjb4 = cbxZdjb4.SelectedValue.ToString();
            string zdjb5 = "";
            if (!string.IsNullOrEmpty(cbxZdjb5.Text))
                zdjb5 = cbxZdjb5.SelectedValue.ToString();

            
            
            string zzlx = "";
            if (cbx_cyzzlx.SelectedValue.ToString() != "3")
            {
                   ListItem item = (ListItem) cbx_cyzzlx.Items[cbx_cyzzlx.SelectedIndex];
                   zzlx = item.Value.ToString();
                 
            }
            string zyrq = "";
            if (DateTime.Parse(dtp_cyzyrq.Text) > DateTime.Parse("1990-01-02 00:00:00"))
                zyrq = DateTime.Parse(dtp_cyzyrq.Text).ToString("yyyy-MM-dd HH:mm:ss");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("治愈", "1");
            dic.Add("好转", "2");
            dic.Add("未愈", "3");
            dic.Add("死亡", "4");
            dic.Add("其他", "9");
            string cyzt_v = dic[cbx_cyzt.SelectedValue.ToString()];
            string tmp = dtp_cyrq.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string cysj = DateTime.Parse(tmp).ToString("yyyy-MM-dd HH:mm:ss");
            string url = GzsnhGlobal.Url + "leaveInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(tbx_djlsh.Text) + "&leaveDate=" + Base64.encodebase64(cysj) + "&outOfficeId=" + Base64.encodebase64(cbx_cyks.SelectedValue.ToString()) + "&outHosId=" + Base64.encodebase64(cyzt_v) + "&icdAllNo=" + Base64.encodebase64(cbx_cyzd.SelectedValue.ToString()) + "";
            url += "&secondIcdNo=" + Base64.encodebase64(icd2) + "&threeIcdNo=" + Base64.encodebase64(icd3) + "&fourNo=" + Base64.encodebase64(icd4) + "&fiveNo=" + Base64.encodebase64(icd5);
            url += "&majorDiseaseICD=" + Base64.encodebase64(zdjb1) + "&secondMajorDiseaseICD=" + Base64.encodebase64(zdjb2) + "&threeMajorDiseaseICD=" + Base64.encodebase64(zdjb3) + "&fourMajorDiseaseICD=" + Base64.encodebase64(zdjb4) + "&fiveMajorDiseaseICD=" + Base64.encodebase64(zdjb5);
            url += "&treatCode=" + Base64.encodebase64(treated) + "&secondTreatCode=" + Base64.encodebase64(treated2) + "&threeTreatCode=" + Base64.encodebase64(treated3) + "&fourTreatCode=" + Base64.encodebase64(treated4) + "&fiveTreatCode=" + Base64.encodebase64(treated5);
            url += "&turnMode=" + Base64.encodebase64(zzlx) + "&turnCode=" + Base64.encodebase64(tbx_zybm.Text) + "&turnDate=" + Base64.encodebase64(zyrq) + "&hisTotal=" + Base64.encodebase64(lbl_zyf.Text.Split(':')[1]) + "";
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
                if (Base64.decodebase64(param.Split(',')[0]) != "1")
                {
                    MessageBox.Show("出院登记失败"); return;
                }
            }
            catch (Exception ex)
            {
                //Log4Net.error(Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "项目名称：" + dtyp.Rows[i]["name"].ToString() + "项目编码：" + dtyp.Rows[i]["iid"].ToString());
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            bllGzsnhMethod.updateHisNhcyinfo(ihsp_id);
            MessageBox.Show("成功！");
        }

        private void btn_cycx_Click(object sender, EventArgs e)
        {

            string url = GzsnhGlobal.Url + "cancelLeaveInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(tbx_djlsh.Text) + "&reason=";
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
            }
            catch (Exception ex)
            {
                //Log4Net.error(Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "项目名称：" + dtyp.Rows[i]["name"].ToString() + "项目编码：" + dtyp.Rows[i]["iid"].ToString());
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            bllGzsnhMethod.cancleHisNhcyinfo(ihsp_id);
            MessageBox.Show("撤销成功！");
        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            if (!isHisihspSign())
            {
                return;
            }
            //新生儿
            double neonSum = DataTool.stringToDouble(billIhspAct.getHisNeonCostDetSum(ihsp_id));
            if (Math.Abs(neonSum) > 0.001)
            {
                MessageBox.Show("请先新生儿结算后再结算！(新生儿住院总费用为：" + neonSum);

                return ;
            }
            FrmdoAccount frmdoAccount = new FrmdoAccount();
            frmdoAccount.Ihsp_id = this.ihsp_id;
            frmdoAccount.ShowDialog();

            //string currDateTime = BillSysBase.currDate();
            // FrmdoAccount charge = new FrmdoAccount();
            // charge.Zylsh = tbx_djlsh.Text.Trim();
            // charge.Hiszyh = zyh;
            // charge.Ylfkfs = ylfkfs;
            // charge.Mtzyjl_iid = mtzyjl_iid;
            // charge.Centerno = tbx_centerno.Text;
            // charge.StartPosition = FormStartPosition.CenterScreen;
            // charge.Cysj = DateTime.Parse(dtp_cyrq.Text).ToString("yyyy-MM-dd HH:mm:ss");
            // charge.ShowDialog(this);


        }

        private void btn_jscx_Click(object sender, EventArgs e)
        {
            string url = GzsnhGlobal.Url + "cancelInpatientRedeem?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(tbx_djlsh.Text) + "";
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));

                int k = 0;//billIhspAct.cancleAccount(ihsp_account_id);
                if ( k == -1)
                {
                    MessageBox.Show("数据库更新失败");
                    return;
                }
               
                  
                      ;

            }
            catch (Exception ex)
            {
                //Log4Net.error(Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "项目名称：" + dtyp.Rows[i]["name"].ToString() + "项目编码：" + dtyp.Rows[i]["iid"].ToString());
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            MessageBox.Show("成功！");
        }

        private void btn_zysh_Click(object sender, EventArgs e)
        {
        
            FrmAudit frmAudit = new FrmAudit();
            frmAudit.Ihsp_id = this.ihsp_id;
            frmAudit.ShowDialog();
        }

        private void btn_zyfdx_Click(object sender, EventArgs e)
        {
            FrmGetTopLine frmGetTopLine = new FrmGetTopLine();
            frmGetTopLine.Ihsp_id = this.ihsp_id;
            frmGetTopLine.ShowDialog();
        }

        private void btn_zyjsddy_Click(object sender, EventArgs e)
        {
            //frmCharge charge = new frmCharge();
            //charge.Hiszyh = zyh;
            //charge.Mtzyjl_iid = mtzyjl_iid;
            //charge.zyjsdy();
        }
        private bool isHisihspSign()
        {
            if (!billIhspAct.isHisihspSign(ihsp_id))
                {
                   MessageBox.Show("当前患者未挂账，不能办理出院，请确认！");
                 return false;
               }
           return true;
        }

        private void tct_zyfymx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tct_zyfymx.SelectedIndex == 1)
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                string url = GzsnhGlobal.Url + "inpDetailSeek?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbx_centerno.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(tbx_djlsh.Text) + "";
                try
                {
                    string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                    
                    try
                    {
                        dtv_nhfy.Rows.Clear();

                        if (param.Equals("[]"))
                        {
                            return;
                        }

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
                            dtv_nhfy.Rows.Add();
                            for (int j = 0; j < result.Count; j++)
                            {
                                dtv_nhfy.Rows[i].Cells[j].Value = result[j];
                            }
                            result.Clear();
                        }
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
                    MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                    return;
                }

            }
        }

        private void cbx_cyzd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_cyzd.DisplayMember = "icdname";
                cbx_cyzd.ValueMember = "icdallno";
                cbx_cyzd.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_cyzd.Text.ToUpper()); //疾病编码
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbx_dezd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_dezd.DisplayMember = "icdname";
                cbx_dezd.ValueMember = "icdallno";
                cbx_dezd.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_dezd.Text.ToUpper()); //疾病编码
            }
        }

        private void cbx_dszd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_dszd.DisplayMember = "icdname";
                cbx_dszd.ValueMember = "icdallno";
                cbx_dszd.DataSource = bllGzsnhMethod.getnhjbxxbm(cbx_dszd.Text.ToUpper()); //疾病编码
            }
        }

        private void cbxjbzd4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxjbzd4.DisplayMember = "icdname";
                cbxjbzd4.ValueMember = "icdallno";
                cbxjbzd4.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxjbzd4.Text.ToUpper()); //疾病编码
            }
        }

        private void cbxjbzd5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxjbzd5.DisplayMember = "icdname";
                cbxjbzd5.ValueMember = "icdallno";
                cbxjbzd5.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxjbzd5.Text.ToUpper()); //疾病编码
            }
        }

        private void cbx_cyzlfs_KeyUp(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter)
            {
                cbx_cyzlfs.DisplayMember = "name";
                cbx_cyzlfs.ValueMember = "code";
                cbx_cyzlfs.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_cyzlfs.Text);//治疗方式
            }
        }

        private void cbx_defs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_defs.DisplayMember = "name";
                cbx_defs.ValueMember = "code";
                cbx_defs.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_defs.Text);//治疗方式
            }
        }

        private void cbx_dsfs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_dsfs.DisplayMember = "name";
                cbx_dsfs.ValueMember = "code";
                cbx_dsfs.DataSource = bllGzsnhMethod.getNhzlfsbm(cbx_dsfs.Text);//治疗方式
            }
        }

        private void cbxZlfs4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZlfs4.DisplayMember = "name";
                cbxZlfs4.ValueMember = "code";
                cbxZlfs4.DataSource = bllGzsnhMethod.getNhzlfsbm(cbxZlfs4.Text);//治疗方式
            }
        }

        private void cbxZlfs5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZlfs5.DisplayMember = "name";
                cbxZlfs5.ValueMember = "code";
                cbxZlfs5.DataSource = bllGzsnhMethod.getNhzlfsbm(cbxZlfs5.Text);//治疗方式
            }
        }

        private void cbxZdjb1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb1.DisplayMember = "icdname";
                cbxZdjb1.ValueMember = "icdallno";
                cbxZdjb1.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxZdjb1.Text.ToUpper()); //疾病编码
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

        private void cbxZdjb4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb4.DisplayMember = "icdname";
                cbxZdjb4.ValueMember = "icdallno";
                cbxZdjb4.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxZdjb4.Text.ToUpper()); //疾病编码
            }
        }

        private void cbxZdjb5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxZdjb5.DisplayMember = "icdname";
                cbxZdjb5.ValueMember = "icdallno";
                cbxZdjb5.DataSource = bllGzsnhMethod.getnhjbxxbm(cbxZdjb5.Text.ToUpper()); //疾病编码
            }
        }
    }
}
