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
using MTHIS.common;
namespace MTREG.medinsur
{
    public partial class FrmClinicIdCard : Form
    {
        public FrmClinicIdCard()
        {
            InitializeComponent();
        }
        FrmClinicReg frmRegister ;

        public FrmClinicReg FrmRegister
        {
            get { return frmRegister; }
            set { frmRegister = value; }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOkClick();
        }
        private void btnOkClick()
        {
            //this.FrmRegister.IdCardInfo.Homeaddress = tbxHomeaddress.Text;
            //this.FrmRegister.IdCardInfo.Sex = tbxSex.Text;
            //this.FrmRegister.IdCardInfo.Race = tbxRace.Text;
            //this.FrmRegister.IdCardInfo.Birth = dtpBirth.Text;
            //this.FrmRegister.IdCardInfo.Name = tbxName.Text;
            //this.FrmRegister.IdCardInfo.Idcard = tbxIDCard.Text;
            //this.frmRegister.InsurInfo.Birth = dtpBirth.Value.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntq_Click(object sender, EventArgs e)
        {
            btntqClick();
        }
        private void btntqClick()
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
        /// <summary>
        /// 当点击回车键时，焦点在控件中一次传递
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (( ActiveControl is Button) && keyData == Keys.Enter)
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btntq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                btntqClick();
            }
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                btnOkClick();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                this.Close();
            }
        }

    }
}
