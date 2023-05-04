using Financial.Control.Domain.Constants;
using Financial.Control.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Financial.Control.Domain.Constants.FieldLenght;
using static Financial.Control.Domain.Constants.Patterns;

namespace Financial.Control.Application.Validation.Cards
{
    public class CardNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cardNumber = (value as string).Replace(" ", "");
            if (cardNumber.Length < CardFieldsLenght.CardNumber)
                return new ValidationResult("O cartão informado não está em um formato válido.", new List<string> { validationContext.MemberName });

            if (!CardFlagPattern.Patterns.Any(pattern => Regex.IsMatch(cardNumber, pattern.Value)))
                return new ValidationResult("O cartão informado ainda não é suportado pelo sistema.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
