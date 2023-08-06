using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum PaymentType
    {
        [Description("Cartão de crédito")]
        CreditCard = 1,
        [Description("Cartão de débito")]
        DebitCard = 2,
        [Description("Dinheiro físico")]
        Money = 3
    }
}
