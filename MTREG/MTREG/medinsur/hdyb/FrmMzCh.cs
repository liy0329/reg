using System;
using System.Windows.Forms;
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
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmMzCh : Form
    {
        public FrmMzCh()
        {
            InitializeComponent();
        }

        private Mzybdk mzybdk;
        internal Mzybdk Mzybdk
        {
            get { return mzybdk; }
            set { mzybdk = value; }
        }

        YBCJ yw1 = new YBCJ();

        string patientType;
        /// <summary>
        /// 传递患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }

        private void SetValue()
        {
            this.cmbPatientType.SelectedValue = patientType;
        }

        BllClinicMedinsr bllClinicMedinsr = new BllClinicMedinsr();

        private bool flag;
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private void btn_Wk_Click(object sender, EventArgs e)
        {
            string jmylzh = this.tbx_jmylzh.Text.Trim();
            if (string.IsNullOrEmpty(jmylzh))
            {
                MessageBox.Show("请输入身份证号或个人编号！", "提示信息");
                return;
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "1";
            yw_in_ryjbxxhzh.Ylzh = jmylzh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            string grbh = ryjbxxhzh_cc[0];//个人编号
            this.ipt_grbh.Text = grbh;
            this.tbxsfzh.Text = ryjbxxhzh_cc[1];//身份证号
            this.ipt_ickh.Text = ryjbxxhzh_cc[3]; //IC卡号
            this.ipt_xm.Text = ryjbxxhzh_cc[4]; //姓名
            this.tbx_dwbh.Text = ryjbxxhzh_cc[2]; //单位编号
            this.tbx_dwmc.Text = ryjbxxhzh_cc[38];//单位名称
            this.tbx_xb.Text = ryjbxxhzh_cc[5];//性别
            this.tbx_qh.Text = ryjbxxhzh_cc[21];//区号
            string sj = "";
            if (!string.IsNullOrEmpty(ryjbxxhzh_cc[6]))
            {
                try
                {
                    string year = ryjbxxhzh_cc[6].Substring(0, 4);
                    string moths = ryjbxxhzh_cc[6].Substring(4, 2);
                    string dys = ryjbxxhzh_cc[6].Substring(6, 2);
                    sj = year + "-" + moths + "-" + dys;
                    this.cmbxcsny.Value = Convert.ToDateTime(Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex)
                { }
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
            string zhye = (lnjz + bnzr - zhzc).ToString().Trim();
            this.tbx_grzhye.Text = zhye;
            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算" || ryjbxxhzh_cc[17] == "出院未结算" || ryjbxxhzh_cc[17] == "出院未结" || ryjbxxhzh_cc[17] == "在院")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");
                return;
            }
            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "1";
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
                this.lab_fsqk.Text = "不锁";
            }
            mzybdk.Grbh = ryjbxxhzh_cc[0];//个人编号 
            mzybdk.Sfzh = ryjbxxhzh_cc[1];//身份证号
            mzybdk.Ickh = ryjbxxhzh_cc[3]; //IC卡号
            mzybdk.Xm = ryjbxxhzh_cc[4]; //姓名
            mzybdk.Dwbh = ryjbxxhzh_cc[2]; //单位编号
            mzybdk.Dwmc = ryjbxxhzh_cc[38];//单位名称
            mzybdk.Xb = ryjbxxhzh_cc[5];//性别
            mzybdk.Qh = ryjbxxhzh_cc[21];//区号
            mzybdk.Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss"); //出生日期
            mzybdk.Zhye = zhye;
            mzybdk.Sfck = "0";
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            string yllb = this.cbx_yllb.SelectedValue.ToString().Trim();
            if (yllb == "13" || yllb == "15")
            {
                string spbz = this.cbx_spbz.SelectedValue.ToString().Trim();
                if (spbz == "-1" || this.cbx_spbz.Text.Trim() == "")
                {
                    MessageBox.Show("医疗类别是慢性病或特殊病，请选择审批病种！", "提示信息");
                    return;
                }
                mzybdk.Jbbm = this.cbx_spbz.SelectedValue.ToString().Trim();
                mzybdk.Jbmc = this.cbx_spbz.Text.Trim();
            }
            else
            {
                mzybdk.Jbbm = this.tbx_jbbm.Text.Trim();
                mzybdk.Jbmc = this.tbx_jbmc.Text.Trim();
            }
            mzybdk.Yllb = yllb;
            flag = true;

            this.Close();
        }

        private void btn_Yk_Click(object sender, EventArgs e)
        {
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "1";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            string grbh = ryjbxxhzh_cc[0];//个人编号
            this.ipt_grbh.Text = grbh;
            this.tbxsfzh.Text = ryjbxxhzh_cc[1];//身份证号
            this.ipt_ickh.Text = ryjbxxhzh_cc[3]; //IC卡号
            this.ipt_xm.Text = ryjbxxhzh_cc[4]; //姓名
            this.tbx_dwbh.Text = ryjbxxhzh_cc[2]; //单位编号
            this.tbx_dwmc.Text = ryjbxxhzh_cc[38];//单位名称
            this.tbx_qh.Text = ryjbxxhzh_cc[21];//区号
            this.tbx_xb.Text = ryjbxxhzh_cc[5];//性别
            string sj = "";
            if (!string.IsNullOrEmpty(ryjbxxhzh_cc[6]))
            {
                try
                {
                    string year = ryjbxxhzh_cc[6].Substring(0, 4);
                    string moths = ryjbxxhzh_cc[6].Substring(4, 2);
                    string dys = ryjbxxhzh_cc[6].Substring(6, 2);
                    sj = year + "-" + moths + "-" + dys;
                    this.cmbxcsny.Value = Convert.ToDateTime(Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex)
                { }
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
            string zhye = (lnjz + bnzr - zhzc).ToString().Trim();
            this.tbx_grzhye.Text = zhye;
            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算" || ryjbxxhzh_cc[17] == "出院未结算" || ryjbxxhzh_cc[17] == "出院未结" || ryjbxxhzh_cc[17] == "在院")
            {
                MessageBox.Show("此人目前为住院状态，不能进行门诊结算操作！", "提示信息");
                return;
            }
            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "1";
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
                this.lab_fsqk.Text = "不锁";
            }
            mzybdk.Grbh = ryjbxxhzh_cc[0];//个人编号 
            mzybdk.Sfzh = ryjbxxhzh_cc[1];//身份证号
            mzybdk.Ickh = ryjbxxhzh_cc[3]; //IC卡号
            mzybdk.Xm = ryjbxxhzh_cc[4]; //姓名
            mzybdk.Dwbh = ryjbxxhzh_cc[2]; //单位编号
            mzybdk.Dwmc = ryjbxxhzh_cc[38];//单位名称
            mzybdk.Xb = ryjbxxhzh_cc[5];//性别
            mzybdk.Qh = ryjbxxhzh_cc[21];//区号
            mzybdk.Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss"); //出生日期
            mzybdk.Zhye = zhye;
            mzybdk.Sfck = "1";
        }

        private void FrmMzCh_Load(object sender, EventArgs e)
        {
            //加载下拉列表
            loadSelectDrop();
        }
        //初始化下拉框数据
        private void loadSelectDrop()
        {
            //医疗类别-AKA130
            var dtm = bllClinicMedinsr.getMediTypeInfo();
            this.cbx_yllb.ValueMember = "Id";
            this.cbx_yllb.DisplayMember = "Name";
            this.cbx_yllb.DataSource = dtm;
            //审批类别
            var dta = bllClinicMedinsr.getApproTypeInfo();
            this.cbx_splb.ValueMember = "id";
            this.cbx_splb.DisplayMember = "Name";
            this.cbx_splb.DataSource = dta;
            cbx_splb.SelectedValue = -1;

            //患者类型的初始化
            var dtp = bllClinicMedinsr.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            SetValue();
            this.cmbPatientType.Enabled = false;
            //dgw_ryjbmc.Visible = false;
        }
        //关闭按钮
        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }
        //医疗类别
        private void cbx_yllb_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbx_splb.Text = "";
            this.cbx_spbz.Text = "";
            if (cbx_yllb.SelectedValue == null || cbx_yllb.SelectedValue.ToString() == "11")
            {
                this.but_ok.Enabled = true;
                return;
            }
            this.but_ok.Enabled = false;
            string grbh = this.ipt_grbh.Text.Trim();
            if (grbh == null || grbh == "")
            {
                MessageBox.Show("请先读卡！", "提示信息");
                return;
            }
            if (cbx_yllb.SelectedValue.ToString() == "13" || cbx_yllb.SelectedValue.ToString() == "15")
            {
                this.lb_xx.Text = "请选择审批类别！";
                this.lb_xx.Visible = true;
            }
            else
            {
                lb_xx.Visible = false;
            }
        }
        //审批类别
        private void cbx_splb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //审批病种
        private void cbx_spbz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_spbz.SelectedValue == null)
            {
                return;
            }
            this.lb_xx.Visible = false;
            string splb = this.cbx_splb.SelectedValue.ToString().Trim();
            if (splb == "-1")
            {
                this.but_ok.Enabled = false;
                MessageBox.Show("请选择审批类别！", "提示信息");
                return;
            }

            string spbz = this.cbx_spbz.SelectedValue.ToString().Trim();
            if (spbz == "-1")
            {
                this.but_ok.Enabled = false;
                return;
            }

            string grbh = this.ipt_grbh.Text.Trim();
            string yllb = this.cbx_yllb.SelectedValue.ToString().Trim();
            int spbz2 = this.cbx_spbz.SelectedIndex;
            if (splb == "17" || splb == "16")
            {
                if (spbz2 < 0)
                {
                    this.but_ok.Enabled = false;
                    MessageBox.Show("门诊慢性病或特殊病需要选择审批病种，请选择！", "提示信息");
                    return;
                }
            }
            if (yllb == "13" || yllb == "15")
            {
                //调用读人员审批信息
                YBCJ_IN yw_in_dryspxx = new YBCJ_IN();
                yw_in_dryspxx.Yw = "BB31KC20";
                yw_in_dryspxx.Ybcjbz = "1";
                if (Mzybdk.Sfck == "1")
                {
                    yw_in_dryspxx.Ylzh = "0";
                }
                else
                {
                    yw_in_dryspxx.Ylzh = grbh;
                }
                yw_in_dryspxx.Hisjl = grbh;
                yw_in_dryspxx.Rc = grbh + "|" + splb + "|" + this.cbx_spbz.SelectedValue.ToString().Trim();
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
                }
                this.but_ok.Enabled = true;
            }
        }

        private void tbx_jbbm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dgvClinicDiagn.Visible = true;
                dgvClinicDiagn.BringToFront();
                setDgvSource(tbx_jbbm.Text.Trim());
                dgvClinicDiagn.Rows[0].Selected = true;
                dgvClinicDiagn.Focus();
            }
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            dgvClinicDiagn.DataSource = bllClinicMedinsr.getClinicDisease(pincode);
            this.dgvClinicDiagn.Columns["id"].Width = 100;
            this.dgvClinicDiagn.Columns["name"].Width = 400;
        }

        private void dgvClinicDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvClinicDiagn.Rows.Count > 0)
            {
                int rowindex = this.dgvClinicDiagn.CurrentRow.Index;
                if (e.KeyData == Keys.Enter && rowindex >= 0)
       
                {
                    tbx_jbmc.Text = dgvClinicDiagn.Rows[rowindex].Cells["name"].Value.ToString();
                    tbx_jbbm.Text = dgvClinicDiagn.Rows[rowindex].Cells["id"].Value.ToString();
                    dgvClinicDiagn.Visible = false;
                    dgvClinicDiagn.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index > 0)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvClinicDiagn.CurrentRow != null && dgvClinicDiagn.CurrentRow.Index < dgvClinicDiagn.Rows.Count - 1)
                {
                    dgvClinicDiagn.Rows[dgvClinicDiagn.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void cbx_splb_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbx_splb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbx_splb.SelectedValue == null)
            {
                return;
            }
            this.cbx_spbz.Text = "";

            string splb = this.cbx_splb.SelectedValue.ToString().Trim();
            int splb2 = this.cbx_splb.SelectedIndex;
            if (splb == "-1" || splb2 < 0)
            {
                return;
            }
            string yllb = this.cbx_yllb.SelectedValue.ToString().Trim();
            if (yllb == "11")
            {
                this.cbx_splb.Text = "";
                MessageBox.Show("请先选择医疗类别", "提示信息");
                return;
            }
            string grbh = this.ipt_grbh.Text.Trim();
            if (grbh == null || grbh == "")
            {
                this.cbx_splb.Text = "";
                MessageBox.Show("请先读卡！", "提示信息");
                return;
            }
            if (yllb == "13")
            {
                if (splb != "6")
                {
                    this.cbx_splb.SelectedValue = "-1";
                    MessageBox.Show("医疗类别是慢性病，审批类别必须是慢性病！", "提示信息");
                    return;
                }
            }
            if (yllb == "15")
            {
                if (splb != "4")
                {
                    this.cbx_splb.SelectedValue = "-1";
                    MessageBox.Show("医疗类别是特殊病，审批类别必须是特殊病！", "提示信息");
                    return;
                }
            }
            if (splb == "16" && yllb == "13")
            {
                //调用人员已审批过的慢性病信息
                YBCJ_IN yw_in_dryyspgdmxbxx = new YBCJ_IN();
                yw_in_dryyspgdmxbxx.Yw = "BB31SPXX";
                yw_in_dryyspgdmxbxx.Ybcjbz = "1";
                if (mzybdk.Sfck == "1")
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
                        this.cbx_spbz.DisplayMember = "Text";
                        this.cbx_spbz.ValueMember = "Value";
                        this.cbx_spbz.DataSource = items;
                        this.cbx_spbz.SelectedValue = "-1";
                    }
                    else
                    {
                        MessageBox.Show("审批病种为空，不能慢性病收费！", "提示信息");
                        return;
                    }
                }
            }
            else if (splb == "17" || yllb == "15")
            {
                this.cbx_spbz.Text = "";
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("", "-1"));
                items.Add(new ListItem("复明工程白内障", "FMGCBNZ"));
                items.Add(new ListItem("恶性肿瘤放化疗(共用)", "TSB0000001"));
                items.Add(new ListItem("尿毒症透析(共用)", "TSB0000002"));
                items.Add(new ListItem("血友病(普通)", "TSB0000003"));
                items.Add(new ListItem("重症精神病(贫困救助)", "PKTSB0000001"));
                items.Add(new ListItem("白血病(贫困救助)", "PKTSB0000002"));
                items.Add(new ListItem("器官移植后使用抗排异药物(普通)", "TSB0000004"));
                this.cbx_spbz.DisplayMember = "Text";
                this.cbx_spbz.ValueMember = "Value";
                this.cbx_spbz.DataSource = items;
                this.cbx_spbz.SelectedValue = "-1";

            }
            this.lb_xx.Text = "请选择审批病种！";
            this.lb_xx.Visible = true;
        }
    }
}
