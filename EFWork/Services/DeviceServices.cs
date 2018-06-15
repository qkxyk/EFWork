using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Dynamic;
using EFWork.Models;
using System.Threading.Tasks;

namespace EFWork.Services
{
    public class DeviceServices
    {
        public async Task<IEnumerable<Controllers.Dev>> GetDevice(string order, int pageSize = 5, int currentPage = 1)
        {
            using (var db = new EFWorkContext())
            {
                var data = db.Device.Include(a => a.DeviceType).Include(a => a.DeviceData).Select(a => new Controllers.Dev { DeviceId = a.DeviceId, DeviceName = a.DeviceName, DeviceTypeName = a.DeviceType.Name, Dt = a.DeviceData == null ? default(DateTime): a.DeviceData.Dt, Message = a.DeviceData == null ? "" : a.DeviceData.Message });
                int count = data.Count();
                Console.WriteLine(data.ToString());
                var d = await data.OrderBy(order).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
                return d;
            }
        }
    }
}