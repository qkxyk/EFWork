using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class TypeDefineMap : EntityTypeConfiguration<TypeDefineModel>
    {
        public TypeDefineMap()
        {
            this.ToTable("TypeDefine").HasKey(a => a.Id);

            this.HasRequired(a => a.DeviceTypeTemplate).WithMany(a => a.TypeDefine).HasForeignKey(a => a.TemplateId);
        }
    }
}