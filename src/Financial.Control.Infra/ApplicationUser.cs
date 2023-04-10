using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Financial.Control.Infra
{
    public class ApplicationUser : IApplicationUser
    {
        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }

        public ApplicationUser(IHttpContextAccessor context)
        {
            Id = long.Parse(context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Sid)).Select(cl => cl.Value).FirstOrDefault() ?? "0");
            Nome = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Name)).Select(cl => cl.Value).FirstOrDefault();
            Email = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Email)).Select(cl => cl.Value).FirstOrDefault();
        }
    }
}
