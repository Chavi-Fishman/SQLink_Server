using LoginServer.API.Entities.DTO;
using LoginServer.API.Entities.Response;
using LoginServer.BL.Interfaces;
using SqlinkServer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.BL.Services
{
    public class ProjectsService:IProjectsService
    {
        IProjectDal _projectDal;
        public ProjectsService(IProjectDal projectDal)
        {
            this._projectDal = projectDal;
        }
        public List<ProjectsDTO> GetUserProjects(int userId)
        {
           return this._projectDal.GetUserProjects(userId); 
        }
    }
}
