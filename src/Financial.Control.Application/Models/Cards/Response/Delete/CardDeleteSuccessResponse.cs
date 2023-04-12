using Financial.Control.Domain.Models.Cards.Response.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Models.Cards.Response.Delete
{
    public sealed class CardDeleteSuccessResponse : BaseSuccessResponse, ICardDeleteSuccessResponse
    {
        public string Message { get; }
        private CardDeleteSuccessResponse(string message) => Message = message;
        public static CardDeleteSuccessResponse Create(string message) => new CardDeleteSuccessResponse(message);
    }
}
