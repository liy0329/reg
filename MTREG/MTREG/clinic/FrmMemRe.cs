using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using MTREG.common;
using System.Text.RegularExpressions;
using MTREG.common.bll;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.gzsyb;

namespace MTREG.clinic
{
    public partial class FrmMemRe : Form
    {
        int flag;
        string member_id;
        public FrmMemRe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        public void getSource(string id)
        {
            member_id = id;
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memIdSearch(id);
            if(dt.Rows.Count>0)
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
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPayType.SelectedValue == null || cmbPayType.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("请选择支付方式!", "提示信息");
                cmbPayType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxAftBalance.Text))
            {
                MessageBox.Show("请在充值金额处回车获取操作后金额后再点击确定!","提示信息");
                tbxReFee.Focus();
                return;
            }
            okMethod();
        }
        
        private void okMethod()
        {
            MemRechargedet memRechargedet = new MemRechargedet();
            memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
            memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
            memRechargedet.Operatdate = BillSysBase.currDate();
            memRechargedet.Operatorid = ProgramGlobal.User_id;
            memRechargedet.depart_id = ProgramGlobal.Depart_id;
            memRechargedet.Opertype = "RE";
            memRechargedet.Amount = tbxReFee.Text;
            memRechargedet.Bas_member_id = member_id;
            memRechargedet.Balance = tbxAftBalance.Text;
            memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();
            BillMember billMember = new BillMember();

            string fee_sql = billMember.inMemBalancedet(memRechargedet);
            fee_sql += billMember.upMemBalance(member_id, tbxAftBalance.Text);

            BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
            if (bllRecipelCharge.doExeSql(fee_sql) < 0)
            {
                MessageBox.Show("修改会员卡失败！");
                SysWriteLogs.writeLogs1("修改会员卡错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), fee_sql);
                return;
            }
            //会员充值打印
            
            if ((MessageBox.Show("充值成功！是否打印", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                MemberPrint();
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMemRe_Load(object sender, EventArgs e)
        {
            BllMemberReg bllMemberReg = new BllMemberReg();
            DataTable dtPayType = bllMemberReg.payPaytypeListWithNull();//bllMemberReg.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 1;
            }
            tbxNowBalance.ReadOnly = true;
            tbxAftBalance.ReadOnly = true;
            tbxReFee.Focus();
        }

        /// <summary>
        /// 缴款金额改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxReFee_TextChanged(object sender, EventArgs e)
        {
            if (tbxReFee.Text == ".")
            {
                tbxReFee.Text = "0.";
                tbxReFee.SelectionStart = tbxReFee.Text.Length;
            }
            if (string.IsNullOrEmpty(tbxReFee.Text))
            {
                tbxAftBalance.Clear();
                return;
            }
            if (!Regex.IsMatch(tbxReFee.Text, @"(\d+(\.\d+)?)"))
            {
                MessageBox.Show("充值金额填写格式不正确!", "提示信息");
                tbxReFee.Focus();
                tbxReFee.Clear();
                tbxAftBalance.Clear();
                return;
            }
            //计算充值后余额
            getAftBalance();
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void MemberPrint()
        {

            Member member = new Member();
            BillMember billMember = new BillMember();
            member.Hspcard = lblHspCard.Text;
            //member.Cardstat = MemberCardStat.YES.ToString();
            DataTable dt = billMember.memberSearch(member, "","");
            
            
            string in_zfc1 = "|";
            in_zfc1 += lblName.Text + "|";//姓名
            in_zfc1 += dt.Rows[0]["sex"].ToString() + "|";//性别
            in_zfc1 += lblHspCard.Text + "|";//卡号
            in_zfc1 += cmbPayType.Text + "|";//支付方式
            in_zfc1 += cmbPayType.Text + "|";//费别  默认为自费
            in_zfc1 += Double.Parse( tbxReFee.Text).ToString("0.00") + "元|";//交款金额
            money n = new money(DataTool.Getdouble(tbxReFee.Text));
            in_zfc1 += n.Convert() + "|";
            in_zfc1 += Double.Parse( tbxAftBalance.Text).ToString("0.00") + "|";//卡内余额
            in_zfc1 += ProgramGlobal.User_id + "|";//收款人
            in_zfc1 += DateTime.Now + "|";//交款日期
            FrmDy hyddy = new FrmDy();
            hyddy.in_zfc = in_zfc1;
            hyddy.dy("mzzfyjj");
            MessageBox.Show("打印金额成功！");
        }
        /// <summary>
        /// 计算充值后余额
        /// </summary>
        private void getAftBalance()
        {
            string refee = "0.00";
            string nowBalance = "0.00";
            if (tbxReFee.Text == "")
            {
                refee = "0.00";
            }
            else
            {
                refee = tbxReFee.Text;
            }
            if (tbxNowBalance.Text == "")
            {
                nowBalance = "0.00";
            }
            else
            {
                nowBalance = tbxNowBalance.Text;
            }

            double retfee = double.Parse(DataTool.FormatData(refee, "2")) + double.Parse(DataTool.FormatData(nowBalance, "2"));
            this.tbxAftBalance.Text = DataTool.FormatData(retfee.ToString(), "2");
        }

        private void tbxReFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 20201117修改前
                //string refee = "0.00";
                //string nowBalance="0.00";
                //if (tbxReFee.Text == "")
                //{
                //    refee = "0.00";
                //}
                //else
                //{
                //    refee = tbxReFee.Text;
                //}
                //if (tbxNowBalance.Text == "")
                //{
                //    nowBalance = "0.00";
                //}
                //else
                //{
                //    nowBalance = tbxNowBalance.Text;
                //}
                
                //double retfee = double.Parse(DataTool.FormatData(refee, "2")) + double.Parse(DataTool.FormatData(nowBalance, "2"));
                //this.tbxAftBalance.Text = DataTool.FormatData(retfee.ToString(), "2");
                #endregion
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                okMethod();
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
                    this.tbxReFee.Focus();
                    return base.ProcessDialogKey(keyData);
                }
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
