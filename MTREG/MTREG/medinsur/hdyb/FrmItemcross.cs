using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bll;
using MTREG.common;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmItemcross : Form
    {
        BllCostTransfer bllCostTransfer = new BllCostTransfer();
        public FrmItemcross()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string checkedbox = "";
            if (cbxCost.Checked)
            {
                checkedbox = BasItemFrom.COST.ToString();
            }
            if (cbxDrug.Checked)
            {
                checkedbox = BasItemFrom.DRUG.ToString();
            }
            if (cbxStuff.Checked)
            {
                checkedbox = BasItemFrom.STUFF.ToString();
            }
            DataTable dt= bllCostTransfer.crossSearch(checkedbox, tbxNameOrPincode.Text);
            dgvCross.DataSource = dt;

        }

        private void cbxCost_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxCost.Checked)
            {
                cbxDrug.Checked = false;
                cbxStuff.Checked = false;
            }            
        }

        private void FrmItemcross_Load(object sender, EventArgs e)
        {
            cbxCost.Checked = true;
            DataTable dt= bllCostTransfer.crossSearch(BasItemFrom.COST.ToString(), "");
            dgvCross.DataSource = dt;
            #region
            dgvCross.Columns["id"].HeaderText = "编码";
            dgvCross.Columns["standcode"].HeaderText = "医保内码";
            dgvCross.Columns["name"].HeaderText = "名称";
            dgvCross.Columns["spec"].HeaderText = "规格";
            dgvCross.Columns["unit"].HeaderText = "单位";
            dgvCross.Columns["city_prc"].HeaderText = "市单价";
            #endregion
        }

        private void dgvCross_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvCross.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                                          (e.RowIndex + 1).ToString(),
                                                          dgvCross.RowHeadersDefaultCellStyle.Font,
                                                          rectangle,
                                                          dgvCross.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 选中药品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDrug.Checked)
            {
                cbxCost.Checked = false;
                cbxStuff.Checked = false;
            }
        }
        /// <summary>
        /// 选中材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxStuff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxStuff.Checked)
            {
                cbxDrug.Checked = false;
                cbxCost.Checked = false;
            }
        }
    }
}
