using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdxbhnh;

namespace MTREG.medinsur.hdxbhnh
{
    public partial class FrmSelectCrossXBH : Form
    {
        public FrmSelectCrossXBH()
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
        private void btnItemCross_Click(object sender, EventArgs e)
        {
            FrmItemcrossXBH frmItemcross = new FrmItemcrossXBH();
            frmItemcross.ShowDialog();

        }

        private void btnItemfrom_Click(object sender, EventArgs e)
        {
            FrmItemfromXBH frmItemfromXBH = new FrmItemfromXBH();
            frmItemfromXBH.Insurtype_id = Insurtype_id;
            frmItemfromXBH.ShowDialog();
        }

        private void btnDrugtype_Click(object sender, EventArgs e)
        {
            FrmDrugTypeXBH frmDrugTypeXBH = new FrmDrugTypeXBH();
            frmDrugTypeXBH.Insurtype_id = Insurtype_id;
            frmDrugTypeXBH.ShowDialog();
        }
        /// <summary>
        /// 财务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemtype_Click(object sender, EventArgs e)
        {
            FrmItemTypeXBH frmItemTypeXBH = new FrmItemTypeXBH();
            frmItemTypeXBH.Insurtype_id = Insurtype_id;
            frmItemTypeXBH.ShowDialog();
        }
    }
}
