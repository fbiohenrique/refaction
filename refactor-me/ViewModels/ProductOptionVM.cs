﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.ViewModels
{
    public class ProductOptionVM : IProduct
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}