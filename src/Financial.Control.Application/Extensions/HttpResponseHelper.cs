using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Application.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class HttpResponseHelper
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        public static void SetStatusCode(this HttpResponse response, HttpStatusCode httpStatusCode) => response.StatusCode = (int) httpStatusCode;
    }
}
