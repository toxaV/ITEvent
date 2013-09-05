using System;
using Entities;
using Microsoft.Phone.Tasks;

namespace Buisness
{
    public class WindowsPhoneTask
    {
        public void SaveAppointment(FeedItem feedItem)
        {
            if (feedItem == null)
            {
                throw new Exception("feed item is null");
            }

            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask
            {
                StartTime = feedItem.Date,
                EndTime = feedItem.Date,
                Subject = feedItem.Title,
                IsAllDayEvent = false,
                Reminder = Reminder.OneHour,
                AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy
            };

            saveAppointmentTask.Show();
        }

        public void ShareLink(FeedItem feedItem)
        {
            if (feedItem == null)
            {
                throw new Exception("feed item is null");
            }

            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = feedItem.Title;
            shareLinkTask.LinkUri = new Uri(feedItem.Id, UriKind.Absolute);
            shareLinkTask.Message = "Круто! Я пойду";

            shareLinkTask.Show();
        }
    }
}
