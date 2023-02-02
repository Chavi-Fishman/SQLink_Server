using LoginServer.API.Entities.Request;
using LoginServer.API.Entities.Response;
using LoginServer.API.Filters;
using LoginServer.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
       
        [HttpPost]
        [Route("login")]
        [ValidateModel]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                return _authService.Login(request);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());//todo write to log file
                return BadRequest("unknown error");
            }
        }

    }
}
