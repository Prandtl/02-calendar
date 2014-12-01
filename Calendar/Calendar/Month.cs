using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Month
    {
        public int AmountOfWeeks { get; private set; }
        public int AmountOfDays { get; private set; }
        public DayOfWeek FirstDay { get; private set; }
        public DateTime InputDay { get; private set; }

        public Month(int day,int month,int year)
        {
            InputDay=new DateTime(year,month,day,new GregorianCalendar());
            System.Globalization.Calendar cal = new GregorianCalendar();
            FirstDay = cal.GetDayOfWeek(new DateTime(year, month, 1));
            AmountOfDays = cal.GetDaysInMonth(year, month);
            int firstDay = (int) FirstDay - 1;
            int daysWithoutFirstWeek = AmountOfDays - (7 - firstDay);
            int daysOnLastWeek = daysWithoutFirstWeek%7;
            AmountOfWeeks = daysOnLastWeek == 0 ? 
                daysWithoutFirstWeek/7 + 1 :
                daysWithoutFirstWeek/7 + 2;
        }
    }
}
