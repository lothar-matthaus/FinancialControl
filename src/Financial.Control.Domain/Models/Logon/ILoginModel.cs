using Financial.Control.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Logon
{
    public interface ILoginModel
    {
        public string Name { get; }
        public string Email { get; }
        public UserToken Token { get; }
    }
}
