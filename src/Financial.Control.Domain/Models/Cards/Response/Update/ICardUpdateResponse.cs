namespace Financial.Control.Domain.Models.Cards.Response.Update
{
    public interface ICardUpdateResponse : IBaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, IBaseResponse
    {
    }
}
