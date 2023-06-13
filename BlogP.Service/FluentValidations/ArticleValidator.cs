using BlogP.Entity.Entities;
using FluentValidation;

namespace BlogP.Service.FluentValidations
{
    public class ArticleValidator: AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(150)
                .WithName("Başlık");

            RuleFor(x => x.Content)
               .NotEmpty()
               .NotNull()
               .MinimumLength(1)
               .MaximumLength(150)
               .WithName("İçerik");
        }
    }
}
