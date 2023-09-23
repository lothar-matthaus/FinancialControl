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
            Card card = await _unitOfWork.Cards
                .Query(card => card.Id.Equals(request.Id) &&
                      (card.User.Id.Equals(_applicationUser.Id))).FirstOrDefaultAsync(cancellationToken);

            if (card is null)
                return CardDeleteResponse.AsError(CardMessage.CardDeleteError(), HttpStatusCode.BadRequest, ErrorResponse
                    .Create(CardMessage.CardNotFound(), Notification.Create(request.GetType().Name, "Id", GenericMessage.IdNotExists(request.Id))));

            _unitOfWork.Cards.Delete(card);

            return CardDeleteResponse.AsSuccess(CardMessage.CardDeleteSuccess(), HttpStatusCode.OK, SuccessResponse<ICardModel>.Create(CardModel.Create(card)));
        }
    }
}
