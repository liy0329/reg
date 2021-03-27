using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.sjzsyb.clinic;
using MTREG.clinic.bll;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.dor;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmrelationship : Form
    {
        public Frmrelationship()
        {
            InitializeComponent();
        }
        Sjzsyb syb = new Sjzsyb();
        DataTable dtsm = new DataTable();
        DataTable dtInfo = new DataTable();

        private void Frmrelationship_Load(object sender, EventArgs e)
        {

            
            //去掉空白行
            dV_item.AllowUserToAddRows = false;
            dv_dzxx.AllowUserToAddRows = false;
            rdBt_YPml.Checked = true;
            //项目定义初始化
            initXMDI();
            //查询医保目录对照初始化
            CareSepel();
            //cost_insurcross
            inidata();
            
            
        }
        /// <summary>
        /// 初始化data
        /// </summary>
        public void inidata()
        {
            this.WindowState = FormWindowState.Normal;
            dv_insuritem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dv_insuritem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dV_item.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dV_item.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //对照初始化
            shux();
            try
            {
                DataGridViewColumn col = dv_dzxx.Columns[1];
                //按降序(即始终每次新添加的数据排最前)
                ListSortDirection direction = ListSortDirection.Descending;
                dv_dzxx.Sort(col, direction);
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnModify";
                btn.HeaderText = "删除";
                btn.DefaultCellStyle.NullValue = "删除";
                dv_dzxx.Columns.Add(btn);
                dv_dzxx.Columns["btnModify"].HeaderText = "删除";
                dv_dzxx.Columns["btnModify"].Width = 50;
                dv_dzxx.Columns["btnModify"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {

            }
            for (int i = 0; i < dv_dzxx.Rows.Count; i++)
            {
                if (dv_dzxx.Rows[i].Cells["审核状态"].Value.ToString() == "未审核")
                    dv_dzxx.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//已审核黄色
                if (dv_dzxx.Rows[i].Cells["审核状态"].Value.ToString() == "审核未通过")
                    dv_dzxx.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            }
        }
        /// 项目定义类型
        public void initXMDI()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("", "全部"));
            items.Add(new ListItem("COST", "费用"));
            items.Add(new ListItem("DRUG", "药品"));
            items.Add(new ListItem("MSG", "信息"));
            items.Add(new ListItem("STUFF", "材料"));
            this.cmB_HISlxgl.DisplayMember = "Text";
            this.cmB_HISlxgl.ValueMember = "Value";
            this.cmB_HISlxgl.DataSource = items;

        }
        //HIS运行下拉选项
        private void cmB_HISlxgl_SelectedIndexChanged(object sender, EventArgs e)
        {
            mhcxpygl();
        }

        ///直接根据下来跟名字来搜索
        public void mhcxpygl()
        {
            Yb_Itme yb_item = new Yb_Itme();
            string name = tB_HISpymgl.Text;
            string type = cmB_HISlxgl.SelectedValue.ToString();
            DataTable dt = yb_item.QBall(name, type);
            dV_item.DataSource = dt;

            for (int i = 0; i < dV_item.Rows.Count; i++)
            {
                if (dV_item.Rows[i].Cells["isstop"].Value.ToString() == "T")
                    dV_item.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//已审核黄色
                if (dV_item.Rows[i].Cells["isstop"].Value.ToString() == "Y")
                    dV_item.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            }
        }
        //HIS自动显示
        private void tB_HISpymgl_TextChanged(object sender, EventArgs e)
        {
            mhcxpygl();
        }
        //回车显示模糊查询拼音过滤
        private void tB_HISpymgl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mhcxpygl();
            }
        }

        //分割线————————————————————————————————————
        //医保拼音码过滤
        private void tb_ybpymgl_TextChanged(object sender, EventArgs e)
        {
            Yb_Itme yb_item = new Yb_Itme();
            string Healthspell = tb_ybpymgl.Text;

            string itemfrom = "";
            if (rdBt_YPml.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (rdBt_Zlml.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (rdBt_FWssml.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery(Healthspell, "", "", itemfrom);
            dv_insuritem.DataSource = dt;

            //for (int i = 0; i < dv_insuritem.Rows.Count; i++)
            //{
            //    if (dv_insuritem.Rows[i].Cells["有效标志"].Value != null && dv_insuritem.Rows[i].Cells["有效标志"].Value.ToString() == "停用")
            //        dv_insuritem.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            //}

        }
        //医保模糊查询DGV调用方法
        public void CareSepel()
        {
            Yb_Itme yb_item = new Yb_Itme();
            string Healthspell = tb_ybpymgl.Text;
            string HealthBOT = tb_ybxmmcgl.Text;
            string Healthcoding = tb_ybxmbmgl.Text;

            string itemfrom = "";
            if (rdBt_YPml.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (rdBt_Zlml.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (rdBt_FWssml.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery(Healthspell, HealthBOT, Healthcoding, itemfrom);
            dv_insuritem.DataSource = dt;
            //for (int i = 0; i < dv_insuritem.Rows.Count; i++)
            //{
            //    if (dv_insuritem.Rows[i].Cells["有效标志"].Value != null && dv_insuritem.Rows[i].Cells["有效标志"].Value.ToString() == "停用")
            //        dv_insuritem.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            //}
        }
        //医保项目名称过滤
        private void tb_ybxmmcgl_TextChanged(object sender, EventArgs e)
        {

            Yb_Itme yb_item = new Yb_Itme();
            string HealthBOT = tb_ybxmmcgl.Text;

            string itemfrom = "";
            if (rdBt_YPml.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (rdBt_Zlml.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (rdBt_FWssml.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery("", HealthBOT, "", itemfrom);
            dv_insuritem.DataSource = dt;
            //for (int i = 0; i < dv_insuritem.Rows.Count; i++)
            //{
            //    if (dv_insuritem.Rows[i].Cells["有效标志"].Value != null && dv_insuritem.Rows[i].Cells["有效标志"].Value.ToString() == "停用")
            //        dv_insuritem.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            //}

        }
        //医保项目编码过滤
        private void tb_ybxmbmgl_TextChanged(object sender, EventArgs e)
        {
            Yb_Itme yb_item = new Yb_Itme();
            string Healthcoding = tb_ybxmbmgl.Text;

            string itemfrom = "";
            if (rdBt_YPml.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (rdBt_Zlml.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (rdBt_FWssml.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery("", "", Healthcoding, itemfrom);
            dv_insuritem.DataSource = dt;
            //for (int i = 0; i < dv_insuritem.Rows.Count; i++)
            //{
            //    if (dv_insuritem.Rows[i].Cells["有效标志"].Value != null && dv_insuritem.Rows[i].Cells["有效标志"].Value.ToString() == "停用")
            //        dv_insuritem.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            //}
        }
        //点击扩展DGV对应显示方法
        private void dV_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Yb_Itme yb_item = new Yb_Itme();
            int Index = dV_item.CurrentRow.Index;
            string ClickYB = dV_item.Rows[Index].Cells["项目名称"].Value.ToString();
            string itemfrom = "";
            if (rdBt_YPml.Checked == true)
            {
                itemfrom = "DRUG";
            }
            else if (rdBt_Zlml.Checked == true)
            {
                itemfrom = "COST";
            }
            else if (rdBt_FWssml.Checked == true)
            {
                itemfrom = "BED";
            }
            DataTable dt = yb_item.Healthquery("", ClickYB, "", itemfrom);
            dv_insuritem.DataSource = dt;
        }

        private void tb_ybxmmcgl_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //双击单元格进行对照
        private void dv_insuritem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dV_item.CurrentRow.Index;
            int Index1 = dv_insuritem.CurrentRow.Index;

            string HIS110 = dV_item.Rows[Index].Cells["项目名称"].Value.ToString();
            string YB110 = dv_insuritem.Rows[Index1].Cells["项目名称"].Value.ToString();
            //项目定义类型
            string AKC224 = dv_insuritem.Rows[Index1].Cells["项目定义类型"].Value.ToString();
            //医保id
            string YB515 = dv_insuritem.Rows[Index1].Cells["id"].Value.ToString();
            //项目id
            string his515 = dV_item.Rows[Index].Cells["id"].Value.ToString();

            string HIS077 = dv_insuritem.Rows[Index1].Cells["医保项目编码"].Value.ToString();

            string xianzhi = dv_insuritem.Rows[Index1].Cells["限制使用信息"].Value.ToString();

            string HIS00 = dv_insuritem.Rows[Index1].Cells["医保等级"].Value.ToString();

            string HIS0771 = dV_item.Rows[Index].Cells["his编码"].Value.ToString();

            string HIS0772 = dV_item.Rows[Index].Cells["停用"].Value.ToString();
            DialogResult result = MessageBox.Show("是否对照:" + "【" + HIS110 + "】" + "【" + YB110 + "】", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Yb_Itme yb_item = new Yb_Itme();
                string sql = yb_item.Thecomparison(AKC224, his515, YB515, HIS077, YB110, HIS00, xianzhi, HIS0771);
                if (yb_item.doExeSql(sql) == -1)
                    MessageBox.Show("保存失败！","提示");
                shux();

                
            }
        }
        string id;
        public void shux()
        {
            Yb_Itme yb_item = new Yb_Itme();
            DataTable dt = yb_item.Thequery(ref id);
            dv_dzxx.DataSource = dt;

            if (dv_dzxx.CurrentRow == null)
            {
                return;
            }

            for (int i = 0; i < dv_dzxx.Rows.Count; i++)
            {
                if (dv_dzxx.Rows[i].Cells["审核状态"].Value.ToString() == "N")
                    dv_dzxx.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//已审核黄色
                if (dv_dzxx.Rows[i].Cells["审核状态"].Value.ToString() == "Y")
                    dv_dzxx.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            }
            //string sql = "SELECT cost.id AS'主键',cost.cost_insurtype_id AS'医保类型',cost.insuritemtype AS'医保目录类型码',cost.itemfrom AS'项目定义类型',cost.item_id AS'项目外键',cost.drug_factyitem_id AS'厂家序列',cost.cost_insuritem_id AS'医保目录',cost.insurcode AS'医保编码',cost.insurname AS'项目名称',cost.insurclass AS'医保等级',cost.limituse AS'11',cost.hiscode AS'his编码',cost.Isstop AS'停用'from cost_insurcross cost";
        }

        private void dv_dzxx_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Yb_Itme yb = new Yb_Itme();
                int Index = dv_dzxx.CurrentRow.Index;
                string SMSJ = dv_dzxx.Rows[Index].Cells["主键"].Value.ToString();
                DialogResult DV_dzsj = MessageBox.Show("删除:" + "【" + SMSJ + "】", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DV_dzsj == DialogResult.Yes)
                {
                    foreach (DataGridViewRow bt in dv_dzxx.SelectedRows)
                    {
                        string sql = "delete from cost_insurcross where id=" + SMSJ;
                        //if (bt.IsNewRow == false)//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                        yb.doExeSql(sql);
                        shux();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }
        //单击删除按钮删除
        private void dv_dzxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv_dzxx.Columns[e.ColumnIndex].Name == "btnModify")
            {
                foreach (DataGridViewRow bt in dv_dzxx.SelectedRows)
                {
                    Yb_Itme yb = new Yb_Itme();
                    int Index = dv_dzxx.CurrentRow.Index;
                    string SMSJ = dv_dzxx.Rows[Index].Cells["编号"].Value.ToString();
                    string sql = "delete from cost_insurcross where id=" + SMSJ;
                    //if (bt.IsNewRow == false)//如果不是已提交的行，默认情况下在添加一行数据成功后，DataGridView为新建一行作为新数据的插入位置
                    yb.doExeSql(sql);
                    shux();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //药品
            SJZYB_IN<declare_yp_In> yb_in_yp = new SJZYB_IN<declare_yp_In>();
            yb_in_yp.MSGNO = "1633";
            yb_in_yp.INPUT = new List<declare_yp_In>();
            declare_yp_In dom_yp = new declare_yp_In();
            dom_yp.AKC224 = "1";
            dom_yp.INROW = "";


            SJZYB_IN<declare_zl_In> yb_in_zl = new SJZYB_IN<declare_zl_In>();
            yb_in_zl.MSGNO = "1633";
            yb_in_zl.INPUT = new List<declare_zl_In>();
            declare_zl_In dom_zl = new declare_zl_In();
            dom_zl.AKC224 = "2";
            dom_zl.INROW = "";

            SJZYB_IN<declare_fw_In> yb_in_fw = new SJZYB_IN<declare_fw_In>();
            yb_in_fw.MSGNO = "1633";
            yb_in_fw.INPUT = new List<declare_fw_In>();
            declare_fw_In dom_fw = new declare_fw_In();
            dom_fw.AKC224 = "3";
            dom_fw.INROW = "";

            SjzybInterface yb_xm = new SjzybInterface();
            SJZYB_OUT yb_out = new SJZYB_OUT();

            int Count = dv_dzxx.Rows.Count;
            if (Count <= 0)
            {
                return;
            }
            string id_list = "";
            for (int i = 0; i < Count; i++)
            {
                if (dv_dzxx.Rows[i].Cells["项目定义类型"].Value.ToString() == "DRUG")
                {
                    declare_yp_In_INROW dom_yp_INROW = new declare_yp_In_INROW();
                    dom_yp_INROW.OPERTYPE = "0";
                    dom_yp_INROW.AKA060 = dv_dzxx.Rows[i].Cells["医保编码"].Value.ToString();
                    dom_yp_INROW.AKA061 = dv_dzxx.Rows[i].Cells["项目名称"].Value.ToString();
                    dom_yp_INROW.AKC515 = dv_dzxx.Rows[i].Cells["his编码"].Value.ToString();
                    dom_yp_INROW.AKC516 = dv_dzxx.Rows[i].Cells["his名称"].Value.ToString();
                    dom_yp_INROW.HISAKA066 = dv_dzxx.Rows[i].Cells["his助记符"].Value.ToString();
                    dom_yp_INROW.HISAKA070 = dv_dzxx.Rows[i].Cells["剂型"].Value.ToString();
                    dom_yp_INROW.HISAKA077 = dv_dzxx.Rows[i].Cells["规格"].Value.ToString();
                    dom_yp_INROW.AKC225 = dv_dzxx.Rows[i].Cells["价格"].Value.ToString();
                    if (String.IsNullOrEmpty(id_list))
                    {
                        id_list += "'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    else
                    {
                        id_list += ",'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    string inputData = objk<declare_yp_In_INROW>.Serializer(dom_yp_INROW);
                    
                    dom_yp.INROW += "<INROW>" + inputData + "</INROW>";
                }
                else if (dv_dzxx.Rows[i].Cells["项目定义类型"].Value.ToString() == "COST")
                {
                    declare_zl_In_INROW dom_lz_INROW = new declare_zl_In_INROW();
                    dom_lz_INROW.OPERTYPE = "0";
                    dom_lz_INROW.AKA090 = dv_dzxx.Rows[i].Cells["医保编码"].Value.ToString();
                    dom_lz_INROW.AKA091 = dv_dzxx.Rows[i].Cells["项目名称"].Value.ToString();
                    dom_lz_INROW.AKC515 = dv_dzxx.Rows[i].Cells["his编码"].Value.ToString();
                    dom_lz_INROW.AKC516 = dv_dzxx.Rows[i].Cells["his名称"].Value.ToString();
                    dom_lz_INROW.HISAKA066 = dv_dzxx.Rows[i].Cells["his助记符"].Value.ToString();
                    dom_lz_INROW.AKC225 = dv_dzxx.Rows[i].Cells["价格"].Value.ToString();
                    if (String.IsNullOrEmpty(id_list))
                    {
                        id_list += "'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    else
                    {
                        id_list += ",'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    string inputData = objk<declare_zl_In_INROW>.Serializer(dom_lz_INROW);
                    dom_zl.INROW += "<INROW>" + inputData + "</INROW>"; ;

                }
                else if (dv_dzxx.Rows[i].Cells["项目定义类型"].Value.ToString() == "BED")
                {
                    declare_fw_In_INROW dom_fw_INROW = new declare_fw_In_INROW();
                    dom_fw_INROW.OPERTYPE = "0";
                    dom_fw_INROW.AKA100 = dv_dzxx.Rows[i].Cells["医保编码"].Value.ToString();
                    dom_fw_INROW.AKA102 = dv_dzxx.Rows[i].Cells["项目名称"].Value.ToString();
                    dom_fw_INROW.AKC515 = dv_dzxx.Rows[i].Cells["his编码"].Value.ToString();
                    dom_fw_INROW.AKC516 = dv_dzxx.Rows[i].Cells["his名称"].Value.ToString();
                    dom_fw_INROW.HISAKA066 = dv_dzxx.Rows[i].Cells["his助记符"].Value.ToString();
                    dom_fw_INROW.AKC225 = dv_dzxx.Rows[i].Cells["价格"].Value.ToString();
                    if (String.IsNullOrEmpty(id_list))
                    {
                        id_list += "'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    else
                    {
                        id_list += ",'" + dv_dzxx.Rows[i].Cells["编号"].Value.ToString() + "'";
                    }
                    string inputData = objk<declare_fw_In_INROW>.Serializer(dom_fw_INROW);

                    dom_fw.INROW += "<INROW>" + inputData + "</INROW>"; ;

                }


            }
            if (rdBt_YPml.Checked == true && dom_yp.INROW != "")
            {
                dom_yp.INROW = dom_yp.INROW.Substring(7, dom_yp.INROW.Length - 15);
                yb_in_yp.INPUT.Add(dom_yp);
                int opstat = yb_xm.declare_yp(yb_in_yp, ref yb_out);
                if (opstat == -1)
                {
                    MessageBox.Show(yb_out.ERRORMSG, "提示信息");
                    return;
                }
            }
            else if (rdBt_Zlml.Checked == true && dom_zl.INROW != "")
            {
                dom_zl.INROW = dom_zl.INROW.Substring(7, dom_zl.INROW.Length - 15);
                yb_in_zl.INPUT.Add(dom_zl);
                int opstat = yb_xm.declare_zl(yb_in_zl, ref yb_out);
                if (opstat == -1)
                {
                    MessageBox.Show(yb_out.ERRORMSG, "提示信息");
                    return;
                }
            }
            else if (rdBt_FWssml.Checked == true && dom_fw.INROW != "")
            {
                dom_fw.INROW = dom_fw.INROW.Substring(7, dom_fw.INROW.Length - 15);
                yb_in_fw.INPUT.Add(dom_fw);
                int opstat = yb_xm.declare_fw(yb_in_fw, ref yb_out);
                if (opstat == -1)
                {
                    MessageBox.Show(yb_out.ERRORMSG, "提示信息");
                    return;
                }
            }
            Yb_Itme yb = new Yb_Itme();
            yb.insurTpyr(id_list, "Y");
            MessageBox.Show("申报成功", "提示信息");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDownloadDirectory FrmDownloadDirectory = new FrmDownloadDirectory();
            FrmDownloadDirectory.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDownloadContrast FrmDownloadContrast = new FrmDownloadContrast();
            FrmDownloadContrast.ShowDialog();
            shux();
        }

        private void Frmrelationship_SizeChanged(object sender, EventArgs e)
        {
        }

        private void dv_insuritem_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dv_insuritem.Rows.Count; i++)
            {
                if (dv_insuritem.Rows[i].Cells["有效标志"].Value != null && dv_insuritem.Rows[i].Cells["有效标志"].Value.ToString() == "停用")
                    dv_insuritem.Rows[i].DefaultCellStyle.BackColor = Color.Red;//已审核未通过红色

            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            FrmExcle frmExcle = new FrmExcle();
            frmExcle.Dg = dv_dzxx;
            frmExcle.Show(this);
        }
    }
}
