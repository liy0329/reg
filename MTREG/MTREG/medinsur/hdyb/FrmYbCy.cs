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
using MTREG.medinsur.hdyb.dor;
using MTREG.common;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.medinsur;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdyb.bo;
using System.Web.UI.WebControls;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmYbCy : Form
    {
        public FrmYbCy()
        {
            InitializeComponent();
        }

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
            initTpMge();
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
            cxfy();
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
                string sql_nhflag = "select nhflag,status from inhospital where id= " + ihsp_id;
                DataTable dt_nhflag = BllMain.Db.Select(sql_nhflag).Tables[0];
                this.lb_hiszt.Text = dt_nhflag.Rows[0]["status"].ToString().Trim();
                this.lb_ybzt.Text = dt_nhflag.Rows[0]["nhflag"].ToString().Trim();
                if (dt_nhflag.Rows.Count == 0)
                {
                    return;
                }
                if (dt_nhflag.Rows[0]["nhflag"].ToString().Trim() == "301")
                {
                    btn_jscd.Enabled = false;
                    btn_YbChScfy.Enabled = true;
                    btn_jsht.Enabled = false;
                    btn_ypqb.Enabled = true;
                    btn_sfbx.Enabled = true;
                    but_dtfysc.Enabled = true;
                    btn_yjs.Enabled = true;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = true;
                    btn_ypqbb.Enabled = true;
                    btn_fyqd.Enabled = true;
                    but_jybfdhje.Enabled = true;
                    btn_zfjsht.Enabled = false;
                    btn_zfjs.Enabled = false;
                    btn_jzxxxz.Enabled = true;
                }
                else if (dt_nhflag.Rows[0]["nhflag"].ToString().Trim() == "302")
                {
                    btn_jscd.Enabled = true;
                    btn_YbChScfy.Enabled = false;
                    btn_jsht.Enabled = true;
                    btn_ypqb.Enabled = false;
                    btn_sfbx.Enabled = true;
                    but_dtfysc.Enabled = false;
                    btn_yjs.Enabled = false;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = false;
                    btn_ypqbb.Enabled = false;
                    btn_fyqd.Enabled = true;
                    but_jybfdhje.Enabled = true;
                    btn_zfjsht.Enabled = true;
                    btn_zfjs.Enabled = true;
                    btn_jzxxxz.Enabled = false;
                }
                else
                {
                    btn_jscd.Enabled = false;
                    btn_YbChScfy.Enabled = false;
                    btn_jsht.Enabled = false;
                    btn_ypqb.Enabled = false;
                    btn_sfbx.Enabled = false;
                    but_dtfysc.Enabled = false;
                    btn_yjs.Enabled = false;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = false;
                    btn_ypqbb.Enabled = false;
                    btn_fyqd.Enabled = false;
                    but_jybfdhje.Enabled = false;
                    btn_zfjsht.Enabled = false;
                    btn_zfjs.Enabled = false;
                    btn_jzxxxz.Enabled = true;
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
            items.Add(new ListItem("困难企业住院", "26"));
            items.Add(new ListItem("年终结算", "28"));
            items.Add(new ListItem("年终结算后出院", "29"));
            items.Add(new ListItem("顺产", "51"));
            items.Add(new ListItem("剖腹产", "55"));
            this.combocyjsyllb.DisplayMember = "Text";
            this.combocyjsyllb.ValueMember = "Value";
            this.combocyjsyllb.DataSource = items;
        }
        /// <summary>
        /// 初始化界面信息
        /// </summary>
        private void initTpMge()
        {
            string sql = "select * from KC21 where AKC190= '" + zyh_ + "'";
            DataTable dt = jkdb.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string sql1 = "select inhospital.nhflag,inhospital.member_id,inhospital.sfck,inhospital.outdate as zyjlcysj,inhospital.bas_patienttype_id as zyjlylfkfs,sexList.name as sex from inhospital left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0 where inhospital.id=" + ihsp_id;
            DataTable dt_cysj = BllMain.Db.Select(sql1).Tables[0];
            this.btn_sfck.Text = (dt_cysj.Rows[0]["sfck"].ToString().Trim() == "1") ? ("有卡") : ("无卡");
            this.textBox1.Text = dt_cysj.Rows[0]["sex"].ToString().Trim();
            this.lbl_ylfkfs.Text = dt_cysj.Rows[0]["zyjlylfkfs"].ToString().Trim();
            string sql3 = "select inhospital.outdiagn as cyzd,bas_depart.name as ks,bas_doctor.name as ys from inhospital left join bas_doctor on inhospital.doctor_id=bas_doctor.id  left join bas_depart on inhospital.depart_id=bas_depart.id where inhospital.id = " + DataTool.addFieldBraces(ihsp_id) ;
            DataTable dt_cyjbmc = BllMain.Db.Select(sql3).Tables[0];
            string sql4 = "select diagnname as cyzd from ihsp_diagnmes where ihsp_id = " + DataTool.addFieldBraces(ihsp_id) + " and diagnKind ='OUT' and opkind ='MAIN'";
            DataTable dt_cyzd = BllMain.Db.Select(sql4).Tables[0];
            string cysj = dt_cysj.Rows[0]["zyjlcysj"].ToString().Trim();
            this.cyjsCyrq.Text = cysj;
            member_id = dt_cysj.Rows[0]["member_id"].ToString();
            this.cyjsZyh.Text = dt.Rows[0]["AKC190"].ToString().Trim();
            this.cyjsXm.Text = dt.Rows[0]["AAC003"].ToString().Trim();
            this.CyjsKs.Text = dt_cyjbmc.Rows[0]["ks"].ToString().Trim();//dt.Rows[0]["zkc272"].ToString().Trim();
            this.cyjsGrbh.Text = dt.Rows[0]["AAC001"].ToString().Trim();
            //医疗证号等同个人编号
            jmylzh_ = dt.Rows[0]["AAC001"].ToString().Trim();
            this.cyjsYs.Text = dt_cyjbmc.Rows[0]["ys"].ToString().Trim();
            this.cyjsRyrq.Text = dt.Rows[0]["AKC192"].ToString().Trim();
            if (dt_cyzd.Rows.Count > 0)
            {
                this.cyjsCyjb.Text = dt_cyzd.Rows[0]["cyzd"].ToString().Trim(); //dt.Rows[0]["zkc275"].ToString().Trim();
            }
            this.combocyjsyllb.SelectedValue = dt.Rows[0]["AKA130"].ToString().Trim();
            this.cyjsBfh.Text = dt.Rows[0]["Cka040"].ToString().Trim();
            this.tbx_bch.Text = dt.Rows[0]["Cka041"].ToString().Trim();
            string sumFeeSql = "select sum(fee) as sumAmt from ihsp_costdet where  ihsp_costdet.charged in('RREC','RET','CHAR') and ihsp_id= " + ihsp_id;
            DataTable temSum = BllMain.Db.Select(sumFeeSql).Tables[0];
            hisFeeLable.Text = temSum.Rows[0]["sumAmt"].ToString().Trim();//his费用
            ybfy(this.cyjsZyh.Text.Trim());//城乡费用
            this.fymxcount();
            return;
        }
        /// <summary>
        /// 医保费用
        /// </summary>
        /// <param name="zyh"></param>
        private void ybfy(string zyh)
        {
            string sql = "select sum(AKC227) from KC22 where AKC190='" + zyh + "' and  CKC126=1";

            DataTable dt = jkdb.Select(sql).Tables[0];
            string amt = dt.Rows[0][0].ToString().Trim();
            this.labelYb.Text = amt;
        }
        /// <summary>
        /// 上传情况
        /// </summary>
        private void fymxcount()
        {

            string count1 = "select count(id) as zhs from ihsp_costdet where ihsp_id = " + ihsp_id;//_iid.ToString().Trim();
            string count2 = "select count(id) as yschs from ihsp_costdet where insursync = 'Y' and ihsp_id = " + ihsp_id;//+ _iid.ToString().Trim();
            string count3 = "select count(id) as syhs from ihsp_costdet where insursync ='N' and ihsp_id = " + ihsp_id;//_iid.ToString().Trim();


            DataTable dt_count1 = BllMain.Db.Select(count1).Tables[0];
            DataTable dt_count2 = BllMain.Db.Select(count2).Tables[0];
            DataTable dt_count3 = BllMain.Db.Select(count3).Tables[0];
            this.label_zg.Text = dt_count1.Rows[0]["zhs"].ToString().Trim();//总共
            this.label_sc.Text = dt_count2.Rows[0]["yschs"].ToString().Trim();//已上传
            this.label_sy.Text = dt_count3.Rows[0]["syhs"].ToString().Trim();//未上传

            string sql = "select count(*) as ysx_sc from KC22 where AKC190='" + zyh_ + "' and  CKC126=1";
            DataTable dt = jkdb.Select(sql).Tables[0];
            string ysx_sc = dt.Rows[0]["ysx_sc"].ToString().Trim();
            this.label_ysx.Text = ysx_sc;//已生效

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
            string sql1 = "select inhospital.ihspcode as 住院号,ihsp_costdet.ypspbz as 药品审核,ihsp_costdet.yptsxx AS 药品提示信息,ihsp_costdet.ybxfdhje AS 负担后金额,ihsp_costdet.name as 项目名称,ihsp_costdet.prc as 单价"
                        + ",ihsp_costdet.num AS 数量,ihsp_costdet.fee AS 金额,ihsp_costdet.itemfrom AS 项目类别,ihsp_costdet.yblx AS 费用等级"
                        + ",(select standcode from bas_item where ihsp_costdet.item_id=bas_item.id) as 医保编码,ihsp_costdet.ihsp_advdet_id AS 处方号"
                        + ",ihsp_costdet.costexdate AS 创建日期,ihsp_costdet.costexdate AS 开方日期, ihsp_costdet.insursync AS 是否上传"
                        + ",ihsp_costdet.item_id as prodiid,ihsp_costdet.id from ihsp_costdet,inhospital where inhospital.id=ihsp_costdet.ihsp_id and charged in ('RET','RREC','CHAR') and inhospital.id=" + ihsp_id + " order by yptsxx desc";
            DataTable dtTmp = BllMain.Db.Select(sql1).Tables[0];
            if (dtTmp.Rows.Count == 0)
            {
                return;
            }
            this.dataGridView2.DataSource = dtTmp.DefaultView;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                if (dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "N" || dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "")
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未上传黄色
                if ((dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "") || (dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "0"))
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;//无编码红色
                if ((dataGridView2.Rows[i].Cells["药品提示信息"].Value.ToString() != "") && (!((dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "1") || (dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "2"))))
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;//限制性青色
            }
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from inhospital where id = " + ihsp_id;
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "301")
                return;
            //if (Tool.IsUpload == true)
            //{
            //    string sqlfyxx = "select iid from mtzyjlstuff where ybsc = 0 and mtzyjl = " + mtzyjl_iid;

            //    DataTable dtxx = hisdb.Select(sqlfyxx).Tables[0];
            //    if (dtxx.Rows.Count > 0)
            //    {
            //        MessageBox.Show("后台正在自动上传费用,稍后再预结算！", "提示信息");
            //        return;
            //    }
            //}
            string ybjk_sql_delete = " delete from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "' and  CKC126=0";
            jkdb.Update(ybjk_sql_delete);
            string ybjk_sql = "select AKC220 from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "'";

            DataTable dt = jkdb.Select(ybjk_sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N' where ihsp_id=" + this.ihsp_id + " and id not in (";
                string iid_sqls = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iid_sqls += dt.Rows[i]["AKC220"].ToString() + ",";
                }
                iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
                his_sql_update += iid_sqls + ")";

                BllMain.Db.Update(his_sql_update);
            }
            else
            {
                string his_sql_update = "update ihsp_costdet set insursync='N' where ihsp_id='" + this.ihsp_id + "'";
                int ac = BllMain.Db.Update(his_sql_update);
            }
            Zyybfysc ybfysc = new Zyybfysc();
            RetMsg ret = ybfysc.ybscfymx(int.Parse(ihsp_id),ylkfkfs, cyjsGrbh.Text.Trim(), this.cyjsZyh.Text.Trim(), lblFeeUpLoad);
            string msg_ybxfdhjebz = "";
           // ybfysc.xfdhje(int.Parse(ihsp_id), this.cyjsZyh.Text.Trim(), out msg_ybxfdhjebz);
            cxfy();
            this.fymxcount();
            this.ybfy(this.cyjsZyh.Text.Trim());
            if (!string.IsNullOrEmpty(msg_ybxfdhjebz))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = "上传费用情况如下：【住院号：" + this.cyjsZyh.Text.Trim() + "-" + ret.Mesg + msg_ybxfdhjebz + "】";
                frmmesg.ShowDialog(this);
            }
            lblFeeUpLoad.Text = "上传费用成功！";
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
            if (int.Parse(label_ysx.Text) < 1)
            {
                MessageBox.Show("请先上传费用！");
                return;
            }
            lblFeeUpLoad.Text = "正在预结算..........";
            lblFeeUpLoad.Update();
            string zyh = this.cyjsZyh.Text;
            string yllb = this.combocyjsyllb.SelectedValue.ToString().Trim();
            string grbh = this.cyjsGrbh.Text;
            //出院登记
            if (cydj() != 1)
            {
                lblFeeUpLoad.Text = "更新kc21失败！！";
                return;
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            string sql_gxsfck = "select status,nhflag,sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_ryjbxxhzh.Hisjl = zyh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[17] == "出院已结算")
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("此人目前为出院状态，不能再做出院结算操作！", "提示信息");
                return;
            }

            //帐户余额
            string lnjz_s = ryjbxxhzh_cc[50];//历年结转
            double lnjz = 0;
            if (lnjz_s != null && lnjz_s != "")
                lnjz = double.Parse(lnjz_s);

            string bnzr_s = ryjbxxhzh_cc[51];//本年注入
            double bnzr = 0;
            if (bnzr_s != null && bnzr_s != "")
                bnzr = double.Parse(bnzr_s);

            string zhzc_s = ryjbxxhzh_cc[55]; //帐户支出
            double zhzc = 0;
            if (zhzc_s != null && zhzc_s != "")
                zhzc = double.Parse(zhzc_s);

            this.cyjsZhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();

            //读人员是否封锁
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ryfsxx.Ylzh = "0";
            }
            else
            {
                yw_in_ryfsxx.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_ryfsxx.Hisjl = zyh;
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }

            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');

            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    lblFeeUpLoad.Text = "此卡处于半封锁状态";
                    return;
                }
            }
            if (fsjb == 2)
            {
                lblFeeUpLoad.Text = "此卡已经被封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            //预结算
            YBCJ_IN yw_in_zyyjs = new YBCJ_IN();
            yw_in_zyyjs.Yw = "BC311003";
            yw_in_zyyjs.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_zyyjs.Ylzh = "0";
            }
            else
            {
                yw_in_zyyjs.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_zyyjs.Hisjl = zyh;
            //个人编号 门诊住院号，医疗类别，单据号，经办人，帐户支付金额
            yw_in_zyyjs.Rc = grbh + "|" + zyh + "|" + yllb + "|" + zyh + "|" + ProgramGlobal.Username + "|0|0";
            int opt_zyyjs = yw1.ybcjhs(yw_in_zyyjs);
            if (opt_zyyjs != 0)
            {
                lblFeeUpLoad.Text = "预结算失败";
                MessageBox.Show(yw_in_zyyjs.Mesg, "提示信息");
                return;
            }
            string[] zyyjs_cc = yw_in_zyyjs.Cc.Split('|');
            this.cyjsFyzje.Text = zyyjs_cc[0];
            this.cyjsTczfje.Text = zyyjs_cc[15];
            this.cyjsXjygzf.Text = zyyjs_cc[16];
            this.cyjsZhzf.Text = zyyjs_cc[14];
            this.tbx_qfx.Text = zyyjs_cc[19];
            this.tbx_gwyjjzf.Text = zyyjs_cc[17];
            this.tbx_bcdbzfje.Text = zyyjs_cc[23];

            this.fymxcount();
            this.ybfy(zyh);
            MessageBox.Show("预结算成功，返回帐户支付金额，下一步请点结算按钮！");
            //-判断自费是否结算，如果未结算，不允许医保结算
            if (billIhspAct.isHisAccount(ihsp_id))
            {
                this.btn_js.Enabled = true;
            }
            else
            {
                this.btn_js.Enabled = false;
                MessageBox.Show("该病人自费未结算，不能医保结算");
            }
            
            this.cyjsXjsjzf.Text = this.cyjsXjygzf.Text.Trim();
            String bcxjyzf = this.cyjsXjsjzf.Text;
            if (bcxjyzf != null && bcxjyzf != "")
            {
                if (this.yjkzfy.Text.Trim() == "" || this.yjkzfy.Text.Trim() == null)
                {
                    this.tbx_thbxj.Text = (0 - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
                }
                else
                {
                    this.tbx_thbxj.Text = (double.Parse(this.yjkzfy.Text) - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
                }
            }
            lblFeeUpLoad.Text = "预结算成功";
            cxfy();
            string fhxx = "";
            try
            {
                string sql_hdybcc = "select * from hdybcc where xh=11";
                DataTable dt_hdybcc = BllMain.Db.Select(sql_hdybcc).Tables[0];
                string[] retdata_hdybcc = dt_hdybcc.Rows[0]["ywccyb"].ToString().Split('|');
                for (int j = 0; j < zyyjs_cc.Length; j++)
                {
                    string hdybcc_hy = "";
                    if (retdata_hdybcc.Length > j)
                    {
                        hdybcc_hy = retdata_hdybcc[j];
                    }
                    fhxx += "<" + (j + 1) + ">-" + hdybcc_hy + "：" + zyyjs_cc[j] + "\r\n";
                }
                this.Tbx_tsxx.Text = fhxx;
            }
            catch
            {
                this.Tbx_tsxx.Text = fhxx;
            }
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
            this.cyjsXjsjzf.Text = "";
            this.cyjsZhzf.Text = "";
            this.tbx_thbxj.Text = "";
            this.tbx_qfx.Text = "";
            this.Tbx_tsxx.Text = "";
        }
        private int cydj()
        {
            //修改kc21
            string zyh = this.cyjsZyh.Text;
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
            string cyjb = this.cyjsCyjb.Text;
            string ys = this.cyjsYs.Text;
            string ks = this.CyjsKs.Text;

            if (cyrq == null || cyrq == "")
            {
                MessageBox.Show("出院日期不能为空，请输入出院日期，格式为'yyyy-MM-dd'!", "提示信息");
                this.cyjsCyrq.Focus();
                return 0;
            }
            if (cyjb.Length > 7)
            {
                cyjb = cyjb.Substring(0, 7);
            }

            string sql = "update KC21 set AKC194='" + cyrq + "', AKC195='" + cyyy + "',AKC196='" + cyjb + "',zkc271='" + ys + "',zkc272='" + ks + "' where AKC190='" + zyh + "'";
            if (jkdb.Update(sql) == -1)
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
            string sql_gxsfck = "select sfck,status,outcondition from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
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
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                djh = this.fphtext.Text.Trim();
                //if (ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "OO" || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == null || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "")
                if (!ds_sfck.Tables[0].Rows[0]["status"].ToString().Equals("SETT"))
                {
                    lblFeeUpLoad.Text = "";
                    MessageBox.Show("His系统没有结算，不允许城乡结算！");
                    return;
                }
            }
            else
            {
                String[] getfph = new String[1];
                if (ds_sfck.Tables[0].Rows[0]["status"].ToString() != "SIGN")
                {
                    lblFeeUpLoad.Text = "";
                    MessageBox.Show("此患者未挂账，请挂账之后再进行结算!");
                    return;
                }
                if (string.IsNullOrEmpty(djh))
                {
                    MessageBox.Show("发票号为空,请领取发票!");
                    return;
                }
            }
            //结算
            YBCJ_IN yw_in_zyjs = new YBCJ_IN();
            yw_in_zyjs.Yw = "CC311003";
            yw_in_zyjs.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_zyjs.Ylzh = "0";
            }
            else
            {
                yw_in_zyjs.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_zyjs.Hisjl = zyh;
            //个人编号 门诊住院号，医疗类别，单据号，经办人，帐户支付金额
            yw_in_zyjs.Rc = grbh + "|" + zyh + "|" + yllb + "|" + djh + "|" + ProgramGlobal.Username + "|0|" + this.cyjsZhzf.Text.Trim();
            if (yllb == "29")
            {
                string sql_8 = "update KC22 SET AAE072='" + djh + "' WHERE AKC190 ='" + zyh + "' and  AAE072 ='" + zyh + "';";
                sql_8 += "UPDATE KC21 SET AKA130='" + yllb + "'  where  AKC190 ='" + zyh + "' and AKA130='28'";
                jkdb.Update(sql_8);
            }
            else
            {
                int row = this.up_kc22_djh(djh/*ksyksfph*/, zyh);
                string sql_9 = "UPDATE KC21 SET AKA130='" + yllb + "' where  AKC190 ='" + zyh + "'";
                jkdb.Update(sql_9);
                if (row <= 0)
                {
                    MessageBox.Show("结算前修改单据号错误！", "提示信息");
                    return;
                }
            }
            int opt_zyjs = yw1.ybcjhs(yw_in_zyjs);
            if (opt_zyjs != 0)
            {
                if ("29" == yllb)
                {
                    string sql_8 = "update KC22 SET AAE072='" + zyh + "' WHERE AKC190 ='" + zyh + "' and  AAE072 ='" + djh + "';";
                    sql_8 += "UPDATE KC21 set AKA130= '28'  where  AKC190 = '" + zyh + "' and AKA130='29'";
                    jkdb.Update(sql_8);
                }
                else
                {
                    string sql_8 = "update KC22 set AAE072='" + zyh + "' where AKC190='" + zyh + "';";
                    sql_8 += "UPDATE KC21 set AKA130='" + yllb + "'  where  AKC190 = '" + zyh + "'";
                    jkdb.Update(sql_8);
                }
                MessageBox.Show(yw_in_zyjs.Mesg, "提示信息");
                return;
            }
            string[] zyjs_cc = yw_in_zyjs.Cc.Split('|');
            string _iid = ihsp_id;
            string insetyb = "delete from zlsyb_zyinfo where mzzyjliid = " + _iid + ";"
                             + "insert into zlsyb_zyinfo(mzzyjliid,ybgrbh,fph,jbr,jssj,yllb,yyzfy,ybzfy,zyh,"
                             + "jsqzhye,jshzhye,bctczfje,bcxjzfje,bczhzfje,hzname,qfybch,gwyjjzf,bcdbzfje,jswzsczfc) "
                             + "values ('"
                             + _iid + "','"//1
                             + grbh + "','"//2
                             + djh + "','"//3
                             + ProgramGlobal.Username + "','"//4
                             + BillSysBase.currDate() + "','"//5
                             + yllb + "','"//6
                             + this.hisFeeLable.Text.Trim() + "','"//7
                             + zyjs_cc[0] + "','"//8
                             + zyh + "','"//9
                             + cyjsZhye.Text.Trim() + "','"//10
                             + zyjs_cc[18] + "','"//11
                             + zyjs_cc[15] + "','"//12
                             + zyjs_cc[16] + "','"//13
                             + zyjs_cc[14] + "','"//14
                             + cyjsXm.Text.Trim() + "','"//15
                             + "1" + "','"
                             + zyjs_cc[17] + "','"
                             + zyjs_cc[23] + "','"
                             + yw_in_zyjs.Cc + "'); ";
            //是否先结后报
            string isxjhb = Ini.IniReadValue2("pz", "ISXJHB");
            if (isxjhb == "0")
            {
                if (actMethod() < 0)
                {
                    MessageBox.Show("医保结算成功，his结算失败");
                    return;
                }
            }
            else
            {
                string sql_upaccount = "UPDATE ihsp_account SET insurefee = '" + (Convert.ToDouble(cyjsTczfje.Text.Trim()) + Convert.ToDouble(tbx_bcdbzfje.Text.Trim()) + Convert.ToDouble(tbx_gwyjjzf.Text.Trim())).ToString() +"', insuraccountfee = '" + cyjsZhzf.Text.Trim().ToString() + "'  WHERE ihsp_id = " + _iid.ToString();
                BllMain.Db.Update(sql_upaccount);
            }
            StringBuilder message = new StringBuilder();
            if (BllMain.Db.Update(insetyb) == -1)
            {
                SysWriteLogs.writeLogs1("市医保结算更新his错误信息", DateTime.Now, "sql=" + insetyb);
                MessageBox.Show("医保结算成功，更新his失败！" + message);
                return;
            }
            //修改his系统nhflag标志
            string settinsurdate = BillSysBase.currDate();//获取当前时间
            if (yllb == "28")
            {
                string sql2 = "update inhospital set nhflag=302, nh_fph='" + djh + "'  where id=" + _iid.ToString() + "; ";
                sql2 += " update inhospital set yllb = '28' " + ",settInsurdate='" + settinsurdate + "' where zyjlzyh = '" + zyh + "';";//增加报销时间的更新 2019_3_21 czh
                BllMain.Db.Update(sql2);
                MessageBox.Show("年终结算成功！");
            }
            else
            {
                string sql2 = "update inhospital set nhflag=302,nh_fph='" + djh + "' , yllb = '" + yllb + "',settInsurdate='" + settinsurdate + "'  where id=" + _iid.ToString().Trim();//增加报销时间的更新 2019_3_21 czh
                BllMain.Db.Update(sql2);
                MessageBox.Show("出院结算成功！");
            }
            initButton();
            string mes = "需要打印发票吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            this.dyfp(grbh, zyh, ihsp_id);
        }
        public void dyfp(string strGrbh, string strZyh, string strZyjlid)
        {
            if (string.IsNullOrEmpty(strGrbh) || string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strZyjlid))
            {
                MessageBox.Show("发票参数获取失败!");
                return;
            }
            //结算打印
            YBCJ_IN yw_in_zyjsddy = new YBCJ_IN();
            yw_in_zyjsddy.Yw = "BB310003";
            yw_in_zyjsddy.Ybcjbz = "0";
            string sql_gxsfck = "select yllb,sfck,nhflag from inhospital where id='" + strZyjlid + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_zyjsddy.Ylzh = "0";
            }
            else
            {
                yw_in_zyjsddy.Ylzh = strGrbh;
            }
            string sql_cxybfph = "select fph,jssj,yllb from zlsyb_zyinfo where mzzyjliid=" + strZyjlid + ";";
            DataSet ds_ybfph = BllMain.Db.Select(sql_cxybfph);
            if (ds_ybfph.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("没有在‘zlsyb_zyinfo’表里找到此人结算信息！", "提示信息");
                return;
            }
            yw_in_zyjsddy.Hisjl = strZyh;
            //个人编号|门诊住院号|单据号|经办人
            yw_in_zyjsddy.Rc = strGrbh + "|" + strZyh + "|" + ds_ybfph.Tables[0].Rows[0]["fph"].ToString().Trim() + "|" + ProgramGlobal.Username;
            int opt_zyjsddy = yw1.ybcjhs(yw_in_zyjsddy);
            if (opt_zyjsddy != 0)
            {
                MessageBox.Show(yw_in_zyjsddy.Mesg, "提示信息");
                return;
            }
            string sql_insert_zyjsdy = "update zlsyb_zyinfo set zyjsdyzfc='" + yw_in_zyjsddy.Cc + "' where mzzyjliid='" + strZyjlid + "'";
            BllMain.Db.Update(sql_insert_zyjsdy);
            string[] zyjsddy_cc = yw_in_zyjsddy.Cc.Split('|');
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

            DataTable datafpdy = zydyfp(strZyjlid);
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
            DataTable Dygrxx = GetDygrxx(strZyjlid);
            hj = Math.Round(hj, 2);
            if (hj != DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()))
            {
                MessageBox.Show("项目类型之和【" + hj.ToString() + "】与病人费用总和【" + Dygrxx.Rows[0]["amt"].ToString() + "】不等！");
                //return;
            }
            #endregion
            string in_zfc1 = "|";
            in_zfc1 += zyjsddy_cc[3] + "|";//定点医院名称
            in_zfc1 += "|";
            in_zfc1 += zyjsddy_cc[4] + "|";//科室
            in_zfc1 += zyjsddy_cc[2] + "|";//单据号
            in_zfc1 += zyjsddy_cc[1] + "|";//医院住院号
            in_zfc1 += zyjsddy_cc[8].Substring(0, 4) + "|" + zyjsddy_cc[8].Substring(4, 2) + "|" + zyjsddy_cc[8].Substring(6, 2) + "|";//入院日期
            in_zfc1 += zyjsddy_cc[9].Substring(0, 4) + "|" + zyjsddy_cc[9].Substring(4, 2) + "|" + zyjsddy_cc[9].Substring(6, 2) + "|";//出院日期
            in_zfc1 += zyjsddy_cc[10] + "|";//住院天数
            in_zfc1 += zyjsddy_cc[6] + "|";//患者姓名
            in_zfc1 += Dygrxx.Rows[0]["xb"].ToString().Trim() + "|";//患者性别
            in_zfc1 += "职工医保|";
            in_zfc1 += zyjsddy_cc[11] + "|";//个人编号
            in_zfc1 += "床位费|" + cwf.ToString("0.00") + "|医保|护理费|" + hlf.ToString("0.00") + "|医保|诊查费|" + zcf.ToString("0.00") + "|医保|";
            in_zfc1 += "卫生材料费|" + wsclf.ToString("0.00") + "|医保|检查费|" + jcf.ToString("0.00") + "|医保|药品费|" + ypf.ToString("0.00") + "|医保|";
            in_zfc1 += "化验费|" + hyf.ToString("0.00") + "|医保|药事服务费|" + ysfwf.ToString("0.00") + "|医保|治疗费|" + zlf.ToString("0.00") + "|医保|";
            in_zfc1 += "一般诊疗费|" + ybzlf.ToString("0.00") + "|医保|手术费|" + ssf.ToString("0.00") + "|医保|其他住院费用|" + qtzyfy.ToString("0.00") + "|医保|输血费|" + sxf.ToString("0.00") + "|医保|";
            money n = new money(DataTool.Getdouble(zyjsddy_cc[28]));//费用合计-大写
            in_zfc1 += n.Convert() + "|";//合计大写
            in_zfc1 += zyjsddy_cc[28] + "|";//合计
            string sql_amt = "select COALESCE( sum(payfee),0) as sum from ihsp_payinadv where ihsp_id='" + ihsp_id + "'";
            DataTable dt_amt = BllMain.Db.Select(sql_amt).Tables[0];
            double amt_yj = 0;
            double amt_bj = 0;
            double amt_tf = 0;
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
            amt_tf = amt_yj - DataTool.Getdouble(zyjsddy_cc[52]);
            if (amt_tf < 0)
            {
                amt_bj = -amt_tf;
                amt_tf = 0;
            }
            in_zfc1 += amt_bj.ToString("0.00") + "|";//补缴金额
            in_zfc1 += amt_tf.ToString("0.00") + "|";//退费金额
            in_zfc1 += (DataTool.Getdouble(zyjsddy_cc[28]) - DataTool.Getdouble(zyjsddy_cc[52])).ToString() + "|";//医院垫支----（医院总费用-现金支付金额）
            in_zfc1 += zyjsddy_cc[41] + "|";//医保统筹支付
            in_zfc1 += zyjsddy_cc[50] + "|";//个人账户支付
            in_zfc1 += zyjsddy_cc[68] + "|";//个人自付
            in_zfc1 += zyjsddy_cc[69] + "|";//个人自费
            in_zfc1 += zyjsddy_cc[51] + "|";//个人账户余额
            in_zfc1 += zyjsddy_cc[42] + "|";//统筹累计支付
            in_zfc1 += "大病支付:" + zyjsddy_cc[44] + "|";
            in_zfc1 += "大病累计支付:" + zyjsddy_cc[45] + "|";
            in_zfc1 += "进入统筹金额:" + zyjsddy_cc[40] + "|";
            in_zfc1 += "公务员支付:" + zyjsddy_cc[47] + "|";
            in_zfc1 += "报销总额:" + zyjsddy_cc[66] + "|";//报销总额
            in_zfc1 += "起付线:" + zyjsddy_cc[38] + "|";
            in_zfc1 += "住院次数:" + zyjsddy_cc[5] + "|";
            in_zfc1 += "医保中心名称:" + zyjsddy_cc[0] + "|";
            in_zfc1 += zyjsddy_cc[55] + "|";//经办人
            in_zfc1 += zyjsddy_cc[56].Substring(0, 4) + "|" + zyjsddy_cc[56].Substring(4, 2) + "|" + zyjsddy_cc[56].Substring(6, 2) + "|"; ;//结算日期
            if (ds_ybfph.Tables[0].Rows[0]["yllb"].ToString().Trim() == "28")
            {
                in_zfc1 += "年终结算|";
            }
            else if (ds_ybfph.Tables[0].Rows[0]["yllb"].ToString().Trim() == "29")
            {
                in_zfc1 += "年终结算后出院|";
            }
            in_zfc1 += "";
            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("zyyb");
            #endregion
        }
        public DataTable zydyfp(String mtzyjl_iid)
        {
            //String sql = "select insur_itemfrom.name as xmlb,sum(fee) as amt from insur_itemfrom,ihsp_costdet where ihsp_costdet.ihsp_id=" + mtzyjl_iid + " and ihsp_costdet.itemtype_id=insur_itemfrom.itemtype_id  GROUP BY xmlb ";
            String sql = " select insur_itemfrom.name as xmlb,sum(fee ) as amt"
                       + " from ihsp_costdet left join insur_itemfrom on insur_itemfrom.itemtype_id = ihsp_costdet.itemtype_id AND insur_itemfrom.cost_insurtype_id = 6 "
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
        public int actMethod()
        {
            string hisOrderNo = "";
            List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();
            ihspaccount.Id = BillSysBase.nextId("ihsp_account");
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
            ihspaccount.Insurefee = (Convert.ToDouble(cyjsTczfje.Text.Trim()) + Convert.ToDouble(tbx_bcdbzfje.Text.Trim()) + Convert.ToDouble(tbx_gwyjjzf.Text.Trim())).ToString();
            ihspaccount.Selffee = cyjsZhzf.Text.Trim().ToString();

            IhspInvoicedet ihspInvoicedet = new IhspInvoicedet();
            ihspInvoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet.PaytypeId = cbx_fklx.SelectedValue.ToString();
            ihspInvoicedet.PaysumbyId = billIhspAct.getPaysumby(cbx_fklx.SelectedValue.ToString());
            ihspInvoicedet.Payfee = ihspaccount.Balanceamt;
            invoicedets.Clear();
            invoicedets.Add(ihspInvoicedet);

            string account_sql = "";
            account_sql = billIhspAct.doAccount(ihspaccount, invoicedets, "selfcost");
            if (-1 == billIhspMan.doExeSql(account_sql))//结算
            {

                return -1;
            }
            return 0;
        }

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
            YBCJ_IN yw_in_scfy = new YBCJ_IN();
            yw_in_scfy.Yw = "BB310000";
            yw_in_scfy.Ybcjbz = "0";
            string sql_gxsfck = "select sfck,nhflag from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_scfy.Ylzh = "0";
            }
            else
            {
                yw_in_scfy.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_scfy.Hisjl = zyhTmp;
            yw_in_scfy.Rc = zyhTmp + "|" + zyhTmp;
            int opt_scfy = yw1.ybcjhs(yw_in_scfy);
            if (opt_scfy != 0)
            {
                MessageBox.Show(yw_in_scfy.Mesg, "提示信息");
                return;
            }
            //删除kc22数据
            this.del_kc22_zyh(zyhTmp);
            string sql_scfy = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + ihsp_id;
            BllMain.Db.Update(sql_scfy);
            cxfy();
            this.fymxcount();
            this.ybfy(this.cyjsZyh.Text.Trim());
            MessageBox.Show("删除费用成功！");
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
            if (string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strYllb) || string.IsNullOrEmpty(strZyjlId) || string.IsNullOrEmpty(strGrbh))
            {
                MessageBox.Show("获取结算回退参数失败!!!");
                return;
            }
            string sql1 = "select ihsp_account.id from ihsp_account,inhospital where  ihsp_account.ihsp_id = inhospital.id and inhospital.id=" + strZyjlId;
            string account_id = BllMain.Db.Select(sql1).Tables[0].ToString();
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
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            string sql_gxsfck = "select sfck,nhflag from inhospital where id='" + strZyjlId + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = strGrbh;
            }
            yw_in_ryjbxxhzh.Hisjl = strZyh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行结算回退操作！", "提示信息");
                return;
            }
            string djh = "";
            //查询KC22的AAE072 单据号
            if ("29" == strYllb)
            {
                string newdjh = "select fph from zlsyb_zyinfo where mzzyjliid=" + strZyjlId;
                DataTable dd = BllMain.Db.Select(newdjh).Tables[0];
                djh = dd.Rows[0]["fph"].ToString().Trim();

            }
            else
            {
                string sql_djh = "select AAE072 from KC22 where AKC190='" + strZyh + "'";
                DataTable dt = jkdb.Select(sql_djh).Tables[0];
                djh = dt.Rows[0]["AAE072"].ToString().Trim();
            }
            //结算回退
            YBCJ_IN yw_in_zyjsht = new YBCJ_IN();
            yw_in_zyjsht.Yw = "DC311003";
            yw_in_zyjsht.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_zyjsht.Ylzh = "0";
            }
            else
            {
                yw_in_zyjsht.Ylzh = strGrbh;
            }
            yw_in_zyjsht.Hisjl = strZyh;
            yw_in_zyjsht.Rc = strGrbh + "|" + strZyh + "|" + djh + "|" + ProgramGlobal.Username;
            int opt_zyjsht = yw1.ybcjhs(yw_in_zyjsht);
            if (opt_zyjsht != 0)
            {
                MessageBox.Show(yw_in_zyjsht.Mesg, "提示信息");
                return;
            }

            //修改kc22传输标志，置为0
            this.upcsbz_Kc22_JK0(strZyh, djh, strYllb);
            string sql2 = "";
            if (strYllb == "29")
            {
                sql2 += "UPDATE KC21 set AKA130= '28'  where  AKC190 = '" + strZyh + "' and AKA130='29'";
                jkdb.Update(sql2);
                string sql23 = "delete from kc22 where AKC190='" + strZyh + "' and AAE072 ='" + djh + "'";
                jkdb.Update(sql23);
                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0  where ihsp_id=" + strZyjlId;
                BllMain.Db.Update(his_sql_update_ht);
                //修改his医保标志
                string sql = "update inhospital set nhflag=301,yllb = '28',settInsurdate=null where id=" + strZyjlId;//_iid.ToString().Trim(); //2019_3_21增加更新医保报销时间为空  czh
                BllMain.Db.Update(sql);
            }
            else
            {
                sql2 = "delete from kc22 where AKC190='" + strZyh + "' and AAE072 ='" + djh + "'";
                jkdb.Update(sql2);
                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0 where ihsp_id=" + strZyjlId;//
                BllMain.Db.Update(his_sql_update_ht);
                string sql = "update inhospital set nhflag=301,settInsurdate=null  where id=" + strZyjlId;//_iid.ToString().Trim(); //2019_3_21增加更新医保报销时间为空 czh
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
            string sqll = "select ihsp_account_id from ihsp_costdet where ihsp_id="+ihsp_id;
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
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
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
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
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
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
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

        private void btn_sfck_Click(object sender, EventArgs e)
        {
            if (this.btn_sfck.Text.Trim() == "有卡")
            {
                BllMain.Db.Update("update inhospital set sfck=0 where id=" + this.ihsp_id);
                this.btn_sfck.Text = "无卡";
            }
            else
            {
                BllMain.Db.Update("update inhospital set sfck=1 where id=" + this.ihsp_id);
                this.btn_sfck.Text = "有卡";
            }
        }

        private void but_jybfdhje_Click(object sender, EventArgs e)
        {
            lblFeeUpLoad.Text = "";
            string update_sql = "update ihsp_costdet set ybxfdhjebz=0 where ihsp_id=" + ihsp_id + ";";
            BllMain.Db.Update(update_sql);
            //先负担后金额
            Zyybfysc ybfysc = new Zyybfysc();
            string msg_ybxfdhjebz = "";
            //ybfysc.xfdhje(int.Parse(ihsp_id), this.cyjsZyh.Text.Trim(), out msg_ybxfdhjebz);
            if (!string.IsNullOrEmpty(msg_ybxfdhjebz))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = msg_ybxfdhjebz;
                frmmesg.ShowDialog(this);
            }
            MessageBox.Show("获取先负担后金额完成!");
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                ybzjkfymx();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                string sqlitem = "select ihsp_costdet.ihsp_id as Mtzyjl,ihsp_costdet.itemfrom AS Xmlb,bas_item.name AS xmmc,bas_item.standcode as Ybbm,ihsp_costdet.yblx AS Yblx"
                               + ",ihsp_costdet.spec as Guige,ihsp_costdet.unit as Uom,ihsp_costdet.prc as Prc,sum(ihsp_costdet.num) as Qty,sum(ihsp_costdet.fee) as Amt"
                               + ",sum(ihsp_costdet.ybxfdhje) as xfdhje,bas_item.id as mtprod "
                               + " from bas_item,ihsp_costdet where ihsp_costdet.item_id=bas_item.id and ihsp_costdet.ihsp_id=" + ihsp_id + " "
                               + " and ihsp_costdet.charged in('CHAR','RET','RREC') "
                               + " GROUP BY ihsp_costdet.ihsp_id,ihsp_costdet.itemfrom,bas_item.hiscode,ihsp_costdet.insurclass,ihsp_costdet.spec,ihsp_costdet.unit,bas_item.id";

                dataGridView3.DataSource = BllMain.Db.Select(sqlitem).Tables[0];
                double zjehj = 0;
                double xfdhjehj = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "") || (dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "0"))
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;//
                    zjehj += double.Parse(dataGridView3.Rows[i].Cells["xmje"].Value.ToString());
                    string xfdhje5 = dataGridView3.Rows[i].Cells["xfdhje"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(xfdhje5))
                    {
                        xfdhjehj += double.Parse(xfdhje5);
                    }
                }
                this.lbl_zje.Text = zjehj.ToString("0.00");
                this.lbl_xfdhje.Text = xfdhjehj.ToString("0.00");
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                cxfy();
            }
        }
        /// <summary>
        /// 中间库费用
        /// </summary>
        private void ybzjkfymx()
        {
            string sql = "select  CKC126 AS yb_sfsc,AKC190 AS 住院号,AKC224 AS 类别,AKC220 AS 处方号,AAE072 AS 单据号,AKC223 AS 名称,ZKA100 as 规格,ZKA101 as 单位,AKC225 as 单价,AKC226 as 数量,AKC227 as 金额,AKA065 as 等级,AKC515 as 编码,AKC221 as 处方日期 from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "' order by AKC515 desc";
            dataGridView1.DataSource = jkdb.Select(sql).Tables[0];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["类别"].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Cells["类别"].Value = "药品";
                }
                else if (dataGridView1.Rows[i].Cells["类别"].Value.ToString() == "2")
                {
                    dataGridView1.Rows[i].Cells["类别"].Value = "诊疗";
                }
                else if (dataGridView1.Rows[i].Cells["类别"].Value.ToString() == "3")
                {
                    dataGridView1.Rows[i].Cells["类别"].Value = "床位";
                }
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            { return; }

            string mtzyjlstuffiid = dataGridView2.CurrentRow.Cells["id"].Value.ToString().Trim();
            string xmmc = dataGridView2.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
            string fydj = dataGridView2.CurrentRow.Cells["费用等级"].Value.ToString().Trim();
            string hism = dataGridView2.CurrentRow.Cells["prodiid"].Value.ToString().Trim();
            string xmbmsql = " select hiscode as xmbm from bas_item where id = " + hism + " ";
            DataTable dt = BllMain.Db.Select(xmbmsql).Tables[0];
            string xmbm = dt.Rows[0]["xmbm"].ToString().Trim();
            FrmXgjyb jyb = new FrmXgjyb();
            jyb.Hzmc = this.cyjsXm.Text.Trim();
            jyb.Xmmc = xmmc;
            jyb.Jyb = fydj;
            jyb.Xmbm = xmbm;
            jyb.Xzxyysm = dataGridView2.CurrentRow.Cells["药品提示信息"].Value.ToString().Trim();
            jyb.StartPosition = FormStartPosition.CenterScreen;
            jyb.ShowDialog();
            if (jyb.Flag == false)
            {
                return;
            }
            string updateyblx = "update ihsp_costdet set ypspbz='" + jyb.Xzxyysfkb + "', yblx = '" + jyb.Jyb + "' where insursync='N' and ihsp_id = " + ihsp_id + " and id = " + mtzyjlstuffiid;
            BllMain.Db.Update(updateyblx);
            this.cxfy();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["iid"].Value.ToString() == mtzyjlstuffiid)
                {
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["项目名称"];
                    break;
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView3.Rows.Count <= 0)
            {
                return;
            }
            if ((dataGridView3.Rows[e.RowIndex].Cells["Ybbm"].Value.ToString() == "") || (dataGridView3.Rows[e.RowIndex].Cells["Ybbm"].Value.ToString() == "0"))
            {
                FrmXmbmxg xfxmbm = new FrmXmbmxg();
                xfxmbm.Xmmc = this.dataGridView3.Rows[e.RowIndex].Cells["xmmc"].Value.ToString().Trim();
                xfxmbm.Mtprodiid = this.dataGridView3.Rows[e.RowIndex].Cells["hisbm"].Value.ToString().Trim();
                xfxmbm.Xmjg = this.dataGridView3.Rows[e.RowIndex].Cells["xmdj"].Value.ToString().Trim();
                xfxmbm.StartPosition = FormStartPosition.CenterScreen;
                xfxmbm.ShowDialog();
            }
            else
            {
                this.lb_pdbxxx.Text = "";
                string xmmc_ = this.dataGridView3.Rows[e.RowIndex].Cells["xmmc"].Value.ToString().Trim();
                string hisbm_ = this.dataGridView3.Rows[e.RowIndex].Cells["hisbm"].Value.ToString().Trim();
                string sfxmdm = this.dataGridView3.Rows[e.RowIndex].Cells["Ybbm"].Value.ToString().Trim();
                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "0";
                string sql_gxsfck = "select sfck from inhospital where id='" + this.ihsp_id + "'";
                DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
                if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
                {
                    yw_in_smldz.Ylzh = "0";
                }
                else
                {
                    yw_in_smldz.Ylzh = this.jmylzh_;
                }
                yw_in_smldz.Rc = sfxmdm;
                //string sql_cx = "select * from ihsp_costdet where id=" + hisbm_;
                //DataTable dt_xmcx = BllMain.Db.Select(sql_cx).Tables[0];
                //if (dt_xmcx.Rows.Count == 0)
                //{
                //    return;
                //}
                //else
                //{
                //    string projecttype = dt_xmcx.Rows[0]["itemfrom"].ToString().Trim();
                    string projecttype = this.dataGridView3.Rows[e.RowIndex].Cells["Xmlb"].Value.ToString().Trim();
                    if (projecttype == "DRUG")
                    {
                        string sql_hdybcc = "select * from hdybcc where xh=3";
                        DataTable dt_xmcx3 = BllMain.Db.Select(sql_hdybcc).Tables[0];
                        yw_in_smldz.Yw = "BB31KA02";
                        int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                        if (opt_smldz != 0)
                        {
                            return;
                        }
                        string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                        if (smldz_cc[1] == "XX")
                        {
                            this.lb_pdbxxx.Text = "[药品没有对码：" + hisbm_ + "-" + xmmc_ + "-" + yw_in_smldz.Mesg + "]\r\n";
                            return;
                        }
                        else if (!string.IsNullOrEmpty(smldz_cc[0]))
                        {
                            string fhxx = "";
                            try
                            {
                                string[] retdata1 = dt_xmcx3.Rows[0]["ywccjm"].ToString().Split('|');

                                for (int j = 0; j < smldz_cc.Length; j++)
                                {
                                    fhxx += retdata1[j] + "：" + smldz_cc[j] + "|";
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                this.lb_pdbxxx.Text = fhxx;
                            }
                        }
                    }
                    else if (projecttype == "STUFF")
                    {
                        string sql_hdybcc = "select * from hdybcc where xh=22";
                        DataTable dt_xmcx3 = BllMain.Db.Select(sql_hdybcc).Tables[0];
                        yw_in_smldz.Yw = "BB31KA04";
                        int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                        if (opt_smldz != 0)
                        {
                            return;
                        }
                        string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                        if (smldz_cc[1] == "XX")
                        {
                            this.lb_pdbxxx.Text = "[床位费没有对码：" + hisbm_ + "-" + xmmc_ + "-" + yw_in_smldz.Mesg + "]\r\n";
                            return;
                        }
                        else if (!string.IsNullOrEmpty(smldz_cc[0]))
                        {
                            string fhxx = "";
                            try
                            {
                                string[] retdata1 = dt_xmcx3.Rows[0]["ywccjm"].ToString().Split('|');

                                for (int j = 0; j < smldz_cc.Length; j++)
                                {
                                    fhxx += retdata1[j] + "：" + smldz_cc[j] + "|";
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                this.lb_pdbxxx.Text = fhxx;
                            }
                        }
                    }
                    else
                    {
                        string sql_hdybcc = "select * from hdybcc where xh=4";
                        DataTable dt_xmcx3 = BllMain.Db.Select(sql_hdybcc).Tables[0];
                        yw_in_smldz.Yw = "BB31KA03";
                        int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                        if (opt_smldz != 0)
                        {
                            return;
                        }
                        string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                        if (smldz_cc[1] == "XX")
                        {
                            this.lb_pdbxxx.Text = "[诊疗费没有对码：" + hisbm_ + "-" + xmmc_ + "-" + yw_in_smldz.Mesg + "]\r\n";
                            return;
                        }
                        else if (!string.IsNullOrEmpty(smldz_cc[0]))
                        {
                            string fhxx = "";
                            try
                            {
                                string[] retdata1 = dt_xmcx3.Rows[0]["ywccjm"].ToString().Split('|');

                                for (int j = 0; j < smldz_cc.Length; j++)
                                {
                                    fhxx += retdata1[j] + "：" + smldz_cc[j] + "|";
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                this.lb_pdbxxx.Text = fhxx;
                            }
                        }
                    }
                //}
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }
            string scordelete_ = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().Trim();
            if (scordelete_.Equals("True"))
            {
                try
                {
                    string zyh = this.cyjsZyh.Text.Trim();
                    string mtzyjlstuffiid = dataGridView1.CurrentRow.Cells["处方号"].Value.ToString().Trim();
                    if (MessageBox.Show("确定删除费用吗？【项目名称: " + dataGridView1.CurrentRow.Cells["名称"].Value.ToString() + "-处方号：" + dataGridView1.CurrentRow.Cells["处方号"].Value.ToString().Trim() + "-等级：" + dataGridView1.CurrentRow.Cells["等级"].Value.ToString().Trim() + "-编码：" + dataGridView1.CurrentRow.Cells["编码"].Value.ToString().Trim() + "】", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }

                    string sql_gxsfck = "select sfck,nhflag from inhospital where id='" + ihsp_id + "'";
                    DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);

                    if (ds_sfck.Tables[0].Rows[0]["nhflag"].ToString().Trim() != "1101")
                    {
                        MessageBox.Show("非医保城乡在院患者，不可以删除费用！");
                        return;
                    }
                    YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
                    yw_in_ybsjcs.Yw = "BB310001";
                    if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString().Trim() == "1")
                    {
                        yw_in_ybsjcs.Ylzh = "0";
                    }
                    else
                    {
                        yw_in_ybsjcs.Ylzh = this.cyjsGrbh.Text.Trim();
                    }
                    yw_in_ybsjcs.Rc = this.cyjsGrbh.Text.Trim() + "|" + this.cyjsZyh.Text.Trim();
                    string sql_fycx = "select top 1 * from kc22 where AKC190='" + this.cyjsZyh.Text.Trim() + "' and AKC220='" + mtzyjlstuffiid + "';";
                    DataTable dt_fycx = jkdb.Select(sql_fycx).Tables[0];
                    if (dt_fycx.Rows.Count > 0)
                    {
                        string AKC220_kc22 = DateTime.Now.ToString("yyMMddHHmmss") + mtzyjlstuffiid;
                        string sql_fy_insert = "insert into kc22(AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,";
                        sql_fy_insert += "AKC227,AKA070,AAE040,ZKA100,ZKA101,CKC048,CKC126,CKC125,AKA065) values ('";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC190"].ToString().Trim() + "','";
                        sql_fy_insert += AKC220_kc22 + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC221"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC515"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC223"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC224"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKC225"].ToString().Trim() + "','";
                        sql_fy_insert += (-double.Parse(dt_fycx.Rows[0]["AKC226"].ToString().Trim())).ToString() + "','";
                        sql_fy_insert += (-double.Parse(dt_fycx.Rows[0]["AKC227"].ToString().Trim())).ToString() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKA070"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AAE040"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["ZKA100"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["ZKA101"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["CKC048"].ToString().Trim() + "','";
                        sql_fy_insert += "0','";
                        sql_fy_insert += dt_fycx.Rows[0]["CKC125"].ToString().Trim() + "','";
                        sql_fy_insert += dt_fycx.Rows[0]["AKA065"].ToString().Trim() + "')";
                        if (jkdb.Update(sql_fy_insert) == -1)
                        {
                            MessageBox.Show("[插入KC22错误：zyh-" + this.cyjsZyh.Text.Trim() + "-处方号-" + mtzyjlstuffiid + "-项目名称-" + dataGridView1.CurrentRow.Cells["名称"].Value.ToString().Trim() + "]");
                            return;
                        }
                        int opt_ybsjcs = yw1.ybcjhs(yw_in_ybsjcs);
                        if (opt_ybsjcs == 0)
                        {
                            string ckc126_1 = "update KC22 set CKC126=1,AKC190='-" + this.cyjsZyh.Text.Trim() + "',AAE072='-" + dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "' where AKC190='" + this.cyjsZyh.Text.Trim() + "' and AKC220 in('" + AKC220_kc22 + "','" + mtzyjlstuffiid + "');";
                            if (jkdb.Update(ckc126_1) == -1)
                            {
                                MessageBox.Show("[更新KC22错误：zyh-" + this.cyjsZyh.Text.Trim() + "-处方号-" + mtzyjlstuffiid + "-项目名称-" + dataGridView1.CurrentRow.Cells["名称"].Value.ToString().Trim() + "]");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("[数据传输：zyh-" + this.cyjsZyh.Text.Trim() + "-处方号-" + mtzyjlstuffiid + "-项目名称-" + dataGridView1.CurrentRow.Cells["名称"].Value.ToString().Trim() + "-" + yw_in_ybsjcs.Mesg + "-" + "]");
                            string sql_del = "delete from KC22 where AKC190='-" + this.cyjsZyh.Text.Trim() + " and AKC220='" + AKC220_kc22 + "';";
                            jkdb.Update(sql_del);
                            return;
                        }
                        string sql_his = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0  where id= " + mtzyjlstuffiid;
                        if (BllMain.Db.Update(sql_his) == -1)
                        {
                            MessageBox.Show("更新his信息失败！");
                        }
                        MessageBox.Show("[zyh-" + this.cyjsZyh.Text.Trim() + "-处方号-" + mtzyjlstuffiid + "-项目名称-" + dataGridView1.CurrentRow.Cells["名称"].Value.ToString().Trim() + "-删除费用成功！]");
                    }
                    else
                    {
                        MessageBox.Show("[zyh-" + this.cyjsZyh.Text.Trim() + "-处方号-" + mtzyjlstuffiid + "-项目名称-" + dataGridView1.CurrentRow.Cells["名称"].Value.ToString().Trim() + "-删除费用失败！]");
                    }
                }
                catch
                { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_kc22_cx = " SELECT AKC515 as 编码,AKC223 as 项目名称,AKC225 as 单价,sum(AKC226) as 数量,sum(AKC227) as 金额,AKA065 as 性质 FROM KC22 WHERE AKC190='" + this.cyjsZyh.Text.Trim() + "' ";
            sql_kc22_cx += " and CKC126=1 group by AKC515,AKC223,AKC225,AKA065 order by AKC223 asc;";
            DataTable dt_kc22_cx = jkdb.Select(sql_kc22_cx).Tables[0];
            string ybjk_sql_delete = " delete from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "' and CKC126=0";
            jkdb.Update(ybjk_sql_delete);
            string ybjk_sql = "select AKC220 from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "'";
            DataTable dt = jkdb.Select(ybjk_sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0   where ihsp_id=" + this.ihsp_id + " and id not in (";
                string iid_sqls = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iid_sqls += dt.Rows[i]["AKC220"].ToString() + ",";
                }
                iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
                his_sql_update += iid_sqls + ")";
                BllMain.Db.Update(his_sql_update);

            }
            else
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0   where ihsp_id=" + this.ihsp_id + "";
                int ac = BllMain.Db.Update(his_sql_update);
            }
            string mesg = "";
            YBCJ_IN yw_in_ybsjcs = new YBCJ_IN();
            yw_in_ybsjcs.Yw = "BB310001";
            if (this.btn_sfck.Text == "有卡")
            {
                yw_in_ybsjcs.Ylzh = "0";
            }
            else
            {
                yw_in_ybsjcs.Ylzh = this.Grbh_;
            }
            yw_in_ybsjcs.Rc = this.Grbh_ + "|" + this.cyjsZyh.Text.Trim();
            for (int i = 0; i < dt_kc22_cx.Rows.Count; i++)
            {
                if (DataTool.Getdouble(dt_kc22_cx.Rows[i]["数量"].ToString().Trim()) == 0)
                    continue;
                string sql_fycx = "select top 1 * from kc22 where AKC225='" + dt_kc22_cx.Rows[i]["单价"].ToString().Trim() + "'";
                sql_fycx += " and AKC223='" + dt_kc22_cx.Rows[i]["项目名称"].ToString().Trim() + "'";
                sql_fycx += " and AKC190='" + this.cyjsZyh.Text.Trim() + "' order by AKC220 asc";
                DataTable dt_fycx = jkdb.Select(sql_fycx).Tables[0];
                if (dt_fycx.Rows.Count > 0)
                {
                    string AKC220_kc22 = DateTime.Now.ToString("yyMMddHHmmss") + i.ToString();
                    string sql_fy_insert = "insert into kc22(AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,";
                    sql_fy_insert += "AKC227,AKA070,AAE040,ZKA100,ZKA101,CKC048,CKC126,CKC125,AKA065) values ('";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC190"].ToString().Trim() + "','";
                    sql_fy_insert += AKC220_kc22 + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC221"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC515"].ToString().Trim() + "','";
                    sql_fy_insert += dt_kc22_cx.Rows[i]["项目名称"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC224"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKC225"].ToString().Trim() + "','";
                    sql_fy_insert += (-double.Parse(dt_kc22_cx.Rows[i]["数量"].ToString().Trim())).ToString() + "','";
                    sql_fy_insert += (-double.Parse(dt_kc22_cx.Rows[i]["金额"].ToString().Trim())).ToString() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKA070"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AAE040"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["ZKA100"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["ZKA101"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["CKC048"].ToString().Trim() + "','";
                    sql_fy_insert += "0','";
                    sql_fy_insert += dt_fycx.Rows[0]["CKC125"].ToString().Trim() + "','";
                    sql_fy_insert += dt_fycx.Rows[0]["AKA065"].ToString().Trim() + "')";
                    if (jkdb.Update(sql_fy_insert) == -1)
                    {
                        mesg += "[插入KC22错误：zyh-" + this.cyjsZyh.Text.Trim() + "-项目名称-" + dt_kc22_cx.Rows[i]["项目名称"].ToString().Trim() + "-数量-" + dt_kc22_cx.Rows[i]["数量"].ToString().Trim() + "]\r\n";
                        continue;
                    }
                    int opt_ybsjcs = yw1.ybcjhs(yw_in_ybsjcs);
                    if (opt_ybsjcs == 0)
                    {
                        string ckc126_1 = "update KC22 set CKC126=1,AKC190='-" + this.cyjsZyh.Text.Trim() + "',AAE072='-" + dt_fycx.Rows[0]["AAE072"].ToString().Trim() + "' where AKC190='" + this.cyjsZyh.Text.Trim() + "' and AKC220='" + AKC220_kc22 + "';";
                        jkdb.Update(ckc126_1);

                    }
                    else
                    {
                        mesg += "[数据传输：zyh-" + this.cyjsZyh.Text.Trim() + "-项目名称-" + dt_kc22_cx.Rows[i]["项目名称"].ToString().Trim() + "-" + yw_in_ybsjcs.Mesg + "-" + "]\r\n";
                        string sql_del = "delete from KC22 where AKC190='-" + this.cyjsZyh.Text.Trim() + " and AKC220='" + AKC220_kc22 + "';";
                        jkdb.Update(sql_del);
                        continue;
                    }
                }
                else
                {
                    mesg += "[项目不存在：zyh-" + this.cyjsZyh.Text.Trim() + "-项目名称-" + dt_kc22_cx.Rows[i]["项目名称"].ToString().Trim() + "-数量-" + dt_kc22_cx.Rows[i]["数量"].ToString().Trim() + "]\r\n";
                    continue;
                }
            }
            string sql_cx = "select sum(AKC227) as sum from kc22 where AKC190='"+this.cyjsZyh.Text.Trim()+"'";
            DataTable dt_cx = jkdb.Select(sql_cx).Tables[0];
            if (dt_cx.Rows[0]["sum"].ToString().Trim() == "0" || dt_cx.Rows[0]["sum"].ToString().Trim() == "0.00")
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0   where ihsp_id=" + this.ihsp_id + "";
                int ac = BllMain.Db.Update(his_sql_update);
            }
        }

        private void btn_jscd_Click(object sender, EventArgs e)
        {
            lblFeeUpLoad.Text = "";
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
                this.cyjsXjsjzf.Text = "";
                return;
            }
            String bcxjyzf = this.cyjsXjygzf.Text;
            if (bcxjyzf == null || bcxjyzf == "")
            {
                MessageBox.Show("本次现金应支付为空或者0", "提示信息");
                this.cyjsZhzf.Text = "";
                this.cyjsXjsjzf.Text = "";
                return;
            }
            double bcxjyzf_d = Double.Parse(bcxjyzf);
            if (bczhzfje_d > bcxjyzf_d)
            {
                MessageBox.Show("本次帐户支付不能大于本次现金应支付！", "提示信息");
                this.cyjsZhzf.Text = "";
                this.cyjsXjsjzf.Text = "";
                return;
            }

            double bcxjzf = bcxjyzf_d - bczhzfje_d;
            double bcxjzf_x = Math.Round(bcxjzf, 2);
            this.cyjsXjsjzf.Text = bcxjzf_x.ToString().Trim();
            if (this.yjkzfy.Text.Trim() == "" || this.yjkzfy.Text.Trim() == null)
            {
                this.tbx_thbxj.Text = (0 - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
            }
            else
            {
                this.tbx_thbxj.Text = (double.Parse(this.yjkzfy.Text) - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
            }
        }

        private void btn_zfjsht_Click(object sender, EventArgs e)
        {

        }

        private void btn_jzxxxz_Click(object sender, EventArgs e)
        {

        }

        private void but_dtfysc_Click(object sender, EventArgs e)
        {

        }
    }
}
