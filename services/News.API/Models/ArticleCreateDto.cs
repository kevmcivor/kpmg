using System;

namespace News.API.Models
{
    public class ArticleCreateDto
    {
        public string Title { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public DateTime PublicationDate { get; set; }

        public string ImageUri { get; set; }
    }
}
