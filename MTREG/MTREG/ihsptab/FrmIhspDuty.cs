using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsptab.bo;
using MTREG.ihsptab.bll;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.ihsptab;
using MTREG.ihsptab.bll;
using MTREG.clintab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmIhspDuty : Form
    {
        Ihsptab ihsptab = new Ihsptab();
        BllIhsptab bllIhsptab = new BllIhsptab();
       
         
        public FrmIhspDuty()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        public void searchMethod()
        {
            ihsptab.Startdate = this.dtpStartTime.Value.ToString();
            ihsptab.Enddate = this.dtpEndTime.Value.ToString();
            ihsptab.Charger_id = ProgramGlobal.User_id;
           
            double payiscash = 0.00;
            double paynocash = 0.00;
            DataTable dtpay = bllIhsptab.paySearch("", ihsptab);
            DataColumn paycol = new DataColumn();
            paycol.ColumnName = "序列";
            dtpay.Columns.Add(paycol);
            dtpay.Columns["序列"].SetOrdinal(0);
            if (dtpay != null && dtpay.Rows.Count > 0)
            {
                if (dtpay.Rows.Count > 0)
                {
                    DataRow dr = dtpay.NewRow();
                    double payfee = 0.00;
                    for (int i = 0; i < dtpay.Rows.Count; i++)
                    {
                        payfee = payfee + double.Parse(dtpay.Rows[i]["payfee"].ToString());
                        if (dtpay.Rows[i]["paytypename"].ToString() == "现金")
                        {
                            payiscash += double.Parse(dtpay.Rows[i]["payfee"].ToString());
                        }
                    }
                    dr["序列"] = "合计：";
                    dr["payfee"] = payfee;
                    dtpay.Rows.Add(dr);
                    paynocash = payfee - payiscash;
                }
            }
            lblPayIsCash.Text = DataTool.FormatData(payiscash.ToString(), "2");
            lblPayNoCash.Text = DataTool.FormatData(paynocash.ToString(), "2");
            dgvIhsptabPay.DataSource = dtpay;
            #region  dgvIhsptabPay单元格标题设置
            this.dgvIhsptabPay.Columns["序列"].HeaderText = "序列";
            this.dgvIhsptabPay.Columns["序列"].Width = 100;
            this.dgvIhsptabPay.Columns["charger"].HeaderText = "收费员";
            this.dgvIhsptabPay.Columns["charger"].Width = 100;
            this.dgvIhsptabPay.Columns["ihspname"].HeaderText = "患者姓名";
            this.dgvIhsptabPay.Columns["ihspname"].Width = 100;
            this.dgvIhsptabPay.Columns["departname"].HeaderText = "科室";
            this.dgvIhsptabPay.Columns["departname"].Width = 100;
            this.dgvIhsptabPay.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvIhsptabPay.Columns["ihspcode"].Width = 100;
            this.dgvIhsptabPay.Columns["payfee"].HeaderText = "费用金额";
            this.dgvIhsptabPay.Columns["payfee"].Width = 100;
            this.dgvIhsptabPay.Columns["paytypename"].HeaderText = "收款类别";
            this.dgvIhsptabPay.Columns["paytypename"].Width = 80;
            this.dgvIhsptabPay.Columns["chargedate"].HeaderText = "缴款时间";
            this.dgvIhsptabPay.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhsptabPay.Columns["chargedate"].Width = 110;
            this.dgvIhsptabPay.Columns["ihsptab_id"].HeaderText = "班结外键";
            this.dgvIhsptabPay.Columns["ihsptab_id"].Visible = false;
            #endregion
            double acciscash = 0.00;
            double accnocash = 0.00;
            DataTable dtacc = new DataTable();// bllIhsptab.accountSearch("", ihsptab);
            DataColumn acccol = new DataColumn();
            acccol.ColumnName = "序列";
            dtacc.Columns.Add(acccol);
            dtacc.Columns["序列"].SetOrdinal(0);
            if (dtacc != null && dtacc.Rows.Count > 0)
            {
                if (dtacc.Rows.Count > 0)
                {
                    DataRow dr = dtacc.NewRow();
                    double prepamt = 0.00;
                    double feeamt = 0.00;
                    double retfee = 0.00;
                    for (int i = 0; i < dtacc.Rows.Count; i++)
                    {
                        if (dtacc.Rows[i]["prepamt"].ToString() != "")
                        {
                            prepamt = prepamt + double.Parse(DataTool.FormatData(dtacc.Rows[i]["prepamt"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["feeamt"].ToString() != "")
                        {
                            feeamt = feeamt + double.Parse(DataTool.FormatData(dtacc.Rows[i]["feeamt"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["retfee"].ToString() != "")
                        {
                            retfee = retfee + double.Parse(DataTool.FormatData(dtacc.Rows[i]["retfee"].ToString(), "2"));
                        }
                        if (dtacc.Rows[i]["paytypename"].ToString() == "现金")
                        {
                            if (dtacc.Rows[i]["feeamt"].ToString() != "")
                            {
                                acciscash += double.Parse(DataTool.FormatData(dtacc.Rows[i]["feeamt"].ToString(), "2"));
                            }
                        }
                    }
                    dr["序列"] = "合计：";
                    dr["prepamt"] = prepamt;
                    dr["feeamt"] = feeamt;
                    dr["retfee"] = retfee;
                    dtacc.Rows.Add(dr);
                    accnocash = feeamt - acciscash;
                }
            }
            dgvIhsptabAcc.DataSource = dtacc;
            #region  dgvIhsptabAcc单元格标题设置
            this.dgvIhsptabAcc.Columns["序列"].HeaderText = "序列";
            this.dgvIhsptabAcc.Columns["序列"].Width = 100;
            this.dgvIhsptabAcc.Columns["charger"].HeaderText = "收费员";
            this.dgvIhsptabAcc.Columns["charger"].Width = 100;
            this.dgvIhsptabAcc.Columns["ihspname"].HeaderText = "患者姓名";
            this.dgvIhsptabAcc.Columns["ihspname"].Width = 100;
            this.dgvIhsptabAcc.Columns["departname"].HeaderText = "科室";
            this.dgvIhsptabAcc.Columns["departname"].Width = 100;
            this.dgvIhsptabAcc.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvIhsptabAcc.Columns["ihspcode"].Width = 100;
            this.dgvIhsptabAcc.Columns["indate"].HeaderText = "入院时间";
            this.dgvIhsptabAcc.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhsptabAcc.Columns["indate"].Width = 110;
            this.dgvIhsptabAcc.Columns["outdate"].HeaderText = "出院时间";
            this.dgvIhsptabAcc.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhsptabAcc.Columns["outdate"].Width = 110;
            this.dgvIhsptabAcc.Columns["prepamt"].HeaderText = "预售款额";
            this.dgvIhsptabAcc.Columns["prepamt"].Width = 80;
            this.dgvIhsptabAcc.Columns["feeamt"].HeaderText = "费用合计";
            this.dgvIhsptabAcc.Columns["feeamt"].Width = 80;
            this.dgvIhsptabAcc.Columns["retfee"].HeaderText = "结退金额";
            this.dgvIhsptabAcc.Columns["retfee"].Width = 80;
            this.dgvIhsptabAcc.Columns["paytypename"].HeaderText = "收款类别";
            this.dgvIhsptabAcc.Columns["paytypename"].Width = 80;
            this.dgvIhsptabAcc.Columns["ihsptab_id"].HeaderText = "班结外键";
            this.dgvIhsptabAcc.Columns["ihsptab_id"].Visible = false;
            #endregion
            lblAccIsCash.Text = DataTool.FormatData(acciscash.ToString(), "2");
            lblAccNoCash.Text = DataTool.FormatData(accnocash.ToString(), "2");
            lblAllIsCash.Text = DataTool.FormatData((payiscash + acciscash).ToString(), "2");
            lblAllNoCash.Text = DataTool.FormatData((paynocash + accnocash).ToString(), "2");
            lblAll.Text = DataTool.FormatData((payiscash + acciscash + paynocash + accnocash).ToString(), "2");
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhsptabDuty_Load(object sender, EventArgs e)
        {
            BllClicTab bllClicTab = new BllClicTab();
            if (!bllClicTab.ihspDutyIshave())
            {
                FrmIhspTabInit frmStartTime = new FrmIhspTabInit("ihspduty");
                frmStartTime.ShowDialog();
                if (frmStartTime.DialogResult != DialogResult.OK)
                {
                    btnAccount.Enabled = false;
                }
            }
            dtpStartTime.Enabled = false;
            string enddate = bllIhsptab.dutyEndDate(ProgramGlobal.User_id);
            dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            if (!string.IsNullOrEmpty(enddate))
            {
                dtpStartTime.Value = Convert.ToDateTime(enddate);
            }
            tbxCharger.ReadOnly = true;
            tbxCharger.Text = bllIhsptab.getDoctorName(ProgramGlobal.User_id);
            tbxPer.ReadOnly = true;
            tbxPer.Text = bllIhsptab.getDoctorName(ProgramGlobal.User_id);
            searchMethod();                        
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("截止日期不能大于当前日期");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误：截止时间应该大于起始时间 ！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
          
            Ihsptab ihsptab = new Ihsptab();
            ihsptab.Depart_id = ProgramGlobal.Depart_id;
            ihsptab.Billcode = BillSysBase.newBillcode("ihsptab_duty_billcode");
            ihsptab.Id = BillSysBase.nextId("ihsptab_duty");
            ihsptab.Startdate = dtpStartTime.Value.ToString();
            ihsptab.Enddate = dtpEndTime.Value.ToString();
            ihsptab.Charger_id = ProgramGlobal.User_id;
            ihsptab.Settleby = ProgramGlobal.User_id;
            ihsptab.Daytab = "N";
            if (!bllIhsptab.doIhsptabDuty(ihsptab))
            {
                MessageBox.Show("班结失败");
                return;
            }
            DialogResult = DialogResult.OK;
            MessageBox.Show("班结成功!");         
            this.Close();
        }

    }
}
