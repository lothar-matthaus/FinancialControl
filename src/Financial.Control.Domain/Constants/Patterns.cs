using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Constants
{
    public class Patterns
    {
        public static class CardFlagPattern
        {
            public const string Mastercard = "^5[1-5][0-9]{14}$";
            public const string Visa = "^4[0-9]{12}(?:[0-9]{3})";
            public const string JCB = @"^(?:2131|1800|35\d{3})\d{11}";
            public const string Hipercard = @"^606282|^3841(?:[0|4|6]{1})0";
            public const string Elo = @"^(40117[8-9]|43127[0-9]|438935|451416|457393|457631|457632|504175|627780|636297|636368|636369|65003[1-3]|65003[5-7]|65004[0-9]|65040[5-9]|6504[1-3]|6504[5-9]|65070[0-4]|650720|65098[5-9]|65165[2-9]|6550[0-1][0-9]|65502[0-9]|65503[0-4]|655035)\\d{10}$";

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
