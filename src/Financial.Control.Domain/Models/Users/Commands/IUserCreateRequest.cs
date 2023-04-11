using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Financial.Control.Domain.Models.Users.Commands
{
    public interface IUserCreateRequest : IBaseRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
