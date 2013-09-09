using Business;
using Entities;

namespace Services.Implementation
{
    public class WindowsPhoneTaskService : IWindowsPhoneTaskService
    {
        public void SaveToCalendar(FeedItem feedItem)
        {
            new WindowsPhoneTask().SaveAppointment(feedItem);
        }

        public void ShareLink(FeedItem feedItem, string message)
        {
            new WindowsPhoneTask().ShareLink(feedItem, message);
        }
    }
}