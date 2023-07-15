using Financial.Control.Application.Models.Logon.Commands;
using Financial.Control.Application.Models.Logon.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Logon
{
    public class LoginHandler : BaseRequestHandler<LoginRequest, LoginResponse>
    {
        public LoginHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = _app.UnitOfWork.Users
                 .Query(us => us.Account.Email.Value.Equals(request.Email))
                 .Include(us => us.Account)
                 .FirstOrDefault();

            user?.Login(_app.Services.TokenService, request.Password);

            if (user is null || user.Account.Token is null)
                return LoginResponse.AsError(LoginMessage.LoginError(), HttpStatusCode.BadRequest, LoginErrorResponse
                    .Create(new List<Notification> { Notification.Create(request.GetType().Name, string.Empty, new string[] { LoginMessage.UserOrPasswordInvalid() }) }));

            return LoginResponse.AsSuccess(LoginMessage.LoginSuccess(), HttpStatusCode.OK, LoginSuccessResponse.Create(user));
        }
    }
}
