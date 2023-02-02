using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Request;
using LoginServer.API.Entities.Response;
using LoginServer.BL.Cache;
using LoginServer.BL.Interfaces;
using SqlinkServer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.BL.Services
{
    public class AuthService : IAuthService
    {
        IUserDal _userDal;
        SessionMemoryCache _sessionMemoryCache;
        public AuthService(IUserDal userDal, SessionMemoryCache sessionMemoryCache)
        {
            this._userDal = userDal;
            this._sessionMemoryCache = sessionMemoryCache;
        }
        public LoginResponse Login(LoginRequest request)
        {
            var personalDetails =  this._userDal.Login(request);
            if (personalDetails != null)
            {
                var token = Guid.NewGuid().ToString();
                _sessionMemoryCache.Add(token, new ServicesEntities.SessionData { token = token, UserId = personalDetails.UserId });
                return new LoginResponse { Token = token, PersonalDetails = personalDetails };
            }
            return null;
        }
    }
}
