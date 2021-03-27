using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.netpay;
using MTHIS.tools;
using MTREG.netpay.bo;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.hdyb;
using MTREG.tools;
using MTHIS.db;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
//using MTREG.medinsur.hdyb.dor;
using MTREG.common;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.medinsur;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdyb.bo;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb.dor;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;
using System.IO;
using MTREG.ihsp;
using MTREG.ihsptab.bo;
using System.Diagnostics;


namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmSybCy : Form
    {
        public FrmSybCy()
        {
            InitializeComponent();
        }
        SjzybInterface sjzybInterface = new SjzybInterface();
        YBCJ yw1 = new YBCJ();
        BllMain db = new BllMain();
        JKDB jkdb = new JKDB();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsur bllInsur = new BllInsur();
        Ihspaccount ihspaccount = new Ihspaccount();
        private string zyh_;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh_
        {
            get { return zyh_; }
            set { zyh_ = value; }
        }
        private string ihsp_id;
        /// <summary>
        /// 住院记录id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string grbh_;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh_
        {
            get { return grbh_; }
            set { grbh_ = value; }
        }
        private string jmylzh_;
        /// <summary>
        /// 居民医疗证号
        /// </summary>
        public string Jmylzh_
        {
            get { return jmylzh_; }
            set { jmylzh_ = value; }
        }
        private string account;
        /// <summary>
        /// 医疗付款方式
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string ylkfkfs;
        /// <summary>
        /// 医疗付款方式
        /// </summary>
        public string Ylkfkfs
        {
            get { return ylkfkfs; }
            set { ylkfkfs = value; }
        }
        private bool isck = false;
        /// <summary>
        /// 是否持卡
        /// </summary>
        public bool Isck
        {
            get { return isck; }
            set { isck = value; }
        }
        private string member_id = "";
        string invoicecode = "";//发票号
        string nextinvoicesql = "";//发票号sql

        private void FrmYbCy1_Load(object sender, EventArgs e)
        {
            initButton();
            inityjk();
            initFklx();
            initCyyy();
            initYllb();
            cxfy();
            initTpMge();
            initjz();
            this.yjkzfy.Text = cxyjkzfy(ihsp_id);
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                this.fphtext.Text = "";
                this.fphtext.ReadOnly = false;
            }
            else
            {
                this.fphtext.ReadOnly = true;
                this.fphtext.Text = getNextZyFph();//获取当前发票号
            }

        }
        /// <summary>
        /// 按钮
        /// </summary>
        public void initButton()
        {
            try
            {
                if (string.IsNullOrEmpty(ihsp_id))
                {
                    return;
                }
                string sql_nhflag = "select status from inhospital where id= " + ihsp_id;
                DataTable dt_nhflag = BllMain.Db.Select(sql_nhflag).Tables[0];
                this.lb_hiszt.Text = dt_nhflag.Rows[0]["status"].ToString().Trim();
                if (dt_nhflag.Rows.Count == 0)
                {
                    return;
                }
                if (dt_nhflag.Rows[0]["status"].ToString().Trim() == "SIGN")//已挂账
                {
                    btnXfsj.Enabled = true;//费用上传
                    btn_YbChScfy.Enabled = true;//删除费用上传
                    btn_jscd.Enabled = false;//重打发票
                    btn_yjs.Enabled = true;//预结算
                    btn_jsht.Enabled = false;//结算回退
                    btn_js.Enabled = false;//结算
                }
                else if (dt_nhflag.Rows[0]["status"].ToString().Trim() == "SETT")//已结算
                {
                    btnXfsj.Enabled = false;//费用上传
                    btn_YbChScfy.Enabled = false;//删除费用上传
                    btn_jscd.Enabled = true;//重打发票
                    btn_yjs.Enabled = false;//预结算
                    btn_jsht.Enabled = true;//结算回退
                    btn_js.Enabled = false;//结算
                }
                else
                {
                    btnXfsj.Enabled = true;//费用上传
                    btn_YbChScfy.Enabled = true;//删除费用上传
                    btn_jscd.Enabled = false;//重打发票
                    btn_yjs.Enabled = false;//预结算
                    btn_jsht.Enabled = false;//结算回退
                    btn_js.Enabled = false;//结算
                }
                if (Ylkfkfs == "35")
                {
                    button3.Visible = true;
                }

            }
            catch
            { }
        }
        /// <summary>
        /// 预交款
        /// </summary>
        public void inityjk()
        {
            DataTable datatable = billIhspAct.payAccount(ihsp_id);
            label19.Text = label19.Text.Trim() + "   " + datatable.Rows.Count;
            dgvjs_yjk.DataSource = datatable;
            double paytotal = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                paytotal += double.Parse(DataTool.FormatData(datatable.Rows[i]["payfee"].ToString(), "2"));
            }
            this.yjkzfy.Text = DataTool.FormatData(paytotal.ToString(), "2");

        }
        /// <summary>
        /// 付款类型
        /// </summary>
        private void initFklx()
        {
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cbx_fklx.ValueMember = "id";
                this.cbx_fklx.DisplayMember = "name";
                this.cbx_fklx.DataSource = dtpt;
                this.cbx_fklx.SelectedValue = "1";
            }
        }
        /// <summary>
        /// 出院原因
        /// </summary>
        private void initCyyy()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("康复", "1"));
            items.Add(new ListItem("转院", "2"));
            items.Add(new ListItem("死亡", "3"));
            items.Add(new ListItem("其他", "7"));
            this.comboCyyy.DisplayMember = "Text";
            this.comboCyyy.ValueMember = "Value";
            this.comboCyyy.DataSource = items;
            comboCyyy.SelectedValue = "1";
        }
        /// <summary>
        /// 医疗类别
        /// </summary>
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("普通住院", "21"));
            items.Add(new ListItem("转入住院", "25"));
            items.Add(new ListItem("意外伤害住院", "27"));
            items.Add(new ListItem("生育住院", "52"));

            this.combocyjsyllb.DisplayMember = "Text";
            this.combocyjsyllb.ValueMember = "Value";
            this.combocyjsyllb.DataSource = items;
        }
        /// <summary>
        /// 是否双侧输卵管结扎
        /// </summary>
        private void initjz()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("无", ""));
            items.Add(new ListItem("是", "1"));
            items.Add(new ListItem("否", "0"));

            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.ValueMember = "Value";
            this.comboBox2.DataSource = items;
        }
        /// <summary>
        /// 初始化界面信息
        /// </summary>
        private void initTpMge()
        {
            string sql = "select * from sybzyjl where AKC190= '" + zyh_ + "'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string sql1 = "select  inhospital.`name`,inhospital.member_id,inhospital.indate AS zyjlrysj,inhospital.outdate as zyjlcysj,inhospital.bas_patienttype_id as zyjlylfkfs,sexList.name as sex,insurcode ,healthcard from inhospital left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0 where inhospital.id=" + ihsp_id;
            DataTable dt_cysj = BllMain.Db.Select(sql1).Tables[0];
            this.textBox1.Text = dt_cysj.Rows[0]["sex"].ToString().Trim();
            this.lbl_ylfkfs.Text = dt_cysj.Rows[0]["zyjlylfkfs"].ToString().Trim();
            string sql3 = "select inhospital.outdiagn as cyzd,bas_depart.name as ks,bas_doctor.name as ys from inhospital left join bas_doctor on inhospital.doctor_id=bas_doctor.id  left join bas_depart on inhospital.depart_id=bas_depart.id where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt_cyjbmc = BllMain.Db.Select(sql3).Tables[0];
            string sql4 = " SELECT insur_illness_name AS cyzd,insur_illness_illcode AS CODE,a.diagndate,a.opkind FROM insur_directory_contrast LEFT JOIN (SELECT ihsp_id,diagnICD,diagndate,opkind,sn FROM ihsp_diagnmes WHERE diagnKind = 'OUT' ) a ON a.diagnICD = insur_directory_contrast.bas_caseicd_case_icd10 WHERE a.ihsp_id =  " + DataTool.addFieldBraces(ihsp_id) + " order by a.sn";
            DataTable dt_cyzd = BllMain.Db.Select(sql4).Tables[0];
            string cysj = dt_cysj.Rows[0]["zyjlcysj"].ToString().Trim();
            this.cyjsCyrq.Text = cysj;
            member_id = dt_cysj.Rows[0]["member_id"].ToString();
            this.cyjsZyh.Text = dt.Rows[0]["AKC190"].ToString().Trim();
            this.cyjsXm.Text = dt_cysj.Rows[0]["name"].ToString().Trim();
            this.CyjsKs.Text = dt_cyjbmc.Rows[0]["ks"].ToString().Trim();//dt.Rows[0]["zkc272"].ToString().Trim();
            this.cyjsGrbh.Text = dt_cysj.Rows[0]["insurcode"].ToString().Trim();
            this.cyjsICkh.Text = dt_cysj.Rows[0]["healthcard"].ToString().Trim();
            //医疗证号等同个人编号
            //jmylzh_ = dt.Rows[0]["AAC001"].ToString().Trim();
            this.cyjsYs.Text = dt_cyjbmc.Rows[0]["ys"].ToString().Trim();
            this.cyjsRyrq.Text = dt_cysj.Rows[0]["zyjlrysj"].ToString().Trim();
            foreach (DataRow dr in dt_cyzd.Rows)
            {
                this.cyjsCyjb.Text += dr["cyzd"].ToString().Trim() + ","; //dt.Rows[0]["zkc275"].ToString().Trim();
                this.cyjsCyjbcode.Text += dr["code"].ToString().Trim() + ",";
            }
            this.combocyjsyllb.SelectedValue = dt.Rows[0]["AKA130"].ToString().Trim();

            string sql_rc = "SELECT bas_sickroom.`name` AS romm, bas_sickbed.`name` AS cw FROM inhospital LEFT JOIN bas_sickbed ON bas_sickbed.id = inhospital.sickbed_id LEFT JOIN bas_sickroom ON bas_sickroom.id = inhospital.sickroom_id  WHERE ihspcode = " + DataTool.addFieldBraces(zyh_);
            DataTable dt4 = BllMain.Db.Select(sql_rc).Tables[0];
            this.cyjsBfh.Text = dt4.Rows[0]["romm"].ToString().Trim();
            this.tbx_bch.Text = dt4.Rows[0]["cw"].ToString().Trim();
            string sumFeeSql = "select sum(fee) as sumAmt from ihsp_costdet where  ihsp_costdet.charged in('CHAR') and ihsp_id= " + ihsp_id;
            DataTable temSum = BllMain.Db.Select(sumFeeSql).Tables[0];
            hisFeeLable.Text = temSum.Rows[0]["sumAmt"].ToString().Trim();//his费用

            //ybfy(this.cyjsZyh.Text.Trim());//城乡费用
            this.fymxcount();
            return;
        }
        ///// <summary>
        ///// 医保费用
        ///// </summary>
        ///// <param name="zyh"></param>
        //private void ybfy(string zyh)
        //{
        //    string sql = "select sum(AKC227) from KC22 where AKC190='" + zyh + "' and  CKC126=1";

        //    DataTable dt = jkdb.Select(sql).Tables[0];
        //    string amt = dt.Rows[0][0].ToString().Trim();

        //}
        /// <summary>
        /// 上传情况
        /// </summary>
        private void fymxcount()
        {

            string count1 = "select count(id) as zhs from ihsp_costdet where charged IN (   'CHAR' ) and ihsp_id = " + ihsp_id;//_iid.ToString().Trim();
            string count2 = "select count(id) as yschs from ihsp_costdet where charged IN (   'CHAR' ) and insursync = 'Y' and ihsp_id = " + ihsp_id;//+ _iid.ToString().Trim();
            string count3 = "select count(id) as syhs from ihsp_costdet where charged IN (   'CHAR' ) and insursync ='N' and ihsp_id = " + ihsp_id;//_iid.ToString().Trim();


            DataTable dt_count1 = BllMain.Db.Select(count1).Tables[0];
            DataTable dt_count2 = BllMain.Db.Select(count2).Tables[0];
            DataTable dt_count3 = BllMain.Db.Select(count3).Tables[0];
            this.label_zg.Text = dt_count1.Rows[0]["zhs"].ToString().Trim();//总共
            this.label_sc.Text = dt_count2.Rows[0]["yschs"].ToString().Trim();//已上传
            this.label_sy.Text = dt_count3.Rows[0]["syhs"].ToString().Trim();//未上传



        }
        /// <summary>
        /// 预交款总费用
        /// </summary>
        /// <param name="ihs_id"></param>
        /// <returns></returns>
        public String cxyjkzfy(string ihs_id)
        {
            String sql = " select COALESCE( sum(payfee),0) as amt from ihsp_payinadv where ihsp_id='" + ihsp_id + "' ";
            return BllMain.Db.Select(sql).Tables[0].Rows[0]["amt"].ToString().Trim(); //所有预交款
        }
        /// <summary>
        /// 获取发票
        /// </summary>
        /// <returns></returns>
        public String getNextZyFph()
        {

            string invoiceKind = billIhspAct.getInvoiceKind(this.ylkfkfs);
            if (invoiceKind == "")
            {
                return "1222222222222222";
            }
            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                MessageBox.Show("发票已用完，不能进行收费！");
                return "";
            }
            int invoiceNum = billIhspAct.getInvoiceNum(invoiceKind, ProgramGlobal.User_id.Trim().ToString());
            if (invoiceNum < 10)
            {
                fpsy_label.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
            }
            else if (invoiceNum >= 10)
            {
                fpsy_label.Text = "";
            }
            return invoicecode;
        }
        /// <summary>
        /// 初始化费用
        /// </summary>
        private void cxfy()
        {
            string sql0 = "UPDATE ihsp_costdet SET fee = ROUND(num * prc,2) WHERE ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(sql0);
            string sql2 = "UPDATE inhospital SET feeamt = (SELECT SUM(fee) FROM ihsp_costdet WHERE ihsp_costdet.ihsp_id = inhospital.id) WHERE id = " + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(sql2);
            string sql1 = "SELECT "
                        + " inhospital.ihspcode AS '住院号',"
                        + " ihsp_costdet.NAME AS '项目名称',"
                        + " ihsp_costdet.prc AS '单价',"
                        + " ihsp_costdet.num AS '数量',"
                        + " ihsp_costdet.fee AS '金额',"
                        + " ihsp_costdet.itemfrom AS '项目类别',"
                        + " cost_insurcross.insurcode  AS '医保编码',"
                        + " ihsp_costdet.ihsp_advdet_id AS '处方号',"
                        + " ihsp_costdet.costexdate AS '创建日期',"
                        + " ihsp_costdet.costexdate AS '开方日期',"
                        + " ihsp_costdet.insursync AS '是否上传',"
                        + " ihsp_costdet.item_id AS prodiid,"
                        + " ihsp_costdet.id "
                    + " FROM"
                        + " ihsp_costdet"
                    + " LEFT JOIN inhospital ON inhospital.id = ihsp_costdet.ihsp_id "
                    + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = ihsp_costdet.item_id AND cost_insurcross.isstop = 'T'"
                    + " WHERE"
                        + " inhospital.id = ihsp_costdet.ihsp_id "
                        + " AND charged IN (   'CHAR' ) "
                        + " AND inhospital.id =  " + DataTool.addFieldBraces(ihsp_id);

            DataTable dtTmp = BllMain.Db.Select(sql1).Tables[0];
            if (dtTmp.Rows.Count == 0)
            {
                return;
            }
            this.dataGridView2.DataSource = dtTmp.DefaultView;

            #region
            dataGridView2.Columns["住院号"].Width = 100;
            dataGridView2.Columns["住院号"].DisplayIndex = 0;

            dataGridView2.Columns["项目名称"].Width = 150;
            dataGridView2.Columns["项目名称"].DisplayIndex = 1;

            dataGridView2.Columns["单价"].Width = 70;
            dataGridView2.Columns["单价"].DisplayIndex = 2;

            dataGridView2.Columns["数量"].Width = 70;
            dataGridView2.Columns["数量"].DisplayIndex = 3;

            dataGridView2.Columns["金额"].Width = 70;
            dataGridView2.Columns["金额"].DisplayIndex = 4;

            dataGridView2.Columns["项目类别"].Width = 100;
            dataGridView2.Columns["项目类别"].DisplayIndex = 5;

            dataGridView2.Columns["医保编码"].Width = 150;
            dataGridView2.Columns["医保编码"].DisplayIndex = 6;

            dataGridView2.Columns["处方号"].Width = 150;
            dataGridView2.Columns["处方号"].DisplayIndex = 7;

            dataGridView2.Columns["创建日期"].Width = 150;
            dataGridView2.Columns["创建日期"].DisplayIndex = 8;

            dataGridView2.Columns["开方日期"].Width = 150;
            dataGridView2.Columns["开方日期"].DisplayIndex = 9;

            dataGridView2.Columns["是否上传"].Width = 70;
            dataGridView2.Columns["是否上传"].DisplayIndex = 10;

            dataGridView2.Columns["prodiid"].Width = 70;
            dataGridView2.Columns["prodiid"].DisplayIndex = 11;

            dataGridView2.Columns["id"].Width = 70;
            dataGridView2.Columns["id"].DisplayIndex = 12;
            #endregion
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                if (dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "N" || dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "")
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未上传黄色
                if ((dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "") || (dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "0"))
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;//无编码红色
                //if ((dataGridView2.Rows[i].Cells["药品提示信息"].Value.ToString() != "") && (!((dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "1") || (dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "2"))))
                //    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;//限制性青色
            }
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {

            Sjzzyybfysc ybfysc = new Sjzzyybfysc();
            RetMsg ret = ybfysc.ybscfymx(int.Parse(ihsp_id), ylkfkfs, cyjsGrbh.Text.Trim(), this.cyjsZyh.Text.Trim(), lblFeeUpLoad);

            cxfy();
            this.fymxcount();

            if (!string.IsNullOrEmpty(ret.Mesg))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = "上传费用情况如下：【住院号：" + this.cyjsZyh.Text.Trim() + "-" + ret.Mesg + "】";
                frmmesg.ShowDialog(this);
            }
            lblFeeUpLoad.Text = "上传费用完成！";
            lblFeeUpLoad.Update();
        }

        private void btn_yjs_Click(object sender, EventArgs e)
        {


            initnull();
            int _iid = int.Parse(ihsp_id);
            if (_iid == 0)
            {
                return;
            }
            //if (Tool.IsUpload == true)
            //{
            //    string sqlfyxx = "select id from ihsp_costdet where insursync ='N' and ihsp_id = " + ihsp_id;

            //    DataTable dtxx = BllMain.Db.Select(sqlfyxx).Tables[0];
            //    if (dtxx.Rows.Count > 0)
            //    {
            //        MessageBox.Show("后台正在自动上传费用,稍后再预结算！", "提示信息");
            //        return;
            //    }
            //}
            if (int.Parse(label_sc.Text) < 1)
            {
                MessageBox.Show("请先上传费用！");
                return;
            }
            lblFeeUpLoad.Text = "正在预结算..........";
            lblFeeUpLoad.Update();
            string zyh = this.cyjsZyh.Text;
            string yllb = this.combocyjsyllb.SelectedValue.ToString().Trim();
            string grbh = this.cyjsGrbh.Text;
            string jbmc = this.cyjsCyjb.Text;
            string jbcode = this.cyjsCyjbcode.Text;
            //出院登记
            if (cydj() != 1)
            {
                lblFeeUpLoad.Text = "更新失败！！";
                return;
            }
            //读人员基本信息和帐户信息

            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";//出院预结算
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡
            string Ylzh = "";

            Ylzh = "0";

            yb_in_ryjbxxhzh.MSGNO = "1401";
            yb_in_ryjbxxhzh.AAC001 = Ylzh;
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }

            if (yb_out_ryjbxxhzh.ZKC031.Equals("0"))
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("此人目前为出院状态，不能再做出院结算操作！", "提示信息");
                return;
            }
            //帐户余额
            this.cyjsZhye.Text = yb_out_ryjbxxhzh.AKC087.ToString();


            //预结算
            SJZYB_IN<zyyjs_IN> yb_in_zyyjs = new SJZYB_IN<zyyjs_IN>();
            yb_in_zyyjs.INPUT = new List<zyyjs_IN>();
            zyyjs_IN zyyjs_IN = new bean.zyyjs_IN();
            zyyjs_IN.ZKC759 = "1"; //普通住院结算
            if (this.but_jybfdhje.Text.ToString().Equals("使用账户"))
            {
                zyyjs_IN.BKC111 = "1";
            }
            else if (this.but_jybfdhje.Text.ToString().Equals("不使用账户"))
            {
                zyyjs_IN.BKC111 = "0";
            }
            yb_in_zyyjs.INPUT.Add(zyyjs_IN);
            string sql_sybzyjl = " SELECT AKC190,"//门诊（住院）流水号，医院用于区分每次就诊或住院的唯一标识(不为空)
                                                 + "AKA130,"//医疗类别详见代码表(不为空)21，普通住院
                                                 + "AKC192,"//入院日期 YYYYMMDDHH24MISS（如果是门诊，则为门诊日期）(不为空)
                                                 + "AKC193,"//入院诊断疾病编码(不为空)
                                                 + "AKC194,"//出院日期 YYYYMMDDHH24MISS（住院费用结算时必录）
                                                 + "AKC195,"//出院原因（住院费用结算时必录）
                                                 + "AKC196,"//出院疾病诊断编码（门诊、住院费用结算时必录）
                                                 + "AAE011,"//经办人(不为空)
                                                 + "AAE036,"//经办日期 YYYYMMDDHH24MISS(不为空)
                                                 + "AKC008,"//医生姓名(不为空)
                                                 + "AKC025,"//科室名称(不为空)
                                                 + "AKC140,"//入院诊断疾病名称(不为空)
                                                 + "AKC600,"//入院描述
                                                 + "AKC141,"//出院疾病诊断名称（门诊、住院费用结算时必录）
                                                 + "AKC701,"//出院描述
                                                 + "AKC030,"//病房号
                                                 + "AKE020,"//病床号
                                                 + "AKC032,"//住址
                                                 + "AKC033,"//职业
                                                 + "AKC034,"//患者联系电话
                                                 + "AKC031,"//病历号(不为空)
                                                 + "AMC026,"//生育类别（选择生育门诊,生育住院登记,生育住院登记信息修改,生育住院结算时必须录入）
                                                 + "AMC100,"//孕周（选择生育医疗类别时，必须录入）
                                                 + "AMC001,"//准生证号
                                                 + "AMC013,"//胎儿数（正常生产、难产、剖腹产时为必填项）
                                                 + "AMC008,"//出生证编号
                                                 + "AKC120,"//意外伤害标志
                                                 + "BKF040,"//中心科室编码(不为空)
                                                 + "BKF050,"//中心医师编码(不为空)
                                                 + "AMC020,"//手术日期,分娩日期或流产日期(生育住院结算时必须录入),必须在入院日期之后,不能晚于结算日期
                                                 + "AKC069,"//急诊标志，用于记录急诊就医
                                                 + "CKAA59"//是否双侧输卵管结扎（0 否 1 是）（正常生产、难产、剖腹产时为必填项）";
                                                 + " FROM sybzyjl WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dt_Sybzyjl = BllMain.Db.Select(sql_sybzyjl).Tables[0];
            List<KC21> kc21_list = objk<KC21>.FillModel(dt_Sybzyjl);
            string sql_dia = " SELECT "
                           + " insur_illness_name AS cyzd,"
                           + " insur_illness_illcode AS CODE,"
                           + " a.diagndate,"
                           + " a.opkind,"
                           + " a.sn"
                       + " FROM"
                           + " insur_directory_contrast"
                       + " LEFT JOIN (SELECT ihsp_id,diagnICD,diagndate,opkind,sn FROM ihsp_diagnmes WHERE diagnKind = 'OUT' AND opkind <> '' ) a ON a.diagnICD = insur_directory_contrast.bas_caseicd_case_icd10"
                       + " WHERE"
                        + " a.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                        + "GROUP BY insur_illness_illcode order by sn ;";
            DataTable dt_dia = BllMain.Db.Select(sql_dia).Tables[0];
            kc21_list[0].AKC192 = (Convert.ToDateTime(kc21_list[0].AKC192)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AKC194 = (Convert.ToDateTime(kc21_list[0].AKC194)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AAE036 = (Convert.ToDateTime(kc21_list[0].AAE036)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AMC020 = (Convert.ToDateTime(kc21_list[0].AMC020)).ToString("yyyyMMddHHmmss");
            KC21 kc21 = new KC21();
            kc21 = kc21_list[0];
            kc21.KC33XML = "";
            int sn = 1;
            for (int i = 0; i < dt_dia.Rows.Count; i++)
            {


                kc21.KC33XML += "<KC33ROW>"
                                   + "<AKC190>" + zyh + "</AKC190>"//门诊（住院）号
                                   + "<BKE150>" + sn++ + "</BKE150>"//诊断顺序
                                   + "<AKC221>" + Convert.ToDateTime(dt_dia.Rows[i]["diagndate"].ToString()).ToString("yyyyMMddHHmmss") + "</AKC221>"//确诊日期
                                   + "<AKA120>" + dt_dia.Rows[i]["CODE"].ToString() + "</AKA120>"//诊断编码
                                   + "<AKA121>" + dt_dia.Rows[i]["cyzd"].ToString() + "</AKA121>"//诊断名称
                                   + "<AAE013></AAE013>"//备注
                      + "</KC33ROW>";

            }


            yb_in_zyyjs.KC21XML = new KC21();
            yb_in_zyyjs.KC21XML = kc21;
            //yb_in_zyyjs.KC21XML.CKAA59 = this.comboBox2.SelectedValue.ToString();
            //yb_in_zyyjs.KC21XML.AMC013 = this.textBox7.Text.ToString();
            zyjs_OUT yb_out_zyyjs = new zyjs_OUT();


            string sql_ybjl = "select healthcard,insurcode, AKA130 from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where inhospital.id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb1 = dt_Sybzyjl.Rows[0]["AKA130"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["healthcard"].ToString().Trim();
            yb_in_zyyjs.AAC001 = Ylzh;
            yb_in_zyyjs.AKC190 = zyh;
            yb_in_zyyjs.AKC020 = iccode;
            yb_in_zyyjs.MSGNO = "1104";
            yb_in_zyyjs.AKA130 = yllb1;

            int ret_zyyjs = sjzybInterface.zyyjs(yb_in_zyyjs, ref yb_out_zyyjs);
            if (yb_out_zyyjs.RETURNNUM == -1)
            {
                lblFeeUpLoad.Text = "预结算失败";
                MessageBox.Show(yb_out_zyyjs.ERRORMSG, "提示信息");
                return;
            }

            this.cyjsFyzje.Text = yb_out_zyyjs.AKC264;
            this.cyjsTczfje.Text = yb_out_zyyjs.AKC260;
            this.cyjsXjygzf.Text = yb_out_zyyjs.AKC261;
            this.cyjsZhzf.Text = yb_out_zyyjs.AKC255;
            this.tbx_qfx.Text = yb_out_zyyjs.CKA050;
            this.tbx_gwyjjzf.Text = yb_out_zyyjs.AKC707;
            this.tbx_bcdbzfje.Text = yb_out_zyyjs.AKC706;
            this.tbx_qtjjzf.Text = yb_out_zyyjs.AKC708;

            this.fymxcount();
            //this.ybfy(zyh);
            MessageBox.Show("预结算成功，返回帐户支付金额，下一步请点结算按钮！");
            //-判断自费是否结算，如果未结算，不允许医保结算
            //if (billIhspAct.isHisAccount(ihsp_id))
            //{
            this.btn_js.Enabled = true;
            this.but_jybfdhje.Enabled = false;
            //}
            //else
            //{
            //    this.btn_js.Enabled = false;
            //    MessageBox.Show("该病人自费未结算，不能医保结算");
            //}
            //报销合计（不含账户支付）基本统筹 + 大病救助 + 公务员补助 + 其他基金
            this.bxhj.Text = (double.Parse(yb_out_zyyjs.AKC260) + double.Parse(yb_out_zyyjs.AKC706) + double.Parse(yb_out_zyyjs.AKC707) + double.Parse(yb_out_zyyjs.AKC708)).ToString().Trim();
            String bcxjyzf = this.cyjsXjygzf.Text;
            //实际收费 realfee_his = 预交款 - 本次现金支付金额， realfee_yi = 医疗费总额 -(预交款 + 报销合计（不含账户支付）+ 账户支付)
            Double realfee_his = 0, realfee_yi = 0;
            if (bcxjyzf != null && bcxjyzf != "")
            {
                if (this.yjkzfy.Text.Trim() == "" || this.yjkzfy.Text.Trim() == null)
                {
                    realfee_his = (double.Parse(bcxjyzf) - 0);
                    realfee_yi = double.Parse(yb_out_zyyjs.AKC264) - (0 + double.Parse(bcxjyzf) + (double.Parse(yb_out_zyyjs.AKC260) + double.Parse(yb_out_zyyjs.AKC706) + double.Parse(yb_out_zyyjs.AKC707) + double.Parse(yb_out_zyyjs.AKC708)) + double.Parse(yb_out_zyyjs.AKC261));
                }
                else
                {
                    realfee_his = (double.Parse(bcxjyzf) - double.Parse(this.yjkzfy.Text));
                    realfee_yi = double.Parse(yb_out_zyyjs.AKC264) - (double.Parse(this.yjkzfy.Text) + double.Parse(bcxjyzf) + (double.Parse(yb_out_zyyjs.AKC260) + double.Parse(yb_out_zyyjs.AKC706) + double.Parse(yb_out_zyyjs.AKC707) + double.Parse(yb_out_zyyjs.AKC708)) + double.Parse(yb_out_zyyjs.AKC261));
                }
                if (realfee_his == realfee_yi)
                {
                    lblFeeUpLoad.Text = "预结算异常";
                    cxfy();
                    return;
                }
                if (realfee_his < 0)
                {
                    label3.Text = "应退";
                    label3.Update();
                }
                else if (realfee_his > 0)
                {
                    label3.Text = "应收";
                    label3.Update();
                }
                this.tbx_thbxj.Text = realfee_his.ToString();
            }

            lblFeeUpLoad.Text = "预结算成功";
            this.textBox7.Enabled = false;
            this.textBox2.Enabled = false;
            cxfy();
            //string fhxx = "";
            //try
            //{
            //    string sql_hdybcc = "select * from hdybcc where xh=11";
            //    DataTable dt_hdybcc = BllMain.Db.Select(sql_hdybcc).Tables[0];
            //    string[] retdata_hdybcc = dt_hdybcc.Rows[0]["ywccyb"].ToString().Split('|');
            //    for (int j = 0; j < zyyjs_cc.Length; j++)
            //    {
            //        string hdybcc_hy = "";
            //        if (retdata_hdybcc.Length > j)
            //        {
            //            hdybcc_hy = retdata_hdybcc[j];
            //        }
            //        fhxx += "<" + (j + 1) + ">-" + hdybcc_hy + "：" + zyyjs_cc[j] + "\r\n";
            //    }
            //    this.Tbx_tsxx.Text = fhxx;
            //}
            //catch
            //{
            //    this.Tbx_tsxx.Text = fhxx;
            //}
        }
        /// <summary>
        /// 清空界面
        /// </summary>
        public void initnull()
        {
            this.cyjsZhye.Text = "";
            this.cyjsFyzje.Text = "";
            this.cyjsTczfje.Text = "";
            this.tbx_bcdbzfje.Text = "";
            this.tbx_gwyjjzf.Text = "";
            this.cyjsXjygzf.Text = "";
            this.bxhj.Text = "";
            this.cyjsZhzf.Text = "";
            this.tbx_thbxj.Text = "";
            this.tbx_qfx.Text = "";

        }
        private int cydj()
        {
            //修改sybzyjl
            string zyh = this.cyjsZyh.Text;
            string ryrq = this.cyjsRyrq.Text;
            string cyrq = this.cyjsCyrq.Text;
            string cyyy1 = this.comboCyyy.Text;
            if (string.IsNullOrEmpty(this.cyjsCyjb.Text.Trim()))
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("请注意：出院疾病不能为空！");
                return 0;
            }
            if (cyyy1 == null || cyyy1 == "")
            {
                MessageBox.Show("出院原因不能为空！", "提示信息");
                this.comboCyyy.Focus();
                return 0;
            }
            string cyyy = this.comboCyyy.SelectedValue.ToString().Trim();
            string sql4 = " SELECT insur_illness_name AS cyzd,insur_illness_illcode AS CODE,a.diagndate,a.opkind FROM insur_directory_contrast LEFT JOIN (SELECT ihsp_id,diagnICD,diagndate,opkind FROM ihsp_diagnmes WHERE diagnKind = 'OUT' AND opkind = 'MAIN' and diagntype=2) a ON a.diagnICD = insur_directory_contrast.bas_caseicd_case_icd10 WHERE a.ihsp_id =  " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt_cyzd = BllMain.Db.Select(sql4).Tables[0];

            string ys = this.cyjsYs.Text;
            string ks = this.CyjsKs.Text;

            if (cyrq == null || cyrq == "")
            {
                MessageBox.Show("出院日期不能为空，请输入出院日期，格式为'yyyy-MM-dd'!", "提示信息");
                this.cyjsCyrq.Focus();
                return 0;
            }
            if (dt_cyzd.Rows.Count == 0)
            {
                string sql_aa = "SELECT ihsp_id,diagnICD,diagnname,opkind FROM ihsp_diagnmes WHERE diagnKind = 'OUT' AND opkind = 'MAIN' and diagntype=2 and ihsp_id=" + ihsp_id;
                DataTable dt_aa = BllMain.Db.Select(sql_aa).Tables[0];
                if (dt_aa.Rows.Count == 0)
                {
                    MessageBox.Show("主要诊断没有填写，填完诊断后再结算");
                    return 0;
                }
                MessageBox.Show("主要诊断:" + dt_aa.Rows[0]["diagnICD"].ToString() + " " + dt_aa.Rows[0]["diagnname"].ToString() + "没有与医保诊断对应，请对应后再结算");
                return 0;
            }

            string sql = "";
            //lyj待补充 2019-09-05
            sql += "UPDATE sybzyjl SET AKC192 = " + DataTool.addFieldBraces(ryrq) //出院时间
                 + ",AKC194 = " + DataTool.addFieldBraces(cyrq) //出院时间
                 + ",AKC195 = " + DataTool.addFieldBraces(cyyy) //出院原因
                 + ",AKC196 = " + DataTool.addFieldBraces(dt_cyzd.Rows[0]["CODE"].ToString()) //出院疾病诊断编码（
                 + ",AKC141 = " + DataTool.addFieldBraces(dt_cyzd.Rows[0]["cyzd"].ToString()) //出院疾病诊断名称（
                 + ",AAE011 = " + DataTool.addFieldBraces(ProgramGlobal.Nickname)
                 + ",AAE036 = " + DataTool.addFieldBraces(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                 + ",AKC008 = " + DataTool.addFieldBraces(ys) //医生姓名
                 + ",AKC025 =" + DataTool.addFieldBraces(ks);  //科室名称
            if (groupBox3.Visible)
            {
                sql += ",AMC001 =" + DataTool.addFieldBraces(this.textBox2.Text)  //生育号
                     + ",AMC013 =" + DataTool.addFieldBraces(this.textBox7.Text)  //胎儿数
                     + ",CKAA59 =" + DataTool.addFieldBraces(this.comboBox2.SelectedValue.ToString());  //是否双侧输卵管结扎
            }

            sql += " WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            if (BllMain.Db.Update(sql) == -1)
            {
                return -1;
            }
            return 1;
        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            //住院结算
            //发票号
            lblFeeUpLoad.Text = "";
            if (string.IsNullOrEmpty(this.cyjsCyrq.Text.Trim()))
            {
                MessageBox.Show("没有出院时间！");
                return;
            }
            string yllb = this.combocyjsyllb.SelectedValue.ToString().Trim();
            double ybFee = Convert.ToDouble(cyjsFyzje.Text.Trim());
            double hisFee = Convert.ToDouble(hisFeeLable.Text.Trim());
            double chaZhi = hisFee - ybFee;
            if ((chaZhi > 0.01 || chaZhi < -0.01) && !(yllb == "28" || yllb == "29"))
            {

                MessageBox.Show("HIS系统费用与医保系统费用不符，不能结算！！！");
                return;
            }
            string zyh = this.cyjsZyh.Text;
            string grbh = this.cyjsGrbh.Text;
            //string sql_gxsfck = "select sfck,status from inhospital where id='" + ihsp_id + "'";
            //string sql_gxsfck = "select sfck,status,outcondition from inhospital where id='" + ihsp_id + "'";
            //DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            string djh = "";
            djh = this.fphtext.Text.Trim();
            //if (ds_sfck.Tables[0].Rows[0]["status"].ToString() != "SIGN")
            //{
            //    MessageBox.Show("此患者未挂账，请挂账之后再进行结算!");
            //    return;
            //}
            //if (string.IsNullOrEmpty(djh))
            //{
            //    MessageBox.Show("发票号为空,请领取发票!");
            //    return;
            //}
            //if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            //{
            //    djh = this.fphtext.Text.Trim();
            //    //if (ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "OO" || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == null || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "")
            //    if (!ds_sfck.Tables[0].Rows[0]["status"].ToString().Equals("SETT"))
            //    {
            //        lblFeeUpLoad.Text = "";
            //        MessageBox.Show("His系统没有结算，不允许城乡结算！");
            //        return;
            //    }
            //}
            //else
            //{
            //    String[] getfph = new String[1];
            //    if (ds_sfck.Tables[0].Rows[0]["status"].ToString() != "SIGN")
            //    {
            //        lblFeeUpLoad.Text = "";
            //        MessageBox.Show("此患者未挂账，请挂账之后再进行结算!");
            //        return;
            //    }
            //    if (string.IsNullOrEmpty(djh))
            //    {
            //        MessageBox.Show("发票号为空,请领取发票!");
            //        return;
            //    }
            //}
            //读人员基本信息和帐户信息

            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "23";//出院结算
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡


            yb_in_ryjbxxhzh.MSGNO = "1401";
            yb_in_ryjbxxhzh.AAC001 = "0";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            //结算
            SJZYB_IN<zyjs_IN> yb_in_zyjs = new SJZYB_IN<zyjs_IN>();
            yb_in_zyjs.INPUT = new List<zyjs_IN>();
            zyjs_IN zyjs_in = new zyjs_IN();
            zyjs_in.AAE072 = djh;
            zyjs_in.AKC190 = zyh;
            zyjs_in.AKC264 = hisFee;
            zyjs_in.ZKC759 = "1";
            if (this.but_jybfdhje.Text.ToString().Equals("使用账户"))
            {
                zyjs_in.BKC111 = "1";
            }
            else if (this.but_jybfdhje.Text.ToString().Equals("不使用账户"))
            {
                zyjs_in.BKC111 = "0";
            }
            yb_in_zyjs.INPUT.Add(zyjs_in);
            string sql_sybzyjl = " SELECT AKC190,"//门诊（住院）流水号，医院用于区分每次就诊或住院的唯一标识(不为空)
                                                 + "AKA130,"//医疗类别详见代码表(不为空)21，普通住院
                                                 + "AKC192,"//入院日期 YYYYMMDDHH24MISS（如果是门诊，则为门诊日期）(不为空)
                                                 + "AKC193,"//入院诊断疾病编码(不为空)
                                                 + "AKC194,"//出院日期 YYYYMMDDHH24MISS（住院费用结算时必录）
                                                 + "AKC195,"//出院原因（住院费用结算时必录）
                                                 + "AKC196,"//出院疾病诊断编码（门诊、住院费用结算时必录）
                                                 + "AAE011,"//经办人(不为空)
                                                 + "AAE036,"//经办日期 YYYYMMDDHH24MISS(不为空)
                                                 + "AKC008,"//医生姓名(不为空)
                                                 + "AKC025,"//科室名称(不为空)
                                                 + "AKC140,"//入院诊断疾病名称(不为空)
                                                 + "AKC600,"//入院描述
                                                 + "AKC141,"//出院疾病诊断名称（门诊、住院费用结算时必录）
                                                 + "AKC701,"//出院描述
                                                 + "AKC030,"//病房号
                                                 + "AKE020,"//病床号
                                                 + "AKC032,"//住址
                                                 + "AKC033,"//职业
                                                 + "AKC034,"//患者联系电话
                                                 + "AKC031,"//病历号(不为空)
                                                 + "AMC026,"//生育类别（选择生育门诊,生育住院登记,生育住院登记信息修改,生育住院结算时必须录入）
                                                 + "AMC100,"//孕周（选择生育医疗类别时，必须录入）
                                                 + "AMC001,"//准生证号
                                                 + "AMC013,"//胎儿数（正常生产、难产、剖腹产时为必填项）
                                                 + "AMC008,"//出生证编号
                                                 + "AKC120,"//意外伤害标志
                                                 + "BKF040,"//中心科室编码(不为空)
                                                 + "BKF050,"//中心医师编码(不为空)
                                                 + "AMC020,"//手术日期,分娩日期或流产日期(生育住院结算时必须录入),必须在入院日期之后,不能晚于结算日期
                                                 + "AKC069,"//急诊标志，用于记录急诊就医
                                                 + "CKAA59 "//是否双侧输卵管结扎（0 否 1 是）（正常生产、难产、剖腹产时为必填项）";
                                                 + "FROM sybzyjl WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dt_Sybzyjl = BllMain.Db.Select(sql_sybzyjl).Tables[0];
            List<KC21> kc21_list = objk<KC21>.FillModel(dt_Sybzyjl);
            kc21_list[0].AKC192 = (Convert.ToDateTime(kc21_list[0].AKC192)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AKC194 = (Convert.ToDateTime(kc21_list[0].AKC194)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AAE036 = (Convert.ToDateTime(kc21_list[0].AAE036)).ToString("yyyyMMddHHmmss");
            kc21_list[0].AMC020 = (Convert.ToDateTime(kc21_list[0].AMC020)).ToString("yyyyMMddHHmmss");
            KC21 kc21 = new KC21();
            kc21 = kc21_list[0];
            string sql_dia = " SELECT "
                           + " insur_illness_name AS cyzd,"
                           + " insur_illness_illcode AS CODE,"
                           + " a.diagndate,"
                           + " a.opkind,"
                           + " a.sn"
                       + " FROM"
                           + " insur_directory_contrast"
                       + " LEFT JOIN (SELECT ihsp_id,diagnICD,diagndate,opkind,sn FROM ihsp_diagnmes WHERE diagnKind = 'OUT'  AND opkind <> '' ) a ON a.diagnICD = insur_directory_contrast.bas_caseicd_case_icd10"
                       + " WHERE"
                        + " a.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                        + "GROUP BY insur_illness_illcode ;";
            DataTable dt_dia = BllMain.Db.Select(sql_dia).Tables[0];
            kc21.KC33XML = "";
            int j = 1;
            for (int i = 0; i < dt_dia.Rows.Count; i++)
            {

                kc21.KC33XML += "<KC33ROW>"
                                   + "<AKC190>" + zyh + "</AKC190>"//门诊（住院）号
                                   + "<BKE150>" + j++ + "</BKE150>"//诊断顺序
                                   + "<AKC221>" + Convert.ToDateTime(dt_dia.Rows[i]["diagndate"].ToString()).ToString("yyyyMMddHHmmss") + "</AKC221>"//确诊日期
                                   + "<AKA120>" + dt_dia.Rows[i]["CODE"].ToString() + "</AKA120>"//诊断编码
                                   + "<AKA121>" + dt_dia.Rows[i]["cyzd"].ToString() + "</AKA121>"//诊断名称
                                   + "<AAE013></AAE013>"//备注
                      + "</KC33ROW>";


            }




            yb_in_zyjs.KC21XML = new KC21();
            yb_in_zyjs.KC21XML = kc21;
            zyjs_OUT yb_out_zyjs = new zyjs_OUT();

            string Ylzh = "";
            string sql_ybjl = "select healthcard,insurcode, AKA130 from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where inhospital.id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb1 = dt_Sybzyjl.Rows[0]["AKA130"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["healthcard"].ToString().Trim();
            string grbh1 = dtybjl.Rows[0]["insurcode"].ToString().Trim();


            Ylzh = "0";

            yb_in_zyjs.AKA130 = yllb1;
            yb_in_zyjs.AAC001 = Ylzh;
            yb_in_zyjs.AKC190 = zyh;
            yb_in_zyjs.AKC020 = iccode;
            yb_in_zyjs.MSGNO = "1105";
            int ret_zyyjs = sjzybInterface.zyjs(yb_in_zyjs, ref yb_out_zyjs);
            if (yb_out_zyjs.RETURNNUM == -1)
            {
                MessageBox.Show(yb_out_zyjs.ERRORMSG, "提示信息");
                return;
            }

            string _iid = ihsp_id;
            string insetyb = "";
            //是否先结后报
            string isxjhb = Ini.IniReadValue2("pz", "ISXJHB");
            js_sql jsxx = new js_sql();
            jsxx.js = yb_out_zyjs;
            jsxx.AAE072 = yb_in_zyjs.INPUT[0].AAE072;
            jsxx.AKC190 = yb_in_zyjs.AKC190;
            jsxx.BKC111 = zyjs_in.BKC111;
            jsxx.MSGID = yb_in_zyjs.MSGID;
            jsxx.REFMSGID = yb_out_zyjs.REFMSGID;
            jsxx.registkind = "IHSP";
            jsxx.AKA130 = yb_in_zyjs.AKA130;
            jsxx.id = BillSysBase.nextId("sjz_yb_jsxx");

            string ihspaccount_id = "";
            if (isxjhb == "0")
            {
                if (actMethod(ref ihspaccount_id) < 0)
                {
                    MessageBox.Show("医保结算成功，his结算失败");
                    return;
                }
            }
            else
            {
                string sql_upaccount = "UPDATE ihsp_account SET insurefee = '" + (Convert.ToDouble(cyjsTczfje.Text.Trim()) + Convert.ToDouble(tbx_bcdbzfje.Text.Trim()) + Convert.ToDouble(tbx_gwyjjzf.Text.Trim())).ToString() + "', insuraccountfee = '" + cyjsZhzf.Text.Trim().ToString() + "'  WHERE ihsp_id = " + _iid.ToString();
                BllMain.Db.Update(sql_upaccount);
            }
            StringBuilder message = new StringBuilder();
            jsxx.ihspaccount_id = ihspaccount_id;
            insetyb = objk<js_sql>.getsql(jsxx);
            if (BllMain.Db.Update(insetyb) == -1)
            {
                SysWriteLogs.writeLogs1("市医保结算更新his错误信息", DateTime.Now, "sql=" + insetyb);
                MessageBox.Show("医保结算成功，更新his失败！" + message);
                return;
            }
            //修改his系统nhflag标志
            string settinsurdate = BillSysBase.currDate();//获取当前时间
            string sql2 = "update inhospital set chargedby = '" + ProgramGlobal.User_id + "',chargedate = '" + settinsurdate + "'  where id=" + ihsp_id.ToString().Trim();
            BllMain.Db.Update(sql2);
            MessageBox.Show("出院结算成功！");
            initButton();
            string mes = "需要打印发票吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            this.dyfp(grbh, zyh, ihsp_id);
        }
        public void dyfp(string strGrbh, string strZyh, string ihsp_id)
        {
            if (string.IsNullOrEmpty(strGrbh) || string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(ihsp_id))
            {
                MessageBox.Show("发票参数获取失败!");
                return;
            }

            string sql_up = " UPDATE ihsp_account SET print = print+1 WHERE ihsp_id = '" + ihsp_id + "';";
            BllMain.Db.Update(sql_up);
            string sql_cxybfph = "select * from sjz_yb_jsxx where iscurr = 'Y' AND akc190=" + strZyh + ";";
            DataTable ds_ybfph = BllMain.Db.Select(sql_cxybfph).Tables[0];
            if (ds_ybfph.Rows.Count == 0)
            {
                MessageBox.Show("没有在‘zlsyb_zyinfo’表里找到此人结算信息！", "提示信息");
                return;
            }
            List<fp> list = new List<fp>();
            fp fpxx = new fp();
            list = objk<fp>.FillModel(ds_ybfph);
            fpxx = list[0];

            string[] zyjsddy_cc = "||||".Split('|');
            #region
            #region
            double cwf = 0;//床位费 
            double zcf = 0;//诊察费
            double jcf = 0;//检查费
            double hyf = 0;//化验费
            double zlf = 0;//治疗费
            double ssf = 0;//手术费
            double hlf = 0;//护理费
            double wsclf = 0;//卫生材料费
            double ypf = 0; //药品费
            double ysfwf = 0;//药事服务费
            double ybzlf = 0;//一般诊疗费
            double sxf = 0;//输血费
            double qtzyfy = 0;//其他住院收费

            DataTable datafpdy = zydyfp(ihsp_id);
            double hj = 0;
            for (int i = 0; i < datafpdy.Rows.Count; i++)
            {
                hj += DataTool.Getdouble(datafpdy.Rows[i]["Amt"].ToString().Trim());
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
                {
                    cwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//床位费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊察费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
                {
                    zcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊察费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复"))
                {
                    zlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("监护费"))
                {
                    hlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//护理费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费"))
                {
                    ssf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//手术费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
                {
                    hyf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("卫生材料费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("材料费"))
                {
                    wsclf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//卫生材料费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药品费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
                {
                    ypf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药品费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药事服务费"))
                {
                    ysfwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药事服务费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("一般诊疗费"))
                {
                    ybzlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//一般诊疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费"))
                {
                    if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
                    {
                        jcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
                        continue;
                    }
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
                {
                    sxf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//输血费
                    continue;
                }
                else
                {
                    qtzyfy += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他住院收费
                    continue;
                }
            }
            DataTable Dygrxx = GetDygrxx(ihsp_id);
            hj = Math.Round(hj, 2);
            if (hj != DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()))
            {
                MessageBox.Show("项目类型之和【" + hj.ToString() + "】与病人费用总和【" + Dygrxx.Rows[0]["amt"].ToString() + "】不等！");
                //return;
            }
            #endregion

            string sumFeeSql = "select sum(fee) as sumAmt from ihsp_costdet where  ihsp_costdet.charged in('CHAR') and ihsp_id= " + ihsp_id;
            DataTable temSum = BllMain.Db.Select(sumFeeSql).Tables[0];
            string accfeeSql = "SELECT feeamt from ihsp_account where ihsp_id = " + ihsp_id;
            DataTable accSum = BllMain.Db.Select(accfeeSql).Tables[0];
            Double costFee = Convert.ToDouble(temSum.Rows[0][0].ToString());
            Double accFee = Convert.ToDouble(accSum.Rows[0][0].ToString());
            Double difference = costFee - accFee;
            if (Math.Abs(difference) > 0.3)
            {
                MessageBox.Show("费用明细表总和与结算表费用不一致！请重新结算或者联系管理员。");
                return;
            }


            string sqlks = "SELECT inhospital.outdiagn AS cyzd,inhospital.indate,inhospital.outdate, bas_depart. NAME AS ks, bas_doctor. NAME AS ys FROM inhospital LEFT JOIN bas_doctor ON inhospital.doctor_id = bas_doctor.id LEFT JOIN bas_depart ON inhospital.depart_id = bas_depart.id WHERE inhospital.id =" + ihsp_id;
            DataTable dt_ks = BllMain.Db.Select(sqlks).Tables[0];
            string sql1 = "select inhospital.member_id,inhospital.outdate as zyjlcysj,inhospital.bas_patienttype_id as zyjlylfkfs,inhospital.name,sexList.name as sex,healthcard ,healthcard from inhospital left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0 where inhospital.id=" + ihsp_id;
            DataTable dt_cysj = BllMain.Db.Select(sql1).Tables[0];
            string in_zfc1 = "|";
            in_zfc1 += fpxx.AKB021 + "|";//定点医院名称
            in_zfc1 += fpxx.AKC778 + "|";
            in_zfc1 += dt_ks.Rows[0]["ks"].ToString() + "|";//科室
            in_zfc1 += fpxx.AAE072 + "|";//单据号
            in_zfc1 += fpxx.AKC190 + "|";//医院住院号
            //入院日期
            in_zfc1 += DateTime.Parse(dt_ks.Rows[0]["indate"].ToString()).ToString("yyyy") + "|" + DateTime.Parse(dt_ks.Rows[0]["indate"].ToString()).ToString("MM") + "|" + DateTime.Parse(dt_ks.Rows[0]["indate"].ToString()).ToString("dd") + "|";
            //(dt.Rows[0]["AKC192"].ToString()).Substring(0, 4) + "|" + ().Substring(4, 2) + "|" + (dt.Rows[0]["AKC192"].ToString()).Substring(6, 2)) + "|" + "|||";
            //出院日期
            in_zfc1 += DateTime.Parse(dt_ks.Rows[0]["outdate"].ToString()).ToString("yyyy") + "|" + DateTime.Parse(dt_ks.Rows[0]["outdate"].ToString()).ToString("MM") + "|" + DateTime.Parse(dt_ks.Rows[0]["outdate"].ToString()).ToString("dd") + "|";
            // in_zfc1 += zyjsddy_cc[8].(0, 4) + "|" + zyjsddy_cc[8].Substring(4, 2) + "|" + zyjsddy_cc[8].Substring(6, 2) + "|";//入院日期
            //in_zfc1 += zyjsddy_cc[9].Substring(0, 4) + "|" + zyjsddy_cc[9].Substring(4, 2) + "|" + zyjsddy_cc[9].Substring(6, 2) + "|";//出院日期
            //住院天数//住院次数
            TimeSpan ts = DateTime.Parse(DateTime.Parse(dt_ks.Rows[0]["outdate"].ToString().Trim()).ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Parse(dt_ks.Rows[0]["indate"].ToString().Trim()).ToString("yyyy-MM-dd"));
            in_zfc1 += ts.Days + "|";

            //患者姓名
            in_zfc1 += dt_cysj.Rows[0]["NAME"] + "|";
            in_zfc1 += Dygrxx.Rows[0]["xb"].ToString().Trim() + "|";//患者性别
            in_zfc1 += fpxx.AKC779 + "|";//医保类型


            in_zfc1 += dt_cysj.Rows[0]["healthcard"] + "|";

            #region
            string in_zfc_fy = "";
            if (cwf != 0)
                in_zfc_fy += "床位费|" + cwf.ToString("0.00") + "|医保|";
            if (hlf != 0)
                in_zfc_fy += "护理费|" + hlf.ToString("0.00") + "|医保|";
            if (zcf != 0)
                in_zfc_fy += "诊查费|" + zcf.ToString("0.00") + "|医保|";
            if (wsclf != 0)
                in_zfc_fy += "卫生材料费|" + wsclf.ToString("0.00") + "|医保|";
            if (jcf != 0)
                in_zfc_fy += "检查费|" + jcf.ToString("0.00") + "|医保|";
            if (ypf != 0)
                in_zfc_fy += "药品费|" + ypf.ToString("0.00") + "|医保|";
            if (hyf != 0)
                in_zfc_fy += "化验费|" + hyf.ToString("0.00") + "|医保|";
            if (ysfwf != 0)
                in_zfc_fy += "药事服务费|" + ysfwf.ToString("0.00") + "|医保";
            if (zlf != 0)
                in_zfc_fy += "治疗费|" + zlf.ToString("0.00") + "|医保|";
            if (ybzlf != 0)
                in_zfc_fy += "一般诊疗费|" + ybzlf.ToString("0.00") + "|医保|";
            if (ssf != 0)
                in_zfc_fy += "手术费|" + ssf.ToString("0.00") + "|医保|";
            if (qtzyfy != 0)
                in_zfc_fy += "其他住院费用|" + qtzyfy.ToString("0.00") + "|医保|";
            if (sxf != 0)
                in_zfc_fy += "输血费|" + sxf.ToString("0.00") + "|医保|";
            #endregion
            //in_zfc1 += "床位费|" + cwf.ToString("0.00") + "|医保|护理费|" + hlf.ToString("0.00") + "|医保|诊查费|" + zcf.ToString("0.00") + "|医保|";
            //in_zfc1 += "卫生材料费|" + wsclf.ToString("0.00") + "|医保|检查费|" + jcf.ToString("0.00") + "|医保|药品费|" + ypf.ToString("0.00") + "|医保|";
            //in_zfc1 += "化验费|" + hyf.ToString("0.00") + "|医保|药事服务费|" + ysfwf.ToString("0.00") + "|医保|治疗费|" + zlf.ToString("0.00") + "|医保|";
            //in_zfc1 += "一般诊疗费|" + ybzlf.ToString("0.00") + "|医保|手术费|" + ssf.ToString("0.00") + "|医保|其他住院费用|" + qtzyfy.ToString("0.00") + "|医保|输血费|" + sxf.ToString("0.00") + "|医保|";

            money n = new money(DataTool.Getdouble(temSum.Rows[0]["sumAmt"].ToString().Trim()));//费用合计大写
            in_zfc1 += n.Convert() + "|";//合计大写
            in_zfc1 += Double.Parse(temSum.Rows[0]["sumAmt"].ToString().Trim()).ToString("0.00") + "元|";
            //money n = new money(DataTool.Getdouble(zyjsddy_cc[28]));//费用合计-大写
            //in_zfc1 += n.Convert() + "|";//合计大写
            //in_zfc1 += zyjsddy_cc[28] + "|";//合计
            string sql_amt = "select COALESCE( sum(payfee),0) as sum from ihsp_payinadv where ihsp_id='" + ihsp_id + "'";
            DataTable dt_amt = BllMain.Db.Select(sql_amt).Tables[0];
            double amt_yj = 0;
            double amt_bj = 0;
            Decimal amt_tf = 0;
            if (dt_amt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt_amt.Rows[0]["sum"].ToString().Trim()))
                {
                    amt_yj = DataTool.Getdouble(dt_amt.Rows[0]["sum"].ToString());
                    in_zfc1 += amt_yj.ToString("0.00") + "|";//预缴金额
                }
                else
                {
                    in_zfc1 += "0|";//预缴金额
                }
            }
            else
            {
                in_zfc1 += "0|";//预缴金额
            }

            //amt_tf = DataTool.Getdouble(temSum.Rows[0]["sumAmt"].ToString().Trim()) - amt_yj - DataTool.Getdouble(fpxx.AKC785);
            amt_tf = Decimal.Parse(temSum.Rows[0]["sumAmt"].ToString().Trim()) - Decimal.Parse(amt_yj.ToString()) - Decimal.Parse(fpxx.AKC785);

            if (amt_tf > 0)
            {
                in_zfc1 += amt_tf.ToString("0.00") + "|";//补缴金额
                in_zfc1 += "0.00|";//退费金额
            }
            else
            {
                in_zfc1 += "0.00|";//补缴金额
                in_zfc1 += (0 - amt_tf).ToString("0.00") + "|";//退费金额
            }
            in_zfc1 += fpxx.AKC785 + "|";//医院垫支----（医院总费用-现金支付金额）
            in_zfc1 += fpxx.AKC780 + "|";//医保统筹支付
            in_zfc1 += fpxx.AKC255 + "|";//个人账户支付
            in_zfc1 += fpxx.AKC754 + "|";//个人自付
            in_zfc1 += fpxx.AKC253 + "|";//个人自费
            in_zfc1 += fpxx.AKC087 + "|";//个人账户余额
            in_zfc1 += fpxx.AKC782 + "|";//统筹累计支付
            in_zfc1 += "补助统筹累计:" + fpxx.AKC793 + "|";
            in_zfc1 += "大病统筹累计:" + fpxx.AKC121 + "|";
            in_zfc1 += "基本统筹支付:" + fpxx.AKC766 + "|";
            in_zfc1 += "补助统筹支付:" + fpxx.AKC707 + "|";
            in_zfc1 += "大病统筹支付:" + fpxx.AKC706 + "|";
            in_zfc1 += "免收金额:" + fpxx.AKC783 + "|";
            //in_zfc1 += "|";
            if (fpxx.BAC081 == "1")
            {
                in_zfc1 += "基本提高支付:" + fpxx.CKAA20 + "|";
                in_zfc1 += "大病提高支付:" + fpxx.CKAA27 + "|";
                in_zfc1 += "医疗救助支付:" + fpxx.BKE151 + "|";
                in_zfc1 += "医疗救助补充支付:" + fpxx.CKAA40 + "|";
            }
            else
            {
                in_zfc1 += "||||";
            }
            in_zfc1 += "|";

            string sql = "SELECT bas_doctor.`name` FROM ihsp_account LEFT JOIN bas_doctor ON bas_doctor.id = ihsp_account.chargedby_id WHERE STATUS = 'SETT' AND ihsp_id =  '" + ihsp_id + "'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }
            in_zfc1 += dt.Rows[0]["name"] + "|";//经办人cyjsYs
            in_zfc1 += DateTime.Now.ToString("yyyy") + "|" + DateTime.Now.ToString("MM") + "|" + DateTime.Now.ToString("dd") + "|"; //fpxx.AAE040.Substring(0, 4) + "|" + fpxx.AAE040.Substring(4, 2) + "|" + fpxx.AAE040.Substring(6, 2) + "|"; ;//结算日期
            in_zfc1 += fpxx.AKC788 + "|";
            in_zfc1 += "石家庄市医保(WH02)";
            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.in_zfc_fy = in_zfc_fy;
            cxjsddy.dy("zyyb");
            #endregion
        }
        public DataTable zydyfp(String mtzyjl_iid)
        {
            //String sql = "select insur_itemfrom.name as xmlb,sum(fee) as amt from insur_itemfrom,ihsp_costdet where ihsp_costdet.ihsp_id=" + mtzyjl_iid + " and ihsp_costdet.itemtype_id=insur_itemfrom.itemtype_id  GROUP BY xmlb ";
            String sql = " select cost_itemtype1.`name` AS xmlb,sum(fee ) as amt"
                       + " from ihsp_costdet left join cost_itemtype1 on cost_itemtype1.id = ihsp_costdet.itemtype1_id "
                       + " where  ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(mtzyjl_iid) + " GROUP BY xmlb";

            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable GetDygrxx(String mtzyjl_iid)
        {
            String sql = "select (case sex when 'M' then '男' when 'W' then '女' when 'U' then '' end) as xb,feeamt as amt from inhospital where id=" + mtzyjl_iid;
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 更改单据号
        /// </summary>
        /// <param name="djh"></param>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private int up_kc22_djh(string djh, string zyh)
        {

            string sql = "update KC22 set AAE072='" + djh + "' where AKC190='" + zyh + "'";
            int row = jkdb.Update(sql);
            return 1;
        }
        /// <summary>
        /// 结算时更改数据
        /// </summary>
        public int actMethod(ref string ihspaccount_id)
        {
            string hisOrderNo = "";
            List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();
            ihspaccount.Id = BillSysBase.nextId("ihsp_account");
            ihspaccount_id = ihspaccount.Id;
            ihspaccount.Ihsp_id = ihsp_id;
            ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
            ihspaccount.Member_id = member_id;
            ihspaccount.Bas_paytype_id = this.cbx_fklx.SelectedValue.ToString();
            ihspaccount.HisOrderNo = hisOrderNo;
            ihspaccount.Cheque = "";
            ihspaccount.Bas_patienttype_id = ylkfkfs;
            ihspaccount.Num = "1";
            ihspaccount.Invoice = invoicecode;//发票
            ihspaccount.Nextinvoicesql = nextinvoicesql;//发票sql

            ihspaccount.Feeamt = this.cyjsFyzje.Text.ToString().Trim();
            ihspaccount.Prepamt = yjkzfy.Text.ToString();
            ihspaccount.Balanceamt = tbx_thbxj.Text.ToString().Trim();
            ihspaccount.Recivefee = this.tbx_thbxj.Text.Trim().ToString();
            ihspaccount.Retfee = this.tbx_thbxj.Text.Trim().ToString();
            ihspaccount.Depart_id = ProgramGlobal.Depart_id;
            ihspaccount.Chargedby_id = ProgramGlobal.User_id;
            ihspaccount.Chargedate = BillSysBase.currDate();
            ihspaccount.Cancleby = "";
            ihspaccount.Ihsp_account_id = "";
            ihspaccount.Status = IhspAccountStatus.SETT.ToString();
            ihspaccount.Insurefee = this.bxhj.Text.ToString();//(Convert.ToDouble(cyjsTczfje.Text.Trim()) + Convert.ToDouble(tbx_bcdbzfje.Text.Trim()) + Convert.ToDouble(tbx_gwyjjzf.Text.Trim())).ToString();
            ihspaccount.Selffee = cyjsZhzf.Text.Trim().ToString();

            IhspInvoicedet ihspInvoicedet = new IhspInvoicedet();
            ihspInvoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet.PaytypeId = cbx_fklx.SelectedValue.ToString();
            ihspInvoicedet.PaysumbyId = billIhspAct.getPaysumby(cbx_fklx.SelectedValue.ToString());
            ihspInvoicedet.Payfee = ihspaccount.Balanceamt;
            invoicedets.Clear();
            invoicedets.Add(ihspInvoicedet);

            IhspInvoicedet ihspInvoicedet1 = new IhspInvoicedet();
            ihspInvoicedet1.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet1.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet1.PaytypeId = billIhspAct.getPaytypeId(BasPaytypeKeyname.SELFFEE.ToString());//账户支付
            ihspInvoicedet1.PaysumbyId = "301";
            ihspInvoicedet1.Payfee = ihspaccount.Selffee;
            invoicedets.Add(ihspInvoicedet1);

            IhspInvoicedet ihspInvoicedet2 = new IhspInvoicedet();
            ihspInvoicedet2.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet2.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet2.PaytypeId = billIhspAct.getPaytypeId(BasPaytypeKeyname.INSUREFEE.ToString());//统筹支付
            ihspInvoicedet2.PaysumbyId = "301";
            ihspInvoicedet2.Payfee = ihspaccount.Insurefee;
            invoicedets.Add(ihspInvoicedet2);

            string account_sql = "";
            account_sql = billIhspAct.doAccount(ihspaccount, invoicedets, "selfcost");
            if (-1 == billIhspMan.doExeSql(account_sql))//结算
            {

                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 撤销医保费用，先将上传信息下载，根据下载出的数据进行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_YbChScfy_Click(object sender, EventArgs e)
        {

            lblFeeUpLoad.Text = "";
            //删除费用
            string zyhTmp = this.cyjsZyh.Text.Trim();
            if (zyhTmp == null || zyhTmp == "")
            {
                MessageBox.Show("没有选中患者，不允许删除费用", "提示信息");
                return;
            }

            if (this.combocyjsyllb.SelectedValue.ToString() == "28" || this.combocyjsyllb.SelectedValue.ToString() == "29")
            {
                string mes1 = "是年终结算或年终结算后出院，确定删除费用？";
                if (MessageBox.Show(mes1, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            string mes = "确定删除[住院号:" + zyhTmp + ",姓名:" + this.cyjsXm.Text + "]的费用吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            string grbh = this.cyjsGrbh.Text.ToString().Trim();
            string zyh = this.cyjsZyh.Text.ToString().Trim();
            SJZYB_IN<zyfysc_IN> yb_in_scfy = new SJZYB_IN<zyfysc_IN>();
            yb_in_scfy.INPUT = new List<zyfysc_IN>();
            zyfysc_IN zyfysc = new zyfysc_IN();
            SJZYB_OUT yb_out_scfy = new SJZYB_OUT();

            string Ylzh = "";
            string sql_gxsfck = "select healthcard,insurcode, AKA130 from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where inhospital.id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            string yllb = ds_sfck.Tables[0].Rows[0]["AKA130"].ToString().Trim();
            grbh = ds_sfck.Tables[0].Rows[0]["insurcode"].ToString().Trim();
            string iccode = ds_sfck.Tables[0].Rows[0]["healthcard"].ToString().Trim();

            Ylzh = grbh;
            yb_in_scfy.AKA130 = yllb;
            yb_in_scfy.AAC001 = Ylzh;
            yb_in_scfy.AKC190 = zyh;
            yb_in_scfy.AKC020 = iccode;
            yb_in_scfy.MSGNO = "1106";


            #region 下载上传情况
            SJZYB_IN<DownloadCostdet_In> yb_in_ryjbxxhzh = new SJZYB_IN<DownloadCostdet_In>();
            yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
            DownloadCostdet_In dom = new DownloadCostdet_In();
            DownloadCostdet_Out yb_out_ryjbxxhzh = new DownloadCostdet_Out();
            dom.AKC190 = this.cyjsZyh.Text.ToString();
            dom.CURRENTPAGE = "1";
            yb_in_ryjbxxhzh.INPUT.Add(dom);
            Ylzh = "0";
            yb_in_ryjbxxhzh.AKC020 = this.cyjsICkh.Text.ToString(); ;
            yb_in_ryjbxxhzh.MSGNO = "1636";
            yb_in_ryjbxxhzh.AKA130 = this.combocyjsyllb.SelectedValue.ToString(); ;
            int ret1 = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret1 == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            string ReturnMsg = "";
            if (int.Parse(yb_out_ryjbxxhzh.TOTALPAGE) > 2)
            {
                for (int i = 2; i <= int.Parse(yb_out_ryjbxxhzh.TOTALPAGE); i++)
                {
                    yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
                    dom = new DownloadCostdet_In();
                    dom.AKC190 = this.cyjsZyh.Text.ToString();
                    dom.CURRENTPAGE = i.ToString();
                    yb_in_ryjbxxhzh.INPUT.Add(dom);
                    ret1 = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
                    int returnnum = Convert.ToInt32(yb_out_ryjbxxhzh.RETURNNUM);
                    if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                    {
                        ReturnMsg = yb_out_ryjbxxhzh.ERRORMSG;
                        MessageBox.Show(ReturnMsg, "提示信息");
                        return;
                    }
                }
            }
            DataTable dt = new DataTable();
            if (yb_out_ryjbxxhzh.OUTROW.Count > 0)
            {
                dt = yb_out_ryjbxxhzh.OUTROW.ToDataTable<DownloadCostdet_Out_OUTROW>();

            }
            #endregion

            string Mesg = "";
            int i1 = 1;
            foreach (DataRow dr in dt.Rows)
            {
                lblFeeUpLoad.Text = "正在撤销医保费用，" + (i1++) + "/" + dt.Rows.Count;
                lblFeeUpLoad.Update();
                zyfysc.AAC001 = grbh;
                zyfysc.AKC190 = zyh;
                //zyfysc.AKC378 = dr["AKC378"].ToString().Trim();
                //zyfysc.AKC281 = dr["MSGID"].ToString().Trim();
                zyfysc.AKC378 = dr["AKC378"].ToString().Trim();
                zyfysc.AKC281 = dr["AKC275"].ToString().Trim();
                yb_in_scfy.INPUT.Add(zyfysc);
                int ret = sjzybInterface.zyfy_delete(yb_in_scfy, yb_out_scfy);
                if (yb_out_scfy.RETURNNUM != 1)
                {
                    Mesg += yb_out_scfy.ERRORMSG;
                    FrmMesg frmmesg = new FrmMesg();
                    frmmesg.StartPosition = FormStartPosition.CenterScreen;
                    frmmesg.In_mesg = "删除费用情况如下：【住院号：" + this.cyjsZyh.Text.Trim() + "-" + Mesg + "】";
                    frmmesg.ShowDialog(this);
                    return;
                }
            }
            string sql_ybsc = "update ihsp_costdet set insursync='N',MSGID = NULL where ihsp_id = " + DataTool.addFieldBraces(ihsp_id) + ";";
            if (BllMain.Db.Update(sql_ybsc) != 0)
            {
                Mesg += " : 医保费用成功！His更新失败\r\n";
            }

            if (!string.IsNullOrEmpty(Mesg))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = "删除费用情况如下：【住院号：" + this.cyjsZyh.Text.Trim() + "-" + Mesg + "】";
                frmmesg.ShowDialog(this);
                return;
            }

            MessageBox.Show("删除费用成功！");
            lblFeeUpLoad.Text = "删除费用成功！";
            lblFeeUpLoad.Update();
            cxfy();
            this.fymxcount();
        }
        private void del_kc22_zyh(string zyh)
        {
            string sql = "delete from KC22 where AKC190='" + zyh + "' and AAE072='" + zyh + "'";

            int ac = jkdb.Update(sql);
            int ab = ac;
        }

        private void btn_jsht_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            lblFeeUpLoad.Text = "";
            string zyhTmp = this.cyjsZyh.Text.Trim();//住院号
            string yllbTmp = this.combocyjsyllb.SelectedValue.ToString().Trim();//医疗类别
            string zyjlId = ihsp_id;//住院记录id
            string grbhTmp = this.cyjsGrbh.Text.Trim();//个人编号

            string mes = "确定结算回退[住院号:" + zyhTmp + ",姓名:" + this.cyjsXm.Text + "]吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            js_ht(zyhTmp, yllbTmp, zyjlId, grbhTmp);
        }
        //结算回退
        public void js_ht(string strZyh, string strYllb, string strZyjlId, string strGrbh)
        {
            if (string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strZyjlId))
            {
                MessageBox.Show("获取结算回退参数失败!!!");
                return;
            }
            string sql1 = "select ihsp_account.id from ihsp_account,inhospital where  ihsp_account.ihsp_id = inhospital.id and inhospital.unlocked = 'Y'  and inhospital.id=" + DataTool.addFieldBraces(strZyjlId);
            DataTable dt_acc = BllMain.Db.Select(sql1).Tables[0];
            if (dt_acc.Rows.Count <= 0)
            {
                MessageBox.Show("未查询到解锁信息,请进行解锁");
                return;
            }
            string account_id = dt_acc.Rows[0]["id"].ToString();
            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");

                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y" || 1 == 1)
                { }
                else
                {
                    MessageBox.Show("不是当天结算,请进行回退申请");
                    return;
                }
            }
            else
            {
                MessageBox.Show("未查询到解锁信息,请进行解锁");
                return;
            }
            //读人员基本信息和帐户信息

            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "28";
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡


            yb_in_ryjbxxhzh.AAC001 = "0";

            yb_in_ryjbxxhzh.MSGNO = "1401";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }

            if (yb_out_ryjbxxhzh.ZKC031.Equals("1"))
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("此人目前为在院状态，不能再做住院结算召回操作！", "提示信息");
                return;
            }
            string sql_sybdz = "SELECT * FROM sjz_yb_jsxx WHERE iscurr = 'Y' AND AKC190 = " + DataTool.addFieldBraces(strZyh);
            DataTable dt_sybdz = BllMain.Db.Select(sql_sybdz).Tables[0];
            if (dt_sybdz.Rows.Count <= 0)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("此人目前His没有结算信息，不能再做住院结算召回操作！", "提示信息");
                return;
            }
            string djh = "";
            string jyls = "";
            string AKA130 = "";
            //查询 单据号

            string sql_djh = "select AKA130,AAE072,MSGID from sjz_yb_jsxx where AKC190='" + strZyh + "'  ORDER BY aae040 DESC";
            DataTable dt_jsxx = BllMain.Db.Select(sql_djh).Tables[0];
            djh = dt_jsxx.Rows[0]["AAE072"].ToString().Trim();
            jyls = dt_jsxx.Rows[0]["MSGID"].ToString().Trim();
            AKA130 = dt_jsxx.Rows[0]["AKA130"].ToString().Trim();

            //结算回退
            SJZYB_IN<zyjszh_IN> yb_in_zyjsht = new SJZYB_IN<zyjszh_IN>();
            yb_in_zyjsht.INPUT = new List<zyjszh_IN>();
            zyjszh_IN zyjszh_in = new zyjszh_IN();
            zyjszh_OUT yb_out_zyjsht = new zyjszh_OUT();
            zyjszh_in.AAE072 = djh;
            zyjszh_in.AKC190 = strZyh;
            zyjszh_in.AKC281 = jyls;
            yb_in_zyjsht.INPUT.Add(zyjszh_in);


            string sql_ybjl = "select healthcard,insurcode from inhospital LEFT JOIN sybzyjl ON sybzyjl.AKC190 = inhospital.ihspcode where sybzyjl.id=" + DataTool.addFieldBraces(strZyjlId.ToString()) + "";
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string iccode = dtybjl.Rows[0]["healthcard"].ToString().Trim();
            string grbh1 = dtybjl.Rows[0]["insurcode"].ToString().Trim();

            yb_in_zyjsht.AAC001 = "0";
            yb_in_zyjsht.AKC190 = strZyh;
            yb_in_zyjsht.AKC020 = iccode;
            yb_in_zyjsht.AKA130 = AKA130;
            yb_in_zyjsht.MSGNO = "1203";

            int ret_zyjsht = sjzybInterface.zyjszh(yb_in_zyjsht, ref yb_out_zyjsht);
            if (yb_out_zyjsht.RETURNNUM == -1)
            {
                MessageBox.Show(yb_out_zyjsht.ERRORMSG, "提示信息");
                return;
            }
            decimal AKC264 = 0;
            decimal AKC255 = 0;
            decimal AKC260 = 0;
            decimal AKC261 = 0;
            decimal AKC706 = 0;
            decimal AKC707 = 0;
            decimal AKC708 = 0;


            AKC264 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC264"].ToString());
            AKC255 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC255"].ToString());
            AKC260 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC260"].ToString());
            AKC261 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC261"].ToString());
            AKC706 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC706"].ToString());
            AKC707 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC707"].ToString());
            AKC708 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC708"].ToString());

            js_sql jsxx = new js_sql();
            jsxx.AAE072 = yb_in_zyjsht.INPUT[0].AAE072;
            jsxx.AKC190 = yb_in_zyjsht.AKC190;
            jsxx.BKC111 = "";
            jsxx.MSGID = yb_in_zyjsht.MSGID;
            jsxx.REFMSGID = yb_out_zyjsht.REFMSGID;
            jsxx.AKA130 = yb_in_zyjsht.AKA130;
            jsxx.id = BillSysBase.nextId("sjz_yb_jsxx");
            string sql_jsxx = " INSERT INTO sjz_yb_jsxx (id,AKA130,AKC190,AAE072,MSGID,REFMSGID,AKC264,AKC255,AKC260,AKC261,AKC706,AKC707,AKC708,AAE040,registkind)"
                            + " VALUES( "
                            + DataTool.addFieldBraces(jsxx.id)
                            + "," + DataTool.addFieldBraces(jsxx.AKA130)
                            + "," + DataTool.addFieldBraces(jsxx.AKC190)
                            + "," + DataTool.addFieldBraces(jsxx.AAE072)
                            + "," + DataTool.addFieldBraces(jsxx.MSGID)
                            + "," + DataTool.addFieldBraces(jsxx.REFMSGID)
                            + "," + DataTool.addFieldBraces(AKC264.ToString())
                            + "," + DataTool.addFieldBraces(AKC255.ToString())
                            + "," + DataTool.addFieldBraces(AKC260.ToString())
                            + "," + DataTool.addFieldBraces(AKC261.ToString())
                            + "," + DataTool.addFieldBraces(AKC706.ToString())
                            + "," + DataTool.addFieldBraces(AKC707.ToString())
                            + "," + DataTool.addFieldBraces(AKC708.ToString())
                            + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                            + "," + DataTool.addFieldBraces("IHSP")
                            + " );";
            sql_jsxx += "UPDATE sjz_yb_jsxx SET iscurr = 'N' where akc190 = " + DataTool.addFieldBraces(jsxx.AKC190) + ";";
            BllMain.Db.Update(sql_jsxx);

            string sql2 = "";
            if (strYllb == "29")
            {
                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + strZyjlId;
                BllMain.Db.Update(his_sql_update_ht);
                //修改his医保标志
                string sql = "update inhospital set yllb = '28',settInsurdate=null where id=" + strZyjlId;//_iid.ToString().Trim(); //2019_3_21增加更新医保报销时间为空  czh
                BllMain.Db.Update(sql);
            }
            else
            {

                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0 where ihsp_id=" + strZyjlId;//
                BllMain.Db.Update(his_sql_update_ht);
                string sql = "update inhospital set settInsurdate=null  where id=" + strZyjlId;//_iid.ToString().Trim(); //2019_3_21增加更新医保报销时间为空 czh
                BllMain.Db.Update(sql);
            }
            if (Ini.IniReadValue2("pz", "ISXJHB") == "0")
            {
                if (!retAccount(strZyjlId))
                {
                    MessageBox.Show("his撤销失败");
                    return;
                }
            }
            else
            {
                string sql_upaccount = "UPDATE ihsp_account SET insurefee = 0 insuraccountfee = 0  WHERE ihsp_id = " + strZyjlId;
                BllMain.Db.Update(sql_upaccount);
            }
            initButton();
            MessageBox.Show("结算回退成功！", "提示信息");
            return;
        }
        private bool retAccount(string ihsp_id)
        {
            //string sql = "select ihsp_account.id,ihsp_invoicedet.bas_paytype_id from ihsp_account,ihsp_invoicedet,inhospital where  ihsp_invoicedet.ihsp_account_id=ihsp_account.id and ihsp_account.ihsp_id = inhospital.id and inhospital.id=" + ihsp_id;
            //DataTable d1t = BllMain.Db.Select(sql).Tables[0];
            string sqll = "select ihsp_account_id from ihsp_costdet where ihsp_id=" + ihsp_id;
            DataTable d2t = BllMain.Db.Select(sqll).Tables[0];
            string account_id = d2t.Rows[0]["ihsp_account_id"].ToString();
            string sql = "select bas_paytype_id from ihsp_invoicedet where  ihsp_account_id=" + account_id;
            DataTable d1t = BllMain.Db.Select(sql).Tables[0];


            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                string ihspaccountId = dataTable.Rows[0]["id"].ToString();
                string sourceHisOrderNo = dataTable.Rows[0]["hisOrderNo"].ToString();
                DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");

                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y" || 1 == 1)
                {

                    //网络支付退费
                    //string currDate = BillSysBase.currDate();
                    //string hisRefundNo = "";
                    //if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
                    //{
                    //    return false;
                    //}

                    //网络支付退费_END
                    string paytypeId = d1t.Rows[0]["bas_paytype_id"].ToString();//从界面获取实收金额的paytype
                    if (billIhspAct.cancleAccount(ihspaccountId, paytypeId) < 0)
                    {

                        return false;
                    }


                    return true;
                }
                else
                {
                    MessageBox.Show("不是当天结算,请进行回退申请");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("没有可退结算记录!");
                return false;
            }
        }
        private void upcsbz_Kc22_JK0(string zyh, string djh, string yllb)//修改kc22传输标志，置为0
        {

            string sql = "UPDATE KC22 SET CKC126 =0 WHERE AKC190 ='" + zyh + "'";
            if (yllb == "29")
            {
                sql += " and aae072 ='" + djh + "'";
            }
            JKDB jkdb = new JKDB();
            int r = jkdb.Update(sql);
            if (-1 == r)
            {
                MessageBox.Show("数据库更新错误");
                return;
            }
        }

        private void btn_ypqb_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from inhospital where id = '" + ihsp_id + "'";
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "301")
                return;
            string sql_ypqbgx = "update ihsp_costdet set ypspbz=1 where insursync='N' and yptsxx!='' and ypspbz not in (1,2) and ihsp_id='" + this.ihsp_id + "'";
            BllMain.Db.Update(sql_ypqbgx);
        }

        private void btn_ypqbb_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from inhospital where id = '" + ihsp_id + "'";
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "301")
                return;
            string sql_ypqbgx = "update ihsp_costdet set ypspbz=2 where  insursync='N' and yptsxx!='' and ypspbz not in (1,2) and ihsp_id='" + this.ihsp_id + "'";
            BllMain.Db.Update(sql_ypqbgx);
        }

        private void btn_sfbx_Click(object sender, EventArgs e)
        {
            string sql_gxsfck = "select sfck,outdate from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            string mtzyjliid = this.ihsp_id;
            String sql_xmcx = " select ihsp_costdet.id,bas_item.standcode as standcode,cost_itemtype.netcode as itemfromcode ";
            sql_xmcx += " from ihsp_costdet left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id ";
            sql_xmcx += " left join bas_item on bas_item.id=ihsp_costdet.item_id and bas_item.standcode not in('','0') ";
            sql_xmcx += " where ihsp_costdet.ihsp_id=" + ihsp_id + " and ihsp_costdet.insursync='N' and ihsp_costdet.charged in ('RREC','RET','CHAR')";
            //sql_xmcx += " and insur_itemfrom.cost_insurtype_id=" + DataTool.addFieldBraces(ylkfkfs);

            DataTable datatable = BllMain.Db.Select(sql_xmcx).Tables[0];
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                string iid = datatable.Rows[i]["id"].ToString();//费用id
                string standcode = datatable.Rows[i]["standcode"].ToString();//医保编码
                string insurcode = datatable.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
                if ((standcode == "") || (standcode == "0"))
                {
                    continue;
                }
                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "0";
                if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
                {
                    yw_in_smldz.Ylzh = "0";
                }
                else
                {
                    yw_in_smldz.Ylzh = this.cyjsGrbh.Text.Trim();
                }
                yw_in_smldz.Rc = standcode;
                if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA02";
                    int opt_smldz = 0; //yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        continue;
                    }
                    //string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "',insurclass = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    BllMain.Db.Update(update_sql);
                }
                else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA04";
                    int opt_smldz = 0; //yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        continue;
                    }
                    //string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "',insurclass = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    BllMain.Db.Update(update_sql);
                }
                else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA03";
                    int opt_smldz = 0; //yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        continue;
                    }
                    //string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    string update_sql = "update ihsp_costdet set yblx = '" + smldz_cc[0] + "',insurclass = '" + smldz_cc[0] + "' where id=" + iid + ";";
                    BllMain.Db.Update(update_sql);
                }
            }
            MessageBox.Show("判断报销已经完成！其中费用等级为空为没有对码项目！");
        }



        private void but_jybfdhje_Click(object sender, EventArgs e)
        {
            if (this.but_jybfdhje.Text.ToString().Equals("使用账户"))
            {
                this.but_jybfdhje.Text = "不使用账户";
            }
            else if (this.but_jybfdhje.Text.ToString().Equals("不使用账户"))
            {
                this.but_jybfdhje.Text = "使用账户";
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                ybmxcx();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                string sqlitem = "SELECT "
                                + " ihsp_costdet.ihsp_id AS Mtzyjl, "
                                + " ihsp_costdet.itemfrom AS Xmlb, "
                                + " bas_item.NAME AS xmmc, "
                                + " cost_insurcross.insurcode AS Ybbm, "
                                + " ihsp_costdet.spec AS Guige, "
                                + " ihsp_costdet.unit AS Uom, "
                                + " ihsp_costdet.prc AS Prc, "
                                + " sum( ihsp_costdet.num ) AS Qty, "
                                + " sum( ihsp_costdet.fee ) AS Amt, "
                                + " bas_item.id AS mtprod  "
                            + " FROM "
                                + " ihsp_costdet  "
                                + " LEFT JOIN bas_item ON ihsp_costdet.item_id = bas_item.id"
                                + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id"
                            + " WHERE "
                                + " ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)
                                + " AND ihsp_costdet.charged IN ( 'CHAR' )  "
                            + " GROUP BY "
                                + " ihsp_costdet.ihsp_id, "
                                + " ihsp_costdet.itemfrom, "
                                + " bas_item.hiscode, "
                                + " ihsp_costdet.insurclass, "
                                + " ihsp_costdet.spec, "
                                + " ihsp_costdet.unit, "
                                + " bas_item.id ";

                dataGridView3.DataSource = BllMain.Db.Select(sqlitem).Tables[0];
                double zjehj = 0;
                double xfdhjehj = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "") || (dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "0"))
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;//
                    zjehj += double.Parse(dataGridView3.Rows[i].Cells["xmje"].Value.ToString());
                    //string xfdhje5 = dataGridView3.Rows[i].Cells["xfdhje"].Value.ToString().Trim();
                    //if (!string.IsNullOrEmpty(xfdhje5))
                    //{
                    //    xfdhjehj += double.Parse(xfdhje5);
                    //}
                }
                this.lbl_zje.Text = zjehj.ToString("0.00");
                this.lbl_xfdhje.Text = xfdhjehj.ToString("0.00");
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                cxfy();
            }
        }
        public void ybmxcx()
        {
            SJZYB_IN<DownloadCostdet_In> yb_in_ryjbxxhzh = new SJZYB_IN<DownloadCostdet_In>();
            yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
            DownloadCostdet_In dom = new DownloadCostdet_In();
            DownloadCostdet_Out yb_out_ryjbxxhzh = new DownloadCostdet_Out();
            dom.AKC190 = this.cyjsZyh.Text.ToString();
            dom.CURRENTPAGE = "1";
            yb_in_ryjbxxhzh.INPUT.Add(dom);
            //判断有卡无卡
            string Ylzh = "";

            Ylzh = "0";

            yb_in_ryjbxxhzh.AKC020 = this.cyjsICkh.Text.ToString(); ;
            yb_in_ryjbxxhzh.MSGNO = "1636";
            yb_in_ryjbxxhzh.AKA130 = this.combocyjsyllb.SelectedValue.ToString(); ;
            int ret = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            string ReturnMsg = "";
            if (int.Parse(yb_out_ryjbxxhzh.TOTALPAGE) > 2)
            {
                for (int i = 2; i <= int.Parse(yb_out_ryjbxxhzh.TOTALPAGE); i++)
                {
                    yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
                    dom = new DownloadCostdet_In();
                    dom.AKC190 = this.cyjsZyh.Text.ToString();
                    dom.CURRENTPAGE = i.ToString();
                    yb_in_ryjbxxhzh.INPUT.Add(dom);
                    ret = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
                    int returnnum = Convert.ToInt32(yb_out_ryjbxxhzh.RETURNNUM);
                    if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                    {
                        ReturnMsg = yb_out_ryjbxxhzh.ERRORMSG;
                        MessageBox.Show(ReturnMsg, "提示信息");
                        return;
                    }
                }
            }
            if (yb_out_ryjbxxhzh.OUTROW.Count > 0)
            {
                //DataTable dt = yb_out_ryjbxxhzh.OUTROW.ToDataTable<DownloadCostdet_Out_OUTROW>();
                DataTable dt = yb_out_ryjbxxhzh.OUTROW.ToDataTable();
                dataGridView(dt);
            }
        }
        public void dataGridView(DataTable dt)
        {
            #region
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["AKA065"].ToString() == "1")
                {
                    dr["AKA065"] = "甲";
                }
                else if (dr["AKA065"].ToString() == "2")
                {
                    dr["AKA065"] = "乙";
                }
                else if (dr["AKA065"].ToString() == "3")
                {
                    dr["AKA065"] = "自费";
                }
                switch (dr["AKA063"].ToString())
                {
                    case "01":
                        dr["AKA063"] = "西药";
                        break;
                    case "02":
                        dr["AKA063"] = "中药";
                        break;
                    case "03":
                        dr["AKA063"] = "中成";
                        break;
                    case "04":
                        dr["AKA063"] = "手术";
                        break;
                    case "05":
                        dr["AKA063"] = "化验";
                        break;
                    case "06":
                        dr["AKA063"] = "检查";
                        break;
                    case "07":
                        dr["AKA063"] = "治疗";
                        break;
                    case "08":
                        dr["AKA063"] = "医用材料";
                        break;
                    case "09":
                        dr["AKA063"] = "贵药品";
                        break;
                    case "10":
                        dr["AKA063"] = "其他自费";
                        break;
                    case "11":
                        dr["AKA063"] = "婴儿费";
                        break;
                    case "12":
                        dr["AKA063"] = "床位";
                        break;
                    case "13":
                        dr["AKA063"] = "放射";
                        break;
                    case "14":
                        dr["AKA063"] = "输血";
                        break;
                    case "15":
                        dr["AKA063"] = "输氧";
                        break;
                    case "16":
                        dr["AKA063"] = "冷暖费";
                        break;
                    case "17":
                        dr["AKA063"] = "接生";
                        break;
                    case "18":
                        dr["AKA063"] = "特检";
                        break;
                    case "19":
                        dr["AKA063"] = "特疗";
                        break;
                    case "20":
                        dr["AKA063"] = "其他住院";
                        break;
                    case "21":
                        dr["AKA063"] = "自费";
                        break;

                }
                dr["AKC221"] = dr["AKC221"].ToString().Substring(0, 4) + "-" + dr["AKC221"].ToString().Substring(4, 2) + "-" + dr["AKC221"].ToString().Substring(6, 2);


            }
            #endregion
            dataGridView1.DataSource = dt;


            dataGridView1.Columns["AKC515"].HeaderText = "医院收费项目编码";
            dataGridView1.Columns["AKC515"].DisplayIndex = 0;
            dataGridView1.Columns["AKC515"].Width = 200;
            dataGridView1.Columns["AKC516"].HeaderText = "医院收费项目名称";
            dataGridView1.Columns["AKC516"].Width = 150;
            dataGridView1.Columns["AKC516"].DisplayIndex = 1;
            dataGridView1.Columns["AKA065"].HeaderText = "项目等级";
            dataGridView1.Columns["AKA065"].Width = 150;
            dataGridView1.Columns["AKA065"].DisplayIndex = 2;
            dataGridView1.Columns["AKA063"].HeaderText = "收费类别";
            dataGridView1.Columns["AKA063"].Width = 150;
            dataGridView1.Columns["AKA063"].DisplayIndex = 3;
            dataGridView1.Columns["AKC225"].HeaderText = "单价";
            dataGridView1.Columns["AKC225"].Width = 150;
            dataGridView1.Columns["AKC225"].DisplayIndex = 4;
            dataGridView1.Columns["AKC226"].HeaderText = "数量";
            dataGridView1.Columns["AKC226"].Width = 150;
            dataGridView1.Columns["AKC226"].DisplayIndex = 5;
            dataGridView1.Columns["AKC227"].HeaderText = "金额";
            dataGridView1.Columns["AKC227"].Width = 150;
            dataGridView1.Columns["AKC227"].DisplayIndex = 6;
            dataGridView1.Columns["AKC222"].HeaderText = "中心收费项目编码";
            dataGridView1.Columns["AKC222"].Width = 150;
            dataGridView1.Columns["AKC222"].DisplayIndex = 7;
            dataGridView1.Columns["AKC223"].HeaderText = "中心收费项目名称";
            dataGridView1.Columns["AKC223"].Width = 150;
            dataGridView1.Columns["AKC223"].DisplayIndex = 8;
            dataGridView1.Columns["AKA069"].HeaderText = "自付比例";
            dataGridView1.Columns["AKA069"].Width = 150;
            dataGridView1.Columns["AKA069"].DisplayIndex = 9;
            dataGridView1.Columns["CKAA06"].HeaderText = "限额内金额";
            dataGridView1.Columns["CKAA06"].Width = 150;
            dataGridView1.Columns["CKAA06"].DisplayIndex = 10;
            dataGridView1.Columns["AKC253"].HeaderText = "超限自费金额";
            dataGridView1.Columns["AKC253"].Width = 150;
            dataGridView1.Columns["AKC253"].DisplayIndex = 11;
            dataGridView1.Columns["AKC783"].HeaderText = "免收金额";
            dataGridView1.Columns["AKC783"].Width = 150;
            dataGridView1.Columns["AKC783"].DisplayIndex = 12;
            dataGridView1.Columns["AKA070"].HeaderText = "剂型";
            dataGridView1.Columns["AKA070"].Width = 150;
            dataGridView1.Columns["AKA070"].DisplayIndex = 13;
            dataGridView1.Columns["AKC604"].HeaderText = "规格";
            dataGridView1.Columns["AKC604"].Width = 150;
            dataGridView1.Columns["AKC604"].DisplayIndex = 14;
            dataGridView1.Columns["AKC221"].HeaderText = "处方日期";
            dataGridView1.Columns["AKC221"].Width = 150;
            dataGridView1.Columns["AKC221"].DisplayIndex = 15;
            dataGridView1.Columns["AKC378"].HeaderText = "医院处方流水号";
            dataGridView1.Columns["AKC378"].Width = 150;
            dataGridView1.Columns["AKC378"].DisplayIndex = 16;

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0)
            //{ return; }

            //string mtzyjlstuffiid = dataGridView2.CurrentRow.Cells["id"].Value.ToString().Trim();
            //string xmmc = dataGridView2.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
            //string fydj = dataGridView2.CurrentRow.Cells["费用等级"].Value.ToString().Trim();
            //string hism = dataGridView2.CurrentRow.Cells["prodiid"].Value.ToString().Trim();
            //string xmbmsql = " select hiscode as xmbm from bas_item where id = " + hism + " ";
            //DataTable dt = BllMain.Db.Select(xmbmsql).Tables[0];
            //string xmbm = dt.Rows[0]["xmbm"].ToString().Trim();
            //FrmXgjyb jyb = new FrmXgjyb();
            //jyb.Hzmc = this.cyjsXm.Text.Trim();
            //jyb.Xmmc = xmmc;
            //jyb.Jyb = fydj;
            //jyb.Xmbm = xmbm;
            //jyb.Xzxyysm = dataGridView2.CurrentRow.Cells["药品提示信息"].Value.ToString().Trim();
            //jyb.StartPosition = FormStartPosition.CenterScreen;
            //jyb.ShowDialog();
            //if (jyb.Flag == false)
            //{
            //    return;
            //}
            //string updateyblx = "update ihsp_costdet set ypspbz='" + jyb.Xzxyysfkb + "', yblx = '" + jyb.Jyb + "' where insursync='N' and ihsp_id = " + ihsp_id + " and id = " + mtzyjlstuffiid;
            //BllMain.Db.Update(updateyblx);
            //this.cxfy();
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{
            //    if (dataGridView2.Rows[i].Cells["iid"].Value.ToString() == mtzyjlstuffiid)
            //    {
            //        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["项目名称"];
            //        break;
            //    }
            //}
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //{
            //    return;
            //}
            //if (dataGridView3.Rows.Count <= 0)
            //{
            //    return;
            //}
            //if ((dataGridView3.Rows[e.RowIndex].Cells["Ybbm"].Value.ToString() == "") || (dataGridView3.Rows[e.RowIndex].Cells["Ybbm"].Value.ToString() == "0"))
            //{
            //    FrmXmbmxg xfxmbm = new FrmXmbmxg();
            //    xfxmbm.Xmmc = this.dataGridView3.Rows[e.RowIndex].Cells["xmmc"].Value.ToString().Trim();
            //    xfxmbm.Mtprodiid = this.dataGridView3.Rows[e.RowIndex].Cells["hisbm"].Value.ToString().Trim();
            //    xfxmbm.Xmjg = this.dataGridView3.Rows[e.RowIndex].Cells["xmdj"].Value.ToString().Trim();
            //    xfxmbm.StartPosition = FormStartPosition.CenterScreen;
            //    xfxmbm.ShowDialog();
            //}

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string costdet_id = dataGridView2.CurrentRow.Cells["id"].ToString().Trim();
            string costdet_name = dataGridView2.CurrentRow.Cells["项目名称"].ToString().Trim();
            string grbh = this.cyjsGrbh.Text.ToString().Trim();
            string zyh = this.cyjsZyh.Text.ToString().Trim();
            string sql = "select fee,AKC378,MSGID from ihsp_costdet id = " + DataTool.addFieldBraces(costdet_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (double.Parse(dt.Rows[0]["fee"].ToString().Trim()) <= 0)
            {
                MessageBox.Show("只能删除计费项目！", "提示信息");
                return;
            }


            string mes = "确定删除" + costdet_name + "吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            SJZYB_IN<zyfysc_IN> yb_in_scfy = new SJZYB_IN<zyfysc_IN>();
            yb_in_scfy.INPUT = new List<zyfysc_IN>();
            zyfysc_IN zyfysc_in = new zyfysc_IN();
            zyfysc_in.AAC001 = grbh;
            zyfysc_in.AKC190 = zyh;
            zyfysc_in.AKC281 = dt.Rows[0]["MSGID"].ToString().Trim();
            zyfysc_in.AKC378 = dt.Rows[0]["AKC378"].ToString().Trim();
            yb_in_scfy.INPUT.Add(zyfysc_in);

            string Ylzh = "";
            string sql_ybjl = "SELECT AAC001,AKA130,AKC020,AKC190 FROM sjz_yb_inof  WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string yllb = dtybjl.Rows[0]["AKA130"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["AKC020"].ToString().Trim();
            string sql_gxsfck = "select sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                Ylzh = "0";
            }
            else
            {
                Ylzh = grbh;
            }
            yb_in_scfy.AKA130 = yllb;
            yb_in_scfy.AAC001 = Ylzh;
            yb_in_scfy.AKC190 = zyh;
            yb_in_scfy.AKC020 = iccode;
            yb_in_scfy.MSGNO = "1106";
            SJZYB_OUT yb_out_scfy = new SJZYB_OUT();
            int ret = sjzybInterface.zyfy_delete(yb_in_scfy, yb_out_scfy);

            if (yb_out_scfy.RETURNNUM != 1)
            {
                MessageBox.Show("删除费用失败！", "提示信息");
                return;
            }
            string sql_ybsc = "update ihsp_costdet set insursync='N',MSGID = NULL where id = " + DataTool.addFieldBraces(costdet_id) + ";";
            if (BllMain.Db.Update(sql_ybsc) != 0)
            {
                MessageBox.Show("医保费用成功！His更新失败", "提示信息");
                return;
            }
            MessageBox.Show("删除费用成功！", "提示信息");

        }

        private void btn_jscd_Click(object sender, EventArgs e)
        {
            lblFeeUpLoad.Text = "";
            string sql_print = " select print from ihsp_account  where ihsp_id = '" + ihsp_id + "';";
            DataTable ds_print = BllMain.Db.Select(sql_print).Tables[0];
            if (Double.Parse(ds_print.Rows[0]["print"].ToString()) >= 1)
            {
                MessageBox.Show("发票已打印，不能重复打印。");
                return;
            }
            this.dyfp(this.cyjsGrbh.Text.Trim(), this.cyjsZyh.Text.Trim(), ihsp_id);

        }

        private void cyjsZhzf_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                return;
            }
            string zhye = this.cyjsZhye.Text;
            if (zhye == null || zhye == "" || zhye == "0")
            {
                MessageBox.Show("帐户余额为空或者0,不能输入！", "提示信息");
                return;
            }
            double zhye_d = Double.Parse(zhye);

            String bczhzfje = this.cyjsZhzf.Text;
            if (bczhzfje == null || bczhzfje == "")
            {
                MessageBox.Show("请输入正确的本次帐户支付金额！", "提示信息");
                return;
            }
            double bczhzfje_d = Double.Parse(bczhzfje);
            if (bczhzfje_d > zhye_d)
            {
                MessageBox.Show("本次帐户支付不能大于帐户余额！", "提示信息");
                this.cyjsZhzf.Text = "";
                this.bxhj.Text = "";
                return;
            }
            String bcxjyzf = this.cyjsXjygzf.Text;
            if (bcxjyzf == null || bcxjyzf == "")
            {
                MessageBox.Show("本次现金应支付为空或者0", "提示信息");
                this.cyjsZhzf.Text = "";
                this.bxhj.Text = "";
                return;
            }
            double bcxjyzf_d = Double.Parse(bcxjyzf);
            if (bczhzfje_d > bcxjyzf_d)
            {
                MessageBox.Show("本次帐户支付不能大于本次现金应支付！", "提示信息");
                this.cyjsZhzf.Text = "";
                this.bxhj.Text = "";
                return;
            }

            double bcxjzf = bcxjyzf_d - bczhzfje_d;
            double bcxjzf_x = Math.Round(bcxjzf, 2);
            this.bxhj.Text = bcxjzf_x.ToString().Trim();
            if (this.yjkzfy.Text.Trim() == "" || this.yjkzfy.Text.Trim() == null)
            {
                this.tbx_thbxj.Text = (0 - double.Parse(this.bxhj.Text)).ToString().Trim();
            }
            else
            {
                this.tbx_thbxj.Text = (double.Parse(this.yjkzfy.Text) - double.Parse(this.bxhj.Text)).ToString().Trim();
            }
        }



        private void combocyjsyllb_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string type = this.combocyjsyllb.SelectedValue.ToString().Trim();
                if (type == "52")
                {
                    this.groupBox3.Visible = true;
                }
                else
                {
                    this.groupBox3.Visible = false;
                }
            }
            catch { }
        }

        private void btn_fyqd_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_zh = new SJZYB_IN<DK_IN>();
            yb_in_zh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_zh = new DK_OUT();
            dk.BKA130 = "29";//出院预结算
            yb_in_zh.INPUT.Add(dk);
            //判断有卡无卡
            string Ylzh = "";

            Ylzh = "0";

            //yb_in_zh.MSGNO = "1401";
            //yb_in_zh.AAC001 = Ylzh;
            //int ret = sjzybInterface.DK(yb_in_zh, ref yb_out_zh);
            //if (ret == -1)
            //{
            //    lblFeeUpLoad.Text = "";
            //    MessageBox.Show(yb_out_zh.ERRORMSG, "提示信息");
            //    return;
            //}

            SJZYB_IN<DownloadCostdet_In> yb_in_ryjbxxhzh = new SJZYB_IN<DownloadCostdet_In>();
            yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
            DownloadCostdet_In dom = new DownloadCostdet_In();
            DownloadCostdet_Out yb_out_ryjbxxhzh = new DownloadCostdet_Out();
            dom.AKC190 = this.cyjsZyh.Text.ToString();
            dom.CURRENTPAGE = "1";
            yb_in_ryjbxxhzh.INPUT.Add(dom);
            //判断有卡无卡


            Ylzh = "0";

            yb_in_ryjbxxhzh.AKC020 = this.cyjsICkh.Text.ToString(); ;
            yb_in_ryjbxxhzh.MSGNO = "1636";
            yb_in_ryjbxxhzh.AKA130 = this.combocyjsyllb.SelectedValue.ToString(); ;
            int ret = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            string ReturnMsg = "";
            if (int.Parse(yb_out_ryjbxxhzh.TOTALPAGE) > 1)
            {
                for (int i = 2; i <= int.Parse(yb_out_ryjbxxhzh.TOTALPAGE); i++)
                {
                    yb_in_ryjbxxhzh.INPUT = new List<DownloadCostdet_In>();
                    dom = new DownloadCostdet_In();
                    dom.AKC190 = this.cyjsZyh.Text.ToString();
                    dom.CURRENTPAGE = i.ToString();
                    yb_in_ryjbxxhzh.INPUT.Add(dom);
                    ret = sjzybInterface.DownloadCostdet(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
                    int returnnum = Convert.ToInt32(yb_out_ryjbxxhzh.RETURNNUM);
                    if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                    {
                        ReturnMsg = yb_out_ryjbxxhzh.ERRORMSG;
                        MessageBox.Show(ReturnMsg, "提示信息");
                        return;
                    }
                }
            }
            #region  数据库版

            string sql_insert = "";
            string sql_delete = "DELETE  from ihsp_costdet_yb WHERE akc190 =" + DataTool.addFieldBraces(this.cyjsZyh.Text.ToString());
            if (BllMain.Db.Update(sql_delete) != 0)
            {
                MessageBox.Show("保存失败，请联系管理员");
                return;
            }
            foreach (DownloadCostdet_Out_OUTROW dic in yb_out_ryjbxxhzh.OUTROW)
            {
                sql_insert += "INSERT INTO ihsp_costdet_yb ( akc190,akc515,akc516,aka065,AKA063,AKC225,AKC226,AKC227,AKC222,AKC223,AKA069,CKAA06,AKC253,AKC783,AKA070,AKC604,AKC221,AKC378)VALUES"
                           + "("
                           + DataTool.addFieldBraces(dic.AKC190)
                           + "," + DataTool.addFieldBraces(dic.AKC515)
                           + "," + DataTool.addFieldBraces(dic.AKC516)
                           + "," + DataTool.addFieldBraces(dic.AKA065)
                           + "," + DataTool.addFieldBraces(dic.AKA063)
                           + "," + DataTool.addFieldBraces(dic.AKC225)
                           + "," + DataTool.addFieldBraces(dic.AKC226)
                           + "," + DataTool.addFieldBraces(dic.AKC227)
                           + "," + DataTool.addFieldBraces(dic.AKC222)
                           + "," + DataTool.addFieldBraces(dic.AKC223)
                           + "," + DataTool.addFieldBraces(dic.AKA069)
                           + "," + DataTool.addFieldBraces(dic.CKAA06)
                           + "," + DataTool.addFieldBraces(dic.AKC253)
                           + "," + DataTool.addFieldBraces(dic.AKC783)
                           + "," + DataTool.addFieldBraces(dic.AKA070)
                           + "," + DataTool.addFieldBraces(dic.AKC604)
                           + "," + DataTool.addFieldBraces(dic.AKC221)
                           + "," + DataTool.addFieldBraces(dic.AKC378)
                           + ");";
            }
            if (BllMain.Db.Update(sql_insert) != 0)
            {
                MessageBox.Show("保存失败，请联系管理员");
                return;
            }

            string sql_select = "SELECT akc190,akc515,akc516,aka065,AKA063,AKC225,sum(AKC226)AS AKC226 ,sum(AKC227) AS AKC227 ,AKC222,AKC223,AKA069,CKAA06,AKC253,AKC783,AKA070,AKC604,AKC221,AKC378 from ihsp_costdet_yb"
                              + " WHERE akc190 = " + DataTool.addFieldBraces(this.cyjsZyh.Text.ToString())
                              + " GROUP BY akc190,akc515,akc516,aka065,AKA063,AKC225,AKC222,AKC223,AKA069,CKAA06,AKC253,AKC783,AKA070,AKC604";
            DataTable dt1 = BllMain.Db.Select(sql_select).Tables[0];

            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.costdetPrt_sjz(dt1, ihsp_id, "");//yb_out_zh.AAB001);

            #endregion

            


        }



        private void button2_Click(object sender, EventArgs e)
        {
            string sql_gxsfck = "select healthcard,insurcode, AKA130,AAE072 from inhospital LEFT JOIN sjz_yb_jsxx ON sjz_yb_jsxx.AKC190 = inhospital.ihspcode and  sjz_yb_jsxx.iscurr = 'Y' where inhospital.id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows.Count != 1)
            {
                MessageBox.Show("结算信息异常");
                return;
            }
            string yllb = ds_sfck.Tables[0].Rows[0]["AKA130"].ToString().Trim();
            string grbh = ds_sfck.Tables[0].Rows[0]["insurcode"].ToString().Trim();
            string iccode = ds_sfck.Tables[0].Rows[0]["healthcard"].ToString().Trim();
            SJZYB_IN<ybSettRpt_In> sjzyb_in = new SJZYB_IN<ybSettRpt_In>();
            string Ylzh = grbh;
            sjzyb_in.INPUT = new List<ybSettRpt_In>();
            ybSettRpt_In dom = new ybSettRpt_In();
            dom.AAE072 = ds_sfck.Tables[0].Rows[0]["AAE072"].ToString().Trim();
            dom.AKC190 = this.cyjsZyh.Text;
            sjzyb_in.INPUT.Add(dom);
            sjzyb_in.AKA130 = yllb;
            sjzyb_in.AAC001 = Ylzh;
            sjzyb_in.AKC190 = this.cyjsZyh.Text;
            sjzyb_in.AKC020 = iccode;
            sjzyb_in.MSGNO = "1731";
            ybSettRpt_Out sjzyb_out = new ybSettRpt_Out();

            int ret = sjzybInterface.DownloadSett(sjzyb_in, ref sjzyb_out);
            if (ret == -1)
            {
                MessageBox.Show(sjzyb_out.ERRORMSG, "提示信息");
                return;
            }

            FrxPrintView FrxPrintView = new FrxPrintView();
            if (sjzyb_out.CKAA14 == "0")
            {
                FrxPrintView.sjzybybSettRpt_jm(dom.AAE072, "", sjzyb_out);
            }
            else if (sjzyb_out.CKAA14 == "1")
            {
                FrxPrintView.sjzybybSettRpt_zg(dom.AAE072, "", sjzyb_out);
            }
            else if (sjzyb_out.CKAA14 == "2")
            {
                FrxPrintView.sjzybybSettRpt_gwy(dom.AAE072, "", sjzyb_out);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            jsdcdnew(this.cyjsZyh.Text.Trim());
        }
        public void jsdcdnew(string strZyh)
        {
            #region
            if (string.IsNullOrEmpty(strZyh))
            {
                MessageBox.Show("发票参数获取失败!");
                return;
            }

            string sql_gxsfck = "select healthcard,insurcode, AKA130,AAE072 from inhospital LEFT JOIN sjz_yb_jsxx ON sjz_yb_jsxx.AKC190 = inhospital.ihspcode where inhospital.id=" + DataTool.addFieldBraces(ihsp_id.ToString()) + "";
            DataTable dt_cyzd = BllMain.Db.Select(sql_gxsfck).Tables[0];


            string yllb = dt_cyzd.Rows[0]["AKA130"].ToString().Trim();
            string grbh = dt_cyzd.Rows[0]["insurcode"].ToString().Trim();
            string iccode = dt_cyzd.Rows[0]["healthcard"].ToString().Trim();

            SJZYB_IN<statementsJM_In> sjzyb_in = new SJZYB_IN<statementsJM_In>();
            sjzyb_in.INPUT = new List<statementsJM_In>();
            statementsJM_In dom = new statementsJM_In();
            dom.AAE072 = dt_cyzd.Rows[0]["AAE072"].ToString().Trim();
            dom.AKC190 = this.cyjsZyh.Text;
            sjzyb_in.INPUT.Add(dom);
            sjzyb_in.AKA130 = yllb;
            sjzyb_in.AAC001 = grbh;
            sjzyb_in.AKC190 = this.cyjsZyh.Text;
            sjzyb_in.AKC020 = iccode;
            sjzyb_in.MSGNO = "1732";
            statementsJM_Out sjzyb_out = new statementsJM_Out();

            int ret = sjzybInterface.DownloadstatementsJM(sjzyb_in, ref sjzyb_out);
            if (ret == -1)
            {
                MessageBox.Show(sjzyb_out.ERRORMSG, "提示信息");
                return;
            }


            string in_zfc1 = "|";
            in_zfc1 += "河北省城乡居民医疗保障费用结算单|";
            in_zfc1 += "（结算日期：" + sjzyb_out.AAE040.Substring(0, 4) + "年" + sjzyb_out.AAE040.Substring(4, 2) + "月" + sjzyb_out.AAE040.Substring(6, 2) + "日" + ")|";
            //in_zfc1 += "报销类别:" + dtbxlb.Tables[0].Rows[0]["AKA130"].ToString().Trim() + "|";

            in_zfc1 += "报销类别:" + sjzyb_out.CKAA52 + "|";
            in_zfc1 += "医疗机构名称:" + sjzyb_out.AKB021 + "|";
            in_zfc1 += "医疗机构等级:" + sjzyb_out.CKAA53 + "|";//县级医院，一般为二级，其余的都是一级及以下,具体情况问医院
            in_zfc1 += "住院号:" + sjzyb_out.AKC190 + "|";
            in_zfc1 += "单位：元|";
            in_zfc1 += "姓名|" + sjzyb_out.AAC003 + "|";
            in_zfc1 += "性别|" + sjzyb_out.AAC004 + "|";
            in_zfc1 += "身份证号|" + sjzyb_out.AAC002 + "|";

            in_zfc1 += "参保地|" + sjzyb_out.CKAA54 + "|";
            in_zfc1 += "人员类别|" + sjzyb_out.CKAA55 + "|";

            in_zfc1 += "诊断名称|" + sjzyb_out.AKC141 + "|";
            in_zfc1 += "入院日期|" + sjzyb_out.AKC192.Substring(0, 4) + "-" + sjzyb_out.AKC192.Substring(4, 2) + "-" + sjzyb_out.AKC192.Substring(6, 2) + "|";
            in_zfc1 += "出院日期|" + sjzyb_out.AKC194.Substring(0, 4) + "-" + sjzyb_out.AKC194.Substring(4, 2) + "-" + sjzyb_out.AKC194.Substring(6, 2) + "|";
            in_zfc1 += "费用总额|" + sjzyb_out.AKC264 + "|";
            in_zfc1 += "政策内费用|" + sjzyb_out.CKAA56 + "|";
            in_zfc1 += "基本医保|";
            in_zfc1 += "统筹支付|" + sjzyb_out.AKC260 + "|";
            in_zfc1 += "提高待遇|" + sjzyb_out.CKAA20 + "|";
            in_zfc1 += "大病保险|";
            in_zfc1 += "统筹支付|" + sjzyb_out.AKC706 + "|";
            in_zfc1 += "提高待遇|" + sjzyb_out.CKAA27 + "|";
            in_zfc1 += "医疗救助|" + sjzyb_out.BKE151 + "|";
            in_zfc1 += "其他保障或补助|" + sjzyb_out.AKC708 + "|";
            in_zfc1 += "票据号|" + sjzyb_out.AAE072 + "|";
            in_zfc1 += "报销流水号|" + sjzyb_out.CKAA57 + "|";
            in_zfc1 += "本次报销合计|" + sjzyb_out.AKC780 + "|";
            in_zfc1 += "本次个人负担|";
            in_zfc1 += "小计|" + sjzyb_out.CKAA58 + "|";
            in_zfc1 += "政策内自付|" + sjzyb_out.AKC754 + "|";
            in_zfc1 += "政策外自费|" + sjzyb_out.AKC253 + "|";
            in_zfc1 += "是否享受三重保障|" + sjzyb_out.CKAA59 + "|";
            in_zfc1 += "审批：|";
            in_zfc1 += "复核：|";
            in_zfc1 += "|";
            in_zfc1 += "患者(家属)：|";
            in_zfc1 += "联系电话：|";
            in_zfc1 += "打印日期:" + Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy年MM月dd日");

            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("zycxjsdnew");
            MessageBox.Show("打印住院结算明细表成功！", "提示信息");
            #endregion
        }


        private void bxhj_MouseHover(object sender, EventArgs e)
        {
            label14.Visible = true;
        }

        private void bxhj_MouseLeave(object sender, EventArgs e)
        {
            label14.Visible = false;
        }





    }
}
