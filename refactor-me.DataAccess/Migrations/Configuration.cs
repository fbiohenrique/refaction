namespace refactor_me.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<refactor_me.DataAccess.Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(refactor_me.DataAccess.Entities context)
        {
            ProductSeed.Seed(context);
            ProductOptionSeed.Seed(context);
        }
    }
}
