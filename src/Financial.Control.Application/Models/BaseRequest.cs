using Financial.Control.Domain.Models;
using MediatR;

namespace Financial.Control.Application.Models
{
    public abstract class BaseRequest<TResponse> : Domain.Models.IBaseRequest, IRequest<TResponse> where TResponse : IBaseResponse
    {
    }
}
