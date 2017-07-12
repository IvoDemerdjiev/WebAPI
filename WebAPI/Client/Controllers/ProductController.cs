using Client.Models;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductClient pc = new ProductClient();
            ViewBag.lisProducts = pc.FindAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productVM)
        {
            ProductClient pc = new ProductClient();
            pc.Create(productVM.Product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductClient pc = new ProductClient();
            pc.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ProductClient pc = new ProductClient();
            ProductViewModel productVM = new ProductViewModel();
            //productVM.Product = pc. TO DO
            return RedirectToAction("Edit", productVM);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productVM)
        {
            ProductClient pc = new ProductClient();
            pc.Edit(productVM.Product);
            return RedirectToAction("Index");
        }
    }
}