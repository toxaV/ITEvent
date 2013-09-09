using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Entities;
using ItEvent.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Services;
using Services.Implementation;

namespace ItEvent
{
    using ItEvent.Resources;

    public partial class MainPage
    {
        private const string RssUrl = @"http://dou.ua/calendar/feed/все%20темы/{0}";

        private readonly IRssService rssService = new RssService();

        private ProgressIndicator progress; 

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            InitApplicationBar();

            SetProgressIndicator();

            rssService.GetFeedItemsAsync(string.Format(RssUrl, rssService.GetCityName()), BindFeeds);

            Caption.Text = rssService.GetCityName();
        }

        public static FeedItem SelectedFeedItem { get; private set; }

        private void SetProgressIndicator()
        {
            progress = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = string.Format(AppResources.msgLoading, rssService.GetCityName()),
            };

            SystemTray.SetProgressIndicator(this, progress);
        }

        private void BindFeeds(List<FeedItem> feeds)
        {
            try
            {
                if (feeds == null)
                {
                    InternetConnectionError();
                    return;
                }

                IEnumerable<FeedItem> orderedItems = feeds.OrderBy(item => item.Date).Where(t => t.Date >= DateTime.Now);

                IEnumerable<FeedItem> feedItems = orderedItems as IList<FeedItem> ?? orderedItems.ToList();

                foreach (RssItemControl rssItemControl in feedItems.Select(feedItem => new RssItemControl(feedItem)))
                {
                    rssItemControl.OnTap += this.RssItemControlOnTap;
                    this.SPContent.Children.Add(rssItemControl);
                }
 
                UpdateTile(feedItems.First());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }

        private void InternetConnectionError()
        {
            MessageBox.Show(AppResources.msgConnectionError);
        }

        private void UpdateTile(FeedItem feedItem)
        {
            var primaryTileData = new FlipTileData
            {
                BackContent = feedItem.ToString(), 
                Title = AppResources.ApplicationTitle
            };

            ShellTile primaryTile = ShellTile.ActiveTiles.First();
            primaryTile.Update(primaryTileData);
        }

        private void RssItemControlOnTap(RssItemControl sender, FeedItem obj)
        {
            SelectedFeedItem = obj;

            NavigationService.Navigate(new Uri("/EventInfo.xaml", UriKind.Relative));
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

            var settingsBarIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/feature.settings.png", UriKind.Relative),
                Text = AppResources.msgMyCity
            };

            var marketPlaceReviewIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/like.png", UriKind.Relative),
                Text = AppResources.msgRate
            };

            settingsBarIconButton.Click += this.SettingsBarIconButtonClick;
            marketPlaceReviewIconButton.Click += this.MarketPlaceReviewIconButtonClick;

            ApplicationBar.Buttons.Add(settingsBarIconButton);
            ApplicationBar.Buttons.Add(marketPlaceReviewIconButton);
        }

        private void MarketPlaceReviewIconButtonClick(object sender, EventArgs e)
        {
            new MarketplaceReviewTask().Show();
        }

        private void SettingsBarIconButtonClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}