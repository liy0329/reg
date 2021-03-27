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
using MTHIS.common;
using MTREG.common;
using MTREG.tools;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.medinsur;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.gysyb.bo;
using System.IO;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.hsdryb;
using MTREG.medinsur.gysyb.clinic;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.ynsyb.clinic;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.clinic.bll;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.common.bll;
using MTREG.netpay;
using MTREG.netpay.bo;

namespace MTREG.clinic
{
    public partial class FrmRefund : Form
    {
        BllRefund bllRefund = new BllRefund();
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        ChargeManagePatientInfo chargeManagePatientInfo = new ChargeManagePatientInfo();
        BillClinicRcpCost billRecipelCharge = new BillClinicRcpCost();
        // FrmClinicMedinsr frmClinicMedinsr = new FrmClinicMedinsr();
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        PersonInfo personInfo = new PersonInfo();//贵州省医保


        string sourceHisOrderNo = "";   //原订单号
        string netpaytype = "-1";
        string invoiceId = "";
        string patienttypeKeyname = "";
        internal ChargeManagePatientInfo ChargeManagePatientInfo
        {
            get { return chargeManagePatientInfo; }
            set { chargeManagePatientInfo = value; }
        }
        public FrmRefund()
        {
            InitializeComponent();
        }

        private void FrmRefund_Load(object sender, EventArgs e)
        {
            //就诊类型
            cmbPatientType.Enabled = false;
            var dtp = bllRecipelCharge.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            this.cmbPatientType.SelectedValue = ChargeManagePatientInfo.Bas_patienttype_id;
            initFrom();
            //加载表格
            loadDataGrid();
            //支付类型
            DataTable dt = new DataTable();
            dt = bllRefund.payPaytypeList();
            this.cmbPayType.ValueMember = "id";
            this.cmbPayType.DisplayMember = "name";
            this.cmbPayType.DataSource = dt;
            this.cmbPayType.SelectedValue = bllRefund.getPaytypeByInvoiceId(chargeManagePatientInfo.Invoice_id);

        }


        private void loadDataGrid()
        {
            getDgvCliniCost();
            dgvCliniCost.Columns["id"].Visible = false;
            dgvCliniCost.Columns["clinicinvoice"].Visible = false;
            dgvCliniCost.Columns["billcode"].HeaderText = "处方号";
            dgvCliniCost.Columns["billcode"].Width = 100;
            dgvCliniCost.Columns["billcode"].DisplayIndex = 2;
            dgvCliniCost.Columns["billcode"].ReadOnly = true;
            dgvCliniCost.Columns["chargedate"].HeaderText = "收费日期";
            dgvCliniCost.Columns["chargedate"].Width = 110;
            dgvCliniCost.Columns["chargedate"].DisplayIndex = 3;
            dgvCliniCost.Columns["chargedate"].ReadOnly = true;
            dgvCliniCost.Columns["dptname"].HeaderText = "科室";
            dgvCliniCost.Columns["dptname"].Width = 85;
            dgvCliniCost.Columns["dptname"].DisplayIndex = 4;
            dgvCliniCost.Columns["dptname"].ReadOnly = true;
            dgvCliniCost.Columns["dctname"].HeaderText = "医生";
            dgvCliniCost.Columns["dctname"].Width = 85;
            dgvCliniCost.Columns["dctname"].DisplayIndex = 5;
            dgvCliniCost.Columns["dctname"].ReadOnly = true;
            dgvCliniCost.Columns["Realfee"].HeaderText = "收费金额";
            dgvCliniCost.Columns["Realfee"].Width = 90;
            dgvCliniCost.Columns["Realfee"].DisplayIndex = 6;
            dgvCliniCost.Columns["Realfee"].ReadOnly = true;
            dgvCliniCost.Columns["checkrcp"].HeaderText = "";
            dgvCliniCost.Columns["checkrcp"].Width = 30;
            dgvCliniCost.Columns["checkrcp"].ReadOnly = true;
            dgvCliniCost.Columns["checkrcp"].DisplayIndex = 1;
            dgvCliniCost.Columns["rcptype"].Visible = false;
            dgvCliniCost.Columns["clinic_rcp_id"].Visible = false;
            dgvCliniCost.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void getDgvCliniCost()
        {
            invoiceId = chargeManagePatientInfo.Invoice_id;
            dgvCliniCost.DataSource = bllRefund.getChargeData(invoiceId);
            DataTable dt = bllRefund.getInvoiceFee(invoiceId);
            this.tbxInsurfee.Text = dt.Rows[0]["AKC780"].ToString();
            this.tbxInsuraccountfee.Text = dt.Rows[0]["AKC255"].ToString();
            tbxPayfee.Text = dt.Rows[0]["AKC261"].ToString();
            sourceHisOrderNo = dt.Rows[0]["hisOrderNo"].ToString();
        }
        private void loadDgvClinicRcp0(string[] gridData)
        {
            decimal amount = 0;
            DataGridViewCheckBoxColumn column0 = new DataGridViewCheckBoxColumn();
            dgvClinicRcp0.Columns.Add(column0);
            column0.Name = "checkrcp";
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column1);
            column1.Name = "id";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column2);
            column2.Name = "text2";
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column3);
            column3.Name = "text3";
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column4);
            column4.Name = "unit";
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column5);
            column5.Name = "num";
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column6);
            column6.Name = "prc";
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            dgvClinicRcp0.Columns.Add(column7);
            column7.Name = "spec";
            dgvClinicRcp0.Columns["checkrcp"].Width = 35;
            dgvClinicRcp0.Columns["checkrcp"].HeaderText = "";

            dgvClinicRcp0.Columns["unit"].Width = 50;
            dgvClinicRcp0.Columns["unit"].HeaderText = "单位";
            dgvClinicRcp0.Columns["num"].Width = 80;
            dgvClinicRcp0.Columns["num"].HeaderText = "数量";
            dgvClinicRcp0.Columns["prc"].Width = 80;
            dgvClinicRcp0.Columns["prc"].HeaderText = "单价";
            dgvClinicRcp0.Columns["spec"].Width = 100;
            dgvClinicRcp0.Columns["spec"].HeaderText = "规格";
            dgvClinicRcp0.Columns["text2"].Width = 150;
            dgvClinicRcp0.Columns["text2"].HeaderText = "项目名称";
            dgvClinicRcp0.Columns["text2"].ReadOnly = true;
            dgvClinicRcp0.Columns["text3"].Width = 120;
            dgvClinicRcp0.Columns["text3"].HeaderText = "发票号";
            dgvClinicRcp0.Columns["text3"].ReadOnly = true;
            dgvClinicRcp0.Columns["id"].Visible = false;

            int j = 0;
            for (int i = 0; i < gridData.Length; i += 2)
            {
                //          j = i / 2;
                DataGridViewRow row = new DataGridViewRow();
                dgvClinicRcp0.Rows.Add(row);
                //           dgvClinicRcp0.Rows[j].Cells[1].Value = gridView[i];
                dgvClinicRcp0.Rows[j].Cells["checkrcp"].Value = false;
                dgvClinicRcp0.Rows[j].Cells["checkrcp"].ReadOnly = true;
                dgvClinicRcp0.Rows[j].Cells["text2"].Value = "处方号：";
                dgvClinicRcp0.Rows[j].Cells["text3"].Value = gridData[i + 1];
                dgvClinicRcp0.Rows[j].Cells["id"].Value = gridData[i];
                DataTable dt = bllRefund.getClinicRcp(gridData[i], invoiceId);
                int m = 0;
                for (; m < dt.Rows.Count; m++)
                {
                    DataGridViewRow newrow = new DataGridViewRow();
                    dgvClinicRcp0.Rows.Add(newrow);
                    dgvClinicRcp0.Rows[j + m + 1].Cells["id"].Value = dt.Rows[m]["id"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["text2"].Value = dt.Rows[m]["name"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["text3"].Value = dt.Rows[m]["billcode"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["unit"].Value = dt.Rows[m]["unit"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["num"].Value = dt.Rows[m]["num"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["prc"].Value = dt.Rows[m]["prc"];
                    dgvClinicRcp0.Rows[j + m + 1].Cells["spec"].Value = dt.Rows[m]["spec"];
                    if (dt.Rows[m]["charged"].ToString() == "CHAR" && dt.Rows[m]["unlocked"].ToString() == "Y")
                    {
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value = true;
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].ReadOnly = true;//都定死
                    }
                    else
                    {
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value = false;
                        dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].ReadOnly = true;//都定死
                    }
                    if (dgvClinicRcp0.Rows[j + m + 1].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                    {
                        amount += decimal.Round(decimal.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["num"].Value.ToString()) * decimal.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["prc"].Value.ToString()), 2);
                        //decimal amount1 = Math.Round(decimal.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["num"].Value.ToString()) * decimal.Parse(dgvClinicRcp0.Rows[j + m + 1].Cells["prc"].Value.ToString()), 2);
                        
                    }

                }
                j = j + m + 1;
            }
            tbxAmount.Text = amount.ToString();
        }
        public void initFrom()
        {
            this.lblPatientName.Text = chargeManagePatientInfo.PatientName;
            this.lblHspcard.Text = chargeManagePatientInfo.Hspcard;
            this.lblSex.Text = chargeManagePatientInfo.Sex;
            this.lblDepart.Text = chargeManagePatientInfo.Depart;
            this.lblDoctor.Text = chargeManagePatientInfo.Doctor;
            this.lblIDCard.Text = chargeManagePatientInfo.Idcard;
            this.lblinvoiceCode.Text = chargeManagePatientInfo.Invoicecode;
            patienttypeKeyname = chargeManagePatientInfo.PatienttypeKeyname;
            this.cmbPatientType.SelectedValue = ChargeManagePatientInfo.Bas_patienttype_id;
        }

        /// <summary>
        ///  总复选框状态改变事件
        /// </summary>
        private void allCheckChange()
        {
            int isallchk = 0;
            if (cbxAllcheck.Checked == true)
            {
                isallchk = 1;
            }
            for (int i = 0; i < dgvCliniCost.RowCount; i++)
            {
                dgvCliniCost.Rows[i].Cells["checkrcp"].Value = isallchk;

            }
        }


        private void cbxAllcheck_CheckStateChanged(object sender, EventArgs e)
        {
            allCheckChange();
        }

        private string[] getDgvData()
        {
            int num = 0;
            for (int i = 0; i < dgvCliniCost.Rows.Count; i++)
            {
                if (dgvCliniCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    num++;
                }
            }
            string[] gridData = new string[num * 2];
            int m = 0;
            for (int i = 0; i < dgvCliniCost.Rows.Count; i++)
            {
                if (dgvCliniCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    gridData[m] = dgvCliniCost.Rows[i].Cells["id"].Value.ToString();
                    gridData[++m] = dgvCliniCost.Rows[i].Cells["billcode"].Value.ToString();
                    m++;
                }
            }
            return gridData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //挂号票判断是否接诊
            BllClinicCostManage bllChargeManage = new BllClinicCostManage();
            if (bllChargeManage.isRegistRcv(ChargeManagePatientInfo.Invoice_id))
            {
                MessageBox.Show("该病人已经接诊,不能退挂号票!");
                return;
            }

            string unlocked = bllChargeManage.getCostUnlocked(invoiceId);
            if (unlocked.Equals("N"))
            {
                MessageBox.Show("药品未解锁不能退费!");
                return;
            }

            //正经开始退 判断医保类型
            if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.HDSYB.ToString().ToUpper().Trim())
            {
                MZSyb SYB = new MZSyb();
                StringBuilder message = new StringBuilder();
                if (!SYB.refund(invoiceId, message, label9))
                {
                    MessageBox.Show(message + "医保退票失败");
                    return;
                }
            }
            else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.HDSCH.ToString().ToUpper().Trim())
            {
                MZCH SYB = new MZCH();
                StringBuilder message = new StringBuilder();
                if (!SYB.refund(invoiceId, message, label9))
                {
                    MessageBox.Show(message + "医保退票失败");
                    return;
                }
            }
            else if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SJZSJM.ToString().ToUpper().Trim() || patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SJZSYB.ToString().ToUpper().Trim())
            {
                MZSyb SYB = new MZSyb();
                StringBuilder message = new StringBuilder();
                string lblinvoiceCode = this.lblinvoiceCode.Text;
                if (!SYB.refmz(lblinvoiceCode, message))
                {
                    MessageBox.Show(message + "医保退票失败");
                    return;
                }
            }


            this.btnOk.Enabled = false;
            refundByCostdetIds();
            this.btnOk.Enabled = true;
        }


        private void refundByCostdetIds()
        {
            //网络支付退费
            string currDate = BillSysBase.currDate();
            string hisRefundNo = "";
            if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
            {
                return;
            }
            //网络支付退费_END
            string sql_merge = "";
            string costdetIds = "";
            string costIds = "";
            for (int i = 0; i < dgvClinicRcp0.Rows.Count; i++)
            {
                if (dgvClinicRcp0.Rows[i].Cells["text2"].Value.ToString() != "处方号：")
                {
                    costdetIds += dgvClinicRcp0.Rows[i].Cells["id"].Value.ToString() + ",";
                }
            }
            for (int i = 0; i < dgvCliniCost.Rows.Count; i++)
            {
                if (dgvCliniCost.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    costIds += dgvCliniCost.Rows[i].Cells["id"].Value.ToString() + ",";
                    string costid = dgvCliniCost.Rows[i].Cells["id"].Value.ToString();
                    string rcptype = dgvCliniCost.Rows[i].Cells["rcptype"].Value.ToString();
                    string clinic_rcp_id = dgvCliniCost.Rows[i].Cells["clinic_rcp_id"].Value.ToString();
                    bllRefund.upClinicCost(costid, ref sql_merge);//更新收费主表
                    bllRefund.upClinicRcpOrChk(clinic_rcp_id, rcptype, ref sql_merge);//更新处方表
                }
            }
            if (!String.IsNullOrEmpty(costdetIds))
            {
                costdetIds = costdetIds.Substring(0, costdetIds.Length - 1);
            }
            if (!String.IsNullOrEmpty(costIds))
            {
                costIds = costIds.Substring(0, costIds.Length - 1);
            }
            string ret_invoice_id = "";
            //门诊卡退费
            BillMember billMember = new BillMember();
            Member member = new Member();
            member.Hspcard = lblHspcard.Text;
            member.Cardstat = MemberCardStat.YES.ToString();
            DataTable dt = billMember.memberSearch(member, "", "");


            string Balance = "";
            if (patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SJZSJM.ToString().ToUpper().Trim() || patienttypeKeyname.ToUpper().Trim() == CostInsurtypeKeyname.SJZSYB.ToString().ToUpper().Trim())
            {
                //回退总费用
                MemRechargedet memRechargedet = new MemRechargedet();
                memRechargedet.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedet.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedet.Operatdate = BillSysBase.currDate();
                memRechargedet.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedet.Opertype = "CO";
                memRechargedet.Amount = tbxAmount.Text;
                memRechargedet.Bas_member_id = dt.Rows[0]["id"].ToString();
                Balance = (Double.Parse(dt.Rows[0]["Balance"].ToString()) + Double.Parse(tbxAmount.Text)).ToString();
                memRechargedet.Balance = Balance;
                memRechargedet.Paytype_id = cmbPayType.SelectedValue.ToString();
                sql_merge += billMember.inMemBalancedet(memRechargedet);
                //减去账号支付
                MemRechargedet memRechargedetyb = new MemRechargedet();
                memRechargedetyb.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedetyb.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedetyb.Operatdate = BillSysBase.currDate();
                memRechargedetyb.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedetyb.Opertype = "EN";
                memRechargedetyb.Amount = "-" + (tbxInsuraccountfee.Text).ToString();
                memRechargedetyb.Bas_member_id = dt.Rows[0]["id"].ToString();
                string Balanceyb_zh = (Double.Parse(Balance) - Double.Parse(tbxInsuraccountfee.Text)).ToString();
                memRechargedetyb.Balance = Balanceyb_zh;
                memRechargedetyb.Paytype_id = "5";
                sql_merge += billMember.inMemBalancedet(memRechargedetyb);
                //减去统筹支付
                memRechargedetyb = new MemRechargedet();
                memRechargedetyb.Id = BillSysBase.nextId("member_rechargedet");
                memRechargedetyb.Billcode = BillSysBase.newBillcode("member_rechargedet_billcode");
                memRechargedetyb.Operatdate = BillSysBase.currDate();
                memRechargedetyb.Operatorid = ProgramGlobal.User_id;
                memRechargedet.depart_id = ProgramGlobal.Depart_id;
                memRechargedetyb.Opertype = "EN";
                memRechargedetyb.Amount = "-" + (tbxInsurfee.Text).ToString();
                memRechargedetyb.Bas_member_id = dt.Rows[0]["id"].ToString();
                string Balanceyb_tc = (Double.Parse(Balanceyb_zh) - Double.Parse(tbxInsurfee.Text)).ToString();
                memRechargedetyb.Balance = Balanceyb_tc;
                memRechargedetyb.Paytype_id = "4";
                sql_merge += billMember.inMemBalancedet(memRechargedetyb);
                sql_merge += billMember.upMemBalance(dt.Rows[0]["id"].ToString(), (Double.Parse(Balance) - Double.Parse(tbxInsuraccountfee.Text) - Double.Parse(tbxInsurfee.Text)).ToString());

            }




            

            bllRefund.upClinicInvoice(ChargeManagePatientInfo.Invoice_id, currDate, ref ret_invoice_id, ref sql_merge);
            bllRefund.upCliniCostdet(costdetIds, currDate, ret_invoice_id, ref sql_merge);
            bllRefund.backRegister(ChargeManagePatientInfo.Invoice_id, ref sql_merge);
            if (bllRecipelCharge.doExeSql(sql_merge) < 0)
            {
                MessageBox.Show("退票生成失败！");
                SysWriteLogs.writeLogs1("退票信息错误日志.log", Convert.ToDateTime(BillSysBase.currDate()), sql_merge);
                return;
            }


            MessageBox.Show("退票成功！");
            this.Close();
        }
        /// <summary>
        /// 支付退费
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="hisRefundNo"></param>
        /// <returns></returns>
        bool doexecNetPayTradeRefund(string currDate, ref string hisRefundNo)
        {
            double payfee = DataTool.stringToDouble(tbxPayfee.Text);
            bool ret = true;
            if (!netpaytype.Equals("-1") && payfee > 0)
            {
                NetPayTradeRefundIn netPayTradeRefundIn = new NetPayTradeRefundIn();
                NetPayTradeRefundOut netPayTradeRefundOut = new NetPayTradeRefundOut();
                NetpayBll netpayBll = new NetpayBll();
                netPayTradeRefundIn.Czyh = ProgramGlobal.User_id;
                hisRefundNo = netPayTradeRefundIn.OutRefundNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayTradeRefundIn.Paytype = netpaytype;
                netPayTradeRefundIn.StoreId = "0";
                netPayTradeRefundIn.Subject = "门诊退费";
                netPayTradeRefundIn.OuterOrderNo = sourceHisOrderNo;
                netPayTradeRefundIn.Tfje = tbxPayfee.Text.Trim();
                netPayTradeRefundOut.OutRefundNo = hisRefundNo;
                NetpayRetRes netpayRetRes = Netpay.execNetPayTradeRefund(netPayTradeRefundIn, netPayTradeRefundOut);
                string zfzt = "1"; //成功
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {

                    zfzt = "-1";
                    mesg = "退单号:[" + hisRefundNo + "]原单号:[" + sourceHisOrderNo + "],姓名:[" + this.lblPatientName.Text + "]网络支付超时或不明确，处于支付故障状态，请及时确定未结算信息！";
                    ret = false;
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "退单号:[" + hisRefundNo + "]原单号:[" + sourceHisOrderNo + "],退款成功";
                }
                netpayBll.refundNetPay(sourceHisOrderNo, currDate, zfzt, netPayTradeRefundOut);
                MessageBox.Show(mesg);
            }
            return ret;

        }
        /// <summary>
        /// 主表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCliniCost_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvClinicRcp0.Columns.Clear();
            loadDgvClinicRcp0(getDgvData());
        }
        /// <summary>
        /// 明细改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicRcp0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double amount = 0;
            for (int i = 0; i < dgvClinicRcp0.Rows.Count; i++)
            {
                if (dgvClinicRcp0.Rows[i].Cells["text2"].Value != null && dgvClinicRcp0.Rows[i].Cells["text2"].Value.ToString() != "处方号：" && dgvClinicRcp0.Rows[i].Cells["checkrcp"].Value != null && dgvClinicRcp0.Rows[i].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
                {
                    amount += double.Parse(dgvClinicRcp0.Rows[i].Cells["num"].Value.ToString()) * double.Parse(dgvClinicRcp0.Rows[i].Cells["prc"].Value.ToString());
                }
            }
            tbxAmount.Text = DataTool.FormatData(amount.ToString(), "2");
        }
        /// <summary>
        /// 触发收费主表数据的复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCliniCost_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCliniCost.IsCurrentCellDirty)
            {
                dgvCliniCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        /// <summary>
        /// 明細表数据的复选框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClinicRcp0_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCliniCost.IsCurrentCellDirty)
            {
                dgvCliniCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cmbPatientType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }


        private void btnReadInsurCard_Click(object sender, EventArgs e)
        {

        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
                return;

            NetpayBll netpayBll = new NetpayBll();
            netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
            if (netpaytype != "-1")
            {

                lblInvoiceMsg.Text = "现在选择网络支付";

            }
            else
            {
                lblInvoiceMsg.Text = "                    ";
            }
        }

        private void dgvCliniCost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCliniCost.SelectedRows[0].Cells["checkrcp"].Value.ToString().ToUpper() == "TRUE")
            //{
            //    dgvCliniCost.SelectedRows[0].Cells["checkrcp"].Value = "False";
            //}
            //else
            //{
            //    dgvCliniCost.SelectedRows[0].Cells["checkrcp"].Value = "true";
            //}
        }
    }
}
