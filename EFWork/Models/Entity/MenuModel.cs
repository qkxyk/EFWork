using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual MenuModel Parent{get;set;}
        public virtual ICollection<MenuModel> Child { get; set; }

        public virtual ICollection<RoleModel> Roles { get; set; }
    }
}