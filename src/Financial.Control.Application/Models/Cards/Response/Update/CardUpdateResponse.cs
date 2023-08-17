using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Update;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Cards.Response.Update
{
    public sealed class CardUpdateResponse : BaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, ICardUpdateResponse
    {
        public CardUpdateResponse()
        {
        }

        public CardUpdateResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<ICardModel> success) : base(message, statusCode, success)
        {
        }
        public CardUpdateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static CardUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<ICardModel> success) => new CardUpdateResponse(message, statusCode, success);
        public static CardUpdateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new CardUpdateResponse(message, statusCode, error);
        #endregion
        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
    }
}
