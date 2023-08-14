using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Get;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Cards.Response.Get
{
    public sealed class CardGetResponse : BaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, ICardGetResponse
    {
        public CardGetResponse() { }

        public CardGetResponse(string message, HttpStatusCode statusCode, ISuccessResponse<ICardModel> success) : base(message, statusCode, success) { }
        public CardGetResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Factory
        public static CardGetResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessResponse<ICardModel> success) => new CardGetResponse(message, statusCode, success);
        public static CardGetResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new CardGetResponse(message, statusCode, error);
        #endregion
        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardGetError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
