using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            try
            {
                using (var proxy = new ProductServiceClient())
                {
                    products = proxy.GetAllProducts().ToList();

                    info = proxy.Endpoint.Binding.Name;
                    info2 = proxy.Endpoint.Address.Uri.ToString();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                // TODO kastar igen under debug...
                throw;
            }

            ViewBag.Info = info;
            ViewBag.Info2 = info2;

            return View(products);
        }

        public ActionResult About()
        {
            List<Product> products;

            using (var proxy = new ProductServiceClient())
            {
                products = proxy.GetAllProducts().Where(n => n.Category == "Verktyg och maskiner").ToList();
            }
            return View(products);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}