namespace Financial.Control.Domain.Models.Cards.Response.Get
{
    public interface ICardGetResponse : IBaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
