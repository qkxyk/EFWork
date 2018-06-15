using EFWork.Models;
using EFWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EFWork.Controllers
{
    public class DeviceController : Controller
    {
        DeviceTypeServices _dts = new DeviceTypeServices();
        // GET: Device
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDeviceType()
        {
            try
            {
                var dts = _dts.GetDeviceType().Select(a => new { Id = a.Id, Name = a.Name }).ToList();
                var res = new JsonResult();
                #region 测试数据
                //res.Data = dts;
                //var name = "小华";
                //var age = "12";
                //var name1 = "小华";
                //var age1 = "12";
                //res.Data = new object[] { new { name, age }, new { name1, age1 } };//返回一个自定义的object数组  

                //List<DeviceTypeModel> list = new List<DeviceTypeModel>() { new DeviceTypeModel() { Id = 1, Name = "aaa" }, new DeviceTypeModel() { Id = 2, Name = "bbb" } };
                //res.Data = list;
                #endregion
                string strMessage = JsonConvert.SerializeObject(dts);
                res.Data = strMessage;
                //var person = new { Name = "小明", Age = 22, Sex = "男" };
                //res.Data = person;//返回单个对象；  
                res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return res;
                //  return Content(strMessage);
                //return Json(dts, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetDeviceTypeTemp(int typeId)
        {
            var temp = _dts.GetDeviceTypeTemplate(typeId, "00000000000000000000000000000000").Select(a => new { Id = a.Id, Name = a.TemplateName, CreateTime = a.CreateDate, Standard = a.BStandard });
            string strTemp = JsonConvert.SerializeObject(temp);

            return Content(strTemp);
        }
    }
}