namespace Financial.Control.Domain.Models.Cards.Response.Create
{
    public interface ICardCreateResponse : IBaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
