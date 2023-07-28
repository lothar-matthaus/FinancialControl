using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Financial.Control.Application.Validation.Cards
{
    public class RevenueMonthValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string dateString = (string)value;
            DateTime date;

            if (!Regex.IsMatch(dateString, "^(0?[1-9]|1[0-2])[\\/-]\\d{4}$"))
                return new ValidationResult("A data da receita/renda deve estar no formato Mês/Ano.", new List<string> { validationContext.MemberName });

            date = DateTime.Parse(dateString);

            if (date.Month != DateTime.Now.Month || date.Year != DateTime.Now.Year)
                return new ValidationResult("A data da receita/renda deve ser referente ao mês atual.", new List<string> { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
