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
    public class TestimonialValidation :AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3, "Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"))
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"));

            RuleFor(x => x.Comment)
                 .MinimumLength(3)
                 .WithMessage(UIMessages.GetMinLengthMessage(3, "Komment"))
                 .MaximumLength(2000)
                 .WithMessage(UIMessages.GetMaxLengthMessage(100, "Komment"))
                 .NotEmpty()
                 .WithMessage(UIMessages.GetRequiredMessage("Komment"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Şəkil daxil edin!");
        }
    }
}
