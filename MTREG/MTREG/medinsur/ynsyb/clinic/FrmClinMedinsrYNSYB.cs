using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.bll;
using System.Web.UI.WebControls;
using MTHIS.common;
using MTHIS.main.bll;


namespace MTREG.medinsur.ynsyb.clinic
{
    public partial class FrmClinMedinsrYNSYB : Form
    {
        public FrmClinMedinsrYNSYB()
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
        bool  flag ;

        public bool Flag
        {
          get { return flag; }
          set { flag = value; }
        }
        GetEmpInfo_out getEmpInfo_out;
        /// <summary>
        /// 个人信息
        /// </summary>
        internal GetEmpInfo_out GetEmpInfo_out
        {
            get { return getEmpInfo_out; }
            set { getEmpInfo_out = value; }
        }
        BllMedinsrYNSYB bllMedinsrYNSYB = new BllMedinsrYNSYB();
        /// <summary>
        /// 加载界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClinMedinsrYNSYB_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            dgvApproInfo.Visible = false;
            cmbApproType.Visible = false;
            //患者类型的初始化
            var dtp = bllMedinsrYNSYB.getPatientType();
            this.cmbPatientType.ValueMember = "Id";
            this.cmbPatientType.DisplayMember = "Name";
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = patientType;
            //审批类别
            List<ListItem> itemsApproType = new List<ListItem>();
            itemsApproType.Add(new ListItem("-1", ""));
            itemsApproType.Add(new ListItem("00", "慢性病、特殊病审批"));
            this.cmbApproType.DisplayMember = "Text";
            this.cmbApproType.ValueMember = "Value";
            this.cmbApproType.DataSource = itemsApproType;
            this.cmbApproType.SelectedValue = "-1";
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
            this.cmbHadGrbh .DisplayMember = "Text";
            this.cmbHadGrbh.ValueMember = "Value";
            this.cmbHadGrbh.DataSource = itemsHadGrbh;
            this.cmbHadGrbh.SelectedValue = "1";
            //医疗类别
            List<ListItem> itemMediType = new List<ListItem>();
            itemMediType.Add(new ListItem("普通门诊","11"));
            itemMediType.Add(new ListItem("特殊疾病门诊","12"));
            itemMediType.Add(new ListItem("门诊慢性病","13"));
            itemMediType.Add(new ListItem("急诊抢救","14"));
            itemMediType.Add(new ListItem("门诊大病","15"));
            //itemInsurType.Add(new ListItem("普通住院","21"));
            //itemInsurType.Add(new ListItem("转入(外)住院、转院","23"));
            //itemInsurType.Add(new ListItem("特殊疾病住院","26"));
            //itemInsurType.Add(new ListItem("特殊疾病转院","27"));
            this.cmbMediType.DisplayMember = "Text";
            this.cmbMediType.ValueMember = "Value";
            this.cmbMediType.DataSource = itemMediType;
        }
        private void dk()
        {
            GetEmpInfo_in getEmpInfo_in = new GetEmpInfo_in();
            if(cmbHasCard.SelectedValue.ToString() == "0")//有卡
            {
                getEmpInfo_in.Kzbz = "2";
                getEmpInfo_in.Grbh = "";
                getEmpInfo_in.Zh = this.tbxCode.Text.Trim();
            }else
            {
                    getEmpInfo_in.Kzbz = "1";
                    getEmpInfo_in.Zh = "";
                if(cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编码
                {
                    getEmpInfo_in.Grbh = this.tbxCode.Text.Trim();       
                }
                else 
                {
                    getEmpInfo_in.Grbh = "";
                }
            }
            
            
            int opt = ynsyb.getEmpInfo(getEmpInfo_in,getEmpInfo_out);
            if(opt!=0)
            {
                 MessageBox.Show(getEmpInfo_out.ErrorMessage+"，获取参保人员基本信息和医保相关参数信息失败！","提示信息");
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
            tbxIsBlock.Text = getEmpInfo_out.Fsbz +"|"+getEmpInfo_out.Fslx;//封锁标志|封锁类型
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
        /// <summary>
        /// 点击确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            getEmpInfo_out.MediType = cmbMediType.SelectedValue.ToString();
            if (cmbApproType.Visible == true)
            {
                getEmpInfo_out.ApproType = cmbApproType.SelectedValue.ToString();
            }
            else
            {
                getEmpInfo_out.ApproType = "";
            }
            getEmpInfo_out.ApproCode = tbxApproNum.Text.Trim();
            getEmpInfo_out.ApItemName = tbxApItemName.Text.Trim();
            getEmpInfo_out.ApItemCode = tbxApItemCode.Text.Trim();
            getEmpInfo_out.DiseaseName = tbxDiseaseName.Text.Trim();
            getEmpInfo_out.DiseaseCode = tbxDiseaseCode.Text.Trim();
        }
        /// <summary>
        /// 点击关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.flag = false;
        }
        /// <summary>
        /// 提取信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            dk();
        }

        private void cmbHasCard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCode.Visible = true;
            if(cmbHasCard.SelectedValue.ToString() == "0")//有卡
            {
                lblCode.Text = "医保卡号:";
            }
            else if(cmbHasCard.SelectedValue.ToString() == "1")//无卡
            {
                if(cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编号
                {
                    lblCode.Text = "个人编号:";
                }
                else if(cmbHadGrbh.SelectedValue.ToString() == "0")
                {
                    lblCode.Visible = false;
                }
            }
        }

        private void cmbHadGrbh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCode.Visible = true;
             if(cmbHasCard.SelectedValue.ToString() == "1")//无卡
             {
                  if(cmbHadGrbh.SelectedValue.ToString() == "1")//未获得个人编号
                  {
                     lblCode.Text = "个人编号:";
                  }
                  else if(cmbHadGrbh.SelectedValue.ToString() == "0")
                  {
                     lblCode.Visible = false;
                  }
             }
        }
        /// <summary>
        /// 审批类别改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbApproType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbMediType.SelectedValue.ToString() == "11")
            {
                return;
            }
            dgvApproInfo.Rows.Clear();
            Hdtgspxx_in hdtgspxx_in = new Hdtgspxx_in();
            Hdtgspxx_out hdtgspxx_out = new Hdtgspxx_out();
            hdtgspxx_in.Jylbdm = "03";
            hdtgspxx_in.Grbh = tbxPersonalNum.Text.Trim();
            hdtgspxx_in.Ddbh = ProgramGlobal.InsurHspCode;
            hdtgspxx_in.Splbdbm = "00";
            if (ynsyb.hdtgspxx(hdtgspxx_in, hdtgspxx_out) == 0)
            {
                string[] retdata = hdtgspxx_out.Spxx.Split('|');
                if (retdata[0].ToString() == "100")
                {
                    MessageBox.Show("没有查询到通过审批信息，不能按该医疗类别收费，请按普通门诊收费！", "提示信息");
                    return;
                }
                string[] approInfo = { "", "", "" };
                for (int i = 1; i < retdata.Length; i++)
                {
                    if (retdata[i].ToString() == "X")
                    {
                        break;
                    }
                    if ((i - 1) % 3 == 0)
                    {
                        approInfo = new string[] { retdata[i].ToString(), retdata[i + 1].ToString(), retdata[i + 2].ToString() };
                        dgvApproInfo.Rows.Add(approInfo);
                        i = i + 2;
                    }
                }
                dgvApproInfo.Visible = true;
            }
            else
            {
                MessageBox.Show(hdtgspxx_out.ErrorMessage + "读取审批信息失败","提示信息");
                return;
            }
        }
        /// <summary>
        /// 医疗类别改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMediType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cmbApproType.Text = "";
            if (cmbMediType.SelectedValue.ToString() == "11")
            {
                this.cmbApproType.SelectedValue = "-1";
                this.cmbApproType.Visible = false;
                this.tbxApproNum.Text = "";
                this.tbxApItemCode.Text = "";
                this.tbxApItemName.Text = "";
            }
            else
            {
                this.cmbApproType.Visible = true;
            }
            if(cmbMediType.SelectedValue == null || cmbMediType.SelectedValue.ToString() =="11")
            {
                this.lblMsg.Visible = false;
                return;
            }
            string grbh = this.tbxPersonalNum.Text.Trim();
            if (grbh == null || grbh == "")
            {
                MessageBox.Show("请先读卡！","提示信息");
                return;
            }
            if(cmbMediType.SelectedValue.ToString() == "13"||cmbMediType.SelectedValue.ToString() == "14"||cmbMediType.SelectedValue.ToString() == "15"||cmbMediType.SelectedValue.ToString() == "19")
            {
                 this.lblMsg.Text = "请选择审批类别！";
                 this.lblMsg.Visible = true;
            }
            else 
            {
                 lblMsg.Visible = false;
            }
        }

        private void dgvApproInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvApproInfo.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvApproInfo.CurrentRow != null)
                {
                    DataTable dt = (DataTable)dgvApproInfo.DataSource;
                    string name = dt.Rows[dgvApproInfo.CurrentRow.Index]["name"].ToString().Trim();
                    string code = dt.Rows[dgvApproInfo.CurrentRow.Index]["code"].ToString().Trim();
                    tbxDiseaseName.Text = name;
                    tbxDiseaseCode.Text = code;
                    dgvApproInfo.Visible = false;
                    dgvApproInfo.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvApproInfo.CurrentRow != null && dgvApproInfo.CurrentRow.Index > 0)
                {
                    dgvApproInfo.Rows[dgvApproInfo.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvApproInfo.CurrentRow != null && dgvApproInfo.CurrentRow.Index < dgvApproInfo.Rows.Count - 1)
                {
                    dgvApproInfo.Rows[dgvApproInfo.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void dgvApproInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataTable dt = (DataTable)dgvApproInfo.DataSource;
                string name = dt.Rows[e.RowIndex]["name"].ToString().Trim();
                tbxDiseaseName.Text = name;
                tbxDiseaseCode.Text = dt.Rows[e.RowIndex]["code"].ToString().Trim();
                tbxDiseaseName.Focus();
                dgvApproInfo.Visible = false;
            }
        }

        private void tbxDiseaseName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbxDiseaseName.SelectAll();
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            dgvApproInfo.DataSource = this.bllMedinsrYNSYB.getDiagnInfo(pincode);
            this.dgvApproInfo.Columns["code"].HeaderText = "编码";
            this.dgvApproInfo.Columns["code"].Width = 130;
            this.dgvApproInfo.Columns["name"].HeaderText = "名称";
            this.dgvApproInfo.Columns["name"].Width = 161;
            this.dgvApproInfo.Columns["bre_code"].HeaderText = "简码";
            this.dgvApproInfo.Columns["bre_code"].Width = 100;
        }
        private void tbxDiseaseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dgvApproInfo.Visible = true;
                setDgvSource(tbxDiseaseName.Text);
                dgvApproInfo.Rows[0].Selected = true;
                dgvApproInfo.Focus();
            }
        }
    }
}
