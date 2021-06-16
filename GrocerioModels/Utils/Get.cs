using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Utils
{
    public class Get
    {
        public static DateTime CurrentDate()
        {
            try
            {
                return System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Europe/Sarajevo"));
            }
            catch
            {
                return System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
            }
        }

    }
}
