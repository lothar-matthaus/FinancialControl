using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Extensions
{
    public static class HttpResponseHelper
    {
        public static void SetStatusCode(this HttpResponse response, HttpStatusCode httpStatusCode) => response.StatusCode = (int)httpStatusCode;
    }
}
