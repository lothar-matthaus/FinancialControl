using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Constants
{
    public class Patterns
    {
        public static class CardFlagPattern
        {
            public const string Mastercard = "^5[1-5][0-9]{14}";
            public const string Visa = "^4[0-9]{12}(?:[0-9]{3})";
            public const string JCB = @"^(?:2131|1800|35\d{3})\d{11}";
            public const string Hipercard = @"^606282|^3841(?:[0|4|6]{1})0";
            public const string Elo = @"/^((((636368)|(438935)|(504175)|(451416)|(636297))\d{0,10})|((5067)|(4576)|(4011))\d{0,12})$/";

            public static Dictionary<CardFlag, string> Patterns { get; } = new() {
                { CardFlag.MasterCard, Mastercard },
                { CardFlag.Visa, Visa},
                { CardFlag.JCB, JCB },
                { CardFlag.Hipercard, Hipercard},
                { CardFlag.Elo, Elo }
            };
        }
    }
}
