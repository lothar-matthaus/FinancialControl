﻿using Financial.Control.Domain.Models.Revenues;

namespace Financial.Control.Domain.Models.Users.Response.Get
{
    public interface IUserGetResponse : IBaseResponse<ISuccessSingleResponse<IUserModel>, IErrorResponse, IUserModel>, IBaseResponse
    {
    }
}
