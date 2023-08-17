using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Users;
using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Update.Users;
using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models.Users;
using Financial.Control.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Financial.Control.Domain.Constants.ApplicationMessage;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserUpdateHandler : BaseRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        public UserUpdateHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }

        public async override Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users
                .Query(us => us.Id.Equals(_applicationUser.Id))
                .FirstOrDefaultAsync();

            bool emailAlreadyExists = await _unitOfWork.Users
                .Query(us => us.Account.Email.Value.Equals(request.Email))
                .AnyAsync();

            if (emailAlreadyExists)
                return UserUpdateResponse.AsError(UserMessage.UserUpdateError(), HttpStatusCode.Conflict, ErrorResponse.Create(UserMessage.UserEmailAlreadyExists(request.Email), new List<Notification>() { Notification
                    .Create(request.GetType().Name, nameof(request.Email), GenericMessage.EmailConflict()) }));

            user.SetName(request.Name);
            user.SetEmail(request.Email);
            user.SetProfilePicture(request.ProfilePictureUrl);

            _unitOfWork.Users.Update(user);

            return UserUpdateResponse.AsSuccess(UserMessage.UserUpdateSuccess(), HttpStatusCode.OK, SuccessSingleResponse<IUserModel>.Create(UserModel.Create(user)));
        }
    }
}
