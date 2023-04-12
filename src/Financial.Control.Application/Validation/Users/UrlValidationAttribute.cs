using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Financial.Control.Application.Validation.Users
{
    public class UrlValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";

            if (!Regex.IsMatch(value as string, pattern))
                return new ValidationResult("O formato da URL informada está incorreto.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
