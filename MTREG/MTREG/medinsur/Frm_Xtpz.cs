using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.tools;
using MTHIS.tools;
using MTHIS;

namespace MTREG.medinsur
{
    public partial class Frm_Xtpz : Form
    {
        public Frm_Xtpz()
        {
            InitializeComponent();
        }

        private void Frm_Xtpz_Load(object sender, EventArgs e)
        {
            if (IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YBCHZDGXSJ").Equals("1"))
            {
                this.cbx_ybchzdgx.Checked = true;//医保城乡自动更新数据
            }
            this.tbx_jgsj.Text = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "JGDATE");//线程间隔运行时间 单位分钟
            this.date_yckssj.Text = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YCKSDATE");//第一次开始时间
            this.date_ycjssj.Text = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "YCJSDATE");//第一次结束时间
            this.date_eckssj.Text = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "ECKSDATE");//第二次开始时间
            this.date_ecjssj.Text = IniUtils.IniReadValue(IniUtils.syspath, "DATE", "ECJSDATE");//第二次结束时间
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "ybState").Equals("1"))
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = true;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "chState").Equals("1"))
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = true;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "mzState").Equals("1"))
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = true;
                this.cbx_zy.Checked = false;

            }
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "zyState").Equals("1"))
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = true;
            }
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "qybState").Equals("1"))
            {
                this.ckb_yb.Checked = true;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
            if (IniUtils.IniReadValue(IniUtils.syspath, "MTCLIENT", "qchState").Equals("1"))
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = true;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void cbx_mz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_mz.Checked == true)
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void cbx_zy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbx_zy.Checked == true)
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
            }
        }

        private void ckb_yb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_yb.Checked == true)
            {
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void ckb_cx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_cx.Checked == true)
            {
                this.ckb_yb.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void ckb_zyyb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_zyyb.Checked == true)
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zych.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void ckb_zych_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_zych.Checked == true)
            {
                this.ckb_yb.Checked = false;
                this.ckb_cx.Checked = false;
                this.ckb_zyyb.Checked = false;
                this.cbx_mz.Checked = false;
                this.cbx_zy.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                if (this.cbx_ybchzdgx.Checked == true)
                {
                    IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "YBCHZDGXSJ", "1");//医保城乡自动更新数据
                }
                else
                {
                    IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "YBCHZDGXSJ", "0");//医保城乡自动更新数据
                }
                IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "JGDATE", this.tbx_jgsj.Text.Trim());//线程间隔运行时间 单位分钟
                IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "YCKSDATE", this.date_yckssj.Text);//第一次开始时间
                IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "YCJSDATE", this.date_ycjssj.Text);//第一次结束时间
                IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "ECKSDATE", this.date_eckssj.Text);//第二次开始时间
                IniUtils.IniWriteValue(IniUtils.syspath,"DATE", "ECJSDATE", this.date_ecjssj.Text);//第二次结束时间
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            #endregion
        }
    }
}
