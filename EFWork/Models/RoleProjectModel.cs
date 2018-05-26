using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class RoleProjectModel
    {
        public int RoleId { get; set; }
        public int ProjectId { get; set; }

        public virtual RoleModel Role { get; set; }
        public virtual ProjectModel Project { get; set; }

    }
}