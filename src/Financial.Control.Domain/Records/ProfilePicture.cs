namespace Financial.Control.Domain.Records
{
    public record ProfilePicture
    {
        public string Value { get; set; }

        protected ProfilePicture() { }
        private ProfilePicture(string value)
        {
            Value = value;
        }

        public static ProfilePicture Create(string value) => new ProfilePicture(value);
    }
}
