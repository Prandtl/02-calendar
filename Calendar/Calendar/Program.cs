using System;
using System.Linq;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input a date in mm.dd.yyyy format.");
            string input = Console.ReadLine();
            DateTime output;
            while (!DateTime.TryParse(input,out output))
            {
                Console.WriteLine("Wrong date format.");
                input = Console.ReadLine();
            }

            var artist = new CalendarArtist(new Month(output));
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
