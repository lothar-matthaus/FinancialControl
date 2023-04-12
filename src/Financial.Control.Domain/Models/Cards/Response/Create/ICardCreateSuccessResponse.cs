namespace Financial.Control.Domain.Models.Cards.Response.Create
{
    public interface ICardCreateSuccessResponse : IBaseSuccessResponse
    {
        public ICardModel Result { get; }
    }
}
