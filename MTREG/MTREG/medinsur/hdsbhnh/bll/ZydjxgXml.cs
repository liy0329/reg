using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class ZydjxgXml
    {
        /// <summary>
        /// 住院登记修改参数body部分
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string inHospitalRegisterModifyInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<basicInfo>";
            bodydata += "<D504_47>" + parm[0] + "</D504_47>";//转诊申请单号
            bodydata += "<D504_01>" + parm[1] + "</D504_01>";//住院登记流水号
            bodydata += "<D504_02>" + parm[2] + "</D504_02>";//个人编码
            bodydata += "<D504_03>" + parm[3] + "</D504_03>";//患者姓名
            bodydata += "<D504_04>" + parm[4] + "</D504_04>";//患者性别
            bodydata += "<D504_05>" + parm[5] + "</D504_05>";//患者身份证号
            bodydata += "<D504_06>" + parm[6] + "</D504_06>";//年龄
            bodydata += "<D504_07>" + parm[7] + "</D504_07>";//家庭编号
            bodydata += "<D504_08>" + parm[8] + "</D504_08>";//医疗证卡号
            bodydata += "<D603_02>" + parm[9] + "</D603_02>";//基金年份
            bodydata += "<D504_28>" + parm[10] + "</D504_28>";//月份
            bodydata += "</basicInfo>";
            bodydata += "<registerInfo>";
            bodydata += "<D504_48>" + parm[11] + "</D504_48>";//登记属性
            bodydata += "<D504_10>" + parm[12] + "</D504_10>";//就诊类型
            bodydata += "<D504_49>" + parm[13] + "</D504_49>";//是否恶性肿瘤
            bodydata += "<D504_21>" + parm[14] + "</D504_21>";//疾病代码
            bodydata += "<D504_50>" + parm[15] + "</D504_50>";//医院初步诊断
            bodydata += "<D504_16>" + parm[16] + "</D504_16>";//入院科室
            bodydata += "<D504_17>" + parm[17] + "</D504_17>";//出院科室
            bodydata += "<D504_51>" + parm[18] + "</D504_51>";//登记床位
            bodydata += "<D504_52>" + parm[19] + "</D504_52>";//入院类型
            bodydata += "<D504_53>" + parm[20] + "</D504_53>";//押金金额
            bodydata += "<D504_11>" + parm[21] + "</D504_11>";//入院时间
            bodydata += "<D504_12>" + parm[22] + "</D504_12>";//出院时间
            bodydata += "<D504_13>" + parm[23] + "</D504_13>";//实际住院天数
            bodydata += "<D101_02>" + parm[24] + "</D101_02>";//就医机构名称
            bodydata += "<D504_14>" + parm[25] + "</D504_14>";//就医机构代码
            bodydata += "<D504_15>" + parm[26] + "</D504_15>";//就医机构级别
            bodydata += "<D504_18>" + parm[27] + "</D504_18>";//经治医生
            bodydata += "<D504_19>" + parm[28] + "</D504_19>";//入院状态
            bodydata += "<D504_20>" + parm[29] + "</D504_20>";//出院状态
            bodydata += "<D504_55>" + parm[30] + "</D504_55>";//症状名称
            bodydata += "<D504_23>" + parm[31] + "</D504_23>";//手术名称代码
            bodydata += "<D504_56>" + parm[32] + "</D504_56>";//担保金额
            bodydata += "<D504_09>" + parm[33] + "</D504_09>";//住院号
            bodydata += "<D504_57>" + parm[34] + "</D504_57>";//担保人
            bodydata += "<D504_58>" + parm[35] + "</D504_58>";//登记人
            bodydata += "<D504_59>" + parm[36] + "</D504_59>";//是否商业保险
            bodydata += "<D504_54>" + parm[37] + "</D504_54>";//HIS科室代码
            bodydata += "<D504_60>" + parm[38] + "</D504_60>";//HIS科室名称
            bodydata += "<D504_61>" + parm[39] + "</D504_61>";//经办机构代码
            bodydata += "<D504_62>" + parm[40] + "</D504_62>";//住院补偿流水号
            bodydata += "<D504_63>" + parm[41] + "</D504_63>";//转外类型
            bodydata += "<D504_64>" + parm[42] + "</D504_64>";//是否急诊
            bodydata += "<D504_65>" + parm[43] + "</D504_65>";//账户名
            bodydata += "<D504_66>" + parm[44] + "</D504_66>";//银行卡号
            bodydata += "<D504_67>" + parm[45] + "</D504_67>";//转诊理由
            bodydata += "<D504_69>" + parm[46] + "</D504_69>";//转出医疗机构名称
            bodydata += "<D504_68>" + parm[47] + "</D504_68>";//转出医疗机构代码
            bodydata += "<D504_70>" + parm[48] + "</D504_70>";//登记日期
            bodydata += "<D504_22>" + parm[49] + "</D504_22>";//并发症
            bodydata += "<D504_26>" + parm[50] + "</D504_26>";//民政通知书号
            bodydata += "<D504_27>" + parm[51] + "</D504_27>";//生育证号
            bodydata += "<D504_80>" + parm[52] + "</D504_80>";//HIS疾病代码
            bodydata += "<D504_81>" + parm[53] + "</D504_81>";//HIS疾病名称
            bodydata += "<D401_15>" + parm[54] + "</D401_15>";//电话号码
            bodydata += "</registerInfo>";
            bodydata += "</body>";
            return bodydata;

        }
        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "B020002";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += inHospitalRegisterModifyInput_body(parm);
            data += allxml.allDatInput_end();
            string[] args = new string[1];
            args[0] = data;
            string nhdata;
            BhnhReturn ret = new BhnhReturn();
            try
            {
                nhdata = (string)BllHdsbhnh.InvokeWebService(weburl,"nh_pipe", args);//调用webservice是需要创建实例
            }
            catch (Exception e)
            {
                ret.Ret_mesg = "客户端调用失败！" + e.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            ret.Ret_data = nhdata; //成功返回数据 
            return ret;
        }
    }
}
