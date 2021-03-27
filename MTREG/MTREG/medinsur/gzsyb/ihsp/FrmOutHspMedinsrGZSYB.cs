using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.gysyb.bo;
using System.Web.UI.WebControls;

namespace MTREG.medinsur.gzsyb.ihsp
{
    public partial class FrmOutHspMedinsrGZSYB : Form
    {
        public FrmOutHspMedinsrGZSYB()
        {
            InitializeComponent();
        }
        PersonInfo personInfo = new PersonInfo();

        internal PersonInfo PersonInfo
        {
            get { return personInfo; }
            set { personInfo = value; }
        }
        Gzsybservice gzsybservice = new Gzsybservice();
        BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
        string total;
        /// <summary>
        /// 总金额
        /// </summary>
        public string Total
        {
            get { return total; }
            set { total = value; }
        }
        string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        string preSettleInsurinfo;
        /// <summary>
        /// 读取医保卡信息
        /// </summary>
        public string PreSettleInsurinfo
        {
            get { return preSettleInsurinfo; }
            set { preSettleInsurinfo = value; }
        }
        private string midsettledInfo;
        /// <summary>
        /// 结算后返回的信息
        /// </summary>
        public string MidSettledInfo
        {
            get { return midsettledInfo; }
            set { midsettledInfo = value; }
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
        private bool flag = false;
        /// <summary>
        /// 读卡成功标志
        /// </summary>
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOutHspMedinsrGZSYB_Load(object sender, EventArgs e)
        {
            //患者类型的初始化
            var dtp = bllInsurIhspGZS.getPatientType();
            this.cmbPatientType.SelectedValue = patientType;
            this.cmbPatientType.Enabled = false;
        
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
        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
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
        /// 修改密码
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
            PersonInfo bailor = gzsybservice.readBailor(personInfo.Swgrbh, personInfo.Swfzxbm);
            this.tbxBailorSex.Text = bailor.Swtrxb;
            this.tbxBailorID.Text = bailor.Swtrsfzh;
            this.tbxBailorName.Text = bailor.Swtrxm;
            this.tbxRelationShip.Text = bailor.Swtrgx;
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.flag = false;
            this.Dispose();
        }
        /// <summary>
        /// 确定按钮
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
                //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
                //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
                //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
                preSettleInsurinfo = personInfo.Zflb + "|" + personInfo.Swgrbh + "|" + personInfo.Swxm + "|" + personInfo.Swxb + "|" + personInfo.Swylzgrylb + "|" + personInfo.Swzxshbxbf + "|" + personInfo.Swcsrq + "|" + personInfo.Swdwbm + "|" + personInfo.Swjmlrylb + "|" + personInfo.Swfzxbm + "|"
                           + personInfo.Swzbzt + "|" + personInfo.Swylrylb + "|" + personInfo.Swsfzh + "|" + personInfo.Sssbjgbm + "|" + personInfo.Swzwbz + "|" + personInfo.Swsznl + "|" + personInfo.Swdwmc + "|" + personInfo.Swjmylrysf + "|" + personInfo.Swgrzhye + "|" + personInfo.Swdqzyzt + "|" + personInfo.Flag + "|"
                           + personInfo.Swtrxm + "|" + personInfo.Swtrgx + "|" + personInfo.Swtrsfzh + "|" + personInfo.Swtrxb + "|" + personInfo.Qjryzd + "|" + personInfo.Qjicd + "|" + personInfo.Qjsjbzyxbrbs;
               // flag = bllInsurIhspGZS.preSettle(ihsp_id,total,preSettleInsurinfo,out midsettledInfo);
                this.Dispose();
            }
        }



    }
}
