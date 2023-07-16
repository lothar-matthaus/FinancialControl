using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardCreateHandler : BaseRequestHandler<CardCreateRequest, CardCreateResponse>
    {
        public CardCreateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<CardCreateResponse> Handle(CardCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefaultAsync();

            if (user is null)
                return CardCreateResponse.AsError(UserMessage.UserUpdateError(), HttpStatusCode.NotFound, CardCreateErrorResponse
                    .Create(UserMessage.UserNotFound(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", new string[] { GenericMessage.IdNotExists(_app.CurrentUser.Id) }) }));

            bool cardAlreadyExists = _app.UnitOfWork.Cards.Query(card => card.CardNumber.Equals(request.CardNumber.Replace(" ", ""))).Any();

            if (cardAlreadyExists)
                return CardCreateResponse.AsError(CardMessage.CardCreateError(), HttpStatusCode.Conflict, CardCreateErrorResponse
                    .Create(CardMessage.CardAlreadyExists(request.CardNumber), new List<Notification>() { Notification.Create(request.GetType().Name, string.Empty, null) }));

            Card card = request;

            user.AddCard(card);

            _app.UnitOfWork.Users.Update(user);

            return CardCreateResponse.AsSuccess(CardMessage.CardCreateSuccess(), HttpStatusCode.Created, CardCreateSuccessResponse.Create(card));
        }
    }
}
