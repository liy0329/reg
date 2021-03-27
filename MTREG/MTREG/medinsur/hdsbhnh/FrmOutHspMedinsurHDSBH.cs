using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.medinsur.bll;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmOutHspMedinsurHDSBH : Form
    {
        BillIhspcost billIhspcost = new BillIhspcost();
        Header header = new Header();
        string patienttype;

        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }

        string ihspid;

        public FrmOutHspMedinsurHDSBH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="ihspid"></param>
        /// <param name="invoice"></param>
        public void getsource(string ihsp_id,string invoice)
        {
            this.ihspid = ihsp_id;
            BllSnhMethod bllSnhMethod = new BllSnhMethod();
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码|经办人
            HdsbhRegInfo hdsbhRegInfo = bllSnhMethod.readRegInfo(ihspid);
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            this.tbxIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            this.tbxName.Text = dt.Rows[0]["ihspname"].ToString();
            this.dtpOutdate.Value =DateTime.Parse(dt.Rows[0]["outdate"].ToString());
            this.tbxPersonNum.Text = hdsbhRegInfo.PersonNum;
            this.tbxInvoice.Text = invoice;
            header.Weburl = hdsbhRegInfo.Weburl;
            header.Trustpointcode = hdsbhRegInfo.Trustpointcode;
            header.TargetOrg = hdsbhRegInfo.TargetOrg;
            header.Password = hdsbhRegInfo.Password;
            lblFeeamt.Text = dt.Rows[0]["feeamt"].ToString();
            cmbPatientType.SelectedValue = Patienttype;
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOutHspMedinsurHDSBH_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatientType.ValueMember = "id";
                this.cmbPatientType.DisplayMember = "name";
                this.cmbPatientType.DataSource = dtp;
            }
            cmbPatientType.Enabled = false;

            string[] param = new string[15];
            param[0] = this.tbxIhspcode.Text.Trim();//住院号
            param[1] = this.tbxPersonNum.Text.Trim();//个人编码
            param[2] = this.tbxInvoice.Text.Trim();//发票号
            string yjsfpsj = this.dtpFpsj.Value.ToString().Trim();//发票时间
            param[3] = DateTime.Parse(yjsfpsj).ToString("yyyy-MM-ddTHH-mm-ss").Trim();//发票时间必填    yyyy-mm-ddT24-mi-ss，强制要求位数，需补齐
            string yjscysj = this.dtpOutdate.Text;//出院时间
            param[8] = DateTime.Parse(yjscysj).ToString("yyyy-MM-ddTHH-mm-ss").Trim();//出院时间必填    yyyy-mm-ddT24-mi-ss，强制要求位数，需补齐
            param[12] = this.tbxName.Text.Trim();//患者姓名
            ZyyjsXml zyyjsXml = new ZyyjsXml();


            BhnhReturn retdata = zyyjsXml.membersQueryFunction(header.Weburl, header.TargetOrg, header.Trustpointcode, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show("失败信息：" + retdata.Ret_mesg, "提示信息");
                return;
            }            
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            this.tbx_zyzfy.Text = ds.Tables["feeInfo"].Rows[0]["D506_03"].ToString();//住院总费用
            this.tbx_zykbzfy.Text = ds.Tables["feeInfo"].Rows[0]["D506_19"].ToString();//住院可报总费用
            this.tbx_sjbcje.Text = ds.Tables["feeInfo"].Rows[0]["D506_24"].ToString();//实际补偿金额
            this.tbx_ncjmzfje.Text = ds.Tables["feeInfo"].Rows[0]["D506_32"].ToString();//农村居民自费金额
            this.tbx_jtzhcdje.Text = ds.Tables["feeInfo"].Rows[0]["D506_57"].ToString();//家庭账户冲抵金额
            this.tbx_tszdjbbcje.Text = ds.Tables["feeInfo"].Rows[0]["D506_58"].ToString();//特殊重大疾病补偿金额
            this.tbx_dsfbcylbxbcje.Text = ds.Tables["feeInfo"].Rows[0]["D506_59"].ToString();//第三方补充医疗保险补偿金额
            this.tbx_dsfdejzbcje.Text = ds.Tables["feeInfo"].Rows[0]["D506_60"].ToString();//第三方大额救助补偿金额
            this.tbx_mzjzbce.Text = ds.Tables["feeInfo"].Rows[0]["D506_103"].ToString();//民政救助补偿额
            this.tbx_ecbcje.Text = ds.Tables["allFeeSubentry"].Rows[0]["D506_104"].ToString();//二次补偿金额
            this.tbx_yljgfdje.Text = ds.Tables["allFeeSubentry"].Rows[0]["D506_105"].ToString();//医疗机构负担金额            
            btnOk.Enabled = false;
            double nhfy = Convert.ToDouble(ds.Tables["feeInfo"].Rows[0]["D506_03"].ToString());//住院总费用
            double hisfy = Convert.ToDouble(this.lblFeeamt.Text);
            BllInsurMethod bllInsurMethod = new BllInsurMethod();
            int flag = bllInsurMethod.upInsurinfoFee(ihspid, tbx_sjbcje.Text,tbx_ncjmzfje.Text);
            if (flag < 0)
            {
                MessageBox.Show("保存预结算信息失败!");
                    return;
            }
            double chazhi = hisfy - nhfy;
            btnClose.Focus();
            if (chazhi > 0.01 || chazhi < -0.01)
            {
                MessageBox.Show("住院总费用与农合返回的总费用不相等！", "提示信息");
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbxIhspcode.Text.Trim() == "")
            {
                MessageBox.Show("住院号为空不能办理预结算", "提示信息");
                tbxIhspcode.Focus();
                return;
            }
            if (dtpFpsj.Text == "")
            {
                MessageBox.Show("必须填写发票时间，不能办理预结算", "提示信息");
                dtpFpsj.Focus();
                return;
            }
            if (this.dtpOutdate.Text == "")
            {
                MessageBox.Show("必须填写出院时间，不能办理预结算", "提示信息");
                dtpOutdate.Focus();
                return;
            }
            if (this.tbxPersonNum.Text == "")
            {
                MessageBox.Show("必须填个人编码，不能办理预结算", "提示信息");
                tbxPersonNum.Focus();
                return;
            }
            if (this.tbxInvoice.Text == "")
            {
                MessageBox.Show("必须填发票号，不能办理预结算", "提示信息");
                tbxInvoice.Focus();
                return;
            }
            if (this.tbxName.Text == "")
            {
                MessageBox.Show("必须填姓名，不能办理预结算", "提示信息");
                tbxInvoice.Focus();
                return;
            }
            
        }
    }
}
