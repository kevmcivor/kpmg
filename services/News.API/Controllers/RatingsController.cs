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
    [Route("api/v1/news/rating")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public RatingsController(
            IArticleRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(Name = "CreateRating")]
        [Authorize("Employee")]
        public async Task<IActionResult> CreateRatingAsync([FromBody] RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            rating.Author = _mapper.Map<Author>(User);

            return Ok(await _repository.AddRating(rating));
        }

        [HttpGet("employee/article/{articleId}", Name = "GetArticleRatingByUser")]
        [Authorize("Employee")]
        [ProducesResponseType(typeof(RatingDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetArticleRatingByUser(int articleId)
        {
            var userId = User.Claims.Where(c => c.Type == "sub").First().Value;
            var rating = await _repository.GetByArticleRatingByUserId(userId, articleId);

            if (rating == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<RatingDto>(rating));
        }
    }
}