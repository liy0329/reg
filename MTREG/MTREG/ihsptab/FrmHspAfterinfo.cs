using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.ihsp.bo;
using MTREG.ihsptab.bo;
using MTREG.ihsptab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmHspAfterinfo : Form
    {
        Ihsptab ihsptabFrm = new Ihsptab();
        BllIhsptab billIhsptab = new BllIhsptab();
        BillCmbList billCmbList = new BillCmbList();
        public FrmHspAfterinfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查找方法
        /// </summary>
        public void searchMethod()
        {
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrl);
            ihsptabFrm.Startdate = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            ihsptabFrm.Enddate = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string name = tbxName.Text.Trim();
            string charger = tbxCharger.Text.Trim();
       
          //  frxPrintView.afterAcc(ihsptabFrm, name, charger, "view");
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
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrl);
            ihsptabFrm.Startdate = dtpStartTime.Value.ToString();
            ihsptabFrm.Enddate = dtpEndTime.Value.ToString();
            string name = tbxName.Text.Trim();
            string charger = tbxCharger.Text.Trim();
          
           // frxPrintView.afterAcc(ihsptabFrm, name, charger, "print");
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAfterAcc_Load(object sender, EventArgs e)
        {
            cbxAfterAcc.Checked = true;
            dtpStartTime.Enabled = false;
            string enddate = billIhsptab.tabEndDate(cmbDep.SelectedValue.ToString());
            if (string.IsNullOrEmpty(enddate))
            {
                return;
            }
            dtpStartTime.Value = Convert.ToDateTime(enddate);
            tbxCharger.Enabled = false;
            tbxCharger.Text = billIhsptab.getDoctorName(ProgramGlobal.User_id);
            if (ProgramGlobal.Settletype == "PER")
            {
                cbxPer.Checked = true;
                cmbDep.Enabled = false;
                cmbPer.Enabled = true;
                cbxDep.Checked = false;
            }
            else
            {
                cbxPer.Checked = false;
                cbxDep.Checked = true;
                cmbDep.Enabled = true;
                cmbPer.Enabled = false;
            }
            searchMethod();
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

        /// <summary>
        /// 个人支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPer.Checked)
            {
                cmbDep.DataSource = null;
                cmbDep.Text = ProgramGlobal.DepartName;
                this.cmbPer.ValueMember = "id";
                this.cmbPer.DisplayMember = "name";
                this.cmbPer.DataSource = billCmbList.doctorNameGet(ProgramGlobal.Depart_id);
                cbxDep.Checked = false;
                cmbPer.Enabled = true;
                cmbDep.Enabled = false;
            }
            else
            {
                cmbPer.Enabled = false;
            }
        }

        /// <summary>
        /// 科室支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDep_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDep.Checked)
            {
                cmbPer.DataSource = null;
                DataTable dt = billCmbList.depTypeList();
                if (dt.Rows.Count > 0)
                {
                    this.cmbDep.ValueMember = "id";
                    this.cmbDep.DisplayMember = "name";
                    this.cmbDep.DataSource = dt;
                    cbxPer.Checked = false;
                    cmbPer.Enabled = false;
                    cmbDep.Enabled = true;
                }
            }
            else
            {
                cmbDep.Enabled = false;
            }
        }

        /// <summary>
        /// 是否结算后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAfterAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAfterAcc.Checked)
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = true;
                string enddate = billIhsptab.tabEndDate(cmbDep.SelectedValue.ToString());
                if (string.IsNullOrEmpty(enddate))
                {
                    return;
                }
                dtpStartTime.Value = Convert.ToDateTime(enddate);
                
            }
            else if (!cbxAfterAcc.Checked)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = false;
            }
        }

        /// <summary>
        /// 起始时间变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("起始日期不能大于当前日期");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
            dtpEndTime.Value = dtpStartTime.Value.AddDays(1);

        }
    }
}
