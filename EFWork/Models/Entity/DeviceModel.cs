using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class DeviceModel
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int TypeId { get; set; }

        public virtual DeviceTypeModel DeviceType { get; set; }
        public virtual DeviceDataModel DeviceData { get; set; }
    }
}