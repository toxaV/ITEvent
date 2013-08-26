﻿using System.Windows;
using Entities;
using ItEvent.Controls;
using Microsoft.Phone.Shell;
using Services;
using System;
using System.Linq;
using System.Collections.Generic;
using Services.Implementation;

namespace ItEvent
{
    public partial class MainPage
    {
        public static FeedItem SelectedFeedItem;

        private readonly ProgressIndicator progress;
        private readonly IRssService rssService = new RssService();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Init();

            string cityName = rssService.GetCityName();

            progress = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = string.Format("Загружаем {0}...", cityName),
            };

            SystemTray.SetProgressIndicator(this, progress);


            string url = string.Format(@"http://dou.ua/calendar/feed/все%20темы/{0}", cityName);

            rssService.GetFeedItemsAsync(url, BindFeeds);

            Caption.Text = cityName;
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

                foreach (FeedItem feedItem in orderedItems)
                {
                    var rssItemControl = new RssItemControl(feedItem);
                    rssItemControl.OnTap += rssItemControl_OnTap;
                    SPContent.Children.Add(rssItemControl);
                }
 
                UpdateTile(orderedItems.First());
            }
            finally
            {
                progress.IsVisible = false;
            }
        }

        private void InternetConnectionError()
        {
            MessageBox.Show("При получении данных возникли проблемы. Проверьте настройки интернет соединения и попробуйте еще раз.");
        }

        private void UpdateTile(FeedItem feedItem)
        {
            var primaryTileData = new FlipTileData
            {
                BackContent = feedItem.ToString(), 
                Title = "IT event"
            };

            ShellTile primaryTile = ShellTile.ActiveTiles.First();
            primaryTile.Update(primaryTileData);
        }

        private void rssItemControl_OnTap(RssItemControl sender, FeedItem obj)
        {
            SelectedFeedItem = obj;

            NavigationService.Navigate(new Uri("/EventInfo.xaml", UriKind.Relative));
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

            var settingsBarIconButton = new ApplicationBarIconButton
            {
                IconUri = new Uri("/Assets/Icons/Dark/feature.settings.png", UriKind.Relative),
                Text = "Мой город"
            };

            settingsBarIconButton.Click += settingsBarIconButton_Click;
            ApplicationBar.Buttons.Add(settingsBarIconButton);
        }

        private void settingsBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}