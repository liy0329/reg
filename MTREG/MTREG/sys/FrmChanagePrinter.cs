using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using MTHIS.db;
using MTHIS.common;

namespace MTHIS.chklist
{
    public partial class FrmChanagePrinter : Form
    {
        public FrmChanagePrinter()
        {
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            init();
        }

        private String rptName;
        public FrmChanagePrinter(String rptName)
        {
            this.rptName = rptName;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            init();
        }
        private String printerName;
        public FrmChanagePrinter(String rptName, String printerName)
        {
            this.rptName = rptName;
            this.printerName = printerName;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            init();
        }

        List<String> cmbx = new List<String>();
        private void FrmChanagePrinter_Load(object sender, EventArgs e)
        {
            this.lblRPT.Text = rptName + "打印机:";
            this.lblPrinter.Text = printerName;
            this.cmbxPrinterName.DataSource = cmbx;
        }

        private void init() 
        {
            if (cmbx.Count != 0) { return; }
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                cmbx.Add(sPrint);
            }
            cmbx.Add("default");
        }

        public bool Exists(string printer) 
        {
            if (cmbx.Contains(printer)) { return true; }
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            String printName = this.cmbxPrinterName.Text;
            Ini.INIClass(GlobalParams.syspath);
            Ini.IniWriteValue("reportprint", rptName, printName);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
