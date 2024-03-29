﻿using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Logon;
using Financial.Control.Domain.ValueObjects;

namespace Financial.Control.Application.Models.Logon
{
    public class LoginModel : ILoginModel
    {
        public string Name { get; }
        public string Email { get; }
        public UserToken Token { get; }
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        private LoginModel(User user)
        {
            Name = user.Name;
            Email = user.Account.Email.Value;
            Token = user.Account.Token;
            CreationDate = user.CreationDate;
            UpdateDate = user.UpdateDate;
        }

        public static LoginModel Create(User user) => new LoginModel(user);
    }
}
