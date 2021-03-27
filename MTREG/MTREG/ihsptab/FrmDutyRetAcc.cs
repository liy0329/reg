using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsptab.bll;
using MTREG.ihsptab.bo;
using MTHIS.main.bll;

namespace MTREG.ihsptab
{
    public partial class FrmDutyRetAcc : Form
    {
        public FrmDutyRetAcc()
        {
            InitializeComponent();
        }
        Ihsptab ihsptab = new Ihsptab();

        internal Ihsptab Ihsptab
        {
            get { return ihsptab; }
            set { ihsptab = value; }
        }
        BllIhsptab billIhsptab = new BllIhsptab();

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
           
           
            this.DialogResult = DialogResult.OK;
           
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDutyRetAcc_Load(object sender, EventArgs e)
        {
            lblBillcode.Text = "确定要回退班结 ： 开始：" + ihsptab.Startdate + " , 结束:" + ihsptab.Enddate + "？";
        }        
    }
}
