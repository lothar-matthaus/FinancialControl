using Financial.Control.Application.Models.Cards;
using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.List;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models.Cards;
using Microsoft.AspNetCore.Http;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardListHandler : BaseRequestHandler<CardListRequest, CardListResponse>
    {
        public CardListHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<CardListResponse> Handle(CardListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Card> cards = _app.UnitOfWork.Cards.Query(card => card.UserId.Equals(_app.CurrentUser.Id));
            IReadOnlyCollection<ICardModel> cardsList = cards.ToList().ConvertAll(card => CardModel.Create(card));

            return CardListResponse.AsSuccess(cardsList.Any() ? CardMessage.CardListSuccess() : CardMessage.CardListNotFound(_app.CurrentUser.Nome),
                System.Net.HttpStatusCode.OK, CardListSuccessResponse.Create(cardsList));
        }
    }
}
