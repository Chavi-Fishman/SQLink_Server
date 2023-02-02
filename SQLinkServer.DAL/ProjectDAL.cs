using AutoMapper;
using LoginServer.API.Entities.DTO;
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
    public class ProjectDAL : IProjectDal
    {
        IMapper _mapper;
        IConfiguration _configuration;
        public ProjectDAL(IConfiguration configuration, IMapper mapper)
        {
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public List<ProjectsDTO> GetUserProjects(int userId)
        {
            using (SQLinkProjectContext context = new SQLinkProjectContext(this._configuration.GetConnectionString("sqlLinkConnection")))
            {
                var userProjects = context.Projects.Where(user => user.UserId == userId).Select(pro =>
                _mapper.Map<ProjectsDTO>(pro)
                ).ToList();
                return userProjects;
            }
        }
    }
}
