using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class DateModifier
    {
        // Transform string YY/MM/DD to datetime object
        public static DateTime DateFromString(string date)
        {
            return DateTime.ParseExact(date, "yyyy/MM/dd", null);
        }

        public static string DateFromDateTime(DateTime datetime)
        {
            return datetime.ToString("yyyy/MM/dd");
        }
    }
}
