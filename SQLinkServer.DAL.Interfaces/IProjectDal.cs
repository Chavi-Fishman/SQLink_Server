using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlinkServer.DAL.Interfaces
{
    public interface IProjectDal
    {
        List<ProjectsDTO> GetUserProjects(int userId);
    }
}
