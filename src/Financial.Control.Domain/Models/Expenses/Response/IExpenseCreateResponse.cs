namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseCreateResponse : IBaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
