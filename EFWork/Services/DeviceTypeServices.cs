using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFWork.Models;

namespace EFWork.Services
{
    public class DeviceTypeServices
    {
        public IEnumerable<DeviceTypeModel> GetDeviceType()
        {
            using (var db = new EFWorkContext())
            {
                var DeviceType = db.DeviceType.ToList();
                return DeviceType;
            }
        }

        public IEnumerable<DeviceTypeTemplateModel> GetDeviceTypeTemplate(int typeId, string token)
        {
            using (var db = new EFWorkContext())
            {
                var deviceTemp = db.DeviceTypeTemplate.Where(a => a.TypeId == typeId && a.Token == token).ToList();
                return deviceTemp;
            }
        }
    }
}