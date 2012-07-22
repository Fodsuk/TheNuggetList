using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheNuggetList.Domain.Util
{
    public static class DateTimeExtensionMethods
    {
        public static string GetElapsedTime(this DateTime datetime)
        {
            return GetElapsedTime(datetime, DateTime.Now);
        }
        
        public static string GetElapsedTime(this DateTime datetime, DateTime compare)
        {
            string elapsedTime = string.Empty;

            DateTime compareDate = compare;

            TimeSpan span = compareDate.Subtract(datetime);

            int daysElapsed = span.Days;

            if (daysElapsed > 0)
            {
                if (daysElapsed == 1)
                    return "1 day";
                else
                    return string.Format("{0} days", daysElapsed);
            }

            int hoursElapsed = span.Hours;

            if (hoursElapsed > 0)
            {
                if (hoursElapsed == 1)
                    return "1 hour";
                else
                    return string.Format("{0} hours", hoursElapsed);            
            }
            
            int minutesElapsed = span.Minutes;

            if (minutesElapsed > 0)
            {
                if (minutesElapsed < 2)
                    return "1 minute";
                else
                    return string.Format("{0} minutes", minutesElapsed);
            }

            throw new ArgumentException(string.Format("time elapsed cannot be calculated for the date provided. ({0})",datetime.ToLongDateString()));
        }
    }
}
