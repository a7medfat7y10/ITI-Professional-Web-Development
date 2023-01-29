using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emp_struct
{
    struct HiringDate
    {
        int day;
        string month;
        int year;

        public HiringDate(int _d, string _m, int _y)
        {
            day = _d;
            month = _m;
            year = _y;
        }
        
        public void setDay(int _d)
        {
            day = _d;
        }
        public void setMonth(string _m)
        {
            month= _m;
        }
        public void setYaer(int _y)
        {
            year= _y;
        }

        public int getDay()
        {
            return day;
        }
        public string getMonth()
        {
            return month;
        }
        public int getYear()
        {
            return year;
        }

        public override string ToString()
        {
            string d = $"{day}/{month}/{year}";
            return d;
        }
    }
}
