﻿namespace web_app.Helper
{
    public static class Time
    {
        public static string ToRelativeDate(DateTimeOffset dateTimeOffset)
        {
            return Process(dateTimeOffset.LocalDateTime);
        }
        public static string Process(DateTime input)
        {
            TimeSpan oSpan = DateTime.Now.Subtract(input);
            double TotalMinutes = oSpan.TotalMinutes;
            string Suffix = " ago";

            if (TotalMinutes < 0.0)
            {
                TotalMinutes = Math.Abs(TotalMinutes);
                Suffix = " from now";
            }

            var aValue = new SortedList<double, Func<string>>();
            aValue.Add(0.75, () => "less than a minute");
            aValue.Add(1.5, () => "about a minute");
            aValue.Add(45, () => string.Format("{0} minutes", Math.Round(TotalMinutes)));
            aValue.Add(90, () => "about an hour");
            aValue.Add(1440, () => string.Format("about {0} hours", Math.Round(Math.Abs(oSpan.TotalHours)))); // 60 * 24
            aValue.Add(2880, () => "a day"); // 60 * 48
            aValue.Add(43200, () => string.Format("{0} days", Math.Floor(Math.Abs(oSpan.TotalDays)))); // 60 * 24 * 30
            aValue.Add(86400, () => "about a month"); // 60 * 24 * 60
            aValue.Add(525600, () => string.Format("{0} months", Math.Floor(Math.Abs(oSpan.TotalDays / 30)))); // 60 * 24 * 365 
            aValue.Add(1051200, () => "about a year"); // 60 * 24 * 365 * 2
            aValue.Add(double.MaxValue, () => string.Format("{0} years", Math.Floor(Math.Abs(oSpan.TotalDays / 365))));

            return aValue.First(n => TotalMinutes < n.Key).Value.Invoke() + Suffix;
        }
    }
}
