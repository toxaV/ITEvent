using Entities;

namespace Services
{
    public interface ICalendarService
    {
        void SaveToCalendar(FeedItem feedItem);
    }
}