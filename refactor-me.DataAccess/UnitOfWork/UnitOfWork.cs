using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            _context = new Entities();
        }

        private Entities _context;

        private ProductDAL _productDAL;

        public ProductDAL ProductDAL
        {
            get { return _productDAL ?? (_productDAL = new ProductDAL(_context)); }
        }

        private ProductOptionDAL _productOptionDAL;

        public ProductOptionDAL ProductOptionDAL
        {
            get { return _productOptionDAL ?? (_productOptionDAL = new ProductOptionDAL(_context)); }
        }

    }
}
