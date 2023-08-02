using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum PaymentType
    {
        [Description("Cartão de crédito")]
        CreditCard,
        [Description("Cartão de débito")]
        DebitCard,
        [Description("Dinheiro físico")]
        Money
    }
}
