using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gysyb.bo;
using System.Web.UI.WebControls;
using MTREG.medinsur.gzsyb.bo;

namespace MTREG.medinsur.gzsyb.ihsp
{
    public partial class FrmIhspMedinsurGZS : Form
    {
        public FrmIhspMedinsurGZS()
        {
            InitializeComponent();
        }
        PersonInfo personInfo = new PersonInfo();

        internal PersonInfo PersonInfo
        {
            get { return personInfo; }
            set { personInfo = value; }
        }
        string registinfo;

        public string Registinfo
        {
            get { return registinfo; }
            set { registinfo = value; }
        }
        Gzsybservice gzsybservice = new Gzsybservice();
        BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
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

        private string sickName;
        /// <summary>
        /// 传进来的病人姓名
        /// </summary>
        public string SickName
        {
            get { return sickName; }
            set { sickName = value; }
        }

        string ihsp_id;
        /// <summary>
        /// 住院记录id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        string ihspcode;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Ihspcode
        {
            get { return ihspcode; }
            set { ihspcode = value; }
        }
        string indate;
        /// <summary>
        /// 入院时间
        /// </summary>
        public string Indate
        {
            get { return indate; }
            set { indate = value; }
        }
        private bool sfzfzyb;
        /// <summary>
        /// 是否为自费转医保
        /// </summary>
        public bool Sfzfzyb
        {
            get { return sfzfzyb; }
            set { sfzfzyb = value; }
        }


        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspMedinsurGZS_Load(object sender, EventArgs e)
        {
            //患者类型的初始化
            var dtp = bllInsurIhspGZS.getPatientType();
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
            //List<ListItem> items = new List<ListItem>();
            //items.Add(new ListItem("31", "普通住院"));
            //items.Add(new ListItem("G31", "(工伤)普通住院"));
            //items.Add(new ListItem("M31", "分娩住院"));
            //items.Add(new ListItem("31", "计划生育手术住院"));
            //items.Add(new ListItem("31", "生育终止妊娠计划生育手术并发症住院"));
            //cmbPayType.DisplayMember = "Text";
            //cmbPayType.ValueMember = "Value";
            //cmbPayType.DataSource = items;
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
            personInfo.Swylrylbmc = tbxMedPerson.Text;

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
        /// 疾病简码下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxDiagnoseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DataTable dt = bllInsurIhspGZS.getIcdInfo(tbxDiagnoseName.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dgvwdybryzd.Visible = true;
                    dgvwdybryzd.BringToFront();
                    dgvwdybryzd.DataSource = dt;
                    this.dgvwdybryzd.Columns["ryzd_icdname"].Width = 161;
                    dgvwdybryzd.Rows[0].Selected = true;
                    dgvwdybryzd.Focus();
                }
                else
                {
                    dgvwdybryzd.Visible = false;
                }
            }
        }

        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void dgvwdybryzd_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvwdybryzd.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvwdybryzd.CurrentRow != null)
                {
                    tbxDiagnoseName.Text = dgvwdybryzd.CurrentRow.Cells["ryzd_icdname"].Value.ToString();
                    tbxDiagnoseCode.Text = dgvwdybryzd.CurrentRow.Cells["ryzd_icdcode"].Value.ToString();
                    dgvwdybryzd.Visible = false;
                    dgvwdybryzd.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvwdybryzd.CurrentRow != null && dgvwdybryzd.CurrentRow.Index > 0)
                {
                    dgvwdybryzd.Rows[dgvwdybryzd.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvwdybryzd.CurrentRow != null && dgvwdybryzd.CurrentRow.Index < dgvwdybryzd.Rows.Count - 1)
                {
                    dgvwdybryzd.Rows[dgvwdybryzd.CurrentRow.Index + 1].Selected = true;
                }
            }
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
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxDiagnoseName.Text.Equals("") || tbxDiagnoseCode.Text.Equals(""))
            {
                MessageBox.Show("请选择入院诊断和ICD码", "提示信息");
                return;
            }
            personInfo.Qjicd = tbxDiagnoseCode.Text;
            personInfo.Qjryzd = tbxDiagnoseName.Text;

            if (this.personInfo.Swxm.Trim() != sickName) //处方患者姓名与医保卡持有者姓名不一致判断
            {
                MessageBox.Show(string.Format(@"就诊卡患者姓名与医保卡持有者不一致，请确认！(就诊卡患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", sickName, personInfo.Swxm.Trim()));
                this.flag = false;
                this.Dispose();
                return;
            }

            if (this.sfzfzyb)
            {
                //说明是自费转医保患者直接调用入院登记函数
                swybzfzyb();

            }

            if (tbxPersonalNum.Text.Equals(""))
            {
                this.flag = false;
                this.Dispose();
            }
            else
            {
                if (cbxMentalDisease.Checked == true)
                {
                    personInfo.Qjsjbzyxbrbs = "1";//精神病住院新人标识
                }
                else
                {
                    personInfo.Qjsjbzyxbrbs = "0";
                }
                //personInfo.Zflb = cmbPayType.SelectedValue.ToString();//支付类别

                //支付类别|个人编号|姓名|性别|医疗照顾人员类别|执行社会保险办法|出生日期|单位编码|居民医疗人员类别|分中心编码
                //参保状态|医疗人员类别|身份证号|所属社保机构编码(使用分中心编码代码)|驻外标志|实足年龄|单位名称|居民医疗人员身份|个人账户余额|当前住院状态|读卡成功标志
                //受委托人姓名|与受委托人关系|受委托人身份证号|受委托人性别|疾病诊断|疾病ICD编码|精神病人住院标识
                registinfo = personInfo.Zflb + "|" + personInfo.Swgrbh + "|" + personInfo.Swxm + "|" + personInfo.Swxb + "|" + personInfo.Swylzgrylb + "|" + personInfo.Swzxshbxbf + "|" + personInfo.Swcsrq + "|" + personInfo.Swdwbm + "|" + personInfo.Swjmlrylb + "|" + personInfo.Swfzxbm + "|"
                           + personInfo.Swzbzt + "|" + personInfo.Swylrylb + "|" + personInfo.Swsfzh + "|" + personInfo.Sssbjgbm + "|" + personInfo.Swzwbz + "|" + personInfo.Swsznl + "|" + personInfo.Swdwmc + "|" + personInfo.Swjmylrysf + "|" + personInfo.Swgrzhye + "|" + personInfo.Swdqzyzt + "|" + personInfo.Flag + "|"
                           + personInfo.Swtrxm + "|" + personInfo.Swtrgx + "|" + personInfo.Swtrsfzh + "|" + personInfo.Swtrxb + "|" + personInfo.Qjryzd + "|" + personInfo.Qjicd +"|" + personInfo.Qjsjbzyxbrbs;
                this.flag = true;
                this.Dispose();
            }
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

        //自费转医保
        public void swybzfzyb()
        {
            BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
            string errInfo = "";
            bool flagtype = bllInsurIhspGZS.rydj(personInfo, ihspcode, indate, ihsp_id, out errInfo);
            if (!flagtype)
            {
                MessageBox.Show("医保登记失败!", "提示信息");
                return;
            }
            else
            {
                MessageBox.Show("医保住院登记成功!", "提示信息");
                int flag = bllInsurIhspGZS.upGzsybRyInfo(ihsp_id, patientType, personInfo);
                if (flag < 0)
                {
                    MessageBox.Show("更新患者信息失败!");
                    return;
                }
            }
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
