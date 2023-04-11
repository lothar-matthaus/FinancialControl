using Financial.Control.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.Message;
using static System.Net.Mime.MediaTypeNames;

namespace Financial.Control.Application.Validation.Users
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = "/^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+\\.([a-z]+)?$/i";

            if (!Regex.IsMatch((value as string), pattern))
                return new ValidationResult("O e-mail informado não está no formato válido.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
