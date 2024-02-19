using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsPOO
{
    public class Date
    {
        private int _year;
        private int _month; 
        private int _day;

        public Date(int year, int month, int day)
        {
             _year = year;
            _month = CheckMonth(month);
            _day = CheckDay(year, month, day);
        }

        private int CheckDay(int year, int month, int day)
        {
            //El año tiene 365.25... dias, por eso ser agrega un día adional cada 4 años a los años bisiestos 
            if(month == 2 && day == 29 && IsLeapYear(year))
            {
                return day;
            }

            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if(day >= 1 && day < daysPerMonth[month]) 
            { 
                return day;
            
            }

            throw new DayException("Invalid Day");
        }

        private bool IsLeapYear(int year)
        {
            //Esta es la manera de programar bien

            return year % 400 == 0 || year % 4 == 0 && year % 100 != 0;


            //Esta es la manera de programarde un SENIOR
            //if(year % 4 == 0)
            //{
            //    if (year % 100 == 0)
            //    {
            //        if(year %400 == 0)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }




        private int CheckMonth(int month)
        {
            if(month >= 1 && month <=12)
            {
                return month;
            }

            throw new MonthException($"Invalid month");
        }

        public override string ToString()
        {
            return $"{_year}/{_month:00}/{_day:00}";
        }
    }
}

