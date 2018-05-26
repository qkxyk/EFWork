using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class RoleMap:EntityTypeConfiguration<RoleModel>
    {
        public RoleMap()
        {
            this.ToTable("Role").HasKey(a => a.Id);
            HasMany(a => a.Menus).WithMany(a => a.Roles).Map(m => { m.ToTable("RoleMenu");m.MapLeftKey("RoleId");m.MapRightKey("MenuId"); });
        }
    }
}