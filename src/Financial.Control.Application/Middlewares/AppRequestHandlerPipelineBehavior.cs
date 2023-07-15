﻿using Financial.Control.Application.Extensions;
using Financial.Control.Application.Models;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Financial.Control.Application.Middlewares
{
    public sealed class BaseRequestHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse, new()
    {
        private readonly IApplication _app;
        private readonly HttpContext _httpContext;

        public BaseRequestHandlerBehavior(IApplication application, IHttpContextAccessor httpContextAccessor)
        {
            _app = application;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                TResponse response = await next();

                ModelStateDictionary modelState = (request as BaseRequest<TResponse>).GetModelState();

                if (!modelState.IsValid)
                {
                    IReadOnlyCollection<Notification> _notifications = modelState.CreateNotifications(request.GetType().Name);

                    response = new TResponse();
                    response.SetInvalidState(_notifications);
                    _httpContext.Response.SetStatusCode(response.StatusCode);

                    return response;
                }

                _httpContext.Response.SetStatusCode(response.StatusCode);
                _app.UnitOfWork.Commit(cancellationToken);

                return response;
            }
            catch (Exception ex)
            {
                IReadOnlyCollection<Notification> notifications = new List<Notification>() { Notification.Create("Internal Server Error", ex.GetType().Name, new string[] { ex.InnerException?.Message ?? ex.Message }) };
                TResponse response = new TResponse();

                response.SetInvalidState(notifications, HttpStatusCode.InternalServerError);
                _httpContext.Response.SetStatusCode(HttpStatusCode.InternalServerError);

                return response;
            }
        }
    }
}
