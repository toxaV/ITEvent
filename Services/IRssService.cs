using Entities;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IRssService: ISettingsManager
    {
        void GetFeedItemsAsync(string rssUrl, Action<List<FeedItem>> callBack);
    }
}
