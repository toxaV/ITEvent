using System;
using Microsoft.Phone.Shell;
using Services;
using Services.Implementation;

namespace ItEvent
{
    using ItEvent.Resources;

    public partial class EventInfo
    {
        public EventInfo()
        {
            InitializeComponent();

            InitApplicationBar();

            if (MainPage.SelectedFeedItem != null)
            {
                Caption.Text = MainPage.SelectedFeedItem.Title;

                SummaryBrowser.Html = MainPage.SelectedFeedItem.Summary;
            }
        }

        private void InitApplicationBar()
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
                Text = AppResources.msgSaveToCallendar
            };

            var shareIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/share.png", UriKind.Relative),
                Text = AppResources.msgShare
            };

            saveToCalendarIconButton.Click += SaveToCalendarIconButtonOnClick;
            shareIconButton.Click += this.ShareIconButtonClick;

            ApplicationBar.Buttons.Add(saveToCalendarIconButton);
            ApplicationBar.Buttons.Add(shareIconButton);
        }

        private void ShareIconButtonClick(object sender, EventArgs e)
        {
            IWindowsPhoneTaskService calendarService = new WindowsPhoneTaskService();
            calendarService.ShareLink(MainPage.SelectedFeedItem, AppResources.msgShareWithFriends);
        }

        private void SaveToCalendarIconButtonOnClick(object sender, EventArgs eventArgs)
        {
            IWindowsPhoneTaskService calendarService = new WindowsPhoneTaskService();
            calendarService.SaveToCalendar(MainPage.SelectedFeedItem);
        }
    }
}