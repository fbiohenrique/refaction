using AutoMapper;
using refactor_me.DataAccess;
using refactor_me.Model;
using refactor_me.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace refactor_me.Core
{
    public class BaseApiController : ApiController
    {
        private UnitOfWork _unitOfWork;

        protected UnitOfWork UnitOfWork
        {
            get { return _unitOfWork ?? (_unitOfWork = new UnitOfWork()); }
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapper.Mapper.Instance;
            }
        }

        public IHttpActionResult Result(IEnumerable<IProduct> enumerable)
        {
            if (enumerable.Count() > 1)
                return Ok(new { Items = enumerable });

            return Ok(enumerable);
        }
    }
}