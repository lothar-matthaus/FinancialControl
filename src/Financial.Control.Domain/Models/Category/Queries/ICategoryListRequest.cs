﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Category.Queries
{
    public interface ICategoryListRequest : IBaseRequest
    {
        public string Name { get; }
    }
}
