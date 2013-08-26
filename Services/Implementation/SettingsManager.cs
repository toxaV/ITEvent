using System.IO.IsolatedStorage;

namespace Services.Implementation
{
    public class SettingsManager : ISettingsManager
    {
        private string CityPropertyName = "city";
        public void SetCityName(string cityName)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains(CityPropertyName))
            {
                settings.Add(CityPropertyName, cityName);
            }
            else
            {
                settings[CityPropertyName] = cityName;
            }

            settings.Save();
        }

        public string GetCityName()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains(CityPropertyName))
            {
                return "Киев";
            }

            return settings[CityPropertyName].ToString();
        }
    }
}
