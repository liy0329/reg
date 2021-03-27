using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using System.Data;
using MTHIS.main.bll;
using MTREG.ihsp.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.bll;
using MTREG.common;

namespace MTREG.medinsur.hdyb.bll
{
    class BllInsur
    {

        /// <summary>
        /// 重打发票
        /// </summary>
        /// <param name="strZyh"></param>
        /// <returns></returns>
        public DataTable RetypeFP(string strZyh)
        {
            string sql = "SELECT "
                        + "insurcode,"
                        + "id"
                        + " FROM "
                        + "inhospital"
                        + " WHERE"
                        + " ihspcode="
                        + strZyh;
            DataTable dtselect = BllMain.Db.Select(sql).Tables[0];
            return dtselect;
        }  
        /// <summary>
        /// 医保出院登记
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public int outhspMag(string ihspcode,string ihsp_id)
        {
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态|经办人
            DataTable dataTable = readRegInfo(ihsp_id);
            string sql = "select AKC194 from KC21 where AKC190=" + DataTool.addFieldBraces(ihspcode);
            DataTable datatable = BllMain.InsurDb.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                BillIhspMan billIhspMan=new BillIhspMan();
                Ybjk ybjk=new Ybjk();
                Ybsjcs_in ryxx = new Ybsjcs_in();
                //修改住院医保接口状态
                int flag = billIhspMan.upinsurstat(ihspcode, Insurstat.SIGN.ToString());
                if (flag < 0)
                {
                    return -1;
                }
                //医保业务
                ryxx.Grbh = dataTable.Rows[0]["PersonalNum"].ToString();
                ryxx.Mzzyh = ihspcode;
                flag=ybjk.ybsjcs(ryxx);
                if (flag < 0)
                {
                    return -2;
                }
                return 0;
            }
            else
            {
                return -3;
            }
        }
        /// <summary>
        /// 存储邯郸医保登记信息
        /// </summary>
        /// <param name="regInfo"></param>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int saveSYRegInfo(string regInfo, string ihspid)
        {
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态
            string[] message = regInfo.Split('|');
            string strXml = "<info>";
            strXml += "<PersonalNum>" + message[0] + "</PersonalNum>";
            strXml += "<Iccardid>" + message[1] + "</Iccardid>";
            strXml += "<Ihspdiagn>" + message[2] + "</Ihspdiagn>";
            strXml += "<Ihspicd>" + message[3] + "</Ihspicd>";
            strXml += "<Ihsptype>" + message[4] + "</Ihsptype>";
            strXml += "<Balance>" + message[5] + "</Balance>";
            strXml += "<CompanyNo>" + message[6] + "</CompanyNo>";
            strXml += "<Isblock>" + message[7] + "</Isblock>";
            strXml += "</info>";
            return ihspInsurInfo(strXml, ihspid);
        }
        /// <summary>
        /// 插入邯郸市医保信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int ihspInsurInfo(string reginfo, string ihsp_id)
        {
            string id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihsp_id)
                                     + "," + DataTool.addFieldBraces(reginfo)
                                     + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 查询邯郸医保信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable hdybinfo(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
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
        /// 读取邯郸市医保登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readRegInfo(string ihspid)
        {
            DataTable dt = hdybinfo(ihspid);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }

        /// <summary>
        /// 插入/更改中软农合出院结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int accountInfo(string settinfo,string midsettinfo, string ihsp_id )
        {
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(settinfo)
                                    + ",midsettinfo=" + DataTool.addFieldBraces(midsettinfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 修改医保信息状态
        /// </summary>
        /// <param name="accountinfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int upopstat(string opstat, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set opstat=" + DataTool.addFieldBraces(opstat)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 医保住院登记
        /// </summary>
        public bool hdsybReg(string ihsp_id)
        {
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态|经办人
            DataTable dataTable = readRegInfo(ihsp_id);
            BillIhspMan billIhspMan = new BillIhspMan();
            BillIhspcost billIhspcost=new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            Ybjk ybjk = new Ybjk();
            string name = dt.Rows[0]["ihspname"].ToString();
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            string indate=dt.Rows[0]["indate"].ToString();
            string outdate = dt.Rows[0]["outdate"].ToString();
            string doctor = dt.Rows[0]["doctorname"].ToString();
            string depart = dt.Rows[0]["deparname"].ToString();
            string sickroom_id = dt.Rows[0]["sickroom_id"].ToString();
            string sickbed_id = dt.Rows[0]["sickbed_id"].ToString();
            string search_sql = "select count(*) from KC21 where AKC190=" + DataTool.addFieldBraces(ihspcode);
            string sql = "INSERT INTO KC21 (AKC190"
               +" ,CKC502"
               +" ,AAC003"
               +" ,AAC001"
               +" ,AAB001"
               +" ,AKA130"
               +" ,AKC192"
               +" ,AKC193"
               +" ,AKC194"
               +" ,zkc274"
               +" ,zkc271"
               +" ,zkc272"
               +" ,Cka040"
               +" ,Cka041"
               +" ,AAE011"
               +" ,AAE036"
               +" ,CKC126) values "
               + "(" + DataTool.addFieldBraces(ihspcode)
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["Iccardid"].ToString())
               + "," + DataTool.addFieldBraces(name)
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["PersonalNum"].ToString())
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["CompanyNo"].ToString())
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["Ihsptype"].ToString())
               + "," + DataTool.addFieldBraces(indate)
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["Ihspicd"].ToString())
               + "," + DataTool.addFieldBraces(outdate)
               + "," + DataTool.addFieldBraces(dataTable.Rows[0]["Ihspdiagn"].ToString())
               + "," + DataTool.addFieldBraces(doctor)
               + "," + DataTool.addFieldBraces(depart)
               + "," + DataTool.addFieldBraces(sickroom_id)
               + "," + DataTool.addFieldBraces(sickbed_id)
               + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
               + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                     + ",0)";
            DataSet ds = BllMain.InsurDb.Select(search_sql);
            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                BllMain.InsurDb.Update(sql);
            }
            Rydj_in ryxx = new Rydj_in();
            ryxx.Grbh = dataTable.Rows[0]["PersonalNum"].ToString();
            ryxx.Mzzyh = ihspcode;
            int flag = ybjk.rydj(ryxx);
            if (flag < 0)
            {
                billIhspMan.upinsurstat(ihspcode, Insurstat.OO.ToString());
                return false;
            }
            flag = billIhspMan.upinsurstat(ihspcode, Insurstat.REG.ToString());
            if (flag < 0)
            {              
                ybjk.rydj_ht(ryxx);
                return false;
            }
            upsjcs(ihspcode);
            upopstat("REG", ihsp_id);//REG已登记正确
            return true;
        }

        /// <summary>
        /// 入院登记回退||转自费
        /// </summary>
        /// <returns></returns>
        public int retIhspReg(string ihsp_id)
        {
            BillIhspcost billIhspcost=new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            Ybjk ybjk = new Ybjk();
            Dryjbxxhzh_out dryjbxxhzh_out = new Dryjbxxhzh_out();
            int flag = ybjk.dryjbxxzhxx(dryjbxxhzh_out);
            if (flag < 0)
            {
                return -2;
            }
            Rydj_in ryxx = new Rydj_in();
            ryxx.Grbh = dryjbxxhzh_out.Grbh;
            ryxx.Mzzyh = ihspcode;
            if (dryjbxxhzh_out.Zyzt == "出院已结算" || dryjbxxhzh_out.Zyzt == "中途结算")
            {               
                return -3;
            }
            flag = ybjk.rydj_ht(ryxx);
            if (flag < 0)
            {               
                return -4;
            }
            string sql = "delete from KC21 where AKC190='" + ihspcode + "'";
            BllMain.InsurDb.Update(sql);
            string sql1 = "delete from KC22 where AKC190='" + ihspcode + "'";
            BllMain.InsurDb.Update(sql1);
            upopstat("XX", ihsp_id);//REG已登记正确
            return 0;
        }

        /// <summary>
        /// 修改kc21传输标志，置为1
        /// </summary>
        /// <param name="zyh"></param>
        private void upsjcs(string zyh)
        {
            String sql = "UPDATE KC21 SET CKC126 =1 WHERE AKC190='" + zyh + "';";
            BllMain.InsurDb.Update(sql);
        }

        /// <summary>
        /// 50次执行传输
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="patienttypeid"></param>
        /// <param name="message"></param>
        public void costTransfer(string ihsp_id, string patienttypeid,StringBuilder message)
        {
            int flag=0;
            for ( ; ; )
            {
                flag = costTransferSub(ihsp_id, patienttypeid);
                if (flag < 50)
                    break;
                if (flag == 50)
                {

                }
            }
            switch (flag)
            {
                case -1: message.Append("读取医保信息失败!");
                    return;
                case -2: message.Append("添加对照表失败!");
                    return;
                case -3: message.Append("未找到相关表信息!");
                    return;
                case -4: message.Append("无可传输项!");
                    return;
                case -6: message.Append("添加目录表失败!");
                    return;
                case -5: message.Append("传入中间表失败!");
                    return;
                case -7: message.Append("医保传输失败!");
                    return;
            }
                
        }

        /// <summary>
        /// 费用信息传送到KC22
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int costTransferSub(string ihsp_id, string patienttypeid)
        {
            Ybjk ybjk = new Ybjk();
            string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "select inhospital.ihspcode"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.name"
                            + ", ihsp_costdet.standcode"
                            + ", insur_itemfrom.insurcode as itemfromcode"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", ihsp_costdet.item_id"
                            + " from ihsp_costdet"
                            + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                            + " left join insur_itemfrom on insur_itemfrom.itemtype_id=ihsp_costdet.itemtype_id"
                            + " where ihsp_costdet.ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                            + " and insur_itemfrom.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('RREC','RET','CHAR')"
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataSet ds = BllMain.Db.Select(sql1);
            if (ds.Tables.Count <= 0)
            {
                //未找到相关表信息!
                return -3;
            }
            DataTable datatable = ds.Tables[0];
            if (datatable.Rows.Count <= 0)
            {
                //无可传输项
                return -4;
            }
            string insurclass = "";
            string upsql = "";
            string insql = "";
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                string id = datatable.Rows[i]["id"].ToString();
                string ihspcode = datatable.Rows[i]["ihspcode"].ToString();
                string chargedate = Convert.ToDateTime(datatable.Rows[i]["chargedate"]).ToString("yyyy-MM-dd");//处方日期,结算日期
                string itemname = datatable.Rows[i]["name"].ToString();//收费项目名称
                string standcode = datatable.Rows[i]["standcode"].ToString();//医保编码
                string insurcode = datatable.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
                string prc = datatable.Rows[i]["prc"].ToString();//单价
                string fee = datatable.Rows[i]["fee"].ToString();//金额
                string num = datatable.Rows[i]["num"].ToString();//数量
                string itemid=datatable.Rows[i]["item_id"].ToString();
                string insuritemid = BillSysBase.nextId("cost_insuritem");
                string insurcrossid = BillSysBase.nextId("cost_insurcross");
                string selectsql="select cost_insuritem.insurclass"
                                +" from cost_insurcross "
                                +" left join cost_insuritem on cost_insuritem.id=cost_insurcross.cost_insuritem_id"
                                + " where cost_insurcross.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                                + " and cost_insurcross.item_id=" + DataTool.addFieldBraces(itemid);
                DataTable dtselect = BllMain.Db.Select(selectsql).Tables[0];
                if (dtselect.Rows.Count > 0)
                {
                    insurclass = dtselect.Rows[0]["insurclass"].ToString();
                }
                else
                {
                    //读取药品信息
                    if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
                    {
                        Dqypxx_out dqypxx_out = new Dqypxx_out();
                        string drugcode = ((int)InsurEnum.Yzc.YP).ToString();
                        int flag = ybjk.dqypxx(dqypxx_out, drugcode, 0);
                        if (flag < 0)
                        {
                            return -1;
                        }
                        insurclass = dqypxx_out.Fydj;
                    }
                    //读取诊疗信息
                    if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
                    {
                        Dqzlxx_out dqzlxx_out = new Dqzlxx_out();
                        string zlcode = Convert.ToString((int)InsurEnum.Yzc.ZL);
                        int flag = ybjk.dqzlxx(zlcode, dqzlxx_out, 0);
                        if (flag < 0)
                        {
                            return -1;
                        }
                        insurclass = dqzlxx_out.Fydj;
                    }
                    string sqlin = "insert into cost_insuritem(id"
                                                        +" ,cost_insurtype_id"
                                                        +" ,name"
                                                        +" ,pincode"
                                                        +" ,insurcode"
                                                        +" ,itemfrom"
                                                        +" ,insurclass)values (" + DataTool.addFieldBraces(insuritemid)
                                                        + "," + DataTool.addFieldBraces(insurtypeid)
                                                        + "," + DataTool.addFieldBraces(itemname)
                                                        + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(itemname))
                                                        + "," + DataTool.addFieldBraces(standcode)
                                                        + "," + DataTool.addFieldBraces(insurcode)
                                                        + "," + DataTool.addFieldBraces(insurclass)
                                                        + " );";
                    if (BllMain.Db.Update(sqlin) < 0)
                    {
                        //添加目录表失败!
                        return -6;
                    }
                    string sqlin1 = "insert into cost_insurcross(id"
                                                        + " ,cost_insurtype_id"
                                                        + " ,item_id"
                                                        + " ,cost_insuritem_id)values (" + DataTool.addFieldBraces(insurcrossid)
                                                        + "," + DataTool.addFieldBraces(insurtypeid)
                                                        + "," + DataTool.addFieldBraces(itemid)
                                                        + "," + DataTool.addFieldBraces(insuritemid)
                                                        + " );";
                    if (BllMain.Db.Update(sqlin1) < 0)
                    {
                        //添加对照表失败!
                        return -2;
                    }

                }
                insql += "insert into KC22(AKC190"
                                        + " ,AKC220"
                                        + " ,AAE072"
                                        + " ,AKC221"
                                        + " ,AKC515"
                                        + " ,AKC223"
                                        + " ,AKC224"
                                        + " ,AKC225"
                                        + " ,AKC226"
                                        + " ,AKC227"
                                        + " ,AAE040"
                                        + " ,CKC126"
                                        + " ,CKC125)"
                                        + "values(" + DataTool.addFieldBraces(ihspcode)//住院号
                                        + "," + DataTool.addFieldBraces(id)//处方号
                                        + "," + DataTool.addFieldBraces(ihspcode)//单据号预结算时等于住院号
                                        + "," + DataTool.addFieldBraces(chargedate)//处方日期
                                        + "," + DataTool.addFieldBraces(standcode)//医院收费项目编码（HIS系统的）
                                        + "," + DataTool.addFieldBraces(itemname)//收费项目名称
                                        + "," + DataTool.addFieldBraces(insurcode)//药品/诊疗/床位费
                                        + "," + DataTool.addFieldBraces(prc)//单价
                                        + "," + DataTool.addFieldBraces(num)//数量
                                        + "," + DataTool.addFieldBraces(fee)//金额
                                        + "," + DataTool.addFieldBraces(chargedate)//结算日期
                                        + ",0"
                                        + ",0"
                                        + ");";
                upsql += "update ihsp_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass) + " where id=" + DataTool.addFieldBraces(id) + ";";
            }
            if (BllMain.InsurDb.Update(insql) < 0)
            {
                //传入中间表失败
                return -5;
            }
            BllMain.Db.Update(upsql);
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态|经办人
            DataTable dtInfo = readRegInfo(ihsp_id);
            Ybsjcs_in ryxx=new Ybsjcs_in();
            ryxx.Mzzyh = ihsp_id;
            ryxx.Grbh = dtInfo.Rows[0]["PersonalNum"].ToString();
            if (ybjk.ybsjcs(ryxx) < 0)
            {
                //医保传输失败
                return -7;
            }
            return datatable.Rows.Count;
        }

        /// <summary>
        /// 修改单据号
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <param name="invoice"></param>
        public int upInvoice(string yllb,string ihspcode,string invoice)
        {
            string inspkind = aka130Keyname(yllb);
            if (inspkind == "NZJSHCY")
            {
                string sql = "update KC22 SET AAE072=" + DataTool.addFieldBraces(invoice) + " WHERE AKC190 = " + DataTool.addFieldBraces(ihspcode) + " and  AAE072 =" + DataTool.addFieldBraces(ihspcode) + ";";
                sql += "UPDATE KC21 SET AKA130=" + DataTool.addFieldBraces(yllb) + " where  AKC190 ='" + DataTool.addFieldBraces(ihspcode) + " and AKA130='28'";
                BllMain.InsurDb.Update(sql);
            }
            else
            {
                string sql1 = "update KC22 set AAE072=" + DataTool.addFieldBraces(invoice) + " where AKC190=" + DataTool.addFieldBraces(ihspcode);
                int flag=BllMain.InsurDb.Update(sql1);
                string sql2 = "UPDATE KC21 SET AKA130=" + DataTool.addFieldBraces(yllb) + " where  AKC190 =" + DataTool.addFieldBraces(ihspcode);
                BllMain.InsurDb.Update(sql2);
                if (flag <= 0)
                {
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 医保住院结算
        /// </summary>
        /// <param name="insurInfo"></param>
        /// <param name="ihsp_id"></param>
        public int insurAcc(string ihsp_id)
        {
            //个人编号|ic卡号|住院诊断名称|住院诊断编码|医疗类别|账户余额|单位编号|封锁状态|经办人
            DataTable dtInfo = readRegInfo(ihsp_id);
            string info1="";
            string inspkind = aka130Keyname(dtInfo.Rows[0]["Ihsptype"].ToString());
            DataTable dataTable = hdybinfo(ihsp_id);
            if (inspkind == "NZJS")
            {
                info1 = dataTable.Rows[0]["midsettinfo"].ToString();
            }
            else
            {
                info1 = dataTable.Rows[0]["settinfo"].ToString();
            }
            string[] message1 = info1.Split('|');////经办人|账户支付金额|单据号
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            Ybjk ybjk = new Ybjk();
            Zyjs_in zyjs_in = new Zyjs_in();
            Zyjs_out zyjs_out = new Zyjs_out();
            zyjs_in.Djh = message1[2];
            zyjs_in.Grbh = dtInfo.Rows[0]["PersonalNum"].ToString();
            zyjs_in.Jbr = message1[0];
            zyjs_in.Mzzyh = ihspcode;
            zyjs_in.Yllb = dtInfo.Rows[0]["Ihsptype"].ToString();
            zyjs_in.Zffs = "0";//支付方式为账号支付
            zyjs_in.Zhzfje = message1[1];
            int flag = ybjk.zyjs(zyjs_in, zyjs_out);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 医疗类别
        /// </summary>
        /// <returns></returns>
        public DataTable aka130()
        {
            DataTable dt = new DataTable();
            string sql = "select insurcode as id,name from insur_hdsyb_aka130 where isstop='N' and registkind='IHSP'";
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
        /// 医疗类别关键字
        /// </summary>
        /// <returns></returns>
        public string aka130Keyname(string insurcode)
        {
            string sql = "select keyname from insur_hdsyb_aka130 where isstop='N' and registkind='IHSP' and insurcode=" + DataTool.addFieldBraces(insurcode);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string keyname = datatable.Rows[0]["keyname"].ToString();
                return keyname;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 医保疾病名称下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable ihspdiagn(string pincode)
        {
            DataTable dt = new DataTable();
            string sql = "select id,name,illcode from cost_insurillness";
            if (pincode != "")
            {
                sql += " where pincode like '%" + pincode + "%'";
            }
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
        /// 获取医保类型关键字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getInsurtype(string id)
        {
            string sql = "select cost_insurtype.keyname as keyname "
                              + " from bas_patienttype "
                              + " left join cost_insurtype on cost_insurtype.id=bas_patienttype.cost_insurtype_id"
                              + " where bas_patienttype.id= " + DataTool.addFieldBraces(id);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string keyname = datatable.Rows[0]["keyname"].ToString();
                return keyname;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取医保类型id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getInsurtypeId(string id)
        {
            string sql = "select cost_insurtype_id"
                              + " from bas_patienttype "
                              + " where id= " + DataTool.addFieldBraces(id);
            DataTable datatable = BllMain.Db.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                string cost_insurtype_id = datatable.Rows[0]["cost_insurtype_id"].ToString();
                return cost_insurtype_id;
            }
            else
            {
                return "";
            }
        }
    }
}
