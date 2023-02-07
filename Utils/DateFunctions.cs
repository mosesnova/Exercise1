using System;

namespace Utils
{
    public static class DateFunctions
    {
        public static DateTime AddBusinessDays(DateTime startDate, int businessDays)
        {
            DateTime finishDate = startDate.AddDays(7); // todo calculate the date using business days
            return finishDate;
        }
    }
}
