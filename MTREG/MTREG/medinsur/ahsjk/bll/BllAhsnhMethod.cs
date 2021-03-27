using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.ahsjk.bo;
using System.Data;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.ihsp.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.common.bll;

namespace MTREG.medinsur.ahsjk.bll
{
    class BllAhsnhMethod
    {

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        public DataTable getAreaCode()
        {
            DataTable dt = new DataTable();
            string sql = "select id,areaname from insur_ahsjnh_trustpointcode";
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
        /// 根据id获取地址
        /// </summary>
        /// <returns></returns>
        public DataTable getWebUrl(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select weburl,areaname,hospitalcode,areacode from insur_ahsjnh_trustpointcode where id=" + DataTool.addIntBraces(id);
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
        /// 测试连接
        /// </summary>
        /// <param name="in_ConnectTest"></param>
        /// <returns></returns>
        public retMesage connectTest(In_ConnectTest in_ConnectTest)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[7];
            string sMessage = "";
            args[0] = in_ConnectTest.SHospitalCode;
            args[1] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_ConnectTest.Weburl,"ConnectTest", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 获取家庭成员列表
        /// </summary>
        /// <param name="in_GetPersonInfo"></param>
        /// <param name="out_GetPersonInfo"></param>
        /// <returns></returns>
        public retMesage getPersonInfo(In_GetPersonInfo in_GetPersonInfo)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[11];
            string sMessage = "";
            string sResult="";
            args[0] = in_GetPersonInfo.SAreaCode;
            args[1] = in_GetPersonInfo.SHospitalCode;
            args[2] = in_GetPersonInfo.SMedicalCode;
            args[9]=sResult;
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_GetPersonInfo.Weburl,"GetPersonInfo ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_GetPersonInfo));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 门诊、住院登记
        /// </summary>
        /// <param name="in_InpatientRegister"></param>
        /// <returns></returns>
        public retMesage inpatientRegister(In_InpatientRegister in_InpatientRegister)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[42];
            string sMessage = "";
            string sInpatientID = "";
            args[0] = in_InpatientRegister.SAreaCode;
            args[1] = in_InpatientRegister.SHospitalCode;
            args[2] = in_InpatientRegister.SInpatientCode;
            args[3] = in_InpatientRegister.SMedicalCode;
            args[4] = in_InpatientRegister.SCardCode;
            args[5] = in_InpatientRegister.SPeopCode;
            args[6] = in_InpatientRegister.SPeopName;
            args[7] = in_InpatientRegister.SSex;
            args[8] = in_InpatientRegister.SAge;
            args[9] = in_InpatientRegister.SBirthDay;
            args[10] = in_InpatientRegister.SIDCardNo;
            args[11] = in_InpatientRegister.SDiagnoseCodeIn1;
            args[12] = in_InpatientRegister.SDiagnoseNameIn1;
            args[23] = in_InpatientRegister.SSectionOfficeName;
            args[24] = in_InpatientRegister.SSectionOfficeCode;
            args[25] = in_InpatientRegister.SCureCode;
            args[26] = in_InpatientRegister.SInHospitalCode;
            args[27] = in_InpatientRegister.SInHosptialDate;
            args[30] = in_InpatientRegister.SChangeCode;
            args[31] = in_InpatientRegister.SChangeRCode;
            args[34] = in_InpatientRegister.SOperatorName;
            args[40] = sInpatientID;
            args[41] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientRegister.Weburl,"InpatientRegister", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            List<object> cities = new List<object>();
            cities.Add(sInpatientID);
            ret.Ret_data = cities;
            ret.Ret_flag = true;
            return ret;
        }

        /// <summary>
        /// 住院登记修改
        /// </summary>
        /// <param name="in_InpatientRegisterModify"></param>
        /// <returns></returns>
        public retMesage inpatientRegisterModify(In_InpatientRegisterModify in_InpatientRegisterModify)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[42];
            string sMessage = "";
            args[0] = in_InpatientRegisterModify.SAreaCode;
            args[1] = in_InpatientRegisterModify.SInpatientID;
            args[2] = in_InpatientRegisterModify.SHospitalCode;
            args[3] = in_InpatientRegisterModify.SInpatientCode;
            args[4] = in_InpatientRegisterModify.SMedicalCode;
            args[5] = in_InpatientRegisterModify.SCardCode;
            args[6] = in_InpatientRegisterModify.SPeopCode;
            args[7] = in_InpatientRegisterModify.SPeopName;
            args[8] = in_InpatientRegisterModify.SSex;
            args[9] = in_InpatientRegisterModify.SAge;
            args[10] = in_InpatientRegisterModify.SBirthDay;
            args[11] = in_InpatientRegisterModify.SIDCardNo;
            args[12] = in_InpatientRegisterModify.SDiagnoseCodeIn1;
            args[13] = in_InpatientRegisterModify.SDiagnoseNameIn1;
            args[24] = in_InpatientRegisterModify.SSectionOfficeName;
            args[25] = in_InpatientRegisterModify.SSectionOfficeCode;
            args[26] = in_InpatientRegisterModify.SCureCode;
            args[27] = in_InpatientRegisterModify.SInHospitalCode;
            args[28] = in_InpatientRegisterModify.SInHosptialDate;
            args[31] = in_InpatientRegisterModify.SChangeCode;
            args[35] = in_InpatientRegisterModify.SOperatorName;
            args[41] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientRegisterModify.Weburl,"InpatientRegisterModify", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 费用上传
        /// </summary>
        /// <param name="in_InpatientRegisterModify"></param>
        /// <returns></returns>
        public retMesage inpatientFeeUpLoad(In_InpatientFeeUpLoad in_InpatientFeeUpLoad)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[31];
            string sMessage = "";
            string sResult = "";
            args[0] = in_InpatientFeeUpLoad.SAreaCode;
            args[1] = in_InpatientFeeUpLoad.SInpatientID;
            args[2] = in_InpatientFeeUpLoad.SHospitalCode;
            args[3] = in_InpatientFeeUpLoad.SCenterItemCode;
            args[4] = in_InpatientFeeUpLoad.SItemKey;
            args[5] = in_InpatientFeeUpLoad.SItemType;
            args[6] = in_InpatientFeeUpLoad.SReceiptName;
            args[7] = in_InpatientFeeUpLoad.SItemCode;
            args[8] = in_InpatientFeeUpLoad.SItemName;
            args[9] = in_InpatientFeeUpLoad.SItemSpec;
            args[10] = in_InpatientFeeUpLoad.SItemDose;
            args[11] = in_InpatientFeeUpLoad.SItemArea;
            args[12] = in_InpatientFeeUpLoad.SItemProc;
            args[13] = in_InpatientFeeUpLoad.SItemPart;
            args[14] = in_InpatientFeeUpLoad.SIfCompound;
            args[15] = in_InpatientFeeUpLoad.STime;
            args[16] = in_InpatientFeeUpLoad.SUnit;
            args[17] = in_InpatientFeeUpLoad.SPrice;
            args[18] = in_InpatientFeeUpLoad.SSum;
            args[19] = in_InpatientFeeUpLoad.SSectionOfficeName;
            args[20] = in_InpatientFeeUpLoad.SSectionOfficeCode;
            args[21] = in_InpatientFeeUpLoad.SDoctorName;
            args[23] = in_InpatientFeeUpLoad.SOperatorDate;
            args[24] = in_InpatientFeeUpLoad.SInputName  ;
            args[29] = sResult;
            args[30] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientFeeUpLoad.Weburl,"InpatientCalculate ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_InpatientFeeUpLoad));
            return ret;
        }
        /// <summary>
        /// 门诊、住院病人费用取消（单条）
        /// </summary>
        /// <param name="in_InpatientFeeCancel"></param>
        /// <returns></returns>
        public retMesage inpatientFeeCancel(In_InpatientFeeCancel in_InpatientFeeCancel)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[13];
            string sMessage = "";
            args[0] = in_InpatientFeeCancel.SAreaCode;
            args[1] = in_InpatientFeeCancel.SInpatientID;
            args[2] = in_InpatientFeeCancel.SHospitalCode;
            args[3] = in_InpatientFeeCancel.SCenterKey;
            args[4] = in_InpatientFeeCancel.SItemKey;
            args[5] = in_InpatientFeeCancel.SOperatorDate;
            args[6] = in_InpatientFeeCancel.SInputName;
            args[12] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientFeeCancel.Weburl,"InpatientFeeCancel", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 门诊、住院病人费用取消（批量）
        /// </summary>
        /// <param name="in_InpatientFeeCancelAll"></param>
        /// <returns></returns>
        public retMesage inpatientFeeCancelAll(In_InpatientFeeCancelAll in_InpatientFeeCancelAll)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[9];
            string sMessage = "";
            args[0] = in_InpatientFeeCancelAll.SAreaCode;
            args[1] = in_InpatientFeeCancelAll.SInpatientID;
            args[2] = in_InpatientFeeCancelAll.SHospitalCode;
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientFeeCancelAll.Weburl,"InpatientFeeCancelAll", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 住院取消登记
        /// </summary>
        /// <param name="in_InpatientRegisterCancel"></param>
        /// <returns></returns>
        public retMesage inpatientRegisterCancel(In_InpatientRegisterCancel in_InpatientRegisterCancel)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[11];
            string sMessage = "";
            args[0] = in_InpatientRegisterCancel.SAreaCode;
            args[1] = in_InpatientRegisterCancel.SInpatientID;
            args[2] = in_InpatientRegisterCancel.SHospitalCode;
            args[3] = in_InpatientRegisterCancel.SReason;
            args[4] = in_InpatientRegisterCancel.SOperatorName;
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientRegisterCancel.Weburl,"InpatientRegisterCancel", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 住院出院登记
        /// </summary>
        /// <param name="in_InpatientOutRegister"></param>
        /// <returns></returns>
        public retMesage inpatientOutRegister(In_InpatientOutRegister in_InpatientOutRegister)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[22];
            string sMessage = "";
            args[0] = in_InpatientOutRegister.SAreaCode;
            args[1] = in_InpatientOutRegister.SInpatientID;
            args[2] = in_InpatientOutRegister.SHospitalCode;
            args[3] = in_InpatientOutRegister.SDiagnoseCodeOut1;
            args[4] = in_InpatientOutRegister.SDiagnoseNameOut1;
            args[9] = in_InpatientOutRegister.SSectionOfficeName;
            args[10] = in_InpatientOutRegister.SSectionOfficeCode;
            args[11] = in_InpatientOutRegister.SOutHospitalCode;
            args[12] = in_InpatientOutRegister.SOutHosptialDate;
            args[13] = in_InpatientOutRegister.SOperatorName;
            args[14] = in_InpatientOutRegister.SReceiptCode;
            args[15] = in_InpatientOutRegister.SAllInCost;
            args[21] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientOutRegister.Weburl,"InpatientOutRegister", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 住院取消出院登记
        /// </summary>
        /// <param name="in_InpatientOutRegisterCancel"></param>
        /// <returns></returns>
        public retMesage inpatientOutRegisterCancel(In_InpatientOutRegisterCancel in_InpatientOutRegisterCancel)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[11];
            string sMessage = "";
            args[0] = in_InpatientOutRegisterCancel.SAreaCode;
            args[1] = in_InpatientOutRegisterCancel.SInpatientID;
            args[2] = in_InpatientOutRegisterCancel.SHospitalCode;
            args[3] = in_InpatientOutRegisterCancel.SReason;
            args[4] = in_InpatientOutRegisterCancel.SOperatorName;            
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientOutRegisterCancel.Weburl,"InpatientOutRegisterCancel", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 门诊、住院试算
        /// </summary>
        /// <param name="in_InpatientTryCalculate"></param>
        /// <returns></returns>
        public retMesage inpatientTryCalculate(In_InpatientTryCalculate in_InpatientTryCalculate)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[12];
            string sMessage = "";
            string sResult = "";
            args[0] = in_InpatientTryCalculate.SAreaCode;
            args[1] = in_InpatientTryCalculate.SInpatientID;
            args[2] = in_InpatientTryCalculate.SHospitalCode;
            args[3] = in_InpatientTryCalculate.SCalcCode;
            args[4] = in_InpatientTryCalculate.SAllInCost;
            args[10] = sResult;
            args[11] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientTryCalculate.Weburl,"InpatientTryCalculate ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_InpatientTryCalculate));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 门诊、住院结算
        /// </summary>
        /// <param name="in_InpatientCalculate"></param>
        /// <returns></returns>
        public retMesage inpatientCalculate(In_InpatientCalculate in_InpatientCalculate)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[14];
            string sMessage = "";
            string sResult = "";
            args[0] = in_InpatientCalculate.SAreaCode;
            args[1] = in_InpatientCalculate.SInpatientID;
            args[2] = in_InpatientCalculate.SHospitalCode;
            args[3] = in_InpatientCalculate.SCalcCode;
            args[4] = in_InpatientCalculate.SReceiptCode;
            args[5] = in_InpatientCalculate.SAllInCost;
            args[6] = in_InpatientCalculate.SOperatorName;
            args[12] = sResult;
            args[13] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientCalculate.Weburl,"InpatientCalculate ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_InpatientCalculate));
            return ret;
        }
        /// <summary>
        /// 门诊、住院取消结算
        /// </summary>
        /// <param name="in_InpatientCalculateCancel"></param>
        /// <returns></returns>
        public retMesage inpatientCalculateCancel(In_InpatientCalculateCancel in_InpatientCalculateCancel)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[12];
            string sMessage = "";
            args[0] = in_InpatientCalculateCancel.SAreaCode;
            args[1] = in_InpatientCalculateCancel.SInpatientID;
            args[2] = in_InpatientCalculateCancel.SCalculateCode;
            args[3] = in_InpatientCalculateCancel.SHospitalCode;
            args[4] = in_InpatientCalculateCancel.SReason;
            args[5] = in_InpatientCalculateCancel.SOperatorName;
            args[6] = in_InpatientCalculateCancel.SObligate1;
            args[13] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatientCalculateCancel.Weburl,"InpatientCalculateCancel ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }           
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 提交结算申请
        /// </summary>
        /// <param name="in_SubmitApply"></param>
        /// <returns></returns>
        public retMesage submitApply(In_SubmitApply in_SubmitApply)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[18];
            string sMessage = "";
            args[0] = in_SubmitApply.SAreaCode;
            args[1] = in_SubmitApply.SInpatientID;
            args[2] = in_SubmitApply.SHospitalCode;
            args[3] = in_SubmitApply.SDiagnoseCodeOut1;
            args[4] = in_SubmitApply.SDiagnoseNameOut1;
            args[9] = in_SubmitApply.SCalcCode;
            args[10] = in_SubmitApply.SOperatorName;
            args[11] = in_SubmitApply.SAllInCost;
            args[17] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_SubmitApply.Weburl,"SubmitApply ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 项目对照情况上传
        /// </summary>
        /// <param name="in_ItemContrastUp"></param>
        /// <returns></returns>
        public retMesage itemContrastUp(In_ItemContrastUp in_ItemContrastUp)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[19];
            string sMessage = "";
            args[0] = in_ItemContrastUp.SAreaCode;
            args[1] = in_ItemContrastUp.SHospitalCode;
            args[2] = in_ItemContrastUp.SCenterItemC;
            args[3] = in_ItemContrastUp.SItemCode;
            args[4] = in_ItemContrastUp.SItemName;
            args[5] = in_ItemContrastUp.SItemSpec;
            args[10] = in_ItemContrastUp.SUnit;
            args[11] = in_ItemContrastUp.SPrice;
            args[12] = in_ItemContrastUp.SItemType;
            args[18] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_ItemContrastUp.Weburl,"ItemContrastUp ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            return ret;
        }

        /// <summary>
        /// 下载结算类型
        /// </summary>
        /// <param name="in_DownCalType"></param>
        /// <returns></returns>
        public retMesage downCalType(In_DownCalType in_DownCalType)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[9];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownCalType.SAreaCode;
            args[1] = in_DownCalType.SHospitalCode;
            args[7] = sResult;
            args[8] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownCalType.Weburl,"DownCalType ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownCalType));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 下载ICD目录
        /// </summary>
        /// <param name="in_DownCalType"></param>
        /// <returns></returns>
        public retMesage downICD(In_DownICD in_DownICD)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[11];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownICD.SAreaCode;
            args[1] = in_DownICD.SUserCode;
            args[2] = in_DownICD.SUserPass;
            args[3] = in_DownICD.SHospitalCode;
            args[9] = sResult;
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownICD.Weburl, "DownICD ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownICD));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 下载中心药品/诊疗目录
        /// </summary>
        /// <param name="in_DownItemList"></param>
        /// <returns></returns>
        public retMesage downItemList(In_DownItemList in_DownItemList)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[9];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownItemList.SAreaCode;
            args[7] = sResult;
            args[8] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownItemList.Weburl,"DownItemList ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownItemList));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 单病种信息上传
        /// </summary>
        /// <param name="in_InpatDiagnosisUpdate"></param>
        /// <returns></returns>
        public retMesage inpatDiagnosisUpdate(In_InpatDiagnosisUpdate in_InpatDiagnosisUpdate)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[21];
            string sMessage = "";
            args[0] = in_InpatDiagnosisUpdate.SAreaCode;
            args[1] = in_InpatDiagnosisUpdate.SUserCode;
            args[2] = in_InpatDiagnosisUpdate.SUserPass;
            args[3] = in_InpatDiagnosisUpdate.SHospitalCode;
            args[4] = in_InpatDiagnosisUpdate.SInpatientID;
            args[5] = in_InpatDiagnosisUpdate.SStature;
            args[6] = in_InpatDiagnosisUpdate.SWeight;
            args[7] = in_InpatDiagnosisUpdate.STreatCode;
            args[8] = in_InpatDiagnosisUpdate.SIcdno;
            args[9] = in_InpatDiagnosisUpdate.SIcdName;
            args[10] = in_InpatDiagnosisUpdate.SSectionOfficeCode;
            args[11] = in_InpatDiagnosisUpdate.SCureCode;
            args[12] = in_InpatDiagnosisUpdate.SInHospitalCode;
            args[13] = in_InpatDiagnosisUpdate.SInHosptialDate;
            args[14] = in_InpatDiagnosisUpdate.SOperatorName;
            args[20] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_InpatDiagnosisUpdate.Weburl, "InpatDiagnosisUpdate ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_mesg = sMessage.ToString();
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 下载单病种治疗方式
        /// </summary>
        /// <param name="in_DownTreat"></param>
        /// <returns></returns>
        public retMesage downTreat(In_DownTreat in_DownTreat)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[12];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownTreat.SAreaCode;
            args[1] = in_DownTreat.SUserCode;
            args[2] = in_DownTreat.SUserPass;
            args[3] = in_DownTreat.SHospitalCode;
            args[4] = in_DownTreat.SYear;
            args[10] = sResult;
            args[11] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownTreat.Weburl,"DownTreat ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownHospitals));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 下载全省医疗机构信息
        /// </summary>
        /// <param name="in_DownHospitals"></param>
        /// <returns></returns>
        public retMesage downHospitals(In_DownHospitals in_DownHospitals)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[12];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownHospitals.SAreaCode;
            args[1] = in_DownHospitals.SUserCode;
            args[2] = in_DownHospitals.SUserPass;
            args[3] = in_DownHospitals.SHospitalCode;
            args[4] = in_DownHospitals.UpdateTime;
            args[10] = sResult;
            args[11] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownHospitals.Weburl,"DownHospitals ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownHospitals));
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 上传/修改转诊单信息
        /// </summary>
        /// <param name="in_UploadTransfer"></param>
        /// <returns></returns>
        public retMesage uploadTransfer(In_UploadTransfer in_UploadTransfer)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[36];
            string sMessage = "";
            string outtruncode = "";
            args[0] = in_UploadTransfer.SAreaCode;
            args[1] = in_UploadTransfer.SUserCode;
            args[2] = in_UploadTransfer.SUserPass;
            args[3] = in_UploadTransfer.SHospitalCode;
            args[4] = in_UploadTransfer.Truncode;
            args[5] = in_UploadTransfer.Stype;
            args[6] = in_UploadTransfer.Memberno;
            args[7] = in_UploadTransfer.Idcardno;
            args[8] = in_UploadTransfer.Name;
            args[9] = in_UploadTransfer.Sex;
            args[10] = in_UploadTransfer.Birthday;
            args[11] = in_UploadTransfer.Bookno;
            args[12] = in_UploadTransfer.Telphone;
            args[13] = in_UploadTransfer.Turntype;
            args[14] = in_UploadTransfer.Icdcode;
            args[15] = in_UploadTransfer.Icdname;
            args[16] = in_UploadTransfer.Turndate;
            args[17] = in_UploadTransfer.Fromhospitalcode;
            args[18] = in_UploadTransfer.Fromhospitalname;
            args[19] = in_UploadTransfer.Tohospitalcode;
            args[20] = in_UploadTransfer.Tohospitalname;
            args[21] = in_UploadTransfer.Tohospitallevel;
            args[22] = in_UploadTransfer.Tohospitalteclevel;
            args[23] = in_UploadTransfer.Leavedateoflasttime;
            args[24] = in_UploadTransfer.Outofficeoflasttime;
            args[25] = in_UploadTransfer.Icdcodeoflasttime;
            args[6] = in_UploadTransfer.Icdnameoflasttime;
            args[6] = in_UploadTransfer.Doctorname;
            args[6] = in_UploadTransfer.Remark;
            args[10] = outtruncode;
            args[11] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_UploadTransfer.Weburl,"UploadTransfer ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            List<object> cities = new List<object>();
            cities.Add(outtruncode);
            ret.Ret_data = cities;
            return ret;
        }
        /// <summary>
        /// 转诊单信息撤销
        /// </summary>
        /// <param name="in_CancelTransfer"></param>
        /// <returns></returns>
        public retMesage cancelTransfer(In_CancelTransfer in_CancelTransfer)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[12];
            string sMessage = "";
            args[0] = in_CancelTransfer.SAreaCode;
            args[1] = in_CancelTransfer.SUserCode;
            args[2] = in_CancelTransfer.SUserPass;
            args[3] = in_CancelTransfer.SHospitalCode;
            args[4] = in_CancelTransfer.Truncode;
            args[5] = in_CancelTransfer.Memberno;
            args[11] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_CancelTransfer.Weburl,"CancelTransfer ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_mesg = sMessage.ToString();
            ret.Ret_flag = true;
            return ret;
        }
        /// <summary>
        /// 转诊单信息查询
        /// </summary>
        /// <param name="in_DownloadTransfer"></param>
        /// <returns></returns>
        public retMesage downloadTransfer(In_DownloadTransfer in_DownloadTransfer)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[16];
            string sMessage = "";
            string sResult = "";
            args[0] = in_DownloadTransfer.SAreaCode;
            args[1] = in_DownloadTransfer.SUserCode;
            args[2] = in_DownloadTransfer.SUserPass;
            args[3] = in_DownloadTransfer.SHospitalCode;
            args[4] = in_DownloadTransfer.Inorout;
            args[5] = in_DownloadTransfer.Truncode;
            args[6] = in_DownloadTransfer.Memberno;
            args[7] = in_DownloadTransfer.Startturndate;
            args[7] = in_DownloadTransfer.Endturndate;
            args[14] = sResult;
            args[15] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_DownloadTransfer.Weburl,"DownloadTransfer ", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_DownloadTransfer));
            ret.Ret_flag = true;
            return ret;
        }

        /// <summary>
        /// 项目对照审核结果查询
        /// </summary>
        /// <param name="in_ItemContrastDown"></param>
        /// <returns></returns>
        public retMesage itemContrastDown(In_ItemContrastDown in_ItemContrastDown)
        {
            BllAhsjnhXml bllAhsjnhXml = new BllAhsjnhXml();
            string[] args = new string[11];
            string sMessage = "";
            string sResult = "";
            args[0] = in_ItemContrastDown.SAreaCode;
            args[1] = in_ItemContrastDown.SHospitalCode;
            args[2] = in_ItemContrastDown.SCenterItemC;
            args[3] = in_ItemContrastDown.SItemCode;
            args[9] = sResult;
            args[10] = sMessage;
            string data = bllAhsjnhXml.InvokeWebService(in_ItemContrastDown.Weburl,"ItemContrastDown", args).ToString();
            retMesage ret = new retMesage();
            if (data == "0")
            {
                ret.Ret_mesg = "客户端调用失败！" + sMessage.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_data = bllAhsjnhXml.parseResult(sResult, typeof(Out_ItemContrastDown));
            ret.Ret_flag = true;
            return ret;
        }


        /// <summary>
        /// 入院回退
        /// </summary>
        /// <returns></returns>
        public int retIhsp(string ihspid, StringBuilder returnMsg)
        {
            BillCmbList billCmbList = new BillCmbList();
            BillIhspcost billIhspcost = new BillIhspcost();
            RegInfo regInfo = readRegInfo(ihspid);            
            //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
            In_InpatientRegisterCancel inp = new In_InpatientRegisterCancel();
            inp.SAreaCode = regInfo.SAreaCode;
            inp.Weburl = regInfo.Weburl;
            inp.SHospitalCode = regInfo.SHospitalCode;
            inp.SInpatientID = regInfo.SInpatientID;
            inp.SOperatorName = billCmbList.getDoctorName(ProgramGlobal.User_id);//出院登记人(回归、冲消登记人)
            inp.SReason = "住院取消登记";
            retMesage ret = inpatientRegisterCancel(inp);
            if (!ret.Ret_flag)
            {
                returnMsg.Append(ret.Ret_mesg);
                return -1;
            }
            upopstat(Insurinfostate.XX.ToString(), ihspid);
            return 0;            
        }

        /// <summary>
        /// 门诊、住院取消结算
        /// </summary>
        /// <returns></returns>
        public int inpatientCalculateCancel(string ihspid,StringBuilder smessage)
        {
            In_InpatientCalculateCancel inp = new In_InpatientCalculateCancel();
            //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码
            RegInfo regInfo = readRegInfo(ihspid);
            //结算单号
            DataTable dt = ahsnhinfo(ihspid);
            string settinfo = dt.Rows[0]["registinfo"].ToString();
            inp.SAreaCode = regInfo.SAreaCode;
            inp.SInpatientID = regInfo.SInpatientID;
            inp.Weburl = regInfo.Weburl;
            inp.SHospitalCode = regInfo.SHospitalCode;
            inp.SCalculateCode = settinfo;
            inp.SReason = "结算回退！";
            retMesage ret = inpatientCalculateCancel(inp);
            if (!ret.Ret_flag)
            {
                smessage.Append("出错:" + ret.Ret_mesg);
                return -1;
            }
            //修改医保状态
            BillIhspcost billIhspcost=new BillIhspcost();
            BillIhspMan billIhspMan = new BillIhspMan();
            DataTable dtIhspcode = billIhspcost.ihspIdSearch(ihspid);
            string ihspcode = dtIhspcode.Rows[0]["ihspcode"].ToString();
            if (billIhspMan.upinsurstat(ihspcode, Insurstat.SIGN.ToString())<0)
            {
                smessage.Append("医保住院状态修改失败!");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 传送费用
        /// </summary>
        public int transfCost(string ihsp_id, string patienttypeid,StringBuilder retmes )
        {
            SysWriteLogs sysWriteLog = new SysWriteLogs();
            string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "select ihsp_costdet.id"      
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.standcode"
                            + ", cost_itemtype.itemtype_id"
                            + ", ihsp_costdet.spec"
                            + ", ihsp_costdet.unit"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.itemtype_id"
                            + ", ihsp_costdet.num"
                            + ", sys_dict.name as dosageform"
                            + ", cost_insuritem.name as hisname"
                            + ", cost_insuritem.hiscode"
                            + ", cost_insuritem.name2 as nh_name"
                            + ", cost_insuritem.insurcode as nh_code"
                            + ", cost_insuritem.id as insuritemid"
                            + " from ihsp_costdet"
                            + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id"
                            + " left join cost_insuritem on cost_insurcross.cost_insuritem_id=cost_insuritem.id"
                            + " left join bas_item on bas_item.id=ihsp_costdet.item_id"
                            + " left join sys_dict on bas_item.dosageform_id=sys_dict.sn and sys_dict.dicttype='drug_dosageform' and father<>0"
                            + " where ihsp_costdet.ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                            + " and cost_insuritem.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('CHAR')";
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
            RegInfo reginfo = readRegInfo(ihsp_id);
            //地区代码|医疗机构代码|医疗证号|webservice地址|就诊ID|人员编号|医疗卡号
            string sql3="";
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                In_InpatientFeeUpLoad inp = new In_InpatientFeeUpLoad();
                string[] param = new string[30];//参数数组
                inp.SAreaCode = reginfo.SAreaCode;
                inp.SInpatientID = reginfo.SInpatientID;
                inp.SHospitalCode = reginfo.SHospitalCode;
                inp.SCenterItemCode = datatable.Rows[i]["standcode"].ToString();//中心项目编码
                inp.SItemKey = datatable.Rows[i]["id"].ToString();//HIS记帐关键字
                sql="select insurcode from insur_itemfrom where itemtype_id="+DataTool.addFieldBraces("itemtype_id")+" and cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid);
                DataTable dttype = BllMain.Db.Select(sql).Tables[0];
                inp.SItemType = dttype.Rows[i]["insurcode"].ToString();//0:西药;1:成药;2:草药:6:特殊检查;9:诊疗项目
                inp.SReceiptName = datatable.Rows[i]["hisname"].ToString();//HIS发票项目名称(收费项目--医院名称)

                inp.SItemCode = datatable.Rows[i]["nh_code"].ToString();
                if (inp.SItemName.Equals("") || inp.SCenterItemCode.Equals(""))
                {
                    sysWriteLog.writeLogs("Errs", DateTime.Now, "ihsp_costdet.id =" + inp.SItemKey + " ;cost_insuritem.insurcode =" + inp.SCenterItemCode + ";cost_insuritem.name as hisname = " + inp.SItemName);
                }

                //是否进行对照
                string sqlCross = "select * from cost_insurcross where cost_insuritem_id=" + DataTool.addFieldBraces(datatable.Rows[i]["insuritemid"].ToString());
                DataTable dtCross = BllMain.Db.Select(sqlCross).Tables[0];
                if (dtCross.Rows.Count==0 || inp.SCenterItemCode.Equals("") || inp.SCenterItemCode == null)
                {
                    inp.SCenterItemCode = "480000010";    //自费的
                    inp.SItemName = "不可报诊疗服务项目";//dt_xmcx.Rows[j]["nh_mc"].ToString();   //收费项目--中心名称
                }
                if (dtCross.Rows.Count>0 && inp.SCenterItemCode.Equals("") && inp.SCenterItemCode == null)
                {

                    inp.SCenterItemCode = "480000010";  //自费的
                    inp.SItemName = "不可报诊疗服务项目";//dt_xmcx.Rows[j]["nh_mc"].ToString();   //收费项目--中心名称
                }
                inp.SItemName = datatable.Rows[i]["nh_name"].ToString();

                inp.SItemSpec = string.IsNullOrEmpty(datatable.Rows[i]["spec"].ToString()) ? "无" : datatable.Rows[i]["spec"].ToString();//规格
                inp.SItemDose = string.IsNullOrEmpty(datatable.Rows[i]["dosageform"].ToString()) ? "无" : datatable.Rows[i]["dosageform"].ToString();//HIS药品/项目剂型
                inp.SItemArea = "无";//HIS药品/项目产地
                inp.SItemProc = "无";//HIS药品/项目加工过程
                inp.SItemPart = "无";//HIS药品/项目入药部位
                inp.SIfCompound = "2";//(可为空)是否复方（1 单味 2 复方)
                inp.STime = datatable.Rows[i]["num"].ToString();
                inp.SPrice="";//单价
                inp.SUnit = datatable.Rows[i]["unit"].ToString();//HIS项目单位
                inp.SItemPart = datatable.Rows[i]["fee"].ToString();
                inp.SSectionOfficeName = "";//HIS科室名称
                inp.SSectionOfficeCode = "";//中心科室编码
                inp.SDoctorName = "";//医生名称
                inp.SOperatorDate = datatable.Rows[i]["chargedate"].ToString();//记帐时间
                inp.SInputName = "";//记帐人姓名                
                retMesage ret = inpatientFeeUpLoad(inp);
                if (!ret.Ret_flag)
                {
                    retmes.Append(ret.Ret_mesg);
                    //写日志文件
                    string outErr = "上传费用明细函数BllAhsnhMethod.inpatientFeeUpLoad失败信息: " + ret.Ret_mesg + ",药品id是:insuritemid=" + datatable.Rows[i]["insuritemid"].ToString() + "上传失败！";
                    sysWriteLog.writeLogs("Errs", DateTime.Now, outErr);
                    return -1;
                }
                else 
                {
                    string outLog = "上传费用明细函数BllAhsnhMethod.inpatientFeeUpLoad:insuritemid=" + datatable.Rows[i]["insuritemid"].ToString() + "上传成功！";
                    sysWriteLog.writeLogs("Logs", DateTime.Now, outLog);
                }

                Out_InpatientFeeUpLoad outp = (Out_InpatientFeeUpLoad)ret.Ret_data[0];
                string insue_costdet = "<info>"
                            + "<sApply>" + outp.sApply + "</sApply>"
                            + "<sOwn>" + outp.sOwn + "</sOwn>"
                            + "<sSelf>" + outp.sSelf + "</sSelf>"
                            + "<sMaxPrice>" + outp.sMaxPrice + "</sMaxPrice>"
                            + "<sApplyBL>" + outp.sApplyBL + "</sApplyBL>"
                            + "<sLimitPrice>" + outp.sLimitPrice + "</sLimitPrice>"
                            + "<sLowBL>" + outp.sLowBL + "</sLowBL>"
                            + "<sHighBL>" + outp.sHighBL + "</sHighBL>"
                            + "<sIfCMed>" + outp.sIfCMed + "</sIfCMed>"
                            + "</info>";
                string insurId = BillSysBase.nextId("insur_costdet");
                sql3 += "insert into insur_costdet(id"
                                    + ",ihsp_costdet_id"
                                    + ",insur_cost_id"
                                    + ",costdetinfo)values("
                                    + DataTool.addIntBraces(insurId)
                                    + "," + DataTool.addFieldBraces(datatable.Rows[i]["id"].ToString())
                                    + "," + DataTool.addFieldBraces(outp.sCenterKey)
                                    + "," + DataTool.addFieldBraces(insue_costdet)
                                    + ");";
            }
            BllMain.Db.Update(sql3);
            return 0;
        }
        /// <summary>
        /// 查询安徽农合信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable ahsnhinfo(string ihsp_id)
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
        /// 插入市安徽市农合登记信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int registInfo(string reginfo, string ihsp_id)
        {
            string opstat = "OO";//医保信息OO
            string id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihsp_id)
                                     + "," + DataTool.addFieldBraces(reginfo)
                                     + "," + DataTool.addFieldBraces(opstat)
                                     + ")";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 插入/更改安徽市农合结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int accountInfo(string accountinfo, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(accountinfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 插入/更改安徽市农合出院管理信息
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int ohspRegInfo(string ohspreginfo, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set ohspreginfo=" + DataTool.addFieldBraces(ohspreginfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 修改信息状态
        /// </summary>
        /// <param name="opstat"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int upopstat(string opstat, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set opstat=" + DataTool.addFieldBraces(opstat)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 查询医保接口状态
        /// </summary>
        /// <param name="ihsp"></param>
        /// <returns></returns>
        public DataTable insurstat(string ihspid)
        {
            DataTable dt = new DataTable();
            string sql = "select inhospital.insurstat"
                        + ",inhospital.ihspcode"
                        + ",inhospital.name"
                        + ",inhospital.feeamt"
                        + ",ihsp_account.invoice"
                        +" from inhospital"
                        +" left join ihsp_account on inhospital.id=ihsp_account.ihsp_id"
                        +" where inhospital.id=" + DataTool.addIntBraces(ihspid);
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
        /// 获取his项目信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="itemfrom"></param>
        /// <param name="isCross"></param>
        /// <returns></returns>
        public DataTable getItemInfo(string name, string itemfrom, string isCross)
        {
            DataTable dt = null;
            string sql = "";
            if (isCross == "0")
            {
                sql = "select "
                    + " id"
                    + ",standcode"
                    + ",name"
                    + ",insurcode"
                    + ",name2"
                    + ",unit"
                    + ",spec"
                    + ",itemfrom"
                    + " from cost_insuritem where name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%' "
                    + " and itemfrom in ("
                    + itemfrom + ")"
                    + " and id in (select item_id from cost_insurcross);";
            }
            else if (isCross == "-1")
            {
                sql = "select "
                    + " id"
                    + ",standcode"
                    + ",name"
                    + ",insurcode"
                    + ",name2"
                    + ",unit"
                    + ",spec"
                    + ",itemfrom"
                    + " from cost_insuritem where name like '%" + name.Trim() + "%' "
                    + " OR pincode like '%" + name.Trim() + "%' "
                    + " and itemfrom in ("
                    + itemfrom + ")"
                    + " and id not in (select item_id from cost_insurcross);";
            }
            dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public int itemCross(string id, string cost_insurtype_id, string itemfrom, string item_id, string cost_insuritem_id)
        {
            string sql = "insert into cost_insurcross ("
                       + " id"
                       + ",cost_insurtype_id"
                       + ",itemfrom"
                       + ",item_id"
                       + ",drug_factyitem_id"
                       + ",cost_insuritem_id )values ("
                       + DataTool.addFieldBraces(id)
                       + "," + DataTool.addFieldBraces(cost_insurtype_id)
                       + "," + DataTool.addFieldBraces(itemfrom)
                       + "," + DataTool.addFieldBraces(item_id)
                       + "," + DataTool.addFieldBraces("")
                       + "," + DataTool.addFieldBraces(cost_insuritem_id)
                       + ");";
            int result = BllMain.Db.Update(sql);
            return result;
        }

        /// <summary>
        /// 保存安徽市农合登记信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveRegXml(RegInfo regInfo, string ihsp_id)
        {
            string strXml = "<info>";
            strXml += "<areaCode>" +regInfo.SAreaCode+ "</areaCode>";
            strXml += "<medicalCode>" + regInfo.SMedicalCode + "</medicalCode>";
            strXml += "<inpatientID>" + regInfo.SInpatientID+ "</inpatientID>";
            strXml += "<cardCode>" + regInfo.SCardCode+ "</cardCode>";
            strXml += "<weburl>" + regInfo.Weburl+ "</weburl>";
            strXml += "<hospitalCode>" + regInfo.SHospitalCode+ "</hospitalCode>";
            strXml += "</info>";
            //地区代码|医疗证号|就诊ID|人员编号|医疗卡号|weburl|医疗机构编码            
            int flag = registInfo(strXml, ihsp_id);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 获取安徽市农合登记信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public RegInfo readRegInfo(string ihsp_id)
        {
            RegInfo regInfo = new RegInfo();
            DataTable dt = ahsnhinfo(ihsp_id);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            regInfo.Weburl = ds.Tables["info"].Rows[0]["weburl"].ToString();
            regInfo.SAreaCode = ds.Tables["info"].Rows[0]["areaCode"].ToString();
            regInfo.SMedicalCode = ds.Tables["info"].Rows[0]["medicalCode"].ToString();
            regInfo.SInpatientID = ds.Tables["info"].Rows[0]["inpatientID"].ToString();
            regInfo.SCardCode = ds.Tables["info"].Rows[0]["cardCode"].ToString();
            regInfo.SHospitalCode = ds.Tables["info"].Rows[0]["hospitalCode"].ToString();
            return regInfo;
        }

        /// <summary>
        /// 保存安徽市农合出院登记信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveohspXml(string ohspinfo, string ihsp_id)
        {
            string[] message = ohspinfo.Split('|');
            string strXml = "<info>";
            strXml += "<sDiagnoseNameOut>" + message[0] + "</sDiagnoseNameOut>";
            strXml += "<sDiagnoseCodeOut>" + message[1] + "</sDiagnoseCodeOut>";
            strXml += "</info>";
            //出院诊断名称|出院诊断编码    
            int flag = ohspRegInfo(strXml, ihsp_id);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 安徽市农合出院登记信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable readOhspXml(string ihsp_id)
        {
            DataTable dt = ahsnhinfo(ihsp_id);
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }



        #region 项目对照
        /// <summary>
        /// 获取His项目编号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getItemid(string name )
        {
            string sql = "select id from bas_item where name like '%" + name + "%'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["id"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取医保编号
        /// </summary>
        /// <param name="insurid"></param>
        /// <returns></returns>
        public string getInsurid(string keyname)
        {
            string sql = "select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["id"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
