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
    public class GuideValidation:AbstractValidator<Guide>
    {
        public GuideValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"));

            RuleFor(x => x.SurName)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Soyad"))
                .MaximumLength(50)
                .WithMessage(UIMessages.GetMaxLengthMessage(50, "Soyad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Soyad"));

            RuleFor(x => x.InstagramLink)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "İnstagram Linki"))
                .MaximumLength(150)
                 .WithMessage(UIMessages.GetMaxLengthMessage(150, "İnstagram Linki"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("İnstagram Linki"));

            RuleFor(x => x.FacebookLink)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Facebook Linki"))
                .MaximumLength(150)
                 .WithMessage(UIMessages.GetMaxLengthMessage(150, "Facebook Linki"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Facebook Linki"));

            RuleFor(x => x.LinkedInLink)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "LinkedIn Linki"))
                .MaximumLength(150)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "LinkedIn Linki"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("LinkedIn Linki"));

            RuleFor(x => x.TwitterLink)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Twitter Linki"))
                .MaximumLength(150)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Twitter Linki"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Twitter Linki"));

        }
    }
}
