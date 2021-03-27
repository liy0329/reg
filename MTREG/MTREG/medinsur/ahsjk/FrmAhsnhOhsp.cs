using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bll;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.ihsp;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bo;
using MTREG.medinsur.bll;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmAhsnhOhsp : Form
    {
        BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
        FrmIhspAccount frmIhspAccount;
        /// <summary>
        /// 结算界面
        /// </summary>
        public FrmIhspAccount FrmIhspAccount
        {
            get { return frmIhspAccount; }
            set { frmIhspAccount = value; }
        }
        public FrmAhsnhOhsp()
        {
            InitializeComponent();
        }
        private string ihspid;
        /// <summary>
        /// 住院号id
        /// </summary>
        public string Ihspid
        {
            get { return ihspid; }
            set { ihspid = value; }
        }
        private string allInCost;
        /// <summary>
        /// HIS住院发生总费用
        /// </summary>
        public string AllInCost
        {
            get { return allInCost; }
            set { allInCost = value; }
        }
        /// <summary>
        /// 下载结算类型
        /// </summary>
        public void initJslx()
        {
            In_DownCalType inp = new In_DownCalType();
            RegInfo reginfo = bllAhsnhMethod.readRegInfo(ihspid);
            //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
            inp.SAreaCode = reginfo.SAreaCode;
            inp.Weburl = reginfo.Weburl;
            inp.SHospitalCode = reginfo.SHospitalCode;
            retMesage ret= bllAhsnhMethod.downCalType(inp);
            this.cmbCalcCode.DisplayMember = "sName";
            this.cmbCalcCode.ValueMember = "sCode";
            cmbCalcCode.DataSource = ret.Ret_data;
        }

        /// <summary>
        /// 试算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExtract_Click(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();            
            /* 调用WebService实现代码 begin */
            In_InpatientTryCalculate inp = new In_InpatientTryCalculate();
            RegInfo reginfo = bllAhsnhMethod.readRegInfo(ihspid);
            //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
            inp.SAreaCode = reginfo.SAreaCode;
            inp.SInpatientID = reginfo.SInpatientID;
            inp.Weburl = reginfo.Weburl;
            inp.SHospitalCode = reginfo.SHospitalCode;
            inp.SCalcCode = this.cmbCalcCode.SelectedValue.ToString();
            inp.SAllInCost = tbxAllInCost.Text;
            //初始化inp输入参数 end
            retMesage ret = bllAhsnhMethod.inpatientTryCalculate(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show("预结算失败[" + ret.Ret_mesg + "], 提示信息");
                return;
            }
            Out_InpatientTryCalculate oEntity = (Out_InpatientTryCalculate)ret.Ret_data[0];
            this.tbx_ylfzje.Text = oEntity.SAllInCost;//医疗总费用
            this.tbx_jjzf.Text = oEntity.SFund;//基金支付
            this.tbx_xjzf.Text = (Convert.ToDouble(oEntity.SAllInCost)
                - Convert.ToDouble(oEntity.SFund)
                - Convert.ToDouble(oEntity.SAccount)
                - (Convert.ToDouble(oEntity.SHospialAssume))).ToString();   
            this.tbx_grzf.Text = oEntity.SOwnCost;
            this.tbx_qfje.Text = oEntity.SBegin;
            this.tbx_zhzf.Text = oEntity.SAccount;//账户支付
            this.tbx_bndjjljzf.Text = oEntity.SSumFund;
            this.tbx_bczfqzhye.Text = oEntity.SAccountBegin;
            this.tbx_kbxzje.Text = oEntity.SAllApply;//可报销总金额
            this.tbx_bczfhzhye.Text = oEntity.SAccountAfter;
            this.tbx_zfje.Text = oEntity.SSelfCost;
            this.tbx_yljgcdfy.Text = oEntity.SHospialAssume;
            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            bllInsurMethod.upInsurinfoFee(ihspid,oEntity.SCMeASum,oEntity.SPatientAssume);
            MessageBox.Show("预结算成功，返回帐户支付金额，下一步请点确定按钮！");

        }

        private void FrmAhsnhOhsp_Load(object sender, EventArgs e)
        {
            initJslx();
            tbxAllInCost.Text = allInCost;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.FrmIhspAccount.CalcCode = cmbCalcCode.SelectedValue.ToString();
        }
    }
 }
