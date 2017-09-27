using System;
using System.Net;
using System.Web.Http;
using refactor_me.Core;
using refactor_me.Model;
using System.Collections.Generic;
using refactor_me.ViewModels;
using refactor_me.Util;
using System.Linq;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : BaseApiController
    {
        /*****************************************
         * 
         *  Fabio Henrique Mendonça Oliveira
         *  E-mail: henriquefbio@rocketmail.com
         *  Cel.: 21 256 8228
         * 
         *****************************************/
        #region NEW CODE

        [Route]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            IEnumerable<Product> products = UnitOfWork.ProductDAL.GetAll(true);
            IEnumerable<ProductVM> productsVM = Mapper.Map<IEnumerable<ProductVM>>(products);
            return Result(productsVM);
        }

        [Route]
        [HttpGet]
        public IHttpActionResult SearchByName(string name)
        {
            IEnumerable<Product> products = UnitOfWork.ProductDAL.SearchByName(name);

            if (products.IsNullOrEmpty())
                return NotFound();

            IEnumerable<ProductVM> productsVM = Mapper.Map<IEnumerable<ProductVM>>(products);
            return Result(productsVM);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(Guid id)
        {
            Product product = UnitOfWork.ProductDAL.Find(id);

            if (product == null)
                return NotFound();

            ProductVM productVM = Mapper.Map<ProductVM>(product);

            return Ok(productVM);
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Create(Product product)
        {
            try
            {
                product.Id = Guid.NewGuid();

                if (product.IsValid)
                {
                    UnitOfWork.ProductDAL.Insert(product, true);
                    return Ok();
                }

                return BadRequest("Invalid Product.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(Guid id, Product product)
        {
            try
            {
                Product productDb = UnitOfWork.ProductDAL.Find(id);

                if (productDb == null)
                    return NotFound();

                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                productDb.DeliveryPrice = product.DeliveryPrice;

                if (productDb.IsValid)
                {
                    UnitOfWork.ProductDAL.Update(productDb, true);
                    return Ok();
                }

                return BadRequest("Invalid Product.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                UnitOfWork.ProductDAL.Delete(o => o.Id == id, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IHttpActionResult GetOptions(Guid productId)
        {
            IEnumerable<ProductOption> productOptions = UnitOfWork.ProductOptionDAL.Get(o => o.ProductId == productId);

            if (productOptions.IsNullOrEmpty())
                return BadRequest();

            IEnumerable<ProductOptionVM> productOptionsVM = Mapper.Map<IEnumerable<ProductOptionVM>>(productOptions);
            return Result(productOptionsVM);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public IHttpActionResult GetOption(Guid productId, Guid id)
        {
            IEnumerable<ProductOption> productOptions = UnitOfWork.ProductOptionDAL.Get(o => o.ProductId == productId);

            if (productOptions.IsNullOrEmpty())
                return BadRequest();

            IEnumerable<ProductOptionVM> productOptionsVM = Mapper.Map<IEnumerable<ProductOptionVM>>(productOptions);
            productOptionsVM = productOptionsVM.Where(w => w.Id == id);

            return Result(productOptionsVM);
        }

        [Route("{productId}/options")]
        [HttpPost]
        public IHttpActionResult CreateOption(Guid productId, ProductOption option)
        {
            try
            {
                option.Id = Guid.NewGuid();
                option.ProductId = productId;

                if (option.IsValid)
                {
                    UnitOfWork.ProductOptionDAL.Insert(option, true);
                    return Ok();
                }

                return BadRequest("Invalid Option.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateOption(Guid id, ProductOption option)
        {
            try
            {
                ProductOption productOptionDb = UnitOfWork.ProductOptionDAL.Find(id);

                if (productOptionDb == null)
                    return NotFound();

                productOptionDb.Name = option.Name;
                productOptionDb.Description = option.Description;

                if (productOptionDb.IsValid)
                {
                    UnitOfWork.ProductOptionDAL.Update(productOptionDb, true);
                    return Ok();
                }

                return BadRequest("Invalid Option.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteOption(Guid id)
        {
            try
            {
                UnitOfWork.ProductOptionDAL.Delete(o => o.Id == id, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

    }
}
