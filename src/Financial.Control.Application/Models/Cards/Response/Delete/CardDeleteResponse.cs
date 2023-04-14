using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Delete;
using System.Net;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteResponse : BaseResponse<ICardDeleteSuccessResponse, ICardDeleteErrorResponse>, ICardDeleteResponse
    {
        public CardDeleteResponse() { }
        private CardDeleteResponse(string message, HttpStatusCode statusCode, ICardDeleteSuccessResponse success) : base(message, statusCode, success) { }
        private CardDeleteResponse(string message, HttpStatusCode statusCode, ICardDeleteErrorResponse error) : base(message, statusCode, error) { }

        #region Create
        public static CardDeleteResponse AsSuccess(string message, HttpStatusCode statusCode, ICardDeleteSuccessResponse success) => new CardDeleteResponse(message, statusCode, success);
        public static CardDeleteResponse AsError(string message, HttpStatusCode statusCode, ICardDeleteErrorResponse error) => new CardDeleteResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            throw new NotImplementedException();
        }
    }
}
