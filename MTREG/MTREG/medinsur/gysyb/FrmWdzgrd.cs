using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MTREG.medinsur.gysyb.bll;
using MTHIS.main.bll;
using MTREG.medinsur.gzsyb.listitem;
using MTHIS.common;
using MTREG.clinic.bll;

namespace MTREG.medinsur.gysyb.clinic
{
    public partial class FrmWdzgrd : Form
    {
        Gysybservice gysybservice = new Gysybservice();
        BllClinicReg bllClinicReg = new BllClinicReg();
        public FrmWdzgrd()
        {
            InitializeComponent();  
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void cshyssfzh()
        {
            try
            {
                string ys = cmbDoctor.SelectedValue.ToString().Trim();
                string sql = "select cardid from bas_doctor where id=" + ys;
                tbxSfzh.Text = BllMain.Db.Select(sql).Tables[0].Rows[0][0].ToString().Trim();
            }
            catch
            { }
        }
        private void cshyp()
        {
            string grbh = tbxGrbh.Text.ToString().Trim();
            if (string.IsNullOrEmpty(grbh))
            {
                return;
            }
            string sql = "select cost_insuritem.name,cost_insuritem.insurcode from sybwdtsxmml ";
            sql += "left join cost_insuritem on sybwdtsxmml.itemcode=cost_insuritem.insurcode  ";
            sql += "where sybwdtsxmml.itemcode not in(select sybwdzgrd.itemcode from sybwdzgrd.personcode='" + grbh + "') ";
            sql += "and sybwdtsxmml.itemcode in(select cost_insurcross.insurcode from cost_insurcross where cost_insurcross.insuritemtype='3') ";
            cbxYbxm.DisplayMember = "name";
            cbxYbxm.ValueMember = "insurcode";
            cbxYbxm.DataSource = BllMain.Db.Select(sql).Tables[0];
        }

        private void btnRd_Click(object sender, EventArgs e)
        {
            string grbh = tbxGrbh.Text.ToString().Trim();
            string itemcode = cbxYbxm.SelectedValue.ToString().Trim();
            string itemname = cbxYbxm.Text.ToString().Trim();
            string drid = tbxSfzh.Text.ToString().Trim();
            string drname = cmbDoctor.Text.ToString().Trim();
            string operatorname = ProgramGlobal.Username;
            string outXml = gysybservice.Wdzgrd(grbh, itemcode, itemname, drid, drname, operatorname);
            StringReader sr = new StringReader(outXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            string flag = ds.Tables["DATA"].Rows[0]["RETCODE"].ToString().Trim();//状态码
            string info = ds.Tables["DATA"].Rows[0]["INFO"].ToString().Trim();//错误信息
            if (flag == "0")
            {
                string sql = "INSERT INTO sybwdzgrd( personcode, itemcode, itemname, drid, drname, operatorname, operatetime) VALUES ('" + grbh + "', '" + itemcode + "', '" + itemname + "', '" + drid + "', '" + drname + "', '" + operatorname + "', '" + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss") + "');";
                BllMain.Db.Update(sql);
                MessageBox.Show("认定成功");
                cshyp();
            }
            else
            {
                MessageBox.Show(info);
            }
        }

        private void cmbDepart_KeyDown(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {
                int l = cmbDepart.SelectionStart; //记录修改时光标位置
                cmbDepart.DroppedDown = false; //下拉框关闭

                string dep = cmbDepart.Text.Trim();
                //简码查询科室
                DataTable dtde = bllClinicReg.getDepartInfo(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                cmbDepart.DataSource = dtde;
                cmbDepart.Text = dep;

                cmbDepart.DroppedDown = true; //打开下拉框
                cmbDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
            else if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }

        /// <summary>
        /// 科室变化处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            //科室下拉框修改后修改医生列表
            departChange();
        }
        /// <summary>
        /// //科室变化处理: 算法修改医生信息
        /// </summary>
        private void departChange()
        {
            if (cmbDepart.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbDepart.SelectedValue)
            {
                String depart_id = cmbDepart.SelectedValue.ToString().Trim();
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbDoctor);
            }
        }
        /// <summary>
        /// 下拉选择框绑定数据库数据函数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="comObject"></param>
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            if (dt.ToString() == "")
            {
                dt.Columns.Add("name", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
            }
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "--请选择--";
                dr["id"] = 0;
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void tbxGrbh_TextChanged(object sender, EventArgs e)
        {
            cshyp(); 
        }

        private void cmbDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            cshyssfzh();
        }
    }
}
