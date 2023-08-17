using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.List;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Cards.Response.List
{
    public sealed class CardListResponse : BaseResponse<ISuccessListResponse<ICardModel>, IErrorResponse, ICardModel>, ICardListResponse
    {
        public CardListResponse() { }
        private CardListResponse(string message, HttpStatusCode statusCode, ISuccessListResponse<ICardModel> success) : base(message, statusCode, success) { }
        private CardListResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static CardListResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessListResponse<ICardModel> success) => new CardListResponse(message, statusCode, success);
        public static CardListResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new CardListResponse(message, statusCode, error);
        #endregion
        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardListError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
