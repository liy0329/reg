using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmSelectCrossHSDR : Form
    {
        public FrmSelectCrossHSDR()
        {
            InitializeComponent();
        }
        private string insurtype_id;
        /// <summary>
        /// 医保类型
        /// </summary>
        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }
        /// <summary>
        /// 三目录对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemCross_Click(object sender, EventArgs e)
        {
            FrmItemcrossHSDR frmItemcrossHSDR = new FrmItemcrossHSDR();
            frmItemcrossHSDR.Insurtype_id = Insurtype_id;
            frmItemcrossHSDR.ShowDialog();
        }
        /// <summary>
        /// 病种信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiseaseCase_Click(object sender, EventArgs e)
        {
            FrmDiseaseCaseHSDR frmDiseaseCaseHSDR = new FrmDiseaseCaseHSDR();
            frmDiseaseCaseHSDR.Insurtype_id = Insurtype_id;
            frmDiseaseCaseHSDR.ShowDialog();
        }
        /// <summary>
        /// 医药代码对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrugCross_Click(object sender, EventArgs e)
        {
            FrmDrugTypeHSDR frmDrugTypeHSDR = new FrmDrugTypeHSDR();
            frmDrugTypeHSDR.Insurtype_id = Insurtype_id;
            frmDrugTypeHSDR.ShowDialog();
        }
    }
}
