using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.sys.bll;
using MTHIS.common;


namespace MTHIS.sys
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pwdOld = this.tbxPwdOld.Text;
            string pwd = this.tbxPwd.Text;
            string reset = this.tbxPwdReset.Text;
            if (pwdOld == null || "".Equals(pwdOld))
            {
                MessageBox.Show("原密码不能为空！");
                this.tbxPwdOld.Focus();
                return;
            }
            if (pwd == null || "".Equals(pwd))
            {
                MessageBox.Show("密码不能为空！");
                this.tbxPwd.Focus();
                return;
            }
            if (!pwd.Equals(reset))
            {
                MessageBox.Show("新密码和输入密码必须一致，请重新填写！");
                this.tbxPwdOld.Text = "";
                this.tbxPwd.Text = "";
                this.tbxPwdReset.Text = "";
                this.tbxPwdReset.Focus();
                return;
            }
            BllAccount bllAccount = new BllAccount();
            DataTable dataTablePawd = new DataTable();
            dataTablePawd = bllAccount.findAccountById(int.Parse(ProgramGlobal.Account_id));
            string pwdOldSql = dataTablePawd.Rows[0]["passwd"].ToString();
            if (pwdOldSql != pwdOld)
            {
                MessageBox.Show("输入的原密码有误！");
                this.tbxPwdOld.Text = "";
                this.tbxPwd.Text = "";
                this.tbxPwdReset.Text = "";
                this.tbxPwdOld.Focus();
                return;
            }
            int r = bllAccount.setPwd(this.tbxPwd.Text, int.Parse(ProgramGlobal.User_id));
            if (r == -1)
            {
                MessageBox.Show("修改密码失败！");
            }
            else
            {
                MessageBox.Show("修改密码成功！");
            }
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && !(ActiveControl is Button))
            {//碰到Button时不跳转到下一个控件，而是执行Button的单击事件
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
