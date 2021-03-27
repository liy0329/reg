using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bll;
using MTREG.common;
using MTREG.ihsp.bll;
using MTHIS.common;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bo;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmOutHspReg : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
        public FrmOutHspReg()
        {
            InitializeComponent();
        }
        private string ihspid;
        /// <summary>
        /// 住院记录id
        /// </summary>
        public string Ihspid
        {
            get { return ihspid; }
            set { ihspid = value; }
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOutHspReg_Load(object sender, EventArgs e)
        {
            DataTable dt = bllAhsnhMethod.insurstat(ihspid);
            tbxIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
            tbxName.Text = dt.Rows[0]["name"].ToString();

            this.cmbDepart.ValueMember = "id";
            this.cmbDepart.DisplayMember = "name";
            var dtde = billCmbList.departList();
            DataRow drde = dtde.NewRow();
            drde["id"] = 0;
            drde["name"] = "--请选择--";
            dtde.Rows.InsertAt(drde, 0);
            this.cmbDepart.DataSource = dtde;
        }

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cydj_Click(object sender, EventArgs e)
        {
            DataTable dt = bllAhsnhMethod.insurstat(ihspid);
            if (dt.Rows.Count > 0 && dt.Rows[0]["insurstat"].ToString() == Insurstat.REG.ToString())
            {
                In_InpatientOutRegister inp = new In_InpatientOutRegister();
                RegInfo reginfo = bllAhsnhMethod.readRegInfo(ihspid);
                //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
                inp.Weburl = reginfo.Weburl;
                inp.SHospitalCode = reginfo.SHospitalCode;
                inp.SAreaCode = reginfo.SAreaCode;
                if (inp.SAreaCode == "")
                {
                    MessageBox.Show("请选择区域！, 提示信息");
                    return;
                }
                inp.SInpatientID = reginfo.SInpatientID;
                //出院诊断
                inp.SDiagnoseNameOut1 = this.tbxIhspdiagn.Text;
                inp.SDiagnoseCodeOut1 = this.tbxIhspicd.Text;
                inp.SDiagnoseNameOut2 = "";
                inp.SDiagnoseCodeOut2 = "";
                inp.SDiagnoseNameOut3 = "";
                inp.SDiagnoseCodeOut3 = "";
                //出院科室
                inp.SSectionOfficeName = this.cmbDepart.Text;
                inp.SSectionOfficeCode = "-";//中心出院科室
                inp.SOutHospitalCode = this.comboCyyy.SelectedValue.ToString();//出院状态编码
                inp.SOutHosptialDate = this.dtpOutDate.Value.ToString();//出院时间
                inp.SOperatorName = billCmbList.getDoctorName(ProgramGlobal.User_id);//操作人姓名
                inp.SReceiptCode = dt.Rows[0]["invoice"].ToString();//发票号码
                inp.SAllInCost = dt.Rows[0]["feeamt"].ToString();//HIS住院发生总费用
                inp.SObligate1 = "";
                inp.SObligate2 = "";
                inp.SObligate3 = "";
                inp.SObligate4 = "";
                inp.SObligate5 = "";
                //初始化inp输入参数 end
                retMesage ret= bllAhsnhMethod.inpatientOutRegister(inp);
                if (!ret.Ret_flag)
                {
                    MessageBox.Show(ret.Ret_mesg, "错误提示");
                    return;
                }
                BillIhspMan billIhspMan=new BillIhspMan();
                int flag = billIhspMan.upinsurstat(tbxIhspcode.Text, Insurstat.SIGN.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("住院记录医保状态更新失败!");
                    return;
                }
                string ohspinfo = tbxIhspdiagn.Text + "|" + tbxIhspcode.Text;//出院诊断名称|出院诊断编码
                bllAhsnhMethod.saveohspXml(ohspinfo, ihspid);
                flag = billIhspMan.upinsurstat(dt.Rows[0]["ihspcode"].ToString(), Insurstat.SIGN.ToString());
                MessageBox.Show("出院登记成功！");
            }            
        }

        /// <summary>
        /// 出院诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxIhspdiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxIhspdiagn.Visible = true;
                setIhspSource(this.tbxIhspdiagn.Text);
                dgvIhspCase.Rows[0].Selected = true;
                dgvIhspCase.Focus();
            }
        }
        /// <summary>
        /// 简码选择dgv赋值
        /// </summary>
        /// <param name="pincode"></param>
        private void setIhspSource(string pincode)
        {
            BillCmbList billCmbList = new BillCmbList();
            DataTable dt = billCmbList.regCase(pincode);
            dgvIhspCase.DataSource = dt;
            this.dgvIhspCase.Columns["id"].HeaderText = "id";
            this.dgvIhspCase.Columns["id"].Visible = false;
            this.dgvIhspCase.Columns["icd10"].HeaderText = "icd10";
            this.dgvIhspCase.Columns["icd10"].Visible = false;
            this.dgvIhspCase.Columns["name"].HeaderText = "名称";
            this.dgvIhspCase.Columns["name"].Width = 161;
            dgvIhspCase.ReadOnly = true;
        }


        private void dgvIhspCase_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvIhspCase.Rows.Count > 0)
            {
                if (e.KeyData == Keys.Enter && dgvIhspCase.CurrentRow != null)
                {
                    this.tbxIhspdiagn.Text = dgvIhspCase.SelectedRows[0].Cells["name"].Value.ToString();
                    this.tbxIhspicd.Text = dgvIhspCase.SelectedRows[0].Cells["icd10"].Value.ToString();
                    dgvIhspCase.Visible = false;
                    dgvIhspCase.Columns.Clear();
                }
                else if (e.KeyData == Keys.Down && dgvIhspCase.CurrentRow != null && dgvIhspCase.CurrentRow.Index > 0)
                {
                    dgvIhspCase.Rows[dgvIhspCase.CurrentRow.Index - 1].Selected = true;
                }
                else if (e.KeyData == Keys.Up && dgvIhspCase.CurrentRow != null && dgvIhspCase.CurrentRow.Index < dgvIhspCase.Rows.Count - 1)
                {
                    dgvIhspCase.Rows[dgvIhspCase.CurrentRow.Index + 1].Selected = true;
                }
            }
        }

        /// <summary>
        /// 取消出院登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qxcydj_Click(object sender, EventArgs e)
        {
            if (this.tbx_qxyy.Text == "")
            {
                MessageBox.Show("请输入取消登记原因", "提示信息");
                return;
            }
            DataTable dt = bllAhsnhMethod.insurstat(ihspid);
            //判断是否已经结算
            if (dt.Rows.Count > 0 && dt.Rows[0]["insurstat"].ToString() == Insurstat.SIGN.ToString())
            {
                In_InpatientOutRegisterCancel inp = new In_InpatientOutRegisterCancel();
                RegInfo reginfo = bllAhsnhMethod.readRegInfo(ihspid);
                //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
                inp.SAreaCode = reginfo.SAreaCode;
                inp.Weburl = reginfo.Weburl;
                inp.SHospitalCode = reginfo.SHospitalCode;
                if (inp.SAreaCode == "")
                {
                    MessageBox.Show("请选择区域！, 提示信息");
                    return;
                }
                inp.SReason = this.tbx_qxyy.Text;
                inp.SInpatientID = reginfo.SInpatientID;
                inp.SOperatorName = billCmbList.getDoctorName(ProgramGlobal.User_id);//操作人姓名
                inp.SObligate1 = "";
                inp.SObligate2 = "";
                inp.SObligate3 = "";
                inp.SObligate4 = "";
                inp.SObligate5 = "";
                retMesage ret = bllAhsnhMethod.inpatientOutRegisterCancel(inp);
                if (!ret.Ret_flag)
                {
                    MessageBox.Show(ret.Ret_mesg, "错误提示");
                    return;
                }
                BillIhspMan billIhspMan = new BillIhspMan();
                int flag = billIhspMan.upinsurstat(tbxIhspcode.Text, Insurstat.REG.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("住院记录医保状态更新失败!");
                    return;
                }
            }            
            MessageBox.Show("取消出院登记成功！");
        }
    }
}
