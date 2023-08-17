using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Delete;
using System.Net;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteResponse : BaseResponse<ISuccessSingleResponse<ICardModel>, IErrorResponse, ICardModel>, ICardDeleteResponse
    {
        public CardDeleteResponse() { }
        private CardDeleteResponse(string message, HttpStatusCode statusCode, ISuccessSingleResponse<ICardModel> success) : base(message, statusCode, success) { }
        private CardDeleteResponse(string message, HttpStatusCode statusCode, IErrorResponse error) : base(message, statusCode, error) { }

        #region Create
        public static CardDeleteResponse AsSuccess(string message, HttpStatusCode statusCode, ISuccessSingleResponse<ICardModel> success) => new CardDeleteResponse(message, statusCode, success);
        public static CardDeleteResponse AsError(string message, HttpStatusCode statusCode, IErrorResponse error) => new CardDeleteResponse(message, statusCode, error);
        #endregion

        public void SetInvalidState(string message, IReadOnlyCollection<Notification> errors, HttpStatusCode? statusCode = null)
        {
            throw new NotImplementedException();
        }
    }
}
