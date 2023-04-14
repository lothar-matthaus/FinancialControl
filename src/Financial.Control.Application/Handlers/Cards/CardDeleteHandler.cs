using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Delete;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardDeleteHandler : AppRequestHandler<CardDeleteRequest, CardDeleteResponse>
    {
        public CardDeleteHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }
        public async override Task<CardDeleteResponse> Handle(CardDeleteRequest request)
        {
            User user = _app.UnitOfWork.Users.Query(user => user.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            if (user is null)
                return CardDeleteResponse.AsError(CardMessage.CardDeleteError(), HttpStatusCode.NotFound, CardDeleteErrorResponse.Create(new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { UserMessage.UserNotFound() }) }));

            Card card = _app.UnitOfWork.Cards.Query(card => card.Id.Equals(request.CardId))
                .FirstOrDefault();

            if (card is null)
                return CardDeleteResponse.AsError(CardMessage.CardDeleteError(), HttpStatusCode.NotFound, CardDeleteErrorResponse.Create(new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { CardMessage.CardNotFound() }) }));

            user.RemoveCard(card);

            _app.UnitOfWork.Users.Update(user);

            return CardDeleteResponse.AsSuccess(CardMessage.CardDeleteSuccess(), HttpStatusCode.OK, CardDeleteSuccessResponse.Create(card));
        }
    }
}
