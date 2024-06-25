using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class ServiceValidation : AbstractValidator<Service>
    {
        public ServiceValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3,"Ad"))
                .MaximumLength(150)
                .WithMessage(UIMessages.GetMaxLengthMessage(150, "Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(200)
                .WithMessage(UIMessages.GetMaxLengthMessage(200, "Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));

            RuleFor(x => x.IconName)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "İkon adı"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "İkon adı"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("İkon adı"));
        }
    }
}
