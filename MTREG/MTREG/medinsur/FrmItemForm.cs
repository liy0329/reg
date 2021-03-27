using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.bll;

namespace MTREG.medinsur
{
    public partial class FrmItemForm : Form
    {
        BllInsurMethod bllInsurMethod = new BllInsurMethod();
        /// <summary>
        /// 正在编辑的单元格的内容
        /// </summary>
        private string value;
        /// <summary>
        /// 正在编辑的单元格的行号
        /// </summary>
        private int rowindex;
        /// <summary>
        /// 正在编辑的单元格的列号
        /// </summary>
        private int columnindex;
        private bool valid = true;
        public FrmItemForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmItemForm_Load(object sender, EventArgs e)
        {
            DataTable dtInsur= bllInsurMethod.insurtype();
            if (dtInsur.Rows.Count > 0)
            {
                cmbInsurItem.DisplayMember = "name";
                cmbInsurItem.ValueMember = "id";
                cmbInsurItem.DataSource = dtInsur;
            }

            this.btnCancel.Tag = "load";
            DataTable dt = bllInsurMethod.itemfromSelect(cmbInsurItem.SelectedValue.ToString());
            dgvItemfrom.DataSource = dt;
            dgvItemfrom.Columns["itemid"].HeaderText = "编码";
            dgvItemfrom.Columns["itemid"].Width = 130;
            dgvItemfrom.Columns["id"].HeaderText = "id";
            dgvItemfrom.Columns["id"].Visible = false;
            dgvItemfrom.Columns["itemtype_id"].HeaderText = "项目分类id";
            dgvItemfrom.Columns["itemtype_id"].Visible = false;
            dgvItemfrom.Columns["itemname"].HeaderText = "项目分类名称";
            dgvItemfrom.Columns["itemname"].Visible = false;
            dgvItemfrom.Columns["insurname"].HeaderText = "医保名称";
            dgvItemfrom.Columns["insurname"].Width = 150;
            dgvItemfrom.Columns["insurcode"].HeaderText = "医保编码";
            dgvItemfrom.Columns["insurcode"].Width = 130;
            if (!this.dgvItemfrom.Columns.Contains("itemname1"))
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                col.DataPropertyName = "itemtype_id";
                col.DataSource = bllInsurMethod.itemtypeList();
                col.DisplayMember = "name";
                col.ValueMember = "id";
                col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                col.HeaderText = "项目分类名称";
                col.Width = 150;
                col.Name = "itemname1";
                this.dgvItemfrom.Columns.Add(col);
            }
            dgvItemfrom.Columns["itemid"].DisplayIndex = 0;
            dgvItemfrom.Columns["itemname1"].DisplayIndex = 1;
            dgvItemfrom.Columns["insurname"].DisplayIndex = 2;
            dgvItemfrom.Columns["insurcode"].DisplayIndex = 3;
        }
        /// <summary>
        /// 判断名称是否为空或重复
        /// </summary>
        public void validTable()
        {

            for (int i = 0; i < this.dgvItemfrom.RowCount - 1; i++)
            {
                for (int j = i + 1; j < this.dgvItemfrom.RowCount; j++)
                {
                    string id1 = this.dgvItemfrom.Rows[i].Cells["id"].Value.ToString();
                    string id2 = this.dgvItemfrom.Rows[j].Cells["id"].Value.ToString();
                    string itemname1 = this.dgvItemfrom.Rows[i].Cells["itemname1"].Value.ToString();
                    string itemname2 = this.dgvItemfrom.Rows[j].Cells["itemname1"].Value.ToString();
                    string insurname1 = this.dgvItemfrom.Rows[i].Cells["insurname"].Value.ToString();
                    string insurname2 = this.dgvItemfrom.Rows[j].Cells["insurname"].Value.ToString();
                    string insurcode1 = this.dgvItemfrom.Rows[i].Cells["insurcode"].Value.ToString();
                    string insurcode2 = this.dgvItemfrom.Rows[j].Cells["insurcode"].Value.ToString();
                    if (id1 == null || id2 == null || "".Equals(id1) || "".Equals(id2))
                    {
                        MessageBox.Show("编号不能为空！");
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
                    if (id1.Equals(id2) && insurname1.Equals(insurname2) && itemname1.Equals(itemname2) && insurcode1.Equals(insurcode2))
                    {
                        MessageBox.Show("' " + itemname1 + " '重复！不能保存！");
                        valid = false;
                        return;
                    }

                }
            }
        }

        private void dgvItemfrom_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            value = this.dgvItemfrom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            rowindex = e.RowIndex;
            columnindex = e.ColumnIndex;
            this.btnCancel.Tag = "edit";
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!bllInsurMethod.isExist("insur_itemtype", cmbInsurItem.SelectedValue.ToString()))
            {
                MessageBox.Show("数据已经存在,不用再次导入!");
                return;
            }
            int flag = bllInsurMethod.inItemfrom(cmbInsurItem.SelectedValue.ToString());
            if (flag < 0)
            {
                MessageBox.Show("导入失败!");
                return;
            }
            MessageBox.Show("导入成功!!");
            DataTable dt = bllInsurMethod.itemfromSelect(cmbInsurItem.SelectedValue.ToString());
            this.dgvItemfrom.DataSource = dt;
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

            int flag = bllInsurMethod.itemfromIn((DataTable)this.dgvItemfrom.DataSource, cmbInsurItem.SelectedValue.ToString());
            this.btnCancel.Tag = "save";
            if (flag == -1)
            {
                MessageBox.Show("添加失败!");
                return;
            }
            MessageBox.Show("添加成功!");
            DataTable dt = bllInsurMethod.itemfromSelect(cmbInsurItem.SelectedValue.ToString());
            dgvItemfrom.DataSource = dt;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string tag = this.btnCancel.Tag.ToString();
            if ("load".Equals(tag) || "save".Equals(tag))
            {
                return;
            }
            if ("edit".Equals(tag))
            {
                this.dgvItemfrom.Rows[rowindex].Cells[columnindex].Value = value;
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataTable dt = bllInsurMethod.itemfromSelect(cmbInsurItem.SelectedValue.ToString());
            dgvItemfrom.DataSource = dt;
        }
    }
}
