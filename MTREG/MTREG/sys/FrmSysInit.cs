using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTHIS.tools;
using System.IO;

namespace MTHIS.sys
{
    public partial class FrmSysInit : Form
    {
        private bool isenabeOk;

        public bool IsenabeOk
        {
            get { return isenabeOk; }
            set { isenabeOk = value; }
        }
        public FrmSysInit()
        {
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isEnableDo()
        {
            IsenabeOk = false;
            FrmSysInitChk chk = new FrmSysInitChk(this);
            chk.ShowDialog();
            return isenabeOk;
        }
        private void btnLogInit_Click(object sender, EventArgs e)
        {

            if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }
            //--日志初始化
            try
            {
                string sql = "delete from lis_modifylog;"
                            + "delete from lis_modifylogitem;"
                            + "delete from lis_devlog;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }
       // --控制初始化
        private void btnCmdInit_Click(object sender, EventArgs e)
        {
            if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }
          
            try
            {
                string sql = "delete from lis_cmd2dev;"
                            + "delete from lis_recall;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }
        // --检验初始化
        private void btnCheckInit_Click(object sender, EventArgs e)
        {
              if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }
          
            try
            {
                string sql = "delete from lis_app;"
                            +"delete from lis_appitem;"
                            +"delete from lis_merge_record;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
           

        }
        
        //--账号初始化
        private void btnAccountInit_Click(object sender, EventArgs e)
        {
            if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }

            try
            {
                string sql = "delete from lis_account where id <> '1';";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }
        //--医生初始化
        private void btnDoctorInit_Click(object sender, EventArgs e)
        {
          


             if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }

            try
            {
                string sql = "delete from lis_doctor;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }

        //--科室初始化
        private void btnDepartInit_Click(object sender, EventArgs e)
        {
 


            if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }

            try
            {
                string sql = "delete from lis_depart;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }


        //--套餐初始化
        private void btnDiagnInit_Click(object sender, EventArgs e)
        {
            
            if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }

            try
            {
                string sql ="delete from lis_diagnset;"
                    +"delete from lis_diagnitem;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }
        //--质控初始化
        private void btnQualityint_Click(object sender, EventArgs e)
        {
            


             if (!isEnableDo())
            {
                MessageBox.Show("初始化密码不正确，初始化失败!", "提示");
                return;
            }

            try
            {
                string sql ="delete from lis_qualityres;"
                        +"delete from lis_qualityresitem;";
                BllMain.Db.Update(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败!", "提示");
                return;
            }
            MessageBox.Show("初始化成功.", "提示");
        }

        private void btn_fastreport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("'是'：启动fastreport安装程序\r\n\r\n'否'：替换相关文件"
                , "启动安装，还是替换文件"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\fastreport\FRNetDemo2010.msi");
            }
            else if (result == DialogResult.No)
            {
                replactFastReporPro();
                replactFastReportDll();
            }
        }

        private void replactFastReporPro()
        {
            String FastReportProPath;
            String tmp;
            FastReportProPath = @"C:\Program Files\FastReports\FastReport.Net Demo\";
            tmp = FindFile("Designer.exe", FastReportProPath);
            if (String.IsNullOrEmpty(tmp))
            {
                FastReportProPath = @"C:\Program Files (x86)\FastReports\FastReport.Net Demo\";
                tmp = FindFile("Designer.exe", FastReportProPath);
                if (String.IsNullOrEmpty(tmp))
                {
                    MessageBox.Show("未找到FastReport根目录，请手工替换");
                    return;
                }
            }
            String newFastReportProPath = Application.StartupPath + @"\fastreport\";
            String pro = "pro.zip";

            //File.Copy(newFastReportProPath + pro, FastReportProPath + pro, true);
            ZipUtils.UnZip(newFastReportProPath + pro, FastReportProPath, "", true);

            MessageBox.Show("FastReport程序替换结束~！");
        }
        private void replactFastReportDll()
        {
            String newFastReportDllPath = Application.StartupPath + @"\fastreport\dll\";

            String Dll = ".dll";
            String[] newFastReportDll = new String[6];
            newFastReportDll[0] = "FastReport";
            newFastReportDll[1] = "FastReport.Bars";
            newFastReportDll[2] = "FastReport.Editor";
            newFastReportDll[3] = "FastReport.Install";
            newFastReportDll[4] = "FastReport.VSDesign";
            newFastReportDll[5] = "FastReport.Web";

            String oldFastReportDllPath = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\";

            String notFindDll = "";
            foreach (String dllName in newFastReportDll)
            {
                String oldDllPath = FindFile(dllName + Dll, oldFastReportDllPath + dllName);
                if (String.IsNullOrEmpty(oldDllPath))
                {
                    notFindDll += dllName + Dll + "\r\n";
                    continue;
                }
                //File.Delete(oldDllPath);
                File.Copy(newFastReportDllPath + dllName + Dll, oldDllPath, true);
            }
            if (String.IsNullOrEmpty(notFindDll))
                MessageBox.Show("FastReport的DLL文件替换成功~！");
            else
                MessageBox.Show("未找到以下dll文件，无法替换，请手工替换：\r\n" + notFindDll);
        }

        /// <summary>
        /// 搜索文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private String FindFile(String filename, String path)
        {
            if (!"\\".Equals(path.Substring(path.Length - 1)))
            {
                path += "\\";
            }
            if (Directory.Exists(path))
            {
                if (File.Exists(path + filename))
                    return path + filename;
                String[] directorys = Directory.GetDirectories(path);
                foreach (String d in directorys)
                {
                    String p = FindFile(filename, d);
                    if (p != null)
                        return p;
                }
            }
            return null;
        }

    }
}
