namespace Financial.Control.Domain.Models.Cards.Response.List
{
    public interface ICardListResponse : IBaseResponse<ISuccessListResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
