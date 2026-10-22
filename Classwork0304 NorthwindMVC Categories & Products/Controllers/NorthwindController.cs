using Classwork0304_NorthwindMVC_Categories___Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classwork0304_NorthwindMVC_Categories___Products.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            NorthwindDbManager manager = new NorthwindDbManager(Properties.Settings.Default.ConStr);
            CategoriesViewModel viewModel = new CategoriesViewModel
            {
                Categories = manager.GetCategories()
            };
            return View(viewModel);
        }

        public ActionResult Products(int categoryId = 1)
        {
            NorthwindDbManager manager = new NorthwindDbManager(Properties.Settings.Default.ConStr);
            ProductsViewModel viewModel = new ProductsViewModel
            {
                Products = manager.GetProductsByCategory(categoryId),
                CategoryName = manager.GetCategoryName(categoryId)
            };
            return View(viewModel);
        }
    }
}