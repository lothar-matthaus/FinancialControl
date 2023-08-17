namespace Financial.Control.Domain.Models.Cards.Commands
{
    public interface ICardUpdateRequest : IBaseRequest, IUpdateRequest
    {
        public string CardName { get; }
        public decimal? Limit { get; }
        public int? CardInvoiceDay { get; }
    }
}
