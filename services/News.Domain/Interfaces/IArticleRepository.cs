using News.Domain.Entities.ArticleAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> GetArticleAsync(int id);

        Task<Article> Add(Article newsArticle);

        Task<Article> Update(Article newsArticle);

        void Delete(int id);

        Task<IEnumerable<Article>> GetRecentAsync();

        Task<Comment> AddComment(Comment comment);

        Task<Rating> AddRating(Rating rating);
    }
}