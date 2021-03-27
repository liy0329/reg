using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bll;
using MTREG.ihsp.bll;
using MTREG.common;

using MTREG.medinsur.hdxbhnh;
using MTREG.medinsur.hdxbhnh.bll;
using MTHIS.common;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTREG.medinsur.gzsnh.bll;
using MTHIS.main.bll;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.bll;
using MTREG.medinsur.gzsnh.bo;
using System.Net;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ynsyb.ihsp.bll;

namespace MTREG.medinsur
{
    public partial class FrmCostTransfer : Form
    {
        BllCostTransfer bllCostTransfer = new BllCostTransfer();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsurMethod bllInsurMethod = new BllInsurMethod();
        DataTable dtArea = new DataTable();
        BillIhspAct bllIhspAct = new BillIhspAct();
        public FrmCostTransfer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 患者类型更改时筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatienttype_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPatienttype.Text == "自费")
            {
                btnTransfer.Enabled = false;
            }
            else { btnTransfer.Enabled = true; }
            DataTable dt= bllCostTransfer.ihspSearch(cmbPatienttype.SelectedValue.ToString());
            dgvInhospital.DataSource = dt;            
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCostTransfer_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dtp = bllCostTransfer.costInsurTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.DataSource = dtp;
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
            }

            DataTable dt = bllCostTransfer.ihspSearch(cmbPatienttype.SelectedValue.ToString());
            dgvInhospital.DataSource = dt;            
            #region  dgv单元格标题设置
            dgvInhospital.ReadOnly = false;
            this.dgvInhospital.Columns["ischecked"].HeaderText = "选择";
            this.dgvInhospital.Columns["ischecked"].Width = 50;
            this.dgvInhospital.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvInhospital.Columns["ihspcode"].Width = 100;
            this.dgvInhospital.Columns["ihspcode"].ReadOnly = true;
            this.dgvInhospital.Columns["ihspname"].HeaderText = "姓名";
            this.dgvInhospital.Columns["ihspname"].Width = 100;
            this.dgvInhospital.Columns["ihspname"].ReadOnly = true;
            this.dgvInhospital.Columns["sex"].HeaderText = "性别";
            this.dgvInhospital.Columns["sex"].Width = 50;
            this.dgvInhospital.Columns["sex"].ReadOnly = true;
            this.dgvInhospital.Columns["departname"].HeaderText = "科室";
            this.dgvInhospital.Columns["departname"].Width = 130;
            this.dgvInhospital.Columns["departname"].ReadOnly = true;
            this.dgvInhospital.Columns["doctorname"].HeaderText = "医生";
            this.dgvInhospital.Columns["doctorname"].Width = 100;
            this.dgvInhospital.Columns["doctorname"].ReadOnly = true;
            this.dgvInhospital.Columns["sickroomname"].HeaderText = "病室";
            this.dgvInhospital.Columns["sickroomname"].Width = 100;
            this.dgvInhospital.Columns["sickroomname"].ReadOnly = true;
            this.dgvInhospital.Columns["sickbedname"].HeaderText = "床号";
            this.dgvInhospital.Columns["sickbedname"].Width = 100;
            this.dgvInhospital.Columns["sickbedname"].ReadOnly = true;
            this.dgvInhospital.Columns["indate"].HeaderText = "入院时间";
            this.dgvInhospital.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvInhospital.Columns["indate"].Width = 110;
            this.dgvInhospital.Columns["indate"].ReadOnly = true;
            this.dgvInhospital.Columns["hspcard"].HeaderText = "卡  号";
            this.dgvInhospital.Columns["hspcard"].Width = 100;
            this.dgvInhospital.Columns["hspcard"].ReadOnly = true;
            this.dgvInhospital.Columns["patienttypename"].HeaderText = "患者类型";
            this.dgvInhospital.Columns["patienttypename"].Width = 80;
            this.dgvInhospital.Columns["patienttypename"].ReadOnly = true;
            this.dgvInhospital.Columns["patienttype"].HeaderText = "Id";
            this.dgvInhospital.Columns["patienttype"].Visible = false;
            this.dgvInhospital.Columns["id"].HeaderText = "Id";
            this.dgvInhospital.Columns["id"].Visible = false;
            dgvInhospital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }

        /// <summary>
        /// 数据传输
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            bool ischeck = true;
            BllInsur bllInsur = new BllInsur();
            textBox1.Clear();
            for (int i = 0; i < dgvInhospital.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvInhospital.Rows[i].Cells["ischecked"];
                ischeck = (bool)checkBox.EditedFormattedValue;
                if (ischeck == true)
                {
                    string ihsp_id = dgvInhospital.Rows[i].Cells["id"].Value.ToString();
                    string patienttype = dgvInhospital.Rows[i].Cells["patienttype"].Value.ToString();
                    string ihspname = dgvInhospital.Rows[i].Cells["ihspname"].Value.ToString();
                    string ihspcode = dgvInhospital.Rows[i].Cells["ihspcode"].Value.ToString();
                    string keyname = bllInsur.getInsurtype(patienttype);
                    if (!bllIhspAct.NursYjs(ihsp_id))
                    {
                        textBox1.AppendText("失败: 住院号:" + ihspcode + ", 姓名:" + ihspname + "时间:" + DateTime.Now.ToString("HH:mm:ss")+"\n");
                    }
                 }
            }
            if (ischeck == false)
            {
                MessageBox.Show("请先选择传输数据!");
                return;
            }
            //ihsp_id = ihsp_id.Substring(0, ihsp_id.Length - 1);
        }

        /// <summary>
        /// 全选改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgvInhospital == null)
                return;
            if (this.cbxSelectAll.Checked)
            {
                for (int i = 0; i < this.dgvInhospital.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvInhospital.Rows[i].Cells["ischecked"];
                    checkBox.Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < this.dgvInhospital.RowCount; i++)
                {
                    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvInhospital.Rows[i].Cells["ischecked"];
                    checkBox.Value = 0;
                }
            }
        }

        /// <summary>
        /// 选择数据变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInhospital_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInhospital.IsCurrentCellDirty)
            {
                dgvInhospital.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
       
    }
}
