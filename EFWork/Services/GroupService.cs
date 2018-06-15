using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFWork.Models;

namespace EFWork.Services
{
    public class GroupService
    {
        public void AddGroup(GroupModel entity)
        {
            using (var db = new EFWorkContext())
            {
                db.Group.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<GroupModel> GetGroup(int pageNo, int pageSize, out int pageCount)
        {
            using (var db = new EFWorkContext())
            {
                var group = db.Group;
                pageCount = group.Count();
                pageCount = (int)Math.Ceiling((decimal)pageCount / pageSize);
                var d = group.OrderBy(a => a.Name).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                return d;
            }
        }
    }
}