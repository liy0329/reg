using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTREG.common;
using MTREG.medinsur.gysyb.bo;
using MTHIS.tools;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gzsnh.bll;
using MTREG.medinsur.gzsyb.ihsp.bll;


namespace MTREG.ihsp.bll
{
    class BillIhspAct
    {        
        /// <summary>
        /// 查询剩余发票号
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <param name="chargeer"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int getInvoiceNum(string invoicekind_id, string chargeer)
        {
            int ret = 0;
            DataTable dt = new DataTable();
            string sql = "select sum(endnum-currnum+1) as num from sys_invoice where charger = " + DataTool.addFieldBraces(chargeer)
                + " and sys_invoicekind_id = " + DataTool.addFieldBraces(invoicekind_id)
                + " and  started in ('OO', 'ST')";
            dt = BllMain.Db.Select(sql).Tables[0];
            if(dt.Rows.Count>0)
                ret = int.Parse(dt.Rows[0]["num"].ToString());
            return ret;
        }
        
        /// <summary>
        /// 获取发票号类型
        /// </summary>
        /// <param name="patienttype_id"></param>
        /// <returns></returns>
        public string getInvoiceKind(string patienttype_id)
        {
            string sql = "select sys_ihspinvoicekind_id from bas_patienttype where id = " + DataTool.addFieldBraces(patienttype_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string pat = dt.Rows[0]["sys_ihspinvoicekind_id"].ToString();
                return pat;
            }
            else
            {
                return "";
            }

        }
      
        /// <summary>
        /// dgvIhspPayinadv查询
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public DataTable payAccount(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select ihsp_payinadv.payfee"
                               + ",sys_dict.name as paytypename"
                               + ",ihsp_payinadv.cheque"
                               + ",bas_doctor.name as doctorname"
                               + ",ihsp_payinadv.chargedate"
                               + " from ihsp_payinadv "
                               + " left join sys_dict on ihsp_payinadv.bas_paytype_id=sys_dict.sn and sys_dict.dicttype = 'bas_paytype' and sys_dict.father_id<>0 "
                               + " left join bas_doctor on ihsp_payinadv.chargedby=bas_doctor.id "
                               + " where 1=1"
                               + (!string.IsNullOrEmpty(ihsp_id) ? (" and  ihsp_payinadv.ihsp_id = " + DataTool.addFieldBraces(ihsp_id)) : "")
                               + " order by ihsp_payinadv.id DESC"
                               ;
            try
            {
                 dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 未结费用查询feeNoAccount
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public DataTable feeNoAccount(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select sum(balanceamt) as feeNoAccount from ihsp_account "
                               + " where  settled='N' and ihsp_id =" + DataTool.addFieldBraces(ihsp_id) + ";";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
        /// <summary>
        /// dgvIhspcost查询
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public DataTable costSearch(string ihsp_id,string str_neonate)
        {
            DataTable dt = new DataTable();
            string sql = "select cost_itemtype.name as itemtypename "
                      + ",ihsp_costdet.name"
                      + ",ihsp_costdet.spec"
                      + ",ihsp_costdet.realfee"
                      + ",ihsp_costdet.num"
                      + ",ihsp_costdet.prc"
                      + ",ihsp_costdet.id"
                      + " from ihsp_costdet "
                      + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id "
                      + " where 1=1 and settled='N' and charged in ('RREC','RET','CHAR')"
                      + " and  ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            
            if (str_neonate.Equals("neonate"))
                    sql += " and ihsp_costdet.neonate_id<>0";
                    sql +=";";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }


    

     

        /// <summary>
        /// 更新住院表结算相关
        /// </summary>
        /// <returns></returns>
        public int upIhsp(string ihsp_id, string status, string chargeby, string chargedate)
        {
            string sql = "update inhospital set status=" + DataTool.addFieldBraces(status)
                + ",enterdep=" + DataTool.addFieldBraces(IhspEnterDep.RECV.ToString())
                + ",retsignedby=" + DataTool.addFieldBraces(chargeby)
                + ",retsigndate=" + DataTool.addFieldBraces(chargedate)
                + " where id=" + DataTool.addFieldBraces(ihsp_id)+";";
         
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 更新住院状态为已挂账，医保状态为已登记
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string upIhsp(string ihsp_id, string status, string insurstat)
        {
            string sql = "update inhospital set status=" + DataTool.addFieldBraces(status);
            if (insurstat != "")
            {
                sql += " ,insurstat=" + DataTool.addFieldBraces(insurstat);
            }       
            sql += " where id=" + DataTool.addFieldBraces(ihsp_id)+";";
            return sql;
        }
        /// <summary>
        /// 撤销医保结算状态
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="insurstat"></param>
        /// <returns></returns>
        public int cancelInsureAccount(string ihsp_id)
        {
            string sql = "update inhospital set insurstat='REG' where id=" + DataTool.addFieldBraces(ihsp_id) + ";";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 更新费用表 只更新charged为RREC：红冲、RET：退费、CHAR: 计费
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string upCost(string ihsp_id, string account_id,string settled)
        {
            string sql = "update ihsp_costdet set settled=" + DataTool.addFieldBraces(settled) 
                + ",ihsp_account_id=" + DataTool.addFieldBraces(account_id)
                + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and charged in('RREC','RET','CHAR');";
            return sql;
        }
      
      
     
   

   

        /// <summary>
        /// 更新住院表审批状态
        /// </summary>
        /// <returns></returns>
        public int upIhspApp(string ihsp_id, string unlocked,string doctor)
        {
            string sql = "update inhospital set unlocked=" + DataTool.addFieldBraces(unlocked)
                + ",unlockby=" + DataTool.addFieldBraces(doctor)
                + " where id=" + DataTool.addFieldBraces(ihsp_id)+";";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 插入结算单表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        /// <returns></returns>
        public string inAccount(Ihspaccount ihspaccount)
        {
            //string sql = "update ihsp_account set islock='Y';";
            string sql = "insert into ihsp_account(id"
                                              + ",billcode"
                                              + ",ihsp_id"
                                              + ",member_id"
                                              + ",bas_paytype_id"
                                              + ",cheque"
                                              + ",bas_patienttype_id"
                                              + ",cost_insurtype_id"
                                              + ",num"
                                              + ",invoice"
                                              + ",feeamt"
                                              + ",prepamt"
                                              + ",balanceamt"
                //+ ",recivefee"
                //+ ",retfee"
                                              + ",depart_id"
                                              + ",chargedby_id"
                                              + ",chargedate"
                                              //+ ",cancleby"
                                              + ",ihsp_account_id"
                                              + ",status"
                                              //+ ",cost_begin_id"
                                              //+ ",cost_end_id"
                                              + ",islock"
                                              + ",insurefee"
                                              + ",insuraccountfee)values(" + DataTool.addFieldBraces(ihspaccount.Id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Billcode)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Ihsp_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Member_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Bas_paytype_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Cheque)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Bas_patienttype_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Cost_insurtype_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Num)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Invoice)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Feeamt)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Prepamt)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Balanceamt)
                //+ "," + DataTool.addFieldBraces(ihspaccount.Recivefee)
                //+ "," + DataTool.addFieldBraces(ihspaccount.Retfee)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Depart_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Chargedby_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Chargedate)
                                                                   //+ "," + DataTool.addFieldBraces(ihspaccount.Cancleby)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Ihsp_account_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Status)
                                                                   //+ "," + DataTool.addFieldBraces(ihspaccount.Cost_begin_id)
                                                                   //+ "," + DataTool.addFieldBraces(ihspaccount.Cost_end_id)
                                                                   + "," + DataTool.addFieldBraces("N")
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Insurefee)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Selffee)
                                                                   + ");";
            return sql;

        }



        /// <summary>
        /// 获取支付类型ID
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getPaytypeId(string keyname)
        {
            string sql = "select sn from sys_dict where dicttype='bas_paytype' and father_id<>0 and keyname=" + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["sn"].ToString();
        }
        
        /// <summary>
        /// 获取支付类型关键字
        /// </summary>
        /// <param name="paytypeId"></param>
        /// <returns></returns>
        public string getPaytypeKeyname(string paytypeId)
        {
            string sql = "select keyname from sys_dict where dicttype='bas_paytype' and father_id<>0 and sn=" + DataTool.addFieldBraces(paytypeId);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["keyname"].ToString();
        }
        /// <summary>
        /// 根据支付类型查询支付汇总
        /// </summary>
        /// <param name="paytype"></param>
        /// <returns></returns>
        public string getPaysumby(string paytype)
        {
            string sql = "select id from bas_paysumby where isinsur='0' and bas_paytype_id='" + paytype + "';";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt.Rows[0]["id"].ToString();
        }

        /// <summary>
        /// 插入结算单费用表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ihsp_account_id"></param>
        /// <returns></returns>
        public string inAccountdet(DataTable dt, string ihsp_account_id)
        {
            string sql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = BillSysBase.nextId("ihsp_accountdet");
                string itemtype = dt.Rows[i]["itemtype_id"].ToString();
                string itemtype1 = dt.Rows[i]["itemtype1_id"].ToString();
                string realfee = dt.Rows[i]["realfee"].ToString();
                sql += "insert into ihsp_accountdet(id"
                                              + ",ihsp_account_id"
                                              + ",itemtype"
                                              + ",itemtype1"
                                              + ",realfee)values(" + DataTool.addFieldBraces(id)
                                                                   + "," + DataTool.addFieldBraces(ihsp_account_id)
                                                                   + "," + DataTool.addFieldBraces(itemtype)
                                                                   + "," + DataTool.addFieldBraces(itemtype1)
                                                                   + "," + DataTool.addFieldBraces(realfee)
                                                                   + ");";
            }
            return sql;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <returns></returns>
        public int sql(string sql)
        {
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 结算回退删除结算单费用表
        /// </summary>
        /// <param name="selectOne"></param>
        /// <returns></returns>
        public string dtlAcount(string selectOne)
        {
            string sql = "delete from ihsp_accountdet where ihsp_account_id =" + DataTool.addFieldBraces(selectOne)+";";
            return sql;
        }

        /// <summary>
        /// 结算回退查询
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public DataTable retAccountSearch(string ihsp_account_id)
        {
            string sql = "select ihsp_account.id"
                                + ",ihsp_account.billcode"
                                + ",ihsp_account.ihsp_id"
                                + ",ihsp_account.member_id"
                                + ",ihsp_account.bas_paytype_id"
                                + ",ihsp_account.cheque"
                                + ",ihsp_account.bas_patienttype_id"
                                + ",ihsp_account.cost_insurtype_id"
                                + ",ihsp_account.num"
                                + ",ihsp_account.invoice"
                                + ",ihsp_account.feeamt"
                                + ",ihsp_account.prepamt"
                                + ",ihsp_account.balanceamt"
                                + ",ihsp_account.recivefee"
                                + ",ihsp_account.retfee"
                                + ",ihsp_account.depart_id"
                                + ",ihsp_account.chargedby_id"
                                + ",ihsp_account.chargedate"
                                + ",ihsp_account.status"
                                + ",ihsp_account.insurefee"
                                + ",ihsp_account.hisOrderNo"
                                + ",ihsp_account.insuraccountfee"
                                + " from ihsp_account"
                                + " where ihsp_account.id = " + DataTool.addFieldBraces(ihsp_account_id)
                                + " and islock='N' and status='SETT' order by id desc limit 1;" ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 重打住院发票信息查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable rePrintSearch(string ihsp_account_id)
        {
            string sql = "select sys_dict.name as paytype"
                                + ",bas_patienttype.name as patienttype"
                                + ",ihsp_account.id"
                                + ",ihsp_account.bas_patienttype_id"
                                + ",ihsp_account.insurefee"
                                + ",ihsp_account.cheque"
                                + ",ihsp_account.insuraccountfee"
                                + ",ihsp_account.feeamt"
                                + ",ihsp_account.prepamt"
                                + ",ihsp_account.invoice"
                                + " from ihsp_account"
                                + " left join sys_dict on sys_dict.sn=ihsp_account.bas_paytype_id and sys_dict.dicttype = 'bas_paytype' and sys_dict.father_id<>0 "
                                //+ " left join inhospital on inhospital.id=ihsp_account.ihsp_id "
                                + " left join bas_patienttype on bas_patienttype.id=ihsp_account.bas_patienttype_id "
                                + " where  ihsp_account.id = " + DataTool.addFieldBraces(ihsp_account_id)
                                + " and ihsp_account.status='SETT' ;"
                                ;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 更新发票号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int upAccInvoice(string id, string invoice, string nextinvoicesql)
        {
            string sql = "update ihsp_account set invoice=" + DataTool.addFieldBraces(invoice) + " where id=" + DataTool.addIntBraces(id) + " and status='SETT';";
            sql += nextinvoicesql;
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 查询医保信息状态
        /// </summary>
        /// <returns></returns>
        public DataTable insurInfo(string ihsp_id)
        {
            string sql = "select opstat from ihsp_insurinfo where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取发票个数
        /// </summary>
        /// <returns></returns>
        public DataTable getBillNum(string ihsp_id)
        {
            string sql = "select id, billcode from ihsp_account where ihsp_id=" + DataTool.addIntBraces(ihsp_id) + " and status='SETT';";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 更新医保状态为已结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string accountInsurStat(string ihsp_id)
        {
            string sql = " update inhospital set insurstat= 'SETT' where id=" + DataTool.addFieldBraces(ihsp_id);
            return sql;

        }
        /**结算*/
        /// <summary>
        /// 插入结算单表
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="ihspaccount"></param>
        ///  <param name="accountkeyname"> insur:医保 selfcost:自费 neonate:新生儿</param>
        /// <returns></returns>
        public string doAccount(Ihspaccount ihspaccount, List<IhspInvoicedet> invoicedets, string accountkeyname)
        {

         
            string neonate ="N";
            if (accountkeyname.Equals("neonate"))
            {
                neonate = "Y";
            }
            string sql = "insert into ihsp_account(id"
                                              + ",billcode"
                                              + ",ihsp_id"
                                              + ",member_id"
                                              + ",bas_paytype_id"
                                              + ",cheque"
                                              + ",bas_patienttype_id"
                                              + ",num"
                                              + ",invoice"
                                              + ",feeamt"
                                              + ",prepamt"
                                              + ",balanceamt"
                //+ ",recivefee"
                //+ ",retfee"
                                              + ",depart_id"
                                              + ",chargedby_id"
                                              + ",chargedate"
                                              + ",ihsp_account_id"
                                              + ",status"
                                              + ",hisOrderNo"
                                              + ",islock"
                                              + ",insurefee"
                                              + ",neonate"
                                              + ",insuraccountfee)values("
                                                                         + DataTool.addFieldBraces(ihspaccount.Id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Billcode)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Ihsp_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Member_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Bas_paytype_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Cheque)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Bas_patienttype_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Num)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Invoice)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Feeamt)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Prepamt)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Balanceamt)
                //+ "," + DataTool.addFieldBraces(ihspaccount.Recivefee)
                //+ "," + DataTool.addFieldBraces(ihspaccount.Retfee)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Depart_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Chargedby_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Chargedate)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Ihsp_account_id)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Status)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.HisOrderNo)
                                                                   + "," + DataTool.addFieldBraces("N")
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Insurefee)
                                                                   + "," + DataTool.addFieldBraces(neonate)
                                                                   + "," + DataTool.addFieldBraces(ihspaccount.Selffee)
                                                                   + ");";
            if (!string.IsNullOrEmpty(ihspaccount.HisOrderNo))
            {
                sql += "update netpaydata set hisstat = 1 where outerOrderNo=" + DataTool.addFieldBraces(ihspaccount.HisOrderNo) + ";";
            }
            sql += ihspaccount.Nextinvoicesql;
            for (int i = 0; i < invoicedets.Count; i++)
            {
                IhspInvoicedet ihspInvoicedet = invoicedets[i];
                sql += "insert into ihsp_invoicedet(id"
                + ",ihsp_account_id"
                + ",payfee"
                + ",bas_paysumby_id"
                + ",bas_paytype_id"
                + ",billcode"
                + ",cheque"
                + ",isfirst)values(" + DataTool.addFieldBraces(ihspInvoicedet.Id)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.IhspAccountId)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.Payfee)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.PaysumbyId)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.PaytypeId)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.Billcode)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.Cheque)
                + "," + DataTool.addFieldBraces(ihspInvoicedet.Isfirst)
                + ");";
            }
            // 新生儿，中途挂账后结算 不更新 inhospital 为 SETT状态
            if (!accountkeyname.Equals("neonate"))
                sql += "update inhospital set status='SETT' where id =" + DataTool.addFieldBraces(ihspaccount.Ihsp_id) + " and status = 'SIGN';";
           
            sql += doAccCostDet(ihspaccount.Ihsp_id, ihspaccount.Id,accountkeyname);
            sql += doAccPayinadv(ihspaccount.Ihsp_id, ihspaccount.Id);

            return sql;
        }

        /// <summary>
        /// 撤销结算插入his表
        /// </summary>
        /// <param name="ihsp_account_id"></param>
        /// <returns></returns>
        public int cancleAccount(string ihsp_account_id, string paytypeId)
        {
            string sql = "select * from ihsp_account where id = " + DataTool.addFieldBraces(ihsp_account_id)
                + ";select * from ihsp_invoicedet where ihsp_account_id=" + DataTool.addFieldBraces(ihsp_account_id);

            DataSet ds = BllMain.Db.Select(sql);
            DataTable dt = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            string hisorderno = dt.Rows[0]["hisorderno"].ToString();
            string disaccount_id = BillSysBase.nextId("ihsp_account");
            string num = "-1";
            sql = "insert into ihsp_account(id"
                                             + ",billcode"
                                             + ",ihsp_id"
                                             + ",member_id"
                                             + ",bas_paytype_id"
                                             + ",cheque"
                                             + ",bas_patienttype_id"
                                             + ",num"
                                             + ",invoice"
                                             + ",feeamt"
                                             + ",prepamt"
                                             + ",balanceamt"
                //+ ",recivefee"
                //+ ",retfee"
                                             + ",depart_id"
                                             + ",chargedby_id"
                                             + ",chargedate"
                                          
                                             + ",ihsp_account_id"
                                             + ",status"

                                        
                                             + ",islock"
                                             + ",insurefee"
                                             + ",insuraccountfee) values(" + DataTool.addFieldBraces(disaccount_id)
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["billcode"].ToString())
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString())
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["member_id"].ToString())
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["bas_paytype_id"].ToString())
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["cheque"].ToString())
                                                                  + "," + DataTool.addFieldBraces(dt.Rows[0]["bas_patienttype_id"].ToString())
                                                                  + "," + DataTool.addFieldBraces(num)// (dt.Rows[0]["num"].ToString())
                                                                   + "," + DataTool.addFieldBraces(dt.Rows[0]["invoice"].ToString())
                                                                   + "," + DataTool.addFieldBraces(dt.Rows[0]["feeamt"].ToString())
                                                                   + "," + DataTool.addFieldBraces(dt.Rows[0]["prepamt"].ToString())
                                                                   + "," + DataTool.addFieldBraces(dt.Rows[0]["balanceamt"].ToString())
                //+ "," + DataTool.addFieldBraces(ihspaccount.Recivefee)
                //+ "," + DataTool.addFieldBraces(ihspaccount.Retfee)
                                                                   + "," + DataTool.addFieldBraces(dt.Rows[0]["depart_id"].ToString())
                                                                   + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)//(dt.Rows[0]["chargedby_id"].ToString())
                                                                   + "," + DataTool.addFieldBraces(BillSysBase.currDate())//(dt.Rows[0]["chargedate"].ToString())
                                                              
                                                                   + "," + DataTool.addFieldBraces(ihsp_account_id)//(dt.Rows[0]["ihsp_account_id"].ToString())
                                                                   + "," + DataTool.addFieldBraces(IhspAccountStatus.RREC.ToString())// (dt.Rows[0]["status"].ToString())
                                                     
                                                               
                                                                    + "," + DataTool.addFieldBraces("N")
                                                                    + "," + DataTool.addFieldBraces(dt.Rows[0]["insurefee"].ToString())
                                                                    + "," + DataTool.addFieldBraces(dt.Rows[0]["insuraccountfee"].ToString())
                                                                    + ");";
            sql += "update ihsp_account set status='RET'"
                            //+ ", chargedate=" + DataTool.addFieldBraces(BillSysBase.currDate())
                            //+ ", cancleby=" + DataTool.addFieldBraces(ProgramGlobal.User_id)
                            + " where id=" + DataTool.addIntBraces(ihsp_account_id) + ";";
            if (!string.IsNullOrEmpty(hisorderno))
            {
                sql += "UPDATE netpaydata set hisstat =1 where outerOrderNo=" + DataTool.addFieldBraces(hisorderno) + ";"
                +"UPDATE netpaydata set isCancel =1 where sourceOuterOrderNo=" + DataTool.addFieldBraces(hisorderno) + ";";
            }
            sql += "update inhospital set status='SIGN',unlocked = 'N' where id =" + DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString()) + ";";
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string payfee = dt2.Rows[i]["payfee"].ToString();
                double d_payfee = DataTool.stringToDouble(payfee);
                payfee = (-d_payfee).ToString();
                //从数据库查到paytype
                string paytype_id = dt2.Rows[i]["bas_paytype_id"].ToString();
                
                //如果是实收金额，取传过来的参数，即界面上选择的类型
                if (isPaytype(paytype_id) > 0)
                {
                    paytype_id = paytypeId;
                }

                sql += "insert into ihsp_invoicedet(id"
                + ",ihsp_account_id"
                + ",payfee"
                + ",bas_paysumby_id"
                + ",bas_paytype_id"
                + ",billcode"
                + ",cheque"
                + ",isfirst)values(" + BillSysBase.nextId("ihsp_invoicedet")
                + "," + DataTool.addFieldBraces(disaccount_id)
                + "," + DataTool.addFieldBraces(payfee)//(dt2.Rows[i]["payfee"].ToString())
                + "," + DataTool.addFieldBraces(dt2.Rows[i]["bas_paysumby_id"].ToString())
                + "," + DataTool.addFieldBraces(paytype_id)//(dt2.Rows[i]["bas_paytype_id"].ToString())
                + "," + DataTool.addFieldBraces(dt2.Rows[i]["billcode"].ToString())
                + "," + DataTool.addFieldBraces(dt2.Rows[i]["cheque"].ToString())
                + "," + DataTool.addFieldBraces(dt2.Rows[i]["isfirst"].ToString())
                + ");";
            }
            //sql += cancleAccCostDet(DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString()), DataTool.addFieldBraces(dt.Rows[0]["id"].ToString()), disaccount_id);
            sql += cancleAccCostDet(dt.Rows[0]["ihsp_id"].ToString(), dt.Rows[0]["id"].ToString(), disaccount_id);
            //sql += cancleAccPayinadv(DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString()), DataTool.addFieldBraces(dt.Rows[0]["id"].ToString()), disaccount_id);
            sql += cancleAccPayinadv(dt.Rows[0]["ihsp_id"].ToString(), dt.Rows[0]["id"].ToString(), disaccount_id);
            //sql += cancleAccNhJsxx(DataTool.addFieldBraces(dt.Rows[0]["ihsp_id"].ToString()));
            sql += "update inhospital set chargedate = null where id =" + dt.Rows[0]["ihsp_id"].ToString() + ";";
            int ret = BllMain.Db.Update(sql);
            if (ret < 0)
            {
                LogUtils.writeFileLog("住院HIS", "结算回退sql:" + sql);
            }
            return ret;
        }

        /// <summary>
        /// 付款类型下拉表
        /// </summary>
        /// <returns></returns>
        public int isPaytype(string bas_paytype_id)
        {
            DataTable dt = new DataTable();
            string sql = "select * from bas_paysumby where isinsur='0' and bas_paytype_id='" + bas_paytype_id + "';";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {
                return 0;
            }
            return dt.Rows.Count;
        }


        /// <summary>
        /// 更新费用表 只更新charged为RREC：红冲、RET：退费、CHAR: 计费 
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="account_id"></param>
        /// <param name="accountkeyname"> insur:医保 selfcost:自费 neonate:新生儿</param>
        /// <returns></returns>
        public string doAccCostDet(string ihsp_id, string account_id, string accountkeyname)
        {

            string sql = "select id from ihsp_costdet "
                  + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and charged in('RREC','RET','CHAR')"
                 + " and settled=" + DataTool.addFieldBraces("N");
            if (accountkeyname.Equals("neonate"))
            {
                sql += " and neonate_id<>0";
            }
            else if(accountkeyname.Equals("insur"))
            {
                sql += " and neonate_id=0";
            }
            sql += ";";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sql = "";
            string num = "1";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "insert into ihsp_costdetsettle(id,ihsp_costdet_id,ihsp_account_id,num) VALUES("
                    + BillSysBase.nextId("ihsp_costdetsettle")
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                    + "," + DataTool.addFieldBraces(account_id)
                    + "," + DataTool.addFieldBraces(num)
                    + ");";
                sql += "update ihsp_costdet set settled=" + DataTool.addFieldBraces("Y")
                    + ",ihsp_account_id=" + DataTool.addFieldBraces(account_id)
                    + " where id =" + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())+";";
            }
            return sql;
        }
        /// <summary>
        /// 更新预交款表
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string doAccPayinadv(string ihsp_id, string account_id)
        {
            string sql = " select id from ihsp_payinadv " + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and settled=" + DataTool.addFieldBraces("N") + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sql = "";
            string num = "1";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "insert into ihsp_payinadvsettle(id,ihsp_payinadv_id,ihsp_account_id,num) VALUES("
                    + BillSysBase.nextId("ihsp_payinadvsettle")
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["id"].ToString())
                    + "," + DataTool.addFieldBraces(account_id)
                    + "," + DataTool.addFieldBraces(num)
                    + ");";
            }
            sql += "update ihsp_payinadv set settled=" + DataTool.addFieldBraces("Y")
                                                            + ",ihsp_account_id=" + DataTool.addFieldBraces(account_id)
                                                            + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and settled=" + DataTool.addFieldBraces("N") + ";";
            return sql;
        }
        /// <summary>
        /// 更新费用表 只更新charged为RREC：红冲、RET：退费、CHAR: 计费 
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string cancleAccCostDet(string ihsp_id, string account_id, string disaccount_id)
        {
            string sql = "select * from ihsp_costdetsettle "
                 + " where ihsp_account_id=" + DataTool.addFieldBraces(account_id) + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sql = "";
            string num = "-1";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "insert into ihsp_costdetsettle(id,ihsp_costdet_id,ihsp_account_id,num) VALUES("
                    + BillSysBase.nextId("ihsp_costdetsettle")
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["ihsp_costdet_id"].ToString())
                    + "," + DataTool.addFieldBraces(disaccount_id)
                    + "," + DataTool.addFieldBraces(num)
                    + ");";
            }
            sql += "update ihsp_costdet set settled=" + DataTool.addFieldBraces("N")
                + ",ihsp_account_id= 0"
                + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and ihsp_account_id=" + DataTool.addFieldBraces(account_id) + ";";

            return sql;
        }
        /// <summary>
        /// 更新预交款表
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public string cancleAccPayinadv(string ihsp_id, string account_id, string disaccount_id)
        {
            string sql = " select * from ihsp_payinadvsettle " + " where ihsp_account_id=" + DataTool.addFieldBraces(account_id) + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sql = "";
            string num = "-1";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "insert into ihsp_payinadvsettle(id,ihsp_payinadv_id,ihsp_account_id,num) VALUES("
                    + BillSysBase.nextId("ihsp_payinadvsettle")
                    + "," + DataTool.addFieldBraces(dt.Rows[i]["ihsp_payinadv_id"].ToString())
                    + "," + DataTool.addFieldBraces(disaccount_id)
                    + "," + DataTool.addFieldBraces(num)
                    + ");";
            }
            sql += "update ihsp_payinadv set settled=" + DataTool.addFieldBraces("N")
                                                            + ",ihsp_account_id=0 "
                                                            + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + " and ihsp_account_id=" + DataTool.addFieldBraces(account_id) + ";";
            return sql;
        }

        public string getHisPayinadvSum(string ihsp_id)
        {
            string sumfee = "";
            string sql = " SELECT"
                              + " COALESCE( SUM(payfee),0) as sumfee"
                              + " FROM"
                              + " ihsp_payinadv"
                              + " where settled='N'"
                              + " and ihsp_id =" + DataTool.addFieldBraces(ihsp_id);

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sumfee = DataTool.FormatData(dt.Rows[0]["sumfee"].ToString(),"2");
            return sumfee;
        }
        public string getHisCostDetSum(string ihsp_id)//医保未结费用
        {
            string sumfee = "";
            string sql = " SELECT"
                                + " COALESCE( SUM(realfee),0) as sumfee"
                                + " FROM"
                                + " ihsp_costdet"
                                + " where ihsp_costdet.charged in ('RREC', 'RET','CHAR')  and settled='N'"
                                + " and neonate_id='0'"
                                + " and ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(ihsp_id);


            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sumfee = DataTool.FormatData(dt.Rows[0]["sumfee"].ToString(), "2");
            return sumfee;
        }
        public string getHisNeonCostDetSum(string ihsp_id)//新生儿未结费用
        {
            string sumfee = "";
            string sql = " SELECT"
                                + "  COALESCE( SUM(realfee),0) as sumfee"
                                + " FROM"
                                + " ihsp_costdet"
                                + " where ihsp_costdet.charged in ('RREC', 'RET','CHAR')  and settled='N'"
                                + " and neonate_id<>0 "
                                + " and ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(ihsp_id);


            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            sumfee = DataTool.FormatData(dt.Rows[0]["sumfee"].ToString(), "2");
            return sumfee;
        }
        /// <summary>
        /// 判断挂账
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool isHisihspSign(string ihsp_id)
        {
            string sql = " select id from inhospital where status in ('SIGN ','MSIG') and id= " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断his是否结账
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool isHisAccount(string ihsp_id)
        {
            string sql = " select id from inhospital where status ='SETT' and id= " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        
        public string getPaysumbyKeyname(string keyname)
        {
            string sql = " SELECT id from bas_paysumby WHERE bas_paysumby.keyname =" + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["id"].ToString();
            return ret;
        }
        public string getInsurFeePaytypeId()
        {
            string sql = "SELECT sn  FROM `sys_dict` WHERE `dicttype` = 'bas_paytype' and keyname='INSUREFEE'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["sn"].ToString();
            return ret;
        }
        public string getSELFFEEPaytypeId()
        {
            string sql = "SELECT sn  FROM `sys_dict` WHERE `dicttype` = 'bas_paytype' and keyname='SELFFEE'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["sn"].ToString();
            return ret;
        }
        public string getPatienttypeId(string ihsp_id)
        {
            string sql = "select bas_patienttype_id from inhospital where id =" + DataTool.addFieldBraces(ihsp_id) + ";";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["bas_patienttype_id"].ToString();
            return ret;
        }

        
        /// <summary>
        /// 护士预结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool NursYjs(string ihsp_id)
        {
            BllInsur bllInsur = new BllInsur();
            string patienttype_id = getPatienttypeId(ihsp_id);
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == CostInsurtypeKeyname.GZSYB.ToString())//贵州省医保
            {

                BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
                return bllInsurIhspGZS.NursYjs(ihsp_id);
            }
            else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())//贵阳市医保
            {
                BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
                return bllInsurGYSYB.NursYjs(ihsp_id);
            }
            else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())//贵州省农合
            {
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                return bllGzsnhMethod.NursYjs(ihsp_id);
            }
            BillSysBase.doIhspAmt(ihsp_id);
            return true;
        }
        
    }
}
