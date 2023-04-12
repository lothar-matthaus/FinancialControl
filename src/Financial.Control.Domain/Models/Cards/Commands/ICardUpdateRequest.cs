using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Domain.Models.Cards.Commands
{
    public interface ICardUpdateRequest : IBaseRequest
    {
        [Required]
        public long CardId { get; }
        public string CardName { get; }
        public decimal? Limit { get; }
        public int? CardInvoiceDay { get; }
    }
}
