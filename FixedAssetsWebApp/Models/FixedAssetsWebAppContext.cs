using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FixedAssetsWebApp.Models
{
    public class FixedAssetsWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FixedAssetsWebAppContext() : base("FixedAssetsWebAppContext")
        {
            // Prevent EF from recreating DB in the program that has already existed.
            Database.SetInitializer<FixedAssetsWebAppContext>(null);
        }

        public DbSet<Assets> Assets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removes pluralization of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
