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

        [HttpPost]
        [Authorize("Employee")]
        [HttpPost()]
        public async Task<IActionResult> CreateRatingAsync([FromBody] RatingDto ratingDto)
        {
            var rating = new Rating
            {
                Rate = ratingDto.Rate,
                Article = new Article { Id = ratingDto.ArticleId },
                Author = _mapper.Map<Author>(User)
        };

            return Ok(await _repository.AddRating(rating));
        }
    }
}