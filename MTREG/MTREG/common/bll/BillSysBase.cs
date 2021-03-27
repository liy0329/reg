using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using System.Windows.Forms;
using MTREG.common.bll;
using MTREG.clinic.bo;

namespace MTREG.common
{
    class BillSysBase
    {


        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static bool doIhspAmt(string ihsp_id)
        {

            DataTable dt = new DataTable();
            bool ret = true;
            String sql = "CALL doIhspAmt(" + DataTool.addIntBraces(ihsp_id) + ")";
            try
            {
                BllMain.Db.Update(sql);
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }

        

        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static List<string> currInvoice(string chargeBy, string ip, string invoicekindId, string needCount)
        {
            DataTable dt = new DataTable();
            List<string> invoices = new List<string>();
            String sql = "CALL currInvoice(" + DataTool.addIntBraces(chargeBy) + "," + DataTool.addFieldBraces(ip) + "," + DataTool.addIntBraces(invoicekindId) + "," + DataTool.addIntBraces(needCount) + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string invoicebill = dt.Rows[0]["prefix"].ToString() + dt.Rows[0]["currnum"].ToString() + dt.Rows[0]["postfix"].ToString();
                    invoices.Add(invoicebill);
                }
            }
            catch (Exception e)
            {

            }
            return invoices;
        }

        
        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static List<string> nextInvoice(string chargeBy, String ip, string invoicekindId, string needCount)
        {
            DataTable dt = new DataTable();
            List<string> invoices = new List<string>();
            String sql = "CALL nextInvoice(" + DataTool.addIntBraces(chargeBy) + "," + DataTool.addFieldBraces(ip) + "," + DataTool.addIntBraces(invoicekindId) + "," + DataTool.addIntBraces(needCount) + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    return null;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string invoicebill = dt.Rows[0]["prefix"].ToString() + dt.Rows[0]["currnum"].ToString() + dt.Rows[0]["postfix"].ToString();
                    invoices.Add(invoicebill);

                }
            }
            catch (Exception e)
            {

            }
            return invoices;
        }

        /// <summary>
        /// 查询剩余发票号
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <param name="charger"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static int getInvoiceNum(string invoicekindId, string chargeBy)
        {
            int ret = 0;
            DataTable dt = new DataTable();
            string sql = "select sum(endnum-currnum+1) as num from sys_invoice where charger = " + DataTool.addFieldBraces(chargeBy)
                + " and sys_invoicekind_id = " + DataTool.addFieldBraces(invoicekindId)
                + " and  started in ('OO', 'ST')";
            dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
                ret = int.Parse(dt.Rows[0]["num"].ToString());
            return ret;
        }
        
        /// <summary>
        /// 取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static int currInvoiceA(string chargeBy, string invoicekindId,int num, ref string invoicecode, ref string nextinvoicesql)
        {

           int invoiceNum=0;
            DataTable dt1 = new DataTable();
            string sql1 = "select sum(endnum-currnum+1) as num from sys_invoice where charger = " + DataTool.addFieldBraces(chargeBy)
                + " and sys_invoicekind_id = " + DataTool.addFieldBraces(invoicekindId)
                + " and  started in ('OO', 'ST')";
            dt1 = BllMain.Db.Select(sql1).Tables[0];
            try
            {

                invoiceNum = int.Parse(dt1.Rows[0]["num"].ToString());
            }
            catch (Exception e)
            {
                invoiceNum = 0;
                return invoiceNum;
            }

            List<string> invoices = new List<string>();
            string sql = "SELECT currnum,endnum,id,postfix, prefix,started  from sys_invoice "
            +"WHERE " 
            +" sys_invoicekind_id="+DataTool.addFieldBraces(invoicekindId)
            +" and charger ="+DataTool.addFieldBraces( chargeBy)
            +" and started in ('OO','ST') order by issuedate";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string currnum = dt.Rows[i]["currnum"].ToString();
                string endnum = dt.Rows[i]["endnum"].ToString();
                string id = dt.Rows[i]["id"].ToString();
                string postfix = dt.Rows[i]["postfix"].ToString();
                string prefix = dt.Rows[i]["prefix"].ToString();
                string started = dt.Rows[i]["started"].ToString();
               int int_currnum = DataTool.stringToInt(currnum);
                int int_endnum = DataTool.stringToInt(endnum);
                if(int_currnum<int_endnum)
                {
                     
                    invoicecode = prefix+currnum+postfix;
                    if (!started.Trim().Equals("OO"))
                        nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1 where id=" + DataTool.addFieldBraces(id) + ";";
                    else
                        nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'ST' where id=" + DataTool.addFieldBraces(id) + ";";
                    
                    break;
                }
                else if (int_currnum == int_endnum)
                {
                    invoicecode = prefix + currnum + postfix;
                    nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'EN' where id=" + DataTool.addFieldBraces(id) + ";";
                  
                    break;
                }
            }
            return invoiceNum;
        }

        /// <summary>
        /// 取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static int currInvoiceB(string chargeBy, string invoicekindId, List<ClinicInvoice> clinicinvoices)
        {
            //int num = clinicinvoices.Count;//1
            int num = 1;
            int invoiceNum = 0;
            DataTable dt1 = new DataTable();
            string sql1 = "select COALESCE(sum(endnum-currnum+1),0) as num from sys_invoice where charger = " + DataTool.addFieldBraces(chargeBy)
                + " and sys_invoicekind_id =  " + DataTool.addFieldBraces(invoicekindId)
                + " and  started in ('OO', 'ST')";
            dt1 = BllMain.Db.Select(sql1).Tables[0];
            try
            {

                invoiceNum = int.Parse(dt1.Rows[0]["num"].ToString()) - num;
            }
            catch (Exception ex)
            {
               
                invoiceNum = 0;
                return invoiceNum;
            }
            if (invoiceNum <= 0)
            {
                return invoiceNum=0;
            }

            List<string> invoices = new List<string>();
            string sql = "SELECT currnum,endnum,id,postfix, prefix,started  from sys_invoice "
            + "WHERE "
            + " sys_invoicekind_id=" + DataTool.addFieldBraces(invoicekindId)
            + " and charger =" + DataTool.addFieldBraces(chargeBy)
            + " and started in ('OO','ST') order by issuedate";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];

            int i_num = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string currnum = dt.Rows[i]["currnum"].ToString();
                string endnum = dt.Rows[i]["endnum"].ToString();
                string id = dt.Rows[i]["id"].ToString();
                string postfix = dt.Rows[i]["postfix"].ToString();
                string prefix = dt.Rows[i]["prefix"].ToString();
                string started = dt.Rows[i]["started"].ToString();
                int int_currnum = DataTool.stringToInt(currnum);
                int int_endnum = DataTool.stringToInt(endnum);
                string nextinvoicesql="";
                string invoicecode = "";
                while (i_num < clinicinvoices.Count)
                {
                    if (int_currnum < int_endnum)
                    {

                        invoicecode = prefix + int_currnum + postfix;
                        if (!started.Trim().Equals("OO"))
                            nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1 where id=" + DataTool.addFieldBraces(id) + ";";
                        else
                            nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'ST' where id=" + DataTool.addFieldBraces(id) + ";";

                        clinicinvoices[i_num].Invoice = invoicecode;
                        clinicinvoices[i_num].Nextinvoicesql = nextinvoicesql;
                        i_num++;
                        int_currnum++;
                    }
                    else if (int_currnum == int_endnum)
                    {
                        invoicecode = prefix + currnum + postfix;
                        nextinvoicesql = "update sys_invoice set currnum=" + int_currnum + "+1,started = 'EN' where id=" + DataTool.addFieldBraces(id) + ";";
                        clinicinvoices[i_num].Invoice = invoicecode;
                        clinicinvoices[i_num].Nextinvoicesql = nextinvoicesql;
                        i_num++;
                        break;
                    }
                }
                if (i_num == clinicinvoices.Count)
                    break;
              
            }
            return invoiceNum;
        }

        /// <summary>
        /// 取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static bool currInvoice(string chargeBy, string invoicekindId, ref string invoicecode, ref string nextinvoicesql)
        {


            

            List<string> invoices = new List<string>();
            string sql = "SELECT currnum,endnum,id,postfix, prefix,started  from sys_invoice "
            + "WHERE "
            + " sys_invoicekind_id=" + DataTool.addFieldBraces(invoicekindId)
            + " and charger =" + DataTool.addFieldBraces(chargeBy)
            + " and started in ('OO','ST') order by issuedate";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            bool ret = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string currnum = dt.Rows[i]["currnum"].ToString();
                string endnum = dt.Rows[i]["endnum"].ToString();
                string id = dt.Rows[i]["id"].ToString();
                string postfix = dt.Rows[i]["postfix"].ToString();
                string prefix = dt.Rows[i]["prefix"].ToString();
                string started = dt.Rows[i]["started"].ToString();
                int int_currnum = DataTool.stringToInt(currnum);
                int int_endnum = DataTool.stringToInt(endnum);
                if (int_currnum < int_endnum)
                {

                    invoicecode = prefix + currnum + postfix;
                    if (!started.Trim().Equals("OO"))
                        nextinvoicesql = "update sys_invoice set currnum=currnum+1 where id=" + DataTool.addFieldBraces(id) + ";";
                    else
                        nextinvoicesql = "update sys_invoice set currnum=currnum+1,started = 'ST' where id=" + DataTool.addFieldBraces(id) + ";";
                    ret = true;
                    break;
                }
                else if (int_currnum == int_endnum)
                {
                    invoicecode = prefix + currnum + postfix;
                    nextinvoicesql = "update sys_invoice set currnum=currnum+1,started = 'EN' where id=" + DataTool.addFieldBraces(id) + ";";
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// 取发票号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static bool currInvoice(string chargeBy, string invoicekindId, int num, List<string> invoicecodes, List<string> nextinvoicesqls)
        {
            List<string> invoices = new List<string>();
            string sql = "SELECT currnum,endnum,id,postfix, prefix,started  from sys_invoice "
            + "WHERE "
            + " sys_invoicekind_id=" + DataTool.addFieldBraces(invoicekindId)
            + " and charger =" + DataTool.addFieldBraces(chargeBy)
            + " and started in ('OO','ST') order by issuedate";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            bool ret = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string currnum = dt.Rows[i]["currnum"].ToString();
                string endnum = dt.Rows[i]["endnum"].ToString();
                string id = dt.Rows[i]["id"].ToString();
                string postfix = dt.Rows[i]["postfix"].ToString();
                string prefix = dt.Rows[i]["prefix"].ToString();
                string started = dt.Rows[i]["started"].ToString();
                int int_currnum = DataTool.stringToInt(currnum);
                int int_endnum = DataTool.stringToInt(endnum);
                
               // int_currnum++
                if (int_currnum < int_endnum)
                {

                   string invoicecode = prefix + currnum + postfix;
                   string nextinvoicesql ="";
                    if (!started.Trim().Equals("OO"))
                        nextinvoicesql = "update sys_invoice set currnum=" + DataTool.addFieldBraces(int_currnum.ToString()) + "+1 where id=" + DataTool.addFieldBraces(id) + ";";
                    else
                        nextinvoicesql = "update sys_invoice set currnum=" + DataTool.addFieldBraces(int_currnum.ToString()) + "+1, started = 'ST' where id=" + DataTool.addFieldBraces(id) + ";";
                    
                    invoicecodes.Add(invoicecode);
                    nextinvoicesqls.Add(nextinvoicesql);
                    num -= 1;
                    if (num == 0)
                    {
                        return true;
                    }
                    
                }
                else if (int_currnum == int_endnum)
                {
                    //invoicecode = prefix + currnum + postfix;
                    //nextinvoicesql = "update sys_invoice set currnum=currnum+1,started = 'EN' where id=" + DataTool.addFieldBraces(id) + ";";
                    ret = true;
                    break;
                }

            }
            return ret;
        }
        /// <summary> 
        /// 获取当前门诊号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static String currBillcode(String billName)
        {
            DataTable dt = new DataTable();
            String sql = "SELECT currBillNo(" + DataTool.addFieldBraces(billName) + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt.Rows[0][0].ToString();
        }

       
        /// <summary>
        /// 获取门诊号
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static String newBillcode(String billName)
        {
            DataTable dt = new DataTable();
            String sql = "SELECT newBillNo(" + DataTool.addFieldBraces(billName) + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
                  return dt.Rows[0][0].ToString();
              
            }
            catch (Exception e)
            {
                
            }
            return null;
        }

        public static DataTable getDataByDicttype(string dicttype)
        {
            DataTable dt = null;
            string sql = "select sn as id, name from sys_dict where dicttype=" + DataTool.addFieldBraces(dicttype)
                 + " and father_id<>0 and isstop='N' order by ordersn";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception)
            {

                return dt;
            }
            return dt;
        }

        /// <summary>
        /// 获取id值
        /// </summary>
        /// <param name="seqName"></param>
        /// <returns></returns>
        public static String nextId(String seqName)
        {
            DataTable dt = new DataTable();
            String sql = "SELECT NEXTID(" + DataTool.addFieldBraces(seqName) + ")";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                
            }
            return dt.Rows[0][0].ToString();
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static String currDate()
        {
            DataTable dt = new DataTable();
            String sql = "SELECT currDate()";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 控件界面自适应大小 相对于1600*900分辨率
        /// </summary>
        /// <param name="mForm"></param>
        /// <param name="width">1600*900分辨率下的宽</param>
        /// <param name="height">1600*900分辨率下的高</param>
        public static void controlAutoSize(Control mForm)
        {           
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            float wScale = (float)SW/1600;//新旧窗体之间的比例，与最早的旧窗体  
            float hScale = (float)SH /900;//.Height;
            mForm.Width = (int)(mForm.Width * wScale);
            mForm.Height = (int)(mForm.Height * hScale);
            autoScaleControl(mForm, wScale, hScale);
        }
        /// <summary>
        /// 设置控件内的控件  例如panle
        /// </summary>
        /// <param name="control"></param>
        /// <param name="wScale"></param>
        /// <param name="hScale"></param>
        private static void autoScaleControl(Control control, float wScale, float hScale)
        {
            int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    autoScaleControl(c, wScale, hScale);
                }
                c.Left = (int)((c.Left) * wScale);//新旧控件之间的线性比例。
                c.Top = (int)((c.Top) * hScale);//  
                c.Width = (int)(c.Width * wScale);
                c.Height = (int)(c.Height * hScale);//  
                c.Font = new System.Drawing.Font("宋体", (float)(c.Font.Size * hScale), c.Font.Style);
                ctrlNo += 1;
            }
        }
    }

    /// <summary>
    /// 结账方式
    /// </summary>
    public enum Settletype
    {
        /// <summary>
        /// 自动结
        /// </summary>
        AUTO,
        /// <summary>
        ///统一结
        /// </summary>
        UNIFY,
        /// <summary>
        /// 单独结
        /// </summary>
        ALONE,

    };
    /// <summary>
    /// 挂号方式
    /// </summary>
    public enum RegClass
    {
        /// <summary>
        /// 网络挂号
        /// </summary>
        NET,
        /// <summary>
        ///自助机
        /// </summary>
        SELF,
        ///
        /// 窗口挂号
        /// 
        WIN,

    };
    /// <summary>
    ///会员卡状态 
    /// </summary>
    public enum MemberCardStat
    {
        /// <summary>
        ///作废 
        /// </summary>
        XX,
        /// <summary>
        ///未使用
        /// </summary>
        NO,
        /// <summary>
        ///激活 
        /// </summary>
        YES,
        /// <summary>
        /// 挂失
        /// </summary>
        LOSS,
        /// <summary>
        /// 冻结
        /// </summary>
        LOCK,
    };
    /// <summary>
    /// 会员卡钱包操作
    /// </summary>
    public enum MemberRechargeType
    {
        /// <summary>
        /// 充值
        /// </summary>
        RE,
        /// <summary>
        /// 取现
        /// </summary>
        EN,
        /// <summary>
        /// 消费
        /// </summary>
        CO,
    };
    /// <summary>
    /// 计费状态
    /// </summary>
    public enum CostCharged
    {
        /// <summary>
        /// 未计费
        /// </summary>
        OO,
        /// <summary>
        /// 红冲
        /// </summary>
        RREC,
        /// <summary>
        /// 退费
        /// </summary>
        RET,
        /// <summary>
        /// 计费 
        /// </summary>
        CHAR,
    };
    /// <summary>
    /// 门诊处方计费标识
    /// </summary>
    public enum Ischarged
    {
        /// <summary>
        ///是 
        /// </summary>
        Y,
        /// <summary>
        /// 否（默认）
        /// </summary>
        N,
        /// <summary>
        /// 退费
        /// </summary>
        R,
    };
    /// <summary>
    /// 住院状态
    /// </summary>
    public enum IhspStatus
    {
        /// <summary>
        /// 已登记
        /// </summary>
        BREG,
        /// <summary>
        /// 退入院
        /// </summary>
        XX,
        /// <summary>
        /// 已在院
        /// </summary>
        REG,
        /// <summary>
        /// 已挂账
        /// </summary>
        SIGN,
        /// <summary>
        /// 已结算
        /// </summary>
        SETT,
    };

    /// <summary>
    /// 住院入科状态
    /// </summary>
    public enum IhspEnterDep
    {
        /// <summary>
        /// 未接收
        /// </summary>
        OO,
        /// <summary>
        /// 已入科
        /// </summary>
        RECV,
        /// <summary>
        /// 已出科
        /// </summary>
        OUT,

    };
    /// <summary>
    /// 住院归档状态
    /// </summary>
    public enum IhspIsarchive
    {
        /// <summary>
        /// 未接收
        /// </summary>
        OO,
        /// <summary>
        /// 住院
        /// </summary>
        IHSP,
        /// <summary>
        /// 申请归档
        /// </summary>
        APP,
        /// <summary>
        /// 申请召回
        /// </summary>
        RAPP,
        /// <summary>
        /// 已归档
        /// </summary>
        CHK,

    };
    /// <summary>
    /// 住院预付款状态
    /// </summary>
    public enum IhspPayinadvStatus
    {
        /// <summary>
        /// 计费
        /// </summary>
        CHRG,
        /// <summary>
        /// 红冲
        /// </summary>
        RREC,
        /// <summary>
        /// 退费
        /// </summary>
        RET,

    };
    /// <summary>
    /// 住院转科状态
    /// </summary>
    public enum IhspChgDep
    {
        /// <summary>
        /// 转出
        /// </summary>
        TURN,
        /// <summary>
        /// 接收
        /// </summary>
        RECV,
        /// <summary>
        ///   作废
        /// </summary>
        XX,

    };
    /// <summary>
    /// 住院退费申请
    /// </summary>
    public enum IhspRetAppStatus
    {
        /// <summary>
        ///  填单
        /// </summary>
        OO,
        /// <summary>
        /// 申请
        /// </summary>
        APP,
        /// <summary>
        ///  已审核
        /// </summary>
        CHK,
        /// <summary>
        /// 已退费
        /// </summary>
        DO,
        /// <summary>
        /// 已作废
        /// </summary>
        XX,

    };
    /// <summary>
    /// 住院结账状态
    /// </summary>
    public enum IhspAccountStatus
    {
        /// <summary>
        /// 结算
        /// </summary>
        SETT,
        /// <summary>
        ///红冲
        /// </summary>
        RREC,
        /// <summary>
        ///退结算
        /// </summary>
        RET,

    };
    /// <summary>
    /// 住院转诊状态
    /// </summary>
    public enum IhspNetChgIhspStatus
    {
        /// <summary>
        /// 填单
        /// </summary>
        OO,
        /// <summary>
        /// 转出
        /// </summary>
        APP,
        /// <summary>
        /// 接收
        /// </summary>
        RECV,
        /// <summary>
        /// 作废
        /// </summary>
        XX,

    };
    /// <summary>
    /// 住院会诊状态
    /// </summary>
    public enum IhspConsultKind
    {
        /// <summary>
        /// 共享
        /// </summary>
        A,
        /// <summary>
        /// 会诊
        /// </summary>
        B,
        /// <summary>
        /// 远程
        /// </summary>
        C,

    };

    public enum RegisterStatus
    {
        /// <summary>
        /// 未计费
        /// </summary>
        OO,
        /// <summary>
        /// 作废
        /// </summary>
        XX,
        /// <summary>
        /// 挂号
        /// </summary>
        REG,
        /// <summary>
        /// 已接收
        /// </summary>
        RECV,
        /// <summary>
        /// 退号
        /// </summary>
        BACK,
        /// <summary>
        /// 冲退
        /// </summary>
        RUSH
    };
    public enum RegisterIsarchive
    {
        /// <summary>
        /// 未叫号
        /// </summary>
        OO,
        /// <summary>
        /// 已叫号
        /// </summary>
        CALL,
        /// <summary>
        /// 已归档0
        /// </summary>
        RCHIVE
    };
    public enum CostRcpType
    {
        /// <summary>
        ///  挂号
        /// </summary>
        REG,

        /// <summary>
        /// 处方
        /// </summary>
        RCP,

        /// <summary>
        /// 检查
        /// </summary>
        CHK
    };
    public enum BasCostClass
    {
        /// <summary>
        /// 省单价
        /// </summary>
        PROV,
        /// <summary>
        /// 市单价
        /// </summary>
        CITY,
        /// <summary>
        /// 县单价
        /// </summary>
        COUNTY
    };
    /// <summary>
    /// 项目定义类型
    /// </summary>
    public enum BasItemFrom
    {
        /// <summary>
        /// 费用
        /// </summary>
        COST,
        /// <summary>
        /// 药品
        /// </summary>
        DRUG,
        /// <summary>
        /// 信息
        /// </summary>
        MSG,
        /// <summary>
        /// 材料
        /// </summary>
        STUFF

    };

    /// <summary>
    /// 患者类型
    /// </summary>
    public enum CostInsurtypeKeyname
    {
        /// <summary>
        /// 自费
        /// </summary>
        SELFCOST,
        /// <summary>
        /// 邯郸市医保
        /// </summary>
        HDSYB,
        /// <summary>
        /// 邯郸市城合
        /// 
        /// </summary>
        HDSCH,
        /// <summary>
        /// 邯郸北航农合
        /// </summary>
        HDBHNH,
        /// <summary>
        /// 邯郸中软农合
        /// </summary>
        HDZRNH,
        /// <summary>
        /// 邯郸[县]北航农合
        /// </summary>
        HDXBHNH,
        /// <summary>
        /// 邯郸市生育
        /// </summary>
        HDSSY,
        /// <summary>
        /// 邯郸[县]中软农合
        /// </summary>
        HDXZRNH,
        /// <summary>
        /// 衡水武邑县医保
        /// </summary>
        HSDRYB,
        /// <summary>
        /// 贵阳市医保
        /// </summary>
        GYSYB,
        /// <summary>
        /// 贵州省医保
        /// </summary>
        GZSYB,
        /// <summary>
        /// 安徽市级农合
        /// </summary>
        AHSJNH,
        /// <summary>
        /// 云南通海县医保
        /// </summary>
        YNTHXYB,
        /// <summary>
        /// 贵州省农合
        /// </summary>
        GZSNH,
        /// <summary>
        /// 云南省异地医保
        /// </summary>
        YNYDYB,
        /// <summary>
        /// 云南省医保
        /// </summary>
        YNSYB,
        /// <summary>
        /// 石家庄市医保职工
        /// </summary>
        SJZSYB,
        /// <summary>
        /// 石家庄市医保居民
        /// </summary>
        SJZSJM,
        /// <summary>
        /// 工伤保险
        /// </summary>
        GSBX

    };

    /// <summary>
    /// 支付类型
    /// </summary>
    public enum BasPaytypeKeyname
    {
        /// <summary>
        /// 现金
        /// </summary>
        CASHFEE,
        /// <summary>
        /// 医保统筹
        /// </summary>
        INSUREFEE,
        /// <summary>
        /// 商保支付
        /// </summary>
        INSUROTH,
        /// <summary>
        /// 个人自付
        /// </summary>
        SELFFEE,
        /// <summary>
        /// 银联卡
        /// </summary>
        UNIONPAY,
        /// <summary>
        /// 微信
        /// </summary>
        WECHAT,
        /// <summary>
        /// 支付宝
        /// </summary>
        ALIPAY,
        /// <summary>
        /// 工伤保险
        /// </summary>
        GSBX,
        /// <summary>
        /// 网银
        /// </summary>
        CYBERPAY
    };
    //药品io类别
    public enum DrugIoKind
    {
        /// <summary>
        /// 进货入库
        /// </summary>
        IN01,
        /// <summary>
        /// 联网入库
        /// </summary>
        IN02,
        /// <summary>
        /// 退库入库
        /// </summary>
        IN03,
        /// <summary>
        /// 门诊退药
        /// </summary>
        IN04,
        /// <summary>
        /// 住院退药
        /// </summary>
        IN05,
        /// <summary>
        /// 退药入库
        /// </summary>
        IN06,
        /// <summary>
        /// 调整增库
        /// </summary>
        IN07,
        /// <summary>
        /// 调拨入库
        /// </summary>
        IN08,
        /// <summary>
        /// 退货出库
        /// </summary>
        OUT01,
        /// <summary>
        /// 请领出库
        /// </summary>
        OUT02,
        /// <summary>
        /// 退库出库
        /// </summary>
        OUT03,
        /// <summary>
        /// 门诊发药
        /// </summary>
        OUT04,
        /// <summary>
        /// 住院发药
        /// </summary>
        OUT05,
        /// <summary>
        /// 售药出库
        /// </summary>
        OUT06,
        /// <summary>
        /// 调整减库
        /// </summary>
        OUT07,
        /// <summary>
        /// 调拨出库
        /// </summary>
        OUT08,
        /// <summary>
        /// 报损出库
        /// </summary>
        OUT09

    };
    //药品io入出状态
    public enum DrugOpStat
    {
        /// <summary>
        /// 
        /// </summary>
        OO,
        /// <summary>
        /// 申请
        /// </summary>
        APP,
        /// <summary>
        /// 审核
        /// </summary>
        CHK,
        /// <summary>
        /// 作废
        /// </summary>
        XX
    };
    /// <summary>
    /// 处方状态
    /// </summary>
    public enum ClinicRcpOpstat
    {
        /// <summary>
        /// 作废
        /// </summary>
        XX,
        /// <summary>
        /// 未提交
        /// </summary>
        OO,
        /// <summary>
        /// 提交
        /// </summary>
        YES,
        /// <summary>
        /// 执行
        /// </summary>
        EXE,
        /// <summary>
        /// 退方
        /// </summary>
        RET
    };
    /// <summary>
    /// 就诊类型
    /// </summary>
    public enum RegistKind
    {
        /// <summary>
        /// 门诊
        /// </summary>
        CLIN,
        /// <summary>
        /// 住院
        /// </summary>
        IHSP,
        /// <summary>
        /// 体检
        /// </summary>
        ECHK
    };
    /// <summary>
    /// 医保接口状态
    /// </summary>
    public enum Insurstat
    {
        /// <summary>
        /// 未登记
        /// </summary>
        OO,
        /// <summary>
        /// 已登记
        /// </summary>
        REG,
        /// <summary>
        /// 已出院
        /// </summary>
        SIGN,
        /// <summary>
        /// 已结算
        /// </summary>
        SETT
    };
    /// <summary>
    /// 以分床
    /// </summary>
    public enum IhspInbed
    {
        /// <summary>
        ///是 
        /// </summary>
        Y,
        /// <summary>
        /// 否（默认）
        /// </summary>
        N,
        /// <summary>
        /// 退床
        /// </summary>
        R,
    }
    /// <summary>
    /// 病人状态
    /// </summary>
    public enum IhspIshpstate
    {
        /// <summary>
        /// 普通
        /// </summary>
        COMM,
        /// <summary>
        /// 会诊
        /// </summary>
        CONSULT,
        /// <summary>
        /// 共享
        /// </summary>
        SHARE,
    }
    /// <summary>
    /// 医保信息状态
    /// </summary>
    public enum Insurinfostate
    {
        /// <summary>
        /// 添加
        /// </summary>
        OO,
        /// <summary>
        /// 已登记
        /// </summary>
        REG,
        /// <summary>
        /// 年终结算
        /// </summary>
        MIDSETT,
        /// <summary>
        /// 结算
        /// </summary>
        SETT,
        /// <summary>
        /// 作废
        /// </summary>
        XX,
    }
    public enum SysPrintCodeid
    {
        /// <summary>
        /// 贵阳市医保发票[门]
        /// </summary>
        CLIN_GYSYBFP,
        /// <summary>
        /// 贵州省医保发票[门]
        /// </summary>
        CLIN_GZSYBFP,
        /// <summary>
        /// 门诊自费发票
        /// </summary>
        CLIN_MZZFFP,
        /// <summary>
        /// 邯郸市医保发票[门]
        /// </summary>
        CLIN_HDSYBFP,
        /// <summary>
        /// 邯郸市城合发票[门]
        /// </summary>
        CLIN_HDSCHFP,
        /// <summary>
        /// 衡水武邑县医保发票[门]
        /// </summary>
        CLIN_HSWYXYB,
        /// <summary>
        /// 门诊收费员日结表
        /// </summary>
        CTFC,
        /// <summary>
        /// 门诊收入汇总日结表
        /// </summary>
        CTFCA,
        /// <summary>
        /// 支付类型日结表
        /// </summary>
        CTFP,
        /// <summary>
        /// 门诊科室核算
        /// </summary>
        CDeA,
        /// <summary>
        /// 门诊结算后项目汇总
        /// </summary>
        CTACII,
        /// <summary>
        /// 门诊医生核算
        /// </summary>
        CDoA,
        /// <summary>
        /// 门诊结算后支付类型汇总
        /// </summary>
        CLIN_MZJSHZFLXHZ,
        /// <summary>
        /// 住院发票
        /// </summary>
        IHSP_ZYFP,
        /// <summary>
        /// 住院自费发票
        /// </summary>
        IHSP_ZYZFFP,
        /// <summary>
        /// 邯郸市医保发票[住]
        /// </summary>
        IHSP_HDSYBFP,
        /// <summary>
        /// 邯郸市城合发票[住]
        /// </summary>
        IHSP_HDSCHFP,
        /// <summary>
        /// 邯郸市生育发票
        /// </summary>
        IHSP_HDSSYFP,
        /// <summary>
        /// 衡水武邑县医保发票[住]
        /// </summary>
        IHSP_HSWYXYB,
        /// <summary>
        /// 住院预交款
        /// </summary>
        IP,
        /// <summary>
        /// 住院担保凭证
        /// </summary>
        IG,
        /// <summary>
        /// 住院结算后情况
        /// </summary>
        ITACI,
        /// <summary>
        /// 住院收费员汇总日结表
        /// </summary>
        ITFCA,
        /// <summary>
        /// 出院收入汇总日结表
        /// </summary>
        ITCA,
        /// <summary>
        /// 住院收费员明细日结表
        /// </summary>
        ITFC,
        /// <summary>
        /// 住院医生核算
        /// </summary>
        IIDoA,
        /// <summary>
        /// 出院医生
        /// </summary>
        IODoA,
        /// <summary>
        /// 住院科室核算
        /// </summary>
        IIDeA,
        /// <summary>
        /// 出院科室核算
        /// </summary>
        IODeA,
        /// <summary>
        /// 云南异地医保结算单
        /// </summary>
        ynydybSettPrt,
        /// <summary>
        /// 石家庄医保结算单（公务员）
        /// </summary>
        sjzybybSettRpt_gwy,
        /// <summary>
        /// 石家庄医保结算单（居民）
        /// </summary>
        sjzybybSettRpt_jm,
        /// <summary>
        /// 石家庄医保结算单（职工）
        /// </summary>
        sjzybybSettRpt_zg,
        /// <summary>
        /// 费用清单
        /// </summary>
        ihspCostSummary,
        /// <summary>
        /// 住院腕带打印[住]
        /// </summary>
        IHSP_WRISTBAND,
        /// <summary>
        /// 新生儿腕带打印[住]
        /// </summary>
        xse_WRISTBAND
    }
    /// <summary>
    /// 项目类别关键字
    /// </summary>
    public enum ItemtypeKeyname
    {
        /// <summary>
        /// 材料
        /// </summary>
        STUFF,
        /// <summary>
        /// 西药
        /// </summary>
        WSMED,
        /// <summary>
        /// 中成药
        /// </summary>
        PATMED,
        /// <summary>
        /// 中草药
        /// </summary>
        HERBMED,
    }
    /// <summary>
    /// 年龄单位
    /// </summary>
    public enum AgeUnit
    {
        /// <summary>
        /// 岁
        /// </summary>
        AGE=4,
        /// <summary>
        /// 月
        /// </summary>
        MOON=3,
        /// <summary>
        /// 天
        /// </summary>
        DAY=1,
        /// <summary>
        /// 小时
        /// </summary>
        HOUR=0
    }
    /// <summary>
    /// 性别
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男
        /// </summary>
        M,
        /// <summary>
        /// 女
        /// </summary>
        W,
        /// <summary>
        /// 其他
        /// </summary>
        U
    }
    /// <summary>
    /// 诊断类型
    /// </summary>
    public enum DiagnKind
    {
        /// <summary>
        ///门诊诊断 
        /// </summary>
        CLIN,
        /// <summary>
        ///初步诊断 
        /// </summary>
        First,
        /// <summary>
        /// 修正诊断
        /// </summary>
        Mod,
        /// <summary>
        /// 补充诊断
        /// </summary>
        ADD,
        /// <summary>
        /// 出院诊断（或者死亡诊断）
        /// </summary>
        OUT

    }
}


