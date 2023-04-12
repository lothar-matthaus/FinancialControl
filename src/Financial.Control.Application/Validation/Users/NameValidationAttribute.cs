using System.ComponentModel.DataAnnotations;
using static Financial.Control.Domain.Constants.FieldLenght;

namespace Financial.Control.Application.Validation.Users
{
    public class NameValidationAttribute : ValidationAttribute
    {
        private readonly bool IsRequired;

        public NameValidationAttribute(bool isRequired = false)
        {
            IsRequired = isRequired;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsRequired && ((value as string).Length < UserFieldsLenght.Name))
                return new ValidationResult($"O campo '{validationContext.MemberName}' precisa ter pelo menos [{UserFieldsLenght.Name}] caracteres.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
