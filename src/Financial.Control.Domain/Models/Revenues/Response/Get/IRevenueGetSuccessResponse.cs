using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Revenues.Response.Get
{
    public interface IRevenueGetSuccessResponse : IBaseSuccessResponse
    {
        public IRevenueModel Result { get;}
    }
}
