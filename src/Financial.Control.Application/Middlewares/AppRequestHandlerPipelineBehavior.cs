using Financial.Control.Application.Extensions;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Middlewares
{
    public sealed class BaseRequestHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse, new()
    {
        private readonly IApplicationUser _applicationUser;
        private readonly HttpContext _httpContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationManager _notificationManager;

        public BaseRequestHandlerBehavior(IApplicationUser applicationUser, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, INotificationManager notificationManager)
        {
            _applicationUser = applicationUser;
            _httpContext = httpContextAccessor.HttpContext;
            _unitOfWork = unitOfWork;
            _notificationManager = notificationManager;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            List<Notification> notifications = new List<Notification>();

            try
            {
                User user = await _unitOfWork.Users.Query(us => us.Id.Equals(_applicationUser.Id)).FirstOrDefaultAsync(cancellationToken);

                if (_httpContext.User.Identity.IsAuthenticated && user is null)
                {
                    response = new TResponse();
                    notifications.Add(Notification.Create(request.GetType().Name, "Id", UserMessage.UserNotFound()));
                    response.SetInvalidState(UserMessage.UserGetError(), notifications, HttpStatusCode.BadRequest);
                    _httpContext.Response.SetStatusCode(response.StatusCode);

                    return response;
                }

                response = await next();

                if (_notificationManager.HasNotifications())
                {
                    notifications.AddRange(_notificationManager.GetAllNotifications());

                    response = new TResponse();
                    response.SetInvalidState(ValidationMessage.ValidationFailed(), notifications, HttpStatusCode.BadRequest);
                    _httpContext.Response.SetStatusCode(response.StatusCode);

                    return response;
                }

                _httpContext.Response.SetStatusCode(response.StatusCode);
                await _unitOfWork.Commit(cancellationToken);

                return response;
            }
            catch (Exception ex)
            {
                response = new TResponse();

                notifications.Add(Notification.Create(ex.GetType().Name, ex.Source, $"{ex.Message} - {ex.InnerException?.Message}"));
                response.SetInvalidState(ServerMessage.InternalServerError(), notifications, HttpStatusCode.InternalServerError);
                _httpContext.Response.SetStatusCode(HttpStatusCode.InternalServerError);

                return response;
            }
        }
    }
}
