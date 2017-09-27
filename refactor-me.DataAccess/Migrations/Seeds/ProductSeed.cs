using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess.Migrations
{
    public class ProductSeed
    {
        public static void Seed(Entities db)
        {
            db.Product.AddOrUpdate(o => o.Id,
               new Product()
               {
                   Id = new Guid("{8F2E9176-35EE-4F0A-AE55-83023D2DB1A3}"),
                   Name = "Samsung Galaxy S7",
                   Description = "Newest mobile product from Samsung.",
                   Price = 1024.99M,
                   DeliveryPrice = 16.99M
               },
               new Product()
               {
                   Id = new Guid("{DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3}"),
                   Name = "Apple iPhone 6S",
                   Description = "Newest mobile product from Apple.",
                   Price = 1299.99M,
                   DeliveryPrice = 15.99M
               }
               );
        }
    }
}
