using System;
using Buisness;
using Entities;

namespace Services.Implementation
{
    public class CalendarService : ICalendarService
    {
        public void SaveToCalendar(FeedItem feedItem)
        {
            if (feedItem == null)
            {
                throw new Exception("feedItem is null");
            }

            new CalendarWorker().Save(feedItem);
        }
    }
}