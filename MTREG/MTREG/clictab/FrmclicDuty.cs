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
using MTREG.ihsptab;

namespace MTREG.clintab
{
    public partial class FrmClicDuty : Form
    {
        BllMemberTab bllMemberTab = new BllMemberTab();
        BllClicTab bllClicTab = new BllClicTab();
        public FrmClicDuty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 门诊方法
        /// </summary>
        public void clinicSearch()
        {
            string startdate = dtpStime.Value.ToString();
            string enddate = dtpEtime.Value.ToString();
          
            string chargeby = ProgramGlobal.User_id;
            DataTable dt = bllClicTab.dutyClinicInvoice(startdate, enddate,  chargeby);
            dgvClinicInvoice.DataSource = dt;
            #region updateHeaderText
            dgvClinicInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClinicInvoice.ReadOnly = true;
            dgvClinicInvoice.Columns["id"].Visible = false;
            dgvClinicInvoice.Columns["invoice"].HeaderText = "发票号";
            dgvClinicInvoice.Columns["invoice"].DisplayIndex = 0;
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
        /// 储值卡方法
        /// </summary>
        public void memberSearch()
        {
            string startdate = dtpStime.Value.ToString();
            string enddate = dtpEtime.Value.ToString();
            string type = "duty";
            string chargeby = ProgramGlobal.User_id;
            DataTable dt = bllMemberTab.getRechargedetInfo(startdate, enddate, chargeby, type);
            dgvRechargedet.DataSource = dt;
            #region updateHeaderText
            dgvRechargedet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRechargedet.ReadOnly = true;
            dgvRechargedet.Columns["paytype"].HeaderText = "支付类型";
            dgvRechargedet.Columns["paytype"].DisplayIndex = 0;
            dgvRechargedet.Columns["paytype"].Width = 115;
            dgvRechargedet.Columns["opertype"].HeaderText = "操作类型";
            dgvRechargedet.Columns["opertype"].DisplayIndex = 1;
            dgvRechargedet.Columns["opertype"].Width = 105;
            dgvRechargedet.Columns["amount"].HeaderText = "操作金额";
            dgvRechargedet.Columns["amount"].DisplayIndex = 2;
            dgvRechargedet.Columns["amount"].Width = 125;
            dgvRechargedet.Columns["doctor"].HeaderText = "操作人";
            dgvRechargedet.Columns["doctor"].DisplayIndex = 3;
            dgvRechargedet.Columns["doctor"].Width = 105;
            dgvRechargedet.Columns["depart"].HeaderText = "操作科室";
            dgvRechargedet.Columns["depart"].DisplayIndex = 4;
            dgvRechargedet.Columns["depart"].Width = 115;
            dgvRechargedet.Columns["operatdate"].HeaderText = "操作时间";
            dgvRechargedet.Columns["operatdate"].DisplayIndex = 5;
            dgvRechargedet.Columns["operatdate"].Width =195;
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
            tbxMemAccount.Text = (reAmount - enAmount).ToString();
        }
        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clinicSearch();
            memberSearch();
        }

        /// <summary>
        /// 结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettle_Click(object sender, EventArgs e)
        {
            Clinictab clinictab = new Clinictab();
            clinictab.Startdate = dtpStime.Value.ToString();
            clinictab.Enddate = dtpEtime.Value.ToString();
            if (dtpEtime.Value <= dtpStime.Value)
            {
                dtpEtime.Focus();
                MessageBox.Show("班结时间不能小于上次班结时间，请正确选择班结时间!");
                return;
            }
            clinictab.Settledate= BillSysBase.currDate();
            clinictab.Settleby = ProgramGlobal.User_id;
            clinictab.Depart_id = ProgramGlobal.Depart_id;
            clinictab.Charger_id = ProgramGlobal.User_id;
            clinictab.Daytab = "N";
            if (!bllClicTab.doClinictabDuty(clinictab))
            {
                MessageBox.Show("班结失败");
                return;
            }
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("班结成功!");
            this.Close();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinictabDuty_Load(object sender, EventArgs e)
        {
            if (!bllClicTab.clinicDutyIshave(ProgramGlobal.User_id))
            {
                FrmClinTabInit frmStartTime = new FrmClinTabInit("clinicduty");
                frmStartTime.ShowDialog();
                if (frmStartTime.DialogResult != DialogResult.OK)
                {
                    btnSettle.Enabled = false;
                }
            }
        
            string starttime = bllClicTab.getDutyEndtime(ProgramGlobal.User_id);
            string endtime = BillSysBase.currDate();
            if (string.IsNullOrEmpty(starttime))
            {
                starttime = endtime;
            }
            dtpStime.Value = Convert.ToDateTime(starttime);
            dtpEtime.Value = Convert.ToDateTime(endtime);
            dtpStime.Enabled = false;
            tbxPer.Enabled = false;
            tbxUsers.Enabled = false;
            tbxPer.Text = bllClicTab.getDoctorName(ProgramGlobal.User_id);
            tbxUsers.Text = bllClicTab.getDoctorName(ProgramGlobal.User_id);
            clinicSearch();
            memberSearch();          
        }


        /// <summary>
        /// 截止时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEtime_ValueChanged(object sender, EventArgs e)
        {
                  
        }

        private void dtpEtime_Leave(object sender, EventArgs e)
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
    }
}
