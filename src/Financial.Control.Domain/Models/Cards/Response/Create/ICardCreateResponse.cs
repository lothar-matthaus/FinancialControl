namespace Financial.Control.Domain.Models.Cards.Response.Create
{
    public interface ICardCreateResponse : IBaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
