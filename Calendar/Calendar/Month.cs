﻿using System;
using System.Globalization;

namespace Calendar
{
    class Month
    {
        public int FirstWeekNumber { get; private set; }
        public int AmountOfWeeks { get; private set; }
        public int AmountOfDays { get; private set; }
        public int DaysOnLastWeek { get; private set; }
        public DayOfWeek FirstDay { get; private set; }
        public DateTime InputDay { get; private set; }

        public Month(int day, int month, int year)
        {
            InputDay = new DateTime(year, month, day, new GregorianCalendar());
            System.Globalization.Calendar cal = new GregorianCalendar();
            var first = new DateTime(year, month, 1);
            FirstDay = cal.GetDayOfWeek(first);
            AmountOfDays = cal.GetDaysInMonth(year, month);
            int firstDay = (int) FirstDay - 1;
            int daysWithoutFirstWeek = AmountOfDays - (7 - firstDay);
            DaysOnLastWeek = daysWithoutFirstWeek % 7;
            AmountOfWeeks = DaysOnLastWeek == 0
                ? daysWithoutFirstWeek/7 + 1
                : daysWithoutFirstWeek/7 + 2;
            FirstWeekNumber = cal.GetWeekOfYear(first,
                DateTimeFormatInfo.CurrentInfo.CalendarWeekRule,
                DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }


    }
}
