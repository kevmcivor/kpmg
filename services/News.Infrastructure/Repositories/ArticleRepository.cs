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

        public async Task<Article> Update(Article article)
        {
            _context.Attach(article.Author);
            _context.Update(article);

            await _context.SaveChangesAsync();

            return await GetArticleAsync(article.Id);
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            _context.Attach(comment.Author);
            _context.Attach(comment.Article);
            _context.Add(comment);

            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            _context.Attach(rating.Author);
            _context.Attach(rating.Article);
            _context.Add(rating);

            await _context.SaveChangesAsync();

            return rating;
        }

        public async Task<int> Delete(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Content)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (article != null)
            {
                _context.Articles.Attach(article);
                _context.Remove(article);
                _context.Remove(article.Content);
            }

            return await _context.SaveChangesAsync();
        }
    }
}
