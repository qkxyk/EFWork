using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class DeviceTypeTemplateMap : EntityTypeConfiguration<DeviceTypeTemplateModel>
    {
        public DeviceTypeTemplateMap()
        {
            this.ToTable("DeviceTypeTemplate").HasKey(a => a.Id);

            this.HasRequired(a => a.Group).WithMany(a => a.DeviceTypeTemplateModel).HasForeignKey(a => a.Token);
            HasRequired(a => a.DeviceType).WithMany(a => a.DeviceTypeTemplateModel).HasForeignKey(a => a.TypeId);
        }
    }
}