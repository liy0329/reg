using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.bll;
using MTREG.idcard.bll;
using MTREG.ihsp;
namespace MTREG.medinsur
{
    public partial class FrmIdCard : Form
    {
        FrmIhspReg frmIhspReg;

        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }
        public FrmIdCard()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.FrmIhspReg.IdCardInfo.Homeaddress = tbxHomeaddress.Text;
            this.FrmIhspReg.IdCardInfo.Sex = tbxSex.Text;
            this.FrmIhspReg.IdCardInfo.Race = tbxRace.Text;
            this.FrmIhspReg.IdCardInfo.Birth = dtpBirth.Text;
            this.FrmIhspReg.IdCardInfo.Name = tbxName.Text;
            this.FrmIhspReg.IdCardInfo.Idcard = tbxIDCard.Text;
            this.FrmIhspReg.IdCardInfo.Birth = dtpBirth.Value.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntq_Click(object sender, EventArgs e)
        {
            IdCardInfo idCardInfo = new IdCardInfo();
            idCardInfo.readInsurCard();
            tbxIDCard.Text = idCardInfo.Idcard; ;
            tbxName.Text = idCardInfo.Name;
            tbxRace.Text = idCardInfo.Race;
            tbxSex.Text = idCardInfo.Sex;
            tbxHomeaddress.Text = idCardInfo.Homeaddress;
            tbxSex.Text = idCardInfo.Sex;
            dtpBirth.Value = Convert.ToDateTime(idCardInfo.Birth);
        }


    }
}
