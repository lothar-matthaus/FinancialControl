namespace Financial.Control.Domain.Models.Cards.Response.Get
{
    public interface ICardGetSuccessResponse : IBaseSuccessResponse
    {
        public ICardModel Result { get; }
    }
}
