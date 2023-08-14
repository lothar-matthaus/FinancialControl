using System.ComponentModel;

namespace Financial.Control.Domain.Enums
{
    public enum AccountStatus
    {
        [Description("Ativa")]
        Active = 1,
        [Description("Bloqueada")]
        Blocked = 2,
        [Description("Removida")]
        Removed = 3
    }
}
