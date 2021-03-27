using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdssy.bll;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;

namespace MTREG.medinsur.hdssy
{
    public partial class FrmInHspMedinsrHDSSY : Form
    {
        FrmIhspReg frmIhspReg;
        BillCmbList billCmbList = new BillCmbList();
        BllInHspMedinsrHDSSY bllInHspMedinsrHDSSY = new BllInHspMedinsrHDSSY();
        Ybjk ybjk = new Ybjk();
        Dryjbxxhzh_out dryjbxxhzh_out = new Dryjbxxhzh_out();
        Dqdwfsxxsy_out dqdwfsxxsy_out = new Dqdwfsxxsy_out();
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }
        private string patientType;
        /// <summary>
        /// 患者类型
        /// </summary>
        public string PatientType
        {
            get { return patientType; }
            set { patientType = value; }
        }
        public FrmInHspMedinsrHDSSY()
        {
            InitializeComponent();
        }

        private void FrmInHspMedinsrHDSSY_Load(object sender, EventArgs e)
        {
            tbxIhspicd.ReadOnly = true;
            dgvIhspdiagn.Visible = false;
            #region 患者类型  医疗类别
            this.cmbPatientType.ValueMember = "id";
            this.cmbPatientType.DisplayMember = "name";
            var dtp = billCmbList.patientTypeList();
            this.cmbPatientType.DataSource = dtp;
            cmbPatientType.SelectedValue = PatientType;
            cmbPatientType.Enabled = false;

            DataTable dta = bllInHspMedinsrHDSSY.aka130();
            this.cmbYllb.ValueMember = "id";
            this.cmbYllb.DisplayMember = "name";
            this.cmbYllb.DataSource = dta;
            #endregion
            
            hdsyb();
        }

        /// <summary>
        /// 读邯郸市医保信息
        /// </summary>
        private void hdsyb()
        {
            FormCollection fmCollection = System.Windows.Forms.Application.OpenForms;
            int flag = ybjk.dryjbxxzhxx(dryjbxxhzh_out);
            if (flag < 0)
            {
                MessageBox.Show("读人员基本信息和账户信息失败!");
                return;
            }
            //判断住院状态
            if (dryjbxxhzh_out.Zyzt == "住院未结算" || dryjbxxhzh_out.Zyzt == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行住院登记操作！", "提示信息");
                this.Close();
                fmCollection["FrmIhspReg"].Close();
            }

            //封锁状态
            int isblock = ybjk.dqdwfsxx_sy(dryjbxxhzh_out.Grbh, dqdwfsxxsy_out);
            if (isblock != 0)
            {
                MessageBox.Show(dqdwfsxxsy_out.Message + ", 读医保API人员帐户封锁信息失败！", "提示信息");
                this.Close();
            }
            int fsjb = int.Parse(dqdwfsxxsy_out.Fsjb.ToString());
            if (fsjb == 1)
            {
                DialogResult dialogresult = MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付,请先进行医保转自费后按自费进行结算!", "提示信息", MessageBoxButtons.OK);
                if (dialogresult == DialogResult.OK)
                {
                    this.Close();
                    fmCollection["FrmIhspReg"].Close();
                }

            }
            if (fsjb == 2)
            {
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                this.Close();
                fmCollection["FrmIhspReg"].Close();
            }
            if (fsjb == 0)
            {
                this.tbxIsBlock.Text = "不锁";
            }

            if (dryjbxxhzh_out.Csrq != "" && dryjbxxhzh_out.Csrq != null)
            {
                try
                {
                    string year = dryjbxxhzh_out.Csrq.Substring(0, 4);
                    string moths = dryjbxxhzh_out.Csrq.Substring(4, 2);
                    string dys = dryjbxxhzh_out.Csrq.Substring(6, 2);
                    string sj = year + "-" + moths + "-" + dys;
                    dryjbxxhzh_out.Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                    this.dtpBirth.Value = Convert.ToDateTime(dryjbxxhzh_out.Csrq);
                }
                catch (Exception ex) { }
            }

            string lnjz_s = dryjbxxhzh_out.ZhLnjz;
            double lnjz = 0;
            if (lnjz_s != null && lnjz_s != "")
                lnjz = double.Parse(lnjz_s);
            string bnzr_s = dryjbxxhzh_out.ZhBnzr;
            double bnzr = 0;
            if (bnzr_s != null && bnzr_s != "")
                bnzr = double.Parse(bnzr_s);
            string zhzc_s = dryjbxxhzh_out.ZhZhzc;
            double zhzc = 0;
            if (zhzc_s != null && zhzc_s != "")
                zhzc = double.Parse(zhzc_s);
            string zhye = (lnjz + bnzr - zhzc).ToString();
            this.tbxBalance.Text = zhye;//账户余额
            tbxCompanyName.Text = dryjbxxhzh_out.Dwmc;
            tbxCompanyNum.Text = dryjbxxhzh_out.Dwbh;
            tbxICCardID.Text = dryjbxxhzh_out.Ickh;
            tbxIDCard.Text = dryjbxxhzh_out.Sfzh;
            tbxName.Text = dryjbxxhzh_out.Xm;
            tbxPersonalNum.Text = dryjbxxhzh_out.Grbh;
            tbxSex.Text = dryjbxxhzh_out.Xb;
        }

        private void tbxIhspdiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dgvIhspdiagn.Visible = true;
                setDgvSource(tbxIhspdiagn.Text);
                dgvIhspdiagn.Rows[0].Selected = true;
                dgvIhspdiagn.Focus();
            }
        }
        /// <summary>
        /// dgvIhspdiagn赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setDgvSource(string pincode)
        {
            dgvIhspdiagn.DataSource = bllInHspMedinsrHDSSY.ihspdiagn(pincode);
            this.dgvIhspdiagn.Columns["id"].HeaderText = "id";
            this.dgvIhspdiagn.Columns["id"].Visible = false;
            this.dgvIhspdiagn.Columns["name"].HeaderText = "名称";
            this.dgvIhspdiagn.Columns["name"].Width = 161;
            this.dgvIhspdiagn.Columns["illcode"].HeaderText = "illcode";
            this.dgvIhspdiagn.Columns["illcode"].Visible = false;
        }

        private void dgvIhspdiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvIhspdiagn.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvIhspdiagn.CurrentRow != null)
                {
                    tbxIhspdiagn.Text = dgvIhspdiagn.SelectedRows[0].Cells["name"].Value.ToString();
                    tbxIhspicd.Text = dgvIhspdiagn.SelectedRows[0].Cells["illcode"].Value.ToString();
                    dgvIhspdiagn.Visible = false;
                    dgvIhspdiagn.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvIhspdiagn.CurrentRow != null && dgvIhspdiagn.CurrentRow.Index > 0)
                {
                    dgvIhspdiagn.Rows[dgvIhspdiagn.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvIhspdiagn.CurrentRow != null && dgvIhspdiagn.CurrentRow.Index < dgvIhspdiagn.Rows.Count - 1)
                {
                    dgvIhspdiagn.Rows[dgvIhspdiagn.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.FrmIhspReg.InsurInfo.PatientType = cmbPatientType.SelectedValue.ToString();
            this.FrmIhspReg.InsurInfo.Balance = tbxBalance.Text;
            this.FrmIhspReg.InsurInfo.Companyname = tbxCompanyName.Text;
            this.FrmIhspReg.InsurInfo.Companynum = tbxCompanyNum.Text;
            this.FrmIhspReg.InsurInfo.Iccardid = tbxICCardID.Text;
            this.FrmIhspReg.InsurInfo.Idcard = tbxIDCard.Text;
            this.FrmIhspReg.InsurInfo.Isblock = tbxIsBlock.Text;
            this.FrmIhspReg.InsurInfo.Name = tbxName.Text;
            this.FrmIhspReg.InsurInfo.PersonalNum = tbxPersonalNum.Text;
            this.FrmIhspReg.InsurInfo.Sex = tbxSex.Text;
            this.FrmIhspReg.InsurInfo.Ihspdiagn = tbxIhspdiagn.Text;
            this.FrmIhspReg.InsurInfo.Ihspicd = tbxIhspicd.Text;
            this.FrmIhspReg.InsurInfo.Birth = dtpBirth.Value.ToString();
            this.FrmIhspReg.InsurInfo.Ihsptype = cmbYllb.SelectedValue.ToString();
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
            string insurinfo = tbxPersonalNum.Text + "|" + tbxICCardID.Text + "|" + tbxIhspdiagn.Text + "|" + tbxIhspicd.Text + "|" + cmbYllb.SelectedValue.ToString() + "|" + tbxBalance.Text + "|" + tbxCompanyNum.Text + "|" + tbxIsBlock.Text;
            this.FrmIhspReg.Registinfo = insurinfo;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
