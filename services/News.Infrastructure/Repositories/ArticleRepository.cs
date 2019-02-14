using Microsoft.EntityFrameworkCore;
using News.Domain.Entities.ArticleAggregate;
using News.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly NewsContext _context;

        public ArticleRepository(NewsContext context)
        {
            _context =  context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Article> Add(Article newsArticle)
        {
            if (await _context.Authors.FindAsync(newsArticle.Author.Id) == null)
            {
                _context.Add(newsArticle.Author);
            }
            
            _context.Add(newsArticle);

            await _context.SaveChangesAsync();

            return await GetArticleAsync(newsArticle.Id);
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Content)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Article>> GetRecentAsync()
        {
            return await _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Content)
                .OrderByDescending(a => a.PublicationDate)
                .Take(10).ToListAsync();
        }

        public async Task<Article> Update(Article articleUpdate)
        {
            var article = await _context.Articles
                .Include(a => a.Content)
                .FirstAsync(a => a.Id == articleUpdate.Id);

            article.PublicationDate = articleUpdate.PublicationDate;
            article.Content.Title = articleUpdate.Content.Title;
            article.Content.Headline = articleUpdate.Content.Headline;
            article.Content.Body = articleUpdate.Content.Body;
            article.Content.ImageUri = articleUpdate.Content.ImageUri;

            await _context.SaveChangesAsync();

            return await GetArticleAsync(article.Id);
        }

        public async Task<int> Delete(int id)
        {
            //use TransactionScope
            var article = await _context.Articles
                .Include(a => a.Content)
                .FirstOrDefaultAsync(a => a.Id == id);
            var comments = await _context.Comments
                .Where(c => c.Article.Id == id).ToListAsync();
            var ratings = await _context.Ratings
                .Where(r => r.Article.Id == id).ToListAsync();

            if (article != null)
            {
                comments.ForEach(c => _context.Remove(c));
                ratings.ForEach(r => _context.Remove(r));
                _context.Remove(article);
                _context.Remove(article.Content);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            _context.Attach(comment.Author);
            _context.Attach(comment.Article);
            _context.Add(comment);

            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int articleId)
        {
            return await _context.Comments
                .Include(c => c.Author)
                .Where(c => c.Article.Id == articleId)
                .OrderByDescending(c => c.Id)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            _context.Attach(rating.Author);
            _context.Attach(rating.Article);
            _context.Add(rating);

            await _context.SaveChangesAsync();

            return rating;
        }

        public async Task<Rating> GetByArticleRatingByUserId(
            string userId, 
            int articleId)
        {
            return await _context.Ratings
                .Include(r => r.Article)
                .Where(r => r.Article.Id == articleId && r.Author.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
