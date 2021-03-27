using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.clintab.bo;
using MTREG.clintab.bll;

namespace MTREG.clintab
{
    public partial class FrmClicAdjustbydoctor : Form
    {
        BllFrxOper bllFrxOper = new BllFrxOper();
        public FrmClicAdjustbydoctor()
        {
            InitializeComponent();
        }
        private void FrmDoctorAccount_Load(object sender, EventArgs e)
        {
            //就诊类型
            var dtp = bllFrxOper.getRegtypeInfo();

            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            //科室
            var dt1 = bllFrxOper.getDepartInfo();
            this.cmbDepart.ValueMember = "Id";
            this.cmbDepart.DisplayMember = "Name";
            var dr = dt1.NewRow();
            dr["Id"] = 0;
            dr["Name"] = "--全部--";
            dt1.Rows.InsertAt(dr, 0);
            this.cmbDepart.DataSource = dt1;
            //科室类型
            cmbDepartType.Items.Add("处方科室");
            cmbDepartType.Items.Add("执行科室");
            cmbDepartType.Text = "处方科室";
        }
        /// <summary>
        /// 查询并预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStime.Value.ToString();
            string timeEnd = this.dtpEtime.Value.ToString();
            //       frxPrintView.viewCharge(timeBegin, timeEnd);
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrl);
            frxPrintView.viewDoctorInWindow(timeBegin, timeEnd,"RCPDPT", cmbDepart.SelectedValue.ToString(), cmbPatientType.SelectedValue.ToString());
        }
        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            string tempName = "ClinicDoctorAccounting.frx";
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
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStime.Value.ToString();
            string timeEnd = this.dtpEtime.Value.ToString();
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.printDoctorAccount(timeBegin,timeEnd,"RCPDPT",cmbDepart.SelectedValue.ToString(), cmbPatientType.SelectedValue.ToString());
        }


    }
}
