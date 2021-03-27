using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTHIS.common;
using MTREG.common;
using MTHIS.main.bll;

namespace MTREG.medinsur.ahsjk
{
    public partial class FrmItemcrossAhsjnh : Form
    {
        BllAhsnhMethod bllAhsnhMethod = new bll.BllAhsnhMethod();
        public FrmItemcrossAhsjnh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 上传项目信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_scxmxx_Click(object sender, EventArgs e)
        {
            string lx = "9";
            string yplx = this.TextBox_Yylx.Text.Trim();
            if (yplx == "西药")
            {
                lx = "0";
            }
            if (yplx == "中成药")
            {
                lx = "1";
            }
            if (yplx == "中草药")
            {
                lx = "2";
            }

            /* 调用WebService实现代码 begin */
            In_ItemContrastUp inp = new In_ItemContrastUp();
            //初始化inp输入参数 begin
            DataTable dt= bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SCenterItemC = TextBox_nhbm.Text;//中心项目编码
            inp.SItemCode = this.tbx_bh.Text.Trim();
            inp.SItemName = this.TextBox_Yymc.Text.Trim();
            inp.SItemSpec = "无";
            inp.SItemDose = "无";
            inp.SItemArea = "无";
            inp.SItemProc = "无";
            inp.SItemPart = "无";
            inp.SUnit = txt_unit.Text;
            inp.SPrice = TextBox_Yydj.Text;
            inp.SItemType = lx;
            //初始化inp输入参数 end
            retMesage ret = bllAhsnhMethod.itemContrastUp(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show("失败信息:" + ret.Ret_mesg + ",", "提示信息");
                return;
            }
            /* 调用WebService实现代码 end */

            MessageBox.Show("上传成功！", "提示信息");
        }

        private void FrmItemcrossAhsjnh_Load(object sender, EventArgs e)
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

        private void TextBox_Jm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.textbox_jm_keyup();
            }            
        }
        private void textbox_jm_keyup()
        {
            string itemfrom = "";
            string isCross = "";
            if (radioButton_yp.Checked == true)
            {
                itemfrom = "'DRUG'";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "'COST'";
            }
            else if (radioButton_jc.Checked == true)
            {
                
            }
            else if (radioButton_cl.Checked == true)
            {
                itemfrom = "'STUFF'";
            }
            if (checkBox_sfdy.Checked == true)
                isCross = "0";
            else
                isCross = "-1";
            if (TextBox_Jm.Text == "")
            {
                //清空
                this.qkjm();
                this.TextBox_Jm.Focus();
                this.dgvItemInfo.DataSource = null;
            }
            dgvItemInfo.Columns.Clear();
            dgvItemInfo.DataSource = bllAhsnhMethod.getItemInfo(TextBox_Jm.Text.Trim(), itemfrom, isCross);
            #region updateHeaderText
            dgvItemInfo.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));
            dgvItemInfo.Columns["id"].HeaderText = "编码";
            dgvItemInfo.Columns["id"].DisplayIndex = 0;
            dgvItemInfo.Columns["standcode"].HeaderText = "His编码";
            dgvItemInfo.Columns["standcode"].DisplayIndex = 1;
            dgvItemInfo.Columns["standcode"].Width = 100;
            dgvItemInfo.Columns["name"].HeaderText = "His名称";
            dgvItemInfo.Columns["name"].Width = 100;
            dgvItemInfo.Columns["name"].DisplayIndex = 2;
            dgvItemInfo.Columns["insurcode"].HeaderText = "农合编码";
            dgvItemInfo.Columns["insurcode"].DisplayIndex = 3;
            dgvItemInfo.Columns["insurcode"].Width = 100;
            dgvItemInfo.Columns["name2"].HeaderText = "农合名称";
            dgvItemInfo.Columns["name2"].Width = 100;
            dgvItemInfo.Columns["name2"].DisplayIndex = 4;
            dgvItemInfo.Columns["unit"].HeaderText = "规格";
            dgvItemInfo.Columns["unit"].Width = 100;
            dgvItemInfo.Columns["unit"].DisplayIndex = 5;
            dgvItemInfo.Columns["spec"].HeaderText = "单位";
            dgvItemInfo.Columns["spec"].Width = 100;
            dgvItemInfo.Columns["spec"].DisplayIndex = 6;
            dgvItemInfo.Columns["itemfrom"].Visible = false;
            dgvItemInfo.ReadOnly = true;
            dgvItemInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItemInfo.MultiSelect = false;
            if (dgvItemInfo.Rows.Count > 0)
            {
                dgvItemInfo.Rows[0].Selected = true;
            }
            #endregion
        }
        /// <summary>
        /// 对应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_dy_Click(object sender, EventArgs e)
        {
            string id=dgvItemInfo.SelectedRows[0].Cells["id"].ToString();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("请先在表格中进行选择!");
                return;
            }
            string sql = "update cost_insuritem set standcode=" + DataTool.addFieldBraces(tbx_nhfhyybm.Text)
                + ",name=" + DataTool.addFieldBraces(tbx_nhfhyymc.Text)
                + ",name2=" + DataTool.addFieldBraces(tbx_nhfhyymc.Text)
                + ",insurcode=" + DataTool.addFieldBraces(tbx_nhfhyymc.Text)
                + ",approve=" + DataTool.addFieldBraces(tbx_nhfhyymc.Text)
                + " where id=" + DataTool.addIntBraces(id)+";";
            string item_id=bllAhsnhMethod.getItemid(TextBox_Jm.Text);
            string insurid = bllAhsnhMethod.getInsurid(CostInsurtypeKeyname.AHSJNH.ToString());
            sql += "insert into cost_insurcross(id,cost_insurtype_id,item_id,cost_insuritem_id)"
                + "values(" + DataTool.addIntBraces(BillSysBase.nextId("cost_insurcross"))
                + "," + DataTool.addFieldBraces(insurid)
                + "," + DataTool.addFieldBraces(item_id)
                + "," + DataTool.addFieldBraces(id)
                +");";
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("对应失败!");
                return;
            }
            MessageBox.Show("对应成功!");
        }
        /// <summary>
        /// 项目对照审核结果查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_hqdzxx_Click(object sender, EventArgs e)
        {
            string lx = "9";
            string yplx = this.TextBox_Yylx.Text.Trim();
            if (yplx == "西药")
            {
                lx = "0";
            }
            if (yplx == "中成药")
            {
                lx = "1";
            }
            if (yplx == "中草药")
            {
                lx = "2";
            }            
            In_ItemContrastDown inp = new In_ItemContrastDown();
            DataTable dt = bllAhsnhMethod.getWebUrl(this.cmbArea.SelectedValue.ToString());
            inp.SAreaCode = dt.Rows[0]["areacode"].ToString();//地区代码
            inp.Weburl = dt.Rows[0]["weburl"].ToString();
            inp.SHospitalCode = dt.Rows[0]["hospitalcode"].ToString();//医疗机构编码
            inp.SCenterItemC = TextBox_nhbm.Text.Trim();//中心项目编码
            inp.SItemCode = tbx_bh.Text.Trim();//his编码
            retMesage ret=bllAhsnhMethod.itemContrastDown(inp);
            if (!ret.Ret_flag)
            {
                MessageBox.Show(ret.Ret_mesg,"提示信息");
                return;
            }
            Out_ItemContrastDown outp = (Out_ItemContrastDown)ret.Ret_data[0];
            string state = "";           
            switch(outp.SState)
            {
                case "0":state="未审核";break;
                case "1": state = "审核通过"; break;
                case "2": state = "审核未通过"; break;
                case "3": state = "再次上报待通过"; break;
                case "9": state = "中心未找到(未上传)"; break;
            }
            tbx_nhfhfylx.Text = lx;//费用类型
            tbx_nhfhshzt.Text = state;//审核结果
            tbx_nhfhshr.Text = outp.SAuditName;//审核人
            tbx_nhfhshsj.Text = outp.SAuditDate;//审核时间
            tbx_btgyy.Text = outp.SReason;//审核不通过原因
        }

        private void dgvItemInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.Yyxx(e.RowIndex);
            }

            return;
        }

        private void dgvItemInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvItemInfo.RowCount > 0)
            {
                int idx = this.dgvItemInfo.CurrentRow.Index;
                this.Yyxx(idx);
            }
        }
        private void Yyxx(int rowindex)
        {
            string nhbm = this.dgvItemInfo.Rows[rowindex].Cells["insurcode"].Value.ToString();
            string Yymc = this.dgvItemInfo.Rows[rowindex].Cells["name"].Value.ToString();
            string Yylx = this.dgvItemInfo.Rows[rowindex].Cells["itemfrom"].Value.ToString();
            string Yydj = this.dgvItemInfo.Rows[rowindex].Cells["unit"].Value.ToString();
            string nhmc = this.dgvItemInfo.Rows[rowindex].Cells["name2"].Value.ToString();
            string Yybh = this.dgvItemInfo.Rows[rowindex].Cells["standcode"].Value.ToString();
            string unit = this.dgvItemInfo.Rows[rowindex].Cells["unit"].Value.ToString();
            this.TextBox_nhbm.Text = nhbm;//医院药品回显
            this.TextBox_Yymc.Text = Yymc;//医院名称回显
            this.TextBox_Yylx.Text = Yylx;//医院类型回显
            this.TextBox_Yydj.Text = Yydj;//医院单价回显
            this.TextBox_nhmc.Text = nhmc;//农合名称
            this.tbx_bh.Text = Yybh;//医院
            this.txt_unit.Text = unit;
        }
        private void qkjm()
        {
            this.tbx_nhfhyybm.Text = "";
            this.tbx_nhfhyymc.Text = "";
            this.tbx_nhfhnhbm.Text = "";
            this.tbx_nhfhnhmc.Text = "";
            this.tbx_nhfhfylx.Text = "";
            this.tbx_nhfhshzt.Text = "";
            this.tbx_nhfhshr.Text = "";
            this.tbx_nhfhshsj.Text = "";
            this.tbx_btgyy.Text = "";
            this.TextBox_nhbm.Text = "";
            this.TextBox_Yymc.Text = "";
            this.TextBox_Yylx.Text = "";
            this.TextBox_Yydj.Text = "";
            this.TextBox_nhmc.Text = "";
            this.tbx_bh.Text = "";
        }

        private void but_qxdy_Click(object sender, EventArgs e)
        {            
            string id = dgvItemInfo.SelectedRows[0].Cells["id"].ToString();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("请先在表格中进行选择!");
                return;
            }
            string sql = "update cost_insuritem set approve='未审核' where id="+DataTool.addIntBraces(id)+";";
            sql += "delete from cost_insurcross where cost_insuritem_id=" + DataTool.addIntBraces(id);
            if (BllMain.Db.Update(sql) < 0)
            {
                MessageBox.Show("取消对照失败!");
                return;
            }
            MessageBox.Show("取消对照成功!");
        }
    }
}
