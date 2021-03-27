using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdxbhnh.bll;
using System.Web.UI.WebControls;
using MTREG.common;
using MTREG.medinsur.hdxbhnh.bo;

namespace MTREG.medinsur.hdxbhnh
{
    public partial class FrmItemcrossXBH : Form
    {
        public FrmItemcrossXBH()
        {
            InitializeComponent();
        }
        BllItemcrossXBH bllItemcross = new BllItemcrossXBH();
        private void FrmItemcross_Load(object sender, EventArgs e)
        {
            cbxDrug.Checked = true;
            dgvDrugItem.Visible = false;
            dgvCostItem.Visible = false;
            dgvStuffItem.Visible = false;
            lblCrossId3.Visible = false;
            lblCrossId1.Visible = false;
            lblCrossId2.Visible = false;
            btnCross.Enabled = false;
            btnCancelCross.Enabled = false;
        }
        /// <summary>
        /// 对照按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCross_Click(object sender, EventArgs e)
        {
            CostInsurcross costInsurcross = new CostInsurcross();
            costInsurcross.Id = BillSysBase.nextId("cost_insurcross");
            costInsurcross.Item_id = dgvItemInfo.CurrentRow.Cells["id"].Value.ToString();
            costInsurcross.Itemfrom = dgvItemInfo.CurrentRow.Cells["itemfrom"].Value.ToString();
            string cost_insurtype_id = bllItemcross.getInsurTypeId();
            costInsurcross.Cost_insurtype_id = cost_insurtype_id;
             if (tctItemType.SelectedTab == tpgDrug)
            {     
                costInsurcross.Cost_insuritem_id = lblCrossId1.Text.Trim();
                costInsurcross.Drug_factyitem_id = "";
             }
             else if(tctItemType.SelectedTab == tpgCost)
             {             
                costInsurcross.Cost_insuritem_id = lblCrossId2.Text.Trim();
                costInsurcross.Drug_factyitem_id = "";
             }
             else if(tctItemType.SelectedTab == tpgStuff)
             {
                costInsurcross.Cost_insuritem_id = lblCrossId3.Text.Trim();
                costInsurcross.Drug_factyitem_id = "";
             }
            int value = bllItemcross.itemCross(costInsurcross);
            if (value == 0)
            {
                MessageBox.Show("操作成功！");
                if (tctItemType.SelectedTab == tpgDrug)
                {
                    lblCrossId1.Text = costInsurcross.Id;
                }
                else if (tctItemType.SelectedTab == tpgCost)
                {
                    lblCrossId2.Text = costInsurcross.Id;
                }
                else if (tctItemType.SelectedTab == tpgStuff)
                {
                    lblCrossId3.Text = costInsurcross.Id;
                }
            }
            else if (value == -1)
            {
                MessageBox.Show("操作失败！");
            }
            dgvDrugItem.Visible = false;
            dgvCostItem.Visible = false;
            dgvStuffItem.Visible = false;
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                getDgvItem();
            }
            if (e.KeyData == Keys.Enter && dgvItemInfo.Rows.Count > 0)
            {
                dgvItemInfo.Rows[0].Selected = true;
                dgvItemInfo.Focus();
            } 
        }
        private void getDgvItem()
        {
            string itemfrom = "";
            string isCross = "";
            if (cbxDrug.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (cbxDiagnoseCost.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (cbxStuff.Checked == true)
            {
                itemfrom = "STUFF";
            }
            if (cbxIsCross.Checked == true)
                isCross = "0";
            else
                isCross = "-1";
            dgvItemInfo.Columns.Clear();
            dgvItemInfo.DataSource = bllItemcross.getItemInfo(tbxName.Text.Trim(), itemfrom, isCross);
            #region updateHeaderText
            dgvItemInfo.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            dgvItemInfo.Columns["id"].HeaderText = "编码";
            dgvItemInfo.Columns["id"].DisplayIndex = 0;
            dgvItemInfo.Columns["standcode"].HeaderText = "医保内码";
            dgvItemInfo.Columns["standcode"].DisplayIndex = 1;
            dgvItemInfo.Columns["standcode"].Width = 100;
            dgvItemInfo.Columns["name"].HeaderText = "名称";
            dgvItemInfo.Columns["name"].Width = 100;
            dgvItemInfo.Columns["name"].DisplayIndex = 2;
            dgvItemInfo.Columns["unit"].HeaderText = "规格";
            dgvItemInfo.Columns["unit"].Width = 100;
            dgvItemInfo.Columns["unit"].DisplayIndex = 3;
            dgvItemInfo.Columns["spec"].HeaderText = "单位";
            dgvItemInfo.Columns["spec"].Width = 100;
            dgvItemInfo.Columns["spec"].DisplayIndex = 4;
            dgvItemInfo.Columns["itemfrom"].Visible = false;
            dgvItemInfo.ReadOnly = true;
            dgvItemInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItemInfo.MultiSelect = false;
            if (dgvItemInfo.Rows.Count > 0)
            {
                dgvItemInfo.Rows[0].Selected = true;
            }
            #endregion
           
        }

        private void dgvItemInfo_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvItemInfo.CurrentRow != null)
            {
                string item_id = dgvItemInfo.CurrentRow.Cells["id"].Value.ToString();
                string itemfrom = dgvItemInfo.CurrentRow.Cells["itemfrom"].Value.ToString();
                if (bllItemcross.ischeck(item_id))
                {
                    DataTable dt = bllItemcross.getInsurItemFromCross(item_id);
                    if (cbxDrug.Checked == true)
                    {
                        tctItemType.SelectedTab = tpgDrug;
                        lblCrossId1.Text = dt.Rows[0]["id"].ToString();
                        tbxName1.Text = dt.Rows[0]["name"].ToString();
                        tbxCode1.Text = dt.Rows[0]["insurcode"].ToString();
                        tbxAlias1.Text = dt.Rows[0]["name2"].ToString();
                        tbxUnit1.Text = dt.Rows[0]["unit"].ToString();
                        //        tbxForms1.Text = dt.Rows[0][""].ToString();
                    }
                    else if (cbxDiagnoseCost.Checked == true)
                    {
                        tctItemType.SelectedTab = tpgCost;
                        lblCrossId2.Text = dt.Rows[0]["id"].ToString();
                        tbxName2.Text = dt.Rows[0]["name"].ToString();
                        tbxCode2.Text = dt.Rows[0]["insurcode"].ToString();
                        tbxUnit2.Text = dt.Rows[0]["unit"].ToString();
                    }
                    else if (cbxStuff.Checked == true)
                    {
                        tctItemType.SelectedTab = tpgStuff;
                        lblCrossId3.Text = dt.Rows[0]["id"].ToString();
                        tbxName3.Text = dt.Rows[0]["name"].ToString();
                        tbxCode3.Text = dt.Rows[0]["insurcode"].ToString();
                        tbxSpec3.Text = dt.Rows[0]["spec"].ToString();
                        tbxUnit3.Text = dt.Rows[0]["unit"].ToString();
                    }
                }
                else
                {
                    clear();
                }
            }
            dgvDrugItem.Visible = false;
            dgvCostItem.Visible = false;
            dgvStuffItem.Visible = false;
        }

        private void tbxName1_TextChanged(object sender, EventArgs e)
        {
            dgvDrugItem.Visible = true;
            dgvDrugItem.DataSource = bllItemcross.getInsurInfo(tbxName1.Text.Trim(),"DRUG");
            btnCancelCross.Enabled = false;
            btnCross.Enabled = false;
            #region updateHeaderText
            dgvDrugItem.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            dgvDrugItem.Columns["id"].Visible = false;
            dgvDrugItem.Columns["name"].HeaderText = "名称";
            dgvDrugItem.Columns["name"].Width = 150;
            dgvDrugItem.Columns["name"].DisplayIndex = 2;
            dgvDrugItem.Columns["insurcode"].HeaderText = "农合编码";
            dgvDrugItem.Columns["insurcode"].DisplayIndex = 1;
            dgvDrugItem.Columns["insurcode"].Width = 160;
            dgvDrugItem.Columns["unit"].HeaderText = "规格";
            dgvDrugItem.Columns["unit"].Width = 120;
            dgvDrugItem.Columns["unit"].DisplayIndex = 3;
            dgvDrugItem.Columns["spec"].HeaderText = "单位";
            dgvDrugItem.Columns["spec"].Width = 100;
            dgvDrugItem.Columns["spec"].DisplayIndex = 4;
            dgvDrugItem.Columns["itemfrom"].Visible = false;
            dgvDrugItem.Columns["name2"].Visible = false;
            dgvDrugItem.ReadOnly = true;
            dgvDrugItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrugItem.MultiSelect = false;
            if (dgvDrugItem.Rows.Count > 0)
            {
                dgvDrugItem.Rows[0].Selected = true;
            }
            #endregion
        }
        private void dgvDrugItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDrugItem.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvDrugItem.CurrentRow != null)
                {
                    if (tctItemType.SelectedTab == tpgDrug)
                    {
                        tctItemType.SelectedTab = tpgDrug;
                        lblCrossId1.Text = dgvDrugItem.CurrentRow.Cells["id"].Value.ToString();
                        tbxName1.Text = dgvDrugItem.CurrentRow.Cells["name"].Value.ToString();
                        if(!dgvDrugItem.CurrentRow.Cells["insurcode"].Value.Equals(null))
                        {
                           tbxCode1.Text = dgvDrugItem.CurrentRow.Cells["insurcode"].Value.ToString();
                        }
                        if (!dgvDrugItem.CurrentRow.Cells["name2"].Value.Equals(null))
                        {
                            tbxAlias1.Text = dgvDrugItem.CurrentRow.Cells["name2"].Value.ToString();
                        }
                        if (!dgvDrugItem.CurrentRow.Cells["unit"].Value.Equals(null))
                        {
                            tbxUnit1.Text = dgvDrugItem.CurrentRow.Cells["unit"].Value.ToString();
                        }
                        //        tbxForms1.Text = dgvInsurItem.CurrentRow.Cells[""].Value.ToString();
                    }
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                    dgvDrugItem.Visible = false;
                    dgvDrugItem.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvDrugItem.CurrentRow != null && dgvDrugItem.CurrentRow.Index > 0)
                {
                    dgvDrugItem.Rows[dgvDrugItem.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvDrugItem.CurrentRow != null && dgvDrugItem.CurrentRow.Index < dgvDrugItem.Rows.Count - 1)
                {
                    dgvDrugItem.Rows[dgvDrugItem.CurrentRow.Index + 1].Selected = true;
                }
            }
            else
            {
                if (e.KeyData == Keys.Enter)
                {
                    dgvDrugItem.Visible = false;
                    dgvDrugItem.Columns.Clear();
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                }
            }
        }

        private void tbxName2_TextChanged(object sender, EventArgs e)
        {
            dgvCostItem.Visible = true;
            dgvCostItem.DataSource = bllItemcross.getInsurInfo(tbxName1.Text.Trim(),"COST");
            #region updateHeaderText
            dgvCostItem.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            dgvCostItem.Columns["id"].Visible = false;
            dgvCostItem.Columns["name"].HeaderText = "名称";
            dgvCostItem.Columns["name"].Width = 120;
            dgvCostItem.Columns["name"].DisplayIndex = 2;
            dgvCostItem.Columns["insurcode"].HeaderText = "农合编码";
            dgvCostItem.Columns["insurcode"].DisplayIndex = 1;
            dgvCostItem.Columns["insurcode"].Width = 130;
            dgvCostItem.Columns["unit"].HeaderText = "规格";
            dgvCostItem.Columns["unit"].Width = 120;
            dgvCostItem.Columns["unit"].DisplayIndex = 3;
            dgvCostItem.Columns["spec"].HeaderText = "单位";
            dgvCostItem.Columns["spec"].Width = 100;
            dgvCostItem.Columns["spec"].DisplayIndex = 4;
            dgvCostItem.Columns["itemfrom"].Visible = false;
            dgvCostItem.Columns["name2"].Visible = false;
            dgvCostItem.ReadOnly = true;
            dgvCostItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCostItem.MultiSelect = false;
            if (dgvCostItem.Rows.Count > 0)
            {
                dgvCostItem.Rows[0].Selected = true;
            }
            #endregion
        }

        private void tbxName3_TextChanged(object sender, EventArgs e)
        {
            dgvStuffItem.Visible = true;
            dgvStuffItem.DataSource = bllItemcross.getInsurInfo(tbxName1.Text.Trim(),"STUFF");
            btnCancelCross.Enabled = false;
            btnCross.Enabled = false;
            btnCancelCross.Enabled = false;
            btnCross.Enabled = false;
            #region updateHeaderText
            dgvStuffItem.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            dgvStuffItem.Columns["id"].Visible = false;
            dgvStuffItem.Columns["name"].HeaderText = "名称";
            dgvStuffItem.Columns["name"].Width = 120;
            dgvStuffItem.Columns["name"].DisplayIndex = 2;
            dgvStuffItem.Columns["insurcode"].HeaderText = "农合编码";
            dgvStuffItem.Columns["insurcode"].DisplayIndex = 1;
            dgvStuffItem.Columns["insurcode"].Width = 130;
            dgvStuffItem.Columns["unit"].HeaderText = "规格";
            dgvStuffItem.Columns["unit"].Width = 120;
            dgvStuffItem.Columns["unit"].DisplayIndex = 3;
            dgvStuffItem.Columns["spec"].HeaderText = "单位";
            dgvStuffItem.Columns["spec"].Width = 100;
            dgvStuffItem.Columns["spec"].DisplayIndex = 4;
            dgvStuffItem.Columns["itemfrom"].Visible = false;
            dgvStuffItem.Columns["name2"].Visible = false;
            dgvStuffItem.ReadOnly = true;
            dgvStuffItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStuffItem.MultiSelect = false;
            if (dgvStuffItem.Rows.Count > 0)
            {
                dgvStuffItem.Rows[0].Selected = true;
            }
            #endregion
        }

        private void btnCancelCross_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (tctItemType.SelectedTab == tpgDrug)
            {
                result = bllItemcross.itemCrossCancel(lblCrossId1.Text.Trim());
            }
            else if(tctItemType.SelectedTab == tpgCost)
            {
                result = bllItemcross.itemCrossCancel(lblCrossId2.Text.Trim());
            }
            else if(tctItemType.SelectedTab == tpgStuff)
            {
                result = bllItemcross.itemCrossCancel(lblCrossId3.Text.Trim());
            }
            if (result == 0)
            {
                MessageBox.Show("操作成功！");
                clear();
            }
            else if (result == -1)
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void cbxDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDrug.Checked == true)
            {
                cbxDiagnoseCost.Checked = false;
                cbxStuff.Checked = false;
                if (tbxName.Text != "")
                {
                    getDgvItem();
                }
            }
        }

        private void cbxDiagnoseCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiagnoseCost.Checked == true)
            {
                cbxDrug.Checked = false;
                cbxStuff.Checked = false;
                if (tbxName.Text != "")
                {
                    getDgvItem();
                }
            }
        }

        private void cbxStuff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxStuff.Checked == true)
            {
                cbxDrug.Checked = false;
                cbxDiagnoseCost.Checked = false;
                if (tbxName.Text != "")
                {
                    getDgvItem();
                }
            }
        }

        private void tbxName1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvDrugItem.Rows.Count > 0)
            {
                dgvDrugItem.Rows[0].Selected = true;
                dgvDrugItem.Focus();
            }
            else if (e.KeyData == Keys.Enter && dgvDrugItem.Rows.Count == 0)
            {
                dgvDrugItem.Visible = false;
                tbxName1.Text = "";
            }
        }

        private void tbxName2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvCostItem.Rows.Count > 0)
            {
                dgvCostItem.Rows[0].Selected = true;
                dgvCostItem.Focus();
            }
            else if (e.KeyData == Keys.Enter && dgvCostItem.Rows.Count == 0)
            {
                dgvCostItem.Visible = false;
                tbxName2.Text = "";
            }
        }

        private void tbxName3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && dgvStuffItem.Rows.Count > 0)
            {
                dgvStuffItem.Rows[0].Selected = true;
                dgvStuffItem.Focus();
            }
            else if (e.KeyData == Keys.Enter && dgvStuffItem.Rows.Count == 0)
            {
                dgvCostItem.Visible = false;
                tbxName3.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            if (tctItemType.SelectedTab == tpgDrug)
            {
                tctItemType.SelectedTab = tpgDrug;
                tbxName1.Text = "";
                tbxCode1.Text = "";
                tbxAlias1.Text = "";
                tbxUnit1.Text = "";
                //        tbxForms1.Text = dgvInsurItem.CurrentRow.Cells[""].ToString();
            }
            else if (tctItemType.SelectedTab == tpgCost)
            {
                tctItemType.SelectedTab = tpgCost;
                tbxName2.Text = "";
                tbxCode2.Text = "";
                tbxUnit2.Text = "";
            }
            else if (tctItemType.SelectedTab == tpgStuff)
            {
                tctItemType.SelectedTab = tpgStuff;
                tbxName3.Text = "";
                tbxCode3.Text = "";
                tbxSpec3.Text = "";
                tbxUnit3.Text = "";
            }
            dgvDrugItem.Visible = false;
            dgvCostItem.Visible = false;
            dgvStuffItem.Visible = false;
        }

        private void dgvCostItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvCostItem.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvCostItem.CurrentRow != null)
                {
                    if (tctItemType.SelectedTab == tpgCost)
                    {
                        tctItemType.SelectedTab = tpgCost;
                        lblCrossId2.Text = dgvCostItem.CurrentRow.Cells["id"].Value.ToString();
                        tbxName2.Text = dgvCostItem.CurrentRow.Cells["name"].Value.ToString();
                        if (!dgvCostItem.CurrentRow.Cells["insurcode"].Value.Equals(null))
                        {
                            tbxCode2.Text = dgvCostItem.CurrentRow.Cells["insurcode"].Value.ToString();
                        }
                        if (!dgvCostItem.CurrentRow.Cells["unit"].Value.Equals(null))
                        {
                            tbxUnit2.Text = dgvCostItem.CurrentRow.Cells["unit"].Value.ToString();
                        }
                    }
                    dgvCostItem.Visible = false;
                    dgvCostItem.Columns.Clear();
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                }
                else if (e.KeyData == Keys.Down && dgvCostItem.CurrentRow != null && dgvCostItem.CurrentRow.Index > 0)
                {
                    dgvCostItem.Rows[dgvCostItem.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvCostItem.CurrentRow != null && dgvCostItem.CurrentRow.Index < dgvCostItem.Rows.Count - 1)
                {
                    dgvCostItem.Rows[dgvCostItem.CurrentRow.Index + 1].Selected = true;
                }
            }
            else
            {
                if (e.KeyData == Keys.Enter)
                {
                    dgvCostItem.Visible = false;
                    dgvCostItem.Columns.Clear();
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                }
            }
        }

        private void dgvStuffItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvStuffItem.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvStuffItem.CurrentRow != null)
                { 
                    if (tctItemType.SelectedTab == tpgStuff)
                    {
                        tctItemType.SelectedTab = tpgStuff;
                        lblCrossId3.Text = dgvStuffItem.CurrentRow.Cells["id"].Value.ToString();
                        tbxName3.Text = dgvStuffItem.CurrentRow.Cells["name"].Value.ToString();
                        if (!dgvStuffItem.CurrentRow.Cells["insurcode"].Value.Equals(null))
                        {
                            tbxCode3.Text = dgvStuffItem.CurrentRow.Cells["insurcode"].Value.ToString();
                        }
                        if (!dgvStuffItem.CurrentRow.Cells["spec"].Value.Equals(null))
                        {
                            tbxSpec3.Text = dgvStuffItem.CurrentRow.Cells["spec"].Value.ToString();
                        }
                        if (!dgvStuffItem.CurrentRow.Cells["unit"].Value.Equals(null))
                        {
                            tbxUnit3.Text = dgvStuffItem.CurrentRow.Cells["unit"].Value.ToString();
                        }
                    }
                    dgvStuffItem.Visible = false;
                    dgvStuffItem.Columns.Clear();
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                }
                else if (e.KeyData == Keys.Down && dgvStuffItem.CurrentRow != null && dgvStuffItem.CurrentRow.Index > 0)
                {
                    dgvStuffItem.Rows[dgvStuffItem.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvStuffItem.CurrentRow != null && dgvStuffItem.CurrentRow.Index < dgvCostItem.Rows.Count - 1)
                {
                    dgvStuffItem.Rows[dgvStuffItem.CurrentRow.Index + 1].Selected = true;
                }
            }
            else
            {
                if (e.KeyData == Keys.Enter)
                {
                    dgvStuffItem.Visible = false;
                    dgvStuffItem.Columns.Clear();
                    btnCancelCross.Enabled = true;
                    btnCross.Enabled = true;
                }
            }
        }

        private void tctItemType_Selected(object sender, TabControlEventArgs e)
        {
            if (tctItemType.SelectedIndex == 0 && tbxName1.Text.Trim() == "")
            {
                btnCross.Enabled = false;
                btnCancelCross.Enabled = false;
            }
            else if (tctItemType.SelectedIndex == 1 && tbxName2.Text.Trim() == "")
            {
                btnCancelCross.Enabled = false;
                btnCross.Enabled = false;
            }
            else if (tctItemType.SelectedIndex == 2 && tbxName3.Text.Trim() == "")
            {
                btnCancelCross.Enabled = false;
                btnCross.Enabled = false;
            }
            else
            {
                btnCancelCross.Enabled = true;
                btnCross.Enabled = true;
            }
            return;
        }
    }
}
