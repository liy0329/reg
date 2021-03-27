using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Sycyjs_out
    {
        //医疗费总额|生育医疗费定额补贴限额 |个人自费|生育医疗费定额补贴金额|XX
        private string _ylfze;
        private string _syylfdebtxe;
        private string _grzf;
        private string _syylfdebtje;
        private string _message;

        /// <summary>
        /// 医疗费总额
        /// </summary>
        public string Ylfze
        {
            set { _ylfze = value; }
            get { return _ylfze; }
        }
        /// <summary>
        /// 生育医疗费定额补贴限额
        /// </summary>
        public string Syylfdebtxe
        {
            set { _syylfdebtxe = value; }
            get { return _syylfdebtxe; }
        }
        /// <summary>
        /// 个人自费
        /// </summary>
        public string Grzf
        {
            set { _grzf = value; }
            get { return _grzf; }
        }
        /// <summary>
        /// 生育医疗费定额补贴金额
        /// </summary>
        public string Syylfdebtje
        {
            set { _syylfdebtje = value; }
            get { return _syylfdebtje; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
