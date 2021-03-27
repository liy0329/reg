using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.Entity;
using MTREG.medinsur.gzsyb.Util;
using MTREG.medinsur.gzsyb.bll;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class Frm_JSD : Form
    {
        public JSD_Entity jsd;
        CrystalReport1 report1 = new CrystalReport1();
        
        public Frm_JSD()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 打印方法
        /// </summary>
        //public void Print()
        //{
        //    List<JSD_Entity> list = new List<JSD_Entity>();
        //    list.Add(jsd);
        //    //CrystalReport1 report1 = new CrystalReport1();
        //    //CrystalReport_sybbbd CReportSybbbd = new CrystalReport_sybbbd();
        //    //if (list.Count > 0)
        //    //{
        //    //    CReportSybbbd.SetDataSource(list);
        //    //    crystalReportViewer1.ReportSource = CReportSybbbd;
        //    //}
        //}
        /// <summary>
        /// 预览方法
        /// </summary>
        public void Preview()
        {
            List<JSD_Entity> list = new List<JSD_Entity>();
            list.Add(jsd);
         
            if (list.Count > 0)
            {
                report1.SetDataSource(list);
             
                crystalReportViewer1.ReportSource = report1;
            }            
        }
        
        private void find_btn_Click(object sender, EventArgs e)
        {
            if ("".Equals(text_jsd.Text))
            {
                MessageBox.Show("请输入住院号");
                return;
            }
            jsd = new JSD_Entity();
            jsd.Printer = ProgramGlobal.Username;
            String sql1 = "select id from inhospital where inhospital.ihspcode='" + text_jsd.Text.Trim() + "'";
            DataSet ds1 = BllMain.Db.Select(sql1);


            String current_iid = ds1.Tables[0].Rows[0][0].ToString();
         //   String ctct_iid = ds1.Tables[0].Rows[0][0].ToString();

            //省医保
            //if ("168".Equals(ds1.Tables[0].Rows[0][4].ToString()))                
           // {
                
           // }
            //if ("173".Equals(ds1.Tables[0].Rows[0][4].ToString()))
            //{
                
                Gzsybservice Swybservice = new Gzsybservice();
                Swybservice.Zyjsddy(current_iid);
                return;
                
               
            //}
           
            Preview();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            report1.PrintToPrinter(1, false, 0, 0);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ;
        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }
    }
}
