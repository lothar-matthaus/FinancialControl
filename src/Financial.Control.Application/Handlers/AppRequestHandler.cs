using Financial.Control.Application.Models;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Financial.Control.Application.Handlers
{
    public abstract class AppRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse, new()
    {
        protected readonly IApplication _app;
        private readonly HttpContext _httpContext;

        public AppRequestHandler(IApplication application, HttpContext httpContext)
        {
            _app = application;
            _httpContext = httpContext;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TResponse response = await Handle(request);

                ModelStateDictionary modelState = (request as BaseRequest<TResponse>).GetModelState();

                if (!modelState.IsValid)
                {
                    IReadOnlyCollection<Notification> _notifications = modelState
                                    .Select(ms => ms).ToList().ConvertAll(ms => Notification.Create(request.GetType().Name, ms.Key, ms.Value.Errors.Select(err => err.ErrorMessage)
                                    .ToList()));

                    response = new TResponse();
                    response.SetInvalidState(_notifications);
                    _httpContext.Response.StatusCode = (int)response.StatusCode;

                    return response;
                }

                _app.UnitOfWork.Commit();

                return response;
            }
            catch (Exception ex)
            {
                IReadOnlyCollection<Notification> notifications = new List<Notification>() { Notification.Create("", "", new string[] { ex.InnerException.Message ?? "" }) };
                TResponse response = new TResponse();

                response.SetInvalidState(notifications, ex.Message, HttpStatusCode.InternalServerError);
                _httpContext.Response.StatusCode = (int)response.StatusCode;

                return response;
            }
        }

        public abstract Task<TResponse> Handle(TRequest request);
    }
}
