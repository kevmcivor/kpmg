using FluentValidation;
using News.API.Models;

namespace News.API.Validators
{
    public class ArticleCreateValidator : AbstractValidator<ArticleCreateDto>
    {
        public ArticleCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(x => x.Title)
                .MaximumLength(1000)
                .WithMessage("Title max length is 1000");
        }
    }
}
