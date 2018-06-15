using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class TypeDefineModel
    {
        public int Id { get; set; }
        public string DataKey { get; set; }//数据标示
        public string DataName { get; set; }//数据名称
        public string Unit { get; set; }//单位
        public string DataType { get; set; }//数据类型
        public string DefaultValue { get; set; }//默认值

        public int TemplateId { get; set; }
        public virtual DeviceTypeTemplateModel DeviceTypeTemplate { get; set; }
    }
}