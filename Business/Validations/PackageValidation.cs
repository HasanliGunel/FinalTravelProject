using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;

namespace Business.Validations
{
    public class PackageValidation:AbstractValidator<Package>
    {
        public PackageValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Açıqlama"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Açıqlama"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"));

        }
    }
}
