using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class AdvantageValidation : AbstractValidator<Advantage>
    {
        public AdvantageValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(250, "Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.IconName)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ikon adı"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(150, "Ikon adı"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ikon adı"));
        }
    }
}
