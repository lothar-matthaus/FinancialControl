namespace Financial.Control.Domain.Records
{
    public record Email
    {
        public string Value { get; set; }

        protected Email() { }
        private Email(string value)
        {
            Value = value;
        }
        public static Email Create(string value) => new Email(value);
    }
}
