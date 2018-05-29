using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; } = false;

        public virtual ICollection<MenuModel> Menus { get; set; }
        public virtual ICollection<RoleProjectModel> RoleProject { get; set; }
        public virtual ICollection<UserRoleModel> UserRole { get; set; }
    }
}