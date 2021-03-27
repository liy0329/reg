using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.gzsyb.bo;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmClinMedinsurGZS : Form
    {
        public FrmClinMedinsurGZS()
        {
            InitializeComponent();
        }
        PersonInfo personInfo = new PersonInfo();

        internal PersonInfo PersonInfo
        {
            get { return personInfo; }
            set { personInfo = value; }
        }
        BllClinicMedinsrGZS bllClinicMedinsr = new BllClinicMedinsrGZS();
        Gzsybservice gzsybservice = new Gzsybservice();
        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        private bool flag = false;
        /// <summary>
        /// 读卡成功标志
        /// </summary>
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private void FrmClinMedinsurGZS_Load(object sender, EventArgs e)
        {
            //患者类型的初始化
            var dtp = bllClinicMedinsr.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            SetValue();
            this.cmbPatientType.Enabled = false;
            initPayType();//支付类别
           
        }
        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }
        /// <summary>
        /// 初始化支付类别
        /// </summary>
        public void initPayType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "普通门诊"));
            items.Add(new ListItem("18", "特殊门诊"));
            items.Add(new ListItem("G11", "(工伤)普通门诊"));
            items.Add(new ListItem("M11", "门诊产前检查"));
            items.Add(new ListItem("M12", "门诊流产费用支付"));
            items.Add(new ListItem("M13", "门诊计划生育手术支付"));
            //items.Add(new ListItem("31", "普通住院"));
            //items.Add(new ListItem("G31", "(工伤)普通住院"));
            //items.Add(new ListItem("M31", "分娩住院"));
            //items.Add(new ListItem("31", "计划生育手术住院"));
            //items.Add(new ListItem("31", "生育终止妊娠计划生育手术并发症住院"));
            cmbPayType.DisplayMember = "Value";
            cmbPayType.ValueMember = "Text";
            cmbPayType.DataSource = items;
        }
        /// <summary>
        /// 读卡函数
        /// </summary>
        private bool dk()
        {
            personInfo = gzsybservice.Zydk();
            if (personInfo.Flag == "-1")
            {
                MessageBox.Show("读卡失败！");            
                return false;
            }
            tbxPersonalNum.Text = personInfo.Swgrbh;
            tbxName.Text = personInfo.Swxm;
            string xb = personInfo.Swxb;
            if (xb == "1")
            {
                this.tbxSex.Text = "男";
            }
            else if (xb == "2")
            {
                this.tbxSex.Text = "女";
            }
            else if (xb == "0")
            {
                this.tbxSex.Text = "无";
            }
            string zgrylb = personInfo.Swylzgrylb;
            if (zgrylb == "0")
            {
                this.tbxMedicare.Text = "非医疗照顾人员";

            }
            else if (zgrylb == "1")
            {
                this.tbxMedicare.Text = "医疗照顾人员";
            }
            tbxExeInsurMethod.Text = personInfo.Swzxshbxbf;
            dtpBirth.Text = personInfo.Swcsrq;
            tbxCompanyNum.Text = personInfo.Swdwbm;
            tbxInsurPersonType.Text = personInfo.Swjmlrylb;
            //swfzxbm.Text = personInfo.Swfzxbm;//分中心编码
            //swzbzt.Text = personInfo.Swzbzt;//参保状态
            string cbzt = personInfo.Swzbzt;
            if (cbzt == "1")
            {
                this.tbxIsBlock.Text = "在保";
            }
            else if (cbzt == "0")
            {
                this.tbxIsBlock.Text = "未在保";
            }
            string rylb = personInfo.Swylrylb;
            if (rylb == "11")
            {
                this.tbxMedPerson.Text = "在职";
            }
            else if (rylb == "12")
            {
                this.tbxMedPerson.Text = "在职长期驻外";
            }
            else if (rylb == "21")
            {
                this.tbxMedPerson.Text = "退休";
            }
            else if (rylb == "22")
            {
                this.tbxMedPerson.Text = "退休异地安置";
            }
            else if (rylb == "31")
            {
                this.tbxMedPerson.Text = "离休";
            }
            else if (rylb == "32")
            {
                this.tbxMedPerson.Text = "二等乙级伤残军人";
            }
            else if (rylb == "33")
            {
                this.tbxMedPerson.Text = "离休异地安置";
            }
            tbxIDCard.Text = personInfo.Swsfzh;
            tbxInsurOrgonCode.Text = personInfo.Sssbjgbm;
            string zwbz = personInfo.Swzwbz;
            if (zwbz == "0")
            {
                this.tbxOutside.Text = "否";
            }
            else if (zwbz == "1")
            {
                this.tbxOutside.Text = "是";
            }
            tbxAge.Text = personInfo.Swsznl;
            tbxCompanyName.Text = personInfo.Swdwmc;
            tbxInsurPersonIdentity.Text = personInfo.Swjmylrysf;
            tbxBalance.Text = personInfo.Swgrzhye;
            string zyzt = personInfo.Swdqzyzt;
            if (zyzt == "1")
            {
                this.tbxIsInHosp.Text = "在院";
            }
            else if (zyzt == "2")
            {
                this.tbxIsInHosp.Text = "未在院";
            }
            return true;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.flag = false;
            this.Dispose();
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxPersonalNum.Text.Equals(""))
            {
                this.flag = false;
                this.Dispose();
            }
            else
            {
                personInfo.Zflb = cmbPayType.SelectedValue.ToString();
                this.flag = true;
                this.Dispose();
            }
        }
        /// <summary>
        /// 诊断名称KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxDiognose_KeyDown(object sender, KeyEventArgs e)
        {
             
        }
        /// <summary>
        /// 修改密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyPassword_Click(object sender, EventArgs e)
        {
            gzsybservice.updatePassword();
        }
        /// <summary>
        /// 读取委托人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadBailor_Click(object sender, EventArgs e)
        {
            PersonInfo bailor = gzsybservice.readBailor(personInfo.Swgrbh,personInfo.Swfzxbm);
            this.tbxBailorSex.Text = bailor.Swtrxb;
            this.tbxBailorID.Text = bailor.Swtrsfzh;
            this.tbxBailorName.Text = bailor.Swtrxm;
            this.tbxRelationShip.Text = bailor.Swtrgx;
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            bool flag = dk();//读卡
            if (!flag)
            {
                lblSuccess.Text = "读卡失败！";
            }
            else if (flag)
            {
                lblSuccess.Text = "读卡成功！";
            } 
        }       
     }
}
