using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Logon;
using Financial.Control.Application.Models.Logon.Commands;
using Financial.Control.Application.Models.Logon.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Logon;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Logon
{
    public class LoginHandler : BaseRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginHandler(IApplicationUser applicationUser,
            IUnitOfWork unitOfWork,
            INotificationManager notificationManager,
            IAuthenticationService authenticationService) : base(applicationUser, unitOfWork, notificationManager)
        {
            _authenticationService = authenticationService;
        }

        public async override Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users
                 .Query(us => us.Account.Email.Value.Equals(request.Email))
                 .FirstOrDefaultAsync(cancellationToken);

            _authenticationService.Login(user, request.Password, cancellationToken);

            if (user is null || user.Account.Token is null)
                return LoginResponse.AsError(LoginMessage.LoginError(), HttpStatusCode.BadRequest, ErrorResponse.Create(LoginMessage.UserOrPasswordInvalid(), null));

            return LoginResponse.AsSuccess(LoginMessage.LoginSuccess(), HttpStatusCode.OK, SuccessResponse<ILoginModel>.Create(LoginModel.Create(user)));
        }
    }
}
