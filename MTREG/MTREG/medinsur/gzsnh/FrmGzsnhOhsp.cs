using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.gzsnh.bll;
using System.Net;
using MTREG.common;
using MTREG.medinsur.gzsnh.bo;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhOhsp : Form
    {
        private string ihsp_id;
        /// <summary>
        /// 住院记录ID
        /// </summary>
        public string Ihsp_id
        {
          get { return ihsp_id; }
          set { ihsp_id = value; }
        }

        public FrmGzsnhOhsp()
        {
            InitializeComponent();
        }

        private void FrmGzsnhOhsp_Load(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            dgvIhspCase.Visible=false;
            List<ListItem> turnMode = new List<ListItem>();//转诊类型
            ListItem turnMode1 = new ListItem("正常转院","0");
            ListItem turnMode2 = new ListItem("县外就医转诊","1");
            ListItem turnMode3 = new ListItem("转院","2");
            ListItem turnMode4 = new ListItem("其他","3");
            ListItem turnMode5 = new ListItem("", "");
            turnMode.Add(turnMode1);
            turnMode.Add(turnMode2);
            turnMode.Add(turnMode3);
            turnMode.Add(turnMode4);
            turnMode.Add(turnMode5);
            cmbTurnMode.DisplayMember = "Text";
            cmbTurnMode.ValueMember = "Value";
            cmbTurnMode.DataSource = turnMode;
            cmbTurnMode.SelectedIndex = 3;

            List<ListItem> ohspState = new List<ListItem>();//出院状态
            ListItem ohspState1 = new ListItem("治愈","1");
            ListItem ohspState2 = new ListItem("好转","2");
            ListItem ohspState3 = new ListItem("未愈","3");
            ListItem ohspState4 = new ListItem("死亡","4");
            ListItem ohspState5 = new ListItem("其他","9");
            ohspState.Add(ohspState1);
            ohspState.Add(ohspState2);
            ohspState.Add(ohspState3);
            ohspState.Add(ohspState4);
            ohspState.Add(ohspState5);
            cmbOutHosId.DataSource = ohspState;
            cmbOutHosId.DisplayMember = "Text";
            cmbOutHosId.ValueMember = "Value";
            cmbOutHosId.SelectedIndex = 1;
             
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            string fee=bllGzsnhMethod.getCostFee(ihsp_id);
            lblHisTotal.Text = fee;
        }
        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuthsp_Click(object sender, EventArgs e)
        {                       
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            bllGzsnhMethod.costTransfer(ihsp_id);
            WebClient webClient = new WebClient();
            if (string.IsNullOrEmpty(tbxIhspicd.Text))
            {
                MessageBox.Show("出院诊断不能为空"); return;
            }
            string zyrq = "";
            if (DateTime.Parse(dtpTurnDate.Text) > DateTime.Parse("1990-01-02 00:00:00"))
            {
                zyrq = DateTime.Parse(dtpTurnDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string outdate = dtpOutDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "leaveInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&leaveDate=" + Base64.encodebase64(outdate) + "&outOfficeId=" + Base64.encodebase64(cmbDepart.SelectedValue.ToString()) + "&outHosId=" + Base64.encodebase64(cmbOutHosId.SelectedValue.ToString()) + "&icdAllNo=" + Base64.encodebase64(tbxIhspicd.Text.ToString()) + "";
            url += "&secondIcdNo=" + Base64.encodebase64("") + "&threeIcdNo=" + Base64.encodebase64("") + "&fourNo=" + Base64.encodebase64("") + "&fiveNo=" + Base64.encodebase64("");
            url += "&treatCode=" + Base64.encodebase64(cmbTreatCode.SelectedValue.ToString()) + "&secondTreatCode=" + Base64.encodebase64("") + "&threeTreatCode=" + Base64.encodebase64("") + "&fourTreatCode=" + Base64.encodebase64("") + "&fiveTreatCode=" + Base64.encodebase64("");
            url += "&turnMode=" + Base64.encodebase64(cmbTurnMode.SelectedValue.ToString()) + "&turnCode=" + Base64.encodebase64(tbxCode.Text) + "&turnDate=" + Base64.encodebase64(zyrq) + "&hisTotal=" + Base64.encodebase64(lblHisTotal.Text) + "";
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
                MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            int flag = bllGzsnhMethod.upinsurstat(ihsp_id,Insurstat.SIGN.ToString());
            if (flag < 0)
            {
                MessageBox.Show("出院登记成功！医保状态修改失败");
            }
            MessageBox.Show("成功！");
        }

        /// <summary>
        /// 取消出院登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qxcydj_Click(object sender, EventArgs e)
        {
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            WebClient webClient = new WebClient();
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "cancelLeaveInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&reason=";
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
            int flag = bllGzsnhMethod.upinsurstat(ihsp_id, Insurstat.REG.ToString());
            if (flag < 0)
            {
                MessageBox.Show("出院登记成功！医保状态修改失败");
            }
            MessageBox.Show("撤销成功！");
        }
    }
}
