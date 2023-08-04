using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Categories.Response.List
{
    public interface ICategoryListErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
