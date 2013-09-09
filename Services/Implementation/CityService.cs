using System.Collections.Generic;

namespace Services.Implementation
{
    using Business.Helpers;

    public class CityService : ICityService
    {
        public List<string> GetSupportedCities()
        {
            return new CityHelper().GetSupportedCities();
        }

        public string GetDefaultCity()
        {
            return new CityHelper().GetDefaultCity();
        }
    }
}
