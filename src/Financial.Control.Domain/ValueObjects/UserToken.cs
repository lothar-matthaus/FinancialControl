namespace Financial.Control.Domain.ValueObjects
{
    public record UserToken
    {
        public string AccessToken { get; }
        public DateTime ExpirationTime { get; }

        public UserToken() { }
        private UserToken(string accessToken, DateTime expirationTime)
        {
            AccessToken = accessToken;
            ExpirationTime = expirationTime;
        }

        public static UserToken Create(string accessToken, DateTime expirationTime) => new UserToken(accessToken, expirationTime);
    }
}
