using Financial.Control.Domain.Entities.Base;
using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities
{
    public class DebitCard : Card
    {
        protected DebitCard() : base() { }
        private DebitCard(string name, CardFlag flag, string number) : base(name, flag, CardType.Debit, number) { }

        public static DebitCard Create(string name, CardFlag flag, string number) => new DebitCard(name, flag, number);
    }
}
