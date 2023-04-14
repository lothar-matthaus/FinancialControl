namespace Financial.Control.Domain.Models.Cards.Response.Delete
{
    public interface ICardDeleteSuccessResponse : IBaseSuccessResponse
    {
        public ICardModel Result { get; }
    }
}
