using Financial.Control.Domain.Models;

namespace Financial.Control.Application.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public long Id { get; }

        protected BaseModel(long id)
        {
            Id = id;
        }
    }
}
