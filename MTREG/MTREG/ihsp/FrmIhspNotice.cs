using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.db;
using MTHIS.common;
using MTREG.ihsp.bll;

namespace MTREG.ihsp
{
    public partial class FrmIhspNotice : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        FrmIhspReg frmIhspReg=new FrmIhspReg("REG") ;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 有参数构造函数
        /// </summary>
        public FrmIhspNotice(FrmIhspReg IhspReg)
        {
            InitializeComponent();
            this.frmIhspReg = IhspReg;            
        }
        /// <summary>
        /// 确定按钮；grid中选中数据传回父级窗口。关闭自身
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            onSelectInspNotice();      
        }

        private void onSelectInspNotice()
        {
            if (dgvIhspNotice.SelectedRows.Count == 0 && dgvIhspNotice.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string id = dgvIhspNotice.SelectedRows[0].Cells["id"].Value.ToString();

            string patienType = dgvIhspNotice.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
         
            frmIhspReg.getSource(id, patienType);
            this.Close();
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public void seachMeathod()
        {
            string depart = "";
            string hspcard = this.tbxHspcard.Text.Trim().ToString();
            string name = this.tbxName.Text.Trim();
            if (tbxDepart.Text == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.tbxDepart.Text.ToString();
            }
            BillIhspMan billIhspMan = new BillIhspMan();
            string startTime = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dataTable = billIhspMan.IhspNoticeSearch(name, hspcard, depart,startTime,endTime);
            this.dgvIhspNotice.DataSource = dataTable;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            seachMeathod();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspNotice_Load(object sender, EventArgs e)
        {
         
            #region combox设置
            DataTable dtde = billCmbList.ihspDepart(tbxDepart.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.lbxDepart.ValueMember = "id";
                this.lbxDepart.DisplayMember = "name";
                var dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.lbxDepart.DataSource = dtde;
            }  
            #endregion
            seachMeathod();
            #region dvg标题设置
            this.dgvIhspNotice.Columns["hspcard"].HeaderText = "卡号";
            this.dgvIhspNotice.Columns["hspcard"].Width = 110;
            this.dgvIhspNotice.Columns["name"].HeaderText = "姓名";
            this.dgvIhspNotice.Columns["name"].Width = 80;
            this.dgvIhspNotice.Columns["sex"].HeaderText = "性别";
            this.dgvIhspNotice.Columns["sex"].Width = 50;
            this.dgvIhspNotice.Columns["age"].HeaderText = "年龄";
            this.dgvIhspNotice.Columns["age"].Width = 50;
            this.dgvIhspNotice.Columns["birthday"].HeaderText = "出生日期";
            this.dgvIhspNotice.Columns["birthday"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhspNotice.Columns["birthday"].Width = 120;
            this.dgvIhspNotice.Columns["departname"].HeaderText = "科室";
            this.dgvIhspNotice.Columns["departname"].Width = 130;
            this.dgvIhspNotice.Columns["payfee"].HeaderText = "预交金额";
            this.dgvIhspNotice.Columns["payfee"].Width = 100;
            this.dgvIhspNotice.Columns["indate"].HeaderText = "通知时间";
            this.dgvIhspNotice.Columns["indate"].Width = 120;
            this.dgvIhspNotice.Columns["id"].HeaderText = "id";
            this.dgvIhspNotice.Columns["id"].Visible = false;
            this.dgvIhspNotice.Columns["bas_patienttype_id"].HeaderText = "bas_patienttype_id";
            this.dgvIhspNotice.Columns["bas_patienttype_id"].Visible = false;
            dgvIhspNotice.ReadOnly = true;
            dgvIhspNotice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
           
        }

        /// <summary>
        /// 双击选择入院通知书dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIhspNotice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            onSelectInspNotice(); 
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbxHspcard.Text = "";
            tbxName.Text = "";
            tbxDepart.Clear();
            tbxDepCode.Clear();
            lbxDepart.Visible = false;
            seachMeathod();
        }

        /// <summary>
        /// 焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspNotice_Activated(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }
        private void tbxDepart_TextChanged(object sender, EventArgs e)
        {
            lbxDepart.Visible = true;
            DataTable dtde = billCmbList.ihspDepart(tbxDepart.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.lbxDepart.ValueMember = "id";
                this.lbxDepart.DisplayMember = "name";
                var dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.lbxDepart.DataSource = dtde;
            }
        }

        private void tbxDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxDepart.Focus();
                if (lbxDepart.Items.Count >= 2)
                {
                    lbxDepart.SelectedIndex = 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                tbxDepCode.Text = lbxDepart.SelectedValue.ToString();
                tbxDepart.Text = lbxDepart.Text.ToString();
                lbxDepart.Visible = false;
            }
        }

        private void lbxDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxDepart.SelectedIndex == 1)
                {
                    tbxDepart.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxDepart.SelectedItem;
                tbxDepart.Text = drv.DataView[lbxDepart.SelectedIndex]["name"].ToString();
                tbxDepCode.Text = lbxDepart.SelectedValue.ToString();//获取value值后index变为0,所以放在后面                
                tbxDepart.Focus();
                lbxDepart.Visible = false;
            }
        }

        private void tbxDepart_Enter(object sender, EventArgs e)
        {
            lbxDepart.Visible = true;
            tbxDepart.SelectAll();
        }

        private void tbxDepart_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxDepart.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }
        private void lbxDepart_Leave(object sender, EventArgs e)
        {
            lbxDepart.Visible = false;
        }

        private void lbxDepart_MouseDown(object sender, MouseEventArgs e)
        {
            lbxDepart.Visible = true;
        }

        /// <summary>
        /// 双击选择入院通知书dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIhspNotice_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            onSelectInspNotice(); 
        }

        private void lbxDepart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
