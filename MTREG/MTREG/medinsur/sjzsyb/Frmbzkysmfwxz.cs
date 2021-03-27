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
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmbzkysmfwxz : Form
    {
        public Frmbzkysmfwxz()
        {
            InitializeComponent();
        }

        private void Frmbzkysmfwxz_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Index = dataGridView2.CurrentRow.Index;
            SJZYB_IN<bzkysmfwxz_In> yb_in_doc = new SJZYB_IN<bzkysmfwxz_In>();
            yb_in_doc.INPUT = new List<bzkysmfwxz_In>();
            bzkysmfwxz_Out yb_out_doc = new bzkysmfwxz_Out();
            bzkysmfwxz_In doc = new bzkysmfwxz_In();
            SjzybInterface yb_xz = new SjzybInterface();
            doc.AKA120 = dataGridView2.Rows[Index].Cells["医保编码"].Value.ToString();
            doc.CURRENTPAGE = "1";
            yb_in_doc.MSGNO = "1638";
            yb_in_doc.INPUT.Add(doc);

            string ReturnMsg = "";
            int opstat = yb_xz.Downloadbzkysmfwxz(yb_in_doc, ref yb_out_doc);
            if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_doc.ERRORMSG;
                MessageBox.Show("下载三目失败!" + ReturnMsg, "提示信息");
                return;
            }
            
            if ((yb_out_doc.TOTALPAGE != null && int.Parse(yb_out_doc.TOTALPAGE) > 2))
            {
                for (int i = 2; i <= int.Parse(yb_out_doc.TOTALPAGE); i++)
                {
                    doc = new bzkysmfwxz_In();
                    doc.CURRENTPAGE = i.ToString();
                    yb_in_doc.MSGNO = "1638";
                    yb_in_doc.INPUT.Add(doc);
                    opstat = yb_xz.Downloadbzkysmfwxz(yb_in_doc, ref yb_out_doc);
                    if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
                    {
                        ReturnMsg = yb_out_doc.ERRORMSG;
                        MessageBox.Show("下载三目失败" + ReturnMsg, "提示信息");
                        return;
                    }
                }
            }

            Yb_Itme docitme = new Yb_Itme();
            docitme.deleteybinsur_scope();
            string sql = "";
            for (int j = 0; j < yb_out_doc.OUTROW.Count; j++)
            {

                sql += docitme.Addybinsur_scope(yb_out_doc.OUTROW[j]);

                if (j % 50 == 0 && j > 0)
                {
                    if (docitme.doExeSql(sql) == -1)
                    {
                        MessageBox.Show("添加药品失败！");
                        return;
                    }
                    sql = "";
                }
            }
            if (!String.IsNullOrEmpty(sql) && docitme.doExeSql(sql) == -1)
            {
                MessageBox.Show("添加药品失败！");
                return;
            }
            //DataTable dt = yb_out_doc.OUTROW.ToDataTable<bzkysmfwxz_Out_OUTROW>();
            dataGridView();
        }
        public void dataGridView()
        {
            string sql = @"SELECT insur_scope.aka120,insur_illness.`name` as dicname,insur_scope.ake001,cost_insuritem.`name` as itemname,cost_insuritem.spec,insur_scope.aae100,insur_scope.aae030,insur_scope.aae031,insur_scope.aae013 from insur_scope
                            LEFT JOIN cost_insuritem ON cost_insuritem.insurcode = insur_scope.ake001
                            LEFT JOIN insur_illness ON insur_illness.illcode = insur_scope.aka120";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["AAE100"].ToString() == "0")
                {
                    dr["AAE100"] = "无效";
                }
                else if (dr["AAE100"].ToString() == "1")
                {
                    dr["AAE100"] = "有效";
                }
            }
            dataGridView1.DataSource = dt;
            #region

            dataGridView1.Columns["AKA120"].HeaderText = "病种编码";
            dataGridView1.Columns["AKA120"].Width = 150;
            dataGridView1.Columns["AKA120"].DisplayIndex = 0;

            dataGridView1.Columns["dicname"].HeaderText = "病种编码";
            dataGridView1.Columns["dicname"].Width = 150;
            dataGridView1.Columns["dicname"].DisplayIndex = 1;

            dataGridView1.Columns["itemname"].HeaderText = "药品/项目名称";
            dataGridView1.Columns["itemname"].DisplayIndex = 2;
            dataGridView1.Columns["itemname"].Width = 200;

            dataGridView1.Columns["AKE001"].HeaderText = "药品/项目编码";
            dataGridView1.Columns["AKE001"].DisplayIndex = 3;
            dataGridView1.Columns["AKE001"].Width = 200;

            dataGridView1.Columns["spec"].HeaderText = "规格";
            dataGridView1.Columns["spec"].DisplayIndex = 4;
            dataGridView1.Columns["spec"].Width = 200;

            dataGridView1.Columns["AAE100"].HeaderText = "有效标志";
            dataGridView1.Columns["AAE100"].Width = 150;
            dataGridView1.Columns["AAE100"].DisplayIndex = 5;

            dataGridView1.Columns["AAE013"].HeaderText = "备注";
            dataGridView1.Columns["AAE013"].Width = 100;
            dataGridView1.Columns["AAE013"].DisplayIndex = 6;

            dataGridView1.Columns["AAE030"].HeaderText = "开始时间";
            dataGridView1.Columns["AAE030"].Width = 100;
            dataGridView1.Columns["AAE030"].DisplayIndex = 7;

            dataGridView1.Columns["AAE031"].HeaderText = "终止时间";
            dataGridView1.Columns["AAE031"].Width = 100;
            dataGridView1.Columns["AAE031"].DisplayIndex = 8;

            #endregion
        }

        private void tb_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Focus();
                    this.dataGridView2.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dataGridView2.Focus();
                this.dataGridView2.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Focus();
                    this.dataGridView2.Rows[0].Selected = true;
                }
                return;
            }
            string name = this.tb_name.Text;
            string code = this.tb_code.Text;
            string sql = "SELECT `name` AS 名称 ,pincode AS 拼音,illcode AS 医保编码 ,updatetime AS 更新时间 ,starttime AS 开始时间,Endtime AS 结束时间,  case when sign = '1' then '有效' when sign = '0' then '无效' when sign = '' then '未知' end as 是否有效 FROM insur_illness WHERE (`name` LIKE '%" + name + "%' OR pincode LIKE'%" + name + "%') AND illcode LIKE '%" + code + "%' LIMIT 999";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dataGridView2.DataSource = dt;
                dataGridView2.Visible = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tb_name.Text = dataGridView2.Rows[e.RowIndex].Cells["名称"].Value.ToString().Trim();
                tb_code.Text = dataGridView2.Rows[e.RowIndex].Cells["医保编码"].Value.ToString().Trim();
                dataGridView2.Visible = false;
                //cyjsjbbm.Focus();
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            FrmExcle frmExcle = new FrmExcle();
            frmExcle.Dg = dataGridView1;
            frmExcle.Show(this);
        }


    }
}
