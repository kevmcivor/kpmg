namespace News.API.Models
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public string ImageUri { get; set; }
    }
}