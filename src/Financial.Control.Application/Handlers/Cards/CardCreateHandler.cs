using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardCreateHandler : BaseRequestHandler<CardCreateRequest, CardCreateResponse>
    {
        public CardCreateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<CardCreateResponse> Handle(CardCreateRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users.Query(us => us.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            bool cardAlreadyExists = _unitOfWork.Cards.Query(card => card.Number.Equals(request.CardNumber.Replace(" ", ""))).Any();

            if (cardAlreadyExists)
                return CardCreateResponse.AsError(CardMessage.CardCreateError(), HttpStatusCode.Conflict, ErrorResponse
                    .Create(CardMessage.CardAlreadyExists(request.CardNumber), new List<Notification>() { Notification.Create(request.GetType().Name, string.Empty, null) }));

            Card card = request;

            if (!card.IsValid())
            {
                _notificationManager.AddNotifications(card.GetNotifications());
                return null;
            }

            user.AddCard(card);

            _unitOfWork.Users.Update(user);

            return CardCreateResponse.AsSuccess(CardMessage.CardCreateSuccess(), HttpStatusCode.Created, SuccessSingleResponse<ICardModel>.Create(CardModel.Create(card)));
        }
    }
}
