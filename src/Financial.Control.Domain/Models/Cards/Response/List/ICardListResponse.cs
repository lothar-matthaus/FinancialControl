namespace Financial.Control.Domain.Models.Cards.Response.List
{
    public interface ICardListResponse : IBaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
