using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bo;
using MTREG.clinic.bll;
using MTREG.common;
using MTHIS.common;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb.Util;
using System.Threading;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.gzsyb;
using MTHIS.main.bll;

namespace MTREG.clinic
{
    public partial class FrmViewCard : Form
    {
        public FrmViewCard()
        {
            InitializeComponent();
        }
        Member member = new Member();
        /// <summary>
        /// 会员表id
        /// </summary>
        public string member_id { get; set; }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmViewCard_Load(object sender, EventArgs e)
        {
            BillMember billMember = new BillMember();
            #region combox绑定数据
            tbxRace.Text = "汉族";
            tbxRaceCode.Text = "1";

            

            var dtm = billMember.marriageList();
            this.cmbMarriage.ValueMember = "id";
            this.cmbMarriage.DisplayMember = "name";
            this.cmbMarriage.DataSource = dtm;

            var dts = billMember.sexList();
            this.cmbSex.ValueMember = "id";
            this.cmbSex.DisplayMember = "name";
            this.cmbSex.DataSource = dts;


            var dtb = billMember.bloodtypeList();
            this.cmbBloodtype.ValueMember = "id";
            this.cmbBloodtype.DisplayMember = "name";
            this.cmbBloodtype.DataSource = dtb;

            //年龄单位
            BllClinicReg bllClinicReg = new BllClinicReg();
            DataTable dtunit = bllClinicReg.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgesUnit.DisplayMember = "name";
                this.cmbAgesUnit.ValueMember = "id";
                this.cmbAgesUnit.DataSource = dtunit;
                this.cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
            }

            BllMemberReg bllMemberReg = new BllMemberReg();
            DataTable dtPayType = bllMemberReg.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 1;
            }
            #endregion
            intban();
            getSource(member_id);
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
        /// <summary>
        /// 禁止编辑
        /// </summary>
        public void intban()
        {
            this.tbxName.Enabled = false;
            this.tbxRace.Enabled = false;
            this.tbxIdcard.Enabled = false;
            this.dtpBirthday.Enabled = false;
            this.cmbSex.Enabled = false;
            this.tbxAddress.Enabled = false;
            this.tbxHmhouseNumber.Enabled = false;
            this.tbxProfession.Enabled = false;
            this.cmbBloodtype.Enabled = false;
            this.tbxEmail.Enabled = false;
            this.tbxMobile.Enabled = false;
            this.cmbMarriage.Enabled = false;
            this.tbxCompanyname.Enabled = false;
            this.tbxQqcode.Enabled = false;
            this.tbxAge.Enabled = false;
            this.cmbAgesUnit.Enabled = false;
            this.tbxCompanyphone.Enabled = false;
            this.tbxCompanyaddr.Enabled = false;
            this.cmbPayType.Enabled = false;
            this.btnOK.Enabled = false;
        }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public void intallow()
        {
            this.tbxName.Enabled = true;
            this.tbxRace.Enabled = true;
            this.tbxIdcard.Enabled = true;
            this.dtpBirthday.Enabled = true;
            this.cmbSex.Enabled = true;
            this.tbxAddress.Enabled = true;
            this.tbxHmhouseNumber.Enabled = true;
            this.tbxProfession.Enabled = true;
            this.cmbBloodtype.Enabled = true;
            this.tbxEmail.Enabled = true;
            this.tbxMobile.Enabled = true;
            this.cmbMarriage.Enabled = true;
            this.tbxCompanyname.Enabled = true;
            this.tbxQqcode.Enabled = true;
            this.tbxAge.Enabled = true;
            this.cmbAgesUnit.Enabled = true;
            this.tbxCompanyphone.Enabled = true;
            this.tbxCompanyaddr.Enabled = true;
            this.cmbPayType.Enabled = true;
            this.btnOK.Enabled = true;
        }
        /// <summary>
        /// 获取FrmMember数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cbxchecked"></param>
        public void getSource(string id)
        {
            BillMember billMember = new BillMember();
            member.Id = id;
            DataTable dt = billMember.memIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                tbxName.Text = dt.Rows[0]["name"].ToString();
                cmbSex.SelectedValue = billMember.getSexId(dt.Rows[0]["sex"].ToString());
                dtpBirthday.Value = Convert.ToDateTime(dt.Rows[0]["birthday"]);
                string year = (DateTime.Now.Year - (DateTime.Parse(dt.Rows[0]["birthday"].ToString()).Year)).ToString();
                tbxAge.Text = year;
                tbxIdcard.Text = dt.Rows[0]["idcard"].ToString();
                if (dt.Rows[0]["race_id"].ToString() != "")
                {
                    tbxRace.Text = dt.Rows[0]["race"].ToString();
                    tbxRaceCode.Text = dt.Rows[0]["race_id"].ToString();
                }
                if (dt.Rows[0]["homeaddress"].ToString() != "")
                {
                    tbxAddress.Text = dt.Rows[0]["homeaddress"].ToString();
                }
                if (dt.Rows[0]["mobile"].ToString() != "")
                {
                    tbxMobile.Text = dt.Rows[0]["mobile"].ToString();
                } if (dt.Rows[0]["email"].ToString() != "")
                {
                    tbxEmail.Text = dt.Rows[0]["email"].ToString();
                } if (dt.Rows[0]["companyname"].ToString() != "")
                {
                    tbxCompanyname.Text = dt.Rows[0]["companyname"].ToString();
                } if (dt.Rows[0]["qqcode"].ToString() != "")
                {
                    tbxQqcode.Text = dt.Rows[0]["qqcode"].ToString();
                } if (dt.Rows[0]["companyphone"].ToString() != "")
                {
                    tbxCompanyphone.Text = dt.Rows[0]["companyphone"].ToString();
                }
                if (dt.Rows[0]["companyaddr"].ToString() != "")
                {
                    tbxCompanyaddr.Text = dt.Rows[0]["companyaddr"].ToString();
                }

                if (dt.Rows[0]["profession_id"].ToString() != "")
                {
                    tbxProfession.Text = dt.Rows[0]["profession"].ToString();
                    tbxProfesCode.Text = dt.Rows[0]["profession_id"].ToString();
                }
                if (dt.Rows[0]["hmstreetname"].ToString() != "")
                {
                    tbxHmhouseNumber.Text = dt.Rows[0]["hmhouseNumber"].ToString();
                    tbxAddressCode.Text = dt.Rows[0]["hmstreetname"].ToString();
                    tbxAddress.Text = dt.Rows[0]["mergername"].ToString();
                }
                tbxBalance.Text = dt.Rows[0]["balance"].ToString();
            }
            cbxRemakeCard.Checked = false;
            tbxBalance.Enabled = false;
            tbxHspcard.Enabled = false;
            tbxName.Enabled = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            okClick();
        }
        /// <summary>
        /// 确定按钮方法
        /// </summary>
        public void okClick()
        {
            if (!ma_Click())
                return;
            member.Hspcard = tbxHspcard.Text.Replace(" ","");
            member.Idcard = tbxIdcard.Text;
            member.Homeaddress = tbxAddress.Text.Trim() + tbxHmhouseNumber.Text.Trim();
            member.Hmstreetname = tbxAddressCode.Text.ToString();
            member.HmhouseNumber = tbxHmhouseNumber.Text.Trim();
            member.Email = tbxEmail.Text;
            member.Companyname = tbxCompanyname.Text;
            member.Companyphone = tbxCompanyphone.Text;
            member.Name = tbxName.Text;
            member.Pincode = GetData.GetChineseSpell(tbxName.Text.ToString());
            switch (cmbSex.Text)
            {
                case "男": member.Sex = Sex.M.ToString(); break;
                case "女": member.Sex = Sex.W.ToString(); break;
                case "未说明性别": member.Sex = Sex.U.ToString(); break;
                case "未知性别": member.Sex = ""; break;
            }
            member.Profession = tbxProfession.Text.Trim();
            member.Profession_id = tbxProfesCode.Text.Trim();
            member.Bloodtype = cmbBloodtype.SelectedValue.ToString();
            member.Qqcode = tbxQqcode.Text;
            member.Companyaddr = tbxCompanyaddr.Text;
            member.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
            member.Mobile = tbxMobile.Text;
            member.Marriage_id = cmbMarriage.SelectedValue.ToString();
            //member.Member_rank_id = cmbMemRank.SelectedValue.ToString();
            member.Race = tbxRace.Text.Trim();

            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("姓名不能为空!", "提示信息");
                tbxName.Focus();
                tbxName.SelectAll();
                return;
            }
            if (string.IsNullOrEmpty(tbxAge.Text) || Double.Parse(tbxAge.Text) < 1)
            {
                MessageBox.Show("年龄不能为空!", "提示信息");
                tbxName.Focus();
                tbxName.SelectAll();
                return;
            }
            if (string.IsNullOrEmpty(tbxMobile.Text))
            {
                MessageBox.Show("电话不能为空!", "提示信息");
                tbxMobile.Focus();
                tbxMobile.SelectAll();
                return;
            }

            BillMember billMember = new BillMember();
            string fee_sql = billMember.setMember(member);
            DataTable dt = billMember.getRegister(member.Id);
            if (dt.Rows.Count > 0)
            {
                fee_sql += billMember.setRegister(dt.Rows[0]["id"].ToString(), member.Name, member.Hspcard, member.Sex, tbxAge.Text);
            }
            if (BllMain.Db.Update(fee_sql) != 0)
            {
                MessageBox.Show("更改失败");
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 修改判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRemakeCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRemakeCard.Checked == true)
            {
                intallow();
            }
            else
            {
                intban();
            }
        }

        public bool ma_Click()
        {
            Mifare dk = new Mifare();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            BillMember billMember = new BillMember();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            member.Hspcard = this.tbxHspcard.Text;
            DataTable dt = billMember.memberSearch(member, "", "");
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("未检测到该健康卡！");
                return false;
            }
            return true;

        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            DateTime birth = dtpBirthday.Value;
            DateTime current = Convert.ToDateTime(BillSysBase.currDate());
            Sickages yea = DateDiff(current, birth);
            tbxAge.Text = yea.Cur_values.ToString(); //(current.Year - birth.Year).ToString();
            cmbAgesUnit.SelectedText = yea.Ageunit.ToString();
            
        }
        public Sickages DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            Sickages sickage = new Sickages();

            if (dateTime2.Year == 1900)
            {
                sickage.Ageunit = "岁";
                return sickage;
            }

            string dateTime1Str = dateTime1.ToString("yyyy-MM-dd HH:mm:ss");//当天日期
            string dateTime2Str = dateTime2.ToString("yyyy-MM-dd HH:mm:ss");//出生日期

            string[] time1_s1 = dateTime1Str.Split(' ');
            string[] time1_Date_s = new string[5];
            string[] time1_Time_s = new string[5];
            if (time1_s1.Length >= 2)
            {
                time1_Date_s = time1_s1[0].Split('-');
                time1_Time_s = time1_s1[1].Split(':');
            }
            string[] time2_s1 = dateTime2Str.Split(' ');
            string[] time2_Date_s = new string[5];
            string[] time2_Time_s = new string[5];
            if (time2_s1.Length >= 2)
            {
                time2_Date_s = time2_s1[0].Split('-');
                time2_Time_s = time2_s1[1].Split(':');
            }
            if (time1_Date_s.Length >= 3 && time2_Date_s.Length >= 3)
            {
                if (time1_Date_s[0] == time2_Date_s[0])
                {
                    if (time1_Date_s[1] == time2_Date_s[1])
                    {
                        if (time1_Date_s[2] == time2_Date_s[2])
                        {
                            if (time1_Time_s[0] == time2_Time_s[0])
                            {
                                int dateTiem1_H_int = Convert.ToInt32(time1_Time_s[0]);
                                int dateTiem2_H_int = Convert.ToInt32(time2_Time_s[0]);
                                sickage.Cur_values = dateTiem1_H_int - dateTiem2_H_int;
                                sickage.Ageunit = "时";
                            }
                            else
                            {
                                int dateTiem1_H_int = Convert.ToInt32(time1_Time_s[0]);
                                int dateTiem2_H_int = Convert.ToInt32(time2_Time_s[0]);
                                sickage.Cur_values = dateTiem1_H_int - dateTiem2_H_int;
                                sickage.Ageunit = "时";
                            }
                        }
                        else
                        {
                            int dateTiem1_D_int = Convert.ToInt32(time1_Date_s[2]);
                            int dateTiem2_D_int = Convert.ToInt32(time2_Date_s[2]);
                            sickage.Cur_values = dateTiem1_D_int - dateTiem2_D_int;
                            sickage.Ageunit = "日";
                        }
                    }
                    else
                    {
                        int dateTiem1_M_int = Convert.ToInt32(time1_Date_s[1]);
                        int dateTiem2_M_int = Convert.ToInt32(time2_Date_s[1]);
                        sickage.Cur_values = dateTiem1_M_int - dateTiem2_M_int;
                        sickage.Ageunit = "月";
                    }
                }
                else
                {
                    int dateTiem1_Y_int = Convert.ToInt32(time1_Date_s[0]);
                    int dateTiem2_Y_int = Convert.ToInt32(time2_Date_s[0]);
                    int age = DateTime.Now.Year - dateTime2.Year;
                    if (DateTime.Now.Month < dateTime2.Month || (DateTime.Now.Month == dateTime2.Month && DateTime.Now.Day < dateTime2.Day)) age--;
                    TimeSpan ts = DateTime.Now - dateTime2;
                    string ages = age == 0 ? "-" + ts.Days : age.ToString();
                    sickage.Cur_values = age;
                    sickage.Ageunit = "岁";
                }
            }
            return sickage;
        }

    }
}
