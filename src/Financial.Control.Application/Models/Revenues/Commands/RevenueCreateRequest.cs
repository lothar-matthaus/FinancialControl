using Financial.Control.Application.Models.Revenues.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Revenues.Commands;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Revenues.Commands
{
    public class RevenueCreateRequest : BaseRequest<RevenueCreateResponse>, IRevenueCreateRequest
    {
        /// <summary>
        /// Nome para identificar a receita
        /// </summary>
        [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
        [MinLength(4, ErrorMessage = "O campo 'Name' deve possuir pelo menos [4] caracteres")]
        public string Name { get; set; }

        /// <summary>
        /// Valor da receita do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo 'Value' é obrigatório.")]
        [DefaultValue(0)]
        public decimal Value { get; set; }

        public static implicit operator Revenue(RevenueCreateRequest request)
        {
            return Revenue.Create(request.Name, request.Value);
        }
    }
}
