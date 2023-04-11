using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models
{
    public interface IBaseModel
    {
        public long Id { get; }
    }
}
