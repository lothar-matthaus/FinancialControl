using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Create;
using System.Net;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Models.Cards.Response.Create
{
    public class CardCreateResponse : BaseResponse<ICardCreateSuccessResponse, ICardCreateErrorResponse>, ICardCreateResponse
    {
        public CardCreateResponse()
        {
        }
        private CardCreateResponse(string message, HttpStatusCode statusCode, ICardCreateSuccessResponse success) : base(message, statusCode, success)
        {
        }
        private CardCreateResponse(string message, HttpStatusCode statusCode, ICardCreateErrorResponse error) : base(message, statusCode, error)
        {
        }

        #region Behaviors
        public static CardCreateResponse AsSuccess(string message, HttpStatusCode statusCode, ICardCreateSuccessResponse success) => new CardCreateResponse(message, statusCode, success);
        public static CardCreateResponse AsError(string message, HttpStatusCode statusCode, ICardCreateErrorResponse error) => new CardCreateResponse(message, statusCode, error);

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            Message = CardMessage.CardCreateError();
            StatusCode = statusCode ?? HttpStatusCode.BadRequest;
            Error = CardCreateErrorResponse.Create(errors);
        }
        #endregion
    }
}
