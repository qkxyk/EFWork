using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class UserMap : EntityTypeConfiguration<UserModel>
    {
        public UserMap()
        {
            this.ToTable("User").HasKey(a => a.Id);       
        }
    }
}