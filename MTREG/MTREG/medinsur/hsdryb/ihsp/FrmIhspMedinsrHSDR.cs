using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTHIS.common;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hdyb.clinic.bo;
using System.Web.UI.WebControls;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.ihsp
{
    public partial class FrmIhspMedinsrHSDR : Form
    {
        public FrmIhspMedinsrHSDR()
        {
            InitializeComponent();
        }
        private InsurInfo insurInfo;

        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }
        BllIhspMedinsrHSDR bllIhspMedinsrHSDR = new BllIhspMedinsrHSDR();
        FrmIhspReg frmIhspReg;
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }
        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        private void FrmIhspMedinsrHSDR_Load(object sender, EventArgs e)
        {
            //加载下拉列表
            loadSelectDrop();
            readPersonalInfo();
            dgvClinicDiagn.Visible = false;
        }
        private void loadSelectDrop()
        {
            //患者类型的初始化
            var dtp = bllIhspMedinsrHSDR.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = patientType;
            //医疗类别
            List<ListItem> itemsMedi = new List<ListItem>();
            itemsMedi.Add(new ListItem("普通住院", "36"));
            this.cmbMediType.DisplayMember = "Text";
            this.cmbMediType.ValueMember = "Value";
            this.cmbMediType.DataSource = itemsMedi;
            this.cmbMediType.SelectedValue = "36";

            //人员类别初始化
            List<ListItem> itemtype = new List<ListItem>();
            itemtype.Add(new ListItem("在职","11"));
            itemtype.Add(new ListItem("退休", "21"));
            itemtype.Add(new ListItem("普通离休(非地市)", "31"));
            itemtype.Add(new ListItem("普通离休(地市级)", "33"));
            itemtype.Add(new ListItem("特殊离休", "34"));
            itemtype.Add(new ListItem("学生全额", "60"));
            itemtype.Add(new ListItem("低保学生", "61"));
            itemtype.Add(new ListItem("重残学生", "62"));
            itemtype.Add(new ListItem("普通居民", "63"));
            itemtype.Add(new ListItem("低保居民", "64"));
            itemtype.Add(new ListItem("伤残居民", "65"));
            itemtype.Add(new ListItem("学生大额", "66"));
            this.cmbAKC021.DisplayMember = "Text";
            this.cmbAKC021.ValueMember = "Value";
            this.cmbAKC021.DataSource = itemtype;
            this.cmbAKC021.SelectedValue = "63";
        }
        /// <summary>
        /// 读人员基本信息和账户信息
        /// </summary>
        private void readPersonalInfo()
        {
            WYJK wyjk = new WYJK();//函数调用类
            InOutParameter parameter = new InOutParameter(); //输入输出参数类
            TopParameter common = new TopParameter(); //头参数类
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.AKC190 = "";
            common.AKC020 = "";
            common.AKA130 = "";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.MSGNO = "1401";
            common.KC22XML = "";

            parameter = wyjk.dryjbxxzhxx(common);

            tbxCompanyNum.Text = parameter.AAB001;
            tbxCompanyName.Text = parameter.AAB004;
            tbxPersonalNum.Text = parameter.AAC001;
            tbxICCardID.Text = parameter.AKC020;
            tbxIDCard.Text = parameter.AAC002;
            tbxName.Text = parameter.AAC003;
            tbxSex.Text = parameter.AAC004;
            if (parameter.AAC006 != "" && parameter.AAC006 != null)
            {
                try
                {
                    string year = parameter.AAC006.Substring(0, 4);
                    string moths = parameter.AAC006.Substring(4, 2);
                    string dys = parameter.AAC006.Substring(6, 2);
                    string time = year + "-" + moths + "-" + dys;
                    parameter.AAC006 = Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                    this.dtpBirth.Value = Convert.ToDateTime(parameter.AAC006);
                }
                catch (Exception ex) { }
            }
            dtpBirth.Text = parameter.AAC006;
            tbxBalance.Text = parameter.AKC087;
            //判断住院状态
            if (parameter.ZKC031 == "1" || parameter.ZKC031 == "2")
            {
                MessageBox.Show("此人目前为住院状态，不能进行住院登记操作！", "提示信息");
                return;
            }
            if (parameter.ReturnNum != "-1" && parameter != null)
            {
                QFXXCX();
                MXBSPXXCX();
            }
            else
            {
                if (parameter == null)
                {
                    MessageBox.Show("读卡失败！");
                }
                else
                {
                    MessageBox.Show(parameter.ErrorMsg);
                }
            }
            // insurInfo.PatientType = parameter.Rylb;
            insurInfo.Balance = parameter.AKC087;
            insurInfo.Companyname = parameter.AAB004;
            insurInfo.Companynum = parameter.AAB001;
            insurInfo.Iccardid = parameter.AKC020;
            insurInfo.Idcard = parameter.AAC002;
            insurInfo.Name = parameter.AAC003;
            insurInfo.PersonalNum = parameter.AAC001;
            insurInfo.Sex = parameter.AAC004;
            insurInfo.Birth = dtpBirth.Value.ToString();
            //insurInfo.Insurfee = ;
            //insurInfo.Selffee = ;
            insurInfo.Ihsptype = cmbMediType.SelectedValue.ToString();
            //insurInfo.Ihspdiagn = ;
            insurInfo.Clinicicd = lblClinicDisease.Text.ToString();
            //insurInfo.Clinicdiagn = ;
            insurInfo.Approvenum = txtApproDiseaseCode.Text.Trim();
            lblSuccess.Text = "读卡成功！";
            return;
        }
        /// <summary>
        /// 人员欠费信息查询
        /// </summary>
        private void QFXXCX()
        {
            TopParameter common = new TopParameter();
            InOutParameter parameter = new InOutParameter();
            WYJK wyjk = new WYJK();
            DataTable dt = new DataTable();
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.AKC190 = "";
            common.AKC020 = tbxICCardID.Text.Trim();
            common.AKA130 = "";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.MSGNO = "1714";
            common.INPUT = string.Format("<AAC001>{0}</AAC001><AAZ500>{1}</AAZ500><AKA130>{2}</AKA130><BKC192>{3}</BKC192><BKC194>{4}</BKC194>",
                tbxPersonalNum.Text.Trim(), tbxICCardID.Text.Trim(), cmbMediType.SelectedValue.ToString(), Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMdd"), Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMdd"));
            parameter = wyjk.cbryqfztcx(common, out dt);
            if (parameter.Output == "0")
            {
                tbxIsBlock.Text = "正常";
                insurInfo.Isblock = "0";
            }
            else
            {
                tbxIsBlock.Text = "欠费：" + parameter.Output;
                insurInfo.Isblock = "-1";
            }
        }
        /// <summary>
        /// 慢性病审批信息查询
        /// </summary>
        private void MXBSPXXCX()
        {
            TopParameter common = new TopParameter();
            InOutParameter parameter = new InOutParameter();
            WYJK wyjk = new WYJK();
            DataTable dt = new DataTable();
            //初始化TOP信息
            common.AAE140 = "0";
            common.AAC001 = "0";
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.AKC190 = "";
            common.AKC020 = tbxICCardID.Text.Trim();
            common.AKA130 = "";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.MSGNO = "1910";
            common.INPUT = string.Format("<AAC001>{0}</AAC001>", tbxPersonalNum.Text.Trim());
            parameter = wyjk.mxbspxxcx(common, out dt);
            if (parameter.ReturnNum == "0")
            {
                txtApproDisease.Text = dt.Rows[0]["AKA121"].ToString();
                txtApproDiseaseCode.Text = dt.Rows[0]["BKC462"].ToString();
            }
        }
        private void tbxClinicDisease_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dgvClinicDiagn.Visible = true;
                dgvClinicDiagn.BringToFront();
                setDgvSource(tbxClinicDisease.Text.Trim());
                dgvClinicDiagn.Rows[0].Selected = true;
                dgvClinicDiagn.Focus();
            }
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            dgvClinicDiagn.DataSource = bllIhspMedinsrHSDR.getClinicDisease(pincode);
            this.dgvClinicDiagn.Columns["id"].Visible = false;
            this.dgvClinicDiagn.Columns["name"].Width = 161;
            this.dgvClinicDiagn.Columns["illcode"].Visible = false;
        }
        private void dgvClinicDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvClinicDiagn.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvClinicDiagn.CurrentRow != null)
                {
                    tbxClinicDisease.Text = dgvClinicDiagn.SelectedRows[0].Cells["name"].Value.ToString();
                    lblClinicDisease.Text = dgvClinicDiagn.SelectedRows[0].Cells["illcode"].Value.ToString();
                    dgvClinicDiagn.Visible = false;
                    dgvClinicDiagn.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index > 0)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index < dgvClinicDiagn.Rows.Count - 1)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            this.FrmIhspReg.InsurInfo.PatientType = cmbPatientType.SelectedValue.ToString();
            this.FrmIhspReg.InsurInfo.Balance = tbxBalance.Text;
            this.FrmIhspReg.InsurInfo.Companyname = tbxCompanyName.Text;
            this.FrmIhspReg.InsurInfo.Companynum = tbxCompanyNum.Text;
            this.FrmIhspReg.InsurInfo.Iccardid = tbxICCardID.Text;
            this.FrmIhspReg.InsurInfo.Idcard = tbxIDCard.Text;
            this.FrmIhspReg.InsurInfo.Isblock = tbxIsBlock.Text;
            this.FrmIhspReg.InsurInfo.Name = tbxName.Text;
            this.FrmIhspReg.InsurInfo.PersonalNum = tbxPersonalNum.Text;
            this.FrmIhspReg.InsurInfo.Sex = tbxSex.Text;
            this.FrmIhspReg.InsurInfo.Birth = dtpBirth.Value.ToString();
            this.FrmIhspReg.InsurInfo.Ihsptype = cmbMediType.SelectedValue.ToString();
            //个人编号|ic卡号|医疗类别|账户余额|单位编号|单位名称|封锁状态|经办人|入院诊断疾病编码|疾病名称|人员类别
            string insurinfo = tbxPersonalNum.Text + "|" + tbxICCardID.Text + "|" +  cmbMediType.SelectedValue.ToString() + "|" 
                + tbxBalance.Text + "|" + tbxCompanyNum.Text + "|" + tbxCompanyName.Text +"|" + tbxIsBlock.Text + "|" + ProgramGlobal.Username
                + "|" + lblClinicDisease.Text.Trim() + "|" + tbxClinicDisease.Text.Trim() + "|" + cmbAKC021.SelectedValue.ToString();
            this.FrmIhspReg.Registinfo = insurinfo;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
