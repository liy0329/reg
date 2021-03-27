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
    public partial class FrmRefundInvoice : Form
    {
        BllRefundInvoice bllRefundInvoice = new BllRefundInvoice();
        ChargeManagePatientInfo chargeManagePatientInfo = new ChargeManagePatientInfo();

        internal ChargeManagePatientInfo ChargeManagePatientInfo
        {
            get { return chargeManagePatientInfo; }
            set { chargeManagePatientInfo = value; }
        }
        string[] gridView;
        public FrmRefundInvoice()
        {
            InitializeComponent();
        }

        public void prtGetsource(string[] gridView)
        {

            this.lblPatientName.Text = chargeManagePatientInfo.PatientName;
            this.lblHspcard.Text = chargeManagePatientInfo.Hspcard;
            this.lblSex.Text = chargeManagePatientInfo.Sex;
            this.lblDepart.Text = chargeManagePatientInfo.Depart;
            this.lblDoctor.Text = chargeManagePatientInfo.Doctor;
            this.lblIDCard.Text = chargeManagePatientInfo.Idcard;
            this.gridView = gridView;
        }

        private void FrmRefundInvoice_Load(object sender, EventArgs e)
        {
            //加载表格
            loadDataGrid();
        }
        private void loadDataGrid()
        {
            DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClinicRcp0.Columns.Add(column1);
            column1.CellTemplate = dgvcell;
            column1.Name = "id";
            DataGridViewColumn column2 = new DataGridViewColumn();
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClinicRcp0.Columns.Add(column2);
            column2.CellTemplate = dgvcell;
            column2.Name = "text2";
            DataGridViewColumn column3 = new DataGridViewColumn();
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClinicRcp0.Columns.Add(column3);
            column3.CellTemplate = dgvcell;
            column3.Name = "text3";
            dgvClinicRcp0.Columns["id"].Visible = false;

            int j =0;
            for (int i = 0; i < gridView.Length; i+=2)
            {
      //          j = i / 2;
                DataGridViewRow row = new DataGridViewRow();
                dgvClinicRcp0.Rows.Add(row);
     //           dgvClinicRcp0.Rows[j].Cells[1].Value = gridView[i];
                dgvClinicRcp0.Rows[j].Cells[0].ReadOnly = false;
                dgvClinicRcp0.Rows[j].Cells[1].Value = "处方号：";
                dgvClinicRcp0.Rows[j].Cells[2].Value = gridView[i+1];
                DataTable dt = bllRefundInvoice.getClinicRcp(gridView[i]);
                int m = 0;
                for (; m < dt.Rows.Count; m++)
                {
                    DataGridViewRow newrow = new DataGridViewRow();
                    dgvClinicRcp0.Rows.Add(newrow);
                    if (dt.Rows[m]["charged"].ToString() == "CHAR" && dt.Rows[m]["unlocked"].ToString() == "Y")
                    {
                        dgvClinicRcp0.Rows[j + m + 1].Cells[0].Value = true;
                    }
                    dgvClinicRcp0.Rows[j + m + 1].Cells[1].Value = dt.Rows[m]["name"];
                }
                j =j+m+ 1;
            }
            dgvClinicRcp0.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvClinicRcp0.Columns["text2"].Width = 150;
            dgvClinicRcp0.Columns["text2"].ReadOnly = true;
            dgvClinicRcp0.Columns["text3"].Width = 150;
            dgvClinicRcp0.Columns["text3"].ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClinicRcp0_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void dgvClinicRcp0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    int index = dgvClinicRcp0.CurrentRow.Index;
        //    if (dgvClinicRcp0.Rows[index].Cells["checkrcp"].Value == null || dgvClinicRcp0.Rows[index].Cells["text2"].Value==null)
        //    {
        //        return;
        //    }
        //    if (dgvClinicRcp0.Rows[index].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE" && dgvClinicRcp0.Rows[index].Cells["text2"].Value.ToString() == "处方号：")
        //    {
        //        for (int i = index+1; i < dgvClinicRcp0.Rows.Count; i++)
        //        {
        //            if (dgvClinicRcp0.Rows[index + 1].Cells["text2"].Value == null)
        //            {
        //                return;
        //            }
        //            if (dgvClinicRcp0.Rows[index + 1].Cells["text2"].Value.ToString() != "处方号：")
        //            {
        //                dgvClinicRcp0.Rows[index + 1].Cells["checkrcp"].Value = true;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 触发复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicRcp0_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvClinicRcp0.IsCurrentCellDirty)
            {
                dgvClinicRcp0.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblIDCard_Click(object sender, EventArgs e)
        {

        }

        private void lblSex_Click(object sender, EventArgs e)
        {

        }

        private void lblDoctor_Click(object sender, EventArgs e)
        {

        }

        private void lblPatientName_Click(object sender, EventArgs e)
        {

        }

        private void lblDepart_Click(object sender, EventArgs e)
        {

        }

        private void lblHspcard_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }


}
