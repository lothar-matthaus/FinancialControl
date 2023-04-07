using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserCreateRequest : BaseRequest<UserCreateResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ProfilePictureUrl { get; set; }
    }
}
