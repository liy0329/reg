using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hsdryb.bo
{
    /// <summary>
    /// 费用明细
    /// </summary>
    class KC22
    {
        /// <summary>
        /// 门诊（住院）号
        /// </summary>
        public string AKC190 { get; set; }

        /// <summary>
        /// 处方号
        /// </summary>
        public string AKC220 { get; set; }

        /// <summary>
        /// 处方日期yyyyMMddHHmmss
        /// </summary>
        public string AKC221 { get; set; }

        /// <summary>
        /// 医院收费项目编码
        /// </summary>
        public string AKC515 { get; set; }

        /// <summary>
        /// 医院收费项目名称
        /// </summary>
        public string AKC516 { get; set; }

        /// <summary>
        /// 药品/诊疗/床位费
        /// </summary>
        public string AKC224 { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string AKC225 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string AKC226 { get; set; }

        /// <summary>
        /// 金额 
        /// </summary>
        public string AKC227 { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        public string AKA070 { get; set; }

        /// <summary>
        /// 每次用量  
        /// </summary>
        public string AKA071 { get; set; }

        /// <summary>
        /// 每次用量单位   
        /// </summary>
        public string AKC602 { get; set; }

        /// <summary>
        /// 使用频次    
        /// </summary>
        public string AKA072 { get; set; }

        /// <summary>
        /// 用法    
        /// </summary>
        public string AKA073 { get; set; }

        /// <summary>
        /// 执行天数    
        /// </summary>
        public string AKC603 { get; set; }

        /// <summary>
        /// 规格名称    
        /// </summary>
        public string AKC604 { get; set; }

        /// <summary>
        /// 每日最大用量
        /// </summary>
        public string AKA075 { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string BKA970 { get; set; }

        /// <summary>
        /// 医师编码
        /// </summary>
        public string BKF050 { get; set; }

        /// <summary>
        /// 医师名称
        /// </summary>
        public string AKC008 { get; set; }

        /// <summary>
        /// KC22出参
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string KC22_inXml(List<KC22> entity)
        {
            StringBuilder sb = new StringBuilder(200);

            foreach (var item in entity)
            {
                sb.Append("<KC22ROW>");
                sb.AppendFormat("<AKC190>{0}</AKC190>", item.AKC190);
                sb.AppendFormat("<AKC220>{0}</AKC220>", item.AKC220);
                // sb.AppendFormat("<AKC221>{0}</AKC221>",DateTime.Parse(item.AKC221).ToString("yyyyMMddHHmmss"));
                sb.AppendFormat("<AKC221>{0}</AKC221>", item.AKC221);
                sb.AppendFormat("<AKC515>{0}</AKC515>", item.AKC515);
                sb.AppendFormat("<AKC516>{0}</AKC516>", item.AKC516);
                sb.AppendFormat("<AKC224>{0}</AKC224>", item.AKC224);
                sb.AppendFormat("<AKC225>{0}</AKC225>", item.AKC225);
                sb.AppendFormat("<AKC226>{0}</AKC226>", item.AKC226);
                sb.AppendFormat("<AKC227>{0}</AKC227>", item.AKC227);
                sb.AppendFormat("<AKA070>{0}</AKA070>", item.AKA070);
                sb.AppendFormat("<AKA071>{0}</AKA071>", item.AKA071);
                sb.AppendFormat("<AKC602>{0}</AKC602>", item.AKC602);
                sb.AppendFormat("<AKA072>{0}</AKA072>", item.AKA072);
                sb.AppendFormat("<AKA073>{0}</AKA073>", item.AKA073);
                sb.AppendFormat("<AKC603>{0}</AKC603>", item.AKC603);
                sb.AppendFormat("<AKC604>{0}</AKC604>", item.AKC604);
                sb.AppendFormat("<AKA075>{0}</AKA075>", item.AKA075);
                sb.AppendFormat("<BKA970>{0}</BKA970>", item.BKA970);
                sb.AppendFormat("<BKF050>{0}</BKF050>", item.BKF050);
                sb.AppendFormat("<AKC008>{0}</AKC008>", item.AKC008);
                sb.Append("</KC22ROW>");
            }

            return sb.ToString();
        }
        /// <summary>
        /// KC22出参（门诊）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string mzKC22_inXml(List<KC22> entity)
        {
            StringBuilder sb = new StringBuilder(200);

            foreach (var item in entity)
            {
                sb.Append("<KC22ROW>");
                sb.AppendFormat("<AKC190>{0}</AKC190>", item.AKC190);
                sb.AppendFormat("<AKC220>{0}</AKC220>", item.AKC220);
                sb.AppendFormat("<AKC221>{0}</AKC221>", DateTime.Parse(item.AKC221).ToString("yyyyMMddHHmmss"));
                //sb.AppendFormat("<AKC221>{0}</AKC221>", item.AKC221);
                sb.AppendFormat("<AKC515>{0}</AKC515>", item.AKC515);
                sb.AppendFormat("<AKC516>{0}</AKC516>", item.AKC516);
                sb.AppendFormat("<AKC224>{0}</AKC224>", item.AKC224);
                sb.AppendFormat("<AKC225>{0}</AKC225>", item.AKC225);
                sb.AppendFormat("<AKC226>{0}</AKC226>", item.AKC226);
                sb.AppendFormat("<AKC227>{0}</AKC227>", item.AKC227);
                sb.AppendFormat("<AKA070>{0}</AKA070>", item.AKA070);
                sb.AppendFormat("<AKA071>{0}</AKA071>", item.AKA071);
                sb.AppendFormat("<AKC602>{0}</AKC602>", item.AKC602);
                sb.AppendFormat("<AKA072>{0}</AKA072>", item.AKA072);
                sb.AppendFormat("<AKA073>{0}</AKA073>", item.AKA073);
                sb.AppendFormat("<AKC603>{0}</AKC603>", item.AKC603);
                sb.AppendFormat("<AKC604>{0}</AKC604>", item.AKC604);
                sb.AppendFormat("<AKA075>{0}</AKA075>", item.AKA075);
                sb.AppendFormat("<BKA970>{0}</BKA970>", item.BKA970);
                sb.AppendFormat("<BKF050>{0}</BKF050>", item.BKF050);
                sb.AppendFormat("<AKC008>{0}</AKC008>", item.AKC008);
                sb.Append("</KC22ROW>");
            }

            return sb.ToString();
        }
    }
}
