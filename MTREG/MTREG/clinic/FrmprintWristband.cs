using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.common;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MTHIS.common;
using System.Drawing;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.gysyb;
using MTREG.medinsur.gysyb.bo;
using MTHIS.main.bll;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.hdyb;
using MTREG.ihsptab.bo;

namespace MTREG.clinic
{
    public partial class FrmprintWristband : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        bool isqd = false;
        public FrmprintWristband()
        {
            InitializeComponent();
        }

        private void printWristband_Load(object sender, EventArgs e)
        {
            DataTable dtde = billCmbList.ihspDepart(cmbDepart.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.DataSource = dtde;
            }   

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = this.tbxName.Text.Trim().ToString();
            string ihspcode = this.tbxIhspcode.Text.Trim().ToString();
            string depart = "";
            if (cmbDepart.Text.Trim() == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cmbDepart.Text.Trim().ToString();
            }
            string startTime = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string hspcard = this.tbxHspcard.Text.Trim().ToString();
            DataTable dt = billIhspMan.getdr(name,ihspcode,hspcard,depart,startTime,endTime);
            dgvdr.DataSource = dt;
            #region  dgv单元格标题设置
            dgvdr.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvdr.RowsDefaultCellStyle.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvdr.ColumnHeadersHeight = (int)(30 * ProgramGlobal.HeightScale);
            this.dgvdr.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvdr.Columns["ihspcode"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["ihspname"].HeaderText = "姓名";
            this.dgvdr.Columns["ihspname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["sex"].HeaderText = "性别";
            this.dgvdr.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["departname"].HeaderText = "科室";
            this.dgvdr.Columns["departname"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["doctorname"].HeaderText = "医生";
            this.dgvdr.Columns["doctorname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["sickroomname"].HeaderText = "病室";
            this.dgvdr.Columns["sickroomname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["sickbedname"].HeaderText = "床号";
            this.dgvdr.Columns["sickbedname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["indate"].HeaderText = "入院时间";
            this.dgvdr.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvdr.Columns["indate"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["hspcard"].HeaderText = "卡  号";
            this.dgvdr.Columns["hspcard"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["patienttype"].HeaderText = "患者类型";
            this.dgvdr.Columns["patienttype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvdr.Columns["bas_patienttype_id"].HeaderText = "患者类型id";
            this.dgvdr.Columns["bas_patienttype_id"].Visible = false;
            this.dgvdr.Columns["displaycolor"].Visible = false;
            this.dgvdr.Columns["id"].HeaderText = "Id";
            this.dgvdr.Columns["id"].Visible = false;
            #endregion
            tbxIhspcode.Focus();
            dgvdr.ReadOnly = true;
            dgvdr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvdr.Rows.Count > 0)
            {
                dgvdr.Rows[0].Selected = true;
            }
            dataxse();
        }

        private void dgvdr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataxse();
        }
        private void dataxse()
        {
            if (dgvdr.RowCount == 0)
            {
                dgvxse.DataSource = null;
                return;
            }
            DataTable dt = billIhspMan.getxse(Convert.ToInt32(dgvdr.SelectedRows[0].Cells["id"].Value.ToString().Trim()));
            dgvxse.DataSource = dt;
            dgvxse.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvxse.RowsDefaultCellStyle.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvxse.ColumnHeadersHeight = (int)(30 * ProgramGlobal.HeightScale);
            this.dgvxse.Columns["name"].HeaderText = "姓名";
            this.dgvxse.Columns["name"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["sex"].HeaderText = "性别";
            this.dgvxse.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["birthday"].HeaderText = "生日";
            this.dgvxse.Columns["birthday"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["birthtime"].HeaderText = "出生时间";
            this.dgvxse.Columns["birthtime"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["height"].HeaderText = "身高";
            this.dgvxse.Columns["height"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["weight"].HeaderText = "体重";
            this.dgvxse.Columns["weight"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["recorddate"].HeaderText = "记录时间";
            this.dgvxse.Columns["recorddate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvxse.Columns["recorddate"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["isihsp"].HeaderText = "是否住院";
            this.dgvxse.Columns["isihsp"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvxse.Columns["id"].HeaderText = "Id";
            this.dgvxse.Columns["id"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbxHspcard.Text = "";
            this.tbxIhspcode.Text = "";
            this.tbxName.Text = "";
            cmbDepart.SelectedValue = 0;
            this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            dgvxse.DataSource = null;
            dgvdr.DataSource = null;
        }

        private void btnPrintWD_Click(object sender, EventArgs e)
        {
            if (dgvdr.SelectedRows.Count == 0 && dgvdr.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先病人在列表中选择");
                return;
            }
            String mtzyjl_iid = dgvdr.SelectedRows[0].Cells["id"].Value.ToString(); //住院记录表iid
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.WristbandPrt(mtzyjl_iid);
        }

        private void butxsewd_Click(object sender, EventArgs e)
        {
            if (this.isqdxse.Checked == true)
            {
                if (dgvdr.SelectedRows.Count == 0 && dgvdr.SelectedCells.Count == 0)
                {
                    MessageBox.Show("请先病人在列表中选择");
                    return;
                }
                DataTable dt = billIhspMan.getxsexx("", dgvdr.SelectedRows[0].Cells["id"].Value.ToString());
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.xse(dt);
            }
            else
            {
                if (dgvxse.SelectedRows.Count == 0 && dgvxse.SelectedCells.Count == 0)
                {
                    MessageBox.Show("请先在新生儿列表中选择");
                    return;
                }
                DataTable dt = billIhspMan.getxsexx(dgvxse.SelectedRows[0].Cells["id"].Value.ToString(), "");
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.xse(dt);
            }
        }
    }
}
