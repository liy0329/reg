using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.sys.bll;
using MTHIS.db;
using MTHIS.common;
using MTHIS.chklist;

namespace MTHIS.sys
{
    public partial class FrmPrintSetting : Form
    {
        BllPrint bllprint = new BllPrint();
        public FrmPrintSetting()
        {
            InitializeComponent();
        }

        #region 回车下移
        /// <summary>
        /// 按回车光标下移打印名称框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPrintcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPrintname.Focus();
            }
        }
        /// <summary>
        /// 按回车光标下移坐标值框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPrintname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxX_val.Focus();
            }
        }
        /// <summary>
        /// 按回车光标下移坐标轴框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxX_val_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxY_val.Focus();
            }
        }
        /// <summary>
        /// 按回车光标下移到是否使用框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxY_val_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxIsused.Focus();
            }
        }
        /// <summary>
        /// 按回车光标下移到打印预览框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxIsused_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxIsprintview.Focus();
            }
        }
        /// <summary>
        /// 按回车光标下移到保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxiSprintview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxTmpName.Focus();
            }
        }
        #endregion

        /// <summary>
        /// 页面加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrint_Load(object sender, EventArgs e)
        {
            load();
        }
        /// <summary>
        /// dataGrindView绑定加载数据
        /// </summary>
        private void load()
        {
            this.dataGridView1.DataSource = bllprint.SelectData();
            this.dataGridView1.Columns["id"].HeaderText = "编码";
            this.dataGridView1.Columns["codeid"].HeaderText = "打印编码";
            this.dataGridView1.Columns["name"].HeaderText = "打印名称";
            this.dataGridView1.Columns["point_x"].HeaderText = "坐标值";
            this.dataGridView1.Columns["point_y"].HeaderText = "坐标轴";
            this.dataGridView1.Columns["isstop"].HeaderText = "是否停用";
            this.dataGridView1.Columns["ispreview"].HeaderText = "打印预览";
            this.dataGridView1.Columns["frmurl"].HeaderText = "模板名称";

            this.lbl_stateshow.Text = "";
            BllPrint bllPrint=new BllPrint();
            this.lblSysm_id.Text = bllPrint.getSysm_id();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxPrintcode.Text == null || tbxPrintcode.Text.Equals(" "))
            {
                MessageBox.Show("请输入编码！");
                tbxPrintcode.Focus();
                return;

            }
            if (tbxPrintname.Text == null || tbxPrintname.Text.Equals(" "))
            {
                MessageBox.Show("请输入打印名称！");
                tbxPrintname.Focus();
                return;

            }
            if (string.IsNullOrEmpty(tbxTmpName.Text) || tbxTmpName.Text.Equals(" "))
            {
                MessageBox.Show("请输入模板名称！");
                tbxTmpName.Focus();
                return;
            }
            int opstat = saveItemData();
            if (opstat < 0)
            {
                MessageBox.Show("保存失败");
                return;
            }
            if (opstat == 1)
            {
                MessageBox.Show("保存成功");
                load();
                this.btnAdd.Focus();
                return;
            }
            MessageBox.Show("保存成功");
            load();
        }

        private void ShowData()
        {
            BllPrint blllist = new BllPrint();
            DataTable dt = blllist.SelectData();
            if (dt.Rows.Count > 0)
            {
                this.dataGridView1.DataSource = dt;
            }
        }
        private void setItemInputData()
        {
            //控制项
            this.lblOpstat.Text = "1";//0:增加 1:修改 2:删除
            this.lbl_stateshow.Text = "编辑状态";
            //this.btnCancel.Enabled = true;

            //数据项
            if (this.dataGridView1.CurrentRow != null)
            {
                DataRow row = ((DataTable)(dataGridView1.DataSource)).Rows[this.dataGridView1.CurrentRow.Index];//获取GrideView的每一行
                this.lblPrintId.Text = row["id"].ToString();
                this.tbxPrintcode.Text = row["codeid"].ToString();
                this.tbxPrintname.Text = row["name"].ToString();
                this.tbxX_val.Text = row["point_x"].ToString();
                this.tbxY_val.Text = row["point_y"].ToString();
                this.cbxIsused.Text = row["isstop"].ToString();
                this.cbxIsprintview.Text = row["ispreview"].ToString();
                if (row["frmurl"] != null)
                    this.tbxTmpName.Text = row["frmurl"].ToString();
            }

        }
        private void resetItemInputData()
        {
            //控制项
            this.lblPrintId.Text = "";
            this.lblOpstat.Text = "0";//0:增加 1:修改 2:删除
            this.lbl_stateshow.Text = "当前处于添加状态";
            //this.btnCancel.Enabled = true;
            //数据项
            this.tbxPrintcode.Text = "";
            this.tbxPrintname.Text = "";
            this.tbxX_val.Text = "";
            this.tbxY_val.Text = "";
            this.tbxTmpName.Text = "";
            this.cbxIsused.SelectedIndex = 1;
            this.cbxIsprintview.SelectedIndex = 0;
            tbxPrintcode.Focus();

        }

        private int saveItemData()
        {
            string id = this.lblPrintId.Text.Trim();
            string printcode = this.tbxPrintcode.Text.ToString();
            string printname = this.tbxPrintname.Text.ToString();
            string x = this.tbxX_val.Text;
            string y = this.tbxY_val.Text.ToString();
            string isused = "N";
            string isprintview = "N";
            string templatename = this.tbxTmpName.Text;
            if (this.cbxIsused.Text == "是")
                isused = "Y";
            if (this.cbxIsprintview.Text == "是")
                isprintview = "Y";
            int ret = -1;
            if (lblOpstat.Text.Trim().Equals("0"))
            {
                if (bllprint.insertItemData(printcode, printname, x, y, isused, isprintview, templatename,this.lblSysm_id.Text) != -1)
                    ret = 1;
            }
            else
            {
                if (bllprint.updateItemData(id, printcode, printname, x, y, isused, isprintview, templatename, this.lblSysm_id.Text) != -1)
                    ret = 2;
            }
            return ret;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="printId">打印表主键值</param>
        /// <returns>0:成功 -1:失败</returns>
        private int deleteItemData(string printId)
        {
            int ret = 0;
            if (lblOpstat.Text.Equals("2"))
            {
                ret = bllprint.deleteItemData(printId);
            }
            return ret;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.lbl_stateshow.Text = "您现在处于添加状态";
            resetItemInputData();

        }
        /// <summary>
        /// 点删除键要执行删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.lblOpstat.Text = "2";
                if (deleteItemData(lblPrintId.Text.Trim()) == 0)
                    MessageBox.Show("删除成功");
                this.load();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.lbl_stateshow.Text = "您现在处于编辑状态";
            setItemInputData();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                                                          TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void tbxX_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 & (int)e.KeyChar <= 57 | (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbxY_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 & (int)e.KeyChar <= 57 | (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbxIsused_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tbxTmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        //预览报告
        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                string tempName = this.dataGridView1.CurrentRow.Cells["frmurl"].Value.ToString();
                string tempPath = GlobalParams.reportDir + "\\" + tempName;
                try
                {
                    FastReport.Report temp = new FastReport.Report();
                    temp.Load(tempPath);
                    temp.Design();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开设置界面失败！");
                }
            }
        }

        private void btnChanagePrinter_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
                return;
            String rptName = this.dataGridView1.CurrentRow.Cells["frmurl"].Value.ToString();
            if (String.IsNullOrEmpty(rptName))
            {
                MessageBox.Show("没有指定报告单模板");
                return;
            }
            Ini.INIClass(GlobalParams.syspath);
            String printerName = Ini.IniReadValue("reportprint", rptName);
            MTHIS.chklist.FrmChanagePrinter frm = new MTHIS.chklist.FrmChanagePrinter(rptName, printerName);
            frm.ShowDialog();
        }

    }
}
