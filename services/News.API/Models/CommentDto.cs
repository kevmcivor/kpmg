namespace News.API.Models
{
    public class CommentDto
    {
        public string Content { get; set; }

        public int ArticleId{ get; set; }

        public string AuthorName { get; set; }
    }
}
