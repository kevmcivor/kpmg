using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.API.Models;
using News.Domain.Entities.ArticleAggregate;
using News.Domain.Interfaces;
using System.Linq;

namespace News.API.Controllers
{
    [Route("api/v1/news/article")]
    [ApiController]
    //[ApiConventionType(typeof(DefaultApiConventions))]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticlesController(
            IArticleRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet("{id:int}", Name = "GetArticle")]
        [ProducesResponseType(typeof(ArticleDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetArticleAsync(int id)
        {
            var newsArticle = await _repository.GetArticleAsync(id);

            var user = User;

            if (newsArticle == null)
            {
                return NotFound();
            }

            var newsArticleDto = _mapper.Map<ArticleDto>(newsArticle);
            
            return Ok(newsArticleDto);
        }

        [HttpPost(Name = "CreateArticle")] //update template
        [Authorize("Admin")]
        [ProducesResponseType(typeof(ArticleDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateArticleAsync(
            [FromBody]ArticleCreateDto newsArticleCreateDTO)
        {
            if (newsArticleCreateDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var article = _mapper.Map<Article>(newsArticleCreateDTO); 
            article.Author = new Author {
                Id = User.Claims.Where(c => c.Type == "sub").First().Value,
                Name = User.Claims.Where(c => c.Type == "name").First().Value
            };

            var newsArticle = await _repository.Add(article); 

            if (newsArticle == null)
            {
                return NotFound();
            }

            var newsArticleDto = _mapper.Map<ArticleDto>(newsArticle);

            return Ok(newsArticleDto);

            //return CreatedAtRoute("GetArticle", new { id = newsArticleDto.Id }, newsArticleDto);
        }

        [HttpPatch(Name = "UpdateArticle")] //update template, use constants
        [Authorize("Admin")]
        [ProducesResponseType(typeof(ArticleCreateDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateArticleAsync([FromBody]ArticleUpdateDto newsArticleUpdateDTO)
        {
            if (newsArticleUpdateDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(_mapper.Map<Article>(newsArticleUpdateDTO));
            }
            catch (Exception ex)
            {
                //log exception
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        [Route("recent")]
        [ProducesResponseType(typeof(IEnumerable<ArticleDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRecentAsync()
        {
            var articles = await _repository.GetRecentAsync();

            if (articles == null)
            {
                return NoContent();
            }

            var output = this._mapper.Map<List<ArticleDto>>(articles);

            return Ok(output);
        }
    }
}