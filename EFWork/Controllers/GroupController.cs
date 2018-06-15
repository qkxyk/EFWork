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
    public class GroupController : Controller
    {
        GroupService _gs = new GroupService();
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddGroup(GroupModel group)
        {
            group.Token = Guid.NewGuid().ToString("N");
            try
            {
                _gs.AddGroup(group);
            }
            catch (Exception)
            {

            }
            return View("Index");
        }

        public ActionResult GetGroupData()
        {
            int pageCount;
            var groups = _gs.GetGroup(1, 10, out pageCount).Select(a => new { Token = a.Token, Name = a.Name, Code = a.Code }).ToList();
            string strGroups = JsonConvert.SerializeObject(groups);
            //JsonResult jr = new JsonResult();
            //jr.Data = strGroups;

            return Content(strGroups);
        }
    }
}