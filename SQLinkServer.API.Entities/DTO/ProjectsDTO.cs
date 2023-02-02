using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.API.Entities.DTO
{
    public class ProjectsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Score { get; set; }
        public int? DurationInDays { get; set; }
        public int? BugsCount { get; set; }
        public bool? MadeDadeline { get; set; }
        public int? UserId { get; set; }
    }
}
