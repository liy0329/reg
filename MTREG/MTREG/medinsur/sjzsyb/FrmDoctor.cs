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
    public partial class FrmDoctor : Form
    {
        Sjzsyb syb = new Sjzsyb();
        
        public FrmDoctor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDoctor_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //下载当前定点中心的所有医师信息
            
            SJZYB_IN<Doctor_In> yb_in_doc = new SJZYB_IN<Doctor_In>();
            yb_in_doc.INPUT = new List<Doctor_In>();
            Doctor_Out yb_out_doc = new Doctor_Out();
            Doctor_In doc = new Doctor_In ();
            SjzybInterface yb_xz = new SjzybInterface();
            doc.CURRENTPAGE = "1";
            yb_in_doc.MSGNO = "1631";
            yb_in_doc.INPUT.Add(doc);
            
            int opstat = yb_xz.DownloadDoctor(yb_in_doc,ref yb_out_doc);

            string ReturnMsg = "";
            if ((yb_out_doc.TOTALPAGE !=null && int.Parse( yb_out_doc.TOTALPAGE) > 2 ))
            {
                for (int i = 2; i <= int.Parse(yb_out_doc.TOTALPAGE); i++ )
                {
                    doc = new Doctor_In();
                    doc.CURRENTPAGE = i.ToString();
                    yb_in_doc.MSGNO = "1631";
                    yb_in_doc.INPUT.Add(doc);
                    opstat = yb_xz.DownloadDoctor(yb_in_doc, ref yb_out_doc);
                }
            }

            int returnnum = Convert.ToInt32(yb_out_doc.RETURNNUM);
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_doc.ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            
            //更新sjz_yb_doc

            string sql = "";

            Yb_Itme docitme = new Yb_Itme();
            docitme.deleteyb_doctoritme();
            for (int i = 0; i < yb_out_doc.OUTROW.Count; i++ )
            {
               sql += docitme.addyb_doctoritme(yb_out_doc.OUTROW[i]);
            }
            if (docitme.doExeSql(sql) == -1)
            {
                MessageBox.Show("添加医生失败！");
                return;
            }
            
            DataTable dt = docitme.selectyb_doctoritme();
            dataGridView1.DataSource = dt;
            this.label1.Visible = true;
            
            this.label1.Text ="共获取医师：" + dt.Rows.Count.ToString() + "位";

        }


    }
}
