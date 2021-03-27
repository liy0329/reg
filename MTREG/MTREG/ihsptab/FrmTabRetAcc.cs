using System;
using System.Windows.Forms;
using MTREG.ihsp.bo;
using MTREG.ihsp.bll;
using MTREG.ihsptab.bll;
using MTREG.ihsptab.bo;
using MTHIS.main.bll;

namespace MTREG.ihsptab
{
    public partial class FrmTabRetAcc : Form
    {
        public FrmTabRetAcc()
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

        private void FrmTabRetAcc_Load(object sender, EventArgs e)
        {
            lblBillcode.Text = "确定要回退住院日结 ： 开始：" + ihsptab.Startdate + " , 结束:" + ihsptab.Enddate + "？";
        } 
    }
}
