using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp;
using MTREG.medinsur.hsdryb.bo;
using MTHIS.common;
using MTREG.medinsur.hsdryb.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTREG.medinsur.bll;
using MTREG.common;

namespace MTREG.medinsur.hsdryb.ihsp
{
    public partial class FrmOutHspMedinsrHSDR : Form
    {
        public FrmOutHspMedinsrHSDR()
        {
            InitializeComponent();
        }
        BllIhspMedinsrHSDR bllIhspMedinsrHSDR = new BllIhspMedinsrHSDR();
        FrmIhspAccount frmIhspAccount;
        public FrmIhspAccount FrmIhspAccount
        {
            get { return frmIhspAccount; }
            set { frmIhspAccount = value; }
        }
        private string id;
        /// <summary>
        /// 住院号id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string patientType;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOutHspMedinsrHSDR_Load(object sender, EventArgs e)
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
            itemtype.Add(new ListItem("在职", "11"));
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
            this.frmIhspAccount.InsurInfo.Balance = parameter.AKC087;
            this.frmIhspAccount.InsurInfo.Companyname = parameter.AAB004;
            this.frmIhspAccount.InsurInfo.Companynum = parameter.AAB001;
            this.frmIhspAccount.InsurInfo.Iccardid = parameter.AKC020;//卡号
            this.frmIhspAccount.InsurInfo.Idcard = parameter.AAC002;
            this.frmIhspAccount.InsurInfo.Name = parameter.AAC003;
            this.frmIhspAccount.InsurInfo.PersonalNum = parameter.AAC001;
            this.frmIhspAccount.InsurInfo.Sex = parameter.AAC004;
            this.frmIhspAccount.InsurInfo.Birth = dtpBirth.Value.ToString();
            //insurInfo.Insurfee = ;
            //insurInfo.Selffee = ;
            this.frmIhspAccount.InsurInfo.Ihsptype = cmbMediType.SelectedValue.ToString();//医疗类别
            //insurInfo.Ihspdiagn = ;
            this.frmIhspAccount.InsurInfo.Clinicicd = lblClinicDisease.Text.ToString();
            //insurInfo.Clinicdiagn = ;
            this.frmIhspAccount.InsurInfo.Approvenum = txtApproDiseaseCode.Text.Trim();
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
                this.frmIhspAccount.InsurInfo.Isblock = "0";
            }
            else
            {
                tbxIsBlock.Text = "欠费：" + parameter.Output;
                this.frmIhspAccount.InsurInfo.Isblock = "-1";
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
        private void btnOk_Click(object sender, EventArgs e)
        {

            TopParameter common = new TopParameter();
            DataTable dt  = bllIhspMedinsrHSDR.getIhspcode(id);
            string ihspcode = "";
            if(dt.Rows.Count>0)
                ihspcode = dt.Rows[0]["ihspcode"].ToString();
            common.AKC190 = ihspcode;
            common.AKC020 = tbxICCardID.Text.Trim();
            common.AKA130 = cmbMediType.SelectedValue.ToString();
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.MSGNO = "1104";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            common.INPUT = string.Format("<ZKC759>{0}</ZKC759><BKC111>{1}</BKC111>", "1", cmbUseCard.SelectedValue.ToString());
            WYJK wyjk = new WYJK();
            var par = wyjk.zyfyyjs(common);
            if (par.ReturnNum != "-1")
            {
                this.frmIhspAccount.InsurInfo.Balance = par.AKC252;//结算前账户余额
                this.frmIhspAccount.InsurInfo.InsuraccountFee = par.AKC255;//账户支付
                this.frmIhspAccount.InsurInfo.Insurfee = par.AKC260;//统筹支付
                this.frmIhspAccount.InsurInfo.Selffee = par.AKC261;//
                //this.frmIhspAccount.InsurInfo. = par.AKC261;//现金支付
                MessageBox.Show("预结算成功！请进行下一步结算！");
            }
            else
            {
                MessageBox.Show("调用医保接口失败:" + par.ErrorMsg);
            }
            this.frmIhspAccount.InsurInfo.UseCard = cmbUseCard.SelectedValue.ToString();
        }
    }
}
