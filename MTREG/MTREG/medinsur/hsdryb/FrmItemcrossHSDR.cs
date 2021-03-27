using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hsdryb.bll;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmItemcrossHSDR : Form
    {
        public FrmItemcrossHSDR()
        {
            InitializeComponent();
        }
        private string insurtype_id;

        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }
        BllItemCrossHSDR bllItemCrossHSDR = new BllItemCrossHSDR();
        private void FrmItemcrossHSDR_Load(object sender, EventArgs e)
        {
            cbxDrug.Checked = true;
            loadHisDataGrid();
            #region updateHeaderText
            dgvHisItem.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvHisItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHisItem.Columns["id"].HeaderText = "编码";
            dgvHisItem.Columns["id"].DisplayIndex = 0;
            dgvHisItem.Columns["id"].Width = 100;
            dgvHisItem.Columns["standcode"].HeaderText = "医保内码";
            dgvHisItem.Columns["standcode"].DisplayIndex = 1;
            dgvHisItem.Columns["standcode"].Width = 100;
            dgvHisItem.Columns["name"].HeaderText = "名称";
            dgvHisItem.Columns["name"].Width = 150;
            dgvHisItem.Columns["name"].DisplayIndex = 2;
            dgvHisItem.Columns["spec"].HeaderText = "规格";
            dgvHisItem.Columns["spec"].Width = 120;
            dgvHisItem.Columns["spec"].DisplayIndex = 3;
            dgvHisItem.Columns["unit"].HeaderText = "单位";
            dgvHisItem.Columns["unit"].Width = 70;
            dgvHisItem.Columns["unit"].DisplayIndex = 4;
            dgvHisItem.Columns["city_prc"].HeaderText = "单价";
            dgvHisItem.Columns["city_prc"].Width = 90;
            dgvHisItem.Columns["city_prc"].DisplayIndex = 5;
            dgvHisItem.ReadOnly = true;
            dgvHisItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
            loadInsurDataGrid();
            #region updateHeaderText
            dgvInsurItem.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvInsurItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInsurItem.Columns["standcode"].HeaderText = "医保内码";
            dgvInsurItem.Columns["standcode"].DisplayIndex = 0;
            dgvInsurItem.Columns["standcode"].Width = 100;
            dgvInsurItem.Columns["insurcode"].HeaderText = "目录编码";
            dgvInsurItem.Columns["insurcode"].DisplayIndex = 1;
            dgvInsurItem.Columns["insurcode"].Width = 100;
            dgvInsurItem.Columns["name"].HeaderText = "目录名称";
            dgvInsurItem.Columns["name"].DisplayIndex = 2;
            dgvInsurItem.Columns["name"].Width = 150;
            dgvInsurItem.Columns["insurclass"].HeaderText = "项目等级";
            dgvInsurItem.Columns["insurclass"].DisplayIndex = 3;
            dgvInsurItem.Columns["insurclass"].Width = 90;
            dgvInsurItem.Columns["limitprc"].HeaderText = "最高限价";
            dgvInsurItem.Columns["limitprc"].DisplayIndex = 4;
            dgvInsurItem.Columns["limitprc"].Width = 90;
            dgvInsurItem.Columns["ratioihsp"].HeaderText = "自付比例";
            dgvInsurItem.Columns["ratioihsp"].DisplayIndex = 5;
            dgvInsurItem.Columns["ratioihsp"].Width = 90;
            dgvInsurItem.Columns["itemfrom"].HeaderText = "收费类别";
            dgvInsurItem.Columns["itemfrom"].DisplayIndex = 5;
            dgvInsurItem.Columns["itemfrom"].Width = 90;
            dgvInsurItem.Columns["limituse"].HeaderText = "限制信息";
            dgvInsurItem.Columns["limituse"].DisplayIndex = 5;
            dgvInsurItem.Columns["limituse"].Width = 90;
            dgvInsurItem.Columns["approve"].HeaderText = "审批状态";
            dgvInsurItem.Columns["approve"].DisplayIndex = 5;
            dgvInsurItem.Columns["approve"].Width = 90;
            #endregion
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void loadHisDataGrid()
        {
            string itemfrom = "";
            if (cbxDrug.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (cbxDiagnoCost.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (cbxStuff.Checked == true)
            {
                itemfrom = "STUFF";
            }
            dgvHisItem.DataSource = bllItemCrossHSDR.getHisItem(itemfrom, tbxName.Text.Trim());
        }
        private void loadInsurDataGrid()
        {
            string itemfrom = "";
            if (cbxDrug.Checked == true)
            {
                itemfrom = "'DRUG'";
            }
            else if (cbxDiagnoCost.Checked == true)
            {
                itemfrom = "'COST','BED'";
            }
            else if (cbxStuff.Checked == true)
            {
                itemfrom = "'STUFF'";
            }
            dgvInsurItem.DataSource = bllItemCrossHSDR.getInsurItem(itemfrom, tbxName.Text.Trim(), Insurtype_id);
        }
        private void tcItemCross_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tcItemCross.SelectedIndex == 0)
            {
                loadHisDataGrid();
            }
            else if (this.tcItemCross.SelectedIndex == 1)
            {
                loadInsurDataGrid();
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            FrmDownloadInsurItem frmDownloadInsurItem = new FrmDownloadInsurItem();
            frmDownloadInsurItem.Insurtype_id = this.insurtype_id;
            frmDownloadInsurItem.ShowDialog();
        }

        private void cbxDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDrug.Checked)
            {
                cbxDiagnoCost.Checked = false;
                cbxStuff.Checked = false;
            }
            loadHisDataGrid();
        }

        private void cbxDiagnoCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiagnoCost.Checked)
            {
                cbxStuff.Checked = false;
                cbxDrug.Checked = false;
            }
            loadHisDataGrid();
        }

        private void cbxStuff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxStuff.Checked)
            {
                cbxDiagnoCost.Checked = false;
                cbxDrug.Checked = false;
            }
            loadHisDataGrid();
        }

        private void cbxDrug0_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDrug0.Checked)
            {
                cbxDiagnoCost0.Checked = false;
                cbxStuff0.Checked = false;
            }
            loadInsurDataGrid();
        }

        private void cbxDiagnoCost0_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiagnoCost0.Checked)
            {
                cbxStuff0.Checked = false;
                cbxDrug0.Checked = false;
            }
            loadInsurDataGrid();
        }

        private void cbxStuff0_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxStuff0.Checked)
            {
                cbxDiagnoCost0.Checked = false;
                cbxDrug0.Checked = false;
            }
            loadInsurDataGrid();
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            loadHisDataGrid();
        }

        private void tbxName0_KeyDown(object sender, KeyEventArgs e)
        {
            loadInsurDataGrid();
        }



    }
}
