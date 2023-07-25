using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models
{
    public interface IBaseIdRequest
    {
        public abstract long Id { get; }

        public abstract void SetRequestId(long id);
    }
}
