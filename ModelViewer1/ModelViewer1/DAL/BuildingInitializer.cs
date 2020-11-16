using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ModelViewer1.Models;


namespace ModelViewer1.DAL
{
    public class BuildingInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<BuildingContext>
    {
        protected override void Seed(BuildingContext context)
        {
            var buildings = new List<BuildingModel>
            {
                new BuildingModel{Id = 1, Architect = "Markus", Name = "Big Villa"},
                new BuildingModel{Id = 2, Architect = "Johan", Name = "Mansion"},
                new BuildingModel{Id = 3, Architect = "Peter", Name = "Apartment complex"},
                new BuildingModel{Id = 4, Architect = "Jaque", Name = "Hotel"}
            };

            buildings.ForEach(b => context.Buildings.Add(b));
        }
    }
}