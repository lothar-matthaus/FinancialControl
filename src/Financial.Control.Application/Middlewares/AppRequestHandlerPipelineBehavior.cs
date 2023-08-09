using Financial.Control.Application.Extensions;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

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
            List<Notification> notifications = new List<Notification>();
            TResponse response;

            try
            {
                User user = await _app.UnitOfWork.Users.Query(us => us.Id.Equals(_app.CurrentUser.Id)).FirstOrDefaultAsync(cancellationToken);

                if (_httpContext.User.Identity.IsAuthenticated && user is null)
                {
                    response = new TResponse();
                    response.SetInvalidState(UserMessage.UserGetError(), new List<Notification>() { Notification.Create(request.GetType().Name, "Id", UserMessage.UserNotFound()) }, HttpStatusCode.BadRequest);

                    return response;
                }

                response = await next();

                if (_app.Services.NotificationManager.HasNotifications())
                {
                    IReadOnlyCollection<Notification> _notifications = _app.Services.NotificationManager.GetAllNotifications();

                    response = new TResponse();
                    response.SetInvalidState(ValidationMessage.ValidationFailed(), _notifications);
                    _httpContext.Response.SetStatusCode(response.StatusCode);

                    return response;
                }

                _httpContext.Response.SetStatusCode(response.StatusCode);
                await _app.UnitOfWork.Commit(cancellationToken);

                return response;
            }
            catch (Exception ex)
            {
                response = new TResponse();
                notifications.Add(Notification.Create(ex.GetType().Name, ex.Source, $"{ex.Message} - {ex.InnerException?.Message}"));
                _httpContext.Response.SetStatusCode(HttpStatusCode.InternalServerError);
                response.SetInvalidState(ServerMessage.InternalServerError(), notifications, HttpStatusCode.InternalServerError);
                return response;
            }
        }
    }
}
