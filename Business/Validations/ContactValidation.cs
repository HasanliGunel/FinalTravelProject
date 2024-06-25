using Business.BaseMessages;
using Entities.Concrete.TableModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));

            RuleFor(x => x.Email)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Email"))
                .EmailAddress()
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Email"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Email"));

            RuleFor(x => x.Subject)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Basşlıq"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Basşlıq"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Basşlıq"));
            
            RuleFor(x => x.Message)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Mesaj"))
                .MaximumLength(2000)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Mesaj"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Mesaj"));


        }
    }
}
