using Buisness;
using Entities;

namespace Services.Implementation
{
    public class CalWindowsPhoneTaskendarService : IWindowsPhoneTaskService
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