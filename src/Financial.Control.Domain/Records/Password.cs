namespace Financial.Control.Domain.Records
{
    public record Password
    {
        public string Value { get; private set; }
        public string PlainText { get; }

        protected Password() { }
        private Password(string plainText)
        {
            PlainText = plainText;
        }

        public static Password Create(string plainText) => new Password(plainText);
        public static Password Create() => new Password("");
    }
}