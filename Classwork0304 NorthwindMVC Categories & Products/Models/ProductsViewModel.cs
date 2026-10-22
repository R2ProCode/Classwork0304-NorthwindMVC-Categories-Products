using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classwork0304_NorthwindMVC_Categories___Products.Models
{
    public class ProductsViewModel
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}