using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Alelo = 4
    }
}
