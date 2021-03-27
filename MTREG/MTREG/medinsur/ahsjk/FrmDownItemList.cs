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
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmDownItemList : Form
    {
        public FrmDownItemList()
        {
            InitializeComponent();
        }

        private void FrmDownItemList_Load(object sender, EventArgs e)
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

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDown_Click(object sender, EventArgs e)
        {
            BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
            In_DownItemList inp = new In_DownItemList();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            retMesage ret = bllAhsnhMethod.downItemList(inp);
            int bodyCount = ret.Ret_data.Count;
            string sql = "";
            string insurid = bllAhsnhMethod.getInsurid(CostInsurtypeKeyname.AHSJNH.ToString());
            for (int i = 0; i < bodyCount; i++)
            {
                Out_DownItemList oEntity = (Out_DownItemList)ret.Ret_data[i];

                sql += "insert into cost_insuritem(id,cost_insurtype_id,name2,insurcode,spec,unit,updateat)"
                    + "values(" + DataTool.addFieldBraces(BillSysBase.nextId("cost_insuritem"))
                    + "," + DataTool.addFieldBraces(insurid)
                    + "," + DataTool.addFieldBraces(oEntity.SName)
                    + "," + DataTool.addFieldBraces(oEntity.SCode)
                    + "," + DataTool.addFieldBraces(oEntity.SSpec)
                    + "," + DataTool.addFieldBraces(oEntity.SUnit)
                    + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                    +");";
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

    }
}
