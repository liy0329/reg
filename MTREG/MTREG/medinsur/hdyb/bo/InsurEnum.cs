using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class InsurEnum
    {
        /// <summary>
        /// 有效标志
        /// </summary>
        public enum Yxbz:int
        {
            /// <summary>
            /// 否
            /// </summary>
            N = 0,
            /// <summary>
            /// 是
            /// </summary>
            Y = 1
        };
        /// <summary>
        /// 收费项目等级
        /// </summary>
        public enum Sfxmdj : int
        {
            /// <summary>
            /// 甲类
            /// </summary>
            JL = 1,
            /// <summary>
            /// 乙类
            /// </summary>
            YL = 2,
            /// <summary>
            /// 自费
            /// </summary>
            ZF = 3
        };
        /// <summary>
        /// 出院原因
        /// </summary>
        public enum Cyyy : int
        {
            /// <summary>
            ///康复 
            /// </summary>
            KF = 1,
            /// <summary>
            ///转院 
            /// </summary>
            ZY = 2,
            /// <summary>
            //死亡 
            /// </summary>
            SW=3,
            /// <summary>
            ///其他 
            /// </summary>
            QT=4
        };
        /// <summary>
        /// 传输标志
        /// </summary>
        public enum Csbz : int
        {
            /// <summary>
            /// 未传输
            /// </summary>
             WCS= 0,
            /// <summary>
            /// 已传输
            /// </summary>
             YCS= 1
        };
        /// <summary>
        /// 药品/诊疗/床位费
        /// </summary>
        public enum Yzc : int
        {
            /// <summary>
            /// 药品
            /// </summary>
             YP= 1,
            /// <summary>
            ///诊疗 
            /// </summary>
             ZL= 2,
            /// <summary>
            ///床位费 
            /// </summary>
             CWF= 3
        };

        /// <summary>
        /// 审批状态
        /// </summary>
        public enum Spzt : int
        {
            /// <summary>
            /// 未审批
            /// </summary>
             WSP= 0,
            /// <summary>
            /// 审批通过
            /// </summary>
             SPTG= 1,
            /// <summary>
            /// 审批作废
            /// </summary>
             SPZF= 2
        };

        /// <summary>
        /// 生育手术类别
        /// </summary>
        public enum Sysslb : int
        {
            /// <summary>
            /// 顺产
            /// </summary>
             SC= 1,
            /// <summary>
            /// 异位妊娠手术
            /// </summary>
             YWRCSS= 2,
            /// <summary>
            /// 剖腹产
            /// </summary>
            PFC = 3,
            /// <summary>
            /// 怀孕二个月流产
            /// </summary>
            HYEGYLC=4,
            /// <summary>
            /// 二个月以上六个月以下引产
            /// </summary>
           EGYYSLGYYXYC =5
        };

        /// <summary>
        /// 审核标志
        /// </summary>
        public enum Shbz : int
        {
            限制性用药可报 = 1,
            限制性用药不可报 = 2,
            体内置换材料提供招标价格 = 3,
            体内置换材料不提供招标价格=4
        };


        //foreach (int  myCode in Enum.GetValues(typeof(eErrorDetailCode)))
        //     {
        //         string strName =Enum.GetName(typeof(eErrorDetailCode), myCode);//获取名称
        //         string strVaule = myCode.ToString();//获取值
        //         ListItem myLi = new ListItem(strName,strVaule);
        //         ddlType.Items.Add(myLi);//添加到DropDownList控件
        //     }
    }
}
