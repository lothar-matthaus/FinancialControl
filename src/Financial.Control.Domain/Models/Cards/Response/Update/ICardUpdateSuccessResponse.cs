namespace Financial.Control.Domain.Models.Cards.Response.Update
{
    public interface ICardUpdateSuccessResponse : IBaseSuccessResponse
    {
        public ICardModel Result { get; }
    }
}
