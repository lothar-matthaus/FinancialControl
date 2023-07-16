using System.ComponentModel;

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
