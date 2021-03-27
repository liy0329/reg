using System;
using System.Data;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsp.bll;

namespace MTREG.ihsp
{
    public partial class FrmUnlocked : Form
    {
        BillIhspAct billIhspAct = new BillIhspAct();
        string thisid;
        int flag;
        public FrmUnlocked()
        {
            InitializeComponent();
        }
         /// <summary>
        /// 从frmapprover中获取数据
        /// </summary>
        /// <param name="source"></param>
        public void getAppSource(string id)
        {
            this.thisid = id;
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt= billIhspcost.ihspIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {
                this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
                this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
                this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
                this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
                this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd"); ;
                this.lblPrepamt.Text = DataTool.FormatData(dt.Rows[0]["prepamt"].ToString(), "2");
                this.lblFeeamt.Text = DataTool.FormatData(dt.Rows[0]["feeamt"].ToString(), "2");
                double payamt = double.Parse(DataTool.FormatData(dt.Rows[0]["balanceamt"].ToString(), "2"));
                if (payamt > 0)
                {
                    this.lblInBalanceamt.Text = DataTool.FormatData(payamt.ToString(), "2");
                }
                if (payamt < 0)
                {
                    this.lblInBalanceamt.Text = DataTool.FormatData((-payamt).ToString(), "2");
                    this.lblOutBalanceamt.Text = "0.00";
                }
                else
                {
                    this.lblOutBalanceamt.Text = DataTool.FormatData(payamt.ToString(), "2");
                    this.lblInBalanceamt.Text = "0.00";
                }
                this.lblSex.Text = dt.Rows[0]["sex"].ToString();
                this.lblAge.Text = dt.Rows[0]["age"].ToString();
                DateTime start = Convert.ToDateTime(this.lblIndate.Text);
                DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
                TimeSpan day = end.Subtract(start);
                this.lblIhspDay.Text = day.Days.ToString();
                this.lblInvoice.Text = dt.Rows[0]["invoicecode"].ToString();
            }
        }

        /// <summary>
        /// 审批按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApprove_Click(object sender, EventArgs e)
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            string unlocked="Y";
            string unlockby=ProgramGlobal.User_id;
            flag = billIhspAct.upIhspApp(thisid, unlocked, unlockby);
            if(flag<0)
            {
                MessageBox.Show("修改审批状态失败");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
