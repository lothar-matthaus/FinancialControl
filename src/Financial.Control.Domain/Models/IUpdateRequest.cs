namespace Financial.Control.Domain.Models
{
    public interface IUpdateRequest
    {
        public abstract long Id { get; }
        public abstract void SetRequestId(long id);
    }
}
