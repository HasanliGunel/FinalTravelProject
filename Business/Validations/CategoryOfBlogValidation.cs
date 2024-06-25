using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class CategoryOfBlogValidation : AbstractValidator<CategoryOfBlog>
    {
        public CategoryOfBlogValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Ad"));

        }
    }
}
