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
    public partial class FrmDrugtype : Form
    {
        BllInsurCross bllInsurCross = new BllInsurCross();
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
        /// <summary>
        /// 新添加一行的行号
        /// </summary>
        private int newRowIndex;
        private bool valid=true;
        public FrmDrugtype()
        {
            InitializeComponent();
        }
        private string insurtype_id;

        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDrugtype_Load(object sender, EventArgs e)
        {
            this.btnCancel.Tag = "load";
            DataTable dt = bllInsurCross.drugSelect(Insurtype_id);
            dgvDrugtype.DataSource = dt;
            dgvDrugtype.Columns["itemid"].HeaderText = "编码";
            dgvDrugtype.Columns["itemid"].Width = 130;
            dgvDrugtype.Columns["id"].HeaderText = "id";
            dgvDrugtype.Columns["id"].Visible = false;
            dgvDrugtype.Columns["itemtype_id"].HeaderText = "项目分类名称";
            dgvDrugtype.Columns["itemtype_id"].Visible = false;
            dgvDrugtype.Columns["itemname"].HeaderText = "项目分类名称";
            dgvDrugtype.Columns["itemname"].Visible = false;
            dgvDrugtype.Columns["insurname"].HeaderText = "医保名称";
            dgvDrugtype.Columns["insurname"].Width = 150;
            dgvDrugtype.Columns["insurcode"].HeaderText = "医保编码";
            dgvDrugtype.Columns["insurcode"].Width = 130;
            if (!this.dgvDrugtype.Columns.Contains("itemname1"))
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                col.DataPropertyName = "itemtype_id";
                col.DataSource = bllInsurCross.itemtypeList();
                col.DisplayMember = "name";
                col.ValueMember = "id";
                col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                col.HeaderText = "项目分类名称";
                col.Width = 150;
                col.Name = "itemname1";
                this.dgvDrugtype.Columns.Add(col);
            }
            dgvDrugtype.Columns["itemid"].DisplayIndex = 0;
            dgvDrugtype.Columns["itemname1"].DisplayIndex = 1;
            dgvDrugtype.Columns["insurname"].DisplayIndex = 2;
            dgvDrugtype.Columns["insurcode"].DisplayIndex = 3;
        }

        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //    DataTable dataTable = (DataTable)this.dgvDrugtype.DataSource;
        //    dataTable.Rows.Add();
        //    // add ytc  新增一行 焦点到新增的行上
        //    this.dgvDrugtype.CurrentCell = this.dgvDrugtype.Rows[this.dgvDrugtype.Rows.Count - 1].Cells["id"];
        //    int nextVal = 1;
        //    if (this.dgvDrugtype.RowCount > 1)
        //    {                            
        //        nextVal = int.Parse(this.dgvDrugtype["id", this.dgvDrugtype.RowCount - 2].Value.ToString()) + 1;
        //    }
        //    this.dgvDrugtype["id", this.dgvDrugtype.RowCount - 1].Value = nextVal.ToString();
        //    this.dgvDrugtype["insurcode", this.dgvDrugtype.RowCount - 1].Value = Insurtype_id;
        //    this.dgvDrugtype["id", this.dgvDrugtype.RowCount - 1].ReadOnly = true;
        //}

        /// <summary>
        /// 判断名称是否为空或重复
        /// </summary>
        public void validTable()
        {
            for (int i = 0; i < this.dgvDrugtype.RowCount - 1; i++)
            {
                for (int j = i + 1; j < this.dgvDrugtype.RowCount; j++)
                {
                    string id1 = this.dgvDrugtype.Rows[i].Cells["id"].Value.ToString();
                    string id2 = this.dgvDrugtype.Rows[j].Cells["id"].Value.ToString();
                    string itemname1 = this.dgvDrugtype.Rows[i].Cells["itemname1"].Value.ToString();
                    string itemname2 = this.dgvDrugtype.Rows[j].Cells["itemname1"].Value.ToString();
                    string insurname1 = this.dgvDrugtype.Rows[i].Cells["insurname"].Value.ToString();
                    string insurname2 = this.dgvDrugtype.Rows[j].Cells["insurname"].Value.ToString();
                    string insurtcode1 = this.dgvDrugtype.Rows[i].Cells["insurcode"].Value.ToString();
                    string insurtcode2 = this.dgvDrugtype.Rows[j].Cells["insurcode"].Value.ToString();
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
                    if (insurtcode1 == null || insurtcode2 == null || "".Equals(insurtcode1) || "".Equals(insurtcode2))
                    {
                        MessageBox.Show("医保编码不能为空！");
                        valid = false;
                        return;
                    }
                    if (id1.Equals(id2) && insurname1.Equals(insurname2) && itemname1.Equals(itemname2) && insurtcode1.Equals(insurtcode2))
                    {
                        MessageBox.Show("' " + itemname1 + " '重复！不能保存！");
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
            int flag = bllInsurCross.drugIn((DataTable)this.dgvDrugtype.DataSource, Insurtype_id);
            this.btnCancel.Tag = "save";
            if (flag == -1)
            {
                MessageBox.Show("添加失败!");
                return;
            }
            MessageBox.Show("添加成功!");
            DataTable dt = bllInsurCross.drugSelect(Insurtype_id);
            dgvDrugtype.DataSource = dt;
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
            if ("add".Equals(tag))
            {
                if (newRowIndex == 1 || newRowIndex == this.dgvDrugtype.RowCount)
                {
                    return;
                }
                DataTable dd = (DataTable)this.dgvDrugtype.DataSource;
                dd.Rows.RemoveAt(newRowIndex);
                return;
            }
            if ("edit".Equals(tag))
            {
                if (rowindex == newRowIndex && (int)this.dgvDrugtype.Rows[newRowIndex].Tag == 0)
                {
                    DataTable dd = (DataTable)this.dgvDrugtype.DataSource;
                    dd.Rows.RemoveAt(newRowIndex);
                    newRowIndex--;
                    rowindex--;
                    btnCancel.Tag = "load";
                    return;
                }
                else
                {
                    this.dgvDrugtype.Rows[rowindex].Cells[columnindex].Value = value;
                }
            }
        }

        /// <summary>
        /// 单元格验证时,判定值的格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dgvDrugtype_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (this.dgvDrugtype.CurrentCell.OwningColumn.Name == "ordersn" || this.dgvDrugtype.CurrentCell.OwningColumn.Name == "sn")
        //    {
        //        var res = 0;
        //        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
        //        {
        //            var flag = int.TryParse(e.FormattedValue.ToString(), out res);
        //            if (!flag)
        //            {
        //                MessageBox.Show("请输入数字");
        //                e.Cancel = true;
        //                this.dgvDrugtype.CancelEdit();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 增加一行时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugtype_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.btnCancel.Tag = "add";
            newRowIndex = e.RowIndex;
            this.dgvDrugtype.Rows[newRowIndex].Tag = 0;
            
        }

        /// <summary>
        /// 单元格开始编辑时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugtype_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            value = this.dgvDrugtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            rowindex = e.RowIndex;
            columnindex = e.ColumnIndex;
            if (newRowIndex != this.dgvDrugtype.RowCount && "add".Equals(this.btnCancel.Tag.ToString()) && newRowIndex != rowindex)
            {
                this.dgvDrugtype.Rows[newRowIndex].Tag = 1;
            }
            this.btnCancel.Tag = "edit";
        }

        /// <summary>
        /// 编辑结束时 添加对应数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugtype_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgvDrugtype["id", e.RowIndex].Value = BillSysBase.nextId("insur_drugtype");
            //this.dgvDrugtype["insurcode", e.RowIndex].Value = Insurtype_id;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("确定要删除这条记录吗？", "提示信息", MessageBoxButtons.OKCancel);
        //    if (result == System.Windows.Forms.DialogResult.Cancel)
        //    {
        //        return;
        //    }

        //    if (this.dgvDrugtype.SelectedCells.Count > 0)
        //    {
        //        int flag=bllInsurCross.drugDel(this.dgvDrugtype.SelectedCells[0].OwningRow.Cells["id"].Value.ToString());
        //        if (flag < 0)
        //        {
        //            MessageBox.Show("删除失败!");
        //            return;
        //        }
        //    }
        //    DataTable dt = bllInsurCross.drugSelect(Insurtype_id);
        //    dgvDrugtype.DataSource = dt;
        //}

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIn_Click(object sender, EventArgs e)
        {
            int flag = bllInsurCross.inDrugtype(Insurtype_id);
            if (flag < 0)
            {
                MessageBox.Show("导入失败!");
                return;
            }
            MessageBox.Show("导入成功!!");
            DataTable dt = bllInsurCross.drugSelect(Insurtype_id);
           
        }
    }
}
