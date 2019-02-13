using System;
using System.Collections.Generic;
using System.Text;

namespace News.Domain.Entities.ArticleAggregate
{
    public class Rating
    {
        public int Id { get; set; }

        public int Rate { get; set; }

        public Author Author { get; set; }

        public Article Article { get; set; }
    }
}
