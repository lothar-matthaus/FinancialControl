namespace Financial.Control.Domain.Models.Expenses.Commands
{
    public interface IExpenseUpdateRequest : IBaseRequest, IUpdateRequest
    {
        public string Description { get; }
        public long CategoryId { get; }
    }
}
