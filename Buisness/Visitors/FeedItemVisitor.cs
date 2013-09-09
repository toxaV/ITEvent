using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Entities;

namespace Business.Visitors
{
    using Business.Helpers;

    public class FeedItemVisitor
    {
        private const string ImagePattern = "<img.+?src=[\"'](.+?)[\"'].+?>";
        private const string AHrefPattern = "<a href=\"http://dou.ua/calendar.*?>.*?</a>";

        private readonly FeedItem feedItem;

        public FeedItemVisitor(FeedItem feedItem)
        {
            if (feedItem == null)
            {
                throw new Exception("feedItem is null");
            }

            this.feedItem = feedItem;
        }

        public void Visit()
        {
            string[] splitedTitle = feedItem.Title.Split(',');
            int splittedTitleElementCount = splitedTitle.Count();

            if (splitedTitle.Length > 2)
            {
                FillDate(splitedTitle[splittedTitleElementCount - 2]);
                FillTitle(splitedTitle.Take(splittedTitleElementCount - 2));

                FillImage();
                CleanSummary();
            }
        }

        private void FillDate(string date)
        {
            feedItem.DateString = date;
            feedItem.Date = new DateHelper().Parse(date);
        }

        private void FillTitle(IEnumerable<string> titles)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string title in titles)
            {
                builder.AppendFormat("{0}, ", title);
            }

            feedItem.Title = builder.Remove(builder.Length - 2, 2).ToString();
        }

        private void FillImage()
        {
            feedItem.ImageUrl = Regex.Match(feedItem.Summary, ImagePattern, RegexOptions.IgnoreCase).Groups[1].Value;
        }

        private void CleanSummary()
        {
            feedItem.Summary = Regex.Replace(feedItem.Summary, ImagePattern, string.Empty);
            feedItem.Summary = Regex.Replace(feedItem.Summary, AHrefPattern, string.Empty);
        }
    }
}
