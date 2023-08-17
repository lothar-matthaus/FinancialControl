namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseUpdateResponse : IBaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
