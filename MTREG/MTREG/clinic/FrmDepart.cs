using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clinic.bll;

namespace MTREG.clinic.bo
{
    public partial class FrmDepart : Form
    {
        BillRegSearch billRegSearch = new BillRegSearch();
        Register register = new Register();
        string thisid;
        int flag;
        public FrmDepart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取挂号记录的数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id)
        {
            this.thisid = id;
            DataTable dt= billRegSearch.regIdSearch(id);
            if (dt.Rows.Count > 0)
            {
                this.lblName.Text = dt.Rows[0]["regname"].ToString();
                this.lblBillcode.Text = dt.Rows[0]["billcode"].ToString();
            }
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDepart_Load(object sender, EventArgs e)
        {
            DataTable dt = billRegSearch.regIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {

                #region combox设置
                var dtde = billRegSearch.DepartList();
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.DataSource = dtde;
                this.cmbDepart.SelectedValue = dt.Rows[0]["depart_id"];           

                                
                var dtdo = billRegSearch.DoctorList();
                this.cmbDoctor.ValueMember = "id";
                this.cmbDoctor.DisplayMember = "name";
                //this.cmbDoctor.DataSource = dtdo;
                //this.cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"];
                if (null != cmbDepart.SelectedValue && !cmbDepart.SelectedIndex.Equals(0))
                {
                    String departid = cmbDepart.SelectedValue.ToString();
                    bindComboxData(billRegSearch.doctorNameGet(departid), cmbDoctor);
                    this.cmbDoctor.SelectedValue = dt.Rows[0]["doctor_id"];
                }
                #endregion
            }
        }

        /// <summary>
        /// 由科室得到医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepart_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (null != cmbDepart.SelectedValue && !cmbDepart.SelectedIndex.Equals(0))
            {
                String departid = cmbDepart.SelectedValue.ToString();
                bindComboxData(billRegSearch.doctorNameGet(departid), cmbDoctor);
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

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt= billRegSearch.regIdSearch(thisid);
            if (dt.Rows.Count > 0)
            {
                register.Billcode = dt.Rows[0]["billcode"].ToString();
                register.Depart_id = cmbDepart.SelectedValue.ToString();
                register.Doctor_id = cmbDoctor.SelectedValue.ToString();
                flag = billRegSearch.updateDepart(register);
                if (flag == -1)
                {
                    MessageBox.Show("保存失败!");
                }

                this.Close();
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
