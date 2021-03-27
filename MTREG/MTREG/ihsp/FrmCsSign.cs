using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.common;

namespace MTREG.ihsp
{
    public partial class FrmCsSign : Form
    {
        BillIhspcost billIhspcost = new BillIhspcost();
        string ihspid;
        public FrmCsSign()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取出院窗口数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id)
        {
            this.ihspid = id;
            DataTable dt=billIhspcost.ihspIdSearch(ihspid);
            if (dt.Rows.Count > 0)
            {
                this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
                this.lblName.Text = dt.Rows[0]["ihspcode"].ToString();
                this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
                this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
                this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
                this.lblPrepamt.Text = DataTool.FormatData(dt.Rows[0]["prepamt"].ToString(), "2");
                this.lblFeeamt.Text = DataTool.FormatData(dt.Rows[0]["feeamt"].ToString(), "2");
                this.lblSex.Text = dt.Rows[0]["sex"].ToString();
                this.lblAge.Text = dt.Rows[0]["age"].ToString();
                DateTime start = Convert.ToDateTime(this.lblIndate.Text);
                DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
                TimeSpan day = end.Subtract(start);
                this.lblIhspDay.Text = day.Days.ToString();
                if (lblPrepamt.Text == "")
                {
                    lblPrepamt.Text = "0.00";
                }
                if (lblFeeamt.Text == "")
                {
                    lblFeeamt.Text = "0.00";
                }
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            BillIhspAct billIhspAct = new BillIhspAct();
            int flag=billIhspAct.upIhsp(ihspid, "REG",ProgramGlobal.User_id ,BillSysBase.currDate());
            if (flag < 0)
            {
                MessageBox.Show("更新失败!","提示信息");
                return;
            }
            this.Close();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
