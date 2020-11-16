using ModelViewer1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ModelViewer1.DAL
{
    public class BuildingContext : DbContext
    {
        public BuildingContext() : base("BuildingContext")
        {
        }
            public DbSet<BuildingModel> Buildings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}