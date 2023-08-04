using System.ComponentModel.DataAnnotations;

namespace Financial.Control.Domain.Entities.Base
{
    public class BaseEntity : IValidatableObject
    {
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
