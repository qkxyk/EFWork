using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFWork.Models
{
    public class EFWorkContext:DbContext
    {
        public EFWorkContext():base("EFWork")
        {

        }
        public IDbSet<MenuModel> Menu { get; set; }
        public IDbSet<RoleModel> Role { get; set; }
        public IDbSet<ProjectModel> Project { get; set; }
        public IDbSet<RoleProjectModel> RoleProject { get; set; }
        public IDbSet<UserModel> User { get; set; }
        public IDbSet<UserRoleModel> UserRole { get; set; }
        public IDbSet<DeviceDataModel> DeviceData { get; set; }
        public IDbSet<DeviceModel> Device { get; set; }
        public IDbSet<DeviceTypeModel> DeviceType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new RoleProjectMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DeviceDataMap());
            modelBuilder.Configurations.Add(new DeviceMap());
            modelBuilder.Configurations.Add(new DeviceTypeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}