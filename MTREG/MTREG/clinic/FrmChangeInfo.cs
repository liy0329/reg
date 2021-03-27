using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using System.Text.RegularExpressions;
using MTREG.common;
using MTREG.ihsp.bll;
using System.Threading;
using MTHIS.common;

namespace MTREG.clinic
{
    public partial class FrmChangeInfo : Form
    {
        BillRegSearch billRegSearch = new BillRegSearch();
        BllClinicReg bllClinicReg = new BllClinicReg();
        BillCmbList billCmbList = new BillCmbList();
        BllClinicReg bllRegister = new BllClinicReg();
        string thisid;
        int flag;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 年龄,出生日期联动
        /// </summary>
        bool ischarge = false;
        public FrmChangeInfo()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmChangeInfo_Load(object sender, EventArgs e)
        {

            DataTable dt = billRegSearch.regIdSearch(thisid);            
            if (dt.Rows.Count > 0)
            {
                this.tbxProfession.Text = dt.Rows[0]["profession"].ToString();
                lbxProfession.Visible = false;
                this.cmbSex.SelectedValue = billRegSearch.sexId(dt.Rows[0]["sex"].ToString());
            }
            //省地址初始化
            DataTable province = bllClinicReg.provinceList("");
            var provincePay = province.NewRow();
            provincePay["id"] = 0;
            provincePay["name"] = "-请选择-";
            province.Rows.InsertAt(provincePay, 0);
            cmbProvince.DataSource = province;
            cmbProvince.ValueMember = "id";
            cmbProvince.DisplayMember = "name";
            cmbProvince.SelectedValue = "520000";
           
            DataTable dtcmb = billRegSearch.ihspIdSearch(thisid);
            if(dtcmb.Rows.Count > 0)
            {
            cmbProvince.SelectedValue = DataTool.ChangeNull(dtcmb.Rows[0]["hmprovince"].ToString());
            cmbCity.SelectedValue = DataTool.ChangeNull(dtcmb.Rows[0]["hmcity"].ToString());
            cmbCounty.SelectedValue = DataTool.ChangeNull(dtcmb.Rows[0]["hmcounty"].ToString());
            string pcc = cmbProvince.Text + cmbCity.Text + cmbCounty.Text;
            string address = dtcmb.Rows[0]["homeaddress"].ToString();
            string subaddress = System.Text.RegularExpressions.Regex.Replace(address,pcc, "");
            txbsubAddress.Text = subaddress;
            }
          
        }

        private void comboboxSource()
        {
            #region combox设置
            var dts = billRegSearch.sexList();
            this.cmbSex.ValueMember = "id";
            this.cmbSex.DisplayMember = "name";
            this.cmbSex.DataSource = dts;

            //年龄单位
            DataTable dtunit = bllClinicReg.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgeunit.DisplayMember = "name";
                this.cmbAgeunit.ValueMember = "id";
                this.cmbAgeunit.DataSource = dtunit;
                this.cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
            }
            DataTable dtMonth = bllClinicReg.ageunitList();
            if (dtMonth.Rows.Count > 0)
            {
                this.cmbMonth.DisplayMember = "name";
                this.cmbMonth.ValueMember = "id";
                this.cmbMonth.DataSource = dtMonth;
                this.cmbMonth.SelectedValue = (int)AgeUnit.MOON;
                this.cmbMonth.Enabled = false;
            }
            //var dtp = billRegSearch.professionList();
            //this.cmbProfession.ValueMember = "id";
            //this.cmbProfession.DisplayMember = "name";
            //this.cmbProfession.DataSource = dtp;

            ////民族            
            //var dtr = bllClinicReg.getRaceInfo(tbxRace.Text.Trim());
            //this.cmbRace.ValueMember = "Id";
            //this.cmbRace.DisplayMember = "Name";
            //this.cmbRace.DataSource = dtr;

            //DataTable dt = billCmbList.regionList(tbxHomeaddress.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    this.cmbHomeaddress.ValueMember = "id";
            //    this.cmbHomeaddress.DisplayMember = "mergername";
            //    cmbHomeaddress.DataSource = dt;
            //}
            #endregion
        }
        /// <summary>
        ///从FrmRegSearch中获取信息
        /// </summary>
        public void getSource(string id)
        {
            comboboxSource();
            this.thisid = id;
            DataTable dt = billRegSearch.regIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {
                this.tbxAge.Text = dt.Rows[0]["age"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["birthday"].ToString()))
                {
                    this.dtpBirthday.Value = Convert.ToDateTime(dt.Rows[0]["birthday"]);
                }
                else
                {
                    MessageBox.Show("提示：出生日期未填写,默认改为当前时间减去年龄哦!");
                    DateTime birth = dtpBirthday.Value;
                    DateTime current = Convert.ToDateTime(BillSysBase.currDate());
                    TimeSpan ts = current.Subtract(birth);
                    if (ts.TotalDays < 90)
                    {
                        tbxAge.Text = ((int)ts.TotalDays).ToString();
                        cmbAgeunit.SelectedValue = "1";
                    }
                    else if (current.Year - birth.Year < 3)
                    {
                        tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                        cmbAgeunit.SelectedValue = "3";
                    }
                    else
                    {
                        tbxAge.Text = (current.Year - birth.Year).ToString();
                        cmbAgeunit.SelectedValue = "4";
                    }
                }
                this.tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
                this.tbxMobile.Text = dt.Rows[0]["homephone"].ToString();
                this.tbxName.Text = dt.Rows[0]["regname"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["race_id"].ToString()))
                {
                    this.tbxRaceCode.Text = dt.Rows[0]["race_id"].ToString();
                    this.tbxRace.Text = dt.Rows[0]["race"].ToString();
                    lbxRace.Visible = false;
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["profession_id"].ToString()))
                {
                    tbxProfesCode.Text = dt.Rows[0]["profession_id"].ToString();
                    tbxProfession.Text = dt.Rows[0]["profession"].ToString();
                    lbxProfession.Visible = false;
                }
            }
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
                if (ts.TotalDays < 90)
                {
                    tbxAge.Text = ((int)ts.TotalDays).ToString();
                    cmbAgeunit.SelectedValue = "1";
                }
                else if (current.Year - birth.Year < 3)
                {
                    tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                    cmbAgeunit.SelectedValue = "3";
                }
                else
                {
                    tbxAge.Text = (current.Year - birth.Year).ToString();
                    cmbAgeunit.SelectedValue = "4";
                }
            }
        }

        /// <summary>
        /// 年龄数值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                tbxAge.Text = "0";
                tbxAge.SelectAll();
            }
            if (!Regex.IsMatch(tbxAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxAge.Focus();
                this.tbxAge.Text = "1";
                return;
            }
            ischarge = true;
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 150)
                {
                    MessageBox.Show("年龄不得大于150");
                    tbxAge.Clear();
                    tbxAge.SelectAll();
                }
                if (int.Parse(tbxAge.Text.Trim()) < 3 && int.Parse(tbxAge.Text.Trim()) >= 1)
                {
                    tbxMonAge.Visible = true;
                    cmbMonth.Visible = true;
                }
                else
                {
                    tbxMonAge.Visible = false;
                    cmbMonth.Visible = false;
                }
            }
            else
            {
                tbxMonAge.Visible = false;
                cmbMonth.Visible = false;
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.MOON)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 12)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.DAY)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 30)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.MOON;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.HOUR)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 72)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.DAY;
                    tbxAge.Text = "3";
                    tbxAge.SelectAll();
                }
            }
            ageChanged();
            ischarge = false;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveMethod();
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        private void saveMethod()
        {

            Register register = new Register();
            Member member = new Member();
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("姓名不能为空", "提示");
                tbxName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                MessageBox.Show("年龄不能为空!","提示");
                tbxAge.Focus();
                return;
            }
            if (!Regex.IsMatch(tbxMobile.Text,@"^[1]+[3,5,8,4]+\d{9}") && !string.IsNullOrEmpty(tbxMobile.Text))
            {
                //MessageBox.Show("手机号格式不正确！", "提示");
                //tbxMobile.Focus();
                //return;
            }
            if (!Regex.IsMatch(tbxIDCard.Text, @"^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$") && !string.IsNullOrEmpty(tbxIDCard.Text))
            {
                MessageBox.Show("身份证号格式不正确！", "提示");
                tbxIDCard.Focus();
                return ;
            }
            DataTable dt = billRegSearch.regIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {
                member.Id = dt.Rows[0]["memberid"].ToString();
                member.Birthday = dtpBirthday.Value.ToString();
                member.Profession = tbxProfession.Text.Trim();
                member.Profession_id = tbxProfesCode.Text;
                member.Mobile = tbxMobile.Text;
                member.HmhouseNumber = txbsubAddress.Text;
                member.Idcard = tbxIDCard.Text;
                member.Race = tbxRace.Text.ToString();
                member.Race_id = tbxRaceCode.Text;
                if (cmbProvince.SelectedValue.ToString() != "0")
                {
                    member.Homeaddress = cmbProvince.Text + cmbCity.Text + cmbCounty.Text + member.HmhouseNumber;
                }
                else 
                {
                    member.Homeaddress = member.HmhouseNumber;
                }
                
                flag = billRegSearch.upMember(member);
                IhspInfo ihspInfo = new IhspInfo();
                ihspInfo.Ihsp_id = thisid;
                ihspInfo.Idcard = member.Idcard;
                ihspInfo.Homephone = member.Mobile;
                ihspInfo.Profession = member.Profession;
                ihspInfo.Profession_id = member.Profession_id;
                ihspInfo.Homeaddress = member.Homeaddress;//现住址
                ihspInfo.Hmprovince = cmbProvince.SelectedValue.ToString();//省外键
                ihspInfo.Hmcity = cmbCity.SelectedValue.ToString();//市外键
                ihspInfo.Hmcounty = cmbCounty.SelectedValue.ToString();//县外键
                ihspInfo.HmhouseNumber = member.HmhouseNumber;
                billRegSearch.upIhsp(ihspInfo);
                if (flag == -1)
                {
                    MessageBox.Show("会员表修改失败!");
                    return;
                }
                register.Billcode = dt.Rows[0]["billcode"].ToString();
                register.Name = tbxName.Text;
                switch (cmbSex.Text)
                {
                    case "男": register.Sex = Sex.M.ToString(); break;
                    case "女": register.Sex = Sex.W.ToString(); break;
                    case "未说明性别": register.Sex = Sex.U.ToString(); break;
                    case "未知性别": register.Sex = ""; break;
                }
                register.Age = tbxAge.Text;
                register.Ageunit = cmbAgeunit.SelectedValue.ToString();
                register.Birthday = member.Birthday;
                flag = billRegSearch.upRegister(register);
                if (flag == -1)
                {
                    MessageBox.Show("挂号表修改失败!");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("修改成功!");
                this.Close();
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAgeunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ischarge = true;
            if (!string.IsNullOrEmpty(tbxAge.Text))
            {
                if (int.Parse(tbxAge.Text) >= 1 && int.Parse(tbxAge.Text) < 3 && (int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
                {
                    cmbMonth.Visible = true;
                    tbxMonAge.Visible = true;
                }
                else
                {
                    cmbMonth.Visible = false;
                    tbxMonAge.Visible = false;
                }
                ageChanged();
            }
            ischarge = false;
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

        private void cmbMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbMonth.Visible)
                {
                    tbxMonAge.Focus();
                }
                else
                {
                    this.dtpBirthday.Focus();
                }
            }
        }

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgeunit.Focus();
                cmbAgeunit.DroppedDown = true;
            }
        }

        private void cmbAgeunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbMonth.Visible)
                {
                    tbxMonAge.Focus();
                }
                else
                {
                    this.tbxProfession.Focus();
                }
            }
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

        private void tbxMonAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxProfession.Focus();
            }
        }


        private void tbxHmhouseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbSex.Focus();
                this.cmbSex.DroppedDown = true;
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();
            }
        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxAge.Focus();
            }
        }

        private void tbxMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxIDCard.Focus();
            }
        }

        private void tbxIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            //添加根据身份证号修改生日年龄性别
            if (e.KeyCode == Keys.Enter)
            {
                cmbProvince.Focus();
                
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                saveMethod();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
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


        #region 职业 简码下拉
        private void tbxProfession_TextChanged(object sender, EventArgs e)
        {
            lbxProfession.Visible = true;
            DataTable dt = bllClinicReg.professionList(tbxProfession.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxProfession.ValueMember = "id";
                this.lbxProfession.DisplayMember = "name";
                lbxProfession.DataSource = dt;
            }
        }
        private void tbxProfession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxProfession.Focus();
                if (lbxProfession.Items.Count >= 2)
                {
                    lbxProfession.SelectedIndex = 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbxProfession.Text))
                {
                    tbxRace.Focus();
                }
                else if (lbxProfession.Visible)
                {
                    tbxProfesCode.Text = lbxProfession.SelectedValue.ToString();
                    tbxProfession.Text = lbxProfession.Text.ToString();
                    lbxProfession.Visible = false;
                }
                else
                {
                    tbxRace.Focus();
                }
            }
        }

        private void tbxProfession_Enter(object sender, EventArgs e)
        {
            if (lbxProfession.DataSource != null)
            {
                lbxProfession.Visible = true;
                tbxProfession.SelectAll();
            }
        }
        private void lbxProfession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxProfession.SelectedIndex == 1)
                {
                    tbxProfession.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxProfession.SelectedItem;
                tbxProfession.Text = drv.DataView[lbxProfession.SelectedIndex]["name"].ToString();
                tbxProfesCode.Text = lbxProfession.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
                tbxProfession.Focus();
                lbxProfession.Visible = false;
            }
        }
        private void tbxProfession_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxProfession.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }
        private void lbxProfession_Leave(object sender, EventArgs e)
        {
            lbxProfession.Visible = false;
        }

        private void lbxProfession_MouseDown(object sender, MouseEventArgs e)
        {
            lbxProfession.Visible = true;
        }

        #endregion

        #region 民族 简码下拉
        private void tbxRace_TextChanged(object sender, EventArgs e)
        {
            lbxRace.Visible = true;
            DataTable dt = bllClinicReg.getRaceInfo(tbxRace.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxRace.ValueMember = "Id";
                this.lbxRace.DisplayMember = "Name";
                this.lbxRace.DataSource = dt;
            }
        }
        private void tbxRace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxRace.Focus();
                if (lbxRace.Items.Count >= 2)
                {
                    lbxRace.SelectedIndex = 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbxRace.Text))
                {
                    this.tbxMobile.Focus();
                }
                else if (lbxRace.Visible)
                {
                    tbxRaceCode.Text = lbxRace.SelectedValue.ToString();
                    tbxRace.Text = lbxRace.Text.ToString();
                    lbxRace.Visible = false;
                }
                else
                {
                    this.tbxMobile.Focus();
                }
            }
        }

        private void tbxRace_Enter(object sender, EventArgs e)
        {
            if (lbxRace.DataSource != null)
            {
                lbxRace.Visible = true;
                tbxRace.SelectAll();
            }
        }
        private void lbxRace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxRace.SelectedIndex == 1)
                {
                    tbxRace.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxRace.SelectedItem;
                tbxRace.Text = drv.DataView[lbxRace.SelectedIndex]["name"].ToString();
                tbxRaceCode.Text = lbxRace.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
                tbxRace.Focus();
                lbxRace.Visible = false;
            }
        }
        private void tbxRace_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxRace.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }
        private void lbxRace_Leave(object sender, EventArgs e)
        {
            lbxRace.Visible = false;
        }

        private void lbxRace_MouseDown(object sender, MouseEventArgs e)
        {
            lbxRace.Visible = true;
        }

        #endregion

        private void lbxProfession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRowView drv = (DataRowView)lbxProfession.SelectedItem;
            tbxProfession.Text = drv.DataView[lbxProfession.SelectedIndex]["name"].ToString();
            tbxProfesCode.Text = lbxProfession.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
            tbxProfession.Focus();
            lbxProfession.Visible = false;
        }

        private void lbxRace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRowView drv = (DataRowView)lbxRace.SelectedItem;
            tbxRace.Text = drv.DataView[lbxRace.SelectedIndex]["name"].ToString();
            tbxRaceCode.Text = lbxRace.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
            tbxRace.Focus();
            lbxRace.Visible = false;
        }

        private void cmbProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            provinceChange();
        }
        /// <summary>
        /// 地址1
        /// </summary>
        private void provinceChange()
        {
            if (cmbProvince.SelectedValue == null) { return; }
            string value = cmbProvince.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCity);
                }
                else
                {

                    bindComboxData(bllClinicReg.cityListB(value), cmbCity);
                }

                if (cmbCity.Items.Count > 1)
                {
                    cmbCity.SelectedIndex = 1;
                }

            }
        }
        private void cmbCity_SelectedValueChanged(object sender, EventArgs e)
        {
            cityChange();
        }

        private void cityChange()
        {
            if (cmbCity.SelectedValue == null) { return; }
            string value = cmbCity.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCounty);
                }
                else
                {
                    bindComboxData(bllClinicReg.countyListB(value), cmbCounty);
                }
                if (value.Equals("520100"))//贵阳市
                {
                    cmbCounty.SelectedValue = "520102";//南明区
                }
                else
                {

                    if (cmbCounty.Items.Count > 1)
                    {
                        cmbCounty.SelectedIndex = 1;
                    }
                }
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
        //绑定下拉框
        private void bindSpealeData(DataTable dt, ComboBox comObject)
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
                comObject.SelectedValue = "520100";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void cmbProvince_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbCity_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
