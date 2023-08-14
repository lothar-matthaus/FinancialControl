namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseCreateResponse : IBaseResponse<ISuccessResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
