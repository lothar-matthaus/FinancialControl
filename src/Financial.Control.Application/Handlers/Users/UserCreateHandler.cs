using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : AppRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public UserCreateHandler(IApplication application,
            IHttpContextAccessor httpContextAccessor) :
            base(application, httpContextAccessor)
        { }

        public async override Task<UserCreateResponse> Handle(UserCreateRequest request)
        {
            bool emailAlreadyExists = _app.UnitOfWork.Users.Query(us => us.Email.Value.Equals(request.Email)).Any();

            if (emailAlreadyExists)
                return UserCreateResponse.AsError($"Erro ao cadastrar o usuário.", HttpStatusCode.Conflict,
                    UserCreateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, nameof(request.Email), new string[] { $"O e-mail '{request.Email}' informado já está cadastrado no sistema." })
                    }));

            User user = User.Create(request.Name, request.Email, request.ProfilePictureUrl, request.Password);
            _app.UnitOfWork.Users.Add(user);

            return UserCreateResponse.AsSuccess("Usuário criado com sucesso.", HttpStatusCode.Created, UserCreateSuccessResponse.Create(user));
        }
    }
}
