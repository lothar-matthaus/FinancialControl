namespace Financial.Control.Domain.Models
{
    public interface IBaseModel
    {
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }
    }
}
