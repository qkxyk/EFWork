using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    //设备类型模版，和设备类型的关系是多对1的关系，和设备类型模版定义是1对多的关系
    public class DeviceTypeTemplateModel
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool BStandard { get; set; } = false;//是否标准模版

        public string Token { get; set; }
        public virtual GroupModel Group { get; set; }
        public int TypeId { get; set; }
        public virtual DeviceTypeModel DeviceType { get; set; }
        public virtual ICollection<TypeDefineModel> TypeDefine { get; set; }
    }
}