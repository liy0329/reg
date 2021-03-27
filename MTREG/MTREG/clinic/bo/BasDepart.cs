using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class BasDepart
    {
        private String id;
	    private String netcode;// 中心编码
	    private String name;// 科室名称
	    private String pincode;// 拼音简码
	    private String bascode;// 编码 -层级编码
	    private String hiscode;// 科室编码
	    private String keyname;// 科室关键字
	    private String father_id;// 级别 (上级科室)
	    private String ordersn;// 科室排序 显示下拉列表顺序（同一级别顺序）
	    private String position;// 位置
	    private String leader;// 负责人
	    private String infect_environclass_id;// 环境类别（字典） 院感的环境类别
	    private String tel;// 电话
	    private String fax;// 传真
	    private String bas_deprank_id;// 属性分类 {0：不区分、1：医院科室、2: 门诊诊室、 3: 住院病区}
	    private String Stringroduction;// 科室简介
	    private String keyword;// 网络关键词
	    private String isstop;// 是否停用{N:NO 默认/Y:YES}非空
	    private String sync;// 
	    private String netstartdate;// 
	    private String netstop;// 
	    private String memo;// 备注
	    private String createtime;// 创建时间
	    private String upString;// 更新时间
    }
}
