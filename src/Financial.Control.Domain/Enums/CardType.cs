using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum CardType
    {
        [Description("Crédito")]
        Credit = 1,
        [Description("Débito")]
        Debit = 2
    }
}
