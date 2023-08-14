using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Users;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Update.Password;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    internal class UserUpdatePasswordHandler : BaseRequestHandler<UserUpdatePasswordRequest, UserUpdatePasswordResponse>
    {
        public UserUpdatePasswordHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager) { }

        public override async Task<UserUpdatePasswordResponse> Handle(UserUpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users.Query(us => us.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync(cancellationToken);

            user.Account.SetPassword(request.NewPassword, request.ConfirmNewPassword, request.CurrentPassword);

            if (!user.Account.Password.IsValid())
            {
                _notificationManager.AddNotifications(user.Account.Password.GetNotifications());
                return null;
            }

            _unitOfWork.Users.Update(user);

            return UserUpdatePasswordResponse.AsSuccess(UserMessage.UserUpdatePasswordSuccess(), HttpStatusCode.OK, SuccessResponse<IUserModel>.Create(UserModel.Create(user)));
        }
    }
}
