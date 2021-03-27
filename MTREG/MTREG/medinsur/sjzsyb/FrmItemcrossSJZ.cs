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

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmItemcrossSJZ : Form
    {
        Sjzsyb syb = new Sjzsyb();
        BllItemcrossSJZ bllItemcross = new BllItemcrossSJZ();
        public FrmItemcrossSJZ()
        {
            InitializeComponent();
        }

        private void textbox_jm_keyup()
        {
            string itemfrom = "";
            string isCross = "";
            if (radioButton_yp.Checked == true)
            {
                itemfrom = "'DRUG'";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "'COST'";
            }
            else if (radioButton_fw.Checked == true)
            {
                itemfrom = "'STUFF'";
            }
            //else if (radioButton_cl.Checked == true)
            //{
            //    itemfrom = "'STUFF'";
            //}
            if (checkBox_sfdy.Checked == true)
                isCross = "0";
            else
                isCross = "-1";
            if (TextBox_Jm.Text == "")
            {
                //清空
                this.TextBox_Jm.Focus();
                this.dgvItemInfo.DataSource = null;
            }
            dgvItemInfo.Columns.Clear();
            
            #region updateHeaderText
            dgvItemInfo.Font = new Font("宋体", 14, (System.Drawing.FontStyle.Bold));


            DataGridViewCheckBoxColumn columncb = new DataGridViewCheckBoxColumn();
            columncb.HeaderText = "选择";
            columncb.Name = "cb_check";
            columncb.TrueValue = true;
            columncb.FalseValue = false;
            //column9.DataPropertyName = "IsScienceNature";
            columncb.DataPropertyName = "IsChecked";
            dgvItemInfo.Columns.Add(columncb);
            dgvItemInfo.Columns["cb_check"].DisplayIndex = 0;
            dgvItemInfo.Columns["cb_check"].Width = 50;

            dgvItemInfo.DataSource = bllItemcross.getItemInfo(TextBox_Jm.Text.Trim(), itemfrom, isCross);
            if (itemfrom.Equals("'DRUG'"))
            {
                dgvItemInfo.Columns["AKC515"].HeaderText = "His编码";
                dgvItemInfo.Columns["AKC515"].DisplayIndex = 1;
                dgvItemInfo.Columns["AKC515"].Width = 200;
                dgvItemInfo.Columns["AKC516"].HeaderText = "His名称";
                dgvItemInfo.Columns["AKC516"].Width = 150;
                dgvItemInfo.Columns["AKC516"].DisplayIndex = 2;
                dgvItemInfo.Columns["AKA060"].HeaderText = "医保编码";
                dgvItemInfo.Columns["AKA060"].DisplayIndex = 3;
                dgvItemInfo.Columns["AKA060"].Width = 200;
                dgvItemInfo.Columns["AKA061"].HeaderText = "医保名称";
                dgvItemInfo.Columns["AKA061"].Width = 150;
                dgvItemInfo.Columns["AKA061"].DisplayIndex = 4;
                dgvItemInfo.Columns["HISAKA077"].HeaderText = "规格";
                dgvItemInfo.Columns["HISAKA077"].Width = 100;
                dgvItemInfo.Columns["HISAKA077"].DisplayIndex = 5;
                dgvItemInfo.Columns["HISAKA070"].HeaderText = "剂型";
                dgvItemInfo.Columns["HISAKA070"].Width = 100;
                dgvItemInfo.Columns["HISAKA070"].DisplayIndex = 6;
                dgvItemInfo.Columns["AKC225"].HeaderText = "价格";
                dgvItemInfo.Columns["AKC225"].Width = 100;
                dgvItemInfo.Columns["AKC225"].DisplayIndex = 7;
                dgvItemInfo.Columns["HISCKAA00"].HeaderText = "生产厂家";
                dgvItemInfo.Columns["HISCKAA00"].Width = 100;
                dgvItemInfo.Columns["HISCKAA00"].DisplayIndex = 8;
                dgvItemInfo.Columns["HISAKA066"].Visible = false;
                dgvItemInfo.Columns["isstop"].Visible = false;
            }
            else
            {
                dgvItemInfo.Columns["AKC515"].HeaderText = "His编码";
                dgvItemInfo.Columns["AKC515"].DisplayIndex = 1;
                dgvItemInfo.Columns["AKC515"].Width = 200;
                dgvItemInfo.Columns["AKC516"].HeaderText = "His名称";
                dgvItemInfo.Columns["AKC516"].Width = 150;
                dgvItemInfo.Columns["AKC516"].DisplayIndex = 2;
                dgvItemInfo.Columns["AKA060"].HeaderText = "医保编码";
                dgvItemInfo.Columns["AKA060"].DisplayIndex = 3;
                dgvItemInfo.Columns["AKA060"].Width = 200;
                dgvItemInfo.Columns["AKA061"].HeaderText = "医保名称";
                dgvItemInfo.Columns["AKA061"].Width = 150;
                dgvItemInfo.Columns["AKA061"].DisplayIndex = 4;
                dgvItemInfo.Columns["AKC225"].HeaderText = "价格";
                dgvItemInfo.Columns["AKC225"].Width = 100;
                dgvItemInfo.Columns["AKC225"].DisplayIndex = 5;
                dgvItemInfo.Columns["HISAKA066"].Visible = false;
                dgvItemInfo.Columns["isstop"].Visible = false;

            }
            
            dgvItemInfo.ReadOnly = true;
            dgvItemInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItemInfo.MultiSelect = false;
            if (dgvItemInfo.Rows.Count > 0)
            {
                dgvItemInfo.Rows[0].Selected = true;
                for (int i = 0; i < dgvItemInfo.Rows.Count; i++)
                {
                    if (dgvItemInfo.Rows[i].Cells["isstop"].Value.ToString() == "0")
                        dgvItemInfo.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未审核
                    //else if (dgvItemInfo.Rows[i].Cells["isstop"].Value.ToString() == "1")
                    //    dgvItemInfo.Rows[i].DefaultCellStyle.BackColor = Color.Brown;//
                    else if (dgvItemInfo.Rows[i].Cells["isstop"].Value.ToString() == "2")
                        dgvItemInfo.Rows[i].DefaultCellStyle.BackColor = Color.Orange;//审核未通过

                }
            }
            #endregion
        }

        private void TextBox_Jm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.textbox_jm_keyup();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemfrom = "";
            string isCross = "";
            if (radioButton_yp.Checked == true)
            {
                itemfrom = "1";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "2";
            }
            else if (radioButton_fw.Checked == true)
            {
                itemfrom = "3";
            }
            if (checkBox_sfdy.Checked == true)
                isCross = "0";
            else
                isCross = "1";
            if (!(dgvItemInfo.Rows.Count > 0))
            {
                MessageBox.Show("没有项目信息", "提示信息");
                return;
            }

            string data = "";
            for (int i = 0; i < dgvItemInfo.Rows.Count; i++ )
            {
                if ((Convert.ToBoolean(dgvItemInfo.Rows[i].Cells["cb_check"].Value) == true))
                {
                    if(itemfrom.Equals("1"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA060>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA060>"
                        + "<AKA061>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA061>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<HISAKA070>" + dgvItemInfo.Rows[i].Cells["HISAKA070"].Value + "</HISAKA070>"
                        + "<HISAKA077>" + dgvItemInfo.Rows[i].Cells["HISAKA077"].Value + "</HISAKA077>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "<HISCKAA00>" + dgvItemInfo.Rows[i].Cells["HISCKAA00"].Value + "</HISCKAA00>"
                        + "</INROW>";
                    }
                    else if (itemfrom.Equals("2"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA090>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA090>"
                        + "<AKA091>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA091>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "</INROW>";
                    }
                    else if (itemfrom.Equals("3"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA100>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA100>"
                        + "<AKA102>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA102>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "</INROW>";
                    }
                    
                }
            }
            if(data.Equals(""))
            {
                MessageBox.Show("请选择需要对应的项目", "提示信息");
                return;
            }
            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            Sjzsyb_IN syb_in = new Sjzsyb_IN();
            syb_in.Yw = "1633";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001></AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190></AKC190>"//门诊/住院流水号 
                        + "<AKC020></AKC020>"//社保卡号 
                        + "<AKA130></AKA130>"//可空 
                        + "<MSGNO>1633</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + "<INPUT>"
                            + "<AKC224>" + itemfrom + "</AKC224>"
                            + data
                        + "</INPUT>"
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);

            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];
            string ReturnMsg = "";



            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
        }

        private void dgvItemInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                //获取控件的值

                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgvItemInfo.Rows[e.RowIndex].Cells["cb_check"];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    checkCell.Value = false;
                }
                else
                {
                    checkCell.Value = true;
                }
            }
        }

        private void dgvItemInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)//如果单击列表头，全选．
            {

                int i;
                for (i = 0; i < this.dgvItemInfo.RowCount; i++)
                {
                    if ((Convert.ToBoolean(dgvItemInfo.Rows[i].Cells["cb_check"].Value) == false))
                    {
                        this.dgvItemInfo.Rows[i].Cells["cb_check"].Value = "true";//如果为true则为选中,false未选中
                    }
                    else
                    {
                        this.dgvItemInfo.Rows[i].Cells["cb_check"].Value = "false";//如果为true则为选中,false未选中
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string itemfrom = "";
            string isCross = "3";
            if (radioButton_yp.Checked == true)
            {
                itemfrom = "1";
            }
            else if (radioButton_zl.Checked == true)
            {
                itemfrom = "2";
            }
            else if (radioButton_fw.Checked == true)
            {
                itemfrom = "3";
            }

            string data = "";
            for (int i = 0; i < dgvItemInfo.Rows.Count; i++)
            {
                if ((Convert.ToBoolean(dgvItemInfo.Rows[i].Cells["cb_check"].Value) == true))
                {
                    if (itemfrom.Equals("1"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA060>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA060>"
                        + "<AKA061>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA061>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<HISAKA070>" + dgvItemInfo.Rows[i].Cells["HISAKA070"].Value + "</HISAKA070>"
                        + "<HISAKA077>" + dgvItemInfo.Rows[i].Cells["HISAKA077"].Value + "</HISAKA077>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "<HISCKAA00>" + dgvItemInfo.Rows[i].Cells["HISCKAA00"].Value + "</HISCKAA00>"
                        + "</INROW>";
                    }
                    else if (itemfrom.Equals("2"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA090>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA090>"
                        + "<AKA091>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA091>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "</INROW>";
                    }
                    else if (itemfrom.Equals("3"))
                    {
                        data += "<INROW>"
                        + "<OPERTYPE>" + isCross + "</OPERTYPE>"//0 新增 1 修改 2 删除
                        + "<AKA100>" + dgvItemInfo.Rows[i].Cells["AKA060"].Value + "</AKA100>"
                        + "<AKA102>" + dgvItemInfo.Rows[i].Cells["AKA061"].Value + "</AKA102>"
                        + "<AKC515>" + dgvItemInfo.Rows[i].Cells["AKC515"].Value + "</AKC515>"
                        + "<AKC516>" + dgvItemInfo.Rows[i].Cells["AKC516"].Value + "</AKC516>"
                        + "<HISAKA066>" + dgvItemInfo.Rows[i].Cells["HISAKA066"].Value + "</HISAKA066>"
                        + "<AKC225>" + dgvItemInfo.Rows[i].Cells["AKC225"].Value + "</AKC225>"
                        + "</INROW>";
                    }

                }
            }
            if (data.Equals(""))
            {
                MessageBox.Show("请选择需要对应的项目", "提示信息");
                return;
            }

            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            Sjzsyb_IN syb_in = new Sjzsyb_IN();
            syb_in.Yw = "1633";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001></AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190></AKC190>"//门诊/住院流水号 
                        + "<AKC020></AKC020>"//社保卡号 
                        + "<AKA130></AKA130>"//可空 
                        + "<MSGNO>1633</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + "<INPUT>"
                            + "<AKC224>" + itemfrom + "</AKC224>"
                            + data
                        + "</INPUT>"
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);

            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];
            string ReturnMsg = "";



            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
        }

        

        
    }
}