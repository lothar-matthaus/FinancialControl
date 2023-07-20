using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        protected BaseModel(long id, DateTime creationDate, DateTime updateDate)
        {
            Id = id;
            CreationDate = creationDate;
            UpdateDate = updateDate;
        }
    }
}
