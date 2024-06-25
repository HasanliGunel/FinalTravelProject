using Core.Validation;
using System.Text;

namespace Core.Extension
{
    public static class CollectionExtensionMethods
    {
        public static string ValidationErrorMessagesWithNewLine(this List<ValidationErrorModel> errors)
        {
            StringBuilder sb = new();

            foreach (var error in errors)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(error.PropName);
                sb.Append(Environment.NewLine);
                //sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
