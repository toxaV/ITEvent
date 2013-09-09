using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Helpers
{
    public class DateHelper
    {
        private readonly Dictionary<string, int> monthes = new Dictionary<string, int>();

        public DateHelper()
        {
            if (monthes != null)
            {
                monthes.Add("января", 1);
                monthes.Add("февраля", 2);
                monthes.Add("марта", 3);
                monthes.Add("апреля", 4);
                monthes.Add("мая", 5);
                monthes.Add("июня", 6);
                monthes.Add("июля", 7);
                monthes.Add("августа", 8);
                monthes.Add("сентября", 9);
                monthes.Add("октября", 10);
                monthes.Add("ноября", 11);
                monthes.Add("декабря", 12);
            }
        }

        public DateTime Parse(string date)
        {
            string[] dateParts = date.Trim().Split(' ');

            if (monthes.Keys.Contains(dateParts.Last().ToLower()))
            {
               int month = monthes[dateParts.Last().ToLower()];
               int day = Convert.ToInt32(dateParts.First());
               int year = DateTime.Now.Year;

               return new DateTime(year, month, day);
            }

            return DateTime.MaxValue;
        }
    }
}
