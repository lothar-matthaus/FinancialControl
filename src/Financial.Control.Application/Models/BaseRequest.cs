using MediatR;

namespace Financial.Control.Application.Models
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
    {

    }
}
