namespace Financial.Control.Domain.Interfaces
{
    public interface IApplicationUser
    {
        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
    }
}
