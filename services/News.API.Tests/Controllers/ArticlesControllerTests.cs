using AutoMapper;
using Moq;
using News.API.Controllers;
using News.Domain.Entities.ArticleAggregate;
using News.Domain.Interfaces;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using News.API.Models;
using AutoFixture;

namespace News.API.Tests
{
    public class ArticlesControllerTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IArticleRepository> _repository;
        private Fixture _fixture;

        public ArticlesControllerTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IArticleRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetWhenCalledRepositoryCallsGetGetArticleAsync()
        {
            var result = await GetController().GetArticleAsync(1);

            _repository.Verify(x => x.GetArticleAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetWhenCalledAndArticleFoundThenMapperMapsArticleToDto()
        {
            var article = _fixture.Build<Article>().Create();
            _repository.Setup(x => x.GetArticleAsync(It.IsAny<int>())).ReturnsAsync(article);

            var result = await GetController().GetArticleAsync(1);

            _mapper.Verify(x => x.Map<ArticleDto>(article), Times.Once);
        }

        [Fact]
        public async Task GetWhenCalledAndArticleNotFoundThenMapperNotMapped()
        {
            var article = _fixture.Build<Article>().Create();
            _repository.Setup(x => x.GetArticleAsync(1)).ReturnsAsync((Article)null);
 
            var result = await GetController().GetArticleAsync(1);

            _mapper.Verify(x => x.Map<ArticleDto>(article), Times.Never);
        }

        [Fact]
        public async Task GetWhenCalledReturnsOkResult()
        {
            _repository.Setup(x => x.GetArticleAsync(It.IsAny<int>())).ReturnsAsync(new Article());

            var result = await GetController().GetArticleAsync(1);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetWhenCalledAndArticleNotFoundReturnsNotFoundResult()
        {
            _repository.Setup(x => x.GetArticleAsync(It.IsAny<int>())).ReturnsAsync((Article)null);

            var result = await GetController().GetArticleAsync(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        private ArticlesController GetController()
        {
            return new ArticlesController(_repository.Object, _mapper.Object);
        }
    }
}
