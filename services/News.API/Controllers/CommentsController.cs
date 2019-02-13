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
using System.Security.Claims;


namespace News.API.Controllers
{
    [Route("api/v1/news/comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public CommentsController(
            IArticleRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        [Authorize("Employee")]
        [HttpPost()]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentDto commentDto)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                Article = new Article { Id = commentDto.ArticleId },
                Author = new Author
                {
                    Id = User.Claims.Where(c => c.Type == "sub").First().Value,
                    Name = User.Claims.Where(c => c.Type == "name").First().Value
                }
            };

            return Ok(await _repository.AddComment(comment));
        }
    }
}