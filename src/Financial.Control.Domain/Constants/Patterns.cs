using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Constants
{
    public class Patterns
    {
        public class CardFlagPattern
        {
            public const string Mastercard = "^5[1-5][0-9]{14}";
            public const string Visa = "^4[0-9]{12}(?:[0-9]{3})";
            public const string JBC = @"^(?:2131|1800|35\d{3})\d{11}";
            public const string Hipercard = @"/^(606282\d{10}(\d{3})?)|(3841\d{15})$/";
            public const string Elo = @"/^((((636368)|(438935)|(504175)|(451416)|(636297))\d{0,10})|((5067)|(4576)|(4011))\d{0,12})$/";
        }
    }
}
