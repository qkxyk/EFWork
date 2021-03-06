﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace EFWork.Models
{
    public class MenuMap:EntityTypeConfiguration<MenuModel>
    {
        public MenuMap()
        {
            this.ToTable("Menu").HasKey(a => a.Id);

            this.HasOptional(a => a.Parent).WithMany(a => a.Child).HasForeignKey(a => a.ParentId);
        }
    }
}