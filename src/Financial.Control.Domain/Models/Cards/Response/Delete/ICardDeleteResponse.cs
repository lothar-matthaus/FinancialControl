namespace Financial.Control.Domain.Models.Cards.Response.Delete
{
    public interface ICardDeleteResponse : IBaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
