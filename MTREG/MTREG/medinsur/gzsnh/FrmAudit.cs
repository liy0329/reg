using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh.bll;
using System.Net;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmAudit : Form
    {
        WebClient webClient = new WebClient();
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        public FrmAudit()
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

        /// <summary>
        /// 审核状态查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            Dictionary<int, string> result = new Dictionary<int, string>();
            string type = "";
            if (cbx_typeno.SelectedValue.ToString() != "0")
                type = cbx_typeno.SelectedValue.ToString();
            string url = GzsnhGlobal.Url + "auditingSeek?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&typeNo=" + Base64.encodebase64(type) + "";
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
                    string state = "";
                    switch (result[0])
                    {
                        case "01":
                            state = "未审核"; break;
                        case "02":
                            state = "初审通过"; break;
                        case "03":
                            state = "复审通过"; break;
                        case "09":
                            state = "审核不通过"; break;
                        case "00":
                            state = "无待审核信息"; break;
                    }
                    tbx_shjg.Text = "审核状态:" + state + "\r\n专家意见:" + result[1] + "\r\n省农合管理部门意见:" + result[2] + "\r\n审核不通过原因:" + result[3] + "\r\n";
                    result.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void FrmAudit_Load(object sender, EventArgs e)
        {
            List<ListItem> item = new List<ListItem>();//登记状态
            ListItem item1 = new ListItem("1", "超出临床路径");
            ListItem item2 = new ListItem("2", "终止治疗");
            ListItem item3 = new ListItem("0", "撤销申请");
            item.Add(item1);
            item.Add(item2);
            item.Add(item3);
            cbx_sqlx.DisplayMember = "Text";
            cbx_sqlx.ValueMember = "Value";
            cbx_sqlx.DataSource = item;
            cbx_sqlx.SelectedValue = "0";

            List<ListItem> type = new List<ListItem>();//登记状态
            ListItem type1 = new ListItem("1", "超出临床路径");
            ListItem type2 = new ListItem("2", "终止治疗审核");
            ListItem type3 = new ListItem("0", "");
            item.Add(type1);
            item.Add(type2);
            item.Add(type3);
            cbx_typeno.DisplayMember = "Text";
            cbx_typeno.ValueMember = "Value";
            cbx_typeno.DataSource = type;
            cbx_typeno.SelectedValue = "0";
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommite_Click(object sender, EventArgs e)
        {
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "inUpAudit?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&type=" + Base64.encodebase64(cbx_sqlx.SelectedValue.ToString()) + "&reason=" + Base64.encodebase64(tbx_reason.Text) + "";
            try
            {
                Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
            }
            catch
            {
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            MessageBox.Show("成功");
        }
    }
}
