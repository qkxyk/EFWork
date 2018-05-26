using EFWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllTopProject(int pageNo = 1, int pageSize = 5)
        {
            using (var db = new EFWorkContext())
            {
                var d = db.Project.Where(a => a.ParentId == null);
                int dataCount = d.Count();
                var m = d.OrderBy(a => a.Id).Skip((pageNo - 1) * pageSize).Take(pageSize);
                ProjectResponse pr = new ProjectResponse();
                pr.PageNo = pageNo;
                pr.PageSize = pageSize;
                pr.DataCount = dataCount;
                pr.PageCount = (int)Math.Ceiling((decimal)dataCount / pageSize);
                foreach (var item in m)
                {
                    pr.Projects.Add(new Project() { Id = item.Id, Name = item.Name, ParentId = item.ParentId });
                }
                return Json(pr, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAllProject(int role, int pageNo = 1, int pageSize = 5)
        {
            using (var db = new EFWorkContext())
            {
                var d = from m in db.Project where m.ParentId==null && m.RoleProject.Any(a => a.RoleId == role) select m;
                int dataCount = d.Count();
                var p = d.OrderBy(a => a.Id).Skip((pageNo - 1) * pageSize).Take(pageSize);
                ProjectResponse pr = new ProjectResponse();
                pr.PageNo = pageNo;
                pr.PageSize = pageSize;
                pr.DataCount = dataCount;
                pr.PageCount = (int)Math.Ceiling((decimal)dataCount / pageSize);
                foreach (var item in p)
                {
                    pr.Projects.Add(new Project() { Id = item.Id, Name = item.Name, ParentId = item.ParentId });
                }
                return Json(pr, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}