using System;
using Entities;
using Microsoft.Phone.Tasks;

namespace Buisness
{
    public class CalendarWorker
    {
        public void Save(FeedItem feedItem)
        {
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();

            saveAppointmentTask.Subject = feedItem.Title;
            saveAppointmentTask.IsAllDayEvent = false;
            saveAppointmentTask.Reminder = Reminder.OneHour;
            saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;

            saveAppointmentTask.Show();
        }
    }
}
