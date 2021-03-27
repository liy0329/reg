using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;

namespace MTREG.ihsp
{
    public partial class FrmDiagn : Form
    {
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        string icdCode;
        BillCmbList billCmbList = new BillCmbList();
        FrmIhspReg frmIhspReg;
        /// <summary>
        /// 住院登记
        /// </summary>
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }

        public FrmDiagn()
        {
            InitializeComponent();
        }

        private void tbxDiagn_TextChanged(object sender, EventArgs e)
        {
            lbxDiagn.Visible = true;
            DataTable dt = billCmbList.regCase(tbxDiagn.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxDiagn.ValueMember = "icd10";
                this.lbxDiagn.DisplayMember = "name";
                lbxDiagn.DataSource = dt;
            }
        }

        private void tbxDiagn_KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxDiagn.Focus();
                if (lbxDiagn.Items.Count >= 2)
                {
                    lbxDiagn.SelectedIndex = 0;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lbxDiagn.Visible)
                {
                    if (lbxDiagn.Items.Count >= 2)
                    {
                        lbxDiagn.SelectedIndex = 0;
                    }
                    //icdCode = lbxDiagn.SelectedValue.ToString();
                    //tbxDiagn.Text = lbxDiagn.Text.ToString();
                    //lbxDiagn.Visible = false;
                }
              
            }
        }

        private void tbxDiagn_Enter(object sender, EventArgs e)
        {
            if (lbxDiagn.DataSource != null)
            {
                lbxDiagn.Visible = true;
                tbxDiagn.SelectAll();
            }
        }
        private void tbxDiagn_MouseDown(object sender, MouseEventArgs e)
        {
            //if (lbxDiagn.DataSource != null)
            //{
            //    tbxDiagn.SelectAll();
            //}
            tbxDiagn.Text = "";
            DataTable dt = billCmbList.regCase(tbxDiagn.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                lbxDiagn.Visible = true;
                this.lbxDiagn.ValueMember = "icd10";
                this.lbxDiagn.DisplayMember = "name";
                lbxDiagn.DataSource = dt;
            }
        }
        private void lbxDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxDiagn.SelectedIndex == 1)
                {
                    tbxDiagn.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxDiagn.SelectedItem;
                tbxDiagn.Text = drv.Row["name"].ToString();
                icdCode = drv.Row["icd10"].ToString(); ;//获取value值后index变为0,所以放在后面                
                tbxDiagn.Focus();
                lbxDiagn.Visible = false;
            }
        }
        private void tbxDiagn_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxDiagn.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }
        private void lbxDiagn_Leave(object sender, EventArgs e)
        {
            lbxDiagn.Visible = false;
        }

        private void lbxDiagn_MouseDown(object sender, MouseEventArgs e)
        {
            lbxDiagn.Visible = true;
            DataRowView drv = (DataRowView)lbxDiagn.SelectedItem;
            tbxDiagn.Text = drv.DataView[lbxDiagn.SelectedIndex]["name"].ToString();
            icdCode = lbxDiagn.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
            tbxDiagn.Focus();
            lbxDiagn.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvDiagn.Rows.Add();
            dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["icdname"].Value = tbxDiagn.Text.Trim();
            dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["icd"].Value = icdCode;
            dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["delete"].Value = "删除";
            tbxDiagn.Clear();
            lbxDiagn.Visible = false;
            icdCode = "";
        }

        private void dgvDiagn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvDiagn.Columns[dgvDiagn.CurrentCell.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    dgvDiagn.Rows.Remove(dgvDiagn.CurrentRow);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            okMethod();
        }
        /// <summary>
        /// 确定方法
        /// </summary>
        private void okMethod()
        {
            frmIhspReg.ClininDiagnName = "";
            frmIhspReg.ClininDiagnICD = "";
            for (int i = 0; i < dgvDiagn.Rows.Count; i++)
            {
                frmIhspReg.ClininDiagnName += dgvDiagn.Rows[i].Cells["icdname"].Value.ToString() + ",";
                frmIhspReg.ClininDiagnICD += dgvDiagn.Rows[i].Cells["icd"].Value.ToString() + ",";
            }
            if (frmIhspReg.ClininDiagnName != "" && frmIhspReg.ClininDiagnICD != "")
            {
                frmIhspReg.ClininDiagnName = frmIhspReg.ClininDiagnName.Substring(0, frmIhspReg.ClininDiagnName.Length - 1);
                frmIhspReg.ClininDiagnICD = frmIhspReg.ClininDiagnICD.Substring(0, frmIhspReg.ClininDiagnICD.Length - 1);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请添加疾病信息或者单击取消关闭窗口!", "提示信息");
                tbxDiagn.Focus();
                return;
            }
        }
        private void btnConsole_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDiagn_Load(object sender, EventArgs e)
        {
            if (frmIhspReg.ClininDiagnName != "" && frmIhspReg.ClininDiagnICD != "")
            {
                string icdInfo = frmIhspReg.ClininDiagnICD;
                string[] icdList = icdInfo.Split(',');
                string nameInfo = frmIhspReg.ClininDiagnName;
                string[] nameList = nameInfo.Split(',');
                for (int i = 0; i < icdList.Length; i++)
                {
                    dgvDiagn.Rows.Add();
                    dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["icdname"].Value = nameList[i];
                    dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["icd"].Value = icdList[i];
                    dgvDiagn.Rows[dgvDiagn.Rows.Count - 1].Cells["delete"].Value = "删除";
                }
            }
        }

        private void dgvDiagn_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvDiagn.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvDiagn.RowHeadersDefaultCellStyle.Font, rectangle, dgvDiagn.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData==Keys.F2)
            {
                okMethod();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
