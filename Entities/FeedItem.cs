using System;

namespace Entities
{
    public class FeedItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public string DateString { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Title, DateString);
        }
    }
}