using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.clinic.bll;
using MTREG.common;
using MTREG.netpay.bo;

namespace MTREG.netpay
{
    public partial class FrmNetPayManage : Form
    {
        BillClinicRcpCost bllRecipelCharge = new BillClinicRcpCost();
        public FrmNetPayManage()
        {
            InitializeComponent();
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string startDate = this.dtpStime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endDate = this.dtpEtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string patientName = this.tbxPatientName.Text.Trim();
            string charger_id = this.cmbChargeby.SelectedValue.ToString();
            string sql = "select  outerOrderNo"
            + ",sourceOuterOrderNo"
                    + ",case ddlx  when '1' then '挂号' when '2' then '缴费' when '3' then '预交金' end as ddlx"
                    + ",case ddly  when '1' then '门诊' when '2' then '住院' end as ddly"
                    + ",hzxm"
                    + ",ksmc"
                    + ",innerOrderNo"
                    + ",case zfzt when '0' then '失败' when '1' then '成功' when '-1' then '未知'  end as zfzt"
                    + ",jyrq"
                    + ",case isCancel when '0' then '' when '-1' then '撤销' when '1' then '退费' end as isCancel"
                    + ",case jylx when '1' then '支付' when '2' then '退款' end as jylx"
                    + ", case hisstat  when '0' then '未完成' when '1' then '已完成' end as hisstat"
                    + " from netpaydata where 1=1 and jylx=" + DataTool.addFieldBraces(cmbJylx.SelectedValue.ToString())
                    + " and jyrq>" + DataTool.addFieldBraces(startDate)
                    + " and jyrq<" + DataTool.addFieldBraces(endDate);
            if (!string.IsNullOrEmpty(patientName))
            {
                sql += " and hzxm" + DataTool.addFieldBraces(patientName);
            }
            if (charger_id != "0")
            {
                sql += " and czyh=" + DataTool.addFieldBraces(charger_id);
            }
            this.dgv_NetPay.DataSource = BllMain.Db.Select(sql).Tables[0];


        }

        private void FrmNetPayManage_Load(object sender, EventArgs e)
        {

            init();
            search();
        }
        private void init()
        {
            this.dtpEtime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            //收费员
            var dtcharge = bllRecipelCharge.getChargebyInfo();
            this.cmbChargeby.ValueMember = "Id";
            this.cmbChargeby.DisplayMember = "Name";
            var drcharge = dtcharge.NewRow();
            drcharge["Id"] = 0;
            drcharge["Name"] = "--全部--";
            dtcharge.Rows.InsertAt(drcharge, 0);
            this.cmbChargeby.DataSource = dtcharge;

            DataTable dtunit = new DataTable();
            dtunit.Columns.Add("name");
            dtunit.Columns.Add("value");
            DataRow dr1 = dtunit.NewRow();
            dr1[0] = "支付";
            dr1[1] = "1";
            dtunit.Rows.Add(dr1);
            DataRow dr2 = dtunit.NewRow();
            dr2[0] = "支付退款";
            dr2[1] = "2";
            dtunit.Rows.Add(dr2);

            this.cmbJylx.DisplayMember = "name";
            this.cmbJylx.ValueMember = "value";
            this.cmbJylx.DataSource = dtunit;




        }


        private void dgv_NetPay_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_NetPay.SelectedRows.Count != 0 && dgv_NetPay.SelectedCells.Count != 0)
            {
                string zfzt = dgv_NetPay.SelectedRows[0].Cells["zfzt"].Value.ToString();
                string hisstat = dgv_NetPay.SelectedRows[0].Cells["hisstat"].Value.ToString();
                if (zfzt.Equals("失败") || hisstat.Equals("已完成") || jylx.Equals("退款"))
                {
                    btnNetPayCancel.Enabled = false;
                }
                else
                {
                    btnNetPayCancel.Enabled = true;
                }

            }
        }

        private void btnRefundQuery_Click(object sender, EventArgs e)
        {
            NetPayTradeRefundQueryIn netPayTradeRefundQueryIn = new NetPayTradeRefundQueryIn();
            NetPayTradeRefundQueryOut netPayTradeRefundQueryOut = new NetPayTradeRefundQueryOut();
            if (this.dgv_NetPay.SelectedRows.Count != 0 && this.dgv_NetPay.Rows.Count > 0)
            {
                string outerOrderNo = dgv_NetPay.SelectedRows[0].Cells["outerOrderNo"].Value.ToString();
                string sql = "SELECT"
                     + " appCode,"
                     + " outerOrderNo as outRefundNo,"
                     + " SourceOuterOrderNo as outerOrderNo,"
                     + " paytype"
                     + " from netpaydata "
                     + " where outerOrderNo =" + DataTool.addFieldBraces(outerOrderNo);
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                netPayTradeRefundQueryIn.AppCode = dt.Rows[0]["appCode"].ToString();
                netPayTradeRefundQueryIn.OutRefundNo = dt.Rows[0]["outRefundNo"].ToString();
                netPayTradeRefundQueryIn.OuterOrderNo = dt.Rows[0]["outerOrderNo"].ToString();
                netPayTradeRefundQueryIn.Paytype = dt.Rows[0]["paytype"].ToString();
                netPayTradeRefundQueryIn.Czyh = ProgramGlobal.User_id;
                NetpayRetRes netpayRetRes = Netpay.execNetPayTradeRefundQuery(netPayTradeRefundQueryIn, netPayTradeRefundQueryOut);
                string resultInfo ="";
                if (netpayRetRes.Ret_flag)
                {
                   resultInfo = "状态:成功\r\n"
                    + "支付流水号:" + netPayTradeRefundQueryOut.TradeNo + "\r\n"
                    + "收据号:" + netPayTradeRefundQueryOut.OuterOrderNo + "\r\n"
                    + "退款金额:" + netPayTradeRefundQueryOut.RefundFee + "\r\n"
                    + "退款时间:" + netPayTradeRefundQueryOut.Gmt_refund_pay + "\r\n"
                    + "支付方式:" + netPayTradeRefundQueryOut.Paytype + "\r\n"
                    + "随机字符串:" + netPayTradeRefundQueryOut.Nonce_str + "\r\n"
                    + "MD5签名:" + netPayTradeRefundQueryOut.Sign;
                }
                else
                {
                    resultInfo = "状态:成功\r\n" + netpayRetRes.Err_mesg;
                    
                }
                FrmQueryViewInfo frmQueryViewInfo = new FrmQueryViewInfo();

                frmQueryViewInfo.getreSource(resultInfo);
                frmQueryViewInfo.ShowDialog();
            }
        }

        private void btnNetPayCancel_Click(object sender, EventArgs e)
        {

            if (this.dgv_NetPay.SelectedRows.Count != 0 && this.dgv_NetPay.Rows.Count > 0)
            {
                NetPayCancelIn netPayCancelIn = new NetPayCancelIn();
                NetPayCancelOut netPayCancelOut = new NetPayCancelOut();
                string outerOrderNo = dgv_NetPay.SelectedRows[0].Cells["outerOrderNo"].Value.ToString();
                string sql = "SELECT"
                     + " appCode,"
                     + " innerOrderNo,"
                     + " outerOrderNo,"
                     + " paytype"
                     + " from netpaydata "
                     + " where outerOrderNo =" + DataTool.addFieldBraces(outerOrderNo);
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                netPayCancelIn.AppCode = dt.Rows[0]["appCode"].ToString();
                netPayCancelIn.InnerOrderNo = dt.Rows[0]["innerOrderNo"].ToString();
                netPayCancelIn.OuterOrderNo = dt.Rows[0]["outerOrderNo"].ToString();
                netPayCancelIn.Paytype = dt.Rows[0]["paytype"].ToString();
                netPayCancelIn.Cdly = "1";
                netPayCancelIn.Czyh = ProgramGlobal.User_id;
                NetpayRetRes netpayRetRes = Netpay.execNetPayCancel(netPayCancelIn, netPayCancelOut);
                if (netpayRetRes.Ret_flag)
                {

                    string sql_cancel = "update netpaydata set isCancel='-1' where  outerOrderNo =" + DataTool.addFieldBraces(outerOrderNo);
                    BllMain.Db.Update(sql_cancel);
                    MessageBox.Show("撤销成功!");
                    return;
                }
                MessageBox.Show("撤销操作失败，请查询撤销状态!" + netpayRetRes.Err_mesg);

            }
        }

       
    }
}
