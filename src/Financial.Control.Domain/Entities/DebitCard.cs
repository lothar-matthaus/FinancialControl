using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enum;

namespace Financial.Control.Domain.Entities
{
    public class DebitCard : Card
    {
        protected DebitCard() : base(string.Empty, CardType.Debit, string.Empty) { }
        private DebitCard(string flag, string number) : base(flag, CardType.Debit, number) { }

        public static DebitCard Create(string flag, string number) => new DebitCard(flag, number);
    }
}
