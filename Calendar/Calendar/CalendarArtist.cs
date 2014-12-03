using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Calendar
{
    internal class CalendarArtist
    {

        public CalendarArtist(Month month)
        {
            SetMonth(month);
        }

        public void SetMonth(Month month)
        {
            this.month = month;
        }

        public void CreateImage()
        {
            height = 120 + 35*month.AmountOfWeeks;
            width = 500;

            calendarPage = new Bitmap(width, height);

            var g = Graphics.FromImage(calendarPage);

            DrawCalendarHead(g);
            DrawDayNames(g, width - 7*70, 80);
            DrawDates(g,10,120);

            calendarPage.Save("page.bmp");
        }

        private void DrawCalendarHead(Graphics g)
        {
            g.DrawString(monthNames[month.InputDay.Month], monthNameFont, simpleBlackBrush, 5, 5);
            g.DrawString(month.InputDay.Year.ToString(), yearFont, simpleBlackBrush, width - 80, 60);
        }

        private void DrawDayNames(Graphics g,int xStart,int yStart)
        {
            int start = xStart;
            foreach (var name in daysHeadNames)
            {
                g.DrawString(name, daysHeadFont, simpleBlackBrush, start, yStart);
                start += 65;
            }
        }

        private void DrawDates(Graphics g,int xStart,int yStart)
        {
            int toSkipOnFirstWeek = (int) month.FirstDay == 0
                ? 6
                : (int) month.FirstDay - 1;
            var dates = Enumerable.Repeat(0, toSkipOnFirstWeek)
                .Concat(Enumerable.Range(1, month.AmountOfDays)).ToArray();
            if (month.DaysOnLastWeek > 0)
                dates=dates.Concat(Enumerable.Repeat(0, 7 - month.DaysOnLastWeek)).ToArray();
            var weeks = dates.Select((x, i) => Tuple.Create(x, i/7))
                .GroupBy(x => x.Item2)
                .Select(x=>x.Select(z=>z.Item1)
                    .ToArray())
                .ToArray();
            for (int i = 0; i < weeks.Length; i++)
            {
                for (int j = 0; j < weeks[i].Length; j++)
                {
                    if (weeks[i][j] == 0)
                        continue;
                    g.DrawString(weeks[i][j].ToString(), daysFont, simpleBlackBrush, xStart + j*65, yStart + i*35);
                    if (month.InputDay.Day == weeks[i][j])
                        g.DrawRectangle(new Pen(Color.DarkRed, 3), xStart + j*65, yStart + i*35, 69, 37);
                }
            }

        }

        private Bitmap calendarPage;

        private Month month;

        private int width = 500;
        private int height = 90 + 35*6;

        private readonly Font monthNameFont = new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold);
        private readonly Font yearFont = new Font(FontFamily.GenericSansSerif, 20);
        private readonly Font daysHeadFont = new Font(FontFamily.GenericMonospace, 30);
        private readonly Font daysFont = new Font(FontFamily.GenericMonospace, 30);

        private readonly Brush simpleBlackBrush=new SolidBrush(Color.Black);

        private readonly Dictionary<int, string> monthNames = new Dictionary<int, string>
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

        private readonly List<string> daysHeadNames = new List<string> {"Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"};
    }
}
