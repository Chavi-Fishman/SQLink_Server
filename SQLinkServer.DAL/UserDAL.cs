using AutoMapper;
using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Request;
using LoginServer.API.Entities.Response;
using Microsoft.Extensions.Configuration;
using SqlinkServer.DAL.Interfaces;
using SqlLinkServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.DAL
{
    public class UserDAL : IUserDal
    {
        IMapper _mapper;
        IConfiguration _configuration;
        public UserDAL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public UserDTO Login(LoginRequest request)
        {
            using (SQLinkProjectContext context = new SQLinkProjectContext(this._configuration.GetConnectionString("sqlLinkConnection")))
            {
                var user = context.Users.FirstOrDefault(user => user.Email == request.Email && user.Password == request.Password);
                if (user != null)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
