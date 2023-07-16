using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Financial.Control.Application.Handlers
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse, new()
    {
        protected readonly IApplication _app;
        private readonly HttpContext _httpContext;

        public BaseRequestHandler(IApplication application, IHttpContextAccessor httpContextAccessor)
        {
            _app = application;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
