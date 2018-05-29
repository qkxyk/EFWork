using EFWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using System.Linq.Dynamic;

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

        public async Task<ActionResult> GetAllProject(int role, int pageNo = 1, int pageSize = 5)
        {
            using (var db = new EFWorkContext())
            {
                //var d =  from m in db.Project where m.ParentId == null && m.RoleProject.Any(a => a.RoleId == role) select m;
                var d = db.Project.Where(a => a.Parent == null && a.RoleProject.Any(b => b.RoleId == role));
                int dataCount = d.Count();
                var p = await d.OrderBy(a => a.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
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

        public async Task<ActionResult> GetAllMenu(int role, int pageNo = 1, int pageSize = 5)
        {
            using (var db = new EFWorkContext())
            {
                //var d =  from m in db.Project where m.ParentId == null && m.RoleProject.Any(a => a.RoleId == role) select m;
                var d = db.Menu.Where(a => a.Parent == null && a.Roles.Any(b => b.Id == role));
                int dataCount = d.Count();
                //var p = await d.OrderBy(a => a.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();

                //var orderExpression = string.Format("{0} {1}", sortName, sortType); //sortName排序的名称 sortType排序类型 （desc asc）
                var orderExpression = string.Format("{0} {1}", "id", "desc"); //sortName排序的名称 sortType排序类型 （desc asc）
                var p = await d.OrderBy(orderExpression).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
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
        public ActionResult GetUserInfo()
        {
            using (var db = new EFWorkContext())
            {
                var d = db.User.Include(a => a.UserRole.Role);
                UserListModelView ul = new UserListModelView();
                foreach (var item in d)
                {
                    UserModelView u = new UserModelView();
                    u.Id = item.Id;
                    u.Name = item.Name;

                    if (item.UserRole != null)
                    {
                        u.RoleId = item.UserRole.RoleId;
                        u.RoleName = item.UserRole.Role.Name;
                        u.IsAdmin = item.UserRole.Role.IsAdmin;
                    }
                    else
                    {

                    }
                    ul.Users.Add(u);
                }
                return Json(ul, JsonRequestBehavior.AllowGet);
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

    public static class DBHelper
    {
        public static IQueryable<T> DataSort<T>(IQueryable<T> source, string sortExpression, string sortDirection)
        {
            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }
        public static IQueryable<T> DataPaging<T>(IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip(pageNumber * pageSize).Take(pageSize);
        }
        public static IQueryable<T> Sorting<T>(IQueryable<T> source, string sortExpression, string sortDirection, int pageNumber, int pageSize)
        {
            IQueryable<T> query = DataSort<T>(source, sortExpression, sortDirection);
            return DataPaging(query, pageNumber, pageSize);
        }
    }
}