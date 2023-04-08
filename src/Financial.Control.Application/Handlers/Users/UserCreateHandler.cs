using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : AppRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public UserCreateHandler(IApplication application,
            IHttpContextAccessor httpContextAccessor) : 
            base(application, httpContextAccessor.HttpContext) { }

        public async override Task<UserCreateResponse> Handle(UserCreateRequest request)
        {
            User user = User.Create(request.Name, request.Email, request.ProfilePictureUrl, request.Password);
            _app.UnitOfWork.Users.Add(user);

            return UserCreateResponse.AsSuccess("Usuário criado com sucesso.", HttpStatusCode.Created, UserCreateSuccessResponse.Create(user));
        }
    }
}
