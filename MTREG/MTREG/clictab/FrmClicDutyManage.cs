using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clintab.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.clintab.bo;

namespace MTREG.clintab
{
    public partial class FrmClicDutyManage : Form
    {
        BllClicTab bllClicTab = new BllClicTab();
        BllClicTabManage bllClinicTabManage = new BllClicTabManage();
        public FrmClicDutyManage()
        {
            InitializeComponent();
        }

        private void FrmClicDutyManage_Load(object sender, EventArgs e)
        {
            dtpStime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEtime.Value = Convert.ToDateTime(BillSysBase.currDate());
            tbxPer.Text = bllClicTab.getDoctorName(ProgramGlobal.User_id);
            tbxPer.Enabled = false;
            searchMethod();
            DataTable dt = bllClinicTabManage.getDutyMaxId(ProgramGlobal.User_id);
            if (dt.Rows.Count == 0 || string.IsNullOrEmpty(dt.Rows[0]["id"].ToString()))
            {
                btnRetreatSettle.Enabled = false;
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public void searchMethod()
        {
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd")+ " 23:59:59";
          

            dgvClinicTab.DataSource = bllClinicTabManage.getClinicTabDuty(startDate, endDate, tbxPer.Text);
            #region updateHeaderText
            dgvClinicTab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClinicTab.ReadOnly = true;
            dgvClinicTab.Columns["id"].Visible = false;
            dgvClinicTab.Columns["depart_id"].Visible = false;
            dgvClinicTab.Columns["settleby"].Visible = false;
            dgvClinicTab.Columns["billcode"].HeaderText = "结算单号";
            dgvClinicTab.Columns["billcode"].Width = 150;
            dgvClinicTab.Columns["billcode"].DisplayIndex = 0;
            dgvClinicTab.Columns["dptname"].HeaderText = "科室";
            dgvClinicTab.Columns["dptname"].DisplayIndex = 1;
            dgvClinicTab.Columns["dptname"].Width = 150;
            dgvClinicTab.Columns["dctname"].HeaderText = "收费员";
            dgvClinicTab.Columns["dctname"].DisplayIndex = 2;
            dgvClinicTab.Columns["startdate"].HeaderText = "上次结账时间";
            dgvClinicTab.Columns["startdate"].Width = 200;
            dgvClinicTab.Columns["startdate"].DisplayIndex = 3;
            dgvClinicTab.Columns["enddate"].HeaderText = "本次结账时间";
            dgvClinicTab.Columns["enddate"].DisplayIndex = 4;
            dgvClinicTab.Columns["enddate"].Width = 200;
            
            
            #endregion
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
        /// 退结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetreatSettle_Click(object sender, EventArgs e)
        {
            string startDate = this.dtpStime.Value.ToString();
            string endDate = this.dtpEtime.Value.ToString();
            Clinictab clinictab = new Clinictab();
            clinictab.Charger_id = ProgramGlobal.User_id;
            if (bllClinicTabManage.getLastClinicTabDuty(clinictab))
            {
                startDate = clinictab.Startdate;
                endDate = clinictab.Enddate;
            }
            else
            {
                MessageBox.Show("上次日结后，无可退班结!!");
                return;
            }
            
            if (MessageBox.Show("确定要退结算开始" + startDate + "结束" + endDate, "退结算", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int flag = bllClinicTabManage.deleteClinicTabDuty(clinictab.Charger_id);
                if (flag < 0)
                {
                    MessageBox.Show("退结算失败!");
                    return;
                }
                MessageBox.Show("退结算成功!");
              
            }
            searchMethod();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmClicTabReport frmClinicTabReport = new FrmClicTabReport();
            if (dgvClinicTab.Rows.Count > 0 && dgvClinicTab.CurrentRow != null)
            {
                frmClinicTabReport.Text = "门诊班结打印";
                frmClinicTabReport.ClinicTabReport.Clinictab_id = dgvClinicTab.CurrentRow.Cells["id"].Value.ToString();
                frmClinicTabReport.ClinicTabReport.Info = dgvClinicTab.CurrentRow.Cells["settleby"].Value.ToString();
                frmClinicTabReport.ClinicTabReport.StarTime = dgvClinicTab.CurrentRow.Cells["startdate"].Value.ToString();
                frmClinicTabReport.ClinicTabReport.EndTime = dgvClinicTab.CurrentRow.Cells["enddate"].Value.ToString();
                frmClinicTabReport.ClinicTabReport.Flag = "duty";
                frmClinicTabReport.Show();
            }
        }

        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicTab_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvClinicTab.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvClinicTab.RowHeadersDefaultCellStyle.Font, rectangle, dgvClinicTab.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            FrmClicDuty frmClicDuty = new FrmClicDuty();
            frmClicDuty.ShowDialog();
            if (frmClicDuty.DialogResult == DialogResult.OK)
            {
                searchMethod();
            }
        }
    }
}
