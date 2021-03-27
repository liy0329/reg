using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.clinic.bo;
using MTREG.common;
using MTREG.clinic.bll;
using System.Text.RegularExpressions;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.hdyb;

namespace MTREG.clinic
{
    public partial class FrmMemEn : Form
    {
        int flag;
        public FrmMemEn()
        {
            InitializeComponent();
        }
        string member_id;
        /// <summary>
        /// 获取会员信息
        /// </summary>
        public void getSource(string id)
        {
            member_id = id;
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                lblHspCard.Text = dt.Rows[0]["hspcard"].ToString();
                lblName.Text = dt.Rows[0]["name"].ToString();
                lblIdcard.Text = dt.Rows[0]["idcard"].ToString();
                tbxNowBalance.Text = dt.Rows[0]["balance"].ToString();
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 取现金额改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxEnFee_TextChanged(object sender, EventArgs e)
        {
            if (tbxEnFee.Text == ".")
            {
                tbxEnFee.Text = "0.";
                tbxEnFee.SelectionStart = tbxEnFee.Text.Length;
            }
            if (tbxNowBalance.Text == "")
            {
                tbxNowBalance.Text = "0";
            }
            if (string.IsNullOrEmpty(tbxEnFee.Text))
            {
                return;
            }
            if (!Regex.IsMatch(tbxEnFee.Text, @"(\d+(\.\d+)?)"))
            {
                MessageBox.Show("取现金额填写格式不正确!", "提示信息");
                tbxEnFee.Focus();
                tbxEnFee.Clear();
                return;
            }
            if (double.Parse(tbxNowBalance.Text) < double.Parse(tbxEnFee.Text))
            {
                MessageBox.Show("取现金额不能大于当前金额!", "提示信息");
                tbxEnFee.Focus();
                tbxEnFee.Clear();
                return;
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAftBalance.Text))
            {
                MessageBox.Show("请在取现金额处回车获取操作后金额后再点击确定!", "提示信息");
                tbxEnFee.Focus();
                return;
            }
            okMethod();
        }

        /// <summary>
        /// 取现方法
        /// </summary>
        private void okMethod()
        {
            MemRechargedet memRechargedet = new MemRechargedet();
            memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
            memRechargedet.Operatdate = BillSysBase.currDate();
            memRechargedet.Operatorid = ProgramGlobal.User_id;
            memRechargedet.depart_id = ProgramGlobal.Depart_id;
            memRechargedet.Opertype = MemberRechargeType.EN.ToString();
            memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
            memRechargedet.Amount = "-" + tbxEnFee.Text;
            memRechargedet.Bas_member_id = member_id;
            memRechargedet.Balance = tbxAftBalance.Text;
            memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();

            BillMember billMember = new BillMember();
            //sql
            string fee_sql = billMember.inMemBalancedet(memRechargedet);
            fee_sql += billMember.upMemBalance(member_id, tbxAftBalance.Text);

            BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
            if (bllRecipelCharge.doExeSql(fee_sql) < 0)
            {
                MessageBox.Show("添加充值记录失败！");
                SysWriteLogs.writeLogs1("添加充值记录错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), fee_sql);
                return;
            }
            if ((MessageBox.Show("退卡成功！是否打印", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                MemberPrint(member_id);
            }
            
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private void MemberPrint(string id)
        {
            Member member = new Member();
            BillMember billMember = new BillMember();
            member.Hspcard = lblHspCard.Text;
            member.Cardstat = MemberCardStat.YES.ToString();
            DataTable dt = billMember.memRechargedets(id);
            int index = dt.Rows.Count - 1;
            string in_zfc1 = "|";
            in_zfc1 += lblName.Text + "|";//姓名
            in_zfc1 += dt.Rows[index]["sex1"].ToString() + "|";//性别
            in_zfc1 += lblHspCard.Text + "|";//卡号
            in_zfc1 += cmbPayType.Text + "|";//支付方式
            in_zfc1 += "自费" + "|";//费别  默认为自费
            in_zfc1 += Double.Parse(dt.Rows[index]["amount"].ToString()).ToString("0.00") + "元|";//交款金额
            money n = new money(0 - DataTool.Getdouble(dt.Rows[index]["amount"].ToString()));
            in_zfc1 += "负" + n.Convert() + "|";
            in_zfc1 += Double.Parse(dt.Rows[index]["balance"].ToString()).ToString("0.00") + "元|";//卡内余额
            in_zfc1 += ProgramGlobal.User_id + "|";//收款人
            in_zfc1 += DateTime.Now + "|";//交款日期
            FrmDy hyddy = new FrmDy();
            hyddy.in_zfc = in_zfc1;
            hyddy.dy("mzzfyjj");
            MessageBox.Show("打印金额成功！");
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMemEn_Load(object sender, EventArgs e)
        {
            BllMemberReg bllMemberReg = new BllMemberReg();
            DataTable dtPayType = bllMemberReg.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 1;
            }
            tbxNowBalance.ReadOnly = true;
            tbxAftBalance.ReadOnly = true;
            tbxEnFee.Focus();
        }

        private void tbxEnFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enfee = "0.00";
                if (tbxEnFee.Text == "")
                {
                    enfee = "0.00";
                }
                else
                {
                    enfee = tbxEnFee.Text;
                    if (double.Parse(DataTool.FormatData(tbxEnFee.Text, "2")) > double.Parse(DataTool.FormatData(tbxNowBalance.Text, "2")))
                    {
                        MessageBox.Show("取现金额不能大于卡内余额!");
                        tbxEnFee.Clear();
                        return;
                    }
                }
                double fee = double.Parse(DataTool.FormatData(tbxNowBalance.Text, "2")) - double.Parse(DataTool.FormatData(enfee, "2"));
                this.tbxAftBalance.Text = DataTool.FormatData(fee.ToString(), "2");
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                okMethod();
            }
        }
        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
        }
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
        }
        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is Button) && (keyData == Keys.Enter))
            {
                if (ActiveControl == btnCancel)
                {
                    this.tbxEnFee.Focus();
                    return base.ProcessDialogKey(keyData);
                }
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
