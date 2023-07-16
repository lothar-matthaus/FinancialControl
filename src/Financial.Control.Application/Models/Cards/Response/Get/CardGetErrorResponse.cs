using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Models.Cards.Response.Get;

namespace Financial.Control.Application.Models.Cards.Response.Get
{
    public sealed class CardGetErrorResponse : BaseErrorResponse, ICardGetErrorResponse
    {
        private CardGetErrorResponse(string message, IReadOnlyCollection<Notification> errors) : base(message, errors) { }
       
        #region Factory
        public static CardGetErrorResponse Create(string message, IReadOnlyCollection<Notification> errors) => new CardGetErrorResponse(message, errors);
        #endregion
    }
}
