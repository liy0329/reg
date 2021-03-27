using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class BasDoctor
    {
        private String id;
        private String netcode;//中心编码
        private String depart_id;//所属科室 depart_id
        private String name;//医生姓名
        private String pincode;//拼音简码
        private String sex;//性别枚举 M: 男 、W: 女 、U: 未知
        private String workno;//工号
        private String reg_level_id;//挂号等级
        private String hiscode;//his编号
        private String recipright;//处方权
        private String isstop;//停用 N: 默认 ,Y:停用  非空
        private String tel1;//手机
        private String tel2;//电话
        private String email;//电子邮件
        private String qqcode;//qq号
        private String wechat;//微信号
        private String Stringroduction;//个人简介
        private String keyword;//网络关键词
        private String netstop;//网络停用
        private String regString;//网络开展时间
        private String regstatus;//状态
        /**
         * practicetype_id
         * 执业类别外键(字典)
         */
        private String practicetype_id;//执业注册类别
        private String practicecode;//执业证书号

        /**
         * 执业范围（字典）
            例如:中医专业、中西医结合专业、全科医学专业、急救医学专业
            康复医学专业、预防保健专业、口腔科专业、蒙医专业、藏医专业
            傣医专业、维医专业、等
         */
        private String practicerange_id;//执业范围
        private String practiceString;//执业时间
        private String practicechg;//执业变更时间
        /**
         * manage_id
         * 行政职务（字典）
         */
        private String manage_id;//管理职务（字典）党委书记 院(所\站)长 科室主任 科长 护士长 等
        private String manageString;//行政职务聘任时间
        /**
         * dutytype_id
         * 专业技术职称（字典）
         */
        private String dutytype_id;//专业技术职务外键  bas_dutytype_id
        private String dutytypeString;//获取专业技术职称时间

        /**
         * certificate_id
         * 专业技术职称（字典）
         */
        private String certificate_id;//职称类别外键（字典） certificate_id
        private String worktype_id;//岗位类别
        private String joinpartyString;
        private String entryString;//到院时间
        private String engageString;//聘任日期
        private String cardid;//身份证号
        private String birthday;//出生日期
        private String education_id;//学历外键（字典）education_id 外键参考education.id
        private String eduspecial_id;//所学专业 eduspecial_id
        private String educollege;//毕业院校
        private String eduString;//毕业时间
        private String startworktime;//参加工作时间
        private String expired;//在职离职 枚举IS: 在职NO: 离职
        private String expireString;//离职日期
        private String sign;//签名图片路径
        private String nativeplace;//籍贯
        private String race;//民族
        private String homeaddr;//家庭住址
        private String memo;//备注
        private String createtime;//创建时间
        private String upStringtime;//更新时间
    }
}
