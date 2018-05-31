using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual ProjectModel Parent { get; set; }
        public virtual ICollection<ProjectModel> Child { get; set; }

        public virtual ICollection<RoleProjectModel> RoleProject { get; set;}
    }
}