using System;

namespace News.API.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public string ImageUri { get; set; }

        public DateTime PublicationDate { get; set; }

        public int RatingAverage { get; set; }

        public string AuthorName { get; set; }
    }
}
