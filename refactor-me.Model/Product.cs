using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Model
{
    public class Product
    {
        public Product()
        {
            ProductOption = new HashSet<ProductOption>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public virtual ICollection<ProductOption> ProductOption { get; set; }

        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        private bool Validate()
        {
            return !String.IsNullOrEmpty(Name) && Price > 0;
        }
    }
}
