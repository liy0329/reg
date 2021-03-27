using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsnh.bll;
using System.Net;
using MTREG.medinsur.gzsnh.bo;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGetTopLine : Form
    {
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        WebClient webClient = new WebClient();
        public FrmGetTopLine()
        {
            InitializeComponent();
        }
        private string ihsp_id;
        /// <summary>
        /// 住院记录ID
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string bclx = "";
            if (cbx_bclx.SelectedValue.ToString() != "0")
            {
                bclx = cbx_bclx.SelectedValue.ToString();
            }
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "getinpatientTopLine?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&year=" + Base64.encodebase64(tbx_year.Text) + "&memberNo=" + Base64.encodebase64(gzsnhRegInfo.Membersysno) + "&redeemType=" + Base64.encodebase64(bclx) + "&treatCode=" + Base64.encodebase64(cbx_zlfs.SelectedValue.ToString()) + "&totalCosts=" + Base64.encodebase64("") + "&totalEnableFee=" + Base64.encodebase64("") + "";
            string param = webClient.DownloadString(url);
            try
            {
                string[] info = param.Replace("},{", "@").Split('@');
                for (int i = 0; i < info.Length; i++)
                {
                    string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                    for (int j = 0; j < detial.Length; j++)
                    {
                        string[] data = detial[j].Split(':');
                        result.Add(j, Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                    }
                    tbx_result.Text = "个人编号:" + result[0] + "\r\n年度内已发生住院次数:" + result[1] + "\r\n年度内住院补偿总额:" + result[2] + "\r\n年度内本补偿类型补偿总额:" + result[3] + "\r\n本补偿类型年度封顶线限额:" + result[4] + "\r\n本地区普通住院年度封顶线:" + result[5] + "该参合人员截止当前时间可用补偿额:" + result[6] + "参合属性:" + result[7] + "";
                    result.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void FrmGetTopLine_Load(object sender, EventArgs e)
        {
            object[] objs = { "0", null };
            DataTable dt = new DataTable();
            DataRow dr;

            cbx_cyzd.DisplayMember = "icdname";
            cbx_cyzd.ValueMember = "icdallno";
            dt = bllGzsnhMethod.getnhjbxxbm();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_cyzd.DataSource = dt;//疾病编码

            cbx_zlfs.DisplayMember = "name";
            cbx_zlfs.ValueMember = "code";
            dt = bllGzsnhMethod.getNhzlfsbm();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_zlfs.DataSource = dt;//治疗方式

            cbx_bclx.DisplayMember = "name";
            cbx_bclx.ValueMember = "code";
            dt = bllGzsnhMethod.getHisnhbcflcx();
            dr = dt.NewRow();
            dr.ItemArray = objs;
            dt.Rows.InsertAt(dr, 0);
            cbx_bclx.DataSource = dt;//补偿类型

        }
    }
}
