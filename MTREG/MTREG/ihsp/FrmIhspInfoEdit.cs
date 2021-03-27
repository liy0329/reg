using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.clinic.bll;
using MTREG.common;
using MTREG.idcard.bll;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.medinsur.sjzsyb.bll;
using System.IO;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.ihsp
{
    public partial class FrmIhspInfoEdit : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        string ihsp_id;
        string member_id;
        bool ischarge = false;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 用于时间控件转移焦点
        /// </summary>
        int i = 0;
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        public FrmIhspInfoEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 患者类型
        /// </summary>
        public string bas_patienttype { get; set; }
        string doctor_name = "";
        string deparname = "";
        private void FrmIhspInfoEdit_Load(object sender, EventArgs e)
        {
            isInformationManager();
            comboxSource();
            getInfo();
        }/// <summary>
        /// 判断是不是信息管理员
        /// </summary>
        public void isInformationManager()
        {
            tbxIntroducer.Enabled = false;
            if (ProgramGlobal.User_id.Equals("193"))
            {
                tbxIntroducer.Enabled = true;
            }
            else
            {
                tbxIntroducer.Enabled = false;
            }
        }
        public void getInfo()
        {
            string sql1 = "select  inhospital.`name`,inhospital.member_id,sexList.sn AS sex,ihspcode,inhospital.hspcard ,inhospital.birthday,enterdep,depart_id,doctor_id,age,ageunit,moonage,moonageunit,introducer,member.idcard from inhospital LEFT JOIN sys_dict AS sexList ON inhospital.sex = sexList.keyname AND sexList.dicttype = 'bas_sex' AND sexList.father_id <> 0  LEFT JOIN member ON member.id = inhospital.member_id where inhospital.id=" + ihsp_id;
            DataTable dt_cysj = BllMain.Db.Select(sql1).Tables[0];
            if (dt_cysj.Rows[0]["enterdep"].ToString().Trim() != "OO")
            {
                cmbDepart.Enabled = false;
                cmbDoctor.Enabled = false;
                label3.Visible = true;
            }
            lblIhspcode.Text = dt_cysj.Rows[0]["ihspcode"].ToString().Trim();
            lblHspcard.Text = dt_cysj.Rows[0]["hspcard"].ToString().Trim();
            tbxName.Text = dt_cysj.Rows[0]["name"].ToString().Trim();
            tbxIDCard.Text = dt_cysj.Rows[0]["idcard"].ToString().Trim();
            tbxAge.Text = dt_cysj.Rows[0]["age"].ToString().Trim();
            if (!String.IsNullOrEmpty(dt_cysj.Rows[0]["ageunit"].ToString().Trim()))
            {
                cmbAgeunit.SelectedValue = dt_cysj.Rows[0]["ageunit"].ToString().Trim();
            }
            tbxIntroducer.Text = dt_cysj.Rows[0]["introducer"].ToString().Trim();
            cmbSex.SelectedValue = dt_cysj.Rows[0]["sex"].ToString().Trim();
            if (dt_cysj.Rows[0]["moonage"].ToString() != "0")
            {
                tbxMonAge.Text = dt_cysj.Rows[0]["moonage"].ToString().Trim();
                cmbMonth.Text = dt_cysj.Rows[0]["moonageunit"].ToString().Trim();
            }
            dtpBirthday.Value = Convert.ToDateTime(dt_cysj.Rows[0]["birthday"].ToString().Trim());
            cmbDepart.SelectedValue = dt_cysj.Rows[0]["depart_id"].ToString().Trim();
            if (!String.IsNullOrEmpty(dt_cysj.Rows[0]["doctor_id"].ToString().Trim()))
            {
                cmbDoctor.SelectedValue = dt_cysj.Rows[0]["doctor_id"].ToString().Trim();
            }
            member_id = dt_cysj.Rows[0]["member_id"].ToString().Trim();
        }
        /// <summary>
        /// 加载下拉框数据
        /// </summary>
        public void comboxSource()
        {
            DataTable dtunit = billCmbList.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgeunit.DisplayMember = "name";
                this.cmbAgeunit.ValueMember = "id";
                this.cmbAgeunit.DataSource = dtunit;
                this.cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
            }
            DataTable dtMonth = billCmbList.ageunitList();
            if (dtMonth.Rows.Count > 0)
            {
                this.cmbMonth.DisplayMember = "name";
                this.cmbMonth.ValueMember = "id";
                this.cmbMonth.DataSource = dtMonth;
                this.cmbMonth.SelectedValue = (int)AgeUnit.MOON;
                this.cmbMonth.Enabled = false;
            }
            //性别
            DataTable dts = billCmbList.sexList();
            if (dts.Rows.Count > 0)
            {
                this.cmbSex.ValueMember = "id";
                this.cmbSex.DisplayMember = "name";
                this.cmbSex.DataSource = dts;
            }
            //科室
            DataTable dtde = billCmbList.ihspDepart("");
            if (dtde.Rows.Count > 0)
            {
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                this.cmbDepart.DataSource = dtde;
            }


        }

        /// <summary>
        /// 确定修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            okMethod();
        }

        /// <summary>
        /// 确定
        /// </summary>
        private void okMethod()
        {
            this.DialogResult = DialogResult.No;
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                this.Close();
            }
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("姓名不能为空!");
                tbxName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                MessageBox.Show("年龄不能为空!");
                tbxAge.Focus();
                return;
            }
            string idcard = this.tbxIDCard.Text.Trim().ToUpper();                 //身份证号

            //如果是石家庄医保，要先同步医保信息，再更改本地信息
            if (bas_patienttype == CostInsurtypeKeyname.SJZSYB.ToString())
            {
                if (MessageBox.Show("是否修改医保信息", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string sql = "select * from inhospital where id =" + DataTool.addFieldBraces(ihsp_id) + ";";
                    DataTable dt_cysj = BllMain.Db.Select(sql).Tables[0];
                    string sql1 = "select * from sybzyjl where AKC190 =" + DataTool.addFieldBraces(dt_cysj.Rows[0]["ihspcode"].ToString()) + ";";
                    DataTable dt_zyjl = BllMain.Db.Select(sql1).Tables[0];

                    SJZYB_IN<modify_In> yb_in_dj = new SJZYB_IN<modify_In>();
                    SJZYB_OUT yb_out_dj = new SJZYB_OUT();

                    yb_in_dj.KC21XML = new KC21();
                    yb_in_dj.AKC190 = dt_cysj.Rows[0]["ihspcode"].ToString();
                    yb_in_dj.AAC001 = "0";
                    yb_in_dj.AKA130 = dt_zyjl.Rows[0]["AKA130"].ToString();
                    yb_in_dj.MSGNO = "1102";
                    yb_in_dj.AKC020 = dt_cysj.Rows[0]["healthcard"].ToString();
                    List<KC21> kc21_list = objk<KC21>.FillModel(dt_zyjl);
                    KC21 kc21 = new KC21();
                    kc21 = kc21_list[0];
                    yb_in_dj.KC21XML = kc21;
                    yb_in_dj.INPUT = new List<modify_In>();
                    modify_In doc = new modify_In();
                    doc.AKC190 = dt_cysj.Rows[0]["ihspcode"].ToString();
                    doc.AKC281 = dt_cysj.Rows[0]["MSGID"].ToString();
                    yb_in_dj.INPUT.Add(doc);

                    string BKF040 = "";//中心科室编码
                    string BKF050 = "";//中心医师编码
                    //查询科室的中心编码
                    string ks_sql = "select AKF001 from contrast_dep where  bas_depart_id='" + cmbDepart.SelectedValue.ToString() + "'";
                    DataTable ks_dt = BllMain.Db.Select(ks_sql).Tables[0];
                    if (!string.IsNullOrEmpty(ks_dt.Rows[0][0].ToString()))
                    {
                        BKF040 = ks_dt.Rows[0][0].ToString();
                    }
                    //查询医师的中心编码
                    string ys_sql = "select BKF050 from contrast_doc where bas_doctor_id='" + cmbDoctor.SelectedValue.ToString() + "'";
                    DataTable ys_dt = BllMain.Db.Select(ys_sql).Tables[0];
                    if (!string.IsNullOrEmpty(ys_dt.Rows[0][0].ToString()))
                    {
                        BKF050 = ys_dt.Rows[0][0].ToString();
                    }
                    yb_in_dj.KC21XML.AKC025 = cmbDepart.Text;
                    yb_in_dj.KC21XML.BKF040 = BKF040;
                    yb_in_dj.KC21XML.AKC008 = cmbDoctor.Text;
                    yb_in_dj.KC21XML.BKF050 = BKF050;
                    yb_in_dj.KC21XML.AAE036 = DateTime.Now.ToString("yyyyMMddHHmmss");


                    SjzybInterface sjzybInterface = new SjzybInterface();
                    int ret_zyyjs = sjzybInterface.zymodify(yb_in_dj, ref yb_out_dj);

                    string ReturnMsg = "";
                    int returnnum = Convert.ToInt32(yb_out_dj.RETURNNUM);
                    if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                    {
                        ReturnMsg = yb_out_dj.ERRORMSG;

                        MessageBox.Show(ReturnMsg, "提示信息");
                        return;
                    }

                    string sql2 = "";
                    sql2 += "UPDATE sybzyjl SET "
                         + "AKC025 = " + DataTool.addFieldBraces(yb_in_dj.KC21XML.AKC025)
                         + ",BKF040 = " + DataTool.addFieldBraces(yb_in_dj.KC21XML.BKF040)
                         + ",AKC008 = " + DataTool.addFieldBraces(yb_in_dj.KC21XML.AKC008)
                         + ",BKF050 = " + DataTool.addFieldBraces(yb_in_dj.KC21XML.BKF050)
                         + ",AAE036 = " + DataTool.addFieldBraces(yb_in_dj.KC21XML.AAE036)
                         + " where AKC190 = " + DataTool.addFieldBraces(yb_in_dj.AKC190) + ";";
                    if (BllMain.Db.Update(sql2) == -1)
                    {
                        MessageBox.Show("修改医保成功，但更新HIS标志失败！");
                        return;
                    }



                }

            }
            Member member = new Member();
            Inhospital inhospital = new Inhospital();
            BillIhspMan billIhspMan = new BillIhspMan();
            inhospital.Id = Ihsp_id;
            inhospital.Name = this.tbxName.Text.Trim().ToString();
            switch (cmbSex.Text.Trim())
            {
                case "男": inhospital.Sex = Sex.M.ToString(); break;
                case "女": inhospital.Sex = Sex.W.ToString(); break;
                case "未说明性别": inhospital.Sex = Sex.U.ToString(); break;
                case "未知性别": inhospital.Sex = ""; break;
            }
            inhospital.Pincode = GetData.GetChineseSpell(tbxName.Text.Trim().ToString());
            inhospital.Age = this.tbxAge.Text.Trim().ToString();
            inhospital.Ageunit = this.cmbAgeunit.SelectedValue.ToString();
            inhospital.MonAge = this.tbxMonAge.Text.Trim().ToString();
            inhospital.Monageunit = this.cmbMonth.SelectedValue.ToString();
            inhospital.Birthday = this.dtpBirthday.Value.ToString("yyyy-MM-dd HH:mm:ss");
            inhospital.Depart = cmbDepart.SelectedValue.ToString();
            inhospital.Doctor = cmbDoctor.SelectedValue.ToString();
            inhospital.Member_id = member_id;
            inhospital.Introducer = this.tbxIntroducer.Text.Trim().ToString();

            member.Idcard = this.tbxIDCard.Text.Trim().ToString().ToUpper();

            int flag = billIhspMan.uphspReg(inhospital, member);
            if (flag == -1)
            {
                MessageBox.Show("住院信息更新失败！");
                return;
            }
            if (checkBox1.Checked)
            {
                string sex = "";
                if (Convert.ToInt32(cmbSex.SelectedValue.ToString()) == 1)
                    sex = "M";
                else
                    sex = "W";
                flag = billIhspMan.upemr_neonate(tbxName.Text.Trim().ToString(), sex, ihsp_id);
                if (flag == -1)
                {
                    MessageBox.Show("新生儿信息更新失败！");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 出生日期改变--年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (ischarge == false)
            {
                DateTime birth = dtpBirthday.Value;
                DateTime current = Convert.ToDateTime(BillSysBase.currDate());
                TimeSpan ts = current.Subtract(birth);
                if (ts.TotalDays <= 3)
                {
                    tbxAge.Clear();
                    cmbAgeunit.SelectedValue = (int)AgeUnit.HOUR;
                }
                else if (ts.TotalDays <= 30)
                {
                    tbxAge.Text = ((int)ts.TotalDays).ToString();
                    cmbAgeunit.SelectedValue = (int)AgeUnit.DAY;
                }
                else if (current.Year - birth.Year < 1)
                {
                    tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                    cmbAgeunit.SelectedValue = (int)AgeUnit.MOON;
                }
                else if (current.Year - birth.Year < 3)
                {
                    int year = current.Year - birth.Year;
                    int month = current.Month - birth.Month;
                    if (month < 0)
                    {
                        year = year - 1;
                        month = month + 12;
                    }
                    tbxAge.Text = year.ToString();
                    tbxMonAge.Text = month.ToString();
                    cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
                }
                else
                {
                    tbxAge.Text = (current.Year - birth.Year).ToString();
                    cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
                }
            }
        }
        
        
        private void tbxMonAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxMonAge.Text))
            {
                tbxMonAge.Text = "0";
                tbxMonAge.SelectAll();
            }
            if (!Regex.IsMatch(tbxMonAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxMonAge.Focus();
                this.tbxMonAge.Text = "1";
                return;
            }
            else
            {
                if (int.Parse(tbxMonAge.Text.Trim()) >= 12)
                {
                    MessageBox.Show("月数不能大于12");
                    tbxMonAge.Text = "0";
                    tbxMonAge.SelectAll();
                }
            }
            ischarge = true;
            string age = tbxMonAge.Text.ToString();
            string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
            string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
            string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
            string birthYear = dtpBirthday.Value.Year.ToString();
            string birthMonth = (int.Parse(currentMonth)).ToString();
            string birthDay = (int.Parse(currentDay)).ToString();
            string Year = (int.Parse(age) / 12).ToString();
            string Month = (int.Parse(age) % 12).ToString();

            birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
            if (int.Parse(birthMonth) <= 0)
            {
                birthMonth = (int.Parse(birthMonth) + 12).ToString();
                birthYear = (int.Parse(birthYear) - 1).ToString();
            }
            birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
            if (int.Parse(birthMonth) == 4 || int.Parse(birthMonth) == 6 || int.Parse(birthMonth) == 9 || int.Parse(birthMonth) == 11)
            {
                if (int.Parse(birthDay) == 31)
                {
                    birthMonth = (int.Parse(birthMonth) + 1).ToString();
                    birthDay = "1";
                }
            }
            if (int.Parse(birthMonth) == 2)
            {
                if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                {
                    if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
                    {
                        birthDay = "29";
                    }
                }
                else
                {
                    if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
                    {
                        birthDay = "28";
                    }
                }
            }
            dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            ischarge = false;
        }
        /// <summary>
        /// 计算出生日期
        /// </summary>
        private void ageChanged()
        {
            string monthDay = "";
            string age = tbxAge.Text.ToString();
            if (age != null && !age.Equals("") && Regex.IsMatch(age, @"^[+-]?\d*$"))
            {
                string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
                string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
                string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
                string birthYear = (int.Parse(currentYear)).ToString();
                string birthMonth = (int.Parse(currentMonth)).ToString();
                string birthDay = (int.Parse(currentDay)).ToString();

                if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
                {
                    birthYear = (int.Parse(currentYear) - int.Parse(age)).ToString();
                    birthMonth = dtpBirthday.Value.Month.ToString();
                    birthDay = dtpBirthday.Value.Day.ToString();
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.MOON)
                {
                    string Year = (int.Parse(age) / 12).ToString();
                    string Month = (int.Parse(age) % 12).ToString();

                    birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
                    if (int.Parse(birthMonth) <= 0)
                    {
                        birthMonth = (int.Parse(birthMonth) + 12).ToString();
                        birthYear = (int.Parse(birthYear) - 1).ToString();
                    }
                    birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.DAY)
                {
                    birthDay = (int.Parse(currentDay) - int.Parse(age)).ToString();
                    while (int.Parse(birthDay) <= 0)
                    {
                        monthDay = getMonthDay(birthMonth, birthYear);
                        birthDay = (int.Parse(birthDay) + int.Parse(monthDay)).ToString();
                        birthMonth = (int.Parse(birthMonth) - 1).ToString();
                        if (int.Parse(birthMonth) <= 0)
                        {
                            birthMonth = (int.Parse(birthMonth) + 12).ToString();
                            birthYear = (int.Parse(birthYear) - 1).ToString();
                        }
                    }
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.HOUR)
                {
                    string Day = (int.Parse(age) / 24).ToString();
                    birthDay = (int.Parse(currentDay) - int.Parse(Day)).ToString();
                    if (int.Parse(birthDay) < 0)
                    {
                        birthDay = (int.Parse(birthDay) + 30).ToString();
                    }

                }
                if (int.Parse(birthMonth) == 2)
                {
                    if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                    {
                        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
                        {
                            birthDay = "29";
                        }
                    }
                    else
                    {
                        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
                        {
                            birthDay = "28";
                        }
                    }
                }
                dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            }
            else
            {
                MessageBox.Show("年龄输入有误");
                return;
            }
        }
        /// <summary>
        /// 获取前一个月有多少天
        /// </summary>
        /// <param name="birthMonth">当前的月</param>
        /// <param name="birthYear">当前的年</param>
        /// <returns></returns>
        public string getMonthDay(string birthMonth, string birthYear)
        {
            string monthDay = "";
            string monthy = (int.Parse(birthMonth) - 1).ToString();
            if (monthy == "1")
            {
                monthy = "12";
                birthYear = (int.Parse(birthYear) - 1).ToString();
            }
            if (monthy == "1" || monthy == "3" || monthy == "5" || monthy == "7" || monthy == "8" || monthy == "10" || monthy == "12")
            {
                monthDay = "31";
            }
            else if (monthy == "2")
            {
                if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                {
                    monthDay = "29";
                }
                else
                {
                    monthDay = "28";
                }
            }
            else
            {
                monthDay = "30";
            }
            return monthDay;
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReadIDCard.Focus();
            }
        }

        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            readIdcard();
        }
        /// <summary>
        /// 读取身份证信息
        /// </summary>
        public void readIdcard()
        {
            IdCardInfo idCardInfo = new IdCardInfo();
            idCardInfo.readInsurCard();
            this.tbxIDCard.Text = idCardInfo.Idcard; ;
            this.tbxName.Text = idCardInfo.Name;
            this.cmbSex.Text = idCardInfo.Sex;
            // tbxHomeaddress.Text = idCardInfo.Homeaddress;
            cmbSex.Text = idCardInfo.Sex;
            this.dtpBirthday.Value = Convert.ToDateTime(idCardInfo.Birth);
        }

        private void btnReadIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                readIdcard();
            }
            if (e.KeyCode == Keys.Enter)
            {
                tbxIDCard.Focus();
            }
        }

        private void tbxIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!checkIdCard())
                {
                    tbxIDCard.Focus();
                }
                else
                {
                    tbxAge.Focus();

                }

            }
        }
        //身份证检查校验自动生成 年龄 与 出生年月
        public bool checkIdCard()
        {
            //正则表达式 身份证验证出生年月日要合法
            //身份证号18位正则表达式
            Regex reg18 = new Regex(@"^([1-9]{1}\d{5}[1-2]{1}[09]{1}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))(\d{4}|(\d{3}[x]{1})|(\d{3}[X]{1})))$");
            //身份证15位正则表达式
            Regex reg15 = new Regex(@"^([1-9]{1}\d{5}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))\d{3})$");

            if (string.IsNullOrEmpty(tbxIDCard.Text) || string.IsNullOrWhiteSpace(tbxIDCard.Text))
            {
                dtpBirthday.Focus();
                return true;
            }
            string idCard = tbxIDCard.Text.Trim();
            //身份证判断
            if (!reg18.IsMatch(idCard))
            {
                MessageBox.Show("请输入正确的身份证号，请重新输入！");

                return false;
            }
            if (!idCardEcho())
                return false;

            return true;
        }
        /// <summary>
        /// 身份证号得到出生日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool idCardEcho()
        {
            string idCard = tbxIDCard.Text.Trim();
            if (idCard == "")
            {
                return false;
            }
            string year = "";
            string month = "";
            string day = "";
            string sex = "";
            string birthday = "";
            if (idCard.Length == 15)
            {
                year = idCard.Substring(6, 2);
                year = "19" + year;
                month = idCard.Substring(8, 2);
                day = idCard.Substring(10, 2);
                sex = idCard.Substring(12, 3);
            }
            else if (idCard.Length == 18)
            {
                year = idCard.Substring(6, 4);
                month = idCard.Substring(10, 2);
                day = idCard.Substring(12, 2);
                sex = idCard.Substring(14, 3);
            }

            birthday = year + "-" + month + "-" + day;
            DateTime birth = new DateTime();
            try
            {
                birth = DateTime.ParseExact(birthday, "yyyy-MM-dd", null);
            }
            catch (Exception e)
            {
                MessageBox.Show("身份证出生年月输入不合法，请重新输入！");
                this.tbxIDCard.Focus();
                return false;
            }
            dtpBirthday.Value = birth;
            if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性奇数为男性
            {
                this.cmbSex.Text = "女";
            }
            else
            {
                this.cmbSex.Text = "男";
            }
            return true;
        }
        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is Button) && (keyData == Keys.Enter))
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }


        private void dtpIndate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                i++;
                SendKeys.Send("{right}");
                if (i == 3)
                {
                    SendKeys.Send("{tab}");
                    i = 0;
                }
            }
        }

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbAgeunit.Focus();
                this.cmbAgeunit.DroppedDown = true;
            }
        }

        private void cmbAgeunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxMonAge.Visible)
                {
                    tbxMonAge.Focus();
                }
                else
                {
                    this.dtpBirthday.Focus();
                }
            }
        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                i++;
                SendKeys.Send("{right}");
                if (i == 3)
                {
                    SendKeys.Send("{tab}");
                    i = 0;
                }
            }
        }

        private void tbxCompanyname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk.Focus();
            }
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                okMethod();
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
        }

        private void tbxMonAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();
            }
        }


        private void but_updatexse_Click(object sender, EventArgs e)
        {
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                this.Close();
            }

            BillIhspMan billIhspMan = new BillIhspMan();
            string sex = "";
            if (Convert.ToInt32(cmbSex.SelectedValue.ToString()) == 1)
                sex = "M";
            else
                sex = "W";
            int flag = billIhspMan.upemr_neonate(tbxName.Text.Trim().ToString(), sex, ihsp_id);
            if (flag == -1)
            {
                MessageBox.Show("新生儿信息更新失败！");
                return;
            }
        }

        private void cmbDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            departChange();
        }
        /// <summary>
        /// //科室变化处理: 算法修改医生信息
        /// </summary>
        private void departChange()
        {
            BllClinicReg bllClinicReg = new BllClinicReg();
            if (cmbDepart.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbDepart.SelectedValue)
            {
                String depart_id = cmbDepart.SelectedValue.ToString();
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbDoctor);
            }
        }
        //绑定下拉框
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            if (dt.ToString() == "")
            {
                dt.Columns.Add("name", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
            }
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "--请选择--";
                dr["id"] = 0;
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
