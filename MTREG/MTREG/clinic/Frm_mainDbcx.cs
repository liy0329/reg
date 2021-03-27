using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.common;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MTHIS.common;
using System.Drawing;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.gysyb;
using MTREG.medinsur.gysyb.bo;
using MTHIS.main.bll;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.hdyb;
using MTREG.ihsptab.bo;
using GemBox.ExcelLite;

namespace MTREG.clinic
{
    public partial class Frm_mainDbcx : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        public Frm_mainDbcx()
        {
            InitializeComponent();
        }

        private void Frm_mainDbcx_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = DateTime.Now.AddDays(-30);
            initKs(); //科室
            initzyzt();// 住院状态初始化
            initsfqx();// 是否取消
        }

        private void initKs()
        {
            var dtde = billCmbList.departList();
            this.cbx_zyks.ValueMember = "id";
            this.cbx_zyks.DisplayMember = "name";
            DataRow dr = dtde.NewRow();
            dr["id"] = 0;
            dr["name"] = "--请选择--";
            dtde.Rows.InsertAt(dr, 0);
            this.cbx_zyks.DataSource = dtde;

            var dtd = billIhspMan.getAllDoctorByDepart("");//billCmbList.doctorList();
            this.cbx_ys.ValueMember = "id";
            this.cbx_ys.DisplayMember = "name";
            DataRow drdo = dtd.NewRow();
            drdo["id"] = 0;
            drdo["name"] = "--请选择--";
            dtd.Rows.InsertAt(drdo, 0);
            this.cbx_ys.DataSource = dtd;
        }
        private void initsfqx()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("ALL", "全部"));
            items.Add(new ListItem("N", "正在使用"));
            items.Add(new ListItem("Y", "已取消"));
            cbx_sfqx.DisplayMember = "Value";
            cbx_sfqx.ValueMember = "Text";
            cbx_sfqx.DataSource = items;
            cbx_sfqx.SelectedValue = "ALL";
        }

        private void initzyzt()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("ALL", "全部"));
            items.Add(new ListItem("XX", "退入院"));
            items.Add(new ListItem("BREG", "已登记"));
            items.Add(new ListItem("REG", "已在院"));
            items.Add(new ListItem("REST", "修疗程"));
            items.Add(new ListItem("SIGN", "已挂账"));
            items.Add(new ListItem("SETT", "已结算"));
            cbx_cyjs_zyzt.DisplayMember = "Value";
            cbx_cyjs_zyzt.ValueMember = "Text";
            cbx_cyjs_zyzt.DataSource = items;
            cbx_cyjs_zyzt.SelectedValue = "ALL";
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            getbdxx();
        }
        private void getbdxx()
        {
            string sql = @" select inhospital.ihspcode as zyh,
                            inhospital.name as name,
                            inhospital.prepamt as yjk,
                            inhospital.feeamt as zfy,
                            inhospital.nustmpamt as ye,
                            case when inhospital.sex='U' then '未知' when inhospital.sex='M' then'男' when inhospital.sex='W' then '女' end as xb,
                            bas_doctor.name as dbr,
                            bas_depart.name as ks,
                            ihsp_guaranfee.amt as dbje,
                            ihsp_guaranfee.createdate as dbrq,
                            ihsp_guaranfee.enddate as qxrq,
                            ihsp_guaranfee.memo as dbyy,
                            case when ihsp_guaranfee.delstat ='N' then '否' when ihsp_guaranfee.delstat ='Y' then '是' end as sfqx,
                            (select nickname from acc_account where id = ihsp_guaranfee.createdby ) as tjczy,
                            (select nickname from acc_account where id = ihsp_guaranfee.cance_cxr ) as qxczy,
                            inhospital.id as mtzyjlid
                            from ihsp_guaranfee  
                            left join inhospital on ihsp_guaranfee.ihsp_id=inhospital.id  
                            left join bas_depart on ihsp_guaranfee.depart_id=bas_depart.id 
                             left join bas_doctor on ihsp_guaranfee.doctor_id=bas_doctor.id 
                             where 1 = 1";// inhospital.ihspcode= '" + this.tbx_zyh.Text.Trim() + @;
            if (!String.IsNullOrEmpty(tbx_zyh.Text.Trim()))
                sql += "  and inhospital.ihspcode = " + DataTool.addFieldBraces(tbx_zyh.Text.Trim());

            if (!String.IsNullOrEmpty(cbx_cyjs_zyzt.SelectedValue.ToString()) && cbx_cyjs_zyzt.SelectedValue.ToString() != "ALL")
                sql += "  and inhospital.status =" + DataTool.addFieldBraces(cbx_cyjs_zyzt.SelectedValue.ToString());

            if (!String.IsNullOrEmpty(cbx_sfqx.SelectedValue.ToString()) && cbx_sfqx.SelectedValue.ToString() != "ALL")
                sql += "  and ihsp_guaranfee.delstat = " + DataTool.addFieldBraces(cbx_sfqx.SelectedValue.ToString());

            if (!String.IsNullOrEmpty(tbx_name.Text.Trim()))
                sql += "  and inhospital.name like '%" + tbx_name.Text.Trim() + "%'";

            if (!String.IsNullOrEmpty(cbx_ys.SelectedValue.ToString()) && cbx_ys.SelectedValue.ToString() != "0")
                sql += "  and ihsp_guaranfee.doctor_id =" + DataTool.addFieldBraces(cbx_ys.SelectedValue.ToString());

            if (!String.IsNullOrEmpty(cbx_zyks.SelectedValue.ToString()) && cbx_zyks.SelectedValue.ToString() != "0")
                sql += "  and ihsp_guaranfee.depart_id = " + DataTool.addFieldBraces(cbx_zyks.SelectedValue.ToString());
            sql += " and ihsp_guaranfee.createdate > '" + this.dtp_begin.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ihsp_guaranfee.createdate < '" + this.dtp_end.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            sql += " order by ihsp_guaranfee.createdate DESC";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            dgv_dbcx.DataSource = dt;
        }
        private void cbx_zyks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据科室修改医生
            if (null != cbx_zyks.SelectedValue && cbx_zyks.SelectedValue.ToString() != "0")
            {
                String departid = cbx_zyks.SelectedValue.ToString().Trim();
                bindComboxData(billIhspMan.getAllDoctorByDepart(departid), cbx_ys);
            }
        }
        /// <summary>
        /// 根据选择绑定下拉菜单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="comObject"></param>
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnDcb_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excl表格（.xls）|*.xls";
            save.FilterIndex = 1;
            if (save.ShowDialog() == DialogResult.OK)
            {
                string localpath = save.FileName.ToString().Trim();
                string filename = localpath.Substring(localpath.LastIndexOf("\\") + 1);
                ExcelFile excel = new ExcelFile();
                ExcelWorksheet sheet = excel.Worksheets.Add(filename);
                int columns = dgv_dbcx.Columns.Count;
                int rows = dgv_dbcx.Rows.Count;
                for (int i = 0; i < columns; i++)
                {
                    sheet.Cells[0, i].Value = dgv_dbcx.Columns[i].HeaderText;
                }
                for (int j = 1; j <= rows; j++)
                {
                    for (int k = 0; k < columns; k++)
                    {
                        try
                        {
                            sheet.Cells[j, k].Value = dgv_dbcx[k, j - 1].Value.ToString().Trim();
                        }
                        catch { }
                    }
                }
                excel.SaveXls(localpath);
                MessageBox.Show(localpath + "保存成功", "文件路径");
            }
        }
    }
}
