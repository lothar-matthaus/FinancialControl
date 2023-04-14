using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardCreateHandler : AppRequestHandler<CardCreateRequest, CardCreateResponse>
    {
        public CardCreateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<CardCreateResponse> Handle(CardCreateRequest request)
        {
            User user = _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            bool cardAlreadyExists = _app.UnitOfWork.Cards.Query(card => card.CardNumber.Equals(request.CardNumber)).Any();

            if (cardAlreadyExists)
                return CardCreateResponse.AsError(CardMessage.CardCreateError(), HttpStatusCode.Conflict, CardCreateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, string.Empty, new string[]{ CardMessage.CardAlreadyExists(request.CardNumber)})
                    }));

            if (user is null)
                return CardCreateResponse.AsError(UserMessage.UserUpdateError(), HttpStatusCode.NotFound, CardCreateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, string.Empty, new string[]{ UserMessage.UserNotFound()})
                    }));

            Card card = request;

            user.AddCard(card);

            _app.UnitOfWork.Users.Update(user);

            return CardCreateResponse.AsSuccess(CardMessage.CardCreateSuccess(), HttpStatusCode.Created, CardCreateSuccessResponse.Create(card));
        }
    }
}
