using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFWork.Models
{
    public class UserRoleModel
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}