using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdxbhnh.bll;
using MTREG.medinsur.hdxbhnh.bo;


namespace MTREG.medinsur.hdxbhnh
{
    public partial class FrmMedinsrXBH : Form
    {
        BllMedinsrXBH bllMedinsrXBH = new BllMedinsrXBH();
        public FrmMedinsrXBH()
        {
            InitializeComponent();
        }
        string registinfo;
        /// <summary>
        /// 医保信息字符串
        /// </summary>
        public string Registinfo
        {
            get { return registinfo; }
            set { registinfo = value; }
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
        string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }

        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }
        private void FrmMedinsrXBH_Load(object sender, EventArgs e)
        {
            //患者类型的初始化
            var dtp = bllMedinsrXBH.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            SetValue();
            this.cmbPatientType.Enabled = false;
            //区划代码
            var dtz = bllMedinsrXBH.getZoneCode();
            this.cmbZoneCode.ValueMember = "Id";
            this.cmbZoneCode.DisplayMember = "Name";
            this.cmbZoneCode.DataSource = dtz;
        }

        private void tbxPersonJoinNum_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string PersonJoinNum = this.tbxPersonJoinNum.Text.ToString();
            string ZoneCode = this.cmbZoneCode.SelectedValue.ToString();
            registinfo += PersonJoinNum + "|";
            registinfo += ZoneCode;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxPersonJoinNum_Leave(object sender, EventArgs e)
        {
            if (tbxPersonJoinNum.Text.Length != 10 && tbxPersonJoinNum.Text.Length != 18)
            {
                MessageBox.Show("请输入正确的个人参合号！");
                this.tbxPersonJoinNum.Focus();
            }
        }
    }
}
