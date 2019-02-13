using System;
using System.Collections.Generic;
using System.Text;

namespace News.Domain.Entities.ArticleAggregate
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content {get; set;}

        public Author Author { get; set; } 

        public Article Article { get; set; }
    }
}
