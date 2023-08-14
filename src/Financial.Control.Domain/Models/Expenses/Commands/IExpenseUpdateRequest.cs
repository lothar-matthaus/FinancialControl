namespace Financial.Control.Domain.Models.Expenses.Commands
{
    public interface IExpenseUpdateRequest : IBaseRequest, IBaseIdRequest
    {
        public string Description { get; }
        public long CategoryId { get; }
    }
}
