using System;
using Entities;
using System.Windows.Media.Imaging;

namespace ItEvent.Controls
{
    public partial class RssItemControl
    {
        public event Action<RssItemControl, FeedItem> OnTap;

        private readonly FeedItem feedItem;

        public RssItemControl(FeedItem feedItem)
        {
            InitializeComponent();

            if (feedItem == null)
                return;

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

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (OnTap != null)
            {
                OnTap(this, feedItem);
            }
        }
    }
}