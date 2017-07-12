using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGettingStarted.Models;

namespace WebApiGettingStarted.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Shirt", Price = 20m, Qty = 4},
            new Product { Id = 2, Name = "Pants", Price = 30m, Qty = 5},
            new Product { Id = 3, Name = "Shoes", Price = 40m, Qty = 6}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products.ToList();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.Where(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
