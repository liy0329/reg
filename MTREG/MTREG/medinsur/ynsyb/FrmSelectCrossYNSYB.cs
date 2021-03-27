using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.ynsyb
{
    public partial class FrmSelectCrossYNSYB : Form
    {
        public FrmSelectCrossYNSYB()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 三目录对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemCross_Click(object sender, EventArgs e)
        {
            FrmItemcrossYNSYB frmItemcross = new FrmItemcrossYNSYB();
            frmItemcross.ShowDialog();
        }
        /// <summary>
        /// 医药项目对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemfrom_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 药品分类对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrugtype_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 财务分类对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemtype_Click(object sender, EventArgs e)
        {

        }
    }
}
