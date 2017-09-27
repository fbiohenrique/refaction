﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.ViewModels
{
    public class ProductVM : IProduct
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}