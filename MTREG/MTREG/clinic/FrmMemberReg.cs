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
using MTREG.common;
using MTHIS.common;
using System.Text.RegularExpressions;
using MTHIS.main.bll;
using MTREG.idcard.bll;
using MTREG.tools;
using System.Runtime.InteropServices;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb.Util;
using System.Threading;
using MTREG.medinsur.sjzsyb.bll;

namespace MTREG.clinic
{
    public partial class FrmMemberReg : Form
    {
        /// <summary>
        /// 读身份证使用
        /// </summary>
        CardMsgs cardmsgs = new CardMsgs();
        private int nport;
        public int Nport
        {
            get { return nport; }
            set { nport = value; }
        }
        private bool falg;
        public bool Falg
        {
            get { return falg; }
            set { falg = value; }
        }

        BllClinicReg bllRegister = new BllClinicReg();
        BllMemberReg bllMemberReg = new BllMemberReg();
        /// <summary>
        /// 用于时间控件转移焦点
        /// </summary>
        int i = 0;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 记录会员id
        /// </summary>
        string member_id = "-1";
        /// <summary>
        /// 年龄,出生日期联动
        /// </summary>
        bool ischarge = false;
        /// <summary>
        /// 记录余额
        /// </summary>
        string preBalance = "0";
        public FrmMemberReg()
        {
            InitializeComponent();            
        }

        private void FrmMemberReg_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            lblRegistBillcode.Text = BillSysBase.newBillcode("register_billcode");
            tbxRealFee.Text = "0.00";
            comboxSource();
            loadDataGrid();
            getRegisterInfo();
        }
        //加载dataGridview数据
        private void loadDataGrid()
        {
            //初始化左侧当前挂号信息
            dgvRegistChart.DataSource = bllRegister.getRegisterInfo();
            #region updateHeaderText
            dgvRegistChart.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
            this.dgvRegistChart.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), FontStyle.Bold);
            dgvRegistChart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistChart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistChart.Columns["doctor_id"].Visible = false;
            dgvRegistChart.Columns["depart_id"].Visible = false;
            dgvRegistChart.Columns["diagnlen"].Visible = false;
            dgvRegistChart.Columns["reg_level_id"].Visible = false;
            dgvRegistChart.Columns["doctor"].HeaderText = "医生";
            dgvRegistChart.Columns["doctor"].DisplayIndex = 0;
            dgvRegistChart.Columns["doctor"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["depart"].HeaderText = "科室";
            dgvRegistChart.Columns["depart"].DisplayIndex = 1;
            dgvRegistChart.Columns["depart"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["clinicroom"].HeaderText = "诊室";
            dgvRegistChart.Columns["clinicroom"].DisplayIndex = 2;
            dgvRegistChart.Columns["clinicroom"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["reglevel"].HeaderText = "级别";
            dgvRegistChart.Columns["reglevel"].DisplayIndex = 3;
            dgvRegistChart.Columns["reglevel"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["waitnum"].HeaderText = "挂号数";
            dgvRegistChart.Columns["waitnum"].DisplayIndex = 4;
            dgvRegistChart.Columns["waitnum"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["waitnum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistChart.Columns["regprc"].HeaderText = "金额";
            dgvRegistChart.Columns["regprc"].DisplayIndex = 5;
            dgvRegistChart.Columns["regprc"].Width = (int)(75 * ProgramGlobal.WidthScale);
            dgvRegistChart.Columns["regprc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistChart.Columns["waitlen"].HeaderText = "等待时间";
            dgvRegistChart.Columns["waitlen"].DisplayIndex = 6;
            dgvRegistChart.Columns["waitlen"].Width = (int)(120 * ProgramGlobal.WidthScale);
            #endregion
        }
        //初始化下拉框数据
        private void comboxSource()
        {
            tbxRace.Text = "汉族";
            tbxRaceCode.Text = "1";
            lbxRace.Visible = false;
            //科室
            var dtd = bllRegister.getDepartInfo("");
            this.cmbDepart.ValueMember = "Id";
            this.cmbDepart.DisplayMember = "Name";
            var drd = dtd.NewRow();
            drd["Id"] = 0;
            drd["Name"] = "--全部--";
            dtd.Rows.InsertAt(drd, 0);
            this.cmbDepart.DataSource = dtd;

            //年龄单位
            DataTable dtunit = bllRegister.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgesUnit.DisplayMember = "name";
                this.cmbAgesUnit.ValueMember = "id";
                this.cmbAgesUnit.DataSource = dtunit;
                this.cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
            }
            DataTable dtMonth = bllRegister.ageunitList();
            if (dtMonth.Rows.Count > 0)
            {
                this.cmbMonth.DisplayMember = "name";
                this.cmbMonth.ValueMember = "id";
                this.cmbMonth.DataSource = dtMonth;
                this.cmbMonth.SelectedValue = (int)AgeUnit.MOON;
                this.cmbMonth.Enabled = false;
            }
            //急诊
            var dtu = bllRegister.getUrgent();
            this.cmbUrgent.ValueMember = "Id";
            this.cmbUrgent.DisplayMember = "Name";
            this.cmbUrgent.DataSource = dtu;

            //性别
            DataTable dtsex = new DataTable();
            dtsex.Columns.Add("name");
            dtsex.Columns.Add("value");
            DataRow dr11 = dtsex.NewRow();
            dr11[0] = "男";
            dr11[1] = 'M';
            dtsex.Rows.Add(dr11);
            DataRow dr12 = dtsex.NewRow();
            dr12[0] = "女";
            dr12[1] = 'W';
            dtsex.Rows.Add(dr12);
            DataRow dr13 = dtsex.NewRow();
            dr13[0] = "未知";
            dr13[1] = 'U';
            dtsex.Rows.Add(dr13);
            this.cmbSex.DisplayMember = "name";
            this.cmbSex.ValueMember = "value";
            this.cmbSex.DataSource = dtsex;

            DataTable dtPayType = bllMemberReg.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 1;
            }
        }
        //绑定下拉框
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "--请选择--";
                dr["id"] = 0;
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dgvRegistChart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String depart_id = dgvRegistChart.Rows[e.RowIndex].Cells["depart_id"].Value.ToString();
                String doctor_id = dgvRegistChart.Rows[e.RowIndex].Cells["doctor_id"].Value.ToString();
                this.cmbDepart.SelectedValue = depart_id;
                bindComboxData(bllRegister.getDoctorByDepartId(depart_id), cmbDoctor);
                cmbDoctor.SelectedValue = doctor_id;
            }
            tbxIDCard.Focus();
        }

        private void cmbDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbDoctorTextChanged();                  
        }
        /// <summary>
        /// 计算实收金额
        /// </summary>
        private void cmbDoctorTextChanged()
        {
            double totalAmount = 0.00;
            if (null != cmbDepart.SelectedValue && !cmbDoctor.SelectedIndex.Equals(0) && !cmbDoctor.SelectedIndex.Equals(-1))
            {
                String doctor_id = cmbDoctor.SelectedValue.ToString();
                dgvFee.DataSource = bllRegister.getPrcByDoctor(doctor_id);
                this.dgvFee.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
                dgvFee.Columns["name"].Width = (int)(160 * ProgramGlobal.HeightScale);
                dgvFee.Columns["prc"].Width = (int)(100 * ProgramGlobal.HeightScale);
                dgvFee.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvFee.Columns["item_id"].Visible = false;
                dgvFee.Columns["itemfrom"].Visible = false;
                dgvFee.Columns["standcode"].Visible = false;
                dgvFee.Columns["spec"].Visible = false;
                dgvFee.Columns["unit"].Visible = false;
                dgvFee.Columns["itemtype_id"].Visible = false;
                dgvFee.Columns["itemtype1_id"].Visible = false;                
                for (int i = 0; i < dgvFee.Rows.Count; i++)
                {
                    totalAmount += double.Parse(dgvFee.Rows[i].Cells["prc"].Value.ToString());
                }
            }
            else
            {
                dgvFee.DataSource = bllRegister.getPrcByDoctor("");
                this.dgvFee.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
                dgvFee.Columns["name"].Width = (int)(170 * ProgramGlobal.HeightScale);
                dgvFee.Columns["prc"].Width = (int)(100 * ProgramGlobal.HeightScale);
                dgvFee.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvFee.Columns["item_id"].Visible = false;
                dgvFee.Columns["itemfrom"].Visible = false;
                dgvFee.Columns["standcode"].Visible = false;
                dgvFee.Columns["spec"].Visible = false;
                dgvFee.Columns["unit"].Visible = false;
                dgvFee.Columns["itemtype_id"].Visible = false;
                dgvFee.Columns["itemtype1_id"].Visible = false;
                for (int i = 0; i < dgvFee.Rows.Count; i++)
                {
                    totalAmount += double.Parse(dgvFee.Rows[i].Cells["prc"].Value.ToString());
                }                
            }
            tbxRealFee.Text = totalAmount.ToString();
            tbxCardBalance.Text = (Double.Parse(tbxReFee.Text.ToString()) - totalAmount).ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            regMethod();            
        }

        /// <summary>
        ///  充值挂号
        /// </summary>
        public void regMethod()
        {
            string hspcard = "";
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                this.Close();
            }
            if (tbxAge.Text == "")
            {
                tbxAge.Text = "0";
            }
            if (tbxPatientName.Text == "")
            {
                MessageBox.Show("患者姓名不能为空!");
                tbxPatientName.Focus();
                return;
            }
            if (cmbDoctor.SelectedIndex == -1 || cmbDoctor.SelectedIndex == 0)
            {
                MessageBox.Show("医生信息不能为空!");
                cmbDoctor.Focus();
                return;
            }
            if (cmbDepart.SelectedValue.Equals(0))
            {
                MessageBox.Show("科室信息不能为空!");
                cmbDepart.Focus();
                return;
            }
            string idcard = this.tbxIDCard.Text.Trim();                 //身份证号
            Regex reg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");//正则表达式
            //身份证判断
            if (idcard != "" && !reg.IsMatch(idcard))
            {
                MessageBox.Show("身份证号位数不够或者有其他字符！");
                this.tbxIDCard.Focus();
                return;
            }
            if (double.Parse(tbxAge.Text.Trim()) <= 0)
            {
                MessageBox.Show("年龄不能小于等于0");
                tbxAge.Focus();
                return;
            }
            string age = this.tbxAge.Text.Trim();
            if (!Regex.IsMatch(age, @"^[+-]?1?\d?\d$"))
            {
                MessageBox.Show("输入年龄有误，请重新输入！");
                tbxAge.Focus();
                return;
            }
            hspcard = tbxHspcard.Text;
            if (hspcard == "")
            {
                hspcard = BillSysBase.newBillcode("member_hspcard");
            }
            //会员卡
            Member member = new Member();
            member.Name = tbxPatientName.Text.Trim().ToString();
            member.Pincode = GetData.GetChineseSpell(tbxPatientName.Text.ToString());
            member.Sex = cmbSex.SelectedValue.ToString();
            member.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
            member.Hspcard = hspcard;
            if (tbxRaceCode.Text != "")
            {
                member.Race_id = tbxRaceCode.Text.Trim();
                member.Race = tbxRace.Text.Trim().ToString();
            }
            if (tbxAddressCode.Text != null)
            {
                member.Hmstreetname = tbxAddressCode.Text.Trim().ToString();
                member.Homeaddress = tbxAddress.Text.Trim().ToString() + tbxHmhouseNumber.Text.Trim();
                member.HmhouseNumber = this.tbxHmhouseNumber.Text.Trim().ToString();
            }
            if (string.IsNullOrEmpty(tbxAddress.Text))
            {
                member.Hmstreetname = "";
            }
            member.Idcard = tbxIDCard.Text.Trim().ToString();
            if (tbxProfesCode.Text.Trim() != null)
            {
                member.Profession = tbxProfession.Text.Trim();
                member.Profession_id = tbxProfesCode.Text.Trim().ToString();
            }
            member.Mobile = tbxPhoneNum.Text.Trim().ToString();
            member.Companyname = tbxCompanyName.Text.Trim().ToString();
            member.Createdate = BillSysBase.currDate();
            member.Createdby = ProgramGlobal.User_id;
            //挂号记录
            Register register = new Register();
            String doctor_id = cmbDoctor.SelectedValue.ToString();
            DataTable dt = bllRegister.getRegLevelByDoctor(doctor_id);
            String reg_level_id = "";
            if (dt.Rows.Count > 0)
            {
                reg_level_id = dt.Rows[0]["reg_level_id"].ToString();
            }
            register.Id = BillSysBase.nextId("register");
            register.Billcode = BillSysBase.newBillcode("register_billcode");
            register.Regdate = BillSysBase.currDate();
            register.Reg_level_id = reg_level_id;
            register.Bas_patienttype_id = "1";
            register.Healthcard = tbxHspcard.Text.Trim().ToString();
            register.Sys_region_id = "3";  
            register.Reg_regclass_id = bllRegister.getRegclass();
            register.Urgent = bllRegister.getUrgent(cmbUrgent.SelectedValue.ToString());
            register.Doctor_id = cmbDoctor.SelectedValue.ToString();
            register.Depart_id = cmbDepart.SelectedValue.ToString();
            register.Users_id = ProgramGlobal.User_id;
            register.Amount = tbxRealFee.Text.ToString();
            register.Status = RegisterStatus.REG.ToString();
            register.Isarchive = RegisterIsarchive.OO.ToString();           
            register.Hspcard = hspcard;
            register.Name = tbxPatientName.Text.ToString();
            register.Pincode = GetData.GetChineseSpell(tbxPatientName.Text.ToString());
            register.Sex = cmbSex.SelectedValue.ToString();
            register.Birthday = dtpBirthday.Value.ToString();
            register.Age = tbxAge.Text.ToString();
            register.Ageunit = cmbAgesUnit.SelectedValue.ToString();
            register.Moonage = tbxMonAge.Text.Trim();
            register.Moonageunit = cmbMonth.SelectedValue.ToString();
            register.Createtime = BillSysBase.currDate();
            register.Updatetime = BillSysBase.currDate();
            //就诊人员信息表
            IhspInfo ihspInfo = new IhspInfo();
            ihspInfo.Id = BillSysBase.nextId("ihsp_info");
            ihspInfo.Ihsp_id = register.Id;
            ihspInfo.Idcard = member.Idcard;
            ihspInfo.Profession = member.Profession;
            ihspInfo.Homeaddress = tbxAddress.Text.Trim() + tbxHmhouseNumber.Text.Trim();
            ihspInfo.Hmstreetname = tbxAddressCode.Text.Trim().ToString();
            ihspInfo.HmhouseNumber = tbxHmhouseNumber.Text.Trim();
            ihspInfo.Homephone = member.Mobile;
            ihspInfo.Companyname = member.Companyname;
            //收费主表
            ClinicCost clinicCost = new ClinicCost();
            clinicCost.Id = BillSysBase.nextId("clinic_cost");
            clinicCost.Regist_id = register.Id;
            clinicCost.Billcode = register.Billcode;
            clinicCost.Clinic_rcp_id = "0";
            clinicCost.Executed = "N";
            clinicCost.Depart_id = cmbDepart.SelectedValue.ToString();
            clinicCost.Doctor_id = cmbDoctor.SelectedValue.ToString();
            clinicCost.Rcpdate = BillSysBase.currDate();
            clinicCost.Recipelfee = tbxRealFee.Text.Trim().ToString();
            clinicCost.Realfee = tbxRealFee.Text.Trim().ToString();
            clinicCost.Unlocked = "N";
            clinicCost.Retappstat = "N";
            //收费明细表
            CliniCostdet cliniCostdet = new CliniCostdet();

            cliniCostdet.Clinic_cost_id = clinicCost.Id;
            cliniCostdet.Regist_id = register.Id;

            cliniCostdet.Clinic_rcpdetail_id = "0";
            cliniCostdet.Depart_id = cmbDepart.SelectedValue.ToString();
            cliniCostdet.Doctor_id = cmbDoctor.SelectedValue.ToString();
            cliniCostdet.Exedep_id = cmbDepart.SelectedValue.ToString();
            cliniCostdet.Packsole = "N";
            cliniCostdet.Drug_packsole_id = "0";
            cliniCostdet.Chargedate = BillSysBase.currDate();  
            string sql = "";
            sql+=bllMemberReg.addClinic_costItem(clinicCost);
            

            if (!bllRegister.hasMember(tbxHspcard.Text.Trim().ToString()))
            {
                member.Id = BillSysBase.nextId("member");
                member_id = member.Id;
                sql+=bllMemberReg.addMemberItem(member);
                sql += bllMemberReg.inMember_balance(member.Id,tbxCardBalance.Text);

            }
            else
            {
                DataTable dt_member = bllRegister.getMemberInfo(tbxHspcard.Text.Trim().ToString());
                if (dt_member.Rows.Count > 0)
                {
                    member_id = dt_member.Rows[0]["id"].ToString();
                }
                sql += bllMemberReg.upMember_balance(member_id, tbxCardBalance.Text);                
            }
            string refee = tbxReFee.Text;
            if (string.IsNullOrEmpty(tbxReFee.Text))
            {
                refee = "0";
            }
            sql += bllMemberReg.inRegister(register, member_id);
            string id = "";
            sql += bllMemberReg.inMember_rechargedet(member_id, "RE", tbxReFee.Text, cmbPayType.SelectedValue.ToString(), refee,ref id);
            string paytypeid = bllMemberReg.getPaytypeId("CONSUMEFEE");
            sql += bllMemberReg.inMember_rechargedet(member_id, "CO", tbxRealFee.Text, paytypeid, refee,ref id);
            
            for (int i = 0; i < dgvFee.Rows.Count; i++)
            {
                cliniCostdet.Id = BillSysBase.nextId("clinic_costdet");
                cliniCostdet.Prc = dgvFee.Rows[i].Cells["prc"].Value.ToString();
                cliniCostdet.Fee = cliniCostdet.Prc;
                cliniCostdet.Discnt = "1";
                cliniCostdet.Realfee = (double.Parse(cliniCostdet.Prc) * double.Parse(cliniCostdet.Discnt)).ToString();
                cliniCostdet.Standcode = dgvFee.Rows[i].Cells["standcode"].Value.ToString();
                cliniCostdet.Item_id = dgvFee.Rows[i].Cells["item_id"].Value.ToString();
                cliniCostdet.Itemfrom = dgvFee.Rows[i].Cells["itemfrom"].Value.ToString();
                cliniCostdet.Name = dgvFee.Rows[i].Cells["name"].Value.ToString();
                cliniCostdet.Spec = dgvFee.Rows[i].Cells["spec"].Value.ToString();
                cliniCostdet.Unit = dgvFee.Rows[i].Cells["unit"].Value.ToString();
                cliniCostdet.Num = "1";
                cliniCostdet.Itemtype_id = dgvFee.Rows[i].Cells["itemtype_id"].Value.ToString();
                cliniCostdet.Itemtype1_id = dgvFee.Rows[i].Cells["itemtype1_id"].Value.ToString();
                cliniCostdet.Member_rechargedet_id = id;
                sql += bllMemberReg.addClinic_costDetItem(cliniCostdet);                
            }
            
            sql += bllMemberReg.inIhspInfo(ihspInfo);
            if (BllMain.Db.Update(sql)<0)
            {
                MessageBox.Show("插入患者信息失败！");
                return;
            }
            MessageBox.Show("挂号成功！");
            getRegisterInfo();
            clear();
            loadDataGrid();
        }


        /// <summary>
        /// 金额变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxReFee_TextChanged(object sender, EventArgs e)
        {
            if (tbxReFee.Text == ".")
            {
                tbxReFee.Text = "0.";
                tbxReFee.SelectionStart = tbxReFee.Text.Length;
            }
            if (string.IsNullOrEmpty(tbxReFee.Text))
            {
                return;
            }
            if (!Regex.IsMatch(tbxReFee.Text, @"(\d+(\.\d+)?)"))
            {
                MessageBox.Show("提示：填写格式有误!");
                this.tbxReFee.Focus();
                this.tbxReFee.Text="0.00";
                return;
            }
            double balance=double.Parse(tbxReFee.Text)-double.Parse(tbxRealFee.Text);
            balance = balance + double.Parse(preBalance);
            tbxCardBalance.Text =DataTool.FormatData(balance.ToString(),"2");
        }


        /// <summary>
        /// 加载用户挂号信息
        /// </summary>
        public void getRegisterInfo()
        {
            DateTime dt = DateTime.Parse(BillSysBase.currDate());
            string today = dt.ToString("yyyy-MM-dd") + " 00:00:00";
            dgvRegistItem.DataSource = bllMemberReg.getRegisterById(today);//根据医院卡号查询挂号信息
            #region updateHeaderText
            this.dgvRegistItem.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), FontStyle.Bold);
            this.dgvRegistItem.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale), (FontStyle.Bold));
            dgvRegistItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistItem.Columns["id"].Visible = false;
            dgvRegistItem.Columns["billcode"].HeaderText = "编号";
            dgvRegistItem.Columns["billcode"].DisplayIndex = 0;
            dgvRegistItem.Columns["billcode"].Width = (int)(120 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["regdate"].HeaderText = "挂号时间";
            dgvRegistItem.Columns["regdate"].DisplayIndex = 7;
            dgvRegistItem.Columns["regdate"].Width = (int)(140 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["name"].HeaderText = "姓名";
            dgvRegistItem.Columns["name"].DisplayIndex = 2;
            dgvRegistItem.Columns["name"].Width = (int)(150 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["sex"].HeaderText = "性别";
            dgvRegistItem.Columns["sex"].DisplayIndex = 3;
            dgvRegistItem.Columns["sex"].Width = (int)(70 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["patienttype"].HeaderText = "患者类型";
            dgvRegistItem.Columns["patienttype"].DisplayIndex = 4;
            dgvRegistItem.Columns["patienttype"].Width = (int)(200 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["amount"].HeaderText = "金额";
            dgvRegistItem.Columns["amount"].DisplayIndex = 5;
            dgvRegistItem.Columns["amount"].Width = (int)(90 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistItem.Columns["username"].HeaderText = "挂号者";
            dgvRegistItem.Columns["username"].DisplayIndex = 6;
            dgvRegistItem.Columns["username"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["hspcard"].HeaderText = "卡号";
            dgvRegistItem.Columns["hspcard"].DisplayIndex = 1;
            dgvRegistItem.Columns["hspcard"].Width = (int)(130 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["dctname"].HeaderText = "医生";
            dgvRegistItem.Columns["dctname"].DisplayIndex = 8;
            dgvRegistItem.Columns["dctname"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvRegistItem.Columns["dptname"].HeaderText = "科室";
            dgvRegistItem.Columns["dptname"].DisplayIndex = 9;
            dgvRegistItem.Columns["dptname"].Width = (int)(80 * ProgramGlobal.WidthScale);
            #endregion
        }

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
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
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
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.MOON)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 12)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.DAY)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 30)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.MOON;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.HOUR)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 72)
                {
                    cmbAgesUnit.SelectedValue = (int)AgeUnit.DAY;
                    tbxAge.Text = "3";
                    tbxAge.SelectAll();
                }
            }
            ageChanged();
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

                if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
                {
                    birthYear = (int.Parse(currentYear) - int.Parse(age)).ToString();
                    birthMonth = dtpBirthday.Value.Month.ToString();
                    birthDay = dtpBirthday.Value.Day.ToString();
                }
                else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.MOON)
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
                else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.DAY)
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
                else if ((int)cmbAgesUnit.SelectedValue == (int)AgeUnit.HOUR)
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
                    cmbAgesUnit.SelectedValue = "1";
                }
                else if (current.Year - birth.Year < 3)
                {
                    tbxAge.Text = ((int)ts.TotalDays / 30).ToString();
                    cmbAgesUnit.SelectedValue = "3";
                }
                else
                {
                    tbxAge.Text = (current.Year - birth.Year).ToString();
                    cmbAgesUnit.SelectedValue = "4";
                }
            }
        }

        private void cmbAgesUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ischarge = true;
            if (!string.IsNullOrEmpty(tbxAge.Text))
            {
                if (int.Parse(tbxAge.Text) >= 1 && int.Parse(tbxAge.Text) < 3 && (int)cmbAgesUnit.SelectedValue == (int)AgeUnit.AGE)
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

        /// <summary>
        /// 清空信息
        /// </summary>
        public void clear()
        {
            lblRegistBillcode.Text = BillSysBase.newBillcode("register_billcode");
            tbxHspcard.Clear();
            tbxHmhouseNumber.Clear();
            tbxAddress.Clear();
            lbxAddress.Visible = false;
            tbxAge.Clear();
            tbxCardBalance.Text = "0.00";
            tbxIDCard.Clear();
            tbxPatientName.Clear();
            tbxPhoneNum.Clear();
            tbxProfession.Clear();
            lbxProfession.Visible = false;
            tbxCompanyName.Clear();
            cmbSex.SelectedValue = Sex.M.ToString();
            tbxRealFee.Text="0.00";
            tbxReFee.Text = "0.00";
            dtpBirthday.Value = Convert.ToDateTime(BillSysBase.currDate());
            cmbAgesUnit.SelectedValue = (int)AgeUnit.AGE;
            dgvFee.DataSource = null;            
            cmbDepart.SelectedValue = 0;
            cmbDoctor.DataSource = null;
            cmbDoctor.Text = "--请选择--";
            tbxRace.Text = "汉族";
            tbxRaceCode.Text = "1";
            lbxRace.Visible = false;
        }

        private void FrmMemberReg_Shown(object sender, EventArgs e)
        {
            //if (ProgramGlobal.Clininicpay == "A")
            //{
            //    MessageBox.Show("只能采用门诊挂号缴费方式!");
            //    this.Close();
            //}
        }

        #region 回车换行

        private void cmbUrgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxPatientName.Focus();
            }
        }

        private void tbxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxRace.Focus();
            }
        }

        private void btnReadIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                readIdcard();
                cmbUrgent.Focus();
                cmbUrgent.DroppedDown = true;
            }
        }
        private void cmbUrgent_Enter(object sender, EventArgs e)
        {
            cmbUrgent.DroppedDown = true;
        }
        private void cmbDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxIDCard.Focus();
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxAge.Focus();
            }
        }      

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgesUnit.Focus();
                cmbAgesUnit.DroppedDown = true;
            }
        }
        private void tbxMonAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();
            }
        }  
        private void cmbAgesUnit_KeyDown(object sender, KeyEventArgs e)
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

        private void tbxIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            //身份证18位正则表达式
            Regex reg18 = new Regex(@"^([1-9]{1}\d{5}[1-2]{1}[09]{1}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))(\d{4}|(\d{3}[x]{1})))$");//正则表达式
            //身份证15位正则表达式
            Regex reg15 = new Regex(@"^([1-9]{1}\d{5}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))\d{3})$");
            if (e.KeyCode == Keys.Enter)
            {
                string identityCard = tbxIDCard.Text.Trim();
                if (reg18.IsMatch(identityCard) || reg15.IsMatch(identityCard) && !string.IsNullOrEmpty(identityCard))
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
                    this.cmbSex.Focus();
                }
                else if (string.IsNullOrEmpty(identityCard))
                {
                    this.cmbSex.Focus();
                }
                else
                {
                    MessageBox.Show("身份证号格式不正确!");
                    return;
                }
            }
        }

        private void tbxPhoneNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxCompanyName.Focus();
            }
        }

        private void tbxCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxReFee.Focus();
            }
        }

        private void tbxReFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }
        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                regMethod();
                getRegisterInfo();
                clear();
            }
        }
        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is Button) && (keyData == Keys.Enter) && (ActiveControl != tbxHspcard))
            {
                if (ActiveControl.Name == btnOk.Name)
                {
                    tbxHspcard.Focus();
                    return base.ProcessDialogKey(keyData);
                }
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion                

        private void btnClinicReg_Click(object sender, EventArgs e)
        {
            FrmClinicReg frmClinicReg = new FrmClinicReg();
            frmClinicReg.StartPosition = FormStartPosition.Manual;
            frmClinicReg.WindowState = FormWindowState.Normal;
            frmClinicReg.Location = new Point(this.Location.X + 10, this.Location.Y + 10);  
            frmClinicReg.Show();
            this.Close();
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
            this.btnReadIDCard.Enabled = true;
            this.tbxPatientName.Text = "";//姓名
            cmbSex.Text = "";//性别
            this.dtpBirthday.Value = Convert.ToDateTime(BillSysBase.currDate().ToString());//出生日期;
            tbxAddress.Text = "";//家庭住址
            tbxIDCard.Text = "";//身份证号
        }
        #endregion
        [DllImport("Trf32.dll")]
        public static extern int dc_init(Int16 port, int baud);  //初试化
        [DllImport("Trf32.dll")]
        public static extern int dc_exit(int icdev);
        [DllImport("Trf32.dll")]
        public static extern int DC_start_i_d(int icdev);
        [DllImport("Trf32.dll")]
        public static extern int DC_find_i_d(int icdev);
        [DllImport("Trf32.dll")]
        public static extern int DC_end_i_d(int icdev);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_name(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_sex(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_nation(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_birth(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_address(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_id_number(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_department(int IdHandle);
        [DllImport("Trf32.dll")]
        public static extern IntPtr DC_i_d_query_expire_day(int IdHandle);


        [DllImport("Trf32.dll")]
        public static extern int dc_card(int icdev, char mode, long snr);
        [DllImport("Trf32.dll")]
        public static extern int dc_card_chr(int icdev, char mode, ref byte snr);

        [DllImport("Trf32.dll")]
        public static extern int DC_i_d_query_photo_file(int IdHandle, string FileName);
        [DllImport("Trf32.dll")]
        public static extern int dc_config_card(int IdHandle, byte cardtype);
        [DllImport("Trf32.dll")]
        public static extern int dc_reset(int icdev);
        public Int32 icdev = -1;
        public int st;
        public int IdHandle = -1;
        #endregion
        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            Mifare dk = new Mifare();
            Member member = new Member();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memberSearch(member, "","");
            
            
            this.tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
            this.tbxPatientName.Text = dt.Rows[0]["name"].ToString();
            this.cmbSex.Text = dt.Rows[0]["sex"].ToString();
            this.dtpBirthday.Text = dt.Rows[0]["birthday"].ToString();
            this.tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
            this.tbxReFee.Text = dt.Rows[0]["balance"].ToString();
            this.tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
        }
        /// <summary>
        /// 测试读取身份证信息
        /// </summary>
        public void readIdcard()
        {
            IdCardInfo idCardInfo = new IdCardInfo();
            idCardInfo.readInsurCard();
            this.tbxIDCard.Text = idCardInfo.Idcard; ;
            this.tbxPatientName.Text = idCardInfo.Name;
            this.cmbSex.Text = idCardInfo.Sex;
            this.tbxAddress.Text = idCardInfo.Homeaddress;
            cmbSex.Text = idCardInfo.Sex;
            this.dtpBirthday.Value = Convert.ToDateTime(idCardInfo.Birth);
        }
        /// <summary>
        /// 根据选择的科室绑定对应医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            departChange();
        }
        private void departChange()
        {
            if (null != cmbDepart.SelectedValue && !cmbDepart.SelectedIndex.Equals(0))
            {
                String depart_id = cmbDepart.SelectedValue.ToString();
                bindComboxData(bllRegister.getDoctorByDepartId(depart_id), cmbDoctor);
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

        private void tbxHmhouseNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPhoneNum.Focus();
            }
        }
        #region 民族 简码下拉
        private void tbxRace_TextChanged(object sender, EventArgs e)
        {
            lbxRace.Visible = true;
            DataTable dt = bllRegister.getRaceInfo(tbxRace.Text.Trim());
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
                    cmbDepart.Focus();
                    cmbDepart.DroppedDown = true;
                }
                else if (lbxRace.Visible)
                {
                    tbxRaceCode.Text = lbxRace.SelectedValue.ToString();
                    tbxRace.Text = lbxRace.Text.ToString();
                    lbxRace.Visible = false;
                }
                else
                {
                    cmbDepart.Focus();
                    cmbDepart.DroppedDown = true;
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
            lbxAddress.Visible = true;
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
            lbxAddress.Visible = true;
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
                    tbxAddress.Focus();
                }
                else if (lbxProfession.Visible)
                {
                    tbxProfesCode.Text = lbxProfession.SelectedValue.ToString();
                    tbxProfession.Text = lbxProfession.Text.ToString();
                    lbxProfession.Visible = false;
                }
                else
                {
                    tbxAddress.Focus();
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

        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                if (bllRegister.hasMember(tbxHspcard.Text.Trim().ToString()))
                {
                    DataTable dt_member = bllRegister.getMemberInfo(tbxHspcard.Text.Trim().ToString());
                    if (dt_member.Rows.Count > 0)
                    {
                        member_id = dt_member.Rows[0]["id"].ToString();
                        if (dt_member.Rows[0]["balance"].ToString() != "")
                        {
                            preBalance = dt_member.Rows[0]["balance"].ToString();
                        }
                        else
                        {
                            preBalance = "0";
                        }
                        tbxIDCard.Text = dt_member.Rows[0]["idcard"].ToString();
                        tbxPatientName.Text = dt_member.Rows[0]["name"].ToString();
                        if (!string.IsNullOrEmpty(dt_member.Rows[0]["hmstreetname"].ToString()))
                        {
                            tbxHmhouseNumber.Text = dt_member.Rows[0]["hmhouseNumber"].ToString();
                            tbxAddress.Text = dt_member.Rows[0]["mergername"].ToString();
                            tbxAddressCode.Text = dt_member.Rows[0]["hmstreetname"].ToString();
                            lbxAddress.Visible = false;

                        }
                        dtpBirthday.Value = Convert.ToDateTime(dt_member.Rows[0]["birthday"].ToString());
                        cmbSex.SelectedValue = dt_member.Rows[0]["sex"].ToString();
                        tbxCompanyName.Text = dt_member.Rows[0]["companyname"].ToString();
                        if (!string.IsNullOrEmpty(dt_member.Rows[0]["profession_id"].ToString()))
                        {
                            this.tbxProfession.Text = dt_member.Rows[0]["profession"].ToString();
                            this.tbxProfesCode.Text = dt_member.Rows[0]["profession_id"].ToString();
                            lbxProfession.Visible = false;

                        }
                        tbxPhoneNum.Text = dt_member.Rows[0]["mobile"].ToString();
                        if (!string.IsNullOrEmpty(dt_member.Rows[0]["race_id"].ToString()))
                        {
                            tbxRace.Text = dt_member.Rows[0]["race"].ToString();
                            tbxRaceCode.Text = dt_member.Rows[0]["race_id"].ToString();
                            lbxRace.Visible = false;
                        }
                    }
                }
                btnReadIDCard.Focus();
            }
        }
    }
}
