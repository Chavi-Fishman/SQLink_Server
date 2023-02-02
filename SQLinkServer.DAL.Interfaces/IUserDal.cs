using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Request;
using LoginServer.API.Entities.Response;
using System;

namespace SqlinkServer.DAL.Interfaces
{
    public interface IUserDal
    {
        UserDTO Login(LoginRequest request);
    }
}
