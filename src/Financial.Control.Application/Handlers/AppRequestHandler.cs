using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Models;
using Financial.Control.Domain.Repository;
using MediatR;

namespace Financial.Control.Application.Handlers
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse, new()
    {
        protected readonly IApplicationUser _applicationUser;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly INotificationManager _notificationManager;


        public BaseRequestHandler(IApplicationUser applicationUser, IUnitOfWork unitOfWork, INotificationManager notificationManager)
        {
            _applicationUser = applicationUser;
            _unitOfWork = unitOfWork;
            _notificationManager = notificationManager;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
