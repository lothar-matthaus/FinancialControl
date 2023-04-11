using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum CardType
    {
        [Description("Crédito")]
        Credit,
        [Description("Débito")]
        Debit
    }
}
