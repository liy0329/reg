/*************************************************************************************
     * CLR版本：       2.0.50727.1433
     * 类 名 称：       DictTypeConstant
     * 机器名称：       TIANCI
     * 命名空间：       MTLIS.common
     * 文 件 名：       DictTypeConstant
     * 创建时间：       2013-5-23 9:14:30
     * 作    者：       杨天赐
     * 说   明：        数据字典的常量
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTHIS.common
{
    /// <summary>
    ///数据字典常量类
    /// </summary>
    public class DictTypeConstant
    {
        /// <summary>
        ///  检验类型
        /// </summary>
        public const string CHK_TYPE = "chktype";
        /// <summary>
        /// 检验项目单位
        /// </summary>
        public const string CHK_PRJ_UNIT = "chkprjunit";
        /// <summary>
        /// 检验项目年龄单位
        /// </summary>
        public const string CHK_PRJ_AGE_UNIT = "chkprjageunit";
        /// <summary>
        /// 标本备注
        /// </summary>
        public const string SAMPLE_MEMO = "samplememo";
        /// <summary>
        /// 就诊类型
        /// </summary>
        public const string APP_TYPE = "apptype";
        /// <summary>
        /// 标本类型
        /// </summary>
        public const string SAMPLE_TYPE = "sampletype";
        /// <summary>
        /// 标本状态
        /// </summary>
        public const string SAMPLE_STATUS = "samplestatus";
        /// <summary>
        /// 质控规则
        /// </summary>
        public const string QLTY_RULE = "qltyrule";
        /// <summary>
        /// 检验方法
        /// </summary>
        public const string CHK_METHOD = "chkmethod";
        /// <summary>
        /// 质控波长
        /// </summary>
        public const string QLTY_WAVE_LENGTH = "qltywavelength";
        /// <summary>
        /// 失控原因
        /// </summary>
        public const string LOSE_CAUSE = "losecause";
        /// <summary>
        /// 纠正措施
        /// </summary>
        public const string CORRECT_MEASURE = "correctmeasure";
        /// <summary>
        /// 纠正结果
        /// </summary>
        public const string CORRECT_RESULT = "correctresult";
        /// <summary>
        /// 结果类型
        /// </summary>
        public const string RESULT_TYPE = "resulttype";

        /// <summary>
        /// 抗生素药品分类
        /// </summary>
        public const string DRUG_TYPE = "drugtype";

        /// <summary>
        /// 药品分组
        /// </summary>
        public const string DRUG_GROUP = "druggroup";

        /// <summary>
        /// 细菌大类
        /// </summary>
        public const string GERMS_TYPE = "germstype";

        /// <summary>
        /// 细菌标准分类
        /// </summary>
        public const string GERMSTAND_TYPE = "germstandtype";

        /// <summary>
        /// 过敏度
        /// </summary>
        public const string DRUGALLERGY_TYPE = "drugallergy";
    }
}
