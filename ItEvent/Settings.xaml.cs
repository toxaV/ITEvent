using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Services;
using Services.Implementation;

namespace ItEvent
{
    public partial class Settings
    {
        public Settings()
        {
            InitializeComponent();

            Caption.Text = "Мой город";

            List<string> cities = new List<string>
            {
                "Киев",
                "Днепропетровск",
                "Львов",
                "Одесса",
                "Харьков",
                "Донецк",
                "Запорожье",
                "Кривой Рог",
                "Симферополь"
            };

            citiesSelector.ItemsSource = cities;
        }

        private void citiesSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems[0] != null)
            {
                IRssService rssService = new RssService();

                rssService.SetCityName(e.AddedItems[0] as string);

                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}