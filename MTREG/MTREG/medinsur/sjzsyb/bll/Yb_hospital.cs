using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.sjzsyb.bean;
using MTHIS.common;

namespace MTREG.medinsur.sjzsyb.bll
{
    public class Yb_hospital
    {
        /// <summary>
        /// 添加医保住院信息
        /// </summary>
        /// <param name="kc21"></param>
        /// <returns></returns>
        public string add_Sybzyjl(KC21 kc21)
        {
            string sql = " insert into Sybzyjl ( AKC190,"//门诊（住院）流水号，医院用于区分每次就诊或住院的唯一标识(不为空)
                                                 + "AKA130,"//医疗类别详见代码表(不为空)21，普通住院
                                                 + "AKC192,"//入院日期 YYYYMMDDHH24MISS（如果是门诊，则为门诊日期）(不为空)
                                                 + "AKC193,"//入院诊断疾病编码(不为空)
                                                 + "AKC194,"//出院日期 YYYYMMDDHH24MISS（住院费用结算时必录）
                                                 + "AKC195,"//出院原因（住院费用结算时必录）
                                                 + "AKC196,"//出院疾病诊断编码（门诊、住院费用结算时必录）
                                                 + "AAE011,"//经办人(不为空)
                                                 + "AAE036,"//经办日期 YYYYMMDDHH24MISS(不为空)
                                                 + "AKC008,"//医生姓名(不为空)
                                                 + "AKC025,"//科室名称(不为空)
                                                 + "AKC140,"//入院诊断疾病名称(不为空)
                                                 + "AKC600,"//入院描述
                                                 + "AKC141,"//出院疾病诊断名称（门诊、住院费用结算时必录）
                                                 + "AKC701,"//出院描述
                                                 + "AKC030,"//病房号
                                                 + "AKE020,"//病床号
                                                 + "AKC032,"//住址
                                                 + "AKC033,"//职业
                                                 + "AKC034,"//患者联系电话
                                                 + "AKC031,"//病历号(不为空)
                                                 + "AMC026,"//生育类别（选择生育门诊,生育住院登记,生育住院登记信息修改,生育住院结算时必须录入）
                                                 + "AMC100,"//孕周（选择生育医疗类别时，必须录入）
                                                 + "AMC001,"//准生证号
                                                 + "AMC013,"//胎儿数（正常生产、难产、剖腹产时为必填项）
                                                 + "AMC008,"//出生证编号
                                                 + "AKC120,"//意外伤害标志
                                                 + "BKF040,"//中心科室编码(不为空)
                                                 + "BKF050,"//中心医师编码(不为空)
                                                 + "AMC020,"//手术日期,分娩日期或流产日期(生育住院结算时必须录入),必须在入院日期之后,不能晚于结算日期
                                                 + "AKC069,"//急诊标志，用于记录急诊就医
                                                 + "CKAA59,"//是否双侧输卵管结扎（0 否 1 是）（正常生产、难产、剖腹产时为必填项）
                                                 + "kc33xml)"
                                         + "VALUES ("
                                         + DataTool.addFieldBraces(kc21.AKC190)
                                         + "," + DataTool.addFieldBraces(kc21.AKA130)
                                         + "," + DataTool.addFieldBraces(kc21.AKC192)
                                         + "," + DataTool.addFieldBraces(kc21.AKC193)
                                         + "," + DataTool.addFieldBraces(kc21.AKC194)
                                         + "," + DataTool.addFieldBraces(kc21.AKC195)
                                         + "," + DataTool.addFieldBraces(kc21.AKC196)
                                         + "," + DataTool.addFieldBraces(kc21.AAE011)
                                         + "," + DataTool.addFieldBraces(kc21.AAE036)
                                         + "," + DataTool.addFieldBraces(kc21.AKC008)
                                         + "," + DataTool.addFieldBraces(kc21.AKC025)
                                         + "," + DataTool.addFieldBraces(kc21.AKC140)
                                         + "," + DataTool.addFieldBraces(kc21.AKC600)
                                         + "," + DataTool.addFieldBraces(kc21.AKC141)
                                         + "," + DataTool.addFieldBraces(kc21.AKC701)
                                         + "," + DataTool.addFieldBraces(kc21.AKC030)
                                         + "," + DataTool.addFieldBraces(kc21.AKE020)
                                         + "," + DataTool.addFieldBraces(kc21.AKC032)
                                         + "," + DataTool.addFieldBraces(kc21.AKC033)
                                         + "," + DataTool.addFieldBraces(kc21.AKC034)
                                         + "," + DataTool.addFieldBraces(kc21.AKC031)
                                         + "," + DataTool.addFieldBraces(kc21.AMC026)
                                         + "," + DataTool.addFieldBraces(kc21.AMC100)
                                         + "," + DataTool.addFieldBraces(kc21.AMC001)
                                         + "," + DataTool.addFieldBraces(kc21.AMC013)
                                         + "," + DataTool.addFieldBraces(kc21.AMC008)
                                         + "," + DataTool.addFieldBraces(kc21.AKC120)
                                         + "," + DataTool.addFieldBraces(kc21.BKF040)
                                         + "," + DataTool.addFieldBraces(kc21.BKF050)
                                         + "," + DataTool.addFieldBraces(kc21.AMC020)
                                         + "," + DataTool.addFieldBraces(kc21.AKC069)
                                         + "," + DataTool.addFieldBraces(kc21.CKAA59)
                                         + "," + DataTool.addFieldBraces(kc21.KC33XML)
                                         + ");";

            return sql;
        }
        /// <summary>
        /// 添加医保住院信息
        /// </summary>
        /// <param name="kc21"></param>
        /// <returns></returns>
        public string add_Sybmzjl(KC21 kc21)
        {
            string sql = " insert into Sybmzjl ( AKC190,"//门诊（住院）流水号，医院用于区分每次就诊或住院的唯一标识(不为空)
                                                 + "AKA130,"//医疗类别详见代码表(不为空)21，普通住院
                                                 + "AKC192,"//入院日期 YYYYMMDDHH24MISS（如果是门诊，则为门诊日期）(不为空)
                                                 + "AKC193,"//入院诊断疾病编码(不为空)
                                                 + "AKC194,"//出院日期 YYYYMMDDHH24MISS（住院费用结算时必录）
                                                 + "AKC195,"//出院原因（住院费用结算时必录）
                                                 + "AKC196,"//出院疾病诊断编码（门诊、住院费用结算时必录）
                                                 + "AAE011,"//经办人(不为空)
                                                 + "AAE036,"//经办日期 YYYYMMDDHH24MISS(不为空)
                                                 + "AKC008,"//医生姓名(不为空)
                                                 + "AKC025,"//科室名称(不为空)
                                                 + "AKC140,"//入院诊断疾病名称(不为空)
                                                 + "AKC600,"//入院描述
                                                 + "AKC141,"//出院疾病诊断名称（门诊、住院费用结算时必录）
                                                 + "AKC701,"//出院描述
                                                 + "AKC030,"//病房号
                                                 + "AKE020,"//病床号
                                                 + "AKC032,"//住址
                                                 + "AKC033,"//职业
                                                 + "AKC034,"//患者联系电话
                                                 + "AKC031,"//病历号(不为空)
                                                 + "AMC026,"//生育类别（选择生育门诊,生育住院登记,生育住院登记信息修改,生育住院结算时必须录入）
                                                 + "AMC100,"//孕周（选择生育医疗类别时，必须录入）
                                                 + "AMC001,"//准生证号
                                                 + "AMC013,"//胎儿数（正常生产、难产、剖腹产时为必填项）
                                                 + "AMC008,"//出生证编号
                                                 + "AKC120,"//意外伤害标志
                                                 + "BKF040,"//中心科室编码(不为空)
                                                 + "BKF050,"//中心医师编码(不为空)
                                                 + "AMC020,"//手术日期,分娩日期或流产日期(生育住院结算时必须录入),必须在入院日期之后,不能晚于结算日期
                                                 + "AKC069,"//急诊标志，用于记录急诊就医
                                                 + "CKAA59)"//是否双侧输卵管结扎（0 否 1 是）（正常生产、难产、剖腹产时为必填项）
                                         + "VALUES ("
                                         + DataTool.addFieldBraces(kc21.AKC190)
                                         + "," + DataTool.addFieldBraces(kc21.AKA130)
                                         + "," + DataTool.addFieldBraces(kc21.AKC192)
                                         + "," + DataTool.addFieldBraces(kc21.AKC193)
                                         + "," + DataTool.addFieldBraces(kc21.AKC194)
                                         + "," + DataTool.addFieldBraces(kc21.AKC195)
                                         + "," + DataTool.addFieldBraces(kc21.AKC196)
                                         + "," + DataTool.addFieldBraces(kc21.AAE011)
                                         + "," + DataTool.addFieldBraces(kc21.AAE036)
                                         + "," + DataTool.addFieldBraces(kc21.AKC008)
                                         + "," + DataTool.addFieldBraces(kc21.AKC025)
                                         + "," + DataTool.addFieldBraces(kc21.AKC140)
                                         + "," + DataTool.addFieldBraces(kc21.AKC600)
                                         + "," + DataTool.addFieldBraces(kc21.AKC141)
                                         + "," + DataTool.addFieldBraces(kc21.AKC701)
                                         + "," + DataTool.addFieldBraces(kc21.AKC030)
                                         + "," + DataTool.addFieldBraces(kc21.AKE020)
                                         + "," + DataTool.addFieldBraces(kc21.AKC032)
                                         + "," + DataTool.addFieldBraces(kc21.AKC033)
                                         + "," + DataTool.addFieldBraces(kc21.AKC034)
                                         + "," + DataTool.addFieldBraces(kc21.AKC031)
                                         + "," + DataTool.addFieldBraces(kc21.AMC026)
                                         + "," + DataTool.addFieldBraces(kc21.AMC100)
                                         + "," + DataTool.addFieldBraces(kc21.AMC001)
                                         + "," + DataTool.addFieldBraces(kc21.AMC013)
                                         + "," + DataTool.addFieldBraces(kc21.AMC008)
                                         + "," + DataTool.addFieldBraces(kc21.AKC120)
                                         + "," + DataTool.addFieldBraces(kc21.BKF040)
                                         + "," + DataTool.addFieldBraces(kc21.BKF050)
                                         + "," + DataTool.addFieldBraces(kc21.AMC020)
                                         + "," + DataTool.addFieldBraces(kc21.AKC069)
                                         + "," + DataTool.addFieldBraces(kc21.CKAA59)
                                         + ");";

            return sql;
        }
       
    }
}
