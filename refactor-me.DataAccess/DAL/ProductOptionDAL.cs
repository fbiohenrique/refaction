using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.DataAccess.Repository;

namespace refactor_me.DataAccess
{
    public class ProductOptionDAL : Repository<ProductOption>
    {
        public ProductOptionDAL(Entities context) : base(context)
        {
        }
    }
}
