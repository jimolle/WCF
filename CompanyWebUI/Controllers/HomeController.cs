using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyWebUI.ServiceReference;

namespace CompanyWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products;
            string info;
            string info2;

            using (var proxy = new ProductServiceClient())
            {
                info = proxy.Endpoint.Binding.Name;
                info2 = proxy.Endpoint.Address.Uri.ToString();

                products = proxy.GetAllProducts().ToList();
            }
            ViewBag.Info = info;
            ViewBag.Info2 = info2;


            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}