namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseListResponse : IBaseResponse<ISuccessListResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
