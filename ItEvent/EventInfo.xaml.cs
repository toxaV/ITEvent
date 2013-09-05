using System;
using Microsoft.Phone.Shell;
using Services;
using Services.Implementation;

namespace ItEvent
{
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
            IWindowsPhoneTaskService calendarService = new CalWindowsPhoneTaskendarService();
            calendarService.ShareLink(MainPage.SelectedFeedItem);
        }

        private void SaveToCalendarIconButtonOnClick(object sender, EventArgs eventArgs)
        {
            IWindowsPhoneTaskService calendarService = new CalWindowsPhoneTaskendarService();
            calendarService.SaveToCalendar(MainPage.SelectedFeedItem);
        }
    }
}