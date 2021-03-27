using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTLIS.db;
using System.Runtime.InteropServices;
using MTHIS.tools;
using MTHIS.db;
using System.IO;
using MTHIS.main.bll;

namespace MTHIS.db
{
    public partial class FrmDBConnectionConfiguration : Form
    {
        public FrmDBConnectionConfiguration()
        {
            InitializeComponent();
        }

        string ip = "";
        BllMain bllMain = new BllMain();
        /// <summary>
        /// 参数说明：section：INI文件中的段落；key：INI文件中的关键字；val：INI文件中关键字的数值；filePath：INI文件的完整的路径和名称。 
        /// </summary>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 参数说明：section：INI文件中的段落名称；key：INI文件中的关键字；def：无法读取时候时候的缺省数值；retVal：读取数值；size：数值的大小；filePath：INI文件的完整路径和名称。
        /// </summary>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        string inipath = Application.StartupPath + "\\dbconfig.ini";//文件路径

        private void FrmDBConnectionConfiguration_Load(object sender, EventArgs e)
        {
         
            hisdb();
         
            chkdb();
            if (!bllMain.initDB())
            {
                MessageBox.Show("数据连接对象加载失败,请检查数据库连接配置文件dbconfig.ini", "提示");
            }
        }


        private void hisdb()
        {
            this.tbxLisDbType.Text = IniReadValue("MTHIS", "DBType");
            this.tbxLisDbPort.Text = IniReadValue("MTHIS", "Port");
            this.tbxLisDbDriver.Text = IniReadValue("MTHIS", "Driver");
            ip = IniReadValue("MTHIS", "Server");
            this.tbxLisDbIp.Text = ip;
            this.tbxLisDbName.Text = IniReadValue("MTHIS", "Database");
            this.tbxLisDbUser.Text = IniReadValue("MTHIS", "Uid");
            this.tbxLisDbPass.Text = IniReadValue("MTHIS", "Pwd");
        }

        private void chkdb()
        {
            this.tbxChkDbType.Text = IniReadValue("MTMCHK", "DBType");
            this.tbxChkDbDriver.Text = IniReadValue("MTMCHK", "Driver");
            this.tbxChkDbIp.Text = IniReadValue("MTMCHK", "Server");
            ip = IniReadValue("MTMCHK", "Server");
            this.tbxChkDbPort.Text = IniReadValue("MTMCHK", "Port");
            this.tbxChkDbName.Text = IniReadValue("MTMCHK", "Database");
            this.tbxChkDbUser.Text = IniReadValue("MTMCHK", "Uid");
            this.tbxChkDbPass.Text = IniReadValue("MTMCHK", "Pwd");
        }

     

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
           long i = WritePrivateProfileString(Section, Key, Value, inipath);
        }

        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
           
        }



       

        private void btnTestLink_Click(object sender, EventArgs e)
        {

          
        }

        

       

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void but_tc_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnlistest_Click(object sender, EventArgs e)
        {
            if(!histestlink())
                return;
            string constring =
                        "DRIVER=" + tbxLisDbDriver.Text.Trim()
                        + ";SERVER=" + tbxLisDbIp.Text.Trim()
                        + ";PORT=" + tbxLisDbPort.Text.Trim()
                        + ";DATABASE=" + tbxLisDbName.Text.Trim()
                        + ";UID=" + tbxLisDbUser.Text.Trim()
                        + ";PASSWORD=" + tbxLisDbPass.Text.Trim()
                        + ";OPTION=3;MULTI_STATEMENTS=1;";
            if (!BllMain.Db.ConnectionTest(constring))
            {
                lblLisMsg.ForeColor = Color.Red;
                lblLisMsg.Text = "数据库未连接成功，现在检查是否安装odbc驱动，未安装请安装，和检查配置参数是否正确，";
                btnInstanllODBC.Visible = true;
                return;
            }
            lblLisMsg.ForeColor = Color.Green;
            lblLisMsg.Text = "测试连接成功,请【初始化】配置文件";
            btnHisDbInit.Enabled = true;
        }
        public bool histestlink()
        {
            lblLisMsg.Visible = true;
            if (tbxLisDbIp.Text.Trim() == null || tbxLisDbIp.Text.Trim() == "")
            {
                lblLisMsg.ForeColor = Color.Red;
                lblLisMsg.Text = "请输入ip地址以测试连接";
                tbxLisDbPort.Focus();
                return false;
            }
            string[] str = tbxLisDbIp.Text.Split('.');
            if (str.Length != 4)
            {
                lblLisMsg.ForeColor = Color.Red;
                lblLisMsg.Text = "您所输入的IP地址不正确";
                tbxLisDbPort.Focus();
                tbxLisDbPort.SelectAll();
                return false;
            }
            bool isfault = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length > 3 && str[i].Length < 0)
                    isfault = true;

            }
            if (isfault == true)
            {
                lblLisMsg.ForeColor = Color.Red;
                lblLisMsg.Text = "检测到您输入的ip地址错误，请重新输入";
                tbxLisDbPort.Focus();
                tbxLisDbPort.SelectAll();
                return false;
            }
            bool ping_success = false;
            ping_success = ping_ip.ping(tbxLisDbIp.Text.Trim());
            if (ping_success == true)
            {
                lblLisMsg.ForeColor = Color.Blue;
                lblLisMsg.Text = "您测试的主机ip是" + tbxLisDbIp.Text + "测试连接成功，数据库未连接成功，现在请初始化配置文件。";
               
           
                return true;

            }
            else
            {
                lblLisMsg.ForeColor = Color.Red;
                lblLisMsg.Text = "您测试的主机ip是" + tbxLisDbIp.Text + "测试连接失败，请检测输入主机ip是否正确！";
               
                btnHisDbInit.Enabled = false;
                tbxLisDbIp.Focus();
                tbxLisDbIp.SelectAll();
                lblLisMsg.Visible = true;
                return false;
            }
        }

     

        private void but_ejkok_Click(object sender, EventArgs e)
        {
           
        }

        

        private void but_ejktc_Click(object sender, EventArgs e)
        {
            Close();
        }


        public bool test()
        {
            hisdb();
            bool ping_success = false;
            ping_success = ping_ip.ping(ip);
            if (ping_success == true)
            {

                return ping_success;

            }
            return ping_success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChkPing_Click(object sender, EventArgs e)
        {
            chktestlink();
        }

        private void btnChkDbInit_Click(object sender, EventArgs e)
        {
            chkinit_ini();
        }

        private void chkinit_ini()
        {
            if (tbxChkDbType.Text == "")
            {
                MessageBox.Show("未填写数据库类型", "提示信息");
                tbxChkDbType.Focus();
                return;
            }
            if (tbxChkDbDriver.Text == "")
            {
                MessageBox.Show("未填写驱动", "提示信息");
                tbxChkDbDriver.Focus();
                return;
            }
            if (tbxChkDbIp.Text == "")
            {
                MessageBox.Show("未填写地址", "提示信息");
                tbxChkDbIp.Focus();
                return;
            }
            else
            {
                string[] str2 = tbxChkDbIp.Text.ToString().Split('.');
                int len2 = str2.Length;
                if (len2 != 4)
                {
                    MessageBox.Show("您所输入的地址不正确", "提示信息");
                    tbxChkDbIp.Focus();
                    tbxChkDbIp.SelectAll();
                }
            }
            if (tbxChkDbPort.Text == "")
            {
                MessageBox.Show("未填写端口", "提示信息");
                tbxChkDbPort.Focus();
                return;
            }

            if (tbxChkDbName.Text == "")
            {
                MessageBox.Show("未填写数据库", "提示信息");
                tbxChkDbName.Focus();
                return;
            }
            if (tbxChkDbUser.Text == "")
            {
                MessageBox.Show("未填写用户名", "提示信息");
                tbxChkDbUser.Focus();
                return;
            }
            if (tbxChkDbPass.Text == "")
            {
                MessageBox.Show("未填写密码", "提示信息");
                tbxChkDbPass.Focus();
                return;
            }

            IniWriteValue("MTMCHK", "DBType", tbxChkDbType.Text.Trim());
            IniWriteValue("MTMCHK", "Driver", tbxChkDbDriver.Text.Trim());
            IniWriteValue("MTMCHK", "Server", tbxChkDbIp.Text.Trim());
            IniWriteValue("MTMCHK", "Port", tbxChkDbPort.Text.Trim());
            IniWriteValue("MTMCHK", "Database", tbxChkDbName.Text.Trim());
            IniWriteValue("MTMCHK", "Uid", tbxChkDbUser.Text.Trim());
            IniWriteValue("MTMCHK", "Pwd", tbxChkDbPass.Text.Trim());
            if (!ExistINIFile())
            {
                this.lblChkMsg.ForeColor = Color.Red;
                this.lblChkMsg.Text = "初始化失败！不存在ini文件";
                return;
            }
            else
            {
                hisdb();
                this.lblChkMsg.ForeColor = Color.Green;
                this.lblChkMsg.Text = "初始化完成。";
                this.btnChkDbInit.Enabled = false;
            }
        }
        private bool chktestlink()
        {
            lblChkMsg.Visible = true;
            if (string.IsNullOrEmpty(this.tbxChkDbIp.Text.Trim()))
            {
                lblChkMsg.ForeColor = Color.Red;
                lblChkMsg.Text = "请输入ip地址以测试连接";
                tbxChkDbIp.Focus();
                return false;
            }
            string[] str = tbxChkDbIp.Text.Split('.');
            if (str.Length != 4)
            {
                lblChkMsg.ForeColor = Color.Red;
                lblChkMsg.Text = "您所输入的地址不正确";
                tbxChkDbIp.Focus();
                tbxChkDbIp.SelectAll();
                return false;
            }
            bool isfault = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length > 3 && str[i].Length < 0)
                    isfault = true;

            }
            if (isfault == true)
            {
                lblChkMsg.ForeColor = Color.Red;
                lblChkMsg.Text = "检测到您输入的ip地址错误，请重新输入";
                tbxChkDbIp.Focus();
                tbxChkDbIp.SelectAll();
                return false;
            }
            bool ping_success = false;
            ping_success = ping_ip.ping(tbxChkDbIp.Text.Trim());
            if (ping_success == true)
            {
                lblChkMsg.ForeColor = Color.Green;
                lblChkMsg.Text = "您测试的主机ip是" + tbxChkDbIp.Text + "测试连接成功，现在请初始化配置文件。";
                btnChkDbInit.Enabled = true;
                return true;

            }
            else
            {
                lblChkMsg.ForeColor = Color.Red;
                lblChkMsg.Text = "您测试的主机ip是" + tbxChkDbIp.Text + "测试连接失败，请检测输入主机ip是否正确！";
                btnHisDbInit.Enabled = false;
                tbxChkDbIp.Focus();
                tbxChkDbIp.SelectAll();
                return false;
            }
        }

        private void btnLisDbInit_Click(object sender, EventArgs e)
        {
            hisinit_ini();
        }

        private void hisinit_ini()
        {
            this.lblLisMsg.Visible = true;
            if (tbxLisDbType.Text == "")
            {
                MessageBox.Show("未填写数据库类型", "提示信息");
                tbxLisDbType.Focus();
                return;
            }
            if (tbxLisDbDriver.Text == "")
            {
                MessageBox.Show("未填写驱动", "提示信息");
                tbxLisDbDriver.Focus();
                return;
            }
            if (tbxLisDbIp.Text == "")
            {
                MessageBox.Show("未填写地址", "提示信息");
                tbxLisDbIp.Focus();
                return;
            }
            else
            {
                string[] str2 = tbxLisDbIp.Text.ToString().Split('.');
                int len2 = str2.Length;
                if (len2 != 4)
                {
                    MessageBox.Show("您所输入的地址不正确", "提示信息");
                    tbxLisDbIp.Focus();
                    tbxLisDbIp.SelectAll();
                }
            }
            if (tbxLisDbPort.Text == "")
            {
                MessageBox.Show("未填写端口", "提示信息");
                tbxLisDbPort.Focus();
                return;
            }

            if (tbxLisDbName.Text == "")
            {
                MessageBox.Show("未填写数据库", "提示信息");
                tbxLisDbName.Focus();
                return;
            }
            if (tbxLisDbUser.Text == "")
            {
                MessageBox.Show("未填写用户名", "提示信息");
                tbxLisDbUser.Focus();
                return;
            }
            if (tbxLisDbPass.Text == "")
            {
                MessageBox.Show("未填写密码", "提示信息");
                tbxLisDbPass.Focus();
                return;
            }
            
            IniWriteValue("MTHIS", "DBType", tbxLisDbType.Text.Trim());
            IniWriteValue("MTHIS", "Driver", tbxLisDbDriver.Text.Trim());
            IniWriteValue("MTHIS", "Server", tbxLisDbIp.Text.Trim());
            IniWriteValue("MTHIS", "Port", tbxLisDbPort.Text.Trim());
            IniWriteValue("MTHIS", "Database", tbxLisDbName.Text.Trim());
            IniWriteValue("MTHIS", "Uid", tbxLisDbUser.Text.Trim());
            IniWriteValue("MTHIS", "Pwd", tbxLisDbPass.Text.Trim());
            
            if (!ExistINIFile())
            {
                this.lblLisMsg.ForeColor = Color.Red;
                this.lblLisMsg.Text = "初始化失败！不存在ini文件";
                return;
            }
            else
            {
                hisdb();
                this.lblLisMsg.ForeColor = Color.Green;
                this.lblLisMsg.Text = "初始化完成。";                
                this.btnHisDbInit.Enabled = false;
            }
        }

        private void btnInstanllODBC_Click(object sender, EventArgs e)
        {
            String oldDllPath1 = @"C:\Windows\System32\";
            String oldDllPath2 = @"C:\Windows\SysWOW64\";
            String newDllPath = Application.StartupPath + @"\mysql-odbc\mysql-odbc-install-dll.zip";
            if (Directory.Exists(oldDllPath1))
                ZipUtils.UnZip(newDllPath, oldDllPath1, "", false);
            if (Directory.Exists(oldDllPath2))
                ZipUtils.UnZip(newDllPath, oldDllPath2, "", false);
            System.Diagnostics.Process.Start(Application.StartupPath + @"\mysql-odbc\mysql-connector-odbc-5.3.2-win32.msi");

            String inipath = Ini.inipath;
            Ini.INIClass(Ini.syspath);
            Ini.IniWriteValue("mysqlodbc", "mysqlodbc", "1");
            Ini.INIClass(inipath);
            btnInstanllODBC.Visible = false;
        }

    }
}
