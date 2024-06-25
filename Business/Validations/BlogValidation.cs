using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(300, "Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(500)
                .WithMessage(UIMessages.GetMaxLengthMessage(500, "Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.Text)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Mətn"))
                .MaximumLength(5000)
                .WithMessage(UIMessages.GetMaxLengthMessage(5000, "Mətn"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Mətn"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Şəkil daxil edin!");

        }

    }
}
