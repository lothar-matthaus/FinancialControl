using Financial.Control.Application.Models.Cards.Queries;
using Financial.Control.Application.Models.Cards.Response.Get;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Financial.Control.Domain.Constants.Message;

namespace Financial.Control.Application.Handlers.Cards
{
    public class CardGetHandler : AppRequestHandler<CardGetRequest, CardGetResponse>
    {
        public CardGetHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor) { }

        public async override Task<CardGetResponse> Handle(CardGetRequest request)
        {
            Card card = _app.UnitOfWork.Cards.Query(card => card.Id.Equals(request.CardId) && card.UserId.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            if (card is null)
                return CardGetResponse.AsError(CardMessage.CardGetError(), HttpStatusCode.NotFound, CardGetErrorResponse
                    .Create(new List<Notification> { Notification.Create(request.GetType().Name, "CardId", new string[] { CardMessage.CardNotFound() }) }));

            return CardGetResponse.AsSuccess(CardMessage.CardGetSuccess(), HttpStatusCode.OK, CardGetSuccessResponse.Create(card));
        }
    }
}
