using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Validation
{
    public class ValidationTool
    {
        public static bool Validate(IValidator validator, object entity, out List<ValidationErrorModel> error)
        {
            error = Enumerable.Empty<ValidationErrorModel>().ToList();
            ValidationErrorModel model = null;
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                
                foreach (var item in result.Errors)
                {
                    model = new ValidationErrorModel();
                    model.ErrorMessage = item.ErrorMessage;
                    model.ErrorCode = item.ErrorCode;
                    //error.PropName = item.PropertyName;
                    error.Add(model);
                }
            }
            
            return result.IsValid;


        }
    }
}
