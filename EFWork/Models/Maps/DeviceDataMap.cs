using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;


namespace EFWork.Models
{
    public class DeviceDataMap : EntityTypeConfiguration<DeviceDataModel>
    {
        public DeviceDataMap()
        {
            this.ToTable("DeviceData").HasKey(a => a.Id);
        }
    }
}