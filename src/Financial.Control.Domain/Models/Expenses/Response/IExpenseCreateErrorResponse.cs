using Financial.Control.Domain.Entities.Notifications;

namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseCreateErrorResponse : IBaseErrorResponse
    {
        public new string Message { get; }
        public new IReadOnlyCollection<Notification> Errors { get; }
    }
}
