﻿using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Create;

namespace Financial.Control.Application.Models.Cards.Response.Create
{
    public class CardCreateErrorResponse : BaseErrorResponse, ICardCreateErrorResponse
    {
        private CardCreateErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }

        public static CardCreateErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardCreateErrorResponse(errors);
    }
}
