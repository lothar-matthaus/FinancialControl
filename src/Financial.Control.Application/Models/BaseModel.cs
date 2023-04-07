namespace Financial.Control.Application.Models
{
    public abstract class BaseModel
    {
        public long Id { get; }

        protected BaseModel(long id)
        {
            Id = id;
        }
    }
}
