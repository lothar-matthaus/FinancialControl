using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Enums
{
    public enum AccountStatus
    {
        [Description("Ativa")]
        Active,
        [Description("Bloqueada")]
        Blocked,
        [Description("Removida")]
        Removed
    }
}
