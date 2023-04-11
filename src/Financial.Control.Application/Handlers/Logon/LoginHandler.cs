using Financial.Control.Application.Models.Logon.Commands;
using Financial.Control.Application.Models.Logon.Response;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Handlers.Logon
{
    public class LoginHandler : AppRequestHandler<LoginRequest, LoginResponse>
    {
        public LoginHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<LoginResponse> Handle(LoginRequest request)
        {
            User user = _app.UnitOfWork.Users
                 .Query(us => us.Account.Email.Value.Equals(request.Email)).FirstOrDefault();

            if (user is null)
                return LoginResponse.AsError("Usuário não encontrado.", HttpStatusCode.NotFound, LoginErrorResponse.Create(null));

            user.Login(_app.Services.TokenService, request.Password);

            if (user.Account.Token is null)
                return LoginResponse.AsError("Usuário ou senha inválidos.", HttpStatusCode.BadRequest, LoginErrorResponse.Create(null));

            return LoginResponse.AsSuccess("Login feito com sucesso", HttpStatusCode.OK, LoginSuccessResponse.Create(user));
        }
    }
}
