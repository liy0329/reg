using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MTREG.ihsptab.bll;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.common;

namespace MTREG.ihsptab
{
    public partial class FrmIhspDutyManage : Form
    {
        BllIhsptab bllIhsptab = new BllIhsptab();
        FrmDutyRetAcc frmIhspDutyRet = new FrmDutyRetAcc();
        BillCmbList billCmbList = new BillCmbList();
        public FrmDutyRetAcc FrmIhsptabRet
        {
            get { return frmIhspDutyRet; }
            set { frmIhspDutyRet = value; }
        }
        FrmPreView frmPreView = new FrmPreView();

        public FrmPreView FrmPreView
        {
            get { return frmPreView; }
            set { frmPreView = value; }
        }
        public FrmIhspDutyManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查找方法
        /// </summary>
        public void searchMethod()
        {
            string person = ProgramGlobal.User_id;
            string startime = this.dtpStartTime.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string endtime = this.dtpEndTime.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            DataTable dt = bllIhsptab.ihspdutySearch(startime, endtime, person);
            dgvTabAccount.DataSource = dt;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspDutyManage_Load(object sender, EventArgs e)
        {
        
            tbxCreatedby.ReadOnly = true;
            tbxCreatedby.Text = bllIhsptab.getDoctorName(ProgramGlobal.User_id);

            dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
            dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());            
           
            searchMethod();
            #region dgv标题设置
            dgvTabAccount.Columns["billcode"].HeaderText = "结算单号";
            dgvTabAccount.Columns["billcode"].Width = 180;
            dgvTabAccount.Columns["charger"].HeaderText = "收费员";
            dgvTabAccount.Columns["charger"].Width = 100;
            dgvTabAccount.Columns["departname"].HeaderText = "科室";
            dgvTabAccount.Columns["departname"].Width = 180;
            dgvTabAccount.Columns["startdate"].HeaderText = "上次结账时间";
            dgvTabAccount.Columns["startdate"].Width = 150;
            dgvTabAccount.Columns["enddate"].HeaderText = "本次结账时间";
            dgvTabAccount.Columns["enddate"].Width = 150;                                    
            dgvTabAccount.Columns["id"].HeaderText = "id";
            dgvTabAccount.Columns["id"].Visible = false;
            dgvTabAccount.Columns["depart_id"].HeaderText = "depart";
            dgvTabAccount.Columns["depart_id"].Visible = false;
            dgvTabAccount.ReadOnly = true;
            dgvTabAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
            dgvbutton();
           
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
            dgvTabAccount.Columns.Insert(0, btn);
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod();
        }

        /// <summary>
        /// 退结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetAccount_Click(object sender, EventArgs e)
        {


            this.frmIhspDutyRet.Ihsptab.Charger_id = ProgramGlobal.User_id;
            if (!bllIhsptab.getLastIhspTabDuty(frmIhspDutyRet.Ihsptab))
            {

                MessageBox.Show("上次日结后，无可退班结!");
                return;
            }
            this.frmIhspDutyRet.Ihsptab.Charger_id = ProgramGlobal.User_id;
            frmIhspDutyRet.ShowDialog();
            if (frmIhspDutyRet.DialogResult == DialogResult.OK)
            {
                if (!bllIhsptab.deleteIhspTabDuty(ProgramGlobal.User_id))
                {
                    MessageBox.Show("班结回退失败!");
                    return;
                }
                MessageBox.Show("班结回退成功!");
                searchMethod();
            }
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
                this.FrmPreView.Ihsptab.Charger_id = dgvTabAccount.SelectedRows[0].Cells["charger"].Value.ToString();
                this.FrmPreView.Ihsptab.Depart_id = dgvTabAccount.SelectedRows[0].Cells["depart_id"].Value.ToString();
                this.FrmPreView.Ihsptab.Paytype = "duty";
                frmPreView.ShowDialog();
            }
        }

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


        private void dgvTabAccount_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvTabAccount.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvTabAccount.RowHeadersDefaultCellStyle.Font, rectangle, dgvTabAccount.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

    }
}
