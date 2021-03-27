using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.gzsnh
{
    public partial class FrmGzsnhSelectCross : Form
    {
        public FrmGzsnhSelectCross()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmUpDateDisease frmUpDateDisease = new FrmUpDateDisease();
            frmUpDateDisease.ShowDialog();
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            FrmTreatment frmTreatment = new FrmTreatment();
            frmTreatment.ShowDialog();
        }
    }
}
