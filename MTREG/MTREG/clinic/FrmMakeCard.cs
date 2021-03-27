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

namespace MTREG.clinic
{
    public partial class FrmMakeCard : Form
    {
        Member member = new Member();
        BllClinicReg bllRegister = new BllClinicReg();
        int flag;
        /// <summary>
        /// 用于时间控件转移焦点
        /// </summary>
        int i = 0;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 门诊卡id
        /// </summary>
        string fareuid;
        public FrmMakeCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMakeCard_Load(object sender, EventArgs e)
        {
            BillMember billMember = new BillMember();
            #region combox绑定数据
            tbxRace.Text = "汉族";
            tbxRaceCode.Text = "1";
            lbxRace.Visible = false;

            //var dtrank = billMember.rankList();
            //this.cmbMemRank.ValueMember = "id";
            //this.cmbMemRank.DisplayMember = "name";
            //this.cmbMemRank.DataSource = dtrank;

            var dtm = billMember.marriageList();
            this.cmbMarriage.ValueMember = "id";
            this.cmbMarriage.DisplayMember = "name";
            this.cmbMarriage.DataSource = dtm;
            this.cmbMarriage.SelectedValue = "2";

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
            cbxRemakeCard.Enabled = false;
        }

        /// <summary>
        /// 获取FrmMember数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cbxchecked"></param>
        public void getSource(string id, string cbxchecked)
        {
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

            if (cbxchecked == "false")
            {
                tbxHspcard.Focus();
                cbxRemakeCard.Checked = false;
                tbxNewHspcode.Visible = false;
                lblNewHspcard.Visible = false;

                btnMemRe.Visible = false;
            }
            else
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
                    tbxIdcard.Text = dt.Rows[0]["idcard"].ToString();
                    if (dt.Rows[0]["race_id"].ToString() != "")
                    {
                        tbxRace.Text = dt.Rows[0]["race"].ToString();
                        tbxRaceCode.Text = dt.Rows[0]["race_id"].ToString();
                        lbxRace.Visible = false;
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
                        lbxProfession.Visible = false;
                    }
                    if (dt.Rows[0]["hmstreetname"].ToString() != "")
                    {
                        tbxHmhouseNumber.Text = dt.Rows[0]["hmhouseNumber"].ToString();
                        tbxAddressCode.Text = dt.Rows[0]["hmstreetname"].ToString();
                        tbxAddress.Text = dt.Rows[0]["mergername"].ToString();
                        lbxProfession.Visible = false;
                    }
                    tbxBalance.Text = dt.Rows[0]["balance"].ToString();
                }
                lblNewHspcard.Visible = true;
                tbxNewHspcode.Visible = true;
                cbxRemakeCard.Checked = true;
                tbxBalance.Enabled = false;
                tbxHspcard.Enabled = false;
                tbxName.Enabled = false;
                tbxNewHspcode.Focus();
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

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            okClick();
        }

        /// <summary>
        /// 会员卡制卡打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void card_zk_dy()
        {
            Member member = new Member();
            BillMember billMember = new BillMember();
            if (cbxRemakeCard.Checked == false)
            {
                member.Hspcard = tbxHspcard.Text;
            }
            else
            {
                member.Hspcard = tbxNewHspcode.Text;
            }
            DataTable dt = billMember.memberSearch(member, "", "");
            string in_zfc1 = "|";
            in_zfc1 += tbxName.Text + "|";
            in_zfc1 += dt.Rows[0]["sex"].ToString().Trim() + "|";//性别
            in_zfc1 += tbxHspcard.Text + "|";
            in_zfc1 += cmbPayType.Text + "|";//支付方式
            in_zfc1 += cmbPayType.Text + "|";//费别  默认为自费
            in_zfc1 += Double.Parse(tbxBalance.Text).ToString("0.00") + "元|";//交款金额
            money n = new money(DataTool.Getdouble(tbxBalance.Text));
            in_zfc1 += n.Convert() + "|";
            in_zfc1 += (Double.Parse(tbxBalance.Text) - 2).ToString("0.00") + "|";//账户余额
            in_zfc1 += ProgramGlobal.User_id + "|";//收款人
            in_zfc1 += DateTime.Now + "|";//交款日期


            FrmDy HYzkdy = new FrmDy();
            HYzkdy.in_zfc = in_zfc1;
            HYzkdy.dy("mzzfyjj");
            MessageBox.Show("打印金额成功！");
        }
        /// <summary>
        /// 确定按钮方法
        /// </summary>
        public void okClick()
        {
            ma_Click();
            BillMember billMember = new BillMember();
            if (cbxRemakeCard.Checked)
            {
                member.Hspcard = tbxNewHspcode.Text;
            }
            else if (!cbxRemakeCard.Checked)
            {
                member.Hspcard = tbxHspcard.Text;
            }
            if (!(String.IsNullOrEmpty(fareuid) || fareuid == "00000000"))
            {
                member.Mzfare = fareuid;
            }
            else
            {
                MessageBox.Show("没有门诊卡号！请重新读卡。");
                return;
            }
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
            member.Race_id = tbxRaceCode.Text.ToString();
            member.Createdate = BillSysBase.currDate();
            member.Cardstat = MemberCardStat.YES.ToString();
            member.Createdby = ProgramGlobal.User_id;
            member.Balance = tbxBalance.Text;
            if (string.IsNullOrEmpty(member.Hspcard))
            {
                member.Hspcard = BillSysBase.newBillcode("member_hspcard");
            }
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
            if (string.IsNullOrEmpty(member.Balance) || Double.Parse(member.Balance) < 2)
            {
                MessageBox.Show("充值金额必须大于2元！");
                return;
            }
            if (cbxRemakeCard.Checked == false)
            {
                member.Id = BillSysBase.nextId("member");
                string fee_sql = billMember.inMember(member);

                string id = BillSysBase.nextId("member_balance");
                string cardstat = MemberCardStat.YES.ToString();
                fee_sql += billMember.inMemberBalance(id, member.Id, (Double.Parse(member.Balance) - 2).ToString(), cardstat);
                MemRechargedet memRechargedet = new MemRechargedet();
                memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedet.Operatdate = BillSysBase.currDate();
                memRechargedet.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedet.Opertype = "RE";
                memRechargedet.Amount = tbxBalance.Text;
                memRechargedet.Bas_member_id = member.Id;
                memRechargedet.Balance = tbxBalance.Text;
                memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();

                fee_sql += billMember.inMemBalancedet(memRechargedet);

                memRechargedet = new MemRechargedet();
                memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedet.Operatdate = BillSysBase.currDate();
                memRechargedet.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedet.Opertype = "CO";
                memRechargedet.Amount = "-2";
                memRechargedet.Bas_member_id = member.Id;
                memRechargedet.Balance = (Double.Parse(tbxBalance.Text) - 2).ToString();
                memRechargedet.Paytype_id = "20";
                fee_sql += billMember.inMemBalancedet(memRechargedet);
                //虚拟插入register，供数字医院读卡使用，不接诊
                string[] mem = new string[4];
                mem[0] = member.Name;
                mem[1] = member.Pincode;
                mem[2] = member.Sex;
                mem[3] = member.Birthday;
                fee_sql += billMember.xregister(member.Id, member.Hspcard, mem);

                BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
                if (bllRecipelCharge.doExeSql(fee_sql) < 0)
                {
                    MessageBox.Show("添加会员卡失败！");
                    SysWriteLogs.writeLogs1("修改会员卡错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), fee_sql);
                    return;
                }
            }
            else if (cbxRemakeCard.Checked == true)
            {
                string fee_sql = billMember.upMember(member);
                MemRechargedet memRechargedet = new MemRechargedet();
                memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedet.Operatdate = BillSysBase.currDate();
                memRechargedet.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedet.Opertype = "CO";
                memRechargedet.Amount = "-2";
                memRechargedet.Bas_member_id = member.Id;
                memRechargedet.Balance = (Double.Parse(tbxBalance.Text) - 2).ToString();
                memRechargedet.Paytype_id = "20";

                fee_sql += billMember.inMemBalancedet(memRechargedet);
                fee_sql += billMember.upMemBalance(member.Id, (Double.Parse(member.Balance) - 2).ToString());
                string cardstat = MemberCardStat.YES.ToString();
                fee_sql += billMember.upMemBalanceSta(member.Id, cardstat);
                fee_sql += billMember.upMemSta(member.Id, cardstat);

                DataTable dt = billMember.getRegister(member.Id);
                if (dt.Rows.Count > 0)
                {
                    fee_sql += billMember.setRegister(dt.Rows[0]["id"].ToString(), member.Name, member.Hspcard, member.Sex, tbxAge.Text);
                }

                BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
                if (bllRecipelCharge.doExeSql(fee_sql) < 0)
                {
                    MessageBox.Show("修改会员卡失败！");
                    SysWriteLogs.writeLogs1("修改会员卡错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), fee_sql);
                    return;
                }
            }
            //制卡打印
            if ((MessageBox.Show("添加会员卡成功！是否打印", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                card_zk_dy();
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        #region 回车按键事件
        private void tbxHspcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxRace.Focus();
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

        private void tbxIdcard_KeyDown(object sender, KeyEventArgs e)
        {
            Regex reg = new Regex(@"^(\d{8}[0-1]\d[0-3]\d{4}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{5}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{4}(\d|X|x))$");//正则表达式
            if (e.KeyCode == Keys.Enter)
            {
                string identityCard = tbxIdcard.Text.Trim();
                if (reg.IsMatch(identityCard) || !string.IsNullOrEmpty(identityCard))
                {
                    string birthday = "";
                    string sex = "";
                    if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
                    {
                        birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                        sex = identityCard.Substring(14, 3);
                    }
                    if (identityCard.Length == 15)
                    {
                        birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                        sex = identityCard.Substring(12, 3);
                    }
                    DateTime dateTime = Convert.ToDateTime(birthday);
                    dtpBirthday.Value = dateTime;
                    if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性奇数为男性
                    {
                        this.cmbSex.Text = "女";
                    }
                    else
                    {
                        this.cmbSex.Text = "男";
                    }
                    this.dtpBirthday.Focus();
                }
                else if (string.IsNullOrEmpty(identityCard))
                {
                    this.dtpBirthday.Focus();
                }
                else
                {
                    MessageBox.Show("身份证号格式不正确!");
                    return;
                }
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            this.tbxAddress.Focus();
        }

        private void tbxBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void tbxMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMarriage.Focus();
                cmbMarriage.DroppedDown = true;
            }
        }

        private void tbxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxMobile.Focus();
            }
        }

        private void cmbBloodtype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxEmail.Focus();
            }
        }

        private void cmbMarriage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxCompanyname.Focus();
            }
        }

        private void tbxCompanyname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxQqcode.Focus();
            }
        }

        private void tbxQqcode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.cmbMemRank.Focus();
            //    this.cmbMemRank.DroppedDown = true;
            //}
        }

        private void cmbMemRank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxCompanyphone.Focus();
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
        private void tbxCompanyphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxCompanyaddr.Focus();
            }

        }

        private void tbxCompanyaddr_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbxCompanyzip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbxBalance.Enabled == true)
            {
                this.tbxBalance.Focus();

            }
            else if (e.KeyCode == Keys.Enter && tbxBalance.Enabled == false)
            {
                this.btnOK.Focus();
            }
        }

        private void tbxNewHspcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }

        }
        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                okClick();
            }
        }
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
        }
        #endregion

        private void tbxHmhouseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxProfession.Focus();
            }
        }
        #region 民族 简码下拉
        private void tbxRace_TextChanged(object sender, EventArgs e)
        {
            lbxRace.Visible = true;
            DataTable dt = bllRegister.getRaceInfo(tbxRace.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxRace.ValueMember = "id";
                this.lbxRace.DisplayMember = "name";
                lbxRace.DataSource = dt;
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
                    tbxIdcard.Focus();
                }
                else if (lbxRace.Visible)
                {
                    tbxRaceCode.Text = lbxRace.SelectedValue.ToString();
                    tbxRace.Text = lbxRace.Text.ToString();
                    lbxRace.Visible = false;
                }
                else
                {
                    tbxIdcard.Focus();
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

        #region 地址 简码下拉
        private void tbxHomeaddress_TextChanged(object sender, EventArgs e)
        {
            lbxAddress.Visible = false;
            DataTable dt = bllRegister.regionList(tbxAddress.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxAddress.ValueMember = "id";
                this.lbxAddress.DisplayMember = "mergername";
                lbxAddress.DataSource = dt;
            }
        }
        private void tbxHomeaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxAddress.Focus();
                if (lbxAddress.Items.Count >= 2)
                {
                    lbxAddress.SelectedIndex = 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbxAddress.Text))
                {
                    tbxHmhouseNumber.Focus();
                }
                else if (lbxAddress.Visible)
                {
                    tbxAddressCode.Text = lbxAddress.SelectedValue.ToString();
                    tbxAddress.Text = lbxAddress.Text.ToString();
                    lbxAddress.Visible = false;
                }
                else
                {
                    tbxHmhouseNumber.Focus();
                }
            }
        }

        private void tbxHomeaddress_Enter(object sender, EventArgs e)
        {
            if (lbxAddress.DataSource != null)
            {
                lbxAddress.Visible = true;
                tbxAddress.SelectAll();
            }
        }
        private void lbxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxAddress.SelectedIndex == 1)
                {
                    tbxAddress.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxAddress.SelectedItem;
                tbxAddress.Text = drv.DataView[lbxAddress.SelectedIndex]["mergername"].ToString();
                tbxAddressCode.Text = lbxAddress.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
                tbxAddress.Focus();
                lbxAddress.Visible = false;
            }
        }
        private void tbxHomeaddress_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxAddress.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }
        private void lbxAddress_Leave(object sender, EventArgs e)
        {
            lbxAddress.Visible = false;
        }

        private void lbxAddress_MouseDown(object sender, MouseEventArgs e)
        {
            lbxAddress.Visible = false;
        }

        #endregion

        #region 职业 简码下拉
        private void tbxProfession_TextChanged(object sender, EventArgs e)
        {
            lbxProfession.Visible = true;
            DataTable dt = bllRegister.professionList(tbxProfession.Text.Trim());
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
                    cmbBloodtype.Focus();
                    cmbBloodtype.DroppedDown = true;
                }
                else if (lbxRace.Visible)
                {
                    tbxProfesCode.Text = lbxProfession.SelectedValue.ToString();
                    tbxProfession.Text = lbxProfession.Text.ToString();
                    lbxProfession.Visible = false;
                }
                else
                {
                    cmbBloodtype.Focus();
                    cmbBloodtype.DroppedDown = true;
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
                tbxRaceCode.Text = lbxProfession.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
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

        /// <summary>
        /// 读卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//读卡号 要判断 e 是否为回车
            {
                string hspCard = tbxHspcard.Text.Trim();
                if (hspCard.Length > 2)
                {
                    hspCard = hspCard.Replace(";", "");
                    hspCard = hspCard.Replace("?", "");
                    tbxHspcard.Text = hspCard;
                }
                if (hspCard.Trim().Equals(""))
                    return;
                this.tbxName.Focus();
            }
        }

        # region 身份证初始化
        private Thread thread;
        #region 关闭线程方法

        /// <summary>
        /// 关闭线程方法
        /// ReWriter:qinYangYang 2014-4-7
        /// </summary>
        /// <param name="param"></param>
        public void CloseSFZXC(object param)
        {
            try
            {
                thread.Abort();
            }
            catch (Exception ex)
            {
                //关闭线程
            }
        }

        #endregion
        #region 开启线程方法

        /// <summary>
        /// 开启线程方法 读身份信息
        /// ReWriter:qinYangYang 2014-4-6
        /// </summary>
        /// <param name="param"></param>
        public static void StartSFZXC(object param)
        {
            string errInfo = "";
            CustomWindowsMessages cwm = new CustomWindowsMessages();
            CardMsgs carmsg = new CardMsgs();
            int iPort = 0;
            while (true)
            {
                if (cwm.SendMessageInfo(ref iPort))
                {
                    break;
                }
                SysWriteLogs.SleepTimes(1200);
            }

        }

        #endregion
        #region 初始化身份证信息

        /// <summary>
        ///  初始化身份证信息
        ///  Writer:qinYangYang 2014/4/8
        /// </summary>
        public void initidCardInfo()
        {
            this.btnReadIdcard.Enabled = true;
            this.tbxName.Text = "";//姓名
            cmbSex.Text = "";//性别
            this.dtpBirthday.Value = Convert.ToDateTime(BillSysBase.currDate().ToString());//出生日期;
            tbxAddress.Text = "";//家庭住址
            tbxReadIdcard.Text = "";//身份证号
        }
        #endregion
        #region
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }

        /************************端口类API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData, ref byte cFPhotoname);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();
        /***********************设置附加功能函数 ************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);
        #endregion
        #endregion
        public Int32 icdev = -1;
        public int st;
        public int IdHandle = -1;

        private void btnReadIdcard_Click(object sender, EventArgs e)
        {
            int m_iPort;
            int i;
            uint[] iBaud = new uint[1];
            i = Syn_FindReader();
            m_iPort = i;


            IDCardData CardMsg = new IDCardData();
            int nRet, nPort, iPhotoType;
            string stmp;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = m_iPort;
            //Syn_SetPhotoPath(0, ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:	1=当前路径	2=指定路径
            ////cPhotoPath	绝对路径,仅在iOption=2时有效
            //iPhotoType = 0;
            Syn_SetPhotoType(4); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            //Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            Syn_SetSexType(1);	// 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            Syn_SetNationType(2);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            Syn_SetBornType(3);			// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeBType(3);	// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeEType(1, 1);	// 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
            // 0=长期 不转换,	1=长期转换为 有效期开始+50年           
            if (Syn_OpenPort(nPort) == 0)
            {
                if (Syn_SetMaxRFByte(nPort, 80, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
                    nRet = Syn_ReadMsg(nPort, 0, ref CardMsg);
                    if (nRet == 0)
                    {

                        //姓名
                        this.tbxName.Text = CardMsg.Name.ToString().Trim();

                        //性别
                        string sex = (CardMsg.Sex == "男") ? "M" : "W";
                        cmbSex.Text = CardMsg.Sex;

                        //民族
                        this.tbxRace.Text = CardMsg.Nation;

                        //出生日期
                        DateTime time = Convert.ToDateTime(CardMsg.Born);
                        this.dtpBirthday.Value = time;
                        //this.dtpBirthday.Value = Convert.ToDateTime(date);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
                        //listBox1.Items.Add(stmp);
                        ////地址

                        tbxAddress.Text = CardMsg.Address;

                        //stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
                        //listBox1.Items.Add(stmp);
                        ////身份证号
                        this.tbxIdcard.Text = CardMsg.IDCardNo;

                    }
                    else
                    {
                        MessageBox.Show("读取身份证信息错误");
                    }
                }
            }
            else
            {
                MessageBox.Show("打开端口失败");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ma_Click();
        }
        public void ma_Click()
        {
            Mifare dk = new Mifare();
            dk.OpenPoint();
            fareuid = dk.FindCard();
            dk.ClosePoint();
            BillMember billMember = new BillMember();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            DataTable dt = billMember.memberSearch(member, "", "");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该门诊卡以激活使用！");
                return;
            }
            if (!(String.IsNullOrEmpty(fareuid) || fareuid == "00000000"))
            {
                if (cbxRemakeCard.Checked)
                {
                    tbxNewHspcode.Text = BillSysBase.newBillcode("member_hspcard"); ;
                }
                else if (!cbxRemakeCard.Checked)
                {
                    tbxHspcard.Text = BillSysBase.newBillcode("member_hspcard"); ;
                }
            }
        }

        private void btnMemRe_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(member.Id))
                return;
            FrmMemRe frmMemRe = new FrmMemRe();
            string id = member.Id;
            frmMemRe.getSource(id);
            frmMemRe.ShowDialog();
            //if (frmMemRe.DialogResult == DialogResult.OK)
            //{
            //    searchMethod("");
            //}
            getSource(id, "true");
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            DateTime birth = dtpBirthday.Value;
            DateTime current = Convert.ToDateTime(BillSysBase.currDate());
            Sickages yea = DateDiff(current, birth);
            tbxAge.Text = yea.Cur_values.ToString(); 
            cmbAgesUnit.SelectedText = yea.Ageunit.ToString();
            
        }
        public  Sickages DateDiff(DateTime dateTime1, DateTime dateTime2)
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

        private void tbxAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                tbxAge.Text = "0";
                tbxAge.SelectAll();
                //tbxAge.SelectionStart = tbxAge.Text.Length;
            }
            if (!Regex.IsMatch(tbxAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxAge.Focus();
                this.tbxAge.Text = "1";
                return;
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 150)
                {
                    MessageBox.Show("年龄不得大于150");
                    tbxAge.Clear();
                    tbxAge.SelectAll();
                }
            }
            
            int i = DateTime.Now.Year - int.Parse(tbxAge.Text) - dtpBirthday.Value.Year;
            if (!(i < 2 && i > -2))
            {
                ageChanged();
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

                if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
                {
                    birthYear = (int.Parse(currentYear) - int.Parse(age)).ToString();
                    birthMonth = dtpBirthday.Value.Month.ToString();
                    birthDay = dtpBirthday.Value.Day.ToString();
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
    }
}
