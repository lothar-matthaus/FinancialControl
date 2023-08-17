namespace Financial.Control.Domain.Models.Expenses.Response
{
    public interface IExpenseGetResponse : IBaseResponse<ISuccessSingleResponse<IExpenseModel>, IErrorResponse, IExpenseModel>, IBaseResponse
    {
    }
}
