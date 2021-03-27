using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    public partial class FrmInHspMedinsrHDSNH : Form
    {
        Header header = new Header();
        FrmIhspReg frmIhspReg;
        public FrmIhspReg FrmIhspReg
        {
            get { return frmIhspReg; }
            set { frmIhspReg = value; }
        }
        BllSnhMethod bllSnhMethod = new BllSnhMethod();
        HeaderXml headerXml = new HeaderXml();
        public FrmInHspMedinsrHDSNH()
        {
            InitializeComponent();
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

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInHspMedinsrHDSNH_Load(object sender, EventArgs e)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatientType.ValueMember = "id";
                this.cmbPatientType.DisplayMember = "name";
                this.cmbPatientType.DataSource = dtp;
                cmbPatientType.SelectedValue = PatientType;
            }
            cmbPatientType.Enabled = false;

            DataTable dt_area = bllSnhMethod.area();
            if (dt_area.Rows.Count > 0)
            {
                cmbArea.ValueMember = "id";
                cmbArea.DisplayMember = "name";
                DataRow dr = dt_area.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请先选择区域--";
                dt_area.Rows.InsertAt(dr, 0);
                cmbArea.DataSource = dt_area;                
            }

            DataTable dt_dict = bllSnhMethod.getdict("12");
            if (dt_dict.Rows.Count > 0)
            {
                cmbDjsx.ValueMember = "sn";
                cmbDjsx.DisplayMember = "name";
                cmbDjsx.DataSource = dt_dict;                
            }

            DataTable dt_dict1 = bllSnhMethod.getdict("29");
            if (dt_dict1.Rows.Count > 0)
            {
                cmbZwlx.ValueMember = "sn";
                cmbZwlx.DisplayMember = "name";
                cmbZwlx.DataSource = dt_dict1;                
            }

            DataTable dts = billCmbList.sexList();
            if (dts.Rows.Count > 0)
            {
                this.cmbSex.ValueMember = "id";
                this.cmbSex.DisplayMember = "name";
                this.cmbSex.DataSource = dts;
            }
            this.tbxHospCode.Text = "请先选择区域";
            
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            FrmIhspReg.HdsbhInfo.Name = this.tbxName.Text;
            FrmIhspReg.HdsbhInfo.Idcard = this.tbxIDCard.Text;
            FrmIhspReg.HdsbhInfo.Sex = this.cmbSex.SelectedValue.ToString();
            FrmIhspReg.HdsbhInfo.Birthday = this.dtpBirth.Value.ToString();
            FrmIhspReg.HdsbhInfo.PersonNum = this.tbxPersonalNum.Text;
            FrmIhspReg.HdsbhInfo.Address = this.tbxAddress.Text;
            FrmIhspReg.HdsbhInfo.Djsj = this.dtpDjsj.Value.ToString();
            FrmIhspReg.HdsbhInfo.Companyname = tbxCompanyName.Text;
            FrmIhspReg.HdsbhInfo.Djsx = this.cmbDjsx.SelectedValue.ToString();
            FrmIhspReg.HdsbhInfo.Zwlx = this.cmbZwlx.SelectedValue.ToString();
            this.FrmIhspReg.Header.Weburl = header.Weburl;
            this.FrmIhspReg.Header.Trustpointcode = header.Trustpointcode;
            this.FrmIhspReg.Header.TargetOrg = header.TargetOrg;
            this.FrmIhspReg.Header.Password = header.Password;
            string str = tbxCardCode.Text.Trim().ToString();
            if (string.IsNullOrEmpty(tbxHospCode.Text.ToString()))
            {
                MessageBox.Show("医疗机构代码不能为空!");
                tbxHospCode.Focus();
                return;
            }
            FrmIhspReg.HdsbhInfo.Hspcode = this.tbxHospCode.Text.ToString();
            this.Close();
        }

        /// <summary>
        /// 区域选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbArea.SelectedValue.ToString() == "0" || string.IsNullOrEmpty(cmbArea.SelectedValue.ToString()))
            {
                return;
            }
            DataTable dt=bllSnhMethod.getWebUrl(cmbArea.SelectedValue.ToString());
            if (dt.Rows.Count == 1)
            {
                header.Weburl = dt.Rows[0]["weburl"].ToString();
                this.FrmIhspReg.Header.Weburl = dt.Rows[0]["weburl"].ToString();
                header.Trustpointcode = dt.Rows[0]["trustpointcode"].ToString();
                this.FrmIhspReg.Header.Trustpointcode = dt.Rows[0]["trustpointcode"].ToString();
                header.TargetOrg = dt.Rows[0]["uniquekey"].ToString();
                this.FrmIhspReg.Header.TargetOrg = dt.Rows[0]["uniquekey"].ToString();
                header.Password = dt.Rows[0]["password"].ToString();
                this.FrmIhspReg.Header.Password = dt.Rows[0]["password"].ToString();
                string sql = "select id from insur_hdsbh_hospital where Qhdm=" + DataTool.addFieldBraces(header.TargetOrg);
                DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("未找到相关机构!");
                    return;
                }
                tbxHospCode.Text = dt1.Rows[0]["id"].ToString();
            }
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            string[] param = new string[2];//参数数组
            GrxxcxXml grxxcxXml = new GrxxcxXml();
            if (cmbArea.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("请先选择区域!");
                cmbArea.Focus();
                return;
            }

            string str = tbxCardCode.Text.Trim().ToString();
            int length = str.Length;
            if (length == 18)
            {
                param[0] = str;
                param[1] = tbxPersonalNum.Text;
                BhnhReturn retdata = grxxcxXml.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
                if (!retdata.Ret_flag)
                {
                    MessageBox.Show(retdata.Ret_mesg, "提示信息");
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
                string nhxb = ds.Tables["body"].Rows[0]["D401_03"].ToString();//农合性别 其他参数参照文件夹下的文档
                string nhchzt = ds.Tables["body"].Rows[0]["D401_52"].ToString();//参合状态
                this.tbxPersonalNum.Text = ds.Tables["body"].Rows[0]["D401_21_A"].ToString();//农合个人编号
                this.tbxName.Text = ds.Tables["body"].Rows[0]["D401_02"].ToString();//姓名
                this.tbxIDCard.Text = ds.Tables["body"].Rows[0]["D401_01"].ToString();//身份证号
                this.dtpBirth.Value = Convert.ToDateTime(ds.Tables["body"].Rows[0]["D401_04"].ToString());//出生日期
                this.tbxCompanyName.Text = ds.Tables["body"].Rows[0]["D401_11"].ToString();//工作单位
                this.tbxAddress.Text = ds.Tables["body"].Rows[0]["D401_13"].ToString();//通讯地址
                if (nhchzt == "本年未参合")
                {
                    MessageBox.Show("该医疗证号本年未参合", "提示信息");
                    return;
                }
                cmbSex.SelectedValue = nhxb;

            }
            else
            {
                MessageBox.Show("医疗证号位数不符合!");
                tbxCardCode.Focus();
                return;
            }
        }
    }
}
