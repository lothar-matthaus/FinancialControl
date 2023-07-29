using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Control.Application.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class FinancialControlController : ControllerBase
    {
        protected readonly IMediator _mediatR;

        public FinancialControlController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
    }
}
