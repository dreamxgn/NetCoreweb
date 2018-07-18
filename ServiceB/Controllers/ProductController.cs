using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceB.classs;

namespace ServiceB.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [Route("getproducts")]
        [HttpGet]
        public List<ProductInfo> GetProducts()
        {
            List<ProductInfo> list = new List<ProductInfo>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new ProductInfo() { Name = "产品" + i.ToString(), Price = (float)(i * 0.5) });
            }
            return list;
        }
    }
}