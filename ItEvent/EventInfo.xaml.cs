namespace ItEvent
{
    public partial class EventInfo
    {
        public EventInfo()
        {
            InitializeComponent();

            if (MainPage.SelectedFeedItem != null)
            {
                Caption.Text = MainPage.SelectedFeedItem.Title;

                SummaryBrowser.Html = MainPage.SelectedFeedItem.Summary;
            }
        }
    }
}