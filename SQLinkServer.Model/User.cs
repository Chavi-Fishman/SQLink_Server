using System;
using System.Collections.Generic;

#nullable disable

namespace SqlLinkServer.Model
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public DateTime JoinedAt { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
