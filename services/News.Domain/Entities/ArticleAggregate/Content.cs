
namespace News.Domain.Entities.ArticleAggregate
{
    public class Content
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public string ImageUri { get; set; } 
    }
}
