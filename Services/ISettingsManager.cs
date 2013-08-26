namespace Services
{
    public interface ISettingsManager
    {
        string GetCityName();
        void SetCityName(string cityName);
    }
}
