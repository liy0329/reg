using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bll;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.common;
using MTREG.medinsur.ahsjk.bo.inp;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmDownIcd : Form
    {
        public FrmDownIcd()
        {
            InitializeComponent();
        }

        private void butDown_Click(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            In_DownICD inp = new In_DownICD();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            retMesage ret = bllAhsnhMethod.downICD(inp);
            int bodyCount = ret.Ret_data.Count;
            string sql = "";
            string insurid = bllAhsnhMethod.getInsurid(CostInsurtypeKeyname.AHSJNH.ToString());
            for (int i = 0; i < bodyCount; i++)
            {
                Out_DownICD oEntity = (Out_DownICD)ret.Ret_data[i];
                sql += "insert into cost_insurillness(id,cost_insurtype_id,name,pincode,illcode,createdat,createdby)"
                                        + "values(" + DataTool.addFieldBraces(BillSysBase.nextId("cost_insurillness"))
                                        + "," + DataTool.addFieldBraces(insurid)
                                        + "," + DataTool.addFieldBraces(oEntity.SIcdName)
                                        + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(oEntity.SIcdName))
                                        + "," + DataTool.addFieldBraces(oEntity.SIcdno)
                                        + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                                        + "," + DataTool.addFieldBraces(ProgramGlobal.User_id) + ";";
            }
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("His录入失败!","提示信息");
                return;
            }
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg);
                return;
            }
            MessageBox.Show("下载成功！", "提示信息");
        }           

        private void FrmDownIcd_Load(object sender, EventArgs e)
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
