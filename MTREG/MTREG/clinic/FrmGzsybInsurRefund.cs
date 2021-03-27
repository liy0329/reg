using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.common;
using MTREG.clinic.bo;
using MTREG.clinic.bll;
using MTREG.medinsur.gzsyb.bll;

namespace MTREG.clinic
{
    public partial class FrmGzsybInsurRefund : Form
    {
        BillClinicRcpCost bllClinicRcpCost = new BillClinicRcpCost();

        public FrmGzsybInsurRefund()
        {
            InitializeComponent();
        }

        private void FrmGysybInsurRefund_Load(object sender, EventArgs e)
        {
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            //加载表格
            initdgvList();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void searchInvoiceList()
        {
            InsurInfoParam insurInfoParam = new InsurInfoParam();
            insurInfoParam.PatientName = tbxPatientName.Text.Trim();
            insurInfoParam.StartDate = this.dtpStime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            insurInfoParam.EndDate = this.dtpEtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            this.dgvInvoice.DataSource = bllClinicRcpCost.getGzsybClinicAccountList(insurInfoParam);
        }

        /// <summary>
        /// 加载dataGridview信息
        /// </summary>
        private void initdgvList()
        {
            searchInvoiceList();

            #region updateHeaderText
            dgvInvoice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvInvoice.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));

            dgvInvoice.Columns["invoice_id"].HeaderText = "结算编号";
            dgvInvoice.Columns["invoice_id"].Width = (int)(130 * ProgramGlobal.WidthScale);
            
            dgvInvoice.Columns["patientname"].HeaderText = "姓名";
            dgvInvoice.Columns["patientname"].Width = (int)(130 * ProgramGlobal.WidthScale);
            
            dgvInvoice.Columns["insurcode"].HeaderText = "个人编号";
            dgvInvoice.Columns["insurcode"].Width = (int)(130 * ProgramGlobal.WidthScale);
            
            dgvInvoice.Columns["chargedate"].HeaderText = "收费时间";
            dgvInvoice.Columns["chargedate"].Width = (int)(200 * ProgramGlobal.WidthScale);
            
            dgvInvoice.Columns["stat"].HeaderText = "状态";
            dgvInvoice.Columns["stat"].Width = (int)(100 * ProgramGlobal.WidthScale);

            dgvInvoice.Columns["ybflaginfo"].HeaderText = "收费确认";
            dgvInvoice.Columns["ybflaginfo"].Width = (int)(100 * ProgramGlobal.WidthScale);

            dgvInvoice.Columns["ybretflaginfo"].HeaderText = "退费确认";
            dgvInvoice.Columns["ybretflaginfo"].Width = (int)(100 * ProgramGlobal.WidthScale);

            dgvInvoice.Columns["astrjylsh"].Visible = false;
            dgvInvoice.Columns["retastrjylsh"].Visible = false;
            dgvInvoice.Columns["hisaccount"].Visible = false;
            dgvInvoice.Columns["ybflag"].Visible = false;
            dgvInvoice.Columns["ybretflag"].Visible = false;
            
            dgvInvoice.ReadOnly = true;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoice.MultiSelect = false;
            if (dgvInvoice.Rows.Count > 0)
            {
                dgvInvoice.Rows[0].Selected = true;
            }
            #endregion

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchInvoiceList();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {
                string invoiceId = dgvInvoice.CurrentRow.Cells["invoice_id"].Value.ToString();

                BllClinicMedinsrGZS bllClinicMedinsrGZS = new BllClinicMedinsrGZS();
                bool flag = bllClinicMedinsrGZS.reFund(invoiceId);
                if (!flag)
                {
                    return;
                }
                bllClinicRcpCost.upGzsybHisaccount(invoiceId, "2");
            }
        }

        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow != null)
            {
                string hisaccount = dgvInvoice.CurrentRow.Cells["hisaccount"].Value.ToString();
                 string invoice_id = dgvInvoice.CurrentRow.Cells["invoice_id"].Value.ToString();

                string ybflag = dgvInvoice.CurrentRow.Cells["ybflag"].Value.ToString();
                string ybretflag = dgvInvoice.CurrentRow.Cells["ybretflag"].Value.ToString();
                 if (hisaccount == "1" && bllClinicRcpCost.getInVoiceCount(invoice_id) == 0)
                {
                    btnRefund.Enabled = true;
                }
                else
                {
                    btnRefund.Enabled = false;
                }
                 if (ybflag == "1")
                 {
                     this.btnChargeCancel.Enabled = true;
                 }
                 else
                 {
                     this.btnChargeCancel.Enabled = false;
                 }
                 if (ybretflag == "1")
                 {
                     this.btnRetCancel.Enabled = true;
                 }
                 else

                 {
                     this.btnRetCancel.Enabled = false;
                 }
            }
        }

        private void btnChargeCancel_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow == null)
            {
                MessageBox.Show("请选择病人结算信息！", "提示消息");
                return; }
            string invoice_id = dgvInvoice.CurrentRow.Cells["invoice_id"].Value.ToString();
            string astrjylsh = dgvInvoice.CurrentRow.Cells["astrjylsh"].Value.ToString();
            BllClinicMedinsrGZS bllClinicMedinsrGZS = new BllClinicMedinsrGZS();

            if (!bllClinicMedinsrGZS.doCancleCharege(astrjylsh, invoice_id))
            {
                MessageBox.Show("撤销收费确认失败！", "提示消息");
                return;
            }

            MessageBox.Show("撤销收费确认成功！", "提示消息");
            searchInvoiceList();
        }

        private void btnRetCancel_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow == null)
            {
                MessageBox.Show("请选择病人结算信息！", "提示消息");
                return;
            }
            string invoice_id = dgvInvoice.CurrentRow.Cells["invoice_id"].Value.ToString();
            string retastrjylsh = dgvInvoice.CurrentRow.Cells["retastrjylsh"].Value.ToString();
            BllClinicMedinsrGZS bllClinicMedinsrGZS = new BllClinicMedinsrGZS();

            if (!bllClinicMedinsrGZS.doCancleRetCharege(retastrjylsh, invoice_id))
            {
                MessageBox.Show("撤销退费确认失败！", "提示消息");
                return;
            }

            MessageBox.Show("撤销退费确认成功！", "提示消息");
            searchInvoiceList();
        }
    }
}
