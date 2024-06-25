using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class HomeSlideValidation:AbstractValidator<HomeSlide>
    {
        public HomeSlideValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Şəkil daxil edin!");
        }
    }
}
