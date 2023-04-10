﻿namespace Financial.Control.Domain.Records
{
    public record UserToken
    {
        public string AccessToken { get; }
        public DateTime ExpirationTime { get; }

        private UserToken(string accessToken, DateTime expirationTime)
        {
            AccessToken = accessToken;
            ExpirationTime = expirationTime;
        }

        public static UserToken Create(string accessToken, DateTime expirationTime) => new UserToken(accessToken, expirationTime);
    }
}
