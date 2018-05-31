using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class DeviceDataModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public DateTime Dt { get; set; } = DateTime.Now;
    }
}