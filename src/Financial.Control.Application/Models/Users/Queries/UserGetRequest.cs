using Financial.Control.Application.Models.Users.Response.Get;

namespace Financial.Control.Application.Models.Users.Queries
{
    public class UserGetRequest : BaseRequest<UserGetResponse>
    {
        public UserGetRequest() { }
        public static UserGetRequest Create() => new UserGetRequest();
    }

}
