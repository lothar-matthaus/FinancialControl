using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Logon.Response
{
    public interface ILoginSuccessResponse : IBaseSuccessResponse
    {
        public ILoginModel Result { get; }
    }
}
