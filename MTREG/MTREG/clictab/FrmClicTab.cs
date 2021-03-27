using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.clintab.bll;
using MTREG.clintab.bo;
using MTREG.common;
using MTHIS.main.bll;


namespace MTREG.clintab
{
    public partial class FrmClicTab : Form
    {
     
        BllClicTab bllClicTab = new BllClicTab();
        BllMemberTab bllMemberTab = new BllMemberTab();
        /// <summary>
        /// 结算方式
        /// </summary>
        string settletype;
        /// <summary>
        /// 在日结主表中是否存在
        /// </summary>
        bool exist;
        public FrmClicTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinicTab_Load(object sender, EventArgs e)
        {
            if (!bllClicTab.clinicTabIshave())
            {
                FrmClinTabInit frmStartTime = new FrmClinTabInit("clinictab");
                frmStartTime.ShowDialog();
                if (frmStartTime.DialogResult != DialogResult.OK)
                {
                    btnSettle.Enabled = false;
                }
            }
            var dtdet = bllClicTab.getTabDptInfo();
            this.cmbDpt.ValueMember = "Id";
            this.cmbDpt.DisplayMember = "Name";
            this.cmbDpt.DataSource = dtdet;

            tbxUsers.Text = bllClicTab.getDoctorName(ProgramGlobal.User_id);
            tbxUsers.Enabled = false;
            DataTable dtConfig = bllClicTab.getSettleType();
            dtpStime.Enabled = false;
            string enddate = bllClicTab.getTabEndtime(cmbDpt.SelectedValue.ToString());            
            dtpStime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEtime.Value = Convert.ToDateTime(BillSysBase.currDate());
            settletype = dtConfig.Rows[0]["settletype"].ToString();
            if (!string.IsNullOrEmpty(enddate))
            {
                dtpStime.Value = Convert.ToDateTime(enddate);
                if (Convert.ToDateTime(enddate).Day == Convert.ToDateTime(BillSysBase.currDate()).Day)
                {
                    btnSettle.Enabled = false;
                }
            }
           
          
            clinicSearchMethod();
            memberSearch();
               
                   
        }

        /// <summary>
        /// 门诊查找方法
        /// </summary>
        private void clinicSearchMethod()
        {
          
            string sett = cmbDpt.SelectedValue.ToString();
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable dt = bllClicTab.dayClinicInvoice(startDate, endDate, sett);
            dgvClinicInvoice.DataSource = dt;
            #region updateHeaderText
            dgvClinicInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClinicInvoice.ReadOnly = true;
            dgvClinicInvoice.Columns["id"].Visible = false;
            dgvClinicInvoice.Columns["billcode"].HeaderText = "发票号";
            dgvClinicInvoice.Columns["billcode"].DisplayIndex = 0;
            dgvClinicInvoice.Columns["sickname"].HeaderText = "姓名";
            dgvClinicInvoice.Columns["sickname"].DisplayIndex = 1;
            dgvClinicInvoice.Columns["rcpdptname"].HeaderText = "科室";
            dgvClinicInvoice.Columns["rcpdptname"].DisplayIndex = 2;
            dgvClinicInvoice.Columns["rcpdptname"].Width = 150;
            dgvClinicInvoice.Columns["patienttype"].HeaderText = "患者类型";
            dgvClinicInvoice.Columns["patienttype"].Width = 100;
            dgvClinicInvoice.Columns["patienttype"].DisplayIndex = 3;
            dgvClinicInvoice.Columns["realfee"].HeaderText = "金额";
            dgvClinicInvoice.Columns["realfee"].DisplayIndex = 4;
            dgvClinicInvoice.Columns["insurefee"].HeaderText = "统筹金额";
            dgvClinicInvoice.Columns["insurefee"].DisplayIndex = 5;
            dgvClinicInvoice.Columns["insuraccountfee"].HeaderText = "账户支付";
            dgvClinicInvoice.Columns["insuraccountfee"].DisplayIndex = 6;
            dgvClinicInvoice.Columns["chargedate"].HeaderText = "收费日期";
            dgvClinicInvoice.Columns["chargedate"].DisplayIndex = 7;
            dgvClinicInvoice.Columns["chargedate"].Width = 200;
            dgvClinicInvoice.Columns["dptname"].HeaderText = "收费室";
            dgvClinicInvoice.Columns["dptname"].DisplayIndex = 8;
            dgvClinicInvoice.Columns["dptname"].Width = 150;
            #endregion
            double amount = 0, insure = 0, self = 0;
            for (int i = 0; i < dgvClinicInvoice.Rows.Count; i++)
            {
                amount += double.Parse(dgvClinicInvoice.Rows[i].Cells["realfee"].Value.ToString());
                insure += double.Parse(dgvClinicInvoice.Rows[i].Cells["insurefee"].Value.ToString());
                self += double.Parse(dgvClinicInvoice.Rows[i].Cells["insuraccountfee"].Value.ToString());
            }
            tbxAmount.Text = amount.ToString();
            tbxInsure.Text = insure.ToString();
            tbxself.Text = self.ToString();
        }
        /// <summary>
        /// 储值卡查找方法
        /// </summary>
        private void memberSearch()
        {
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string type = "tab";
            string chargeDep = cmbDpt.SelectedValue.ToString();
            DataTable dt = bllMemberTab.getRechargedetInfo(startDate, endDate, chargeDep, type);
            dgvRechargedet.DataSource = dt;
            #region updateHeaderText
            dgvRechargedet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRechargedet.ReadOnly = true;
            dgvRechargedet.Columns["paytype"].HeaderText = "支付类型";
            dgvRechargedet.Columns["paytype"].DisplayIndex = 0;
            dgvRechargedet.Columns["paytype"].Width = 100;
            dgvRechargedet.Columns["opertype"].HeaderText = "操作类型";
            dgvRechargedet.Columns["opertype"].DisplayIndex = 1;
            dgvRechargedet.Columns["opertype"].Width = 100;
            dgvRechargedet.Columns["amount"].HeaderText = "操作金额";
            dgvRechargedet.Columns["amount"].DisplayIndex = 2;
            dgvRechargedet.Columns["amount"].Width = 100;
            dgvRechargedet.Columns["doctor"].HeaderText = "操作人";
            dgvRechargedet.Columns["doctor"].DisplayIndex = 3;
            dgvRechargedet.Columns["doctor"].Width = 100;
            dgvRechargedet.Columns["depart"].HeaderText = "操作科室";
            dgvRechargedet.Columns["depart"].DisplayIndex = 4;
            dgvRechargedet.Columns["depart"].Width = 100;
            dgvRechargedet.Columns["operatdate"].HeaderText = "操作时间";
            dgvRechargedet.Columns["operatdate"].DisplayIndex = 5;
            dgvRechargedet.Columns["operatdate"].Width = 200;
            #endregion
            double reAmount = 0;
            double enAmount = 0;
            for (int i = 0; i < dgvRechargedet.Rows.Count; i++)
            {
                if (dgvRechargedet.Rows[i].Cells["opertype"].Value.ToString() == "充值")
                {
                    reAmount += double.Parse(dgvRechargedet.Rows[i].Cells["amount"].Value.ToString());
                }
                else if (dgvRechargedet.Rows[i].Cells["opertype"].Value.ToString() == "取现")
                {
                    enAmount += double.Parse(dgvRechargedet.Rows[i].Cells["amount"].Value.ToString());
                }
            }
            tbxAmount.Text = (reAmount - enAmount).ToString();
        }
        

        /// <summary>
        /// 结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettle_Click(object sender, EventArgs e)
        {

        
            doClinicTab();
             
              
        }
        /// <summary>
        /// 门诊日结
        /// </summary>
        private void doClinicTab()
        {
            Clinictab clinictab = new Clinictab();
            clinictab.Id = BillSysBase.nextId("clinictab_day");
            clinictab.Billcode = BillSysBase.newBillcode("clinictab_day_billcode");
            clinictab.Startdate = dtpStime.Value.ToString();
            clinictab.Enddate = dtpEtime.Value.ToString();
            clinictab.Depart_id = cmbDpt.SelectedValue.ToString();
            clinictab.Settleby = ProgramGlobal.User_id;
            clinictab.Settledate = BillSysBase.currDate();
            string sql = "";
            sql += bllClicTab.inClinictabDay(clinictab);
            sql += bllClicTab.inChargertabDay(clinictab);
            ///插入门诊核算汇总
            sql += bllClicTab.inClinictab_costgather(clinictab);
            ///修改班结表中日结号外键
            sql += bllClicTab.upClinicTabDuty(clinictab);
            ///未日结的插0            
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("门诊日结失败!");
                return;
            }
            MessageBox.Show("门诊日结成功!");
            this.Close();
        }
        /// <summary>
        /// 住院日结
        /// </summary>
        private void ihspTab()
        {
          

        }
        private void dtpEtime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEtime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("截止日期不能大于当前日期");
                dtpEtime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
            if (DateTime.Compare(this.dtpStime.Value, this.dtpEtime.Value) > 0)
            {
                MessageBox.Show("错误：截止时间应该大于起始时间 ！");
                dtpEtime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }        
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
           
                clinicSearchMethod();
           
        }
       
    }
}
