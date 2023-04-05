using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enum;

namespace Financial.Control.Domain.Entities
{
    public class DebitCard : Card
    {
        protected DebitCard() : base(string.Empty, CardType.Debit) { }
        private DebitCard(string flag) : base(flag, CardType.Debit) { }

        public static DebitCard Create(string flag) => new DebitCard(flag);
    }
}
