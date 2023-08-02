using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Delete;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardDeleteHandler : BaseRequestHandler<CardDeleteRequest, CardDeleteResponse>
    {
        public CardDeleteHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }
        public async override Task<CardDeleteResponse> Handle(CardDeleteRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users.Query(user => user.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            Card card = _app.UnitOfWork.Cards
                .Query(card => card.Id.Equals(request.CardId))
                .FirstOrDefault();

            if (card is null)
                return CardDeleteResponse.AsError(CardMessage.CardDeleteError(), HttpStatusCode.BadRequest, CardDeleteErrorResponse
                    .Create(CardMessage.CardNotFound(), new List<Notification> { Notification.Create(request.GetType().Name) }));

            user.RemoveCard(card);

            _app.UnitOfWork.Users.Update(user);

            return CardDeleteResponse.AsSuccess(CardMessage.CardDeleteSuccess(), HttpStatusCode.OK, CardDeleteSuccessResponse.Create(card));
        }
    }
}
