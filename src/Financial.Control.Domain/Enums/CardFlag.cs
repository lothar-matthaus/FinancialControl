using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum CardFlag
    {
        [Description("Mastercard")]
        MasterCard = 1,
        [Description("Visa")]
        Visa = 2,
        [Description("Hipercard")]
        Hipercard = 3,
        [Description("Alelo")]
        Alelo = 4,
        [Description("JDC")]
        JBC = 5
    }
}
