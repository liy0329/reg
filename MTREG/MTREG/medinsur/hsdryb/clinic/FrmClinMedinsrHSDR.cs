using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hsdryb.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.hsdryb.bo;
using MTHIS.common;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.common;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmClinMedinsrHSDR : Form
    {
        public FrmClinMedinsrHSDR()
        {
            InitializeComponent();
        }
        private InsurInfo insurInfo;

        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }
        BllClinMedinsrHSDR bllMedinsrHSDR = new BllClinMedinsrHSDR();
        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }
        private void FrmMedinsrHSDR_Load(object sender, EventArgs e)
        { 
            //加载下拉列表
            loadSelectDrop();
            readPersonalInfo();
            dgvClinicDiagn.Visible = false;
        }
        private void loadSelectDrop()
        {
            //患者类型的初始化
            var dtp = bllMedinsrHSDR.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            SetValue();
            //医疗类别
            List<ListItem> itemsMedi = new List<ListItem>();
            itemsMedi.Add(new ListItem("普通门诊", "11"));
            itemsMedi.Add(new ListItem("药店划卡", "12"));
            itemsMedi.Add(new ListItem("门诊慢性病","13"));
            itemsMedi.Add(new ListItem("门诊统筹", "21"));
            itemsMedi.Add(new ListItem("普通住院", "36"));
            this.cmbMediType.DisplayMember = "Text";
            this.cmbMediType.ValueMember = "Value";
            this.cmbMediType.DataSource = itemsMedi;
            this.cmbMediType.SelectedValue = "11";
            
            ////审批类别
            //List<ListItem> itemsAppro = new List<ListItem>();
            //itemsAppro.Add(new ListItem("","-1"));
            //itemsAppro.Add(new ListItem("特殊检查", "1"));
            //itemsAppro.Add(new ListItem("特殊治疗", "2"));
            //itemsAppro.Add(new ListItem("急诊抢救", "3"));
            //itemsAppro.Add(new ListItem("门诊特殊病", "4"));
            //itemsAppro.Add(new ListItem("门诊慢性病", "6"));
            //itemsAppro.Add(new ListItem("外检外治", "8"));
            //itemsAppro.Add(new ListItem("医院取消报销", "9"));
            //itemsAppro.Add(new ListItem("外检外治", "10"));
            //itemsAppro.Add(new ListItem("灵活人员重大疾病", "11"));
            //itemsAppro.Add(new ListItem("医保转非医保审批", "12"));
            //itemsAppro.Add(new ListItem("非医保转医保审批", "14"));
            //this.cmbApproType.DisplayMember = "Text";
            //this.cmbApproType.ValueMember = "Value";
            //this.cmbApproType.DataSource = itemsAppro;
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
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");
                return ;
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
            //insurInfo.Clinicdiagn = ;
            insurInfo.Approvenum = txtApproDiseaseCode.Text.Trim();
            insurInfo.ApproveType = txtApproDisease.Text.Trim();
            lblSuccess.Text = "读卡成功！";
            return ;
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
            parameter = wyjk.cbryqfztcx(common,out dt);
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
            parameter = wyjk.mxbspxxcx(common,out dt);
            if (parameter.ReturnNum == "0")
            {
                txtApproDisease.Text = dt.Rows[0]["AKA121"].ToString();
                txtApproDiseaseCode.Text = dt.Rows[0]["BKC462"].ToString();
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            insurInfo.PatientType = cmbPatientType.SelectedValue.ToString();
            insurInfo.Clinicicd = lblClinicDisease.Text.ToString();
            insurInfo.Cliniciname = tbxClinicDisease.Text.ToString();
            if (lblSuccess.Text == "读卡成功！")
            {
                insurInfo.Msg = "0";
            }
            else
            {
                insurInfo.Msg = "-1";
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dgvClinicDiagn.DataSource = bllMedinsrHSDR.getClinicDisease(pincode);
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
    }
}
