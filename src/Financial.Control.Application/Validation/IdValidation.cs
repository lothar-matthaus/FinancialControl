using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.FieldLenght;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Application.Validation.Cards
{
    public class IdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            long id = (long)value;

            if (id == default)
                return new ValidationResult($"O id '{id}' informado não é válido.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
