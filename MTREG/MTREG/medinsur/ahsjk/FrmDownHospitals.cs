using System;
using System.Data;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmDownHospitals : Form
    {
        public FrmDownHospitals()
        {
            InitializeComponent();
            init();
        }

        private void FrmDownHospitals_Load(object sender, EventArgs e)
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
        private void init()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            In_DownHospitals inp = new In_DownHospitals();
            DataTable dt1 = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt1.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt1.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt1.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = this.txt_UserCode.Text;
            inp.SUserPass = this.txt_UserPass.Text;
            inp.UpdateTime = this.dtp_Date.Text;
            retMesage ret = bllAhsnhMethod.downHospitals(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowCount = ret.Ret_data.Count;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("organCode"));
            dt.Columns.Add(new DataColumn("hospName"));
            dt.Columns.Add(new DataColumn("grader"));
            dt.Columns.Add(new DataColumn("orgLevel"));
            for (int i = 0; i < rowCount; i++)
            {
                Out_DownHospitals oEntity = (Out_DownHospitals)ret.Ret_data[i];
                dt.Rows.Add(new object[] { oEntity.OrganCode, oEntity.HospName, parseGrader(oEntity.Grader), parseOrgLevel(oEntity.OrgLevel) });
            }
            this.dgv_HspInfo.AutoGenerateColumns = false;
            this.dgv_HspInfo.DataSource = dt;
        }

        private string parseGrader(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "1":
                    newVal = "一级";
                    break;
                case "2":
                    newVal = "二级";
                    break;
                case "3":
                    newVal = "三级";
                    break;
            }
            return newVal;
        }

        private string parseOrgLevel(string orignalVal)
        {
            string newVal = "";
            switch (orignalVal)
            {
                case "1":
                    newVal = "村卫生室";
                    break;
                case "2":
                    newVal = "乡镇卫生院";
                    break;
                case "3":
                    newVal = "县级医疗机构";
                    break;
                case "4":
                    newVal = "市级医疗机构";
                    break;
                case "5":
                    newVal = "省级医疗机构";
                    break;
            }
            return newVal;
        }

    }
}
