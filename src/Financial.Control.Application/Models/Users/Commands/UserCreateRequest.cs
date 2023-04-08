using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Application.Models.Users.Commands
{
    public class UserCreateRequest : BaseRequest<UserCreateResponse>
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail inserido está no formato inválido.")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        [MinLength(8 ,ErrorMessage = "O campo 'Password' deve possuir no mínimo [8] caracteres.")]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "O campo 'ConfirmPassword' é obrigatório.")]
        [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "O campo 'PictureProfileUrl' é obrigatório.")]
        public string ProfilePictureUrl { get; set; }
    }
}
