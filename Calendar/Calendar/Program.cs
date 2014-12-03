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
    }
}
