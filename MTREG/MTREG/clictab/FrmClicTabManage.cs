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
using MTREG.common;

using MTHIS.main.bll;
using MTREG.clintab;
using MTREG.ihsptab;
using MTREG.ihsptab.bll;
using MTREG.clintab.bo;

namespace MTREG.clintab
{
    public partial class FrmClicTabManage : Form
    {
        BllClicTab bllClinicTab = new BllClicTab();
        BllIhsptab billIhsptab = new BllIhsptab();
        BllClicTabManage bllClinicTabManage = new BllClicTabManage();
        /// <summary>
        /// 结算方式
        /// </summary>
        string settletype;

        FrmPreView frmPreView = new FrmPreView();

        public FrmPreView FrmPreView
        {
            get { return frmPreView; }
            set { frmPreView = value; }
        }
        public FrmClicTabManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinicTabManage_Load(object sender, EventArgs e)
        {
            loadSelectDrop();
            dtpStime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEtime.Value = Convert.ToDateTime(BillSysBase.currDate());
            DataTable dtConfig = bllClinicTab.getSettleType();
            settletype = dtConfig.Rows[0]["settletype"].ToString();
           
            clinicSearch();
            DataTable dtId = bllClinicTabManage.getTabMaxId(cmbDpt.SelectedValue.ToString());
            if (dtId.Rows.Count == 0 || string.IsNullOrEmpty(dtId.Rows[0]["id"].ToString()))
            {
                btnRetreatSettle.Enabled=false;
            }
        }
        /// <summary>
        /// 加载cmb
        /// </summary>
        private void loadSelectDrop()
        {
            var dt = bllClinicTab.getTabDptInfo();
            this.cmbDpt.ValueMember = "Id";
            this.cmbDpt.DisplayMember = "Name";
            this.cmbDpt.DataSource = dt;
        }
      
        /// <summary>
        /// 门诊查询数据
        /// </summary>
        private void clinicSearch()
        {
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            string depart = cmbDpt.SelectedValue.ToString();
            dgvClinicTab.DataSource = bllClinicTabManage.getClinicTabDay(startDate, endDate, depart);
            #region updateHeaderText
            dgvClinicTab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClinicTab.ReadOnly = true;
            dgvClinicTab.Columns["id"].Visible = false;
            dgvClinicTab.Columns["depart_id"].Visible = false;
            dgvClinicTab.Columns["settledate"].Visible = false;
            dgvClinicTab.Columns["billcode"].HeaderText = "结算单号";
            dgvClinicTab.Columns["billcode"].Width = 150;
            dgvClinicTab.Columns["billcode"].DisplayIndex = 0;
            dgvClinicTab.Columns["dptname"].HeaderText = "科室";
            dgvClinicTab.Columns["dptname"].DisplayIndex = 1;
            dgvClinicTab.Columns["dptname"].Width = 150;
            dgvClinicTab.Columns["startdate"].HeaderText = "上次结账时间";
            dgvClinicTab.Columns["startdate"].Width = 200;
            dgvClinicTab.Columns["startdate"].DisplayIndex = 2;
            dgvClinicTab.Columns["enddate"].HeaderText = "本次结账时间";
            dgvClinicTab.Columns["enddate"].DisplayIndex = 3;
            dgvClinicTab.Columns["enddate"].Width = 200;
            #endregion
        }
      
        /// <summary>
        /// 查询按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
          
                clinicSearch();
          
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
            clinictab.Depart_id = cmbDpt.SelectedValue.ToString();
            if (bllClinicTabManage.getLastClinicTab(clinictab))
            {
                startDate = clinictab.Startdate;
                endDate = clinictab.Enddate;
            }
            else
            {
                MessageBox.Show("无可退日结!");
                return;
            }
            if (MessageBox.Show("确定要退结算开始" + startDate + "结束" + endDate, "退结算", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                string sql = bllClinicTabManage.retClinicTab(clinictab.Depart_id);
                    if (BllMain.Db.Update(sql) < 0)
                    {
                        MessageBox.Show("退日结算失败!");
                        return;
                    }
                    MessageBox.Show("退日结算成功!");
                    clinicSearch();
                   
            }            
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tcTab.SelectedTab == tpClinic)
            {
                FrmClicTabReport frmClinicTabReport = new FrmClicTabReport();
                if (dgvClinicTab.Rows.Count > 0 && dgvClinicTab.SelectedRows.Count > 0)
                {
                    frmClinicTabReport.Text = "门诊日结打印";
                    frmClinicTabReport.ClinicTabReport.Clinictab_id = dgvClinicTab.CurrentRow.Cells["id"].Value.ToString();
                    frmClinicTabReport.ClinicTabReport.StarTime = dgvClinicTab.CurrentRow.Cells["startdate"].Value.ToString();
                    frmClinicTabReport.ClinicTabReport.EndTime = dgvClinicTab.CurrentRow.Cells["enddate"].Value.ToString();
                    frmClinicTabReport.ClinicTabReport.Flag = "tab";
                    frmClinicTabReport.Show();
                }
            }
            else if (tcTab.SelectedTab == tpIhsp)
            {
                if (dgvTabAccount.Rows.Count > 0 && dgvTabAccount.SelectedRows.Count > 0)
                {
                    this.FrmPreView.Ihsptab.Id = dgvTabAccount.SelectedRows[0].Cells["id"].Value.ToString();
                    this.FrmPreView.Ihsptab.Startdate = dgvTabAccount.SelectedRows[0].Cells["startdate"].Value.ToString();
                    this.FrmPreView.Ihsptab.Enddate = dgvTabAccount.SelectedRows[0].Cells["enddate"].Value.ToString();
                    this.FrmPreView.Ihsptab.Charger_id = dgvTabAccount.SelectedRows[0].Cells["charger"].Value.ToString();
                    this.FrmPreView.Ihsptab.Depart_id = dgvTabAccount.SelectedRows[0].Cells["depart_id"].Value.ToString();
                    this.FrmPreView.Ihsptab.Paytype = "tab";
                    frmPreView.ShowDialog();
                }
            }
        }

        private void dgvClinicTab_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvClinicTab.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvClinicTab.RowHeadersDefaultCellStyle.Font, rectangle, dgvClinicTab.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 行标 列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTabAccount_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvTabAccount.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvTabAccount.RowHeadersDefaultCellStyle.Font, rectangle, dgvTabAccount.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
