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
    public partial class FrmDrugTypeHSDR : Form
    {
        public FrmDrugTypeHSDR()
        {
            InitializeComponent();
        }
        private bool valid = true;
        private string insurtype_id;
        /// <summary>
        /// 医保类型
        /// </summary>
        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }
        BllItemCrossHSDR bllItemCrossHSDR = new BllItemCrossHSDR();
        private void FrmDrugTypeHSDR_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            #region updateHeaderText
            dgvInsurDrugType.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvInsurDrugType.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInsurDrugType.Columns["id"].Visible = false;
            dgvInsurDrugType.Columns["itemtype_id"].Visible = false;
            dgvInsurDrugType.Columns["itemid"].HeaderText = "编码";
            dgvInsurDrugType.Columns["itemid"].Width = 70;
            dgvInsurDrugType.Columns["itemid"].DisplayIndex = 0;
            dgvInsurDrugType.Columns["itemname"].HeaderText = "名称";
            dgvInsurDrugType.Columns["itemname"].Visible = false;
            
            dgvInsurDrugType.Columns["insurname"].HeaderText = "医保名称";
            dgvInsurDrugType.Columns["insurname"].DisplayIndex = 2;
            dgvInsurDrugType.Columns["insurname"].Width = 180;
            dgvInsurDrugType.Columns["insurcode"].HeaderText = "医保编码";
            dgvInsurDrugType.Columns["insurcode"].Width = 180;
            dgvInsurDrugType.Columns["insurcode"].DisplayIndex = 3;
            if (!this.dgvInsurDrugType.Columns.Contains("itemname1"))
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                col.DataPropertyName = "itemtype_id";
                col.DataSource = bllItemCrossHSDR.itemtypeList();
                col.DisplayMember = "name";
                col.ValueMember = "id";
                col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                col.HeaderText = "项目分类名称";
                col.Width = 150;
                col.Name = "itemname1";
                this.dgvInsurDrugType.Columns.Add(col);
            }
            dgvInsurDrugType.Columns["itemname1"].DisplayIndex = 1;
            dgvInsurDrugType.ReadOnly = true;
            dgvInsurDrugType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        private void loadDataGrid()
        {
            dgvInsurDrugType.DataSource = bllItemCrossHSDR.getDrugcodeCross(Insurtype_id);
        }
        public void validTable()
        {
            for (int i = 0; i < this.dgvInsurDrugType.RowCount - 1; i++)
            {
                for (int j = i + 1; j < this.dgvInsurDrugType.RowCount; j++)
                {
                    string id1 = this.dgvInsurDrugType.Rows[i].Cells["id"].Value.ToString();
                    string id2 = this.dgvInsurDrugType.Rows[j].Cells["id"].Value.ToString();
                    string itemid1 = this.dgvInsurDrugType.Rows[i].Cells["itemid"].Value.ToString();
                    string itemid2 = this.dgvInsurDrugType.Rows[j].Cells["itemid"].Value.ToString();
                    string itemname1 = this.dgvInsurDrugType.Rows[i].Cells["itemname1"].Value.ToString();
                    string itemname2 = this.dgvInsurDrugType.Rows[j].Cells["itemname1"].Value.ToString();
                    string insurname1 = this.dgvInsurDrugType.Rows[i].Cells["insurname"].Value.ToString();
                    string insurname2 = this.dgvInsurDrugType.Rows[j].Cells["insurname"].Value.ToString();
                    string insurcode1 = this.dgvInsurDrugType.Rows[i].Cells["insurcode"].Value.ToString();
                    string insurcode2 = this.dgvInsurDrugType.Rows[i].Cells["insurcode"].Value.ToString();
                    if (id1 == null || id2 == null || "".Equals(id1) || "".Equals(id2))
                    {
                        MessageBox.Show("编号不能为空！");
                        valid = false;
                        return;
                    }
                    if (itemid1 == null || itemid2 == null || "".Equals(itemid1) || "".Equals(itemid2))
                    {
                        MessageBox.Show("医院项目编号不能为空！");
                        valid = false;
                        return;
                    }
                    if (itemname1 == null || itemname2 == null || "".Equals(itemname1) || "".Equals(itemname2))
                    {
                        MessageBox.Show("项目分类名称不能为空！");
                        valid = false;
                        return;
                    }
                    if (insurname1 == null || insurname2 == null || "".Equals(insurname1) || "".Equals(insurname2))
                    {
                        MessageBox.Show("医保名称不能为空！");
                        valid = false;
                        return;
                    }
                    if (insurcode1 == null || insurcode2 == null || "".Equals(insurcode1) || "".Equals(insurcode2))
                    {
                        MessageBox.Show("医保编码不能为空！");
                        valid = false;
                        return;
                    }
                    if(itemid1.Equals(itemid2) && itemname1.Equals(itemname2) && insurname1.Equals(insurname2) && insurcode1.Equals(insurcode2))
                    {
                        MessageBox.Show("' " + itemname1 + " '    重复！不能保存！");
                        valid = false;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            validTable();
            if (!valid)
            {
                valid = true;
                return;
            }
            int flag = bllItemCrossHSDR.updateItemfrom((DataTable)this.dgvInsurDrugType.DataSource,Insurtype_id);
            if (flag == -1)
            {
                MessageBox.Show("添加失败！");
            }
            MessageBox.Show("添加成功！");
            loadDataGrid();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            int flag = bllItemCrossHSDR.inDrugtype(Insurtype_id);
            if (flag < 0)
            {
                MessageBox.Show("导入失败！");
                return;
            }
            MessageBox.Show("导入成功！");
            loadDataGrid();
         }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvInsurDrugType.ReadOnly = false;
            dgvInsurDrugType.AllowUserToAddRows = true;
        }


    }
}
