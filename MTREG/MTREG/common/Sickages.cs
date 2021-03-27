using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTHIS.common
{
    public class Sickages
    {
        
        int years = 0;
        public Sickages()
        { }
        public Sickages(string ageunit, int agevalues)
        {
            this.ageunit = ageunit;
            this.cur_values = agevalues;
        }

        public int Years
        {
            get { return years; }
            set { years = value; }
        }
        int months =0;

        public int Months
        {
            get { return months; }
            set { months = value; }
        }
        int days =0;

        public int Days
        {
            get { return days; }
            set { days = value; }
        }
        int cur_values;

        public int Cur_values
        {
            get { return cur_values; }
            set { cur_values = value; }
        }
        string ageunit ="岁";

        public string Ageunit
        {
            get { return ageunit; }
            set { ageunit = value; }
        }
        private double curr_doublvalue;

        public double Curr_doublvalue
        {
            get
            {

                double curyearValue = (double)cur_values;
                if (ageunit == "岁")
                    curyearValue = (double)cur_values;
                else if (ageunit == "月")
                {


                    curyearValue = (double)cur_values / 12;

                }
                else if (ageunit == "天")
                {
                    curyearValue = (double)cur_values / 365;


                }
                else if (ageunit == "时")
                {
                    curyearValue = (double)cur_values / 8760;

                }
                curyearValue = Math.Round(curyearValue, 2);
                return curyearValue;

            }

        }
    }
}
