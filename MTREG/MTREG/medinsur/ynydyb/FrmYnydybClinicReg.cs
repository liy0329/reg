using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using System.Web.UI.WebControls;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using MTREG.ihsp.bll;
using MTREG.clinic;

namespace MTREG.medinsur.ynydyb
{
    public partial class FrmYnydybClinicReg : Form
    {
        YnydybRegInfo ynydybRegInfo = new YnydybRegInfo();
        /// <summary>
        /// 云南异地医保信息
        /// </summary>
        internal YnydybRegInfo YnydybRegInfo
        {
            get { return ynydybRegInfo; }
            set { ynydybRegInfo = value; }
        }
        /// <summary>
        /// 门诊疾病id
        /// </summary>
        string clinic_caseicd_id;

        private string patienttype;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }
        public FrmYnydybClinicReg()
        {
            InitializeComponent();
        }

        private void FrmYnydybClinicReg_Load(object sender, EventArgs e)
        {
            init_kms();
            init_sftzb();
            initYllb();
            initSplb();
            init_rqlb();//人群类别
            init_jydlb();
            init_xb();//
        }
        public void init_xb()
        {
            //性别初始化
            List<ListItem> items_xb = new List<ListItem>();
            items_xb.Add(new ListItem("0", ""));
            items_xb.Add(new ListItem("1", "男"));
            items_xb.Add(new ListItem("2", "女"));
            items_xb.Add(new ListItem("9", "未说明性别"));

            this.Zydk_Xb.DisplayMember = "Text";
            this.Zydk_Xb.ValueMember = "Value";
            this.Zydk_Xb.DataSource = items_xb;
            Zydk_Xb.SelectedValue = "0";
        }

        public void init_jydlb()
        {
            //就医地类别初始化
            List<ListItem> items_jydlb = new List<ListItem>();
            items_jydlb.Add(new ListItem("0", ""));
            items_jydlb.Add(new ListItem("1", "本地就医"));
            items_jydlb.Add(new ListItem("2", "异地就医"));
            //items_jydlb.Add(new ListItem("3", "其它"));

            this.Zydk_Jydlb.DisplayMember = "Text";
            this.Zydk_Jydlb.ValueMember = "Value";
            this.Zydk_Jydlb.DataSource = items_jydlb;
            Zydk_Jydlb.SelectedValue = "0";
        }

        public void init_rqlb()
        {
            //人群类别初始化
            List<ListItem> items_rqlb = new List<ListItem>();
            items_rqlb.Add(new ListItem("0", ""));
            items_rqlb.Add(new ListItem("1", "城镇职工"));
            items_rqlb.Add(new ListItem("2", "城镇居民"));
            items_rqlb.Add(new ListItem("3", "离休"));
            //items_rqlb.Add(new ListItem("4", "其它"));
            this.Zydk_Rqlb.DisplayMember = "Text";
            this.Zydk_Rqlb.ValueMember = "Value";
            this.Zydk_Rqlb.DataSource = items_rqlb;
            Zydk_Rqlb.SelectedValue = "0";
        }
        private void init_sftzb()
        {
            List<ListItem> items_sftzb = new List<ListItem>();
            items_sftzb.Add(new ListItem("0", "否"));
            items_sftzb.Add(new ListItem("1", "是"));
            this.ZySftzb.DisplayMember = "Text";
            this.ZySftzb.ValueMember = "Value";
            this.ZySftzb.DataSource = items_sftzb;
            this.ZySftzb.SelectedValue = "0";
        }
        private void init_kms()
        {
            //卡模式初始化
            List<ListItem> items_kms = new List<ListItem>();
            items_kms.Add(new ListItem("0", "医保IC卡"));
            items_kms.Add(new ListItem("1", "医保磁卡"));
            items_kms.Add(new ListItem("3", "医保证"));
            this.ZyKms.DisplayMember = "Text";
            this.ZyKms.ValueMember = "Value";
            this.ZyKms.DataSource = items_kms;
            this.ZyKms.SelectedValue = "0";
        }
        private void initYllb()
        {
            //医疗类别初始化
            List<ListItem> items_yllb = new List<ListItem>();
            items_yllb.Add(new ListItem("21", "普通住院"));
            items_yllb.Add(new ListItem("22", "特殊病种住院"));
            items_yllb.Add(new ListItem("23", "转外诊治住院"));
            items_yllb.Add(new ListItem("24", "病种包干住院"));
            items_yllb.Add(new ListItem("31", "家庭病床"));

            //items_yllb.Add(new ListItem("21", "普通住院"));
            //items_yllb.Add(new ListItem("22", "家庭病床"));
            //items_yllb.Add(new ListItem("23", "转入住院"));
            //items_yllb.Add(new ListItem("24", "包干病种住院"));
            //items_yllb.Add(new ListItem("25", "重特大疾病"));
            //items_yllb.Add(new ListItem("26", "特殊慢性病住院"));
            //items_yllb.Add(new ListItem("27", "死亡结算"));
            //items_yllb.Add(new ListItem("29", "转院出院普通住院"));
            //items_yllb.Add(new ListItem("16", "生育保险住院（居民）"));

            this.ZyYllb.DisplayMember = "Text";
            this.ZyYllb.ValueMember = "Value";
            this.ZyYllb.DataSource = items_yllb;
        }
        private void initSplb()
        {
            List<ListItem> items_splb = new List<ListItem>();
            items_splb.Add(new ListItem("-1", ""));
            items_splb.Add(new ListItem("7", "精神病住院审批"));
            //items_splb.Add(new ListItem("22", "家庭病床"));
            //items_splb.Add(new ListItem("23", "转入住院"));
            //items_splb.Add(new ListItem("24", "包干病种住院"));
            //items_splb.Add(new ListItem("25", "重特大疾病"));
            //items_splb.Add(new ListItem("26", "特殊慢性病住院"));
            //items_splb.Add(new ListItem("27", "死亡结算"));
            //items_splb.Add(new ListItem("29", "转院出院普通住院"));
            //items_splb.Add(new ListItem("16", "生育保险住院（居民）"));

            this.ZySplb.DisplayMember = "Text";
            this.ZySplb.ValueMember = "Value";
            this.ZySplb.DataSource = items_splb;
            this.ZySplb.SelectedValue = "-1";
        }
        /// <summary>
        /// 读卡
        /// </summary>
        private void readCard()
        {
            //获取异地医保持卡人的个人基本信息和账户信息
            Dkcx_out dkcx_out1 = new Dkcx_out();
            YNYDYB ynydyb = new YNYDYB();
            int opt_dkcx = ynydyb.dkcx(dkcx_out1);
            if (opt_dkcx != 0)
            {
                MessageBox.Show(dkcx_out1.ErrorMessage + ", 获取异地医保持卡人的个人基本信息和账户信息失败！", "提示信息");
                return;
            }
            this.Zydk_Xm.Text = dkcx_out1.Xm;//姓名
            this.Zydk_Ybkh.Text = dkcx_out1.Ybkh;//医保卡号
            this.Zydk_Grbm.Text = dkcx_out1.Grbm;//个人编码
            this.Zydk_Cbdtcqbm.Text = dkcx_out1.Cbdtcqbm;//参保地统筹区编码
            this.Zydk_Ylrylb.SelectedValue = dkcx_out1.Ylrylb;//医疗人员类别
            this.Zydk_Sfzh.Text = dkcx_out1.Sfzh;//身份证号
            this.Zydk_Xb.SelectedValue = dkcx_out1.Xb;//性别
            this.Zydk_Sznl.Text = dkcx_out1.Sznl;//实足年龄
            this.Zydk_Rqlb.SelectedValue = dkcx_out1.Rqlb;//人群类别
            this.Zydk_Csrq.Text = dkcx_out1.Csrq;//出生日期
            this.Zydk_Jydtcqbm.Text = dkcx_out1.Jydtcqbm;//就医地统筹区编码
            this.Zydk_Dwmc.Text = dkcx_out1.Dwmc;//单位名称
            this.Zydk_Dwbm.Text = dkcx_out1.Dwbm;//单位编码 
            this.Zydk_Zhye.Text = dkcx_out1.Zhye;//帐户余额
            this.Zydk_Jydlb.SelectedValue = dkcx_out1.Jydlb;//就医地类别
            this.Zydk_Cbdfzxbh.Text = dkcx_out1.Cbdfzxbh;//参保地分中心编号
            this.Zydk_Jydfzxbh.Text = dkcx_out1.Jydfzxbh;//就医地分中心编号
            this.tbx_ybcs1mc.Text = dkcx_out1.Ybcsmc1;
            this.tbx_ybcs2mc.Text = dkcx_out1.Ybcsmc2;
            this.tbx_ybcs3mc.Text = dkcx_out1.Ybcsmc3;
            this.tbx_ybcs4mc.Text = dkcx_out1.Ybcsmc4;
            this.tbx_ybcs5mc.Text = dkcx_out1.Ybcsmc5;
            this.tbx_ybcs6mc.Text = dkcx_out1.Ybcsmc6;
            this.tbx_ybcs1z.Text = dkcx_out1.Ybcsz1;
            this.tbx_ybcs2z.Text = dkcx_out1.Ybcsz2;
            this.tbx_ybcs3z.Text = dkcx_out1.Ybcsz3;
            this.tbx_ybcs4z.Text = dkcx_out1.Ybcsz4;
            this.tbx_ybcs5z.Text = dkcx_out1.Ybcsz5;
            this.tbx_ybcs6z.Text = dkcx_out1.Ybcsz6;
        }

        /// <summary>
        /// 确定后传参
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            clinicReg();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 门诊挂号
        /// </summary>
        public void clinicReg()
        {
            YnydybRegInfo.Kms = ZyKms.SelectedValue.ToString();
            YnydybRegInfo.Sftzb = ZySftzb.SelectedValue.ToString();
            YnydybRegInfo.Spbh = ZySpbh.Text;
            YnydybRegInfo.Yllb = ZyYllb.SelectedValue.ToString();
            YnydybRegInfo.Hzlxr = ZyHzlxr.Text;
            YnydybRegInfo.Hzlxdh = ZyHzlxdh.Text;
            YnydybRegInfo.Name = Zydk_Xm.Text;
            YnydybRegInfo.Grbh = Zydk_Grbm.Text;
            YnydybRegInfo.InsuredAreaNo = Zydk_Cbdtcqbm.Text;
            YnydybRegInfo.Hzybkh = Zydk_Ybkh.Text;
            YnydybRegInfo.Sex = Zydk_Xb.SelectedValue.ToString();
            YnydybRegInfo.Rqlb = Zydk_Rqlb.SelectedValue.ToString();
            YnydybRegInfo.Ylrylb = Zydk_Ylrylb.SelectedValue.ToString();
            YnydybRegInfo.Jydlb = Zydk_Jydlb.SelectedValue.ToString();
            YnydybRegInfo.Jydtcqbm = Zydk_Cbdtcqbm.Text;
            YnydybRegInfo.Cbdfzxbh = Zydk_Cbdfzxbh.Text;
            YnydybRegInfo.Jydfzxbh = Zydk_Jydfzxbh.Text;
            YnydybRegInfo.IcdCode = tbxClinicicd.Text;
            YnydybRegInfo.Icdname = tbxClinicdiagn.Text;
        }

        private void Jzryjbmc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(tbxClinicdiagn.Text))
                {
                    dgvClinicCase.Visible = true;
                    setClinicSource(this.tbxClinicdiagn.Text);
                    dgvClinicCase.Rows[0].Selected = true;
                    dgvClinicCase.Focus();
                }
            }
        }

        private void dgvClinicCase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClinicCase.CurrentRow != null)
            {
                this.tbxClinicdiagn.Text = dgvClinicCase.CurrentRow.Cells["name"].Value.ToString();
                this.tbxClinicicd.Text = dgvClinicCase.CurrentRow.Cells["icd10"].Value.ToString();
                this.clinic_caseicd_id = dgvClinicCase.CurrentRow.Cells["id"].Value.ToString();
                dgvClinicCase.Visible = false;
                dgvClinicCase.Columns.Clear();
            }
        }
        /// <summary>
        /// 简码选择dgv赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setClinicSource(string pincode)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dt = billCmbList.regCase(pincode);
            dgvClinicCase.DataSource = dt;
            this.dgvClinicCase.Columns["id"].HeaderText = "id";
            this.dgvClinicCase.Columns["id"].Visible = false;
            this.dgvClinicCase.Columns["icd10"].HeaderText = "icd10";
            this.dgvClinicCase.Columns["icd10"].Visible = false;
            this.dgvClinicCase.Columns["name"].HeaderText = "名称";
            this.dgvClinicCase.Columns["name"].Width = 161;
            dgvClinicCase.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
