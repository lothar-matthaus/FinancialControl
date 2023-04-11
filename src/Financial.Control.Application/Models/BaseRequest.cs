using Financial.Control.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Financial.Control.Application.Models
{
    public abstract class BaseRequest<TResponse> : Domain.Models.IBaseRequest, IRequest<TResponse> where TResponse : IBaseResponse
    {
        protected ModelStateDictionary ModelState { get; private set; }
        public void SetModelState(ModelStateDictionary modelState) => ModelState = modelState;
        public ModelStateDictionary GetModelState() => ModelState;
    }
}
