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
            var comment = _mapper.Map<Comment>(commentDto);
            comment.Author = _mapper.Map<Author>(User);

            return Ok(await _repository.AddComment(comment));
        }

        [HttpGet("article/{articleId}", Name = "GetComments")]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetByArticle(int articleId)
        {
            var comments = await _repository.GetCommentsAsync(articleId);

            if (comments == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<CommentDto>>(comments));
        }
    }
}