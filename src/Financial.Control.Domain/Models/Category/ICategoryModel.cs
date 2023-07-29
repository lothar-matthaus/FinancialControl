using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Category
{
    public interface ICategoryModel : IBaseModel
    {
        public new long Id { get; }
        public string Name { get; }
    }
}
