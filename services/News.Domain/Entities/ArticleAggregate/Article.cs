using System;
using System.Collections.Generic;
using System.Text;

namespace News.Domain.Entities.ArticleAggregate
{
    public class Article
    {
        public int Id { get; set; }

        public Content Content { get; set; }

        public Author Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
