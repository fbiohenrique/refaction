using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess
{
    public class Entities : DbContext
    {
        public Entities() : base(System.Configuration.ConfigurationManager.AppSettings["Connection"])
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductOptionConfiguration());
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOption> ProductOption { get; set; }
    }
}
