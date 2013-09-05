using System;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Services.Implementation;

namespace ItEvent
{
    public partial class EventInfo
    {
        public EventInfo()
        {
            InitializeComponent();

            Init();

            if (MainPage.SelectedFeedItem != null)
            {
                Caption.Text = MainPage.SelectedFeedItem.Title;

                SummaryBrowser.Html = MainPage.SelectedFeedItem.Summary;
            }
        }

        private void Init()
        {
            ApplicationBar = new ApplicationBar
            {
                Opacity = 1.0,
                Mode = ApplicationBarMode.Default,
                IsVisible = true,
                IsMenuEnabled = true
            };

            var saveToCalendarIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/feature.calendar.png", UriKind.Relative),
                Text = "Я пойду"
            };

            var shareIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/share.png", UriKind.Relative),
                Text = "Рассказать"
            };

            saveToCalendarIconButton.Click += SaveToCalendarIconButtonOnClick;
            shareIconButton.Click += shareIconButton_Click;

            ApplicationBar.Buttons.Add(saveToCalendarIconButton);
            ApplicationBar.Buttons.Add(shareIconButton);
        }

        private void shareIconButton_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = MainPage.SelectedFeedItem.Title;
            shareLinkTask.LinkUri = new Uri(MainPage.SelectedFeedItem.Id, UriKind.Absolute);
            shareLinkTask.Message = "Круто! Я пойду";

            shareLinkTask.Show();
        }

        private void SaveToCalendarIconButtonOnClick(object sender, EventArgs eventArgs)
        {
            CalendarService calendarService = new CalendarService();
            calendarService.SaveToCalendar(MainPage.SelectedFeedItem);
        }
    }
}