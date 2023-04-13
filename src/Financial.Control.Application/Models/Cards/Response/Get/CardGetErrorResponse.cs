using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Get;

namespace Financial.Control.Application.Models.Cards.Response.Get
{
    public sealed class CardGetErrorResponse : BaseErrorResponse, ICardGetErrorResponse
    {
        private CardGetErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors) { }
        #region Factory
        public static CardGetErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardGetErrorResponse(errors);
        #endregion
    }
}
