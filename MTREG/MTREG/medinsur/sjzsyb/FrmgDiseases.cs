using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmgDiseases : Form
    {
        public FrmgDiseases()
        {
            InitializeComponent();
        }
        private void FrmgDiseases_Load(object sender, EventArgs e)
        {
            //窗体默认的大小
            this.WindowState = FormWindowState.Normal;
            //DGV里的数据居中
            //dv_insuritem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dv_insuritem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dV_item.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dV_item.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //去掉dgv空白行
            dgv_ybbz.AllowUserToAddRows = false;
            dgv_zdlb.AllowUserToAddRows = false;
            dgv_HISBZ.AllowUserToAddRows = false;
            //初始化医保病种
            Contrast();
            //初始化HIS诊断类别();
            HISDiagnosis();
            //双击添加病种初始化
            BZInitialize();
            try
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnModify";
                btn.HeaderText = "删除";
                btn.DefaultCellStyle.NullValue = "删除";
                dgv_HISBZ.Columns.Add(btn);
                dgv_HISBZ.Columns["btnModify"].HeaderText = "删除";
                dgv_HISBZ.Columns["btnModify"].Width = 50;
                dgv_HISBZ.Columns["btnModify"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 初始化HIS诊断类别
        /// </summary>
        public void HISDiagnosis()
        {
            string diaType = "";
            if (rd_xy.Checked == true)//西医诊断
                diaType = "1";
            else if (rd_zy.Checked == true)//中医诊断
                diaType = "2";
            else if (rd_zyzh.Checked == true)//症候
                diaType = "3";
            Yb_Itme yb_item = new Yb_Itme();
            string HISM = TB_hism.Text;
            string HISBM = TB_jbbm.Text;
            DataTable dt = yb_item.Diagnostics(HISM, HISBM, diaType);
            dgv_zdlb.DataSource = dt;
        }
        /// <summary>
        /// 初始化医保病种
        /// </summary>
        public void Contrast()
        {
            Yb_Itme yb_item = new Yb_Itme();
            string ybpym = tB_ybpym.Text;
            string ybbzm = tB_ybbzm.Text;
            //string itemfrom = "";
            //if (rd_xy.Checked == true)
            //{
            //    itemfrom = "DRUG";
            //}
            DataTable dt = yb_item.entityContrast(ybpym, ybbzm, "");
            dgv_ybbz.DataSource = dt;
        }
        private void tB_ybpym_TextChanged(object sender, EventArgs e)
        {
            Contrast();
        }
        private void tB_ybbzm_TextChanged(object sender, EventArgs e)
        {
            Contrast();
        }
        private void TB_hism_TextChanged(object sender, EventArgs e)
        {
            HISDiagnosis();
        }
        private void TB_jbbm_TextChanged(object sender, EventArgs e)
        {
            HISDiagnosis();
        }

        private void dgv_ybbz_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_zdlb.CurrentRow == null)
            {
                MessageBox.Show("未添加院内病种", "提示");
                return;
            }
            if (dgv_ybbz.CurrentRow == null)
            {
                MessageBox.Show("未添加医保病种", "提示");
                return;
            }
            //HIS病种
            int Index = dgv_zdlb.CurrentRow.Index;
            //医保病种
            int Index1 = dgv_ybbz.CurrentRow.Index;

            string hiscode = dgv_zdlb.Rows[Index].Cells["HIS病种编码"].Value.ToString();
            string hisname = dgv_zdlb.Rows[Index].Cells["HIS病种名称"].Value.ToString();
            string hisid = dgv_zdlb.Rows[Index].Cells["HIS编号"].Value.ToString();

            string ybname = dgv_ybbz.Rows[Index1].Cells["病种名称"].Value.ToString();
            string ybid = dgv_ybbz.Rows[Index1].Cells["编号"].Value.ToString();
            string ybcode = dgv_ybbz.Rows[Index1].Cells["病种编码"].Value.ToString();

            DialogResult result = MessageBox.Show("是否对照:" + "【" + hisname + "】" + "【" + ybname + "】", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Yb_Itme yb_item = new Yb_Itme();
                string sql = yb_item.plot(hisid, hisname, hiscode, ybid, ybname, ybcode);
                sql += yb_item.setbas_caseicd(hisid,"Y");
                if (yb_item.doExeSql(sql) == -1)
                {
                    MessageBox.Show("添加病种对照失败", "提示");
                    return;
                }
                BZInitialize();
                DataGridViewColumn col = dgv_HISBZ.Columns[1];
                //按降序(即始终每次新添加的数据排最前)
                ListSortDirection direction = ListSortDirection.Descending;
                dgv_HISBZ.Sort(col, direction);
            }
            //}catch(Exception ex)
            //{

            //}

        }
        /// <summary>
        /// 病种对照初始化
        /// </summary>
        public void BZInitialize()
        {
            Yb_Itme yb_item = new Yb_Itme();
            string Title = TB_mcgl.Text;
            DataTable dt = yb_item.Theplot(Title);
            dgv_HISBZ.DataSource = dt;

            #region
            dgv_HISBZ.Columns["编号"].Visible = false;
            dgv_HISBZ.Columns["his数据ID"].HeaderText = "his数据ID";
            dgv_HISBZ.Columns["his数据ID"].DisplayIndex = 1;
            dgv_HISBZ.Columns["his数据ID"].Width = 100;
            dgv_HISBZ.Columns["his名称"].HeaderText = "his名称";
            dgv_HISBZ.Columns["his名称"].DisplayIndex = 2;
            dgv_HISBZ.Columns["his名称"].Width = 200;
            dgv_HISBZ.Columns["his疾病编码"].HeaderText = "his疾病编码";
            dgv_HISBZ.Columns["his疾病编码"].DisplayIndex = 3;
            dgv_HISBZ.Columns["his疾病编码"].Width = 150;
            
            dgv_HISBZ.Columns["医保名称"].HeaderText = "医保名称";
            dgv_HISBZ.Columns["医保名称"].DisplayIndex = 4;
            dgv_HISBZ.Columns["医保名称"].Width = 200;
            dgv_HISBZ.Columns["医保编码"].HeaderText = "医保编码";
            dgv_HISBZ.Columns["医保编码"].DisplayIndex = 5;
            dgv_HISBZ.Columns["医保编码"].Width = 150;
            dgv_HISBZ.Columns["医保疾病编码"].HeaderText = "医保疾病编码";
            dgv_HISBZ.Columns["医保疾病编码"].DisplayIndex = 6;
            dgv_HISBZ.Columns["医保疾病编码"].Width = 200;
            #endregion
        }
        /// <summary>
        /// 文本框输出读取刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_mcgl_TextChanged(object sender, EventArgs e)
        {
            BZInitialize();
        }
        /// <summary>
        /// 对照数据库删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HISBZ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_HISBZ.Columns[e.ColumnIndex].Name == "btnModify")
                {
                    foreach (DataGridViewRow bt in dgv_HISBZ.SelectedRows)
                    {
                        Yb_Itme yb = new Yb_Itme();
                        int Index = dgv_HISBZ.CurrentRow.Index;
                        string SMSJ = dgv_HISBZ.Rows[Index].Cells["编号"].Value.ToString();
                        string sql = "delete from insur_directory_contrast where id=" + SMSJ + ";";
                        string hisid = dgv_HISBZ.Rows[Index].Cells["his数据ID"].Value.ToString();
                        sql += yb.setbas_caseicd(hisid, "N");
                        //if (bt.IsNewRow == false)//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                        yb.doExeSql(sql);
                        BZInitialize();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// 单击HISDGV显示对应得病种DGV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_zdlb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Yb_Itme yb_item = new Yb_Itme();
            //int Index = dgv_zdlb.CurrentRow.Index;
            //string hisdy = dgv_zdlb.Rows[Index].Cells["HIS病种名称"].Value.ToString();
            ////string itemfrom = "";
            ////if (rd_xy.Checked == true)
            ////{
            ////    itemfrom = "DRUG";
            ////}
            ////else if (rd_zy.Checked == false)
            ////{
            ////    itemfrom = "COST";
            ////}
            ////else if (rd_zyzh.Checked == false)
            ////{
            ////    itemfrom = "BED";
            ////}
            //DataTable dt = yb_item.entityContrast("","", hisdy);
            //dgv_ybbz.DataSource = dt;
        }

        private void rd_xy_CheckedChanged(object sender, EventArgs e)
        {
            HISDiagnosis();
        }

        private void rd_zy_CheckedChanged(object sender, EventArgs e)
        {
            HISDiagnosis();
        }

        private void rd_zyzh_CheckedChanged(object sender, EventArgs e)
        {
            HISDiagnosis();
        }
    }
}
