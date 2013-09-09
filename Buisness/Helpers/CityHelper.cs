using System.Collections.Generic;

namespace Business.Helpers
{
    public class CityHelper
    {
        private readonly List<string> cities = new List<string>
            {
                "Киев",
                "Днепропетровск",
                "Львов",
                "Одесса",
                "Харьков",
                "Донецк",
                "Запорожье",
                "Кривой Рог",
                "Симферополь"
            };

        public List<string> GetSupportedCities()
        {
            return cities;
        }

        public string GetDefaultCity()
        {
            return cities[0];
        }
    }
}