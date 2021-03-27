using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.bll;
using MTREG.medinsur.bo;

namespace MTREG.medinsur
{
    public partial class FrmAreaInfodet : Form
    {        
        BllInsurMethod bllInsurMethod = new BllInsurMethod();
        FrmAreaInfo frmAreaInfo;
        string areaid;
        public FrmAreaInfo FrmAreaInfo
        {
            get { return frmAreaInfo; }
            set { frmAreaInfo = value; }
        }

        public FrmAreaInfodet()
        {
            InitializeComponent();
        }

        private void FrmAreaInfodet_Load(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            DataTable dtInsur = bllInsurMethod.insurtypeInfo();
            cmbInsurtype.DisplayMember = "name";
            cmbInsurtype.ValueMember = "id";
            cmbInsurtype.DataSource = dtInsur;

            areaid = frmAreaInfo.AreaInfo.Id;
            cmbInsurtype.SelectedValue = frmAreaInfo.AreaInfo.Cost_insurtype_id;
            tbxInsuritemtype.Text = frmAreaInfo.AreaInfo.Insuritemtype;
            tbxAreacode.Text = frmAreaInfo.AreaInfo.Areacode;
            tbxAreaname.Text = frmAreaInfo.AreaInfo.Areaname;
            tbxMemo.Text = frmAreaInfo.AreaInfo.Memo;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bllInsurMethod.upAreaInfo(tbxInsuritemtype.Text, tbxAreaname.Text,tbxAreacode.Text,tbxMemo.Text,areaid) < 0)
            {
                MessageBox.Show("编辑保存失败!","提示信息");
                return;
            }
            MessageBox.Show("保存成功!");
            this.Close();
        }
    }
}
