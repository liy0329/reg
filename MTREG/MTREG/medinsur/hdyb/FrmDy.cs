using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using MTHIS.common;
using MTHIS.tools;
namespace MTREG.medinsur.hdyb
{
    public partial class FrmDy : Form
    {
        public FrmDy()
        {
            InitializeComponent();
        }
        public bool flag_cs = false;
        public string in_zfc = "";//输入字符串
        public string in_zfc_fy = "";//输入字符串
        public int hs_fy = 0;
        int page_gd = 0;
        int page_kd = 0;


        int top = 0;
        int left = 0;
        string default_dyj = "";

        private String[] list_bt;

        public String[] List_bt
        {
            get { return list_bt; }
            set { list_bt = value; }
        }
        //private List<String[]> list_bt = new List<String[]>();

        //public List<String[]> List_bt
        //{
        //    get { return list_bt; }
        //    set { list_bt = value; }
        //}
        private List<String[]> list_mx = new List<String[]>();

        public List<String[]> List_mx
        {
            get { return list_mx; }
            set { list_mx = value; }
        }
        public void dy(string fptype)
        {
            if (fptype == "mzzf")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzzf");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzzf);
                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzzfyjj")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzzfyjj");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzybmzzfyjj);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzyb")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzyb");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzybnew);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzybnew")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzyb");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzybnew);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "ybdz")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "ybdz");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.ybdz);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzcx")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzcx");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzcx);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzcxjsd")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzcxjsd");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzcxjsd);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzcxhz")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzcxhz");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzcxhz);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zyzf")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zyzf");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zyzf);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zyyb")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zyyb");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zyyb);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zysyyb")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zysyyb");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zysyyb);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zycx")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zycx");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zycx);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zycxjsd")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zycxjsd");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zycxjsd);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zycxhz")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zycxhz");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zycxhz);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1; ;
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zyyjk")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zyyjk");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zyyjk);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zyfyqd")
            {
                #region
                if (flag_cs)
                {
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|住院号:2017120201|科室:内科|结账金额:201710.00|入院日期:2017-11-10";
                    in_zfc += "|性别:男|住院天数:10|费别:自费|预交金额:201710.00|出院日期:2017-11-20";
                    in_zfc += "|工作单位:广平县中医院|打印时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "|等级|负担后余额";
                    in_zfc += "|合计:201710.00|201710.00";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶瓶支", "111122.00", "111122.00", "甲", "811122.00" };
                    for (int m = 0; m < 180; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    /*/
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|住院号:2017120201|科室:内科|结账金额:201710.00|入院日期:2017-11-10";
                    in_zfc += "|性别:男|住院天数:10|费别:自费|预交金额:201710.00|出院日期:2017-11-20";
                    in_zfc += "|工作单位:广平县中医院|打印时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "||";
                    in_zfc += "|合计:201710.00|";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶瓶支", "111122.00", "111122.00" };
                    for (int m = 0; m < 100; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    //*/
                }
                #endregion
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zyfyqd");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);
                page_kd = int.Parse(str[2]);
                page_gd = int.Parse(str[3]);
                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zyfyqd);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zyfyqd_ld")
            {
                #region
                if (flag_cs)
                {
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|住院号:2017120201|科室:内科|结账金额:201710.00|入院日期:2017-11-10";
                    in_zfc += "|性别:男|住院天数:10|费别:自费|预交金额:201710.00|出院日期:2017-11-20";
                    in_zfc += "|工作单位:广平县中医院|打印时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "|等级|负担后余额";
                    in_zfc += "|合计:201710.00|201710.00";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶支", "111122.00", "111122.00", "甲", "811122.00" };
                    for (int m = 0; m < 100; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    /*/
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|住院号:2017120201|科室:内科|结账金额:201710.00|入院日期:2017-11-10";
                    in_zfc += "|性别:男|住院天数:10|费别:自费|预交金额:201710.00|出院日期:2017-11-20";
                    in_zfc += "|工作单位:广平县中医院|打印时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "||";
                    in_zfc += "|合计:201710.00|";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶瓶支", "111122.00", "111122.00" };
                    for (int m = 0; m < 100; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    //*/
                }
                #endregion
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zyfyqd_ld");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);
                page_kd = int.Parse(str[2]);
                page_gd = int.Parse(str[3]);
                if (list_mx.Count > 60)
                {
                    str[3] = (top + 20 * 5 + 20 * 4 / 5 * (list_mx.Count + 5)).ToString();
                }

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zyfyqd_ld);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1; ;
                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "mzfyqd_ld")
            {
                #region
                if (flag_cs)
                {
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|性别:男|科室:内科|发票号:2017120201|费别:自费|收费时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "|等级";
                    in_zfc += "|合计:201710.00";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶支", "111122.00", "111122.00", "甲", "811122.00" };
                    for (int m = 0; m < 100; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    /*/
                    //*
                    in_zfc += "广平县中医院病人费用清单";
                    in_zfc += "|姓名:李宁|性别:男|科室:内科|发票号:2017120201|费别:自费|收费时间:2017-11-10 10:10:10";
                    in_zfc += "|序号|项目类别|项目名称及规格|数量|单位|单价|金额";
                    in_zfc += "||";
                    in_zfc += "|合计:201710.00|201710.00";

                    String[] zd_mx = { "1", "西药", "阿莫西林胶囊阿莫西林胶囊/mg*lmg*lmg*l", "1110.00", "瓶瓶支", "111122.00", "111122.00" };
                    for (int m = 0; m < 100; m++)
                    {
                        list_mx.Add(zd_mx);
                    }
                    //*/
                }
                #endregion
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "mzfyqd_ld");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);
                page_kd = int.Parse(str[2]);
                page_gd = int.Parse(str[3]);
                if (list_mx.Count > 60)
                {
                    str[3] = (top + 20 * 5 + 20 * 4 / 5 * (list_mx.Count + 5)).ToString();
                }

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.mzfyqd_ld);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1; ;
                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
            else if (fptype == "zycxjsdnew")
            {
                #region
                string zfc = IniUtils.IniReadValue(IniUtils.syspath, "FPDYSZ1", "zycxjsdnew");//
                string[] str = zfc.Split(';');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Split('=')[1];
                }

                top = int.Parse(str[5]);
                left = int.Parse(str[4]);

                //实例化打印对象 
                PrintDocument printDocument1 = new PrintDocument();

                //设置打印用的纸张,当设置为Custom的时候，可以自定义纸张的大小 
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", int.Parse(str[2]), int.Parse(str[3]));

                default_dyj = printDocument1.PrinterSettings.PrinterName;
                foreach (var item in PrinterSettings.InstalledPrinters)
                {
                    if (item.ToString() == str[1])
                    {
                        //设置打印机
                        printDocument1.PrinterSettings.PrinterName = str[1];
                        break;
                    }
                }
                try
                {
                    if (str[7] == "true")
                        printDocument1.DefaultPageSettings.Landscape = true;//设置横向打印，不设置默认是纵向的
                }
                catch
                { }
                //注册PrintPage事件，打印每一页时会触发该事件 
                printDocument1.PrintPage += new PrintPageEventHandler(this.zycxjsdnew);

                if (str[6] == "0")//直接打印
                {
                    //打印
                    printDocument1.Print();
                }
                else//预览打印
                {
                    //初始化打印预览对话框对象 
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

                    //将printDocument1对象赋值给打印预览对话框的Document属性 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowDialog();
                }
                #endregion
            }
        }
        /// <summary>
        /// 住院结算单新版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zycxjsdnew(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc += "|";
                in_zfc += "河北省城乡居民医疗保障费用结算单|";
                in_zfc += "（结算日期：2019年05月18日）|";
                in_zfc += "报销类别:普通住院|医疗机构名称:峰峰矿区医院|医疗机构等级:三级|住院号:000079|单位：元|";
                in_zfc += "姓名|张连玉|性别|女|身份证号|130429199011111112|参保地|邯郸市峰峰县|人员类别|普通居民|诊断名称|精神分裂分裂分裂分裂分裂分症分症|入院日期|2019-05-10|出院日期|2019-05-18|";
                in_zfc += "费用总额|3156.95|政策内费用|2898.74|基本医保|统筹支付|2170.29|提高待遇|0.00|大病保险|统筹支付|0.00|提高待遇|0.00|医疗救助|0.00|其他保障或补助|0.00|";
                in_zfc += "票据号|123456789|报销流水号|20190518164450|本次报销合计|2170.29|本次个人负担|小计|986.66|政策内自付|728.45|政策外自费|258.21|是否享受三重保障|否|";
                in_zfc += "审批：|复核：||患者(家属)：|联系电话：|";
                in_zfc += "打印日期:2019年05月18日";
            }
            #endregion

            int sg = 20;
            int line_h = -3;
            Font font_bt = new Font("宋体", 17, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font_2 = new Font("宋体", 8, FontStyle.Regular);
            Font font_1 = new Font("宋体", 7, FontStyle.Regular);
            Pen myPen_bk = new Pen(Color.FromArgb(255, Color.Black), 1.2F);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            Brush brush_ts = Brushes.Red;
            string[] zd = in_zfc.Split('|');
            int nls = 20;
            //if (z)
            //{

            //}
            //标题
            e.Graphics.DrawString(zd[1], font_bt, brush_ts, left + (730 - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 17);
            //结算日期
            e.Graphics.DrawString(zd[2], font, brush, left + (730 - e.Graphics.MeasureString(zd[2], font).Width) / 2, top + sg * 1);
            //表格外的第一行
            e.Graphics.DrawString(zd[3], font, brush, left + line_h, top + sg * 2);
            e.Graphics.DrawString(zd[4], font, brush, left + 160 + line_h, top + sg * 2);
            e.Graphics.DrawString(zd[5], font, brush, left + 395 + line_h, top + sg * 2);
            e.Graphics.DrawString(zd[6], font, brush, left + 545 + line_h, top + sg * 2);
            e.Graphics.DrawString(zd[7], font, brush, left + 660 + line_h, top + sg * 2);
            //横线1
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 3 - 2), new Point(left + line_h + 720, top + sg * 3 - 2));
            //姓名
            e.Graphics.DrawString(zd[8], font, brush, left + 25, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[9], font, brush, left + 18, top + sg * 5 + nls / 2);
            //性别
            e.Graphics.DrawString(zd[10], font, brush, left + 115, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[11], font, brush, left + 117, top + sg * 5 + nls / 2);
            //身份证号
            e.Graphics.DrawString(zd[12], font, brush, left + 190, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[13], font_1, brush, left + 171, top + sg * 5 + nls / 2);
            //参保地
            e.Graphics.DrawString(zd[14], font, brush, left + 288, top + sg * 3 + 10);
            if (zd[15].Length > 5)
            {
                if (zd[15].Length > 7)
                {
                    string strq = zd[15].Substring(0, 7);
                    string strh = zd[15].Substring(7, zd[15].Length - 7);
                    e.Graphics.DrawString(strq, font_1, brush, left + 278, top + sg * 5 + nls / 2);
                    e.Graphics.DrawString(strh, font_1, brush, left + 278, top + sg * 5 + nls / 2 + 15);
                }
                else
                {
                    e.Graphics.DrawString(zd[15], font_1, brush, left + 278, top + sg * 5 + nls / 2);
                }

            }
            else
            {
                e.Graphics.DrawString(zd[15], font, brush, left + 288, top + sg * 5 + nls / 2);
            }
            //e.Graphics.DrawString(zd[15], font, brush, left + 288, top + sg * 5 + nls / 2);
            //人员类别
            e.Graphics.DrawString(zd[16], font, brush, left + 374, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[17], font_1, brush, left + 360, top + sg * 5 + nls / 2);
            //诊断名称
            e.Graphics.DrawString(zd[18], font, brush, left + 460, top + sg * 3 + 10);

            if (zd[19].Length > 5)
            {
                if (zd[19].Length > 7)
                {
                    string strq = zd[19].Substring(0, 7);
                    string strh = zd[19].Substring(7, zd[19].Length - 7);
                    e.Graphics.DrawString(strq, font_1, brush, left + 455, top + sg * 5);
                    e.Graphics.DrawString(strh, font_1, brush, left + 455, top + sg * 5 + 15);
                }
                else
                {
                    e.Graphics.DrawString(zd[19], font_1, brush, left + 455, top + sg * 5 + nls / 2);
                }

            }
            else
            {
                e.Graphics.DrawString(zd[19], font, brush, left + 455, top + sg * 5 + nls / 2);
            }
            //入院日期
            e.Graphics.DrawString(zd[20], font, brush, left + 555, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[21], font, brush, left + 545, top + sg * 5 + nls / 2);
            //出院日期
            e.Graphics.DrawString(zd[22], font, brush, left + 645, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[23], font, brush, left + 635, top + sg * 5 + nls / 2);
            //line2
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 - 6), new Point(left + line_h + 720, top + sg * 5 - 6));
            //line3
            e.Graphics.DrawLine(myPen, new Point(left + line_h, nls + top + sg * 6 - 2), new Point(left + line_h + 720, nls + top + sg * 6 - 2));
            top += nls;
            //line4
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 7 - 2), new Point(left + line_h + 720, top + sg * 7 - 2));

            //费用总额
            e.Graphics.DrawString(zd[24], font, brush, left + 15, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[25], font, brush, left + 15, top + sg * 9);
            //政策内费用
            e.Graphics.DrawString(zd[26], font, brush, left + 95, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[27], font, brush, left + 105, top + sg * 9);
            //基本医保
            e.Graphics.DrawString(zd[28], font, brush, left + 238, top + sg * 7 + 1);
            // 统筹支付
            e.Graphics.DrawString(zd[29], font, brush, left + 190, top + sg * 8 - 2);
            e.Graphics.DrawString(zd[30], font, brush, left + 195, top + sg * 9);
            // 提高待遇
            e.Graphics.DrawString(zd[31], font, brush, left + 280, top + sg * 8 - 2);
            e.Graphics.DrawString(zd[32], font, brush, left + 290, top + sg * 9);
            //大病保险
            e.Graphics.DrawString(zd[33], font, brush, left + 418, top + sg * 7 + 1);
            // 统筹支付
            e.Graphics.DrawString(zd[34], font, brush, left + 374, top + sg * 8 - 2);
            e.Graphics.DrawString(zd[35], font, brush, left + 384, top + sg * 9);
            // 提高待遇
            e.Graphics.DrawString(zd[36], font, brush, left + 460, top + sg * 8 - 2);
            e.Graphics.DrawString(zd[37], font, brush, left + 475, top + sg * 9);
            //医疗救助
            e.Graphics.DrawString(zd[38], font, brush, left + 550, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[39], font, brush, left + 560, top + sg * 9);
            //其他保障
            e.Graphics.DrawString(zd[40], font, brush, left + 620, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[41], font, brush, left + 655, top + sg * 9);
            //line5
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 175, top + sg * 8 - 5), new Point(left + line_h + 540, top + sg * 8 - 5));
            //line6,7
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 9 - 6), new Point(left + line_h + 720, top + sg * 9 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 10 - 2), new Point(left + line_h + 720, top + sg * 10 - 2));
            //line8
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 11 - 6), new Point(left + line_h + 720, top + sg * 11 - 6));
            //line9
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 290, top + sg * 12 - 3), new Point(left + line_h + 625, top + sg * 12 - 3));
            //line10
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 13 - 6), new Point(left + line_h + 720, top + sg * 13 - 6));
            //票据号
            e.Graphics.DrawString(zd[42], font, brush, left + 20, top + sg * 11 + 10);
            e.Graphics.DrawString(zd[43], font, brush, left + 12, top + sg * 13);
            //报销流水号
            e.Graphics.DrawString(zd[44], font, brush, left + 95, top + sg * 11 + 10);
            e.Graphics.DrawString(zd[45], font_1, brush, left + 90, top + sg * 13);
            //本次报销合计
            e.Graphics.DrawString(zd[46], font, brush, left + 185, top + sg * 11 + 10);
            e.Graphics.DrawString(zd[47], font, brush, left + 205, top + sg * 13);
            //本次个人负担
            e.Graphics.DrawString(zd[48], font, brush, left + 410, top + sg * 11);
            //小计
            e.Graphics.DrawString(zd[49], font, brush, left + 325, top + sg * 12);
            e.Graphics.DrawString(zd[50], font, brush, left + 320, top + sg * 13 - 2);
            //政策内自付
            e.Graphics.DrawString(zd[51], font, brush, left + 420, top + sg * 12);
            e.Graphics.DrawString(zd[52], font, brush, left + 435, top + sg * 13);
            //政策外自费
            e.Graphics.DrawString(zd[53], font, brush, left + 530, top + sg * 12);
            e.Graphics.DrawString(zd[54], font, brush, left + 545, top + sg * 13);
            //是否享用三重保障
            e.Graphics.DrawString(zd[55], font_2, brush, left + 623, top + sg * 11 + 10);
            e.Graphics.DrawString(zd[56], font, brush, left + 660, top + sg * 13);
            //line11
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 14 - 2), new Point(left + line_h + 720, top + sg * 14 - 2));

            e.Graphics.DrawString(zd[57], font, brush, left, top + sg * 14);
            e.Graphics.DrawString(zd[58], font, brush, left + 120, top + sg * 14);
            e.Graphics.DrawString(zd[59], font, brush, left + 240, top + sg * 14);
            e.Graphics.DrawString(zd[60], font, brush, left + 400, top + sg * 14);
            e.Graphics.DrawString(zd[61], font, brush, left + 540, top + sg * 14);
            e.Graphics.DrawString(zd[62], font, brush, left + 540, top + sg * 15);
            //line_sx
            #region
            //竖线1
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 3 - 2 - nls), new Point(left + line_h, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 7 - 2), new Point(left + line_h, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 11 - 6), new Point(left + line_h, top + sg * 14 - 2));
            //竖线2
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 90, top + sg * 3 - 2 - nls), new Point(left + line_h + 90, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 90, top + sg * 7 - 2), new Point(left + line_h + 90, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 90, top + sg * 11 - 6), new Point(left + line_h + 90, top + sg * 14 - 2));
            //竖线3
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 175, top + sg * 3 - 2 - nls), new Point(left + line_h + 175, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 175, top + sg * 7 - 2), new Point(left + line_h + 175, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 175, top + sg * 11 - 6), new Point(left + line_h + 175, top + sg * 14 - 2));
            //竖线4
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 270, top + sg * 3 - 2 - nls), new Point(left + line_h + 270, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 270, top + sg * 8 - 4), new Point(left + line_h + 270, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 290, top + sg * 11 - 6), new Point(left + line_h + 290, top + sg * 14 - 2));
            //竖线5
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 360, top + sg * 3 - 2 - nls), new Point(left + line_h + 360, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 360, top + sg * 7 - 2), new Point(left + line_h + 360, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 403, top + sg * 12 - 3), new Point(left + line_h + 403, top + sg * 14 - 2));
            //竖线6
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 450, top + sg * 3 - 2 - nls), new Point(left + line_h + 450, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 450, top + sg * 8 - 4), new Point(left + line_h + 450, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 514, top + sg * 12 - 3), new Point(left + line_h + 514, top + sg * 14 - 2));
            //竖线7
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 3 - 2 - nls), new Point(left + line_h + 540, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 7 - 2), new Point(left + line_h + 540, top + sg * 10 - 2));
            //竖线8
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 630, top + sg * 3 - 2 - nls), new Point(left + line_h + 630, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 625, top + sg * 7 - 2), new Point(left + line_h + 625, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 625, top + sg * 11 - 6), new Point(left + line_h + 625, top + sg * 14 - 2));
            //最后一条竖线
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 720, top + sg * 3 - 2 - nls), new Point(left + line_h + 720, top + sg * 6 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 720, top + sg * 7 - 2), new Point(left + line_h + 720, top + sg * 10 - 2));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 720, top + sg * 11 - 6), new Point(left + line_h + 720, top + sg * 14 - 2));
            #endregion
            #endregion
        }
        private void mzzf(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|井陉县中医医院|中医院|门诊|40008|马锁贵马锁贵马锁贵马锁贵马锁贵马锁贵|男|自费|壹佰玖拾捌元整|198|刘克强|2020|06|12|执行科室：放射科|";
                in_zfc_fy = "|X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费|";
                in_zfc_fy += "|X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费|";
                in_zfc_fy += "|X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费|";
                in_zfc_fy += "|X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费||X线计算机体层CT平扫|1|108.00000|自费|";

                //in_zfc_fy += "|注射用左卡尼汀/1g|100|1600.00|门诊药房";

                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int sg_temp = 220 / hs_fy;
            int hg_temp = 315;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 205, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 295, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 425, top + sg * 0);

            if (zd[5].Length > 10)
            {
                e.Graphics.DrawString(zd[5].Substring(0, 10), font, brush, left + 30, top + sg * 1);
                e.Graphics.DrawString(zd[5].Substring(10, zd[5].Length - 10), font, brush, left + 30, top + sg * 1 + 12);
            }
            else
            {
                e.Graphics.DrawString(zd[5], font, brush, left + 30, top + sg * 1);
            }
            e.Graphics.DrawString(zd[6], font, brush, left + 180, top + sg * 1);
            e.Graphics.DrawString(zd[7], font, brush, left + 290, top + sg * 1);
            if (!string.IsNullOrEmpty(zd[15]))
            {
                //Bitmap bm = new Bitmap(200, 70);
                //bm = get39(zd[13]);
                //e.Graphics.DrawImage(bm, left + 500, top - 40);//-1
                //e.Graphics.DrawString(zd[15], font2, brush, left, top - 30);//-1
            }
            //*********************************************************************************************************
            double feesum = 0.00;
            string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < ((zd_fy.Length - 1) / 5); i++)
            {
                if (i >= (hs_fy * 2))
                {
                    break;
                }
                if (i < hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 5].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 11) ? (zd_fy[1 + i * 5].Substring(11, zd_fy[1 + i * 5].Length - 1 -11)) : (zd_fy[1 + i * 5])), font, brush, left + 4, top + sg * 3 + i * sg_temp + sg_temp / 2);// top + sg * 3 + i * sg_temp + sg_temp / 2);                
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 12) ? (zd_fy[1 + i * 5].Substring(0, 12)+ "...") : (zd_fy[1 + i * 5])), font, brush, left + 4, top + sg * 3 + i * sg_temp);// top + sg * 3 + i * sg_temp + sg_temp / 2);                    /*/
                    //*
                    // e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4, top + sg * 3 + i * sg_temp);
                    //*/
                    
                    e.Graphics.DrawString(zd_fy[2 + i * 5], font1, brush, left + 185, top + sg * 3 + i * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 5], font1, brush, left + 215, top + sg * 3 + i * sg_temp);
                    feesum += Double.Parse(zd_fy[3 + i * 5]);
                    e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 270, top + sg * 3 + i * sg_temp);

                }
                if (i >= hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 5].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 11) ? (zd_fy[1 + i * 5].Substring(11, zd_fy[1 + i * 5].Length - 1 - 11)) : (zd_fy[1 + i * 5])), font, brush, left + 4, top + sg * 3 + (i - hs_fy) * sg_temp);// top + sg * 3 + i * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 12) ? (zd_fy[1 + i * 5].Substring(0, 12) + "...") : (zd_fy[1 + i * 5])), font, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);// top + sg * 3 + i * sg_temp + sg_temp / 2);                    /*/
                    //*
                    //e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    //*/
                    e.Graphics.DrawString(zd_fy[2 + i * 5], font1, brush, left + 185 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 5], font1, brush, left + 215 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    feesum += Double.Parse(zd_fy[3 + i * 5]);
                    e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 270 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                }
            }
            //*********************************************************************************************************
            e.Graphics.DrawString(RMB_DX.Convert(feesum), font, brush, left + 75, top + sg * 14);//合计（大写）：
            e.Graphics.DrawString(feesum.ToString("0.00"), font, brush, left + 345, top + sg * 14);
            //e.Graphics.DrawString(zd[8], font, brush, left + 75, top + sg * 14);//合计（大写）：
            //e.Graphics.DrawString(zd[9], font, brush, left + 345, top + sg * 14);

            e.Graphics.DrawString(zd[10], font, brush, left + 365, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[11], font1, brush, left + 535, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[12], font1, brush, left + 578, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[13], font1, brush, left + 609, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[14], font1, brush, left + 150, top + sg * 15 + 85);//7
            #endregion
        }
        private void mzybmzzfyjj(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|曹二狗|男|2019121616|现金|自费|100|壹佰元整|98|海绵宝宝|2019-12-16|";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            //int sg_temp = 220 / hs_fy;
            int hg_temp = 315;
            int line_h = 10;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 12, FontStyle.Regular);
            Pen myPen_bk = new Pen(Color.FromArgb(255, Color.Black), 1.2F);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');

            e.Graphics.DrawString("井陉县中医院  预交金凭条", font, brush, left + sg * 4, top + sg * 2);
            e.Graphics.DrawLine(myPen, new Point(left + sg * 1 + 5, top + sg * 3), new Point(left + sg * 15 + 5, top + sg * 3));
            e.Graphics.DrawString("姓名 ：", font, brush, left + sg * 1, top + sg * 3 + 3);
            e.Graphics.DrawString(zd[1], font, brush, left + sg * 3 + 10, top + sg * 3 + 3);

            e.Graphics.DrawString("性别 ：", font, brush, left + sg * 8, top + sg * 3 + 3);
            e.Graphics.DrawString(zd[2], font, brush, left + sg * 10 + 10, top + sg * 3 + 3);

            e.Graphics.DrawString("卡号 ：", font, brush, left + sg * 1, top + sg * 4);
            e.Graphics.DrawString(zd[3], font, brush, left + sg * 3 + 10, top + sg * 4);

            e.Graphics.DrawLine(myPen, new Point(left + sg * 1 + 5, top + sg * 5), new Point(left + sg * 15 + 5, top + sg * 5));
            e.Graphics.DrawString("支付类别 ：", font, brush, left + sg * 1, top + sg * 5 + 3);
            e.Graphics.DrawString(zd[4], font, brush, left + sg * 5 + 10, top + sg * 5 + 3);

            e.Graphics.DrawString("费别 ：", font, brush, left + sg * 8, top + sg * 5 + 3);
            e.Graphics.DrawString(zd[5], font, brush, left + sg * 10 + 10, top + sg * 5 + 3);

            e.Graphics.DrawString("缴款金额 ：", font, brush, left + sg * 1, top + sg * 6 + 3);
            e.Graphics.DrawString(zd[6], font, brush, left + sg * 5 + 10, top + sg * 6 + 3);

            e.Graphics.DrawString("金额大写 ：", font, brush, left + sg * 1, top + sg * 7 + 3);
            e.Graphics.DrawString(zd[7], font, brush, left + sg * 5 + 10, top + sg * 7 + 3);

            e.Graphics.DrawString("卡内余额 ：", font, brush, left + sg * 1, top + sg * 8 + 3);
            e.Graphics.DrawString(zd[8], font, brush, left + sg * 5 + 10, top + sg * 8 + 3);

            e.Graphics.DrawLine(myPen, new Point(left + sg * 1 + 5, top + sg * 9), new Point(left + sg * 15 + 5, top + sg * 9));
            e.Graphics.DrawString("收款人 ：", font, brush, left + sg * 1, top + sg * 9 + 3);
            e.Graphics.DrawString(zd[9], font, brush, left + sg * 4, top + sg * 9 + 3);

            e.Graphics.DrawString("缴款日期 ：", font, brush, left + sg * 8, top + sg * 9 + 3);
            e.Graphics.DrawString(zd[10], font, brush, left + sg * 12 - 10, top + sg * 9 + 3);



            #endregion
        }
        private void ybdz(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|2020-01-09|2020-01-09|账平|门诊|3|0|13.6500|0.0000|0.0000|0.0000|0.0000|13.6500|0.0000|0.0000|0.0000|2020-01-09|许紫薇|";
                hs_fy = 12;
            }
            #endregion

            int sg = 40;
            //int sg_temp = 220 / hs_fy;
            int hg_temp = 315;
            int line_h = 10;

            Font font = new Font("宋体", 13, FontStyle.Regular);
            Font font1 = new Font("宋体", 16, FontStyle.Regular);
            Font font2 = new Font("宋体", 12, FontStyle.Regular);
            Pen myPen_bk = new Pen(Color.FromArgb(255, Color.Black), 1.2F);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');

            e.Graphics.DrawString("医疗信息对账单", font1, brush, left + sg * 8, top + sg * 1);

            e.Graphics.DrawString("开始时间 ：", font, brush, left + sg * 6, top + sg * 2 + 3);
            e.Graphics.DrawString(zd[1], font, brush, left + sg * 8 + 10, top + sg * 2 + 3);
            e.Graphics.DrawString("结束时间 ：", font, brush, left + sg * 12, top + sg * 2 + 3);
            e.Graphics.DrawString(zd[2], font, brush, left + sg * 14 + 10, top + sg * 2 + 3);
            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 3), new Point(left + sg * 19, top + sg * 3));

            e.Graphics.DrawString("对账结果 ：", font, brush, left + sg * 1, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[3], font, brush, left + sg * 3 + 10, top + sg * 3 + 10);
            e.Graphics.DrawString("业务类型 ：", font, brush, left + sg * 6, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[4], font, brush, left + sg * 8 + 10, top + sg * 3 + 10);
            e.Graphics.DrawString("正交易笔数 ：", font, brush, left + sg * 10, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[5], font, brush, left + sg * 12 + 30, top + sg * 3 + 10);
            e.Graphics.DrawString("反交易笔数 ：", font, brush, left + sg * 14, top + sg * 3 + 10);
            e.Graphics.DrawString(zd[6], font, brush, left + sg * 16 + 30, top + sg * 3 + 10);
            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 4), new Point(left + sg * 19, top + sg * 4));
            e.Graphics.DrawString("接收方医疗费总额 ：", font, brush, left + sg * 1, top + sg * 4 + 10);
            e.Graphics.DrawString(zd[7], font, brush, left + sg * 5 + 10, top + sg * 4 + 10);
            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 5), new Point(left + sg * 19, top + sg * 5));

            e.Graphics.DrawString("接收方现金支付合计 ：", font, brush, left + sg * 1, top + sg * 5 + 10);
            e.Graphics.DrawString(zd[8], font, brush, left + sg * 5 + 20, top + sg * 5 + 10);

            e.Graphics.DrawString("医保金合计：", font, brush, left + sg * 10, top + sg * 5 + 10);
            e.Graphics.DrawString(zd[9], font, brush, left + sg * 12 + 20, top + sg * 5 + 10);

            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 6), new Point(left + sg * 19, top + sg * 6));

            e.Graphics.DrawString("接收方帐户支付合计 ：", font, brush, left + sg * 1, top + sg * 6 + 10);
            e.Graphics.DrawString(zd[10], font, brush, left + sg * 5 + 20, top + sg * 6 + 10);

            e.Graphics.DrawString("统筹基金合计 ：", font, brush, left + sg * 10, top + sg * 6 + 10);
            e.Graphics.DrawString(zd[11], font, brush, left + sg * 13 + 10, top + sg * 6 + 10);

            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 7), new Point(left + sg * 19, top + sg * 7));

            e.Graphics.DrawString("接收方大病救助基金 ：", font, brush, left + sg * 1, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[12], font, brush, left + sg * 5 + 20, top + sg * 7 + 10);

            e.Graphics.DrawString("接收方统筹基金支付 ：", font, brush, left + sg * 10, top + sg * 7 + 10);
            e.Graphics.DrawString(zd[13], font, brush, left + sg * 14 + 20, top + sg * 7 + 10);

            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 8), new Point(left + sg * 19, top + sg * 8));

            e.Graphics.DrawString("接收方公务员补助合计 ：", font, brush, left + sg * 1, top + sg * 8 + 10);
            e.Graphics.DrawString(zd[14], font, brush, left + sg * 6, top + sg * 8 + 10);

            e.Graphics.DrawString("接收方其他基金支付合计：", font, brush, left + sg * 10, top + sg * 8 + 10);
            e.Graphics.DrawString(zd[15], font, brush, left + sg * 15 + 10, top + sg * 8 + 10);
            e.Graphics.DrawLine(myPen, new Point(left + sg * 1, top + sg * 9), new Point(left + sg * 19, top + sg * 9));
            e.Graphics.DrawString("统计时间：", font, brush, left + sg * 1, top + sg * 9 + 10);
            e.Graphics.DrawString(zd[16], font, brush, left + sg * 3 + 30, top + sg * 9 + 10);
            e.Graphics.DrawString("统计人：", font, brush, left + sg * 10, top + sg * 9 + 10);
            e.Graphics.DrawString(zd[17], font, brush, left + sg * 13 + 30, top + sg * 9 + 10);

            #endregion
        }
        private void mzyb(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|井陉县中医医院|其他诊疗机构|外一科|80080|李白|男|井陉县职工-在职|20191209|肆拾元陆角整|40.6|0.0000|40.6000|0.0000|0.0000|799.1500|0.0000|0.0000||基本统筹支付:0.0000|补助统筹支付:0.0000|大病统筹支付::0.0000||基本提高支付：0.0000|大病提高支付:0.0000|医疗救助支付：0.0000|医疗救助补充支付:0.0000|收款单位|执行科室：门诊西药房|许紫薇|2020|01|11||石家庄市医保(WH02)||";
                in_zfc_fy = "|缬沙坦胶囊/80mg12S2板（穗悦）|1|0.6500|医保[甲]||缬沙坦胶囊/80mg12S2板（穗悦）|1|19.2900|医保[乙 95%]||阿莫西林胶囊/0.25g|1|10.6700|医保[甲]||西咪替丁片/0.1g|111|0.0900|医保[自费]|";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int sg_temp = 220 / hs_fy;
            int hg_temp = 315;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 205, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 295, top + sg * 0);
            e.Graphics.DrawString(zd[36], font, brush, left + 425, top + sg * 0 - 40);
            e.Graphics.DrawString(zd[35], font, brush, left + 425, top + sg * 0 - 20);
            e.Graphics.DrawString(zd[4], font, brush, left + 425, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 30, top + sg * 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 180, top + sg * 1);
            e.Graphics.DrawString(zd[7], font2, brush, left + 290, top + sg * 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 480, top + sg * 1);
            //*********************************************************************************************************
            double feesum = 0.00;
            string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < ((zd_fy.Length - 1) / 5); i++)
            {
                if (i >= (hs_fy * 2))
                {
                    break;
                }
                if (i < hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 5].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 22) ? (zd_fy[1 + i * 5].Substring(11, 11)) : (zd_fy[1 + i * 5].Substring(11, (zd_fy[1 + i * 5].Length - 11)))), font, brush, left + 4, top + sg * 3 + i * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 11) ? (zd_fy[1 + i * 5].Substring(0, 11)) : (zd_fy[1 + i * 5])), font, brush, left + 4, top + sg * 3 + i * sg_temp);
                    /*/
                    //*
                    e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4, top + sg * 3 + i * sg_temp);
                    //*/

                    e.Graphics.DrawString(zd_fy[2 + i * 5], font1, brush, left + 175, top + sg * 3 + i * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 5], font1, brush, left + 205, top + sg * 3 + i * sg_temp);
                    feesum += Double.Parse(zd_fy[3 + i * 5]);
                    if (zd_fy[4 + i * 5].Length > 6)
                    {
                        e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 240, top + sg * 3 + i * sg_temp);
                    }
                    else
                    {
                        e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 260, top + sg * 3 + i * sg_temp);
                    }


                }
                if (i >= hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 5].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 22) ? (zd_fy[1 + i * 5].Substring(11, 11)) : (zd_fy[1 + i * 5].Substring(11, (zd_fy[1 + i * 5].Length - 11)))), font, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 5].Length > 11) ? (zd_fy[1 + i * 5].Substring(0, 11)) : (zd_fy[1 + i * 5])), font, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    /*/
                   //*
                   e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                   //*/
                    e.Graphics.DrawString(zd_fy[2 + i * 5], font1, brush, left + 175 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 5], font1, brush, left + 205 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    feesum += Double.Parse(zd_fy[3 + i * 5]);
                    if (zd_fy[4 + i * 5].Length > 6)
                    {
                        e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 255 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    }
                    else
                    {
                        e.Graphics.DrawString(zd_fy[4 + i * 5], font1, brush, left + 260 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    }
                }
            }
            //*********************************************************************************************************

            //e.Graphics.DrawString(zd[9], font, brush, left + 75, top + sg * 14);//合计（大写）：
            //e.Graphics.DrawString(zd[10], font, brush, left + 345, top + sg * 14);
            e.Graphics.DrawString(RMB_DX.Convert(feesum), font, brush, left + 75, top + sg * 14);//合计（大写）：
            e.Graphics.DrawString(feesum.ToString("0.00"), font, brush, left + 345, top + sg * 14);
            if (zd_fy.Length == 121)
            {
                e.Graphics.DrawString("0", font, brush, left + 75, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 240, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 385, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 550, top + sg * 15 + 4);//2

                e.Graphics.DrawString("0", font, brush, left + 75, top + sg * 15 + 23);//3
                e.Graphics.DrawString("0", font, brush, left + 240, top + sg * 15 + 23);//3
                e.Graphics.DrawString("0", font, brush, left + 405, top + sg * 15 + 23);//3
                e.Graphics.DrawString(zd[18], font, brush, left + 460, top + sg * 15 + 23);//3

                e.Graphics.DrawString(zd[19].Split(':')[0].ToString() + ": 0", font, brush, left + 0, top + sg * 14 + 65);//3
                e.Graphics.DrawString(zd[20].Split(':')[0].ToString() + ": 0", font, brush, left + 177, top + sg * 14 + 65);//4
                e.Graphics.DrawString(zd[21].Split(':')[0].ToString() + ": 0", font, brush, left + 330, top + sg * 14 + 65);//5
                e.Graphics.DrawString(zd[22], font, brush, left + 490, top + sg * 14 + 65);//5

                e.Graphics.DrawString((zd[23] != "" ? zd[23].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 0, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[24] != "" ? zd[24].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 140, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[25] != "" ? zd[25].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 310, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[36] != "" ? zd[26].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 470, top + sg * 14 + 85);//5



                e.Graphics.DrawString(zd[27], font, brush, left + 0, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[28], font, brush, left + 170, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[29], font, brush, left + 380, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[30], font, brush, left + 500, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[31], font, brush, left + 560, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[32], font, brush, left + 600, top + sg * 15 + 85);//7

                e.Graphics.DrawString(zd[33], font, brush, left + 450, top + sg * 1 - 48);//7
                e.Graphics.DrawString(zd[34], font, brush, left + 280, top + sg * 1 - 40);//7
                return;
            }

            e.Graphics.DrawString(zd[11], font, brush, left + 75, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[12], font, brush, left + 240, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[13], font, brush, left + 385, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[14], font, brush, left + 550, top + sg * 15 + 4);//2

            e.Graphics.DrawString(zd[15], font, brush, left + 75, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[16], font, brush, left + 240, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[17], font, brush, left + 405, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[18], font, brush, left + 460, top + sg * 15 + 23);//3

            e.Graphics.DrawString(zd[19], font, brush, left + 0, top + sg * 14 + 65);//3
            e.Graphics.DrawString(zd[20], font, brush, left + 177, top + sg * 14 + 65);//4
            e.Graphics.DrawString(zd[21], font, brush, left + 330, top + sg * 14 + 65);//5
            e.Graphics.DrawString(zd[22], font, brush, left + 490, top + sg * 14 + 65);//5

            e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[24], font, brush, left + 140, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[25], font, brush, left + 310, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[26], font, brush, left + 470, top + sg * 14 + 85);//5



            e.Graphics.DrawString(zd[27], font, brush, left + 0, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[28], font, brush, left + 170, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[29], font, brush, left + 380, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[30], font, brush, left + 500, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[31], font, brush, left + 560, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[32], font, brush, left + 600, top + sg * 15 + 85);//7

            e.Graphics.DrawString(zd[33], font, brush, left + 450, top + sg * 1 - 48);//7
            e.Graphics.DrawString(zd[34], font, brush, left + 280, top + sg * 1 - 40);//7
            #endregion
        }
        int page_mzfp = 0;
        /// <summary>
        /// new门诊发票打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mzybnew(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|井陉县中医医院|其他诊疗机构|外一科|80080|李白|男|井陉县职工-在职|20191209|肆拾元陆角整|40.6|0.0000|40.6000|0.0000|0.0000|799.1500|0.0000|0.0000||基本统筹支付:0.0000|补助统筹支付:0.0000|大病统筹支付::0.0000||基本提高支付：0.0000|大病提高支付:0.0000|医疗救助支付：0.0000|医疗救助补充支付:0.0000|收款单位|执行科室：门诊西药房|许紫薇|2020|01|11||石家庄市医保(WH02)||";
                in_zfc_fy = "|缬沙坦胶囊/80mg12S2板（穗悦）|1|0.6500|医保[甲]||缬沙坦胶囊/80mg12S2板（穗悦）|1|19.2900|医保[乙 95%]||阿莫西林胶囊/0.25g|1|10.6700|医保[甲]||西咪替丁片/0.1g|111|0.0900|医保[自费]|";
                hs_fy = 12;
            }
            #endregion

            int printCount = list_mx.Count / 24 + ((list_mx.Count % 24) != 0 ? 1 : 0);
            if (page_mzfp >= printCount)
            {
                page_mzfp = 0;
            }
            page_mzfp++;

            int sg = 20;
            int sg_temp = 220 / hs_fy;
            int hg_temp = 315;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 205, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 295, top + sg * 0);
            e.Graphics.DrawString(zd[36], font, brush, left + 425, top + sg * 0 - 40);
            e.Graphics.DrawString(zd[35], font, brush, left + 425, top + sg * 0 - 20);
            e.Graphics.DrawString(zd[4], font, brush, left + 425, top + sg * 0);

            if (zd[5].Length > 10)
            {
                e.Graphics.DrawString(zd[5].Substring(0, 10), font, brush, left + 30, top + sg * 1);
                e.Graphics.DrawString(zd[5].Substring(10, zd[5].Length - 1 - 10), font, brush, left + 30, top + sg * 1 + 12);
            }
            else
            {
                e.Graphics.DrawString(zd[5], font, brush, left + 30, top + sg * 1);
            }
            e.Graphics.DrawString(zd[6], font, brush, left + 180, top + sg * 1);
            e.Graphics.DrawString(zd[7], font2, brush, left + 290, top + sg * 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 480, top + sg * 1);
            //*********************************************************************************************************

            #region 页码
            e.Graphics.DrawString("("+page_mzfp + "-" + printCount+")", font, brush, left + 600, top + sg * 0 - 30);
            e.Graphics.DrawString("(第" + page_mzfp + "页" + "," + "共" + printCount + "页)", font, brush, left + 300, top + sg * 16 + 85);
            #endregion

            double feesum = 0.00;
            //string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = (page_mzfp - 1) * 24; i < list_mx.Count; i++)
            {
                if ((i / 12) % 2 == 0)
                {
                    //*
                    if ((list_mx[i][0].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((list_mx[i][0].Length > 22) ? (list_mx[i][0].Substring(11, 11)) : (list_mx[i][0].Substring(11, (list_mx[i][0].Length - 11)))), font, brush, left + 4, top + sg * 3 + (i -(page_mzfp -1 ) * 24) * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((list_mx[i][0].Length > 11) ? (list_mx[i][0].Substring(0, 11)) : (list_mx[i][0])), font, brush, left + 4, top + sg * 3 + (i - (page_mzfp - 1) * 24) * sg_temp);
                    /*/
                    //*
                    e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4, top + sg * 3 + i * sg_temp);
                    //*/

                    e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 175, top + sg * 3 + (i - (page_mzfp - 1) * 24) * sg_temp);
                    e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 205, top + sg * 3 + (i - (page_mzfp - 1) * 24) * sg_temp);
                    feesum += Double.Parse(list_mx[i][2]);
                    if (list_mx[i][3].Length > 6)
                    {
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 240, top + sg * 3 + (i - (page_mzfp - 1) * 24) * sg_temp);
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 260, top + sg * 3 + (i - (page_mzfp - 1) * 24) * sg_temp);
                    }


                }
                if ((i / 12) % 2 == 1)
                {
                    //*
                    if ((list_mx[i][0].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((list_mx[i][0].Length > 22) ? (list_mx[i][0].Substring(11, 11)) : (list_mx[i][0].Substring(11, (list_mx[i][0].Length - 11)))), font, brush, left + 4 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((list_mx[i][0].Length > 11) ? (list_mx[i][0].Substring(0, 11)) : (list_mx[i][0])), font, brush, left + 4 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp);
                    /*/
                   //*
                   e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                   //*/
                    e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 175 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp);
                    e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 205 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp);
                    feesum += Double.Parse(list_mx[i][2]);
                    if (list_mx[i][3].Length > 6)
                    {
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 255 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp);
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 260 + hg_temp, top + sg * 3 + ((i - (page_mzfp - 1) * 24) - hs_fy) * sg_temp);
                    }
                   
                }
                if (list_mx.Count == 24 * page_m && i == list_mx.Count - 1)
                {

                }
                else
                {
                    if (i == page_mzfp * 24 - 1)
                    {
                        //e.HasMorePages = true;
                        //break;
                        if (i == list_mx.Count - 1)
                        {
                            e.HasMorePages = false;
                            break;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            break;
                        }
                    }
                }

            }
            //*********************************************************************************************************

            //e.Graphics.DrawString(zd[9], font, brush, left + 75, top + sg * 14);//合计（大写）：
            //e.Graphics.DrawString(zd[10], font, brush, left + 345, top + sg * 14);
            e.Graphics.DrawString(RMB_DX.Convert(feesum), font, brush, left + 75, top + sg * 14);//合计（大写）：
            e.Graphics.DrawString(feesum.ToString("0.00"), font, brush, left + 345, top + sg * 14);

            if (page_mzfp < printCount)
            {
                e.Graphics.DrawString("0", font, brush, left + 75, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 240, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 385, top + sg * 15 + 4);//2
                e.Graphics.DrawString("0", font, brush, left + 550, top + sg * 15 + 4);//2

                e.Graphics.DrawString("0", font, brush, left + 75, top + sg * 15 + 23);//3
                e.Graphics.DrawString("0", font, brush, left + 240, top + sg * 15 + 23);//3
                e.Graphics.DrawString("0", font, brush, left + 405, top + sg * 15 + 23);//3
                e.Graphics.DrawString(zd[18], font, brush, left + 460, top + sg * 15 + 23);//3

                e.Graphics.DrawString(zd[19].Split(':')[0].ToString() + ": 0", font, brush, left + 0, top + sg * 14 + 65);//3
                e.Graphics.DrawString(zd[20].Split(':')[0].ToString() + ": 0", font, brush, left + 177, top + sg * 14 + 65);//4
                e.Graphics.DrawString(zd[21].Split(':')[0].ToString() + ": 0", font, brush, left + 330, top + sg * 14 + 65);//5
                e.Graphics.DrawString(zd[22], font, brush, left + 490, top + sg * 14 + 65);//5

                e.Graphics.DrawString((zd[23] != "" ? zd[23].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 0, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[24] != "" ? zd[24].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 140, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[25] != "" ? zd[25].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 310, top + sg * 14 + 85);//5
                e.Graphics.DrawString((zd[36] != "" ? zd[26].Split(':')[0].ToString() + ": 0" : ""), font, brush, left + 470, top + sg * 14 + 85);//5



                e.Graphics.DrawString(zd[27], font, brush, left + 0, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[28], font, brush, left + 170, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[29], font, brush, left + 380, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[30], font, brush, left + 500, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[31], font, brush, left + 560, top + sg * 15 + 85);//7
                e.Graphics.DrawString(zd[32], font, brush, left + 600, top + sg * 15 + 85);//7

                e.Graphics.DrawString(zd[33], font, brush, left + 450, top + sg * 1 - 48);//7
                e.Graphics.DrawString(zd[34], font, brush, left + 280, top + sg * 1 - 40);//7
                return;
            }

            e.Graphics.DrawString(zd[11], font, brush, left + 75, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[12], font, brush, left + 240, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[13], font, brush, left + 385, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[14], font, brush, left + 550, top + sg * 15 + 4);//2

            e.Graphics.DrawString(zd[15], font, brush, left + 75, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[16], font, brush, left + 240, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[17], font, brush, left + 405, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[18], font, brush, left + 460, top + sg * 15 + 23);//3

            e.Graphics.DrawString(zd[19], font, brush, left + 0, top + sg * 14 + 65);//3
            e.Graphics.DrawString(zd[20], font, brush, left + 177, top + sg * 14 + 65);//4
            e.Graphics.DrawString(zd[21], font, brush, left + 330, top + sg * 14 + 65);//5
            e.Graphics.DrawString(zd[22], font, brush, left + 490, top + sg * 14 + 65);//5

            e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[24], font, brush, left + 140, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[25], font, brush, left + 310, top + sg * 14 + 85);//5
            e.Graphics.DrawString(zd[26], font, brush, left + 470, top + sg * 14 + 85);//5



            e.Graphics.DrawString(zd[27], font, brush, left + 0, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[28], font, brush, left + 170, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[29], font, brush, left + 380, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[30], font, brush, left + 500, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[31], font, brush, left + 560, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[32], font, brush, left + 600, top + sg * 15 + 85);//7

            e.Graphics.DrawString(zd[33], font, brush, left + 450, top + sg * 1 - 48);//7
            e.Graphics.DrawString(zd[34], font, brush, left + 280, top + sg * 1 - 40);//7
            #endregion
        }
        private void mzcx(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                //in_zfc = "|广平中医院|二级甲等|检验科|201701|王宁|男|城乡居民基本医疗保险|130427199201|壹仟零伍拾|1050|医保统筹支付|个人账户支付|个人自付|个人自费|个人账户余额|起付标准累计|统筹累计支付|贫困救助支付合计|起付线支付|本次符合基本医疗费用|本年历次个人自付累计|进入大病金额|大病支付金额|本年大病累计支付|个人现金支付|医保中心名称|备注提示|收款人|参保人签字|2017|07|29";
                in_zfc = "|广平中医院|二级甲等|检验科|201701|王宁|男|城乡居民基本医疗保险|130427199201|壹仟零伍拾|1050|1.00|2.00|3.00|4.00|5.00|6.00|7.00|贫困救助支付合计:8.00 起付线支付:8.00|本次符合基本医疗费用:9.00   本年历次个人自付累计:9.00   进入大病金额:9.00   大病支付金额:9.00|本年大病累计支付:10.00       个人现金支付:10.00       医保中心名称:邯郸市邯山区医保中心|备注提示:|李白|参保人签字:|2017|07|29";
                in_zfc_fy = "|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房";
                in_zfc_fy += "|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房";
                in_zfc_fy += "|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房";
                //in_zfc_fy += "|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房|注射用左卡尼汀/1g|100|1600.00|门诊药房";

                //in_zfc_fy += "|注射用左卡尼汀/1g|100|1600.00|门诊药房";

                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int sg_temp = 220 / hs_fy;
            int hg_temp = 315;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 205, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 295, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 425, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 30, top + sg * 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 180, top + sg * 1);
            e.Graphics.DrawString(zd[7], font2, brush, left + 290, top + sg * 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 480, top + sg * 1);
            //*********************************************************************************************************

            string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < ((zd_fy.Length - 1) / 4); i++)
            {
                if (i >= (hs_fy * 2))
                {
                    break;
                }
                if (i < hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 4].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 4].Length > 22) ? (zd_fy[1 + i * 4].Substring(11, 11)) : (zd_fy[1 + i * 4].Substring(11, (zd_fy[1 + i * 4].Length - 11)))), font, brush, left + 4, top + sg * 3 + i * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 4].Length > 11) ? (zd_fy[1 + i * 4].Substring(0, 11)) : (zd_fy[1 + i * 4])), font, brush, left + 4, top + sg * 3 + i * sg_temp);
                    /*/
                    //*
                    e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4, top + sg * 3 + i * sg_temp);
                    //*/

                    e.Graphics.DrawString(zd_fy[2 + i * 4], font1, brush, left + 175, top + sg * 3 + i * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 4], font1, brush, left + 205, top + sg * 3 + i * sg_temp);
                    e.Graphics.DrawString(zd_fy[4 + i * 4], font1, brush, left + 260, top + sg * 3 + i * sg_temp);

                }
                if (i >= hs_fy)
                {
                    //*
                    if ((zd_fy[1 + i * 4].Length > 11) && (hs_fy == 6))
                    {
                        e.Graphics.DrawString(((zd_fy[1 + i * 4].Length > 22) ? (zd_fy[1 + i * 4].Substring(11, 11)) : (zd_fy[1 + i * 4].Substring(11, (zd_fy[1 + i * 4].Length - 11)))), font, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp + sg_temp / 2);
                    }
                    e.Graphics.DrawString(((zd_fy[1 + i * 4].Length > 11) ? (zd_fy[1 + i * 4].Substring(0, 11)) : (zd_fy[1 + i * 4])), font, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    /*/
                   //*
                   e.Graphics.DrawString(zd_fy[1 + i * 4], font1, brush, left + 4 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                   //*/
                    e.Graphics.DrawString(zd_fy[2 + i * 4], font1, brush, left + 175 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    e.Graphics.DrawString(zd_fy[3 + i * 4], font1, brush, left + 205 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                    e.Graphics.DrawString(zd_fy[4 + i * 4], font1, brush, left + 260 + hg_temp, top + sg * 3 + (i - hs_fy) * sg_temp);
                }
            }
            //*********************************************************************************************************

            e.Graphics.DrawString(zd[9], font, brush, left + 75, top + sg * 14);//合计（大写）：
            e.Graphics.DrawString(zd[10], font, brush, left + 345, top + sg * 14);

            e.Graphics.DrawString(zd[11], font, brush, left + 75, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[12], font, brush, left + 240, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[13], font, brush, left + 385, top + sg * 15 + 4);//2
            e.Graphics.DrawString(zd[14], font, brush, left + 550, top + sg * 15 + 4);//2

            e.Graphics.DrawString(zd[15], font, brush, left + 75, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[16], font, brush, left + 240, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[17], font, brush, left + 405, top + sg * 15 + 23);//3
            e.Graphics.DrawString(zd[18], font1, brush, left + 460, top + sg * 15 + 23);//3

            e.Graphics.DrawString(zd[19], font1, brush, left - 10, top + sg * 15 + 36);//4

            e.Graphics.DrawString(zd[20], font1, brush, left - 10, top + sg * 15 + 49);//5

            e.Graphics.DrawString(zd[21], font1, brush, left - 10, top + sg * 15 + 62);//6

            e.Graphics.DrawString(zd[22], font, brush, left + 355, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[23], font1, brush, left + 399, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[24], font1, brush, left + 535, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[25], font1, brush, left + 578, top + sg * 15 + 85);//7
            e.Graphics.DrawString(zd[26], font1, brush, left + 609, top + sg * 15 + 85);//7
            #endregion
        }
        private void mzcxjsd(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|邯郸市城乡居民医疗保险（门诊慢性病、特殊病）结算单|医疗机构：广平中医院|门诊号：2017111018271234|入院(门诊)日期：2017-11-10|个人编号：1304251728|姓名：李宁|人员类别：城乡居民";
                in_zfc += "|医疗类别|门诊特殊病|总费用|800|起付线标准|400|累计起付线|0";
                in_zfc += "|本年历次统筹支出|200|本次合规费用|700|本次统筹支付|200";
                in_zfc += "|本年大病历次合规金额|1200|本年大病历次支付金额|700|本次大病合规金额|0|本次大病支付金额|0";
                in_zfc += "|其中贫困人口提高待遇部分分项";
                in_zfc += "|门诊起付线降低提高待遇|提高门诊报销比例提高待遇|门诊提高封顶线提高待遇|大病保险提高封顶线提高待遇|大病保险取消起付线提高待遇|贫困人口提高待遇部分合计|本年历次门诊医疗救助累计|本次门诊医疗救助支付";
                in_zfc += "|0|0|0|0|0|0|0|0";
                in_zfc += "|报销支付合计|200|本次个人现金支付|600";
                in_zfc += "|备注提示：|医保中心名称：邯郸市大名县医保中心|参保人签字:李宁|经办人：李白|经办日期：2017-07-29";
            }
            #endregion

            int sg = 20;
            int hg_temp1 = 90;
            int line_h = -5;

            Font font_bt = new Font("宋体", 15, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font_jc = new Font("宋体", 10, FontStyle.Regular);
            //Font font_jc = new Font("宋体", 10, FontStyle.Bold);
            Pen myPen_bk = new Pen(Color.FromArgb(255, Color.Black), 1.2F);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            Brush brush_ts = Brushes.Red;
            string[] zd = in_zfc.Split('|');

            e.Graphics.DrawString(zd[1], font_bt, brush_ts, left + (hg_temp1 * 8 - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 10);//1

            e.Graphics.DrawString(zd[2], font, brush, left, top + sg * 1);//2
            e.Graphics.DrawString(zd[3], font, brush, left + 330, top + sg * 1);//2
            e.Graphics.DrawString(zd[4], font, brush, left + 535, top + sg * 1);//2

            e.Graphics.DrawString(zd[5], font, brush, left, top + sg * 2);//3
            e.Graphics.DrawString(zd[6], font, brush, left + 330, top + sg * 2);//3
            e.Graphics.DrawString(zd[7], font, brush, left + 535, top + sg * 2);//3

            //line1
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 8, top + sg * 3 - 3));

            e.Graphics.DrawString(zd[8], font, brush, left + hg_temp1 * 0, top + sg * 3);//4
            e.Graphics.DrawString(zd[9], font, brush, left + hg_temp1 * 1, top + sg * 3);//4
            e.Graphics.DrawString(zd[10], font, brush, left + hg_temp1 * 2, top + sg * 3);//4
            e.Graphics.DrawString(zd[11], font, brush, left + hg_temp1 * 3, top + sg * 3);//4
            e.Graphics.DrawString(zd[12], font, brush, left + hg_temp1 * 4, top + sg * 3);//4
            e.Graphics.DrawString(zd[13], font, brush, left + hg_temp1 * 5, top + sg * 3);//4
            e.Graphics.DrawString(zd[14], font, brush, left + hg_temp1 * 6, top + sg * 3);//4
            e.Graphics.DrawString(zd[15], font, brush, left + hg_temp1 * 7, top + sg * 3);//4

            //line2,3
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + hg_temp1 * 8, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 8, top + sg * 4 + 1));

            e.Graphics.DrawString(zd[16].Substring(0, 4), font, brush, left, top + sg * 4 + 3);//5
            e.Graphics.DrawString(zd[16].Substring(4, 4), font, brush, left, top + sg * 5 - 2);//6
            e.Graphics.DrawString(zd[17], font, brush, left + hg_temp1 * 1, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[18].Substring(0, 4), font, brush, left + hg_temp1 * 4, top + sg * 4 + 3);//5
            e.Graphics.DrawString(zd[18].Substring(4, 2), font, brush, left + hg_temp1 * 4 + 12, top + sg * 5 - 2);//6
            e.Graphics.DrawString(zd[19], font, brush, left + hg_temp1 * 5, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[20].Substring(0, 4), font_jc, brush_ts, left + hg_temp1 * 6, top + sg * 4 + 3);//5
            e.Graphics.DrawString(zd[20].Substring(4, 2), font_jc, brush_ts, left + hg_temp1 * 6 + 12, top + sg * 5 - 2);//6
            e.Graphics.DrawString(zd[21], font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 4 + 10);//5.5

            //line4,5
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 6 - 6), new Point(left + line_h + hg_temp1 * 8, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 8, top + sg * 6 - 2));

            e.Graphics.DrawString(zd[22].Substring(0, 5), font, brush, left, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[22].Substring(5, 5), font, brush, left, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[23], font, brush, left + hg_temp1 * 1, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[24].Substring(0, 5), font, brush, left + hg_temp1 * 2, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[24].Substring(5, 5), font, brush, left + hg_temp1 * 2, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[25], font, brush, left + hg_temp1 * 3, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[26].Substring(0, 4), font, brush, left + hg_temp1 * 4, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[26].Substring(4, 4), font, brush, left + hg_temp1 * 4, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[27], font, brush, left + hg_temp1 * 5, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[28].Substring(0, 4), font_jc, brush_ts, left + hg_temp1 * 6, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[28].Substring(4, 2), font_jc, brush_ts, left + hg_temp1 * 6 + 12, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[29], font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 6 + 10);//7.5

            //line6,7
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 8 - 6), new Point(left + line_h + hg_temp1 * 8, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 8 - 2), new Point(left + line_h + hg_temp1 * 8, top + sg * 8 - 2));

            e.Graphics.DrawString(zd[30], font, brush, left + 100, top + sg * 8);//9

            //line8
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 9 - 2), new Point(left + line_h + hg_temp1 * 5, top + sg * 9 - 2));

            e.Graphics.DrawString(zd[31].Substring(0, 5), font, brush, left, top + sg * 9 + 2);//10
            e.Graphics.DrawString(zd[31].Substring(5, 2), font, brush, left, top + sg * 10 - 2);//11
            e.Graphics.DrawString(zd[31].Substring(7, 4), font, brush, left, top + sg * 11 - 6);//12
            e.Graphics.DrawString(zd[32].Substring(0, 4), font, brush, left + hg_temp1 * 1, top + sg * 9 + 2);//10
            e.Graphics.DrawString(zd[32].Substring(4, 4), font, brush, left + hg_temp1 * 1, top + sg * 10 - 2);//11
            e.Graphics.DrawString(zd[32].Substring(8, 4), font, brush, left + hg_temp1 * 1, top + sg * 11 - 6);//12
            e.Graphics.DrawString(zd[33].Substring(0, 4), font, brush, left + hg_temp1 * 2, top + sg * 9 + 2);//10
            e.Graphics.DrawString(zd[33].Substring(4, 3), font, brush, left + hg_temp1 * 2, top + sg * 10 - 2);//11
            e.Graphics.DrawString(zd[33].Substring(7, 4), font, brush, left + hg_temp1 * 2, top + sg * 11 - 6);//12
            e.Graphics.DrawString(zd[34].Substring(0, 4), font, brush, left + hg_temp1 * 3, top + sg * 9 + 2);//10
            e.Graphics.DrawString(zd[34].Substring(4, 5), font, brush, left + hg_temp1 * 3, top + sg * 10 - 2);//11
            e.Graphics.DrawString(zd[34].Substring(9, 4), font, brush, left + hg_temp1 * 3, top + sg * 11 - 6);//12
            e.Graphics.DrawString(zd[35].Substring(0, 4), font, brush, left + hg_temp1 * 4, top + sg * 9 + 2);//10
            e.Graphics.DrawString(zd[35].Substring(4, 5), font, brush, left + hg_temp1 * 4, top + sg * 10 - 2);//11
            e.Graphics.DrawString(zd[35].Substring(9, 4), font, brush, left + hg_temp1 * 4, top + sg * 11 - 6);//12

            e.Graphics.DrawString(zd[36].Substring(0, 4), font_jc, brush_ts, left + hg_temp1 * 5, top + sg * 8 + 10 + 2);//9
            e.Graphics.DrawString(zd[36].Substring(4, 4), font_jc, brush_ts, left + hg_temp1 * 5, top + sg * 9 + 10 - 2);//10
            e.Graphics.DrawString(zd[36].Substring(8, 4), font_jc, brush_ts, left + hg_temp1 * 5, top + sg * 10 + 10 - 6);//11
            e.Graphics.DrawString(zd[37].Substring(0, 4), font, brush, left + hg_temp1 * 6, top + sg * 8 + 10 + 2);//9
            e.Graphics.DrawString(zd[37].Substring(4, 4), font, brush, left + hg_temp1 * 6, top + sg * 9 + 10 - 2);//10
            e.Graphics.DrawString(zd[37].Substring(8, 4), font, brush, left + hg_temp1 * 6, top + sg * 10 + 10 - 6);//11
            e.Graphics.DrawString(zd[38].Substring(0, 4), font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 8 + 10 + 2);//9
            e.Graphics.DrawString(zd[38].Substring(4, 4), font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 9 + 10 - 2);//10
            e.Graphics.DrawString(zd[38].Substring(8, 2), font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 10 + 10 - 6);//11

            //line9
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 12 - 6), new Point(left + line_h + hg_temp1 * 8, top + sg * 12 - 6));

            e.Graphics.DrawString(zd[39], font, brush, left, top + sg * 12);//13
            e.Graphics.DrawString(zd[40], font, brush, left + hg_temp1 * 1, top + sg * 12);//13
            e.Graphics.DrawString(zd[41], font, brush, left + hg_temp1 * 2, top + sg * 12);//13
            e.Graphics.DrawString(zd[42], font, brush, left + hg_temp1 * 3, top + sg * 12);//13
            e.Graphics.DrawString(zd[43], font, brush, left + hg_temp1 * 4, top + sg * 12);//13
            e.Graphics.DrawString(zd[44], font_jc, brush_ts, left + hg_temp1 * 5, top + sg * 12);//13
            e.Graphics.DrawString(zd[45], font, brush, left + hg_temp1 * 6, top + sg * 12);//13
            e.Graphics.DrawString(zd[46], font_jc, brush_ts, left + hg_temp1 * 7, top + sg * 12);//13

            //line10,11
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 13 - 4), new Point(left + line_h + hg_temp1 * 8, top + sg * 13 - 4));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 13), new Point(left + line_h + hg_temp1 * 8, top + sg * 13));


            e.Graphics.DrawString(zd[47].Substring(0, 4), font_jc, brush_ts, left, top + sg * 13 + 2);//14
            e.Graphics.DrawString(zd[47].Substring(4, 2), font_jc, brush_ts, left, top + sg * 14 - 2);//15
            e.Graphics.DrawString(zd[48], font_jc, brush_ts, left + hg_temp1 * 1, top + sg * 13 + 10);//14.5
            e.Graphics.DrawString(zd[49].Substring(0, 4), font_jc, brush_ts, left + hg_temp1 * 4, top + sg * 13 + 2);//14
            e.Graphics.DrawString(zd[49].Substring(4, 4), font_jc, brush_ts, left + hg_temp1 * 4, top + sg * 14 - 2);//15
            e.Graphics.DrawString(zd[50], font_jc, brush_ts, left + hg_temp1 * 5, top + sg * 13 + 10);//14.5

            //line12
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 15 - 3), new Point(left + line_h + hg_temp1 * 8, top + sg * 15 - 3));

            e.Graphics.DrawString(zd[51], font, brush, left, top + sg * 15);//16

            e.Graphics.DrawString(zd[52], font, brush, left, top + sg * 16);//17
            e.Graphics.DrawString(zd[53], font, brush, left + 320, top + sg * 16);//17
            e.Graphics.DrawString(zd[54], font, brush, left + 470, top + sg * 16);//17
            e.Graphics.DrawString(zd[55], font, brush, left + 580, top + sg * 16);//17
            if (zd[52].Contains("大名"))
            {
                e.Graphics.DrawString("医保中心审核人（签字）：", font, brush, left, top + sg * 17);//18
            }
            //line_sx
            #region
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h, top + sg * 15 - 3));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 1, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 1, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 1, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 1, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 1, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 1, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 1, top + sg * 9 - 2), new Point(left + line_h + hg_temp1 * 1, top + sg * 13 - 4));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 1, top + sg * 13), new Point(left + line_h + hg_temp1 * 1, top + sg * 15 - 3));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 2, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 2, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 2, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 2, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 2, top + sg * 9 - 2), new Point(left + line_h + hg_temp1 * 2, top + sg * 13 - 4));


            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 3, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 3, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 3, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 3, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 3, top + sg * 9 - 2), new Point(left + line_h + hg_temp1 * 3, top + sg * 13 - 4));


            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 4, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 4, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 4, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 4, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 4, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 4, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 4, top + sg * 9 - 2), new Point(left + line_h + hg_temp1 * 4, top + sg * 13 - 4));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 4, top + sg * 13), new Point(left + line_h + hg_temp1 * 4, top + sg * 15 - 3));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 5, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 5, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 5, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 5, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 5, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 5, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 5, top + sg * 8 - 2), new Point(left + line_h + hg_temp1 * 5, top + sg * 13 - 4));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 5, top + sg * 13), new Point(left + line_h + hg_temp1 * 5, top + sg * 15 - 3));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 6, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 6, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 6, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 6, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 6, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 6, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 6, top + sg * 8 - 2), new Point(left + line_h + hg_temp1 * 6, top + sg * 13 - 4));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 7, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 7, top + sg * 4 - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 7, top + sg * 4 + 1), new Point(left + line_h + hg_temp1 * 7, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 7, top + sg * 6 - 2), new Point(left + line_h + hg_temp1 * 7, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 * 7, top + sg * 8 - 2), new Point(left + line_h + hg_temp1 * 7, top + sg * 13 - 4));

            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h + hg_temp1 * 8, top + sg * 3 - 3), new Point(left + line_h + hg_temp1 * 8, top + sg * 15 - 3));
            #endregion
            #endregion
        }
        private void mzcxhz(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|广平中医院城乡居民门诊报销汇总情况|开始时间：2017-12-12 00:00:00|结束时间：2017-12-12 23:59:59|报销员|发票总费用|现金支付|报销总费用|基本统筹|大病支付|贫困救助|贫困救助|打印时间：2017-12-12 16:59:59|打印人：李宁";
                in_zfc_fy += "|李白|100000000.00|160000.00|170000.00|180000.00|190000.00|200000.00|200000.00";
                in_zfc_fy += "|李白|2000000.00|260000.00|270000.00|280000.00|290000.00|300000.00|200000.00";
                in_zfc_fy += "|李白|3000000.00|360000.00|370000.00|380000.00|390000.00|400000.00|200000.00";
                in_zfc_fy += "|李白|4000000.00|460000.00|470000.00|480000.00|490000.00|500000.00|200000.00";
                hs_fy = 4;
            }
            #endregion

            int sg = 20;
            int hg_temp1 = 80;
            int hg_temp = 100;
            int line_h = -5;
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Font font_bt = new Font("宋体", 15, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font_bt, brush, left + (hg_temp1 + 7 * hg_temp - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 5);

            e.Graphics.DrawString(zd[2], font, brush, left, top + sg * 1);
            e.Graphics.DrawString(zd[3], font, brush, left + 350, top + sg * 1);

            //line1
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 7 * hg_temp, top + sg * 2 - 3));

            e.Graphics.DrawString(zd[4], font, brush, left, top + sg * 2);
            e.Graphics.DrawString(zd[5], font, brush, left + hg_temp1, top + sg * 2);
            e.Graphics.DrawString(zd[6], font, brush, left + hg_temp1 + 1 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[7], font, brush, left + hg_temp1 + 2 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[8], font, brush, left + hg_temp1 + 3 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[9], font, brush, left + hg_temp1 + 4 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[10], font, brush, left + hg_temp1 + 5 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[11], font, brush, left + hg_temp1 + 6 * hg_temp, top + sg * 2);
            //line2
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * (3 + hs_fy) - 3), new Point(left + line_h + hg_temp1 + 7 * hg_temp, top + sg * (3 + hs_fy) - 3));

            e.Graphics.DrawString(zd[12], font, brush, left, top + sg * (3 + hs_fy));
            e.Graphics.DrawString(zd[13], font, brush, left + 350, top + sg * (3 + hs_fy));
            //*********************************************************************************************************
            string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < hs_fy; i++)
            {
                //line
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * (3 + i) - 3), new Point(left + line_h + hg_temp1 + 7 * hg_temp, top + sg * (3 + i) - 3));

                e.Graphics.DrawString(zd_fy[1 + i * 8], font, brush, left, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[2 + i * 8], font, brush, left + hg_temp1, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[3 + i * 8], font, brush, left + hg_temp1 + 1 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[4 + i * 8], font, brush, left + hg_temp1 + 2 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[5 + i * 8], font, brush, left + hg_temp1 + 3 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[6 + i * 8], font, brush, left + hg_temp1 + 4 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[7 + i * 8], font, brush, left + hg_temp1 + 5 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[8 + i * 8], font, brush, left + hg_temp1 + 6 * hg_temp, top + sg * (3 + i));
            }
            //*********************************************************************************************************

            //line_sx
            #region
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 2 - 3), new Point(left + line_h, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1, top + sg * 2 - 3), new Point(left + line_h + hg_temp1, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 1 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 1 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 2 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 2 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 3 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 3 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 4 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 4 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 6 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 6 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 7 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 7 * hg_temp, top + sg * (3 + hs_fy) - 3));
            #endregion
            #endregion
        }

        private void zyzf(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|广平中医院|二级甲等|检验科|201701|171234|2017|10|12|2017|11|15|50|王宁|男||";
                in_zfc += "|床位费|100|自费|护理费|200|自费|诊查费|300|自费|卫生材料费|400|自费|检查费|500|自费|药品费|600|自费";
                in_zfc += "|化验费|700|自费|药事服务费|800|自费|治疗费|900|自费|一般诊疗费|1000|自费|手术费|1100|自费|其他住院费用|1200|自费|输血费|1300|自费";
                in_zfc += "|壹仟零伍拾|1050|1.00|2.00|3.00|李白|2017|07|29";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int hg_temp = 325;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 212, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 310, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 460, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 35, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 160, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[7], font, brush, left + 210, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 243, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[9], font, brush, left + 283, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[10], font, brush, left + 330, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[11], font, brush, left + 370, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[12], font, brush, left + 470, top + sg * 1 - 1);//

            e.Graphics.DrawString(zd[13], font, brush, left + 25, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[14], font, brush, left + 140, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[15], font, brush, left + 265, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[16], font, brush, left + 473, top + sg * 2 - 6);//

            //*********************************************************************************************************

            e.Graphics.DrawString(zd[17], font, brush, left + 0, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[18], font, brush, left + 200, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[19], font, brush, left + 265, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[20], font, brush, left + 0 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[21], font, brush, left + 200 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[22], font, brush, left + 265 + hg_temp, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[24], font, brush, left + 200, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[25], font, brush, left + 265, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[26], font, brush, left + 0 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[27], font, brush, left + 200 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[28], font, brush, left + 265 + hg_temp, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[29], font, brush, left + 0, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[30], font, brush, left + 200, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[31], font, brush, left + 265, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[32], font, brush, left + 0 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[33], font, brush, left + 200 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[34], font, brush, left + 265 + hg_temp, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[35], font, brush, left + 0, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[36], font, brush, left + 200, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[37], font, brush, left + 265, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[38], font, brush, left + 0 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[39], font, brush, left + 200 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[40], font, brush, left + 265 + hg_temp, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[41], font, brush, left + 0, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[42], font, brush, left + 200, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[43], font, brush, left + 265, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[44], font, brush, left + 0 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[45], font, brush, left + 200 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[46], font, brush, left + 265 + hg_temp, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[47], font, brush, left + 0, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[48], font, brush, left + 200, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[49], font, brush, left + 265, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[50], font, brush, left + 0 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[51], font, brush, left + 200 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[52], font, brush, left + 265 + hg_temp, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[53], font, brush, left + 0 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[54], font, brush, left + 200 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[55], font, brush, left + 265 + hg_temp, top + sg * 9 + 3);//

            ////*********************************************************************************************************

            e.Graphics.DrawString(zd[56], font, brush, left + 60, top + sg * 10 + 2);//
            e.Graphics.DrawString(zd[57], font, brush, left + 340, top + sg * 10 + 2);//

            e.Graphics.DrawString(zd[58], font, brush, left + 50, top + sg * 11);//
            e.Graphics.DrawString(zd[59], font, brush, left + 207, top + sg * 11);//
            e.Graphics.DrawString(zd[60], font, brush, left + 360, top + sg * 11);//

            e.Graphics.DrawString(zd[61], font, brush, left + 322, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[62], font, brush, left + 514, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[63], font, brush, left + 566, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[64], font, brush, left + 606, top + sg * 16 - 10);//

            #endregion
        }
        private void zyyb(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|井陉县中医院|其他诊疗机构|外一科|90001|20000002|2020|01|07|2020|01|02|0|冯雪峰|男|井陉县职工-在职|20191209|床位费|0.00|医保|护理费|0.00|医保|诊查费|0.00|医保|卫生材料费|0.00|医保|检查费|0.00|医保|药品费|78.00|医保|化验费|0.00|医保|药事服务费|0.00|医保|治疗费|0.00|医保|一般诊疗费|0.00|医保|手术费|0.00|医保|其他住院费用|0.00|医保|输血费|0.00|医保|柒拾捌元整|78.00元|0.00|78.00|0.00|0.0000|0.0000|78.0000|0.0000|0.0000|857.0000|0.0000|补助统筹累计:0.0000|大病统筹累计:0.0000|基本统筹支付:0.0000|补助统筹支付:0.0000|大病统筹支付:0.0000||基本提高支付:0.0000|大病提高支付:0.0000|医疗救助支付:0.0000|医疗救助补充支付:0.0000|收款单位|许紫薇|2020|01|02|普通|石家庄市医保(WH02)";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int hg_temp = 325;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 212, top + sg * 0);
            e.Graphics.DrawString(zd[45], font, brush, left + 350, top + sg * 0 - 20);
            e.Graphics.DrawString(zd[3], font, brush, left + 350, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 460, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 35, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 160, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[7], font, brush, left + 210, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 243, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[9], font, brush, left + 283, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[10], font, brush, left + 330, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[11], font, brush, left + 370, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[12], font, brush, left + 470, top + sg * 1 - 1);//

            e.Graphics.DrawString(zd[13], font, brush, left + 25, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[14], font, brush, left + 140, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[15], font, brush, left + 265, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[16], font, brush, left + 473, top + sg * 2 - 6);//

            //*********************************************************************************************************

            //e.Graphics.DrawString(zd[17], font, brush, left + 0, top + sg * 3 + 7);//
            //e.Graphics.DrawString(zd[18], font, brush, left + 200, top + sg * 3 + 7);//
            //e.Graphics.DrawString(zd[19], font, brush, left + 265, top + sg * 3 + 7);//

            //e.Graphics.DrawString(zd[20], font, brush, left + 0 + hg_temp, top + sg * 3 + 7);//
            //e.Graphics.DrawString(zd[21], font, brush, left + 200 + hg_temp, top + sg * 3 + 7);//
            //e.Graphics.DrawString(zd[22], font, brush, left + 265 + hg_temp, top + sg * 3 + 7);//

            //e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 4 + 4);//
            //e.Graphics.DrawString(zd[24], font, brush, left + 200, top + sg * 4 + 4);//
            //e.Graphics.DrawString(zd[25], font, brush, left + 265, top + sg * 4 + 4);//

            //e.Graphics.DrawString(zd[26], font, brush, left + 0 + hg_temp, top + sg * 4 + 4);//
            //e.Graphics.DrawString(zd[27], font, brush, left + 200 + hg_temp, top + sg * 4 + 4);//
            //e.Graphics.DrawString(zd[28], font, brush, left + 265 + hg_temp, top + sg * 4 + 4);//

            //e.Graphics.DrawString(zd[29], font, brush, left + 0, top + sg * 5 + 2);//
            //e.Graphics.DrawString(zd[30], font, brush, left + 200, top + sg * 5 + 2);//
            //e.Graphics.DrawString(zd[31], font, brush, left + 265, top + sg * 5 + 2);//

            //e.Graphics.DrawString(zd[32], font, brush, left + 0 + hg_temp, top + sg * 5 + 2);//
            //e.Graphics.DrawString(zd[33], font, brush, left + 200 + hg_temp, top + sg * 5 + 2);//
            //e.Graphics.DrawString(zd[34], font, brush, left + 265 + hg_temp, top + sg * 5 + 2);//

            //e.Graphics.DrawString(zd[35], font, brush, left + 0, top + sg * 6 + 3);//
            //e.Graphics.DrawString(zd[36], font, brush, left + 200, top + sg * 6 + 3);//
            //e.Graphics.DrawString(zd[37], font, brush, left + 265, top + sg * 6 + 3);//

            //e.Graphics.DrawString(zd[38], font, brush, left + 0 + hg_temp, top + sg * 6 + 3);//
            //e.Graphics.DrawString(zd[39], font, brush, left + 200 + hg_temp, top + sg * 6 + 3);//
            //e.Graphics.DrawString(zd[40], font, brush, left + 265 + hg_temp, top + sg * 6 + 3);//

            //e.Graphics.DrawString(zd[41], font, brush, left + 0, top + sg * 7 + 3);//
            //e.Graphics.DrawString(zd[42], font, brush, left + 200, top + sg * 7 + 3);//
            //e.Graphics.DrawString(zd[43], font, brush, left + 265, top + sg * 7 + 3);//

            //e.Graphics.DrawString(zd[44], font, brush, left + 0 + hg_temp, top + sg * 7 + 3);//
            //e.Graphics.DrawString(zd[45], font, brush, left + 200 + hg_temp, top + sg * 7 + 3);//
            //e.Graphics.DrawString(zd[46], font, brush, left + 265 + hg_temp, top + sg * 7 + 3);//

            //e.Graphics.DrawString(zd[47], font, brush, left + 0, top + sg * 8 + 3);//
            //e.Graphics.DrawString(zd[48], font, brush, left + 200, top + sg * 8 + 3);//
            //e.Graphics.DrawString(zd[49], font, brush, left + 265, top + sg * 8 + 3);//

            //e.Graphics.DrawString(zd[50], font, brush, left + 0 + hg_temp, top + sg * 8 + 3);//
            //e.Graphics.DrawString(zd[51], font, brush, left + 200 + hg_temp, top + sg * 8 + 3);//
            //e.Graphics.DrawString(zd[52], font, brush, left + 265 + hg_temp, top + sg * 8 + 3);//

            //e.Graphics.DrawString(zd[53], font, brush, left + 0 + hg_temp, top + sg * 9 + 3);//
            //e.Graphics.DrawString(zd[54], font, brush, left + 200 + hg_temp, top + sg * 9 + 3);//
            //e.Graphics.DrawString(zd[55], font, brush, left + 265 + hg_temp, top + sg * 9 + 3);//

            string[] zfc_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < ((zfc_fy.Length - 1) / 3); i++)
            {
                if (i % 2 == 0)
                {
                    e.Graphics.DrawString(zfc_fy[0 + i * 3], font, brush, left + 0, top + sg * (3 + (i / 2)) + 7);//
                    e.Graphics.DrawString(zfc_fy[1 + i * 3], font, brush, left + 200, top + sg * (3 + (i / 2)) + 7);//
                    e.Graphics.DrawString(zfc_fy[2 + i * 3], font, brush, left + 265, top + sg * (3 + (i / 2)) + 7);//
                }
                else
                {
                    e.Graphics.DrawString(zfc_fy[0 + i * 3], font, brush, left + 0 + hg_temp, top + sg * (3 + (i / 2)) + 7);//
                    e.Graphics.DrawString(zfc_fy[1 + i * 3], font, brush, left + 200 + hg_temp, top + sg * (3 + (i / 2)) + 7);//
                    e.Graphics.DrawString(zfc_fy[2 + i * 3], font, brush, left + 265 + hg_temp, top + sg * (3 + (i / 2)) + 7);//
                }
            }

                ////*********************************************************************************************************

                //e.Graphics.DrawString(zd[56], font, brush, left + 60, top + sg * 10 + 2);//
                //e.Graphics.DrawString(zd[57], font, brush, left + 340, top + sg * 10 + 2);//

                //e.Graphics.DrawString(zd[58], font, brush, left + 50, top + sg * 11);//
                //e.Graphics.DrawString(zd[59], font, brush, left + 207, top + sg * 11);//
                //e.Graphics.DrawString(zd[60], font, brush, left + 360, top + sg * 11);//
                //e.Graphics.DrawString(zd[61], font, brush, left + 515, top + sg * 11);//

                //e.Graphics.DrawString(zd[62], font, brush, left + 75, top + sg * 12 - 2);//
                //e.Graphics.DrawString(zd[63], font, brush, left + 230, top + sg * 12 - 2);//
                //e.Graphics.DrawString(zd[64], font, brush, left + 360, top + sg * 12 - 2);//
                //e.Graphics.DrawString(zd[65], font, brush, left + 515, top + sg * 12 - 2);//

                //e.Graphics.DrawString(zd[66], font, brush, left + 75, top + sg * 13 - 4);//
                //e.Graphics.DrawString(zd[67], font, brush, left + 230, top + sg * 13 - 4);//
                //e.Graphics.DrawString(zd[68], font, brush, left + 295, top + sg * 13 - 4);//
                //e.Graphics.DrawString(zd[69], font, brush, left + 470, top + sg * 13 - 4);//

                //e.Graphics.DrawString(zd[70], font, brush, left + 0, top + sg * 14 - 7);//
                //e.Graphics.DrawString(zd[71], font, brush, left + 180, top + sg * 14 - 7);//
                //e.Graphics.DrawString(zd[72], font, brush, left + 335, top + sg * 14 - 7);//

                //e.Graphics.DrawString(zd[73], font, brush, left + 500, top + sg * 14 - 7);//
                //e.Graphics.DrawString(zd[74], font, brush, left + 0, top + sg * 15 - 10);//
                //e.Graphics.DrawString(zd[75], font, brush, left + 180, top + sg * 15 - 10);//
                //e.Graphics.DrawString(zd[76], font, brush, left + 335, top + sg * 15 - 10);//
                //e.Graphics.DrawString(zd[77], font, brush, left + 500, top + sg * 15 - 10);//


                //e.Graphics.DrawString(zd[78], font, brush, left + 0, top + sg * 16 - 10);//
                //e.Graphics.DrawString(zd[79], font, brush, left + 322, top + sg * 16 - 10);//
                //e.Graphics.DrawString(zd[80], font, brush, left + 432, top + sg * 16 - 10);//
                //e.Graphics.DrawString(zd[81], font, brush, left + 482, top + sg * 16 - 10);//
                //e.Graphics.DrawString(zd[82], font, brush, left + 520, top + sg * 16 - 10);//
                //try
                //{
                //    if (!string.IsNullOrEmpty(zd[83]))
                //    {
                //        e.Graphics.DrawString(zd[83], font, brush, left + 500, top + sg * 0 - 30);
                //    }
                //}
                //catch
                //{ }
            e.Graphics.DrawString(zd[17], font, brush, left + 60, top + sg * 10 + 2);//
            e.Graphics.DrawString(zd[18], font, brush, left + 340, top + sg * 10 + 2);//

            e.Graphics.DrawString(zd[19], font, brush, left + 50, top + sg * 11);//
            e.Graphics.DrawString(zd[20], font, brush, left + 207, top + sg * 11);//
            e.Graphics.DrawString(zd[21], font, brush, left + 360, top + sg * 11);//
            e.Graphics.DrawString(zd[22], font, brush, left + 515, top + sg * 11);//

            e.Graphics.DrawString(zd[23], font, brush, left + 75, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[24], font, brush, left + 230, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[25], font, brush, left + 360, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[26], font, brush, left + 515, top + sg * 12 - 2);//

            e.Graphics.DrawString(zd[27], font, brush, left + 75, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[28], font, brush, left + 230, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[29], font, brush, left + 295, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[30], font, brush, left + 470, top + sg * 13 - 4);//

            e.Graphics.DrawString(zd[31], font, brush, left + 0, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[32], font, brush, left + 180, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[33], font, brush, left + 335, top + sg * 14 - 7);//

            e.Graphics.DrawString(zd[34], font, brush, left + 500, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[35], font, brush, left + 0, top + sg * 15 - 10);//
            e.Graphics.DrawString(zd[36], font, brush, left + 180, top + sg * 15 - 10);//
            e.Graphics.DrawString(zd[37], font, brush, left + 335, top + sg * 15 - 10);//
            e.Graphics.DrawString(zd[38], font, brush, left + 500, top + sg * 15 - 10);//


            e.Graphics.DrawString(zd[39], font, brush, left + 0, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[40], font, brush, left + 322, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[41], font, brush, left + 432, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[42], font, brush, left + 482, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[43], font, brush, left + 520, top + sg * 16 - 10);//
            try
            {
                if (!string.IsNullOrEmpty(zd[44]))
                {
                    e.Graphics.DrawString(zd[44], font, brush, left + 500, top + sg * 0 - 30);
                }
            }
            catch
            { }
            #endregion
        }
        private void zysyyb(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|广平中医院|二级甲等|检验科|201701|171234|2017|10|12|2017|11|15|50|王宁|男|医保职工基本医疗保险|130427199201";
                in_zfc += "|床位费|100|医保|护理费|200|医保|诊查费|300|医保|卫生材料费|400|医保|检查费|500|医保|药品费|600|医保";
                in_zfc += "|化验费|700|医保|药事服务费|800|医保|治疗费|900|医保|一般诊疗费|1000|医保|手术费|1100|医保|其他住院费用|1200|医保|输血费|1300|医保";
                in_zfc += "|壹仟零伍拾|1050|1.00|2.00|3.00|4.00|5.00|6.00|7.00|8.00|9.00|10.00|生育医疗费定额补偿金额:11.00|个人现金支付:1200.00|医保中心名称:邯郸市邯山区医保中心|李白|2017|07|29";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int hg_temp = 325;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 212, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 310, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 460, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 35, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 160, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[7], font, brush, left + 210, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 243, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[9], font, brush, left + 283, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[10], font, brush, left + 330, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[11], font, brush, left + 370, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[12], font, brush, left + 470, top + sg * 1 - 1);//

            e.Graphics.DrawString(zd[13], font, brush, left + 25, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[14], font, brush, left + 140, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[15], font, brush, left + 265, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[16], font, brush, left + 473, top + sg * 2 - 6);//

            //*********************************************************************************************************

            e.Graphics.DrawString(zd[17], font, brush, left + 0, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[18], font, brush, left + 200, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[19], font, brush, left + 265, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[20], font, brush, left + 0 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[21], font, brush, left + 200 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[22], font, brush, left + 265 + hg_temp, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[24], font, brush, left + 200, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[25], font, brush, left + 265, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[26], font, brush, left + 0 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[27], font, brush, left + 200 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[28], font, brush, left + 265 + hg_temp, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[29], font, brush, left + 0, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[30], font, brush, left + 200, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[31], font, brush, left + 265, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[32], font, brush, left + 0 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[33], font, brush, left + 200 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[34], font, brush, left + 265 + hg_temp, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[35], font, brush, left + 0, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[36], font, brush, left + 200, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[37], font, brush, left + 265, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[38], font, brush, left + 0 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[39], font, brush, left + 200 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[40], font, brush, left + 265 + hg_temp, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[41], font, brush, left + 0, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[42], font, brush, left + 200, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[43], font, brush, left + 265, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[44], font, brush, left + 0 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[45], font, brush, left + 200 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[46], font, brush, left + 265 + hg_temp, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[47], font, brush, left + 0, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[48], font, brush, left + 200, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[49], font, brush, left + 265, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[50], font, brush, left + 0 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[51], font, brush, left + 200 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[52], font, brush, left + 265 + hg_temp, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[53], font, brush, left + 0 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[54], font, brush, left + 200 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[55], font, brush, left + 265 + hg_temp, top + sg * 9 + 3);//

            ////*********************************************************************************************************

            e.Graphics.DrawString(zd[56], font, brush, left + 60, top + sg * 10 + 2);//
            e.Graphics.DrawString(zd[57], font, brush, left + 340, top + sg * 10 + 2);//

            e.Graphics.DrawString(zd[58], font, brush, left + 50, top + sg * 11);//
            e.Graphics.DrawString(zd[59], font, brush, left + 207, top + sg * 11);//
            e.Graphics.DrawString(zd[60], font, brush, left + 360, top + sg * 11);//
            e.Graphics.DrawString(zd[61], font, brush, left + 515, top + sg * 11);//

            e.Graphics.DrawString(zd[62], font, brush, left + 75, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[63], font, brush, left + 230, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[64], font, brush, left + 360, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[65], font, brush, left + 515, top + sg * 12 - 2);//

            e.Graphics.DrawString(zd[66], font, brush, left + 75, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[67], font, brush, left + 230, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[68], font, brush, left + 295, top + sg * 13 - 4);//

            e.Graphics.DrawString(zd[69], font, brush, left + 0, top + sg * 14 - 7);//

            e.Graphics.DrawString(zd[70], font, brush, left + 0, top + sg * 15 - 10);//

            e.Graphics.DrawString(zd[71], font, brush, left + 322, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[72], font, brush, left + 514, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[73], font, brush, left + 566, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[74], font, brush, left + 606, top + sg * 16 - 10);//

            #endregion
        }
        private void zycx(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|广平中医院|二级甲等|检验科|201701|171234|2017|10|12|2017|11|15|50|王宁|男|城乡居民|130427199201";
                in_zfc += "|床位费|100|城乡|护理费|200|城乡|诊查费|300|城乡|卫生材料费|400|城乡|检查费|500|城乡|药品费|600|城乡";
                in_zfc += "|化验费|700|城乡|药事服务费|800|城乡|治疗费|900|城乡|一般诊疗费|1000|城乡|手术费|1100|城乡|其他住院费用|1200|城乡|输血费|1300|城乡";
                in_zfc += "|壹仟零伍拾|1050|1.00|2.00|3.00|4.00|5.00|6.00|7.00|8.00|9.00|10.00|标准床费:11.00|起付线:1200.00|本次符合基本医疗费用:1300.00|住院次数:14|进入大病金额:1500.00|大病支付金额:1600|本年大病累计支付:1700|个人现金支付:1700|医保中心名称:邯郸市邯山区医保中心|李白|参保人签字:|2017|07|29";
                hs_fy = 12;
            }
            #endregion

            int sg = 20;
            int hg_temp = 325;

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font1 = new Font("宋体", 9, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font, brush, left + 50, top + sg * 0);
            e.Graphics.DrawString(zd[2], font, brush, left + 212, top + sg * 0);
            e.Graphics.DrawString(zd[3], font, brush, left + 310, top + sg * 0);
            e.Graphics.DrawString(zd[4], font, brush, left + 460, top + sg * 0);

            e.Graphics.DrawString(zd[5], font, brush, left + 35, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[6], font, brush, left + 160, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[7], font, brush, left + 210, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[8], font, brush, left + 243, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[9], font, brush, left + 283, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[10], font, brush, left + 330, top + sg * 1 - 1);
            e.Graphics.DrawString(zd[11], font, brush, left + 370, top + sg * 1 - 1);//
            e.Graphics.DrawString(zd[12], font, brush, left + 470, top + sg * 1 - 1);//

            e.Graphics.DrawString(zd[13], font, brush, left + 25, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[14], font, brush, left + 140, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[15], font, brush, left + 265, top + sg * 2 - 6);//
            e.Graphics.DrawString(zd[16], font, brush, left + 473, top + sg * 2 - 6);//

            //*********************************************************************************************************

            e.Graphics.DrawString(zd[17], font, brush, left + 0, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[18], font, brush, left + 200, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[19], font, brush, left + 265, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[20], font, brush, left + 0 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[21], font, brush, left + 200 + hg_temp, top + sg * 3 + 7);//
            e.Graphics.DrawString(zd[22], font, brush, left + 265 + hg_temp, top + sg * 3 + 7);//

            e.Graphics.DrawString(zd[23], font, brush, left + 0, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[24], font, brush, left + 200, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[25], font, brush, left + 265, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[26], font, brush, left + 0 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[27], font, brush, left + 200 + hg_temp, top + sg * 4 + 4);//
            e.Graphics.DrawString(zd[28], font, brush, left + 265 + hg_temp, top + sg * 4 + 4);//

            e.Graphics.DrawString(zd[29], font, brush, left + 0, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[30], font, brush, left + 200, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[31], font, brush, left + 265, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[32], font, brush, left + 0 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[33], font, brush, left + 200 + hg_temp, top + sg * 5 + 2);//
            e.Graphics.DrawString(zd[34], font, brush, left + 265 + hg_temp, top + sg * 5 + 2);//

            e.Graphics.DrawString(zd[35], font, brush, left + 0, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[36], font, brush, left + 200, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[37], font, brush, left + 265, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[38], font, brush, left + 0 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[39], font, brush, left + 200 + hg_temp, top + sg * 6 + 3);//
            e.Graphics.DrawString(zd[40], font, brush, left + 265 + hg_temp, top + sg * 6 + 3);//

            e.Graphics.DrawString(zd[41], font, brush, left + 0, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[42], font, brush, left + 200, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[43], font, brush, left + 265, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[44], font, brush, left + 0 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[45], font, brush, left + 200 + hg_temp, top + sg * 7 + 3);//
            e.Graphics.DrawString(zd[46], font, brush, left + 265 + hg_temp, top + sg * 7 + 3);//

            e.Graphics.DrawString(zd[47], font, brush, left + 0, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[48], font, brush, left + 200, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[49], font, brush, left + 265, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[50], font, brush, left + 0 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[51], font, brush, left + 200 + hg_temp, top + sg * 8 + 3);//
            e.Graphics.DrawString(zd[52], font, brush, left + 265 + hg_temp, top + sg * 8 + 3);//

            e.Graphics.DrawString(zd[53], font, brush, left + 0 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[54], font, brush, left + 200 + hg_temp, top + sg * 9 + 3);//
            e.Graphics.DrawString(zd[55], font, brush, left + 265 + hg_temp, top + sg * 9 + 3);//

            ////*********************************************************************************************************

            e.Graphics.DrawString(zd[56], font, brush, left + 60, top + sg * 10 + 2);//
            e.Graphics.DrawString(zd[57], font, brush, left + 340, top + sg * 10 + 2);//

            e.Graphics.DrawString(zd[58], font, brush, left + 50, top + sg * 11);//
            e.Graphics.DrawString(zd[59], font, brush, left + 207, top + sg * 11);//
            e.Graphics.DrawString(zd[60], font, brush, left + 360, top + sg * 11);//
            e.Graphics.DrawString(zd[61], font, brush, left + 515, top + sg * 11);//

            e.Graphics.DrawString(zd[62], font, brush, left + 75, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[63], font, brush, left + 230, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[64], font, brush, left + 360, top + sg * 12 - 2);//
            e.Graphics.DrawString(zd[65], font, brush, left + 515, top + sg * 12 - 2);//

            e.Graphics.DrawString(zd[66], font, brush, left + 75, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[67], font, brush, left + 230, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[68], font, brush, left + 305, top + sg * 13 - 4);//
            e.Graphics.DrawString(zd[69], font, brush, left + 470, top + sg * 13 - 4);//

            e.Graphics.DrawString(zd[70], font, brush, left - 5, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[71], font, brush, left + 220, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[72], font, brush, left + 320, top + sg * 14 - 7);//
            e.Graphics.DrawString(zd[73], font, brush, left + 490, top + sg * 14 - 7);//

            e.Graphics.DrawString(zd[74], font, brush, left - 5, top + sg * 15 - 10);//
            e.Graphics.DrawString(zd[75], font, brush, left + 180, top + sg * 15 - 10);//
            e.Graphics.DrawString(zd[76], font, brush, left + 340, top + sg * 15 - 10);//

            e.Graphics.DrawString(zd[77], font, brush, left + 322, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[78], font, brush, left + 370, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[79], font, brush, left + 514, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[80], font, brush, left + 566, top + sg * 16 - 10);//
            e.Graphics.DrawString(zd[81], font, brush, left + 606, top + sg * 16 - 10);//

            try
            {
                if (!string.IsNullOrEmpty(zd[82]))
                {
                    e.Graphics.DrawString(zd[82], font, brush, left + 460, top + sg * 0 - 20);
                }
            }
            catch
            { }
            #endregion
        }
        private void zycxjsd(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc += "|邯郸市城乡居民医疗保险费用结算单（定点医院使用）";
                in_zfc += "|医疗机构:|广平中医院广平中医院广平中医院广平中医院广平中医|医院住院号:2017120201|入院日期:2017-11-02|出院日期:2017-11-10";
                in_zfc += "|个人编号:1304251728|姓名:李宁|住院次数:2|人员类别:城乡居民城乡居民";
                in_zfc += "|甲类费用|100000.00|乙类费用|100000.00|自费费用|100000.00|标准床位费|100000.00";
                in_zfc += "|总费用|100000.00|其中:中草药的汤剂、饮片|100000.00|起付线标准|100000.00|累计起付线|100000.00";
                in_zfc += "|本年历次合规费用|100000.00|本年历次统筹支出|100000.00|本次合规费用|100000.00|本次统筹支付|100000.00";
                in_zfc += "|本年大病历次合规金额|100000.00|本年大病历次支付金额|100000.00|本次大病合规金额|100000.00|本次大病支付金额|100000.00";
                in_zfc += "|本年历次住院医疗救助累计|100000.00|本次住院医疗救助支付|100000.00|本年历次重特大疾病住院医疗救助累计|100000.00|本次重特大疾病住院医疗救助支付|1800";
                in_zfc += "|贫困人口提高待遇部分|100000.00|报销支付合计|100000.00|本次个人现金支付|100000.00";
                in_zfc += "|其中贫困人口提高待遇部分分项";
                in_zfc += "|住院起付线降低提高待遇|100000.00|提高住院报销比例提高待遇|100000.00|大病保险取消起付线提高待遇|100000.00|大病保险提高封顶线提高待遇|100000.00";
                in_zfc += "|备注提示:|医保中心名称:邯郸市大名县医保中心|参保人签字:李宁|经办人:李白|经办日期:2017-11-20";
            }
            #endregion

            int sg = 20;
            int line_h = -3;

            Font font_bt = new Font("宋体", 17, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font font_ts = new Font("宋体", 10, FontStyle.Regular);
            Font font_jc = new Font("宋体", 10, FontStyle.Regular);
            //Font font_jc = new Font("宋体", 10, FontStyle.Bold);
            Pen myPen_bk = new Pen(Color.FromArgb(255, Color.Black), 1.2F);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            Brush brush_ts = Brushes.Red;
            string[] zd = in_zfc.Split('|');

            e.Graphics.DrawString(zd[1], font_bt, brush_ts, left + (730 - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 17);//1

            e.Graphics.DrawString(zd[2], font, brush, left + line_h, top + sg * 1);//2
            if (zd[3].Length > 12)
            {
                e.Graphics.DrawString(zd[3].Substring(0, 12), font_ts, brush, left + 65 + line_h, top + sg * 1 - 8);//1.5
                e.Graphics.DrawString(zd[3].Substring(12, zd[3].Length - 12), font_ts, brush, left + 65 + line_h, top + sg * 1 + 6);//2.5
            }
            else
            {
                e.Graphics.DrawString(zd[3], font, brush, left + 65 + line_h, top + sg * 1);//2
            }
            e.Graphics.DrawString(zd[4], font, brush, left + 240 + line_h, top + sg * 1);//2
            e.Graphics.DrawString(zd[5], font, brush, left + 400 + line_h, top + sg * 1);//2
            e.Graphics.DrawString(zd[6], font, brush, left + 550 + line_h, top + sg * 1);//2

            e.Graphics.DrawString(zd[7], font, brush, left + line_h, top + sg * 2);//3
            e.Graphics.DrawString(zd[8], font, brush, left + 240 + line_h, top + sg * 2);//3
            e.Graphics.DrawString(zd[9], font, brush, left + 400 + line_h, top + sg * 2);//3
            e.Graphics.DrawString(zd[10], font, brush, left + 550 + line_h, top + sg * 2);//3

            //line1
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h + 730, top + sg * 3 - 3));

            e.Graphics.DrawString(zd[11], font, brush, left, top + sg * 3);//4
            e.Graphics.DrawString(zd[12], font, brush, left + 93, top + sg * 3);//4
            e.Graphics.DrawString(zd[13], font, brush, left + 173, top + sg * 3);//4
            e.Graphics.DrawString(zd[14], font, brush, left + 266, top + sg * 3);//4
            e.Graphics.DrawString(zd[15], font, brush, left + 350, top + sg * 3);//4
            e.Graphics.DrawString(zd[16], font, brush, left + 455, top + sg * 3);//4
            e.Graphics.DrawString(zd[17], font, brush, left + 540, top + sg * 3);//4
            e.Graphics.DrawString(zd[18], font, brush, left + 645, top + sg * 3);//4

            ////line2
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + 730, top + sg * 4 - 3));

            e.Graphics.DrawString(zd[19], font, brush, left, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[20], font, brush, left + 93, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[21].Substring(0, 6), font, brush, left + 173, top + sg * 4 + 3);//5
            e.Graphics.DrawString(zd[21].Substring(6, zd[21].Length - 6), font, brush, left + 173, top + sg * 5 - 2);//6
            e.Graphics.DrawString(zd[22], font, brush, left + 266, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[23], font, brush, left + 350, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[24], font, brush, left + 455, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[25], font, brush, left + 540, top + sg * 4 + 10);//5.5
            e.Graphics.DrawString(zd[26], font, brush, left + 645, top + sg * 4 + 10);//5.5

            //line3,4
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 6 - 6), new Point(left + line_h + 730, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 6 - 2), new Point(left + line_h + 730, top + sg * 6 - 2));

            e.Graphics.DrawString(zd[27].Substring(0, 4), font, brush, left, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[27].Substring(4, zd[27].Length - 4), font, brush, left, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[28], font, brush, left + 93, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[29].Substring(0, 4), font, brush, left + 173, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[29].Substring(4, zd[29].Length - 4), font, brush, left + 173, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[30], font, brush, left + 266, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[31].Substring(0, 4), font, brush, left + 350, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[31].Substring(4, zd[31].Length - 4), font, brush, left + 363, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[32], font, brush, left + 455, top + sg * 6 + 10);//7.5
            e.Graphics.DrawString(zd[33].Substring(0, 4), font_jc, brush_ts, left + 540, top + sg * 6 + 2);//7
            e.Graphics.DrawString(zd[33].Substring(4, zd[33].Length - 4), font_jc, brush_ts, left + 553, top + sg * 7 - 2);//8
            e.Graphics.DrawString(zd[34], font_jc, brush_ts, left + 645, top + sg * 6 + 10);//7.5

            ////line5,6
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 8 - 6), new Point(left + line_h + 730, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 8 - 2), new Point(left + line_h + 730, top + sg * 8 - 2));

            e.Graphics.DrawString(zd[35].Substring(0, 5), font, brush, left, top + sg * 8 + 2);//9
            e.Graphics.DrawString(zd[35].Substring(5, zd[35].Length - 5), font, brush, left, top + sg * 9 - 2);//10
            e.Graphics.DrawString(zd[36], font, brush, left + 93, top + sg * 8 + 10);//9.5
            e.Graphics.DrawString(zd[37].Substring(0, 5), font, brush, left + 173, top + sg * 8 + 2);//9
            e.Graphics.DrawString(zd[37].Substring(5, zd[37].Length - 5), font, brush, left + 173, top + sg * 9 - 2);//10
            e.Graphics.DrawString(zd[38], font, brush, left + 266, top + sg * 8 + 10);//9.5
            e.Graphics.DrawString(zd[39].Substring(0, 4), font, brush, left + 350, top + sg * 8 + 2);//9
            e.Graphics.DrawString(zd[39].Substring(4, zd[39].Length - 4), font, brush, left + 350, top + sg * 9 - 2);//10
            e.Graphics.DrawString(zd[40], font, brush, left + 455, top + sg * 8 + 10);//9.5
            e.Graphics.DrawString(zd[41].Substring(0, 4), font_jc, brush_ts, left + 540, top + sg * 8 + 2);//9
            e.Graphics.DrawString(zd[41].Substring(4, zd[41].Length - 4), font_jc, brush_ts, left + 540, top + sg * 9 - 2);//10
            e.Graphics.DrawString(zd[42], font_jc, brush_ts, left + 645, top + sg * 8 + 10);//9.5

            //line7,8
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 10 - 6), new Point(left + line_h + 730, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 10 - 2), new Point(left + line_h + 730, top + sg * 10 - 2));

            e.Graphics.DrawString(zd[43].Substring(0, 6), font, brush, left, top + sg * 10 + 8);//11
            e.Graphics.DrawString(zd[43].Substring(6, zd[43].Length - 6), font, brush, left, top + sg * 11 + 4);//12
            e.Graphics.DrawString(zd[44], font, brush, left + 93, top + sg * 11 - 2);//12
            e.Graphics.DrawString(zd[45].Substring(0, 6), font_jc, brush_ts, left + 173, top + sg * 10 + 8);//11
            e.Graphics.DrawString(zd[45].Substring(6, zd[45].Length - 6), font_jc, brush_ts, left + 186, top + sg * 11 + 4);//12
            e.Graphics.DrawString(zd[46], font_jc, brush_ts, left + 266, top + sg * 11 - 2);//12
            e.Graphics.DrawString(zd[47].Substring(0, 6), font, brush, left + 350, top + sg * 10 + 2);//10
            e.Graphics.DrawString(zd[47].Substring(6, 6), font, brush, left + 350, top + sg * 11 - 2);//11
            e.Graphics.DrawString(zd[47].Substring(12, zd[47].Length - 12), font, brush, left + 356, top + sg * 12 - 6);//13
            e.Graphics.DrawString(zd[48], font, brush, left + 455, top + sg * 11 - 2);//12
            e.Graphics.DrawString(zd[49].Substring(0, 6), font_jc, brush_ts, left + 540, top + sg * 10 + 2);//10
            e.Graphics.DrawString(zd[49].Substring(6, 6), font_jc, brush_ts, left + 540, top + sg * 11 - 2);//11
            e.Graphics.DrawString(zd[49].Substring(12, zd[49].Length - 12), font_jc, brush_ts, left + 563, top + sg * 12 - 6);//13
            e.Graphics.DrawString(zd[50], font_jc, brush_ts, left + 645, top + sg * 11 - 2);//12

            //line9,10
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 13 - 10), new Point(left + line_h + 730, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 13 - 6), new Point(left + line_h + 730, top + sg * 13 - 6));

            e.Graphics.DrawString(zd[51].Substring(0, 6), font_jc, brush_ts, left, top + sg * 13 - 2);//14
            e.Graphics.DrawString(zd[51].Substring(6, zd[51].Length - 6), font_jc, brush_ts, left + 16, top + sg * 14 - 6);//15
            e.Graphics.DrawString(zd[52], font_jc, brush_ts, left + 93, top + sg * 13 + 8);//14.5
            e.Graphics.DrawString(zd[53], font_jc, brush_ts, left + 350, top + sg * 13 + 8);//14.5
            e.Graphics.DrawString(zd[54], font_jc, brush_ts, left + 455, top + sg * 13 + 8);//14.5
            e.Graphics.DrawString(zd[55].Substring(0, 6), font, brush, left + 540, top + sg * 13 - 2);//14
            e.Graphics.DrawString(zd[55].Substring(6, zd[55].Length - 6), font, brush, left + 566, top + sg * 14 - 6);//15
            e.Graphics.DrawString(zd[56], font, brush, left + 645, top + sg * 13 + 8);//14.5

            //line11
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 15 - 10), new Point(left + line_h + 730, top + sg * 15 - 10));

            e.Graphics.DrawString(zd[57], font, brush, left, top + sg * 15 - 6);//16

            //line12
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 16 - 10), new Point(left + line_h + 730, top + sg * 16 - 10));

            e.Graphics.DrawString(zd[58].Substring(0, 6), font, brush, left, top + sg * 16 - 6);//17
            e.Graphics.DrawString(zd[58].Substring(6, zd[58].Length - 6), font, brush, left + 7, top + sg * 17 - 10);//18
            e.Graphics.DrawString(zd[59], font, brush, left + 93, top + sg * 16 + 4);//17.5
            e.Graphics.DrawString(zd[60].Substring(0, 6), font, brush, left + 173, top + sg * 16 - 6);//17
            e.Graphics.DrawString(zd[60].Substring(6, zd[60].Length - 6), font, brush, left + 173, top + sg * 17 - 10);//18
            e.Graphics.DrawString(zd[61], font, brush, left + 266, top + sg * 16 + 4);//17.5
            e.Graphics.DrawString(zd[62].Substring(0, 6), font, brush, left + 356, top + sg * 16 - 6);//17
            e.Graphics.DrawString(zd[62].Substring(6, zd[62].Length - 6), font, brush, left + 350, top + sg * 17 - 10);//18
            e.Graphics.DrawString(zd[63], font, brush, left + 455, top + sg * 16 + 4);//17.5
            e.Graphics.DrawString(zd[64].Substring(0, 6), font, brush, left + 546, top + sg * 16 - 6);//17
            e.Graphics.DrawString(zd[64].Substring(6, zd[64].Length - 6), font, brush, left + 540, top + sg * 17 - 10);//18
            e.Graphics.DrawString(zd[65], font, brush, left + 645, top + sg * 16 + 4);//17.5

            //line13
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 18 - 14), new Point(left + line_h + 730, top + sg * 18 - 14));

            e.Graphics.DrawString(zd[66], font, brush, left + line_h, top + sg * 18 - 10);//19

            e.Graphics.DrawString(zd[67], font, brush, left + line_h, top + sg * 19 - 10);//20
            e.Graphics.DrawString(zd[68], font, brush, left + 320 + line_h, top + sg * 19 - 10);//20
            e.Graphics.DrawString(zd[69], font, brush, left + 490 + line_h, top + sg * 19 - 10);//20
            e.Graphics.DrawString(zd[70], font, brush, left + 600 + line_h, top + sg * 19 - 10);//20
            if (zd[67].Contains("大名"))
            {
                e.Graphics.DrawString("医保中心审核人（签字）:", font, brush, left + line_h, top + sg * 20 - 10);//21
            }
            //line_sx
            #region
            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 3 - 3), new Point(left + line_h + 93, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 6 - 2), new Point(left + line_h + 93, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 8 - 2), new Point(left + line_h + 93, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 10 - 2), new Point(left + line_h + 93, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 13 - 6), new Point(left + line_h + 93, top + sg * 15 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 93, top + sg * 16 - 10), new Point(left + line_h + 93, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 173, top + sg * 3 - 3), new Point(left + line_h + 173, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 173, top + sg * 6 - 2), new Point(left + line_h + 173, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 173, top + sg * 8 - 2), new Point(left + line_h + 173, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 173, top + sg * 10 - 2), new Point(left + line_h + 173, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 173, top + sg * 16 - 10), new Point(left + line_h + 173, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 266, top + sg * 3 - 3), new Point(left + line_h + 266, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 266, top + sg * 6 - 2), new Point(left + line_h + 266, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 266, top + sg * 8 - 2), new Point(left + line_h + 266, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 266, top + sg * 10 - 2), new Point(left + line_h + 266, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 266, top + sg * 16 - 10), new Point(left + line_h + 266, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 3 - 3), new Point(left + line_h + 350, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 6 - 2), new Point(left + line_h + 350, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 8 - 2), new Point(left + line_h + 350, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 10 - 2), new Point(left + line_h + 350, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 13 - 6), new Point(left + line_h + 350, top + sg * 15 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 350, top + sg * 16 - 10), new Point(left + line_h + 350, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 3 - 3), new Point(left + line_h + 455, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 6 - 2), new Point(left + line_h + 455, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 8 - 2), new Point(left + line_h + 455, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 10 - 2), new Point(left + line_h + 455, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 13 - 6), new Point(left + line_h + 455, top + sg * 15 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 455, top + sg * 16 - 10), new Point(left + line_h + 455, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 3 - 3), new Point(left + line_h + 540, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 6 - 2), new Point(left + line_h + 540, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 8 - 2), new Point(left + line_h + 540, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 10 - 2), new Point(left + line_h + 540, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 13 - 6), new Point(left + line_h + 540, top + sg * 15 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 540, top + sg * 16 - 10), new Point(left + line_h + 540, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 3 - 3), new Point(left + line_h + 645, top + sg * 6 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 6 - 2), new Point(left + line_h + 645, top + sg * 8 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 8 - 2), new Point(left + line_h + 645, top + sg * 10 - 6));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 10 - 2), new Point(left + line_h + 645, top + sg * 13 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 13 - 6), new Point(left + line_h + 645, top + sg * 15 - 10));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 645, top + sg * 16 - 10), new Point(left + line_h + 645, top + sg * 18 - 14));

            e.Graphics.DrawLine(myPen_bk, new Point(left + line_h + 730, top + sg * 3 - 3), new Point(left + line_h + 730, top + sg * 18 - 14));
            #endregion
            #endregion
        }
        private void zycxhz(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|定点医院综合指标控制报表|定点医院名称：广平中医院|医保编码：201712|单位：人、元、天|医院（科室）|医疗总费用|统筹费用|住院天数|住院人数|备注|制表人：|医保科长签字：|主管院长签字：|报表时间：2017-12-12";
                in_zfc_fy += "|李白|100000000.00|160000.00|170000.00|180000.00|190000.00";
                in_zfc_fy += "|李白|2000000.00|260000.00|270000.00|280000.00|290000.00";
                in_zfc_fy += "|李白|3000000.00|360000.00|370000.00|380000.00|390000.00";
                in_zfc_fy += "|李白|4000000.00|460000.00|470000.00|480000.00|490000.00";
                hs_fy = 4;
            }
            #endregion

            int sg = 20;
            int hg_temp1 = 100;
            int hg_temp = 105;
            int line_h = -7;
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Font font_bt = new Font("宋体", 15, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font_bt, brush, left + (hg_temp1 + 5 * hg_temp - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 5);

            e.Graphics.DrawString(zd[2], font, brush, left, top + sg * 1);
            e.Graphics.DrawString(zd[3], font, brush, left + 270, top + sg * 1);
            e.Graphics.DrawString(zd[4], font, brush, left + 460, top + sg * 1);

            //line1
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * 2 - 3));

            e.Graphics.DrawString(zd[5], font, brush, left, top + sg * 2);
            e.Graphics.DrawString(zd[6], font, brush, left + hg_temp1, top + sg * 2);
            e.Graphics.DrawString(zd[7], font, brush, left + hg_temp1 + 1 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[8], font, brush, left + hg_temp1 + 2 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[9], font, brush, left + hg_temp1 + 3 * hg_temp, top + sg * 2);
            e.Graphics.DrawString(zd[10], font, brush, left + hg_temp1 + 4 * hg_temp, top + sg * 2);

            //line2
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * (3 + hs_fy) - 3), new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * (3 + hs_fy) - 3));

            //*********************************************************************************************************
            string[] zd_fy = in_zfc_fy.Split('|');
            for (int i = 0; i < hs_fy; i++)
            {
                //line
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * (3 + i) - 3), new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * (3 + i) - 3));

                e.Graphics.DrawString(zd_fy[1 + i * 6], font, brush, left, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[2 + i * 6], font, brush, left + hg_temp1, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[3 + i * 6], font, brush, left + hg_temp1 + 1 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[4 + i * 6], font, brush, left + hg_temp1 + 2 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[5 + i * 6], font, brush, left + hg_temp1 + 3 * hg_temp, top + sg * (3 + i));
                e.Graphics.DrawString(zd_fy[6 + i * 6], font, brush, left + hg_temp1 + 4 * hg_temp, top + sg * (3 + i));
            }
            //*********************************************************************************************************
            e.Graphics.DrawString(zd[11], font, brush, left, top + sg * (3 + hs_fy));
            e.Graphics.DrawString(zd[12], font, brush, left + 120, top + sg * (3 + hs_fy));
            e.Graphics.DrawString(zd[13], font, brush, left + 280, top + sg * (3 + hs_fy));
            e.Graphics.DrawString(zd[14], font, brush, left + 450, top + sg * (3 + hs_fy));
            //line_sx
            #region
            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 2 - 3), new Point(left + line_h, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1, top + sg * 2 - 3), new Point(left + line_h + hg_temp1, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 1 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 1 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 2 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 2 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 3 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 3 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 4 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 4 * hg_temp, top + sg * (3 + hs_fy) - 3));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * 2 - 3), new Point(left + line_h + hg_temp1 + 5 * hg_temp, top + sg * (3 + hs_fy) - 3));
            #endregion
            #endregion
        }
        private void zyyjk(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region

            #region
            if (flag_cs)
            {
                in_zfc = "|广平中医院预交款收据|姓名：李宁|性别：男|科室：内二|住院号：100015|消费总额：1234.23|余额：12.34|次数|本次收受|发生时间|预交款方式|";
                in_zfc += "医疗付款方式|1|2000.00|2017-10-21 15:20:22|现金|城乡居民|大写金额：贰仟元整|操作员：李红|打印时间：2017-10-22 15:20:22|";
                in_zfc += "注意：请在办理出院结算时，将此凭证交回住院处，谢谢合作！|预交款单号：192029";
            }
            #endregion

            int sg = 20;
            int line_h = -5;
            Font font_bt = new Font("宋体", 16, FontStyle.Bold);
            Font font1 = new Font("宋体", 12, FontStyle.Bold);
            Font font = new Font("宋体", 10, FontStyle.Regular);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;
            string[] zd = in_zfc.Split('|');


            e.Graphics.DrawString(zd[1], font_bt, brush, left + (600 - e.Graphics.MeasureString(zd[1], font_bt).Width) / 2, top + sg * 0 - 15);//1

            e.Graphics.DrawString(zd[2], font, brush, left, top + sg * 1);//2
            e.Graphics.DrawString(zd[3], font, brush, left + 220, top + sg * 1);//2
            e.Graphics.DrawString(zd[4], font, brush, left + 440, top + sg * 1);//2

            e.Graphics.DrawString(zd[5], font, brush, left, top + sg * 2);//3
            e.Graphics.DrawString(zd[6], font, brush, left + 220, top + sg * 2);//3
            e.Graphics.DrawString(zd[7], font, brush, left + 440, top + sg * 2);//3

            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + (sg + 2) * 3 - 5), new Point(left + line_h + 600, top + (sg + 2) * 3 - 5));
            e.Graphics.DrawString(zd[8], font, brush, left, top + (sg + 2) * 3);//4
            e.Graphics.DrawString(zd[9], font, brush, left + 40, top + (sg + 2) * 3);//4
            e.Graphics.DrawString(zd[10], font, brush, left + 180, top + (sg + 2) * 3);//4
            e.Graphics.DrawString(zd[11], font, brush, left + 330, top + (sg + 2) * 3);//4
            e.Graphics.DrawString(zd[12], font, brush, left + 430, top + (sg + 2) * 3);//4

            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + (sg + 2) * 4 - 5), new Point(left + line_h + 600, top + (sg + 2) * 4 - 5));
            e.Graphics.DrawString(zd[13], font, brush, left, top + (sg + 2) * 4);//5
            e.Graphics.DrawString(zd[14], font, brush, left + 40, top + (sg + 2) * 4);//5
            e.Graphics.DrawString(zd[15], font, brush, left + 180, top + (sg + 2) * 4);//5
            e.Graphics.DrawString(zd[16], font, brush, left + 330, top + (sg + 2) * 4);//5
            e.Graphics.DrawString(zd[17], font, brush, left + 430, top + (sg + 2) * 4);//5

            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + (sg + 2) * 5 - 5), new Point(left + line_h + 600, top + (sg + 2) * 5 - 5));
            e.Graphics.DrawString(zd[18], font1, brush, left, top + (sg + 2) * 5 - 2);//6

            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + (sg + 2) * 6 - 5), new Point(left + line_h + 600, top + (sg + 2) * 6 - 5));

            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + (sg + 2) * 3 - 5), new Point(left + line_h, top + (sg + 2) * 6 - 5));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 40, top + (sg + 2) * 3 - 5), new Point(left + line_h + 40, top + (sg + 2) * 5 - 5));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 180, top + (sg + 2) * 3 - 5), new Point(left + line_h + 180, top + (sg + 2) * 5 - 5));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 330, top + (sg + 2) * 3 - 5), new Point(left + line_h + 330, top + (sg + 2) * 5 - 5));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 430, top + (sg + 2) * 3 - 5), new Point(left + line_h + 430, top + (sg + 2) * 5 - 5));
            e.Graphics.DrawLine(myPen, new Point(left + line_h + 600, top + (sg + 2) * 3 - 5), new Point(left + line_h + 600, top + (sg + 2) * 6 - 5));

            e.Graphics.DrawString(zd[19], font, brush, left, top + sg * 7);//7
            e.Graphics.DrawString(zd[20], font, brush, left + 300, top + sg * 7);//7

            e.Graphics.DrawString(zd[21], font, brush, left, top + sg * 8);//8

            e.Graphics.DrawString(zd[22], font, brush, left, top + sg * 9);//9
            #endregion

            #region
            //int top_fz = 0;
            //top_fz = top + sg * 9 + 80;
            //e.Graphics.DrawString(zd[1], font_bt, brush, left + 140, top_fz + sg * 0 - 15);//1

            //e.Graphics.DrawString(zd[2], font, brush, left + 20, top_fz + sg * 1);//2
            //e.Graphics.DrawString(zd[3], font, brush, left + 220, top_fz + sg * 1);//2
            //e.Graphics.DrawString(zd[4], font, brush, left + 420, top_fz + sg * 1);//2

            //e.Graphics.DrawString(zd[5], font, brush, left + 20, top_fz + sg * 2);//3
            //e.Graphics.DrawString(zd[6], font, brush, left + 220, top_fz + sg * 2);//3
            //e.Graphics.DrawString(zd[7], font, brush, left + 420, top_fz + sg * 2);//3

            //e.Graphics.DrawLine(myPen, new Point(left + 10, top_fz + (sg + 2) * 3 - 5), new Point(left + 560, top_fz + (sg + 2) * 3 - 5));
            //e.Graphics.DrawString(zd[8], font, brush, left + 20, top_fz + (sg + 2) * 3);//4
            //e.Graphics.DrawString(zd[9], font, brush, left + 100, top_fz + (sg + 2) * 3);//4
            //e.Graphics.DrawString(zd[10], font, brush, left + 270, top_fz + (sg + 2) * 3);//4
            //e.Graphics.DrawString(zd[11], font, brush, left + 410, top_fz + (sg + 2) * 3);//4

            //e.Graphics.DrawLine(myPen, new Point(left + 10, top_fz + (sg + 2) * 4 - 5), new Point(left + 560, top_fz + (sg + 2) * 4 - 5));
            //e.Graphics.DrawString(zd[12], font, brush, left + 20, top_fz + (sg + 2) * 4);//5
            //e.Graphics.DrawString(zd[13], font, brush, left + 100, top_fz + (sg + 2) * 4);//5
            //e.Graphics.DrawString(zd[14], font, brush, left + 270, top_fz + (sg + 2) * 4);//5
            //e.Graphics.DrawString(zd[15], font, brush, left + 410, top_fz + (sg + 2) * 4);//5

            //e.Graphics.DrawLine(myPen, new Point(left + 10, top_fz + (sg + 2) * 5 - 5), new Point(left + 560, top_fz + (sg + 2) * 5 - 5));
            //e.Graphics.DrawString(zd[16], font1, brush, left + 20, top_fz + (sg + 2) * 5 - 2);//6

            //e.Graphics.DrawLine(myPen, new Point(left + 10, top_fz + (sg + 2) * 6 - 5), new Point(left + 560, top_fz + (sg + 2) * 6 - 5));

            //e.Graphics.DrawLine(myPen, new Point(left + 10, top_fz + (sg + 2) * 3 - 5), new Point(left + 10, top_fz + (sg + 2) * 6 - 5));
            //e.Graphics.DrawLine(myPen, new Point(left + 80, top_fz + (sg + 2) * 3 - 5), new Point(left + 80, top_fz + (sg + 2) * 5 - 5));
            //e.Graphics.DrawLine(myPen, new Point(left + 250, top_fz + (sg + 2) * 3 - 5), new Point(left + 250, top_fz + (sg + 2) * 5 - 5));
            //e.Graphics.DrawLine(myPen, new Point(left + 400, top_fz + (sg + 2) * 3 - 5), new Point(left + 400, top_fz + (sg + 2) * 5 - 5));
            //e.Graphics.DrawLine(myPen, new Point(left + 560, top_fz + (sg + 2) * 3 - 5), new Point(left + 560, top_fz + (sg + 2) * 6 - 5));

            //e.Graphics.DrawString(zd[17], font, brush, left + 20, top_fz + sg * 7);//7
            //e.Graphics.DrawString(zd[18], font, brush, left + 300, top_fz + sg * 7);//7

            //e.Graphics.DrawString(zd[19], font, brush, left + 20, top_fz + sg * 8);//8

            //e.Graphics.DrawString(zd[20], font, brush, left + 20, top_fz + sg * 9);//9
            #endregion
        }
        int page_m = 0;
        private void zyfyqd(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int printCount = list_mx.Count / 60 + ((list_mx.Count % 60) != 0 ? 1 : 0);
            if (page_m >= printCount)
            {
                page_m = 0;
            }
            page_m++;
            String[] zd = in_zfc.Split('|');
            int sg = 20;
            int line_h = -5;
            Font font_bt = new Font("宋体", 16, FontStyle.Bold);
            Font font1 = new Font("宋体", 10, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Font font = new Font("宋体", 11, FontStyle.Regular);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;

            #region
            e.Graphics.DrawString(zd[0], font_bt, brush, left + (800 - e.Graphics.MeasureString(zd[0], font_bt).Width) / 2, top + sg * 0 - 15);//1

            e.Graphics.DrawString(zd[1], font, brush, left, top + sg * 1);//2
            e.Graphics.DrawString(zd[2], font, brush, left + 120, top + sg * 1);//2
            e.Graphics.DrawString(zd[3], font, brush, left + 260, top + sg * 1);//2
            e.Graphics.DrawString(zd[4], font, brush, left + 430, top + sg * 1);//2
            e.Graphics.DrawString(zd[5], font, brush, left + 605, top + sg * 1);//2

            e.Graphics.DrawString(zd[6], font, brush, left, top + sg * 2);//3
            e.Graphics.DrawString(zd[7], font, brush, left + 120, top + sg * 2);//3
            e.Graphics.DrawString(zd[8], font, brush, left + 260, top + sg * 2);//3
            e.Graphics.DrawString(zd[9], font, brush, left + 430, top + sg * 2);//3
            e.Graphics.DrawString(zd[10], font, brush, left + 605, top + sg * 2);//3

            e.Graphics.DrawString(zd[11], font, brush, left, top + sg * 3);//4
            e.Graphics.DrawString(zd[12], font, brush, left + 540, top + sg * 3);//4
            if (string.IsNullOrEmpty(zd[20]))
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + 800, top + sg * 4 - 3));
                e.Graphics.DrawString(zd[13], font, brush, left, top + sg * 4);//5
                e.Graphics.DrawString(zd[14], font, brush, left + 40, top + sg * 4);//5
                e.Graphics.DrawString(zd[15], font, brush, left + 110, top + sg * 4);//5
                e.Graphics.DrawString(zd[16], font, brush, left + 450, top + sg * 4);//5
                e.Graphics.DrawString(zd[17], font, brush, left + 520, top + sg * 4);//5
                e.Graphics.DrawString(zd[18], font, brush, left + 600, top + sg * 4);//5
                e.Graphics.DrawString(zd[19], font, brush, left + 700, top + sg * 4);//5
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 - 2), new Point(left + line_h + 800, top + sg * 5 - 2));


                #region
                for (int i = (page_m - 1) * 60; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 450, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 520, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 600, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        if (list_mx.Count == 60 * page_m && i == list_mx.Count - 1)
                        {

                        }
                        else
                        {
                            if (i == page_m * 60 - 1)
                            {
                                e.HasMorePages = true;
                                break;
                            }
                        }
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 665, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString("----------------------------------------------------------------------------------", font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        if (list_mx.Count == 60 * page_m && i == list_mx.Count - 1)
                        {

                        }
                        else
                        {
                            if (i == page_m * 60 - 1)
                            {
                                e.HasMorePages = true;
                                break;
                            }
                        }
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 665, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            else
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + 800, top + sg * 4 - 3));
                e.Graphics.DrawString(zd[13], font, brush, left, top + sg * 4);//5
                e.Graphics.DrawString(zd[14], font, brush, left + 40, top + sg * 4);//5
                e.Graphics.DrawString(zd[15], font, brush, left + 110, top + sg * 4);//5
                e.Graphics.DrawString(zd[16], font, brush, left + 380, top + sg * 4);//5
                e.Graphics.DrawString(zd[17], font, brush, left + 440, top + sg * 4);//5
                e.Graphics.DrawString(zd[18], font, brush, left + 485, top + sg * 4);//5
                e.Graphics.DrawString(zd[19], font, brush, left + 575, top + sg * 4);//5
                e.Graphics.DrawString(zd[20], font, brush, left + 655, top + sg * 4);//5
                e.Graphics.DrawString(zd[21], font, brush, left + 695, top + sg * 4);//5
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 - 2), new Point(left + line_h + 800, top + sg * 5 - 2));


                #region
                for (int i = (page_m - 1) * 60; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 380, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 440, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 485, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 575, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][7], font1, brush, left + 660, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][8], font1, brush, left + 695, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        if (list_mx.Count == 60 * page_m && i == list_mx.Count - 1)
                        {

                        }
                        else
                        {
                            if (i == page_m * 60 - 1)
                            {
                                e.HasMorePages = true;
                                break;
                            }
                        }
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 550, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                            e.Graphics.DrawString(zd[23], font, brush, left + 694, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString("----------------------------------------------------------------", font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 575, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60));//5
                        if (list_mx.Count == 60 * page_m && i == list_mx.Count - 1)
                        {

                        }
                        else
                        {
                            if (i == page_m * 60 - 1)
                            {
                                e.HasMorePages = true;
                                break;
                            }
                        }

                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 550, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                            e.Graphics.DrawString(zd[23], font, brush, left + 694, top + sg * 5 + sg * 4 / 5 * (i - (page_m - 1) * 60) + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            #endregion
        }
        private void zyfyqd_ld(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String[] zd = in_zfc.Split('|');
            int sg = 20;
            int line_h = -5;
            Font font_bt = new Font("宋体", 16, FontStyle.Bold);
            Font font1 = new Font("宋体", 10, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Font font = new Font("宋体", 11, FontStyle.Regular);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;

            #region
            e.Graphics.DrawString(zd[0], font_bt, brush, left + (800 - e.Graphics.MeasureString(zd[0], font_bt).Width) / 2, top + sg * 0 - 15);//1

            e.Graphics.DrawString(zd[1], font, brush, left, top + sg * 1);//2
            e.Graphics.DrawString(zd[2], font, brush, left + 120, top + sg * 1);//2
            e.Graphics.DrawString(zd[3], font, brush, left + 260, top + sg * 1);//2
            e.Graphics.DrawString(zd[4], font, brush, left + 430, top + sg * 1);//2
            e.Graphics.DrawString(zd[5], font, brush, left + 605, top + sg * 1);//2

            e.Graphics.DrawString(zd[6], font, brush, left, top + sg * 2);//3
            e.Graphics.DrawString(zd[7], font, brush, left + 120, top + sg * 2);//3
            e.Graphics.DrawString(zd[8], font, brush, left + 260, top + sg * 2);//3
            e.Graphics.DrawString(zd[9], font, brush, left + 430, top + sg * 2);//3
            e.Graphics.DrawString(zd[10], font, brush, left + 605, top + sg * 2);//3

            e.Graphics.DrawString(zd[11], font, brush, left, top + sg * 3);//4
            e.Graphics.DrawString(zd[12], font, brush, left + 540, top + sg * 3);//4
            if (string.IsNullOrEmpty(zd[20]))
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + 800, top + sg * 4 - 3));
                e.Graphics.DrawString(zd[13], font, brush, left, top + sg * 4);//5
                e.Graphics.DrawString(zd[14], font, brush, left + 40, top + sg * 4);//5
                e.Graphics.DrawString(zd[15], font, brush, left + 110, top + sg * 4);//5
                e.Graphics.DrawString(zd[16], font, brush, left + 450, top + sg * 4);//5
                e.Graphics.DrawString(zd[17], font, brush, left + 520, top + sg * 4);//5
                e.Graphics.DrawString(zd[18], font, brush, left + 600, top + sg * 4);//5
                e.Graphics.DrawString(zd[19], font, brush, left + 700, top + sg * 4);//5
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 - 2), new Point(left + line_h + 800, top + sg * 5 - 2));


                #region
                for (int i = 0; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 5 + sg * 4 / 5 * i);//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 450, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 520, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 600, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 5 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 665, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString("----------------------------------------------------------------------------------", font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 5 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 665, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            else
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 3), new Point(left + line_h + 800, top + sg * 4 - 3));
                e.Graphics.DrawString(zd[13], font, brush, left, top + sg * 4);//5
                e.Graphics.DrawString(zd[14], font, brush, left + 40, top + sg * 4);//5
                e.Graphics.DrawString(zd[15], font, brush, left + 110, top + sg * 4);//5
                e.Graphics.DrawString(zd[16], font, brush, left + 380, top + sg * 4);//5
                e.Graphics.DrawString(zd[17], font, brush, left + 440, top + sg * 4);//5
                e.Graphics.DrawString(zd[18], font, brush, left + 485, top + sg * 4);//5
                e.Graphics.DrawString(zd[19], font, brush, left + 575, top + sg * 4);//5
                e.Graphics.DrawString(zd[20], font, brush, left + 655, top + sg * 4);//5
                e.Graphics.DrawString(zd[21], font, brush, left + 695, top + sg * 4);//5
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 - 2), new Point(left + line_h + 800, top + sg * 5 - 2));


                #region
                for (int i = 0; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 5 + sg * 4 / 5 * i);//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 380, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 440, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 485, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 575, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][7], font1, brush, left + 660, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][8], font1, brush, left + 695, top + sg * 5 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 520, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                            e.Graphics.DrawString(zd[23], font, brush, left + 660, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString("----------------------------------------------------------------", font1, brush, left + 110, top + sg * 5 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 575, top + sg * 5 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[22], font, brush, left + 520, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                            e.Graphics.DrawString(zd[23], font, brush, left + 660, top + sg * 5 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            #endregion
        }
        private void mzfyqd_ld(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String[] zd = in_zfc.Split('|');
            int sg = 20;
            int line_h = -5;
            Font font_bt = new Font("宋体", 16, FontStyle.Bold);
            Font font1 = new Font("宋体", 10, FontStyle.Regular);
            Font font2 = new Font("宋体", 8, FontStyle.Regular);
            Font font = new Font("宋体", 11, FontStyle.Regular);
            Pen myPen = new Pen(Color.FromArgb(255, Color.Black), 1.0F);
            Brush brush = Brushes.Black;

            #region
            e.Graphics.DrawString(zd[0], font_bt, brush, left + (800 - e.Graphics.MeasureString(zd[0], font_bt).Width) / 2, top + sg * 0 - 15);//1

            e.Graphics.DrawString(zd[1], font, brush, left, top + sg * 1);//2
            e.Graphics.DrawString(zd[2], font, brush, left + 180, top + sg * 1);//2
            e.Graphics.DrawString(zd[3], font, brush, left + 360, top + sg * 1);//2
            e.Graphics.DrawString(zd[4], font, brush, left + 540, top + sg * 1);//2

            e.Graphics.DrawString(zd[5], font, brush, left, top + sg * 2);//3
            e.Graphics.DrawString(zd[6], font, brush, left + 540, top + sg * 2);//3

            if (string.IsNullOrEmpty(zd[14]))
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h + 800, top + sg * 3 - 3));
                e.Graphics.DrawString(zd[7], font, brush, left, top + sg * 3);//4
                e.Graphics.DrawString(zd[8], font, brush, left + 40, top + sg * 3);//4
                e.Graphics.DrawString(zd[9], font, brush, left + 110, top + sg * 3);//4
                e.Graphics.DrawString(zd[10], font, brush, left + 450, top + sg * 3);//4
                e.Graphics.DrawString(zd[11], font, brush, left + 520, top + sg * 3);//4
                e.Graphics.DrawString(zd[12], font, brush, left + 600, top + sg * 3);//4
                e.Graphics.DrawString(zd[13], font, brush, left + 700, top + sg * 3);//4
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 2), new Point(left + line_h + 800, top + sg * 4 - 2));

                #region
                for (int i = 0; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 4 + sg * 4 / 5 * i);//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 450, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 520, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 600, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 4 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[15], font, brush, left + 650, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//4
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString("----------------------------------------------------------------------------------", font1, brush, left + 110, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 700, top + sg * 4 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[15], font, brush, left + 650, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            else
            {
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 3 - 3), new Point(left + line_h + 800, top + sg * 3 - 3));
                e.Graphics.DrawString(zd[7], font, brush, left, top + sg * 3);//4
                e.Graphics.DrawString(zd[8], font, brush, left + 40, top + sg * 3);//4
                e.Graphics.DrawString(zd[9], font, brush, left + 110, top + sg * 3);//4
                e.Graphics.DrawString(zd[10], font, brush, left + 390, top + sg * 3);//4
                e.Graphics.DrawString(zd[11], font, brush, left + 440, top + sg * 3);//4
                e.Graphics.DrawString(zd[12], font, brush, left + 505, top + sg * 3);//4
                e.Graphics.DrawString(zd[13], font, brush, left + 595, top + sg * 3);//4
                e.Graphics.DrawString(zd[14], font, brush, left + 690, top + sg * 3);//4
                e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 - 2), new Point(left + line_h + 800, top + sg * 4 - 2));


                #region
                for (int i = 0; i < list_mx.Count; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), font1, brush, left, top + sg * 4 + sg * 4 / 5 * i);//5
                    if (list_mx[i][1] != "小计")
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][2], font1, brush, left + 110, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][3], font1, brush, left + 390, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][4], font2, brush, left + 440, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][5], font1, brush, left + 505, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 595, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][7], font1, brush, left + 690, top + sg * 4 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[15], font, brush, left + 595, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(list_mx[i][1], font1, brush, left + 40, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString("----------------------------------------------------------------", font1, brush, left + 110, top + sg * 4 + sg * 4 / 5 * i);//5
                        e.Graphics.DrawString(list_mx[i][6], font1, brush, left + 595, top + sg * 4 + sg * 4 / 5 * i);//5
                        if (i == list_mx.Count - 1)
                        {
                            e.Graphics.DrawLine(myPen, new Point(left + line_h, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5), new Point(left + line_h + 800, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5));
                            e.Graphics.DrawString(zd[15], font, brush, left + 595, top + sg * 4 + sg * 4 / 5 * i + sg * 4 / 5 + 2);//5
                        }
                    }
                }
                #endregion
            }
            #endregion
        }
        private void sz(PrintDocument printDocument1)
        {
            PageSetupDialog pageSetupDialog1 = new PageSetupDialog();
            //设置pageSetupDialog控件的Document属性，设置操作文档
            pageSetupDialog1.Document = printDocument1;
            //启用边距
            pageSetupDialog1.AllowMargins = true;
            //启用对话框的方向部分
            pageSetupDialog1.AllowOrientation = true;
            //启用对话框的纸张部分
            pageSetupDialog1.AllowPaper = true;
            //启用“打印机”按钮
            pageSetupDialog1.AllowPrinter = true;
            //显示页面设置对话框
            pageSetupDialog1.ShowDialog();
        }
        public Bitmap get39(string s)
        {
            Pen PenBlack = new Pen(Brushes.Black);//黑色线
            Pen PenWhite = new Pen(Brushes.White);//白色线
            PenBlack.Width = 1;//统一的黑色线的宽
            PenWhite.Width = 1;//统一的白色线的宽

            Bitmap bm = new Bitmap(200, 70);//定义画布的像素（长，高）

            Graphics g = Graphics.FromImage(bm);//声明绘图
            g.Clear(Color.White);//定义绘图的背景色为白色
            #region 自定义字符的二进制格式
            Hashtable ht = new Hashtable();//自定义字符的二进制的格式
            #region 39码 12位
            ht.Add('A', "110101001011");
            ht.Add('B', "101101001011");
            ht.Add('C', "110110100101");
            ht.Add('D', "101011001011");
            ht.Add('E', "110101100101");
            ht.Add('F', "101101100101");
            ht.Add('G', "101010011011");
            ht.Add('H', "110101001101");
            ht.Add('I', "101101001101");
            ht.Add('J', "101011001101");
            ht.Add('K', "110101010011");
            ht.Add('L', "101101010011");
            ht.Add('M', "110110101001");
            ht.Add('N', "101011010011");
            ht.Add('O', "110101101001");
            ht.Add('P', "101101101001");
            ht.Add('Q', "101010110011");
            ht.Add('R', "110101011001");
            ht.Add('S', "101101011001");
            ht.Add('T', "101011011001");
            ht.Add('U', "110010101011");
            ht.Add('V', "100110101011");
            ht.Add('W', "110011010101");
            ht.Add('X', "100101101011");
            ht.Add('Y', "110010110101");
            ht.Add('Z', "100110110101");
            ht.Add('0', "101001101101");
            ht.Add('1', "110100101011");
            ht.Add('2', "101100101011");
            ht.Add('3', "110110010101");
            ht.Add('4', "101001101011");
            ht.Add('5', "110100110101");
            ht.Add('6', "101100110101");
            ht.Add('7', "101001011011");
            ht.Add('8', "110100101101");
            ht.Add('9', "101100101101");
            ht.Add('+', "100101001001");
            ht.Add('-', "100101011011");
            ht.Add('*', "100101101101");
            ht.Add('/', "100100101001");
            ht.Add('%', "101001001001");
            ht.Add('$', "100100100101");
            ht.Add('.', "110010101101");
            ht.Add(' ', "100110101101");
            #endregion
            #endregion
            float w = 1F;//条形码单个一条的宽度
            float h = 40F;//条形码单个一条的高度
            s = "*" + s.ToString().ToUpper() + "*";//39码格式的定义为“*……*”;
            //s = s.ToString().ToUpper();
            string result_bin = "";//把字符的二进制toString()显示,"00"表示开始标签
            try
            {
                foreach (char ch in s)
                {
                    result_bin += ht[ch].ToString().Trim();
                    result_bin += "0";//规定每个字符隔开一条白线
                    result_bin += ",";//为以后的DrawString(即：画字符串)做准备（因为每个字符要求隔开）
                }
                result_bin += "10";//"10"表示结束标签
            }
            catch
            {

                g.DrawString("存在不允许的字符", new Font("宋体", 5), Brushes.Black, new PointF(0, 50));//当出现错误时，通过画布显示

                g.Dispose();
                bm.Save("11.jpg");
                return bm;
            }
            Pen thePen = null;
            float x = w;//画布逐渐向右扩展的宽为线条的宽
            float x2 = 0;//字符的X坐标的逐渐向右扩展的初始值
            float topY = 1F;//线条顶点的Y坐标
            float chInt = 0;//为DrawString 做准备
            float len = ht['1'].ToString().Length;//任意单个字符的二进制的长度
            foreach (char c in result_bin)
            {
                if (c != ',')
                {
                    thePen = c == '0' ? PenWhite : PenBlack;//当二进制为“0”时，显示白线，当二进制为“1”时，显示黑线
                    g.DrawLine(thePen, new PointF(x, topY), new PointF(x, 1F + h));//根据上边的线条，画在画布上
                    x += w;
                    x2 += w;
                }
                //打印字符串
                else if (c == ',')
                {

                    int chint2 = 0;
                    foreach (char thec in s)
                    {
                        if (chint2 == chInt)
                        {
                            g.DrawString(thec.ToString(), new Font("宋体", 5), Brushes.Black, new PointF(x2 - ((len + 1) * 1), 2 + h + 1));//在画布上显示文字
                        }
                        chint2 = chint2 + 1;
                    }
                    chInt = chInt + 1;
                }
            }
            g.Dispose();
            bm.Save("11.jpg");
            return bm;
        }

        private void FrmDy_Load(object sender, EventArgs e)
        {

        }

    }
}
