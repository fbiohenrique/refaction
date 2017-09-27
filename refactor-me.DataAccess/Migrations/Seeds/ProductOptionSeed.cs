﻿using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess.Migrations
{
    public class ProductOptionSeed
    {
        public static void Seed(Entities db)
        {
            db.ProductOption.AddOrUpdate(o => o.Id,
               new ProductOption()
               {
                   Id = new Guid("{0643CCF0-AB00-4862-B3C5-40E2731ABCC9}"),
                   ProductId = new Guid("{8F2E9176-35EE-4F0A-AE55-83023D2DB1A3}"),
                   Name = "White",
                   Description = "White Samsung Galaxy S7"
               },
               new ProductOption()
               {
                   Id = new Guid("{A21D5777-A655-4020-B431-624BB331E9A2}"),
                   ProductId = new Guid("{8F2E9176-35EE-4F0A-AE55-83023D2DB1A3}"),
                   Name = "Black",
                   Description = "Black Samsung Galaxy S7"
               },
               new ProductOption()
               {
                   Id = new Guid("{5C2996AB-54AD-4999-92D2-89245682D534}"),
                   ProductId = new Guid("{DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3}"),
                   Name = "Rose Gold",
                   Description = "Gold Apple iPhone 6S"
               },
               new ProductOption()
               {
                   Id = new Guid("{9AE6F477-A010-4EC9-B6A8-92A85D6C5F03}"),
                   ProductId = new Guid("{DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3}"),
                   Name = "White",
                   Description = "White Apple iPhone 6S"
               },
               new ProductOption()
               {
                   Id = new Guid("{4E2BC5F2-699A-4C42-802E-CE4B4D2AC0EF}"),
                   ProductId = new Guid("{DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3}"),
                   Name = "Black",
                   Description = "Black Apple iPhone 6S"
               }
               );
        }
    }
}
