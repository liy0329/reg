using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clintab.bll;
using MTREG.clintab.bo;
using MTHIS.common;

namespace MTREG.clintab
{
    public partial class FrmClicAfterinfo : Form
    {
        BllClicAfterinfo bllAccountGathered = new BllClicAfterinfo();
        public FrmClicAfterinfo()
        {
            InitializeComponent();
        }

        private void FrmAccountGathered_Load(object sender, EventArgs e)
        {
            //加载下拉列表
            loadSelectDrop();
            //加载表格
            loadDataGrid();


        }
        private void loadSelectDrop()
        {
            dtpStimeI.Text = "2016/08/01 00:00:00";
            dtpStimeP.Text = "2016/08/01 00:00:00";
            dtpStimeI.Enabled = false;
            dtpStimeP.Enabled = false;
        }

        private void loadDataGrid()
        {
            getItemGather();
            #region updateHeaderText
            //dgvItemGather.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            //dgvItemGather.Columns["item_id"].Visible = false;
            //dgvItemGather.Columns["name"].HeaderText = "项目类型";
            //dgvItemGather.Columns["name"].Width = 160;
            //dgvItemGather.Columns["name"].DisplayIndex = 0;
            //dgvItemGather.Columns["receive"].HeaderText = "收款金额";
            //dgvItemGather.Columns["receive"].Width = 160;
            //dgvItemGather.Columns["receive"].DisplayIndex = 1;
            //dgvItemGather.Columns["refund"].HeaderText = "退费金额";
            //dgvItemGather.Columns["refund"].Width = 140;
            //dgvItemGather.Columns["refund"].DisplayIndex = 2;
            //dgvItemGather.Columns["realfee"].HeaderText = "实收金额";
            //dgvItemGather.Columns["realfee"].Width = 100;
            //dgvItemGather.Columns["realfee"].DisplayIndex = 3;
            //dgvItemGather.ReadOnly = true;
            //dgvItemGather.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        private void getItemGather()
        {
            string startDate = this.dtpStimeI.Value.ToString("yyyy-MM-dd hh-mm-ss");
            string endDate = this.dtpEtimeI.Value.ToString("yyyy-MM-dd hh-mm-ss");
           // dgvItemGather.DataSource = bllAccountGathered.getItemGather( startDate,endDate);
        }
        private void getPayTypeGather()
        {
            string startDate = this.dtpStimeP.Value.ToString("yyyy-MM-dd hh-mm-ss");
            string endDate = this.dtpEtimeP.Value.ToString("yyyy-MM-dd hh-mm-ss");
          //  dgvPaytypeGather.DataSource = bllAccountGathered.getPaytypeGather(startDate, endDate);
            #region updateHeaderText
            //dgvPaytypeGather.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            //dgvPaytypeGather.Columns["id"].Visible = false;
            //dgvPaytypeGather.Columns["name"].HeaderText = "项目类型";
            //dgvPaytypeGather.Columns["name"].Width = 160;
            //dgvPaytypeGather.Columns["name"].DisplayIndex = 0;
            //dgvPaytypeGather.Columns["receive"].HeaderText = "收款金额";
            //dgvPaytypeGather.Columns["receive"].Width = 160;
            //dgvPaytypeGather.Columns["receive"].DisplayIndex = 1;
            //dgvPaytypeGather.Columns["refund"].HeaderText = "退费金额";
            //dgvPaytypeGather.Columns["refund"].Width = 140;
            //dgvPaytypeGather.Columns["refund"].DisplayIndex = 2;
            //dgvPaytypeGather.Columns["realfee"].HeaderText = "实收金额";
            //dgvPaytypeGather.Columns["realfee"].Width = 100;
            //dgvPaytypeGather.Columns["realfee"].DisplayIndex = 3;
            //dgvPaytypeGather.ReadOnly = true;
            //dgvPaytypeGather.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        private void btnSearchI_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStimeI.Value.ToString();
            string timeEnd = this.dtpEtimeI.Value.ToString();
            //       frxPrintView.viewCharge(timeBegin, timeEnd);
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlI);
            frxPrintView.viewItemInWindow(timeBegin, timeEnd, "depart", "patienType");
        }

        private void btnSearchP_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStimeP.Value.ToString();
            string timeEnd = this.dtpEtimeP.Value.ToString();
            //       frxPrintView.viewCharge(timeBegin, timeEnd);
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrlP);
            frxPrintView.viewPayTypeInWindow(timeBegin, timeEnd, "depart", "patienType");
        }

        private void btnDesignI_Click(object sender, EventArgs e)
        {
            string tempName = "ClinicTabAfterCostItemInfo.frx";
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

        private void btnDesignP_Click(object sender, EventArgs e)
        {
            string tempName = "ClinicTabAfterPayTypeInfo.frx";
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

        private void btnPrintI_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStimeI.Value.ToString();
            string timeEnd = this.dtpEtimeI.Value.ToString();
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.printItem(timeBegin, timeEnd, "doctor", "patienType");
        }

        private void btnPrintP_Click(object sender, EventArgs e)
        {
            string timeBegin = this.dtpStimeI.Value.ToString();
            string timeEnd = this.dtpEtimeI.Value.ToString();
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.printPayType(timeBegin, timeEnd, "doctor", "patienType");
        }
    }
}
