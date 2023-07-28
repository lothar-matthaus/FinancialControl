namespace Financial.Control.Domain.Models
{
    public interface IBaseIdRequest
    {
        public abstract long Id { get; }
        public abstract void SetRequestId(long id);
    }
}
