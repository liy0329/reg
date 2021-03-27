using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.ynsyb.bll;
using MTREG.medinsur.ynsyb.bo;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.ynsyb.ihsp.bll;

namespace MTREG.medinsur.ynsyb.ihsp
{
    public partial class FrmOutHspMedinsrYNSYB : Form
    {
        public FrmOutHspMedinsrYNSYB()
        {
            InitializeComponent();
        }
        YNSYB ynsyb = new YNSYB();
        private string patientType;

        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private string ihsp_id;

        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string ihspCode;
        /// <summary>
        /// 住院号
        /// </summary>
        public string IhspCode
        {
            get { return ihspCode; }
            set { ihspCode = value; }
        }
        GetEmpInfo_out getEmpInfo_out;
        BllMedinsrYNSYB bllMedinsrYNSYB = new BllMedinsrYNSYB();
        /// <summary>
        /// 个人信息
        /// </summary>
        internal GetEmpInfo_out GetEmpInfo_out
        {
            get { return getEmpInfo_out; }
            set { getEmpInfo_out = value; }
        }
        private void FrmOutHspMedinsrYNSYB_Load(object sender, EventArgs e)
        {
            //患者类型的初始化
            var dtp = bllMedinsrYNSYB.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = patientType;
            //是否有卡
            List<ListItem> itemsHasCard = new List<ListItem>();
            itemsHasCard.Add(new ListItem("有卡", "0"));
            itemsHasCard.Add(new ListItem("无卡", "1"));
            this.cmbHasCard.DisplayMember = "Text";
            this.cmbHasCard.ValueMember = "Value";
            this.cmbHasCard.DataSource = itemsHasCard;
            this.cmbHasCard.SelectedValue = "0";
            //是否已获得个人编号
            List<ListItem> itemsHadGrbh = new List<ListItem>();
            itemsHadGrbh.Add(new ListItem("已获得个人编号", "0"));
            itemsHadGrbh.Add(new ListItem("未获得个人编号", "1"));
            this.cmbHadGrbh.DisplayMember = "Text";
            this.cmbHadGrbh.ValueMember = "Value";
            this.cmbHadGrbh.DataSource = itemsHadGrbh;
            this.cmbHadGrbh.SelectedValue = "1";
            //医疗类别
            List<ListItem> itemMediType = new List<ListItem>();
            itemMediType.Add(new ListItem("普通门诊", "11"));
            itemMediType.Add(new ListItem("特殊疾病门诊", "12"));
            itemMediType.Add(new ListItem("门诊慢性病", "13"));
            itemMediType.Add(new ListItem("急诊抢救", "14"));
            itemMediType.Add(new ListItem("门诊大病", "15"));
            itemMediType.Add(new ListItem("普通住院","21"));
            itemMediType.Add(new ListItem("转入(外)住院、转院","23"));
            itemMediType.Add(new ListItem("特殊疾病住院","26"));
            itemMediType.Add(new ListItem("特殊疾病转院","27"));
            this.cmbMediType.DisplayMember = "Text";
            this.cmbMediType.ValueMember = "Value";
            this.cmbMediType.DataSource = itemMediType;
        }
        private void dk()
        {
            GetEmpInfo_in getEmpInfo_in = new GetEmpInfo_in();
            if (cmbHasCard.SelectedValue.ToString() == "0")//有卡
            {
                getEmpInfo_in.Kzbz = "2";
                getEmpInfo_in.Grbh = "";
                getEmpInfo_in.Zh = this.tbxCode.Text.Trim();
            }
            else
            {
                getEmpInfo_in.Kzbz = "1";
                getEmpInfo_in.Zh = "";
                if (cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编码
                {
                    getEmpInfo_in.Grbh = this.tbxCode.Text.Trim();
                }
                else
                {
                    getEmpInfo_in.Grbh = "";
                }
            }


            int opt = ynsyb.getEmpInfo(getEmpInfo_in, getEmpInfo_out);
            if (opt != 0)
            {
                MessageBox.Show(getEmpInfo_out.ErrorMessage + "，获取参保人员基本信息和医保相关参数信息失败！", "提示信息");
                this.flag = false;
                return;
            }
            tbxName.Text = getEmpInfo_out.Xm;
            tbxSex.Text = getEmpInfo_out.Xb;
            tbxIDCard.Text = getEmpInfo_out.Sfzh;
            dtpBirth.Text = getEmpInfo_out.Csrq;
            tbxCompanyName.Text = getEmpInfo_out.Dwmc;
            tbxCompanyNum.Text = getEmpInfo_out.Dwbh;
            tbxPersonalNum.Text = getEmpInfo_out.Grbh;//个人编号
            tbxICCardID.Text = getEmpInfo_out.Kh;//医保卡号
            tbxBalance.Text = getEmpInfo_out.Zhye;//账户余额
            tbxIsBlock.Text = getEmpInfo_out.Fsbz + "|" + getEmpInfo_out.Fslx;//封锁标志|封锁类型
            string rylbbm = getEmpInfo_out.Rylbbm;//人员类别编码
            string rylbmc = getEmpInfo_out.Rylbmc;//人员类别名称
            string ctqh = getEmpInfo_out.Tcqh;//统筹区号
            string qybh = getEmpInfo_out.Qybh;//区域编号
            string zgjmbz = getEmpInfo_out.Zgjmbz;//职工居民标志
            string ybcsmc1 = getEmpInfo_out.Ybcsmc1;//医保参数名称1
            string ybcsmc2 = getEmpInfo_out.Ybcsmc2;//医保参数名称2
            string ybcsmc3 = getEmpInfo_out.Ybcsmc3;//医保参数名称3
            string ybcsmc4 = getEmpInfo_out.Ybcsmc4;//医保参数名称4
            string ybcsmc5 = getEmpInfo_out.Ybcsmc5;//医保参数名称5
            string ybcsmc6 = getEmpInfo_out.Ybcsmc6;//医保参数名称6
            string ybcs1z = getEmpInfo_out.Ybcsz1;//医保参数值1
            string ybcs2z = getEmpInfo_out.Ybcsz2;
            string ybcs3z = getEmpInfo_out.Ybcsz3;
            string ybcs4z = getEmpInfo_out.Ybcsz4;
            string ybcs5z = getEmpInfo_out.Ybcsz5;
            string ybcs6z = getEmpInfo_out.Ybcsz6;
            this.flag = true;
            lblSuccess.Text = "读卡成功！";
            this.flag = true;
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            dk();
        }

        private void cmbHasCard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCode.Visible = true;
            if (cmbHasCard.SelectedValue.ToString() == "0")//有卡
            {
                lblCode.Text = "医保卡号:";
            }
            else if (cmbHasCard.SelectedValue.ToString() == "1")//无卡
            {
                if (cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编号
                {
                    lblCode.Text = "个人编号:";
                }
                else if (cmbHadGrbh.SelectedValue.ToString() == "0")
                {
                    lblCode.Visible = false;
                }
            }
        }

        private void cmbHadGrbh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCode.Visible = true;
            if (cmbHasCard.SelectedValue.ToString() == "1")//无卡
            {
                if (cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编号
                {
                    lblCode.Text = "个人编号:";
                }
                else if (cmbHadGrbh.SelectedValue.ToString() == "0")
                {
                    lblCode.Visible = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.flag = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.flag == false)
                return;
            getEmpInfo_out.MediType = cmbMediType.SelectedValue.ToString();
            //预结算
            BllIhspInsurYNSYB bllIhspInsurYNSYB = new BllIhspInsurYNSYB();
            int ops = bllIhspInsurYNSYB.preSettle(getEmpInfo_out,ihspCode,ihsp_id);
            if (ops != 0)
            {
                this.flag = false;
            }
        }
    }
}
