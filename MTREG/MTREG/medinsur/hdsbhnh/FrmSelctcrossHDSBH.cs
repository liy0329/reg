using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmSelctcrossHDSBH : Form
    {
        public FrmSelctcrossHDSBH()
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


        private void btnItemfrom_Click(object sender, EventArgs e)
        {
            FrmItemFromSbh frmItemFromSbh = new FrmItemFromSbh();
            frmItemFromSbh.Insurtype_id = Insurtype_id;
            frmItemFromSbh.ShowDialog();
        }

        private void btnDrugtype_Click(object sender, EventArgs e)
        {
            FrmDrugTyprSbh frmDrugTyprSbh = new FrmDrugTyprSbh();
            frmDrugTyprSbh.Insurtype_id = Insurtype_id;
            frmDrugTyprSbh.ShowDialog();
        }
        /// <summary>
        /// 财务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemtype_Click(object sender, EventArgs e)
        {
            FrmItemTypeSbh frmItemTypeSbh = new FrmItemTypeSbh();
            frmItemTypeSbh.Insurtype_id = Insurtype_id;
            frmItemTypeSbh.ShowDialog();
        }

        private void btnItemCross_Click(object sender, EventArgs e)
        {
            FrmItemcrossHDSBH frmItemcrossHDSBH = new FrmItemcrossHDSBH();
            frmItemcrossHDSBH.ShowDialog();
        }

    }
}
