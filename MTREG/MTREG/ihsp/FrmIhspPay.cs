using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.db;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.common;
using MTREG.ihsp.bo;
using MTREG.ihsptab.bo;
using System.Text.RegularExpressions;
using MTREG.netpay;
using MTREG.netpay.bo;

namespace MTREG.ihsp
{
    public partial class FrmIhspPay : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspcost billIhspcost = new BillIhspcost();
        private string netpaytype = "-1";//网路支付类型
        private string homephone = "";
        private string idcard = "";
        private string ihspStatus = "";//住院状态
        /// <summary>
        /// 住院id
        /// </summary>
        string ihspId;
        public FrmIhspPay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取FrmIhspMan的值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="patienType"></param>
        public void getManSource(string id)
        {
            ihspId = id;
            DataTable dtman = billIhspcost.ihspIdSearch(ihspId);
            if (dtman.Rows.Count > 0)
            {
                lblIhspcode.Text = dtman.Rows[0]["ihspcode"].ToString();
                lblName.Text = dtman.Rows[0]["ihspname"].ToString();
                lblDepart.Text = dtman.Rows[0]["deparname"].ToString();
                lblPrepamt.Text = dtman.Rows[0]["prepamt"].ToString();
                lblFeeamt.Text = dtman.Rows[0]["feeamt"].ToString();
                lblHspcard.Text = dtman.Rows[0]["hspcard"].ToString();
                lblBalanceamt.Text = dtman.Rows[0]["balanceamt"].ToString();
                idcard = dtman.Rows[0]["idcard"].ToString();
                homephone = dtman.Rows[0]["homephone"].ToString();
                if (lblPrepamt.Text == "")
                {
                    lblPrepamt.Text = "0.00";
                }
                if (lblFeeamt.Text == "")
                {
                    lblFeeamt.Text = "0.00";
                }
                if (lblBalanceamt.Text == "")
                {
                    lblBalanceamt.Text = "0.00";
                }
                ihspStatus = dtman.Rows[0]["status"].ToString();
            }
            else
            {
                MessageBox.Show("未找到相关信息!");
                Close();
            }
        }

       /// <summary>
       /// 撤销预交款
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnRetChrg_Click(object sender, EventArgs e)
        {
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                Close();
            }
            retChrg();
        }
        /// <summary>
        /// 撤销预交款
        /// </summary>
        public void retChrg()
        {
            if (dgvIhspPayinadv.SelectedRows.Count == 0 && dgvIhspPayinadv.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            
            FrmIhspRetChrg frmIhspRetChrg = new FrmIhspRetChrg();
            string payid = dgvIhspPayinadv.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspRetChrg.getSource(ihspId, payid);
            frmIhspRetChrg.ShowDialog();
            if (frmIhspRetChrg.DialogResult == DialogResult.OK)
            {
                reset();
            }
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspPay_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            DataTable dt = new DataTable();
            dt = billCmbList.payPaytypeList();
            cmbPayType.ValueMember = "id";
            cmbPayType.DisplayMember = "name";
            cmbPayType.DataSource = dt;
            cmbPayType.SelectedValue = 1;

            //lblBillcode.Text = BillSysBase.newBillcode("ihsp_payinadv_billcode");
            lblBillcode.Text = BillSysBase.currBillcode("ihsp_payinadv_billcode");
            BillIhspMan billIhspMan=new BillIhspMan();
            DataTable datatable = billIhspMan.paySearch(ihspId,ihspStatus);
            dgvIhspPayinadv.DataSource = datatable;
            #region dgv标题设置
            dgvIhspPayinadv.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspPayinadv.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspPayinadv.Columns["billcode"].HeaderText = "预交款号";
            dgvIhspPayinadv.Columns["billcode"].Width = (int)(120*ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["payfee"].HeaderText = "缴款金额";
            dgvIhspPayinadv.Columns["payfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIhspPayinadv.Columns["payfee"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["paytypename"].HeaderText = "交款方式";
            dgvIhspPayinadv.Columns["paytypename"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["cheque"].HeaderText = "支票号";
            dgvIhspPayinadv.Columns["cheque"].Width = (int)(100 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["status"].HeaderText = "状态";
            dgvIhspPayinadv.Columns["status"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["doctorname"].HeaderText = "收款人";
            dgvIhspPayinadv.Columns["doctorname"].Width = (int)(80 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["chargedate"].HeaderText = "收款时间";
            dgvIhspPayinadv.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvIhspPayinadv.Columns["chargedate"].Width = (int)(180 * ProgramGlobal.WidthScale);
            dgvIhspPayinadv.Columns["id"].HeaderText = "id";
            dgvIhspPayinadv.Columns["id"].Visible = false;
            dgvIhspPayinadv.Columns["ihsp_id"].HeaderText = "ihsp_id";
            dgvIhspPayinadv.Columns["ihsp_id"].Visible = false;
            #endregion
            dgvIhspPayinadv.ReadOnly = true;
            dgvIhspPayinadv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (ihspStatus.Equals("SETT"))
            {
                //已结算病人不能交预交款
                btnAddIhspPay.Enabled = false;
                btnRetIhspPay.Enabled = false;
            }
            if (datatable.Rows.Count > 0)
            {
                if (!ihspStatus.Equals("SETT"))
                {
                    string status = dgvIhspPayinadv.Rows[0].Cells["status"].Value.ToString();
                    if (status == "计费")
                    {
                        btnRetIhspPay.Enabled = true;
                        btnRePrint.Enabled = true;
                    }
                    else
                    {
                        btnRetIhspPay.Enabled = false;
                        btnRePrint.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 获取FrmIhspCost的值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="patienType"></param>
        public void getCostSource(string id)
        {
            ihspId = id;
            DataTable dtCost = billIhspcost.ihspIdSearch(ihspId);
            lblIhspcode.Text = dtCost.Rows[0]["ihspcode"].ToString();
            lblName.Text = dtCost.Rows[0]["ihspname"].ToString();
            lblDepart.Text = dtCost.Rows[0]["deparname"].ToString();
            lblPrepamt.Text = dtCost.Rows[0]["prepamt"].ToString();
            lblFeeamt.Text = dtCost.Rows[0]["feeamt"].ToString();
            lblHspcard.Text = dtCost.Rows[0]["hspcard"].ToString();
            lblBalanceamt.Text = dtCost.Rows[0]["balanceamt"].ToString();
        }

        /// <summary>
        /// 缴费按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIhspPay_Click(object sender, EventArgs e)
        {
            if (ProgramGlobal.VersionChk == "N")
            {
                MessageBox.Show("版本已过期,请联系相关工作人员进行升级!");
                Close();
            }
            btnAddIhspPay.Enabled = false;
            doAddIhspPay();
            btnAddIhspPay.Enabled = true;
        }
        /// <summary>
        /// 缴费按钮
        /// </summary>
        public void doAddIhspPay()
        {
            if (tbxPayFee.Text.Trim() == "")
            {
                tbxPayFee.Focus();
                MessageBox.Show("缴款金额不能为空");
                return;
            }
       
            if (cmbPayType.Text.Trim() == "")
            {
                tbxPayFee.Focus();
                MessageBox.Show("缴款类型不能为空");
                return;
            }

            //网络支付业务:

            string hisOrderNo = "";
            string currDate = BillSysBase.currDate();
            //if (!doExecNetPay(currDate, ref hisOrderNo))
            //    return;
            //网络支付业务_END:

            Ihsppayinadv ihsppayinadv = new Ihsppayinadv();
            ihsppayinadv.Id = BillSysBase.nextId("ihsp_payinadv");
            ihsppayinadv.Billcode = BillSysBase.newBillcode("ihsp_payinadv_billcode");
            ihsppayinadv.Ihsp_id = ihspId;
            ihsppayinadv.Paytype = cmbPayType.SelectedValue.ToString();
            ihsppayinadv.Bas_paysumby_id = billIhspMan.getPaysumby(ihsppayinadv.Paytype);
            ihsppayinadv.Cheque = tbxCheque.Text.Trim();
            ihsppayinadv.Num = "1";
            ihsppayinadv.Payman = tbxPayMan.Text.Trim();
            ihsppayinadv.Prepamt = lblPrepamt.Text.Trim();
            ihsppayinadv.Feeamt = lblFeeamt.Text.Trim();
            ihsppayinadv.Payfee = tbxPayFee.Text.Trim();
            ihsppayinadv.Status = IhspPayinadvStatus.CHRG.ToString();
            ihsppayinadv.Depart = ProgramGlobal.Depart_id;
            ihsppayinadv.Chargedby = ProgramGlobal.User_id;
            ihsppayinadv.HisOrderNo = hisOrderNo;
            ihsppayinadv.Chargedate = currDate;
            ihsppayinadv.Ihsp_payinadv_id = null;
                  
            string sql = billIhspMan.inhspPay(ihsppayinadv);
            if (billIhspMan.doExeSql(sql) == -1)
            {
                MessageBox.Show("交预付款失败");
                return;
            }
            BillSysBase.doIhspAmt(ihspId);
            if (MessageBox.Show("交预付款成功，是否打印预交款发票?", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.getIhspPayInadv(ihsppayinadv.Id);
            }
             reset();
           
          
        }

        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            bool ret = true;
            if (!netpaytype.Equals("-1"))
            {
                NetPayIn netPayIn = new NetPayIn();
                NetPayOut netPayOut = new NetPayOut();
                NetpayBll netpayBll = new NetpayBll();
                string chk_authCode = tbx_authCode.Text.Trim();
                if (chk_authCode.Length < 18)
                {
                    tbx_authCode.Text = "";
                    MessageBox.Show("扫码失败，请重新扫码，后重新支付");
                    tbx_authCode.Focus();
                    return false;
                }
                if (chk_authCode.Length > 18)
                {
                    chk_authCode = chk_authCode.Substring(0, 18);
                }

                netPayIn.AuthCode = chk_authCode;
                netPayIn.Czyh = ProgramGlobal.User_id;
                hisOrderNo = netPayIn.OuterOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayIn.Paytype = netpaytype;
                netPayIn.StoreId = "0";
                netPayIn.Subject = "预付款";
                netPayIn.Ddlx = "3";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "2";//订单来源（默认1）：1门诊;2住院
                netPayIn.Hzxm = lblName.Text;
                netPayIn.Lxdh = homephone;
              //  netPayIn.Sfzh = idcard;
                netPayIn.Ysje = tbxPayFee.Text.Trim();
                netPayIn.Ksmc = lblDepart.Text;
                NetpayRetRes netpayRetRes = Netpay.execNetPay(netPayIn, netPayOut);
               
                NetPayData netPayData = new NetPayData();
                netPayData.AppCode = netPayIn.AppCode;
                netPayData.Czyh = netPayIn.Czyh;
                netPayData.Ddlx = netPayIn.Ddlx;
                netPayData.Ddly = netPayIn.Ddly;
                netPayData.InnerOrderNo = netPayOut.InnerOrderNo;
                netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
                netPayData.Jyrq = currDate;
                netPayData.Ksmc = netPayIn.Ksmc;
                netPayData.MerchantId = netPayIn.MerchantId;
                netPayData.MerId = netPayIn.MerId;
                netPayData.OrgCode = netPayIn.OrgCode;
                netPayData.OuterOrderNo = netPayIn.OuterOrderNo;
                netPayData.Paytype = netPayIn.Paytype;
                netPayData.SourceOuterOrderNo = "";
                netPayData.StoreId = netPayIn.StoreId;
                netPayData.TradeNo = netPayOut.TradeNo;
                netPayData.Ysje = netPayIn.Ysje;
                netPayData.Hzxm = netPayIn.Hzxm;
                netPayData.Sfzh = netPayIn.Sfzh;
                netPayData.Lxdh = netPayIn.Lxdh;
                netPayData.Yymc = ProgramGlobal.HspName;
                netPayData.Zfzt = "1"; //成功
                netPayData.Ihsp_id = this.ihspId;
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    netPayData.Zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {
                    netPayData.Zfzt = "-1";//失败[支付不确定]
                    ret = false;
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]支付成功";
                }
                netpayBll.saveToDb(netPayData);
                MessageBox.Show(mesg);
            }
            return ret;
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void reset()
        {
            getManSource(ihspId);
            DataTable datatable = billIhspMan.paySearch(ihspId,ihspStatus);
            dgvIhspPayinadv.DataSource = datatable;
            tbx_authCode.Text = "";
            tbxPayFee.Focus();
            tbxPayFee.Clear();
            cmbPayType.SelectedValue = 1;
            netpaytype = "-1";
        }
        /// <summary>
        /// 判断状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHospitalPayinadv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!ihspStatus.Equals("SETT"))
            {
                string status = dgvIhspPayinadv.SelectedRows[0].Cells["status"].Value.ToString();
                if (status == "计费")
                {
                    btnRetIhspPay.Enabled = true;
                    btnRePrint.Enabled = true;
                }
                else
                {
                    btnRetIhspPay.Enabled = false;
                    btnRePrint.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 重打预交金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            rePrint();
        }
        /// <summary>
        /// 重打
        /// </summary>
        public void rePrint()
        {
            if (dgvIhspPayinadv.SelectedRows.Count == 0 && dgvIhspPayinadv.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspPayRpt frmIhspRePrint = new FrmIhspPayRpt();
            string payid = dgvIhspPayinadv.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspRePrint.getSource(ihspId, payid);
            frmIhspRePrint.ShowDialog();
        }

        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is Button) &&
                keyData == Keys.Enter)
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHospitalPayinadv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "退费": dgvIhspPayinadv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue; break;
                    case "红冲": dgvIhspPayinadv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green; break;
                }
            }
        }

        /// <summary>
        /// 选择不同的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIhspPayinadv_SelectionChanged(object sender, EventArgs e)
        {
            if (!ihspStatus.Equals("SETT"))
            {
                string status = "";
                if (dgvIhspPayinadv.SelectedRows.Count != 0 && dgvIhspPayinadv.SelectedCells.Count != 0)
                {
                    status = dgvIhspPayinadv.SelectedRows[0].Cells["status"].Value.ToString();
                }
                if (status == "计费")
                {
                    btnRetIhspPay.Enabled = true;
                    btnRePrint.Enabled = true;
                }
                else
                {
                    btnRetIhspPay.Enabled = false;
                    btnRePrint.Enabled = false;
                }
            }
        }

        private void FrmIhspPay_Activated(object sender, EventArgs e)
        {
            tbxPayFee.Focus();
        }

        private void tbxPayMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddIhspPay.Focus();
            }
        }

        private void tbxPayFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxCheque.Focus();
            }
        }

        private void tbxCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPayMan.Focus();
            }
        }

        private void btnDoChrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                doAddIhspPay();
            }
        }

        private void btnRePrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                rePrint();
            }
        }

        private void btnRetChrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                retChrg();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void tbxPayFee_TextChanged(object sender, EventArgs e)
        {
            if (tbxPayFee.Text==".")
            {
                tbxPayFee.Text = "0.";
                tbxPayFee.SelectionStart = tbxPayFee.Text.Length;
            }
            if (string.IsNullOrEmpty(tbxPayFee.Text))
            {
                return;
            }
            if (!Regex.IsMatch(tbxPayFee.Text, @"(\d+(\.\d+)?)"))
            {
                MessageBox.Show("提示：交款金额填写格式有误!");
                tbxPayFee.Focus();
                tbxPayFee.Clear();
                return;
            }
        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;
            tbx_authCode.ReadOnly = true;
            tbx_authCode.Text = "";
            NetpayBll netpayBll = new NetpayBll();
            netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
            if (netpaytype != "-1")
            {
                tbx_authCode.ReadOnly = false;
                tbx_authCode.Clear();
                tbx_authCode.Focus();
                //lblInvoiceMsg.Text = "现在选择网络支付";
            }
            else
            {
                lblInvoiceMsg.Text = "                    ";
            }
        }
    }
}
