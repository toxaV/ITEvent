using System;
using System.Windows.Media.Imaging;
using Entities;

namespace ItEvent.Controls
{
    public partial class RssItemControl
    {
        private readonly FeedItem feedItem;

        public RssItemControl(FeedItem feedItem)
        {
            InitializeComponent();

            if (feedItem == null)
            {
                return;
            }

            this.feedItem = feedItem;

            Content.Text = feedItem.ToString();

            if (!string.IsNullOrEmpty(feedItem.ImageUrl))
            {
                Uri uri = new Uri(feedItem.ImageUrl, UriKind.Absolute);
                Logo.Source = new BitmapImage(uri);
            }
            else
            {
                Uri uri = new Uri("/Assets/Logo/logo.png", UriKind.Relative);
                Logo.Source = new BitmapImage(uri);
            }
        }

        public new event Action<RssItemControl, FeedItem> OnTap;

        private void LayoutRootTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnTap != null)
            {
                OnTap(this, feedItem);
            }
        }
    }
}