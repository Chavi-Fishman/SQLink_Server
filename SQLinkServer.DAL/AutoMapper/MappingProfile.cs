using AutoMapper;
using LoginServer.API.Entities.DTO;
using SqlLinkServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.DAL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Project, ProjectsDTO>();
            CreateMap<ProjectsDTO, Project>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }

    }
}
