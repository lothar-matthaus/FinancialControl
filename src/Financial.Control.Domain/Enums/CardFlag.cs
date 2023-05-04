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
        [Description("Elo")]
        Elo = 4,
        [Description("JCB")]
        JCB = 5
    }
}
