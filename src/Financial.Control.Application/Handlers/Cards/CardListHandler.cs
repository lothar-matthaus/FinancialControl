using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.List;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardListHandler : BaseRequestHandler<CardListRequest, CardListResponse>
    {
        public CardListHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<CardListResponse> Handle(CardListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Card> cards = await _unitOfWork.Cards.Query(card => card.UserId.Equals(_applicationUser.Id)).ToListAsync();
            IReadOnlyCollection<ICardModel> cardsList = cards.ToList().ConvertAll(card => CardModel.Create(card));

            return CardListResponse.AsSuccess(cardsList.Any() ? CardMessage.CardListSuccess() : CardMessage.CardListNotFound(_applicationUser.Nome),
                System.Net.HttpStatusCode.OK, SuccessListResponse<ICardModel>.Create(cardsList));
        }
    }
}
