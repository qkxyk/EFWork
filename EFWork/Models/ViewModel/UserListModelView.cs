using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class UserListModelView
    {
        public UserListModelView()
        {
            Users = new List<UserModelView>();
        }
        public List<UserModelView> Users { get; set; }
        public bool BSuccess { get; set; }
    }
}