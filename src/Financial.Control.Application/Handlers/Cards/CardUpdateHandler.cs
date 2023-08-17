using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Update;
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
    public class CardUpdateHandler : BaseRequestHandler<CardUpdateRequest, CardUpdateResponse>
    {
        public CardUpdateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }

        public async override Task<CardUpdateResponse> Handle(CardUpdateRequest request, CancellationToken cancellationToken)
        {
            Card card = await _unitOfWork.Cards
                .Query(card => card.Id.Equals(request.Id) && card.UserId.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            if (card is null)
                return CardUpdateResponse.AsError(CardMessage.CardUpdateError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(CardMessage.CardNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id)) }));

            card.SetName(request.CardName);
            (card as CreditCard).SetCardInvoiceDate(request.CardInvoiceDay);
            (card as CreditCard).SetLimit(request.Limit);

            if (!card.IsValid())
            {
                _notificationManager.AddNotifications(card.GetNotifications());
                return null;
            }

            _unitOfWork.Cards.Update(card);

            return CardUpdateResponse.AsSuccess(CardMessage.CardUpdateSuccess(), HttpStatusCode.OK, SuccessSingleResponse<ICardModel>.Create(CardModel.Create(card)));
        }
    }
}
