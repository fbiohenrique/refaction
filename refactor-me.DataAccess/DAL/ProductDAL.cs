using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.DataAccess.Repository;
using refactor_me.Model;
using refactor_me.Util;

namespace refactor_me.DataAccess
{
    public class ProductDAL : Repository<Product>
    {
        public ProductDAL(Entities context) : base(context)
        {
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            IEnumerable<Product> products = Get(o => Utility.CompareInsensitive(o.Name, name, true));
            return products;
        }
    }
}
