using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Response;
using LoginServer.BL.Cache;
using LoginServer.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        const string AuthorizationHeader = "Authorization";
        IProjectsService _projectsService;
        SessionMemoryCache _sessionMemoryCache;
        public ProjectsController(SessionMemoryCache sessionMemoryCache, IProjectsService projectsService)
        {
            this._sessionMemoryCache = sessionMemoryCache;
            this._projectsService = projectsService;
        }

        [HttpGet]
        //[Authorize] - todo move authentication logic to AuthenticationHandler
        public ActionResult<List<ProjectsDTO>> Get()
        {
            string token = Request.Headers[AuthorizationHeader].FirstOrDefault();
            if (token == null)
            {
                return BadRequest(StatusCodes.Status401Unauthorized);
            }
            token = token.Substring("Bearer".Length).Trim();
            var sessionData = _sessionMemoryCache.Get(token);
            if (sessionData == null)
            {
                return BadRequest(StatusCodes.Status401Unauthorized);
            }
            _sessionMemoryCache.Refresh(token, sessionData);

            int userId = sessionData.UserId;

            return _projectsService.GetUserProjects(userId);
        }
    }
}
