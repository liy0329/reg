using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.gzsyb.bo;
using System.Windows.Forms;
using MTREG.common;

namespace MTREG.medinsur.gzsyb.bll
{
    class BllClinicMedinsrGZS
    {
        GzsybInterface gzsybInterface = new GzsybInterface();
        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <returns></returns>
        public DataTable getPatientType()
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name from bas_patienttype";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        public DataTable getIcd(string where)
        {
            string sql = "";
            return BllMain.Db.Select(sql).Tables[0];
        }
      

        /// <summary>
        /// 获取医保结算信息
        /// </summary>
        /// <param name="invoice_id"></param>
        /// <returns></returns>
        public DataTable getReFund(string invoice_id)
        {
            string sql = "select "
                            +"akc190"// 就诊编号    
                            +",yab003"//分中心编号  
                            +",aka130"//支付类别    
                            +",yka103"//结算编号    
                            +",ykb065"//社会保险办法
                            +",aac001"//个人编号    
                            + " from gzsyb_mzfyb"
                            + " where mtmzblstuffiid=" + DataTool.addIntBraces(invoice_id);
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 门诊退结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool reFund(string invoiceId)
        {
            string currtime = BillSysBase.currDate();
          
            DataTable dt = getReFund(invoiceId);
  
            String[] param = new String[10];
            param[0] = dt.Rows[0]["akc190"].ToString();//就诊编号
            param[1] = dt.Rows[0]["yab003"].ToString();//分中心编号
            param[2] = dt.Rows[0]["aka130"].ToString();//支付类别
            param[3] = dt.Rows[0]["yka103"].ToString();//结算编号(原始结算编号)
            param[4] = ProgramGlobal.User_id;//经办人员编码
            param[5] = ProgramGlobal.Username;//经人人姓名
            param[6] = currtime;//经办时间
            param[7] = "不详";//退费原因
            param[8] = dt.Rows[0]["ykb065"].ToString(); ;//社会保险办法
            param[9] = dt.Rows[0]["aac001"].ToString(); ;//个人编号
            SettleBack ihhk = new SettleBack();
            //调用交易函数
            Call_in callIn = new Call_in();
            callIn.AstrJybh = "42";//交易编号
            callIn.Astr_jysr_xml = ihhk.xmlCode_head() + ihhk.xmlCode_in(param);//交易输入
            Call_out callOut = gzsybInterface.Call(callIn);
            if (callOut.Aintappcode < 0)
            {
                MessageBox.Show(callOut.Astrappms, "错误信息");
                return false;
            }
            //交易成功
            string sql_upd = "update gzsyb_mzfyb set mztfr=" +DataTool.addFieldBraces( ProgramGlobal.Username)
                + ",mztfsj=" + DataTool.addFieldBraces(BillSysBase.currDate())
                + ",retastrjylsh=" + DataTool.addFieldBraces(callOut.Astrjylsh)
                + ",retastrjyyzm=" + DataTool.addFieldBraces(callOut.Astrjyyzm) 
                + " where mtmzblstuffiid='" + invoiceId + "';";
            if (BllMain.Db.Update(sql_upd) == -1)
            {
                MessageBox.Show("数据库错误", "错误信息");
                Cancel_in cancelIn = new Cancel_in();
                cancelIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
                if (cancelOut.AintAppcode < 0)
                {
                    MessageBox.Show(cancelOut.AstrAppmsg, "错误信息");
                }
                MessageBox.Show("结算回退失败！", "提示信息");
                return false;
            }
            else
            {
                Confirm_in confirmIn = new Confirm_in();
                confirmIn.Astrjylsh = callOut.Astrjylsh;//交易流水号
                confirmIn.Astrjyyzm = callOut.Astrjyyzm;//交易验证码
                Confirm_out confirmOut = gzsybInterface.Confirm(confirmIn);
                if (confirmOut.AintAppcode < 0)
                {
                  string sql_confirm=  "update gzsyb_mzfyb set ybretflag=2 where  mtmzblstuffiid='" + invoiceId + "';";
                  BllMain.Db.Update(sql_confirm);
                    MessageBox.Show(confirmOut.AstrAppmsg, "错误信息");
                    return false;
                }
                MessageBox.Show("结算回退成功！", "提示消息");
            }
        
            return true;
        }

        /// <summary>
        /// 获取医保结算信息
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <returns></returns>
        public DataTable getSettinfo(string register_id)
        {
            string infosql = "select settinfo,registinfo from clinic_insurinfo where register_id=" + DataTool.addFieldBraces(register_id);
            DataTable dt = BllMain.Db.Select(infosql).Tables[0];
            return dt;
        }

        public bool doCancleCharege(string astrjylsh, string invoice_id)
        {
            Cancel_in cancelIn = new Cancel_in();
            cancelIn.Astrjylsh = astrjylsh;//交易流水号
            Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
            if (cancelOut.AintAppcode < 0)
            {

                string sql_confirm = "update gzsyb_mzfyb set ybflag=0 where  mtmzblstuffiid='" + invoice_id + "';";
                BllMain.Db.Update(sql_confirm);
                return false;
            }
            return true;
        }
        public bool doCancleRetCharege(string astrjylsh, string invoice_id)
        {
            Cancel_in cancelIn = new Cancel_in();
            cancelIn.Astrjylsh = astrjylsh;//交易流水号
            Cancel_out cancelOut = gzsybInterface.Cancel(cancelIn);
            if (cancelOut.AintAppcode < 0)
            {

                string sql_confirm = "update gzsyb_mzfyb set ybretflag=0 where  mtmzblstuffiid='" + invoice_id + "';";
                BllMain.Db.Update(sql_confirm);
                return false;
            }
            return true;
        }
       
    }
}
