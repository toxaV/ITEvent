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

        public void ShareLink(FeedItem feedItem)
        {
            new WindowsPhoneTask().ShareLink(feedItem);
        }
    }
}