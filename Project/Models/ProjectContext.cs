using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project.Models
{
    public class ProjectContext:DbContext
    {
        public DbSet<Project.Models.Products> Products { get; set; }
        public DbSet<Project.Models.SubCategory> SubCategory { get; set; }
        public DbSet<Project.Models.PrimaryCategory> PrimaryCat { get; set; }
        public DbSet<Project.Models.Schemes> Schemes { get; set; }
        public DbSet<Project.Models.Orders> Orders { get; set; }
    }
}