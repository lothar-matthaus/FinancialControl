using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Users;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Repository;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : BaseRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public UserCreateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public async override Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            bool emailAlreadyExists = await _unitOfWork.Users.EmailAlreadyExists(request.Email);

            if (emailAlreadyExists)
                _notificationManager.AddNotification(Notification.Create(request.GetType().Name, nameof(request.Email), UserMessage.UserEmailAlreadyExists(request.Email)));

            Account account = Account.Create(request.Email, request.ProfilePictureUrl, request.Password, request.ConfirmPassword);
            User user = User.Create(request.Name, account);

            if (!user.IsValid())
                _notificationManager.AddNotifications(user.GetNotifications());

            await _unitOfWork.Users.AddAsync(user, cancellationToken);

            return UserCreateResponse.AsSuccess(UserMessage.UserCreateSuccess(), HttpStatusCode.Created, SuccessSingleResponse<IUserModel>.Create(UserModel.Create(user)));
        }
    }
}
