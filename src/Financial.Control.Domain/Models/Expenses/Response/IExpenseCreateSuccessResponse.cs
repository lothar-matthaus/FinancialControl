namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseCreateSuccessResponse : IBaseSuccessResponse
    {
        public IExpenseModel Result { get; }
    }
}
