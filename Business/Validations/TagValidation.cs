using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class TagValidation:AbstractValidator<Tag>
    {
        public TagValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));
        }
    }
}
