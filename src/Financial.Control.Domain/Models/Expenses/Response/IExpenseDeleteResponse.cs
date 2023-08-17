namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseDeleteResponse : IBaseResponse<ISuccessResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
