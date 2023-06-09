﻿using Financial.Control.Application.Models.Cards.Commands;
using Financial.Control.Application.Models.Cards.Response.Update;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardUpdateHandler : AppRequestHandler<CardUpdateRequest, CardUpdateResponse>
    {
        public CardUpdateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<CardUpdateResponse> Handle(CardUpdateRequest request)
        {
            Card card = _app.UnitOfWork.Cards
                .Query(card => card.Id.Equals(request.CardId) && card.UserId.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            if (card is null)
                return CardUpdateResponse.AsError(CardMessage.CardUpdateError(), HttpStatusCode.NotFound, CardUpdateErrorResponse
                    .Create(new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { CardMessage.CardNotFound() }) }));

            card.SetName(request.CardName);
            (card as CreditCard).SetCardInvoiceDate(request.CardInvoiceDay);
            (card as CreditCard).SetLimit(request.Limit);

            _app.UnitOfWork.Cards.Update(card);

            return CardUpdateResponse.AsSuccess(CardMessage.CardUpdateSuccess(), HttpStatusCode.OK, CardUpdateSuccessResponse.Create(card));
        }
    }
}
