using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using MTREG.common;
using MTHIS.common;
using MTREG.common.bll;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.gzsyb;

namespace MTREG.clinic
{
    public partial class FrmNocard : Form
    {
        int flag;
        string member_id;
        
        public FrmNocard()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// 是否有卡
        /// </summary>
        public bool userfare { get; set; }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNocard_Load(object sender, EventArgs e)
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
            checkBox1.Checked = userfare;
        }
        /// <summary>
        /// 获取会员信息
        /// </summary>
        public void getSource(string id)
        {
            this.member_id = id;
            BillMember billMember = new BillMember();
            DataTable dt = billMember.memIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                lblHspCard.Text = dt.Rows[0]["hspcard"].ToString();
                lblName.Text = dt.Rows[0]["name"].ToString();
                lblIdcard.Text = dt.Rows[0]["idcard"].ToString();

                Balance = Double.Parse(dt.Rows[0]["balance"].ToString());
                lblBalance.Text = (Balance + 2).ToString("0.00");
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
            BillMember billMember = new BillMember();
            string usehspcard = "N";
            
            string fee_sql = "";
            MemRechargedet memRechargedet = new MemRechargedet();
            if (checkBox1.Checked == true)
            {
                memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedet.Operatdate = BillSysBase.currDate();
                memRechargedet.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedet.Opertype = MemberRechargeType.CO.ToString();
                memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedet.Amount = "2";
                memRechargedet.Balance = lblBalance.Text;
                memRechargedet.Bas_member_id = member_id;
                memRechargedet.Paytype_id = "20";
                fee_sql = billMember.inMemBalancedet(memRechargedet);
            }

            memRechargedet = new MemRechargedet();
            memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();
            memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
            memRechargedet.Operatdate = BillSysBase.currDate();
            memRechargedet.Operatorid = ProgramGlobal.User_id;
            memRechargedet.depart_id = ProgramGlobal.Depart_id;
            memRechargedet.Opertype = MemberRechargeType.EN.ToString();
            memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
            memRechargedet.Amount = "-" + lblBalance.Text;
            memRechargedet.Balance = "0";
            memRechargedet.Bas_member_id = member_id;
            memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();
            fee_sql += billMember.inMemBalancedet(memRechargedet);

            fee_sql += billMember.upMemBalance(member_id, "0.00");
            fee_sql += billMember.upMemHspcard(member_id, usehspcard);
            BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
            if (bllRecipelCharge.doExeSql(fee_sql) < 0)
            {
                MessageBox.Show("退卡失败！");
                SysWriteLogs.writeLogs1("退卡错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), fee_sql);
                return;
            }
            if ((MessageBox.Show("退卡成功！是否打印", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                MemberPrint(member_id);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            in_zfc1 += cmbPayType.Text + "|";//费别  默认为自费
            in_zfc1 += Double.Parse(dt.Rows[index]["amount"].ToString()).ToString("0.00") + "元|";//交款金额
            money n = new money(0-DataTool.Getdouble(dt.Rows[index]["amount"].ToString()));
            in_zfc1 += "负"+n.Convert() + "|";
            in_zfc1 += Double.Parse(dt.Rows[index]["balance"].ToString()).ToString("0.00") + "元|";//卡内余额
            in_zfc1 += ProgramGlobal.User_id + "|";//收款人
            in_zfc1 += DateTime.Now + "|";//交款日期
            FrmDy hyddy = new FrmDy();
            hyddy.in_zfc = in_zfc1;
            hyddy.dy("mzzfyjj");
            MessageBox.Show("打印金额成功！");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.lblBalance.Text = (Balance + 2).ToString("0.00");
            }
            else
            {
                this.lblBalance.Text = (Balance).ToString("0.00");
            }
        }
    }
}
