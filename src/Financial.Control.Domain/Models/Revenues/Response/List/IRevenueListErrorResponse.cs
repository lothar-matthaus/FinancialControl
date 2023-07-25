﻿using Financial.Control.Domain.Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Revenues.Response.List
{
    public interface IRevenueListErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}