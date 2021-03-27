using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.common;
using MTHIS.main.bll;
using MTREG.ihsptab.bo;
using MTREG.ihsptab.bll;
using MTREG.ihsptab.bll;
using MTREG.ihsptab;
using MTREG.clintab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmHspTab : Form
    {
        Ihsptab ihsptabFrm = new Ihsptab();
        BllIhsptab billIhsptab = new BllIhsptab();
        BillCmbList billCmbList = new BillCmbList();
        string settletype;
        bool exist = false;
        public FrmHspTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查找方法
        /// </summary>
        public void searchMethod()
        {
            ihsptabFrm.Startdate = this.dtpStartTime.Value.ToString();
            ihsptabFrm.Enddate = this.dtpEndTime.Value.ToString();
     
            ihsptabFrm.Depart_id = cmbDep.SelectedValue.ToString();
            if (ihsptabFrm.Depart_id == "0")
            {
                ihsptabFrm.Depart_id = "";
            }
            double payiscash = 0.00;
            double paynocash = 0.00;
            DataTable dtpay = billIhsptab.paySearch("", ihsptabFrm);
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
                        if(dtpay.Rows[i]["paytypename"].ToString()=="现金")
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
            DataTable dtacc = new DataTable();// billIhsptab.accountSearch("", ihsptabFrm);
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
            this.dgvIhsptabAcc.Columns["ihsptab_id"].Visible=false;
            #endregion
            lblAccIsCash.Text = DataTool.FormatData(acciscash.ToString(),"2");
            lblAccNoCash.Text = DataTool.FormatData(accnocash.ToString(),"2");
            lblAllIsCash.Text = DataTool.FormatData((payiscash + acciscash).ToString(),"2");
            lblAllNoCash.Text = DataTool.FormatData((paynocash + accnocash).ToString(),"2");
            lblAll.Text = DataTool.FormatData((payiscash + acciscash + paynocash + accnocash).ToString(),"2");
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhsptab_Load(object sender, EventArgs e)
        {
            BllClicTab bllClicTab = new BllClicTab();
            if (!bllClicTab.ihspTabIshave())
            {
                FrmIhspTabInit frmStartTime = new FrmIhspTabInit("ihsptab");
                frmStartTime.ShowDialog();
                if (frmStartTime.DialogResult != DialogResult.OK)
                {
                    btnAccount.Enabled = false;
                }
            }
            ///收费科室
            DataTable dtdep = billCmbList.depTypeList();
            if (dtdep.Rows.Count > 0)
            {
                this.cmbDep.ValueMember = "id";
                this.cmbDep.DisplayMember = "name";
                this.cmbDep.DataSource = dtdep;
            }

            ///查询结账方式
            DataTable dtConfig = billIhsptab.getSettleType();
            dtpStartTime.Enabled = false;
            string enddate = billIhsptab.tabEndDate(cmbDep.SelectedValue.ToString());
            dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            settletype = dtConfig.Rows[0]["settletype"].ToString();
            if (!string.IsNullOrEmpty(enddate))
            {
                dtpStartTime.Value = Convert.ToDateTime(enddate);
                if (Convert.ToDateTime(enddate).Day == Convert.ToDateTime(BillSysBase.currDate()).Day)
                {
                    btnAccount.Enabled = false;
                }
            }
         

            tbxCharger.ReadOnly = true;
            tbxCharger.Text = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            searchMethod();                                  
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
        /// 结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {

            ihspTab();
        }
        /// <summary>
        /// 住院日结
        /// </summary>
        private void ihspTab()
        {
            Ihsptab ihsptab = new Ihsptab();
            ihsptab.Depart_id = ProgramGlobal.Depart_id;
            ihsptab.Billcode = BillSysBase.newBillcode("Ihsptab_day_billcode");
            ihsptab.Id = BillSysBase.nextId("ihsptab_day");
            ihsptab.Startdate = dtpStartTime.Value.ToString();
            ihsptab.Enddate = dtpEndTime.Value.ToString();
            ihsptab.Settleby = ProgramGlobal.User_id;
            ihsptab.Settledate = BillSysBase.currDate();
            string sql = "";
            sql += billIhsptab.inIhsptabDay(ihsptab);
            ///未日结的插0
            sql += billIhsptab.inChargertabDay(ihsptab);

            ///在院结算汇总
            sql += billIhsptab.inIhsptap_costgather(ihsptab);
            ///出院结算汇总
            sql += billIhsptab.inIhsptab_outcostgather(ihsptab);
            
            sql += billIhsptab.upIhsptabDuty( ihsptab);
          
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("日结失败!");
                return;
            }
            MessageBox.Show("结算成功!");
            this.Close();
        }

        /// <summary>
        /// 截止时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
