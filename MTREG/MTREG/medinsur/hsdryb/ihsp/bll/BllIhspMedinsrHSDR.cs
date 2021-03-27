using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.hsdryb.bll;
using System.Windows.Forms;

namespace MTREG.medinsur.hsdryb.ihsp.bll
{
    class BllIhspMedinsrHSDR
    {
        /// <summary>
        /// 获取门诊疾病
        /// </summary>
        /// <returns></returns>
        public DataTable getClinicDisease(string pincode)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "select id,name,illcode  from cost_insurillness where pincode like '%" + pincode.Trim() + "%' ";
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }
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
        public int insurReg()
        {
            return 0;
        }
        public DataTable getIhspcode(string id)
        {
            string sql = "select ihspcode from inhospital where id = " + DataTool.addFieldBraces(id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 插入医保信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int add_ihspInsurInfo(string reginfo, string ihsp_id)
        {
            //个人编号|ic卡号|医疗类别|账户余额|单位编号|单位名称|封锁状态|经办人|入院诊断疾病编码|疾病名称|人员类别
            string[] message = reginfo.Split('|');
            string strXml = "<info>";
            strXml += "<PersonalNum>" + message[0] + "</PersonalNum>";
            strXml += "<ICCardID>" + message[1] + "</ICCardID>";
            strXml += "<MediType>" + message[2] + "</MediType>";
            strXml += "<Balance>" + message[3] + "</Balance>";
            strXml += "<CompanyNum>" + message[4] + "</CompanyNum>";
            strXml += "<CompanyName>" + message[5] + "</CompanyName>";
            strXml += "<IsBlock>" + message[6] + "</IsBlock>";
            strXml += "<Maker>" + message[7] + "</Maker>";
            strXml += "<ClinicDiseaseCode>" + message[8] + "</ClinicDiseaseCode>";
            strXml += "<ClinicDiseaseName>" + message[9] + "</ClinicDiseaseName>";
            strXml += "<AKC021>" + message[10] + "</AKC021>";
            strXml += "<info>";
            string id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihsp_id)
                                     + "," + DataTool.addFieldBraces(strXml)
                                     + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                                     + ")";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 查询医保信息表
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable getInsurinfo(string ihsp_id)
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
        /// 读取医保信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable readInsurInfo(string ihsp_id)
        {
            DataTable dt = getInsurinfo(ihsp_id);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dtNew = ds.Tables["info"];
            return dtNew;
        }
        public void costdetTransfer(string ihsp_id, string patienttype, StringBuilder returnMsg)
        {
            int flag = 0;
            for (; ; )
            {
                flag = costdetTransferSub(ihsp_id, patienttype);
                if (flag < 50)
                    break;
                if (flag == 50)
                {

                }
            }
            switch (flag)
            {
                case -1: returnMsg.Append("读取医保信息失败!");
                    return;
                case -2: returnMsg.Append("添加对照表失败!");
                    return;
                case -3: returnMsg.Append("未找到相关表信息!");
                    return;
                case -4: returnMsg.Append("无可传输项!");
                    return;
                case -6: returnMsg.Append("添加目录表失败!");
                    return;
                case -5: returnMsg.Append("传入中间表失败!");
                    return;
            }
        }
        public int costdetTransferSub(string ihsp_id,string patienttype)
        {
            string sql = "";
            string costdetIds = "";
            string sql_search = "select inhospital.ihspcode,ihsp_costdet.id,ihsp_costdet.item_id,bas_item.name"
                              + ",case ihsp_costdet.itemfrom when 'DRUG' then '1' when 'COST' then '2' when 'STUFF' then '3' end as itemfrom"
                              + ",ihsp_costdet.prc,ihsp_costdet.Num,ihsp_costdet.realfee"
                              + " from ihsp_costdet left join bas_item on ihsp_costdet.item_id = bas_item.id"
                              + " left join inhospital on inhospital.id = ihsp_costdet.ihsp_id"
                              + " where ihsp_costdet.ihsp_id = " + ihsp_id;
            DataTable dt = BllMain.Db.Select(sql_search).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                return -4;
            }
            DataTable dtInsure = readInsurInfo(ihsp_id);
            string icCard = dtInsure.Rows[0]["ICCardID"].ToString();
            string ihspType = dtInsure.Rows[0]["MediType"].ToString();//医疗类别
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string id = dt.Rows[0]["id"].ToString();
                costdetIds += id + ",";
                string sql_sear = " select ihsp_advice.begindate from ihsp_advice"
                                + " where ihsp_advice.id = (select ihsp_advice_id from ihsp_advdet where id in ("
                                + " select ihsp_advdet_id from ihsp_costdet where id = " + DataTool.addFieldBraces(id)
                                + " ))";
                DataTable dt_sear = BllMain.Db.Select(sql_sear).Tables[0];

                sql += "insert into KC22 ( "
                         + " AKC190"
                         + ",AKC220"
                         + ",AKC221"
                         + ",AKC515"
                         + ",AKC516"
                         + ",AKC224"
                         + ",AKC225"
                         + ",AKC226"
                         + ",AKC227 ) values ( "
                         + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString())
                         + "," + DataTool.addFieldBraces(id)
                         + "," + DataTool.addFieldBraces(dt_sear.Rows[0]["begindate"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["item_id"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["name"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["itemfrom"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["prc"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["num"].ToString())
                         + "," + DataTool.addFieldBraces(dt.Rows[0]["realfee"].ToString())
                         + ");";
            }
            costdetIds = costdetIds.Substring(0,costdetIds.Length-1);
            int res = BllMain.Hsdrdb.Update(sql);
            if (res == 0)
            {
                string his_sql = "update clinic_costdet set insursync = " + DataTool.addFieldBraces("Y") + " where id in ( " + costdetIds + ")";
                BllMain.Db.Update(his_sql);
                TopParameter common = new TopParameter();
                WYJK wyjk = new WYJK();
                common.MSGNO = "1103";
                common.AKC190 = dt.Rows[0]["ihspcode"].ToString();
                common.AKC020 = icCard;
                common.AKA130 = ihspType;
                common.AKB020 = ProgramGlobal.Othvar_2;
                common.GRANTID = ProgramGlobal.Othvar_3;
                common.BATNO = ProgramGlobal.Othvar_1;
                common.OPERID = ProgramGlobal.User_id;
                common.OPERNAME = ProgramGlobal.Username;
                common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
                common.MSGID = WYJK.getLsh();//第二个获取流水号函数--------------------------------------------------------------------------------
                KC22 kc22 = new KC22();
                var list = Tools<KC22>.ConvertToList(notUploadedCost1(common.AKC190,costdetIds));
                common.KC22XML = (kc22.KC22_inXml(list));
                var opt = wyjk.zyfymxUpload(common);
                if (opt.ReturnNum != "-1")
                {
                    return 0;
                }
                else
                {
                    deleteKC22(common.AKC190, costdetIds);
                }
                return 0;
            }
            else
            {
                MessageBox.Show("上传至中间库信息失败 ---kc22---" + dt.Rows[0]["ihspcode"].ToString());
                return -1;
            }
        }
        //将中间库未上传的数据删除  防止重复数据
        private int deleteKC22(string zyh, string akc220s)
        {
            string sql = "delete from KC22 where akc190 = " + DataTool.addFieldBraces(zyh) + " and akc220 in (" + akc220s + ")";
            int res = BllMain.Hsdrdb.Update(sql);
            if (res == 0)
            {
                string sql_upt = " update ihsp_costdet set insursync = " + DataTool.addFieldBraces("N") + " where id in (" + akc220s + ")";
                BllMain.Db.Update(sql_upt);
            }
            else
            {
                MessageBox.Show("删除中间库数据失败！");
            }
            return res;
        }
        /// <summary>
        /// 中间库医保未上传费用信息
        /// </summary>
        /// <param name="mtzyjl_iid"></param>
        private DataTable notUploadedCost1(string zyh,string akc220s)
        {
            string sql = "select * from kc22 where akc190=" + DataTool.addFieldBraces(zyh) + " and akc220 in (" + akc220s + ")";
            return BllMain.Hsdrdb.Select(sql).Tables[0];
        }
        /// <summary>
        /// 传输病人就诊信息
        /// </summary>
        /// <returns></returns>
        public bool insurReg(string registinfo, string ihsp_id)
        {
            string[] retdata = registinfo.Split('|');
            string personalNum = retdata[0];
            string icCard = retdata[1];
            string ihspType = retdata[2];//医疗类别
            string companyNum = retdata[4];
            string companyName = retdata[5];
            string diseaseCode = retdata[8];
            string diseaseName = retdata[9];
            string personType = retdata[10];
            string sql_select = "select inhospital.id"
                              + " inhospital.ihspcode"
                              + ",inhospital.name"
                              + ",bas_sickroom.name as sickroom"
                              + ",bas_sickbed.name as sickbed"
                              + ",inhospital.depart_id"
                              + ",inhospital.doctor_id"
                              + ",bas_doctor.name as dctname"
                              + ",bas_depart.name as dptname"
                              + ",inhospital.indate"
                              + ",inhospital.ihspicd"
                              + ",inhospital.ihspdiagn"
                              + " from inhospital"
                              + " left join bas_doctor on inhospital.doctor_id = bas_doctor.id"
                              + " left join bas_depart on inhospital.depart_id = bas_depart.id"
                              + " left join bas_sickroom on inhospital.sickroom_id = bas_sickroom.id"
                              + " left join bas_sickbed on inhospital.sickbed_id = bas_sickbed.id"
                              + " where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql_select).Tables[0];
            TopParameter common = new TopParameter(); //头参数类
            common.MSGNO = "1101";
            common.AKC190 = dt.Rows[0]["ihspcode"].ToString();
            common.AKC020 = icCard;
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.AKA130 = ihspType;
            common.GRANTID = ProgramGlobal.Othvar_3;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            common.MSGID = WYJK.getLsh();
            KC21 kc21 = new KC21();
            kc21.AKC190 = dt.Rows[0]["ihspcode"].ToString(); ;
            kc21.AKA130 = ihspType;
            kc21.AAE011 = ProgramGlobal.Username;
            kc21.AKC192 = dt.Rows[0]["indate"].ToString();
            kc21.AAE036 = BillSysBase.currDate();
            kc21.AKC008 = dt.Rows[0]["dctname"].ToString();
            kc21.AKC025 = dt.Rows[0]["dptname"].ToString();
            kc21.AKC031 = dt.Rows[0]["id"].ToString();
            kc21.AAC003 = dt.Rows[0]["name"].ToString();
            kc21.AKC030 = dt.Rows[0]["sickroom"].ToString();
            kc21.AKE020 = dt.Rows[0]["sickbed"].ToString();
            kc21.AAC001 = personalNum;
            kc21.AKC020 = icCard;
            kc21.AAB001 = companyNum;
            kc21.AKC193 = diseaseCode;
            kc21.AKC140 = diseaseName;
            kc21.BKF040 = dt.Rows[0]["depart_id"].ToString();
            kc21.BKF050 = dt.Rows[0]["doctor_id"].ToString();
            kc21.AAB004 = companyName;
            kc21.AKC021 = personType;
            common.KC21XML = kc21.KC21_inXml(kc21);
            string sql_search = "select count(*) from KC21 where AKC190 = " + DataTool.addFieldBraces(kc21.AKC190);
            string sql_ist = "insert into KC21 ("
                          + " AKC190"
                          + ",AKA130"//医疗类别
                          + ",AKC192"
                          + ",AKC193"
                          + ",AAE011"
                          + ",AAE036"
                          + ",AKC008"
                          + ",AKC025"
                          + ",AKC140"
                          + ",AKC031) values ( "
                          + DataTool.addFieldBraces(dt.Rows[0]["ihspcode"].ToString())
                          + "," + DataTool.addFieldBraces(ihspType)
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["indate"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["ihspicd"].ToString())
                          + "," + DataTool.addFieldBraces(ProgramGlobal.Username)
                          + "," + DataTool.addFieldBraces(BillSysBase.currDate())
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["dctname"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["dptname"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["ihspdiagn"].ToString())
                          + "," + DataTool.addFieldBraces(dt.Rows[0]["id"].ToString())
                          + ")";
            DataTable dt_search = BllMain.Hsdrdb.Select(sql_search).Tables[0];
            if (int.Parse(dt_search.Rows[0][0].ToString()) == 0)
            {
                int result = BllMain.Hsdrdb.Update(sql_ist);
                if (result == 0)
                {
                    WYJK wyjk = new WYJK();
                    var opt = wyjk.zydj(common);
                    if (opt.ReturnNum != "-1")
                    {
                        string sql_upd = "update inhospital set insurstat = " + DataTool.addFieldBraces(Insurstat.REG.ToString())
                                   + " where id = " + DataTool.addFieldBraces(ihsp_id);
                        BllMain.Db.Update(sql_upd);
                        return true;
                    }
                    else
                    { 
                        MessageBox.Show("HIS调用医保接口失败！");
                        return false;
                    }
                    
                }
                else
                {
                    string sql_upd = "update inhospital set insurstat = " + DataTool.addFieldBraces(Insurstat.OO.ToString())
                                   + " where id = " + DataTool.addFieldBraces(ihsp_id);
                    BllMain.Db.Update(sql_upd);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("中间库患者信息已存在！");
                return true;
            }

        }
        /// <summary>
        /// 衡水医保住院登记修改
        /// </summary>
        /// <param name="reginfo"></param>
        public bool hsdrybEdit( string ihsp_id)
        {
            DataTable dtInsure=readInsurInfo(ihsp_id);
            string personalNum = dtInsure.Rows[0]["PersonalNum"].ToString();
            string icCard = dtInsure.Rows[0]["ICCardID"].ToString();
            string ihspType = dtInsure.Rows[0]["MediType"].ToString();//医疗类别
            string companyNum = dtInsure.Rows[0]["CompanyNum"].ToString();
            string companyName = dtInsure.Rows[0]["CompanyName"].ToString();
            string diseaseCode = dtInsure.Rows[0]["ClinicDiseaseCode"].ToString();
            string diseaseName = dtInsure.Rows[0]["ClinicDiseaseName"].ToString();
            string personType = dtInsure.Rows[0]["AKC021"].ToString();
            string his_sql = "select count(*) from inhospital where id = " + DataTool.addFieldBraces(ihsp_id)
                           + " and status = " + DataTool.addFieldBraces(IhspStatus.REG.ToString());
            DataTable dt_his = BllMain.Db.Select(his_sql).Tables[0];
            if (int.Parse(dt_his.Rows[0][0].ToString()) == 0)
            {
                MessageBox.Show("修改中间库入院登记信息失败！");
                return false;
            }
            else
            {
                string sql_select = "select inhospital.id"
                                  + " inhospital.ihspcode"
                                  + ",inhospital.name"
                                  + ",bas_sickroom.name as sickroom"
                                  + ",bas_sickbed.name as sickbed"
                                  + ",inhospital.depart_id"
                                  + ",inhospital.doctor_id"
                                  + ",bas_doctor.name as dctname"
                                  + ",bas_depart.name as dptname"
                                  + ",inhospital.indate"
                                  + ",inhospital.ihspicd"
                                  + ",inhospital.ihspdiagn"
                                  + " from inhospital"
                                  + " left join bas_doctor on inhospital.doctor_id = bas_doctor.id"
                                  + " left join bas_depart on inhospital.depart_id = bas_depart.id"
                                  + " left join bas_sickroom on inhospital.sickroom_id = bas_sickroom.id"
                                  + " left join bas_sickbed on inhospital.sickbed_id = bas_sickbed.id"
                                  + " where inhospital.id = " + DataTool.addFieldBraces(ihsp_id);
                DataTable dt = BllMain.Db.Select(sql_select).Tables[0];
                TopParameter common = new TopParameter();
                common.MSGNO = "1102";
                common.AKC190 = dt.Rows[0]["ihspcode"].ToString();
                common.AKC020 = icCard;
                common.AKA130 = ihspType;
                common.AKB020 = ProgramGlobal.Othvar_2;
                common.GRANTID = ProgramGlobal.Othvar_3;
                common.BATNO = ProgramGlobal.Othvar_1;
                common.OPERID = ProgramGlobal.User_id;
                common.OPERNAME = ProgramGlobal.Username;
                common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
                KC21 kc21 = new KC21();
                kc21.AKC190 = dt.Rows[0]["ihspcode"].ToString();
                kc21.AKA130 = ihspType;
                kc21.AAE011 = ProgramGlobal.Username;
                kc21.AKC192 = dt.Rows[0]["indate"].ToString();
                kc21.AAE036 = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
                kc21.AKC031 = ihsp_id;
                #region  可修改
                kc21.AKC025 = dt.Rows[0]["dptname"].ToString();
                kc21.AKE020 = "";
                kc21.BKF050 = dt.Rows[0]["doctor_id"].ToString();
                kc21.AKC008 = dt.Rows[0]["dctname"].ToString();
                kc21.AKC140 = diseaseName;
                kc21.AKC600 = "";
                #endregion
                string sql = "update KC21 set AKC025 = " + DataTool.addFieldBraces(kc21.AKC025)
                           + ",AKE020 = " + DataTool.addFieldBraces(kc21.AKE020)
                           + ",BKF050 = " + DataTool.addFieldBraces(kc21.BKF050)
                           + ",AKC008 = " + DataTool.addFieldBraces(kc21.AKC008)
                           + ",AKC140 = " + DataTool.addFieldBraces(kc21.AKC140)
                           + ",AKC600 = " + DataTool.addFieldBraces(kc21.AKC600)
                           + ";";
                BllMain.Hsdrdb.Update(sql);
                WYJK wyjk = new WYJK();
                var opt = wyjk.zydjxxxg(common);
                if (opt.ReturnNum != "-1")
                {
                    MessageBox.Show("信息更新成功！");
                    return true;
                }
                else
                {
                    MessageBox.Show("修改入院登记信息失败！");
                    return false;
                }

            }
        }
        public int deleteKC22Insur(string ihspid)
        {
            DataTable dtInsure = readInsurInfo(ihspid);
            string personalNum = dtInsure.Rows[0]["PersonalNum"].ToString();
            string icCard = dtInsure.Rows[0]["ICCardID"].ToString();
            string insurType = dtInsure.Rows[0]["MediType"].ToString();//医疗类别
            string sql_code = "select ihspcode from inhospital where id = " + DataTool.addFieldBraces(ihspid);
            string ihspcode = BllMain.Db.Select(sql_code).Tables[0].Rows[0]["ihspcode"].ToString();
            TopParameter common = new TopParameter();
            common.AKB020 = ProgramGlobal.Othvar_2;
            common.AKC190 = ihspcode;
            common.AKC020 = icCard;
            common.AKA130 = insurType;
            common.MSGNO = "1106";
            //string sql_lsh = "select lsh from mtybxx where lszt=2 and zyh='" + common.AKC190 + "';";

            common.MSGID = WYJK.getLsh();

            common.GRANTID = ProgramGlobal.Othvar_3;
            common.OPERID = ProgramGlobal.User_id;
            common.OPERNAME = ProgramGlobal.Username;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");
            common.INPUT = string.Format("<AAC001>{0}</AAC001><AKC190>{1}</AKC190><AKC281>{2}</AKC281><AKC220>{3}</AKC220><AKC515>{4}</AKC515>",personalNum,common.AKC190,"","","");
            WYJK wyjk = new WYJK();
            var opt = wyjk.zyfymxDelete(common);
            if(opt.ReturnNum != "-1")
            {
                string sql = " delete from KC22 where akc190 = " + DataTool.addFieldBraces(common.AKC190);
                if(BllMain.Hsdrdb.Update(sql)==0)
                {
                    string sql_upt = " update ihsp_costdet set insursync = " + DataTool.addFieldBraces("N") + " where ihsp_id =" + DataTool.addFieldBraces(ihspid);
                    BllMain.Db.Update(sql_upt);
                    return 0;//完全成功
                }
                return 1;//半成功
            }
            else 
            {
                return -1;//失败
            }
        }
        /// <summary>
        /// 更新住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upinsurstat(string ihspcode, string insurstat)
        {
            string sql = "update inhospital set insurstat=" + DataTool.addFieldBraces(insurstat) + " where ihspcode=" + DataTool.addFieldBraces(ihspcode);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 衡水出院登记
        /// </summary>
        /// <param name="ihspcode"></param>
        /// <returns></returns>
        public int outhspMag(string ihspcode, string ihsp_id,string invoiceCode,string amt,string useCard)
        {
            DataTable dtInsure = readInsurInfo(ihsp_id);//个人编号|ic卡号|医疗类别|账户余额|单位编号|单位名称|封锁状态|经办人|入院诊断疾病编码|疾病名称|人员类别
            string icCard = dtInsure.Rows[0]["ICCardID"].ToString();
            string insurType = dtInsure.Rows[0]["MediType"].ToString();//医疗类别       
            string sql = "select AKC190,AKA130,AKC192,AKC193,AKC194,AKC195,AKC196,AKC008,AKC025,AKC140,AKC141,AKC031 from KC21 where AKC190=" + DataTool.addFieldBraces(ihspcode);
            DataTable datatable = BllMain.Hsdrdb.Select(sql).Tables[0];
            if (datatable.Rows.Count > 0)
            {
                //修改住院医保接口状态
                int flag = upinsurstat(ihspcode, Insurstat.SIGN.ToString());
                if (flag < 0)
                {
                    return -1;
                }
                
                //医保业务
                WYJK wyjk = new WYJK();
                TopParameter common = new TopParameter();
                common.AKC190 = ihspcode;
                common.AKC020 = icCard;
                common.AKA130 = insurType;
                common.AKB020 = ProgramGlobal.Othvar_2;
                common.MSGNO = "1105";
                common.MSGID = WYJK.getLsh();
                common.GRANTID = ProgramGlobal.Othvar_3;
                common.OPERID = common.AKB020;
                common.OPERNAME = common.AKB020;
                common.BATNO = ProgramGlobal.Othvar_1;
                common.OPTTIME = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss");

                common.INPUT = string.Format("<AKC190>{0}</AKC190><AAE072>{1}</AAE072><ZKC759>{2}</ZKC759><AKC264>{3}</AKC264><BKC111>{4}</BKC111>", common.AKC190, invoiceCode,"1",amt,useCard);
                KC21 kc21 = new KC21
                {
                    AKC190 = common.AKC190,
                    AKA130 = common.AKA130,
                    AKC192 = datatable.Rows[0]["AKC192"].ToString(),
                    AKC193 = datatable.Rows[0]["AKC193"].ToString(),
                    AKC194 = datatable.Rows[0]["AKC194"].ToString(),
                    AKC195 = datatable.Rows[0]["AKC195"].ToString(),
                    AKC196 = datatable.Rows[0]["AKC196"].ToString(),
                    AAE011 = "WYH001",//Global.Myuser,
                    AAE036 = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyyMMddHHmmss"),
                    AKC008 = datatable.Rows[0]["AKC008"].ToString(),
                    AKC025 = datatable.Rows[0]["AKC025"].ToString(),
                    AKC140 = datatable.Rows[0]["AKC140"].ToString(),
                    AKC141 = datatable.Rows[0]["AKC141"].ToString(),
                    AKC031 = datatable.Rows[0]["AKC031"].ToString() 
                };
                common.KC21XML = kc21.KC21_inXml(kc21);
                var opt = wyjk.zyfyjs(common);
                if (opt.ReturnNum != "-1")
                {
                    MessageBox.Show("结算成功！");
                    return 0;
                }
                else
                {
                    MessageBox.Show("结算失败！");
                    return -1;
                }
                
            }
            else
            {
                return -2;
            }
        }
        public void setAccountState(string thisid)
        {
            string sql = "update ihsp_costdet set settled = " + DataTool.addFieldBraces("Y") + " where ihsp_id = " + DataTool.addFieldBraces(thisid);
            BllMain.Hsdrdb.Update(sql);
        }
        /// <summary>
        /// 插入/更改衡水武邑县医保出院结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int accountInfo(string settinfo, string midsettinfo, string ihsp_id)
        {
            //经办人|账户支付金额|单据号
            string[] message = settinfo.Split('|');
            string strXml = "<info>";
            strXml += "<Maker>" + message[0] + "</Maker>";
            strXml += "<InsuraccountFee>" + message[1] + "</InsuraccountFee>";
            strXml += "<Invoice>" + message[2] + "</Invoice>";
            strXml += "<info>";
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(strXml)
                                    + ",midsettinfo=" + DataTool.addFieldBraces(midsettinfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id)
                                     + ")";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 查询衡水武邑县医保信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable hsdrybinfo(string ihsp_id)
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
        /// 读取衡水武邑县医保登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readRegInfo(string ihspid)
        {
            DataTable dt = hsdrybinfo(ihspid);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 读取衡水武邑县医保结算信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readSettleInfo(string ihspid)
        {
            DataTable dt = hsdrybinfo(ihspid);
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
    }
}
