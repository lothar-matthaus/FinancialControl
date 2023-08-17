namespace Financial.Control.Domain.Models.Cards.Response.Update
{
    public interface ICardUpdateResponse : IBaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
