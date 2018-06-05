using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class DeviceTypeMap:EntityTypeConfiguration<DeviceTypeModel>
    {
        public DeviceTypeMap()
        {
            this.ToTable("DevcieType").HasKey(a=>a.Id);
        }
    }
}