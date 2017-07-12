using Application.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Application.Service.Services
{
    public class ProductService : IProductService
    {
        private ProductsEntities db = new ProductsEntities();

        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return db.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SaveData(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return true;
                }
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}