using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.common;

namespace MTREG.clinic
{
    public partial class FrmRechargedet : Form
    {
        public FrmRechargedet()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable dataTable = new DataTable();
        public string member_id = "";

        private void FrmRechargedet_Load(object sender, EventArgs e)
        {
            
            this.dtp_begin.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).AddMonths(-1).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtp_end.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            getSource();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="?"></param>
        public void getSource()
        {
            BillMember billMember=new BillMember();
            dt = billMember.memIdSearch(member_id);
            if (dt.Rows.Count > 0)
            {
                lblId.Text = dt.Rows[0]["hspcard"].ToString();
                lblIdcard.Text = dt.Rows[0]["idcard"].ToString();
                lblName.Text = dt.Rows[0]["name"].ToString();
                switch (dt.Rows[0]["sex"].ToString())
                {
                    case "M": this.lblSex.Text = "男"; break;
                    case "W": this.lblSex.Text = "女"; break;
                    case "U": this.lblSex.Text = "未知"; break;
                }
                lblHomeaddress.Text = dt.Rows[0]["homeaddress"].ToString();
                lblBalance.Text = dt.Rows[0]["balance"].ToString();
                lblMobile.Text = dt.Rows[0]["mobile"].ToString();
                lblProfession.Text = dt.Rows[0]["profession"].ToString();
                dataTable = billMember.memRechargedet(dt.Rows[0]["id"].ToString(), dtp_begin.Value.ToString(), dtp_end.Value.ToString());
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string opertype = dataTable.Rows[i]["opertype"].ToString();
                    switch (opertype)
                    {
                        case "EN": dataTable.Rows[i]["opertype"] = "取现"; break;
                        case "RE": dataTable.Rows[i]["opertype"] = "充值"; break;
                        case "CO": dataTable.Rows[i]["opertype"] = "消费"; break;
                    }
                }
                dgvRechargedet.DataSource = dataTable;
                #region dgv标题设置
                this.dgvRechargedet.Columns["operatdate"].HeaderText = "操作日期";
                this.dgvRechargedet.Columns["operatdate"].Width = 150;
                this.dgvRechargedet.Columns["opertype"].HeaderText = "操作名称";
                this.dgvRechargedet.Columns["opertype"].Width = 125;
                this.dgvRechargedet.Columns["amount"].HeaderText = "操作金额";
                this.dgvRechargedet.Columns["amount"].Width = 120;
                this.dgvRechargedet.Columns["balance"].HeaderText = "余额";
                this.dgvRechargedet.Columns["balance"].Width = 130;
                this.dgvRechargedet.Columns["paytype"].HeaderText = "付款方式";
                this.dgvRechargedet.Columns["paytype"].Width = 130;
                #endregion
                dgvRechargedet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRechargedet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvRechargedet.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvRechargedet.RowHeadersDefaultCellStyle.Font, rectangle, dgvRechargedet.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            PrintService PrintService = new PrintService();
            PrintService.StartPrint(PrintService.WriteTxt(dt, dataTable), "txt");
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            getSource();
        }
    }
}
