namespace Financial.Control.Domain.Models.Cards.Response.Get
{
    public interface ICardGetResponse : IBaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
