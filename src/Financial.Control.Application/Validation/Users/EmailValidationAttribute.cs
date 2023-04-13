using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Financial.Control.Application.Validation.Users
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        private readonly bool _isRequired;

        public EmailValidationAttribute(bool isRequired = false)
        {
            _isRequired = isRequired;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            if (_isRequired && !Regex.IsMatch((value as string), pattern))
                return new ValidationResult("O e-mail informado não está no formato válido.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
