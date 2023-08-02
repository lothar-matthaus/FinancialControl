using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardGetHandler : BaseRequestHandler<CardGetRequest, CardGetResponse>
    {
        public CardGetHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<CardGetResponse> Handle(CardGetRequest request, CancellationToken cancellationToken)
        {
            Card card = await _app.UnitOfWork.Cards.Query(card => card.Id.Equals(request.Id) && card.UserId.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            if (card is null)
                return CardGetResponse.AsError(CardMessage.CardGetError(), HttpStatusCode.BadRequest, CardGetErrorResponse
                    .Create(CardMessage.CardNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(request.Id) }) }));

            return CardGetResponse.AsSuccess(CardMessage.CardGetSuccess(), HttpStatusCode.OK, CardGetSuccessResponse.Create(card));
        }
    }
}
