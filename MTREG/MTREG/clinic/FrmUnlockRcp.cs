using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bo;
using MTREG.clinic.bll;
using MTHIS.common;

namespace MTREG.clinic
{
    public partial class FrmUnlockRcp : Form
    {
        BllUnlockRcp bllUnlockRcp = new BllUnlockRcp();
        ChargeManagePatientInfo chargeManagePatientInfo = new ChargeManagePatientInfo();
        string invoiceId = "";
        internal ChargeManagePatientInfo ChargeManagePatientInfo
        {
            get { return chargeManagePatientInfo; }
            set { chargeManagePatientInfo = value; }
        }
        public FrmUnlockRcp()
        {
            InitializeComponent();
        }

        private void FrmUnlockRcp_Load(object sender, EventArgs e)
        {
            //加载表格
            loadDataGrid();
        }

        private void loadDataGrid()
        {
            dgvCliniCost.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvCliniCost.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliniCost.Columns["id"].Visible = false;
            dgvCliniCost.Columns["billcode"].HeaderText = "处方号";
            dgvCliniCost.Columns["billcode"].Width = 100;
            dgvCliniCost.Columns["billcode"].DisplayIndex = 1;
            dgvCliniCost.Columns["billcode"].ReadOnly = true;
            dgvCliniCost.Columns["chargedate"].HeaderText = "收费日期";
            dgvCliniCost.Columns["chargedate"].Width = 110;
            dgvCliniCost.Columns["chargedate"].DisplayIndex = 2;
            dgvCliniCost.Columns["chargedate"].ReadOnly = true;
            dgvCliniCost.Columns["dptname"].HeaderText = "科室";
            dgvCliniCost.Columns["dptname"].Width = 85;
            dgvCliniCost.Columns["dptname"].DisplayIndex = 3;
            dgvCliniCost.Columns["dptname"].ReadOnly = true;
            dgvCliniCost.Columns["dctname"].HeaderText = "医生";
            dgvCliniCost.Columns["dctname"].Width = 85;
            dgvCliniCost.Columns["dctname"].DisplayIndex = 4;
            dgvCliniCost.Columns["dctname"].ReadOnly = true;
            dgvCliniCost.Columns["Realfee"].HeaderText = "收费金额";
            dgvCliniCost.Columns["Realfee"].Width = 90;
            dgvCliniCost.Columns["Realfee"].DisplayIndex = 5;
            dgvCliniCost.Columns["Realfee"].ReadOnly = true;
            dgvCliniCost.Columns["checkrcp"].HeaderText = "";
            dgvCliniCost.Columns["checkrcp"].Width = 30;
            dgvCliniCost.Columns["checkrcp"].ReadOnly = false;
            dgvCliniCost.Columns["checkrcp"].DisplayIndex = 6;
            dgvCliniCost.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }
        public void getDgvCliniCost(string invoiceId)
        {
            this.invoiceId = invoiceId;
            dgvCliniCost.DataSource = bllUnlockRcp.getChargeData(invoiceId);
        }
        private void loadDgvClinicRcp0(string[] gridData)
        {
            double amount = 0;
            DataGridViewCheckBoxColumn column0 = new DataGridViewCheckBoxColumn();
            dgvClinicRcp0.Columns.Add(column0);
            column0.Name = "checkrcp";
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column1);
            column1.Name = "id";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column2);
            column2.Name = "text2";
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column3);
            column3.Name = "text3";
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column4);
            column4.Name = "unit";
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column5);
            column5.Name = "num";
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column6);
            column6.Name = "prc";
            dgvClinicRcp0.Columns["checkrcp"].Width = 35;
            dgvClinicRcp0.Columns["checkrcp"].HeaderText = "";
            dgvClinicRcp0.Columns["unit"].Width = 50;
            dgvClinicRcp0.Columns["unit"].HeaderText = "单位";
            dgvClinicRcp0.Columns["num"].Width = 50;
            dgvClinicRcp0.Columns["num"].HeaderText = "数量";
            dgvClinicRcp0.Columns["prc"].Width = 50;
            dgvClinicRcp0.Columns["prc"].HeaderText = "单价";
            dgvClinicRcp0.Columns["text2"].Width = 150;
            dgvClinicRcp0.Columns["text2"].HeaderText = "项目名称";
            dgvClinicRcp0.Columns["text2"].ReadOnly = true;
            dgvClinicRcp0.Columns["text3"].Width = 150;
            dgvClinicRcp0.Columns["text3"].HeaderText = "发票号";
            dgvClinicRcp0.Columns["text3"].ReadOnly = true;
            dgvClinicRcp0.Columns["id"].Visible = false;
            dgvClinicRcp0.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            int j = 0;
            for (int i = 0; i < gridData.Length; i += 2)
            {
                DataGridViewRow row = new DataGridViewRow();
                dgvClinicRcp0.Rows.Add(row);
                // dgvClinicRcp0.Rows[j].Cells[1].Value = gridView[i];

                dgvClinicRcp0.Rows[j].Cells["checkrcp"].Value = false;
                dgvClinicRcp0.Rows[j].Cells["checkrcp"].ReadOnly = true;
                dgvClinicRcp0.Rows[j].Cells["text2"].Value = "处方号：";
                dgvClinicRcp0.Rows[j].Cells["text3"].Value = gridData[i + 1];
                DataTable dt = bllUnlockRcp.getClinicRcp(gridData[i]);
                int m = 0;
                for (; m < dt.Rows.Count; m++)
                {
                    DataGridViewRow newrow = new DataGridViewRow();
                    dgvClinicRcp0.Rows.Add(newrow);
                    dgvClinicRcp0.Rows[j + m + 1].Cells["id"].Value = dt.Rows[m]["id"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["text2"].Value = dt.Rows[m]["name"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["unit"].Value = dt.Rows[m]["unit"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["num"].Value = dt.Rows[m]["num"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["text3"].Value = dt.Rows[m]["billcode"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["prc"].Value = dt.Rows[m]["prc"];
                    if (dt.Rows[m]["retappstat"].ToString() == "Y")
                    {
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value = true;
                    }
                    else if (dt.Rows[m]["retappstat"].ToString() == "N")
                    {
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value = false;
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].ReadOnly = true;
                    }
                    if (dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                    {
                        amount += double.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["num"].Value.ToString()) * double.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["prc"].Value.ToString());
                    }

                }
                j = j + m + 1;
            }

            tbxAmount.Text = amount.ToString();
        }
        public void prtGetsource()
        {
            this.lblPatientName.Text = chargeManagePatientInfo.PatientName;
            this.lblHspcard.Text = chargeManagePatientInfo.Hspcard;
            this.lblSex.Text = chargeManagePatientInfo.Sex;
            this.lblDepart.Text = chargeManagePatientInfo.Depart;
            this.lblDoctor.Text = chargeManagePatientInfo.Doctor;
            this.lblIDCard.Text = chargeManagePatientInfo.Idcard;

        }
        /// <summary>
        ///  总复选框状态改变事件
        /// </summary>
        private void allCheckChange()
        {
            int isallchk = 0;
            if (cbxAllcheck.Checked == true)
            {
                isallchk = 1;
            }
            for (int i = 0; i < dgvCliniCost.RowCount; i++)
            {
                dgvCliniCost.Rows[i].Cells["checkrcp"].Value = isallchk;

            }
        }
        private string[] getDgvData()
        {
            int num = 0;
            for (int i = 0; i < dgvCliniCost.Rows.Count; i++)
            {
                if (dgvCliniCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    num++;
                }
            }
            string[] gridData = new string[num * 2];
            int m = 0;
            for (int i = 0; i < dgvCliniCost.Rows.Count; i++)
            {

                if (dgvCliniCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    gridData[m] = dgvCliniCost.Rows[i].Cells["id"].Value.ToString();
                    gridData[++m] = dgvCliniCost.Rows[i].Cells["billcode"].Value.ToString();
                    m++;
                }
            }
            return gridData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string merge_sql = "";
            bllUnlockRcp.modifyCliniCostdet(getCliniCostdetIds(), ref merge_sql);
            bllUnlockRcp.modifyCliniCost(getCliniCostIds(), ref merge_sql);
            int result = bllUnlockRcp.doExeSql(merge_sql);
            if (result == 0)
            {
               MessageBox.Show("处方解锁成功！");
               this.Close();
            }
            else if(result == -1)
            {
                MessageBox.Show("处方解锁失败！");
            }
        }

        /// <summary>
        /// 串收费明细表的id
        /// </summary>
        /// <returns></returns>
        private string getCliniCostdetIds()
        {
            string rcpdetIds = "";
            for (int i = 0; i < dgvClinicRcp0.Rows.Count; i++)
            {
                if (dgvClinicRcp0.Rows[i].Cells["text2"].Value.ToString()!="" && dgvClinicRcp0.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    rcpdetIds += dgvClinicRcp0.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            if (!String.IsNullOrEmpty(rcpdetIds))

                rcpdetIds = rcpdetIds.Substring(0, rcpdetIds.Length - 1);
            return rcpdetIds;
        }
        
        /// <summary>
        /// 串收费主表的id
        /// </summary>
        /// <returns></returns>
        private string getCliniCostIds()
        {
            string rcpdetIds = "";
            DataTable dt = bllUnlockRcp.getCliniCostIds(getCliniCostdetIds());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rcpdetIds += dt.Rows[i]["id"].ToString() + ",";
            }
            if (!String.IsNullOrEmpty(rcpdetIds))
            {
                rcpdetIds = rcpdetIds.Substring(0, rcpdetIds.Length - 1);
            }
            return rcpdetIds;
        }
        /// <summary>
        /// 触发收费主表数据的复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCliniCost_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCliniCost.IsCurrentCellDirty)
            {
                dgvCliniCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        /// <summary>
        /// 主表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCliniCost_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvClinicRcp0.Columns.Clear();
            loadDgvClinicRcp0(getDgvData());
        }
        /// <summary>
        /// 明细改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicRcp0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double amount = 0;
            for (int i = 0; i < dgvClinicRcp0.Rows.Count; i++)
            {
                if (dgvClinicRcp0.Rows[i].Cells["text2"].Value != null && dgvClinicRcp0.Rows[i].Cells["text2"].Value.ToString() != "处方号：" && dgvClinicRcp0.Rows[i].Cells["checkrcp"].Value !=null&& dgvClinicRcp0.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE"
                    && dgvClinicRcp0.Rows[i].Cells["num"].Value != null && dgvClinicRcp0.Rows[i].Cells["prc"].Value !=null)
                {
                    string num = dgvClinicRcp0.Rows[i].Cells["num"].Value.ToString();
                    double num1 = double.Parse(num);
                    string prc = dgvClinicRcp0.Rows[i].Cells["prc"].Value.ToString();
                    double prc1 = double.Parse(prc);
                    amount += num1 * prc1;
                }
            }
            tbxAmount.Text = DataTool.FormatData(amount.ToString(), "2");
        }

        private void cbxAllcheck_CheckStateChanged(object sender, EventArgs e)
        {
            allCheckChange();
        }
        /// <summary>
        /// 明細表数据的复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicRcp0_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCliniCost.IsCurrentCellDirty)
            {
                dgvCliniCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
