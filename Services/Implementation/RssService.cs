using System;
using System.Collections.Generic;
using Business;
using Entities;

namespace Services.Implementation
{
    public class RssService : IRssService
    {
        public void GetFeedItemsAsync(string rssUrl, Action<List<FeedItem>> callBack)
        {
            RssProcessor rssProcessor = new RssProcessor(rssUrl);
            rssProcessor.Bind();

            rssProcessor.BindFinished += callBack;
        }

        public string GetCityName()
        {
            SettingsManager settingsManager = new SettingsManager();
            return settingsManager.GetCityName();
        }

        public void SetCityName(string cityName)
        {
            SettingsManager settingsManager = new SettingsManager();
            settingsManager.SetCityName(cityName);
        }
    }
}