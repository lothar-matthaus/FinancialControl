using Financial.Control.Domain.Enums;

namespace Financial.Control.Domain.Entities
{
    public class DebitCard : Card
    {
        protected DebitCard() : base() { }
        private DebitCard(string name, string number) : base(name, CardType.Debit, number) { }

        public static DebitCard Create(string name, string number) => new DebitCard(name, number);
    }
}
