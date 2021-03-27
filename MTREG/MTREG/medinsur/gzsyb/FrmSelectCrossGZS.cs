using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.gzsyb
{
    public partial class FrmSelectCrossGZS : Form
    {
        public FrmSelectCrossGZS()
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
            FrmItemcrossGZS frmItemcross = new FrmItemcrossGZS();
            frmItemcross.Insurtype_id = this.insurtype_id;
            frmItemcross.ShowDialog();
        }

        private void lblItemCross_Click(object sender, EventArgs e)
        {

        }
    }
}
