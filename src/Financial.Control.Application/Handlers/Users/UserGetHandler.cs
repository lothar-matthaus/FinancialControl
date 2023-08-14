using Financial.Control.Application.Models;
using Financial.Control.Application.Models.Users;
using Financial.Control.Application.Models.Users.Queries;
using Financial.Control.Application.Models.Users.Response.Get;
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
    public class UserGetHandler : BaseRequestHandler<UserGetRequest, UserGetResponse>
    {
        public UserGetHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager) : base(applicationUser, unitOfWork, notificationManager)
        {
        }

        public async override Task<UserGetResponse> Handle(UserGetRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Users
                .Query(us => us.Id.Equals(_applicationUser.Id)).Include(user => user.Account)
                .FirstOrDefaultAsync();

            return UserGetResponse.AsSuccess(UserMessage.UserGetSuccess(), HttpStatusCode.OK, SuccessResponse<IUserModel>.Create(UserModel.Create(user)));
        }
    }
}
