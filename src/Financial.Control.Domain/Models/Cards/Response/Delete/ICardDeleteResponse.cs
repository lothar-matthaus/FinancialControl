namespace Financial.Control.Domain.Models.Cards.Response.Delete
{
    public interface ICardDeleteResponse : IBaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
