using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards.Response.List;
using System.Net;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Models.Cards.Response.List
{
    public sealed class CardListResponse : BaseResponse<ICardListSuccessResponse, ICardListErrorResponse>, IBaseResponse
    {
        public CardListResponse() { }

        public CardListResponse(string message, HttpStatusCode statusCode, ICardListSuccessResponse success) : base(message, statusCode, success) { }
        public CardListResponse(string message, HttpStatusCode statusCode, ICardListErrorResponse error) : base(message, statusCode, error) { }
        
        #region Factory
        public static CardListResponse AsSuccess(string message, HttpStatusCode statusCode, ICardListSuccessResponse success) => new CardListResponse(message, statusCode, success);
        public static CardListResponse AsError(string message, HttpStatusCode statusCode, ICardListErrorResponse error) => new CardListResponse(message, statusCode, error);
        #endregion
        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardListError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = CardListErrorResponse.Create(errors);
        }
    }
}
