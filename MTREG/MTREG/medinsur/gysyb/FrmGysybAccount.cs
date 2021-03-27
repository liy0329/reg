using System;
using System.Data;
using System.Windows.Forms;
using MTREG.common;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTHIS.main.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hdssy;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsbhnh;
using MTREG.medinsur.hdsbhnh.bll;
using System.Text;
using MTREG.medinsur.hsdryb.ihsp;
using MTREG.medinsur.hsdryb.ihsp.bll;

using MTREG.medinsur.gysyb.bo;

using MTREG.medinsur.ahsjk;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.gysyb.bll;
using System.Collections.Generic;
using System.Net;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.ahsjk.bo;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gzsyb.ihsp.bll;
using System.Text.RegularExpressions;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.ihsp;
using MTREG.medinsur.ynsyb.ihsp.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using System.Drawing;
using MTREG.clinic.bll;
using System.Web.UI.WebControls;
using MTREG.ihsp;
using MTREG.common.bll;
using MTREG.netpay;
using MTREG.netpay.bo;

namespace MTREG.medinsur.gysyb
{
    public partial class FrmGysybAccount : Form
    {
        int flag;

        string invoicecode = "";//发票号
        string nextinvoicesql = "";//发票号sql

        double paytotal = 0;//预交款
        double feetotal = 0;//总费用

        string member_id;
        string ihsp_id;//ihspid      
        string cost_insurtype_id = "";//接口类型id
        BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsur bllInsur = new BllInsur();
        Ybjk ybjk = new Ybjk();
        Hdsch hdsch = new Hdsch();
        Ihspaccount ihspaccount = new Ihspaccount();

        private string homephone = "";
        private string idcard = "";
        string netpaytype = "-1";
        public FrmGysybAccount()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取FrmIhospCost数据
        /// </summary>
        public void getSource(string id)
        {
            this.ihsp_id = id;
        }
        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspAccount_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            #region combox设置
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtpt;
                this.cmbPayType.SelectedValue = 1;
            }
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                this.cmbPatienttype.DataSource = dtp;
            }

            //结算方式
            //0：按项目结算；1：单病种包干结算
            List<ListItem2> settleTypeList = new List<ListItem2>();
            settleTypeList.Add(new ListItem2("0", "按项目结算"));
            settleTypeList.Add(new ListItem2("1", "单病种包干结算"));
            this.cmbSettleType.DisplayMember = "name";
            this.cmbSettleType.ValueMember = "value";
            this.cmbSettleType.DataSource = settleTypeList;
            this.cmbSettleType.SelectedIndex = 0;

            //清算方式
            //1：控制线清算方式（生育保险中为非包干方式）；3：单病种按人次定额包干清算方式；4：单病种按日定额包干清算方式；2：重症病种清算；5：生育保险包干清算； 6：单病种包干清算
            List<ListItem2> outSettleTypeList = new List<ListItem2>();
            outSettleTypeList.Add(new ListItem2("1", "控制线清算方式（生育保险中为非包干方式）"));
            outSettleTypeList.Add(new ListItem2("2", "重症病种清算"));
            outSettleTypeList.Add(new ListItem2("3", "单病种按人次定额包干清算方式"));
            outSettleTypeList.Add(new ListItem2("4", "单病种按日定额包干清算方式"));
            outSettleTypeList.Add(new ListItem2("5", "生育保险包干清算"));
            outSettleTypeList.Add(new ListItem2("6", "单病种包干清算"));
            this.cmbOutSettleType.DisplayMember = "name";
            this.cmbOutSettleType.ValueMember = "value";
            this.cmbOutSettleType.DataSource = outSettleTypeList;
            this.cmbOutSettleType.SelectedIndex = 0;

            //出院原因
            //1：治愈，2：好转3：死亡，9：其他
            List<ListItem2> cyyyList = new List<ListItem2>();
            cyyyList.Add(new ListItem2("1", "治愈"));
            cyyyList.Add(new ListItem2("2", "好转"));
            cyyyList.Add(new ListItem2("3", "死亡"));
            cyyyList.Add(new ListItem2("9", "其他"));
            this.cyyy.DisplayMember = "name";
            this.cyyy.ValueMember = "value";
            this.cyyy.DataSource = cyyyList;
            this.cyyy.SelectedIndex = 0;

            //保险类别
            //1:企业基本医疗保险；2:企业离休医疗保险；3:机关事业单位基本医疗保险；4：企业生育保险；5：机关事业单位生育保险；6：居民医保；7：工伤保险
            List<ListItem2> insurTypeList = new List<ListItem2>();
            insurTypeList.Add(new ListItem2("1", "企业基本医疗保险"));
            insurTypeList.Add(new ListItem2("2", "企业离休医疗保险"));
            insurTypeList.Add(new ListItem2("3", "机关事业单位基本医疗保险"));
            insurTypeList.Add(new ListItem2("4", "企业生育保险"));
            insurTypeList.Add(new ListItem2("5", "机关事业单位生育保险"));
            insurTypeList.Add(new ListItem2("6", "居民医保"));
            insurTypeList.Add(new ListItem2("7", "工伤保险"));
            this.cmbInsurType.DisplayMember = "name";
            this.cmbInsurType.ValueMember = "value";
            this.cmbInsurType.DataSource = insurTypeList;
            this.cmbInsurType.SelectedIndex = 0;

            #endregion
            cmbPatienttype.Enabled = false;

            DataTable dt = bllInsurGYSYB.getAccIhspInfo(ihsp_id);
            dgvBind();
            string ihspstatus = dt.Rows[0]["status"].ToString();
            if (ihspstatus == "SETT")
            {
                btnPreSettle.Enabled = false;
                btnAccount.Enabled = false;
            }

            member_id = dt.Rows[0]["member_id"].ToString();
            this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
            this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
            this.lblIndate.Text = Convert.ToDateTime(dt.Rows[0]["indate"].ToString()).ToString("yyyy-MM-dd");
            this.lblOutdate.Text = Convert.ToDateTime(dt.Rows[0]["outdate"].ToString()).ToString("yyyy-MM-dd");
            string Patienttype = dt.Rows[0]["bas_patienttype_id"].ToString();
            this.idcard = dt.Rows[0]["idcard"].ToString();
            this.homephone = dt.Rows[0]["homephone"].ToString();
            if (!string.IsNullOrEmpty(Patienttype))
            {
                this.cmbPatienttype.SelectedValue = Patienttype;
                cost_insurtype_id = bllInsur.getInsurtypeId(Patienttype);
            }
            string insurType = dt.Rows[0]["insuretype"].ToString();
            if (!string.IsNullOrEmpty(insurType))
            {
                this.cmbInsurType.SelectedValue = insurType;
            }

            //发票号
            string invoiceKind = billIhspAct.getInvoiceKind(this.cmbPatienttype.SelectedValue.ToString());
            if (invoiceKind == "")
            {
                MessageBox.Show("获取发票类型时,未找到对应发票类型!");
                this.Close();
                return;
            }
            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                MessageBox.Show("发票已用完，不能进行收费！");
                this.Close();
                return;
            }
            this.lblInvoice.Text = invoicecode;

            int invoiceNum = billIhspAct.getInvoiceNum(invoiceKind, ProgramGlobal.User_id.Trim().ToString());
            if (invoiceNum < 10)
            {
                lblInvoiceMsg.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
            }
            else if (invoiceNum >= 10)
            {
                lblInvoiceMsg.Text = "";
            }

            DateTime start = Convert.ToDateTime(this.lblIndate.Text);
            DateTime end = Convert.ToDateTime(this.lblOutdate.Text);
            TimeSpan day = end.Subtract(start);
            this.lblIhspDay.Text = day.Days.ToString();

            btnAccount.Enabled = false;
        }

        /// <summary>
        /// 绑定datagridview
        /// </summary>
        public void dgvBind()
        {
            //预交款
            DataTable datatable = billIhspAct.payAccount(ihsp_id);
            this.dgvIhspPayinadv.DataSource = datatable;
            #region  dgvIhspPayinadv单元格标题设置
            dgvIhspPayinadv.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspPayinadv.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvIhspPayinadv.Columns["payfee"].HeaderText = "交款金额";
            this.dgvIhspPayinadv.Columns["payfee"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["payfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspPayinadv.Columns["paytypename"].HeaderText = "交款方式";
            this.dgvIhspPayinadv.Columns["paytypename"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["cheque"].HeaderText = "支票号";
            this.dgvIhspPayinadv.Columns["cheque"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["doctorname"].HeaderText = "收款人";
            this.dgvIhspPayinadv.Columns["doctorname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspPayinadv.Columns["chargedate"].HeaderText = "收款时间";
            this.dgvIhspPayinadv.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvIhspPayinadv.Columns["chargedate"].Width = (int)(100 * ProgramGlobal.WidthScale);
            #endregion
            paytotal = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                paytotal += double.Parse(DataTool.FormatData(datatable.Rows[i]["payfee"].ToString(), "2"));
            }
            lblPaytotal.Text = DataTool.FormatData(paytotal.ToString(), "2")+"元";

            //费用清单
            datatable = bllInsurGYSYB.costSearch(ihsp_id);
            this.dgvIhspCost.DataSource = datatable;
            #region  dgvIhspCost单元格标题设置
            dgvIhspCost.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvIhspCost.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvIhspCost.Columns["itemtypename"].HeaderText = "项目类别";
            this.dgvIhspCost.Columns["itemtypename"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["name"].HeaderText = "名称";
            this.dgvIhspCost.Columns["name"].Width = (int)(180 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["realfee"].Visible = false;
            this.dgvIhspCost.Columns["spec"].HeaderText = "规格";
            this.dgvIhspCost.Columns["spec"].Width = (int)(80 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["num"].HeaderText = "数量";
            this.dgvIhspCost.Columns["num"].Width = (int)(70 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspCost.Columns["prc"].HeaderText = "单价";
            this.dgvIhspCost.Columns["prc"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvIhspCost.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvIhspCost.Columns["id"].HeaderText = "id";
            this.dgvIhspCost.Columns["id"].Visible = false;
            #endregion
            //总费用
            feetotal = DataTool.stringToDouble( billIhspAct.getHisCostDetSum(ihsp_id)); 
            //for (int i = 0; i < datatable.Rows.Count; i++)
            //{
            //    string realfee = datatable.Rows[i]["realfee"].ToString();
            //    if (string.IsNullOrEmpty(datatable.Rows[i]["realfee"].ToString()))
            //    {
            //        realfee = "0";
            //    }
            //    feetotal += double.Parse(DataTool.FormatData(realfee, "2"));
            //}
            lblFeetotal.Text = DataTool.FormatData(feetotal.ToString(), "2")+"元" ;
            tbxFeeamt.Text = feetotal.ToString("0.00");
        }
        

        private bool isHisihspSign()
        {
            if (!billIhspAct.isHisihspSign(ihsp_id))
            {
                MessageBox.Show("当前患者未挂账，不能办理出院，请确认！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 单击结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            //判断是否处于挂账状态
            if (!isHisihspSign())
            {
                return;
            }
            BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            //获取疾病名称、疾病编码，判断是否填写
            DataTable dtCy = bllInsurGYSYB.getCydjInfo(ihsp_id);
            string ihsp_diag = dtCy.Rows[0]["diagnname"].ToString();
            string ihsp_diagicd = dtCy.Rows[0]["diagnICD"].ToString();
            if (ihsp_diag.Equals(""))
            {
                MessageBox.Show("没有填写出院诊断, 不能结算!");
                return;
            }
           //新生儿
            
            double neonSum =DataTool.stringToDouble(billIhspAct.getHisNeonCostDetSum(ihsp_id));
           if(Math.Abs( neonSum)>0.001)
           {
               MessageBox.Show("请先新生儿结算后再结算！(新生儿住院总费用为：" + neonSum);
               btnAccount.Enabled = false;
               return;
           }
            //比较住院总费用和上传至医保中心的费用是否一致
            double zFy = DataTool.stringToDouble(tbxYbzfy.Text.Trim()) - feetotal;
            if (zFy < -0.001 || zFy > 0.001)
            {
                MessageBox.Show("住院总费用与上传至医保中心的总费用不相等,无法办理结算请确认！(住院总费用为：" + feetotal + ",该患者上传至医保中心总费用为:" + tbxYbzfy.Text.Trim() + ")");
                btnAccount.Enabled = false;
                return;
            }
            

            //刷卡验证身份
            Sybdk_Entity sybdk_entity = new Sybdk_Entity();
            FrmIhspMedinsrGYSYB frmrgysyb = new FrmIhspMedinsrGYSYB();
            frmrgysyb.Sybdk_entity = sybdk_entity;
            frmrgysyb.Sfzfzyb = false;//不是自费转医保
            frmrgysyb.TextBoxxm = this.lblName.Text.Trim();//患者姓名
            //frmrgysyb.TextBoxsfzh = "";//患者身份证号码
            frmrgysyb.StartPosition = FormStartPosition.CenterScreen;
            frmrgysyb.ShowDialog(this);
            if (!frmrgysyb.flag)
            {
                MessageBox.Show("身份验证失败, 结算失败!");
                return;
            }
            //网络支付
            string hisOrderNo = "";
            string currDate = BillSysBase.currDate();
            if (!doExecNetPay(currDate, ref hisOrderNo))
                return;
            ihspaccount.Chargedate = currDate;
            ihspaccount.HisOrderNo = hisOrderNo;

            //网络支付_END
            //结算
            StringBuilder message = new StringBuilder();
            
            if (!gysybAcc(message, sybdk_entity))
            {
               return;
            }
            //出院
            DataTable dt = bllInsurGYSYB.getInsurstat(ihsp_id);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][0].ToString() == Insurstat.SETT.ToString())
                {
                    string outtype = this.cyyy.SelectedValue.ToString();//出院原因
                    if (!bllInsurGYSYB.Cydj(ihsp_id, outtype, message))
                    {
                        MessageBox.Show("医保接口出院办理失败！" + message.ToString());
                        return;
                    }
                }
            }

            //发票
            FrmClickAccount frmClickAccount = new FrmClickAccount();
            frmClickAccount.getSource(ihspaccount.Invoice, ihsp_id, ihspaccount.Id);
            frmClickAccount.Patienttype = cmbPatienttype.SelectedValue.ToString();
            frmClickAccount.ShowDialog();
            this.Close();
        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            double payfee = DataTool.stringToDouble(tbxInBalanceamt.Text);
            bool ret = true;
            if (!netpaytype.Equals("-1") && payfee > 0)
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
                netPayIn.Subject = "结算收款";
                netPayIn.Ddlx = "2";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "2";//订单来源（默认1）：1门诊;2住院
                netPayIn.Hzxm = lblName.Text;
                netPayIn.Lxdh = homephone;
               // netPayIn.Sfzh = idcard;
                netPayIn.Ysje = tbxInBalanceamt.Text;
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
                netPayData.Ihsp_id = ihsp_id;
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
        /// 贵阳市医保结算
        /// </summary>
        private bool gysybAcc(StringBuilder message,Sybdk_Entity sybdk_entity)
        {
           
           
             string errInfo = "";
            BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            //个人编码|单病种编码|清算方式|结算方式|保险类别
            //发票号

            string cardPay = tbxInsuraccountFee.Text.Trim();
            Dictionary<String, Zyjs_ret> dic = new Dictionary<string,Zyjs_ret>();
            if (cbxCheckSp.Checked == true)
            {
                dic = bllInsurGYSYB.settleSp(ihsp_id, "1", invoicecode, message, cmbOutSettleType.SelectedValue.ToString(), tbxdbzbm.Text);
            }
            else if (cbxCheckSp.Checked == false)
            {
                //添加sybdk_entity，用来获取医保卡信息
                dic = bllInsurGYSYB.settle(ihsp_id, invoicecode, cardPay, message, out errInfo, cmbOutSettleType.SelectedValue.ToString(), tbxdbzbm.Text, sybdk_entity);
            }
            if (!string.IsNullOrEmpty(errInfo))
            {
                MessageBox.Show(errInfo);
                return false;
            }
            Zyjs_ret zyjs_ret_entity = new Zyjs_ret();
            dic.TryGetValue("zyjs_ret", out zyjs_ret_entity);
            //插入从老his导入的表
            if (bllInsurGYSYB.updateZyjs(zyjs_ret_entity) == -1)
            {
                MessageBox.Show("医保结算成功,医保结算信息保存处错误，请及联系工程师执行医保退结算，在进行操作");
                return false;
            }
            
          


           double d_grzhzf = DataTool.stringToDouble(zyjs_ret_entity.Acctpay);//个人账户支付
           double d_ylbzzf = DataTool.stringToDouble(zyjs_ret_entity.Fund3pay);//医疗补助支付
           double d_detczf = DataTool.stringToDouble(zyjs_ret_entity.Fund2pay);//大额统筹支付
           double d_jbtczf = DataTool.stringToDouble(zyjs_ret_entity.Fund1pay);//基本统筹支付
           double d_ybtc = d_jbtczf + d_detczf + d_ylbzzf;//医保统筹
           double d_sbzf = DataTool.stringToDouble(zyjs_ret_entity.Sbpay);//商保支付
           double ssje = feetotal - paytotal - d_grzhzf - d_ybtc - d_sbzf;

           ihspaccount.Id = BillSysBase.nextId("ihsp_account");
           ihspaccount.Ihsp_id = ihsp_id;
           ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
           ihspaccount.Member_id = member_id;
           ihspaccount.Bas_paytype_id = this.cmbPayType.SelectedValue.ToString();
           ihspaccount.Cost_insurtype_id = this.cost_insurtype_id;
           ihspaccount.Cheque = tbxCheque.Text.Trim().ToString();
           ihspaccount.Bas_patienttype_id = this.cmbPatienttype.SelectedValue.ToString();
           ihspaccount.Num = "1";
           //发票号
           ihspaccount.Invoice = invoicecode;
           ihspaccount.Nextinvoicesql = nextinvoicesql;
           //费用
           ihspaccount.Feeamt = feetotal.ToString("0.00");
           //总预交款
           ihspaccount.Prepamt = paytotal.ToString("0.00");


           ihspaccount.Balanceamt = ssje.ToString("0.00");//this.tbxInBalanceamt.Text;

           ihspaccount.Depart_id = ProgramGlobal.Depart_id;
           ihspaccount.Chargedby_id = ProgramGlobal.User_id;
          // ihspaccount.Chargedate = BillSysBase.currDate();
           ihspaccount.Cancleby = "";
           ihspaccount.Ihsp_account_id = "";
           ihspaccount.Status = IhspAccountStatus.SETT.ToString();

           ihspaccount.Insurefee = this.tbxInsurefee.Text.Trim().ToString();
           ihspaccount.Selffee = this.tbxInsuraccountFee.Text.Trim().ToString();

           List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();


           //插入账户支付
           string grzhzf = d_grzhzf.ToString("0.00");
           IhspInvoicedet ihspInvoicedetGrzhzf = new IhspInvoicedet();
           ihspInvoicedetGrzhzf.Id = BillSysBase.nextId("ihsp_invoicedet");
           ihspInvoicedetGrzhzf.IhspAccountId = ihspaccount.Id;
           ihspInvoicedetGrzhzf.Payfee = grzhzf;
           ihspInvoicedetGrzhzf.PaysumbyId = billIhspAct.getPaysumbyKeyname("GYSYB");//市医保
           ihspInvoicedetGrzhzf.PaytypeId = billIhspAct.getSELFFEEPaytypeId();//selffee是账户支付
           invoicedets.Add(ihspInvoicedetGrzhzf);


           //插入医保统筹
           string ybtc = d_ybtc.ToString("0.00");
           IhspInvoicedet ihspInvoicedetYbtc = new IhspInvoicedet();
           ihspInvoicedetYbtc.Id = BillSysBase.nextId("ihsp_invoicedet");
           ihspInvoicedetYbtc.IhspAccountId = ihspaccount.Id;
           ihspInvoicedetYbtc.Payfee = ybtc;
           ihspInvoicedetYbtc.PaysumbyId = billIhspAct.getPaysumbyKeyname("GYSYB");//市医保
           ihspInvoicedetYbtc.PaytypeId = billIhspAct.getInsurFeePaytypeId();//INSUREFEE是医保统筹
           invoicedets.Add(ihspInvoicedetYbtc);

           //插入实收金额
           IhspInvoicedet ihspInvoicedetSSje = new IhspInvoicedet();
           ihspInvoicedetSSje.Id = BillSysBase.nextId("ihsp_invoicedet");
           ihspInvoicedetSSje.IhspAccountId = ihspaccount.Id;
           ihspInvoicedetSSje.Payfee = ssje.ToString("0.00");
           ihspInvoicedetSSje.PaytypeId = this.cmbPayType.SelectedValue.ToString();
           ihspInvoicedetSSje.PaysumbyId = billIhspAct.getPaysumby(ihspInvoicedetSSje.PaytypeId);
           invoicedets.Add(ihspInvoicedetSSje);


           if (d_sbzf != 0)
           {
               //插入商保
               string sbzf = d_sbzf.ToString("0.00");
               IhspInvoicedet ihspInvoicedetSbzf = new IhspInvoicedet();
               ihspInvoicedetSbzf.Id = BillSysBase.nextId("ihsp_invoicedet");
               ihspInvoicedetSbzf.IhspAccountId = ihspaccount.Id;
               ihspInvoicedetSbzf.Payfee = sbzf;
               ihspInvoicedetSbzf.PaysumbyId = billIhspAct.getPaysumbyKeyname("GYSYBSB");//商保
               ihspInvoicedetSbzf.PaytypeId = billIhspAct.getInsurFeePaytypeId();//商保支付
               invoicedets.Add(ihspInvoicedetSbzf);
           }
           string account_sql = billIhspAct.accountInsurStat(ihsp_id);//医保状态信息
           account_sql += billIhspAct.doAccount(ihspaccount, invoicedets, "insur");//HIS结算
           if (-1 == billIhspMan.doExeSql(account_sql))//结算
           {
               MessageBox.Show("医保结算成功,HIS结算错误，请及及时执行医保退结算，用网络支付信息请及时撤销网络支付");
               return false;
           }
           return true;
        }         
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 账户支付变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxInsuraccountFee_TextChanged(object sender, EventArgs e)
        {
            //总费用
            double d_yyzfy = feetotal;
            //医保报销
            double d_insurefee = DataTool.Getdouble(tbxInsurefee.Text);
            //个人应付
            double d_gryfje = d_yyzfy - d_insurefee;
            //账户余额
            double d_grzhye = DataTool.Getdouble(tbxBalance.Text.Trim());

            //个人账户支付
            double d_insuraccountFee = DataTool.Getdouble(tbxInsuraccountFee.Text);
            if (d_insuraccountFee < 0)
            {
                tbxInsuraccountFee.Text = "";
                d_insuraccountFee = 0;
            }
            int flag_xssf = 0;
            //限制算法 [个人账户支付 < 个人应付]
            if (d_insuraccountFee > d_gryfje)
            {
                d_insuraccountFee = d_gryfje;
                tbxInsuraccountFee.Text = d_insuraccountFee.ToString("0.00");
                flag_xssf = 1;

            }
            //限制算法[个人账户支付<=卡内余额]
            if (d_insuraccountFee > d_grzhye)
            {
                d_insuraccountFee = d_grzhye;
                tbxInsuraccountFee.Text = d_insuraccountFee.ToString("0.00");
                flag_xssf = 1;
            }
            if (flag_xssf == 1)
                MessageBox.Show("个人账户支付最多可支付金额为：" + tbxInsuraccountFee.Text.Trim());
            //预交款
            double d_yjk = paytotal;
            //计算个人应收金额 {应收金额= [个人应付金额-个人账户支付-预交金额]}
            double fee = d_gryfje - d_insuraccountFee - d_yjk;
            //赋值收费员应收金额
            this.tbxInBalanceamt.Text = fee.ToString("0.00");
        }

        private void btnPreSettle_Click(object sender, EventArgs e)
        {
            ////string insurtype = "1";//保险类别
            //string bllNo = "20101000019170000FA1";//就诊顺序号
            //string settleNo = "1";//结算编号
            //string zflx = "31";//支付类型
            //string ihspId = "76";
            //StringBuilder message2 = new StringBuilder();
            //bllInsurGYSYB.zyTp(ihspId,bllNo, settleNo, zflx, message2);
            //return;
            if (cbxCheckSp.Checked == true)
            {
                StringBuilder message = new StringBuilder();
                DataTable dtInsur = bllInsurGYSYB.gysybIhspInfo(ihsp_id);
                string bxlb = cmbInsurType.SelectedValue.ToString();//保险类别
                string ybBzbm = tbxdbzbm.Text.Trim();//单病种编码
                string qsfs = cmbOutSettleType.SelectedValue.ToString();//清算方式
                string jsfs = cmbSettleType.SelectedValue.ToString();//结算方式//结算方式为1时，单病种编码不能为空
            
                //个人编码|单病种编码|清算方式|结算方式|保险类别
                //string insurInfo = dtInsur.Rows[0]["insurinfo"].ToString() + "|" + ybBzbm + "|" + qsfs + "|" + jsfs + "|" + bxlb;
                if (bxlb != "2" && bxlb != "5" && bxlb != "4" && bxlb != "7")
                {
                    if (jsfs != "0")
                    {
                        if (!bllInsurGYSYB.setCalType(message, jsfs, ybBzbm, dtInsur.Rows[0]["insurcode"].ToString()))
                        {
                            MessageBox.Show("设置结算方式失败：" + message);
                            return;
                        }
                    }
                }
                message.Length = 0;
                string reckoningType = "1";//清算方式
                if (bxlb != "2" && bxlb != "7")
                {
                    if (qsfs != "9")
                    {
                        reckoningType =qsfs;//清算方式
                    }
                    if (!bllInsurGYSYB.setReckoningType(message, reckoningType, ybBzbm, dtInsur.Rows[0]["insurcode"].ToString()))
                    {
                        MessageBox.Show("设置清算方式失败：" + message);
                        return;
                    }
                }
                message.Length = 0;
                Dictionary<String, Zyjs_ret> dic = bllInsurGYSYB.settleSp(ihsp_id, "0", lblInvoice.Text, message, qsfs, ybBzbm);
                Zyjs_ret zyjs_ret_entity = new Zyjs_ret();
                dic.TryGetValue("zyjs_ret", out zyjs_ret_entity);
                string ybzfy = zyjs_ret_entity.Feeall;//医保总费用
                string jszfy = zyjs_ret_entity.Calfeeall;//结算总费用
                string qzf = zyjs_ret_entity.Feeout;//全自费
                string ggzf = zyjs_ret_entity.Feeself;//挂钩自付
                string yxbx = zyjs_ret_entity.Allowfund;//允许报销
                string bzqfx = zyjs_ret_entity.Startfee;//本次起付线
                string jrqfx = zyjs_ret_entity.Enterstartfee;//进入起付线
                string sbqfx = zyjs_ret_entity.Sbstartfee;//商保起付线
                string sbzf = zyjs_ret_entity.Sbpay;//商保支付
                string jbtcbx = zyjs_ret_entity.Fund1pay;//基本统筹支付
                if (cmbInsurType.Equals("2"))
                {
                    jbtcbx = zyjs_ret_entity.Allowfund;
                }
                string jbtczf = zyjs_ret_entity.Fund1self;//基本统筹自付
                string detcbx = zyjs_ret_entity.Fund2pay;//大额统筹支付
                string detczf = zyjs_ret_entity.Fund2self;//大额统筹自付
                string grzhzf = "0";//个人账户支付
                string cxezf = zyjs_ret_entity.Feeouer;//超限额自付
                string ylbzzf = zyjs_ret_entity.Fund3pay;//医疗补助支付
                //求个人账户余额
                string grzhye = zyjs_ret_entity.Acctpay;
                //总费用
                string feeall = zyjs_ret_entity.Hospfeeall;
                //医保报销
                string ybbx = (DataTool.stringToDouble(jbtcbx) + DataTool.stringToDouble(detcbx) + DataTool.stringToDouble(ylbzzf) + DataTool.stringToDouble(sbzf)).ToString();
                
                //个人应付
                string gryf = (Double.Parse(feeall) - Double.Parse(ybbx)).ToString();
                //个人账户最大支付 = 个人应付 - 全自费
                string grzh_max_zf = (Double.Parse(gryf) - Double.Parse(qzf)).ToString();
                
                if (Double.Parse(grzh_max_zf) < Double.Parse(grzhye))
                {
                    grzhzf = grzh_max_zf;
                }
                else
                {
                    grzhzf = grzhye;
                }
                
                //应收金额=[个人应付-个人账户支付-预交金额]
                string ysje = (Double.Parse(feeall) - Double.Parse(grzhzf) - Double.Parse(lblPaytotal.Text.Replace("元", ""))).ToString();
                this.tbxInsuraccountFee.Text = grzhzf;
                this.tbxBalance.Text = grzhye;
                this.tbxInsurefee.Text = ybbx;
                this.tbxyyzfy.Text = feeall;
                tbxYbzfy.Text = ybzfy;
                tbxjszfy.Text = jszfy;
                tbxqzf.Text = qzf;
                tbxggzf.Text = ggzf;
                tbxyxbx.Text = yxbx;
                tbxbcqfx.Text = bzqfx;
                tbxjbtcbx.Text = jbtcbx;
                tbxjbtczf.Text = jbtczf;
                tbxdetcbx.Text = detcbx;
                tbxdetczf.Text = detczf;
                tbxcxezf.Text = cxezf;
                tbxylbzzf.Text = ylbzzf;
                tbxSbqfx.Text = sbqfx;
                tbxSbzf.Text = sbzf;
                btnAccount.Enabled = true;
            }
            else if (cbxCheckSp.Checked == false)
            {
                StringBuilder message = new StringBuilder();
                DataTable dtInsur = bllInsurGYSYB.gysybIhspInfo(ihsp_id);
                string bxlb = cmbInsurType.SelectedValue.ToString();//保险类别
                string ybBzbm = tbxdbzbm.Text.Trim();//单病种编码
                string qsfs = cmbOutSettleType.SelectedValue.ToString();
                string jsfs = cmbSettleType.SelectedValue.ToString();  //结算方式 为1时，单病种编码不能为空
                string insurcode = dtInsur.Rows[0]["insurcode"].ToString();
                if (bxlb != "2" && bxlb != "5" && bxlb != "4" && bxlb!="7")
                {
                    if (jsfs != "0")
                    {
                        if (!bllInsurGYSYB.setCalType(message, jsfs, ybBzbm, insurcode))
                        {
                            MessageBox.Show("设置结算方式失败：" + message);
                            return;
                        }
                    }
                }
                message.Length = 0;
                string _qsfs = "1";//清算方式
                if (bxlb != "2" && bxlb != "7")
                {
                    if (qsfs != "9")
                    {
                        _qsfs = qsfs;//清算方式
                    }
                    if (!bllInsurGYSYB.setReckoningType(message, _qsfs, ybBzbm, insurcode))
                    {
                        MessageBox.Show("设置清算方式失败：" + message);
                        return;
                    }
                }

                message.Length = 0;
                string errInfo = "";
                Dictionary<String, Zyjs_ret> dic =bllInsurGYSYB.preSettle(ihsp_id, lblInvoice.Text, "0", message, out errInfo, jsfs, tbxdbzbm.Text);
                if (!string.IsNullOrEmpty(errInfo))
                {
                    MessageBox.Show(errInfo);
                    return;
                }
                BillSysBase.doIhspAmt(ihsp_id);
                Zyjs_ret zyjs_ret_entity = new Zyjs_ret();
                dic.TryGetValue("zyjs_ret", out zyjs_ret_entity);
                
                tbxYbzfy.Text = zyjs_ret_entity.Feeall;//医保总费用
                tbxjszfy.Text = zyjs_ret_entity.Calfeeall;//结算总费用
                tbxqzf.Text = zyjs_ret_entity.Feeout;//全自费
                tbxggzf.Text = zyjs_ret_entity.Feeself;//挂钩自付
                tbxyxbx.Text = zyjs_ret_entity.Allowfund;//允许报销
                tbxbcqfx.Text = zyjs_ret_entity.Startfee;//本次起付线
                tbxJrqfx.Text = zyjs_ret_entity.Enterstartfee;//进入起付线
                tbxSbqfx.Text = zyjs_ret_entity.Sbstartfee;//商保起付线
                tbxSbzf.Text = zyjs_ret_entity.Sbpay;//商保支付
                tbxjbtcbx.Text = zyjs_ret_entity.Fund1pay;//基本统筹支付
                if (cmbInsurType.Equals("2"))
                {
                    tbxjbtcbx.Text = zyjs_ret_entity.Allowfund;
                }
                tbxjbtczf.Text = zyjs_ret_entity.Fund1self;//基本统筹自付
                tbxdetcbx.Text = zyjs_ret_entity.Fund2pay;//大额统筹支付
                tbxdetczf.Text = zyjs_ret_entity.Fund2self;//大额统筹自付
                tbxcxezf.Text = zyjs_ret_entity.Feeouer;//超限额自付
                tbxylbzzf.Text = zyjs_ret_entity.Fund3pay;//医疗补助支付


                //求个人账户余额
                tbxBalance.Text = zyjs_ret_entity.Acctpay;//参考孔工方法 2014-5-3
                //grzhye.Text = GyybDb.getGysybGrzhye(Mtzyjliid); //zyjs_ret_entity.Acctbalance;
                //grzhye.Text = sybdk_entity.Zhye;
                //医保报销 = 基本统筹支付+大额统筹支付+医疗补助支付+商保支付
                string ybbx = (DataTool.Getdouble(tbxjbtcbx.Text) + DataTool.Getdouble(zyjs_ret_entity.Fund2pay) + DataTool.Getdouble(zyjs_ret_entity.Fund3pay) + DataTool.Getdouble(zyjs_ret_entity.Sbpay)).ToString();
                double feeall = DataTool.Getdouble(zyjs_ret_entity.Hospfeeall);

                //计算个人账户支付和应收现金
                //write by wzw 2014-4-19_12:29
                //总费用
                double d_yyzfy = feeall;
                //医保报销
                double d_ybbx = DataTool.Getdouble(ybbx.Trim());
                //个人应付=总费用-医保报销
                double d_gryfje = d_yyzfy - d_ybbx;
                //账户余额
                double d_grzhye = DataTool.Getdouble(tbxBalance.Text.Trim());
                double d_grzhzf = 0;
                //个人账户最大支付= 个人应付- 全自费
                double d_zhmax_zf = d_gryfje - DataTool.Getdouble(tbxqzf.Text);
                //个人账户最大支付 < 个人账户余额
                if (d_zhmax_zf < d_grzhye)
                {
                    d_grzhzf = d_zhmax_zf;
                }
                //个人账户最大支付 >=个人账户余额
                else
                {
                    d_grzhzf = d_grzhye;
                }
                
                //赋值个人账户支付
                tbxInsuraccountFee.Text = d_grzhzf.ToString("0.00");
                //预交款金额
                double d_yjkje = paytotal;
                //计算个人应收金额 {应收金额= [个人应付-个人账户支付-预交金额]}
                double d_grysje = d_gryfje - d_grzhzf - d_yjkje;
                //赋值收费员应收金额
                tbxInBalanceamt.Text = d_grysje.ToString("0.00");
                
                this.tbxInsurefee.Text = ybbx;//统筹支付
                this.tbxyyzfy.Text = feeall.ToString("0.00");//医院总金额

                btnAccount.Enabled = true;
            }
        }

        private void tbxdbzbm_KeyDown(object sender, KeyEventArgs e)
        {
            string bzbm = tbxdbzbm.Text.Trim();
            if (string.IsNullOrEmpty(bzbm))
            {
                tbxjsdbzmc.Text = "";
                cmbOutSettleType.SelectedIndex = 0;
            }
            if (cmbSettleType.SelectedValue.ToString().Equals("-1"))
            {
                return;
            }
            if (e.KeyData == Keys.Enter)
            {
                dgvtbz.Visible = true;
                dgvtbz.BringToFront();
                setDgvSource(bzbm.Trim());
                if (dgvtbz.Rows.Count > 0)
                {
                    dgvtbz.Rows[0].Selected = true;
                }
                dgvtbz.Focus();
            }
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            string settleType = cmbSettleType.SelectedValue.ToString();
            dgvtbz.DataSource = bllInsurGYSYB.queryYdbzml(pincode, settleType);
        }
        private void dgvtbz_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvtbz.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvtbz.CurrentRow != null)
                {
                    tbxdbzbm.Text = dgvtbz.CurrentRow.Cells["singleillnesscode"].Value.ToString();
                    tbxjsdbzmc.Text = dgvtbz.CurrentRow.Cells["singleillnessname"].Value.ToString();
                    dgvtbz.Visible = false;
                    dgvtbz.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvtbz.CurrentRow != null && dgvtbz.CurrentRow.Index > 0)
                {
                    dgvtbz.Rows[dgvtbz.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvtbz.CurrentRow != null && dgvtbz.CurrentRow.Index < dgvtbz.Rows.Count - 1)
                {
                    dgvtbz.Rows[dgvtbz.CurrentRow.Index + 1].Selected = true;
                }
            }
            else
            {
                dgvtbz.Visible = false;
                dgvtbz.Columns.Clear();
            }
        }

        private void tbxInBalanceamt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                //总费用
                double d_yyzfy = feetotal;
                //医保报销
                double d_insurefee = DataTool.Getdouble(tbxInsurefee.Text);
                //个人应付
                double d_gryfje = d_yyzfy - d_insurefee;
                //账户余额
                double d_grzhye = DataTool.Getdouble(tbxBalance.Text.Trim());
                //预交款金额
                double d_yjkje = paytotal;
                //计算个人应收金额 {应收金额= [个人应付金额-个人账户支付-预交金额]}
                double d_grysje = DataTool.Getdouble(tbxInBalanceamt.Text.Trim());
                double d_grzhzf = d_gryfje - d_grysje - paytotal;

                if (d_grzhzf > d_grzhye)
                {
                    tbxInsuraccountFee.Text = d_grzhye.ToString("0.00");
                }
                else if (d_grzhzf < 0)
                {
                    tbxInsuraccountFee.Text = "0.00";
                }
                else
                {
                    tbxInsuraccountFee.Text = d_grzhzf.ToString("0.00");
                }
            }
        }

        private void btnOuthsp_Click(object sender, EventArgs e)
        {
            BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            DataTable dt = bllInsurGYSYB.getInsurstat(ihsp_id);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][0].ToString() == Insurstat.SETT.ToString())
                {
                    string outtype = this.cyyy.SelectedValue.ToString();//出院原因
                    StringBuilder message = new StringBuilder();
                    if (!bllInsurGYSYB.Cydj(ihsp_id, outtype, message))
                    {
                        MessageBox.Show("医保接口出院办理失败！" + message.ToString());
                        return;
                    }
                }
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
                lblInvoiceMsg.Text = "现在选择网络支付";

            }
            else
            {
                lblInvoiceMsg.Text = "                    ";
            }
        }

    }
}
