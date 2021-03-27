using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.ynydyb.bo;
using MTREG.common;

namespace MTREG.medinsur.ynydyb.bll
{
    class BllYnydybMethod
    {
        /// <summary>
        /// 记录业务周期号
        /// </summary>
        /// <param name="regCode"></param>
        /// <returns></returns>
        public int inBusiCycleNo(string regCode,string regdate)
        {
            string sql = "update acc_account set regcode=" + DataTool.addFieldBraces(regCode)
                + ",regdate=" + DataTool.addFieldBraces(regdate)
                + " where id=" + DataTool.addIntBraces(ProgramGlobal.Account_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 获取业务周期号
        /// </summary>
        /// <returns></returns>
        public DataTable getBusiCycleNo()
        {
            string sql = "select regcode,regdate from acc_account where id=" + DataTool.addIntBraces(ProgramGlobal.User_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getname(string type, string id)
        {
            string sql = "";
            if (type == "depart")
            {
                sql = "select name from bas_depart where id=" + DataTool.addIntBraces(id);
            }
            else if (type == "doctor")
            {
                sql = "select name from bas_doctor where id=" + DataTool.addIntBraces(id);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["name"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 住院费用50次执行传输
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="patienttypeid"></param>
        /// <param name="message"></param>
        public void costTransfer(string ihsp_id, string patienttypeid, StringBuilder message)
        {
            StringBuilder retmessage = new StringBuilder();
            int flag = 0;
            for (; ; )
            {                
                flag = ihspTransferSub(ihsp_id, patienttypeid, retmessage);
                if (flag < 50)
                    break;
                if (flag == 50)
                {

                }
            }
            switch (flag)
            {
                case -1: message = retmessage;
                    return;
                case -2: message.Append("添加对照表失败!");
                    return;
                case -3: message.Append("未找到相关表信息!");
                    return;
                case -4: message.Append("无可传输项!");
                    return;
                case -6: message.Append("添加目录表失败!");
                    return;
                case -7: message.Append("医保费用传输记录添加失败!");
                    return;
            }
        }  
        
        public int ihspTransferSub(string patienttypeid, string ihsp_id, StringBuilder retMessage)
        {
            int flag = 0;
            YNYDYB ynydyb = new YNYDYB();
            string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "select inhospital.ihspcode"
                            + ", ihsp_costdet.ihsp_id"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.costexdate"
                            + ", ihsp_costdet.name"
                            + ", ihsp_costdet.standcode"
                            + ", insur_itemfrom.insurcode as itemfromcode"
                            + ", insur_itemfrom1.insurcode as itemfrom1code"
                            + ", cost_insuritem.insurcode as insurcode"
                            + ", cost_insuritem.name2 as insurname"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", ihsp_costdet.unit"
                            + ", ihsp_costdet.diagndep_id"
                            + ", ihsp_costdet.diagndoctor_id"
                            + ", ihsp_costdet.item_id"
                            + ", ihsp_costdet.charged"
                            + " from ihsp_costdet"
                            + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                            + " left join insur_itemfrom on insur_itemfrom.itemtype_id=ihsp_costdet.itemtype_id"
                            + " left join insur_itemfrom1 on insur_itemfrom1.itemtype1_id=ihsp_costdet.itemtype1_id"
                            + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id"
                            + " left join cost_insuritem on cost_insuritem.id=cost_insurcross.cost_insuritem_id"
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
            DataTable dtInsure = readIhspRegInfo(ihsp_id);//记录的医保信息
            string insurclass = "";
            string upsql = "";
            //获取项目单价
            YdHqxmdj_in ydHqxmdj_in1 = new YdHqxmdj_in();
            YdHqxmdj_out ydHqxmdj_out1 = new YdHqxmdj_out();
            ydHqxmdj_in1.Cbdtcqbh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydHqxmdj_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            //项目审批结果查询
            YdXmspjgcx_in ydXmspjgcx_in1 = new YdXmspjgcx_in();
            YdXmspjgcx_out ydXmspjgcx_out1 = new YdXmspjgcx_out();
            ydXmspjgcx_in1.Cbdtcqbh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydXmspjgcx_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            //处方明细录入
            YdCfmxlr_out ydCcfmxlr_out1 = new YdCfmxlr_out();
            YdCfmxlr_in ydCfmxlr_in1 = new YdCfmxlr_in();
            ydCfmxlr_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            ydCfmxlr_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydCfmxlr_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
            ydCfmxlr_in1.Czybh = ProgramGlobal.User_id;
            ydCfmxlr_in1.Ywzqh = ynydybGlobal.Ywzqh;
            //处方明细退方
            YdCfmxtf_in ydCfmxtf_in1 = new YdCfmxtf_in();
            YdCfmxtf_out ydCfmxtf_out1 = new YdCfmxtf_out();
            ydCfmxtf_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            ydCfmxtf_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydCfmxtf_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
            ydCfmxtf_in1.Czybh = ProgramGlobal.User_id;
            ydCfmxtf_in1.Ywzqh = ynydybGlobal.Ywzqh;
            //获取发送方流水号
            Hqfsflsh_out hqfsflsh_out1 = new Hqfsflsh_out();
            for (int i = 0; i < datatable.Rows.Count; i++ )
            {               
                string id = datatable.Rows[i]["id"].ToString();
                string ihspcode = datatable.Rows[i]["ihspcode"].ToString();
                string chargedate = Convert.ToDateTime(datatable.Rows[i]["chargedate"]).ToString("yyyy-MM-dd");//处方日期,结算日期
                string itemname = datatable.Rows[i]["name"].ToString();//收费项目名称
                string standcode = datatable.Rows[i]["standcode"].ToString();//医院收费项目内码
                string insurcode = datatable.Rows[i]["insurcode"].ToString();//医保项目编码
                string insurname = datatable.Rows[i]["insurname"].ToString();//医保项目编码
                string itemfromcode = datatable.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
                string itemfrom1code = datatable.Rows[i]["itemfrom1code"].ToString();//核算类别
                string prc = datatable.Rows[i]["prc"].ToString();//单价
                string fee = datatable.Rows[i]["fee"].ToString();//金额
                string num = datatable.Rows[i]["num"].ToString();//数量
                string unit = datatable.Rows[i]["unit"].ToString();//单位
                string doctorname = getname("doctor", datatable.Rows[i]["diagndoctor_id"].ToString());
                string departname = getname("depart", datatable.Rows[i]["diagndep_id"].ToString());
                string costexdate = datatable.Rows[i]["costexdate"].ToString();//开方时间
                string itemid = datatable.Rows[i]["item_id"].ToString();                
                if (datatable.Rows[i]["charged"].ToString() == "CHAR" || datatable.Rows[i]["charged"].ToString() == "RET")
                {
                    ydHqxmdj_in1.Fylb = itemfrom1code;///收费大类对比
                    ydHqxmdj_in1.Sfxmbm = insurcode;
                    ydHqxmdj_in1.Yydj = prc;
                    flag = ynydyb.ydhqxmdj(ydHqxmdj_in1, ydHqxmdj_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[住院号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + ydHqxmdj_out1.ErrorMessage + " 异地医保--确定明细项目单价出错 | ");
                        return -1;
                    }
                    ydXmspjgcx_in1.Xmbh = itemid;
                    ydXmspjgcx_in1.Kfsj = costexdate;
                    flag = ynydyb.ydxmspjgcx(ydXmspjgcx_in1, ydXmspjgcx_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[住院号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + ydXmspjgcx_out1.ErrorMessage + " 异地医保--项目审批结果查询出错 | ");
                        return -1;
                    }
                    flag = ynydyb.hqfsflsh(hqfsflsh_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[住院号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + hqfsflsh_out1.ErrorMessage + " 异地医保--获取发送方交易流水号失败 | ");
                        return -1;
                    }
                    ydCfmxlr_in1.Fsfjylsh = hqfsflsh_out1.Swqjwyzym;
                    ydCfmxlr_in1.Zyh = ihspcode;
                    ydCfmxlr_in1.Cfh = ihsp_id;
                    ydCfmxlr_in1.Cfnxh = id;
                    ydCfmxlr_in1.Yysfxmnm = standcode;
                    ydCfmxlr_in1.Yysfxmmc = itemname;
                    ydCfmxlr_in1.Sfxmbm = insurcode;
                    if (ydCfmxlr_in1.Sfxmbm == "")
                    {
                        ydCfmxlr_in1.Sfxmbm = "9999999999";
                    }
                    ydCfmxlr_in1.Sfxmmc = insurname;
                    ydCfmxlr_in1.Sflb = itemfromcode;
                    ydCfmxlr_in1.Sfdl = itemfrom1code;//收费大类改进
                    ydCfmxlr_in1.Dj = prc;
                    ydCfmxlr_in1.Sl = num;
                    ydCfmxlr_in1.Je = fee;
                    ydCfmxlr_in1.Dw = unit;
                    ydCfmxlr_in1.Kfrq = Convert.ToDateTime(costexdate).ToString("yyyy-MM-dd HH:mm:ss");
                    ydCfmxlr_in1.Kfks = departname;
                    ydCfmxlr_in1.Kfys = doctorname;
                    ydCfmxlr_in1.Xgspbh = ydXmspjgcx_out1.Spbh;
                    ydCfmxlr_in1.Cd = "";
                    ydCfmxlr_in1.Jbr = ProgramGlobal.Username;
                    StringBuilder jsfjylsh_ydcfmxlr = new StringBuilder(2048);
                    flag = ynydyb.ydcfmxlr(jsfjylsh_ydcfmxlr, ydCfmxlr_in1, ydCcfmxlr_out1);
                    if (flag != 0)
                    {
                        if (flag == -2)
                        {
                            YNYDYB ynydyb_yddjcz = new YNYDYB();
                            Hqfsflsh_out hqfsflsh_out_ydcfmxlrcz = new Hqfsflsh_out();
                            int opt_hqjslsh_djcz = ynydyb_yddjcz.hqfsflsh(hqfsflsh_out_ydcfmxlrcz);
                            if (opt_hqjslsh_djcz != 0)
                            {

                                retMessage.Append("[住院号:" + ihspcode + "]-" + hqfsflsh_out_ydcfmxlrcz.ErrorMessage + " 异地医保--获取处方明细录入冲正发送方交易流水号出错 | ");
                                return -1;
                            }

                            YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                            YdCzjy_out ydCzjy_out1 = new YdCzjy_out();                            
                            ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydcfmxlrcz.Swqjwyzym;
                            ydCzjy_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
                            ydCzjy_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
                            ydCzjy_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
                            ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                            ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                            ydCzjy_in1.Yjym = "11";
                            ydCzjy_in1.Yfsfjylsh = ydCfmxlr_in1.Fsfjylsh;


                            StringBuilder jsfjylsh_ydcfmxlrcz = new StringBuilder(2048);
                            flag = ynydyb_yddjcz.ydczjy(jsfjylsh_ydcfmxlrcz, ydCzjy_in1, ydCzjy_out1);
                            if (flag != 0)
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + ydCzjy_out1.ErrorMessage + " 异地医保--处方明细录入冲正出错 | ");
                                return -1;
                            }
                            if (ydCzjy_out1.Czzt == "0")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细录入无需冲正 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "1")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细录入冲正成功 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "2")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细录入禁止冲正 | ");
                                return -1;
                            }
                        }
                        else
                        {
                            retMessage.Append("[住院号:" + ihspcode + "]-" + ydCcfmxlr_out1.ErrorMessage + " 异地医保--处方明细录入出错 | ");
                            return -1;
                        }
                    }                    
                    flag=inInserCostdetId(ydCcfmxlr_out1, id,"", hqfsflsh_out1.Swqjwyzym);
                    if (flag<0)
                    {
                        //医保费用传输记录添加失败!
                        return -7;
                    }
                }
                else
                {
                    int opstat5 = ynydyb.hqfsflsh(hqfsflsh_out1);
                    if (opstat5 != 0)
                    {
                        retMessage.Append("[住院号:" + ihspcode + "]-" + hqfsflsh_out1.ErrorMessage + " 异地医保--获取发送方交易流水号失败 | ");
                        continue;
                    }
                    ydCfmxtf_in1.Fsfjylsh = hqfsflsh_out1.Swqjwyzym;
                    ydCfmxtf_in1.Jzdjh = dtInsure.Rows[0]["AKC190"].ToString();
                    DataTable dtCostdet = getInsurCostdetId(id, "ihsp");
                    ydCfmxtf_in1.Mxlrjyfhdjylsh = dtCostdet.Rows[0]["insur_costed_id"].ToString();//明细录入交易返回的交易流水号
                    ydCfmxtf_in1.Tcsl = (-double.Parse(num)).ToString();
                    ydCfmxtf_in1.Tcje = (-double.Parse(fee)).ToString();
                    ydCfmxtf_in1.Jbr = ProgramGlobal.User_id;

                    StringBuilder jsfjylsh_ydcfmxtf = new StringBuilder(2048);
                    int opt = ynydyb.ydcfmxtf(jsfjylsh_ydcfmxtf, ydCfmxtf_in1, ydCfmxtf_out1);
                    if (opt != 0)
                    {
                        if (opt == -2)
                        {
                            YNYDYB ynydyb_yddjcz = new YNYDYB();
                            Hqfsflsh_out hqfsflsh_out_ydcfmxtfcz = new Hqfsflsh_out();
                            int opt_hqjslsh_djcz = ynydyb_yddjcz.hqfsflsh(hqfsflsh_out_ydcfmxtfcz);
                            if (opt_hqjslsh_djcz != 0)
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + hqfsflsh_out_ydcfmxtfcz.ErrorMessage + " 异地医保--获取处方明细录入冲正发送方交易流水号出错 | ");
                                return -1;
                            
                            }

                            YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                            YdCzjy_out ydCzjy_out1 = new YdCzjy_out();

                            ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydcfmxtfcz.Swqjwyzym;
                            ydCzjy_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
                            ydCzjy_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
                            ydCzjy_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
                            ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                            ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                            ydCzjy_in1.Yjym = "11";
                            ydCzjy_in1.Yfsfjylsh = ydCfmxtf_in1.Fsfjylsh;


                            StringBuilder jsfjylsh_ydcfmxtfcz = new StringBuilder(2048);
                            int opt_yddjcz = ynydyb_yddjcz.ydczjy(jsfjylsh_ydcfmxtfcz, ydCzjy_in1, ydCzjy_out1);
                            if (opt_yddjcz != 0)
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + ydCzjy_out1.ErrorMessage + " 异地医保--处方明细退方出错 | ");
                                return -1;
                            }
                            if (ydCzjy_out1.Czzt == "0")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细退方无需冲正 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "1")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细退方冲正成功 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "2")
                            {
                                retMessage.Append("[住院号:" + ihspcode + "]-" + " 异地医保--处方明细退方禁止冲正 | ");
                                return -1;
                            }

                        }
                        else
                        {
                            retMessage.Append( "[住院号:" + ihspcode + "]-" + ydCfmxtf_out1.ErrorMessage + " 异地医保--处方明细退方出错 | ");
                            return -1;
                        }

                    }
                }
                upsql += "update ihsp_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass) + " where id=" + DataTool.addFieldBraces(id) + ";";                
                insurclass = ydCcfmxlr_out1.Xmsfdj;
                string insuritemid = BillSysBase.nextId("cost_insuritem");
                string insurcrossid = BillSysBase.nextId("cost_insurcross");
                string selectsql = "select cost_insuritem.insurclass"
                                + " from cost_insurcross "
                                + " left join cost_insuritem on cost_insuritem.id=cost_insurcross.cost_insuritem_id"
                                + " where cost_insurcross.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                                + " and cost_insurcross.item_id=" + DataTool.addFieldBraces(itemid);
                DataTable dtselect = BllMain.Db.Select(selectsql).Tables[0];
                if (dtselect.Rows.Count == 0)
                {
                    string sqlin = "insert into cost_insuritem(id"
                                                                + " ,cost_insurtype_id"
                                                                + " ,name"
                                                                + " ,pincode"
                                                                + " ,insurcode"
                                                                + " ,itemfrom"
                                                                + " ,insurclass)values (" + DataTool.addFieldBraces(insuritemid)
                                                                + "," + DataTool.addFieldBraces(insurtypeid)
                                                                + "," + DataTool.addFieldBraces(itemname)
                                                                + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(itemname))
                                                                + "," + DataTool.addFieldBraces("")
                                                                + "," + DataTool.addFieldBraces(itemfromcode)
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
            }
            if (BllMain.Db.Update(upsql)<0)
            {
                retMessage.Append("修改费用传输状态失败!");
                return -1;               
            }
            return datatable.Rows.Count;
        }

        /// <summary>
        /// 获取医保传输号
        /// </summary>
        /// <param name="costdet_id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable getInsurCostdetId(string costdet_id,string type)
        {
            string sql = "";
            if (type == "ihsp")
            {
                sql = "select insur_costed_id from insur_costed where ihsp_costed_id=" + DataTool.addIntBraces(costdet_id);
            }
            else if (type == "clinic")
            {
                sql = "select insur_costed_id from insur_costed where clinic_costed_id=" + DataTool.addIntBraces(costdet_id);
            }
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 插入医保费用传输信息
        /// </summary>
        /// <param name="ydCcfmxlr_out1"></param>
        /// <param name="costdetId"></param>
        /// <param name="insurCostId"></param>
        /// <returns></returns>
        public int inInserCostdetId(YdCfmxlr_out ydCcfmxlr_out1,string ihspCostdetId,string clinicCostdetId,string insurCostId)
        {
            string costDetInfo = "<info>"
                        + "<prc>" + ydCcfmxlr_out1.Sjdj + "</prc>"
                        + "<insurclass>" + ydCcfmxlr_out1.Xmsfdj + "</insurclass>"
                        + "<AAE073>" + ydCcfmxlr_out1.Spbh + "</AAE073>"
                        + "<AKC229>" + ydCcfmxlr_out1.Zfbl + "</AKC229>"
                        + "<fee>" + ydCcfmxlr_out1.Fyze + "</fee>"
                        + "<AKC253>" + ydCcfmxlr_out1.Qzfbf + "</AKC253>"
                        + "<AKC228>" + ydCcfmxlr_out1.Xzfbf + "</AKC228>"
                        + "<AKC800>" + ydCcfmxlr_out1.Yxbxbf + "</AKC800>";
            string insurId = BillSysBase.nextId("insur_costdet");
            string sqlCostdet = "insert into insur_costdet(id"
                                + ",ihsp_costdet_id"
                                + ",clinic_costdet_id"
                                + ",insur_cost_id"
                                + ",costdetinfo)values("
                                + DataTool.addIntBraces(insurId)
                                + "," + DataTool.addFieldBraces(ihspCostdetId)
                                + "," + DataTool.addFieldBraces(clinicCostdetId)
                                + "," + DataTool.addFieldBraces(insurCostId)
                                + "," + DataTool.addFieldBraces(costDetInfo)
                                + ");";
            return BllMain.Db.Update(sqlCostdet);
        }
        /// <summary>
        /// 门诊费用50次执行传输
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="patienttypeid"></param>
        /// <param name="message"></param>
        public void clinicCostTransfer(string clinic_cost_ids, StringBuilder message)
        {
            StringBuilder retmessage = new StringBuilder();
            int flag = 0;
            for (; ; )
            {
                flag = clinicTransferSub(clinic_cost_ids, retmessage);
                if (flag < 50)
                    break;
                if (flag == 50)
                {

                }
            }
            switch (flag)
            {
                case -1: message = retmessage;
                    return;
                case -2: message.Append("添加对照表失败!");
                    return;
                case -3: message.Append("未找到相关表信息!");
                    return;
                case -4: message.Append("无可传输项!");
                    return;
                case -6: message.Append("添加目录表失败!");
                    return;
                case -7: message.Append("医保费用传输记录添加失败!");
                    return;
            }
        }  
        
        /// <summary>
        /// 门诊费用传输
        /// </summary>
        /// <returns></returns>
        public int clinicTransferSub(string clinic_cost_ids,StringBuilder retMessage)
        {
            int flag=0;
            YNYDYB ynydyb=new YNYDYB();
            string sql = "select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.YNYDYB.ToString());
            DataTable dt_insurtype = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt_insurtype.Rows[0]["id"].ToString();
            DataTable dt = new DataTable();
            string sql_slt = "select "
                           + " clinic_costdet.id"
                           + ",clinic_cost.billcode"
                           + ",clinic_cost.rcpdate"
                           + ",clinic_costdet.item_id"
                           + ",clinic_costdet.standcode"
                           + ",clinic_costdet.name"
                           + ", cost_insuritem.insurcode as insurcode"
                           + ", cost_insuritem.name2 as insurname"
                           + ",clinic_costdet.prc"
                           + ",clinic_costdet.num"
                           + ",clinic_costdet.fee"
                           + ",clinic_costdet.spec"
                           + ",clinic_costdet.unit"
                           + ",clinic_costdet.charged"
                           + ",clinic_costdet.chargedate"
                           + ",clinic_costdet.depart_id"
                           + ",clinic_costdet.doctor_id"
                           + ",clinic_costdet.clinic_rcpdetail_id"
                           + ",insur_itemfrom.insurcode as itemfromcode"
                           + ",insur_itemfrom1.insurcode as itemfrom1code"
                           + " from clinic_costdet"
                           + " left join clinic_cost on clinic_cost.id = clinic_costdet.clinic_cost_id"
                           + " left join insur_itemfrom on insur_itemfrom.itemtype_id = clinic_costdet.itemtype_id"
                           + " left join insur_itemfrom1 on insur_itemfrom1.itemtype1_id=clinic_costdet.itemtype1_id"
                           + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id"
                           + " left join cost_insuritem on cost_insuritem.id=cost_insurcross.cost_insuritem_id"
                           + " and insur_itemfrom.cost_insurtype_id =" + DataTool.addFieldBraces(insurtypeid)
                           + " where clinic_costdet.insursync='N'"
                           + " and clinic_costdet.charged in ('RREC','RET','CHAR')"
                           + " and clinic_costdet.id in (" + DataTool.addFieldBraces(clinic_cost_ids) + ")"
                           + " ORDER BY clinic_costdet.id DESC limit 50";
            DataSet ds = BllMain.Db.Select(sql_slt);
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
            DataTable dtInsure = readClinicRegInfo(/*clinic_Invoice_id*/"");//记录的医保信息
            string insurclass = "";
            string upsql = "";
            YNYDYB ynydyb_yddjcz = new YNYDYB();
            //获取项目单价
            YdHqxmdj_in ydHqxmdj_in1 = new YdHqxmdj_in();
            YdHqxmdj_out ydHqxmdj_out1 = new YdHqxmdj_out();
            ydHqxmdj_in1.Cbdtcqbh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydHqxmdj_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            //项目审批结果查询
            YdXmspjgcx_in ydXmspjgcx_in1 = new YdXmspjgcx_in();
            YdXmspjgcx_out ydXmspjgcx_out1 = new YdXmspjgcx_out();
            ydXmspjgcx_in1.Cbdtcqbh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydXmspjgcx_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            //处方明细录入
            YdCfmxlr_out ydCcfmxlr_out1 = new YdCfmxlr_out();
            YdCfmxlr_in ydCfmxlr_in1 = new YdCfmxlr_in();
            ydCfmxlr_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            ydCfmxlr_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydCfmxlr_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
            ydCfmxlr_in1.Czybh = ProgramGlobal.User_id;
            ydCfmxlr_in1.Ywzqh = ynydybGlobal.Ywzqh;
            //处方明细退方
            YdCfmxtf_in ydCfmxtf_in1 = new YdCfmxtf_in();
            YdCfmxtf_out ydCfmxtf_out1 = new YdCfmxtf_out();
            ydCfmxtf_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
            ydCfmxtf_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
            ydCfmxtf_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
            ydCfmxtf_in1.Czybh = ProgramGlobal.User_id;
            ydCfmxtf_in1.Ywzqh = ynydybGlobal.Ywzqh;
            //获取发送方流水号
            Hqfsflsh_out hqfsflsh_out1 = new Hqfsflsh_out();
            for (int i = 0; i < datatable.Rows.Count; i++ )
            {               
                string id = datatable.Rows[i]["id"].ToString();
                string billcode = datatable.Rows[i]["billcode"].ToString();
                string chargedate = Convert.ToDateTime(datatable.Rows[i]["chargedate"]).ToString("yyyy-MM-dd");//处方日期,结算日期
                string itemname = datatable.Rows[i]["name"].ToString();//收费项目名称
                string standcode = datatable.Rows[i]["standcode"].ToString();//医院收费项目内码
                string insurcode = datatable.Rows[i]["insurcode"].ToString();//医保项目编码
                string insurname = datatable.Rows[i]["insurname"].ToString();//医保项目名称
                string itemfromcode = datatable.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
                string itemfrom1code = datatable.Rows[i]["itemfrom1code"].ToString();//核算类别
                string prc = datatable.Rows[i]["prc"].ToString();//单价
                string fee = datatable.Rows[i]["fee"].ToString();//金额
                string num = datatable.Rows[i]["num"].ToString();//数量
                string unit = datatable.Rows[i]["unit"].ToString();//单位
                string doctorname = getname("doctor", datatable.Rows[i]["doctor_id"].ToString());
                string departname = getname("depart", datatable.Rows[i]["depart_id"].ToString());
                string rcpDateSql="select rcpdate from clinic_rcp where id=(select clinic_rcp_id from clinic_rcpdetail where id="+DataTool.addIntBraces(datatable.Rows[i]["clinic_rcpdetail_id"].ToString()) +")";
                DataTable rcpDt=BllMain.Db.Select(rcpDateSql).Tables[0];
                string costexdate = rcpDt.Rows[0]["rcpdate"].ToString();//开方时间
                string itemid = datatable.Rows[i]["item_id"].ToString();
                if (datatable.Rows[i]["charged"].ToString() == "CHAR" || datatable.Rows[i]["charged"].ToString() == "RET")
                {
                    ydHqxmdj_in1.Fylb = itemfrom1code;///收费大类对比
                    ydHqxmdj_in1.Sfxmbm = insurcode;
                    ydHqxmdj_in1.Yydj = prc;
                    flag = ynydyb.ydhqxmdj(ydHqxmdj_in1, ydHqxmdj_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[门诊号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + ydHqxmdj_out1.ErrorMessage + " 异地医保--确定明细项目单价出错 | ");
                        return -1;
                    }
                    ydXmspjgcx_in1.Xmbh = itemid;
                    ydXmspjgcx_in1.Kfsj = costexdate;
                    flag = ynydyb.ydxmspjgcx(ydXmspjgcx_in1, ydXmspjgcx_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[门诊号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + ydXmspjgcx_out1.ErrorMessage + " 异地医保--项目审批结果查询出错 | ");
                        return -1;
                    }
                    flag = ynydyb.hqfsflsh(hqfsflsh_out1);
                    if (flag != 0)
                    {
                        retMessage.Append("[门诊号:" + datatable.Rows[0]["ihspcode"].ToString() + "]-" + hqfsflsh_out1.ErrorMessage + " 异地医保--获取发送方交易流水号失败 | ");
                        return -1;
                    }
                    ydCfmxlr_in1.Fsfjylsh = hqfsflsh_out1.Swqjwyzym;
                    ydCfmxlr_in1.Zyh = billcode;
                    ydCfmxlr_in1.Cfh = billcode;
                    ydCfmxlr_in1.Cfnxh = id;
                    ydCfmxlr_in1.Yysfxmnm = standcode;
                    ydCfmxlr_in1.Yysfxmmc = itemname;
                    ydCfmxlr_in1.Sfxmbm = insurcode;
                    if (ydCfmxlr_in1.Sfxmbm == "")
                    {
                        ydCfmxlr_in1.Sfxmbm = "9999999999";
                    }
                    ydCfmxlr_in1.Sfxmmc = insurname;
                    ydCfmxlr_in1.Sflb = itemfromcode;
                    ydCfmxlr_in1.Sfdl = itemfrom1code;//收费大类改进
                    ydCfmxlr_in1.Dj = prc;
                    ydCfmxlr_in1.Sl = num;
                    ydCfmxlr_in1.Je = fee;
                    ydCfmxlr_in1.Dw = unit;
                    ydCfmxlr_in1.Kfrq = Convert.ToDateTime(costexdate).ToString("yyyy-MM-dd HH:mm:ss");
                    ydCfmxlr_in1.Kfks = departname;
                    ydCfmxlr_in1.Kfys = doctorname;
                    ydCfmxlr_in1.Xgspbh = ydXmspjgcx_out1.Spbh;
                    ydCfmxlr_in1.Cd = "";
                    ydCfmxlr_in1.Jbr = ProgramGlobal.Username;
                    StringBuilder jsfjylsh_ydcfmxlr = new StringBuilder(2048);
                    flag = ynydyb.ydcfmxlr(jsfjylsh_ydcfmxlr, ydCfmxlr_in1, ydCcfmxlr_out1);
                    if (flag != 0)
                    {
                        if (flag == -2)
                        {                            
                            Hqfsflsh_out hqfsflsh_out_ydcfmxlrcz = new Hqfsflsh_out();
                            int opt_hqjslsh_djcz = ynydyb_yddjcz.hqfsflsh(hqfsflsh_out_ydcfmxlrcz);
                            if (opt_hqjslsh_djcz != 0)
                            {

                                retMessage.Append("[门诊号:" + billcode + "]-" + hqfsflsh_out_ydcfmxlrcz.ErrorMessage + " 异地医保--获取处方明细录入冲正发送方交易流水号出错 | ");
                                return -1;
                            }

                            YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                            YdCzjy_out ydCzjy_out1 = new YdCzjy_out();                            
                            ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydcfmxlrcz.Swqjwyzym;
                            ydCzjy_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
                            ydCzjy_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
                            ydCzjy_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
                            ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                            ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                            ydCzjy_in1.Yjym = "11";
                            ydCzjy_in1.Yfsfjylsh = ydCfmxlr_in1.Fsfjylsh;


                            StringBuilder jsfjylsh_ydcfmxlrcz = new StringBuilder(2048);
                            flag = ynydyb_yddjcz.ydczjy(jsfjylsh_ydcfmxlrcz, ydCzjy_in1, ydCzjy_out1);
                            if (flag != 0)
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + ydCzjy_out1.ErrorMessage + " 异地医保--处方明细录入冲正出错 | ");
                                return -1;
                            }
                            if (ydCzjy_out1.Czzt == "0")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细录入无需冲正 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "1")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细录入冲正成功 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "2")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细录入禁止冲正 | ");
                                return -1;
                            }
                        }
                        else
                        {
                            retMessage.Append("[门诊号:" + billcode + "]-" + ydCcfmxlr_out1.ErrorMessage + " 异地医保--处方明细录入出错 | ");
                            return -1;
                        }
                    }
                    flag = inInserCostdetId(ydCcfmxlr_out1, "", id, hqfsflsh_out1.Swqjwyzym);
                    if (flag < 0)
                    {
                        //医保费用传输记录添加失败!
                        return -7;
                    }
                }
                else
                {
                    int opstat5 = ynydyb.hqfsflsh(hqfsflsh_out1);
                    if (opstat5 != 0)
                    {
                        retMessage.Append("[门诊号:" + billcode + "]-" + hqfsflsh_out1.ErrorMessage + " 异地医保--获取发送方交易流水号失败 | ");
                        continue;
                    }
                    ydCfmxtf_in1.Fsfjylsh = hqfsflsh_out1.Swqjwyzym;
                    ydCfmxtf_in1.Jzdjh = dtInsure.Rows[0]["AKC190"].ToString();
                    DataTable dtCostdet = getInsurCostdetId(id, "clinic");
                    ydCfmxtf_in1.Mxlrjyfhdjylsh = dtCostdet.Rows[0]["insur_costed_id"].ToString();//明细录入交易返回的交易流水号
                    ydCfmxtf_in1.Tcsl = (-double.Parse(num)).ToString();
                    ydCfmxtf_in1.Tcje = (-double.Parse(fee)).ToString();
                    ydCfmxtf_in1.Jbr = ProgramGlobal.User_id;

                    StringBuilder jsfjylsh_ydcfmxtf = new StringBuilder(2048);
                    int opt = ynydyb.ydcfmxtf(jsfjylsh_ydcfmxtf, ydCfmxtf_in1, ydCfmxtf_out1);
                    if (opt != 0)
                    {
                        if (opt == -2)
                        {
                            Hqfsflsh_out hqfsflsh_out_ydcfmxtfcz = new Hqfsflsh_out();
                            int opt_hqjslsh_djcz = ynydyb_yddjcz.hqfsflsh(hqfsflsh_out_ydcfmxtfcz);
                            if (opt_hqjslsh_djcz != 0)
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + hqfsflsh_out_ydcfmxtfcz.ErrorMessage + " 异地医保--获取处方明细录入冲正发送方交易流水号出错 | ");
                                return -1;                            
                            }

                            YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                            YdCzjy_out ydCzjy_out1 = new YdCzjy_out();

                            ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydcfmxtfcz.Swqjwyzym;
                            ydCzjy_in1.Hzcbdtcqbh = dtInsure.Rows[0]["InsuredAreaNo"].ToString();
                            ydCzjy_in1.Hzgrbh = dtInsure.Rows[0]["PersonNo"].ToString();
                            ydCzjy_in1.Hzybkh = dtInsure.Rows[0]["SICardNo"].ToString();
                            ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                            ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                            ydCzjy_in1.Yjym = "11";
                            ydCzjy_in1.Yfsfjylsh = ydCfmxtf_in1.Fsfjylsh;


                            StringBuilder jsfjylsh_ydcfmxtfcz = new StringBuilder(2048);
                            int opt_yddjcz = ynydyb_yddjcz.ydczjy(jsfjylsh_ydcfmxtfcz, ydCzjy_in1, ydCzjy_out1);
                            if (opt_yddjcz != 0)
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + ydCzjy_out1.ErrorMessage + " 异地医保--处方明细退方出错 | ");
                                return -1;
                            }
                            if (ydCzjy_out1.Czzt == "0")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细退方无需冲正 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "1")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细退方冲正成功 | ");
                                continue;
                            }
                            else if (ydCzjy_out1.Czzt == "2")
                            {
                                retMessage.Append("[门诊号:" + billcode + "]-" + " 异地医保--处方明细退方禁止冲正 | ");
                                return -1;
                            }

                        }
                        else
                        {
                            retMessage.Append( "[门诊号:" + billcode + "]-" + ydCfmxtf_out1.ErrorMessage + " 异地医保--处方明细退方出错 | ");
                            return -1;
                        }

                    }
                }
                upsql += "update ihsp_costdet set insursync='Y' , insurclass=" + DataTool.addFieldBraces(insurclass) + " where id=" + DataTool.addFieldBraces(id) + ";";                
                insurclass = ydCcfmxlr_out1.Xmsfdj;
                string insuritemid = BillSysBase.nextId("cost_insuritem");
                string insurcrossid = BillSysBase.nextId("cost_insurcross");
                string selectsql = "select cost_insuritem.insurclass"
                                + " from cost_insurcross "
                                + " left join cost_insuritem on cost_insuritem.id=cost_insurcross.cost_insuritem_id"
                                + " where cost_insurcross.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                                + " and cost_insurcross.item_id=" + DataTool.addFieldBraces(itemid);
                DataTable dtselect = BllMain.Db.Select(selectsql).Tables[0];
                if (dtselect.Rows.Count == 0)
                {
                    string sqlin = "insert into cost_insuritem(id"
                                                                + " ,cost_insurtype_id"
                                                                + " ,name"
                                                                + " ,pincode"
                                                                + " ,insurcode"
                                                                + " ,itemfrom"
                                                                + " ,insurclass)values (" + DataTool.addFieldBraces(insuritemid)
                                                                + "," + DataTool.addFieldBraces(insurtypeid)
                                                                + "," + DataTool.addFieldBraces(itemname)
                                                                + "," + DataTool.addFieldBraces(GetData.GetChineseSpell(itemname))
                                                                + "," + DataTool.addFieldBraces("")
                                                                + "," + DataTool.addFieldBraces(itemfromcode)
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
            }
            if (BllMain.Db.Update(upsql)<0)
            {
                retMessage.Append("修改费用传输状态失败!");
                return -1;               
            }
            return datatable.Rows.Count;
        }

        /// <summary>
        /// 患者类型下拉表
        /// </summary>
        /// <returns></returns>
        public DataTable patientTypeList()
        {
            string sql = "select id,name from bas_patienttype";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 存储云南异地医保登记信息
        /// </summary>
        /// <param name="regInfo"></param>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int saveIhspRegInfo(string regInfo,StringBuilder outputDateReg, string ihspid)
        {
            //个人编号|患者医保卡号|患者参保地统筹区编号|医保住院号|住院登记流水号
            string[] message = regInfo.Split('|');
            string strXml = "<info>"
             + "<PersonNo>" + message[0] + "</PersonNo>"
             + "<SICardNo>" + message[1] + "</SICardNo>"
             + "<InsuredAreaNo>" + message[2] + "</InsuredAreaNo>"
             + "<AKC190>" + message[3] + "</AKC190>"
             + "<SenderSerialNo>" + message[4] + "</SenderSerialNo>"
             + "</info>"
             + outputDateReg.ToString();//<outPutDate></outPutDate>
            string id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihspid)
                                     + "," + DataTool.addFieldBraces(strXml)
                                     + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 读取云南异地医保登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readIhspRegInfo(string ihspid)
        {
            DataTable dt = ynydybIhspInfo(ihspid);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 查询云南异地医保信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable ynydybIhspInfo(string ihsp_id)
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
        /// 存储云南异地医保门诊登记信息
        /// </summary>
        /// <param name="regInfo"></param>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int saveClinicRegInfo(string regInfo,StringBuilder outputDateReg ,string clinic_Invoice_id)
        {
            //个人编号|患者医保卡号|患者参保地统筹区编号|医保住院号|住院登记流水号
            string[] message = regInfo.Split('|');
            string strXml = "<info>";
            strXml += "<PersonNo>" + message[0] + "</PersonNo>";
            strXml += "<SICardNo>" + message[1] + "</SICardNo>";
            strXml += "<InsuredAreaNo>" + message[2] + "</InsuredAreaNo>";
            strXml += "<AKC190>" + message[3] + "</AKC190>";
            strXml += "<SenderSerialNo>" + message[4] + "</SenderSerialNo>";
            strXml += "</info>";
            strXml += outputDateReg.ToString();//<output></output>
            string id = BillSysBase.nextId("clinic_insurinfo");
            string sql = "insert into clinic_insurinfo (id,clinic_Invoice_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(clinic_Invoice_id)
                                     + "," + DataTool.addFieldBraces(strXml)
                                     + "," + DataTool.addFieldBraces(Insurinfostate.OO.ToString())
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 读取云南异地医保门诊登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readClinicRegInfo(string clinic_Invoice_id)
        {
            DataTable dt = ynydybClinicInfo(clinic_Invoice_id);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 读取云南异地医保门诊登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readClinicSettInfo(string clinic_Invoice_id)
        {
            DataTable dt = ynydybClinicInfo(clinic_Invoice_id);
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 查询云南异地医保门诊登记信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable ynydybClinicInfo(string clinic_Invoice_id)
        {
            DataTable dt = new DataTable();
            string sql = "select registinfo,settinfo from clinic_insurinfo where clinic_Invoice_id=" + DataTool.addFieldBraces(clinic_Invoice_id);
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
        /// 插入/更改云南异地医保出院结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int saveIhspSettInfo(string settinfo,StringBuilder output, string ihsp_id)
        {
            //明细录入交易返回的交易流水号
            string strXml = "<info>";
            strXml += "<HANDLEID>" + settinfo + "</HANDLEID>";
            strXml += "</info>";
            strXml += output.ToString();//<OutputData></OutputData>
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(settinfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 存储云南异地医保门诊登记信息
        /// </summary>
        /// <param name="regInfo"></param>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int saveClinicSettInfo(StringBuilder outputSett, string senderSerialNo, string clinic_Invoice_id)
        {           
            string strXml = "<info>";
            strXml += "<SenderSerialNo>" + senderSerialNo + "</SenderSerialNo>";
            strXml += "</info>";
            strXml += outputSett;//<outPutDate></outPutDate>
            string sql = "update clinic_insurinfo set settinfo=" + DataTool.addFieldBraces(strXml)
                                    + " where clinic_Invoice_id=" + DataTool.addFieldBraces(clinic_Invoice_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 读取云南异地医保登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readIhspSettInfo(string ihspid)
        {
            DataTable dt = ynydybIhspInfo(ihspid);
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 修改住院医保信息状态
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
        /// 更新住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upinsurstat(string ihsp_id, string insurstat)
        {
            string sql = "update inhospital set insurstat=" + DataTool.addFieldBraces(insurstat) + " where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 修改门诊医保信息状态
        /// </summary>
        /// <param name="accountinfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int upClinicOpstat(string opstat, string Invoice_id)
        {
            string sql = "update ihsp_insurinfo set opstat=" + DataTool.addFieldBraces(opstat)
                                    + " where clinic_Invoice_id=" + DataTool.addFieldBraces(Invoice_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 更新门诊住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upClinicInsurstat(string Invoice_id, string insurstat)
        {
            string sql = "update clinic_invoice set insurstat=" + DataTool.addFieldBraces(insurstat) + " where id=" + DataTool.addFieldBraces(Invoice_id);
            return BllMain.Db.Update(sql);
        }


        /// <summary>
        /// 获得出院信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getIhspInfo1(string ihsp_id)
        {
            string sql = "select inhospital.outdiagn"
                + " ,case "
                + " when inhospital.outcondition='OO' then '未出院'"
                + " when inhospital.outcondition='CURE' then '治愈'"
                + " when inhospital.outcondition='BETTER' then '好转'"
                + " when inhospital.outcondition='NOT' then '未愈'"
                + " when inhospital.outcondition='DIE' then '死亡'"
                + " else '其它' end as outreason"
                + " from inhospital"
                + " where inhospital.id=" + DataTool.addIntBraces(ihsp_id);
            DataTable dt=BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获得出院信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getIhspInfo2(string ihsp_id)
        {
            string sql = "select bas_doctor.name as doctor"
                + ",bas_depart.name as depart"
                + ",bas_sickbed.name as bed"
                + " from ihsp_chgdep"
                + " left join bas_doctor on ihsp_chgdep.s_doctor_id=bas_doctor.id"
                + " left join bas_depart on ihsp_chgdep.s_depart_id=bas_depart.id"
                + " left join bas_sickbed on bas_sickbed.id=ihsp_chgdep.s_bed_id"
                + " where sn=(select count(id) from ihsp_chgdep where ihsp_id=" + DataTool.addIntBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取发票号
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public DataTable geiInvoiceCode(string invoiceId)
        {
            string sql = "select billcode from clinic_invoice where id=" + DataTool.addIntBraces(invoiceId);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="retmessage"></param>
        /// <returns></returns>
        public int clinicSettle(StringBuilder retmessage, YnydybRegInfo ynydybRegInfo, string insurAccount, string invoice,string invoice_id)
        {
            YNYDYB ynydyb = new YNYDYB();
            Hqfsflsh_out hqfsflsh_out1 = new Hqfsflsh_out();
            int opt_hqjslsh = ynydyb.hqfsflsh(hqfsflsh_out1);
            if (opt_hqjslsh != 0)
            {
                retmessage.Append(hqfsflsh_out1.ErrorMessage + ", 异地医保--获取发送方交易流水号失败！");
                return -1;
            }
            YdYlfyjs_in ydYlfyjs_in1 = new YdYlfyjs_in();           
            ydYlfyjs_in1.Fsfjylsh = hqfsflsh_out1.Swqjwyzym;
            ydYlfyjs_in1.Hzcbdtcqbh = ynydybRegInfo.InsuredAreaNo;
            ydYlfyjs_in1.Hzgrbh = ynydybRegInfo.Grbh;
            ydYlfyjs_in1.Hzybkh = ynydybRegInfo.Hzybkh;
            ydYlfyjs_in1.Czybh = ProgramGlobal.User_id;
            ydYlfyjs_in1.Ywzqh = ynydybGlobal.Ywzqh;

            ydYlfyjs_in1.Zyh = ynydybRegInfo.Zyh;
            ydYlfyjs_in1.Cfjzsj = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            ydYlfyjs_in1.Fph = invoice;
            ydYlfyjs_in1.Jbr = ProgramGlobal.Username;
            ydYlfyjs_in1.Jslx = "1";
            ydYlfyjs_in1.Grzhzfje = insurAccount;

            StringBuilder jsfjylsh_ydylfyjs = new StringBuilder(2048);
            StringBuilder outputSett = new StringBuilder();
            int opt_js = ynydyb.ydylfyjs(jsfjylsh_ydylfyjs, ydYlfyjs_in1, outputSett);
            if (opt_js != 0)
            {
                if (opt_js == -2)
                {
                    YNYDYB ynydyb_ydjscz = new YNYDYB();
                    Hqfsflsh_out hqfsflsh_out_ydjscz = new Hqfsflsh_out();
                    int opt_hqjslsh_djcz = ynydyb_ydjscz.hqfsflsh(hqfsflsh_out_ydjscz);
                    if (opt_hqjslsh_djcz != 0)
                    {
                        retmessage.Append(hqfsflsh_out_ydjscz.ErrorMessage + ", 异地医保--获取【结算冲正】发送方交易流水号失败！");
                        return -1;
                    }

                    YdCzjy_in ydCzjy_in1 = new YdCzjy_in();
                    YdCzjy_out ydCzjy_out1 = new YdCzjy_out();
                    ydCzjy_in1.Fsfjylsh = hqfsflsh_out_ydjscz.Swqjwyzym;
                    ydCzjy_in1.Hzcbdtcqbh = ynydybRegInfo.InsuredAreaNo;
                    ydCzjy_in1.Hzgrbh = ynydybRegInfo.Grbh;
                    ydCzjy_in1.Hzybkh = ynydybRegInfo.Hzybkh;
                    ydCzjy_in1.Czybh = ProgramGlobal.User_id;
                    ydCzjy_in1.Ywzqh = ynydybGlobal.Ywzqh;
                    ydCzjy_in1.Yjym = "14";
                    ydCzjy_in1.Yfsfjylsh = ydYlfyjs_in1.Fsfjylsh;


                    StringBuilder jsfjylsh_ydjscz = new StringBuilder(2048);
                    int opt_yddjcz = ynydyb_ydjscz.ydczjy(jsfjylsh_ydjscz, ydCzjy_in1, ydCzjy_out1);
                    if (opt_yddjcz != 0)
                    {
                        retmessage.Append("异地医保--【结算冲正交易】失败:" + ydCzjy_out1.ErrorMessage);
                        return -1;
                    }
                    if (ydCzjy_out1.Czzt == "0")
                    {
                        retmessage.Append("无需冲正！【-2】结算冲正");
                        return -1;
                    }
                    else if (ydCzjy_out1.Czzt == "1")
                    {
                        retmessage.Append("冲正成功！【-2】结算冲正");
                        return -1;
                    }
                    else if (ydCzjy_out1.Czzt == "2")
                    {
                        retmessage.Append("禁止冲正！【-2】结算冲正");
                        return -1;
                    }

                }
                else
                {
                    retmessage.Append("异地医保--结算失败:" + outputSett);
                    return -1;
                }                
            }
            saveClinicSettInfo(outputSett, ydYlfyjs_in1.Fsfjylsh, invoice_id);
            return 0;
        }
        
        /// <summary>
        /// 获取签退信息
        /// </summary>
        /// <returns></returns>
        public DataTable getSignOutInfo()
        {
            #region Ihsp
            string retSql = "select count(id) as retCount"
                         +" from ihsp_account"
                         + " where chargedate<="+DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                         + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                         + " and cancleby="+DataTool.addFieldBraces(ProgramGlobal.User_id)
                         + " and num='-1'";
            DataTable dtRet = BllMain.Db.Select(retSql).Tables[0];
            string retIhspCount = dtRet.Rows[0]["retCount"].ToString();
            string charSql = "select count(id) as charCount"
                         + " from ihsp_account"
                         + " where chargedate<=" + DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                         + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                         + " and chargedby_id=" + DataTool.addFieldBraces(ProgramGlobal.User_id)
                         + " and num='1'";
            DataTable dtChar = BllMain.Db.Select(retSql).Tables[0];
            string charIhspCount = dtRet.Rows[0]["charCount"].ToString();
            string sqlFee = "select sum(feeamt) as feeamt"
                        + ",sum(insurefee) as insurefee"
                        + ",sum(insuraccountfee) as insuraccountfee"
                        + " from ihsp_account"
                        + " where chargedate<=" + DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                        + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                        + " and (cancleby=" + DataTool.addFieldBraces(ProgramGlobal.User_id)
                        + " or chargedby_id=" + DataTool.addFieldBraces(ProgramGlobal.User_id) + ")";
            DataTable dtFee=BllMain.Db.Select(sqlFee).Tables[0];
            string ihspFee = dtFee.Rows[0]["feeamt"].ToString();
            string ihspInsurefee = dtFee.Rows[0]["insurefee"].ToString();
            string ihspInsuraccount = dtFee.Rows[0]["insuraccountfee"].ToString();
            string ihspSelfFee = (DataTool.stringToDouble(ihspFee) - DataTool.stringToDouble(ihspInsurefee) - DataTool.stringToDouble(ihspInsuraccount)).ToString();
            #endregion

            #region clinic
            retSql = "select count(id) as retCount"
                    + " from clinic_invoice"
                    + " where chargedate<=" + DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                    + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                    + " and charged=='RREC'"
                    + " and chargeby=" + DataTool.addFieldBraces(ProgramGlobal.User_id);
            dtRet = BllMain.Db.Select(retSql).Tables[0];
            string retClinicCount = dtRet.Rows[0]["retCount"].ToString();
            retSql = "select count(id) as charCount"
                    + " from clinic_invoice"
                    + " where chargedate<=" + DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                    + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                    + " and charged!='RREC'"
                    + " and chargeby=" + DataTool.addFieldBraces(ProgramGlobal.User_id);
            dtChar = BllMain.Db.Select(retSql).Tables[0];
            string charClinicCount = dtRet.Rows[0]["charCount"].ToString();
            sqlFee="select sum(fee) as feeamt"
                    +" sum(insurefee) as insurefee"
                    +" sum(insuraccountfee) as insuraccountfee"
                    +" from clinic_invoice"
                    + " where chargedate<=" + DataTool.addFieldBraces(ynydybGlobal.SignOuttime)
                    + " and chargedate>=" + DataTool.addFieldBraces(ynydybGlobal.Signtime)
                    + " and chargeby=" + DataTool.addFieldBraces(ProgramGlobal.User_id);
            dtFee=BllMain.Db.Select(sqlFee).Tables[0];
            string clinicFee = dtFee.Rows[0]["feeamt"].ToString();
            string clinicInsurefee = dtFee.Rows[0]["insurefee"].ToString();
            string clinicInsuraccount = dtFee.Rows[0]["insuraccountfee"].ToString();
            string clinicSelfFee = (DataTool.stringToDouble(clinicFee) - DataTool.stringToDouble(clinicInsurefee) - DataTool.stringToDouble(clinicInsuraccount)).ToString();
            #endregion

            string retCount = (int.Parse(retIhspCount) + int.Parse(retClinicCount)).ToString();
            string charCount = (int.Parse(charIhspCount) + int.Parse(charClinicCount)).ToString();
            string fee = (DataTool.stringToDouble(ihspFee) + DataTool.stringToDouble(clinicFee)).ToString();
            string insurefee = (DataTool.stringToDouble(ihspInsurefee) + DataTool.stringToDouble(clinicInsurefee)).ToString();
            string insuraccount = (DataTool.stringToDouble(ihspInsuraccount) + DataTool.stringToDouble(clinicInsuraccount)).ToString();
            string selfFee = ihspSelfFee + clinicSelfFee;

            DataTable dtSignOut = new DataTable();
            dtSignOut.Columns.Add("retCount");
            dtSignOut.Columns.Add("charCount");
            dtSignOut.Columns.Add("fee");
            dtSignOut.Columns.Add("insurefee");
            dtSignOut.Columns.Add("insuraccount");
            dtSignOut.Columns.Add("selfFee");
            DataRow dr = dtSignOut.NewRow();
            dr["retCount"] = retCount;
            dr["charCount"] = charCount;
            dr["fee"] = fee;
            dr["insurefee"] = insurefee;
            dr["insuraccount"] = insuraccount;
            dr["selfFee"] = selfFee;
            return dtSignOut;
        }

        /// <summary>
        /// 住院费用批量删除
        /// </summary>
        /// <returns></returns>
        public int cancelIhspCostdet(string ihsp_id)
        {
            string sql = "update set insursync='N'"
                + " from ihsp_costdet"
                + " where ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                + " and charger_id=" + DataTool.addIntBraces(ProgramGlobal.User_id)
                + " and chargedate>=" + DataTool.addIntBraces(ynydybGlobal.Signtime)
                + " and chargedate<=" + DataTool.addIntBraces(ynydybGlobal.SignOuttime)
                + ";";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 住院费用批量删除
        /// </summary>
        /// <returns></returns>
        public int cancelClinicCostdet(string invoice_id)
        {
            string sql = "update set insursync='N'"
                + " from clinic_costdet"
                + " where clinic_Invoice_id=" + DataTool.addIntBraces(invoice_id)
                + " and chargeby=" + DataTool.addIntBraces(ProgramGlobal.User_id)
                + " and chargedate>=" + DataTool.addIntBraces(ynydybGlobal.Signtime)
                + " and chargedate<=" + DataTool.addIntBraces(ynydybGlobal.SignOuttime)
                + ";";
            return BllMain.Db.Update(sql);
        }

    }
}
    

