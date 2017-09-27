using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Model
{
    public class ProductOption
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        private bool Validate()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
}
