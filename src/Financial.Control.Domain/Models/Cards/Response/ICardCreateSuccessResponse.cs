namespace Financial.Control.Domain.Models.Cards.Response
{
    public interface ICardCreateSuccessResponse : IBaseSuccessResponse
    {
        public ICardModel Result { get; }
    }
}
