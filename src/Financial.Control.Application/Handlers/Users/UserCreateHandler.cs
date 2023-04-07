using Financial.Control.Application.Models.Users.Commands;
using Financial.Control.Application.Models.Users.Response.Create;
using Financial.Control.Domain.Entities;
using MediatR;
using System.Net;

namespace Financial.Control.Application.Handlers.Users
{
    public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            return UserCreateResponse
                .AsSuccess("Usuário criado com sucesso.", HttpStatusCode.Created, UserCreateSuccessResponse
                    .Create(User
                        .Create("Lothar Matthaus", "lothar1258@hotmail.com", "asdasdasdadsa.com", "asdasdasd")));
        }
    }
}
