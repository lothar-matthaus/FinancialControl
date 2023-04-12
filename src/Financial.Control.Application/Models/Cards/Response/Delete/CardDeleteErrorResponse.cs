using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Models.Cards.Response.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteErrorResponse : BaseErrorResponse, ICardDeleteErrorResponse
    {
        private CardDeleteErrorResponse(IReadOnlyCollection<Notification> errors) : base(errors)
        {
        }

        public static CardDeleteErrorResponse Create(IReadOnlyCollection<Notification> errors) => new CardDeleteErrorResponse(errors);
    }
}
