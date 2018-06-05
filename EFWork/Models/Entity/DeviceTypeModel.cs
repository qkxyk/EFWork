using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class DeviceTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DeviceModel> Devices { get; set; }
    }
}