using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.ihsp.bo;
using MTREG.common;
using MTREG.ihsptab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmHspTabManage : Form
    {
        BllIhsptab bllIhsptab=new BllIhsptab();
        FrmTabRetAcc frmIhsptabRet=new FrmTabRetAcc();
        BillCmbList billCmbList = new BillCmbList();
        public FrmTabRetAcc FrmIhsptabRet
        {
            get { return frmIhsptabRet; }
            set { frmIhsptabRet = value; }
        }
        FrmPreView frmPreView = new FrmPreView();

        public FrmPreView FrmPreView
        {
            get { return frmPreView; }
            set { frmPreView = value; }
        }

        public FrmHspTabManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public void searchMethod()
        {
            dgvTabAccount.Columns.Clear();
            string depart =cmbDep.SelectedValue.ToString();
            string startime = this.dtpStartTime.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string endtime = this.dtpEndTime.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            DataTable dt=bllIhsptab.ihsptabSearch(startime,endtime,depart);
            dgvTabAccount.DataSource = dt;
            #region dgv标题设置
            dgvTabAccount.Columns["billcode"].HeaderText = "结算单号";
            dgvTabAccount.Columns["billcode"].Width = 180;
            dgvTabAccount.Columns["departname"].HeaderText = "科室";
            dgvTabAccount.Columns["departname"].Width = 180;
            dgvTabAccount.Columns["startdate"].HeaderText = "上次结账时间";
            dgvTabAccount.Columns["startdate"].Width = 150; 
            dgvTabAccount.Columns["enddate"].HeaderText = "本次结账时间";
            dgvTabAccount.Columns["enddate"].Width = 150;
            dgvTabAccount.Columns["settleby"].HeaderText = "结算人";
            dgvTabAccount.Columns["settleby"].Visible= false;        
            dgvTabAccount.Columns["id"].HeaderText = "id";
            dgvTabAccount.Columns["id"].Visible = false;
            dgvTabAccount.Columns["depart_id"].HeaderText = "depart";
            dgvTabAccount.Columns["depart_id"].Visible = false;
            dgvTabAccount.ReadOnly = true;
            dgvTabAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTabAccount_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();

            DataTable dt = billCmbList.depTypeList();
            if (dt.Rows.Count > 0)
            {
                this.cmbDep.ValueMember = "id";
                this.cmbDep.DisplayMember = "name";
                this.cmbDep.DataSource = dt;
            }
            dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());            
            searchMethod();            
            dgvbutton();
            DataTable dtId= bllIhsptab.getTabMaxId(cmbDep.SelectedValue.ToString());
            if (dtId.Rows.Count == 0)
            {
                btnRetAccount.Enabled = false;
            }
        }

        /// <summary>
        /// dgv按钮列声明
        /// </summary>
        public void dgvbutton()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "打印";
            btn.Text = "打印";
            btn.InheritedStyle.NullValue = "打印";
            btn.Width = 100;
            btn.UseColumnTextForButtonValue = true;
            btn.Frozen = false;
            dgvTabAccount.AutoGenerateColumns = true;
            dgvTabAccount.Columns.Insert(0,btn);
        }

        /// <summary>
        /// 退结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetAccount_Click(object sender, EventArgs e)
        {
            string depart = cmbDep.SelectedValue.ToString();

            this.frmIhsptabRet.Ihsptab.Depart_id = depart;
            if (!bllIhsptab.getLastIhspTab(frmIhsptabRet.Ihsptab))
            {

                MessageBox.Show("无可回退日结!");
                return;
            }
            frmIhsptabRet.ShowDialog();
            if (frmIhsptabRet.DialogResult == DialogResult.OK)
            {
                string sql = bllIhsptab.retIhspTab(depart);
                    if (BllMain.Db.Update(sql) < 0)
                    {
                        MessageBox.Show("退日结算失败!");
                        return;
                    }
                MessageBox.Show("退日结算成功!");
                searchMethod();
            }
           
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod();
            dgvbutton();
        }

        /// <summary>
        /// dgv中的按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTabAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dgvTabAccount.Columns[dgvTabAccount.CurrentCell.ColumnIndex];
            if (column is DataGridViewButtonColumn && column.Name == "打印")
            {
                this.FrmPreView.Ihsptab.Id = dgvTabAccount.SelectedRows[0].Cells["id"].Value.ToString();
                this.FrmPreView.Ihsptab.Startdate = dgvTabAccount.SelectedRows[0].Cells["startdate"].Value.ToString();
                this.FrmPreView.Ihsptab.Enddate = dgvTabAccount.SelectedRows[0].Cells["enddate"].Value.ToString();
                this.FrmPreView.Ihsptab.Charger_id = dgvTabAccount.SelectedRows[0].Cells["settleby"].Value.ToString();
                this.FrmPreView.Ihsptab.Depart_id = dgvTabAccount.SelectedRows[0].Cells["depart_id"].Value.ToString();
                this.FrmPreView.Ihsptab.Paytype = "tab";
                frmPreView.ShowDialog();
            }
           
        }

        /// <summary>
        /// 截止时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("截止日期不能大于当前日期");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误：截止时间应该大于起始时间 ！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
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
