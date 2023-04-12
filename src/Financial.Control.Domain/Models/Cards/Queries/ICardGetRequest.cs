namespace Financial.Control.Domain.Models.Cards.Queries
{
    public interface ICardGetRequest : IBaseRequest
    {
        public long CardId { get; }
    }
}
