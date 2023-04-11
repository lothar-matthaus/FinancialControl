using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.FieldLenght;

namespace Financial.Control.Application.Validation.Cards
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected bool IsRequired { get;}

        public NameValidationAttribute(bool isRequired = false)
        {
            IsRequired = isRequired;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsRequired && (value as string).Length < CardFieldsLenght.Name)
                return new ValidationResult($"O campo '{validationContext.MemberName}' precisa ter pelo menos [{CardFieldsLenght.Name}] caracteres.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
