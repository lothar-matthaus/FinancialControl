using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Financial.Control.Application.Models
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
    {
        protected ModelStateDictionary ModelState { get; private set; }
        public void SetModelState(ModelStateDictionary modelState) => ModelState = modelState;
        public ModelStateDictionary GetModelState() => ModelState;
    }
}
