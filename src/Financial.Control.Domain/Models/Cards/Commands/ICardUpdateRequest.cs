using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Domain.Models.Cards.Commands
{
    public interface ICardUpdateRequest : IBaseRequest, IBaseIdRequest
    {
        public string CardName { get; }
        public decimal? Limit { get; }
        public int? CardInvoiceDay { get; }
    }
}
