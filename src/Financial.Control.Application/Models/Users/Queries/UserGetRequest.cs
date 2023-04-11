using Financial.Control.Application.Models.Users.Response.Get;
using Financial.Control.Domain.Models.Users.Queries;

namespace Financial.Control.Application.Models.Users.Queries
{
    public class UserGetRequest : BaseRequest<UserGetResponse>, IUserGetRequest
    {
        public UserGetRequest() { }
        public static UserGetRequest Create() => new UserGetRequest();
    }

}
