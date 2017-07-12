using Application.Data;
using Application.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService productService = new ProductService();

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            var isSaved = productService.SaveData(product);
            if (isSaved == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            var isUpdated = productService.UpdateProduct(product.Id, product);
            if (isUpdated == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var isDeleted = productService.DeleteProduct(id);
            if (isDeleted == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
