using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Calendar
{
    internal class CalendarArtist
    {

        public CalendarArtist(Month month)
        {
            this.month = month;
        }

        public void CreateImage()
        {
            height = 90 + 35*month.AmountOfWeeks;
            width = 500;

            calendarPage = new Bitmap(width, height);

            var g = Graphics.FromImage(calendarPage);

            g.DrawString(monthNames[month.InputDay.Month], monthName, new SolidBrush(Color.Black), 5, 5);
            g.DrawString(month.InputDay.Year.ToString(), yearFont, new SolidBrush(Color.Black), width - 80, 60);

            int start = width - 70*7;
            foreach (var name in daysHeadNames)
            {
                g.DrawString(name,daysHead,new SolidBrush(Color.Black),start,85 );
                start += 65;
            }



            calendarPage.Save("page.bmp");
        }

        private Bitmap calendarPage;

        private Month month;

        private int width = 500;
        private int height = 90 + 35*6;

        private Font monthName = new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold);
        private Font yearFont = new Font(FontFamily.GenericSansSerif, 20);
        private Font daysHead = new Font(FontFamily.GenericMonospace, 30);

        private Dictionary<int, string> monthNames = new Dictionary<int, string>()
        {
            {1,"January"},
            {2,"February"},
            {3,"March"},
            {4,"April"},
            {5,"May"},
            {6,"June"},
            {7,"July"},
            {8,"August"},
            {9,"September"},
            {10,"October"},
            {11,"November"},
            {12,"December"}
        };

        private List<string> daysHeadNames = new List<string>() {"Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"};
    }
}
