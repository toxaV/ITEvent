using System.Collections.Generic;

namespace Services
{
    public interface ICityService
    {
        List<string> GetSupportedCities();

        string GetDefaultCity();
    }
}
