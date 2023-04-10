using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Update;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.NotificationEntity;
using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserUpdateHandler : AppRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        public UserUpdateHandler(IApplication application, IHttpContextAccessor httpContextAccessor) : base(application, httpContextAccessor)
        {
        }

        public async override Task<UserUpdateResponse> Handle(UserUpdateRequest request)
        {
            User user = _app.UnitOfWork.Users
                .Query(us => us.Id.Equals(_app.CurrentUser.Id))
                .FirstOrDefault();

            bool emailAlreadyExists = _app.UnitOfWork.Users
                .Query(us => us.Email.Value.Equals(request.Email))
                .Any();

            if (emailAlreadyExists)
                return UserUpdateResponse.AsError($"Erro ao atualizar o usuário o usuário.", HttpStatusCode.Conflict,
                    UserUpdateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, nameof(request.Email), new string[] { $"O e-mail '{request.Email}' informado já está cadastrado no sistema." })
                    }));

            if (user is null)
                return UserUpdateResponse.AsError("Erro ao atualizar o usuário", HttpStatusCode.NotFound,
                    UserUpdateErrorResponse.Create(new List<Notification>()
                    {
                        Notification.Create(request.GetType().Name, string.Empty, new string[]{ "O usuário não está cadastrado"})
                    }));

            user.SetName(request.Name);
            user.SetEmail(request.Email);
            user.SetProfilePictureUrl(request.ProfilePictureUrl);

            _app.UnitOfWork.Users.Update(user);

            return UserUpdateResponse.AsSuccess("Usuário atualizado com sucesso.", HttpStatusCode.OK, UserUpdateSuccessResponse.Create(user));
        }
    }
}
