using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.dte;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.common;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmDownTreat : Form
    {
        public FrmDownTreat()
        {
            InitializeComponent();
        }

        private void but_dcExcel_Click(object sender, EventArgs e)
        {
            string[] str = new string[9];
            Excel.SaveAs(dataGridView1);

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("没有可导出的数据", "提示信息");
                return;
            }

        }

        private void but_tc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDownTreat_Load(object sender, EventArgs e)
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

        private void but_xz_Click_1(object sender, EventArgs e)
        {
             /* 调用WebService代码实现 begin */
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            In_DownTreat inp = new In_DownTreat();
            //初始化inp输入参数 begin
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SUserCode = txt_UserCode.Text;
            inp.SUserPass = txt_UserPass.Text;
            inp.SYear = tbx_nf.Text;
            //初始化inp输入参数 end
            retMesage ret = bllAhsnhMethod.downTreat(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show("失败信息: " + ret.Ret_mesg, "提示信息");
                return;
            }
            int bodyCount = ret.Ret_data.Count;
            string sql="";
            for (int i = 0; i < bodyCount; i++)
            {
                Out_DownTreat oEntity = (Out_DownTreat)ret.Ret_data[i];
                dataGridView1.Rows.Insert(i, 1);
                this.dataGridView1.Rows[i].Cells["zlfsbm"].Value = oEntity.STreatCode;
                this.dataGridView1.Rows[i].Cells["zlfsmc"].Value = oEntity.STreatName;
                this.dataGridView1.Rows[i].Cells["dbzicdbm"].Value = oEntity.SIcdno;
                this.dataGridView1.Rows[i].Cells["dbzicdmc"].Value = oEntity.SIcdName;
                this.dataGridView1.Rows[i].Cells["yl1"].Value = oEntity.SObligate1;
                this.dataGridView1.Rows[i].Cells["yl2"].Value = oEntity.SObligate2;
                this.dataGridView1.Rows[i].Cells["yl3"].Value = oEntity.SObligate3;
                this.dataGridView1.Rows[i].Cells["yl4"].Value = oEntity.SObligate4;
                this.dataGridView1.Rows[i].Cells["yl5"].Value = oEntity.SObligate5;
                sql += "insert into insur_ahsjnh_treat(id"
                    + ",treatcode"
                    + ",treatname"
                    + ",icdno"
                    + ",icdname"
                    + ",obligate1"
                    + ",obligate2"
                    + ",obligate3"
                    + ",obligate4"
                    + ",obligate5)values(" + DataTool.addIntBraces(BillSysBase.nextId("insur_ahsjnh_treat"))
                    + "," + DataTool.addFieldBraces(oEntity.STreatCode)
                    + "," + DataTool.addFieldBraces(oEntity.STreatName)
                    + "," + DataTool.addFieldBraces(oEntity.SIcdno)
                    + "," + DataTool.addFieldBraces(oEntity.SIcdName)
                    + "," + DataTool.addFieldBraces(oEntity.SObligate1)
                    + "," + DataTool.addFieldBraces(oEntity.SObligate2)
                    + "," + DataTool.addFieldBraces(oEntity.SObligate3)
                    + "," + DataTool.addFieldBraces(oEntity.SObligate4)
                    + "," + DataTool.addFieldBraces(oEntity.SObligate5)
                    +");";            
            }
            if (BllMain.Db.Update(sql)<0)
            {
                MessageBox.Show("His添加失败!");
                return;
            }
            MessageBox.Show("下载成功!");
        }
    }
}
