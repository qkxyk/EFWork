using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class RoleProjectMap:EntityTypeConfiguration<RoleProjectModel>
    {
        public RoleProjectMap()
        {
            this.ToTable("RoleProject").HasKey(a => new { a.RoleId, a.ProjectId });

            this.HasRequired(a => a.Role).WithMany(a => a.RoleProject).HasForeignKey(a => a.RoleId);
            this.HasRequired(a => a.Project).WithMany(a => a.RoleProject).HasForeignKey(a => a.ProjectId);
        }
    }
}