using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.BL.Interfaces
{
    public interface IProjectsService
    { 
        List<ProjectsDTO> GetUserProjects(int userId);
    }
}
