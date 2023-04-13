using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards;
using Financial.Control.Domain.Models.Cards.Response.Get;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Financial.Control.Application.Models.Cards.Response.Get
{
    public sealed class CardGetSuccessResponse : BaseSuccessResponse, ICardGetSuccessResponse
    {
        public ICardModel Result { get; }
        private CardGetSuccessResponse(Card card) => Result = CardModel.Create(card);
        
        #region Factory
        public static CardGetSuccessResponse Create(Card card) => new CardGetSuccessResponse(card);
        #endregion
    }
}
