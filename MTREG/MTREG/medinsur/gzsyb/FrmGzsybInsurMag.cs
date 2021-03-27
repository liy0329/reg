using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.common;
using MTREG.medinsur.bll;
using MTREG.medinsur;

using MTREG.medinsur.hdxbhnh.bll;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.hdsbhnh.bo;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTREG.medinsur.ahsjk;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsnh.bll;
using System.Net;
using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.ahsjk.bo;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using MTREG.medinsur.ynsyb.ihsp.bll;

namespace MTREG.ihsp
{
    public partial class FrmGzsybInsurMag : Form
    {
        BillIhspcost billIhspcost = new BillIhspcost();
        BillIhspMan billIhspMan = new BillIhspMan();
        BllInsur bllInsur = new BllInsur();
        BllHdsch bllHdsch = new BllHdsch();
     
        string ihspcode;
        string ihspid;
        public FrmGzsybInsurMag()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patienttype"></param>
        public void getSource(string id, string patienttype)
        {
            this.ihspid = id;
            DataTable dt = billIhspcost.ihspIdSearch(id);
            string status = dt.Rows[0]["status"].ToString();
            ihspcode = dt.Rows[0]["ihspcode"].ToString();
            if (status == IhspStatus.SIGN.ToString())
            {
                btnOuthspReg.Enabled = true;
            }
            else
            {
                btnOuthspReg.Enabled = false;
            }
            btnIhspChange.Enabled = false;
            //不等于自费
            string keyname = bllInsur.getInsurtype(patienttype);
            if (keyname != CostInsurtypeKeyname.SELFCOST.ToString())
            {
                BillCmbList billCmbList = new BillCmbList();

                DataTable dtp = billCmbList.patientTypeList();
                if (dtp.Rows.Count > 0)
                {
                    this.cmbPatienttype.ValueMember = "id";
                    this.cmbPatienttype.DisplayMember = "name";
                    this.cmbPatienttype.DataSource = dtp;
                    this.cmbPatienttype.SelectedValue = patienttype;
                }
               
                if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
                {
                    btnIhspChange.Enabled = true;
                    btnReCost.Enabled = true;
                    btnDelete.Enabled = true;
                }
                if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
                {
                    btnIhspChange.Enabled = true;
                    btnTruncode.Enabled = true;
                }
                if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
                {
                    btnOuthspReg.Enabled = true;
                    btnIhspChange.Enabled = true;
                    btnInUpAudit.Enabled = true;
                    btnTopLine.Enabled = true;
                }
            }
            else
            {
                cmbPatienttype.Text="自费";
              
                btnReCost.Enabled = false;
                btnDelete.Enabled = false;
                btnTopLine.Enabled = false;
            }
        }

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuthspReg_Click(object sender, EventArgs e)
        {
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                int flag = bllInsur.outhspMag(ihspcode, ihspid);
                if (flag == -1)
                {
                    MessageBox.Show("更新住院医保接口状态失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -2)
                {
                    MessageBox.Show("医保数据传输失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("出院时间不能为空!", "提示信息");
                    this.Close();
                }
            }
            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                FrmGzsnhOhsp frmGzsnhOhsp = new FrmGzsnhOhsp();
                frmGzsnhOhsp.Ihsp_id = ihspid;
                frmGzsnhOhsp.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
            {
                FrmOutHspReg frmOutHspReg = new FrmOutHspReg();
                frmOutHspReg.Ihspid = ihspid;
                frmOutHspReg.ShowDialog();
            }
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                BllSnhMethod bllSnhMethod = new BllSnhMethod();
                StringBuilder returnMsg = new StringBuilder();
                int flag = bllSnhMethod.ohspReg(ihspid, returnMsg);
                MessageBox.Show(returnMsg.ToString(), "提示信息");
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                int flag = bllHdsch.outhspMag(ihspcode, ihspid);
                if (flag == -1)
                {
                    MessageBox.Show("更新住院医保接口状态失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -2)
                {
                    MessageBox.Show("医保数据传输失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("出院时间不能为空!", "提示信息");
                    this.Close();
                }

            }
           
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                BllInHspMedinsrHDSSY bllInHspMedinsrHDSSY = new BllInHspMedinsrHDSSY();
                int flag = bllInHspMedinsrHDSSY.outhspMag(ihspcode, ihspid);
                if (flag == -1)
                {
                    MessageBox.Show("更新住院医保接口状态失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -2)
                {
                    MessageBox.Show("医保数据传输失败!", "提示信息");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("出院时间不能为空!", "提示信息");
                    this.Close();
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.SIGN.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("修改医保状态失败");
                    return;
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDXZRNH.ToString())
            {

            }
            
            else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())//不使用
            {

            }
            else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            { 
                /*
                BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
                DataTable dt = bllInsurGYSYB.getInsurstat(ihspid);
                StringBuilder message = new StringBuilder();
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0][0].ToString() == Insurstat.SETT.ToString())
                    {
                        if (!bllInsurGYSYB.Cydj(ihspid, message))
                        {
                            MessageBox.Show("医保接口出院办理失败！");
                            return;
                        }
                    }
                }
                */ 
            }
            else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            {
                FrmIhspOutGZS frmIhspOutGZS = new FrmIhspOutGZS();
                this.ihspid = frmIhspOutGZS.Ihspid;
                bool flag = frmIhspOutGZS.Flag;//出院办理成功标志
            }  
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInsurMag_Load(object sender, EventArgs e)
        {
            cmbPatienttype.Enabled = false;
        }
        /// <summary>
        /// 医保转自费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelffee_Click(object sender, EventArgs e)
        {
            int flag;
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                flag = bllInsur.retIhspReg(ihspid);
                if (flag == -2)
                {
                    MessageBox.Show("医保人员基本信息和庄户信息读取失败!");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("此人目前为出院状态，不能做入院登记回退业务操作！");
                    this.Close();
                }
                else if (flag == -4)
                {
                    MessageBox.Show("医保住院回退失败");
                    this.Close();
                }
                flag = billIhspMan.uppatienttype(ihspid, "1");//更新患者类型为自费
                if (flag < 0)
                {
                    MessageBox.Show("更新患者类型失败!");
                    return;
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功！");
                bllInsur.upopstat("XX", ihspid);
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
            {
                BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
                StringBuilder mesage=new StringBuilder();
                flag=bllAhsnhMethod.retIhsp(ihspid, mesage);
                if (flag == -1)
                {
                    MessageBox.Show(mesage.ToString(),"提示信息");
                    return;
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功！");
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                StringBuilder mesage = new StringBuilder();
                bool type=bllGzsnhMethod.cancelIhspReg(ihspid, mesage);
                if (!type)
                {
                    MessageBox.Show(mesage.ToString(), "提示信息");
                    return;
                }
                flag=bllGzsnhMethod.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功！");
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                BllSnhMethod bllSnhMethod = new BllSnhMethod();
                StringBuilder rtmessage = new StringBuilder();
                flag = bllSnhMethod.retihsp(ihspid, rtmessage);
                if (flag == -1)
                {
                    MessageBox.Show(rtmessage.ToString());
                    return;
                }
                flag = billIhspMan.uppatienttype(ihspid, "1");//更新患者类型为自费
                if (flag < 0)
                {
                    MessageBox.Show("更新患者类型失败!");
                    return;
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功!");
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                flag = bllHdsch.retIhspReg(ihspid);
                if (flag == -2)
                {
                    MessageBox.Show("医保人员基本信息和庄户信息读取失败!");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("此人目前为出院状态，不能做入院登记回退业务操作！");
                    this.Close();
                }
                else if (flag == -4)
                {
                    MessageBox.Show("医保住院回退失败");
                    this.Close();
                }
                flag = billIhspMan.uppatienttype(ihspid, "1");//更新患者类型为自费
                if (flag < 0)
                {
                    MessageBox.Show("更新患者类型失败!");
                    return;
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功！");
                bllInsur.upopstat("XX", ihspid);
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.HDXBHNH.ToString())
            {
                BllMedinsrXBH bllMedinsrXBH = new BllMedinsrXBH();
                flag = bllMedinsrXBH.turnSelfFee(ihspid, ihspcode);
                if (flag == 0)
                {
                    MessageBox.Show("转自费成功！");
                }
                else if (flag == -1)
                {
                    MessageBox.Show("转自费失败！");
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                BllInHspMedinsrHDSSY bllInHspMedinsrHDSSY = new BllInHspMedinsrHDSSY();
                flag = bllInHspMedinsrHDSSY.retIhspReg(ihspid);
                if (flag == -2)
                {
                    MessageBox.Show("医保人员基本信息和账户信息读取失败!");
                    this.Close();
                }
                else if (flag == -3)
                {
                    MessageBox.Show("此人目前为出院状态，不能做入院登记回退业务操作！");
                    this.Close();
                }
                else if (flag == -4)
                {
                    MessageBox.Show("医保转自费失败");
                    this.Close();
                }
                flag = billIhspMan.uppatienttype(ihspid, "1");//更新患者类型为自费
                if (flag < 0)
                {
                    MessageBox.Show("更新患者类型失败!");
                    return;
                }
                flag = billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                if (flag < 0)
                {
                    MessageBox.Show("更新医保状态失败!");
                    return;
                }
                MessageBox.Show("转自费成功！");
                bllInsur.upopstat("XX", ihspid);
                this.Close();

            }
            else if (keyname == CostInsurtypeKeyname.HDXZRNH.ToString())
            {

            }
           
            else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())
            {
                BllIhspMedinsrHSDR bllIhspMedinsrHSDR = new BllIhspMedinsrHSDR();
                int value = bllIhspMedinsrHSDR.deleteKC22Insur(ihspid);
                if (value == 0)
                {
                    MessageBox.Show("转自费成功！");
                }
                else if (value == 1)
                {
                    MessageBox.Show("转自费成功，中间库删除失败！");
                }
                else if (value == -1)
                {
                    MessageBox.Show("转自费失败！");
                }
            }
            else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            {
                BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
                if (bllInsurIhspGZS.retIhspReg(ihspid))
                {
                    MessageBox.Show("转自费成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("转自费失败！");
                    this.Close();
                }
            }
            #region 云南省医保
            else if (keyname == CostInsurtypeKeyname.YNSYB.ToString())
            {

            }
            #endregion
            else if (keyname == CostInsurtypeKeyname.YNYDYB.ToString())
            {
                //获取异地医保持卡人的个人基本信息和账户信息
                Dkcx_out dkcx_out1 = new Dkcx_out();
                YNYDYB ynydyb = new YNYDYB();
                int opt_dkcx = ynydyb.dkcx(dkcx_out1);
                if (opt_dkcx != 0)
                {
                    MessageBox.Show(dkcx_out1.ErrorMessage + ", 获取异地医保持卡人的个人基本信息和账户信息失败！", "提示信息");
                    return;
                }
                YNYDYB ynydyb_ydczjy = new YNYDYB();
                Hqfsflsh_out hqfsflsh_out_ydczjy = new Hqfsflsh_out();
                int opt_hqjslsh_wfty = ynydyb_ydczjy.hqfsflsh(hqfsflsh_out_ydczjy);
                if (opt_hqjslsh_wfty != 0)
                {
                    MessageBox.Show(hqfsflsh_out_ydczjy.ErrorMessage + ", 异地医保--获取【无费退院】发送方交易流水号失败！", "错误信息");
                    return;
                }

                YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                YdCzjy_out ydCzjy_out1 = new YdCzjy_out();
                BllYnydybMethod bllYnydybMethod = new BllYnydybMethod();
                DataTable dtReg = bllYnydybMethod.readIhspRegInfo(ihspid);//记录的医保信息
                ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydczjy.Swqjwyzym;
                ydCzjy_in1.Hzcbdtcqbh = dtReg.Rows[0]["InsuredAreaNo"].ToString();
                ydCzjy_in1.Hzgrbh = dtReg.Rows[0]["PersonNo"].ToString();
                ydCzjy_in1.Hzybkh = dtReg.Rows[0]["SICardNo"].ToString();
                ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                ydCzjy_in1.Yjym = "11";
                ydCzjy_in1.Yfsfjylsh = dtReg.Rows[0]["SenderSerialNo"].ToString();
                StringBuilder jsfjylsh_ydczjy = new StringBuilder(2048);
                int opstat = ynydyb_ydczjy.ydczjy(jsfjylsh_ydczjy, ydCzjy_in1, ydCzjy_out1);
                if (opstat != 0)
                {
                    MessageBox.Show("异地医保--【登记冲正交易】失败:" + ydCzjy_out1.ErrorMessage, "错误信息");
                    return;
                }

                bllYnydybMethod.upopstat("XX", ihspid);
                bllYnydybMethod.upinsurstat("OO", ihspid);//住院医保状态
                MessageBox.Show("登记冲正交易成功！");
                this.Close();
            }
            else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            {
                MessageBox.Show("请选择自己的医保类型!");
                return;
            }
        }

     

        /// <summary>
        /// 住院变动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspChange_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 费用删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int flag;
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            #region 邯郸医保
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                Ybjk ybjk=new Ybjk();
                //删除医保费用                
                if (ihspcode == null || ihspcode == "")
                {
                    MessageBox.Show("住院号为空，不允许删除费用", "提示信息");
                    return;
                }
                string mes = "确定删除[住院号:" + ihspcode + "]的费用吗?";
                if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
                DataTable dataTable =bllInsur.readRegInfo(ihspid);
                string info1 = "";
                string inspkind = bllInsur.aka130Keyname(dataTable.Rows[0]["Ihsptype"].ToString());
                if (inspkind == "NZJS")
                {
                    info1 = dataTable.Rows[0]["midsettinfo"].ToString();
                }
                else
                {
                    info1 = dataTable.Rows[0]["settinfo"].ToString();
                }
                string[] message1 = info1.Split('|');////经办人|账户支付金额|单据号
                Sccwsj_in sccwsj_in = new Sccwsj_in();
                sccwsj_in.Mzzyh = ihspcode;//
                sccwsj_in.Djh = message1[2];//
                int opt = ybjk.sccysj(sccwsj_in);
                if (opt != 0)
                {
                    MessageBox.Show(sccwsj_in.Message + ",调用医保API删除错误数据失败！", "提示信息");
                    return;
                }
                //删除kc22数据
                string sql = "delete from KC22 where AKC190='" + ihspcode + "'";
                flag = BllMain.InsurDb.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("删除费用失败！");
                    return;
                }
                MessageBox.Show("删除费用成功！");
                string upsql = "update ihsp_costdet set insursync='N' where ihsp_id=" + DataTool.addFieldBraces(ihspid) + ";";
                flag = BllMain.Db.Update(upsql);
                if (flag < 0)
                {
                    MessageBox.Show("His医保传输状态更新失败!", "错误信息");
                    return;
                }
                MessageBox.Show("删除费用成功！");
                this.Close();
            }
            #endregion

            #region 邯郸市城合
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                Hdsch hdsch = new Hdsch();
                //删除医保费用                
                if (ihspcode == null || ihspcode == "")
                {
                    MessageBox.Show("住院号为空，不允许删除费用", "提示信息");
                    return;
                }
                string mes = "确定删除[住院号:" + ihspcode + "]的费用吗?";
                if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                DataTable dataTable = bllInsur.hdybinfo(ihspid);
                string info = dataTable.Rows[0]["registinfo"].ToString();
                string[] message = info.Split('|');//个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
                string info1 = "";
                string inspkind = bllInsur.aka130Keyname(message[4]);
                if (inspkind == "NZJS")
                {
                    info1 = dataTable.Rows[0]["midsettinfo"].ToString();
                }
                else
                {
                    info1 = dataTable.Rows[0]["settinfo"].ToString();
                }
                string[] message1 = info1.Split('|');////经办人|账户支付金额|单据号
                Sccwsj_in sccwsj_in = new Sccwsj_in();
                sccwsj_in.Mzzyh = ihspcode;//
                sccwsj_in.Djh = message1[2];//
                int opt = hdsch.sccysj(sccwsj_in, message[0]);
                if (opt != 0)
                {
                    MessageBox.Show(sccwsj_in.Message + ",调用医保API删除错误数据失败！", "提示信息");
                    return;
                }
                //删除kc22数据
                string sql = "delete from KC22 where AKC190='" + ihspcode + "'";
                flag = BllMain.InsurDb.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("删除费用失败！");
                    return;
                }                
                string upsql = "update ihsp_costdet set insursync='N' where ihsp_id=" + DataTool.addFieldBraces(ihspid) + ";";
                flag = BllMain.Db.Update(upsql);
                if (flag < 0)
                {
                    MessageBox.Show("His医保传输状态更新失败!", "错误信息");
                    return;
                }
                MessageBox.Show("删除费用成功！");
                this.Close();
            }
            #endregion 

            #region 安徽市级农合
            else if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
            {
                BllAhsnhMethod bllAhsnhMethod = new BllAhsnhMethod();
                In_InpatientFeeCancelAll inp = new In_InpatientFeeCancelAll();
                //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
                RegInfo regInfo = bllAhsnhMethod.readRegInfo(ihspid);               
                inp.Weburl=regInfo.Weburl;
                inp.SHospitalCode = regInfo.SHospitalCode;
                inp.SAreaCode = regInfo.SAreaCode;
                inp.SInpatientID = regInfo.SInpatientID;
                retMesage ret=bllAhsnhMethod.inpatientFeeCancelAll(inp);
                if (!ret.Ret_flag)
                {
                    MessageBox.Show(ret.Ret_mesg,"提示信息");
                    return;
                }
                MessageBox.Show("安徽市级农合退费成功!", "提示信息");
                this.Close();
            }
            #endregion

            #region 邯郸中软农合
            else if (keyname == CostInsurtypeKeyname.HDZRNH.ToString())
            {

            }
            #endregion

            #region 邯郸北航农合
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                string[] param = new string[3];
                param[0] = ihspcode;//农合住院号
                SczyjzXml sczyjzXml = new SczyjzXml();
                BllSnhMethod bllSnhMethod = new BllSnhMethod();
                //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
                HdsbhRegInfo hdsbhRegInfo = bllSnhMethod.readRegInfo(ihspid);
                BhnhReturn retdata = sczyjzXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, param);
                if (!retdata.Ret_flag)
                {
                    MessageBox.Show(retdata.Ret_mesg, "提示信息");
                    return;
                }
                //解析返回的xml
                System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
                {
                    MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                    return;
                }
                string sql = "update ihsp_costdet set insursync='N' where ihsp_id =" + DataTool.addFieldBraces(ihspid);
                flag = BllMain.Db.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("修改传输状态失败！", "提示信息");
                    return;
                }
                MessageBox.Show("删除成功！", "提示信息");
                this.Close();
            }
            #endregion

            #region 衡水武邑县医保
            else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())
            {
                BllIhspMedinsrHSDR bllIhspMedinsrHSDR = new BllIhspMedinsrHSDR();
                int value = bllIhspMedinsrHSDR.deleteKC22Insur(ihspid);
                if (value == 0)
                {
                    MessageBox.Show("删除数据成功！");
                }
                else if (value == 1)
                {
                    MessageBox.Show("数据删除接口调用成功，SQL执行失败！");
                }
                else if (value == -1)
                {
                    MessageBox.Show("数据删除失败！");
                }
            }
            #endregion

            #region 贵州省农合
            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                WebClient webClient = new WebClient();
                //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
                GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
                gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihspid);
                string url = GzsnhGlobal.Url + "inpCancelFee?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "";
                string sql = "";
                try
                {
                    string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
                    if (Base64.decodebase64(param.Split(',')[0]) != "1")
                    {
                        MessageBox.Show("撤销失败"); return;
                    }
                    DataTable dt_costid= bllGzsnhMethod.getCostdetId(ihspid);
                    for(int m=0;m<dt_costid.Rows.Count;m++)
                    {
                        sql += bllGzsnhMethod.upcostState(dt_costid.Rows[m]["id"].ToString(), "N");
                        sql += bllGzsnhMethod.detInsurCostdet(dt_costid.Rows[m]["id"].ToString());
                    }
                    int i = BllMain.Db.Update(sql);
                    if (i < 0)
                    {
                        MessageBox.Show("数据库更新失败");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //Log4Net.error(Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")) + "项目名称：" + dtyp.Rows[i]["name"].ToString() + "项目编码：" + dtyp.Rows[i]["iid"].ToString());
                    MessageBox.Show(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                    return;
                }
                MessageBox.Show("成功！");
                this.Close();
            }
            #endregion

            #region 云南省医保
            else if (keyname == CostInsurtypeKeyname.YNSYB.ToString())
            {
                if (ihspcode == null || ihspcode == "")
                {
                    MessageBox.Show("住院号为空，不允许删除费用", "提示信息");
                    return;
                }
                BllIhspInsurYNSYB bllIhspInsurYNSYB = new BllIhspInsurYNSYB();
                int ops = bllIhspInsurYNSYB.deleteRcp(ihspid);
            }
            #endregion

            #region 云南异地医保
            else if (keyname == CostInsurtypeKeyname.YNYDYB.ToString())
            {
                YNYDYB ynydyb = new YNYDYB();
                BllYnydybMethod bllYnydybMethod=new BllYnydybMethod();
                Hqfsflsh_out hqfsflsh_out_ydwjscfplsc = new Hqfsflsh_out();
                int opt_hqjslsh = ynydyb.hqfsflsh(hqfsflsh_out_ydwjscfplsc);
                if (opt_hqjslsh != 0)
                {
                    MessageBox.Show(hqfsflsh_out_ydwjscfplsc.ErrorMessage + ", 异地医保--获取【未结算处方批量删除】发送方交易流水号失败！", "错误信息");
                    return;
                }

                YdWjscfplsc_in ydWjscfplsc_in1 = new YdWjscfplsc_in();
                YdWjscfplsc_out ydWjscfplsc_out1 = new YdWjscfplsc_out();
                DataTable dtInsur=bllYnydybMethod.readIhspRegInfo(ihspid);
                ydWjscfplsc_in1.Fsfjylsh = hqfsflsh_out_ydwjscfplsc.Swqjwyzym;
                ydWjscfplsc_in1.Hzcbdtcqbh = dtInsur.Rows[0]["SenderSerialNo"].ToString();
                ydWjscfplsc_in1.Hzgrbh = dtInsur.Rows[0]["PersonNo"].ToString();
                ydWjscfplsc_in1.Hzybkh = dtInsur.Rows[0]["SICardNo"].ToString();
                ydWjscfplsc_in1.Czybh = ProgramGlobal.User_id;
                ydWjscfplsc_in1.Ywzqh = ynydybGlobal.Ywzqh;

                ydWjscfplsc_in1.Zyh = dtInsur.Rows[0]["AKC190"].ToString();

                StringBuilder jsfjylsh_ydwjscfplsc = new StringBuilder(2048);
                int opstat_ydwjscfplsc = ynydyb.ydwjscfplsc(jsfjylsh_ydwjscfplsc, ydWjscfplsc_in1, ydWjscfplsc_out1);
                if (opstat_ydwjscfplsc != 0)
                {
                    MessageBox.Show("异地医保--【未结算处方批量】删除失败:" + ydWjscfplsc_out1.ErrorMessage, "错误信息");
                    return;
                }
                flag = bllYnydybMethod.cancelIhspCostdet(ihspid);
                if (flag < 0)
                {
                    MessageBox.Show("His医保传输状态更新失败!","错误信息");
                    return;
                }
                MessageBox.Show("删除成功!");
                this.Close();
            }
            #endregion

            #region 贵州省医保
            if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            {
                BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
                if (bllInsurIhspGZS.deleteIhspcostItem(ihspid))
                {
                    MessageBox.Show("批量删除费用成功");
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// 费用重传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReCost_Click(object sender, EventArgs e)
        {
            int flag;
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());

            #region 邯郸医保
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                StringBuilder returnMsg = new StringBuilder();
                bllInsur.costTransfer(ihspid, cmbPatienttype.SelectedValue.ToString(), returnMsg);
                if (returnMsg.ToString() != "")
                {
                    MessageBox.Show(returnMsg.ToString(), "提示信息!");
                }
            }
            #endregion

            #region 邯郸市城合
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                StringBuilder returnMsg = new StringBuilder();               
                bllHdsch.hdschcostTransfer(ihspid, cmbPatienttype.SelectedValue.ToString(), returnMsg);
                if (returnMsg.ToString() != "")
                {
                    MessageBox.Show(returnMsg.ToString());
                    return;
                }
            }
            #endregion

            #region 邯郸中软农合
            else if (keyname == CostInsurtypeKeyname.HDZRNH.ToString())
            {

            }
            #endregion

            #region 邯郸市北航农合
            else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            {
                BllSnhMethod bllSnhMethod = new BllSnhMethod();
                //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
                HdsbhRegInfo hdsbhRegInfo = bllSnhMethod.readRegInfo(ihspid);
                ZyjzXml zyjzXml = new ZyjzXml();
                BhnhReturn retdata = zyjzXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, ihspid, cmbPatienttype.SelectedValue.ToString());
                if (!retdata.Ret_flag)
                {
                    MessageBox.Show("失败信息" + retdata.Ret_mesg, "提示信息");
                    return;
                }
                MessageBox.Show("上传完毕", "提示信息");
            }
            #endregion

            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            {
                costTransfer(ihspid);
            }

        }
        /// <summary>
        /// 贵州省新农合费用录入
        /// </summary>
        /// <returns></returns>
        public void costTransfer(string ihsp_id)
        {
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();

            DataTable det = null;
            //获取姓名
            string sql = "select name from inhospital where id=" + DataTool.addIntBraces(ihsp_id);
            string name = BllMain.Db.Select(sql).Tables[0].Rows[0]["name"].ToString();

            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);

            string paramc = "";
            for (int j = 0; j < det.Rows.Count; j++)
            {
                if (j != 0)
                    paramc += ",";
                paramc += "{\"hisDetailCode\":\"" + Base64.encodebase64(det.Rows[j]["iid"].ToString()) + "\",\"hisMedicineCode\":\"" + Base64.encodebase64(det.Rows[j]["mtprod"].ToString()) + "\",\"medicineCode\":\"" + Base64.encodebase64(det.Rows[j]["nhbm"].ToString()) + "\",\"medicineName\":\"" + Base64.encodebase64(det.Rows[j]["xmmc"].ToString()) + "\",\"spec\":\"" + Base64.encodebase64(det.Rows[j]["guige"].ToString()) + "\",\"conf\":\"" + Base64.encodebase64(det.Rows[j]["prodjixing"].ToString()) + "\",\"unit\":\"" + Base64.encodebase64(det.Rows[j]["uom"].ToString()) + "\",\"price\":\"" + Base64.encodebase64(det.Rows[j]["prc"].ToString()) + "\",\"quantity\":\"" + Base64.encodebase64(det.Rows[j]["qty"].ToString()) + "\",\"useDate\":\"" + Base64.encodebase64(det.Rows[j]["createdat"].ToString()) + "\"}";
                if (j % 100 == 0 && j != 0)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(gzsnhRegInfo.BookNo) + "\",\"name\":\"" + Base64.encodebase64(name) + "\",\"familyNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Familysysno) + "\",\"memberNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Membersysno) + "\",\"inpatientSn\":\"" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "\",\"rows\":\"" + Base64.encodebase64("100") + "\",\"InpatientDetailList\":[";
                    int a = bllGzsnhMethod.fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                        if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
                            break;
                    }
                }
                else if (j == det.Rows.Count - 1)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(gzsnhRegInfo.BookNo) + "\",\"name\":\"" + Base64.encodebase64(name) + "\",\"familyNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Familysysno) + "\",\"memberNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Membersysno) + "\",\"inpatientSn\":\"" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "\",\"rows\":\"" + Base64.encodebase64((det.Rows.Count % 100).ToString()) + "\",\"InpatientDetailList\":[";
                    int a = bllGzsnhMethod.fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                        if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
                            break;
                    }
                }
            }
            MessageBox.Show("操作成功");
        }

        /// <summary>
        /// 转诊单管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTruncode_Click(object sender, EventArgs e)
        {
            FrmTruncode frmTruncode = new FrmTruncode();
            frmTruncode.ShowDialog();
        }

        private void btnInUpAudit_Click(object sender, EventArgs e)
        {
            FrmAudit frmAudit = new FrmAudit();
            frmAudit.ShowDialog();
        }

        private void btnTopLine_Click(object sender, EventArgs e)
        {
            FrmGetTopLine frmGetTopLine = new FrmGetTopLine();
            frmGetTopLine.ShowDialog();
        }

        private void btnRetOutHsp_Click(object sender, EventArgs e)
        {
             string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
             if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
             {
                 //FrmIhspOutRetGZS frmIhspOutRetGZS = new FrmIhspOutRetGZS();
                 //this.ihspid = frmIhspOutRetGZS.Ihspid;
                 //bool flag = frmIhspOutRetGZS.Flag;//出院办理成功标志
                 BllInsurIhspGZS bllInsurIhsp = new BllInsurIhspGZS();
                 bool sign = bllInsurIhsp.retIhspOut(ihspid);
                 if (sign)
                 {
                     MessageBox.Show("出院医保办理成功！");
                     this.Dispose();
                     return;
                 }
                 else
                 {
                     MessageBox.Show("出院医保办理失败！");
                     this.Dispose();
                     return;
                 }
             }
        }

        private void print_Click(object sender, EventArgs e)
        {
            BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
            bllInsurIhspGZS.printIhspSettle(ihspid);
        } 
    }
}
