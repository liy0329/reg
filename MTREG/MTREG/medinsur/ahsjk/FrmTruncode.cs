using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bll;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmTruncode : Form
    {
        BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
        public FrmTruncode()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            init();
        }

        public void init() 
        {
            this.rdo_Upload.Checked = true;
            this.cmb_SType.Text = "上传转诊单";
            this.cmb_SType.Enabled = false;
            this.btn_Search.Visible = false;
            this.cmb_InOrOut.Visible = false;
            this.cmb_InOrOut.Text = "本院转出病人";
        }

        private void rdo_Upload_CheckedChanged(object sender, EventArgs e)
        {
            clearAllCtrlComp();//置空控件内容
            this.txt_TurnCode.Enabled = false;//转诊单号文本框不可编辑，只用于显示返回的单据号
            this.btn_Search.Visible = false;//获取不按钮可见
            this.cmb_InOrOut.Visible = false;
            this.btn_Upload.Text = "上传";//更改修改/撤销按钮文本为上传
            this.cmb_SType.Text = "上传转诊单";
            enableAllCtrlComp(true);
        }

        private void rdo_Modify_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_TurnCode.Enabled = true;//转诊单号文本框可编辑，用于输入转诊单号，以便查询修改
            this.btn_Search.Visible = true;//获取按钮可见
            this.cmb_InOrOut.Visible = true;
            this.btn_Upload.Text = "修改";//更改上传/撤销按钮文本为修改
            this.cmb_SType.Text = "修改转诊单";
            enableAllCtrlComp(true);
        }

        private void rdo_Back_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_TurnCode.Enabled = true;//转诊单号文本框可编辑，用于输入转诊单号，以便查询修改
            this.btn_Search.Visible = true;//获取按钮可见
            this.cmb_InOrOut.Visible = true;
            this.btn_Upload.Text = "撤销";//更改上传/修改按钮文本为撤销
            this.cmb_SType.Text = "";
            enableAllCtrlComp(false);
        }

        private void clearAllCtrlComp() 
        {
            foreach (Control c in this.Controls) 
            {
                if(c is Label || 
                   c is RadioButton || 
                   c is Button || 
                   c is Panel)
                {
                    continue;
                }
                c.Text = "";
            };
        }

        private void enableAllCtrlComp(bool enable) 
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label ||
                   c is RadioButton ||
                   c is Button ||
                   c is Panel ||
                   c.Name == "cmb_SType" ||//排除操作类型
                   c.Name == "txt_TurnCode" ||//排除转诊单号
                   c.Name == "cmb_InOrOut")//排除转诊流向编码
                {
                    continue;
                }
                c.Enabled = enable;
            };
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            if (this.rdo_Upload.Checked)//上传
            {
                upload();
            }
            else if (this.rdo_Modify.Checked)//修改
            {
                modify();
            }
            else if (this.rdo_Back.Checked)//撤销
            {
                back();
            }
        }

        private void upload() 
        {            
            In_UploadTransfer inp = new In_UploadTransfer();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.Truncode = txt_TurnCode.Text;
            inp.Stype = cmb_SType.Text == "上传转诊单"?"1":"2";
            inp.Memberno = txt_Memberno.Text;
            inp.Idcardno = txt_IdCardno.Text;
            inp.Name = txt_Name.Text;
            inp.Sex = cmb_SSex.Text;
            inp.Birthday = dtp_SBirthday.Text;
            inp.Bookno = txt_BookNo.Text;
            inp.Telphone = txt_Telphone.Text;
            inp.Turntype = parseTurnType(cmb_TurnType.Text);
            inp.Icdcode = txt_IcdCode.Text;
            inp.Icdname = txt_IcdName.Text;
            inp.Turndate = dtp_TurnDate.Text;
            inp.Fromhospitalcode = txt_FromHspCode.Text;
            inp.Fromhospitalname = txt_FromHspName.Text;
            inp.Tohospitalcode = txt_ToHspCode.Text;
            inp.Tohospitalname = txt_ToHspName.Text;
            inp.Tohospitallevel = parseToHspLvl(cmb_ToHspLvl.Text);
            inp.Tohospitalteclevel = parseToHspTechLvl(cmb_ToHspTechLvl.Text);
            inp.Leavedateoflasttime = dtp_LvDtOfLstTime.Text;
            inp.Outofficeoflasttime = txt_OutOfficeOfLstTime.Text;
            inp.Icdcodeoflasttime = txt_IcdCodeOfLstTime.Text;
            inp.Icdnameoflasttime = txt_IcdNameOfLstTime.Text;
            inp.Doctorname = txt_DctrName.Text;
            inp.Remark = txt_Remark.Text;
            retMesage ret = bllAhsnhMethod.uploadTransfer(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg,"提示信息");
                return;
            }            
            txt_TurnCode.Text = ret.Ret_data[0].ToString();
        }

        private void modify() 
        {
            if (string.IsNullOrEmpty(txt_TurnCode.Text)) 
            {
                MessageBox.Show("【转诊单号】不能为空！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txt_TurnCode.BorderStyle = BorderStyle.FixedSingle;
                return;
            }
            upload();
        }

        private void back() 
        {
            In_CancelTransfer inp = new In_CancelTransfer();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.Truncode = txt_TurnCode.Text;
            inp.Memberno = txt_Memberno.Text;
            retMesage ret = bllAhsnhMethod.cancelTransfer(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg,"提示信息");
                return;
            }
            MessageBox.Show("撤销成功!");
        }

        private string parseTurnType(string orignalVal)
        {
            string newVal = "";
            switch(orignalVal)
            {
                case "上转":
                    newVal =  "1";
                    break;
                case "下转":
                    newVal = "2";
                    break;
                case "平行转院":
                    newVal = "3";
                    break;
            }
            return newVal;
        }

        private string parseToHspLvl(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "省级":
                    newVal = "5";
                    break;
                case "市级":
                    newVal = "4";
                    break;
                case "县级":
                    newVal = "3";
                    break;
                case "乡镇级":
                    newVal = "2";
                    break;
                case "省外":
                    newVal = "9";
                    break;
            }
            return newVal;
        }

        private string parseToHspTechLvl(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "三级":
                    newVal = "3";
                    break;
                case "二级":
                    newVal = "2";
                    break;
                case "一级":
                    newVal = "1";
                    break;
            }
            return newVal;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TurnCode.Text))
            {
                MessageBox.Show("【转诊单号】不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_TurnCode.BorderStyle = BorderStyle.FixedSingle;
                return;
            }
            searchTurnBill();
        }

        private void searchTurnBill() 
        {
            In_DownloadTransfer inp = new In_DownloadTransfer();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.Truncode = txt_TurnCode.Text;
            inp.Memberno = txt_Memberno.Text;
            inp.Inorout = cmb_InOrOut.Text == "本院转出病人" ? "1" : "2";
            retMesage ret = bllAhsnhMethod.downloadTransfer(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Out_DownloadTransfer oEntity = (Out_DownloadTransfer)ret.Ret_data[0];
            txt_TurnCode.Text = oEntity.Truncode;
            txt_Memberno.Text = oEntity.Memberno;
            txt_IdCardno.Text = oEntity.Idcardno;
            txt_Name.Text = oEntity.Name;
            cmb_SSex.Text = oEntity.Sex;
            dtp_SBirthday.Text = oEntity.Birthday;
            txt_BookNo.Text = oEntity.Bookno;
            txt_Telphone.Text = oEntity.Telephone;
            cmb_TurnType.Text = reserveTurnType(oEntity.Turntype);
            txt_IcdCode.Text = oEntity.Idcardno;
            txt_IcdName.Text = oEntity.Icdname;
            dtp_TurnDate.Text = oEntity.Turndate;
            txt_FromHspCode.Text = oEntity.Fromhospitalcode;
            txt_FromHspName.Text = oEntity.Fromhospitalname;
            txt_ToHspCode.Text = oEntity.Tohospitalcode;
            txt_ToHspName.Text = oEntity.Tohospitalname;
            cmb_ToHspLvl.Text = reserveToHspLvl(oEntity.Tohospitallevel);
            cmb_ToHspTechLvl.Text = reserveToHspTechLvl(oEntity.Tohospitalteclevel);
            dtp_LvDtOfLstTime.Text = oEntity.Leavedateoflasttime;
            txt_OutOfficeOfLstTime.Text = oEntity.Outofficeoflasttime;
            txt_IcdCodeOfLstTime.Text = oEntity.Icdcodeoflasttime;
            txt_IcdNameOfLstTime.Text = oEntity.Icdnameoflasttime;
            txt_DctrName.Text = oEntity.Doctorname;
            txt_Remark.Text = oEntity.Remark;
        }

        private string reserveTurnType(string orginalVal) 
        {
            string newVal = "";
            switch (orginalVal)
            {
                case "1":
                    newVal = "上转";
                    break;
                case "2":
                    newVal = "下转";
                    break;
                case "3":
                    newVal = "平行转院";
                    break;
            }
            return newVal;
        }

        private string reserveToHspLvl(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "5":
                    newVal = "省级";
                    break;
                case "4":
                    newVal = "市级";
                    break;
                case "3":
                    newVal = "县级";
                    break;
                case "2":
                    newVal = "乡镇级";
                    break;
                case "9":
                    newVal = "省外";
                    break;
            }
            return newVal;
        }

        private string reserveToHspTechLvl(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "3":
                    newVal = "三级";
                    break;
                case "2":
                    newVal = "二级";
                    break;
                case "1":
                    newVal = "一级";
                    break;
            }
            return newVal;
        }

        private void txt_TurnCode_Click(object sender, EventArgs e)
        {
            this.txt_TurnCode.BorderStyle = BorderStyle.Fixed3D;
        }

        private void FrmTruncode_Load(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            DataTable dta = bllAhsnhMethod.getAreaCode();
            cmbArea.DataSource = dta;
            cmbArea.ValueMember = "id";
            cmbArea.DisplayMember = "areaname";
            DataRow dr = dta.NewRow();
            dr["areaname"] = "--请选择--";
            dr["id"] = "0";
            dta.Rows.Add(dr); 
        }
    }
}
