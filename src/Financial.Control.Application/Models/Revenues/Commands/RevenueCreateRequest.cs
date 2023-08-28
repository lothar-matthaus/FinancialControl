using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues.Commands;

namespace Financial.Control.Application.Models.Revenues.Commands
{
    public class RevenueCreateRequest : BaseRequest<RevenueCreateResponse>, IRevenueCreateRequest
    {
        /// <summary>
        /// Nome para identificar a receita
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Valor da receita do usuário
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Mês referente a receita (mm/AAAA)
        /// </summary>
        public string Date { get; set; }

        public static implicit operator Revenue(RevenueCreateRequest request)
        {
            return Revenue.Create(request.Name, request.Value, DateTime.Parse(request.Date));
        }
    }
}
