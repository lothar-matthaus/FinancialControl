using Financial.Control.Application.Models.Expenses.Response;
using Financial.Control.Application.Validation.Cards;
using Financial.Control.Domain.Enums;
using Financial.Control.Domain.Models.Expenses.Commands;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Expenses.Commands
{
    public class ExpenseCreateRequest : BaseRequest<ExpenseCreateResponse>, IExpenseCreateRequest
    {
        [Required(ErrorMessage = "Uma descrição para a despesa é obrigatório.")]
        [MinLength(5, ErrorMessage = "A descrição precisa ter pelo menos 5 carateres.")]
        public string Description { get; set; }

        [CardNumberValidation]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "O valor da despesa deve ser informado.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        public PaymentType PaymentType { get; set; }
        public int Installment { get; set; }

        [Required(ErrorMessage = "O identificador da categoria é obrigatória.")]
        [IdValidation]
        public long CategoryId { get; set; }
    }
}
