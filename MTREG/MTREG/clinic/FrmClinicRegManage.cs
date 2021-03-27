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
using MTREG.common;
using MTHIS.common;

namespace MTREG.clinic
{
    public partial class FrmClinicRegManage : Form
    {
        BillRegSearch billRegSearch = new BillRegSearch();
        Register register = new Register();
        public FrmClinicRegManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegSearch_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            searchMethod();            
            this.dgvRegister.ReadOnly = true;
            this.dgvRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void searchMethod()
        {
            register.Name = tbxName.Text;
            register.Hspcard = tbxHspcard.Text;
            register.Createtime = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            register.Updatetime = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            if (cbxStatus.Checked == true)
            {
                register.Status = RegisterStatus.BACK.ToString();
            }
            else
            {
                register.Status = "";
            }
            DataTable datatable = billRegSearch.regSearch(register);
            this.dgvRegister.DataSource = datatable;
            #region  dgvRegister单元格标题设置
            this.dgvRegister.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvRegister.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvRegister.Columns["billcode"].HeaderText = "门诊号";
            this.dgvRegister.Columns["billcode"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["hspcard"].HeaderText = "卡号";
            this.dgvRegister.Columns["hspcard"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["regname"].HeaderText = "姓名";
            this.dgvRegister.Columns["regname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["sex"].HeaderText = "性别";
            this.dgvRegister.Columns["sex"].Width = (int)(70 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["age"].HeaderText = "年龄";
            this.dgvRegister.Columns["age"].Width = (int)(70 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["ageunit"].HeaderText = "";
            this.dgvRegister.Columns["ageunit"].Width = (int)(35 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["deparname"].HeaderText = "科室";
            this.dgvRegister.Columns["deparname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["doctorname"].HeaderText = "医生";
            this.dgvRegister.Columns["doctorname"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["chargeby"].HeaderText = "收费员";
            this.dgvRegister.Columns["chargeby"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["amount"].HeaderText = "挂号金额";
            this.dgvRegister.Columns["amount"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRegister.Columns["regdate"].HeaderText = "挂号日期";
            this.dgvRegister.Columns["regdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvRegister.Columns["regdate"].Width = (int)(110 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["status"].HeaderText = "状态";
            this.dgvRegister.Columns["status"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["prepaid"].HeaderText = "挂号方式";
            this.dgvRegister.Columns["prepaid"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvRegister.Columns["registerid"].HeaderText = "id";
            this.dgvRegister.Columns["registerid"].Visible = false;
            this.dgvRegister.Columns["clinic_invoice_id"].Visible = false;
             for (int i = 0; i < datatable.Rows.Count; i++)
            {
                if (dgvRegister.Rows[i].Cells["prepaid"].Value.ToString() == "非储值卡")
                {
                    dgvRegister.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (dgvRegister.Rows[i].Cells["prepaid"].Value.ToString() == "储值卡")
                {
                    dgvRegister.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }                
             }
            #endregion
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
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");            
            tbxHspcard.Text = "";
            tbxName.Text="";
            cbxStatus.Checked = false;
            searchMethod();
        }

        /// <summary>
        /// 更换科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepart_Click(object sender, EventArgs e)
        {
            if (dgvRegister.SelectedRows.Count == 0 && dgvRegister.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmDepart frmDepart = new FrmDepart();
            string id = dgvRegister.SelectedRows[0].Cells["registerid"].Value.ToString();
            frmDepart.getSource(id);
            frmDepart.ShowDialog();
            if (frmDepart.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }

        /// <summary>
        /// 修改信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (dgvRegister.SelectedRows.Count == 0 && dgvRegister.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmChangeInfo frmChangeInfo = new FrmChangeInfo();
            string id = dgvRegister.SelectedRows[0].Cells["registerid"].Value.ToString();
            frmChangeInfo.getSource(id);
            frmChangeInfo.ShowDialog();
            if (frmChangeInfo.DialogResult == DialogResult.OK)
            {
                searchMethod();
            }
        }

        /// <summary>
        /// 重打按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
         
            FrmReprintInvoice frmReprintInvoice = new FrmReprintInvoice();
            //     int num = dgvInvoice.ColumnCount;
            if (dgvRegister.SelectedRows.Count != 0 && dgvRegister.Rows.Count > 0)
            {
                string clinic_invoice_id = dgvRegister.SelectedRows[0].Cells["clinic_invoice_id"].Value.ToString();
                string invoice = dgvRegister.SelectedRows[0].Cells["invoice"].Value.ToString();
                frmReprintInvoice.getSource(clinic_invoice_id, invoice);
                frmReprintInvoice.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先在列表中选择!");
                return;
            }

        }

        /// <summary>
        /// 退号按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (dgvRegister.SelectedRows.Count == 0 && dgvRegister.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择!");
                return;
            }
            FrmRegBack frmRegBack = new FrmRegBack();
            string id = dgvRegister.SelectedRows[0].Cells["registerid"].Value.ToString();
            frmRegBack.getSource(id);
            frmRegBack.ShowDialog();
            if (frmRegBack.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }

        /// <summary>
        /// dgv选择内容变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRegister_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegister.SelectedRows.Count != 0 && dgvRegister.SelectedCells.Count != 0)
            {
                string status = dgvRegister.SelectedRows[0].Cells["status"].Value.ToString();
                string id = dgvRegister.SelectedRows[0].Cells["registerid"].Value.ToString();
                switch (status)
                {
                    //case "冲退": btnBack.Enabled = false;
                    //    btnChangeInfo.Enabled = false;
                    //    btnDepart.Enabled = false;
                    //    btnReprint.Enabled = false;
                    //    break;
                    case "挂号": btnBack.Enabled = true;
                        btnChangeInfo.Enabled = true;
                        btnDepart.Enabled = true;
                        btnReprint.Enabled = true;
                        break;
                    //case "已接受": btnBack.Enabled = false;
                    //    btnChangeInfo.Enabled = true;
                    //    btnDepart.Enabled = true;
                    //    btnReprint.Enabled = false;
                    //    break;
                    case "退号": btnBack.Enabled = false;
                        btnChangeInfo.Enabled = false;
                        btnDepart.Enabled = false;
                        btnReprint.Enabled = false;
                        break;
                }
                dgvCostdet.DataSource = billRegSearch.getCostdet(id);
                #region  dgvCostdet单元格标题设置
                this.dgvCostdet.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvCostdet.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvCostdet.Columns["name"].HeaderText = "名称";
                this.dgvCostdet.Columns["name"].Width = (int)(250 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["spec"].HeaderText = "规格";
                this.dgvCostdet.Columns["spec"].Width = (int)(200 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["unit"].HeaderText = "单位";
                this.dgvCostdet.Columns["unit"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["num"].HeaderText = "数量";
                this.dgvCostdet.Columns["num"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostdet.Columns["prc"].HeaderText = "单价";
                this.dgvCostdet.Columns["prc"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostdet.Columns["fee"].HeaderText = "金额";
                this.dgvCostdet.Columns["fee"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvCostdet.Columns["fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                #endregion
            }
            else 
            {
                dgvCostdet.DataSource = null;
            }

        }

        /// <summary>
        /// 挂号起始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > Convert.ToDateTime(BillSysBase.currDate()))
            {
                MessageBox.Show("起始日期不能大于当前日期");
                dtpStartTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }            
        }

        /// <summary>
        /// 截止时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0 )
            {
                MessageBox.Show("错误：截止时间应该大于起始时间 ！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                return;
            }
        }

        private void dgvRegister_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    switch (e.Value.ToString())
            //    {
            //        case "非储值卡": dgvRegister.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue; break;
            //        case "储值卡": dgvRegister.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green; break;
            //    }
            //}
        }

     

        private void tbxName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string hspCard = tbxName.Text.Trim();
                if (hspCard.Length > 2)
                {
                    hspCard = hspCard.Replace(";", "");
                    hspCard = hspCard.Replace("?", "");
                    tbxName.Text = hspCard;
                }
                if (hspCard.Trim().Equals(""))
                    return;
                this.btnSearch.Focus();
            }
        }

        private void tbxHspcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string hspCard = tbxHspcard.Text.Trim();
                if (hspCard.Length > 2)
                {
                    hspCard = hspCard.Replace(";", "");
                    hspCard = hspCard.Replace("?", "");
                    tbxHspcard.Text = hspCard;
                }
                if (hspCard.Trim().Equals(""))
                    return;
                this.btnSearch.Focus();
            }
        }

        private void btnRetCard_Click(object sender, EventArgs e)
        {
              string hspcard ="";
              string sickname = "";
             if (dgvRegister.SelectedRows.Count != 0 && dgvRegister.Rows.Count > 0)
            {
                 hspcard = dgvRegister.SelectedRows[0].Cells["hspcard"].Value.ToString();
                 sickname = dgvRegister.SelectedRows[0].Cells["regname"].Value.ToString();
            }
            if(hspcard.Substring(0,2).Equals("TK"))
            {
               MessageBox.Show("已退卡，不能在退卡！");
                return;
            }
            if(hspcard.Substring(0,2).Equals("WK"))
            {
               MessageBox.Show("无卡，不能在退卡！");
                return;
            }
            FrmRetHspCard frmRetHspCard = new FrmRetHspCard();
            frmRetHspCard.getSource(sickname, hspcard);
            frmRetHspCard.ShowDialog();
            if (frmRetHspCard.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }
    
   }
}
