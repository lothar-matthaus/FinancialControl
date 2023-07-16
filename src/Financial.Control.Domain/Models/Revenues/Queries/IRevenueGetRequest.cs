using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Revenues.Queries
{
    public interface IRevenueGetRequest : IBaseRequest
    {
        public long RevenueId { get; set; }
    }
}
