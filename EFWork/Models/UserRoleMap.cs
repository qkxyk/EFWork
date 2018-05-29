using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class UserRoleMap : EntityTypeConfiguration<UserRoleModel>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole").HasKey(a => a.UserId );

           // HasRequired(a => a.User).WithRequiredDependent(a => a.UserRole).Map(a=>a.MapKey("userId"));
            HasRequired(a => a.User).WithOptional(a => a.UserRole);
            this.HasRequired(a => a.Role).WithMany(a => a.UserRole).HasForeignKey(a => a.RoleId);
        }
    }
}