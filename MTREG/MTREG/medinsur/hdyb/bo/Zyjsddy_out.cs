using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Zyjsddy_out
    {
        //医保中心名称|医院住院号|单据号|定点医院名称|科室|出院次数|患者姓名|住院号|入院日期|出院日期|住院天数|个人编号|IC卡号|人员类别|是否公务员|床位费|西药|中成药|中草药|
        private string _ybzxmc;
        private string _yyzyh;
        private string _djh;
        private string _ddymmc;
        private string _ks;
        private string _cycs;
        private string _hzxm;
        private string _zyh;
        private string _ryrq;
        private string _cyrq;
        private string _zyts;
        private string _grbh;
        private string _ickh;
        private string _rylb;
        private string _sfgwy;
        private string _cwf;
        private string _xy;
        private string _zchengy;
        private string _zcaoy;
        //化验|检查|治疗|放射|手术|血费|输氧|冷暖|其他|合计|实收金额|甲类药费|甲类诊疗|标准床费|乙类药费|乙类诊疗|自费药费|自费诊疗|超标床费|起付标准|其他自费|
        private string _hy;
        private string _jc;
        private string _zl;
        private string _fs;
        private string _ss;
        private string _xf;
        private string _sy;
        private string _ln;
        private string _qt;
        private string _hj;
        private string _ssje;
        private string _jlyf;
        private string _jlzl;
        private string _bzcf;
        private string _ylyf;
        private string _ylzl;
        private string _zfyf;
        private string _zfzl;
        private string _cbcf;
        private string _qfbz;
        private string _qtzf;
        //进入统筹基金金额|统筹基金支付|本年度统筹基金支付|进入大病基金金额|大病基金支付|本年度大病基金支付|基本医疗自付金额|公务员基金支付|本次结算后负担余额|
        private string _jrtcjjje;
        private string _tcjjzf;
        private string _bndtcjjzf;
        private string _jrdbjjje;
        private string _dbjjzf;
        private string _bnddbjjzf;
        private string _jbylzfje;
        private string _gwyjjzf;
        private string _bcjshfdye;
        //自付自费金额合计|其中个人账户支付|本次支付后个人账户余额|个人支付现金|押金|退或补现金|经办人|结算日期
        private string _zfzfjehj;
        private string _qzgrzhzf;
        private string _bczfhgrzhye;
        private string _grzfxj;
        private string _yj;
        private string _thbxj;
        private string _jbr;
        private string _jsrq;
        private string _message;
        //乙类限制性用药|超限价诊疗|公务员超限价诊疗|公务员起付线补助|公务员床位费补助|进入超大病基金金额|超大病基金支付|符合公务员补助基数|进入公务员基金金额|本次报销总额|本次自费总额|自付金额|自费金额|公务员超限额床费
        private string _ylxzxyy;

        public string Ylxzxyy
        {
            get { return _ylxzxyy; }
            set { _ylxzxyy = value; }
        }
        private string _cxjzl;

        public string Cxjzl
        {
            get { return _cxjzl; }
            set { _cxjzl = value; }
        }
        private string _gwycxjzl;

        public string Gwycxjzl
        {
            get { return _gwycxjzl; }
            set { _gwycxjzl = value; }
        }
        private string _gwyqfxbz;

        public string Gwyqfxbz
        {
            get { return _gwyqfxbz; }
            set { _gwyqfxbz = value; }
        }
        private string _gwycwfbz;

        public string Gwycwfbz
        {
            get { return _gwycwfbz; }
            set { _gwycwfbz = value; }
        }
        private string _jrcdbjjje;

        public string Jrcdbjjje
        {
            get { return _jrcdbjjje; }
            set { _jrcdbjjje = value; }
        }
        private string _cdbjjzf;

        public string Cdbjjzf
        {
            get { return _cdbjjzf; }
            set { _cdbjjzf = value; }
        }
        private string _fhgwybzjs;

        public string Fhgwybzjs
        {
            get { return _fhgwybzjs; }
            set { _fhgwybzjs = value; }
        }
        private string _jrgwyjjje;

        public string Jrgwyjjje
        {
            get { return _jrgwyjjje; }
            set { _jrgwyjjje = value; }
        }
        private string _bcbxze;

        public string Bcbxze
        {
            get { return _bcbxze; }
            set { _bcbxze = value; }
        }
        private string _bczfze;

        public string Bczfze
        {
            get { return _bczfze; }
            set { _bczfze = value; }
        }
        private string _zfuje;

        public string Zfuje
        {
            get { return _zfuje; }
            set { _zfuje = value; }
        }
        private string _zfeije;

        public string Zfeije
        {
            get { return _zfeije; }
            set { _zfeije = value; }
        }
        private string _gwycxecf;

        public string Gwycxecf
        {
            get { return _gwycxecf; }
            set { _gwycxecf = value; }
        }

        public string Ybzxmc
        {
            set { _ybzxmc = value; }
            get { return _ybzxmc; }
        }
        public string Yyzyh
        {
            set { _yyzyh = value; }
            get { return _yyzyh; }
        }
        //单据号|定点医院名称|科室|出院次数|患者姓名|住院号|入院日期|出院日期|住院天数|个人编号|IC卡号|人员类别|是否公务员|床位费|西药|中成药|中草药|
        public string Djh
        {
            set { _djh = value; }
            get { return _djh; }
        }
        public string Ddyymc
        {
            set { _ddymmc = value; }
            get { return _ddymmc; }
        }
        public string Ks
        {
            set { _ks = value; }
            get { return _ks; }
        }
        public string Cycs
        {
            set { _cycs = value; }
            get { return _cycs; }
        }
        public string Hzxm
        {
            set { _hzxm = value; }
            get { return _hzxm; }
        }
        public string Zyh
        {
            set { _zyh = value; }
            get { return _zyh; }
        }
        public string Ryrq
        {
            set { _ryrq = value; }
            get { return _ryrq; }
        }
        public string Cyrq
        {
            set { _cyrq = value; }
            get { return _cyrq; }
        }
        public string Zyts
        {
            set { _zyts = value; }
            get { return _zyts; }
        }
        //个人编号|IC卡号|人员类别|是否公务员|床位费|西药|中成药|中草药|
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        public string Ickh
        {
            set { _ickh = value; }
            get { return _ickh; }
        }
        public string Rylb
        {
            set { _rylb = value; }
            get { return _rylb; }
        }
        public string Sfgwy
        {
            set { _sfgwy = value; }
            get { return _sfgwy; }
        }
        public string Cwf
        {
            set { _cwf = value; }
            get { return _cwf; }
        }
        public string Xy
        {
            set { _xy = value; }
            get { return _xy; }
        }
        public string Zchengy
        {
            set { _zchengy = value; }
            get { return _zchengy; }
        }
        public string Zcaoy
        {
            set { _zcaoy = value; }
            get { return _zcaoy; }
        }
        //化验|检查|治疗|放射|手术|血费|输氧|冷暖|其他|合计|实收金额|甲类药费|甲类诊疗|标准床费|乙类药费|乙类诊疗|自费药费|自费诊疗|超标床费|起付标准|其他自费|
        public string Hy
        {
            set { _hy = value; }
            get { return _hy; }
        }
        public string Jc
        {
            set { _jc = value; }
            get { return _jc; }
        }
        public string Zl
        {
            set { _zl = value; }
            get { return _zl; }
        }
        public string Fs
        {
            set { _fs = value; }
            get { return _fs; }
        }
        public string Ss
        {
            set { _ss = value; }
            get { return _ss; }
        }
        public string Xf
        {
            set { _xf = value; }
            get { return _xf; }
        }
        public string Sy
        {
            set { _sy = value; }
            get { return _sy; }
        }
        public string Ln
        {
            set { _ln = value; }
            get { return _ln; }
        }
        public string Qt
        {
            set { _qt = value; }
            get { return _qt; }
        }
        public string Hj
        {
            set { _hj = value; }
            get { return _hj; }
        }
        //实收金额|甲类药费|甲类诊疗|标准床费|乙类药费|乙类诊疗|自费药费|自费诊疗|超标床费|起付标准|其他自费|
        public string Ssje
        {
            set { _ssje = value; }
            get { return _ssje; }
        }
        public string Jlyf
        {
            set { _jlyf = value; }
            get { return _jlyf; }
        }
        public string Jlzl
        {
            set { _jlzl = value; }
            get { return _jlzl; }
        }
        public string Bzcf
        {
            set { _bzcf = value; }
            get { return _bzcf; }
        }
        public string Ylyf
        {
            set { _ylyf = value; }
            get { return _ylyf; }
        }
        public string Ylzl
        {
            set { _ylzl = value; }
            get { return _ylzl; }
        }
        public string Zfyf
        {
            set { _zfyf = value; }
            get { return _zfyf; }
        }
        public string Zfzl
        {
            set { _zfzl = value; }
            get { return _zfzl; }
        }
        public string Cbcf
        {
            set { _cbcf = value; }
            get { return _cbcf; }
        }
        public string Qfbz
        {
            set { _qfbz = value; }
            get { return _qfbz; }
        }
        public string Qtzf
        {
            set { _qtzf = value; }
            get { return _qtzf; }
        }
        //进入统筹基金金额|统筹基金支付|本年度统筹基金支付|进入大病基金金额|大病基金支付|本年度大病基金支付|基本医疗自付金额|公务员基金支付|本次结算后负担余额|
        public string Jrtcjjje
        {
            set { _jrtcjjje = value; }
            get { return _jrtcjjje; }
        }
        public string Tcjjzf
        {
            set { _tcjjzf = value; }
            get { return _tcjjzf; }
        }
        public string Bndtcjjzf
        {
            set { _bndtcjjzf = value; }
            get { return _bndtcjjzf; }
        }
        public string Jrdbjjje
        {
            set { _jrdbjjje = value; }
            get { return _jrdbjjje; }
        }
        public string Dbjjzf
        {
            set { _dbjjzf = value; }
            get { return _dbjjzf; }
        }
        public string Bnddbjjzf
        {
            set { _bnddbjjzf = value; }
            get { return _bnddbjjzf; }
        }
        public string Jbylzfje
        {
            set { _jbylzfje = value; }
            get { return _jbylzfje; }
        }
        public string Gwyjjzf
        {
            set { _gwyjjzf = value; }
            get { return _gwyjjzf; }
        }
        public string Bcjshfdye
        {
            set { _bcjshfdye = value; }
            get { return _bcjshfdye; }
        }
        //自付自费金额合计|其中个人账户支付|本次支付后个人账户余额|个人支付现金|押金|退或补现金|经办人|结算日期
        public string Zfzfjehj
        {
            set { _zfzfjehj = value; }
            get { return _zfzfjehj; }
        }
        public string Qzgrzhzf
        {
            set { _qzgrzhzf = value; }
            get { return _qzgrzhzf; }
        }
        public string Bczfhgrzhye
        {
            set { _bczfhgrzhye = value; }
            get { return _bczfhgrzhye; }
        }
        public string Grzfxj
        {
            set { _grzfxj = value; }
            get { return _grzfxj; }
        }
        public string Yj
        {
            set { _yj = value; }
            get { return _yj; }
        }
        public string Thbxj
        {
            set { _thbxj = value; }
            get { return _thbxj; }
        }
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }
        public string Jsrq
        {
            set { _jsrq = value; }
            get { return _jsrq; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

        //|普通项目符合基本医疗

        private string ptxmfhjbyl;

        public string Ptxmfhjbyl
        {
            get { return ptxmfhjbyl; }
            set { ptxmfhjbyl = value; }
        }

        //|一次性材料报销金额
        private string ycxclbxje;

        public string Ycxclbxje
        {
            get { return ycxclbxje; }
            set { ycxclbxje = value; }
        }

        //|一次性材料符合基本医疗
        private string ycxclfhjbyl;

        public string Ycxclfhjbyl
        {
            get { return ycxclfhjbyl; }
            set { ycxclfhjbyl = value; }
        }

        //|统筹第一段
        private string tcdyd;

        public string Tcdyd
        {
            get { return tcdyd; }
            set { tcdyd = value; }
        }

        //|统筹第2段
        private string tcded;

        public string Tcded
        {
            get { return tcded; }
            set { tcded = value; }
        }

        //|统筹第3段
        private string tcdsd;

        public string Tcdsd
        {
            get { return tcdsd; }
            set { tcdsd = value; }
        }

        //|统筹第4段
        private string tcdsid;

        public string Tcdsid
        {
            get { return tcdsid; }
            set { tcdsid = value; }
        }

        //|统筹第5段
        private string tcdwd;

        public string Tcdwd
        {
            get { return tcdwd; }
            set { tcdwd = value; }
        }

        //|统筹1段自付金额
        private string tcdydzfje;

        public string Tcdydzfje
        {
            get { return tcdydzfje; }
            set { tcdydzfje = value; }
        }

        //|统筹2段自付金额
        private string tcdedzfje;

        public string Tcdedzfje
        {
            get { return tcdedzfje; }
            set { tcdedzfje = value; }
        }

        //|统筹3段自付金额
        private string tcdsdzfje;

        public string Tcdsdzfje
        {
            get { return tcdsdzfje; }
            set { tcdsdzfje = value; }
        }

        //|统筹4段自付金额
        private string tcdsidzfje;

        public string Tcdsidzfje
        {
            get { return tcdsidzfje; }
            set { tcdsidzfje = value; }
        }

        //|统筹5段自付金额
        private string tcdwdzfje;

        public string Tcdwdzfje
        {
            get { return tcdwdzfje; }
            set { tcdwdzfje = value; }
        }
        //大写人民币
        private string rmb;

        public string Rmb
        {
            get { return rmb; }
            set { rmb = value; }
        }

        private string yllb;//医疗类别

        public string Yllb
        {
            get { return yllb; }
            set { yllb = value; }
        }
        //医院名称|科室| 流水号 //住院号 | 住院时间 | 住院天数  //  姓名| 性别 //左列。。。床位费 | 诊查费|检查费|化验费|治疗费|手术费 //右列。。。护理费|卫生材料费|药品费|药事服务费|一般诊疗费|其他住院费用|输血费  //合计(大写) | (数字) //预交金额 | 退费金额//收款人 | 收款日期
        private string _yymc;//医院名称      
        private string _lsh;//流水号 
        private string _zykssj;//住院开始时间
        private string _zyjssj;//住院结束时间 
        private string _hzxb;//患者性别 
        private string _zcf;//诊查费
        private string _jcf;//检查费
        private string _hyf;//化验费
        private string _zlf;//治疗费
        private string _ssf;//手术费
        private string _hlf;//护理费
        private string _wsclf;//卫生材料费
        private string _ypf;//药品费
        private string _ysfwf;//药事服务费
        private string _ybzlf;//一般诊疗费
        private string _qtzyfy;//其他住院费用
        private string _sxf;//输血费
        private string _hjdx;//合计(大写)
        private string _hjsz;//合计(数字)
        private string _yjje;//预交金额 
        private string _tfje;//退费金额
        private string _skr;//收款人 
        private string _skrq;// 收款日期
        private string _bjje;//补缴金额

        public string Bjje
        {
            get { return _bjje; }
            set { _bjje = value; }
        }

        //医院名称|科室| 流水号|住院号  4
        public string Yymc
        {
            set { _yymc = value; }
            get { return _yymc; }
        }
      
        public string Lsh
        {
            set { _lsh = value; }
            get { return _lsh; }
        }
     
        // 住院开始时间 |住院结束时间| 住院天数 | 姓名| 性别 5

        private string zykssj_N;

        public string Zykssj_N
        {
            get { return zykssj_N; }
            set { zykssj_N = value; }
        }

        private string zykssj_Y;

        public string Zykssj_Y
        {
            get { return zykssj_Y; }
            set { zykssj_Y = value; }
        }
        private string zykssj_R;
        public string Zykssj_R
        {
            get { return zykssj_R; }
            set { zykssj_R = value; }
        }


        public string Zykssj
        {
            set { _zykssj = value; }
            get { return _zykssj; }
        }

        private string zyjssj_N;

        public string Zyjssj_N
        {
            get { return zyjssj_N; }
            set { zyjssj_N = value; }
        }
        private string zyjssj_Y;

        public string Zyjssj_Y
        {
            get { return zyjssj_Y; }
            set { zyjssj_Y = value; }
        }
        private string zyjssj_R;

        public string Zyjssj_R
        {
            get { return zyjssj_R; }
            set { zyjssj_R = value; }
        }

        public string Zyjssj
        {
            set { _zyjssj = value; }
            get { return _zyjssj; }
        }
       
        
        public string Hzxb
        {
            set { _hzxb = value; }
            get { return _hzxb; }
        }
        //床位费 | 诊查费|检查费|化验费|治疗费|手术费 6
       
        public string Zcf
        {
            set { _zcf = value; }
            get { return _zcf; }
        }
        public string Jcf
        {
            set { _jcf = value; }
            get { return _jcf; }
        }
        public string Hyf
        {
            set { _hyf = value; }
            get { return _hyf; }
        }
        public string Zlf
        {
            set { _zlf = value; }
            get { return _zlf; }
        }
        public string Ssf
        {
            set { _ssf = value; }
            get { return _ssf; }
        }
        //护理费|卫生材料费|药品费|药事服务费|一般诊疗费|其他住院费用|输血费 7
        public string Hlf
        {
            set { _hlf = value; }
            get { return _hlf; }
        }
        public string Wsclf
        {
            set { _wsclf = value; }
            get { return _wsclf; }
        }
        public string Ypf
        {
            set { _ypf = value; }
            get { return _ypf; }
        }
        public string Ysfwf
        {
            set { _ysfwf = value; }
            get { return _ysfwf; }
        }
        public string Ybzlf
        {
            set { _ybzlf = value; }
            get { return _ybzlf; }
        }
        public string Qtzyfy
        {
            set { _qtzyfy = value; }
            get { return _qtzyfy; }
        }
        public string Sxf
        {
            set { _sxf = value; }
            get { return _sxf; }
        }
        //合计(大写) | (数字)|预交金额 | 退费金额|收款人 | 收款日期 6
        public string Hjdx
        {
            set { _hjdx = value; }
            get { return _hjdx; }
        }
        public string Hjsz
        {
            set { _hjsz = value; }
            get { return _hjsz; }
        }
        public string Yjje
        {
            set { _yjje = value; }
            get { return _yjje; }
        }
        public string Tfje
        {
            set { _tfje = value; }
            get { return _tfje; }
        }
        public string Skr
        {
            set { _skr = value; }
            get { return _skr; }
        }
        public string Skrq
        {
            set { _skrq = value; }
            get { return _skrq; }
        }

        private string Skrq_N;

        public string Skrq_N1
        {
            get { return Skrq_N; }
            set { Skrq_N = value; }
        }
        private string Skrq_Y;

        public string Skrq_Y1
        {
            get { return Skrq_Y; }
            set { Skrq_Y = value; }
        }
        private string Skrq_R;

        public string Skrq_R1
        {
            get { return Skrq_R; }
            set { Skrq_R = value; }
        }
    }
}
