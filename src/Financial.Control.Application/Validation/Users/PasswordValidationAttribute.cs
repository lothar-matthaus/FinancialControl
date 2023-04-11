using Financial.Control.Application.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Financial.Control.Application.Validation.Users
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if (!Regex.IsMatch(value as string, pattern))
                return new ValidationResult("A senha deve conter: Pelo menos 8 dígitos. Um número. Uma letra minúscula. Uma letra maiúscula. Um caractere especial.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
