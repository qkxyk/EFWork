using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class GroupMap:EntityTypeConfiguration<GroupModel>
    {
        public GroupMap()
        {
            this.ToTable("Group").HasKey(a => a.Token);
        }
    }
}