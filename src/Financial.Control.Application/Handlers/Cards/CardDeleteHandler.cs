using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Delete;
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
    public class CardDeleteHandler : BaseRequestHandler<CardDeleteRequest, CardDeleteResponse>
    {
        public CardDeleteHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }
        public async override Task<CardDeleteResponse> Handle(CardDeleteRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users.Query(user => user.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            Card card = _unitOfWork.Cards
                .Query(card => card.Id.Equals(request.CardId))
                .FirstOrDefault();

            if (card is null)
                return CardDeleteResponse.AsError(CardMessage.CardDeleteError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(CardMessage.CardNotFound(), new List<Notification> { Notification.Create(request.GetType().Name) }));

            user.RemoveCard(card);

            _unitOfWork.Users.Update(user);

            return CardDeleteResponse.AsSuccess(CardMessage.CardDeleteSuccess(), HttpStatusCode.OK, SuccessResponse<ICardModel>.Create(CardModel.Create(card)));
        }
    }
}
