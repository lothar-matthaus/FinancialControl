using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Models.Users
{
    public interface IUserModel : IBaseModel
    {
        public string Name { get; }
        public string Email { get; }
        public string ProfilePictureUrl { get; }
    }
}
