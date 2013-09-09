using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using Entities;

namespace Business
{
    using Business.Visitors;

    public class RssProcessor
    {
        public RssProcessor(string rssUrl)
        {
            RssUrl = rssUrl;
        }

        public event Action<List<FeedItem>> BindFinished;

        private string RssUrl { get; set; } 

        public void Bind()
        {
            WebClient webClient = new WebClient();

            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClient.DownloadStringCompleted += WebClientDownloadStringCompleted;

            webClient.DownloadStringAsync(new Uri(RssUrl));
        }

        // This method sets up the feed and binds it to our ListBox. 
        public void UpdateFeedList(string feedXml)
        {
            // Load the feed into a SyndicationFeed instance
            StringReader stringReader = new StringReader(feedXml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed syncFeed = SyndicationFeed.Load(xmlReader);

            List<FeedItem> feedItems = new List<FeedItem>();

            foreach (SyndicationItem item in syncFeed.Items)
            {
                string title = item.Title != null ? item.Title.Text : "{no title}";

                FeedItem feedItem = new FeedItem
                {
                    Id = item.Id,
                    Title = title,
                    Summary = item.Summary != null ? item.Summary.Text : null,
                    Content = item.Content != null ? item.Content.ToString() : null
                };

                FeedItemVisitor visitor = new FeedItemVisitor(feedItem);
                visitor.Visit();

                feedItems.Add(feedItem);
            }

            BindFinished(feedItems);
        }

        // Event handler which runs after the feed is fully downloaded.
        private void WebClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                BindFinished(null);
            }
            else
            {
                UpdateFeedList(e.Result);
            }
        }
    }
}
