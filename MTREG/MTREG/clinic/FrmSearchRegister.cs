using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.clinic.bo;

namespace MTREG.clinic
{
    public partial class FrmSearchRegister : Form
    {
        public FrmSearchRegister()
        {
            InitializeComponent();
        }
        BllSearchRegister bllSearchRegister = new BllSearchRegister();
        FrmClinicCost frmClinicCharge;
        int st = 0;
        int et = 0;
       public bool operFlag = false;
        public FrmClinicCost FrmClinicCharge
        {
            get { return frmClinicCharge; }
            set { frmClinicCharge = value; }
        }
        private void FrmSearchRegister_Load(object sender, EventArgs e)
        {
            loadTime();
            //加载挂号记录
            getRegisterData();
            #region updateHeaderText
            dgvRegister.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvRegister.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegister.Columns["id"].Visible = false;
            dgvRegister.Columns["depart_id"].Visible = false;
            dgvRegister.Columns["doctor_id"].Visible = false;
            dgvRegister.Columns["sex"].Visible = false;
            dgvRegister.Columns["age"].Visible = false;
            dgvRegister.Columns["member_id"].Visible = false;
            dgvRegister.Columns["bas_patienttype_id"].Visible = false;
            dgvRegister.Columns["billcode"].HeaderText = "挂号编号";
            dgvRegister.Columns["billcode"].DisplayIndex = 0;
            dgvRegister.Columns["billcode"].Width = 130;
            dgvRegister.Columns["regname"].HeaderText = "患者姓名";
            dgvRegister.Columns["regname"].Width = 130;
            dgvRegister.Columns["regname"].DisplayIndex = 1;
            dgvRegister.Columns["hspcard"].HeaderText = "卡号";
            dgvRegister.Columns["hspcard"].DisplayIndex = 2;
            dgvRegister.Columns["hspcard"].Width = 100;
            dgvRegister.Columns["dptname"].HeaderText = "科室";
            dgvRegister.Columns["dptname"].Width = 130;
            dgvRegister.Columns["dptname"].DisplayIndex = 3;
            dgvRegister.Columns["dctname"].HeaderText = "门诊医生";
            dgvRegister.Columns["dctname"].Width = 130;
            dgvRegister.Columns["dctname"].DisplayIndex = 4;
            if (dgvRegister.Rows.Count > 0)
            {
                dgvRegister.Rows[0].Selected = true;
            }
            dgvRegister.ReadOnly = true;
            dgvRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            #endregion
            
        }
        
        /// <summary>
        /// 计算日期
        /// </summary>
        private void loadTime()
        {
            int dtYear, dtMonth, dtDay;
            dtYear = dtpEtime.Value.Year;
            dtMonth = dtpEtime.Value.Month;
            dtDay = dtpEtime.Value.Day;
            dtDay = dtDay - 3;
            if (dtDay <= 0)
            {
                dtMonth = dtMonth - 1;
                int Feb;
                if ((dtYear % 4 == 0 && dtYear % 100 != 0) || (dtYear % 400 == 0))
                {
                    Feb = 29;
                }
                else
                {
                    Feb = 28;
                }
                switch (dtMonth)
                {
                    case 2:
                        dtDay = Feb + dtDay;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        dtDay = 30 + dtDay;
                        break;
                    default:
                        dtDay = 31 + dtDay;
                        break;
                }
                if (dtMonth == 0)
                {
                    dtMonth = 12;
                    dtYear = dtYear - 1;
                }
            }
            dtpStime.Value = Convert.ToDateTime(dtYear.ToString() + "-" + dtMonth.ToString() + "-" + dtDay.ToString() + " 00:00:00");
        }
        /// <summary>
        /// 获取挂号记录
        /// </summary>
        private void getRegisterData()
        {
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            dgvRegister.DataSource =
            bllSearchRegister.getRegisterInfo(startDate, endDate,tbxPatientName.Text.Trim(),tbxHspcard.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getRegisterData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            getRegisterInfo();
        }
        private void getRegisterInfo()
        {
            if (this.dgvRegister.CurrentRow != null)
            {
                frmClinicCharge.Register.Id = dgvRegister.CurrentRow.Cells["id"].Value.ToString();
                frmClinicCharge.Register.Billcode = dgvRegister.CurrentRow.Cells["billcode"].Value.ToString();
                frmClinicCharge.Register.Hspcard = dgvRegister.CurrentRow.Cells["hspcard"].Value.ToString();
                frmClinicCharge.Register.Name = dgvRegister.CurrentRow.Cells["regname"].Value.ToString();
                frmClinicCharge.Register.Depart_id = dgvRegister.CurrentRow.Cells["depart_id"].Value.ToString();
                frmClinicCharge.Register.Doctor_id = dgvRegister.CurrentRow.Cells["doctor_id"].Value.ToString();
                frmClinicCharge.Register.Age = dgvRegister.CurrentRow.Cells["age"].Value.ToString();
                frmClinicCharge.Register.Sex = dgvRegister.CurrentRow.Cells["sex"].Value.ToString();
                frmClinicCharge.Register.Bas_patienttype_id = dgvRegister.CurrentRow.Cells["bas_patienttype_id"].Value.ToString();
                frmClinicCharge.Register.Member_id = dgvRegister.CurrentRow.Cells["member_id"].Value.ToString();
                operFlag = true;
                this.Close();
                return;
            }
            MessageBox.Show("请选择后确定!", "提示");
            
        }

        private void tbxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter))
            {
                getRegisterData();
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                getRegisterData();
            }
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                getRegisterInfo();
            }
        }

        private void dgvRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRegister.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvRegister.CurrentRow != null)
                {
                    getRegisterInfo();
                    this.DialogResult = DialogResult.OK;
                }
                else if (e.KeyData == Keys.Down && dgvRegister.CurrentRow != null && dgvRegister.CurrentRow.Index > 0)
                {
                    dgvRegister.Rows[dgvRegister.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvRegister.CurrentRow != null && dgvRegister.CurrentRow.Index < dgvRegister.Rows.Count - 1)
                {
                    dgvRegister.Rows[dgvRegister.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void dtpStime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                st++;
                SendKeys.Send("{right}");
                if (st == 3)
                {
                    SendKeys.Send("{tab}");
                    st = 0;
                }
            }
        }

        private void dtpEtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                et++;
                SendKeys.Send("{right}");
                if (et == 3)
                {
                    SendKeys.Send("{tab}");
                    et = 0;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl is TextBox || this.ActiveControl is Button)
                {
                    SendKeys.Send("{tab}");
                    return false;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else if (keyData == Keys.Space && ActiveControl is Button)
            {
                if (this.btnOk.Name == btnOk.Name)
                    this.btnOk.PerformClick();
                else if (this.ActiveControl.Name == btnSearch.Name)
                    this.btnSearch.PerformClick();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void dgvRegister_DoubleClick(object sender, EventArgs e)
        {
            getRegisterInfo();
        }

    }
}
