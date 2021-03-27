using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.ihsp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmAhsnhIhsp : Form
    {
        public FrmAhsnhIhsp()
        {
            InitializeComponent();
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
        FrmIhspReg frmIhspReg;
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbChangeCode.SelectedValue.ToString() == "02"&&string.IsNullOrEmpty(tbxChangeRCode.Text))
            {
                MessageBox.Show("请填入转诊单号!");
                return;
            }
            FrmIhspReg.RegInfo.SChangeRCode = tbxChangeRCode.Text;
            FrmIhspReg.RegInfo.SChangeCode = cmbChangeCode.SelectedValue.ToString();
            FrmIhspReg.RegInfo.SMedicalCode = tbxMedicalCode.Text;
            FrmIhspReg.RegInfo.SAddress = tbxAddress.Text;
            FrmIhspReg.RegInfo.SCardCode = tbxCardCode.Text;
            FrmIhspReg.RegInfo.SPeopName = tbxName.Text;
            FrmIhspReg.RegInfo.SIDCardNo = tbxIDCard.Text;
            FrmIhspReg.RegInfo.SBirthDay = dtpBirth.Value.ToString();
            FrmIhspReg.RegInfo.SSex = cmbSex.SelectedValue.ToString();
            FrmIhspReg.RegInfo.SChangeRCode = tbxChangeRCode.Text;
            FrmIhspReg.RegInfo.SFamilyBalance = tbxFamilyBalance.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAhsnhIhsp_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatientType.ValueMember = "id";
                this.cmbPatientType.DisplayMember = "name";
                this.cmbPatientType.DataSource = dtp;
                cmbPatientType.SelectedValue = PatientType;
            }
            cmbPatientType.Enabled = false;

            DataTable dts = billCmbList.sexList();
            if (dts.Rows.Count > 0)
            {
                this.cmbSex.ValueMember = "id";
                this.cmbSex.DisplayMember = "name";
                this.cmbSex.DataSource = dts;
            }

            BllAhsnhMethod bllAhsnhMethod=new BllAhsnhMethod();
            DataTable dta= bllAhsnhMethod.getAreaCode();
            if (dta.Rows.Count > 0)
            {
                cmbArea.DataSource = dta;
                cmbArea.ValueMember = "id";
                cmbArea.DisplayMember = "areaname";
                DataRow dr = dta.NewRow();
                dr["areaname"] = "--请选择--";
                dr["id"] = "0";
                dta.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 提取按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExtract_Click(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod=new BllAhsnhMethod();
            In_GetPersonInfo inp = new In_GetPersonInfo();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            FrmIhspReg.RegInfo.Weburl = inp.Weburl;
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            FrmIhspReg.RegInfo.SHospitalCode = inp.SHospitalCode;
            inp.SMedicalCode = this.tbxMedicalCode.Text.Trim();//医疗证号
            retMesage ret = bllAhsnhMethod.getPersonInfo(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg,"错误信息");
                return;
            }
            if (ret.Ret_data.Count < 1)
            {
                MessageBox.Show("未获取到相关数据", "提示信息");
                return;
            }
            Out_GetPersonInfo oEntity = (Out_GetPersonInfo)ret.Ret_data[0];            
            this.tbxIDCard.Text = oEntity.SIDCardNo;
            this.tbxPersonalNum.Text = oEntity.SPeopCode;
            this.tbxName.Text = oEntity.SPeopName;
            switch (oEntity.SSex)
            {
                case "男": this.cmbSex.SelectedValue = 1;
                    break;
                case "女": this.cmbSex.SelectedValue = 2;
                    break;
                //case "其他": this.cmbSex.SelectedValue = 9;

            }
            this.dtpBirth.Value =Convert.ToDateTime(oEntity.SBirthDay);
            this.tbxAddress.Text = oEntity.SAddress;
            this.tbxCardCode.Text = oEntity.SCardCode;
            this.tbxAddrCode.Text = oEntity.SAddrCode;
            this.tbxFamilyBalance.Text = oEntity.SFamilyBalance;
            /* 调用WebService实现代码 end */
        }

    }
}
