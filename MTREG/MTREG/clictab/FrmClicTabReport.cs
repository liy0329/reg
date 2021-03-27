using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clintab.bo;
using MTHIS.common;
using MTREG.clintab.bll;

namespace MTREG.clintab
{
    public partial class FrmClicTabReport : Form
    {
        ClinicTabReport clinicTabReport = new ClinicTabReport();
        BllClicTabManage bllClinicTabManage = new BllClicTabManage();

        internal ClinicTabReport ClinicTabReport
        {
            get { return clinicTabReport; }
            set { clinicTabReport = value; }
        }
        public FrmClicTabReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 预览按钮 已去掉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tcReport.SelectedTab.Name == "tpCharger")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.printClinicTabCharger(ClinicTabReport.Clinictab_id, ClinicTabReport.Flag,"view");
            }
            else if (tcReport.SelectedTab.Name == "tpIncome")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.viewClinicTabCostAmtInWindow(ClinicTabReport.Clinictab_id, ClinicTabReport.StarTime, ClinicTabReport.EndTime);
            }
            else if (tcReport.SelectedTab.Name == "tpPayType")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.viewClinicTabPayTypeInWindow(ClinicTabReport.Clinictab_id, ClinicTabReport.StarTime, ClinicTabReport.EndTime, ClinicTabReport.Flag);
            }
            else if (tcReport.SelectedTab == tpMember)
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.printMembere(ClinicTabReport.Info, ClinicTabReport.StarTime, ClinicTabReport.EndTime, ClinicTabReport.Flag,"view");
            }
        }

        
        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (tcReport.SelectedTab.Name == "tpCharger")
            {
                string tempName = "ClinicTabForCharger.frx";
                string tempPath = GlobalParams.reportDir + "\\" + tempName;
                try
                {
                    FastReport.Report temp = new FastReport.Report();
                    temp.Load(tempPath);
                    temp.Design();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开设置界面失败！");
                }
            }
            else if (tcReport.SelectedTab.Name == "tpIncome")
            {
                string tempName = "ClinicTabForCostAmt.frx";
                string tempPath = GlobalParams.reportDir + "\\" + tempName;
                try
                {
                    FastReport.Report temp = new FastReport.Report();
                    temp.Load(tempPath);
                    temp.Design();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开设置界面失败！");
                }
            }
            else if (tcReport.SelectedTab.Name == "tpPayType")
            {
                string tempName = "ClinicTabForPaytype.frx";
                string tempPath = GlobalParams.reportDir + "\\" + tempName;
                try
                {
                    FastReport.Report temp = new FastReport.Report();
                    temp.Load(tempPath);
                    temp.Design();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开设置界面失败！");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tcReport.SelectedTab.Name == "tpCharger")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.printClinicTabCharger(ClinicTabReport.Clinictab_id, ClinicTabReport.Flag,"print");
            }
            else if (tcReport.SelectedTab.Name == "tpIncome")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.printClinicTabCostAmt(ClinicTabReport.Clinictab_id, timeBegin, timeEnd);
            }
            else if (tcReport.SelectedTab.Name == "tpPayType")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.printClinicTabPayType(ClinicTabReport.Clinictab_id, timeBegin, timeEnd, ClinicTabReport.Flag);
            }
        }

        private void FrmClinicTabReport_Load(object sender, EventArgs e)
        {
            if (ClinicTabReport.Flag == "duty")
            {
                tpIncome.Parent = null;
            }
            this.dtpStime.Value = Convert.ToDateTime(ClinicTabReport.StarTime);
            this.dtpEtime.Value = Convert.ToDateTime(ClinicTabReport.EndTime);
            string timeBegin = this.dtpStime.Value.ToString();
            string timeEnd = this.dtpEtime.Value.ToString();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlC);
            frxPrintView.printClinicTabCharger(ClinicTabReport.Clinictab_id, ClinicTabReport.Flag, "view");
        }

        private void tcReport_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            if (tcReport.SelectedTab.Name == "tpCharger")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlC);
                frxPrintView.printClinicTabCharger(ClinicTabReport.Clinictab_id, ClinicTabReport.Flag, "view");
            }
            else if (tcReport.SelectedTab.Name == "tpIncome")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlI);
                frxPrintView.viewClinicTabCostAmtInWindow(ClinicTabReport.Clinictab_id, ClinicTabReport.StarTime, ClinicTabReport.EndTime);
            }
            else if (tcReport.SelectedTab.Name == "tpPayType")
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlP);
                frxPrintView.viewClinicTabPayTypeInWindow(ClinicTabReport.Clinictab_id, ClinicTabReport.StarTime, ClinicTabReport.EndTime, ClinicTabReport.Flag);
            }
            else if (tcReport.SelectedTab == tpMember)
            {
                string timeBegin = this.dtpStime.Value.ToString();
                string timeEnd = this.dtpEtime.Value.ToString();
                FrxPrintView frxPrintView = new FrxPrintView(this.pcMember);
                frxPrintView.printMembere(ClinicTabReport.Info, ClinicTabReport.StarTime, ClinicTabReport.EndTime, ClinicTabReport.Flag,"view");
            }            
        }

    }
}
