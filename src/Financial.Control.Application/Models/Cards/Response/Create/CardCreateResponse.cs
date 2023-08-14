using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Create;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Cards.Response.Create
{
    public class CardCreateResponse : BaseResponse<ISuccessResponse<ICardModel>, IErrorResponse, ICardModel>, ICardCreateResponse
    {
        public CardCreateResponse()
        {
        }
        private CardCreateResponse(string message, HttpStatusCode statusCode, ISuccessResponse<ICardModel> success) : base(message, statusCode, success)
        {
        }
        private CardCreateResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static CardCreateResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessResponse<ICardModel> success) => new CardCreateResponse(message, statusCode, success);
        public static CardCreateResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new CardCreateResponse(message, statusCode, error);

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = ErrorResponse.Create(message, errors);
        }
        #endregion
    }
}
