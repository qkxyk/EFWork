using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class GroupModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<DeviceTypeTemplateModel> DeviceTypeTemplateModel { get; set; }
    }
}