using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bean;
using System.Web.UI.WebControls;
using MTREG.ihsp.bll;


namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmYlFyMxDz : Form
    {
        public FrmYlFyMxDz()
        {
            InitializeComponent();
        }
        SjzybInterface sjzybInterface = new SjzybInterface();
        private void FrmYlFyMxDz_Load(object sender, EventArgs e)
        {
            //去掉空白行
            dgv_ybdzmx.AllowUserToAddRows = false;
            dgv_dzxx.AllowUserToAddRows = false;
            //窗体默认化大小
            this.WindowState = FormWindowState.Normal;
            //业务类别
            Business();
            //初始化
            GRpo();
            //内容居中
            dgv_ybdzmx.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ybdzmx.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        //初始化界面数据
        public void GRpo()
        {
            //开始时间
            DateTime starttime = (Convert.ToDateTime(this.dt_kssj.Text));
            //结束时间
            DateTime endtime = (Convert.ToDateTime(this.dt_jssj.Text));
            string type = cmb_ywlb.SelectedValue.ToString();
            BllItemcrossSJZ BllItemcrossSJZ = new BllItemcrossSJZ();
            DataTable dt = BllItemcrossSJZ.GETAccount(starttime.ToString("yyyy-MM-dd 00:00:00"), endtime.ToString("yyyy-MM-dd 23:59:59"), type,"");
            dgv_ybdzmx.DataSource = dt;
            dgv_ybdzmx.Columns["name"].HeaderText = "患者姓名";
            dgv_ybdzmx.Columns["name"].Width = 100;
            dgv_ybdzmx.Columns["name"].DisplayIndex = 0;

            dgv_ybdzmx.Columns["AKC190"].HeaderText = "住院号";
            dgv_ybdzmx.Columns["AKC190"].Width = 80;
            dgv_ybdzmx.Columns["AKC190"].DisplayIndex = 1;

            dgv_ybdzmx.Columns["AAE072"].HeaderText = "发票号";
            dgv_ybdzmx.Columns["AAE072"].Width = 80;
            dgv_ybdzmx.Columns["AAE072"].DisplayIndex = 2;

            dgv_ybdzmx.Columns["AKC264"].HeaderText = "发送方医疗费总额";
            dgv_ybdzmx.Columns["AKC264"].Width = 160;
            dgv_ybdzmx.Columns["AKC264"].DisplayIndex = 3;

            dgv_ybdzmx.Columns["AKC255"].HeaderText = "发送方帐户支付合计";
            dgv_ybdzmx.Columns["AKC255"].Width = 160;
            dgv_ybdzmx.Columns["AKC255"].DisplayIndex = 4;

            dgv_ybdzmx.Columns["AKC260"].HeaderText = "发送方统筹基金支付合计";
            dgv_ybdzmx.Columns["AKC260"].Width = 160;
            dgv_ybdzmx.Columns["AKC260"].DisplayIndex = 5;


            dgv_ybdzmx.Columns["AKC261"].HeaderText = "发送方现金支付合计";
            dgv_ybdzmx.Columns["AKC261"].Width = 160;
            dgv_ybdzmx.Columns["AKC261"].DisplayIndex = 6;

            dgv_ybdzmx.Columns["AKC706"].HeaderText = "发送方大病救助基金支付";
            dgv_ybdzmx.Columns["AKC706"].Width = 160;
            dgv_ybdzmx.Columns["AKC706"].DisplayIndex = 7;

            dgv_ybdzmx.Columns["AKC707"].HeaderText = "发送方公务员补助合计";
            dgv_ybdzmx.Columns["AKC707"].Width = 160;
            dgv_ybdzmx.Columns["AKC707"].DisplayIndex = 8;

            dgv_ybdzmx.Columns["AKC708"].HeaderText = "发送方其他基金支付合计";
            dgv_ybdzmx.Columns["AKC708"].Width = 160;
            dgv_ybdzmx.Columns["AKC708"].DisplayIndex = 9;

            dgv_ybdzmx.Columns["status"].HeaderText = "结算状态";
            dgv_ybdzmx.Columns["status"].Width = 160;
            dgv_ybdzmx.Columns["status"].DisplayIndex = 10;

            dgv_ybdzmx.Columns["MSGID"].HeaderText = "发送方交易流水号";
            dgv_ybdzmx.Columns["MSGID"].Width = 160;
            dgv_ybdzmx.Columns["MSGID"].DisplayIndex = 11;

            dgv_ybdzmx.Columns["REFMSGID"].HeaderText = "接收方交易流水号";
            dgv_ybdzmx.Columns["REFMSGID"].Width = 160;
            dgv_ybdzmx.Columns["REFMSGID"].DisplayIndex = 12;

        }
        public void getjsxx()
        {
            DateTime Startime = dt_kssj.Value;
            DateTime endtime = dt_jssj.Value;
            string from = cmb_ywlb.SelectedValue.ToString();

            SJZYB_IN<SettlementInfo_In> yb_in_info = new SJZYB_IN<SettlementInfo_In>();
            yb_in_info.INPUT = new List<SettlementInfo_In>();
            SettlementInfo_In dom = new SettlementInfo_In();
            dom.CKA130 = from;
            dom.AAE030 = Startime.ToString("yyyy-MM-dd");
            dom.AAE031 = endtime.ToString("yyyy-MM-dd");
            dom.CKAA08 = "";
            dom.CURRENTPAGE = "1";
            yb_in_info.INPUT.Add(dom);
            yb_in_info.MSGNO = "1637";

            SettlementInfo_Out yb_out_info = new SettlementInfo_Out();
            int ret = sjzybInterface.DownloadInfo(yb_in_info, ref yb_out_info);

            string ReturnMsg = "";
            if (yb_out_info.OUTROW != null)
            {
                if (int.Parse(yb_out_info.TOTALPAGE) > 2)
                {
                    for (int i = 2; i <= int.Parse(yb_out_info.TOTALPAGE); i++)
                    //for (int i = 100; i <= 120; i++)
                    {
                        yb_in_info.INPUT = new List<SettlementInfo_In>();
                        dom = new SettlementInfo_In();
                        dom.CURRENTPAGE = i.ToString();
                        dom.CKA130 = from;
                        dom.AAE030 = Startime.ToString("yyyy-MM-dd");
                        dom.AAE031 = endtime.ToString("yyyy-MM-dd");
                        dom.CKAA08 = "";
                        yb_in_info.INPUT.Add(dom);
                        ret = sjzybInterface.DownloadInfo(yb_in_info, ref yb_out_info);
                        int returnnum = Convert.ToInt32(yb_out_info.RETURNNUM);
                        if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                        {
                            ReturnMsg = yb_out_info.ERRORMSG;
                            MessageBox.Show(ReturnMsg, "提示信息");
                            return;
                        }
                    }
                }
            }
            if (yb_out_info.OUTROW == null || yb_out_info.OUTROW.Count < 0)
            {
                return;
            }
            DataTable dt = yb_out_info.OUTROW.ToDataTable<SettlementInfo_Out_OUTROW>();
            dataGridView(dt);
        }
        public void dataGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["AAE040"] = dr["AAE040"].ToString().Substring(0, 4) + dr["AAE040"].ToString().Substring(4, 2) + dr["AAE040"].ToString().Substring(6, 2);
                //if (String.IsNullOrEmpty(dr["CKAA09"].ToString()))
                //dr["CKAA09"] = dr["CKAA09"].ToString().Substring(0, 4) + dr["CKAA09"].ToString().Substring(4, 2) + dr["CKAA09"].ToString().Substring(6, 2);
                if (dr["CKAA08"].ToString() == "0")
                {
                    dr["CKAA08"] = "未对账";
                }
                else if (dr["CKAA08"].ToString() == "1")
                {
                    dr["CKAA08"] = "账平";
                }
                else if (dr["CKAA08"].ToString() == "2")
                {
                    dr["CKAA08"] = "账不平";
                }
                dr["BAC081"] = dr["BAC081"] == "0" ? "否" : "是";
            }
            dgv_dzxx.DataSource = dt;
            

            #region
            dgv_dzxx.Columns["AKB020"].HeaderText = "                            ";
            dgv_dzxx.Columns["AKB020"].DisplayIndex = 0;
            dgv_dzxx.Columns["AKB020"].Width = 200;

            dgv_dzxx.Columns["AKC190"].HeaderText = "门诊住院流水号";
            dgv_dzxx.Columns["AKC190"].Width = 150;
            dgv_dzxx.Columns["AKC190"].DisplayIndex = 1;

            dgv_dzxx.Columns["AAE072"].HeaderText = "单据号";
            dgv_dzxx.Columns["AAE072"].DisplayIndex = 2;
            dgv_dzxx.Columns["AAE072"].Width = 200;

            dgv_dzxx.Columns["AAE040"].HeaderText = "结算日期";
            dgv_dzxx.Columns["AAE040"].Width = 150;
            dgv_dzxx.Columns["AAE040"].DisplayIndex = 3;

            dgv_dzxx.Columns["AAC001"].HeaderText = "个人编号";
            dgv_dzxx.Columns["AAC001"].Width = 100;
            dgv_dzxx.Columns["AAC001"].DisplayIndex = 4;

            dgv_dzxx.Columns["AKC020"].HeaderText = "社保卡号";
            dgv_dzxx.Columns["AKC020"].Width = 100;
            dgv_dzxx.Columns["AKC020"].DisplayIndex = 5;

            dgv_dzxx.Columns["AKC275"].HeaderText = "发送方交易流水号";
            dgv_dzxx.Columns["AKC275"].Width = 100;
            dgv_dzxx.Columns["AKC275"].DisplayIndex = 6;

            dgv_dzxx.Columns["AKC276"].HeaderText = "接收方交易流水号";
            dgv_dzxx.Columns["AKC276"].Width = 100;
            dgv_dzxx.Columns["AKC276"].DisplayIndex = 7;

            dgv_dzxx.Columns["AKC281"].HeaderText = "撤销（或被撤销）的发送方交易流水号";
            dgv_dzxx.Columns["AKC281"].Width = 100;
            dgv_dzxx.Columns["AKC281"].DisplayIndex = 8;

            dgv_dzxx.Columns["AKC282"].HeaderText = "撤销（或被撤销）的接收方交易流水号";
            dgv_dzxx.Columns["AKC282"].Width = 100;
            dgv_dzxx.Columns["AKC282"].DisplayIndex = 9;

            dgv_dzxx.Columns["AKC283"].HeaderText = "冲正（或被冲正）的发送方交易流水号";
            dgv_dzxx.Columns["AKC283"].Width = 100;
            dgv_dzxx.Columns["AKC283"].DisplayIndex = 10;

            dgv_dzxx.Columns["AKC284"].HeaderText = "被冲正（或被冲正）的接收方交易流水号";
            dgv_dzxx.Columns["AKC284"].Width = 150;
            dgv_dzxx.Columns["AKC284"].DisplayIndex = 11;

            dgv_dzxx.Columns["AKC332"].HeaderText = "业务周期号";
            dgv_dzxx.Columns["AKC332"].DisplayIndex = 12;
            dgv_dzxx.Columns["AKC332"].Width = 200;

            dgv_dzxx.Columns["AKC264"].HeaderText = "医疗费总额";
            dgv_dzxx.Columns["AKC264"].Width = 150;
            dgv_dzxx.Columns["AKC264"].DisplayIndex = 13;

            dgv_dzxx.Columns["AKC255"].HeaderText = "帐户支付";
            dgv_dzxx.Columns["AKC255"].Width = 100;
            dgv_dzxx.Columns["AKC255"].DisplayIndex = 14;

            dgv_dzxx.Columns["AKC260"].HeaderText = "统筹基金支付";
            dgv_dzxx.Columns["AKC260"].Width = 100;
            dgv_dzxx.Columns["AKC260"].DisplayIndex = 15;

            dgv_dzxx.Columns["AKC261"].HeaderText = "现金支付";
            dgv_dzxx.Columns["AKC261"].Width = 100;
            dgv_dzxx.Columns["AKC261"].DisplayIndex = 16;

            dgv_dzxx.Columns["AKC706"].HeaderText = "大病救助基金支付";
            dgv_dzxx.Columns["AKC706"].Width = 100;
            dgv_dzxx.Columns["AKC706"].DisplayIndex = 17;

            dgv_dzxx.Columns["AKC707"].HeaderText = "公务员补助支付";
            dgv_dzxx.Columns["AKC707"].Width = 100;
            dgv_dzxx.Columns["AKC707"].DisplayIndex = 18;

            dgv_dzxx.Columns["AKC708"].HeaderText = "其他基金支出";
            dgv_dzxx.Columns["AKC708"].Width = 100;
            dgv_dzxx.Columns["AKC708"].DisplayIndex = 19;

            dgv_dzxx.Columns["MSGNO"].HeaderText = "交易代码";
            dgv_dzxx.Columns["MSGNO"].Width = 100;
            dgv_dzxx.Columns["MSGNO"].DisplayIndex = 20;

            dgv_dzxx.Columns["CKAA08"].HeaderText = "对账状态";
            dgv_dzxx.Columns["CKAA08"].Width = 150;
            dgv_dzxx.Columns["CKAA08"].DisplayIndex = 21;

            dgv_dzxx.Columns["CKAA09"].HeaderText = "对账时间";
            dgv_dzxx.Columns["CKAA09"].DisplayIndex = 22;
            dgv_dzxx.Columns["CKAA09"].Width = 200;

            dgv_dzxx.Columns["CKAA20"].HeaderText = "基本提高支付（发票）";
            dgv_dzxx.Columns["CKAA20"].Width = 150;
            dgv_dzxx.Columns["CKAA20"].DisplayIndex = 23;

            dgv_dzxx.Columns["CKAA27"].HeaderText = "大病提高支付（发票）";
            dgv_dzxx.Columns["CKAA27"].Width = 100;
            dgv_dzxx.Columns["CKAA27"].DisplayIndex = 24;

            dgv_dzxx.Columns["BKE151"].HeaderText = "医疗救助支付（发票）";
            dgv_dzxx.Columns["BKE151"].Width = 100;
            dgv_dzxx.Columns["BKE151"].DisplayIndex = 25;

            dgv_dzxx.Columns["CKAA40"].HeaderText = "医疗救助补充支付（发票）";
            dgv_dzxx.Columns["CKAA40"].Width = 100;
            dgv_dzxx.Columns["CKAA40"].DisplayIndex = 26;

            dgv_dzxx.Columns["BAC081"].HeaderText = "贫困人口标志";
            dgv_dzxx.Columns["BAC081"].Width = 100;
            dgv_dzxx.Columns["BAC081"].DisplayIndex = 27;
            #endregion
            for (int i = 0; i < dgv_dzxx.Rows.Count; i++)
            {
                if (dgv_dzxx.Rows[i].Cells["AKC283"].Value.ToString() != "" || dgv_dzxx.Rows[i].Cells["CKAA08"].Value.ToString() == "账平")
                {
                    dgv_dzxx.CurrentCell = null;
                    dgv_dzxx.Rows[i].Visible = false; //隐藏行
                }
            }

        }
        //业务类别
        public void Business()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("门诊", "1"));
            items.Add(new ListItem("住院", "2"));
            this.cmb_ywlb.DisplayMember = "Text";
            this.cmb_ywlb.ValueMember = "Value";
            this.cmb_ywlb.DataSource = items;
            cmb_ywlb.SelectedValue = "1";
        }
        //类别下拉值更新刷新数据
        private void cbT_ywlb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GRpo();
            getjsxx();
        }
        //开始时间值更新刷新数据
        private void dt_kssj_ValueChanged(object sender, EventArgs e)
        {
            GRpo();
            getjsxx();
        }
        //结束时间值更新刷新数据
        private void dt_jssj_ValueChanged(object sender, EventArgs e)
        {
            GRpo();
            getjsxx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime starttime = (Convert.ToDateTime(this.dt_kssj.Text));
            DateTime endtime = (Convert.ToDateTime(this.dt_jssj.Text));
            string type = cmb_ywlb.SelectedValue.ToString();
            BllItemcrossSJZ BllItemcrossSJZ = new BllItemcrossSJZ();

            DataTable dt = BllItemcrossSJZ.GETAccount(starttime.ToString("yyyy-MM-dd 00:00:00"), endtime.ToString("yyyy-MM-dd 23:59:59"), type,"");
            SJZYB_IN<Reconciliation_In_xm> yb_in_dz = new SJZYB_IN<Reconciliation_In_xm>();
            yb_in_dz.INPUT = new List<Reconciliation_In_xm>();
            List<Reconciliation_Out_xm> yb_out_dz = new List<Reconciliation_Out_xm>(); ;
            yb_in_dz.MSGNO = "1121";
            for (int i = 0; i < dgv_ybdzmx.Rows.Count; i++)
            {
                Reconciliation_In_xm dom = new Reconciliation_In_xm();
                dom.MSGID = dgv_ybdzmx.Rows[i].Cells["MSGID"].Value.ToString();
                dom.REFMSGID = dgv_ybdzmx.Rows[i].Cells["REFMSGID"].Value.ToString();
                dom.AKC264 = dgv_ybdzmx.Rows[i].Cells["AKC264"].Value.ToString();
                dom.AKC255 = dgv_ybdzmx.Rows[i].Cells["AKC255"].Value.ToString();
                dom.AKC260 = dgv_ybdzmx.Rows[i].Cells["AKC260"].Value.ToString();
                dom.AKC261 = dgv_ybdzmx.Rows[i].Cells["AKC261"].Value.ToString();
                dom.AKC706 = dgv_ybdzmx.Rows[i].Cells["AKC706"].Value.ToString();
                dom.AKC707 = dgv_ybdzmx.Rows[i].Cells["AKC707"].Value.ToString();
                dom.AKC708 = dgv_ybdzmx.Rows[i].Cells["AKC708"].Value.ToString();
                yb_in_dz.INPUT.Add(dom);

                if (yb_in_dz.INPUT.Count == 100)
                {
                    int ret = sjzybInterface.ylxxdz_mx(yb_in_dz, ref yb_out_dz);
                    if (ret == -1)
                    {
                        MessageBox.Show(yb_out_dz[0].ERRORMSG, "提示信息");
                        return;
                    }
                    yb_in_dz.INPUT.Clear();
                }
            } 
            if (yb_in_dz.INPUT.Count > 0)
            {
                int rets = sjzybInterface.ylxxdz_mx(yb_in_dz, ref yb_out_dz);
                if (rets == -1)
                {
                    MessageBox.Show(yb_out_dz[0].ERRORMSG, "提示信息");
                    return;
                }
            }
            MessageBox.Show("对账完成！", "提示信息");
            getjsxx();
        }
       
    }
}
