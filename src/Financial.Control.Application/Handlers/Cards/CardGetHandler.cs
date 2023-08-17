using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.Get;
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
    public class CardGetHandler : BaseRequestHandler<CardGetRequest, CardGetResponse>
    {
        public CardGetHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<CardGetResponse> Handle(CardGetRequest request, CancellationToken cancellationToken)
        {
            Card card = await _unitOfWork.Cards.Query(card => card.Id.Equals(request.Id) && card.UserId.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            if (card is null)
                return CardGetResponse.AsError(CardMessage.CardGetError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(CardMessage.CardNotFound(), new List<Notification> { Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id)) }));

            return CardGetResponse.AsSuccess(CardMessage.CardGetSuccess(), HttpStatusCode.OK, SuccessSingleResponse<ICardModel>.Create(CardModel.Create(card)));
        }
    }
}
