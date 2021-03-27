using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.common;

namespace MTREG.clinic
{
    public partial class FrmMemCardstatLock : Form
    {
        string memid;
        public FrmMemCardstatLock()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取会员信息
        /// </summary>
        public void getSource(string id)
        {
            this.memid = id;
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                lblHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                lblName.Text = dt.Rows[0]["name"].ToString();
                lblIdcard.Text = dt.Rows[0]["idcard"].ToString();
                lblBalance.Text = dt.Rows[0]["balance"].ToString();
            }
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

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //BillMember billMember = new BillMember();
            //string cardstat = MemberCardStat.LOCK.ToString();
            //int flag=billMember.upMemBalanceSta(memid, cardstat);
            //flag=billMember.upMemSta(memid, cardstat);
            //if (flag < 0)
            //{
            //    MessageBox.Show("修改失败!","提示信息");
            //    return;
            //}
            //MessageBox.Show("冻结成功!");
        }
    }
}
