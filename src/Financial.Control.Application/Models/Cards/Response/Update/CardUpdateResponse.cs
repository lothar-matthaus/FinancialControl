using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards.Response.Update;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Models.Cards.Response.Update
{
    public sealed class CardUpdateResponse : BaseResponse<ICardUpdateSuccessResponse, ICardUpdateErrorResponse>, IBaseResponse
    {
        public CardUpdateResponse()
        {
        }

        public CardUpdateResponse(string message, HttpStatusCode statusCode, ICardUpdateSuccessResponse success) : base(message, statusCode, success)
        {
        }
        public CardUpdateResponse(string message, HttpStatusCode statusCode, ICardUpdateErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static CardUpdateResponse AsSuccess(string message, HttpStatusCode statusCode, ICardUpdateSuccessResponse success) => new CardUpdateResponse(message, statusCode, success);
        public static CardUpdateResponse AsError(string message, HttpStatusCode statusCode, ICardUpdateErrorResponse error) => new CardUpdateResponse(message, statusCode, error);
        #endregion
        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = CardUpdateErrorResponse.Create(errors);
        }
    }
}
