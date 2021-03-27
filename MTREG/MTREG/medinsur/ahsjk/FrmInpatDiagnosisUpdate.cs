using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmInpatDiagnosisUpdate : Form
    {
        public FrmInpatDiagnosisUpdate()
        {
            InitializeComponent();
        }

        private void FrmInpatDiagnosisUpdate_Load(object sender, EventArgs e)
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
        string jzh;

        public string Jzh
        {
            get { return jzh; }
            set { jzh = value; }
        }

        private void tbx_jbjm_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Visible = true;
            string sql_nhjbxx = "";
            DataTable dt_nhjbxx = BllMain.Db.Select(sql_nhjbxx).Tables[0];
           dataGridView1.DataSource = dt_nhjbxx.DefaultView;
            if (tbx_jbjm.Text == "" || tbx_jbjm.Text == null)
            {
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tbx_jbbm.Text = dataGridView1.Rows[e.RowIndex].Cells["jbbm"].Value.ToString();
            this.tbx_jbmc.Text = dataGridView1.Rows[e.RowIndex].Cells["jbmc"].Value.ToString();
            this.tbx_zlfsbm.Text = dataGridView1.Rows[e.RowIndex].Cells["zlfsbm"].Value.ToString();
            dataGridView1.Visible = false;
            this.tbx_jbjm.Focus();
        }

        private void frmZydbzxxsc_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            this.tbx_jzh.Text = jzh;
        }

        private void but_qd_Click(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            BillCmbList billCmbList = new BillCmbList();
            /* 调用WebService实现代码 begin */
            In_InpatDiagnosisUpdate inp = new In_InpatDiagnosisUpdate();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.SInpatientID = jzh;
            inp.SStature = this.tbx_sg.Text.Trim();
            inp.SWeight = this.tbx_tz.Text.Trim();
            inp.STreatCode = this.tbx_zlfsbm.Text.Trim();
            inp.SIcdno = this.tbx_jbbm.Text;
            inp.SIcdName = this.tbx_jbmc.Text;
            inp.SSectionOfficeCode = "-";
            inp.SCureCode = "-";
            inp.SInHospitalCode = "-";
            inp.SInHosptialDate = DateTime.Now.ToString();
            inp.SOperatorName = billCmbList.getDoctorName(ProgramGlobal.User_id);
            retMesage ret = bllAhsnhMethod.inpatDiagnosisUpdate(inp);
            if (!ret.Ret_flag) 
            {
                MessageBox.Show("失败信息: " + ret.Ret_mesg, "提示信息");
                return;
            }
            /* 调用WebService实现代码 end */
            MessageBox.Show("成功信息: " + ret.Ret_mesg, "提示信息");
            this.Close();
            this.Dispose();
        }

        private void but_qx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
