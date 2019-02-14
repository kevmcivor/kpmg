using FluentValidation.TestHelper;
using News.API.Validators;
using Xunit;

namespace News.API.Tests.Validators
{
    public class ArticleCreateValidatorTests
    {
        private ArticleCreateValidator _validator;

        public ArticleCreateValidatorTests()
        {
            _validator = new ArticleCreateValidator();
        }

        [Fact]
        public void ValidatorShouldHaveErrorWhenTitleIsNull()
        {
            _validator.ShouldHaveValidationErrorFor(article => article.Title, null as string);
        }

        [Fact]
        public void ValidatorShouldHaveErrorWhenTitleIsEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(article => article.Title, string.Empty);
        }

        [Fact]
        public void ValidatorShouldNotHaveErrorWhenTitleIsSpecified()
        {
            _validator.ShouldNotHaveValidationErrorFor(article => article.Title, "Title");
        }
    }
}

