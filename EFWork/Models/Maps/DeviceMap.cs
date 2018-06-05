using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class DeviceMap:EntityTypeConfiguration<DeviceModel>
    {
        public DeviceMap()
        {
            this.ToTable("Device").HasKey(a => a.DeviceId);

            this.HasRequired(a => a.DeviceType).WithMany(a => a.Devices).HasForeignKey(a => a.TypeId);

            this.HasOptional(a => a.DeviceData).WithRequired(a => a.Device);
        }
    }
}