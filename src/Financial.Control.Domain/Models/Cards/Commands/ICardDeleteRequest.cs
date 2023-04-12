namespace Financial.Control.Domain.Models.Cards.Commands
{
    public interface ICardDeleteRequest : IBaseRequest
    {
        public long CardId { get; }
    }
}
