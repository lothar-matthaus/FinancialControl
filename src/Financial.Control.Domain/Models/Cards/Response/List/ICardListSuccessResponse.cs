namespace Financial.Control.Domain.Models.Cards.Response.List
{
    public interface ICardListSuccessResponse : IBaseSuccessResponse
    {
        public IReadOnlyCollection<ICardModel> Result { get; }
    }
}
