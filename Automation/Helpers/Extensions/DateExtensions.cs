namespace Automation.Helpers.Extensions
{
    using System;
    using System.Globalization;

    public static class DateExtensions
    {
        public static string CurrentDay
        {
            get
            {
                return DateTime.Now.Day.ToString("00");
            }
        }

        public static string CurrentMonth
        {
            get
            {
                return DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")).Substring(0, 3);
            }
        }

        public static string NextMonth
        {
            get
            {
                return DateTime.Now.AddMonths(1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))
                    .Substring(0, 3);
            }
        }

        public static string FormatDateForMyClientMySalesClusters(this DateTime date)
        {
            return date.ToString("MMM yyyy", CultureInfo.GetCultureInfo("en-us"));
        }

        public static string FormatDateForMySalesClusters(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy", CultureInfo.GetCultureInfo("en-us"));
        }

        public static string FormatDateForNnaClusters(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy", CultureInfo.GetCultureInfo("en-us"));
        }

        public static int GetWeekOfTheYear(this DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }

        public static DateTime GetFirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var weekNum = weekOfYear;

            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);

            return result.AddDays(-3);
        }
    }
}