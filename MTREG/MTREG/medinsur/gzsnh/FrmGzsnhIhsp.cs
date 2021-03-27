using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh.bo;
using System.Web.UI.WebControls;
using MTREG.ihsp;
using MTREG.common;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhIhsp : Form
    {
        WebClient webClient = new WebClient();
        BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
        FrmIhspReg frmIhspReg;
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }

        public FrmGzsnhIhsp()
        {
            InitializeComponent();
        }

        private void FrmGzsnhIhsp_Load(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            tbxCenterNo.Text = GzsnhGlobal.CenterNo;
            tbxHospcode.Text = GzsnhGlobal.HospCode;
            dgvAreaInfo.Visible = false;
            dgvIhspCase.Visible = false;
            dgvPersonInfo.Visible = false;
            dgvReferral.Visible = false;
            List<ListItem> zjlx = new List<ListItem>();//证件类型
            ListItem zjlx1 = new ListItem("医疗证（卡）号","0");
            ListItem zjlx2 = new ListItem("身份证号", "1");
            ListItem zjlx3 = new ListItem("监护人身份证号","2");
            zjlx.Add(zjlx1);
            zjlx.Add(zjlx2);
            zjlx.Add(zjlx3);
            cmbType.DisplayMember = "Text";
            cmbType.ValueMember = "Value";
            cmbType.DataSource = zjlx;
            cmbType.SelectedValue = "0";

            List<ListItem> jzlx = new List<ListItem>();//就诊类型
            ListItem jzlx1 = new ListItem("门诊","1");
            ListItem jzlx2 = new ListItem("住院","2");
            ListItem jzlx3 = new ListItem("体格检查", "3");
            ListItem jzlx4 = new ListItem("正常分娩住院", "4");
            ListItem jzlx5 = new ListItem("其他", "9");
            jzlx.Add(jzlx1);
            jzlx.Add(jzlx2);
            jzlx.Add(jzlx3);
            jzlx.Add(jzlx4);
            jzlx.Add(jzlx5);
            cmbJzlx.DisplayMember = "Text";
            cmbJzlx.ValueMember = "Value";
            cmbJzlx.DataSource = jzlx;
            cmbJzlx.SelectedValue = "2";


            List<ListItem> zzlx = new List<ListItem>();//转诊类型
            ListItem zzlx1 = new ListItem("正常转院","0");
            ListItem zzlx2 = new ListItem("县外就医转诊","1");
            ListItem zzlx3 = new ListItem("转院","2");
            ListItem zzlx4 = new ListItem("其他", "3");
            zzlx.Add(zzlx1);
            zzlx.Add(zzlx2);
            zzlx.Add(zzlx3);
            zzlx.Add(zzlx4);
            cmbZzlx.DisplayMember = "Text";
            cmbZzlx.ValueMember = "Value";
            cmbZzlx.DataSource = zzlx;
            cmbZzlx.SelectedValue = "3";

            List<ListItem> xsexb = new List<ListItem>();//新生儿性别
            ListItem xsexb1 = new ListItem("男","1");
            ListItem xsexb2 = new ListItem("女","2");
            xsexb.Add(xsexb1);
            xsexb.Add(xsexb2);
            cmbSex.DisplayMember = "Text";
            cmbSex.ValueMember = "Value";
            cmbSex.DataSource = xsexb;
            cmbNewSex.DisplayMember = "Text";
            cmbNewSex.ValueMember = "Value";
            cmbNewSex.DataSource = xsexb;


            DataTable dtTreat=bllGzsnhMethod.getNhzlfsbm();
            if (dtTreat.Rows.Count > 0)
            {
                this.cmbTreatCode.DisplayMember = "name";
                this.cmbTreatCode.ValueMember = "code";
                this.cmbTreatCode.DataSource = dtTreat;
            }

            DataTable dtOps = bllGzsnhMethod.getOpsInfo();
            this.cmbOpsId.DisplayMember = "name2";
            this.cmbOpsId.ValueMember = "insurcode";
            this.cmbOpsId.DataSource = dtOps;

        }
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPersonInfo_Click(object sender, EventArgs e)
        {
            dgvPersonInfo.Rows.Clear();
            if (string.IsNullOrEmpty(tbxCardCode.Text))
                return;
            dgvPersonInfo.Visible = true;
            Dictionary<int, string> result = new Dictionary<int, string>();
            string identify = "";
            switch (cmbType.SelectedValue.ToString())
            {
                case "0":
                    identify = "&bookno=" + Base64.encodebase64(tbxCardCode.Text.Trim()) + "&idcardno=&guardianCardno=";
                    break;
                case "1":
                    identify = "&bookno=&idcardno=" + Base64.encodebase64(tbxCardCode.Text.Trim()) + "&guardianCardno=";
                    break;
                case "2":
                    identify = "&bookno=&idcardno=&guardianCardno=" + Base64.encodebase64(tbxCardCode.Text.Trim()) + "";
                    break;
            }
            string year = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy");
            string url = GzsnhGlobal.Url + "getPersonInfo?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + identify + "&year=" + Base64.encodebase64(year) + "";
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
                        dgvPersonInfo.Rows.Add();
                        for (int j = 0; j < result.Count; j++)
                        {
                            dgvPersonInfo.Rows[i].Cells[j].Value = result[j];
                        }
                        result.Clear();
                    }
                    //ypflxz();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()); dgvPersonInfo.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", ""))); 
                dgvPersonInfo.Visible = false;
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpPersonInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxCardCode.Text = dgvPersonInfo.CurrentRow.Cells["bookNo"].Value.ToString();
            cmbType.SelectedValue = "0";
            tbxFamilySysno.Text = dgvPersonInfo.CurrentRow.Cells["familySysno"].Value.ToString();
            tbxGrbm.Text= dgvPersonInfo.CurrentRow.Cells["memberNO"].Value.ToString();
            tbxIdcard.Text = dgvPersonInfo.CurrentRow.Cells["idcardNo"].Value.ToString();
            tbxName.Text = dgvPersonInfo.CurrentRow.Cells["name"].Value.ToString();
            cmbSex.SelectedValue = dgvPersonInfo.CurrentRow.Cells["sexid"].Value.ToString();
            tbxAge.Text = dgvPersonInfo.CurrentRow.Cells["age"].Value.ToString();
            tbxAddress.Text = dgvPersonInfo.CurrentRow.Cells["familyAddress"].Value.ToString();
            tbxBirthday.Text = dgvPersonInfo.CurrentRow.Cells["birthday"].Value.ToString();
            tbxPhone.Text = dgvPersonInfo.CurrentRow.Cells["tel"].Value.ToString();
            dgvPersonInfo.Visible = false;
        }

        /// <summary>
        /// 获取转诊单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReferral_Click(object sender, EventArgs e)
        {
            dgvReferral.Visible = true;
            if (tbxCenterNo.Text.ToString() == "")
            {
                MessageBox.Show("农合中心编码不能为空");
                return;
            }
            if (tbxGrbm.Text.ToString() == "")
            {
                MessageBox.Show("个人编号不能为空");
                return;
            }
            Dictionary<int, string> result = new Dictionary<int, string>();
            string url = GzsnhGlobal.Url + "downloadReferralsheet?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(tbxCenterNo.Text.ToString()) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&turnCode=" + Base64.encodebase64("") + "&memberNo=" + Base64.encodebase64(tbxGrbm.Text.ToString());
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

                            dgvReferral.Rows.Add();
                            for (int j = 0; j < result.Count; j++)
                            {
                                dgvPersonInfo.Rows[i].Cells[j].Value = result[j];
                            }
                            result.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("该病人未有转入我院的转诊单");
                        return;
                    }
                    dgvReferral.Visible = true;
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

        /// <summary>
        /// 确定传递数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxFamilySysno.Text))
            {
                MessageBox.Show("家庭编号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbxGrbm.Text))
            {
                MessageBox.Show("个人编号不能为空"); return;
            }
            if (string.IsNullOrEmpty(tbxCenterNo.Text))
            {
                MessageBox.Show("农合中心编码不能为空"); return;
            }           
            string ops = "";
            if (cmbOpsId.SelectedValue.ToString() != "0")
                ops = cmbOpsId.SelectedValue.ToString();
            string treat = "";
            if (cmbTreatCode.SelectedValue.ToString() != "0")
                treat = cmbTreatCode.SelectedValue.ToString();
            if (string.IsNullOrEmpty(tbxCenterNo.Text))
            {
                MessageBox.Show("农合中心编码不能为空"); return;
            }
            if (cmbJzlx.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("就诊类型不能为空"); return;
            }
            string turn = "";
            if (cmbZzlx.SelectedValue.ToString() != "3")
                turn = cmbZzlx.SelectedValue.ToString();
            string turndate = "";
            if (DateTime.Parse(dtpTurnDate.Text).ToString("yyyy-MM-dd HH:mm:ss") != "1990-01-01 00:00:00")
                turndate = DateTime.Parse(dtpTurnDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            string born = "0";
            string bornb = "";
            string bornn = "";
            string borns = "";
            if (cbxIsNewborn.Checked)
            {
                born = "1";
                if (DateTime.Parse(dtpNewBirthday.Text).ToString("yyyy-MM-dd HH:mm:ss") == "1990-01-01 00:00:00")
                {
                    MessageBox.Show("新生儿出生日期不能为空"); return;
                }
                if (string.IsNullOrEmpty(tbxNewName.Text))
                {
                    MessageBox.Show("新生儿姓名不能为空"); return;
                }
                bornb = DateTime.Parse(dtpNewBirthday.Text).ToString("yyyy-MM-dd HH:mm:ss");
                bornn = tbxNewName.Text;
                borns = cmbNewSex.SelectedValue.ToString();
            }

            frmIhspReg.GzsnhRegInfo.Type = "1";
            frmIhspReg.GzsnhRegInfo.Familysysno = this.tbxFamilySysno.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Membersysno = this.tbxGrbm.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Icdallno = this.tbxIhspdiagn.Text;
            frmIhspReg.GzsnhRegInfo.Stature = this.tbxStature.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Weight = this.tbxWeight.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Opsid = ops;
            frmIhspReg.GzsnhRegInfo.Inofficeid = cmbDepart.SelectedValue.ToString();
            frmIhspReg.GzsnhRegInfo.Treatcode = treat;
            frmIhspReg.GzsnhRegInfo.Cureid = cmbJzlx.SelectedValue.ToString();
            frmIhspReg.GzsnhRegInfo.Complication = tbxComplication.Text;
            frmIhspReg.GzsnhRegInfo.Curedoctor = tbxCureDoctor.Text;
            frmIhspReg.GzsnhRegInfo.Bedno = tbxBedNo.Text;
            frmIhspReg.GzsnhRegInfo.Sectionno = tbxSectionNo.Text;
            frmIhspReg.GzsnhRegInfo.Turnmode = turn;
            frmIhspReg.GzsnhRegInfo.Turncode = tbxTurnCode.Text;
            frmIhspReg.GzsnhRegInfo.Turndate = turndate;
            frmIhspReg.GzsnhRegInfo.Ticketno = tbxTicketNo.Text;
            frmIhspReg.GzsnhRegInfo.Ministernotice = tbxTel.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Procreatenotice = tbxProcreatNotice.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Tel = tbxMinisterNotice.Text.Trim();
            frmIhspReg.GzsnhRegInfo.Isnewborn = born;
            frmIhspReg.GzsnhRegInfo.Newbornbirthday = bornb;
            frmIhspReg.GzsnhRegInfo.Newbornname = bornn;
            frmIhspReg.GzsnhRegInfo.Newbornsex = borns;
            this.Close();
            this.Dispose();
        }

        private void dtpReferral_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbZzlx.SelectedIndex = 2;
            tbxTurnCode.Text = dgvReferral.CurrentRow.Cells[0].Value.ToString();
            dtpTurnDate.Value = DateTime.Parse(dgvReferral.CurrentRow.Cells[3].Value.ToString());
            dgvReferral.Visible = false;
            dgvReferral.Columns.Clear();
        }

        private void dtv_nhzxbm_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxCenterNo.Text = dgvAreaInfo.CurrentRow.Cells["areacode"].Value.ToString();
            tbxHospcode.Text = dgvAreaInfo.CurrentRow.Cells["hospitalcode"].Value.ToString();
            GzsnhGlobal.CenterNo = dgvAreaInfo.CurrentRow.Cells["areacode"].Value.ToString();
            GzsnhGlobal.HospCode = dgvAreaInfo.CurrentRow.Cells["hospitalcode"].Value.ToString();
            GzsnhGlobal.Url = dgvAreaInfo.CurrentRow.Cells["weburl"].Value.ToString();
            GzsnhGlobal.UserName = dgvAreaInfo.CurrentRow.Cells["username"].Value.ToString();
            GzsnhGlobal.UserPwd = dgvAreaInfo.CurrentRow.Cells["password"].Value.ToString();
            dgvAreaInfo.Visible = false;
            dgvAreaInfo.Columns.Clear();
        }

        /// <summary>
        /// 获取农合编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCenterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvAreaInfo.Visible = true;
                DataTable dt= bllGzsnhMethod.getAreaInfo(tbxCenterNo.Text);
                dgvAreaInfo.DataSource = dt;
            }
        }

        private void dgvIhspCase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvIhspCase.CurrentRow != null)
            {
                tbxIhspdiagn.Text=dgvIhspCase.CurrentRow.Cells["illcode"].Value.ToString();
                dgvIhspCase.Visible = false;
                dgvIhspCase.Columns.Clear();
            }
        }

        private void dgvIhspCase_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIhspCase.CurrentRow != null)
            {
                tbxIhspdiagn.Text = dgvIhspCase.CurrentRow.Cells["illcode"].Value.ToString();
                dgvIhspCase.Visible = false;
                dgvIhspCase.Columns.Clear();
            }
        }

        private void tbxIhspdiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvIhspCase.Visible = true;
                dgvIhspCase.DataSource = bllGzsnhMethod.getICDInfo(tbxIhspdiagn.Text);
                dgvIhspCase.Columns["name"].HeaderText = "疾病名称";
                dgvIhspCase.Columns["illcode"].HeaderText = "疾病编码";
                dgvIhspCase.ReadOnly = true;
            }
        }       
    }
}
