using System;
using System.Collections.Generic;

#nullable disable

namespace SqlLinkServer.Model
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Score { get; set; }
        public int? DurationInDays { get; set; }
        public int? BugsCount { get; set; }
        public bool? MadeDadeline { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
