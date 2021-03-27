using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.hdsbhnh.bo;
using System.Text.RegularExpressions;
using MTREG.common;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmCostContrast : Form
    {
        public FrmCostContrast()
        {
            InitializeComponent();
        }

        private void nhfyquery(string indate)
        {
            if (this.tbxIhspcode.Text == "")
            {
                MessageBox.Show("请填入住院号!", "提示信息");
                return;
            }
            dgvInsur.Rows.Clear();
            string[] param = new string[4];
            param[0] = this.tbxPersonNum.Text;
            param[1] = this.tbxIhspcode.Text;
            param[2] = DateTime.Parse(indate).ToString("yyyy-MM-ddTHH-mm-ss");
            param[3] = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            ZyjsjlcxXml nhfycx = new ZyjsjlcxXml();
            string sql = "select registinfo from ihsp_insurinfo"
            + " left join inhospital on inhospital.id=ihsp_insurinfo.ihsp_id "
            + " where inhospital.ihspcode= " + DataTool.addFieldBraces(this.tbxIhspcode.Text);
            DataTable dtinsur = BllMain.Db.Select(sql).Tables[0];
            string reginfo = dtinsur.Rows[0]["registinfo"].ToString();
            string[] message = reginfo.Split('|');//住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
            BhnhReturn retdata = nhfycx.membersQueryFunction(message[5], message[7], message[6], message[8] ,param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show(retdata.Ret_mesg, "提示信息");
                return;
            }
            //string data = System.IO.File.ReadAllText(@"d:test.xml");
            //解析返回的xml

            string[] str = Regex.Split(retdata.Ret_data, "<details>", RegexOptions.IgnoreCase);
            string a = str[0];
            string b = "";
            try
            {
                b = str[1];
            }
            catch
            {
                MessageBox.Show("该患者还没有上传费用", "提示信息");
                return;
            }
            string[] str1 = Regex.Split(b, "</details>", RegexOptions.IgnoreCase);
            string c = str1[0];
            string d = str1[1];

            string e = "";
            string f = "";
            try
            {
                string[] str2 = Regex.Split(c, "<D505_30_01>", RegexOptions.IgnoreCase);
                e = str2[1];
                string[] str3 = Regex.Split(e, "</D505_30_01>", RegexOptions.IgnoreCase);
                f = str3[0];//西药         
            }
            catch (Exception ee)
            { }

            string h = "";
            string j = "";
            try
            {
                string[] str4 = Regex.Split(c, "<D505_30_02>", RegexOptions.IgnoreCase);
                h = str4[1];
                string[] str5 = Regex.Split(h, "</D505_30_02>", RegexOptions.IgnoreCase);
                j = str5[0];//中成药               
            }
            catch (Exception ee) { }


            string l = "";
            string m = "";// 中草药
            try
            {
                string[] str6 = Regex.Split(c, "<D505_30_03>", RegexOptions.IgnoreCase);
                l = str6[1];
                string[] str7 = Regex.Split(l, "</D505_30_03>", RegexOptions.IgnoreCase);
                m = str7[0];// 中草药

            }
            catch (Exception ee) { }

            string o = "";
            string p = "";
            try
            {
                string[] str8 = Regex.Split(retdata.Ret_data, "<D505_03_02>", RegexOptions.IgnoreCase);
                o = str8[1];
                string[] str9 = Regex.Split(o, "</D505_03_02>", RegexOptions.IgnoreCase);
                p = str9[0];//诊疗
            }
            catch (Exception ee) { }


            string r = "";
            string s = "";
            try
            {
                string[] str10 = Regex.Split(retdata.Ret_data, "<D505_03_03>", RegexOptions.IgnoreCase);
                r = str10[1];
                string[] str11 = Regex.Split(r, "</D505_03_03>", RegexOptions.IgnoreCase);
                s = str11[0];//材料

            }
            catch (Exception ee) { }

            string strdata = "<body>" + f + j + m + p + s + "</body>";
            string strdata1 = a + d;
            System.IO.StringReader sr1 = new System.IO.StringReader(strdata1);
            DataSet ds1 = new DataSet();
            ds1.ReadXml(sr1);
            this.tbxIhspcode.Text = ds1.Tables["item"].Rows[0]["D504_09"].ToString();
            this.tbxPersonNum.Text = ds1.Tables["item"].Rows[0]["D401_21_A"].ToString();
            this.tbxNhzyh.Text = ds1.Tables["item"].Rows[0]["D505_02"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(strdata);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            for (int jj = 0; jj < ds.Tables["item"].Rows.Count; ++jj)
            {
                dgvInsur.Rows.Add();
                DataGridViewRow row = dgvInsur.Rows[dgvInsur.Rows.Count - 1];
                for (int kk = 0; kk < ds.Tables["item"].Columns.Count - 1; ++kk)
                {
                    row.Cells[ds.Tables["item"].Columns[kk].ColumnName].Value
                        = ds.Tables["item"].Rows[jj][ds.Tables["item"].Columns[kk].ColumnName];
                }
                //for (int k = 0; k < ds.Tables["baseinfo"].Columns.Count - 1; ++k)
                //{
                //    row.Cells[ds.Tables["baseinfo"].Columns[k].ColumnName].Value
                //        = ds.Tables["baseinfo-"].Rows[j][ds.Tables["baseinfo"].Columns[k].ColumnName];
                //}
            }
            double hj = 0;
            for (int z = 0; z < dgvInsur.Rows.Count; z++)
            {
                hj += Convert.ToDouble(dgvInsur.Rows[z].Cells["D505_10"].Value);
            }


            this.textBoxHj2.Text = "             总费用金额：" + hj.ToString() + " 元 ,    行数:" + dgvInsur.Rows.Count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select indate from inhospital where ihspcode=" + DataTool.addFieldBraces(tbxIhspcode.Text);
            DataTable dt= BllMain.Db.Select(sql).Tables[0];
            string indate = dt.Rows[0]["indate"].ToString();
            sql = "select ihsp_costdet.name"
                    +",ihsp_costdet.spec"
                    + ",ihsp_costdet.prc"
                    + ",ihsp_costdet.num"
                    + ",ihsp_costdet.fee"
                    + ",ihsp_costdet.unit"                    
                    + ",insur_itemfrom.itemtype_id"
                    + ",insur_itemfrom.insurcode"
                    + ",insur_itemfrom.name"
                    + ",ihsp_costdet.chargedate"
                    +" from ihsp_costdet"
                    +" left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                    + " left join insur_itemfrom on insur_itemfrom.itemtype_id=ihsp_costdet.itemtype_id"
                    + " Left join cost_insurtype on cost_insurtype.id=insur_itemfrom.cost_insurtype_id"
                    + " where inhospital.ihspcode=" + DataTool.addFieldBraces(tbxIhspcode.Text)
                    + " and cost_insurtype.keyname=" + DataTool.addFieldBraces(CostInsurtypeKeyname.HDBHNH.ToString());
            DataTable dtHis = BllMain.Db.Select(sql).Tables[0];
            dgvHis.DataSource = dtHis;
            nhfyquery(indate);
        }
    }
}
