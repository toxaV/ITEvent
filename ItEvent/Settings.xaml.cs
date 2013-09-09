using System;
using System.Windows.Controls;
using Services;
using Services.Implementation;

namespace ItEvent
{
    using ItEvent.Resources;

    public partial class Settings
    {
        public Settings()
        {
            InitializeComponent();
           
            Caption.Text = AppResources.msgMyCity;

            citiesSelector.ItemsSource = new CityService().GetSupportedCities();
        }

        private void CitiesSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
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