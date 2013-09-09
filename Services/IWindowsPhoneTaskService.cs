using Entities;

namespace Services
{
    public interface IWindowsPhoneTaskService
    {
        void SaveToCalendar(FeedItem feedItem);

        void ShareLink(FeedItem feedItem, string message);
    }
}