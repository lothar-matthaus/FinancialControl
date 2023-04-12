using System.ComponentModel.DataAnnotations;
using static Financial.Control.Domain.Constants.FieldLenght;

namespace Financial.Control.Application.Validation.Cards
{
    public class CardNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value as string).Length < CardFieldsLenght.CardNumber)
                return new ValidationResult("O cartão informado não está em um formato válido.", new List<string> { validationContext.MemberName });


            return ValidationResult.Success;
        }
    }
}
