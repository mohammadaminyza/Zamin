using FluentValidation;
using MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Utilities.Services.Localizations;

namespace Miniblog.Core.ApplicationService.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                .NotNull().WithMessage(translator["Required", nameof(Title)]);

            RuleFor(c => c.Description)
                .NotNull().WithMessage(translator["Required", nameof(Description)]).WithErrorCode("1");
        }
    }
}
