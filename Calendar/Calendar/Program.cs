using System;
using System.Linq;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            bool wrongInput;
            Month calendarMonth=null;
            do
            {
                try
                {
                    wrongInput = false;
                    Console.WriteLine("Input a date in dd.mm.yyyy format.");
                    calendarMonth = DateParse(Console.ReadLine());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    wrongInput = true;
                }

            } while (wrongInput);
            var artist = new CalendarArtist(calendarMonth);
            artist.CreateImage();
        }

        static Month DateParse(string stringDate)
        {
            var e = stringDate.Split('.')
                .Select(int.Parse)
                .ToArray();
            if (e.Length!=3)
                throw new ArgumentException("Wrong date format.");
            int day = e[0];
            if(day<=0||day>31)
                throw new ArgumentException("Invalid day input");
            int month = e[1];
            if(month<=0||month>12)
                throw new ArgumentException("Invalid month input");
            int year = e[2];
            return new Month(day, month, year);
        }
    }
}
