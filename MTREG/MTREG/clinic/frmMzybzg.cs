using System;
using System.Windows.Forms;
using System.Data;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
using MTHIS.main.bll;
using MTREG.medinsur;
using System.Drawing;
using MTREG.clinic.bll;

namespace MTREG.clinic
{
    public partial class frmMzybzg : Form
    {
        JKDB jkdb = new JKDB();
        MZSyb mzsyb = new MZSyb();
        BllClinicCostManage bllChargeManage = new BllClinicCostManage();
        private string cjmzh = "";
        private string jmylzh = "";
        private string zhye = "";
        private string grbh = "";
        private string _iid = "";
        private string dwbh = "";
        private string sfck = "";
        private string dkxxzfc = "";
        YBCJ yw1 = new YBCJ();
        public frmMzybzg()
        {
            InitializeComponent();
        }

        private void frmMzybzg_Load(object sender, EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", "未报销"));
            items.Add(new ListItem("301", "已报销"));
            this.cbx_ybzt.DisplayMember = "Value";
            this.cbx_ybzt.ValueMember = "Text";
            this.cbx_ybzt.DataSource = items;
            init_yllb();//医疗类别      
            tbx_jmylzh.Focus();
        }
        //医疗类别
        private void init_yllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "普通门诊"));
            items.Add(new ListItem("13", "门诊慢性病"));
            items.Add(new ListItem("15", "门诊特殊病"));
            this.combo_yllb.DisplayMember = "Value";
            this.combo_yllb.ValueMember = "Text";
            this.combo_yllb.DataSource = items;
            this.combo_yllb.SelectedValue = "11";
        }

        private void btn_Wk_Click(object sender, EventArgs e)
        {
            jmylzh = this.tbx_jmylzh.Text.Trim();
            if (jmylzh == "" || jmylzh == null)
            {
                MessageBox.Show("请输入个人编号或身份证号！", "提示信息");
                return;
            }
            this.clear_data();
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            yw_in_ryjbxxhzh.Ylzh = jmylzh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            grbh = ryjbxxhzh_cc[0];
            this.ipt_grbh.Text = grbh;
            this.ipt_ickh.Text = ryjbxxhzh_cc[3];
            this.ipt_xm.Text = ryjbxxhzh_cc[4];
            this.ipt_zyzt.Text = ryjbxxhzh_cc[17];
            dwbh = ryjbxxhzh_cc[2];

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

            this.ipt_zhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();

            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");

                return;
            }
            this.dkxxzfc = yw_in_ryjbxxhzh.Cc;
            this.txtBrxm.Text = ryjbxxhzh_cc[4];
            this.sfck = "1";

            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "0";
            yw_in_ryfsxx.Ylzh = jmylzh;
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');
            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                this.lab_fsqk.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            if (fsjb == 2)
            {
                this.lab_fsqk.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            if (fsjb == 0)
            {
                this.lab_fsqk.Text = "不封";
            }

            this.sfck = "0";
            this.txtBrxm.Focus();
        }
        private void clear_data()
        {

            //清空控件数据
            this.tbx_jmylzh.Text = "";
            this.ipt_grbh.Text = "";
            this.ipt_ickh.Text = "";
            this.ipt_zhye.Text = "";
            this.ipt_xm.Text = "";
            this.lab_fsqk.Text = "无";
            this.txtBrxm.Text = "";
            this.tbx_fph.Text = "";

            this.combo_yllb.SelectedValue = "11";
            this.tbx_jmylzh.Text = "";
            this.combo_spbz.DataSource = null;
            this.combo_spbz.Items.Clear();


        }

        private void btn_Yk_Click(object sender, EventArgs e)
        {
            this.clear_data();
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            grbh = ryjbxxhzh_cc[0];
            this.ipt_grbh.Text = grbh;
            this.ipt_ickh.Text = ryjbxxhzh_cc[3];
            this.ipt_xm.Text = ryjbxxhzh_cc[4];
            this.ipt_zyzt.Text = ryjbxxhzh_cc[17];
            dwbh = ryjbxxhzh_cc[2];

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

            this.ipt_zhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();

            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");

                return;
            }
            this.dkxxzfc = yw_in_ryjbxxhzh.Cc;
            this.txtBrxm.Text = ryjbxxhzh_cc[4];
            this.sfck = "1";

            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "0";
            yw_in_ryfsxx.Ylzh = "0";
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');
            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                this.lab_fsqk.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            if (fsjb == 2)
            {
                this.lab_fsqk.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            if (fsjb == 0)
            {
                this.lab_fsqk.Text = "不封";
            }
            this.sfck = "1";
            this.txtBrxm.Focus();
        }

        private void txtBrxm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadDataGrid();
            }
        }

        private void cbx_ybzt_SelectedValueChanged(object sender, EventArgs e)
        {
            string tmp = cbx_ybzt.Text.Trim();
            if (tmp == "" || tmp == "System.Data.DataRowView")
            {
                return;
            }
            if (cbx_ybzt.SelectedValue.ToString() == "0")
            {
                btn_cdfp.Enabled = false;
                btn_jsd.Enabled = false;
                btn_cxjs.Enabled = false;
                btn_ybjs.Enabled = true;
                btn_spbx.Enabled = true;
            }
            else if (cbx_ybzt.SelectedValue.ToString() == "301")
            {
                btn_cdfp.Enabled = true;
                btn_jsd.Enabled = true;
                btn_cxjs.Enabled = true;
                btn_ybjs.Enabled = false;
                btn_spbx.Enabled = true;
            }
        }

        private void combo_yllb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_yllb.SelectedValue == null)
            {
                return;
            }
            else if (this.combo_yllb.SelectedValue.ToString().Trim() == "11")
            {
                this.btn_ybjs.Enabled = true;
                this.combo_spbz.Visible = false;
                this.label_spbz.Visible = false;
                return;
            }
            else if (this.combo_yllb.SelectedValue.ToString().Trim() == "13")
            {
                if (dataGridView_fyxx.Rows.Count == 0)
                {
                    this.combo_yllb.SelectedValue = "11";
                    return;
                }
                this.btn_ybjs.Enabled = false;
                this.combo_spbz.Visible = true;
                this.label_spbz.Visible = true;
                this.combo_spbz.Text = "";
                //调用人员已审批过的慢性病信息
                YBCJ_IN yw_in_dryyspgdmxbxx = new YBCJ_IN();
                yw_in_dryyspgdmxbxx.Yw = "BB31SPXX";
                yw_in_dryyspgdmxbxx.Ybcjbz = "0";
                if (this.sfck == "1")
                {
                    yw_in_dryyspgdmxbxx.Ylzh = "0";
                }
                else
                {
                    yw_in_dryyspgdmxbxx.Ylzh = grbh;
                }
                yw_in_dryyspgdmxbxx.Hisjl = grbh;
                yw_in_dryyspgdmxbxx.Rc = grbh;
                int opt_dryyspgdmxbxx = yw1.ybcjhs(yw_in_dryyspgdmxbxx);
                if (opt_dryyspgdmxbxx != 0)
                {
                    MessageBox.Show(yw_in_dryyspgdmxbxx.Mesg, "提示信息");
                    return;
                }
                else
                {
                    string[] retdata = yw_in_dryyspgdmxbxx.Cc.Split('|');
                    List<ListItem> items = new List<ListItem>();
                    items.Add(new ListItem("-1", ""));
                    for (int i = 0; i < retdata.Length; i++)
                    {
                        if (retdata[i].ToString() == "XX")
                        {
                            break;
                        }
                        if (i % 2 == 0)
                        {
                            items.Add(new ListItem(retdata[i].ToString(), retdata[i + 1].ToString()));
                            i = i + 1;
                        }
                    }
                    if (items.Count > 1)
                    {
                        this.combo_spbz.DisplayMember = "Value";
                        this.combo_spbz.ValueMember = "Text";
                        this.combo_spbz.DataSource = items;
                        this.combo_spbz.SelectedValue = "-1";
                    }
                    else
                    {
                        MessageBox.Show("审批病种为空，不能慢性病收费！", "提示信息");
                        return;
                    }
                }
            }
            else if (this.combo_yllb.SelectedValue.ToString().Trim() == "15")
            {
                if (dataGridView_fyxx.Rows.Count == 0)
                {
                    this.combo_yllb.SelectedValue = "11";
                    return;
                }
                this.btn_ybjs.Enabled = false;
                this.combo_spbz.Visible = true;
                this.label_spbz.Visible = true;
                this.combo_spbz.Text = "";
                List<ListItem> items = new List<ListItem>();
                
                items.Add(new ListItem("-1", ""));
                items.Add(new ListItem("FMGCBNZ", "复明工程白内障"));
                items.Add(new ListItem("TSB0000001", "恶性肿瘤放化疗(共用)"));
                items.Add(new ListItem("TSB0000002", "尿毒症透析(共用)"));
                items.Add(new ListItem("TSB0000003", "血友病(普通)"));
                items.Add(new ListItem("PKTSB0000001", "重症精神病(贫困救助)"));
                items.Add(new ListItem("PKTSB0000002", "白血病(贫困救助)"));
                items.Add(new ListItem("TSB0000004", "器官移植后使用抗排异药物(普通)"));
                
                this.combo_spbz.DisplayMember = "Value";
                this.combo_spbz.ValueMember = "Text";
                this.combo_spbz.DataSource = items;
                this.combo_spbz.SelectedValue = "-1";

            }
            MessageBox.Show("请选择审批病种！", "提示信息");
        }

        private void combo_spbz_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_spbz.SelectedValue == null)
            {
                return;
            }

            string spbz = this.combo_spbz.SelectedValue.ToString().Trim();
            if (spbz == "-1")
            {
                return;
            }

            string grbh = this.ipt_grbh.Text.Trim();
            string yllb = this.combo_yllb.SelectedValue.ToString().Trim();
            string splb = "";
            if (yllb == "13")
                splb = "6";
            else if (yllb == "15")
                splb = "4";
            //调用读人员审批信息
            YBCJ_IN yw_in_dryspxx = new YBCJ_IN();
            yw_in_dryspxx.Yw = "BB31KC20";
            yw_in_dryspxx.Ybcjbz = "0";
            if (this.sfck == "1")
            {
                yw_in_dryspxx.Ylzh = "0";
            }
            else
            {
                yw_in_dryspxx.Ylzh = grbh;
            }
            yw_in_dryspxx.Hisjl = grbh;
            yw_in_dryspxx.Rc = grbh + "|" + splb + "|" + this.combo_spbz.SelectedValue.ToString().Trim();
            int opt_dryspxx = yw1.ybcjhs(yw_in_dryspxx);
            if (opt_dryspxx != 0)
            {
                MessageBox.Show(yw_in_dryspxx.Mesg, "提示信息");
                return;
            }
            else
            {
                if (yw_in_dryspxx.Cc.Split('|')[0] == "0")
                {
                    MessageBox.Show("审批未通过，请用其他方式结算！", "提示信息");
                    return;
                }
                if (yllb == "13")
                {
                    this.btn_ybjs.Enabled = true;
                    if (dataGridView_fyxx.Rows.Count == 0)
                    {
                        return;
                    }
                    string in_jmylzh = grbh;
                    if (this.sfck == "1")
                    {
                        in_jmylzh = "0";
                    }
                    if (!ypdzxx(this.combo_spbz.SelectedValue.ToString().Trim(), dataGridView_fyxx, in_jmylzh)) //读疾病药品对照信息
                    {
                        
                    }
                }
                this.btn_ybjs.Enabled = true;
            }
        }

        //读疾病药品对照信息
        public bool ypdzxx(string jbbm, DataGridView dgvfy, string grbh)
        {
            string yperr = "";
            int dgvcount = dgvfy.Rows.Count;//
            //调用读疾病药品对照信息
            YBCJ_IN yw_in_djbypdzxx = new YBCJ_IN();
            yw_in_djbypdzxx.Yw = "BB31ZK06";
            yw_in_djbypdzxx.Ybcjbz = "0";
            yw_in_djbypdzxx.Ylzh = grbh;
            yw_in_djbypdzxx.Hisjl = grbh;
            for (int i = 0; i < dgvcount; i++)
            {
                if (dgvfy.Rows[i].Cells["checkrcp"].EditedFormattedValue.ToString().Trim() == "false")
                {
                    continue;
                }
                string ybbm = dgvfy.Rows[i].Cells["standcode"].Value.ToString().Trim();
                if (string.IsNullOrEmpty(ybbm))
                {
                    ybbm = "999999999";
                }
                yw_in_djbypdzxx.Rc = jbbm + "|" + ybbm;
                int opt_djbypdzxx = yw1.ybcjhs(yw_in_djbypdzxx);
                if (opt_djbypdzxx != 0)
                {
                    yperr += "药品与疾病对照出错: " + dgvfy.Rows[i].Cells["NAME"].Value.ToString() + yw_in_djbypdzxx.Mesg + "\r\n";
                    continue;
                }
                else
                {
                    if (yw_in_djbypdzxx.Cc.Split('|')[0] == "0")
                    {
                        yperr += "项目: " + dgvfy.Rows[i].Cells["NAME"].Value.ToString() + " 不在疾病目录里，按自费处理!\r\n";
                        continue;
                    }
                }
            }
            if (!string.IsNullOrEmpty(yperr))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = yperr;
                frmmesg.ShowDialog(this);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Jzryjbmc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Jzryjbmc.SelectAll();
        }

        private void Jzryjbmc_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            DataTable ryzddata = new DataTable();
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.Focus();
                    this.dgw_ryjbmc.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dgw_ryjbmc.Focus();
                this.dgw_ryjbmc.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.Focus();
                    this.dgw_ryjbmc.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Space)
            {
                sql = " select illcode as code,name as name,pincode as jm from insur_illness where cost_insurtype_id='19' ";

                ryzddata = BllMain.Db.Select(sql).Tables[0];
                if (dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.DataSource = ryzddata;
                    dgw_ryjbmc.Visible = true;
                }
                else
                {
                    dgw_ryjbmc.Visible = false;
                }
                return;
            }
            //查询
            if (Jzryjbmc.Text.Trim().Equals(""))
            {
                dgw_ryjbmc.Visible = false;
                return;
            }
            string tiaojian = " where 1=1 and illcode like '%" + Jzryjbmc.Text.Trim() + "%' or name like '%" + Jzryjbmc.Text.Trim() + "%'";// or pincode like '%" + Jzryjbmc.Text.Trim().ToUpper() + "%'";
            sql = " select illcode as code,name as name,pincode as jm from insur_illness " + tiaojian;
            ryzddata = BllMain.Db.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dgw_ryjbmc.DataSource = ryzddata;
                dgw_ryjbmc.Visible = true;
            }
            else
            {
                dgw_ryjbmc.Visible = false;
            }
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            loadDataGrid();
            if (dataGridView_brxx.RowCount != 0)
                dataGridView_brxx.Rows[0].Selected = true;
        }
        private void loadDataGrid()
        {
            try
            {
                getDgvInvoiceData();
                #region updateHeaderText
                dataGridView_brxx.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_brxx.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dataGridView_brxx.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                dataGridView_brxx.Columns["regbill"].HeaderText = "门诊号";
                dataGridView_brxx.Columns["regbill"].Width = (int)(130 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["regbill"].DisplayIndex = 0;
                dataGridView_brxx.Columns["invbill"].HeaderText = "发票号";
                dataGridView_brxx.Columns["invbill"].Width = (int)(80 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["invbill"].DisplayIndex = 1;
                dataGridView_brxx.Columns["regname"].HeaderText = "姓名";
                dataGridView_brxx.Columns["regname"].Width = (int)(110 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["regname"].DisplayIndex = 2;
                dataGridView_brxx.Columns["sex"].HeaderText = "性别";
                dataGridView_brxx.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["sex"].DisplayIndex = 3;
                dataGridView_brxx.Columns["dctname"].HeaderText = "收费员";
                dataGridView_brxx.Columns["dctname"].Width = (int)(70 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["dctname"].DisplayIndex = 4;
                dataGridView_brxx.Columns["realfee"].HeaderText = "金额";
                dataGridView_brxx.Columns["realfee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView_brxx.Columns["realfee"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["realfee"].DisplayIndex = 5;
                dataGridView_brxx.Columns["chargedate"].HeaderText = "收费时间";
                dataGridView_brxx.Columns["chargedate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dataGridView_brxx.Columns["chargedate"].Width = (int)(200 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["chargedate"].DisplayIndex = 6;
                dataGridView_brxx.Columns["hspcard"].HeaderText = "卡号";
                dataGridView_brxx.Columns["hspcard"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["hspcard"].DisplayIndex = 7;
                dataGridView_brxx.Columns["charged"].HeaderText = "计费状态";
                dataGridView_brxx.Columns["charged"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["charged"].DisplayIndex = 8;
                dataGridView_brxx.Columns["dptname"].HeaderText = "科室";
                dataGridView_brxx.Columns["dptname"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["dptname"].DisplayIndex = 10;
                this.dataGridView_brxx.Columns["patienttype"].HeaderText = "患者类型";
                this.dataGridView_brxx.Columns["patienttype"].Width = (int)(90 * ProgramGlobal.WidthScale);
                dataGridView_brxx.Columns["dptname"].DisplayIndex = 9;
                dataGridView_brxx.Columns["age"].Visible = false;
                dataGridView_brxx.Columns["id"].Visible = false;
                dataGridView_brxx.Columns["idcard"].Visible = false;
                dataGridView_brxx.Columns["regist_id"].Visible = false;
                dataGridView_brxx.Columns["bas_patienttype_id"].Visible = false;
                dataGridView_brxx.ReadOnly = true;
                dataGridView_brxx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView_brxx.MultiSelect = false;
            }
            catch (Exception ex)
            {
            }
            if (dataGridView_brxx.Rows.Count > 0)
            {
                if (cbx_ybzt.SelectedValue.ToString() == "0")
                {
                    btn_ybjs.Enabled = true;
                    btn_cxjs.Enabled = false;
                    btn_cdfp.Enabled = false;
                    btn_jsd.Enabled = false;
                }
                if (cbx_ybzt.SelectedValue.ToString() == "301")
                {
                    btn_ybjs.Enabled = false;
                    btn_cxjs.Enabled = true;
                    btn_cdfp.Enabled = true;
                    btn_jsd.Enabled = true;
                }
                if (cbx_ybzt.SelectedValue.ToString() == "302")
                {
                    btn_ybjs.Enabled = false;
                    btn_cxjs.Enabled = false;
                    btn_cdfp.Enabled = false;
                    btn_jsd.Enabled = false;
                }
            }
            if (dataGridView_brxx.Rows.Count > 0)
            {
                dataGridView_brxx.Rows[0].Selected = true;
            }
            else
            {
                return;
            }
            this.combo_spbz.DataSource = null;
            this.combo_spbz.Items.Clear();
            if (dataGridView_brxx.SelectedRows.Count == 1)
            {
                _iid = dataGridView_brxx.SelectedRows[0].Cells["id"].Value.ToString().Trim();                
            }
                #endregion
        }
        private void getDgvInvoiceData()
        {
            ChargeManage chargeManage = new ChargeManage();
            chargeManage.PatientName = txtBrxm.Text.Trim();
            chargeManage.Fph = tbx_fph.Text.Trim();
            chargeManage.HspCard = "";
            chargeManage.Depart_id = "";
            chargeManage.Chargeby = "";
            chargeManage.StartDate = this.dateTime_cxrqks.Value.ToString("yyyy-MM-dd");
            chargeManage.EndDate = this.dateTime_cxrqjs.Value.ToString("yyyy-MM-dd HH:mm:ss");
            chargeManage.Islock = "";
            chargeManage.Isret = "CHAR";
            try
            {
                this.dataGridView_brxx.DataSource = bllChargeManage.getInvoice(chargeManage, Convert.ToInt32(cbx_ybzt.SelectedValue.ToString())); 
            }
            catch (Exception)
            {
                getDgvInvoiceData();
            }
        }

        private void dgw_ryjbmc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Jzryjbmc.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdname"].Value.ToString().Trim();
                tbx_jbbm.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdcode"].Value.ToString().Trim();
                dgw_ryjbmc.Visible = false;
                Jzryjbmc.Focus();
            }
        }

        private void dataGridView_brxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgetata();
            _iid = dataGridView_brxx.Rows[e.RowIndex].Cells["id"].Value.ToString().Trim();
        }
        private void dgetata()
        {
            if (dataGridView_brxx.SelectedRows.Count != 0)
            {
                string id = dataGridView_brxx.SelectedRows[0].Cells["id"].Value.ToString();
                DataTable dt = bllChargeManage.ClinicCostdets(id);
                if (dt == null)
                {
                    return;
                }
                this.dataGridView_fyxx.DataSource = dt;
                double amt = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    amt += Convert.ToDouble(dt.Rows[i]["fee"].ToString());
                }
                this.mzzfy.Text = amt.ToString();
                this.fpkcfy.Text = amt.ToString();
                dataGridView_fyxx.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_fyxx.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dataGridView_fyxx.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                dataGridView_fyxx.Columns["checkrcp"].ReadOnly = false;
                dataGridView_fyxx.Columns["checkrcp"].Width = (int)(30 * ProgramGlobal.WidthScale);
                dataGridView_fyxx.Columns["checkrcp"].DisplayIndex = 0;
                dataGridView_fyxx.Columns["checkrcp"].HeaderText = "";
                this.dataGridView_fyxx.Columns["invoice"].HeaderText = "发票号";
                this.dataGridView_fyxx.Columns["invoice"].Width = (int)(120 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["name"].HeaderText = "项目名称";
                this.dataGridView_fyxx.Columns["name"].Width = (int)(250 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["yptsxx"].HeaderText = "药品提示";
                this.dataGridView_fyxx.Columns["yptsxx"].Width = (int)(80 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["charged"].HeaderText = "项目类别";
                this.dataGridView_fyxx.Columns["charged"].Width = (int)(60 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["insurclass"].HeaderText = "等级";
                this.dataGridView_fyxx.Columns["insurclass"].Width = (int)(40 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["spbz"].HeaderText = "审批";
                this.dataGridView_fyxx.Columns["spbz"].Width = (int)(40 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["spec"].HeaderText = "规格";
                this.dataGridView_fyxx.Columns["spec"].Width = (int)(60 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["unit"].HeaderText = "单位";
                this.dataGridView_fyxx.Columns["unit"].Width = (int)(60 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["num"].HeaderText = "数量";
                this.dataGridView_fyxx.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView_fyxx.Columns["num"].Width = (int)(60 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["prc"].HeaderText = "单价";
                this.dataGridView_fyxx.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView_fyxx.Columns["prc"].Width = (int)(80 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["fee"].HeaderText = "总金额";
                this.dataGridView_fyxx.Columns["fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView_fyxx.Columns["fee"].Width = (int)(80 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["chargedate"].HeaderText = "时间";
                this.dataGridView_fyxx.Columns["chargedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView_fyxx.Columns["chargedate"].Width = (int)(80 * ProgramGlobal.WidthScale);
                this.dataGridView_fyxx.Columns["kdksbm"].HeaderText = "开单科室编码";
                this.dataGridView_fyxx.Columns["kdksbm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView_fyxx.Columns["kdksbm"].Width = (int)(80 * ProgramGlobal.WidthScale);
                dataGridView_fyxx.Columns["standcode"].Visible = false;
                dataGridView_fyxx.Columns["id"].Visible = false;
                dataGridView_fyxx.ReadOnly = true;
                dataGridView_fyxx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            else
            {
                dataGridView_fyxx.DataSource = null;
            }
        }

        private void dataGridView_brxx_SelectionChanged(object sender, EventArgs e)
        {
            dgetata();
            _iid = dataGridView_brxx.SelectedRows[0].Cells["id"].Value.ToString().Trim();
        }

        private void cbxAllcheck_CheckedChanged(object sender, EventArgs e)
        {
            int isallchk = 0;
            if (cbxAllcheck.Checked == true)
            {
                isallchk = 1;
                for (int i = 0; i < dataGridView_fyxx.RowCount; i++)
                {
                    dataGridView_fyxx.Rows[i].Cells["checkrcp"].Value = isallchk;
                }
            }
        }

        private void dataGridView_fyxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dataGridView_fyxx.SelectedRows[0].Cells["checkrcp"].Value) == 0)
            {
                dataGridView_fyxx.SelectedRows[0].Cells["checkrcp"].Value = 1;
            }
            else
            {
                dataGridView_fyxx.SelectedRows[0].Cells["checkrcp"].Value = 0;
                cbxAllcheck.Checked = false;
            }
            int coun = 0;
            for (int i = 0; i < dataGridView_fyxx.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView_fyxx.Rows[i].Cells["checkrcp"].Value) == 1)
                {
                    coun += 1;
                }
            }
            if (coun >= dataGridView_fyxx.RowCount)
                cbxAllcheck.Checked = true;

        }

        private void btn_spbx_Click(object sender, EventArgs e)
        {
            if (dataGridView_fyxx.RowCount < 1)
            {
                return;
            }
            pdsfbx();
        }
        //城居  判断是否报销
        private void pdsfbx()
        {
            if (string.IsNullOrEmpty(_iid.ToString().Trim()))
            {
                return;
            }
            Sfbx bx = new Sfbx();
            DataTable dt_xmcx = bx.gethism(dataGridView_brxx.SelectedRows[0].Cells["id"].Value.ToString());
            if (dt_xmcx.Rows.Count == 0)
            {
                return;
            }

            string mesg_pd = "";
            for (int j = 0; j < dt_xmcx.Rows.Count; j++)
            {
                #region
                string iid = dt_xmcx.Rows[j]["id"].ToString().Trim();
                string sfxmdm = dt_xmcx.Rows[j]["sfxmdm"].ToString().Trim();
                string xmmc = dt_xmcx.Rows[j]["xmmc"].ToString().Trim();
                string insurcode = dt_xmcx.Rows[j]["itemfromcode"].ToString();//药品/诊疗/床位费
                if (string.IsNullOrEmpty(sfxmdm))
                {
                    mesg_pd += "[项目医保编码为空：" + iid + "-" + xmmc + "]\r\n";
                    continue;
                }
                //string projecttype = dt_xmcx.Rows[j]["itemfrom"].ToString().Trim();
                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "0";
                if (this.sfck == "1")
                {
                    yw_in_smldz.Ylzh = "0";
                }
                else
                {
                    yw_in_smldz.Ylzh = jmylzh;
                }
                yw_in_smldz.Rc = sfxmdm;
                if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA02";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照药品失败：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[药品没有对码：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                }
                //读取床位信息
                else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA04";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照床位失败：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[床位没有对码：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                }
                //读取诊疗信息
                else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA03";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照诊疗失败：-" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[诊疗没有对码：-" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                }
                #endregion
            }
            if (!string.IsNullOrEmpty(mesg_pd))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg_pd;
                frmmesg.ShowDialog(this);
            }
        }

        private void btn_ybjs_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            if (dataGridView_fyxx.RowCount <1)
            {
                return;
            }
            if (_iid.Equals(""))
            {
                return;
            }
            string grbh = this.ipt_grbh.Text.Trim();
            if (grbh == null || grbh == "")
            {
                MessageBox.Show("个人编号为空，请读卡！", "提示信息");
                return;
            }

            double hisfee = Convert.ToDouble(this.fpkcfy.Text.Trim());
            double ybfee = Convert.ToDouble(ipt_zhye.Text.Trim());
            double cha = hisfee - ybfee;
            if (ybfee < hisfee)
            {
                if (MessageBox.Show("医保卡余额不足，不足金额用现金结算吗? 现金：" + cha.ToString() + " 元", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            //结算
            chmzjs();
            this.clear_data();
        }

        //职工  门诊结算 
        private void chmzjs()
        {
            if (txtBrxm.Text.Trim() != ipt_xm.Text.Trim())
            {
                MessageBox.Show("读卡姓名和患者姓名不符！");
                return;
            }
            //更新KC21 brxx
            string mzh = dataGridView_brxx.CurrentRow.Cells["regbill"].Value.ToString().Trim();
            string ys = dataGridView_brxx.CurrentRow.Cells["ys"].Value.ToString().Trim();
            string ks = dataGridView_brxx.CurrentRow.Cells["dptname"].Value.ToString().Trim();
            string ryrq = Convert.ToDateTime(dataGridView_brxx.CurrentRow.Cells["chargedate"].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string ickh = this.ipt_ickh.Text.Trim();
            string xm = this.ipt_xm.Text.Trim();


            string yllb = this.combo_yllb.SelectedValue.ToString().Trim();
            string jbbm = this.tbx_jbbm.Text;
            string jbmc = this.Jzryjbmc.Text;
            if (yllb == "13" || yllb == "15")
            {
                jbbm = this.combo_spbz.SelectedValue.ToString().Trim();
                jbmc = this.combo_spbz.Text.Trim();
            }
            string jbr = ProgramGlobal.Username;
            string dqrq = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //城乡门诊号
            cjmzh = DateTime.Now.ToString("yyMMddHHmmss") + "1";

            //更新	病人就诊信息KC21表
            string search_sql = "select count(*) from KC21 where AKC190='" + cjmzh + "'";
            string sql = " INSERT INTO KC21 (AKC190,CKC502,AAC003,AAC001,AAB001,AKA130,AKC192,AKC193,zkc274,AKC196,zkc275,zkc271,zkc272,AAE011,AAE036,CKC126) values ";
            sql += "('" + cjmzh + "','" + ickh + "','" + xm + "','" + grbh + "','" + dwbh + "','" + yllb + "','" + ryrq + "','" + jbbm + "','" + jbmc + "','" + jbbm + "','" + jbmc + "','" + ys + "','" + ks + "','" + jbr + "','" + dqrq + "',  0)";

            DataSet ds = jkdb.Select(search_sql);
            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                if (jkdb.Update(sql) == -1)
                {
                    MessageBox.Show("插入kc21表失败");
                    return;
                }
            }

            string mesg = "";
            string costid = "";
            for (int i = 0; i < dataGridView_fyxx.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView_fyxx.Rows[i].Cells["checkrcp"].Value) == 1)
                {
                    costid += dataGridView_fyxx.Rows[i].Cells["id"].Value.ToString().Trim() + ",";
                }
            }
            costid = costid.Substring(0, costid.Length - 1);
            //更新KC22 药品，材料，诊疗
            string ypsql = @"SELECT
	                        clinic_costdet.spbz AS ypspbz,
	                        -- 审批标志
	                        clinic_costdet.yptsxx AS yptsxx,
	                        -- 药品提示信息
	                        clinic_costdet.itemfrom AS projecttype,
                            cost_itemtype.netcode as itemfromcode,
	                        -- 项目类型
	                        clinic_costdet.id AS stuffiid,
	                        -- 
	                        '' AS mzh,
	                        clinic_costdet.id AS cfh,
	                        -- 处方号
	                        clinic_costdet.rcpdate AS cfrq,
	                        -- 处方日期
	                        bas_item.standcode AS sfxmdm,
	                        clinic_costdet. NAME AS xmmc,
	                        clinic_costdet.Prc,
	                        clinic_costdet.Num AS qty,
	                        clinic_costdet.Fee AS amt,
	                        clinic_costdet.chargedate AS jsrq,
	                        clinic_costdet.Spec AS prodguige,
	                        '' AS jixing,
	                        clinic_costdet.unit AS uom -- 收费单位
                        FROM
	                        clinic_costdet
                        LEFT JOIN bas_item on clinic_costdet.item_id = bas_item.id
                        left join cost_itemtype on cost_itemtype.id=clinic_costdet.itemtype_id
                        WHERE
                            clinic_costdet.charged in ('RREC','RET','CHAR')
	                        and clinic_costdet.id in (" + costid + ")";
            DataSet zyjlds = BllMain.Db.Select(ypsql);
            for (int i = 0; i < zyjlds.Tables[0].Rows.Count; i++)
            {
                string stuffiid = zyjlds.Tables[0].Rows[i]["stuffiid"].ToString().Trim();
                string _mzh = zyjlds.Tables[0].Rows[i]["mzh"].ToString().Trim();
                string cfh = zyjlds.Tables[0].Rows[i]["cfh"].ToString().Trim();
                string cfrq = zyjlds.Tables[0].Rows[i]["cfrq"].ToString().Trim();
                string sfxmdm = zyjlds.Tables[0].Rows[i]["sfxmdm"].ToString().Trim();
                string xmmc = zyjlds.Tables[0].Rows[i]["xmmc"].ToString().Trim();
                string prc = zyjlds.Tables[0].Rows[i]["prc"].ToString().Trim();
                string qty = zyjlds.Tables[0].Rows[i]["qty"].ToString().Trim();
                string amt = zyjlds.Tables[0].Rows[i]["amt"].ToString().Trim();
                if (amt == "" || amt == null)
                {
                    amt = "0";
                }
                string jsrq = zyjlds.Tables[0].Rows[i]["jsrq"].ToString().Trim();
                string projecttype = zyjlds.Tables[0].Rows[i]["projecttype"].ToString().Trim();
                string itemfromcode = zyjlds.Tables[0].Rows[i]["itemfromcode"].ToString().Trim();
                string guige = zyjlds.Tables[0].Rows[i]["prodguige"].ToString().Trim();
                string jixing = zyjlds.Tables[0].Rows[i]["jixing"].ToString().Trim();
                string uom = zyjlds.Tables[0].Rows[i]["uom"].ToString().Trim();

                xmmc = System.Text.RegularExpressions.Regex.Replace(xmmc, "[()*|<>&']", "");
                guige = System.Text.RegularExpressions.Regex.Replace(guige, "[()*|<>&']", "");
                jixing = System.Text.RegularExpressions.Regex.Replace(jixing, "[()*|<>&']", "");
                uom = System.Text.RegularExpressions.Regex.Replace(uom, "[()*|<>&']", "");

                string lb = "2";
                string ypdj = "丙";
                string spbz = "";
                string yptsxx = "";
                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "0";
                if (this.sfck == "1")
                {
                    yw_in_smldz.Ylzh = "0";
                }
                else
                {
                    yw_in_smldz.Ylzh = grbh;
                }
                yw_in_smldz.Rc = sfxmdm;
                //if (projecttype == "2" || projecttype == "3" || projecttype == "4")
                if (itemfromcode.Equals(((int)InsurEnum.Yzc.YP).ToString()))
                {
                    lb = "1";
                    yw_in_smldz.Yw = "BB31KA02";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照药品失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[药品没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        ypdj = "丙";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        if (smldz_cc[5] == "1")
                        {
                            spbz = "1";
                        }
                        try
                        {
                            yptsxx = System.Text.RegularExpressions.Regex.Replace(smldz_cc[6], "['|<>&]", "");
                        }
                        catch { }
                    }
                }
                //else if (projecttype == "-103")
                else if (itemfromcode.Equals(((int)InsurEnum.Yzc.CWF).ToString()))
                {
                    lb = "3";
                    yw_in_smldz.Yw = "BB31KA04";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照床位失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[床位没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        ypdj = "丙";
                        continue;
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                    }
                }
                else
                {
                    yw_in_smldz.Yw = "BB31KA03";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg += "[对照诊疗失败：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg += "[诊疗没有对码：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        ypdj = "丙";
                    }
                    else if (!string.IsNullOrEmpty(smldz_cc[0]))
                    {
                        ypdj = smldz_cc[0];
                        if (smldz_cc[9] == "1")
                        {
                            spbz = "3";
                        }
                    }
                }
                if (sfxmdm == "" || sfxmdm == null)
                {
                    sfxmdm = "999999999";
                }
                //类型1 药品，2诊疗 3床位费
                string _insert_sql = "insert into KC22 (AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,AKC227,AAE040,ZKA100,CKC126,CKC125,AKA065,ZKA101,AKA070,CKC048) values ";
                _insert_sql += "('" + cjmzh + "','" + cfh + "','" + cjmzh + "','" + cfrq + "','" + sfxmdm + "','" + xmmc + "','" + lb + "'," + prc + "," + qty + "," + amt + ",'" + jsrq + "','" + guige + "',0,0,'" + ypdj + "','" + uom + "','" + jixing + "','" + spbz + "')";
                //更新mtstuffitem.ybsfsc标志
                string update_sql = "";
                //if (!string.IsNullOrEmpty(spbz))
                //{
                //    update_sql = "update clinic_costdet set yblx='" + ypdj + "',yptsxx='" + yptsxx + "',insursync='Y' where id =" + stuffiid + ";";
                //}
                if (string.IsNullOrEmpty(yptsxx))
                {
                    update_sql = "update clinic_costdet set yblx='" + ypdj + "' where id =" + stuffiid + ";";
                }
                else
                {
                    if (!string.IsNullOrEmpty(spbz))
                    {
                        update_sql = "update clinic_costdet set yblx='" + ypdj + "',spbz='" + spbz + "',yptsxx='" + yptsxx + "' where id =" + stuffiid + ";";
                    }
                    else
                    {
                        update_sql = "update clinic_costdet set yblx='" + ypdj + "' where id =" + stuffiid + ";";
                    }
                }
                if (BllMain.Db.Update(update_sql) == -1)
                {
                    MessageBox.Show("修改费用明细失败！");
                    return;
                }
                if (jkdb.Update(_insert_sql) == -1)
                {
                    MessageBox.Show("插入kc22费用表失败");
                    SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 插入kc22费用表失败 sql" + _insert_sql);
                    return;
                }
            }

            String KC21_sql_ = "UPDATE KC21 SET AKC194 ='" + Convert.ToDateTime(ryrq).ToString("yyyy-MM-dd") + " 23:59:59' WHERE AKC190='" + cjmzh + "';";
            jkdb.Update(KC21_sql_);
            if (!string.IsNullOrEmpty(mesg))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg;
                frmmesg.ShowDialog(this);
            }
            //预结算
            YBCJ_IN yw_in_zyjs = new YBCJ_IN();
            yw_in_zyjs.Yw = "BC311002";
            yw_in_zyjs.Ybcjbz = "0";
            if (this.sfck == "1")
            {
                yw_in_zyjs.Ylzh = "0";
            }
            else
            {
                yw_in_zyjs.Ylzh = grbh;
            }
            yw_in_zyjs.Hisjl = _iid.ToString().Trim();
            //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
            yw_in_zyjs.Rc = grbh + "|" + cjmzh + "|" + yllb + "|" + cjmzh + "|" + ProgramGlobal.Username + "|0";
            int opt_zyyjs = yw1.ybcjhs(yw_in_zyjs);
            if (opt_zyyjs != 0)
            {
                SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 预结算失败医保信息 " + yw_in_zyjs.Mesg);
                MessageBox.Show(yw_in_zyjs.Mesg + "预结算失败");
                return;
            }
            Frm_MzCxJs ybyjs = new Frm_MzCxJs();
            ybyjs.Ybcjbz = yw_in_zyjs.Ybcjbz;
            ybyjs.Yjsxx = yw_in_zyjs.Cc;
            ybyjs.StartPosition = FormStartPosition.CenterScreen;
            ybyjs.ShowDialog();
            if (ybyjs.Flag == false)
            {
                MessageBox.Show("预结算成功，没有结算");
                return;
            }
            yw_in_zyjs.Yw = "CC311002";
            //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
            yw_in_zyjs.Rc = grbh + "|" + cjmzh + "|" + yllb + "|" + cjmzh + "|" + ProgramGlobal.Username + "|" + ybyjs.Zffs;
            int opt_zyjs = yw1.ybcjhs(yw_in_zyjs);
            if (opt_zyjs != 0)
            {
                SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 结算失败医保信息 " + yw_in_zyjs.Mesg);
                MessageBox.Show(yw_in_zyjs.Mesg + "结算失败");
                return;
            }

            string[] dkxx = dkxxzfc.Split('|');
            string[] jsxx = yw_in_zyjs.Cc.Split('|');
            double ybbx_ = Convert.ToDouble(jsxx[0]) - Convert.ToDouble(jsxx[9]);
            string curdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd");//获取服务器当前时间

            //修改医保状态                
            string sql_ybzt = "update clinic_invoice set ybsfsc = 301 where id = " + _iid.ToString() + ";";
            sql_ybzt += " insert into zlsyb_mzinfo (mtmzblstuffiid,xm,sfzh,qh,dwbh,dwmc,grbh,ickh,xb,csrq,jsqzhye,jshzhye,ybmzh,fph,jssj,ybzfy,grzhzf,ybbx,sfy,tp,grxjzf,bctczf,bcgwyzc,bcdbzf,pkjzzfhj,yllb,jswzsczfc,sfck) ";
            sql_ybzt += " values (" + _iid.ToString() + ",'"
                                  + dkxx[4] + "','"
                                  + dkxx[1] + "','"
                                  + dkxx[21] + "','"
                                  + dkxx[2] + "','"
                                  + dkxx[38] + "','"
                                  + dkxx[0] + "','"
                                  + dkxx[3] + "','"
                                  + dkxx[5] + "','"
                                  + dkxx[6] + "','"
                                  + this.ipt_zhye.Text.Trim() + "','"
                                  + jsxx[11] + "','"
                                  + cjmzh + "','"
                                  + cjmzh + "','"
                                  + curdatetime + "','"
                                  + jsxx[0] + "','"
                                  + jsxx[7] + "','"
                                  + ybbx_ + "','"
                                  + ProgramGlobal.Username + "','"
              //2019/5/5    新改
                                 // + "3" + "','"
                                  +"1"+"','"
                                  + jsxx[9] + "','"
                                  + jsxx[8] + "','"
                                  + jsxx[10] + "','"
                                  + jsxx[14] + "','0','"
                                  + yllb + "','"
                                  + yw_in_zyjs.Cc + "','"
                                  + this.sfck + "');";
            if (BllMain.Db.Update(sql_ybzt) == -1)
            {
                MessageBox.Show("职工结算成功,HIS更新失败！");
            }

            MessageBox.Show("职工结算成功！");
            mzsyb.fpcd(_iid);
            if (yllb == "13" || yllb == "15")
            {
                mzsyb.jsdcd(_iid);
            }
            return;

        }

        private void btn_cdfp_Click(object sender, EventArgs e)
        {
            if (_iid.Equals(""))
            {
                return;
            }
            mzsyb.fpcd(_iid);
        }

        private void btn_jsd_Click(object sender, EventArgs e)
        {
            if (_iid.Equals(""))
            {
                return;
            }
            mzsyb.jsdcd(_iid);
        }

        private void btn_cxjs_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            //结算回退
            if (_iid.Equals(""))
            {
                return;
            }
            string brxm = dataGridView_brxx.CurrentRow.Cells["regname"].Value.ToString().Trim();
            if (MessageBox.Show("确定要给[   " + brxm + "   ]撤销结算吗?", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql_djh = "select fph,ybmzh,grbh,sfck from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid = " + _iid.ToString().Trim();
                DataTable dt = BllMain.Db.Select(sql_djh).Tables[0];
                string cj_mzh = dt.Rows[0]["ybmzh"].ToString().Trim();
                //结算回退
                YBCJ_IN yw_in_mzjsht = new YBCJ_IN();
                yw_in_mzjsht.Yw = "DC311002";
                yw_in_mzjsht.Ybcjbz = "0";
                if (dt.Rows[0]["sfck"].ToString().Trim() == "1")
                {
                    yw_in_mzjsht.Ylzh = "0";
                }
                else
                {
                    yw_in_mzjsht.Ylzh = dt.Rows[0]["grbh"].ToString().Trim();
                }
                yw_in_mzjsht.Hisjl = dt.Rows[0]["fph"].ToString().Trim();
                yw_in_mzjsht.Rc = dt.Rows[0]["grbh"].ToString().Trim() + "|" + dt.Rows[0]["ybmzh"].ToString().Trim() + "|" + dt.Rows[0]["fph"].ToString().Trim() + "|" + ProgramGlobal.Username;
                int opt_mzjsht = yw1.ybcjhs(yw_in_mzjsht);
                if (opt_mzjsht != 0)
                {
                    MessageBox.Show(yw_in_mzjsht.Mesg, "提示信息");
                    return;
                }
                //删除KC22 明细
                string sql2 = "delete from KC22 where AKC190='" + cj_mzh + "'";
                jkdb.Update(sql2);
                //删除KC21病人信息
                string sql_kc21 = "delete from KC21 where AKC190 = '" + cj_mzh + "'";
                jkdb.Update(sql_kc21);
                string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//服务器时间
                //string sql_yb = "update zlsyb_mzinfo set cxsj = '" + nowDateTime + "', tfr = " + ProgramGlobal.User_id + "  where mtmzblstuffiid = " + _iid.ToString() + ";";
                string sql_yb = "update zlsyb_mzinfo set isactive = 0,cxsj = '" + nowDateTime + "', tfr = " + ProgramGlobal.User_id + "  where mtmzblstuffiid = " + _iid.ToString() + ";";
                sql_yb += "UPDATE clinic_invoice set ybsfsc = 0 where id = " + _iid.ToString() + ";";
                BllMain.Db.Update(sql_yb);
                MessageBox.Show("结算回退成功！", "提示信息");
                loadDataGrid();
                this.clear_data();
            }
        }

        private void cbxAllcheck_Click(object sender, EventArgs e)
        {
            int isallchk = 0;
            if (cbxAllcheck.Checked == true)
            {
                for (int i = 0; i < dataGridView_fyxx.RowCount; i++)
                {
                    dataGridView_fyxx.Rows[i].Cells["checkrcp"].Value = isallchk;
                }
            }
        }

        private void ipt_zhye_TextChanged(object sender, EventArgs e)
        {

        }

        private void combo_yllb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
